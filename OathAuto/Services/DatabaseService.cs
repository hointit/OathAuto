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
            Mode INTEGER DEFAULT 0,
            IsAutoUpLevel INTEGER DEFAULT 0,
            IsAutoUseX2Exp INTEGER DEFAULT 0,
            IsAutoUseResetLevelItem INTEGER DEFAULT 0,
            IsAutoUseAddPointItem INTEGER DEFAULT 0,
            MaxLevel INTEGER DEFAULT 130,
            FixedX INTEGER DEFAULT 0,
            FixedY INTEGER DEFAULT 0,
            FixedMapId INTEGER DEFAULT 0,
            FixedMapName TEXT DEFAULT '',
            IsAutoMoveEnabled INTEGER DEFAULT 1,
            TowerPositionsJson TEXT DEFAULT '',
            SelectedSkillIdsJson TEXT DEFAULT '',
            CheckedItemIdsJson TEXT DEFAULT ''
          )";

        using (var command = new SQLiteCommand(createTableQuery, connection))
        {
          command.ExecuteNonQuery();
        }
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
            FixedX, FixedY, FixedMapId, FixedMapName,
            IsAutoMoveEnabled,
            TowerPositionsJson, SelectedSkillIdsJson, CheckedItemIdsJson
          ) VALUES (
            @PlayerId, @Mode, @IsAutoUpLevel, @IsAutoUseX2Exp, @IsAutoUseResetLevelItem, @IsAutoUseAddPointItem, @MaxLevel,
            @FixedX, @FixedY, @FixedMapId, @FixedMapName,
            @IsAutoMoveEnabled,
            @TowerPositionsJson, @SelectedSkillIdsJson, @CheckedItemIdsJson
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
          command.Parameters.AddWithValue("@FixedX", settings.FixedX);
          command.Parameters.AddWithValue("@FixedY", settings.FixedY);
          command.Parameters.AddWithValue("@FixedMapId", settings.FixedMapId);
          command.Parameters.AddWithValue("@FixedMapName", settings.FixedMapName ?? "");
          command.Parameters.AddWithValue("@IsAutoMoveEnabled", settings.IsAutoMoveEnabled ? 1 : 0);
          command.Parameters.AddWithValue("@TowerPositionsJson", settings.TowerPositionsJson ?? "");
          command.Parameters.AddWithValue("@SelectedSkillIdsJson", settings.SelectedSkillIdsJson ?? "");
          command.Parameters.AddWithValue("@CheckedItemIdsJson", settings.CheckedItemIdsJson ?? "");

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

        string query = @"
          SELECT PlayerId, Mode, IsAutoUpLevel, IsAutoUseX2Exp, IsAutoUseResetLevelItem, IsAutoUseAddPointItem, MaxLevel,
                 FixedX, FixedY, FixedMapId, FixedMapName,
                 IsAutoMoveEnabled,
                 TowerPositionsJson, SelectedSkillIdsJson, CheckedItemIdsJson
          FROM PlayerSettings
          WHERE PlayerId = @PlayerId";

        using (var command = new SQLiteCommand(query, connection))
        {
          command.Parameters.AddWithValue("@PlayerId", playerId);

          using (var reader = command.ExecuteReader())
          {
            if (reader.Read())
            {
              return new PlayerSettings
              {
                PlayerId = Convert.ToInt32(reader["PlayerId"]),
                Mode = (PlayerMode)Convert.ToInt32(reader["Mode"]),
                IsAutoUpLevel = Convert.ToInt32(reader["IsAutoUpLevel"]) == 1,
                IsAutoUseX2Exp = Convert.ToInt32(reader["IsAutoUseX2Exp"]) == 1,
                IsAutoUseResetLevelItem = Convert.ToInt32(reader["IsAutoUseResetLevelItem"]) == 1,
                IsAutoUseAddPointItem = Convert.ToInt32(reader["IsAutoUseAddPointItem"]) == 1,
                MaxLevel = Convert.ToInt32(reader["MaxLevel"]),
                FixedX = Convert.ToInt32(reader["FixedX"]),
                FixedY = Convert.ToInt32(reader["FixedY"]),
                FixedMapId = Convert.ToInt32(reader["FixedMapId"]),
                FixedMapName = reader["FixedMapName"]?.ToString() ?? "",
                IsAutoMoveEnabled = Convert.ToInt32(reader["IsAutoMoveEnabled"]) == 1,
                TowerPositionsJson = reader["TowerPositionsJson"]?.ToString() ?? "",
                SelectedSkillIdsJson = reader["SelectedSkillIdsJson"]?.ToString() ?? "",
                CheckedItemIdsJson = reader["CheckedItemIdsJson"]?.ToString() ?? ""
              };
            }
          }
        }
      }

      // Return default settings if not found
      return new PlayerSettings
      {
        PlayerId = playerId,
        Mode = PlayerMode.None,
        IsAutoUpLevel = false,
        IsAutoUseX2Exp = false,
        IsAutoUseResetLevelItem = false,
        IsAutoUseAddPointItem = false,
        MaxLevel = 130,
        FixedX = 0,
        FixedY = 0,
        FixedMapId = 0,
        FixedMapName = "",
        IsAutoMoveEnabled = true,
        TowerPositionsJson = "",
        SelectedSkillIdsJson = "",
        CheckedItemIdsJson = ""
      };
    }
  }
}
