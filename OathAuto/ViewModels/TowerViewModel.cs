using OathAuto.AppState;
using OathAuto.Models;
using OathAuto.Services;
using SmartBot;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows;

namespace OathAuto.ViewModels
{
  public partial class PlayerViewModel
  {
    // Tower mode fields
    private int _currentPositionIndex = 0;
    private bool _isMovingForward = true; // True = 0→N, False = N→0
    private const string MONSTER_KEY_NAME = "lần tấn công"; // Adjust this based on actual monster name pattern
    private readonly LockStatus _lock = new LockStatus();
    private ObservableCollection<TowerPosition> _towerPositions;

    public ObservableCollection<TowerPosition> TowerPositions
    {
      get => _towerPositions;
      set
      {
        if (_towerPositions != value)
        {
          _towerPositions = value;
          OnPropertyChanged(nameof(TowerPositions));
        }
      }
    }

    #region Tower Methods
    private void HandleTowerTrainingUpdate()
    {
      // Exit if tower mode is disabled
      // Nếu đang ở đại lý, return
      if (_playerMode != PlayerMode.FightTower) return;

      if (this.Player.MapID == 2)
      {
        SetTrainingState(false);

        //lock (_lock)
        //{
        //  _lock.Status = "open";
          

        //  IntPtr gameWindow = Player.AutoAccount.Target.MainWindowHandle;

        //  // Method 1: Try custom protocol (most likely to work)
          

        //  for (int i = 0; i <200; i++)
        //  {
        //    MouseInputService.ClickGameButton(gameWindow, i);
        //  }

        //  MouseInputService.SendClickWithChildWindow(gameWindow, 38, 76);
        //  Thread.Sleep(3000);
        //}


        return;
      }

      try
      {
        this.Player.AutoAccount.Settings.AIMode = AllEnums.AIModes.DANHTUDO;
        
        bool hasMonsters = CheckForMonsters();
        if (hasMonsters)
        {
          SetTrainingState(true);
        }
        else
        {
          var currentPosition = TowerPositions.First(p => p.IsSelected);
          if (currentPosition != null)
          {
            if (this.Player.AutoAccount.Settings.CenterX != currentPosition.X || this.Player.AutoAccount.Settings.CenterY != currentPosition.Y)
            {
              this.Player.AutoAccount.Settings.CenterX = currentPosition.X;
              this.Player.AutoAccount.Settings.CenterY = currentPosition.Y;
            }
          }
          MoveCurrentPosition();
        }
      }
      catch (Exception ex)
      {
        Debug.WriteLine($"Error in HandleTowerTrainingUpdate: {ex.Message}");
      }
    }

    /// <summary>
    /// Check if player is near the target position (within 2 units)
    /// </summary>
    private bool IsNearPosition(TowerPosition targetPosition)
    {
      if (_player == null || targetPosition == null)
        return false;

      float deltaX = Math.Abs(_player.PosX - targetPosition.X);
      float deltaY = Math.Abs(_player.PosY - targetPosition.Y);

      return deltaX <= 2 && deltaY <= 2;
    }

    private bool CheckForMonsters()
    {
      if (_player?.Monsters == null)
      {
        return false;
      }

      try
      {
        int totalMonsters = _player.Monsters.Count;
        // Use LINQ to check if any monsters match the key name
        var matchingMonsters = _player.Monsters.Where(m => !string.IsNullOrEmpty(m.Name) && m.Name.ToLower().Contains(MONSTER_KEY_NAME)).ToList();
        int matchCount = matchingMonsters.Count;
        return matchCount > 0;
      }
      catch (Exception ex)
      {
        Debug.WriteLine($"Error checking monsters: {ex.Message}");
        return false;
      }
    }

    private void MoveCurrentPosition()
    {
      try
      {
        // Get only checked positions
        var checkedPositions = TowerPositions.Where(p => p.IsSelected).ToList();

        if (checkedPositions.Count == 0)
        {
          Debug.WriteLine("No positions checked for tower mode");
          return;
        }

        // Ensure current index is within bounds
        if (_currentPositionIndex >= checkedPositions.Count)
        {
          _currentPositionIndex = checkedPositions.Count - 1;
          _isMovingForward = false;
        }
        else if (_currentPositionIndex < 0)
        {
          _currentPositionIndex = 0;
          _isMovingForward = true;
        }

        var targetPosition = checkedPositions[_currentPositionIndex];
        bool isArrived = IsNearPosition(targetPosition);

        if (!isArrived)
        {
          Debug.WriteLine($"{this.Player.Name} is moving to tower position: {targetPosition.X}, {targetPosition.Y}");
          // Not arrived yet, keep moving to current target
          _player.AutoAccount.CallMoveTo((int)targetPosition.X, (int)targetPosition.Y);
          return;
        }

        // Arrived at position, move to next checked position (ping-pong)
        if (_isMovingForward)
        {
          _currentPositionIndex++;
          if (_currentPositionIndex >= checkedPositions.Count - 1)
          {
            _currentPositionIndex = checkedPositions.Count - 1;
            _isMovingForward = false;
          }
        }
        else
        {
          _currentPositionIndex--;
          if (_currentPositionIndex <= 0)
          {
            _currentPositionIndex = 0;
            _isMovingForward = true;
          }
        }
      }
      catch (Exception ex)
      {
        Debug.WriteLine($"Error moving to tower position: {ex.Message}");
      }
    }
    #endregion
  }
}
