using System.Collections.Generic;
using System.ComponentModel;
using static SmartBot.AllEnums;

namespace OathAuto.Models
{
  public class InventoryItem : INotifyPropertyChanged
  {
    private int _itemIndex = 0;
    private int _itemId = -1;
    private bool _needToWait;
    private int _buyingPrice;
    private int _sellingPrice;
    private double _realSpread;
    private double _midSpread;
    private double _highSpread;
    private double _lowSpread;
    private bool _hasHistory;
    private byte _itemCount;
    private string _itemName = "";
    private int _saveNameCode;
    private int _itemGUID1;
    private int _itemGUID2;
    private byte _lines;
    private List<int> _lineValueArray = new List<int>();
    private int _savedCode;
    private string _itemType = "";
    private byte _itemStars;
    private ItemSources _itemSource;
    private byte _dinhViPhuTime;
    private int _itemMapID;
    private int _btdMapID;
    private int _btdposX;
    private int _btdposY;
    private long _lastTimeSeen;

    public int ItemIndex
    {
      get => _itemIndex;
      set
      {
        if (_itemIndex != value)
        {
          _itemIndex = value;
          OnPropertyChanged(nameof(ItemIndex));
        }
      }
    }

    public int ItemId
    {
      get => _itemId;
      set
      {
        if (_itemId != value)
        {
          _itemId = value;
          OnPropertyChanged(nameof(ItemId));
        }
      }
    }

    public bool NeedToWait
    {
      get => _needToWait;
      set
      {
        if (_needToWait != value)
        {
          _needToWait = value;
          OnPropertyChanged(nameof(NeedToWait));
        }
      }
    }

    public int BuyingPrice
    {
      get => _buyingPrice;
      set
      {
        if (_buyingPrice != value)
        {
          _buyingPrice = value;
          OnPropertyChanged(nameof(BuyingPrice));
        }
      }
    }

    public int SellingPrice
    {
      get => _sellingPrice;
      set
      {
        if (_sellingPrice != value)
        {
          _sellingPrice = value;
          OnPropertyChanged(nameof(SellingPrice));
        }
      }
    }

    public double RealSpread
    {
      get => _realSpread;
      set
      {
        if (_realSpread != value)
        {
          _realSpread = value;
          OnPropertyChanged(nameof(RealSpread));
        }
      }
    }

    public double MidSpread
    {
      get => _midSpread;
      set
      {
        if (_midSpread != value)
        {
          _midSpread = value;
          OnPropertyChanged(nameof(MidSpread));
        }
      }
    }

    public double HighSpread
    {
      get => _highSpread;
      set
      {
        if (_highSpread != value)
        {
          _highSpread = value;
          OnPropertyChanged(nameof(HighSpread));
        }
      }
    }

    public double LowSpread
    {
      get => _lowSpread;
      set
      {
        if (_lowSpread != value)
        {
          _lowSpread = value;
          OnPropertyChanged(nameof(LowSpread));
        }
      }
    }

    public bool HasHistory
    {
      get => _hasHistory;
      set
      {
        if (_hasHistory != value)
        {
          _hasHistory = value;
          OnPropertyChanged(nameof(HasHistory));
        }
      }
    }

    public byte ItemCount
    {
      get => _itemCount;
      set
      {
        if (_itemCount != value)
        {
          _itemCount = value;
          OnPropertyChanged(nameof(ItemCount));
        }
      }
    }

    public string ItemName
    {
      get => _itemName;
      set
      {
        if (_itemName != value)
        {
          _itemName = value ?? "";
          OnPropertyChanged(nameof(ItemName));
        }
      }
    }

    public int SaveNameCode
    {
      get => _saveNameCode;
      set
      {
        if (_saveNameCode != value)
        {
          _saveNameCode = value;
          OnPropertyChanged(nameof(SaveNameCode));
        }
      }
    }

    public int ItemGUID1
    {
      get => _itemGUID1;
      set
      {
        if (_itemGUID1 != value)
        {
          _itemGUID1 = value;
          OnPropertyChanged(nameof(ItemGUID1));
        }
      }
    }

    public int ItemGUID2
    {
      get => _itemGUID2;
      set
      {
        if (_itemGUID2 != value)
        {
          _itemGUID2 = value;
          OnPropertyChanged(nameof(ItemGUID2));
        }
      }
    }

    public byte Lines
    {
      get => _lines;
      set
      {
        if (_lines != value)
        {
          _lines = value;
          OnPropertyChanged(nameof(Lines));
        }
      }
    }

    public List<int> LineValueArray
    {
      get => _lineValueArray;
      set
      {
        if (_lineValueArray != value)
        {
          _lineValueArray = value ?? new List<int>();
          OnPropertyChanged(nameof(LineValueArray));
        }
      }
    }

    public int SavedCode
    {
      get => _savedCode;
      set
      {
        if (_savedCode != value)
        {
          _savedCode = value;
          OnPropertyChanged(nameof(SavedCode));
        }
      }
    }

    public string ItemType
    {
      get => _itemType;
      set
      {
        if (_itemType != value)
        {
          _itemType = value ?? "";
          OnPropertyChanged(nameof(ItemType));
        }
      }
    }

    public byte ItemStars
    {
      get => _itemStars;
      set
      {
        if (_itemStars != value)
        {
          _itemStars = value;
          OnPropertyChanged(nameof(ItemStars));
        }
      }
    }

    public ItemSources ItemSource
    {
      get => _itemSource;
      set
      {
        if (_itemSource != value)
        {
          _itemSource = value;
          OnPropertyChanged(nameof(ItemSource));
        }
      }
    }

    public byte DinhViPhuTime
    {
      get => _dinhViPhuTime;
      set
      {
        if (_dinhViPhuTime != value)
        {
          _dinhViPhuTime = value;
          OnPropertyChanged(nameof(DinhViPhuTime));
        }
      }
    }

    public int ItemMapID
    {
      get => _itemMapID;
      set
      {
        if (_itemMapID != value)
        {
          _itemMapID = value;
          OnPropertyChanged(nameof(ItemMapID));
        }
      }
    }

    public int BTDMapID
    {
      get => _btdMapID;
      set
      {
        if (_btdMapID != value)
        {
          _btdMapID = value;
          OnPropertyChanged(nameof(BTDMapID));
        }
      }
    }

    public int BTDposX
    {
      get => _btdposX;
      set
      {
        if (_btdposX != value)
        {
          _btdposX = value;
          OnPropertyChanged(nameof(BTDposX));
        }
      }
    }

    public int BTDposY
    {
      get => _btdposY;
      set
      {
        if (_btdposY != value)
        {
          _btdposY = value;
          OnPropertyChanged(nameof(BTDposY));
        }
      }
    }

    public long LastTimeSeen
    {
      get => _lastTimeSeen;
      set
      {
        if (_lastTimeSeen != value)
        {
          _lastTimeSeen = value;
          OnPropertyChanged(nameof(LastTimeSeen));
        }
      }
    }

    /// <summary>
    /// Check if this inventory slot is empty
    /// </summary>
    public bool CanDisplay
    {
      // Chỉ hiện thị những vật phẩm có trong ô hành nang số 1
      get { return ItemId != 0 && ItemIndex < 30; }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
      if (PropertyChanged != null)
      {
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }
    }

    /// <summary>
    /// Update this item from a CoreLibrary InventoryItem
    /// </summary>
    public void UpdateFrom(SmartBot.InventoryItem source)
    {
      if (source == null) return;

      ItemId = source.ItemID;
      NeedToWait = source.NeedToWait;
      BuyingPrice = source.BuyingPrice;
      SellingPrice = source.SellingPrice;
      RealSpread = source.RealSpread;
      MidSpread = source.MidSpread;
      HighSpread = source.HighSpread;
      LowSpread = source.LowSpread;
      HasHistory = source.HasHistory;
      ItemCount = source.ItemCount;
      ItemName = source.ItemName != string.Empty ? source.ItemName : source.ItemID.ToString();
      SaveNameCode = source.SaveNameCode;
      ItemGUID1 = source.ItemGUID1;
      ItemGUID2 = source.ItemGUID2;
      Lines = source.Lines;
      LineValueArray = source.LineValueArray;
      SavedCode = source.SavedCode;
      ItemType = source.ItemType;
      ItemStars = source.ItemStars;
      ItemSource = source.ItemSource;
      DinhViPhuTime = source.DinhViPhuTime;
      ItemMapID = source.ItemMapID;
      BTDMapID = source.BTDMapID;
      BTDposX = source.BTDposX;
      BTDposY = source.BTDposY;
      LastTimeSeen = source.LastTimeSeen;

      // Notify that IsEmpty might have changed
      OnPropertyChanged(nameof(CanDisplay));
    }
  }
}
