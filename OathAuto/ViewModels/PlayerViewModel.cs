using OathAuto.AppState;
using OathAuto.Models;
using OathAuto.Services;
using SmartBot;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using Newtonsoft.Json;
using static SmartBot.AllEnums;
using InventoryItem = OathAuto.Models.InventoryItem;

namespace OathAuto.ViewModels
{
  public partial class PlayerViewModel : INotifyPropertyChanged
  {
    private Player _player;
    private readonly SmartClassService _smartClassService;
    private readonly int _accountIndex;
    private DatabaseService _databaseService;
    private ICommand _skillCheckedChangedCommand;
    private ICommand _getCurrentPositionCommand;
    private ICommand _clearFixedPositionCommand;

    // Player mode for internal logic
    private PlayerMode _playerMode = PlayerMode.None;

    // Settings - bound directly to UI
    private PlayerSettings _settings;

    private bool _isLoadingSettings = false; // Flag to prevent saving during load

    public PlayerViewModel(Player player, SmartClassService smartClassService, int accountIndex)
    {
      // Prevent saving during initialization
      _isLoadingSettings = true;

      _player = player ?? new Player();
      _smartClassService = smartClassService;
      _accountIndex = accountIndex;
      _player.PropertyChanged += OnPlayerPropertyChanged;

      // Initialize database service
      string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TLBB.db");
      if (File.Exists(dbPath))
      {
        _databaseService = new DatabaseService(dbPath);
      }

      // Initialize command for skill checkbox changes
      _skillCheckedChangedCommand = new RelayCommand(OnSkillCheckedChanged);

      // Initialize training option commands
      _getCurrentPositionCommand = new RelayCommand(ExecuteGetCurrentPosition);
      _clearFixedPositionCommand = new RelayCommand(ExecuteClearFixedPosition);

      // Initialize tower positions
      _towerPositions = new ObservableCollection<TowerPosition>
      {
        new TowerPosition { Name = "Position 1", X = 26, Y = 36, IsChecked = true },
        new TowerPosition { Name = "Position 2", X = 36, Y = 34, IsChecked = true },
        new TowerPosition { Name = "Position 3", X = 36, Y = 24, IsChecked = true },
        new TowerPosition { Name = "Position 4", X = 24, Y = 23, IsChecked = true }
      };

      // Subscribe to tower position property changes
      foreach (var pos in _towerPositions)
      {
        pos.PropertyChanged += TowerPosition_PropertyChanged;
      }

      // Subscribe to inventory items if already available
      if (_player.InventoryItems != null)
      {
        _player.InventoryItems.CollectionChanged += InventoryItems_CollectionChanged;
        foreach (var item in _player.InventoryItems)
        {
          item.PropertyChanged += InventoryItem_PropertyChanged;
        }
      }

      // Load settings after all initialization is complete
      LoadSettings();

      // Enable saving after initialization is complete
      _isLoadingSettings = false;
    }

    public Player Player
    {
      get => _player;
      set
      {
        if (_player != value)
        {
          if (_player != null)
          {
            _player.PropertyChanged -= OnPlayerPropertyChanged;
          }

          _player = value;
          OnPropertyChanged(nameof(Player));
          if (_player != null)
          {
            _player.PropertyChanged += OnPlayerPropertyChanged;

            // Load skills when player changes
            LoadSkillsIfNeeded();

            // Subscribe to inventory items collection changes
            if (_player.InventoryItems != null)
            {
              _player.InventoryItems.CollectionChanged += InventoryItems_CollectionChanged;
              foreach (var item in _player.InventoryItems)
              {
                item.PropertyChanged += InventoryItem_PropertyChanged;
              }
            }
          }
        }
      }
    }

    public PlayerSettings Settings
    {
      get => _settings;
      set
      {
        if (_settings != value)
        {
          // Unsubscribe from old settings
          if (_settings != null)
          {
            _settings.PropertyChanged -= OnSettingsPropertyChanged;
          }

          _settings = value;
          OnPropertyChanged(nameof(Settings));

          // Subscribe to new settings
          if (_settings != null)
          {
            _settings.PropertyChanged += OnSettingsPropertyChanged;
          }
        }
      }
    }

    // Convenience properties for direct binding (optional)
    public int Id => _player.Id;
    public string Name => _player?.Name ?? string.Empty;
    public string UserName => _player?.UserName ?? string.Empty;
    public Menpais Menpai => _player?.Menpai ?? Menpais.NOMENPAI;
    public string DisplayName => _player?.DisplayName ?? string.Empty;
    public int Level => _player?.Level ?? 0;
    public int HP => _player?.HP ?? 0;
    public int MaxHP => _player?.MaxHP ?? 0;
    public double HPPercent => _player?.HPPercent ?? 0;
    public int MP => _player?.MP ?? 0;
    public int MaxMP => _player?.MaxMP ?? 0;
    public double MPPercent => _player?.MPPercent ?? 0;
    public string MapName => _player?.MapName ?? string.Empty;
    public string MapLocation => _player?.MapLocation ?? string.Empty;
    public bool InCombat => _player?.InCombat ?? false;
    public double ExpPercent => _player?.ExpPercent ?? 0;
    public ObservableCollection<Models.InventoryItem> InventoryItems => _player?.InventoryItems;
    public int DatabaseId => _player.DatabaseId;
    public IEnumerable<Models.InventoryItem> NonEmptyInventoryItems
    {
      get
      {
        if (_player?.InventoryItems == null)
          return new List<Models.InventoryItem>();
        return _player.InventoryItems.Where(item => item.CanDisplay);
      }
    }

    // Mode wrapper properties for XAML binding
    public bool IsTraining
    {
      get => _playerMode == PlayerMode.Training;
      set
      {
        if (IsTraining != value)
        {
          if (value)
          {
            _playerMode = PlayerMode.Training;
            if (_settings != null) _settings.Mode = PlayerMode.Training;
            SetTrainingState(true);
          }
          else if (_playerMode == PlayerMode.Training)
          {
            _playerMode = PlayerMode.None;
            if (_settings != null) _settings.Mode = PlayerMode.None;
            SetTrainingState(false);
          }
          OnPropertyChanged(nameof(IsTraining));
          OnPropertyChanged(nameof(IsTowerMode));
        }
      }
    }

    public bool IsTowerMode
    {
      get => _playerMode == PlayerMode.FightTower;
      set
      {
        if (IsTowerMode != value)
        {
          if (value)
          {
            _playerMode = PlayerMode.FightTower;
            if (_settings != null) _settings.Mode = PlayerMode.FightTower;
            SetTrainingState(false);
            _currentPositionIndex = 0;
            _isMovingForward = true;
            Debug.WriteLine("Tower Mode Enabled - Starting ping-pong patrol");
          }
          else if (_playerMode == PlayerMode.FightTower)
          {
            _playerMode = PlayerMode.None;
            if (_settings != null) _settings.Mode = PlayerMode.None;
            SetTrainingState(false);
            Debug.WriteLine("Tower Mode Disabled");
          }
          OnPropertyChanged(nameof(IsTowerMode));
          OnPropertyChanged(nameof(IsTraining));
        }
      }
    }


    #region Commands
    public ICommand SkillCheckedChangedCommand => _skillCheckedChangedCommand;
    public ICommand GetCurrentPositionCommand => _getCurrentPositionCommand;
    public ICommand ClearFixedPositionCommand => _clearFixedPositionCommand;
    #endregion

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
      if (PropertyChanged != null)
      {
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }
    }
    private void OnPlayerPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      // Re-raise property changed for convenience properties
      OnPropertyChanged(e.PropertyName);
      LoadSkillsIfNeeded();

      // Run level-up and item usage on background thread to avoid blocking UI
      ThreadPool.QueueUserWorkItem(state =>
      {
        if (_playerMode == PlayerMode.Training)
        {
          ModeToFixedPosition();
          UpLevel();
          SetTrainingState(true);
        }
        UseItem();
        // Handle tower training logic for real-time monster detection
        if (_playerMode == PlayerMode.FightTower)
        {
          HandleTowerTrainingUpdate();
        }
      });
    }

    private void ModeToFixedPosition()
    {
      if (_settings != null && _settings.FixedMapId == _player.MapID && (Math.Abs(_settings.FixedX - _player.PosX) > 5 || Math.Abs(_player.PosY - _settings.FixedY) > 5))
      {
        ThreadPool.QueueUserWorkItem(state1 =>
        {
          this._player.AutoAccount.CallMoveTo(_settings.FixedX, _settings.FixedY);
          Thread.Sleep(2000);
        });
      }
    }

    private void OnSettingsPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      // Handle settings changes
      if (e.PropertyName == nameof(PlayerSettings.Mode))
      {
        // Sync _playerMode with Settings.Mode
        _playerMode = _settings.Mode;

        // Update training state based on mode
        if (_playerMode == PlayerMode.Training)
        {
          SetTrainingState(true);
        }
        else if (_playerMode == PlayerMode.FightTower)
        {
          SetTrainingState(false);
          _currentPositionIndex = 0;
          _isMovingForward = true;
          Debug.WriteLine("Tower Mode Enabled - Starting ping-pong patrol");
        }
        else
        {
          SetTrainingState(false);
        }

        // Notify wrapper properties
        OnPropertyChanged(nameof(IsTraining));
        OnPropertyChanged(nameof(IsTowerMode));
      }

      // Save settings when any property changes
      SaveSettings();
    }

    private void LoadSkillsIfNeeded()
    {
      if (_player == null || _databaseService == null)
        return;

      // Check if Menpai is set and skills haven't been loaded
      if (_player.Menpai != Menpais.NOMENPAI && _player.Skills.Count == 0)
      {
        try
        {
          // Load skills from database
          var skills = _databaseService.GetSkillsByMenpai(_player.Menpai.ToString());

          // Clear existing skills and add new ones
          _player.Skills.Clear();
          foreach (var skill in skills)
          {
            // Assign the command to each skill
            skill.CheckedChangedCommand = _skillCheckedChangedCommand;
            _player.Skills.Add(skill);
          }
        }
        catch (Exception ex)
        {
          // Log or handle error silently
          System.Diagnostics.Debug.WriteLine($"Error loading skills: {ex.Message}");
        }
      }
    }

    private void OnSkillCheckedChanged(object parameter)
    {
      var skill = parameter as Skill;
      if (skill != null)
      {
        System.Diagnostics.Debug.WriteLine($"Skill {skill.SkillName} ({skill.SkillId}) checked state changed to: {skill.IsChecked}");
        SaveSettings();
      }
    }

    private void ExecuteGetCurrentPosition(object parameter)
    {
      if (_player != null && _settings != null)
      {
        _settings.FixedX = (int)_player.PosX;
        _settings.FixedY = (int)_player.PosY;
        _settings.FixedMapId = _player.MapID;
        _settings.FixedMapName = _player.MapName;
      }
    }

    private void ExecuteClearFixedPosition(object parameter)
    {
      if (_settings != null)
      {
        _settings.FixedX = 0;
        _settings.FixedY = 0;
        _settings.FixedMapId = 0;
        _settings.FixedMapName = "";
      }
    }

    /// <summary>
    /// Directly controls the training state in AutoAccount without changing IsTraining property.
    /// Use this method when you need to enable/disable AI training without triggering IsTraining property setter.
    /// </summary>
    /// <param name="enabled">True to enable training, false to disable</param>
    private void SetTrainingState(bool enabled)
    {
      if (_player?.AutoAccount != null && _player.AutoAccount.IsAIEnabled != enabled)
      {
        _player.AutoAccount.IsAIEnabled = enabled;
      }
    }

    private void UpLevel()
    {
      try
      {
        if (_settings != null && _playerMode == PlayerMode.Training && _settings.IsAutoUpLevel && _player.Level < _settings.MaxLevel)
        {
          _player.AutoAccount.CallUpLevelPacket();
        }
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex.Message);
      }
    }

    private void UseItem()
    {
      try
      {
        if (_settings == null) return;

        if ((_playerMode == PlayerMode.Training || _settings.UseItemWithoutTraining) && _settings.IsAutoUseX2Exp)
        {
          var x2Item = _player.InventoryItems.FirstOrDefault(i => i.ItemId == ItemIdState.X2ExpItemId);
          if (x2Item != null && x2Item.ItemId != 0)
          {
            _player.AutoAccount.CallUseItem(x2Item.ItemIndex, _player.Id);
          }
        }

        if ((_playerMode == PlayerMode.Training || _settings.UseItemWithoutTraining) && _settings.IsAutoUseResetLevelItem && _player.Level < _settings.MaxLevel)
        {
          // Find reset level item by ID in inventory
          var resetItem = _player.InventoryItems.FirstOrDefault(i => i.ItemId == ItemIdState.ResetLevelItemId);
          if (resetItem != null && resetItem.ItemId != 0)
          {
            _player.AutoAccount.CallUseItem(resetItem.ItemIndex, _player.Id);
            Thread.Sleep(50);
          }
        }

        if ((_playerMode == PlayerMode.Training || _settings.UseItemWithoutTraining) && _settings.IsAutoUseAddPointItem && _player.Level < _settings.MaxLevel)
        {
          // Find add point item by ID in inventory
          var addPointItem = _player.InventoryItems.FirstOrDefault(i => i.ItemId == ItemIdState.AddPointItemId);
          if (addPointItem != null && addPointItem.ItemId != 0)
          {
            _player.AutoAccount.CallUseItem(addPointItem.ItemIndex, _player.Id);
            Thread.Sleep(50);
            _player.AutoAccount.CallUseItem(addPointItem.ItemIndex, _player.Id);
          }
        }

        if (_playerMode == PlayerMode.Training || _settings.UseItemWithoutTraining)
        {
          var checkItems = NonEmptyInventoryItems.Where(i => i.IsChecked);
          foreach (var useItem in checkItems)
          {
            Player.AutoAccount.CallUseItem(useItem.ItemIndex, Player.Id);
          }
        }
      }
      catch(Exception ex)
      {
        Debug.WriteLine(ex.Message.ToString());
      }
    }

    #region Settings Persistence

    private void SaveSettings()
    {
      Debug.WriteLine("Save setting for:" + Player.Name);
      // Don't save during loading or if database service is not available
      if (_isLoadingSettings || _databaseService == null || _player == null || _settings == null)
        return;
      try
      {
        // Update JSON fields
        _settings.TowerPositionsJson = JsonConvert.SerializeObject(_towerPositions);
        _settings.SelectedSkillIdsJson = JsonConvert.SerializeObject(
          _player.Skills.Where(s => s.IsChecked).Select(s => s.SkillId).ToList()
        );
        _settings.CheckedItemIndexesJson = JsonConvert.SerializeObject(
          _player.InventoryItems.Where(i => i.IsChecked).Select(i => i.ItemIndex).ToList()
        );

        _databaseService.SavePlayerSettings(_settings);
        Debug.WriteLine($"Settings saved for player {_player.DatabaseId}");
      }
      catch (Exception ex)
      {
        Debug.WriteLine($"Error saving settings: {ex.Message}");
      }
    }
    public void LoadSettings()
    {
      if (_databaseService == null || _player == null)
        return;
      try
      {
        var loadedSettings = _databaseService.LoadPlayerSettings(_player.DatabaseId);
        if (loadedSettings != null)
        {
          // Set the Settings property with loaded data
          Settings = loadedSettings;

          // Load player mode from settings
          _playerMode = _settings.Mode;

          // Update training state based on mode
          if (_playerMode == PlayerMode.Training)
          {
            SetTrainingState(true);
          }
          else if (_playerMode == PlayerMode.FightTower)
          {
            SetTrainingState(false);
          }
          else
          {
            SetTrainingState(false);
          }

          // Load tower positions
          if (!string.IsNullOrEmpty(_settings.TowerPositionsJson))
          {
            try
            {
              var positions = JsonConvert.DeserializeObject<List<TowerPosition>>(_settings.TowerPositionsJson);
              if (positions != null && positions.Count > 0)
              {
                // Unsubscribe from old positions
                foreach (var oldPos in _towerPositions)
                {
                  oldPos.PropertyChanged -= TowerPosition_PropertyChanged;
                }

                _towerPositions.Clear();
                foreach (var pos in positions)
                {
                  pos.PropertyChanged += TowerPosition_PropertyChanged;
                  _towerPositions.Add(pos);
                }
              }
            }
            catch (Exception ex)
            {
              Debug.WriteLine($"Error loading tower positions: {ex.Message}");
            }
          }

          // Load checked skills
          if (!string.IsNullOrEmpty(_settings.SelectedSkillIdsJson))
          {
            try
            {
              var skillIds = JsonConvert.DeserializeObject<List<int>>(_settings.SelectedSkillIdsJson);
              if (skillIds != null)
              {
                foreach (var skill in _player.Skills)
                {
                  skill.IsChecked = skillIds.Contains(skill.SkillId);
                }
              }
            }
            catch (Exception ex)
            {
              Debug.WriteLine($"Error loading skill selections: {ex.Message}");
            }
          }

          // Load checked inventory items
          if (!string.IsNullOrEmpty(_settings.CheckedItemIndexesJson))
          {
            try
            {
              var itemIndexes = JsonConvert.DeserializeObject<List<int>>(_settings.CheckedItemIndexesJson);
              if (itemIndexes != null && _player.InventoryItems != null)
              {
                foreach (var item in _player.InventoryItems)
                {
                  item.IsChecked = itemIndexes.Contains(item.ItemIndex);
                }
              }
            }
            catch (Exception ex)
            {
              Debug.WriteLine($"Error loading item selections: {ex.Message}");
            }
          }

          Debug.WriteLine($"Settings loaded for player {_player.DatabaseId}");
        }
      }
      catch (Exception ex)
      {
        Debug.WriteLine($"Error loading settings: {ex.Message}");
      }
      finally
      {
      }
    }

    private void TowerPosition_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      if (e.PropertyName == nameof(TowerPosition.IsChecked))
      {
        SaveSettings();
      }
    }

    private void InventoryItems_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
      // Subscribe to new items
      if (e.NewItems != null)
      {
        foreach (InventoryItem item in e.NewItems)
        {
          item.PropertyChanged += InventoryItem_PropertyChanged;
        }
      }

      // Unsubscribe from old items
      if (e.OldItems != null)
      {
        foreach (InventoryItem item in e.OldItems)
        {
          item.PropertyChanged -= InventoryItem_PropertyChanged;
        }
      }
    }

    private void InventoryItem_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      if (e.PropertyName == nameof(InventoryItem.IsChecked))
      {
        SaveSettings();
      }
    }

    #endregion
  }
}
