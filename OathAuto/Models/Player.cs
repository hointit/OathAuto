using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace OathAuto.Models
{
  public class Player : INotifyPropertyChanged
  {
    private string _name = string.Empty;
    private int _level;
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
    private object _inventoryItem;

    public string Name
    {
      get => _name;
      set
      {
        if (_name != value)
        {
          _name = value;
          OnPropertyChanged("Name");
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
        }
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
        }
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

    public object InventoryItem
    {
      get => _inventoryItem;
      set
      {
        if (_inventoryItem != value)
        {
          _inventoryItem = value;
          OnPropertyChanged("InventoryItem");
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
