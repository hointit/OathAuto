// Decompiled with JetBrains decompiler
// Type: SmartBot.frmPlayerPick
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

#nullable disable
namespace SmartBot;

public class frmPlayerPick : Form
{
  public AutoAccount account;
  public int DialogMode;
  private IContainer components;
  private Button btnXoaName;
  private TextBox txtPlayerName;
  private ListView lvPlayerList;
  private ColumnHeader columnHeader16;
  private Label lblTop;
  private Button btnClose;
  private Timer timer1;
  private ColumnHeader columnHeader1;

  public frmPlayerPick() => this.InitializeComponent();

  private void frmBuffList_Load(object sender, EventArgs e)
  {
  }

  private void btnXoaName_Click(object sender, EventArgs e)
  {
    if (this.account == null)
      return;
    this.txtPlayerName.Focus();
    this.lvPlayerList.SelectedItems.Clear();
    this.txtPlayerName.Text = "";
  }

  private void btnDanhSachBuff_Click(object sender, EventArgs e)
  {
    if (this.account == null)
      return;
    OpenFileDialog openFileDialog = new OpenFileDialog();
    if (openFileDialog.ShowDialog() != DialogResult.OK || string.IsNullOrEmpty(openFileDialog.FileName))
      return;
    StreamReader streamReader = new StreamReader(openFileDialog.FileName);
    if (streamReader == null)
      return;
    while (!streamReader.EndOfStream)
    {
      string str = streamReader.ReadLine();
      if (!string.IsNullOrEmpty(str))
      {
        if (this.DialogMode == 0)
        {
          if (!frmLogin.GAuto.Settings.BuffNameList.Contains(str))
            frmLogin.GAuto.Settings.BuffNameList.Add(str);
        }
        else if (this.DialogMode == 1)
        {
          if (!frmLogin.GAuto.Settings.ItemTuHuyList.Contains(str))
            frmLogin.GAuto.Settings.ItemTuHuyList.Add(str);
        }
        else if (this.DialogMode == 2)
        {
          if (!frmLogin.GAuto.Settings.ItemBanList.Contains(str))
            frmLogin.GAuto.Settings.ItemBanList.Add(str);
        }
        else if (this.DialogMode == 3)
        {
          if (!this.account.Settings.AutoPartyList.Contains(str))
            this.account.Settings.AutoPartyList.Add(str);
        }
        else if (this.DialogMode == 4)
        {
          if (!this.account.Settings.PTBlacklist.Contains(str))
            this.account.Settings.PTBlacklist.Add(str);
        }
        else if (this.DialogMode == 5)
        {
          if (!frmLogin.GAuto.Settings.ListItemNhat.Contains(str))
          {
            lock (frmLogin.lockListItemNhat)
              frmLogin.GAuto.Settings.ListItemNhat.Add(str);
          }
        }
        else if (this.DialogMode == 6 && !this.account.Settings.PKPlayerList.Contains(str))
          this.account.Settings.PKPlayerList.Add(str);
      }
    }
    streamReader.Close();
  }

  private void lvBuffList_MouseDoubleClick(object sender, MouseEventArgs e)
  {
    ListView listView = sender as ListView;
    if (listView.SelectedItems.Count <= 0)
      return;
    ListViewItem selectedItem = listView.SelectedItems[0];
    if (this.account == null || string.IsNullOrEmpty(selectedItem.Text))
      return;
    switch (this.DialogMode)
    {
      case 0:
        frmLogin.GAuto.Settings.BuffNameList.Remove(selectedItem.Text);
        break;
      case 1:
        frmLogin.GAuto.Settings.ItemTuHuyList.Remove(selectedItem.Text);
        break;
      case 2:
        frmLogin.GAuto.Settings.ItemBanList.Remove(selectedItem.Text);
        break;
      case 3:
        this.account.Settings.AutoPartyList.Remove(selectedItem.Text);
        break;
      case 4:
        this.account.Settings.PTBlacklist.Remove(selectedItem.Text);
        break;
      case 5:
        lock (frmLogin.lockListItemNhat)
        {
          frmLogin.GAuto.Settings.ListItemNhat.Remove(selectedItem.Text);
          break;
        }
      case 6:
        this.account.Settings.PKPlayerList.Remove(selectedItem.Text);
        break;
    }
  }

  private void timer1_Tick(object sender, EventArgs e)
  {
    if (this.account == null)
      return;
    frmMain.BindPlayerListToListView(this.account, this.lvPlayerList, (GAutoList<string>) null);
  }

  private void btnClose_Click(object sender, EventArgs e)
  {
    this.Close();
    this.Dispose();
  }

  private void frmBuffList_Shown(object sender, EventArgs e)
  {
    switch (this.DialogMode)
    {
      case 0:
        this.lblTop.Text = frmMain.langAttackFollow;
        this.lvPlayerList.Columns[0].Text = frmMain.langPlayerName;
        this.Text = frmMain.langAttackFollow2;
        break;
      case 1:
        this.lblTop.Text = frmMain.langNameToFollow;
        this.lvPlayerList.Columns[0].Text = frmMain.langPlayerName;
        this.Text = frmMain.langFollowSomeone;
        break;
    }
  }

  private void label1_Click(object sender, EventArgs e)
  {
  }

  private void txtBuffName_TextChanged(object sender, EventArgs e)
  {
    if (this.account == null)
      return;
    if (this.DialogMode == 0)
    {
      this.account.Settings.txtDanhTheoAi = this.txtPlayerName.Text;
    }
    else
    {
      if (this.DialogMode != 1)
        return;
      this.account.Settings.txtTheoSauName = this.txtPlayerName.Text;
    }
  }

  private void lvPlayerList_SelectedIndexChanged(object sender, EventArgs e)
  {
    ListView listView = sender as ListView;
    if (listView.SelectedItems.Count <= 0)
      return;
    ListViewItem selectedItem = listView.SelectedItems[0];
    if (!(selectedItem.Text != ""))
      return;
    this.txtPlayerName.Text = selectedItem.Text;
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
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmPlayerPick));
    this.btnXoaName = new Button();
    this.txtPlayerName = new TextBox();
    this.lvPlayerList = new ListView();
    this.columnHeader16 = new ColumnHeader();
    this.columnHeader1 = new ColumnHeader();
    this.lblTop = new Label();
    this.btnClose = new Button();
    this.timer1 = new Timer(this.components);
    this.SuspendLayout();
    this.btnXoaName.BackColor = Color.FromArgb(210, 249, 213);
    componentResourceManager.ApplyResources((object) this.btnXoaName, "btnXoaName");
    this.btnXoaName.Name = "btnXoaName";
    this.btnXoaName.UseVisualStyleBackColor = false;
    this.btnXoaName.Click += new EventHandler(this.btnXoaName_Click);
    this.txtPlayerName.BackColor = Color.WhiteSmoke;
    componentResourceManager.ApplyResources((object) this.txtPlayerName, "txtPlayerName");
    this.txtPlayerName.Name = "txtPlayerName";
    this.txtPlayerName.TextChanged += new EventHandler(this.txtBuffName_TextChanged);
    this.lvPlayerList.BackColor = Color.WhiteSmoke;
    this.lvPlayerList.Columns.AddRange(new ColumnHeader[2]
    {
      this.columnHeader16,
      this.columnHeader1
    });
    this.lvPlayerList.FullRowSelect = true;
    this.lvPlayerList.GridLines = true;
    this.lvPlayerList.HeaderStyle = ColumnHeaderStyle.Nonclickable;
    componentResourceManager.ApplyResources((object) this.lvPlayerList, "lvPlayerList");
    this.lvPlayerList.Name = "lvPlayerList";
    this.lvPlayerList.UseCompatibleStateImageBehavior = false;
    this.lvPlayerList.View = View.Details;
    this.lvPlayerList.SelectedIndexChanged += new EventHandler(this.lvPlayerList_SelectedIndexChanged);
    this.lvPlayerList.MouseDoubleClick += new MouseEventHandler(this.lvBuffList_MouseDoubleClick);
    componentResourceManager.ApplyResources((object) this.columnHeader16, "columnHeader16");
    componentResourceManager.ApplyResources((object) this.columnHeader1, "columnHeader1");
    componentResourceManager.ApplyResources((object) this.lblTop, "lblTop");
    this.lblTop.Name = "lblTop";
    this.btnClose.BackColor = Color.FromArgb(210, 249, 213);
    componentResourceManager.ApplyResources((object) this.btnClose, "btnClose");
    this.btnClose.Name = "btnClose";
    this.btnClose.UseVisualStyleBackColor = false;
    this.btnClose.Click += new EventHandler(this.btnClose_Click);
    this.timer1.Enabled = true;
    this.timer1.Interval = 1000;
    this.timer1.Tick += new EventHandler(this.timer1_Tick);
    componentResourceManager.ApplyResources((object) this, "$this");
    this.AutoScaleMode = AutoScaleMode.Font;
    this.Controls.Add((Control) this.btnClose);
    this.Controls.Add((Control) this.lblTop);
    this.Controls.Add((Control) this.btnXoaName);
    this.Controls.Add((Control) this.txtPlayerName);
    this.Controls.Add((Control) this.lvPlayerList);
    this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
    this.MaximizeBox = false;
    this.Name = nameof (frmPlayerPick);
    this.Load += new EventHandler(this.frmBuffList_Load);
    this.Shown += new EventHandler(this.frmBuffList_Shown);
    this.ResumeLayout(false);
    this.PerformLayout();
  }
}
