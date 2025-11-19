// Decompiled with JetBrains decompiler
// Type: EXControls.EXComboBox
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System.Collections;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace EXControls;

internal class EXComboBox : ComboBox
{
  private Brush _highlightbrush;

  public EXComboBox()
  {
    this._highlightbrush = SystemBrushes.Highlight;
    this.DrawMode = DrawMode.OwnerDrawFixed;
    this.DrawItem += new DrawItemEventHandler(this.this_DrawItem);
  }

  public Brush MyHighlightBrush
  {
    get => this._highlightbrush;
    set => this._highlightbrush = value;
  }

  private void this_DrawItem(object sender, DrawItemEventArgs e)
  {
    if (e.Index == -1)
      return;
    e.DrawBackground();
    if ((e.State & DrawItemState.Selected) != DrawItemState.None)
      e.Graphics.FillRectangle(this._highlightbrush, e.Bounds);
    EXComboBox.EXItem exItem = (EXComboBox.EXItem) this.Items[e.Index];
    Rectangle bounds = e.Bounds;
    int x = bounds.X + 2;
    if (exItem.GetType() == typeof (EXComboBox.EXImageItem))
    {
      EXComboBox.EXImageItem exImageItem = (EXComboBox.EXImageItem) exItem;
      if (exImageItem.MyImage != null)
      {
        Image myImage = exImageItem.MyImage;
        int y = bounds.Y + bounds.Height / 2 - myImage.Height / 2 + 1;
        e.Graphics.DrawImage(myImage, x, y, myImage.Width, myImage.Height);
        x += myImage.Width + 2;
      }
    }
    else if (exItem.GetType() == typeof (EXComboBox.EXMultipleImagesItem))
    {
      EXComboBox.EXMultipleImagesItem multipleImagesItem = (EXComboBox.EXMultipleImagesItem) exItem;
      if (multipleImagesItem.MyImages != null)
      {
        for (int index = 0; index < multipleImagesItem.MyImages.Count; ++index)
        {
          Image myImage = (Image) multipleImagesItem.MyImages[index];
          int y = bounds.Y + bounds.Height / 2 - myImage.Height / 2 + 1;
          e.Graphics.DrawImage(myImage, x, y, myImage.Width, myImage.Height);
          x += myImage.Width + 2;
        }
      }
    }
    int y1 = bounds.Y + bounds.Height / 2 - e.Font.Height / 2;
    e.Graphics.DrawString(exItem.Text, e.Font, (Brush) new SolidBrush(e.ForeColor), (float) x, (float) y1);
    e.DrawFocusRectangle();
  }

  public class EXItem
  {
    private string _text = "";
    private string _value = "";

    public EXItem()
    {
    }

    public EXItem(string text) => this._text = text;

    public string Text
    {
      get => this._text;
      set => this._text = value;
    }

    public string MyValue
    {
      get => this._value;
      set => this._value = value;
    }

    public override string ToString() => this._text;
  }

  public class EXImageItem : EXComboBox.EXItem
  {
    private Image _image;

    public EXImageItem()
    {
    }

    public EXImageItem(string text) => this.Text = text;

    public EXImageItem(Image image) => this._image = image;

    public EXImageItem(string text, Image image)
    {
      this.Text = text;
      this._image = image;
    }

    public EXImageItem(Image image, string value)
    {
      this._image = image;
      this.MyValue = value;
    }

    public EXImageItem(string text, Image image, string value)
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

  public class EXMultipleImagesItem : EXComboBox.EXItem
  {
    private ArrayList _images;

    public EXMultipleImagesItem()
    {
    }

    public EXMultipleImagesItem(string text) => this.Text = text;

    public EXMultipleImagesItem(ArrayList images) => this._images = images;

    public EXMultipleImagesItem(string text, ArrayList images)
    {
      this.Text = text;
      this._images = images;
    }

    public EXMultipleImagesItem(ArrayList images, string value)
    {
      this._images = images;
      this.MyValue = value;
    }

    public EXMultipleImagesItem(string text, ArrayList images, string value)
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
}
