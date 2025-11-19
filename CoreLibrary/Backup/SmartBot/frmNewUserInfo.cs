// Decompiled with JetBrains decompiler
// Type: SmartBot.frmNewUserInfo
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using BrightIdeasSoftware;
using GAuto_Auto_None.Properties;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

#nullable disable
namespace SmartBot;

public class frmNewUserInfo : Form
{
  private IContainer components;
  private GroupBox groupBox1;
  private Label lbGGKM;
  private Label lbGGNap;
  private Label lbHandung;
  private Label lbUsername;
  private Label label4;
  private Label label3;
  private Label label2;
  private Label label1;
  private GroupBox groupBox2;
  private GroupBox groupBox3;
  private Label label5;
  private ObjectListView lvTinhnang;
  private OLVColumn col_Index;
  private OLVColumn col_Tinhnang;
  private OLVColumn col_Remain;
  private OLVColumn col_Comment;
  private OLVColumn col_Buy;
  private ComboBox cboBuyChedo;
  private Label label7;
  private ComboBox cboBuyTime;
  private Label label6;
  private Button btnNapThe;
  private Button btnMua24h;
  private ComboBox cboBuyTrader;
  private Label label8;
  private ComboBox cboBuyYTO;
  private Label label9;
  private ObjectListView lvBuyLic;
  private OLVColumn colLic_Index;
  private OLVColumn col_ItemName;
  private OLVColumn colLic_Comment;
  private OLVColumn colLic_Price;
  private OLVColumn colLic_Remove;
  private StatusStrip statusStrip1;
  private ToolStripStatusLabel status1;
  private ObjectListView lvHistory;
  private OLVColumn colHist_Index;
  private OLVColumn colHist_ActTime;
  private OLVColumn colHist_Activity;
  private OLVColumn colHist_Cost;
  private OLVColumn colHist_Remain;
  private Button btnMuaNgay;
  private Button btnRefresh;
  private BackgroundWorker backgroundWorker1;
  private Label lblTotalPrice;
  private Label label10;
  private OLVColumn colLic_SlotID;

  public frmNewUserInfo() => this.InitializeComponent();

  private void frmNewUserInfo_Load(object sender, EventArgs e)
  {
    if (frmLogin.GAuto.Settings.Account == null)
      return;
    this.lbUsername.DataBindings.Clear();
    this.lbUsername.DataBindings.Add("Text", (object) frmLogin.GAuto.Settings.Account, "Username");
    this.lbGGNap.DataBindings.Clear();
    this.lbGGNap.DataBindings.Add("Text", (object) frmLogin.GAuto.Settings.Account, "RemainGGoldBalance");
    this.lbGGKM.DataBindings.Clear();
    this.lbGGKM.DataBindings.Add("Text", (object) frmLogin.GAuto.Settings.Account, "RemainGGoldPromo");
    this.lbHandung.DataBindings.Clear();
    this.lbHandung.DataBindings.Add("Text", (object) frmLogin.GAuto.Settings.Account, "Handung");
    this.DisplayBangGiaCombo();
  }

  private void DisplayBangGiaCombo(int loai = 0)
  {
    if (frmLogin.GAuto.Settings.Account.BangGia.Count <= 0)
      return;
    List<PriceItem> bangGia = frmLogin.GAuto.Settings.Account.BangGia;
    List<string> stringList1 = new List<string>()
    {
      "Không mua"
    };
    List<string> stringList2 = new List<string>()
    {
      "Không mua"
    };
    List<string> stringList3 = new List<string>()
    {
      "Không mua"
    };
    List<string> stringList4 = new List<string>()
    {
      "Không mua"
    };
    for (int index = bangGia.Count - 1; index >= 0; --index)
    {
      if (bangGia[index].Key == "time")
        stringList1.Add($"{bangGia[index].Desc} | {bangGia[index].Price} {frmLogin.GGUnit}");
      else if (bangGia[index].Key == "tnchedo")
        stringList2.Add($"{bangGia[index].Desc} | {bangGia[index].Price} {frmLogin.GGUnit}");
      else if (bangGia[index].Key == "tnyto")
        stringList3.Add($"{bangGia[index].Desc} | {bangGia[index].Price} {frmLogin.GGUnit}");
      else if (bangGia[index].Key == "tntrader")
        stringList4.Add($"{bangGia[index].Desc} | {bangGia[index].Price} {frmLogin.GGUnit}");
    }
    this.cboBuyTime.BeginUpdate();
    this.cboBuyTime.Items.AddRange((object[]) stringList1.ToArray());
    this.cboBuyTime.SelectedIndex = 0;
    this.cboBuyTime.EndUpdate();
    this.cboBuyChedo.BeginUpdate();
    this.cboBuyChedo.Items.AddRange((object[]) stringList2.ToArray());
    this.cboBuyChedo.SelectedIndex = 0;
    this.cboBuyChedo.EndUpdate();
    this.cboBuyYTO.BeginUpdate();
    this.cboBuyYTO.Items.AddRange((object[]) stringList3.ToArray());
    this.cboBuyYTO.SelectedIndex = 0;
    this.cboBuyYTO.EndUpdate();
    this.cboBuyTrader.BeginUpdate();
    this.cboBuyTrader.Items.AddRange((object[]) stringList4.ToArray());
    this.cboBuyTrader.SelectedIndex = 0;
    this.cboBuyTrader.EndUpdate();
  }

  private void groupBox1_Enter(object sender, EventArgs e)
  {
  }

  private void label7_Click(object sender, EventArgs e)
  {
  }

  private void groupBox2_Enter(object sender, EventArgs e)
  {
  }

  private void label6_Click(object sender, EventArgs e)
  {
  }

  private void btnRefresh_Click(object sender, EventArgs e)
  {
    this.backgroundWorker1.RunWorkerAsync((object) 1);
  }

  private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
  {
    if (e.Argument == null || e.Argument.GetType() != typeof (int) || (int) e.Argument != 1)
      return;
    e.Result = (object) GA.GetUsageHistory();
  }

  private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
  {
    if (e.Result == null || e.Result.GetType() != typeof (Dictionary<string, object>))
      return;
    Dictionary<string, object> result = (Dictionary<string, object>) e.Result;
    if (result == null)
      return;
    frmLogin.GAuto.Settings.Account.ListHistory.Clear();
    if (result.Count > 0)
    {
      int num1 = 0;
      if (result.ContainsKey("count"))
        num1 = result["count"] != null ? int.Parse(result["count"].ToString()) : 0;
      if (num1 > 0 && result["username"].ToString() == frmLogin.GAuto.Settings.Account.Username)
      {
        List<Dictionary<string, object>> dictionaryList = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(result["history"].ToString());
        if (dictionaryList.Count > 0)
        {
          try
          {
            int num2 = 1;
            foreach (Dictionary<string, object> dictionary in dictionaryList)
            {
              HistoryItem historyItem = new HistoryItem();
              historyItem.ActDate = dictionary["date"] != null ? DateTime.Parse(dictionary["date"].ToString()) : DateTime.MinValue;
              double num3 = dictionary["endbalance"] != null ? double.Parse(dictionary["endbalance"].ToString()) / 1000.0 : 0.0;
              historyItem.Balance = num3 > 0.0 ? $"{num3.ToString("0.0")} {frmLogin.GGUnit}" : "-";
              double num4 = dictionary["ggcost"] != null ? double.Parse(dictionary["ggcost"].ToString()) / 1000.0 : 0.0;
              historyItem.Cost = num4 > 0.0 ? $"{num4.ToString("0.0")} {frmLogin.GGUnit}" : "-";
              if (dictionary["comment"] != null)
              {
                if (dictionary["comment"].ToString().StartsWith("Nạp"))
                {
                  historyItem.Comment = dictionary["comment"].ToString();
                }
                else
                {
                  MatchCollection matchCollection = Regex.Matches(dictionary["comment"].ToString(), "^.*hết hạn", RegexOptions.Multiline);
                  if (matchCollection.Count > 0)
                  {
                    string str = matchCollection[0].ToString().Replace("hết hạn", "").Trim().Replace("Mua gói", "").Replace(" giờ", "h").Replace(" ngày", "d");
                    int length = str.IndexOf('[');
                    if (length > 0)
                      str = str.Substring(0, length);
                    historyItem.Comment = str;
                  }
                }
              }
              else
                historyItem.Comment = "---";
              historyItem.Index = num2;
              frmLogin.GAuto.Settings.Account.ListHistory.Add(historyItem);
              ++num2;
            }
          }
          catch (Exception ex)
          {
          }
        }
      }
    }
    this.lvHistory.SetObjects((IEnumerable) frmLogin.GAuto.Settings.Account.ListHistory);
  }

  private void cboBuyChedo_SelectedIndexChanged(object sender, EventArgs e)
  {
    this.ExtractComboItem(sender);
  }

  private void cboBuyTime_DropDown(object sender, EventArgs e)
  {
    ComboBox comboBox = sender as ComboBox;
    if (!comboBox.Focused || comboBox.Items.Count != 0)
      return;
    this.DisplayBangGiaCombo();
  }

  private void cboBuyChedo_DropDown(object sender, EventArgs e)
  {
    ComboBox comboBox = sender as ComboBox;
    if (!comboBox.Focused || comboBox.Items.Count != 0)
      return;
    this.DisplayBangGiaCombo();
  }

  private void cboBuyYTO_DropDown(object sender, EventArgs e)
  {
    ComboBox comboBox = sender as ComboBox;
    if (!comboBox.Focused || comboBox.Items.Count != 0)
      return;
    this.DisplayBangGiaCombo();
  }

  private void cboBuyTime_SelectedIndexChanged(object sender, EventArgs e)
  {
    this.ExtractComboItem(sender);
  }

  private void ExtractComboItem(object sender)
  {
    ComboBox comboBox = sender as ComboBox;
    if (!comboBox.Focused)
      return;
    string input = comboBox.SelectedItem.ToString();
    PriceItem priceItem = (PriceItem) null;
    List<PriceItem> bangGia = frmLogin.GAuto.Settings.Account.BangGia;
    if (bangGia.Count <= 0)
      return;
    if (input.Contains("Không mua"))
    {
      string str = "";
      if (sender == this.cboBuyTime)
        str = "time";
      else if (sender == this.cboBuyChedo)
        str = "tnchedo";
      else if (sender == this.cboBuyYTO)
        str = "tnyto";
      else if (sender == this.cboBuyTrader)
        str = "tntrader";
      if (str != "" && frmLogin.GAuto.Settings.Account.ListBuyItem.Count > 0)
      {
        for (int index = frmLogin.GAuto.Settings.Account.ListBuyItem.Count - 1; index >= 0; --index)
        {
          if (frmLogin.GAuto.Settings.Account.ListBuyItem[index].Key == str)
          {
            frmLogin.GAuto.Settings.Account.ListBuyItem.RemoveAt(index);
            break;
          }
        }
      }
    }
    else
    {
      Match match = Regex.Match(input, "^.*\\|", RegexOptions.Multiline);
      if (match.Length > 0)
      {
        string str = match.ToString().Replace("|", "").Trim();
        for (int index = bangGia.Count - 1; index >= 0; --index)
        {
          if (bangGia[index].Desc == str)
          {
            priceItem = bangGia[index];
            break;
          }
        }
        if (priceItem != null)
        {
          BuyItem buyItem = (BuyItem) null;
          if (frmLogin.GAuto.Settings.Account.ListBuyItem.Count > 0)
          {
            for (int index = frmLogin.GAuto.Settings.Account.ListBuyItem.Count - 1; index >= 0; --index)
            {
              if (frmLogin.GAuto.Settings.Account.ListBuyItem[index].Key == priceItem.Key && priceItem.Price == frmLogin.GAuto.Settings.Account.ListBuyItem[index].Price)
              {
                buyItem = frmLogin.GAuto.Settings.Account.ListBuyItem[index];
                break;
              }
            }
          }
          if (buyItem == null)
          {
            frmLogin.GAuto.Settings.Account.ListBuyItem.Add(new BuyItem()
            {
              Desc = str,
              Price = priceItem.Price,
              Key = priceItem.Key,
              TimeCount = priceItem.Slot,
              TimeCountUnit = priceItem.SlotUnit,
              UnitCount = priceItem.SlotCount,
              UnitCountUnit = priceItem.SlotCountUnit,
              SlotID = GA.GenerateRandomName(5)
            });
          }
          else
          {
            buyItem.Desc = str;
            buyItem.Price = priceItem.Price;
            buyItem.TimeCount = priceItem.Slot;
            buyItem.TimeCountUnit = priceItem.SlotUnit;
            buyItem.UnitCount = priceItem.SlotCount;
            buyItem.UnitCountUnit = priceItem.SlotCountUnit;
          }
        }
      }
    }
    this.lvBuyLic.SetObjects((IEnumerable) frmLogin.GAuto.Settings.Account.ListBuyItem);
  }

  private void cboBuyYTO_SelectedIndexChanged(object sender, EventArgs e)
  {
    this.ExtractComboItem(sender);
  }

  private void cboBuyTrader_SelectedIndexChanged(object sender, EventArgs e)
  {
    this.ExtractComboItem(sender);
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.components != null)
      this.components.Dispose();
    base.Dispose(disposing);
  }

  private void InitializeComponent()
  {
    this.groupBox1 = new GroupBox();
    this.btnMua24h = new Button();
    this.btnNapThe = new Button();
    this.label5 = new Label();
    this.lvTinhnang = new ObjectListView();
    this.col_Index = new OLVColumn();
    this.col_Tinhnang = new OLVColumn();
    this.col_Remain = new OLVColumn();
    this.col_Comment = new OLVColumn();
    this.col_Buy = new OLVColumn();
    this.lbGGKM = new Label();
    this.lbGGNap = new Label();
    this.lbHandung = new Label();
    this.lbUsername = new Label();
    this.label4 = new Label();
    this.label3 = new Label();
    this.label2 = new Label();
    this.label1 = new Label();
    this.groupBox2 = new GroupBox();
    this.lblTotalPrice = new Label();
    this.label10 = new Label();
    this.btnMuaNgay = new Button();
    this.lvBuyLic = new ObjectListView();
    this.colLic_Index = new OLVColumn();
    this.col_ItemName = new OLVColumn();
    this.colLic_Comment = new OLVColumn();
    this.colLic_Price = new OLVColumn();
    this.colLic_SlotID = new OLVColumn();
    this.colLic_Remove = new OLVColumn();
    this.cboBuyTrader = new ComboBox();
    this.label8 = new Label();
    this.cboBuyYTO = new ComboBox();
    this.label9 = new Label();
    this.cboBuyChedo = new ComboBox();
    this.label7 = new Label();
    this.cboBuyTime = new ComboBox();
    this.label6 = new Label();
    this.groupBox3 = new GroupBox();
    this.btnRefresh = new Button();
    this.lvHistory = new ObjectListView();
    this.colHist_Index = new OLVColumn();
    this.colHist_ActTime = new OLVColumn();
    this.colHist_Activity = new OLVColumn();
    this.colHist_Cost = new OLVColumn();
    this.colHist_Remain = new OLVColumn();
    this.statusStrip1 = new StatusStrip();
    this.status1 = new ToolStripStatusLabel();
    this.backgroundWorker1 = new BackgroundWorker();
    this.groupBox1.SuspendLayout();
    ((ISupportInitialize) this.lvTinhnang).BeginInit();
    this.groupBox2.SuspendLayout();
    ((ISupportInitialize) this.lvBuyLic).BeginInit();
    this.groupBox3.SuspendLayout();
    ((ISupportInitialize) this.lvHistory).BeginInit();
    this.statusStrip1.SuspendLayout();
    this.SuspendLayout();
    this.groupBox1.Controls.Add((Control) this.btnMua24h);
    this.groupBox1.Controls.Add((Control) this.btnNapThe);
    this.groupBox1.Controls.Add((Control) this.label5);
    this.groupBox1.Controls.Add((Control) this.lvTinhnang);
    this.groupBox1.Controls.Add((Control) this.lbGGKM);
    this.groupBox1.Controls.Add((Control) this.lbGGNap);
    this.groupBox1.Controls.Add((Control) this.lbHandung);
    this.groupBox1.Controls.Add((Control) this.lbUsername);
    this.groupBox1.Controls.Add((Control) this.label4);
    this.groupBox1.Controls.Add((Control) this.label3);
    this.groupBox1.Controls.Add((Control) this.label2);
    this.groupBox1.Controls.Add((Control) this.label1);
    this.groupBox1.Dock = DockStyle.Top;
    this.groupBox1.Location = new Point(0, 0);
    this.groupBox1.Margin = new Padding(2);
    this.groupBox1.Name = "groupBox1";
    this.groupBox1.Padding = new Padding(2);
    this.groupBox1.Size = new Size(353, 186);
    this.groupBox1.TabIndex = 0;
    this.groupBox1.TabStop = false;
    this.groupBox1.Text = "Tài khoản + tính năng";
    this.groupBox1.Enter += new EventHandler(this.groupBox1_Enter);
    this.btnMua24h.BackColor = Color.FromArgb(210, 249, 213);
    this.btnMua24h.ForeColor = Color.DarkGreen;
    this.btnMua24h.Location = new Point(212, 60);
    this.btnMua24h.Name = "btnMua24h";
    this.btnMua24h.Size = new Size(63 /*0x3F*/, 20);
    this.btnMua24h.TabIndex = 80 /*0x50*/;
    this.btnMua24h.Text = "&Mua 24h";
    this.btnMua24h.UseVisualStyleBackColor = false;
    this.btnNapThe.BackColor = Color.FromArgb(210, 249, 213);
    this.btnNapThe.ForeColor = Color.DarkGreen;
    this.btnNapThe.Location = new Point(280, 60);
    this.btnNapThe.Name = "btnNapThe";
    this.btnNapThe.Size = new Size(63 /*0x3F*/, 20);
    this.btnNapThe.TabIndex = 79;
    this.btnNapThe.Text = "&Nạp thẻ";
    this.btnNapThe.UseVisualStyleBackColor = false;
    this.label5.AutoSize = true;
    this.label5.Location = new Point(6, 63 /*0x3F*/);
    this.label5.Margin = new Padding(2, 0, 2, 0);
    this.label5.Name = "label5";
    this.label5.Size = new Size(100, 13);
    this.label5.TabIndex = 9;
    this.label5.Text = "Tính năng đang có";
    this.lvTinhnang.AllColumns.Add(this.col_Index);
    this.lvTinhnang.AllColumns.Add(this.col_Tinhnang);
    this.lvTinhnang.AllColumns.Add(this.col_Remain);
    this.lvTinhnang.AllColumns.Add(this.col_Comment);
    this.lvTinhnang.AllColumns.Add(this.col_Buy);
    this.lvTinhnang.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
    this.lvTinhnang.CellEditUseWholeCell = false;
    this.lvTinhnang.Columns.AddRange(new ColumnHeader[5]
    {
      (ColumnHeader) this.col_Index,
      (ColumnHeader) this.col_Tinhnang,
      (ColumnHeader) this.col_Remain,
      (ColumnHeader) this.col_Comment,
      (ColumnHeader) this.col_Buy
    });
    this.lvTinhnang.Cursor = Cursors.Default;
    this.lvTinhnang.Dock = DockStyle.Bottom;
    this.lvTinhnang.ForeColor = Color.FromArgb(32 /*0x20*/, 32 /*0x20*/, 32 /*0x20*/);
    this.lvTinhnang.FullRowSelect = true;
    this.lvTinhnang.Location = new Point(2, 80 /*0x50*/);
    this.lvTinhnang.Margin = new Padding(2);
    this.lvTinhnang.Name = "lvTinhnang";
    this.lvTinhnang.Size = new Size(349, 104);
    this.lvTinhnang.TabIndex = 8;
    this.lvTinhnang.UseCompatibleStateImageBehavior = false;
    this.lvTinhnang.View = View.Details;
    this.col_Index.AspectName = "Index";
    this.col_Index.Groupable = false;
    this.col_Index.HeaderCheckBoxUpdatesRowCheckBoxes = false;
    this.col_Index.Hideable = false;
    this.col_Index.IsEditable = false;
    this.col_Index.Sortable = false;
    this.col_Index.Text = "#";
    this.col_Index.Width = 25;
    this.col_Tinhnang.AspectName = "Tinhnang";
    this.col_Tinhnang.Groupable = false;
    this.col_Tinhnang.HeaderCheckBoxUpdatesRowCheckBoxes = false;
    this.col_Tinhnang.Hideable = false;
    this.col_Tinhnang.IsEditable = false;
    this.col_Tinhnang.Sortable = false;
    this.col_Tinhnang.Text = "Tính năng";
    this.col_Tinhnang.Width = 65;
    this.col_Remain.AspectName = "Remain";
    this.col_Remain.Groupable = false;
    this.col_Remain.HeaderCheckBoxUpdatesRowCheckBoxes = false;
    this.col_Remain.Hideable = false;
    this.col_Remain.IsEditable = false;
    this.col_Remain.Sortable = false;
    this.col_Remain.Text = "Sử dụng";
    this.col_Comment.AspectName = "Comment";
    this.col_Comment.FillsFreeSpace = true;
    this.col_Comment.Groupable = false;
    this.col_Comment.HeaderCheckBoxUpdatesRowCheckBoxes = false;
    this.col_Comment.Hideable = false;
    this.col_Comment.IsEditable = false;
    this.col_Comment.Sortable = false;
    this.col_Comment.Text = "Ghi chú";
    this.col_Comment.Width = 120;
    this.col_Buy.Groupable = false;
    this.col_Buy.HeaderCheckBoxUpdatesRowCheckBoxes = false;
    this.col_Buy.Hideable = false;
    this.col_Buy.IsEditable = false;
    this.col_Buy.Sortable = false;
    this.col_Buy.Text = "";
    this.col_Buy.Width = 40;
    this.lbGGKM.AutoSize = true;
    this.lbGGKM.Location = new Point(240 /*0xF0*/, 40);
    this.lbGGKM.Margin = new Padding(2, 0, 2, 0);
    this.lbGGKM.Name = "lbGGKM";
    this.lbGGKM.Size = new Size(25, 13);
    this.lbGGKM.TabIndex = 7;
    this.lbGGKM.Text = "___";
    this.lbGGNap.AutoSize = true;
    this.lbGGNap.Location = new Point(59, 40);
    this.lbGGNap.Margin = new Padding(2, 0, 2, 0);
    this.lbGGNap.Name = "lbGGNap";
    this.lbGGNap.Size = new Size(25, 13);
    this.lbGGNap.TabIndex = 6;
    this.lbGGNap.Text = "___";
    this.lbHandung.AutoSize = true;
    this.lbHandung.Location = new Point(215, 20);
    this.lbHandung.Margin = new Padding(2, 0, 2, 0);
    this.lbHandung.Name = "lbHandung";
    this.lbHandung.Size = new Size(25, 13);
    this.lbHandung.TabIndex = 5;
    this.lbHandung.Text = "___";
    this.lbUsername.AutoSize = true;
    this.lbUsername.Location = new Point(59, 20);
    this.lbUsername.Margin = new Padding(2, 0, 2, 0);
    this.lbUsername.Name = "lbUsername";
    this.lbUsername.Size = new Size(25, 13);
    this.lbUsername.TabIndex = 4;
    this.lbUsername.Text = "___";
    this.label4.AutoSize = true;
    this.label4.Location = new Point(162, 40);
    this.label4.Margin = new Padding(2, 0, 2, 0);
    this.label4.Name = "label4";
    this.label4.Size = new Size(80 /*0x50*/, 13);
    this.label4.TabIndex = 3;
    this.label4.Text = "GG khuyến mãi";
    this.label3.AutoSize = true;
    this.label3.Location = new Point(6, 40);
    this.label3.Margin = new Padding(2, 0, 2, 0);
    this.label3.Name = "label3";
    this.label3.Size = new Size(44, 13);
    this.label3.TabIndex = 2;
    this.label3.Text = "GG nạp";
    this.label2.AutoSize = true;
    this.label2.Location = new Point(162, 20);
    this.label2.Margin = new Padding(2, 0, 2, 0);
    this.label2.Name = "label2";
    this.label2.Size = new Size(54, 13);
    this.label2.TabIndex = 1;
    this.label2.Text = "Hạn dùng";
    this.label1.AutoSize = true;
    this.label1.Location = new Point(6, 20);
    this.label1.Margin = new Padding(2, 0, 2, 0);
    this.label1.Name = "label1";
    this.label1.Size = new Size(55, 13);
    this.label1.TabIndex = 0;
    this.label1.Text = "Tài khoản";
    this.groupBox2.Controls.Add((Control) this.lblTotalPrice);
    this.groupBox2.Controls.Add((Control) this.label10);
    this.groupBox2.Controls.Add((Control) this.btnMuaNgay);
    this.groupBox2.Controls.Add((Control) this.lvBuyLic);
    this.groupBox2.Controls.Add((Control) this.cboBuyTrader);
    this.groupBox2.Controls.Add((Control) this.label8);
    this.groupBox2.Controls.Add((Control) this.cboBuyYTO);
    this.groupBox2.Controls.Add((Control) this.label9);
    this.groupBox2.Controls.Add((Control) this.cboBuyChedo);
    this.groupBox2.Controls.Add((Control) this.label7);
    this.groupBox2.Controls.Add((Control) this.cboBuyTime);
    this.groupBox2.Controls.Add((Control) this.label6);
    this.groupBox2.Dock = DockStyle.Top;
    this.groupBox2.Location = new Point(0, 186);
    this.groupBox2.Margin = new Padding(2);
    this.groupBox2.Name = "groupBox2";
    this.groupBox2.Padding = new Padding(2);
    this.groupBox2.Size = new Size(353, 205);
    this.groupBox2.TabIndex = 1;
    this.groupBox2.TabStop = false;
    this.groupBox2.Text = "Mua giờ + tính năng";
    this.groupBox2.Enter += new EventHandler(this.groupBox2_Enter);
    this.lblTotalPrice.AutoSize = true;
    this.lblTotalPrice.Location = new Point(59, 73);
    this.lblTotalPrice.Margin = new Padding(2, 0, 2, 0);
    this.lblTotalPrice.Name = "lblTotalPrice";
    this.lblTotalPrice.Size = new Size(25, 13);
    this.lblTotalPrice.TabIndex = 76;
    this.lblTotalPrice.Text = "___";
    this.label10.AutoSize = true;
    this.label10.Location = new Point(6, 73);
    this.label10.Margin = new Padding(2, 0, 2, 0);
    this.label10.Name = "label10";
    this.label10.Size = new Size(52, 13);
    this.label10.TabIndex = 75;
    this.label10.Text = "Tổng giá:";
    this.btnMuaNgay.BackColor = Color.FromArgb((int) byte.MaxValue, 224 /*0xE0*/, 192 /*0xC0*/);
    this.btnMuaNgay.ForeColor = Color.Black;
    this.btnMuaNgay.Location = new Point(220, 69);
    this.btnMuaNgay.Name = "btnMuaNgay";
    this.btnMuaNgay.Size = new Size(120, 20);
    this.btnMuaNgay.TabIndex = 74;
    this.btnMuaNgay.Text = "&Thanh toán đơn hàng";
    this.btnMuaNgay.UseVisualStyleBackColor = false;
    this.lvBuyLic.AllColumns.Add(this.colLic_Index);
    this.lvBuyLic.AllColumns.Add(this.col_ItemName);
    this.lvBuyLic.AllColumns.Add(this.colLic_Comment);
    this.lvBuyLic.AllColumns.Add(this.colLic_Price);
    this.lvBuyLic.AllColumns.Add(this.colLic_SlotID);
    this.lvBuyLic.AllColumns.Add(this.colLic_Remove);
    this.lvBuyLic.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
    this.lvBuyLic.CellEditUseWholeCell = false;
    this.lvBuyLic.Columns.AddRange(new ColumnHeader[6]
    {
      (ColumnHeader) this.colLic_Index,
      (ColumnHeader) this.col_ItemName,
      (ColumnHeader) this.colLic_Comment,
      (ColumnHeader) this.colLic_Price,
      (ColumnHeader) this.colLic_SlotID,
      (ColumnHeader) this.colLic_Remove
    });
    this.lvBuyLic.Cursor = Cursors.Default;
    this.lvBuyLic.Dock = DockStyle.Bottom;
    this.lvBuyLic.ForeColor = Color.FromArgb(32 /*0x20*/, 32 /*0x20*/, 32 /*0x20*/);
    this.lvBuyLic.FullRowSelect = true;
    this.lvBuyLic.Location = new Point(2, 92);
    this.lvBuyLic.Margin = new Padding(2);
    this.lvBuyLic.Name = "lvBuyLic";
    this.lvBuyLic.Size = new Size(349, 111);
    this.lvBuyLic.TabIndex = 9;
    this.lvBuyLic.UseCompatibleStateImageBehavior = false;
    this.lvBuyLic.View = View.Details;
    this.colLic_Index.AspectName = "Index";
    this.colLic_Index.Groupable = false;
    this.colLic_Index.HeaderCheckBoxUpdatesRowCheckBoxes = false;
    this.colLic_Index.Hideable = false;
    this.colLic_Index.IsEditable = false;
    this.colLic_Index.Sortable = false;
    this.colLic_Index.Text = "#";
    this.colLic_Index.Width = 25;
    this.col_ItemName.AspectName = "Desc";
    this.col_ItemName.Groupable = false;
    this.col_ItemName.HeaderCheckBoxUpdatesRowCheckBoxes = false;
    this.col_ItemName.Hideable = false;
    this.col_ItemName.IsEditable = false;
    this.col_ItemName.Sortable = false;
    this.col_ItemName.Text = "Món hàng";
    this.col_ItemName.Width = 100;
    this.colLic_Comment.AspectName = "Comment";
    this.colLic_Comment.FillsFreeSpace = true;
    this.colLic_Comment.Groupable = false;
    this.colLic_Comment.HeaderCheckBoxUpdatesRowCheckBoxes = false;
    this.colLic_Comment.Hideable = false;
    this.colLic_Comment.IsEditable = false;
    this.colLic_Comment.Sortable = false;
    this.colLic_Comment.Text = "Ghi chú";
    this.colLic_Price.AspectName = "Price";
    this.colLic_Price.Groupable = false;
    this.colLic_Price.HeaderCheckBoxUpdatesRowCheckBoxes = false;
    this.colLic_Price.Hideable = false;
    this.colLic_Price.IsEditable = false;
    this.colLic_Price.Sortable = false;
    this.colLic_Price.Text = "Giá";
    this.colLic_Price.TextAlign = HorizontalAlignment.Right;
    this.colLic_Price.Width = 40;
    this.colLic_SlotID.AspectName = "SlotID";
    this.colLic_SlotID.Text = "Slot ID";
    this.colLic_Remove.AspectName = "";
    this.colLic_Remove.Groupable = false;
    this.colLic_Remove.HeaderCheckBoxUpdatesRowCheckBoxes = false;
    this.colLic_Remove.Hideable = false;
    this.colLic_Remove.IsEditable = false;
    this.colLic_Remove.Sortable = false;
    this.colLic_Remove.Text = "X";
    this.colLic_Remove.Width = 24;
    this.cboBuyTrader.DropDownWidth = 250;
    this.cboBuyTrader.FormattingEnabled = true;
    this.cboBuyTrader.Location = new Point(233, 46);
    this.cboBuyTrader.Margin = new Padding(2);
    this.cboBuyTrader.Name = "cboBuyTrader";
    this.cboBuyTrader.Size = new Size(109, 21);
    this.cboBuyTrader.TabIndex = 8;
    this.cboBuyTrader.SelectedIndexChanged += new EventHandler(this.cboBuyTrader_SelectedIndexChanged);
    this.label8.AutoSize = true;
    this.label8.Location = new Point(164, 48 /*0x30*/);
    this.label8.Margin = new Padding(2, 0, 2, 0);
    this.label8.Name = "label8";
    this.label8.Size = new Size(71, 13);
    this.label8.TabIndex = 7;
    this.label8.Text = "Thương nhân";
    this.cboBuyYTO.DropDownWidth = 250;
    this.cboBuyYTO.FormattingEnabled = true;
    this.cboBuyYTO.Location = new Point(52, 46);
    this.cboBuyYTO.Margin = new Padding(2);
    this.cboBuyYTO.Name = "cboBuyYTO";
    this.cboBuyYTO.Size = new Size(109, 21);
    this.cboBuyYTO.TabIndex = 6;
    this.cboBuyYTO.DropDown += new EventHandler(this.cboBuyYTO_DropDown);
    this.cboBuyYTO.SelectedIndexChanged += new EventHandler(this.cboBuyYTO_SelectedIndexChanged);
    this.label9.AutoSize = true;
    this.label9.Location = new Point(6, 48 /*0x30*/);
    this.label9.Margin = new Padding(2, 0, 2, 0);
    this.label9.Name = "label9";
    this.label9.Size = new Size(29, 13);
    this.label9.TabIndex = 5;
    this.label9.Text = "YTO";
    this.cboBuyChedo.DropDownWidth = 250;
    this.cboBuyChedo.FormattingEnabled = true;
    this.cboBuyChedo.Location = new Point(233, 26);
    this.cboBuyChedo.Margin = new Padding(2);
    this.cboBuyChedo.Name = "cboBuyChedo";
    this.cboBuyChedo.Size = new Size(109, 21);
    this.cboBuyChedo.TabIndex = 4;
    this.cboBuyChedo.DropDown += new EventHandler(this.cboBuyChedo_DropDown);
    this.cboBuyChedo.SelectedIndexChanged += new EventHandler(this.cboBuyChedo_SelectedIndexChanged);
    this.label7.AutoSize = true;
    this.label7.Location = new Point(164, 27);
    this.label7.Margin = new Padding(2, 0, 2, 0);
    this.label7.Name = "label7";
    this.label7.Size = new Size(42, 13);
    this.label7.TabIndex = 3;
    this.label7.Text = "Chế đồ";
    this.label7.Click += new EventHandler(this.label7_Click);
    this.cboBuyTime.DropDownWidth = 250;
    this.cboBuyTime.FormattingEnabled = true;
    this.cboBuyTime.Location = new Point(52, 26);
    this.cboBuyTime.Margin = new Padding(2);
    this.cboBuyTime.Name = "cboBuyTime";
    this.cboBuyTime.Size = new Size(109, 21);
    this.cboBuyTime.TabIndex = 2;
    this.cboBuyTime.DropDown += new EventHandler(this.cboBuyTime_DropDown);
    this.cboBuyTime.SelectedIndexChanged += new EventHandler(this.cboBuyTime_SelectedIndexChanged);
    this.label6.AutoSize = true;
    this.label6.Location = new Point(6, 27);
    this.label6.Margin = new Padding(2, 0, 2, 0);
    this.label6.Name = "label6";
    this.label6.Size = new Size(46, 13);
    this.label6.TabIndex = 1;
    this.label6.Text = "Giờ chơi";
    this.label6.Click += new EventHandler(this.label6_Click);
    this.groupBox3.Controls.Add((Control) this.btnRefresh);
    this.groupBox3.Controls.Add((Control) this.lvHistory);
    this.groupBox3.Dock = DockStyle.Fill;
    this.groupBox3.Location = new Point(0, 391);
    this.groupBox3.Name = "groupBox3";
    this.groupBox3.Padding = new Padding(2);
    this.groupBox3.Size = new Size(353, 130);
    this.groupBox3.TabIndex = 2;
    this.groupBox3.TabStop = false;
    this.groupBox3.Text = "Lịch sử hoạt động 10 ngày";
    this.btnRefresh.BackColor = Color.White;
    this.btnRefresh.FlatStyle = FlatStyle.Flat;
    this.btnRefresh.ForeColor = Color.White;
    this.btnRefresh.Image = (Image) Resources.refresh;
    this.btnRefresh.ImeMode = ImeMode.NoControl;
    this.btnRefresh.Location = new Point(312, -1);
    this.btnRefresh.Name = "btnRefresh";
    this.btnRefresh.Size = new Size(24, 20);
    this.btnRefresh.TabIndex = 70;
    this.btnRefresh.UseVisualStyleBackColor = false;
    this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);
    this.lvHistory.AllColumns.Add(this.colHist_Index);
    this.lvHistory.AllColumns.Add(this.colHist_ActTime);
    this.lvHistory.AllColumns.Add(this.colHist_Activity);
    this.lvHistory.AllColumns.Add(this.colHist_Cost);
    this.lvHistory.AllColumns.Add(this.colHist_Remain);
    this.lvHistory.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
    this.lvHistory.CellEditUseWholeCell = false;
    this.lvHistory.Columns.AddRange(new ColumnHeader[5]
    {
      (ColumnHeader) this.colHist_Index,
      (ColumnHeader) this.colHist_ActTime,
      (ColumnHeader) this.colHist_Activity,
      (ColumnHeader) this.colHist_Cost,
      (ColumnHeader) this.colHist_Remain
    });
    this.lvHistory.Cursor = Cursors.Default;
    this.lvHistory.Dock = DockStyle.Bottom;
    this.lvHistory.ForeColor = Color.FromArgb(32 /*0x20*/, 32 /*0x20*/, 32 /*0x20*/);
    this.lvHistory.FullRowSelect = true;
    this.lvHistory.Location = new Point(2, 33);
    this.lvHistory.Margin = new Padding(2);
    this.lvHistory.Name = "lvHistory";
    this.lvHistory.Size = new Size(349, 95);
    this.lvHistory.TabIndex = 10;
    this.lvHistory.UseCompatibleStateImageBehavior = false;
    this.lvHistory.View = View.Details;
    this.colHist_Index.AspectName = "Index";
    this.colHist_Index.Groupable = false;
    this.colHist_Index.HeaderCheckBoxUpdatesRowCheckBoxes = false;
    this.colHist_Index.Hideable = false;
    this.colHist_Index.IsEditable = false;
    this.colHist_Index.Sortable = false;
    this.colHist_Index.Text = "#";
    this.colHist_Index.Width = 25;
    this.colHist_ActTime.AspectName = "ActDate";
    this.colHist_ActTime.Groupable = false;
    this.colHist_ActTime.HeaderCheckBoxUpdatesRowCheckBoxes = false;
    this.colHist_ActTime.Hideable = false;
    this.colHist_ActTime.IsEditable = false;
    this.colHist_ActTime.Sortable = false;
    this.colHist_ActTime.Text = "Thời gian";
    this.colHist_ActTime.Width = 110;
    this.colHist_Activity.AspectName = "Comment";
    this.colHist_Activity.FillsFreeSpace = true;
    this.colHist_Activity.Groupable = false;
    this.colHist_Activity.HeaderCheckBoxUpdatesRowCheckBoxes = false;
    this.colHist_Activity.Hideable = false;
    this.colHist_Activity.IsEditable = false;
    this.colHist_Activity.Sortable = false;
    this.colHist_Activity.Text = "Hoạt động";
    this.colHist_Activity.Width = 90;
    this.colHist_Cost.AspectName = "Cost";
    this.colHist_Cost.Groupable = false;
    this.colHist_Cost.HeaderCheckBoxUpdatesRowCheckBoxes = false;
    this.colHist_Cost.Hideable = false;
    this.colHist_Cost.IsEditable = false;
    this.colHist_Cost.Sortable = false;
    this.colHist_Cost.Text = "Tốn";
    this.colHist_Cost.Width = 40;
    this.colHist_Remain.AspectName = "Balance";
    this.colHist_Remain.Groupable = false;
    this.colHist_Remain.HeaderCheckBoxUpdatesRowCheckBoxes = false;
    this.colHist_Remain.Hideable = false;
    this.colHist_Remain.IsEditable = false;
    this.colHist_Remain.Sortable = false;
    this.colHist_Remain.Text = "Còn";
    this.statusStrip1.ImageScalingSize = new Size(32 /*0x20*/, 32 /*0x20*/);
    this.statusStrip1.Items.AddRange(new ToolStripItem[1]
    {
      (ToolStripItem) this.status1
    });
    this.statusStrip1.Location = new Point(0, 521);
    this.statusStrip1.Name = "statusStrip1";
    this.statusStrip1.Padding = new Padding(0, 0, 7, 0);
    this.statusStrip1.Size = new Size(353, 22);
    this.statusStrip1.TabIndex = 3;
    this.statusStrip1.Text = "statusStrip1";
    this.status1.Name = "status1";
    this.status1.Size = new Size(61, 17);
    this.status1.Text = "Trạng thái";
    this.backgroundWorker1.DoWork += new DoWorkEventHandler(this.backgroundWorker1_DoWork);
    this.backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
    this.AutoScaleDimensions = new SizeF(96f, 96f);
    this.AutoScaleMode = AutoScaleMode.Dpi;
    this.ClientSize = new Size(353, 543);
    this.Controls.Add((Control) this.groupBox3);
    this.Controls.Add((Control) this.statusStrip1);
    this.Controls.Add((Control) this.groupBox2);
    this.Controls.Add((Control) this.groupBox1);
    this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
    this.Margin = new Padding(2);
    this.MaximizeBox = false;
    this.MaximumSize = new Size(359, 567);
    this.MinimumSize = new Size(359, 567);
    this.Name = nameof (frmNewUserInfo);
    this.Text = "Thông tin tài khoản";
    this.Load += new EventHandler(this.frmNewUserInfo_Load);
    this.groupBox1.ResumeLayout(false);
    this.groupBox1.PerformLayout();
    ((ISupportInitialize) this.lvTinhnang).EndInit();
    this.groupBox2.ResumeLayout(false);
    this.groupBox2.PerformLayout();
    ((ISupportInitialize) this.lvBuyLic).EndInit();
    this.groupBox3.ResumeLayout(false);
    ((ISupportInitialize) this.lvHistory).EndInit();
    this.statusStrip1.ResumeLayout(false);
    this.statusStrip1.PerformLayout();
    this.ResumeLayout(false);
    this.PerformLayout();
  }
}
