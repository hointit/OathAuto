using OathAuto.Models;
using SmartBot;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;

namespace OathAuto.Services
{
  public class DatabaseService
  {
    private readonly string _connectionString;

    public DatabaseService(string dbPath)
    {
      if (!File.Exists(dbPath))
      {
        throw new FileNotFoundException($"Database file not found: {dbPath}");
      }
      _connectionString = $"Data Source={dbPath};Version=3;";

      // Ensure settings table exists
      CreateSettingsTableIfNotExists();
    }

    private void CreateSettingsTableIfNotExists()
    {
      using (var connection = new SQLiteConnection(_connectionString))
      {
        connection.Open();

        string createTableQuery = @"
          CREATE TABLE IF NOT EXISTS PlayerSettings (
            PlayerId INTEGER PRIMARY KEY,
            IsTraining INTEGER DEFAULT 0,
            IsAutoUpLevel INTEGER DEFAULT 0,
            IsAutoUseX2Exp INTEGER DEFAULT 0,
            IsAutoUseResetLevelItem INTEGER DEFAULT 0,
            IsAutoUseAddPointItem INTEGER DEFAULT 0,
            MaxLevel INTEGER DEFAULT 130,
            ResetLevelItemIndex INTEGER DEFAULT 0,
            AddPointItemIndex INTEGER DEFAULT 0,
            FixedX INTEGER DEFAULT 0,
            FixedY INTEGER DEFAULT 0,
            FixedMapId INTEGER DEFAULT 0,
            FixedMapName TEXT DEFAULT '',
            UseItemWithoutTraining INTEGER DEFAULT 0,
            IsTowerMode INTEGER DEFAULT 0,
            IsAutoMoveEnabled INTEGER DEFAULT 1,
            TowerPositionsJson TEXT DEFAULT '',
            SelectedSkillIdsJson TEXT DEFAULT '',
            CheckedItemIndexesJson TEXT DEFAULT ''
          )";

        using (var command = new SQLiteCommand(createTableQuery, connection))
        {
          command.ExecuteNonQuery();
        }

        // Add new columns if they don't exist (for database migration)
        AddColumnIfNotExists(connection, "PlayerSettings", "IsAutoUseResetLevelItem", "INTEGER DEFAULT 0");
        AddColumnIfNotExists(connection, "PlayerSettings", "IsAutoUseAddPointItem", "INTEGER DEFAULT 0");
        AddColumnIfNotExists(connection, "PlayerSettings", "Mode", "INTEGER DEFAULT 0");

        // Migrate data from IsTraining/IsTowerMode to Mode
        MigrateToModeColumn(connection);
      }
    }

    private void MigrateToModeColumn(SQLiteConnection connection)
    {
      try
      {
        // Update Mode based on IsTraining and IsTowerMode
        // Mode: 0 = None, 1 = Training, 2 = FightTower
        string migrateQuery = @"
          UPDATE PlayerSettings
          SET Mode = CASE
            WHEN IsTowerMode = 1 THEN 2
            WHEN IsTraining = 1 THEN 1
            ELSE 0
          END
          WHERE Mode = 0 AND (IsTraining = 1 OR IsTowerMode = 1)";

        using (var command = new SQLiteCommand(migrateQuery, connection))
        {
          int rowsAffected = command.ExecuteNonQuery();
          if (rowsAffected > 0)
          {
            Debug.WriteLine($"Migrated {rowsAffected} rows from IsTraining/IsTowerMode to Mode");
          }
        }
      }
      catch (Exception ex)
      {
        Debug.WriteLine($"Error migrating to Mode column: {ex.Message}");
      }
    }

    private void AddColumnIfNotExists(SQLiteConnection connection, string tableName, string columnName, string columnDefinition)
    {
      try
      {
        // Check if column exists
        string checkQuery = $"PRAGMA table_info({tableName})";
        bool columnExists = false;

        using (var command = new SQLiteCommand(checkQuery, connection))
        using (var reader = command.ExecuteReader())
        {
          while (reader.Read())
          {
            if (reader["name"].ToString() == columnName)
            {
              columnExists = true;
              break;
            }
          }
        }

        // Add column if it doesn't exist
        if (!columnExists)
        {
          string alterQuery = $"ALTER TABLE {tableName} ADD COLUMN {columnName} {columnDefinition}";
          using (var command = new SQLiteCommand(alterQuery, connection))
          {
            command.ExecuteNonQuery();
            Debug.WriteLine($"Added column {columnName} to table {tableName}");
          }
        }
      }
      catch (Exception ex)
      {
        Debug.WriteLine($"Error adding column {columnName}: {ex.Message}");
      }
    }

    public List<Skill> GetSkillsByMenpai(string menpai)
    {
      var skills = new List<Skill>();

      using (var connection = new SQLiteConnection(_connectionString))
      {
        connection.Open();

        string query = @"SELECT menpai, skillbook, bookslot, skillid, skillname,
                               ragerequired, pkslot, trainslot, buffperiod,
                               isattack, isbuff, special, comment
                        FROM Skillset
                        WHERE menpai = @menpai";

        using (var command = new SQLiteCommand(query, connection))
        {
          command.Parameters.AddWithValue("@menpai", menpai);

          using (var reader = command.ExecuteReader())
          {
            while (reader.Read())
            {
              var skill = new Skill
              {
                Menpai = reader["menpai"].ToString(),
                SkillBook = Convert.ToInt32(reader["skillbook"]),
                BookSlot = Convert.ToInt32(reader["bookslot"]),
                SkillId = reader["skillid"] != DBNull.Value ? Convert.ToInt32(reader["skillid"]) : 0,
                SkillName = reader["skillname"]?.ToString() ?? string.Empty,
                RageRequired = reader["ragerequired"] != DBNull.Value ? Convert.ToInt32(reader["ragerequired"]) : 0,
                PkSlot = reader["pkslot"] != DBNull.Value ? Convert.ToInt32(reader["pkslot"]) : 0,
                TrainSlot = reader["trainslot"] != DBNull.Value ? Convert.ToInt32(reader["trainslot"]) : 0,
                BuffPeriod = reader["buffperiod"] != DBNull.Value ? Convert.ToInt32(reader["buffperiod"]) : 0,
                IsAttack = reader["isattack"] != DBNull.Value ? Convert.ToInt32(reader["isattack"]) : 1,
                IsBuff = reader["isbuff"] != DBNull.Value ? Convert.ToInt32(reader["isbuff"]) : 1,
                Special = reader["special"] != DBNull.Value ? Convert.ToInt32(reader["special"]) : 0,
                Comment = reader["comment"]?.ToString() ?? string.Empty,
                IsChecked = false
              };
              skills.Add(skill);
            }
          }
        }
      }

      return skills;
    }

    public void SavePlayerSettings(PlayerSettings settings)
    {
      Debug.WriteLine("SavePlayerSettings " + settings.PlayerId.ToString());
      using (var connection = new SQLiteConnection(_connectionString))
      {
        connection.Open();

        string query = @"
          INSERT OR REPLACE INTO PlayerSettings (
            PlayerId, Mode, IsAutoUpLevel, IsAutoUseX2Exp, IsAutoUseResetLevelItem, IsAutoUseAddPointItem, MaxLevel,
            ResetLevelItemIndex, AddPointItemIndex, FixedX, FixedY, FixedMapId, FixedMapName,
            UseItemWithoutTraining, IsAutoMoveEnabled,
            TowerPositionsJson, SelectedSkillIdsJson, CheckedItemIndexesJson
          ) VALUES (
            @PlayerId, @Mode, @IsAutoUpLevel, @IsAutoUseX2Exp, @IsAutoUseResetLevelItem, @IsAutoUseAddPointItem, @MaxLevel,
            @ResetLevelItemIndex, @AddPointItemIndex, @FixedX, @FixedY, @FixedMapId, @FixedMapName,
            @UseItemWithoutTraining, @IsAutoMoveEnabled,
            @TowerPositionsJson, @SelectedSkillIdsJson, @CheckedItemIndexesJson
          )";

        using (var command = new SQLiteCommand(query, connection))
        {
          command.Parameters.AddWithValue("@PlayerId", settings.PlayerId);
          command.Parameters.AddWithValue("@Mode", (int)settings.Mode);
          command.Parameters.AddWithValue("@IsAutoUpLevel", settings.IsAutoUpLevel ? 1 : 0);
          command.Parameters.AddWithValue("@IsAutoUseX2Exp", settings.IsAutoUseX2Exp ? 1 : 0);
          command.Parameters.AddWithValue("@IsAutoUseResetLevelItem", settings.IsAutoUseResetLevelItem ? 1 : 0);
          command.Parameters.AddWithValue("@IsAutoUseAddPointItem", settings.IsAutoUseAddPointItem ? 1 : 0);
          command.Parameters.AddWithValue("@MaxLevel", settings.MaxLevel);
          command.Parameters.AddWithValue("@ResetLevelItemIndex", 0); // Deprecated, kept for backward compatibility
          command.Parameters.AddWithValue("@AddPointItemIndex", 0); // Deprecated, kept for backward compatibility
          command.Parameters.AddWithValue("@FixedX", settings.FixedX);
          command.Parameters.AddWithValue("@FixedY", settings.FixedY);
          command.Parameters.AddWithValue("@FixedMapId", settings.FixedMapId);
          command.Parameters.AddWithValue("@FixedMapName", settings.FixedMapName ?? "");
          command.Parameters.AddWithValue("@UseItemWithoutTraining", settings.UseItemWithoutTraining ? 1 : 0);
          command.Parameters.AddWithValue("@IsAutoMoveEnabled", settings.IsAutoMoveEnabled ? 1 : 0);
          command.Parameters.AddWithValue("@TowerPositionsJson", settings.TowerPositionsJson ?? "");
          command.Parameters.AddWithValue("@SelectedSkillIdsJson", settings.SelectedSkillIdsJson ?? "");
          command.Parameters.AddWithValue("@CheckedItemIndexesJson", settings.CheckedItemIndexesJson ?? "");

          command.ExecuteNonQuery();
        }
      }
    }

    public PlayerSettings LoadPlayerSettings(int playerId)
    {
      Debug.WriteLine("LoadPlayerSettings " + playerId.ToString());
      using (var connection = new SQLiteConnection(_connectionString))
      {
        connection.Open();

        string query = @"SELECT * FROM PlayerSettings WHERE PlayerId = @PlayerId";

        using (var command = new SQLiteCommand(query, connection))
        {
          command.Parameters.AddWithValue("@PlayerId", playerId);

          using (var reader = command.ExecuteReader())
          {
            if (reader.Read())
            {
              // Check if new columns exist and load them, otherwise migrate from old columns
              bool isAutoUseResetLevelItem = false;
              bool isAutoUseAddPointItem = false;
              PlayerMode mode = PlayerMode.None;

              // Try to read new columns if they exist
              try
              {
                isAutoUseResetLevelItem = Convert.ToInt32(reader["IsAutoUseResetLevelItem"]) == 1;
              }
              catch
              {
                // Column doesn't exist, try to migrate from old column
                int oldResetIndex = Convert.ToInt32(reader["ResetLevelItemIndex"]);
                isAutoUseResetLevelItem = oldResetIndex > 0;
              }

              try
              {
                isAutoUseAddPointItem = Convert.ToInt32(reader["IsAutoUseAddPointItem"]) == 1;
              }
              catch
              {
                // Column doesn't exist, try to migrate from old column
                int oldAddPointIndex = Convert.ToInt32(reader["AddPointItemIndex"]);
                isAutoUseAddPointItem = oldAddPointIndex > 0;
              }

              // Try to load Mode column if it exists, otherwise migrate from IsTraining/IsTowerMode
              try
              {
                mode = (PlayerMode)Convert.ToInt32(reader["Mode"]);
              }
              catch
              {
                // Mode column doesn't exist, migrate from old columns
                try
                {
                  bool isTraining = Convert.ToInt32(reader["IsTraining"]) == 1;
                  bool isTowerMode = Convert.ToInt32(reader["IsTowerMode"]) == 1;

                  if (isTowerMode)
                    mode = PlayerMode.FightTower;
                  else if (isTraining)
                    mode = PlayerMode.Training;
                  else
                    mode = PlayerMode.None;
                }
                catch
                {
                  mode = PlayerMode.None;
                }
              }

              return new PlayerSettings
              {
                PlayerId = Convert.ToInt32(reader["PlayerId"]),
                Mode = mode,
                IsAutoUpLevel = Convert.ToInt32(reader["IsAutoUpLevel"]) == 1,
                IsAutoUseX2Exp = Convert.ToInt32(reader["IsAutoUseX2Exp"]) == 1,
                IsAutoUseResetLevelItem = isAutoUseResetLevelItem,
                IsAutoUseAddPointItem = isAutoUseAddPointItem,
                MaxLevel = Convert.ToInt32(reader["MaxLevel"]),
                FixedX = Convert.ToInt32(reader["FixedX"]),
                FixedY = Convert.ToInt32(reader["FixedY"]),
                FixedMapId = Convert.ToInt32(reader["FixedMapId"]),
                FixedMapName = reader["FixedMapName"]?.ToString() ?? "",
                UseItemWithoutTraining = Convert.ToInt32(reader["UseItemWithoutTraining"]) == 1,
                IsAutoMoveEnabled = Convert.ToInt32(reader["IsAutoMoveEnabled"]) == 1,
                TowerPositionsJson = reader["TowerPositionsJson"]?.ToString() ?? "",
                SelectedSkillIdsJson = reader["SelectedSkillIdsJson"]?.ToString() ?? "",
                CheckedItemIndexesJson = reader["CheckedItemIndexesJson"]?.ToString() ?? ""
              };
            }
          }
        }
      }

      // Return default settings if not found
      return null;
    }
  }
}
