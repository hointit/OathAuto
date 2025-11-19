// Decompiled with JetBrains decompiler
// Type: EXControls.EXImageListViewItem
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System.Drawing;

#nullable disable
namespace EXControls;

public class EXImageListViewItem : EXListViewItem
{
  private Image _image;

  public EXImageListViewItem()
  {
  }

  public EXImageListViewItem(string text) => this.Text = text;

  public EXImageListViewItem(Image image) => this._image = image;

  public EXImageListViewItem(string text, Image image)
  {
    this._image = image;
    this.Text = text;
  }

  public EXImageListViewItem(string text, Image image, string value)
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
}
