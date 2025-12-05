using OathAuto.Models;
using OathAuto.Services;
using SmartBot;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using static SmartBot.AllEnums;

namespace OathAuto.AppState
{
  /// <summary>
  /// Singleton state manager for skills.
  /// Provides thread-safe in-memory cache of all skills loaded from database.
  /// </summary>
  public class SkillState
  {
    private static SkillState _instance;
    private static readonly object _instanceLock = new object();
    private readonly object _skillsLock = new object();

    private Dictionary<string, List<Skill>> _skillsCache;
    private DatabaseService _databaseService;
    private bool _isInitialized;

    private SkillState()
    {
      _skillsCache = new Dictionary<string, List<Skill>>();
      _isInitialized = false;
      InitializeDatabase();
    }

    /// <summary>
    /// Gets the singleton instance of SkillState
    /// </summary>
    public static SkillState Instance
    {
      get
      {
        if (_instance == null)
        {
          lock (_instanceLock)
          {
            if (_instance == null)
            {
              _instance = new SkillState();
            }
          }
        }
        return _instance;
      }
    }

    /// <summary>
    /// Initializes the database connection and loads all skills into memory
    /// </summary>
    private void InitializeDatabase()
    {
      try
      {
        string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TLBB.db");
        if (File.Exists(dbPath))
        {
          _databaseService = new DatabaseService(dbPath);
          LoadAllSkillsFromDatabase();
          _isInitialized = true;
        }
        else
        {
          Debug.WriteLine($"Database not found at: {dbPath}");
        }
      }
      catch (Exception ex)
      {
        Debug.WriteLine($"Error initializing SkillState: {ex.Message}");
      }
    }

    /// <summary>
    /// Loads all skills from database into memory cache grouped by menpai
    /// </summary>
    private void LoadAllSkillsFromDatabase()
    {
      lock (_skillsLock)
      {
        if (_databaseService == null) return;
        try
        {
          var skills = _databaseService.GetAllSkills();
          _skillsCache = skills.GroupBy(s => s.Mempai).ToDictionary(g =>g.Key, g => g.ToList());
        }
        catch (Exception ex)
        {
          Debug.WriteLine($"Error loading all skills from database: {ex.Message}");
        }
      }
    }


    /// <summary>
    /// Gets skills for a specific menpai from cache
    /// </summary>
    /// <param name="menpai">Menpai name (e.g., "THIEULAM", "EMEI")</param>
    /// <returns>List of skills for the menpai, or empty list if not found</returns>
    public List<Skill> GetSkillsByMenpai(AllEnums.Menpais menpai)
    {
      var strMempai = menpai.ToString();
      if (string.IsNullOrEmpty(menpai.ToString()))
      {
        Debug.WriteLine("GetSkillsByMenpai: menpai is null or empty");
        return new List<Skill>();
      }

      lock (_skillsLock)
      {
        // Check cache first
        if (_skillsCache.ContainsKey(strMempai))
        {
          return new List<Skill>(_skillsCache[strMempai]);
        }
        return new List<Skill>();
      }
    }

    /// <summary>
    /// Gets all skills across all menpai
    /// </summary>
    /// <returns>Dictionary of menpai to skills mapping</returns>
    public Dictionary<string, List<Skill>> GetAllSkills()
    {
      lock (_skillsLock)
      {
        // Return a deep copy to prevent external modifications
        var result = new Dictionary<string, List<Skill>>();
        foreach (var kvp in _skillsCache)
        {
          result[kvp.Key] = new List<Skill>(kvp.Value);
        }
        return result;
      }
    }

    /// <summary>
    /// Reloads all skills from database
    /// </summary>
    public void ReloadSkills()
    {
      lock (_skillsLock)
      {
        _skillsCache.Clear();
        LoadAllSkillsFromDatabase();
        Debug.WriteLine("SkillState reloaded from database");
      }
    }

    /// <summary>
    /// Clears the skills cache
    /// </summary>
    public void ClearCache()
    {
      lock (_skillsLock)
      {
        _skillsCache.Clear();
        Debug.WriteLine("SkillState cache cleared");
      }
    }

    /// <summary>
    /// Checks if SkillState is properly initialized
    /// </summary>
    public bool IsInitialized
    {
      get { return _isInitialized; }
    }
  }
}
