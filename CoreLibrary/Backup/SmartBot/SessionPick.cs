// Decompiled with JetBrains decompiler
// Type: SmartBot.SessionPick
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System.Collections.Generic;
using System.ComponentModel;

#nullable disable
namespace SmartBot;

public class SessionPick : INotifyPropertyChanged
{
  public string autoid = "";
  public string logout = "1";
  private int _id = -1;
  private string _hwid = "";
  private string _lastseen = "";
  private string _exp = "";
  private string _tinhnang = "";
  public List<PriceItem> LastPriceItem = new List<PriceItem>();

  public event PropertyChangedEventHandler PropertyChanged;

  private void NotifyPropertyChanged(string info)
  {
    if (this.PropertyChanged == null)
      return;
    this.PropertyChanged((object) this, new PropertyChangedEventArgs(info));
  }

  public int col_ID
  {
    get => this._id;
    set
    {
      if (this._id == value)
        return;
      this._id = value;
      this.NotifyPropertyChanged(nameof (col_ID));
    }
  }

  public string col_HWID
  {
    get => this._hwid;
    set
    {
      if (!(this._hwid != value))
        return;
      this._hwid = value;
      this.NotifyPropertyChanged(nameof (col_HWID));
    }
  }

  public string col_LastSeen
  {
    get => this._lastseen;
    set
    {
      if (!(this._lastseen != value))
        return;
      this._lastseen = value;
      this.NotifyPropertyChanged(nameof (col_LastSeen));
    }
  }

  public string col_Exp
  {
    get => this._exp;
    set
    {
      if (!(this._exp != value))
        return;
      this._exp = value.Contains("1970") ? "Hết hạn - miễn phí" : value;
      this.NotifyPropertyChanged(nameof (col_Exp));
    }
  }

  public string col_Tinhnang
  {
    get => this._tinhnang;
    set
    {
      if (!(this._tinhnang != value))
        return;
      this._tinhnang = value;
      this.NotifyPropertyChanged(nameof (col_Tinhnang));
    }
  }
}
