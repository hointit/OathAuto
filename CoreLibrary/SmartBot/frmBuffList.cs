// Decompiled with JetBrains decompiler
// Type: SmartBot.frmBuffList
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using GAuto_Auto_None.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

#nullable disable
namespace SmartBot;

public class frmBuffList : Form
{
  public AutoAccount account;
  public int DialogMode;
  private bool flagUpdated;
  private bool needRefresh = true;
  private bool autoRefresh = true;
  private IContainer components;
  private Button btnDanhSachBuff;
  private Button btnAddName;
  private TextBox txtBuffName;
  private ListView lvBuffList;
  private ColumnHeader columnHeader16;
  private Label lblTop;
  private Button btnClose;
  private Timer timer1;
  private Label label12;
  private Label label1;
  private ListView lvPlayers;
  private ColumnHeader columnHeader1;
  private ColumnHeader columnHeader2;
  private Label label2;
  private Button btnAdd;
  private Button btnRemove;
  private Button btnSaveList;
  private Label label3;
  private Button btnRefresh;
  private CheckBox cboxTuRefresh;
  private ComboBox cboItemName;

  public frmBuffList() => this.InitializeComponent();

  private void frmBuffList_Load(object sender, EventArgs e)
  {
  }

  private void btnAddName_Click(object sender, EventArgs e) => this.AddName();

  private void AddName()
  {
    if (this.account == null || string.IsNullOrEmpty(this.cboItemName.Text))
      return;
    string text = this.cboItemName.Text;
    if (text.Contains("~"))
    {
      string[] strArray = text.Split('~');
      if (strArray.Length >= 2)
        text = strArray[1];
    }
    if (this.DialogMode == 0)
    {
      if (!frmLogin.GAuto.Settings.BuffNameList.Contains(text))
        frmLogin.GAuto.Settings.BuffNameList.Add(text);
    }
    else if (this.DialogMode == 1)
    {
      int result = 0;
      int.TryParse(text, out result);
      if (text.Contains(" ") || text.Contains("hài") || text.Contains("mão") || result > 0)
      {
        if (!frmLogin.GAuto.Settings.ItemTuHuyList.Contains(text.ToLower()))
          frmLogin.GAuto.Settings.ItemTuHuyList.Add(text.ToLower());
      }
      else if (!text.Contains(" "))
      {
        bool flag = false;
        for (int index = 0; index < 60; ++index)
        {
          InventoryItem allItem = this.account.MyInventory.AllItems[index];
          string itemName = "";
          string itemType = "";
          GA.GetItemNameTypeFromID(allItem.ItemID, out itemName, out itemType);
          if (text == itemName)
          {
            flag = true;
            if (!frmLogin.GAuto.Settings.ItemTuHuyList.Contains(allItem.ItemID.ToString()))
            {
              frmLogin.GAuto.Settings.ItemTuHuyList.Add(allItem.ItemID.ToString());
              break;
            }
          }
        }
        if (!flag)
          GA.ShowBalloon(string.Format(frmMain.langHuyVatPhamInput, (object) text), frmMain.langWarning, this.account, 10000);
      }
    }
    else if (this.DialogMode == 2)
    {
      if (!frmLogin.GAuto.Settings.ItemBanList.Contains(text.ToLower()))
        frmLogin.GAuto.Settings.ItemBanList.Add(text.ToLower());
    }
    else if (this.DialogMode == 3)
    {
      if (!this.account.Settings.AutoPartyList.Contains(text))
        this.account.Settings.AutoPartyList.Add(text);
    }
    else if (this.DialogMode == 4)
    {
      if (!this.account.Settings.PTBlacklist.Contains(text))
        this.account.Settings.PTBlacklist.Add(text);
    }
    else if (this.DialogMode == 5)
    {
      if (!frmLogin.GAuto.Settings.ListItemNhat.Contains(text.ToLower()))
      {
        lock (frmLogin.lockListItemNhat)
          frmLogin.GAuto.Settings.ListItemNhat.Add(text.ToLower());
      }
    }
    else if (this.DialogMode == 6)
    {
      if (!frmLogin.GAuto.Settings.ListBuffPetID.Contains(text))
        frmLogin.GAuto.Settings.ListBuffPetID.Add(text);
    }
    else if (this.DialogMode == 7)
    {
      if (!this.account.Settings.QuaiNoAttackList.Contains(text))
        this.account.Settings.QuaiNoAttackList.Add(text);
    }
    else if (this.DialogMode == 8)
    {
      if (!this.account.Settings.PKPlayerList.Contains(text))
        this.account.Settings.PKPlayerList.Add(text);
    }
    else if (this.DialogMode == 9)
    {
      if (!this.account.Settings.PKBlackList.Contains(text))
        this.account.Settings.PKBlackList.Add(text);
    }
    else if (this.DialogMode == 10 && !this.account.Settings.ListItemNhatIgnore.Contains(text.ToLower()))
    {
      lock (frmLogin.lockListItemNhat)
        this.account.Settings.ListItemNhatIgnore.Add(text.ToLower());
    }
    this.cboItemName.Text = "";
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
      if (!string.IsNullOrEmpty(str) && !str.StartsWith("#"))
      {
        if (this.DialogMode == 0)
        {
          if (!frmLogin.GAuto.Settings.BuffNameList.Contains(str))
            frmLogin.GAuto.Settings.BuffNameList.Add(str);
        }
        else if (this.DialogMode == 1)
        {
          if (!frmLogin.GAuto.Settings.ItemTuHuyList.Contains(str.ToLower()))
            frmLogin.GAuto.Settings.ItemTuHuyList.Add(str.ToLower());
        }
        else if (this.DialogMode == 2)
        {
          if (!frmLogin.GAuto.Settings.ItemBanList.Contains(str.ToLower()))
            frmLogin.GAuto.Settings.ItemBanList.Add(str.ToLower());
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
          if (!frmLogin.GAuto.Settings.ListItemNhat.Contains(str.ToLower()))
          {
            lock (frmLogin.lockListItemNhat)
              frmLogin.GAuto.Settings.ListItemNhat.Add(str.ToLower());
          }
        }
        else if (this.DialogMode == 6)
        {
          if (!frmLogin.GAuto.Settings.ListBuffPetID.Contains(str))
            frmLogin.GAuto.Settings.ListBuffPetID.Add(str);
        }
        else if (this.DialogMode == 7)
        {
          if (!this.account.Settings.QuaiNoAttackList.Contains(str))
            this.account.Settings.QuaiNoAttackList.Add(str);
        }
        else if (this.DialogMode == 8)
        {
          if (!this.account.Settings.PKPlayerList.Contains(str))
            this.account.Settings.PKPlayerList.Add(str);
        }
        else if (this.DialogMode == 9)
        {
          if (!this.account.Settings.PKBlackList.Contains(str))
            this.account.Settings.PKBlackList.Add(str);
        }
        else if (this.DialogMode == 10 && !this.account.Settings.ListItemNhatIgnore.Contains(str.ToLower()))
        {
          lock (frmLogin.lockListItemNhat)
            this.account.Settings.ListItemNhatIgnore.Add(str.ToLower());
        }
      }
    }
    streamReader.Close();
  }

  private void lvBuffList_MouseDoubleClick(object sender, MouseEventArgs e)
  {
    this.RemoveItem(sender as ListView);
  }

  private void RemoveItem(ListView lv)
  {
    if (lv.SelectedItems.Count <= 0)
      return;
    ListViewItem selectedItem = lv.SelectedItems[0];
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
        frmLogin.GAuto.Settings.ListBuffPetID.Remove(selectedItem.Text);
        break;
      case 7:
        this.account.Settings.QuaiNoAttackList.Remove(selectedItem.Text);
        break;
      case 8:
        this.account.Settings.PKPlayerList.Remove(selectedItem.Text);
        break;
      case 9:
        this.account.Settings.PKBlackList.Remove(selectedItem.Text);
        break;
      case 10:
        lock (frmLogin.lockListItemNhat)
        {
          this.account.Settings.ListItemNhatIgnore.Remove(selectedItem.Text);
          break;
        }
    }
  }

  private void timer1_Tick(object sender, EventArgs e)
  {
    if (this.account == null)
      return;
    if (this.DialogMode == 0)
    {
      frmMain.BindListStringToListView((List<string>) frmLogin.GAuto.Settings.BuffNameList, this.lvBuffList);
      if (this.needRefresh || this.autoRefresh)
      {
        frmMain.BindPlayerListToListView(this.account, this.lvPlayers, frmLogin.GAuto.Settings.BuffNameList);
        this.needRefresh = false;
      }
      this.AdjustGUI();
    }
    else if (this.DialogMode == 1)
      frmMain.BindListStringToListView((List<string>) frmLogin.GAuto.Settings.ItemTuHuyList, this.lvBuffList);
    else if (this.DialogMode == 2)
      frmMain.BindListStringToListView((List<string>) frmLogin.GAuto.Settings.ItemBanList, this.lvBuffList);
    else if (this.DialogMode == 3)
    {
      frmMain.BindListStringToListView((List<string>) this.account.Settings.AutoPartyList, this.lvBuffList);
      if (this.needRefresh || this.autoRefresh)
        frmMain.BindPlayerListToListView(this.account, this.lvPlayers, this.account.Settings.AutoPartyList);
      this.AdjustGUI();
    }
    else if (this.DialogMode == 4)
    {
      frmMain.BindListStringToListView((List<string>) this.account.Settings.PTBlacklist, this.lvBuffList);
      if (this.needRefresh || this.autoRefresh)
      {
        frmMain.BindPlayerListToListView(this.account, this.lvPlayers, this.account.Settings.PTBlacklist);
        this.needRefresh = false;
      }
      this.AdjustGUI();
    }
    else if (this.DialogMode == 5)
      frmMain.BindListStringToListView((List<string>) frmLogin.GAuto.Settings.ListItemNhat, this.lvBuffList);
    else if (this.DialogMode == 6)
    {
      frmMain.BindListStringToListView((List<string>) frmLogin.GAuto.Settings.ListBuffPetID, this.lvBuffList);
      if (this.needRefresh || this.autoRefresh)
      {
        frmMain.BindPetListToListView(this.account, this.lvPlayers, frmLogin.GAuto.Settings.ListBuffPetID);
        this.needRefresh = false;
      }
      this.AdjustGUI();
    }
    else if (this.DialogMode == 7)
      frmMain.BindListStringToListView((List<string>) this.account.Settings.QuaiNoAttackList, this.lvBuffList);
    else if (this.DialogMode == 8)
    {
      frmMain.BindListStringToListView((List<string>) this.account.Settings.PKPlayerList, this.lvBuffList);
      if (this.needRefresh || this.autoRefresh)
      {
        frmMain.BindPlayerListToListView(this.account, this.lvPlayers, this.account.Settings.PKPlayerList);
        this.needRefresh = false;
      }
      this.AdjustGUI();
    }
    else if (this.DialogMode == 9)
    {
      frmMain.BindListStringToListView((List<string>) this.account.Settings.PKBlackList, this.lvBuffList);
      if (this.needRefresh || this.autoRefresh)
      {
        frmMain.BindPlayerListToListView(this.account, this.lvPlayers, this.account.Settings.PKBlackList);
        this.needRefresh = false;
      }
      this.AdjustGUI();
    }
    else if (this.DialogMode == 10)
      frmMain.BindListStringToListView((List<string>) this.account.Settings.ListItemNhatIgnore, this.lvBuffList);
    if (this.lvBuffList.SelectedItems.Count > 0)
      this.btnRemove.Enabled = true;
    else
      this.btnRemove.Enabled = false;
    if (this.lvPlayers.SelectedItems.Count > 0)
      this.btnAdd.Enabled = true;
    else
      this.btnAdd.Enabled = false;
  }

  private void AdjustGUI()
  {
    if (this.flagUpdated)
      return;
    this.btnRemove.Visible = true;
    this.btnAdd.Visible = true;
    this.Width = 399;
    this.flagUpdated = true;
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
        this.lblTop.Text = frmMain.langAddBuffName;
        this.lvBuffList.Columns[0].Text = frmMain.langPlayerName;
        this.Text = frmMain.langHealingList;
        break;
      case 1:
        this.lblTop.Text = frmMain.langItemDestroy;
        this.lvBuffList.Columns[0].Text = frmMain.langDestroyingItems;
        this.Text = frmMain.langWillDestroyList;
        break;
      case 2:
        this.lblTop.Text = frmMain.langItemToSell;
        this.lvBuffList.Columns[0].Text = frmMain.langItemToSellName;
        this.Text = frmMain.langSellingList;
        break;
      case 3:
        this.lblTop.Text = frmMain.langPlayerPTAccept;
        this.lvBuffList.Columns[0].Text = frmMain.langInvitePT;
        this.Text = frmMain.langAcceptPT;
        break;
      case 4:
        this.lblTop.Text = frmMain.langBlockPT;
        this.lvBuffList.Columns[0].Text = frmMain.langBlockPT2;
        this.Text = frmMain.langBlockPTList;
        break;
      case 5:
        this.lblTop.Text = frmMain.langPickItemList;
        this.lvBuffList.Columns[0].Text = frmMain.langPickItemList2;
        this.Text = frmMain.langPickItemList3;
        break;
      case 6:
        this.lblTop.Text = frmMain.langPetBuffName;
        this.lvBuffList.Columns[0].Text = frmMain.langPetBuffName2;
        this.Text = frmMain.langBuffPetName;
        break;
      case 7:
        this.lblTop.Text = frmMain.langNoAttackName;
        this.lvBuffList.Columns[0].Text = frmMain.langMobName;
        this.Text = frmMain.langNoAttackList;
        break;
      case 8:
        this.lblTop.Text = frmMain.langPickPKName;
        this.lvBuffList.Columns[0].Text = frmMain.langPKName;
        this.Text = frmMain.langPK2List;
        break;
      case 9:
        this.lblTop.Text = frmMain.langPickPKBlackName;
        this.lvBuffList.Columns[0].Text = frmMain.langPKName;
        this.Text = frmMain.langPK3List;
        break;
      case 10:
        this.lblTop.Text = frmMain.langPickItemListIgnore;
        this.lvBuffList.Columns[0].Text = frmMain.langPickItemListIgnore2;
        this.Text = frmMain.langPickItemListIgnore3;
        break;
    }
  }

  private void btnAdd_Click(object sender, EventArgs e)
  {
    if (this.lvPlayers.SelectedItems.Count <= 0)
      return;
    foreach (ListViewItem selectedItem in this.lvPlayers.SelectedItems)
    {
      this.cboItemName.Text = selectedItem.Text;
      this.AddName();
    }
  }

  private void btnRemove_Click(object sender, EventArgs e) => this.RemoveItem(this.lvBuffList);

  private void lvPlayers_MouseDoubleClick(object sender, MouseEventArgs e)
  {
    if (this.lvPlayers.SelectedItems.Count <= 0)
      return;
    this.cboItemName.Text = this.lvPlayers.SelectedItems[0].Text;
    this.AddName();
  }

  private void lvBuffList_SelectedIndexChanged(object sender, EventArgs e)
  {
  }

  private void btnSaveList_Click(object sender, EventArgs e)
  {
    if (this.account == null)
      return;
    SaveFileDialog saveFileDialog = new SaveFileDialog();
    if (saveFileDialog.ShowDialog() != DialogResult.OK || string.IsNullOrEmpty(saveFileDialog.FileName))
      return;
    if (!saveFileDialog.FileName.Contains("."))
      saveFileDialog.FileName += ".txt";
    try
    {
      StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);
      if (streamWriter == null)
        return;
      GAutoList<string> gautoList = (GAutoList<string>) null;
      if (this.DialogMode == 0)
        gautoList = frmLogin.GAuto.Settings.BuffNameList;
      else if (this.DialogMode == 1)
        gautoList = frmLogin.GAuto.Settings.ItemTuHuyList;
      else if (this.DialogMode == 2)
        gautoList = frmLogin.GAuto.Settings.ItemBanList;
      else if (this.DialogMode == 3)
        gautoList = this.account.Settings.AutoPartyList;
      else if (this.DialogMode == 4)
        gautoList = this.account.Settings.PTBlacklist;
      else if (this.DialogMode == 5)
        gautoList = frmLogin.GAuto.Settings.ListItemNhat;
      else if (this.DialogMode == 6)
        gautoList = frmLogin.GAuto.Settings.ListBuffPetID;
      else if (this.DialogMode == 7)
        gautoList = this.account.Settings.QuaiNoAttackList;
      else if (this.DialogMode == 8)
        gautoList = this.account.Settings.PKPlayerList;
      else if (this.DialogMode == 9)
        gautoList = this.account.Settings.PKBlackList;
      else if (this.DialogMode == 10)
        gautoList = this.account.Settings.ListItemNhatIgnore;
      if (gautoList != null)
      {
        foreach (string str in (List<string>) gautoList)
          streamWriter.WriteLine(str);
      }
      streamWriter.Close();
      int num = (int) MessageBox.Show(frmMain.langSaveSuccessfully + saveFileDialog.FileName, frmMain.langSaveFileOK, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
    }
    catch (Exception ex)
    {
      GA.WriteUserLog(frmMain.langErrorSavingFile, this.account);
    }
  }

  private void btnRefresh_Click(object sender, EventArgs e) => this.needRefresh = true;

  private void cboxTuRefresh_CheckedChanged(object sender, EventArgs e)
  {
    this.autoRefresh = this.cboxTuRefresh.Checked;
  }

  private void cboItemName_DropDown(object sender, EventArgs e)
  {
    if (this.DialogMode == 1 || this.DialogMode == 2 || this.DialogMode == 5 || this.DialogMode == 10)
    {
      if (this.account == null)
        return;
      try
      {
        List<string> stringList = new List<string>();
        for (int index = 0; index < 60; ++index)
        {
          string str1 = "";
          if (this.account.MyInventory.AllItems[index].ItemName != "" && this.account.MyInventory.AllItems[index].ItemID > 0)
            str1 = this.account.MyInventory.AllItems[index].ItemName;
          if (this.account.MyInventory.AllItems[index].ItemName == string.Empty && this.account.MyInventory.AllItems[index].ItemID > 0)
            str1 = this.account.MyInventory.AllItems[index].ItemID.ToString();
          bool flag = false;
          if (stringList.Count > 0)
          {
            try
            {
              foreach (string str2 in stringList)
              {
                if (str2.Contains("~"))
                {
                  string[] strArray = str2.Split('~');
                  if (strArray.Length >= 2 && strArray[1] == str1)
                  {
                    flag = true;
                    break;
                  }
                }
                else if (str2 == str1)
                {
                  flag = true;
                  break;
                }
              }
            }
            catch (Exception ex)
            {
            }
          }
          if (str1 != "" && !flag)
            stringList.Add($"{(index + 1).ToString()}~{str1}");
        }
        this.cboItemName.BeginUpdate();
        string[] array = stringList.ToArray();
        this.cboItemName.Items.Clear();
        this.cboItemName.Items.AddRange((object[]) array);
        this.cboItemName.EndUpdate();
      }
      catch (Exception ex)
      {
        this.cboItemName.Items.Clear();
      }
    }
    else
    {
      if (this.cboItemName.Items.Count <= 0)
        return;
      this.cboItemName.Items.Clear();
    }
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
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmBuffList));
    this.btnAddName = new Button();
    this.txtBuffName = new TextBox();
    this.lvBuffList = new ListView();
    this.columnHeader16 = new ColumnHeader();
    this.lblTop = new Label();
    this.btnClose = new Button();
    this.timer1 = new Timer(this.components);
    this.label12 = new Label();
    this.label1 = new Label();
    this.lvPlayers = new ListView();
    this.columnHeader1 = new ColumnHeader();
    this.columnHeader2 = new ColumnHeader();
    this.label2 = new Label();
    this.label3 = new Label();
    this.btnRefresh = new Button();
    this.cboxTuRefresh = new CheckBox();
    this.btnSaveList = new Button();
    this.btnRemove = new Button();
    this.btnAdd = new Button();
    this.btnDanhSachBuff = new Button();
    this.cboItemName = new ComboBox();
    this.SuspendLayout();
    this.btnAddName.BackColor = Color.FromArgb(210, 249, 213);
    componentResourceManager.ApplyResources((object) this.btnAddName, "btnAddName");
    this.btnAddName.Name = "btnAddName";
    this.btnAddName.UseVisualStyleBackColor = false;
    this.btnAddName.Click += new EventHandler(this.btnAddName_Click);
    this.txtBuffName.BackColor = Color.WhiteSmoke;
    componentResourceManager.ApplyResources((object) this.txtBuffName, "txtBuffName");
    this.txtBuffName.Name = "txtBuffName";
    this.lvBuffList.BackColor = Color.WhiteSmoke;
    this.lvBuffList.Columns.AddRange(new ColumnHeader[1]
    {
      this.columnHeader16
    });
    this.lvBuffList.ForeColor = Color.FromArgb(32 /*0x20*/, 32 /*0x20*/, 32 /*0x20*/);
    this.lvBuffList.FullRowSelect = true;
    this.lvBuffList.GridLines = true;
    this.lvBuffList.HeaderStyle = ColumnHeaderStyle.Nonclickable;
    componentResourceManager.ApplyResources((object) this.lvBuffList, "lvBuffList");
    this.lvBuffList.Name = "lvBuffList";
    this.lvBuffList.UseCompatibleStateImageBehavior = false;
    this.lvBuffList.View = View.Details;
    this.lvBuffList.SelectedIndexChanged += new EventHandler(this.lvBuffList_SelectedIndexChanged);
    this.lvBuffList.MouseDoubleClick += new MouseEventHandler(this.lvBuffList_MouseDoubleClick);
    componentResourceManager.ApplyResources((object) this.columnHeader16, "columnHeader16");
    componentResourceManager.ApplyResources((object) this.lblTop, "lblTop");
    this.lblTop.Name = "lblTop";
    this.btnClose.BackColor = Color.FromArgb(210, 249, 213);
    componentResourceManager.ApplyResources((object) this.btnClose, "btnClose");
    this.btnClose.Name = "btnClose";
    this.btnClose.UseVisualStyleBackColor = false;
    this.btnClose.Click += new EventHandler(this.btnClose_Click);
    this.timer1.Enabled = true;
    this.timer1.Interval = 500;
    this.timer1.Tick += new EventHandler(this.timer1_Tick);
    componentResourceManager.ApplyResources((object) this.label12, "label12");
    this.label12.ForeColor = Color.DodgerBlue;
    this.label12.Name = "label12";
    componentResourceManager.ApplyResources((object) this.label1, "label1");
    this.label1.Name = "label1";
    this.lvPlayers.BackColor = Color.WhiteSmoke;
    this.lvPlayers.Columns.AddRange(new ColumnHeader[2]
    {
      this.columnHeader1,
      this.columnHeader2
    });
    this.lvPlayers.ForeColor = Color.FromArgb(32 /*0x20*/, 32 /*0x20*/, 32 /*0x20*/);
    this.lvPlayers.FullRowSelect = true;
    this.lvPlayers.GridLines = true;
    this.lvPlayers.HeaderStyle = ColumnHeaderStyle.Nonclickable;
    componentResourceManager.ApplyResources((object) this.lvPlayers, "lvPlayers");
    this.lvPlayers.Name = "lvPlayers";
    this.lvPlayers.UseCompatibleStateImageBehavior = false;
    this.lvPlayers.View = View.Details;
    this.lvPlayers.MouseDoubleClick += new MouseEventHandler(this.lvPlayers_MouseDoubleClick);
    componentResourceManager.ApplyResources((object) this.columnHeader1, "columnHeader1");
    componentResourceManager.ApplyResources((object) this.columnHeader2, "columnHeader2");
    componentResourceManager.ApplyResources((object) this.label2, "label2");
    this.label2.Name = "label2";
    componentResourceManager.ApplyResources((object) this.label3, "label3");
    this.label3.Name = "label3";
    this.btnRefresh.BackColor = Color.FromArgb(210, 249, 213);
    componentResourceManager.ApplyResources((object) this.btnRefresh, "btnRefresh");
    this.btnRefresh.Name = "btnRefresh";
    this.btnRefresh.UseVisualStyleBackColor = false;
    this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);
    componentResourceManager.ApplyResources((object) this.cboxTuRefresh, "cboxTuRefresh");
    this.cboxTuRefresh.BackColor = Color.Transparent;
    this.cboxTuRefresh.Checked = true;
    this.cboxTuRefresh.CheckState = CheckState.Checked;
    this.cboxTuRefresh.Name = "cboxTuRefresh";
    this.cboxTuRefresh.UseVisualStyleBackColor = false;
    this.cboxTuRefresh.CheckedChanged += new EventHandler(this.cboxTuRefresh_CheckedChanged);
    this.btnSaveList.BackColor = Color.Transparent;
    componentResourceManager.ApplyResources((object) this.btnSaveList, "btnSaveList");
    this.btnSaveList.ForeColor = SystemColors.ButtonFace;
    this.btnSaveList.Image = (Image) Resources.save;
    this.btnSaveList.Name = "btnSaveList";
    this.btnSaveList.UseVisualStyleBackColor = false;
    this.btnSaveList.Click += new EventHandler(this.btnSaveList_Click);
    this.btnRemove.BackColor = SystemColors.Control;
    componentResourceManager.ApplyResources((object) this.btnRemove, "btnRemove");
    this.btnRemove.ForeColor = SystemColors.Control;
    this.btnRemove.Image = (Image) Resources.right;
    this.btnRemove.Name = "btnRemove";
    this.btnRemove.UseVisualStyleBackColor = false;
    this.btnRemove.Click += new EventHandler(this.btnRemove_Click);
    this.btnAdd.BackColor = SystemColors.Control;
    componentResourceManager.ApplyResources((object) this.btnAdd, "btnAdd");
    this.btnAdd.ForeColor = SystemColors.Control;
    this.btnAdd.Image = (Image) Resources.left;
    this.btnAdd.Name = "btnAdd";
    this.btnAdd.UseVisualStyleBackColor = false;
    this.btnAdd.Click += new EventHandler(this.btnAdd_Click);
    this.btnDanhSachBuff.BackColor = Color.Transparent;
    componentResourceManager.ApplyResources((object) this.btnDanhSachBuff, "btnDanhSachBuff");
    this.btnDanhSachBuff.ForeColor = SystemColors.ButtonFace;
    this.btnDanhSachBuff.Image = (Image) Resources.folderopen;
    this.btnDanhSachBuff.Name = "btnDanhSachBuff";
    this.btnDanhSachBuff.UseVisualStyleBackColor = false;
    this.btnDanhSachBuff.Click += new EventHandler(this.btnDanhSachBuff_Click);
    this.cboItemName.DropDownWidth = 170;
    this.cboItemName.FormattingEnabled = true;
    componentResourceManager.ApplyResources((object) this.cboItemName, "cboItemName");
    this.cboItemName.Name = "cboItemName";
    this.cboItemName.DropDown += new EventHandler(this.cboItemName_DropDown);
    componentResourceManager.ApplyResources((object) this, "$this");
    this.AutoScaleMode = AutoScaleMode.Font;
    this.Controls.Add((Control) this.cboItemName);
    this.Controls.Add((Control) this.cboxTuRefresh);
    this.Controls.Add((Control) this.btnRefresh);
    this.Controls.Add((Control) this.label3);
    this.Controls.Add((Control) this.btnSaveList);
    this.Controls.Add((Control) this.btnRemove);
    this.Controls.Add((Control) this.btnAdd);
    this.Controls.Add((Control) this.label2);
    this.Controls.Add((Control) this.lvPlayers);
    this.Controls.Add((Control) this.label1);
    this.Controls.Add((Control) this.label12);
    this.Controls.Add((Control) this.btnClose);
    this.Controls.Add((Control) this.lblTop);
    this.Controls.Add((Control) this.btnDanhSachBuff);
    this.Controls.Add((Control) this.btnAddName);
    this.Controls.Add((Control) this.txtBuffName);
    this.Controls.Add((Control) this.lvBuffList);
    this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
    this.MaximizeBox = false;
    this.Name = nameof (frmBuffList);
    this.Load += new EventHandler(this.frmBuffList_Load);
    this.Shown += new EventHandler(this.frmBuffList_Shown);
    this.ResumeLayout(false);
    this.PerformLayout();
  }
}
