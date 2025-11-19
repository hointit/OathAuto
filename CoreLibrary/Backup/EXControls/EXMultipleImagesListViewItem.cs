// Decompiled with JetBrains decompiler
// Type: EXControls.EXMultipleImagesListViewItem
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System.Collections;

#nullable disable
namespace EXControls;

public class EXMultipleImagesListViewItem : EXListViewItem
{
  private ArrayList _images;

  public EXMultipleImagesListViewItem()
  {
  }

  public EXMultipleImagesListViewItem(string text) => this.Text = text;

  public EXMultipleImagesListViewItem(ArrayList images) => this._images = images;

  public EXMultipleImagesListViewItem(string text, ArrayList images)
  {
    this.Text = text;
    this._images = images;
  }

  public EXMultipleImagesListViewItem(string text, ArrayList images, string value)
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
}
