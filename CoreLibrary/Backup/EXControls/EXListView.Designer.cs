// Decompiled with JetBrains decompiler
// Type: EXControls.EXListView
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System;
using System.Collections;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace EXControls;

public class EXListView : ListView
{
  private const uint LVM_FIRST = 4096 /*0x1000*/;
  private const uint LVM_SCROLL = 4116;
  private const int WM_HSCROLL = 276;
  private const int WM_VSCROLL = 277;
  private const int WM_MOUSEWHEEL = 522;
  private const int WM_PAINT = 15;
  private ListViewItem.ListViewSubItem _clickedsubitem;
  private ListViewItem _clickeditem;
  private int _col;
  private TextBox txtbx;
  private int _sortcol;
  private Brush _sortcolbrush;
  private Brush _highlightbrush;
  private int _cpadding;
  private ArrayList _controls;

  [DllImport("user32.dll")]
  private static extern bool SendMessage(IntPtr hWnd, uint m, int wParam, int lParam);

  protected override void WndProc(ref Message m)
  {
    if (m.Msg == 15)
    {
      foreach (EXListView.EmbeddedControl control in this._controls)
      {
        Rectangle bounds = control.MySubItem.Bounds;
        if (bounds.Y > 0 && bounds.Y < this.ClientRectangle.Height)
        {
          control.MyControl.Visible = true;
          control.MyControl.Bounds = new Rectangle(bounds.X + this._cpadding, bounds.Y + this._cpadding, bounds.Width - 2 * this._cpadding, bounds.Height - 2 * this._cpadding);
        }
        else
          control.MyControl.Visible = false;
      }
    }
    switch (m.Msg)
    {
      case 276:
      case 277:
      case 522:
        this.Focus();
        break;
    }
    base.WndProc(ref m);
  }

  private void ScrollMe(int x, int y) => EXListView.SendMessage(this.Handle, 4116U, x, y);

  public EXListView()
  {
    this._cpadding = 4;
    this._controls = new ArrayList();
    this._sortcol = -1;
    this._sortcolbrush = SystemBrushes.ControlLight;
    this._highlightbrush = SystemBrushes.Highlight;
    this.OwnerDraw = true;
    this.FullRowSelect = true;
    this.View = View.Details;
    this.MouseDown += new MouseEventHandler(this.this_MouseDown);
    this.MouseDoubleClick += new MouseEventHandler(this.this_MouseDoubleClick);
    this.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(this.this_DrawColumnHeader);
    this.DrawSubItem += new DrawListViewSubItemEventHandler(this.this_DrawSubItem);
    this.MouseMove += new MouseEventHandler(this.this_MouseMove);
    this.ColumnClick += new ColumnClickEventHandler(this.this_ColumnClick);
    this.txtbx = new TextBox();
    this.txtbx.Visible = false;
    this.Controls.Add((Control) this.txtbx);
    this.txtbx.Leave += new EventHandler(this.c_Leave);
    this.txtbx.KeyPress += new KeyPressEventHandler(this.txtbx_KeyPress);
  }

  public void AddControlToSubItem(Control control, EXControlListViewSubItem subitem)
  {
    this.Controls.Add(control);
    subitem.MyControl = control;
    EXListView.EmbeddedControl embeddedControl;
    embeddedControl.MyControl = control;
    embeddedControl.MySubItem = subitem;
    control.Margin = new Padding(0, 5, 0, 0);
    this._controls.Add((object) embeddedControl);
  }

  public void RemoveControlFromSubItem(EXControlListViewSubItem subitem)
  {
    Control myControl = subitem.MyControl;
    for (int index = 0; index < this._controls.Count; ++index)
    {
      if (((EXListView.EmbeddedControl) this._controls[index]).MySubItem == subitem)
      {
        this._controls.RemoveAt(index);
        subitem.MyControl = (Control) null;
        this.Controls.Remove(myControl);
        myControl.Dispose();
        break;
      }
    }
  }

  public int ControlPadding
  {
    get => this._cpadding;
    set => this._cpadding = value;
  }

  public Brush MySortBrush
  {
    get => this._sortcolbrush;
    set => this._sortcolbrush = value;
  }

  public Brush MyHighlightBrush
  {
    get => this._highlightbrush;
    set => this._highlightbrush = value;
  }

  private void txtbx_KeyPress(object sender, KeyPressEventArgs e)
  {
    if (e.KeyChar != '\r')
      return;
    this._clickedsubitem.Text = this.txtbx.Text;
    this.txtbx.Visible = false;
    this._clickeditem.Tag = (object) null;
  }

  private void c_Leave(object sender, EventArgs e)
  {
    Control control = (Control) sender;
    this._clickedsubitem.Text = control.Text;
    control.Visible = false;
    this._clickeditem.Tag = (object) null;
  }

  private void this_MouseDown(object sender, MouseEventArgs e)
  {
    ListViewItem.ListViewSubItem subItem = this.HitTest(e.X, e.Y).SubItem;
    if (subItem == null)
      return;
    int left = subItem.Bounds.Left;
    if (left >= 0)
      return;
    this.ScrollMe(left, 0);
  }

  private void this_MouseDoubleClick(object sender, MouseEventArgs e)
  {
    if (!(this.GetItemAt(e.X, e.Y) is EXListViewItem itemAt))
      return;
    this._clickeditem = (ListViewItem) itemAt;
    int left = itemAt.Bounds.Left;
    int index;
    for (index = 0; index < this.Columns.Count; ++index)
    {
      left += this.Columns[index].Width;
      if (left > e.X)
      {
        left -= this.Columns[index].Width;
        this._clickedsubitem = itemAt.SubItems[index];
        this._col = index;
        break;
      }
    }
    if (!(this.Columns[index] is EXColumnHeader))
      return;
    EXColumnHeader column = (EXColumnHeader) this.Columns[index];
    if (column.GetType() != typeof (EXEditableColumnHeader))
    {
      if (column.GetType() != typeof (EXBoolColumnHeader) || !((EXBoolColumnHeader) column).Editable)
        return;
      EXBoolListViewSubItem clickedsubitem = (EXBoolListViewSubItem) this._clickedsubitem;
      clickedsubitem.BoolValue = !clickedsubitem.BoolValue;
      this.Invalidate(clickedsubitem.Bounds);
    }
    else
    {
      EXEditableColumnHeader editableColumnHeader = (EXEditableColumnHeader) column;
      if (editableColumnHeader.MyControl != null)
      {
        Control myControl = editableColumnHeader.MyControl;
        if (myControl.Tag != null)
        {
          this.Controls.Add(myControl);
          myControl.Tag = (object) null;
          if (myControl is ComboBox)
            ((ListControl) myControl).SelectedValueChanged += new EventHandler(this.cmbx_SelectedValueChanged);
          myControl.Leave += new EventHandler(this.c_Leave);
        }
        myControl.Location = new Point(left, this.GetItemRect(this.Items.IndexOf((ListViewItem) itemAt)).Y);
        myControl.Width = this.Columns[index].Width;
        if (myControl.Width > this.Width)
          myControl.Width = this.ClientRectangle.Width;
        myControl.Text = this._clickedsubitem.Text;
        myControl.Visible = true;
        myControl.BringToFront();
        myControl.Focus();
      }
      else
      {
        this.txtbx.Location = new Point(left, this.GetItemRect(this.Items.IndexOf((ListViewItem) itemAt)).Y);
        this.txtbx.Width = this.Columns[index].Width;
        if (this.txtbx.Width > this.Width)
          this.txtbx.Width = this.ClientRectangle.Width;
        this.txtbx.Text = this._clickedsubitem.Text;
        this.txtbx.Visible = true;
        this.txtbx.BringToFront();
        this.txtbx.Focus();
      }
    }
  }

  private void cmbx_SelectedValueChanged(object sender, EventArgs e)
  {
    if (!((Control) sender).Visible || this._clickedsubitem == null)
      return;
    if (sender.GetType() == typeof (EXComboBox))
    {
      object selectedItem = ((ComboBox) sender).SelectedItem;
      if (selectedItem.GetType() == typeof (EXComboBox.EXImageItem))
      {
        EXComboBox.EXImageItem exImageItem = (EXComboBox.EXImageItem) selectedItem;
        if (this._col == 0)
        {
          if (this._clickeditem.GetType() == typeof (EXImageListViewItem))
            ((EXImageListViewItem) this._clickeditem).MyImage = exImageItem.MyImage;
          else if (this._clickeditem.GetType() == typeof (EXMultipleImagesListViewItem))
          {
            EXMultipleImagesListViewItem clickeditem = (EXMultipleImagesListViewItem) this._clickeditem;
            clickeditem.MyImages.Clear();
            clickeditem.MyImages.AddRange((ICollection) new object[1]
            {
              (object) exImageItem.MyImage
            });
          }
        }
        else if (this._clickedsubitem.GetType() == typeof (EXImageListViewSubItem))
          ((EXImageListViewSubItem) this._clickedsubitem).MyImage = exImageItem.MyImage;
        else if (this._clickedsubitem.GetType() == typeof (EXMultipleImagesListViewSubItem))
        {
          EXMultipleImagesListViewSubItem clickedsubitem = (EXMultipleImagesListViewSubItem) this._clickedsubitem;
          clickedsubitem.MyImages.Clear();
          clickedsubitem.MyImages.Add((object) exImageItem.MyImage);
          clickedsubitem.MyValue = exImageItem.MyValue;
        }
      }
      else if (selectedItem.GetType() == typeof (EXComboBox.EXMultipleImagesItem))
      {
        EXComboBox.EXMultipleImagesItem multipleImagesItem = (EXComboBox.EXMultipleImagesItem) selectedItem;
        if (this._col == 0)
        {
          if (this._clickeditem.GetType() == typeof (EXImageListViewItem))
            ((EXImageListViewItem) this._clickeditem).MyImage = (Image) multipleImagesItem.MyImages[0];
          else if (this._clickeditem.GetType() == typeof (EXMultipleImagesListViewItem))
          {
            EXMultipleImagesListViewItem clickeditem = (EXMultipleImagesListViewItem) this._clickeditem;
            clickeditem.MyImages.Clear();
            clickeditem.MyImages.AddRange((ICollection) multipleImagesItem.MyImages);
          }
        }
        else if (this._clickedsubitem.GetType() == typeof (EXImageListViewSubItem))
        {
          EXImageListViewSubItem clickedsubitem = (EXImageListViewSubItem) this._clickedsubitem;
          if (multipleImagesItem.MyImages != null)
            clickedsubitem.MyImage = (Image) multipleImagesItem.MyImages[0];
        }
        else if (this._clickedsubitem.GetType() == typeof (EXMultipleImagesListViewSubItem))
        {
          EXMultipleImagesListViewSubItem clickedsubitem = (EXMultipleImagesListViewSubItem) this._clickedsubitem;
          clickedsubitem.MyImages.Clear();
          clickedsubitem.MyImages.AddRange((ICollection) multipleImagesItem.MyImages);
          clickedsubitem.MyValue = multipleImagesItem.MyValue;
        }
      }
    }
    ComboBox comboBox = (ComboBox) sender;
    this._clickedsubitem.Text = comboBox.Text;
    comboBox.Visible = false;
    this._clickeditem.Tag = (object) null;
  }

  private void this_MouseMove(object sender, MouseEventArgs e)
  {
    ListViewItem itemAt = this.GetItemAt(e.X, e.Y);
    if (itemAt == null || itemAt.Tag != null)
      return;
    this.Invalidate(itemAt.Bounds);
    itemAt.Tag = (object) "t";
  }

  private void this_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
  {
    e.DrawDefault = true;
  }

  private void this_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
  {
    e.DrawBackground();
    if (e.ColumnIndex == this._sortcol)
      e.Graphics.FillRectangle(this._sortcolbrush, e.Bounds);
    if ((e.ItemState & ListViewItemStates.Selected) != (ListViewItemStates) 0)
      e.Graphics.FillRectangle(this._highlightbrush, e.Bounds);
    int y1 = e.Bounds.Y + e.Bounds.Height / 2 - e.SubItem.Font.Height / 2;
    int x1 = e.Bounds.X + 2;
    if (e.ColumnIndex == 0)
    {
      EXListViewItem exListViewItem = (EXListViewItem) e.Item;
      if (exListViewItem.GetType() == typeof (EXImageListViewItem))
      {
        EXImageListViewItem imageListViewItem = (EXImageListViewItem) exListViewItem;
        if (imageListViewItem.MyImage != null)
        {
          Image myImage = imageListViewItem.MyImage;
          int y2 = e.Bounds.Y + e.Bounds.Height / 2 - myImage.Height / 2;
          e.Graphics.DrawImage(myImage, x1, y2, myImage.Width, myImage.Height);
          x1 += myImage.Width + 2;
        }
      }
      e.Graphics.DrawString(e.SubItem.Text, e.SubItem.Font, (Brush) new SolidBrush(e.SubItem.ForeColor), (float) x1, (float) y1);
    }
    else if (!(e.SubItem is EXListViewSubItemAB subItem))
    {
      e.DrawDefault = true;
    }
    else
    {
      int x2 = subItem.DoDraw(e, x1, this.Columns[e.ColumnIndex] as EXColumnHeader);
      e.Graphics.DrawString(e.SubItem.Text, e.SubItem.Font, (Brush) new SolidBrush(e.SubItem.ForeColor), (float) x2, (float) y1);
    }
  }

  private void this_ColumnClick(object sender, ColumnClickEventArgs e)
  {
    if (this.Items.Count == 0)
      return;
    for (int index = 0; index < this.Columns.Count; ++index)
      this.Columns[index].ImageKey = (string) null;
    for (int index = 0; index < this.Items.Count; ++index)
      this.Items[index].Tag = (object) null;
    if (e.Column != this._sortcol)
    {
      this._sortcol = e.Column;
      this.Sorting = SortOrder.Ascending;
      this.Columns[e.Column].ImageKey = "up";
    }
    else if (this.Sorting == SortOrder.Ascending)
    {
      this.Sorting = SortOrder.Descending;
      this.Columns[e.Column].ImageKey = "down";
    }
    else
    {
      this.Sorting = SortOrder.Ascending;
      this.Columns[e.Column].ImageKey = "up";
    }
    if (this._sortcol == 0)
    {
      if (this.Items[0].GetType() == typeof (EXListViewItem))
        this.ListViewItemSorter = (IComparer) new EXListView.ListViewItemComparerText(e.Column, this.Sorting);
      else
        this.ListViewItemSorter = (IComparer) new EXListView.ListViewItemComparerValue(e.Column, this.Sorting);
    }
    else if (this.Items[0].SubItems[this._sortcol].GetType() == typeof (EXListViewSubItemAB))
      this.ListViewItemSorter = (IComparer) new EXListView.ListViewSubItemComparerText(e.Column, this.Sorting);
    else
      this.ListViewItemSorter = (IComparer) new EXListView.ListViewSubItemComparerValue(e.Column, this.Sorting);
  }

  private struct EmbeddedControl
  {
    public Control MyControl;
    public EXControlListViewSubItem MySubItem;
  }

  private class ListViewSubItemComparerText : IComparer
  {
    private int _col;
    private SortOrder _order;

    public ListViewSubItemComparerText()
    {
      this._col = 0;
      this._order = SortOrder.Ascending;
    }

    public ListViewSubItemComparerText(int col, SortOrder order)
    {
      this._col = col;
      this._order = order;
    }

    public int Compare(object x, object y)
    {
      string text1 = ((ListViewItem) x).SubItems[this._col].Text;
      string text2 = ((ListViewItem) y).SubItems[this._col].Text;
      Decimal result1;
      Decimal result2;
      DateTime result3;
      DateTime result4;
      int num = !Decimal.TryParse(text1, out result1) || !Decimal.TryParse(text2, out result2) ? (!DateTime.TryParse(text1, out result3) || !DateTime.TryParse(text2, out result4) ? string.Compare(text1, text2) : DateTime.Compare(result3, result4)) : Decimal.Compare(result1, result2);
      if (this._order == SortOrder.Descending)
        num *= -1;
      return num;
    }
  }

  private class ListViewSubItemComparerValue : IComparer
  {
    private int _col;
    private SortOrder _order;

    public ListViewSubItemComparerValue()
    {
      this._col = 0;
      this._order = SortOrder.Ascending;
    }

    public ListViewSubItemComparerValue(int col, SortOrder order)
    {
      this._col = col;
      this._order = order;
    }

    public int Compare(object x, object y)
    {
      string myValue1 = ((EXListViewSubItemAB) ((ListViewItem) x).SubItems[this._col]).MyValue;
      string myValue2 = ((EXListViewSubItemAB) ((ListViewItem) y).SubItems[this._col]).MyValue;
      Decimal result1;
      Decimal result2;
      DateTime result3;
      DateTime result4;
      int num = !Decimal.TryParse(myValue1, out result1) || !Decimal.TryParse(myValue2, out result2) ? (!DateTime.TryParse(myValue1, out result3) || !DateTime.TryParse(myValue2, out result4) ? string.Compare(myValue1, myValue2) : DateTime.Compare(result3, result4)) : Decimal.Compare(result1, result2);
      if (this._order == SortOrder.Descending)
        num *= -1;
      return num;
    }
  }

  private class ListViewItemComparerText : IComparer
  {
    private int _col;
    private SortOrder _order;

    public ListViewItemComparerText()
    {
      this._col = 0;
      this._order = SortOrder.Ascending;
    }

    public ListViewItemComparerText(int col, SortOrder order)
    {
      this._col = col;
      this._order = order;
    }

    public int Compare(object x, object y)
    {
      string text1 = ((ListViewItem) x).Text;
      string text2 = ((ListViewItem) y).Text;
      Decimal result1;
      Decimal result2;
      DateTime result3;
      DateTime result4;
      int num = !Decimal.TryParse(text1, out result1) || !Decimal.TryParse(text2, out result2) ? (!DateTime.TryParse(text1, out result3) || !DateTime.TryParse(text2, out result4) ? string.Compare(text1, text2) : DateTime.Compare(result3, result4)) : Decimal.Compare(result1, result2);
      if (this._order == SortOrder.Descending)
        num *= -1;
      return num;
    }
  }

  private class ListViewItemComparerValue : IComparer
  {
    private int _col;
    private SortOrder _order;

    public ListViewItemComparerValue()
    {
      this._col = 0;
      this._order = SortOrder.Ascending;
    }

    public ListViewItemComparerValue(int col, SortOrder order)
    {
      this._col = col;
      this._order = order;
    }

    public int Compare(object x, object y)
    {
      string myValue1 = ((EXListViewItem) x).MyValue;
      string myValue2 = ((EXListViewItem) y).MyValue;
      Decimal result1;
      Decimal result2;
      DateTime result3;
      DateTime result4;
      int num = !Decimal.TryParse(myValue1, out result1) || !Decimal.TryParse(myValue2, out result2) ? (!DateTime.TryParse(myValue1, out result3) || !DateTime.TryParse(myValue2, out result4) ? string.Compare(myValue1, myValue2) : DateTime.Compare(result3, result4)) : Decimal.Compare(result1, result2);
      if (this._order == SortOrder.Descending)
        num *= -1;
      return num;
    }
  }
}
