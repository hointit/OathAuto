// Decompiled with JetBrains decompiler
// Type: EXControls.EXBoolListViewSubItem
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace EXControls;

public class EXBoolListViewSubItem : EXListViewSubItemAB
{
  private bool _value;

  public EXBoolListViewSubItem()
  {
  }

  public EXBoolListViewSubItem(bool val)
  {
    this._value = val;
    this.MyValue = val.ToString();
  }

  public bool BoolValue
  {
    get => this._value;
    set
    {
      this._value = value;
      this.MyValue = value.ToString();
    }
  }

  public override int DoDraw(DrawListViewSubItemEventArgs e, int x, EXColumnHeader ch)
  {
    EXBoolColumnHeader boolColumnHeader = (EXBoolColumnHeader) ch;
    Image image = !this.BoolValue ? boolColumnHeader.FalseImage : boolColumnHeader.TrueImage;
    int y = e.Bounds.Y + e.Bounds.Height / 2 - image.Height / 2;
    e.Graphics.DrawImage(image, x, y, image.Width, image.Height);
    x += image.Width + 2;
    return x;
  }
}
