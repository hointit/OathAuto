using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using OathAuto.Models;
using OathAuto.Services;

namespace OathAuto.ViewModels
{
  public class MainWindowViewModel : INotifyPropertyChanged
  {
    private readonly SmartClassService _smartClassService;
    private PlayerViewModel _selectedPlayer;
    private Timer _updateTimer;
    private ICommand _stopAllAutoCommand;

    public MainWindowViewModel()
    {
      Players = new ObservableCollection<PlayerViewModel>();

      // Initialize SmartClassService
      _smartClassService = new SmartClassService();
      // Initialize timer for background updates
      InitializeTimer();

      // Initialize commands
      _stopAllAutoCommand = new RelayCommand(ExecuteStopAllAuto);
    }

    private void InitializeTimer()
    {
      _updateTimer = new Timer(600);
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

    #region Commands

    public ICommand StopAllAutoCommand => _stopAllAutoCommand;

    private void ExecuteStopAllAuto(object parameter)
    {
      StopAllAuto();
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
          Debug.WriteLine($"updatedPlayers: {updatedPlayers.Count}-----playersToRemove---{playersToRemove.Count}----PID: {playerToRemove.Player.ProcessID}-----CharID: {playerToRemove.Player.Id}");
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
            existingViewModel.LoadPlayerInventory();
            existingViewModel.LoadSettings();
          }
          else
          {
            var newPlayerViewModel = new PlayerViewModel(updatedPlayer, _smartClassService);
            if (updatedPlayer.DatabaseId > 0)
            {
              newPlayerViewModel.LoadSettings();
              newPlayerViewModel.LoadSkills();
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
      existingPlayer.AutoAccount = newData.AutoAccount;
    }

    #endregion

    #region Cleanup

    /// <summary>
    /// Stops all automation timers across all players and the main update timer
    /// </summary>
    public void StopAllAuto()
    {
      try
      {
        Debug.WriteLine("Stopping all automation timers...");

        // Stop all AutoAccount timers (BGThreadTimer, AIThreadTimer)
        var allPlayers = _smartClassService.GetAllAccountsData();
        if (allPlayers != null)
        {
          foreach (var player in allPlayers)
          {
            if (player.AutoAccount != null)
            {
              // Stop AI Thread Timer (training automation)
              if (player.AutoAccount.AIThreadTimer != null)
              {
                player.AutoAccount.AIThreadTimer.Stop();
                Debug.WriteLine($"Stopped AIThreadTimer for player {player.Name}");
              }

              // Stop BG Thread Timer (background monitoring)
              if (player.AutoAccount.BGThreadTimer != null)
              {
                player.AutoAccount.BGThreadTimer.Stop();
                Debug.WriteLine($"Stopped BGThreadTimer for player {player.Name}");
              }
            }
          }
        }

        // Stop PlayerViewModel timers if any exist
        foreach (var playerViewModel in Players)
        {
          // Set player mode to None to stop any training
          playerViewModel.Mode = PlayerMode.None;
        }

        // Stop main update timer
        if (_updateTimer != null)
        {
          _updateTimer.Stop();
          Debug.WriteLine("Stopped MainWindowViewModel update timer");
        }

        Debug.WriteLine("All automation stopped successfully");
      }
      catch (Exception ex)
      {
        Debug.WriteLine($"Error stopping automation: {ex.Message}");
      }
    }

    /// <summary>
    /// Cleanup resources when ViewModel is disposed
    /// </summary>
    public void Cleanup()
    {
      // Stop all automation before cleanup
      StopAllAuto();

      // Stop and dispose timer
      if (_updateTimer != null)
      {
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
