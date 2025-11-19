// Decompiled with JetBrains decompiler
// Type: SmartBot.TinhNang
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System;
using System.ComponentModel;

#nullable disable
namespace SmartBot;

public class TinhNang : INotifyPropertyChanged
{
  private int _Index;
  private string _Tinhnang = "";
  private string _GiaHanTime = "Chọn";
  private string _Remain = "Hết hạn";
  public long stampExpired;
  private long _remainMS;
  private string _Comment = "(xxx) Yến Tử Ổ - 2pt - 1h";
  private string _tnkey = "na";
  public string SlotID = "";
  public int Slot;
  public string SlotUnit = "day";
  public int SlotCount;
  public string SlotCountUnit = "player";
  private bool _giahan = true;

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

  public int Index
  {
    get => this._Index;
    set
    {
      if (this._Index == value)
        return;
      this._Index = value;
      this.NotifyPropertyChanged(nameof (Index));
    }
  }

  public string Tinhnang
  {
    get => this._Tinhnang;
    set
    {
      if (!(this._Tinhnang != value))
        return;
      this._Tinhnang = value;
      this.NotifyPropertyChanged(nameof (Tinhnang));
    }
  }

  public string GiaHanTime
  {
    get => this._GiaHanTime;
    set
    {
      if (!(this._GiaHanTime != value) || value == null)
        return;
      this._GiaHanTime = value;
      this.NotifyPropertyChanged(nameof (GiaHanTime));
    }
  }

  public string Remain
  {
    get => this._Remain;
    set
    {
      if (!(this._Remain != value))
        return;
      this._Remain = value;
      this.NotifyPropertyChanged(nameof (Remain));
    }
  }

  public long RemainMS
  {
    get => this._remainMS;
    set
    {
      if (this._remainMS == value && value != 0L)
        return;
      this._remainMS = value;
      if (this._remainMS <= 0L)
      {
        this.Remain = "Hết hạn";
      }
      else
      {
        TimeSpan timeSpan = TimeSpan.FromSeconds((double) this._remainMS);
        if (timeSpan.Days > 0)
        {
          this.Remain = $"{timeSpan.Days.ToString()}d {timeSpan.Hours.ToString("00")}:{timeSpan.Minutes.ToString("00")}";
          return;
        }
        this.Remain = $"{timeSpan.Hours.ToString("00")}:{timeSpan.Minutes.ToString("00")}";
      }
      this.NotifyPropertyChanged("Remain");
    }
  }

  public string Comment
  {
    get => this._Comment;
    set
    {
      if (!(this._Comment != value))
        return;
      this._Comment = value;
      this.NotifyPropertyChanged(nameof (Comment));
    }
  }

  public string TNKey
  {
    get => this._tnkey;
    set
    {
      if (!(this._tnkey != value))
        return;
      this._tnkey = value;
      this.Tinhnang = GA.TranslateTNKey(this._tnkey, false);
      string str1 = !(this.SlotUnit == "day") ? this.Slot.ToString() + " giờ" : (this.Slot <= 0 || this.Slot % 30 != 0 ? this.Slot.ToString() + " ngày" : (this.Slot % 30).ToString() + " tháng");
      string str2 = !(this.SlotCountUnit == "player") ? this.SlotCount.ToString() + " party" : this.SlotCount.ToString() + " nhân vật";
      if (this.TNKey == "time")
        this.Comment = "Gói " + str1;
      else
        this.Comment = $"{str1} {str2}";
    }
  }

  public bool Giahan
  {
    get => this._giahan;
    set
    {
      if (this._giahan == value)
        return;
      this._giahan = value;
      this.NotifyPropertyChanged(nameof (Giahan));
    }
  }
}
