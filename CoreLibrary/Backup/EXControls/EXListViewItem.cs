// Decompiled with JetBrains decompiler
// Type: EXControls.EXListViewItem
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System.Windows.Forms;

#nullable disable
namespace EXControls;

public class EXListViewItem : ListViewItem
{
  private string _value;

  public EXListViewItem()
  {
  }

  public EXListViewItem(string text) => this.Text = text;

  public string MyValue
  {
    get => this._value;
    set => this._value = value;
  }
}
