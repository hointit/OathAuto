using OathAuto.Models;
using OathAuto.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace OathAuto.AppState
{
  /// <summary>
  /// Singleton state manager for player settings.
  /// Provides thread-safe in-memory cache of settings with database persistence.
  /// </summary>
  public class SettingState
  {
    private static SettingState _instance;
    private static readonly object _instanceLock = new object();
    private readonly object _settingsLock = new object();

    private Dictionary<int, PlayerSettings> _settingsCache;
    private DatabaseService _databaseService;

    private SettingState()
    {
      _settingsCache = new Dictionary<int, PlayerSettings>();
      InitializeDatabase();
    }

    /// <summary>
    /// Gets the singleton instance of SettingState
    /// </summary>
    public static SettingState Instance
    {
      get
      {
        if (_instance == null)
        {
          lock (_instanceLock)
          {
            if (_instance == null)
            {
              _instance = new SettingState();
            }
          }
        }
        return _instance;
      }
    }

    /// <summary>
    /// Initializes the database connection and loads all settings into memory
    /// </summary>
    private void InitializeDatabase()
    {
      try
      {
        string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TLBB.db");
        if (File.Exists(dbPath))
        {
          _databaseService = new DatabaseService(dbPath);
          LoadAllSettingsFromDatabase();
          Debug.WriteLine("SettingState initialized successfully");
        }
        else
        {
          Debug.WriteLine($"Database not found at: {dbPath}");
        }
      }
      catch (Exception ex)
      {
        Debug.WriteLine($"Error initializing SettingState: {ex.Message}");
      }
    }

    /// <summary>
    /// Loads all player settings from database into memory cache
    /// </summary>
    private void LoadAllSettingsFromDatabase()
    {
      // Note: We'll populate this as players are accessed since we don't have a GetAll method
      // The cache will be populated on-demand
      Debug.WriteLine("SettingState cache initialized (will load on-demand)");
    }

    /// <summary>
    /// Gets player settings from cache or loads from database if not cached
    /// </summary>
    /// <param name="playerId">Player database ID</param>
    /// <param name="playerName">Player name for creating new records</param>
    /// <returns>Player settings (existing or default)</returns>
    public PlayerSettings GetSettings(int playerId, string playerName)
    {
      lock (_settingsLock)
      {
        // Check cache first
        if (_settingsCache.ContainsKey(playerId))
        {
          return _settingsCache[playerId];
        }

        // Not in cache, load from database
        PlayerSettings settings = null;
        if (_databaseService != null)
        {
          try
          {
            settings = _databaseService.LoadPlayerSettings(playerId, playerName);
            Debug.WriteLine($"Settings loaded from DB for player {playerId}");
          }
          catch (Exception ex)
          {
            Debug.WriteLine($"Error loading settings from DB for player {playerId}: {ex.Message}");
          }
        }

        // If still null, create default settings
        if (settings == null)
        {
          settings = CreateDefaultSettings(playerId);
          Debug.WriteLine($"Created default settings for player {playerId}");
        }

        // Cache the settings
        _settingsCache[playerId] = settings;
        return settings;
      }
    }

    /// <summary>
    /// Saves player settings to both cache and database
    /// </summary>
    /// <param name="settings">Settings to save</param>
    /// <param name="playerName">Player name</param>
    public void SaveSettings(PlayerSettings settings, string playerName)
    {
      if (settings == null) return;

      lock (_settingsLock)
      {
        try
        {
          // Update cache
          _settingsCache[settings.PlayerId] = settings;

          // Save to database
          if (_databaseService != null)
          {
            _databaseService.SavePlayerSettings(settings, playerName);
            Debug.WriteLine($"Settings saved for player {settings.PlayerId}");
          }
        }
        catch (Exception ex)
        {
          Debug.WriteLine($"Error saving settings for player {settings.PlayerId}: {ex.Message}");
        }
      }
    }

    /// <summary>
    /// Creates default settings for a new player
    /// </summary>
    /// <param name="playerId">Player database ID</param>
    /// <returns>Default player settings</returns>
    private PlayerSettings CreateDefaultSettings(int playerId)
    {
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
        TowerPositionId = 0,
        SelectedSkillIdsJson = "",
        CheckedItemIdsJson = "",
        SelectedPetId = 0
      };
    }

    /// <summary>
    /// Clears the settings cache (useful for testing or refresh scenarios)
    /// </summary>
    public void ClearCache()
    {
      lock (_settingsLock)
      {
        _settingsCache.Clear();
        Debug.WriteLine("SettingState cache cleared");
      }
    }

    /// <summary>
    /// Removes a specific player's settings from cache
    /// </summary>
    /// <param name="playerId">Player database ID</param>
    public void RemoveFromCache(int playerId)
    {
      lock (_settingsLock)
      {
        if (_settingsCache.ContainsKey(playerId))
        {
          _settingsCache.Remove(playerId);
          Debug.WriteLine($"Settings removed from cache for player {playerId}");
        }
      }
    }
  }
}
