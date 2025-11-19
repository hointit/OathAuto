// Decompiled with JetBrains decompiler
// Type: EXControls.EXMultipleImagesListViewSubItem
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System.Collections;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace EXControls;

public class EXMultipleImagesListViewSubItem : EXListViewSubItemAB
{
  private ArrayList _images;

  public EXMultipleImagesListViewSubItem()
  {
  }

  public EXMultipleImagesListViewSubItem(string text) => this.Text = text;

  public EXMultipleImagesListViewSubItem(ArrayList images) => this._images = images;

  public EXMultipleImagesListViewSubItem(ArrayList images, string value)
  {
    this._images = images;
    this.MyValue = value;
  }

  public EXMultipleImagesListViewSubItem(string text, ArrayList images, string value)
  {
    this.Text = text;
    this._images = images;
    this.MyValue = value;
  }

  public ArrayList MyImages
  {
    get => this._images;
    set => this._images = value;
  }

  public override int DoDraw(DrawListViewSubItemEventArgs e, int x, EXColumnHeader ch)
  {
    if (this.MyImages != null && this.MyImages.Count > 0)
    {
      for (int index = 0; index < this.MyImages.Count; ++index)
      {
        Image myImage = (Image) this.MyImages[index];
        int y = e.Bounds.Y + e.Bounds.Height / 2 - myImage.Height / 2;
        e.Graphics.DrawImage(myImage, x, y, myImage.Width, myImage.Height);
        x += myImage.Width + 2;
      }
    }
    return x;
  }
}
