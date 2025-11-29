using OathAuto.AppState;
using OathAuto.Models;
using OathAuto.Services;
using SmartBot;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading;
using System.Windows;

namespace OathAuto.ViewModels
{
  enum MovingStatus
  {
    None = 0,
    ToMiddlePosition = 1,
    ToPosition = 2,
    Arrived = 3
  }
  public partial class PlayerViewModel
  {
    private const string MONSTER_KEY_NAME = "lần tấn công"; // Adjust this based on actual monster name pattern
    private const string _firstWaveMonsterName = "lần tấn công: thứ 1";
    private readonly LockStatus _lockTower = new LockStatus();
    private MovingStatus _movingStatus = MovingStatus.Arrived;

    private string _currentMonsterName = "";

    private ObservableCollection<TowerPosition> _towerPositions = new()
      {
        // vị trí đầu tiên khi vào map, 46,35
        new () {
          Id = 1, 
          Name = "Vị trí 1", 
          Position = new () { X = 26, Y = 36 },
          SubPostion = new () { X = 25, Y = 38},
          IsSelected = false
        },
        new () 
        {
          Id = 2, 
          Name = "Vị trí 2", 
          Position = new () { X = 36, Y = 34 },
          SubPostion = new () { X = 41, Y = 37},
          IsSelected = false 
        },
        new () 
        { 
          Id = 3, 
          Name = "Vị trí 3",
          Position = new () { X = 36, Y = 24 },
          MiddlePosition = new () { X = 47, Y = 22 },
          SubPostion = new () { X = 39, Y = 21},
          IsSelected = false 
        },
        new () 
        { 
          Id = 4, 
          Name = "Vị trí 4", 
          Position = new () { X = 24, Y = 24 },
          MiddlePosition = new () { X = 47, Y = 22 },
          SubPostion = new () { X = 22, Y = 22},
          IsSelected = false 
        }
      };

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
      if (_playerMode != PlayerMode.FightTower) return;
      lock (_lockTower)
      {
        if (this.Player.MapID == Constant.DaiLyMapId)
        {
          _currentMonsterName = "";
          return;
        }
        try
        {
          if (_settings == null)
          {
            Debug.WriteLine($"Settings is null: {_player.Name}");
            return;
          }
          bool hasMonsters = CheckAndSetStateMonsters();
          if (hasMonsters)
          {
            SetTrainingState(true);
            return;
          }

          var target = _towerPositions.FirstOrDefault(p => p.Id == _settings.TowerPositionId);
          var distance = GA.CalculateDistance(_player.PosX, _player.PosY, target.Position.X, target.Position.Y);
          switch (_movingStatus)
          {
            case MovingStatus.ToMiddlePosition:
              var distanceToMidlle = GA.CalculateDistance(_player.PosX, _player.PosY, target.MiddlePosition.X, target.MiddlePosition.Y);
              if (distanceToMidlle < 2.5)
              {
                // nếu tới rồi thì move tới vị trí cố định
                _movingStatus = MovingStatus.ToPosition;
              }
              else
              {
                // nếu chưa tới thì tiếp tục di chuyển
                _player.AutoAccount.CallMoveTo((int)target.MiddlePosition.X, (int)target.MiddlePosition.Y);
                Thread.Sleep(5000);
                _movingStatus = MovingStatus.ToPosition;
              }
              break;
            case MovingStatus.ToPosition:
              if (distance < 2.5)
              {
                _movingStatus = MovingStatus.Arrived;
              }
              else
              {
                _player.AutoAccount.CallMoveTo((int)target.Position.X, (int)target.Position.Y);
                Thread.Sleep(6000);
                _movingStatus = MovingStatus.Arrived;
              }
              break;
            case MovingStatus.Arrived:
              // check lại distance xem có bị tự động di chuyển quá xa không
              if (distance < 2.5)
              {
                bool hasMonsters1 = CheckAndSetStateMonsters();
                if (hasMonsters1)
                {
                  SetTrainingState(true);
                }
                else
                {
                  if (_currentMonsterName == "" || _currentMonsterName == _firstWaveMonsterName)
                  {
                    if (target.Id == 3 || target.Id == 4)
                    {
                      _movingStatus = MovingStatus.ToMiddlePosition;
                    }
                    else
                    {

                      _movingStatus = MovingStatus.ToPosition;
                    }
                  }
                  else
                  {
                    if (target.SubPostion != null)
                    {
                      _player.AutoAccount.CallMoveTo((int)target.SubPostion.X, (int)target.SubPostion.Y);
                      Thread.Sleep(2000);
                    }
                    _movingStatus = MovingStatus.ToPosition;
                  }
                  // TODO: check xem nếu quá lâu không thấy quái thì làm gì
                }
              }
              else
              {
                _movingStatus = MovingStatus.ToPosition;
                _player.AutoAccount.CallMoveTo((int)target.Position.X, (int)target.Position.Y);
                Thread.Sleep(1000);
              }
              break;
            default:
              return;
          }
        }
        catch (Exception ex)
        {
          Debug.WriteLine($"Error in HandleTowerTrainingUpdate: {ex.Message}");
        }
      }
    }

    private bool CheckAndSetStateMonsters()
    {
      if (_player?.Monsters == null)
      {
        return false;
      }

      try
      {
        int totalMonsters = _player.Monsters.Count;
        var matchingMonsters = _player.Monsters
          .Where(m => !string.IsNullOrEmpty(m.Name) && m.Name.ToLower().Contains(MONSTER_KEY_NAME)).ToList();
        if (matchingMonsters.Count > 0)
        {
          _currentMonsterName = matchingMonsters.FirstOrDefault().Name.ToLower();
        }

        return matchingMonsters.Count > 0;
      }
      catch (Exception ex)
      {
        Debug.WriteLine($"Error checking monsters: {ex.Message}");
        return false;
      }
    }    
    #endregion
  }
}
