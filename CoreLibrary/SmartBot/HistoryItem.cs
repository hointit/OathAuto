// Decompiled with JetBrains decompiler
// Type: SmartBot.HistoryItem
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System;
using System.ComponentModel;

#nullable disable
namespace SmartBot;

public class HistoryItem : INotifyPropertyChanged
{
  private int _Index = -1;
  private DateTime _ActDate = DateTime.Now;
  private string _comment = "";
  private string _cost = "";
  private string _balance = "";

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

  public DateTime ActDate
  {
    get => this._ActDate;
    set
    {
      if (!(this._ActDate != value))
        return;
      this._ActDate = value;
      this.NotifyPropertyChanged(nameof (ActDate));
    }
  }

  public string Comment
  {
    get => this._comment;
    set
    {
      if (!(this._comment != value))
        return;
      this._comment = value;
      this.NotifyPropertyChanged(nameof (Comment));
    }
  }

  public string Cost
  {
    get => this._cost;
    set
    {
      if (!(this._cost != value))
        return;
      this._cost = value;
      this.NotifyPropertyChanged(nameof (Cost));
    }
  }

  public string Balance
  {
    get => this._balance;
    set
    {
      if (!(this._balance != value))
        return;
      this._balance = value;
      this.NotifyPropertyChanged(nameof (Balance));
    }
  }
}
