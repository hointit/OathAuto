// Decompiled with JetBrains decompiler
// Type: SmartBot.ListViewEx
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace SmartBot;

public class ListViewEx : ListView
{
  private const int WM_PAINT = 15;
  private int _LineBefore = -1;
  private int _LineAfter = -1;

  public ListViewEx() => this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

  public int LineBefore
  {
    get => this._LineBefore;
    set => this._LineBefore = value;
  }

  public int LineAfter
  {
    get => this._LineAfter;
    set => this._LineAfter = value;
  }

  protected override void WndProc(ref Message m)
  {
    base.WndProc(ref m);
    if (m.Msg != 15)
      return;
    if (this.LineBefore >= 0 && this.LineBefore < this.Items.Count)
    {
      Rectangle bounds = this.Items[this.LineBefore].GetBounds(ItemBoundsPortion.Entire);
      this.DrawInsertionLine(bounds.Left, bounds.Right, bounds.Top);
    }
    if (this.LineAfter < 0 || this.LineBefore >= this.Items.Count)
      return;
    Rectangle bounds1 = this.Items[this.LineAfter].GetBounds(ItemBoundsPortion.Entire);
    this.DrawInsertionLine(bounds1.Left, bounds1.Right, bounds1.Bottom);
  }

  private void DrawInsertionLine(int X1, int X2, int Y)
  {
    using (Graphics graphics = this.CreateGraphics())
    {
      graphics.DrawLine(Pens.Orange, X1, Y, X2 - 1, Y);
      Point[] points1 = new Point[3]
      {
        new Point(X1, Y - 4),
        new Point(X1 + 7, Y),
        new Point(X1, Y + 4)
      };
      Point[] points2 = new Point[3]
      {
        new Point(X2, Y - 4),
        new Point(X2 - 8, Y),
        new Point(X2, Y + 4)
      };
      graphics.FillPolygon(Brushes.Orange, points1);
      graphics.FillPolygon(Brushes.Orange, points2);
    }
  }
}
