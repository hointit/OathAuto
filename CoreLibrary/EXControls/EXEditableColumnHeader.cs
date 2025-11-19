// Decompiled with JetBrains decompiler
// Type: EXControls.EXEditableColumnHeader
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System.Windows.Forms;

#nullable disable
namespace EXControls;

public class EXEditableColumnHeader : EXColumnHeader
{
  private Control _control;

  public EXEditableColumnHeader()
  {
  }

  public EXEditableColumnHeader(string text) => this.Text = text;

  public EXEditableColumnHeader(string text, int width)
  {
    this.Text = text;
    this.Width = width;
  }

  public EXEditableColumnHeader(string text, Control control)
  {
    this.Text = text;
    this.MyControl = control;
  }

  public EXEditableColumnHeader(string text, Control control, int width)
  {
    this.Text = text;
    this.MyControl = control;
    this.Width = width;
  }

  public Control MyControl
  {
    get => this._control;
    set
    {
      this._control = value;
      this._control.Visible = false;
      this._control.Tag = (object) "not_init";
    }
  }
}
