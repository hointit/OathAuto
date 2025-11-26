using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Timers;
using System.Windows;
using OathAuto.Models;
using OathAuto.Services;

namespace OathAuto.ViewModels
{
  public class MainWindowViewModel : INotifyPropertyChanged
  {
    private readonly SmartClassService _smartClassService;
    private PlayerViewModel _selectedPlayer;
    private Timer _updateTimer;

    public MainWindowViewModel()
    {
      Players = new ObservableCollection<PlayerViewModel>();

      // Initialize SmartClassService
      _smartClassService = new SmartClassService();

      // Initialize timer for background updates
      InitializeTimer();
    }

    private void InitializeTimer()
    {
      _updateTimer = new Timer(300); // 300ms interval
      _updateTimer.Elapsed += OnTimerElapsed;
      _updateTimer.AutoReset = true;
      _updateTimer.Start();
    }

    private void OnTimerElapsed(object sender, ElapsedEventArgs e)
    {
      try
      {
        // Get data on background thread
        var playerData = _smartClassService.GetAllAccountsData();

        // Update UI on UI thread
        Application.Current.Dispatcher.BeginInvoke(new Action(() =>
        {
          UpdatePlayerCollection(playerData);
        }));
      }
      catch (Exception ex)
      {
        System.Diagnostics.Debug.WriteLine($"Error in timer update: {ex.Message}");
      }
    }

    public ObservableCollection<PlayerViewModel> Players { get; private set; }

    #region Properties

    /// <summary>
    /// Collection of all player view models
    /// </summary>
    
    /// <summary>
    /// Currently selected player for detail view and actions
    /// </summary>
    public PlayerViewModel SelectedPlayer
    {
      get => _selectedPlayer;
      set
      {
        if (_selectedPlayer != value)
        {
          _selectedPlayer = value;
          OnPropertyChanged("SelectedPlayer");
        }
      }
    }

    #endregion

    #region Event Handlers
    /// <summary>
    /// Updates the player collection - adds new players and updates existing ones
    /// </summary>
    private void UpdatePlayerCollection(List<Player> updatedPlayers)
    {
      if (updatedPlayers == null) return;

      try
      {
        // Remove players that no longer exist
        var playersToRemove = Players
          .Where(vm => !updatedPlayers.Any(p => p.ProcessID == vm.Player.ProcessID && vm.Player.ProcessID != 0))
          .ToList();

        foreach (var playerToRemove in playersToRemove)
        {
          Players.Remove(playerToRemove);
        }

        // Update existing players or add new ones
        for (int i = 0; i < updatedPlayers.Count; i++)
        {
          var updatedPlayer = updatedPlayers[i];

          // Find existing PlayerViewModel by ProcessID
          var existingViewModel = Players.FirstOrDefault(vm =>
            vm.Player.ProcessID == updatedPlayer.ProcessID && updatedPlayer.ProcessID != 0);

          if (existingViewModel != null)
          {
            UpdatePlayerData(existingViewModel.Player, updatedPlayer);
            var isChangeMap = existingViewModel.Player.MapID != updatedPlayer.MapID;
            existingViewModel.RunAction(isChangeMap);
            var isChangeMempai = existingViewModel.Player.Menpai != updatedPlayer.Menpai;
            existingViewModel.LoadSkills();
            existingViewModel.LoadPets();
          }
          else
          {
            var newPlayerViewModel = new PlayerViewModel(updatedPlayer, _smartClassService, i);
            if (updatedPlayer.DatabaseId > 0)
            {
              newPlayerViewModel.LoadSettings();
              newPlayerViewModel.LoadSkills();
            }
            else
            {
              newPlayerViewModel.Settings = null;
            }

            newPlayerViewModel.LoadPlayerInventory();
            this.Players.Add(newPlayerViewModel);

            // Auto-select first player if none selected
            if (SelectedPlayer == null && Players.Count == 1)
            {
              SelectedPlayer = newPlayerViewModel;
            }
          }
        }
      }
      catch (Exception ex)
      {
        System.Diagnostics.Debug.WriteLine($"Error updating player collection: {ex.Message}");
      }
    }

    /// <summary>
    /// Updates individual player properties to trigger change notifications
    /// </summary>
    private void UpdatePlayerData(Player existingPlayer, Player newData)
    {
      existingPlayer.Id = newData.Id;
      existingPlayer.Name = newData.Name;
      existingPlayer.UserName = newData.UserName;
      existingPlayer.Menpai = newData.Menpai;
      existingPlayer.Level = newData.Level;
      existingPlayer.HP = newData.HP;
      existingPlayer.MaxHP = newData.MaxHP;
      existingPlayer.HPPercent = newData.HPPercent;
      existingPlayer.MP = newData.MP;
      existingPlayer.MaxMP = newData.MaxMP;
      existingPlayer.MPPercent = newData.MPPercent;
      existingPlayer.Rage = newData.Rage;
      existingPlayer.MaxRage = newData.MaxRage;
      existingPlayer.MapName = newData.MapName;
      existingPlayer.MapID = newData.MapID;
      existingPlayer.PosX = newData.PosX;
      existingPlayer.PosY = newData.PosY;
      existingPlayer.InCombat = newData.InCombat;
      existingPlayer.ProcessID = newData.ProcessID;
      existingPlayer.Monsters = newData.Monsters;
      existingPlayer.DatabaseId = newData.DatabaseId;
    }

    #endregion

    #region Cleanup

    /// <summary>
    /// Cleanup resources when ViewModel is disposed
    /// </summary>
    public void Cleanup()
    {
      // Stop and dispose timer
      if (_updateTimer != null)
      {
        _updateTimer.Stop();
        _updateTimer.Elapsed -= OnTimerElapsed;
        _updateTimer.Dispose();
        _updateTimer = null;
      }

      // Shutdown service
      if (_smartClassService != null)
      {
        _smartClassService.Shutdown();
      }

      Players.Clear();
      SelectedPlayer = null;
    }

    #endregion

    #region INotifyPropertyChanged

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
      if (PropertyChanged != null)
      {
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }
    }

    #endregion
  }
}
