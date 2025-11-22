using OathAuto.AppState;
using OathAuto.Models;
using OathAuto.Services;
using SmartBot;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using static SmartBot.AllEnums;

namespace OathAuto.ViewModels
{
  public class PlayerViewModel : INotifyPropertyChanged
  {
    private Player _player;
    private readonly SmartClassService _smartClassService;
    private readonly int _accountIndex;
    private TrainingOption _trainingOption;

    public PlayerViewModel(Player player, SmartClassService smartClassService, int accountIndex)
    {
      _player = player ?? new Player();
      _smartClassService = smartClassService;
      _accountIndex = accountIndex;
      _player.PropertyChanged += OnPlayerPropertyChanged;
      _trainingOption = new TrainingOption(_player);
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
            _trainingOption = new TrainingOption(_player);
            OnPropertyChanged(nameof(TrainingOption));
          }
        }
      }
    }

    public TrainingOption TrainingOption
    {
      get => _trainingOption;
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
    }
  }
}
