// Decompiled with JetBrains decompiler
// Type: SmartBot.Forms.frmScheduler
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace SmartBot.Forms;

public class frmScheduler : Form
{
  public AutoAccount myAccount;
  private IContainer components;
  private CheckBox cboxScheduler;
  private Timer timer1;
  private Label label2;
  private ComboBox cboHour;
  private Label label1;
  private Label label3;
  private ComboBox cboMinute;
  private Label label4;
  private ComboBox cboEventName;
  private Button btnClose;
  private Button btnAddEvent;
  private ListViewEx lvAllEvents;
  private Button btnDelEvent;
  private Button btnEditEvent;
  private ColumnHeader columnHeader1;
  private ColumnHeader columnHeader2;
  private Label label5;

  public frmScheduler() => this.InitializeComponent();

  private void frmScheduler_Load(object sender, EventArgs e)
  {
  }

  private void btnClose_Click(object sender, EventArgs e) => this.Hide();

  private void frmScheduler_FormClosing(object sender, FormClosingEventArgs e)
  {
    e.Cancel = true;
    this.Hide();
  }

  private void btnAddEvent_Click(object sender, EventArgs e)
  {
    if (this.myAccount == null || !(this.cboEventName.Text != ""))
      return;
    if (this.myAccount.Settings.ListScheduler == null)
      this.myAccount.Settings.ListScheduler = new GAutoList<GEventClass>();
    if (this.myAccount.Settings.ListScheduler == null)
      return;
    GEventClass geventClass = new GEventClass();
    int.TryParse(this.cboHour.Text, out geventClass.Hour);
    int.TryParse(this.cboMinute.Text, out geventClass.Minute);
    geventClass.EventName = this.cboEventName.Text;
    this.myAccount.Settings.ListScheduler.Add(geventClass);
  }

  private void timer1_Tick(object sender, EventArgs e)
  {
    if (this.myAccount == null)
      return;
    if (!this.cboxScheduler.Focused && this.myAccount.Myself != null)
      this.cboxScheduler.Checked = this.myAccount.Myself.IsScheduled;
    this.lvAllEvents.BeginUpdate();
    int length = 0;
    int num = 0;
    if (this.lvAllEvents.Items.Count == 0)
      length = this.myAccount.Settings.ListScheduler.Count;
    else if (this.lvAllEvents.Items.Count > this.myAccount.Settings.ListScheduler.Count)
    {
      num = this.lvAllEvents.Items.Count - this.myAccount.Settings.ListScheduler.Count;
      length = 0;
    }
    else if (this.lvAllEvents.Items.Count < this.myAccount.Settings.ListScheduler.Count)
    {
      num = 0;
      length = this.myAccount.Settings.ListScheduler.Count - this.lvAllEvents.Items.Count;
    }
    List<int> intList = new List<int>();
    if (length > 0)
    {
      this.lvAllEvents.Items.Clear();
      ListViewItem[] items = new ListViewItem[length];
      int index1 = 0;
      try
      {
        for (int index2 = this.myAccount.Settings.ListScheduler.Count - 1; index2 >= 0; --index2)
        {
          GEventClass geventClass = this.myAccount.Settings.ListScheduler[index2];
          bool flag = false;
          foreach (ListViewItem listViewItem in this.lvAllEvents.Items)
          {
            if (geventClass.EventName == listViewItem.SubItems[1].Text && geventClass.FormatHour == listViewItem.Text)
            {
              flag = true;
              break;
            }
          }
          if (!flag)
          {
            items[index1] = new ListViewItem();
            items[index1].Text = geventClass.FormatHour;
            items[index1].SubItems.Add(geventClass.EventName);
            ++index1;
          }
        }
        this.lvAllEvents.Items.AddRange(items);
      }
      catch (Exception ex)
      {
      }
    }
    else if (num > 0)
    {
      try
      {
        List<ListViewItem> listViewItemList = new List<ListViewItem>();
        for (int index3 = this.lvAllEvents.Items.Count - 1; index3 >= 0; --index3)
        {
          ListViewItem listViewItem = this.lvAllEvents.Items[index3];
          bool flag = false;
          for (int index4 = this.myAccount.Settings.ListScheduler.Count - 1; index4 >= 0; --index4)
          {
            GEventClass geventClass = this.myAccount.Settings.ListScheduler[index4];
            if (geventClass.EventName == listViewItem.SubItems[1].Text && geventClass.FormatHour == listViewItem.Text)
            {
              flag = true;
              break;
            }
          }
          if (!flag)
            listViewItemList.Add(listViewItem);
        }
        if (listViewItemList.Count > 0)
        {
          for (int index = listViewItemList.Count - 1; index >= 0; --index)
            this.lvAllEvents.Items.Remove(listViewItemList[index]);
        }
      }
      catch (Exception ex)
      {
      }
    }
    if (this.myAccount.Settings.ListScheduler.Count > 0 && this.myAccount.Settings.ListScheduler.Count == this.lvAllEvents.Items.Count)
    {
      for (int index = 0; index < this.lvAllEvents.Items.Count; ++index)
      {
        this.lvAllEvents.Items[index].Text = this.myAccount.Settings.ListScheduler[index].FormatHour;
        this.lvAllEvents.Items[index].SubItems[1].Text = this.myAccount.Settings.ListScheduler[index].EventName;
      }
    }
    this.lvAllEvents.EndUpdate();
  }

  private void btnDelEvent_Click(object sender, EventArgs e)
  {
    if (this.lvAllEvents.SelectedItems.Count <= 0)
      return;
    for (int index1 = this.lvAllEvents.SelectedItems.Count - 1; index1 >= 0; --index1)
    {
      for (int index2 = this.myAccount.Settings.ListScheduler.Count - 1; index2 >= 0; --index2)
      {
        if (this.myAccount.Settings.ListScheduler[index2].FormatHour == this.lvAllEvents.SelectedItems[index1].Text && this.myAccount.Settings.ListScheduler[index2].EventName == this.lvAllEvents.SelectedItems[index1].SubItems[1].Text)
        {
          this.myAccount.Settings.ListScheduler.RemoveAt(index2);
          break;
        }
      }
    }
    this.myAccount.ListScheduler_OnAdd((object) this.myAccount.Settings.ListScheduler, (EventArgs) null);
  }

  private void cboxScheduler_CheckedChanged(object sender, EventArgs e)
  {
    try
    {
      if (!this.cboxScheduler.Focused)
        return;
      frmMain.frmMainInstance.cboxScheduler.Invoke((Delegate) (() =>
      {
        frmMain.frmMainInstance.cboxScheduler.Focus();
        frmMain.frmMainInstance.cboxScheduler_CheckedChanged(sender, e);
      }));
    }
    catch (Exception ex)
    {
      GA.WriteUserLog("Event Scheduler [1]: " + ex.Message, this.myAccount);
    }
  }

  private void btnEditEvent_Click(object sender, EventArgs e)
  {
    this.myAccount.ListScheduler_OnAdd((object) this.myAccount.Settings.ListScheduler, (EventArgs) null);
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.components != null)
      this.components.Dispose();
    base.Dispose(disposing);
  }

  private void InitializeComponent()
  {
    this.components = (IContainer) new System.ComponentModel.Container();
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmScheduler));
    this.cboxScheduler = new CheckBox();
    this.timer1 = new Timer(this.components);
    this.label2 = new Label();
    this.cboHour = new ComboBox();
    this.label1 = new Label();
    this.label3 = new Label();
    this.cboMinute = new ComboBox();
    this.label4 = new Label();
    this.cboEventName = new ComboBox();
    this.btnClose = new Button();
    this.btnAddEvent = new Button();
    this.btnDelEvent = new Button();
    this.btnEditEvent = new Button();
    this.label5 = new Label();
    this.lvAllEvents = new ListViewEx();
    this.columnHeader1 = new ColumnHeader();
    this.columnHeader2 = new ColumnHeader();
    this.SuspendLayout();
    componentResourceManager.ApplyResources((object) this.cboxScheduler, "cboxScheduler");
    this.cboxScheduler.Name = "cboxScheduler";
    this.cboxScheduler.UseVisualStyleBackColor = true;
    this.cboxScheduler.CheckedChanged += new EventHandler(this.cboxScheduler_CheckedChanged);
    this.timer1.Enabled = true;
    this.timer1.Interval = 400;
    this.timer1.Tick += new EventHandler(this.timer1_Tick);
    componentResourceManager.ApplyResources((object) this.label2, "label2");
    this.label2.Name = "label2";
    this.cboHour.BackColor = Color.FromArgb(206, 233, 253);
    componentResourceManager.ApplyResources((object) this.cboHour, "cboHour");
    this.cboHour.FormattingEnabled = true;
    this.cboHour.Items.AddRange(new object[24]
    {
      (object) componentResourceManager.GetString("cboHour.Items"),
      (object) componentResourceManager.GetString("cboHour.Items1"),
      (object) componentResourceManager.GetString("cboHour.Items2"),
      (object) componentResourceManager.GetString("cboHour.Items3"),
      (object) componentResourceManager.GetString("cboHour.Items4"),
      (object) componentResourceManager.GetString("cboHour.Items5"),
      (object) componentResourceManager.GetString("cboHour.Items6"),
      (object) componentResourceManager.GetString("cboHour.Items7"),
      (object) componentResourceManager.GetString("cboHour.Items8"),
      (object) componentResourceManager.GetString("cboHour.Items9"),
      (object) componentResourceManager.GetString("cboHour.Items10"),
      (object) componentResourceManager.GetString("cboHour.Items11"),
      (object) componentResourceManager.GetString("cboHour.Items12"),
      (object) componentResourceManager.GetString("cboHour.Items13"),
      (object) componentResourceManager.GetString("cboHour.Items14"),
      (object) componentResourceManager.GetString("cboHour.Items15"),
      (object) componentResourceManager.GetString("cboHour.Items16"),
      (object) componentResourceManager.GetString("cboHour.Items17"),
      (object) componentResourceManager.GetString("cboHour.Items18"),
      (object) componentResourceManager.GetString("cboHour.Items19"),
      (object) componentResourceManager.GetString("cboHour.Items20"),
      (object) componentResourceManager.GetString("cboHour.Items21"),
      (object) componentResourceManager.GetString("cboHour.Items22"),
      (object) componentResourceManager.GetString("cboHour.Items23")
    });
    this.cboHour.Name = "cboHour";
    componentResourceManager.ApplyResources((object) this.label1, "label1");
    this.label1.Name = "label1";
    componentResourceManager.ApplyResources((object) this.label3, "label3");
    this.label3.Name = "label3";
    this.cboMinute.BackColor = Color.FromArgb(206, 233, 253);
    componentResourceManager.ApplyResources((object) this.cboMinute, "cboMinute");
    this.cboMinute.FormattingEnabled = true;
    this.cboMinute.Items.AddRange(new object[60]
    {
      (object) componentResourceManager.GetString("cboMinute.Items"),
      (object) componentResourceManager.GetString("cboMinute.Items1"),
      (object) componentResourceManager.GetString("cboMinute.Items2"),
      (object) componentResourceManager.GetString("cboMinute.Items3"),
      (object) componentResourceManager.GetString("cboMinute.Items4"),
      (object) componentResourceManager.GetString("cboMinute.Items5"),
      (object) componentResourceManager.GetString("cboMinute.Items6"),
      (object) componentResourceManager.GetString("cboMinute.Items7"),
      (object) componentResourceManager.GetString("cboMinute.Items8"),
      (object) componentResourceManager.GetString("cboMinute.Items9"),
      (object) componentResourceManager.GetString("cboMinute.Items10"),
      (object) componentResourceManager.GetString("cboMinute.Items11"),
      (object) componentResourceManager.GetString("cboMinute.Items12"),
      (object) componentResourceManager.GetString("cboMinute.Items13"),
      (object) componentResourceManager.GetString("cboMinute.Items14"),
      (object) componentResourceManager.GetString("cboMinute.Items15"),
      (object) componentResourceManager.GetString("cboMinute.Items16"),
      (object) componentResourceManager.GetString("cboMinute.Items17"),
      (object) componentResourceManager.GetString("cboMinute.Items18"),
      (object) componentResourceManager.GetString("cboMinute.Items19"),
      (object) componentResourceManager.GetString("cboMinute.Items20"),
      (object) componentResourceManager.GetString("cboMinute.Items21"),
      (object) componentResourceManager.GetString("cboMinute.Items22"),
      (object) componentResourceManager.GetString("cboMinute.Items23"),
      (object) componentResourceManager.GetString("cboMinute.Items24"),
      (object) componentResourceManager.GetString("cboMinute.Items25"),
      (object) componentResourceManager.GetString("cboMinute.Items26"),
      (object) componentResourceManager.GetString("cboMinute.Items27"),
      (object) componentResourceManager.GetString("cboMinute.Items28"),
      (object) componentResourceManager.GetString("cboMinute.Items29"),
      (object) componentResourceManager.GetString("cboMinute.Items30"),
      (object) componentResourceManager.GetString("cboMinute.Items31"),
      (object) componentResourceManager.GetString("cboMinute.Items32"),
      (object) componentResourceManager.GetString("cboMinute.Items33"),
      (object) componentResourceManager.GetString("cboMinute.Items34"),
      (object) componentResourceManager.GetString("cboMinute.Items35"),
      (object) componentResourceManager.GetString("cboMinute.Items36"),
      (object) componentResourceManager.GetString("cboMinute.Items37"),
      (object) componentResourceManager.GetString("cboMinute.Items38"),
      (object) componentResourceManager.GetString("cboMinute.Items39"),
      (object) componentResourceManager.GetString("cboMinute.Items40"),
      (object) componentResourceManager.GetString("cboMinute.Items41"),
      (object) componentResourceManager.GetString("cboMinute.Items42"),
      (object) componentResourceManager.GetString("cboMinute.Items43"),
      (object) componentResourceManager.GetString("cboMinute.Items44"),
      (object) componentResourceManager.GetString("cboMinute.Items45"),
      (object) componentResourceManager.GetString("cboMinute.Items46"),
      (object) componentResourceManager.GetString("cboMinute.Items47"),
      (object) componentResourceManager.GetString("cboMinute.Items48"),
      (object) componentResourceManager.GetString("cboMinute.Items49"),
      (object) componentResourceManager.GetString("cboMinute.Items50"),
      (object) componentResourceManager.GetString("cboMinute.Items51"),
      (object) componentResourceManager.GetString("cboMinute.Items52"),
      (object) componentResourceManager.GetString("cboMinute.Items53"),
      (object) componentResourceManager.GetString("cboMinute.Items54"),
      (object) componentResourceManager.GetString("cboMinute.Items55"),
      (object) componentResourceManager.GetString("cboMinute.Items56"),
      (object) componentResourceManager.GetString("cboMinute.Items57"),
      (object) componentResourceManager.GetString("cboMinute.Items58"),
      (object) componentResourceManager.GetString("cboMinute.Items59")
    });
    this.cboMinute.Name = "cboMinute";
    componentResourceManager.ApplyResources((object) this.label4, "label4");
    this.label4.Name = "label4";
    this.cboEventName.BackColor = Color.FromArgb(206, 233, 253);
    this.cboEventName.DropDownWidth = 150;
    componentResourceManager.ApplyResources((object) this.cboEventName, "cboEventName");
    this.cboEventName.FormattingEnabled = true;
    this.cboEventName.Items.AddRange(new object[23]
    {
      (object) componentResourceManager.GetString("cboEventName.Items"),
      (object) componentResourceManager.GetString("cboEventName.Items1"),
      (object) componentResourceManager.GetString("cboEventName.Items2"),
      (object) componentResourceManager.GetString("cboEventName.Items3"),
      (object) componentResourceManager.GetString("cboEventName.Items4"),
      (object) componentResourceManager.GetString("cboEventName.Items5"),
      (object) componentResourceManager.GetString("cboEventName.Items6"),
      (object) componentResourceManager.GetString("cboEventName.Items7"),
      (object) componentResourceManager.GetString("cboEventName.Items8"),
      (object) componentResourceManager.GetString("cboEventName.Items9"),
      (object) componentResourceManager.GetString("cboEventName.Items10"),
      (object) componentResourceManager.GetString("cboEventName.Items11"),
      (object) componentResourceManager.GetString("cboEventName.Items12"),
      (object) componentResourceManager.GetString("cboEventName.Items13"),
      (object) componentResourceManager.GetString("cboEventName.Items14"),
      (object) componentResourceManager.GetString("cboEventName.Items15"),
      (object) componentResourceManager.GetString("cboEventName.Items16"),
      (object) componentResourceManager.GetString("cboEventName.Items17"),
      (object) componentResourceManager.GetString("cboEventName.Items18"),
      (object) componentResourceManager.GetString("cboEventName.Items19"),
      (object) componentResourceManager.GetString("cboEventName.Items20"),
      (object) componentResourceManager.GetString("cboEventName.Items21"),
      (object) componentResourceManager.GetString("cboEventName.Items22")
    });
    this.cboEventName.Name = "cboEventName";
    this.btnClose.BackColor = Color.FromArgb(247, 207, 142);
    this.btnClose.ForeColor = Color.Black;
    componentResourceManager.ApplyResources((object) this.btnClose, "btnClose");
    this.btnClose.Name = "btnClose";
    this.btnClose.UseVisualStyleBackColor = false;
    this.btnClose.Click += new EventHandler(this.btnClose_Click);
    this.btnAddEvent.BackColor = Color.FromArgb(210, 249, 213);
    this.btnAddEvent.ForeColor = Color.DarkGreen;
    componentResourceManager.ApplyResources((object) this.btnAddEvent, "btnAddEvent");
    this.btnAddEvent.Name = "btnAddEvent";
    this.btnAddEvent.UseVisualStyleBackColor = false;
    this.btnAddEvent.Click += new EventHandler(this.btnAddEvent_Click);
    this.btnDelEvent.BackColor = Color.FromArgb(247, 207, 142);
    this.btnDelEvent.ForeColor = Color.Black;
    componentResourceManager.ApplyResources((object) this.btnDelEvent, "btnDelEvent");
    this.btnDelEvent.Name = "btnDelEvent";
    this.btnDelEvent.UseVisualStyleBackColor = false;
    this.btnDelEvent.Click += new EventHandler(this.btnDelEvent_Click);
    this.btnEditEvent.BackColor = Color.FromArgb(247, 207, 142);
    componentResourceManager.ApplyResources((object) this.btnEditEvent, "btnEditEvent");
    this.btnEditEvent.ForeColor = Color.Black;
    this.btnEditEvent.Name = "btnEditEvent";
    this.btnEditEvent.UseVisualStyleBackColor = false;
    this.btnEditEvent.Click += new EventHandler(this.btnEditEvent_Click);
    componentResourceManager.ApplyResources((object) this.label5, "label5");
    this.label5.ForeColor = Color.Red;
    this.label5.Name = "label5";
    this.lvAllEvents.Columns.AddRange(new ColumnHeader[2]
    {
      this.columnHeader1,
      this.columnHeader2
    });
    this.lvAllEvents.FullRowSelect = true;
    this.lvAllEvents.GridLines = true;
    this.lvAllEvents.LineAfter = -1;
    this.lvAllEvents.LineBefore = -1;
    componentResourceManager.ApplyResources((object) this.lvAllEvents, "lvAllEvents");
    this.lvAllEvents.Name = "lvAllEvents";
    this.lvAllEvents.UseCompatibleStateImageBehavior = false;
    this.lvAllEvents.View = View.Details;
    componentResourceManager.ApplyResources((object) this.columnHeader1, "columnHeader1");
    componentResourceManager.ApplyResources((object) this.columnHeader2, "columnHeader2");
    componentResourceManager.ApplyResources((object) this, "$this");
    this.AutoScaleMode = AutoScaleMode.Font;
    this.Controls.Add((Control) this.label5);
    this.Controls.Add((Control) this.btnEditEvent);
    this.Controls.Add((Control) this.btnDelEvent);
    this.Controls.Add((Control) this.lvAllEvents);
    this.Controls.Add((Control) this.btnAddEvent);
    this.Controls.Add((Control) this.btnClose);
    this.Controls.Add((Control) this.cboEventName);
    this.Controls.Add((Control) this.label4);
    this.Controls.Add((Control) this.label3);
    this.Controls.Add((Control) this.cboMinute);
    this.Controls.Add((Control) this.label1);
    this.Controls.Add((Control) this.label2);
    this.Controls.Add((Control) this.cboHour);
    this.Controls.Add((Control) this.cboxScheduler);
    this.FormBorderStyle = FormBorderStyle.FixedSingle;
    this.MaximizeBox = false;
    this.Name = nameof (frmScheduler);
    this.ShowIcon = false;
    this.FormClosing += new FormClosingEventHandler(this.frmScheduler_FormClosing);
    this.Load += new EventHandler(this.frmScheduler_Load);
    this.ResumeLayout(false);
    this.PerformLayout();
  }
}
