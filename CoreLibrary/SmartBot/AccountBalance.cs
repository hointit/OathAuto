// Decompiled with JetBrains decompiler
// Type: SmartBot.AccountBalance
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security;

#nullable disable
namespace SmartBot;

public class AccountBalance : INotifyPropertyChanged
{
  private string _username = "";
  public LicenseManager MyLicense = new LicenseManager();
  public List<HistoryItem> ListHistory = new List<HistoryItem>();
  public List<PriceItem> BangGia = new List<PriceItem>();
  public List<BuyItem> ListBuyItem = new List<BuyItem>();
  public string Password = "";
  public double RemainBalance;
  private double _GGBalance;
  private string _RemainGGDisplay = "0";
  private double _TotalBalance;
  private string _TitleDisplay = "GAuto TLBB";
  private string _RemainGGPromoDisplay = "0";
  private double _GGPromo;
  private double _duration;
  private string _shorthandung = "";
  private string _handung = "";
  public long LastLogin;
  public string Game = "";
  public long LastValidTimeStamp;
  public bool IsExpired;
  public DateTime ExpireDate;
  public int EncryptionTime;
  public SecureString TempSalt = new SecureString();
  public SecureString TempKey = new SecureString();
  public SecureString TrafficKey = new SecureString();
  public bool IsLoginGGold;
  public string AutoMessage = "Buff máu + đánh quái nhanh nhất";
  public int EmptySecondHits;
  public int EmptySecondQ123Hits;
  public int EmptySecondYTOHits;
  public long LastValidTimeStampQ12;
  public long LastValidTimeStampYTO;
  public int RequestGG24h;
  public string UniqueSessionID = "-1";
  public object BuyBlockDays = (object) 0;
  public int IsFreeMode = -1;
  public GAutoList<TinhNangElement> CheDoInfo = new GAutoList<TinhNangElement>();
  public GAutoList<TinhNangElement> TraderInfo = new GAutoList<TinhNangElement>();
  private int _Price1HQuest = 20;
  private int _Price3HQuest = 50;
  private int _CraftingPrice = 30;
  public int CheDoRemMin = 9999999;
  public int TraderRemMin = 9999999;
  public int CheDoRemMax;
  public int TraderRemMax;
  public int TraderPrice = 30;
  public string CyberDate = "0";
  public string ServerString = "";
  public long LastValidTimeStampCheDo;
  public int EmptySecondCDHits;

  public event PropertyChangedEventHandler PropertyChanged;

  private void NotifyPropertyChanged(string info)
  {
    if (this.PropertyChanged == null)
      return;
    try
    {
      if (frmMain.frmMainInstance.tabDieuKhien.InvokeRequired)
        frmMain.frmMainInstance.tabDieuKhien.Invoke((Delegate) (() => this.PropertyChanged((object) this, new PropertyChangedEventArgs(info))));
      else
        this.PropertyChanged((object) this, new PropertyChangedEventArgs(info));
    }
    catch (Exception ex)
    {
    }
  }

  public string Username
  {
    get => this._username;
    set
    {
      if (!(this._username != value))
        return;
      this._username = value;
      this.NotifyPropertyChanged(nameof (Username));
    }
  }

  public double RemainGGoldBalance
  {
    get => this._GGBalance;
    set
    {
      if (this._GGBalance == value && value > 0.0)
        return;
      this._GGBalance = value;
      this.RemainGGDisplay = $"{value / frmLogin.GGUnitDivision:n0}";
      this.TotalBalance = (this.RemainGGoldBalance + this.RemainGGoldPromo) / frmLogin.GGUnitDivision;
      this.NotifyPropertyChanged(nameof (RemainGGoldBalance));
    }
  }

  public string RemainGGDisplay
  {
    get => this._RemainGGDisplay;
    set
    {
      if (!(this._RemainGGDisplay != value))
        return;
      this._RemainGGDisplay = value;
      this.NotifyPropertyChanged(nameof (RemainGGDisplay));
    }
  }

  public double TotalBalance
  {
    get => this._TotalBalance;
    set
    {
      if (this._TotalBalance == value && value > 0.0)
        return;
      this._TotalBalance = value;
      this.TitleDisplay = frmLogin.HiddenMode ? GA.RandomSentence(1) : string.Format("{0}-{1} | {2} " + frmLogin.GGUnit, (object) frmMain.langProductName, (object) GA.GetMyVersion(), (object) this._TotalBalance.ToString("0.0").Replace(".0", ""));
      this.NotifyPropertyChanged(nameof (TotalBalance));
    }
  }

  public string TitleDisplay
  {
    get => this._TitleDisplay;
    set
    {
      if (!(this._TitleDisplay != value))
        return;
      this._TitleDisplay = value;
      this.NotifyPropertyChanged(nameof (TitleDisplay));
    }
  }

  public string RemainGGPromoDisplay
  {
    get => this._RemainGGPromoDisplay;
    set
    {
      if (!(this._RemainGGPromoDisplay != value))
        return;
      this._RemainGGPromoDisplay = value;
      this.NotifyPropertyChanged(nameof (RemainGGPromoDisplay));
    }
  }

  public double RemainGGoldPromo
  {
    get => this._GGPromo;
    set
    {
      if (this._GGPromo == value && value > 0.0)
        return;
      this._GGPromo = value;
      this.RemainGGPromoDisplay = $"{this.RemainGGoldPromo / frmLogin.GGUnitDivision:n0}";
      this.TotalBalance = (this.RemainGGoldBalance + this.RemainGGoldPromo) / frmLogin.GGUnitDivision;
      this.NotifyPropertyChanged(nameof (RemainGGoldPromo));
    }
  }

  public double RemainMSeconds
  {
    get => this._duration;
    set
    {
      this._duration = value;
      TimeSpan timeSpan = TimeSpan.FromSeconds(this._duration / 1000.0);
      string str1 = $"{timeSpan.Days.ToString("0")} ngày, {timeSpan.Hours.ToString("00")} giờ {timeSpan.Minutes.ToString("00")} phút";
      if (str1 != this.Handung)
        this.Handung = str1;
      string str2 = $"{timeSpan.Days.ToString("0")} ngày, {timeSpan.Hours.ToString("00")}:{timeSpan.Minutes.ToString("00")}";
      if (!(str2 != this.Shorthandung))
        return;
      this.Shorthandung = str2;
    }
  }

  public string Shorthandung
  {
    get => this._shorthandung;
    set
    {
      if (!(this._shorthandung != value))
        return;
      this._shorthandung = value;
      this.NotifyPropertyChanged(nameof (Shorthandung));
    }
  }

  public string Handung
  {
    get => this._handung;
    set
    {
      if (!(this._handung != value))
        return;
      this._handung = value;
      this.NotifyPropertyChanged(nameof (Handung));
    }
  }

  public AccountBalance()
  {
    this.TempKey.AppendChar('Y');
    this.TempKey.AppendChar('8');
    this.TempKey.AppendChar('g');
    this.TempKey.AppendChar('9');
    this.TempKey.AppendChar('z');
    this.TempKey.AppendChar('k');
    this.TempKey.AppendChar('P');
    this.TempKey.AppendChar('o');
    this.TempKey.AppendChar('r');
    this.TempKey.AppendChar('i');
    this.TempSalt.AppendChar('H');
    this.TempSalt.AppendChar('a');
    this.TempSalt.AppendChar('c');
    this.TempSalt.AppendChar('k');
    this.TempSalt.AppendChar('?');
    this.TempSalt.AppendChar('c');
    this.TempSalt.AppendChar('c');
    this.TempSalt.AppendChar('t');
    this.TempSalt.AppendChar('n');
    this.TempSalt.AppendChar('!');
  }

  public int Price1HQuest
  {
    get => this._Price1HQuest;
    set
    {
      if (value == 0)
        return;
      this._Price1HQuest = value;
    }
  }

  public int Price3HQuest
  {
    get => this._Price3HQuest;
    set
    {
      if (value == 0)
        return;
      this._Price3HQuest = value;
    }
  }

  public int CraftingPrice
  {
    get => this._CraftingPrice;
    set
    {
      if (value == 0)
        return;
      this._CraftingPrice = value;
    }
  }
}
