// Decompiled with JetBrains decompiler
// Type: SmartBot.frmAutoPK
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using GAuto_Auto_None.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace SmartBot;

public class frmAutoPK : Form
{
  public AutoAccount myAccount;
  private IContainer components;
  private Timer timer1;
  private CheckBox PKEnable;
  private CheckBox PKBangList;
  private CheckBox PKPlayerList;
  private CheckBox PKAnyOne;
  private CheckBox PKNgaMyFirst;
  private Label label5;
  private GroupBox groupIDBang;
  private Button btnBangExpand;
  private Button btnIDBangAdd;
  private GroupBox groupPlayers;
  private Button btnGroupPlayerExpand;
  private ListView lvPlayers;
  private ColumnHeader columnHeader1;
  private Button btnAddPlayer;
  private TextBox txtPlayerName;
  private Button btnAddPlayerList;
  private ListView lvIDBang;
  private ColumnHeader columnHeader2;
  private TextBox txtIDBang;
  private Button btnPKHotKey;
  private GroupBox groupBlackList;
  private Button btnBlacklist;
  private TextBox txtBlacklistName;
  private Button btnGroupBlacklistExpand;
  private ListView lvBlacklist;
  private ColumnHeader columnHeader3;
  private Button btnBlacklistAdd;
  private CheckBox cboxBlacklist;
  private CheckBox PKThieuLamLast;

  public frmAutoPK()
  {
    frmLogin.ChangeLanguage();
    this.InitializeComponent();
  }

  private void frmAutoPK_Load(object sender, EventArgs e)
  {
  }

  private void btnPlayerExpand_Click(object sender, EventArgs e)
  {
    if (this.myAccount == null || this.myAccount.Myself == null)
      return;
    if (!this.myAccount.Myself.groupPlayersExpanded)
    {
      this.groupPlayers.Height = 191;
      this.myAccount.Myself.groupPlayersExpanded = !this.myAccount.Myself.groupPlayersExpanded;
    }
    else if (this.myAccount.Myself.groupPlayersExpanded)
    {
      this.groupPlayers.Height = 19;
      this.myAccount.Myself.groupPlayersExpanded = !this.myAccount.Myself.groupPlayersExpanded;
    }
    this.txtPlayerName.Visible = this.myAccount.Myself.groupPlayersExpanded;
    this.btnAddPlayer.Visible = this.myAccount.Myself.groupPlayersExpanded;
    this.btnAddPlayerList.Visible = this.myAccount.Myself.groupPlayersExpanded;
    if (this.myAccount.Myself.groupPlayersExpanded)
      this.btnGroupPlayerExpand.Image = (Image) Resources.collapse;
    else
      this.btnGroupPlayerExpand.Image = (Image) Resources.expand;
  }

  private void btnBangExpand_Click(object sender, EventArgs e)
  {
    if (this.myAccount == null || this.myAccount.Myself == null)
      return;
    if (!this.myAccount.Myself.groupIDBangExpanded)
    {
      this.groupIDBang.Height = 191;
      this.myAccount.Myself.groupIDBangExpanded = !this.myAccount.Myself.groupIDBangExpanded;
    }
    else if (this.myAccount.Myself.groupIDBangExpanded)
    {
      this.groupIDBang.Height = 19;
      this.myAccount.Myself.groupIDBangExpanded = !this.myAccount.Myself.groupIDBangExpanded;
    }
    this.txtIDBang.Visible = this.myAccount.Myself.groupIDBangExpanded;
    this.btnIDBangAdd.Visible = this.myAccount.Myself.groupIDBangExpanded;
    if (this.myAccount.Myself.groupIDBangExpanded)
      this.btnBangExpand.Image = (Image) Resources.collapse;
    else
      this.btnBangExpand.Image = (Image) Resources.expand;
  }

  private void frmAutoPK_FormClosing(object sender, FormClosingEventArgs e)
  {
    e.Cancel = true;
    this.Hide();
  }

  private void PKAnyOne_CheckedChanged(object sender, EventArgs e)
  {
    CheckBox checkBox = sender as CheckBox;
    if (this.myAccount == null || !checkBox.Focused)
      return;
    this.myAccount.Settings.cboxPKAnyOne = checkBox.Checked;
  }

  private void PKNgaMyFirst_CheckedChanged(object sender, EventArgs e)
  {
    CheckBox checkBox = sender as CheckBox;
    if (this.myAccount == null || !checkBox.Focused)
      return;
    this.myAccount.Settings.cboxPKNgaMyFirst = checkBox.Checked;
  }

  private void PKPlayerList_CheckedChanged(object sender, EventArgs e)
  {
    CheckBox checkBox = sender as CheckBox;
    if (this.myAccount == null || !checkBox.Focused)
      return;
    this.myAccount.Settings.cboxPKPlayerList = checkBox.Checked;
  }

  private void PKBangList_CheckedChanged(object sender, EventArgs e)
  {
    CheckBox checkBox = sender as CheckBox;
    if (this.myAccount == null || !checkBox.Focused)
      return;
    this.myAccount.Settings.cboxPKBangList = checkBox.Checked;
  }

  private void PKEnable_CheckedChanged(object sender, EventArgs e)
  {
    try
    {
      if (!this.PKEnable.Focused)
        return;
      frmMain.frmMainInstance.cboxAutoPK.Invoke((Delegate) (() =>
      {
        frmMain.frmMainInstance.cboxAutoPK.Focus();
        frmMain.frmMainInstance.cboxAutoPK_CheckedChanged(sender, e);
      }));
    }
    catch (Exception ex)
    {
      GA.WriteUserLog("Auto PK [1]: " + ex.Message, this.myAccount);
    }
  }

  private void timer1_Tick(object sender, EventArgs e)
  {
    if (this.myAccount == null)
      return;
    if (!this.PKEnable.Focused)
      this.PKEnable.Checked = this.myAccount.Settings.cboxPKEnable;
    if (!this.PKBangList.Focused)
      this.PKBangList.Checked = this.myAccount.Settings.cboxPKBangList;
    if (!this.PKPlayerList.Focused)
      this.PKPlayerList.Checked = this.myAccount.Settings.cboxPKPlayerList;
    if (!this.PKAnyOne.Focused)
      this.PKAnyOne.Checked = this.myAccount.Settings.cboxPKAnyOne;
    if (!this.PKNgaMyFirst.Focused)
      this.PKNgaMyFirst.Checked = this.myAccount.Settings.cboxPKNgaMyFirst;
    if (!this.PKThieuLamLast.Focused)
      this.PKThieuLamLast.Checked = this.myAccount.Settings.cboxPKThieuLamLast;
    if (!this.cboxBlacklist.Focused)
      this.cboxBlacklist.Checked = this.myAccount.Settings.cboxBlacklist;
    this.lvIDBang.BeginUpdate();
    int length1 = 0;
    int num1 = 0;
    if (this.lvIDBang.Items.Count == 0)
      length1 = this.myAccount.Settings.PKBangList.Count;
    else if (this.lvIDBang.Items.Count > this.myAccount.Settings.PKBangList.Count)
    {
      num1 = this.lvIDBang.Items.Count - this.myAccount.Settings.PKBangList.Count;
      length1 = 0;
    }
    else if (this.lvIDBang.Items.Count < this.myAccount.Settings.PKBangList.Count)
    {
      num1 = 0;
      length1 = this.myAccount.Settings.PKBangList.Count - this.lvIDBang.Items.Count;
    }
    List<int> intList = new List<int>();
    if (length1 > 0)
    {
      this.lvIDBang.Items.Clear();
      ListViewItem[] items = new ListViewItem[length1];
      int index1 = 0;
      try
      {
        for (int index2 = this.myAccount.Settings.PKBangList.Count - 1; index2 >= 0; --index2)
        {
          int pkBang = this.myAccount.Settings.PKBangList[index2];
          bool flag = false;
          foreach (ListViewItem listViewItem in this.lvIDBang.Items)
          {
            if (pkBang.ToString() == listViewItem.Text)
            {
              flag = true;
              break;
            }
          }
          if (!flag)
          {
            items[index1] = new ListViewItem();
            items[index1].Text = pkBang.ToString();
            ++index1;
          }
        }
        this.lvIDBang.Items.AddRange(items);
      }
      catch (Exception ex)
      {
      }
    }
    else if (num1 > 0)
    {
      try
      {
        List<ListViewItem> listViewItemList = new List<ListViewItem>();
        for (int index3 = this.lvIDBang.Items.Count - 1; index3 >= 0; --index3)
        {
          ListViewItem listViewItem = this.lvIDBang.Items[index3];
          bool flag = false;
          for (int index4 = this.myAccount.Settings.PKBangList.Count - 1; index4 >= 0; --index4)
          {
            if (this.myAccount.Settings.PKBangList[index4].ToString() == listViewItem.Text)
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
            this.lvIDBang.Items.Remove(listViewItemList[index]);
        }
      }
      catch (Exception ex)
      {
      }
    }
    if (this.myAccount.Settings.PKBangList.Count > 0 && this.myAccount.Settings.PKBangList.Count == this.lvIDBang.Items.Count)
    {
      for (int index = 0; index < this.lvIDBang.Items.Count; ++index)
        this.lvIDBang.Items[index].Text = this.myAccount.Settings.PKBangList[index].ToString();
    }
    this.lvIDBang.EndUpdate();
    this.lvPlayers.BeginUpdate();
    int length2 = 0;
    int num2 = 0;
    if (this.lvPlayers.Items.Count == 0)
      length2 = this.myAccount.Settings.PKPlayerList.Count;
    else if (this.lvPlayers.Items.Count > this.myAccount.Settings.PKPlayerList.Count)
    {
      num2 = this.lvPlayers.Items.Count - this.myAccount.Settings.PKPlayerList.Count;
      length2 = 0;
    }
    else if (this.lvPlayers.Items.Count < this.myAccount.Settings.PKPlayerList.Count)
    {
      num2 = 0;
      length2 = this.myAccount.Settings.PKPlayerList.Count - this.lvPlayers.Items.Count;
    }
    intList.Clear();
    if (length2 > 0)
    {
      this.lvPlayers.Items.Clear();
      ListViewItem[] items = new ListViewItem[length2];
      int index5 = 0;
      try
      {
        for (int index6 = this.myAccount.Settings.PKPlayerList.Count - 1; index6 >= 0; --index6)
        {
          string pkPlayer = this.myAccount.Settings.PKPlayerList[index6];
          bool flag = false;
          foreach (ListViewItem listViewItem in this.lvPlayers.Items)
          {
            if (pkPlayer == listViewItem.Text)
            {
              flag = true;
              break;
            }
          }
          if (!flag)
          {
            items[index5] = new ListViewItem();
            items[index5].Text = pkPlayer;
            ++index5;
          }
        }
        this.lvPlayers.Items.AddRange(items);
      }
      catch (Exception ex)
      {
      }
    }
    else if (num2 > 0)
    {
      try
      {
        List<ListViewItem> listViewItemList = new List<ListViewItem>();
        for (int index7 = this.lvPlayers.Items.Count - 1; index7 >= 0; --index7)
        {
          ListViewItem listViewItem = this.lvPlayers.Items[index7];
          bool flag = false;
          for (int index8 = this.myAccount.Settings.PKPlayerList.Count - 1; index8 >= 0; --index8)
          {
            if (this.myAccount.Settings.PKPlayerList[index8] == listViewItem.Text)
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
            this.lvPlayers.Items.Remove(listViewItemList[index]);
        }
      }
      catch (Exception ex)
      {
      }
    }
    if (this.myAccount.Settings.PKPlayerList.Count > 0 && this.myAccount.Settings.PKPlayerList.Count == this.lvPlayers.Items.Count)
    {
      for (int index = 0; index < this.lvPlayers.Items.Count; ++index)
        this.lvPlayers.Items[index].Text = this.myAccount.Settings.PKPlayerList[index];
    }
    this.lvPlayers.EndUpdate();
    this.lvBlacklist.BeginUpdate();
    int length3 = 0;
    int num3 = 0;
    if (this.lvBlacklist.Items.Count == 0)
      length3 = this.myAccount.Settings.PKBlackList.Count;
    else if (this.lvBlacklist.Items.Count > this.myAccount.Settings.PKBlackList.Count)
    {
      num3 = this.lvBlacklist.Items.Count - this.myAccount.Settings.PKBlackList.Count;
      length3 = 0;
    }
    else if (this.lvBlacklist.Items.Count < this.myAccount.Settings.PKBlackList.Count)
    {
      num3 = 0;
      length3 = this.myAccount.Settings.PKBlackList.Count - this.lvBlacklist.Items.Count;
    }
    intList.Clear();
    if (length3 > 0)
    {
      this.lvBlacklist.Items.Clear();
      ListViewItem[] items = new ListViewItem[length3];
      int index9 = 0;
      try
      {
        for (int index10 = this.myAccount.Settings.PKBlackList.Count - 1; index10 >= 0; --index10)
        {
          string pkBlack = this.myAccount.Settings.PKBlackList[index10];
          bool flag = false;
          foreach (ListViewItem listViewItem in this.lvBlacklist.Items)
          {
            if (pkBlack == listViewItem.Text)
            {
              flag = true;
              break;
            }
          }
          if (!flag)
          {
            items[index9] = new ListViewItem();
            items[index9].Text = pkBlack;
            ++index9;
          }
        }
        this.lvBlacklist.Items.AddRange(items);
      }
      catch (Exception ex)
      {
      }
    }
    else if (num3 > 0)
    {
      try
      {
        List<ListViewItem> listViewItemList = new List<ListViewItem>();
        for (int index11 = this.lvBlacklist.Items.Count - 1; index11 >= 0; --index11)
        {
          ListViewItem listViewItem = this.lvBlacklist.Items[index11];
          bool flag = false;
          for (int index12 = this.myAccount.Settings.PKBlackList.Count - 1; index12 >= 0; --index12)
          {
            if (this.myAccount.Settings.PKBlackList[index12] == listViewItem.Text)
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
            this.lvBlacklist.Items.Remove(listViewItemList[index]);
        }
      }
      catch (Exception ex)
      {
      }
    }
    if (this.myAccount.Settings.PKBlackList.Count > 0 && this.myAccount.Settings.PKBlackList.Count == this.lvBlacklist.Items.Count)
    {
      for (int index = 0; index < this.lvBlacklist.Items.Count; ++index)
        this.lvBlacklist.Items[index].Text = this.myAccount.Settings.PKBlackList[index];
    }
    this.lvBlacklist.EndUpdate();
  }

  private void btnIDBangAdd_Click(object sender, EventArgs e)
  {
    if (this.myAccount == null || string.IsNullOrEmpty(this.txtIDBang.Text))
      return;
    int result = -1;
    int.TryParse(this.txtIDBang.Text, out result);
    if (result != -1 && !this.myAccount.Settings.PKBangList.Contains(result))
      this.myAccount.Settings.PKBangList.Add(result);
    this.txtIDBang.Text = "";
  }

  private void btnAddPlayer_Click(object sender, EventArgs e)
  {
    if (this.myAccount == null || string.IsNullOrEmpty(this.txtPlayerName.Text))
      return;
    string text = this.txtPlayerName.Text;
    if (!this.myAccount.Settings.PKPlayerList.Contains(text))
      this.myAccount.Settings.PKPlayerList.Add(text);
    this.txtPlayerName.Text = "";
  }

  private void lvPlayers_DoubleClick(object sender, EventArgs e)
  {
    ListView listView = sender as ListView;
    if (listView.SelectedItems.Count <= 0)
      return;
    ListViewItem selectedItem = listView.SelectedItems[0];
    if (this.myAccount == null || string.IsNullOrEmpty(selectedItem.Text))
      return;
    this.myAccount.Settings.PKPlayerList.Remove(selectedItem.Text);
  }

  private void lvIDBang_DoubleClick(object sender, EventArgs e)
  {
    ListView listView = sender as ListView;
    if (listView.SelectedItems.Count <= 0)
      return;
    ListViewItem selectedItem = listView.SelectedItems[0];
    if (this.myAccount == null || string.IsNullOrEmpty(selectedItem.Text))
      return;
    this.myAccount.Settings.PKBangList.Remove(int.Parse(selectedItem.Text));
  }

  private void btnAddPlayerList_Click(object sender, EventArgs e)
  {
    if (this.myAccount == null)
      return;
    new frmItemList()
    {
      DialogMode = 8,
      account = this.myAccount
    }.Show();
  }

  private void btnPKHotKey_Click(object sender, EventArgs e) => frmMain.OpenHotKeyForm();

  private void btnGroupBlacklistExpand_Click(object sender, EventArgs e)
  {
    if (this.myAccount == null || this.myAccount.Myself == null)
      return;
    if (!this.myAccount.Myself.groupBlacklistExpanded)
    {
      this.groupBlackList.Height = 182;
      this.myAccount.Myself.groupBlacklistExpanded = !this.myAccount.Myself.groupBlacklistExpanded;
    }
    else if (this.myAccount.Myself.groupBlacklistExpanded)
    {
      this.groupBlackList.Height = 19;
      this.myAccount.Myself.groupBlacklistExpanded = !this.myAccount.Myself.groupBlacklistExpanded;
    }
    this.txtBlacklistName.Visible = this.myAccount.Myself.groupBlacklistExpanded;
    this.btnBlacklistAdd.Visible = this.myAccount.Myself.groupBlacklistExpanded;
    this.btnBlacklist.Visible = this.myAccount.Myself.groupBlacklistExpanded;
    if (this.myAccount.Myself.groupBlacklistExpanded)
      this.btnGroupBlacklistExpand.Image = (Image) Resources.collapse;
    else
      this.btnGroupBlacklistExpand.Image = (Image) Resources.expand;
  }

  private void btnBlacklist_Click(object sender, EventArgs e)
  {
    if (this.myAccount == null)
      return;
    new frmItemList()
    {
      DialogMode = 9,
      account = this.myAccount
    }.Show();
  }

  private void btnBlacklistAdd_Click(object sender, EventArgs e)
  {
    if (this.myAccount == null || string.IsNullOrEmpty(this.txtBlacklistName.Text))
      return;
    string text = this.txtBlacklistName.Text;
    if (!this.myAccount.Settings.PKBlackList.Contains(text))
      this.myAccount.Settings.PKBlackList.Add(text);
    this.txtBlacklistName.Text = "";
  }

  private void lvBlacklist_MouseDoubleClick(object sender, MouseEventArgs e)
  {
    ListView listView = sender as ListView;
    if (listView.SelectedItems.Count <= 0)
      return;
    ListViewItem selectedItem = listView.SelectedItems[0];
    if (this.myAccount == null || string.IsNullOrEmpty(selectedItem.Text))
      return;
    this.myAccount.Settings.PKBlackList.Remove(selectedItem.Text);
  }

  private void cboxBlacklist_CheckedChanged(object sender, EventArgs e)
  {
    CheckBox checkBox = sender as CheckBox;
    if (this.myAccount == null || !checkBox.Focused)
      return;
    this.myAccount.Settings.cboxBlacklist = checkBox.Checked;
  }

  private void frmAutoPK_Shown(object sender, EventArgs e)
  {
    this.btnPKHotKey.Focus();
    this.FillInToolTip();
  }

  private void FillInToolTip()
  {
    ToolTip toolTip = new ToolTip();
    toolTip.OwnerDraw = true;
    toolTip.BackColor = Color.Yellow;
    toolTip.AutoPopDelay = 20000;
    toolTip.InitialDelay = 500;
    toolTip.ReshowDelay = 500;
    toolTip.ShowAlways = true;
    toolTip.IsBalloon = true;
    toolTip.SetToolTip((Control) this.PKEnable, frmMain.langPKEnable);
    toolTip.SetToolTip((Control) this.cboxBlacklist, frmMain.langcboxBlacklist);
  }

  private void PKThieuLamLast_CheckedChanged(object sender, EventArgs e)
  {
    CheckBox checkBox = sender as CheckBox;
    if (this.myAccount == null || !checkBox.Focused)
      return;
    this.myAccount.Settings.cboxPKThieuLamLast = checkBox.Checked;
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
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmAutoPK));
    this.timer1 = new Timer(this.components);
    this.PKEnable = new CheckBox();
    this.PKBangList = new CheckBox();
    this.PKPlayerList = new CheckBox();
    this.PKAnyOne = new CheckBox();
    this.PKNgaMyFirst = new CheckBox();
    this.label5 = new Label();
    this.groupIDBang = new GroupBox();
    this.lvIDBang = new ListView();
    this.columnHeader2 = new ColumnHeader();
    this.txtIDBang = new TextBox();
    this.btnBangExpand = new Button();
    this.btnIDBangAdd = new Button();
    this.groupPlayers = new GroupBox();
    this.btnAddPlayerList = new Button();
    this.txtPlayerName = new TextBox();
    this.btnGroupPlayerExpand = new Button();
    this.lvPlayers = new ListView();
    this.columnHeader1 = new ColumnHeader();
    this.btnAddPlayer = new Button();
    this.btnPKHotKey = new Button();
    this.groupBlackList = new GroupBox();
    this.btnBlacklist = new Button();
    this.txtBlacklistName = new TextBox();
    this.btnGroupBlacklistExpand = new Button();
    this.lvBlacklist = new ListView();
    this.columnHeader3 = new ColumnHeader();
    this.btnBlacklistAdd = new Button();
    this.cboxBlacklist = new CheckBox();
    this.PKThieuLamLast = new CheckBox();
    this.groupIDBang.SuspendLayout();
    this.groupPlayers.SuspendLayout();
    this.groupBlackList.SuspendLayout();
    this.SuspendLayout();
    this.timer1.Enabled = true;
    this.timer1.Interval = 250;
    this.timer1.Tick += new EventHandler(this.timer1_Tick);
    componentResourceManager.ApplyResources((object) this.PKEnable, "PKEnable");
    this.PKEnable.Name = "PKEnable";
    this.PKEnable.UseVisualStyleBackColor = true;
    this.PKEnable.CheckedChanged += new EventHandler(this.PKEnable_CheckedChanged);
    componentResourceManager.ApplyResources((object) this.PKBangList, "PKBangList");
    this.PKBangList.Name = "PKBangList";
    this.PKBangList.UseVisualStyleBackColor = true;
    this.PKBangList.CheckedChanged += new EventHandler(this.PKBangList_CheckedChanged);
    componentResourceManager.ApplyResources((object) this.PKPlayerList, "PKPlayerList");
    this.PKPlayerList.Name = "PKPlayerList";
    this.PKPlayerList.UseVisualStyleBackColor = true;
    this.PKPlayerList.CheckedChanged += new EventHandler(this.PKPlayerList_CheckedChanged);
    componentResourceManager.ApplyResources((object) this.PKAnyOne, "PKAnyOne");
    this.PKAnyOne.Name = "PKAnyOne";
    this.PKAnyOne.UseVisualStyleBackColor = true;
    this.PKAnyOne.CheckedChanged += new EventHandler(this.PKAnyOne_CheckedChanged);
    componentResourceManager.ApplyResources((object) this.PKNgaMyFirst, "PKNgaMyFirst");
    this.PKNgaMyFirst.Name = "PKNgaMyFirst";
    this.PKNgaMyFirst.UseVisualStyleBackColor = true;
    this.PKNgaMyFirst.CheckedChanged += new EventHandler(this.PKNgaMyFirst_CheckedChanged);
    componentResourceManager.ApplyResources((object) this.label5, "label5");
    this.label5.Name = "label5";
    componentResourceManager.ApplyResources((object) this.groupIDBang, "groupIDBang");
    this.groupIDBang.BackColor = Color.WhiteSmoke;
    this.groupIDBang.Controls.Add((Control) this.lvIDBang);
    this.groupIDBang.Controls.Add((Control) this.txtIDBang);
    this.groupIDBang.Controls.Add((Control) this.btnBangExpand);
    this.groupIDBang.Controls.Add((Control) this.btnIDBangAdd);
    this.groupIDBang.Name = "groupIDBang";
    this.groupIDBang.TabStop = false;
    componentResourceManager.ApplyResources((object) this.lvIDBang, "lvIDBang");
    this.lvIDBang.BorderStyle = BorderStyle.FixedSingle;
    this.lvIDBang.Columns.AddRange(new ColumnHeader[1]
    {
      this.columnHeader2
    });
    this.lvIDBang.FullRowSelect = true;
    this.lvIDBang.GridLines = true;
    this.lvIDBang.HeaderStyle = ColumnHeaderStyle.Nonclickable;
    this.lvIDBang.Name = "lvIDBang";
    this.lvIDBang.UseCompatibleStateImageBehavior = false;
    this.lvIDBang.View = View.Details;
    this.lvIDBang.DoubleClick += new EventHandler(this.lvIDBang_DoubleClick);
    componentResourceManager.ApplyResources((object) this.columnHeader2, "columnHeader2");
    componentResourceManager.ApplyResources((object) this.txtIDBang, "txtIDBang");
    this.txtIDBang.BackColor = Color.WhiteSmoke;
    this.txtIDBang.Name = "txtIDBang";
    componentResourceManager.ApplyResources((object) this.btnBangExpand, "btnBangExpand");
    this.btnBangExpand.BackColor = Color.WhiteSmoke;
    this.btnBangExpand.ForeColor = Color.WhiteSmoke;
    this.btnBangExpand.Name = "btnBangExpand";
    this.btnBangExpand.UseVisualStyleBackColor = false;
    this.btnBangExpand.Click += new EventHandler(this.btnBangExpand_Click);
    componentResourceManager.ApplyResources((object) this.btnIDBangAdd, "btnIDBangAdd");
    this.btnIDBangAdd.BackColor = Color.FromArgb(210, 249, 213);
    this.btnIDBangAdd.ForeColor = Color.DarkGreen;
    this.btnIDBangAdd.Name = "btnIDBangAdd";
    this.btnIDBangAdd.UseVisualStyleBackColor = false;
    this.btnIDBangAdd.Click += new EventHandler(this.btnIDBangAdd_Click);
    componentResourceManager.ApplyResources((object) this.groupPlayers, "groupPlayers");
    this.groupPlayers.BackColor = Color.WhiteSmoke;
    this.groupPlayers.Controls.Add((Control) this.btnAddPlayerList);
    this.groupPlayers.Controls.Add((Control) this.txtPlayerName);
    this.groupPlayers.Controls.Add((Control) this.btnGroupPlayerExpand);
    this.groupPlayers.Controls.Add((Control) this.lvPlayers);
    this.groupPlayers.Controls.Add((Control) this.btnAddPlayer);
    this.groupPlayers.Name = "groupPlayers";
    this.groupPlayers.TabStop = false;
    componentResourceManager.ApplyResources((object) this.btnAddPlayerList, "btnAddPlayerList");
    this.btnAddPlayerList.BackColor = Color.WhiteSmoke;
    this.btnAddPlayerList.ForeColor = Color.WhiteSmoke;
    this.btnAddPlayerList.Name = "btnAddPlayerList";
    this.btnAddPlayerList.UseVisualStyleBackColor = false;
    this.btnAddPlayerList.Click += new EventHandler(this.btnAddPlayerList_Click);
    componentResourceManager.ApplyResources((object) this.txtPlayerName, "txtPlayerName");
    this.txtPlayerName.BackColor = Color.WhiteSmoke;
    this.txtPlayerName.Name = "txtPlayerName";
    componentResourceManager.ApplyResources((object) this.btnGroupPlayerExpand, "btnGroupPlayerExpand");
    this.btnGroupPlayerExpand.BackColor = Color.WhiteSmoke;
    this.btnGroupPlayerExpand.ForeColor = Color.WhiteSmoke;
    this.btnGroupPlayerExpand.Name = "btnGroupPlayerExpand";
    this.btnGroupPlayerExpand.UseVisualStyleBackColor = false;
    this.btnGroupPlayerExpand.Click += new EventHandler(this.btnPlayerExpand_Click);
    componentResourceManager.ApplyResources((object) this.lvPlayers, "lvPlayers");
    this.lvPlayers.BorderStyle = BorderStyle.FixedSingle;
    this.lvPlayers.Columns.AddRange(new ColumnHeader[1]
    {
      this.columnHeader1
    });
    this.lvPlayers.FullRowSelect = true;
    this.lvPlayers.GridLines = true;
    this.lvPlayers.HeaderStyle = ColumnHeaderStyle.Nonclickable;
    this.lvPlayers.Name = "lvPlayers";
    this.lvPlayers.UseCompatibleStateImageBehavior = false;
    this.lvPlayers.View = View.Details;
    this.lvPlayers.DoubleClick += new EventHandler(this.lvPlayers_DoubleClick);
    componentResourceManager.ApplyResources((object) this.columnHeader1, "columnHeader1");
    componentResourceManager.ApplyResources((object) this.btnAddPlayer, "btnAddPlayer");
    this.btnAddPlayer.BackColor = Color.FromArgb(210, 249, 213);
    this.btnAddPlayer.ForeColor = Color.DarkGreen;
    this.btnAddPlayer.Name = "btnAddPlayer";
    this.btnAddPlayer.UseVisualStyleBackColor = false;
    this.btnAddPlayer.Click += new EventHandler(this.btnAddPlayer_Click);
    componentResourceManager.ApplyResources((object) this.btnPKHotKey, "btnPKHotKey");
    this.btnPKHotKey.BackColor = Color.FromArgb(247, 207, 142);
    this.btnPKHotKey.ForeColor = Color.Black;
    this.btnPKHotKey.Name = "btnPKHotKey";
    this.btnPKHotKey.UseVisualStyleBackColor = false;
    this.btnPKHotKey.Click += new EventHandler(this.btnPKHotKey_Click);
    componentResourceManager.ApplyResources((object) this.groupBlackList, "groupBlackList");
    this.groupBlackList.BackColor = Color.WhiteSmoke;
    this.groupBlackList.Controls.Add((Control) this.btnBlacklist);
    this.groupBlackList.Controls.Add((Control) this.txtBlacklistName);
    this.groupBlackList.Controls.Add((Control) this.btnGroupBlacklistExpand);
    this.groupBlackList.Controls.Add((Control) this.lvBlacklist);
    this.groupBlackList.Controls.Add((Control) this.btnBlacklistAdd);
    this.groupBlackList.Name = "groupBlackList";
    this.groupBlackList.TabStop = false;
    componentResourceManager.ApplyResources((object) this.btnBlacklist, "btnBlacklist");
    this.btnBlacklist.BackColor = Color.WhiteSmoke;
    this.btnBlacklist.ForeColor = Color.WhiteSmoke;
    this.btnBlacklist.Name = "btnBlacklist";
    this.btnBlacklist.UseVisualStyleBackColor = false;
    this.btnBlacklist.Click += new EventHandler(this.btnBlacklist_Click);
    componentResourceManager.ApplyResources((object) this.txtBlacklistName, "txtBlacklistName");
    this.txtBlacklistName.BackColor = Color.WhiteSmoke;
    this.txtBlacklistName.Name = "txtBlacklistName";
    componentResourceManager.ApplyResources((object) this.btnGroupBlacklistExpand, "btnGroupBlacklistExpand");
    this.btnGroupBlacklistExpand.BackColor = Color.WhiteSmoke;
    this.btnGroupBlacklistExpand.ForeColor = Color.WhiteSmoke;
    this.btnGroupBlacklistExpand.Name = "btnGroupBlacklistExpand";
    this.btnGroupBlacklistExpand.UseVisualStyleBackColor = false;
    this.btnGroupBlacklistExpand.Click += new EventHandler(this.btnGroupBlacklistExpand_Click);
    componentResourceManager.ApplyResources((object) this.lvBlacklist, "lvBlacklist");
    this.lvBlacklist.BorderStyle = BorderStyle.FixedSingle;
    this.lvBlacklist.Columns.AddRange(new ColumnHeader[1]
    {
      this.columnHeader3
    });
    this.lvBlacklist.FullRowSelect = true;
    this.lvBlacklist.GridLines = true;
    this.lvBlacklist.HeaderStyle = ColumnHeaderStyle.Nonclickable;
    this.lvBlacklist.Name = "lvBlacklist";
    this.lvBlacklist.UseCompatibleStateImageBehavior = false;
    this.lvBlacklist.View = View.Details;
    this.lvBlacklist.MouseDoubleClick += new MouseEventHandler(this.lvBlacklist_MouseDoubleClick);
    componentResourceManager.ApplyResources((object) this.columnHeader3, "columnHeader3");
    componentResourceManager.ApplyResources((object) this.btnBlacklistAdd, "btnBlacklistAdd");
    this.btnBlacklistAdd.BackColor = Color.FromArgb(210, 249, 213);
    this.btnBlacklistAdd.ForeColor = Color.DarkGreen;
    this.btnBlacklistAdd.Name = "btnBlacklistAdd";
    this.btnBlacklistAdd.UseVisualStyleBackColor = false;
    this.btnBlacklistAdd.Click += new EventHandler(this.btnBlacklistAdd_Click);
    componentResourceManager.ApplyResources((object) this.cboxBlacklist, "cboxBlacklist");
    this.cboxBlacklist.Name = "cboxBlacklist";
    this.cboxBlacklist.UseVisualStyleBackColor = true;
    this.cboxBlacklist.CheckedChanged += new EventHandler(this.cboxBlacklist_CheckedChanged);
    componentResourceManager.ApplyResources((object) this.PKThieuLamLast, "PKThieuLamLast");
    this.PKThieuLamLast.Name = "PKThieuLamLast";
    this.PKThieuLamLast.UseVisualStyleBackColor = true;
    this.PKThieuLamLast.CheckedChanged += new EventHandler(this.PKThieuLamLast_CheckedChanged);
    componentResourceManager.ApplyResources((object) this, "$this");
    this.AutoScaleMode = AutoScaleMode.Font;
    this.Controls.Add((Control) this.PKThieuLamLast);
    this.Controls.Add((Control) this.cboxBlacklist);
    this.Controls.Add((Control) this.btnPKHotKey);
    this.Controls.Add((Control) this.groupIDBang);
    this.Controls.Add((Control) this.groupPlayers);
    this.Controls.Add((Control) this.label5);
    this.Controls.Add((Control) this.PKNgaMyFirst);
    this.Controls.Add((Control) this.PKAnyOne);
    this.Controls.Add((Control) this.PKPlayerList);
    this.Controls.Add((Control) this.PKBangList);
    this.Controls.Add((Control) this.PKEnable);
    this.Controls.Add((Control) this.groupBlackList);
    this.FormBorderStyle = FormBorderStyle.FixedSingle;
    this.MaximizeBox = false;
    this.Name = nameof (frmAutoPK);
    this.FormClosing += new FormClosingEventHandler(this.frmAutoPK_FormClosing);
    this.Load += new EventHandler(this.frmAutoPK_Load);
    this.Shown += new EventHandler(this.frmAutoPK_Shown);
    this.groupIDBang.ResumeLayout(false);
    this.groupIDBang.PerformLayout();
    this.groupPlayers.ResumeLayout(false);
    this.groupPlayers.PerformLayout();
    this.groupBlackList.ResumeLayout(false);
    this.groupBlackList.PerformLayout();
    this.ResumeLayout(false);
    this.PerformLayout();
  }
}
