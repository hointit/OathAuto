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
    private List<QuaiIndividual> _monsters;
    private ObservableCollection<Models.InventoryItem> _inventoryItems;
    private ObservableCollection<Skill> _skills;
    private ObservableCollection<Pet> _pets;
    private double _expPercent;
    public bool _isLoadedOldSetting = false;
    private int _databaseId = 0;
    private int _petActiveIndex = -1;

    public AutoAccount AutoAccount { get; set; }

    public Player()
    {
      // Initialize skills collection
      _skills = new ObservableCollection<Skill>();
      // Initialize pets collection
      _pets = new ObservableCollection<Pet>();
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

    public List<QuaiIndividual> Monsters
    {
      get => _monsters;
      set
      {
        if (_monsters != value)
        {
          _monsters = value;
          OnPropertyChanged(nameof(Monsters));
        }
      }
    }

    public ObservableCollection<InventoryItem> InventoryItems
    {
      get => _inventoryItems;
      set
      {
        if (_inventoryItems != value)
        {
          _inventoryItems = value;
          OnPropertyChanged(nameof(InventoryItems));
        }
      }
    }

    public ObservableCollection<Skill> Skills
    {
      get => _skills;
      set
      {
        if (_skills != value)
        {
          _skills = value;
          OnPropertyChanged(nameof(Skills));
        }
      }
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

    public ObservableCollection<Pet> Pets
    {
      get => _pets;
      set
      {
        if (_pets != value)
        {
          _pets = value;
          OnPropertyChanged(nameof(Pets));
        }
      }
    }


    public event PropertyChangedEventHandler PropertyChanged;

    public void OnPropertyChanged(string propertyName)
    {
      if (PropertyChanged != null)
      {
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }
    }
  }
}
