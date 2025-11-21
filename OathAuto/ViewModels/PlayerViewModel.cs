using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using OathAuto.Models;
using OathAuto.Services;
using SmartBot;
using static SmartBot.AllEnums;

namespace OathAuto.ViewModels
{
  public class PlayerViewModel : INotifyPropertyChanged
  {
    private Player _player;
    private readonly SmartClassService _smartClassService;
    private readonly int _accountIndex;

    // Training properties
    private bool _canLevelUp;
    private int _maxLevel = 120;
    private Models.InventoryItem _resetLevelItem;
    private Models.InventoryItem _addPointItem;

    public PlayerViewModel()
    {
      _player = new Player();
      InitializeCommands();
    }

    public PlayerViewModel(Player player, SmartClassService smartClassService, int accountIndex)
    {
      _player = player ?? new Player();
      _smartClassService = smartClassService;
      _accountIndex = accountIndex;

      // Subscribe to player property changes to re-raise them
      _player.PropertyChanged += OnPlayerPropertyChanged;

      InitializeCommands();
    }

    private void InitializeCommands()
    {
      StartTrainingCommand = new RelayCommand(ExecuteStartTraining, CanExecuteStartTraining);
      StopTrainingCommand = new RelayCommand(ExecuteStopTraining, CanExecuteStopTraining);
      UseItemCommand = new RelayCommand(ExecuteUseItem, CanExecuteUseItem);
      ClearResetLevelItemCommand = new RelayCommand(ExecuteClearResetLevelItem);
      ClearAddPointItemCommand = new RelayCommand(ExecuteClearAddPointItem);
    }

    public Player Player
    {
      get => _player;
      set
      {
        if (_player != value)
        {
          // Unsubscribe from old player
          if (_player != null)
          {
            _player.PropertyChanged -= OnPlayerPropertyChanged;
          }

          _player = value;
          OnPropertyChanged("Player");

          // Subscribe to new player
          if (_player != null)
          {
            _player.PropertyChanged += OnPlayerPropertyChanged;
          }
        }
      }
    }

    // Convenience properties for direct binding (optional)
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
    public bool isTraining
    {
      get => _player?.isTraining ?? false;
      set
      {
        if (_player != null && _player.isTraining != value)
        {
          _player.isTraining = value;
          OnPropertyChanged(nameof(isTraining));
        }
      }
    }
    public double ExpPercent => _player?.ExpPercent ?? 0;
    public ObservableCollection<Models.InventoryItem> InventoryItems => _player?.InventoryItems;

    /// <summary>
    /// Returns only non-empty inventory items for ComboBox display
    /// </summary>
    public IEnumerable<Models.InventoryItem> NonEmptyInventoryItems
    {
      get
      {
        if (_player?.InventoryItems == null)
          return new List<Models.InventoryItem>();

        return _player.InventoryItems.Where(item => item.CanDisplay);
      }
    }

    // Training properties
    public bool CanLevelUp
    {
      get => _canLevelUp;
      set
      {
        if (_canLevelUp != value)
        {
          _canLevelUp = value;
          OnPropertyChanged(nameof(CanLevelUp));
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

    public Models.InventoryItem ResetLevelItem
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

    public Models.InventoryItem AddPointItem
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

    #region Commands

    public ICommand StartTrainingCommand { get; private set; }
    public ICommand StopTrainingCommand { get; private set; }
    public ICommand UseItemCommand { get; private set; }
    public ICommand ClearResetLevelItemCommand { get; private set; }
    public ICommand ClearAddPointItemCommand { get; private set; }

    private bool CanExecuteStartTraining()
    {
      return _smartClassService != null && !isTraining;
    }

    private void ExecuteStartTraining()
    {
      if (_smartClassService == null) return;

      try
      {
        // TODO: Implement start training logic via SmartClassService
        // Example: _smartClassService.StartTraining(_accountIndex);
        System.Diagnostics.Debug.WriteLine($"Start training for {Name}");
      }
      catch (Exception ex)
      {
        System.Diagnostics.Debug.WriteLine($"Error starting training: {ex.Message}");
      }
    }

    private bool CanExecuteStopTraining()
    {
      return _smartClassService != null && isTraining;
    }

    private void ExecuteStopTraining()
    {
      if (_smartClassService == null) return;

      try
      {
        // TODO: Implement stop training logic via SmartClassService
        // Example: _smartClassService.StopTraining(_accountIndex);
        System.Diagnostics.Debug.WriteLine($"Stop training for {Name}");
      }
      catch (Exception ex)
      {
        System.Diagnostics.Debug.WriteLine($"Error stopping training: {ex.Message}");
      }
    }

    private bool CanExecuteUseItem(object parameter)
    {
      return _smartClassService != null && _player != null;
    }

    private void ExecuteUseItem(object parameter)
    {
      if (_smartClassService == null) return;

      try
      {
        // TODO: Implement use item logic via SmartClassService
        // Parameter could be item ID or item object
        // Example: _smartClassService.UseItem(_accountIndex, itemId);
        System.Diagnostics.Debug.WriteLine($"Use item for {Name}, parameter: {parameter}");
      }
      catch (Exception ex)
      {
        System.Diagnostics.Debug.WriteLine($"Error using item: {ex.Message}");
      }
    }

    private void ExecuteClearResetLevelItem()
    {
      ResetLevelItem = null;
    }

    private void ExecuteClearAddPointItem()
    {
      AddPointItem = null;
    }

    #endregion

    private void OnPlayerPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      // Re-raise property changed for convenience properties
      OnPropertyChanged(e.PropertyName);

      // Also raise for specific convenience properties
      switch (e.PropertyName)
      {
        case nameof(Models.Player.Name):
          OnPropertyChanged(nameof(Name));
          break;
        case nameof(Models.Player.UserName):
          OnPropertyChanged(nameof(UserName));
          break;
        case nameof(Models.Player.Menpai):
          OnPropertyChanged(nameof(Menpai));
          break;
        case nameof(Models.Player.DisplayName):
          OnPropertyChanged(nameof(DisplayName));
          break;
        case nameof(Models.Player.Level):
          OnPropertyChanged(nameof(Level));
          break;
        case nameof(Models.Player.HP):
          OnPropertyChanged(nameof(HP));
          break;
        case nameof(Models.Player.MaxHP):
          OnPropertyChanged(nameof(MaxHP));
          break;
        case nameof(Models.Player.HPPercent):
          OnPropertyChanged(nameof(HPPercent));
          break;
        case nameof(Models.Player.MP):
          OnPropertyChanged(nameof(MP));
          break;
        case nameof(Models.Player.MaxMP):
          OnPropertyChanged(nameof(MaxMP));
          break;
        case nameof(Models.Player.MPPercent):
          OnPropertyChanged(nameof(MPPercent));
          break;
        case nameof(Models.Player.MapName):
          OnPropertyChanged(nameof(MapName));
          break;
        case nameof(Models.Player.MapLocation):
          OnPropertyChanged(nameof(MapLocation));
          break;
        case nameof(Models.Player.InCombat):
          OnPropertyChanged(nameof(InCombat));
          break;
          
        case nameof(Models.Player.isTraining):
          OnPropertyChanged(nameof(isTraining));
          break;
        case nameof(Models.Player.ExpPercent):
          OnPropertyChanged(nameof(ExpPercent));
          break;
        case nameof(Models.Player.InventoryItems):
          OnPropertyChanged(nameof(InventoryItems));
          OnPropertyChanged(nameof(NonEmptyInventoryItems));
          break;
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
      if (PropertyChanged != null)
      {
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }
    }
  }
}
