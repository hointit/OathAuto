// Decompiled with JetBrains decompiler
// Type: EXControls.EXImageListViewSubItem
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace EXControls;

public class EXImageListViewSubItem : EXListViewSubItemAB
{
  private Image _image;

  public EXImageListViewSubItem()
  {
  }

  public EXImageListViewSubItem(string text) => this.Text = text;

  public EXImageListViewSubItem(Image image) => this._image = image;

  public EXImageListViewSubItem(Image image, string value)
  {
    this._image = image;
    this.MyValue = value;
  }

  public EXImageListViewSubItem(string text, Image image, string value)
  {
    this.Text = text;
    this._image = image;
    this.MyValue = value;
  }

  public Image MyImage
  {
    get => this._image;
    set => this._image = value;
  }

  public override int DoDraw(DrawListViewSubItemEventArgs e, int x, EXColumnHeader ch)
  {
    if (this.MyImage != null)
    {
      Image myImage = this.MyImage;
      int y = e.Bounds.Y + e.Bounds.Height / 2 - myImage.Height / 2;
      e.Graphics.DrawImage(myImage, x, y, myImage.Width, myImage.Height);
      x += myImage.Width + 2;
    }
    return x;
  }
}
