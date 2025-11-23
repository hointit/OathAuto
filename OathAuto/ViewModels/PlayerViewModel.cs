using OathAuto.AppState;
using OathAuto.Models;
using OathAuto.Services;
using SmartBot;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using static SmartBot.AllEnums;

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

    public PlayerViewModel(Player player, SmartClassService smartClassService, int accountIndex)
    {
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
        new TowerPosition { Name = "Position 2", X = 45, Y = 35, IsChecked = true },
        new TowerPosition { Name = "Position 3", X = 36, Y = 20, IsChecked = true },
        new TowerPosition { Name = "Position 4", X = 24, Y = 19, IsChecked = true }
      };

      // Try to initialize default items if inventory is already loaded
      UpdateDefaultItem();
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
        // This method will be implemented by the user
        // For now, just a placeholder that can be customized
        System.Diagnostics.Debug.WriteLine($"Skill {skill.SkillName} ({skill.SkillId}) checked state changed to: {skill.IsChecked}");
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
  }
}
