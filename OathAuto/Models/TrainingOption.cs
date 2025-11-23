using OathAuto.AppState;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace OathAuto.Models
{
  public class TrainingOption : INotifyPropertyChanged
  {
    private readonly Player _player;
    private bool _isTraining = false;
    private bool _isAutoUpLevel = false;
    private bool _isAutoUseX2Exp = false;
    private int _maxLevel = 130;
    private InventoryItem _resetLevelItem;
    private InventoryItem _addPointItem;
    private int _fixedX = 0;
    private int _fixedY = 0;
    private int _fixedMapId = 0;
    private string _fixedMapName = "";

    public TrainingOption(Player player)
    {
      _player = player ?? throw new ArgumentNullException(nameof(player));
      _player.PropertyChanged += OnPlayerPropertyChanged;

      // Try to initialize default items if inventory is already loaded
      UpdateDefaultItem();
    }

    public bool IsTraining
    {
      get => _isTraining;
      set
      {
        if (_isTraining != value)
        {
          _isTraining = value;
          if (_player?.AutoAccount != null)
          {
            _player.AutoAccount.IsAIEnabled = value;
          }
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

    public InventoryItem ResetLevelItem
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

    public InventoryItem AddPointItem
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

    private void OnPlayerPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
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
      });
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
        if (!_isTraining)
        {
          return;
        }

        if (_isAutoUseX2Exp)
        {
          var x2Item = _player.InventoryItems.FirstOrDefault(i => i.ItemId == ItemIdState.X2ExpItemId);
          if (x2Item != null && x2Item.ItemId != 0)
          {
            _player.AutoAccount.CallUseItem(x2Item.ItemIndex, _player.Id);
          }
        }

        if (_resetLevelItem != null && _player.Level < _maxLevel)
        {
          _player.AutoAccount.CallUseItem(_resetLevelItem.ItemIndex, _player.Id);
          Thread.Sleep(50);
        }

        if (_addPointItem != null && _player.Level < _maxLevel)
        {
          _player.AutoAccount.CallUseItem(_addPointItem.ItemIndex, _player.Id);
          Thread.Sleep(50);
          _player.AutoAccount.CallUseItem(_addPointItem.ItemIndex, _player.Id);
        }
      }
      catch(Exception ex)
      {
        Debug.WriteLine(ex.Message.ToString());
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
