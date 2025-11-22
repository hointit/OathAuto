using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using SmartBot;
using OathAuto.Services;
using CoreInventoryItem = SmartBot.InventoryItem;

namespace OathAuto.Models
{
  public class Player : INotifyPropertyChanged
  {
    private int _id;
    private int _targetId;
    private string _name = string.Empty;
    private string _userName = string.Empty;
    private int _level;
    private AllEnums.Menpais _menpai;
    private int _hp;
    private int _maxHP;
    private double _hpPercent;
    private int _mp;
    private int _maxMP;
    private double _mpPercent;
    private int _rage;
    private int _maxRage;
    private string _mapName = string.Empty;
    private int _mapID;
    private float _posX;
    private float _posY;
    private bool _inCombat;
    private int _processID;
    private bool _isTraining;
    private object _monsters;
    private ObservableCollection<Models.InventoryItem> _inventoryItems;
    private double _expPercent;
    public bool _isLoadedOldSetting = false;
    private int _databaseId = 0;

    public AutoAccount AutoAccount { get; set; }

    public Player()
    {
      // Initialize with 90 empty inventory slots
      _inventoryItems = new ObservableCollection<InventoryItem>();
      for (int i = 0; i < 90; i++)
      {
        var newItem = new InventoryItem();
        newItem.ItemIndex = i;
        _inventoryItems.Add(newItem);
      }
    }

    public int Id
    {
      get => _id;
      set
      {
        if (_id != value)
        {
          _id = value;
          OnPropertyChanged(nameof(Id));
        }
      }
    }

    public int TargetId
    {
      get => _targetId;
      set
      {
        if (_targetId != value)
        {
          _targetId = value;
          OnPropertyChanged(nameof(TargetId));
        }
      }
    }

    public string Name
    {
      get => _name;
      set
      {
        if (_name != value)
        {
          _name = value;
          OnPropertyChanged("Name");
          OnPropertyChanged("DisplayName");
        }
      }
    }

    public string UserName
    {
      get => _userName;
      set
      {
        if (_userName != value)
        {
          _userName = value;
          OnPropertyChanged("UserName");
        }
      }
    }

    public AllEnums.Menpais Menpai
    {
      get => _menpai;
      set
      {
        if (_menpai != value)
        {
          _menpai = value;
          OnPropertyChanged("Menpai");
          OnPropertyChanged("DisplayName");
        }
      }
    }

    public int Level
    {
      get => _level;
      set
      {
        if (_level != value)
        {
          _level = value;
          OnPropertyChanged("Level");
          OnPropertyChanged("DisplayName");
        }
      }
    }

    public string DisplayName
    {
      get
      {
        return string.Format("{0} ({1}/{2})", _name, CommonService.GetEnumDescription(_menpai), _level);
      }
    }

    public int HP
    {
      get => _hp;
      set
      {
        if (_hp != value)
        {
          _hp = value;
          OnPropertyChanged("HP");
        }
      }
    }

    public int MaxHP
    {
      get => _maxHP;
      set
      {
        if (_maxHP != value)
        {
          _maxHP = value;
          OnPropertyChanged("MaxHP");
        }
      }
    }

    public double HPPercent
    {
      get => _hpPercent;
      set
      {
        if (_hpPercent != value)
        {
          _hpPercent = value;
          OnPropertyChanged("HPPercent");
        }
      }
    }

    public int MP
    {
      get => _mp;
      set
      {
        if (_mp != value)
        {
          _mp = value;
          OnPropertyChanged("MP");
        }
      }
    }

    public int MaxMP
    {
      get => _maxMP;
      set
      {
        if (_maxMP != value)
        {
          _maxMP = value;
          OnPropertyChanged("MaxMP");
        }
      }
    }

    public double MPPercent
    {
      get => _mpPercent;
      set
      {
        if (_mpPercent != value)
        {
          _mpPercent = value;
          OnPropertyChanged("MPPercent");
        }
      }
    }

    public int Rage
    {
      get => _rage;
      set
      {
        if (_rage != value)
        {
          _rage = value;
          OnPropertyChanged("Rage");
        }
      }
    }

    public int MaxRage
    {
      get => _maxRage;
      set
      {
        if (_maxRage != value)
        {
          _maxRage = value;
          OnPropertyChanged("MaxRage");
        }
      }
    }

    public string MapName
    {
      get => _mapName;
      set
      {
        if (_mapName != value)
        {
          _mapName = value;
          OnPropertyChanged("MapName");
          OnPropertyChanged("MapLocation");
        }
      }
    }

    public int MapID
    {
      get => _mapID;
      set
      {
        if (_mapID != value)
        {
          _mapID = value;
          OnPropertyChanged("MapID");
          OnPropertyChanged("MapLocation");
        }
      }
    }

    public float PosX
    {
      get => _posX;
      set
      {
        if (Math.Abs(_posX - value) > 0.001f)
        {
          _posX = value;
          OnPropertyChanged("PosX");
          OnPropertyChanged("MapLocation");
        }
      }
    }

    public float PosY
    {
      get => _posY;
      set
      {
        if (Math.Abs(_posY - value) > 0.001f)
        {
          _posY = value;
          OnPropertyChanged("PosY");
          OnPropertyChanged("MapLocation");
        }
      }
    }

    public string MapLocation
    {
      get
      {
        return string.Format("{0}({1}) [{2:F0}, {3:F0}]", _mapName, _mapID, _posX, _posY);
      }
    }

    public bool InCombat
    {
      get => _inCombat;
      set
      {
        if (_inCombat != value)
        {
          _inCombat = value;
          OnPropertyChanged("InCombat");
        }
      }
    }

    public int ProcessID
    {
      get => _processID;
      set
      {
        if (_processID != value)
        {
          _processID = value;
          OnPropertyChanged("ProcessID");
        }
      }
    }

    public bool isTraining
    {
      get => _isTraining;
      set
      {
        if (_isTraining != value)
        {
          _isTraining = value;
          OnPropertyChanged("isTraining");
        }
      }
    }

    public object Monsters
    {
      get => _monsters;
      set
      {
        if (_monsters != value)
        {
          _monsters = value;
          OnPropertyChanged("Monsters");
        }
      }
    }

    public ObservableCollection<InventoryItem> InventoryItems
    {
      get => _inventoryItems;
    }

    /// <summary>
    /// Update inventory items from CoreLibrary items without replacing the collection
    /// </summary>
    public void UpdateInventoryItems(List<CoreInventoryItem> sourceItems)
    {
      if (sourceItems == null) return;

      // Update existing items in place
      int count = System.Math.Min(sourceItems.Count, _inventoryItems.Count);
      for (int i = 0; i < count; i++)
      {
        _inventoryItems[i].UpdateFrom(sourceItems[i]);
      }

      // Notify that inventory items have been updated
      OnPropertyChanged(nameof(InventoryItems));
    }

    /// <summary>
    /// Sync inventory items from another player's inventory without replacing the collection
    /// </summary>
    public void SyncInventoryFrom(Player otherPlayer)
    {
      if (otherPlayer == null || otherPlayer.InventoryItems == null) return;

      // Copy properties from other player's items to this player's items
      int count = System.Math.Min(otherPlayer.InventoryItems.Count, _inventoryItems.Count);
      for (int i = 0; i < count; i++)
      {
        var source = otherPlayer.InventoryItems[i];
        var target = _inventoryItems[i];
        target.ItemId = source.ItemId;
        target.NeedToWait = source.NeedToWait;
        target.BuyingPrice = source.BuyingPrice;
        target.SellingPrice = source.SellingPrice;
        target.RealSpread = source.RealSpread;
        target.MidSpread = source.MidSpread;
        target.HighSpread = source.HighSpread;
        target.LowSpread = source.LowSpread;
        target.HasHistory = source.HasHistory;
        target.ItemCount = source.ItemCount;
        target.ItemName = source.ItemName;
        target.SaveNameCode = source.SaveNameCode;
        target.ItemGUID1 = source.ItemGUID1;
        target.ItemGUID2 = source.ItemGUID2;
        target.Lines = source.Lines;
        target.LineValueArray = source.LineValueArray;
        target.SavedCode = source.SavedCode;
        target.ItemType = source.ItemType;
        target.ItemStars = source.ItemStars;
        target.ItemSource = source.ItemSource;
        target.DinhViPhuTime = source.DinhViPhuTime;
        target.ItemMapID = source.ItemMapID;
        target.BTDMapID = source.BTDMapID;
        target.BTDposX = source.BTDposX;
        target.BTDposY = source.BTDposY;
        target.LastTimeSeen = source.LastTimeSeen;
      }
      // Notify that inventory items have been updated
      OnPropertyChanged(nameof(InventoryItems));
    }

    public double ExpPercent
    {
      get => _expPercent;
      set
      {
        if (_expPercent != value)
        {
          _expPercent = value;
          OnPropertyChanged("ExpPercent");
        }
      }
    }

    public int DatabaseId
    {
      get => _databaseId;
      set
      {
        if (_databaseId != value)
        {
          _databaseId = value;
          OnPropertyChanged(nameof(DatabaseId));
        }
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
