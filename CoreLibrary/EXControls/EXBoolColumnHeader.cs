// Decompiled with JetBrains decompiler
// Type: EXControls.EXBoolColumnHeader
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System.Drawing;

#nullable disable
namespace EXControls;

public class EXBoolColumnHeader : EXColumnHeader
{
  private Image _trueimage;
  private Image _falseimage;
  private bool _editable;

  public EXBoolColumnHeader() => this.init();

  public EXBoolColumnHeader(string text)
  {
    this.init();
    this.Text = text;
  }

  public EXBoolColumnHeader(string text, int width)
  {
    this.init();
    this.Text = text;
    this.Width = width;
  }

  public EXBoolColumnHeader(string text, Image trueimage, Image falseimage)
  {
    this.init();
    this.Text = text;
    this._trueimage = trueimage;
    this._falseimage = falseimage;
  }

  public EXBoolColumnHeader(string text, Image trueimage, Image falseimage, int width)
  {
    this.init();
    this.Text = text;
    this._trueimage = trueimage;
    this._falseimage = falseimage;
    this.Width = width;
  }

  private void init() => this._editable = false;

  public Image TrueImage
  {
    get => this._trueimage;
    set => this._trueimage = value;
  }

  public Image FalseImage
  {
    get => this._falseimage;
    set => this._falseimage = value;
  }

  public bool Editable
  {
    get => this._editable;
    set => this._editable = value;
  }
}
