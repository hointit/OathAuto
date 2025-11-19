// Decompiled with JetBrains decompiler
// Type: EXControls.EXControlListViewSubItem
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System.Windows.Forms;

#nullable disable
namespace EXControls;

public class EXControlListViewSubItem : EXListViewSubItemAB
{
  private Control _control;

  public Control MyControl
  {
    get => this._control;
    set => this._control = value;
  }

  public override int DoDraw(DrawListViewSubItemEventArgs e, int x, EXColumnHeader ch) => x;
}
