using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using OathAuto.Models;

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
  }
}
