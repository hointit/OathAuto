// Decompiled with JetBrains decompiler
// Type: SmartBot.frmItemList
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using BrightIdeasSoftware;
using GAuto_Auto_None.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

#nullable disable
namespace SmartBot;

public class frmItemList : Form
{
  private const long delayPlayer = 1400;
  public AutoAccount account;
  private List<PlayerListItem> surPlayers = new List<PlayerListItem>();
  public int DialogMode;
  private bool flagUpdated;
  private bool needRefresh = true;
  private bool autoRefresh = true;
  private long stampPlayerRefresh;
  private List<int> updateMode = new List<int>()
  {
    0,
    3,
    4,
    6,
    8,
    9
  };
  private GAutoList<string> rightStringList = new GAutoList<string>();
  private IContainer components;
  private Button btnDanhSachBuff;
  private Button btnAddName;
  private TextBox txtBuffName;
  private Label lblTop;
  private Button btnClose;
  private Timer timer1;
  private Label label12;
  private Label label1;
  private Label label2;
  private Button btnAdd;
  private Button btnRemove;
  private Button btnSaveList;
  private Label label3;
  private Button btnRefresh;
  private CheckBox cboxTuRefresh;
  private ComboBox cboItemName;
  public ObjectListView listLeft;
  private OLVColumn colLeft_1;
  public ObjectListView listRight;
  private OLVColumn colRight_1;
  private OLVColumn colRight_2;

  public frmItemList()
  {
    this.InitializeComponent();
    this.colLeft_1.AspectGetter = (AspectGetterDelegate) (row => row != null && row != (object) "" ? row : (object) "");
  }

  private void frmItemList_Load(object sender, EventArgs e)
  {
  }

  private void btnAddName_Click(object sender, EventArgs e) => this.AddName();

  private void RefreshNames(AutoAccount account, GAutoList<string> existList, bool isPet = false)
  {
    if (this.stampPlayerRefresh > GA.nowStamp)
      return;
    this.stampPlayerRefresh = GA.nowStamp + 1400L;
    this.surPlayers.Clear();
    if (!isPet && account.MyPlayers != null)
    {
      if (account.MyPlayers.AllPlayers.Count > 0)
      {
        try
        {
          for (int index1 = account.MyPlayers.AllPlayers.Count - 1; index1 >= 0; --index1)
          {
            PlayerIndividual allPlayer = account.MyPlayers.AllPlayers[index1];
            bool flag1 = false;
            if (existList != null && existList.Count > 0)
            {
              for (int index2 = 0; index2 < existList.Count; ++index2)
              {
                if (existList[index2] == allPlayer.Name)
                {
                  flag1 = true;
                  break;
                }
              }
            }
            bool flag2 = false;
            if (this.surPlayers.Count > 0)
            {
              for (int index3 = 0; index3 < this.surPlayers.Count; ++index3)
              {
                if (this.surPlayers[index3].Name == allPlayer.Name)
                {
                  flag2 = true;
                  break;
                }
              }
            }
            if (!flag1 && !flag2)
              this.surPlayers.Add(new PlayerListItem()
              {
                Name = allPlayer.Name,
                Level = allPlayer.Level
              });
          }
        }
        catch (Exception ex)
        {
        }
      }
    }
    if (isPet)
    {
      if (account.MyQuai != null)
      {
        if (account.MyQuai.AllQuai.Count > 0)
        {
          try
          {
            for (int index4 = account.MyQuai.AllQuai.Count - 1; index4 >= 0; --index4)
            {
              QuaiIndividual quaiIndividual = account.MyQuai.AllQuai[index4];
              if (quaiIndividual.CanAttack == byte.MaxValue)
              {
                bool flag3 = false;
                if (existList != null && existList.Count > 0)
                {
                  for (int index5 = 0; index5 < existList.Count; ++index5)
                  {
                    if (existList[index5] == quaiIndividual.Name)
                    {
                      flag3 = true;
                      break;
                    }
                  }
                }
                bool flag4 = false;
                if (this.surPlayers.Count > 0)
                {
                  for (int index6 = 0; index6 < this.surPlayers.Count; ++index6)
                  {
                    if (this.surPlayers[index6].Name == quaiIndividual.Name)
                    {
                      flag4 = true;
                      break;
                    }
                  }
                }
                if (!flag3 && !flag4)
                  this.surPlayers.Add(new PlayerListItem()
                  {
                    Name = quaiIndividual.Name,
                    Level = quaiIndividual.Level
                  });
              }
            }
          }
          catch (Exception ex)
          {
          }
        }
      }
    }
    try
    {
      if (this.surPlayers.Count > 0)
        this.surPlayers.Sort(new Comparison<PlayerListItem>(F.PlayerComparison));
      int num = -1;
      if (this.listRight.Items.Count > 0 && this.listRight.SelectedObjects != null && this.listRight.SelectedObjects.Count > 0)
        num = this.listRight.IndexOf(this.listRight.SelectedObjects[0]);
      this.listRight.SetObjects((IEnumerable) this.surPlayers);
      if (0 > num || num > this.listRight.Items.Count - 1)
        return;
      this.listRight.SelectedIndex = num;
      this.listRight.FocusedItem = this.listRight.SelectedItems[0];
    }
    catch (Exception ex)
    {
    }
  }

  private void AddName(bool refresh = true)
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
    GAutoList<string> rightList = this.GetRightList();
    if (rightList != null)
    {
      if (this.DialogMode != 1)
      {
        if (!rightList.Contains(text))
        {
          rightList.Add(text);
          if (refresh)
          {
            rightList.Sort();
            this.listLeft.SetObjects((IEnumerable) rightList);
          }
        }
      }
      else
      {
        int result = 0;
        int.TryParse(text, out result);
        if (text.Contains(" ") || text.Contains("hài") || text.Contains("mão") || result > 0)
        {
          if (!rightList.Contains(text.ToLower()))
          {
            rightList.Add(text.ToLower());
            if (refresh)
            {
              rightList.Sort();
              this.listLeft.SetObjects((IEnumerable) rightList);
            }
          }
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
              if (!rightList.Contains(allItem.ItemID.ToString()))
              {
                rightList.Add(allItem.ItemID.ToString());
                if (refresh)
                {
                  rightList.Sort();
                  this.listLeft.SetObjects((IEnumerable) rightList);
                  break;
                }
                break;
              }
            }
          }
          if (!flag)
            GA.ShowBalloon(string.Format(frmMain.langHuyVatPhamInput, (object) text), frmMain.langWarning, this.account, 10000);
        }
      }
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
    GAutoList<string> rightList = this.GetRightList();
    while (!streamReader.EndOfStream)
    {
      string str = streamReader.ReadLine();
      if (!string.IsNullOrEmpty(str) && !str.StartsWith("#") && rightList != null && !rightList.Contains(str))
        rightList.Add(str);
    }
    rightList.Sort();
    this.listLeft.SetObjects((IEnumerable) rightList);
    streamReader.Close();
  }

  private void RemoveItem(ObjectListView lv)
  {
    if (lv.SelectedObjects == null || lv.SelectedObjects.Count <= 0 || this.account == null)
      return;
    GAutoList<string> rightList = this.GetRightList();
    if (rightList == null)
      return;
    for (int index = 0; index < lv.SelectedObjects.Count; ++index)
      rightList.Remove(lv.SelectedObjects[index].ToString());
    rightList.Sort();
    this.listLeft.SetObjects((IEnumerable) rightList);
  }

  private GAutoList<string> GetRightList()
  {
    if (this.account != null)
    {
      if (this.DialogMode == 0)
        return frmLogin.GAuto.Settings.BuffNameList;
      if (this.DialogMode == 1)
        return frmLogin.GAuto.Settings.ItemTuHuyList;
      if (this.DialogMode == 2)
        return frmLogin.GAuto.Settings.ItemBanList;
      if (this.DialogMode == 3)
        return this.account.Settings.AutoPartyList;
      if (this.DialogMode == 4)
        return this.account.Settings.PTBlacklist;
      if (this.DialogMode == 5)
        return frmLogin.GAuto.Settings.ListItemNhat;
      if (this.DialogMode == 6)
        return frmLogin.GAuto.Settings.ListBuffPetID;
      if (this.DialogMode == 7)
        return this.account.Settings.QuaiNoAttackList;
      if (this.DialogMode == 8)
        return this.account.Settings.PKPlayerList;
      if (this.DialogMode == 9)
        return this.account.Settings.PKBlackList;
      if (this.DialogMode == 10)
        return this.account.Settings.ListItemNhatIgnore;
    }
    return (GAutoList<string>) null;
  }

  private void timer1_Tick(object sender, EventArgs e)
  {
    if (this.account == null || !this.autoRefresh && !this.needRefresh || !this.updateMode.Contains(this.DialogMode))
      return;
    if (this.DialogMode != 6)
      this.RefreshNames(this.account, this.GetRightList());
    else
      this.RefreshNames(this.account, this.GetRightList(), true);
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

  private void frmItemList_Shown(object sender, EventArgs e)
  {
    switch (this.DialogMode)
    {
      case 0:
        this.lblTop.Text = frmMain.langAddBuffName;
        this.listLeft.Columns[0].Text = frmMain.langPlayerName;
        this.Text = frmMain.langHealingList;
        break;
      case 1:
        this.lblTop.Text = frmMain.langItemDestroy;
        this.listLeft.Columns[0].Text = frmMain.langDestroyingItems;
        this.Text = frmMain.langWillDestroyList;
        break;
      case 2:
        this.lblTop.Text = frmMain.langItemToSell;
        this.listLeft.Columns[0].Text = frmMain.langItemToSellName;
        this.Text = frmMain.langSellingList;
        break;
      case 3:
        this.lblTop.Text = frmMain.langPlayerPTAccept;
        this.listLeft.Columns[0].Text = frmMain.langInvitePT;
        this.Text = frmMain.langAcceptPT;
        break;
      case 4:
        this.lblTop.Text = frmMain.langBlockPT;
        this.listLeft.Columns[0].Text = frmMain.langBlockPT2;
        this.Text = frmMain.langBlockPTList;
        break;
      case 5:
        this.lblTop.Text = frmMain.langPickItemList;
        this.listLeft.Columns[0].Text = frmMain.langPickItemList2;
        this.Text = frmMain.langPickItemList3;
        break;
      case 6:
        this.lblTop.Text = frmMain.langPetBuffName;
        this.listLeft.Columns[0].Text = frmMain.langPetBuffName2;
        this.Text = frmMain.langBuffPetName;
        break;
      case 7:
        this.lblTop.Text = frmMain.langNoAttackName;
        this.listLeft.Columns[0].Text = frmMain.langMobName;
        this.Text = frmMain.langNoAttackList;
        break;
      case 8:
        this.lblTop.Text = frmMain.langPickPKName;
        this.listLeft.Columns[0].Text = frmMain.langPKName;
        this.Text = frmMain.langPK2List;
        break;
      case 9:
        this.lblTop.Text = frmMain.langPickPKBlackName;
        this.listLeft.Columns[0].Text = frmMain.langPKName;
        this.Text = frmMain.langPK3List;
        break;
      case 10:
        this.lblTop.Text = frmMain.langPickItemListIgnore;
        this.listLeft.Columns[0].Text = frmMain.langPickItemListIgnore2;
        this.Text = frmMain.langPickItemListIgnore3;
        break;
    }
    GAutoList<string> rightList = this.GetRightList();
    if (rightList == null)
      return;
    rightList.Sort();
    this.listLeft.SetObjects((IEnumerable) rightList);
    if (!this.updateMode.Contains(this.DialogMode))
      return;
    this.RefreshNames(this.account, rightList);
    this.listRight.SetObjects((IEnumerable) this.surPlayers);
    this.AdjustGUI();
  }

  private void btnAdd_Click(object sender, EventArgs e)
  {
    if (this.listRight.SelectedObjects == null || this.listRight.SelectedObjects.Count <= 0)
      return;
    for (int index = 0; index < this.listRight.SelectedObjects.Count - 1; ++index)
    {
      this.cboItemName.Text = ((PlayerListItem) this.listRight.SelectedObjects[index]).Name;
      this.AddName(false);
    }
    this.cboItemName.Text = ((PlayerListItem) this.listRight.SelectedObjects[this.listRight.SelectedObjects.Count - 1]).Name;
    this.AddName();
  }

  private void btnRemove_Click(object sender, EventArgs e) => this.RemoveItem(this.listLeft);

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
      GAutoList<string> rightList = this.GetRightList();
      if (rightList != null)
      {
        foreach (string str in (List<string>) rightList)
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

  private void cboItemName_KeyPress(object sender, KeyPressEventArgs e)
  {
    if (e.KeyChar != '\r' && e.KeyChar != '\r')
      return;
    this.AddName();
  }

  private void label1_Click(object sender, EventArgs e)
  {
  }

  private void label3_Click(object sender, EventArgs e)
  {
  }

  private void listLeft_CellClick(object sender, CellClickEventArgs e)
  {
    if (e.ClickCount == 2)
    {
      if (e.ColumnIndex < 0 || e.RowIndex < 0)
        return;
      string model = (string) e.Model;
      if (!(model != ""))
        return;
      GAutoList<string> rightList = this.GetRightList();
      if (rightList == null)
        return;
      rightList.Remove(model);
      this.listLeft.SetObjects((IEnumerable) rightList);
    }
    else
    {
      if (e.ColumnIndex < 0 || e.RowIndex < 0)
        return;
      string model = (string) e.Model;
      if (!(model != ""))
        return;
      this.cboItemName.Text = model;
    }
  }

  private void listRight_CellClick(object sender, CellClickEventArgs e)
  {
    if (e.ClickCount != 2 || e.ColumnIndex < 0 || e.RowIndex < 0)
      return;
    PlayerListItem model = (PlayerListItem) e.Model;
    if (model == null)
      return;
    this.cboItemName.Text = model.Name;
    this.AddName();
  }

  private void listLeft_SelectedIndexChanged(object sender, EventArgs e)
  {
  }

  private void listLeft_SelectionChanged(object sender, EventArgs e)
  {
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
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmItemList));
    this.btnAddName = new Button();
    this.txtBuffName = new TextBox();
    this.lblTop = new Label();
    this.btnClose = new Button();
    this.timer1 = new Timer(this.components);
    this.label12 = new Label();
    this.label1 = new Label();
    this.label2 = new Label();
    this.label3 = new Label();
    this.btnRefresh = new Button();
    this.cboxTuRefresh = new CheckBox();
    this.btnSaveList = new Button();
    this.btnRemove = new Button();
    this.btnAdd = new Button();
    this.btnDanhSachBuff = new Button();
    this.cboItemName = new ComboBox();
    this.listLeft = new ObjectListView();
    this.colLeft_1 = new OLVColumn();
    this.listRight = new ObjectListView();
    this.colRight_1 = new OLVColumn();
    this.colRight_2 = new OLVColumn();
    ((ISupportInitialize) this.listLeft).BeginInit();
    ((ISupportInitialize) this.listRight).BeginInit();
    this.SuspendLayout();
    this.btnAddName.BackColor = Color.FromArgb(210, 249, 213);
    componentResourceManager.ApplyResources((object) this.btnAddName, "btnAddName");
    this.btnAddName.Name = "btnAddName";
    this.btnAddName.UseVisualStyleBackColor = false;
    this.btnAddName.Click += new EventHandler(this.btnAddName_Click);
    this.txtBuffName.BackColor = Color.WhiteSmoke;
    componentResourceManager.ApplyResources((object) this.txtBuffName, "txtBuffName");
    this.txtBuffName.Name = "txtBuffName";
    componentResourceManager.ApplyResources((object) this.lblTop, "lblTop");
    this.lblTop.Name = "lblTop";
    this.btnClose.BackColor = Color.FromArgb(210, 249, 213);
    componentResourceManager.ApplyResources((object) this.btnClose, "btnClose");
    this.btnClose.Name = "btnClose";
    this.btnClose.UseVisualStyleBackColor = false;
    this.btnClose.Click += new EventHandler(this.btnClose_Click);
    this.timer1.Enabled = true;
    this.timer1.Interval = 1500;
    this.timer1.Tick += new EventHandler(this.timer1_Tick);
    componentResourceManager.ApplyResources((object) this.label12, "label12");
    this.label12.ForeColor = Color.DodgerBlue;
    this.label12.Name = "label12";
    componentResourceManager.ApplyResources((object) this.label1, "label1");
    this.label1.Name = "label1";
    this.label1.Click += new EventHandler(this.label1_Click);
    componentResourceManager.ApplyResources((object) this.label2, "label2");
    this.label2.Name = "label2";
    componentResourceManager.ApplyResources((object) this.label3, "label3");
    this.label3.Name = "label3";
    this.label3.Click += new EventHandler(this.label3_Click);
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
    this.cboItemName.KeyPress += new KeyPressEventHandler(this.cboItemName_KeyPress);
    this.listLeft.AllColumns.Add(this.colLeft_1);
    this.listLeft.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
    this.listLeft.CellEditActivation = ObjectListView.CellEditActivateMode.SingleClick;
    this.listLeft.CellEditEnterChangesRows = true;
    this.listLeft.CellEditTabChangesRows = true;
    this.listLeft.CellEditUseWholeCell = false;
    this.listLeft.Columns.AddRange(new ColumnHeader[1]
    {
      (ColumnHeader) this.colLeft_1
    });
    this.listLeft.Cursor = Cursors.Default;
    this.listLeft.ForeColor = Color.FromArgb(32 /*0x20*/, 32 /*0x20*/, 32 /*0x20*/);
    this.listLeft.FullRowSelect = true;
    this.listLeft.HideSelection = false;
    this.listLeft.IsSimpleDragSource = true;
    this.listLeft.IsSimpleDropSink = true;
    componentResourceManager.ApplyResources((object) this.listLeft, "listLeft");
    this.listLeft.Name = "listLeft";
    this.listLeft.UseCompatibleStateImageBehavior = false;
    this.listLeft.UseHotControls = false;
    this.listLeft.UseOverlays = false;
    this.listLeft.View = View.Details;
    this.listLeft.CellClick += new EventHandler<CellClickEventArgs>(this.listLeft_CellClick);
    this.listLeft.SelectionChanged += new EventHandler(this.listLeft_SelectionChanged);
    this.listLeft.SelectedIndexChanged += new EventHandler(this.listLeft_SelectedIndexChanged);
    this.colLeft_1.FillsFreeSpace = true;
    this.colLeft_1.Sortable = false;
    componentResourceManager.ApplyResources((object) this.colLeft_1, "colLeft_1");
    this.listRight.AllColumns.Add(this.colRight_1);
    this.listRight.AllColumns.Add(this.colRight_2);
    this.listRight.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
    this.listRight.CellEditActivation = ObjectListView.CellEditActivateMode.SingleClick;
    this.listRight.CellEditEnterChangesRows = true;
    this.listRight.CellEditTabChangesRows = true;
    this.listRight.CellEditUseWholeCell = false;
    this.listRight.Columns.AddRange(new ColumnHeader[2]
    {
      (ColumnHeader) this.colRight_1,
      (ColumnHeader) this.colRight_2
    });
    this.listRight.Cursor = Cursors.Default;
    this.listRight.ForeColor = Color.FromArgb(32 /*0x20*/, 32 /*0x20*/, 32 /*0x20*/);
    this.listRight.FullRowSelect = true;
    this.listRight.HideSelection = false;
    this.listRight.IsSimpleDragSource = true;
    this.listRight.IsSimpleDropSink = true;
    componentResourceManager.ApplyResources((object) this.listRight, "listRight");
    this.listRight.Name = "listRight";
    this.listRight.UseCompatibleStateImageBehavior = false;
    this.listRight.UseHotControls = false;
    this.listRight.UseOverlays = false;
    this.listRight.View = View.Details;
    this.listRight.CellClick += new EventHandler<CellClickEventArgs>(this.listRight_CellClick);
    this.colRight_1.AspectName = "Name";
    this.colRight_1.FillsFreeSpace = true;
    this.colRight_1.Sortable = false;
    componentResourceManager.ApplyResources((object) this.colRight_1, "colRight_1");
    this.colRight_2.AspectName = "Level";
    componentResourceManager.ApplyResources((object) this.colRight_2, "colRight_2");
    componentResourceManager.ApplyResources((object) this, "$this");
    this.AutoScaleMode = AutoScaleMode.Font;
    this.Controls.Add((Control) this.listRight);
    this.Controls.Add((Control) this.listLeft);
    this.Controls.Add((Control) this.cboItemName);
    this.Controls.Add((Control) this.cboxTuRefresh);
    this.Controls.Add((Control) this.btnRefresh);
    this.Controls.Add((Control) this.label3);
    this.Controls.Add((Control) this.btnSaveList);
    this.Controls.Add((Control) this.btnRemove);
    this.Controls.Add((Control) this.btnAdd);
    this.Controls.Add((Control) this.label2);
    this.Controls.Add((Control) this.label1);
    this.Controls.Add((Control) this.label12);
    this.Controls.Add((Control) this.btnClose);
    this.Controls.Add((Control) this.lblTop);
    this.Controls.Add((Control) this.btnDanhSachBuff);
    this.Controls.Add((Control) this.btnAddName);
    this.Controls.Add((Control) this.txtBuffName);
    this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
    this.MaximizeBox = false;
    this.Name = nameof (frmItemList);
    this.Load += new EventHandler(this.frmItemList_Load);
    this.Shown += new EventHandler(this.frmItemList_Shown);
    ((ISupportInitialize) this.listLeft).EndInit();
    ((ISupportInitialize) this.listRight).EndInit();
    this.ResumeLayout(false);
    this.PerformLayout();
  }
}
