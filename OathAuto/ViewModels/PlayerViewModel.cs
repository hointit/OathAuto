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
    private ICommand _clearResetLevelItemCommand;
    private ICommand _clearAddPointItemCommand;
    private ICommand _getCurrentPositionCommand;
    private ICommand _clearFixedPositionCommand;

    // Training option fields
    private bool _isTraining = false;
    private bool _isAutoUpLevel = false;
    private bool _isAutoUseX2Exp = false;
    private int _maxLevel = 130;
    private OathAuto.Models.InventoryItem _resetLevelItem;
    private OathAuto.Models.InventoryItem _addPointItem;
    private int _fixedX = 0;
    private int _fixedY = 0;
    private int _fixedMapId = 0;
    private string _fixedMapName = "";
    private bool _useItemWithoutTraining = false;
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
      _clearResetLevelItemCommand = new RelayCommand(ExecuteClearResetLevelItem);
      _clearAddPointItemCommand = new RelayCommand(ExecuteClearAddPointItem);
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

      // Try to initialize default items if inventory is already loaded
      UpdateDefaultItem();

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

            // Reset and load settings for new player
            isLoaded = false;
            LoadSettings();
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

    // Training option properties
    public bool IsTraining
    {
      get => _isTraining;
      set
      {
        if (_isTraining != value)
        {
          // Prevent enabling IsTraining when IsTowerMode is active
          if (value && _isTowerMode)
          {
            return;
          }

          _isTraining = value;
          SetTrainingState(value);
          OnPropertyChanged(nameof(IsTraining));
          SaveSettings();
        }
      }
    }

    public bool IsAutoUpLevel
    {
      get => _isAutoUpLevel;
      set
      {
        if (_isAutoUpLevel != value)
        {
          _isAutoUpLevel = value;
          OnPropertyChanged(nameof(IsAutoUpLevel));
          SaveSettings();
        }
      }
    }

    public bool IsAutoUseX2Exp
    {
      get => _isAutoUseX2Exp;
      set
      {
        if (_isAutoUseX2Exp != value)
        {
          _isAutoUseX2Exp = value;
          OnPropertyChanged(nameof(IsAutoUseX2Exp));
          SaveSettings();
        }
      }
    }

    public int MaxLevel
    {
      get => _maxLevel;
      set
      {
        if (_maxLevel != value)
        {
          _maxLevel = value;
          OnPropertyChanged(nameof(MaxLevel));
          SaveSettings();
        }
      }
    }

    public OathAuto.Models.InventoryItem ResetLevelItem
    {
      get => _resetLevelItem;
      set
      {
        if (_resetLevelItem != value)
        {
          _resetLevelItem = value;
          OnPropertyChanged(nameof(ResetLevelItem));
          SaveSettings();
        }
      }
    }

    public OathAuto.Models.InventoryItem AddPointItem
    {
      get => _addPointItem;
      set
      {
        if (_addPointItem != value)
        {
          _addPointItem = value;
          OnPropertyChanged(nameof(AddPointItem));
          SaveSettings();
        }
      }
    }

    public int FixedX
    {
      get => _fixedX;
      set
      {
        if (_fixedX != value)
        {
          _fixedX = value;
          OnPropertyChanged(nameof(FixedX));
          SaveSettings();
        }
      }
    }

    public int FixedY
    {
      get => _fixedY;
      set
      {
        if (_fixedY != value)
        {
          _fixedY = value;
          OnPropertyChanged(nameof(FixedY));
          SaveSettings();
        }
      }
    }

    public int FixedMapId
    {
      get => _fixedMapId;
      set
      {
        if (_fixedMapId != value)
        {
          _fixedMapId = value;
          OnPropertyChanged(nameof(FixedMapId));
          SaveSettings();
        }
      }
    }

    public string FixedMapName
    {
      get => _fixedMapName;
      set
      {
        if (_fixedMapName != value)
        {
          _fixedMapName = value;
          OnPropertyChanged(nameof(FixedMapName));
          SaveSettings();
        }
      }
    }

    public bool UseItemWithoutTraining
    {
      get => _useItemWithoutTraining;
      set
      {
        if (_useItemWithoutTraining != value)
        {
          _useItemWithoutTraining = value;
          OnPropertyChanged(nameof(UseItemWithoutTraining));
          SaveSettings();
        }
      }
    }


    #region Commands
    public ICommand SkillCheckedChangedCommand => _skillCheckedChangedCommand;
    public ICommand ClearResetLevelItemCommand => _clearResetLevelItemCommand;
    public ICommand ClearAddPointItemCommand => _clearAddPointItemCommand;
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
        if (FixedMapId == _player.MapID && (Math.Abs(FixedX - _player.PosX) > 5 || Math.Abs(_player.PosY - FixedY) > 5))
        {
          ThreadPool.QueueUserWorkItem(state1 =>
          {
            this.IsTraining = false;
            this._player.AutoAccount.CallMoveTo(FixedX, FixedY);
            Thread.Sleep(2000);
            this.IsTraining = true;
          });
        }
        if (e.PropertyName == nameof(_player.InventoryItems))
        {
          UpdateDefaultItem();
        }
        UpLevel();
        UseItem();

        // Handle tower training logic for real-time monster detection
        if (_isTowerMode)
        {
          HandleTowerTrainingUpdate();
        }
      });
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

    private void ExecuteClearResetLevelItem(object parameter)
    {
      ResetLevelItem = null;
    }

    private void ExecuteClearAddPointItem(object parameter)
    {
      AddPointItem = null;
    }

    private void ExecuteGetCurrentPosition(object parameter)
    {
      if (_player != null)
      {
        FixedX = (int)_player.PosX;
        FixedY = (int)_player.PosY;
        FixedMapId = _player.MapID;
        FixedMapName = _player.MapName;
      }
    }

    private void ExecuteClearFixedPosition(object parameter)
    {
      FixedX = 0;
      FixedY = 0;
      FixedMapId = 0;
      FixedMapName = "";
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
        if (_isTraining && _isAutoUpLevel && _player.ExpPercent >= 100.0 && _player.Level < _maxLevel)
        {
          _player.AutoAccount.CallUpLevelPacket();
          Thread.Sleep(50);
          _player.AutoAccount.CallUpLevelPacket();
        }
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex.Message);
      }
    }

    private void UpdateDefaultItem()
    {
      try
      {
        if (_player.InventoryItems == null)
          return;

        if (_resetLevelItem != null)
        {
          var updatedItem = _player.InventoryItems.FirstOrDefault(i => i.ItemIndex == _resetLevelItem.ItemIndex);
          if (updatedItem != null && updatedItem.ItemId == _resetLevelItem.ItemId)
          {
            ResetLevelItem = updatedItem;
          }
        }
        else
        {
          ResetLevelItem = _player.InventoryItems.FirstOrDefault(i => i.ItemId == ItemIdState.ResetLevelItemId);
        }

        if (_addPointItem != null)
        {
          var updatedItem = _player.InventoryItems.FirstOrDefault(i => i.ItemIndex == _addPointItem.ItemIndex);
          if (updatedItem != null && updatedItem.ItemId == _addPointItem.ItemId)
          {
            AddPointItem = updatedItem;
          }
        }
        else
        {
          AddPointItem = _player.InventoryItems.FirstOrDefault(i => i.ItemId == ItemIdState.AddPointItemId);
        }
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex.Message.ToString());
      }
    }

    private void UseItem()
    {
      try
      {
        if ((_isTraining || _useItemWithoutTraining) && _isAutoUseX2Exp)
        {
          var x2Item = _player.InventoryItems.FirstOrDefault(i => i.ItemId == ItemIdState.X2ExpItemId);
          if (x2Item != null && x2Item.ItemId != 0)
          {
            _player.AutoAccount.CallUseItem(x2Item.ItemIndex, _player.Id);
          }
        }

        if ((_isTraining || _useItemWithoutTraining) && _resetLevelItem != null && _player.Level < _maxLevel)
        {
          _player.AutoAccount.CallUseItem(_resetLevelItem.ItemIndex, _player.Id);
          Thread.Sleep(50);
        }

        if ((_isTraining || _useItemWithoutTraining) && _addPointItem != null && _player.Level < _maxLevel)
        {
          _player.AutoAccount.CallUseItem(_addPointItem.ItemIndex, _player.Id);
          Thread.Sleep(50);
          _player.AutoAccount.CallUseItem(_addPointItem.ItemIndex, _player.Id);
        }
        if (_isTraining || _useItemWithoutTraining)
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
      // Don't save during loading or if database service is not available
      if (_isLoadingSettings || _databaseService == null || _player == null)
        return;

      try
      {
        var settings = new PlayerSettings
        {
          PlayerId = _player.DatabaseId,
          IsTraining = _isTraining,
          IsAutoUpLevel = _isAutoUpLevel,
          IsAutoUseX2Exp = _isAutoUseX2Exp,
          MaxLevel = _maxLevel,
          ResetLevelItemIndex = _resetLevelItem?.ItemIndex ?? 0,
          AddPointItemIndex = _addPointItem?.ItemIndex ?? 0,
          FixedX = _fixedX,
          FixedY = _fixedY,
          FixedMapId = _fixedMapId,
          FixedMapName = _fixedMapName ?? "",
          UseItemWithoutTraining = _useItemWithoutTraining,
          IsTowerMode = _isTowerMode,
          IsAutoMoveEnabled = _isAutoMoveEnabled,
          TowerPositionsJson = JsonConvert.SerializeObject(_towerPositions),
          SelectedSkillIdsJson = JsonConvert.SerializeObject(
            _player.Skills.Where(s => s.IsChecked).Select(s => s.SkillId).ToList()
          ),
          CheckedItemIndexesJson = JsonConvert.SerializeObject(
            _player.InventoryItems.Where(i => i.IsChecked).Select(i => i.ItemIndex).ToList()
          )
        };

        _databaseService.SavePlayerSettings(settings);
        Debug.WriteLine($"Settings saved for player {_player.DatabaseId}");
      }
      catch (Exception ex)
      {
        Debug.WriteLine($"Error saving settings: {ex.Message}");
      }
    }
    private bool isLoaded = false;
    private void LoadSettings()
    {
      if (_databaseService == null || _player == null || isLoaded)
        return;

      // Save previous state to restore later
      bool wasLoadingSettings = _isLoadingSettings;

      try
      {
        _isLoadingSettings = true;

        var settings = _databaseService.LoadPlayerSettings(_player.DatabaseId);
        if (settings != null)
        {
          // Load training settings
          _isTraining = settings.IsTraining;
          _isAutoUpLevel = settings.IsAutoUpLevel;
          _isAutoUseX2Exp = settings.IsAutoUseX2Exp;
          _maxLevel = settings.MaxLevel;
          _fixedX = settings.FixedX;
          _fixedY = settings.FixedY;
          _fixedMapId = settings.FixedMapId;
          _fixedMapName = settings.FixedMapName ?? "";
          _useItemWithoutTraining = settings.UseItemWithoutTraining;

          // Load tower settings
          _isTowerMode = settings.IsTowerMode;
          _isAutoMoveEnabled = settings.IsAutoMoveEnabled;

          // Load tower positions
          if (!string.IsNullOrEmpty(settings.TowerPositionsJson))
          {
            try
            {
              var positions = JsonConvert.DeserializeObject<List<TowerPosition>>(settings.TowerPositionsJson);
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
          if (!string.IsNullOrEmpty(settings.SelectedSkillIdsJson))
          {
            try
            {
              var skillIds = JsonConvert.DeserializeObject<List<int>>(settings.SelectedSkillIdsJson);
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
          if (!string.IsNullOrEmpty(settings.CheckedItemIndexesJson))
          {
            try
            {
              var itemIndexes = JsonConvert.DeserializeObject<List<int>>(settings.CheckedItemIndexesJson);
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

          // Load reset level and add point items by index
          if (settings.ResetLevelItemIndex > 0 && _player.InventoryItems != null)
          {
            _resetLevelItem = _player.InventoryItems.FirstOrDefault(i => i.ItemIndex == settings.ResetLevelItemIndex);
          }

          if (settings.AddPointItemIndex > 0 && _player.InventoryItems != null)
          {
            _addPointItem = _player.InventoryItems.FirstOrDefault(i => i.ItemIndex == settings.AddPointItemIndex);
          }

          // Notify all properties changed
          OnPropertyChanged(string.Empty);

          Debug.WriteLine($"Settings loaded for player {_player.DatabaseId}");
        }
      }
      catch (Exception ex)
      {
        Debug.WriteLine($"Error loading settings: {ex.Message}");
      }
      finally
      {
        // Restore previous state (important when called from constructor)
        _isLoadingSettings = wasLoadingSettings;
        isLoaded = true;
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
