// Decompiled with JetBrains decompiler
// Type: SmartBot.frmLiteBuy
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
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace SmartBot;

public class frmLiteBuy : Form
{
  private long statusStamp;
  private static int startX = 20;
  private static int startY = 20;
  private int diffX = 150;
  private int diffY = 20;
  private bool left = true;
  private int curX = frmLiteBuy.startX;
  private int curY = frmLiteBuy.startY;
  private List<PriceItem> _priceList = new List<PriceItem>();
  public List<PriceItem> lastPrices = new List<PriceItem>();
  public double totalPrice;
  private bool autoExtend;
  private List<RadioButton> allRadios = new List<RadioButton>();
  private long lastHistoryClick;
  public bool flagGroupLicExpanded = true;
  private int savedGroupLicenseHeight;
  private long stampExtend;
  private double cpPercent;
  private double cpminPrice;
  private IContainer components;
  private Panel pnelTitle;
  private Label lbTitle;
  private StatusStrip statusStrip1;
  private ToolStripStatusLabel stripStatus;
  private System.Windows.Forms.Timer timer1;
  private ToolStripStatusLabel toolStripStatusLabel1;
  private ToolStripStatusLabel stripTotal;
  private Label label1;
  private Label lbUsername;
  private Label lbGG;
  private Label label3;
  private Label lbGGPromo;
  private Label label5;
  private Panel pnelBalance;
  private Panel pnelUsage;
  private Label lbHanDung;
  private Label label4;
  private Panel pnelTinhNang;
  private Label label8;
  private OLVColumn col_Tinhnang;
  private OLVColumn col_Remain;
  private OLVColumn col_Comment;
  private OLVColumn col_Buy;
  private Button btnRefresh;
  private OLVColumn colHist_Index;
  private OLVColumn colHist_ActTime;
  private OLVColumn colHist_Activity;
  private OLVColumn colHist_Cost;
  private OLVColumn colHist_Remain;
  private Label label2;
  private Panel pnelMuaGio;
  private GroupBox groupLicenses;
  public ObjectListView lvTinhnang;
  public ObjectListView lvHistory;
  private BackgroundWorker backgroundWorker1;
  private Button btnPackageExpand;
  private Panel pnelButtons;
  private Button btnClose;
  public Button btnBuyHour;
  private Panel pnelMuaGioTitle;
  private Label label6;
  private OLVColumn col_GiaHan;
  private Button btnCoupon;
  private Label label13;
  private TextBox txtCoupon;
  private Label lbCoupon;

  public frmLiteBuy(bool extend = false)
  {
    this.InitializeComponent();
    this.autoExtend = extend;
    this.lbUsername.DataBindings.Clear();
    this.lbUsername.DataBindings.Add("Text", (object) frmLogin.GAuto.Settings.Account, "Username");
    this.lbGG.DataBindings.Clear();
    this.lbGG.DataBindings.Add("Text", (object) frmLogin.GAuto.Settings.Account, "RemainGGDisplay");
    this.lbGGPromo.DataBindings.Clear();
    this.lbGGPromo.DataBindings.Add("Text", (object) frmLogin.GAuto.Settings.Account, "RemainGGPromoDisplay");
    this.lbHanDung.DataBindings.Clear();
    this.lbHanDung.DataBindings.Add("Text", (object) frmLogin.GAuto.Settings.Account, "Shorthandung");
    this.DisplayPrice();
    this.MinimumSize = new Size(this.Width, 300);
  }

  private void ColExpGUI(bool flagThugon) => this.ExpLicenseGroup(flagThugon);

  public void ExpLicenseGroup(bool flagThugon)
  {
    if (this.flagGroupLicExpanded == flagThugon && flagThugon)
    {
      this.flagGroupLicExpanded = !this.flagGroupLicExpanded;
      this.pnelMuaGio.Visible = !flagThugon;
      this.Height -= this.savedGroupLicenseHeight;
      this.btnPackageExpand.Image = (Image) Resources.expand;
    }
    else
    {
      if (this.flagGroupLicExpanded != flagThugon || flagThugon)
        return;
      this.flagGroupLicExpanded = !this.flagGroupLicExpanded;
      this.pnelMuaGio.Visible = !flagThugon;
      this.Height += this.savedGroupLicenseHeight;
      this.btnPackageExpand.Image = (Image) Resources.collapse;
    }
  }

  private void DisplayPrice()
  {
    List<string> stringList1 = new List<string>();
    List<string> stringList2 = new List<string>();
    List<string> stringList3 = new List<string>();
    List<string> stringList4 = new List<string>();
    List<string> stringList5 = new List<string>();
    for (int index = 0; index < frmLogin.GAuto.Settings.Account.BangGia.Count; ++index)
    {
      PriceItem priceItem = frmLogin.GAuto.Settings.Account.BangGia[index];
      if (priceItem.Key == "time")
        stringList1.Add(priceItem.ItemDisplay);
      else if (priceItem.Key == "tnchedo")
        stringList2.Add(priceItem.ItemDisplay);
      else if (priceItem.Key == "tnyto")
        stringList4.Add(priceItem.ItemDisplay);
      else if (priceItem.Key == "tnq12")
        stringList5.Add(priceItem.ItemDisplay);
      else
        stringList3.Add(priceItem.ItemDisplay);
    }
    if (stringList1.Count <= 0)
      return;
    if (this.allRadios.Count > 0)
    {
      for (int index = 0; index < this.allRadios.Count; ++index)
      {
        this.allRadios[index].Visible = false;
        this.allRadios[index].Dispose();
      }
      this.allRadios.Clear();
    }
    for (int index = 0; index < stringList1.Count; ++index)
      this.DrawRadio(stringList1[index]);
    GroupBox parent1 = new GroupBox();
    parent1.Left = 0;
    parent1.Top = this.curY;
    parent1.Width = this.groupLicenses.Width;
    parent1.Height = stringList2.Count * 25 + 10;
    parent1.Text = "Mua giờ chế đồ";
    this.curX = frmLiteBuy.startX;
    this.curY = frmLiteBuy.startY;
    this.groupLicenses.Controls.Add((Control) parent1);
    for (int index = 0; index < stringList2.Count; ++index)
      this.DrawRadio(stringList2[index], true, parent: (Control) parent1);
    GroupBox parent2 = new GroupBox();
    parent2.Left = 0;
    parent2.Top = parent1.Top + parent1.Height + 5;
    parent2.Width = this.groupLicenses.Width;
    parent2.Height = stringList4.Count * 25 + 15;
    parent2.Text = "Mua giờ Yến Tử Ổ + Q12";
    this.curX = frmLiteBuy.startX;
    this.curY = frmLiteBuy.startY;
    this.groupLicenses.Controls.Add((Control) parent2);
    for (int index = 0; index < stringList4.Count; ++index)
      this.DrawRadio(stringList4[index], true, parent: (Control) parent2);
    this.curY = frmLiteBuy.startY;
    for (int index = 0; index < stringList5.Count; ++index)
      this.DrawRadio(stringList5[index], true, true, (Control) parent2);
  }

  private void DrawRadio(string text, bool singleRow = false, bool rightAlign = false, Control parent = null)
  {
    RadioButton radioButton = new RadioButton();
    radioButton.Click += new EventHandler(this.rdio_Click);
    radioButton.CheckedChanged += new EventHandler(this.rdio_CheckedChanged);
    radioButton.Text = text;
    if (!singleRow)
    {
      radioButton.Left = this.curX;
    }
    else
    {
      if (!rightAlign)
        radioButton.Left = frmLiteBuy.startX;
      else
        radioButton.Left = frmLiteBuy.startX + this.diffX;
      if (!this.left)
        this.curY += this.diffY;
      this.left = true;
    }
    radioButton.Top = this.curY;
    radioButton.Width = 150;
    radioButton.AutoSize = true;
    if (parent == null)
      this.groupLicenses.Controls.Add((Control) radioButton);
    else
      parent.Controls.Add((Control) radioButton);
    if (!singleRow)
    {
      if (this.left)
      {
        this.left = false;
        this.curX += this.diffX;
      }
      else
      {
        this.left = true;
        this.curY += this.diffY;
        this.curX = frmLiteBuy.startX;
      }
    }
    else
      this.curY += this.diffY;
    this.allRadios.Add(radioButton);
  }

  private void rdio_CheckedChanged(object sender, EventArgs e)
  {
    RadioButton radioButton = sender as RadioButton;
    if (radioButton.Checked)
    {
      if (frmLogin.GAuto.Settings.Account.BangGia.Count <= 0)
        return;
      for (int index = frmLogin.GAuto.Settings.Account.BangGia.Count - 1; index >= 0; --index)
      {
        if (frmLogin.GAuto.Settings.Account.BangGia[index].ItemDisplay == radioButton.Text && frmLogin.GAuto.Settings.Account.BangGia[index].Price >= 500.0)
        {
          radioButton.ForeColor = Color.DarkGreen;
          radioButton.Checked = false;
          string str = frmLogin.GAuto.Settings.Account.BangGia[index].ItemDisplay;
          if (str == "Vĩnh viễn -- 0 GG")
            str = "Vĩnh viễn -- 1.200.000 VNĐ";
          GA.ShowMessage($"Để mua gói '{str}', vui lòng liên hệ Jelly Nguyen facebook (http://fb.co/jelly.nguyen.121) để được hướng dẫn", "Chuyển khoản", 120000);
        }
      }
    }
    else
    {
      if (radioButton.ForeColor == Color.DarkGreen)
        radioButton.ForeColor = Color.Black;
      if (this._priceList.Count <= 0)
        return;
      for (int index = this._priceList.Count - 1; index >= 0; --index)
      {
        if (this._priceList[index].ItemDisplay == radioButton.Text)
        {
          this._priceList.RemoveAt(index);
          break;
        }
      }
    }
  }

  private void rdio_Click(object sender, EventArgs e)
  {
    RadioButton radioButton = sender as RadioButton;
    if (radioButton.Checked && frmLogin.GAuto.Settings.Account.BangGia.Count > 0)
    {
      for (int index1 = 0; index1 < frmLogin.GAuto.Settings.Account.BangGia.Count; ++index1)
      {
        if (frmLogin.GAuto.Settings.Account.BangGia[index1].ItemDisplay == radioButton.Text)
        {
          bool flag = false;
          if (this._priceList.Count > 0)
          {
            for (int index2 = this._priceList.Count - 1; index2 >= 0; --index2)
            {
              if (this._priceList[index2].Key == frmLogin.GAuto.Settings.Account.BangGia[index1].Key)
              {
                if (this._priceList[index2].ItemDisplay == frmLogin.GAuto.Settings.Account.BangGia[index1].ItemDisplay)
                {
                  this._priceList.RemoveAt(index2);
                  radioButton.Checked = false;
                  flag = true;
                  break;
                }
                this._priceList[index2] = frmLogin.GAuto.Settings.Account.BangGia[index1];
                flag = true;
                break;
              }
            }
          }
          if (!flag)
          {
            this._priceList.Add(frmLogin.GAuto.Settings.Account.BangGia[index1]);
            break;
          }
          break;
        }
      }
    }
    this.totalPrice = frmLiteBuy.CalcBuyPrice(this._priceList);
    if (this.totalPrice > frmLogin.GAuto.Settings.Account.TotalBalance)
      this.SetStatus("Không đủ GG để mua.", Color.Red);
    else
      this.stripStatus.Text = "";
  }

  public static double CalcBuyPrice(List<PriceItem> _priceList)
  {
    if (_priceList == null || _priceList.Count <= 0)
      return 0.0;
    double num = 0.0;
    try
    {
      for (int index = _priceList.Count - 1; index >= 0; --index)
        num += _priceList[index].Price;
    }
    catch (Exception ex)
    {
    }
    return num;
  }

  private void timer1_Tick(object sender, EventArgs e)
  {
    if (this.lvTinhnang.Items.Count != frmLogin.GAuto.Settings.Account.MyLicense.ListTinhNang.Count)
      this.lvTinhnang.SetObjects((IEnumerable) frmLogin.GAuto.Settings.Account.MyLicense.ListTinhNang);
    if (this.statusStamp > 0L && frmLogin.GlobalTimer.ElapsedMilliseconds > this.statusStamp)
    {
      this.stripStatus.Text = "";
      this.statusStamp = 0L;
    }
    string str = $"Sẽ tốn {this.totalPrice.ToString():n1} GG";
    if (str.Contains(".0"))
      str = $"Sẽ tốn {this.totalPrice.ToString("0")} GG";
    if (this.totalPrice > frmLogin.GAuto.Settings.Account.TotalBalance)
    {
      str = "(Không đủ GG) " + str;
      if (this.stripTotal.ForeColor != Color.Red)
        this.stripTotal.ForeColor = Color.Red;
    }
    else if (this.stripTotal.ForeColor == Color.Red)
      this.stripTotal.ForeColor = Color.DarkGreen;
    this.stripTotal.Text = str;
  }

  private void SetStatus(string text, Color color, int delay = 5000)
  {
    this.btnBuyHour.Invoke((Delegate) (() =>
    {
      this.stripStatus.Text = text;
      this.stripStatus.ForeColor = color;
      this.statusStamp = frmLogin.GlobalTimer.ElapsedMilliseconds + (long) delay;
    }));
  }

  private void frmLiteBuy_Load(object sender, EventArgs e)
  {
    this.col_Buy.AspectGetter = (AspectGetterDelegate) (nv => (object) true);
    this.col_Buy.Renderer = (IRenderer) new MappedImageRenderer(new object[2]
    {
      (object) true,
      (object) Resources.add
    });
  }

  private void btnThoatAuto_Click(object sender, EventArgs e)
  {
    this.ClearBuyData();
    this.Hide();
  }

  private void ClearBuyData()
  {
    if (this.allRadios.Count > 0)
    {
      for (int index = 0; index < this.allRadios.Count; ++index)
        this.allRadios[index].Checked = false;
    }
    if (this._priceList.Count <= 0)
      return;
    this._priceList.Clear();
  }

  private void btnBuyHour_Click(object sender, EventArgs e)
  {
    if (this._priceList.Count > 0)
    {
      double num1 = frmLiteBuy.CalcBuyPrice(this._priceList);
      bool flag1;
      if (num1 <= frmLogin.GAuto.Settings.Account.TotalBalance)
      {
        string str1 = num1.ToString("0.0").Replace(".0", "") + frmLogin.GGUnit;
        string str2 = "";
        PriceItem priceItem = (PriceItem) null;
        foreach (PriceItem price in this._priceList)
        {
          str2 = $"{str2}+ {price.ItemDisplay}\n";
          if (price.Key == "time" && priceItem == null)
            priceItem = price;
        }
        if (this.cpPercent <= 0.0 && !string.IsNullOrEmpty(this.txtCoupon.Text))
        {
          GA.ShowMessage("Bạn phải bấm nút refresh lấy thông tin mã khuyến mãi trước.\nNếu mã không đúng phải bỏ ra trước khi thanh toán.", "Cần thông tin mã KM", 30000);
          return;
        }
        if (this.cpPercent > 0.0 && priceItem != null)
        {
          if (this.cpminPrice > 0.0 && this.cpminPrice / frmLogin.GGUnitDivision > priceItem.Price)
          {
            GA.ShowMessage("Mã khuyến mãi chỉ áp dụng cho gói giờ mệnh giá nhỏ nhất {0} GG.", "Mã khuyến mãi lỗi", 60000, (object) (this.cpminPrice / frmLogin.GGUnitDivision).ToString("0.0").Replace(".0", ""));
            return;
          }
          int num2 = (int) Math.Round((double) (priceItem.Slot * 24) * this.cpPercent);
          string str3 = num2.ToString() + " giờ";
          if (num2 >= 72)
            str3 = ((int) Math.Round((double) num2 / 24.0)).ToString("0.0").Replace(".0", "") + " ngày";
          str2 = $"{str2}+ Tặng thêm {str3} (giờ chơi) ({this.txtCoupon.Text.ToUpper()})\n";
        }
        flag1 = MessageBox.Show($"Bạn sẽ tốn {str1} để mua thêm tính năng mới:\n{str2}\nBấm YES để xác nhận.\nBấm NO để hủy thao tác.", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
      }
      else
      {
        flag1 = false;
        GA.ShowMessage("Bạn không đủ GG để thanh toán.\nVui lòng nạp thêm vào tài khoản", "Không đủ");
      }
      if (!flag1)
        return;
      bool flag2 = false;
      bool flag3 = false;
      Dictionary<string, object> dictionary1 = new Dictionary<string, object>();
      Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
      List<Dictionary<string, object>> inputArr1 = new List<Dictionary<string, object>>();
      Dictionary<string, object> dictionary3 = new Dictionary<string, object>();
      List<Dictionary<string, object>> inputArr2 = new List<Dictionary<string, object>>();
      Dictionary<string, object> dictionary4 = new Dictionary<string, object>();
      List<Dictionary<string, object>> inputArr3 = new List<Dictionary<string, object>>();
      Dictionary<string, object> dictionary5 = new Dictionary<string, object>();
      List<Dictionary<string, object>> inputArr4 = new List<Dictionary<string, object>>();
      for (int index = this._priceList.Count - 1; index >= 0; --index)
      {
        if (this._priceList[index].Key == "time")
        {
          flag2 = true;
          GA.SetRequestTN(inputArr1, this._priceList[index], this._priceList[index].Key);
          if (this.cpPercent > 0.0 && inputArr1 != null && inputArr1.Count > 0)
          {
            if (inputArr1[0].ContainsKey("tcoupon"))
              inputArr1[0].Remove("tcoupon");
            inputArr1[0].Add("tcoupon", (object) this.txtCoupon.Text.ToUpper());
          }
        }
        if (this._priceList[index].Key == "tnchedo")
        {
          flag3 = true;
          GA.SetRequestTN(inputArr2, this._priceList[index], this._priceList[index].Key);
        }
        if (this._priceList[index].Key == "tnyto")
          GA.SetRequestTN(inputArr3, this._priceList[index], this._priceList[index].Key);
        if (this._priceList[index].Key == "tnq12")
          GA.SetRequestTN(inputArr4, this._priceList[index], this._priceList[index].Key);
      }
      if (inputArr1.Count > 0)
      {
        dictionary2.Add("request", (object) inputArr1);
        dictionary2.Add("count", (object) "1");
      }
      if (inputArr2.Count > 0)
      {
        dictionary3.Add("request", (object) inputArr2);
        dictionary3.Add("count", (object) inputArr2.Count);
      }
      if (inputArr3.Count > 0)
      {
        dictionary4.Add("request", (object) inputArr3);
        dictionary4.Add("count", (object) inputArr3.Count);
      }
      if (inputArr4.Count > 0)
      {
        dictionary5.Add("request", (object) inputArr4);
        dictionary5.Add("count", (object) inputArr4.Count);
      }
      if (!flag2 && !flag3 && frmLogin.firstTimeLogin)
      {
        if (frmLogin.GAuto.Settings.IsLoggedIn)
          GA.ShowMessage("Bạn phải chọn gói giờ chơi để tự động gia hạn", "Mua giờ sử dụng", 30000);
        else
          GA.ShowMessage("Tài khoản đang có GG. Bạn phải chọn gói giờ chơi để vào game.", "Mua giờ sử dụng", 30000);
      }
      if (dictionary2.Count > 0)
        dictionary1.Add("reqtime", (object) dictionary2);
      if (dictionary3.Count > 0)
        dictionary1.Add("reqtnchedo", (object) dictionary3);
      if (dictionary4.Count > 0)
        dictionary1.Add("reqtnyto", (object) dictionary4);
      if (dictionary5.Count > 0)
        dictionary1.Add("reqtnq12", (object) dictionary5);
      if (dictionary1.Count <= 0)
        return;
      long num3 = frmLogin.GlobalTimer.ElapsedMilliseconds + 5000L;
      while (frmLogin.GlobalTimer.ElapsedMilliseconds <= num3)
      {
        if (!this.backgroundWorker1.IsBusy)
        {
          this.btnBuyHour.Enabled = false;
          this.lvTinhnang.Enabled = false;
          this.backgroundWorker1.RunWorkerAsync((object) dictionary1);
          break;
        }
        Thread.Sleep(100);
      }
    }
    else
      GA.ShowMessage("Bạn phải chọn một gói giờ hoặc tính năng để mua", "Chưa chọn gói");
  }

  private void frmLiteBuy_FormClosing(object sender, FormClosingEventArgs e)
  {
    e.Cancel = true;
    this.Hide();
  }

  private void frmLiteBuy_Shown(object sender, EventArgs e)
  {
    this.lvTinhnang.SetObjects((IEnumerable) frmLogin.GAuto.Settings.Account.MyLicense.ListTinhNang);
    this.savedGroupLicenseHeight = this.pnelMuaGio.Height;
    this.ColExpGUI(!this.autoExtend);
  }

  private void lvTinhnang_CellClick(object sender, CellClickEventArgs e)
  {
    try
    {
      if (!(sender is ObjectListView objectListView) || e.Item == null || e.ColumnIndex != 4)
        return;
      if (this.stampExtend == 0L || this.stampExtend > 0L && frmLogin.GlobalTimer.ElapsedMilliseconds > this.stampExtend)
      {
        this.stampExtend = frmLogin.GlobalTimer.ElapsedMilliseconds + 5000L;
        TinhNang modelObject = (TinhNang) objectListView.GetModelObject(e.Item.Index);
        if (modelObject == null)
          return;
        PriceItem tnPrice = GA.GetTNPrice(modelObject);
        if (tnPrice != null && tnPrice.Price <= frmLogin.GAuto.Settings.Account.TotalBalance)
        {
          DialogResult dialogResult;
          if (modelObject.GiaHanTime == frmMain.lang_Select || modelObject.GiaHanTime == "")
            dialogResult = MessageBox.Show($"Bạn sẽ gia hạn '{modelObject.Comment} {modelObject.Tinhnang.ToLower()}' tốn {tnPrice.PriceDisplay} {frmLogin.GGUnit}.\nBấm YES để tiếp tục. Bấm NO để hủy.", "Gia hạn giờ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
          else
            dialogResult = MessageBox.Show($"Bạn sẽ gia hạn '{tnPrice.Desc}' tốn {tnPrice.PriceDisplay} {frmLogin.GGUnit}.\nBấm YES để tiếp tục. Bấm NO để hủy.", "Gia hạn giờ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
          if (dialogResult == DialogResult.Yes)
            this.BuyTinhNang(modelObject.TNKey, tnPrice, modelObject.SlotID);
        }
        else if (tnPrice != null && tnPrice.Price > frmLogin.GAuto.Settings.Account.TotalBalance)
          GA.ShowMessage($"Không đủ {frmLogin.GGUnit} để gia hạn thêm tính năng.\nVui lòng nạp thêm vào tài khoản và mua lại lần nữa.", "Không thể thanh toán", 60000);
        else
          GA.ShowMessage("Không tìm thấy giá của gói tính năng này.\n- {0}\nVui lòng liên hệ fanpage để được hỗ trợ.", "Không thấy giá", 60000, (object) $"{modelObject.Tinhnang} {modelObject.Comment}");
        modelObject.GiaHanTime = frmMain.lang_Select;
      }
      else
        GA.ShowMessage(frmMain.langBuyToFast, frmMain.langWarning);
    }
    catch (Exception ex)
    {
    }
  }

  public void UpdateLastPriceItem(PriceItem price)
  {
    if (this.lastPrices.Count > 0)
    {
      try
      {
        for (int index = 0; index < this.lastPrices.Count; ++index)
        {
          if (this.lastPrices[index].Key == price.Key)
          {
            this.lastPrices[index] = price;
            return;
          }
        }
      }
      catch (Exception ex)
      {
      }
    }
    this.lastPrices.Add(price);
  }

  public void AutoExtendLic(string tnkey)
  {
  }

  public void BuyTinhNang(string tnkey, PriceItem price, string tnSlotID = "", bool useForm = true)
  {
    if (tnSlotID == string.Empty)
      tnSlotID = GA.GenerateRandomName(5);
    this.UpdateLastPriceItem(price);
    List<Dictionary<string, object>> inputArr = new List<Dictionary<string, object>>();
    GA.SetRequestTN(inputArr, price, tnkey, tnSlotID);
    if (inputArr.Count <= 0)
      return;
    Dictionary<string, object> optInput = new Dictionary<string, object>();
    optInput.Add("req" + tnkey, (object) new Dictionary<string, object>()
    {
      {
        "count",
        (object) inputArr.Count
      },
      {
        "request",
        (object) inputArr
      }
    });
    if (optInput.Count <= 0)
      return;
    if (useForm)
    {
      this.btnBuyHour.Enabled = false;
      this.lvTinhnang.Enabled = false;
      long num = frmLogin.GlobalTimer.ElapsedMilliseconds + 5000L;
      while (frmLogin.GlobalTimer.ElapsedMilliseconds <= num)
      {
        if (!this.backgroundWorker1.IsBusy)
        {
          this.backgroundWorker1.RunWorkerAsync((object) optInput);
          break;
        }
        Thread.Sleep(100);
      }
    }
    else
    {
      try
      {
        GA.SecureLoginPHPv2(new LoginParams()
        {
          Username = frmLogin.GAuto.Settings.Account.Username,
          Password = frmLogin.GAuto.Settings.Account.Password,
          ShowForm = false
        }, optInput);
      }
      catch (Exception ex)
      {
      }
    }
  }

  private void lvTinhnang_ItemChecked(object sender, ItemCheckedEventArgs e)
  {
    if (!(sender is ObjectListView objectListView) || e == null || e.Item == null)
      return;
    TinhNang modelObject = (TinhNang) objectListView.GetModelObject(e.Item.Index);
    if (modelObject == null)
      return;
    modelObject.Giahan = !e.Item.Checked;
  }

  private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
  {
    if (e.Argument != null)
    {
      if (e.Argument.GetType() == typeof (Dictionary<string, object>))
      {
        try
        {
          LoginResult loginResult = GA.SecureLoginPHPv2(new LoginParams()
          {
            Username = frmLogin.GAuto.Settings.Account.Username,
            Password = frmLogin.GAuto.Settings.Account.Password,
            ShowForm = false
          }, (Dictionary<string, object>) e.Argument);
          e.Result = (object) loginResult;
        }
        catch (Exception ex)
        {
          e.Result = (object) new LoginResult()
          {
            LoginCode = 0,
            LoginData = (object) ("Lỗi khi xử lý lệnh mua. Msg: " + ex.Message)
          };
        }
      }
    }
    if (e.Argument == null || e.Argument.GetType() != typeof (int))
      return;
    if ((int) e.Argument == 1)
      e.Result = (object) GA.GetUsageHistory();
    if ((int) e.Argument != 2)
      return;
    e.Result = (object) frmNapThe.CheckCoupon(this.txtCoupon.Text, 1);
  }

  private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
  {
    if (e.Result != null && e.Result.GetType() == typeof (LoginResult))
    {
      this.btnBuyHour.Enabled = true;
      this.lvTinhnang.Enabled = true;
      LoginResult result = (LoginResult) e.Result;
      if (result.LoginCode == 0)
      {
        if (result.LoginData != null && result.LoginData.ToString() != "")
        {
          int num1 = (int) MessageBox.Show(result.LoginData.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        else
        {
          int num2 = (int) MessageBox.Show("Không thể mua giờ, chưa phân biệt được lỗi.\nVui lòng báo admin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
      }
      else
      {
        if (result.LoginCode != 1)
        {
          GA.ShowMessage(result.Message, "Lỗi mua giờ", 60000);
          this.ClearBuyData();
          return;
        }
        GA.ShowMessage("Mua giờ thành công", "OK", 15000);
        this.ClearBuyData();
      }
      if (!this.backgroundWorker1.IsBusy)
        this.backgroundWorker1.RunWorkerAsync((object) 1);
    }
    if (e.Result == null || e.Result.GetType() != typeof (Dictionary<string, object>))
      return;
    Dictionary<string, object> result1 = (Dictionary<string, object>) e.Result;
    if (result1.ContainsKey("history"))
    {
      frmLogin.GAuto.Settings.Account.ListHistory.Clear();
      if (result1.Count > 0)
      {
        int num3 = 0;
        if (result1.ContainsKey("count"))
          num3 = result1["count"] != null ? int.Parse(result1["count"].ToString()) : 0;
        if (num3 > 0 && result1["username"].ToString() == frmLogin.GAuto.Settings.Account.Username)
        {
          List<Dictionary<string, object>> dictionaryList = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(result1["history"].ToString());
          if (dictionaryList.Count > 0)
          {
            try
            {
              int num4 = 1;
              foreach (Dictionary<string, object> dictionary in dictionaryList)
              {
                HistoryItem historyItem = new HistoryItem();
                historyItem.ActDate = dictionary["date"] != null ? DateTime.Parse(dictionary["date"].ToString()) : DateTime.MinValue;
                double num5 = dictionary["endbalance"] != null ? double.Parse(dictionary["endbalance"].ToString()) / 1000.0 : 0.0;
                historyItem.Balance = num5 > 0.0 ? num5.ToString("0.0") : "-";
                historyItem.Balance = historyItem.Balance.Replace(".0", "");
                double num6 = dictionary["ggcost"] != null ? double.Parse(dictionary["ggcost"].ToString()) / 1000.0 : 0.0;
                historyItem.Cost = num6 > 0.0 ? num6.ToString("0.0") : "-";
                historyItem.Cost = historyItem.Cost.Replace(".0", "");
                if (dictionary["comment"] != null)
                {
                  if (dictionary["comment"].ToString().StartsWith("Nạp"))
                  {
                    historyItem.Comment = dictionary["comment"].ToString();
                    historyItem.Cost = "+" + historyItem.Cost;
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
                    historyItem.Cost = "-" + historyItem.Cost;
                  }
                }
                else
                  historyItem.Comment = "---";
                historyItem.Index = num4;
                frmLogin.GAuto.Settings.Account.ListHistory.Add(historyItem);
                ++num4;
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
    else
    {
      if (!result1.ContainsKey("cp") || !result1.ContainsKey("cpmsg"))
        return;
      this.btnCoupon.Enabled = true;
      this.txtCoupon.Enabled = true;
      object obj = (object) null;
      string str1 = "";
      result1.TryGetValue("cpmsg", out obj);
      if (obj != null)
        str1 = obj.ToString();
      bool flag = true;
      if (str1 == string.Empty)
        flag = false;
      else if (str1.Contains("không hợp lệ") || str1.Contains("không đúng"))
        flag = false;
      if (!flag)
      {
        this.cpPercent = 0.0;
        this.cpminPrice = 0.0;
        this.lbCoupon.ForeColor = Color.DarkRed;
        this.lbCoupon.Text = str1;
      }
      else
      {
        result1.TryGetValue("ad", out obj);
        double.TryParse(obj.ToString(), out this.cpPercent);
        result1.TryGetValue("cpmin", out obj);
        double.TryParse(obj.ToString(), out this.cpminPrice);
        string str2 = "";
        if (this.cpminPrice > 0.0)
          str2 = $" (gói thuê bao {(this.cpminPrice / frmLogin.GGUnitDivision).ToString("0.0").Replace(".0", "")} GG trở lên)";
        this.lbCoupon.ForeColor = Color.DarkGreen;
        this.lbCoupon.Text = str1 + str2;
      }
    }
  }

  private void btnRefresh_Click(object sender, EventArgs e)
  {
    if (frmLogin.GlobalTimer.ElapsedMilliseconds <= this.lastHistoryClick)
      return;
    this.lastHistoryClick = frmLogin.GlobalTimer.ElapsedMilliseconds + 5000L;
    if (this.backgroundWorker1.IsBusy)
      return;
    this.backgroundWorker1.RunWorkerAsync((object) 1);
  }

  private void btnSkillPhaiExpand_Click(object sender, EventArgs e)
  {
    this.ExpLicenseGroup(this.flagGroupLicExpanded);
  }

  private void label6_Click(object sender, EventArgs e)
  {
    this.ExpLicenseGroup(this.flagGroupLicExpanded);
  }

  private void lvTinhnang_CellEditFinished(object sender, CellEditEventArgs e)
  {
    e.AutoDispose = false;
    ((ObjectListView) sender).RefreshItem(e.ListViewItem);
    e.Cancel = true;
  }

  private void lvTinhnang_CellEditStarting(object sender, CellEditEventArgs e)
  {
    if (e.RowObject == null)
      return;
    try
    {
      TinhNang tn = (TinhNang) e.RowObject;
      if (tn == null || frmLogin.GAuto.Settings.Account.BangGia.Count <= 0)
        return;
      List<string> stringList = new List<string>();
      for (int index = 0; index < frmLogin.GAuto.Settings.Account.BangGia.Count; ++index)
      {
        if (frmLogin.GAuto.Settings.Account.BangGia[index].Key == tn.TNKey && frmLogin.GAuto.Settings.Account.BangGia[index].SlotCount == tn.SlotCount)
          stringList.Add(frmLogin.GAuto.Settings.Account.BangGia[index].TimeUnitShort);
      }
      ComboBox cbo = new ComboBox();
      cbo.Bounds = e.CellBounds;
      cbo.DropDownWidth = (int) Math.Round((double) cbo.Bounds.Width * 1.2);
      cbo.BeginUpdate();
      cbo.Items.AddRange((object[]) stringList.ToArray());
      cbo.EndUpdate();
      cbo.GotFocus += new EventHandler(this.cbo_GotFocus);
      cbo.DropDown += new EventHandler(this.cbo_DropDown);
      cbo.SelectedIndexChanged += (EventHandler) ((o, args) =>
      {
        try
        {
          if (cbo == null || cbo.SelectedItem == null)
            return;
          if (tn == null)
            return;
          try
          {
            tn.GiaHanTime = cbo.SelectedItem.ToString();
          }
          catch (Exception ex)
          {
          }
        }
        catch (Exception ex)
        {
        }
        finally
        {
          this.lvTinhnang_CellEditFinished(sender, e);
        }
      });
      e.Control = (Control) cbo;
    }
    catch (Exception ex)
    {
    }
  }

  private void cbo_DropDown(object sender, EventArgs e) => (sender as ComboBox).DroppedDown = false;

  private void cbo_GotFocus(object sender, EventArgs e) => (sender as ComboBox).DroppedDown = true;

  private void pnelButtons_Paint(object sender, PaintEventArgs e)
  {
  }

  private void btnCoupon_Click(object sender, EventArgs e)
  {
    if (this.backgroundWorker1.IsBusy)
      return;
    this.btnCoupon.Enabled = false;
    this.txtCoupon.Enabled = false;
    this.backgroundWorker1.RunWorkerAsync((object) 2);
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
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmLiteBuy));
    this.pnelTitle = new Panel();
    this.btnClose = new Button();
    this.lbTitle = new Label();
    this.statusStrip1 = new StatusStrip();
    this.stripStatus = new ToolStripStatusLabel();
    this.toolStripStatusLabel1 = new ToolStripStatusLabel();
    this.stripTotal = new ToolStripStatusLabel();
    this.timer1 = new System.Windows.Forms.Timer(this.components);
    this.label1 = new Label();
    this.lbUsername = new Label();
    this.lbGG = new Label();
    this.label3 = new Label();
    this.lbGGPromo = new Label();
    this.label5 = new Label();
    this.pnelBalance = new Panel();
    this.lbHanDung = new Label();
    this.label4 = new Label();
    this.pnelUsage = new Panel();
    this.btnRefresh = new Button();
    this.lvHistory = new ObjectListView();
    this.colHist_Index = new OLVColumn();
    this.colHist_ActTime = new OLVColumn();
    this.colHist_Activity = new OLVColumn();
    this.colHist_Cost = new OLVColumn();
    this.colHist_Remain = new OLVColumn();
    this.label2 = new Label();
    this.pnelTinhNang = new Panel();
    this.lvTinhnang = new ObjectListView();
    this.col_Tinhnang = new OLVColumn();
    this.col_Remain = new OLVColumn();
    this.col_Comment = new OLVColumn();
    this.col_GiaHan = new OLVColumn();
    this.col_Buy = new OLVColumn();
    this.label8 = new Label();
    this.pnelMuaGio = new Panel();
    this.groupLicenses = new GroupBox();
    this.pnelButtons = new Panel();
    this.lbCoupon = new Label();
    this.btnCoupon = new Button();
    this.label13 = new Label();
    this.txtCoupon = new TextBox();
    this.btnBuyHour = new Button();
    this.btnPackageExpand = new Button();
    this.backgroundWorker1 = new BackgroundWorker();
    this.pnelMuaGioTitle = new Panel();
    this.label6 = new Label();
    this.pnelTitle.SuspendLayout();
    this.statusStrip1.SuspendLayout();
    this.pnelBalance.SuspendLayout();
    this.pnelUsage.SuspendLayout();
    ((ISupportInitialize) this.lvHistory).BeginInit();
    this.pnelTinhNang.SuspendLayout();
    ((ISupportInitialize) this.lvTinhnang).BeginInit();
    this.pnelMuaGio.SuspendLayout();
    this.pnelButtons.SuspendLayout();
    this.pnelMuaGioTitle.SuspendLayout();
    this.SuspendLayout();
    this.pnelTitle.Controls.Add((Control) this.btnClose);
    this.pnelTitle.Controls.Add((Control) this.lbTitle);
    this.pnelTitle.Dock = DockStyle.Top;
    this.pnelTitle.Location = new Point(0, 0);
    this.pnelTitle.Name = "pnelTitle";
    this.pnelTitle.Size = new Size(314, 48 /*0x30*/);
    this.pnelTitle.TabIndex = 0;
    this.btnClose.BackColor = Color.FromArgb(247, 207, 142);
    this.btnClose.ForeColor = Color.Black;
    this.btnClose.ImeMode = ImeMode.NoControl;
    this.btnClose.Location = new Point(239, 5);
    this.btnClose.Margin = new Padding(0);
    this.btnClose.Name = "btnClose";
    this.btnClose.Size = new Size(69, 23);
    this.btnClose.TabIndex = 16 /*0x10*/;
    this.btnClose.Text = "Đóng";
    this.btnClose.UseVisualStyleBackColor = false;
    this.btnClose.Click += new EventHandler(this.btnThoatAuto_Click);
    this.lbTitle.Dock = DockStyle.Top;
    this.lbTitle.Location = new Point(0, 0);
    this.lbTitle.Margin = new Padding(5, 5, 3, 0);
    this.lbTitle.Name = "lbTitle";
    this.lbTitle.Padding = new Padding(5, 3, 5, 3);
    this.lbTitle.Size = new Size(314, 50);
    this.lbTitle.TabIndex = 0;
    this.lbTitle.Text = "- Chọn gói Thuê bao\r\n- Chọn gói Tính năng (Chế đồ, auto Q)\r\n- Bấm \"Xác nhận mua\"";
    this.statusStrip1.Items.AddRange(new ToolStripItem[3]
    {
      (ToolStripItem) this.stripStatus,
      (ToolStripItem) this.toolStripStatusLabel1,
      (ToolStripItem) this.stripTotal
    });
    this.statusStrip1.Location = new Point(0, 655);
    this.statusStrip1.Name = "statusStrip1";
    this.statusStrip1.Size = new Size(314, 22);
    this.statusStrip1.TabIndex = 1;
    this.statusStrip1.Text = "statusStrip1";
    this.stripStatus.Name = "stripStatus";
    this.stripStatus.Size = new Size(83, 17);
    this.stripStatus.Text = "Trạng thái: OK";
    this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
    this.toolStripStatusLabel1.Size = new Size(145, 17);
    this.toolStripStatusLabel1.Spring = true;
    this.stripTotal.Name = "stripTotal";
    this.stripTotal.Size = new Size(71, 17);
    this.stripTotal.Text = "Sẽ tốn: 0 GG";
    this.timer1.Enabled = true;
    this.timer1.Interval = 400;
    this.timer1.Tick += new EventHandler(this.timer1_Tick);
    this.label1.AutoSize = true;
    this.label1.Location = new Point(11, 5);
    this.label1.Name = "label1";
    this.label1.Size = new Size(76, 13);
    this.label1.TabIndex = 2;
    this.label1.Text = "Tên tài khoản:";
    this.lbUsername.AutoSize = true;
    this.lbUsername.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
    this.lbUsername.ForeColor = Color.Blue;
    this.lbUsername.Location = new Point(93, 5);
    this.lbUsername.Name = "lbUsername";
    this.lbUsername.Size = new Size(25, 13);
    this.lbUsername.TabIndex = 3;
    this.lbUsername.Text = "___";
    this.lbGG.AutoSize = true;
    this.lbGG.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
    this.lbGG.ForeColor = Color.Blue;
    this.lbGG.Location = new Point(93, 22);
    this.lbGG.Name = "lbGG";
    this.lbGG.Size = new Size(25, 13);
    this.lbGG.TabIndex = 5;
    this.lbGG.Text = "___";
    this.label3.AutoSize = true;
    this.label3.Location = new Point(11, 22);
    this.label3.Name = "label3";
    this.label3.Size = new Size(47, 13);
    this.label3.TabIndex = 4;
    this.label3.Text = "GG còn:";
    this.lbGGPromo.AutoSize = true;
    this.lbGGPromo.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
    this.lbGGPromo.ForeColor = Color.Blue;
    this.lbGGPromo.Location = new Point(224 /*0xE0*/, 22);
    this.lbGGPromo.Name = "lbGGPromo";
    this.lbGGPromo.Size = new Size(25, 13);
    this.lbGGPromo.TabIndex = 7;
    this.lbGGPromo.Text = "___";
    this.label5.AutoSize = true;
    this.label5.Location = new Point(168, 22);
    this.label5.Name = "label5";
    this.label5.Size = new Size(54, 13);
    this.label5.TabIndex = 6;
    this.label5.Text = "GG k.mãi:";
    this.pnelBalance.Controls.Add((Control) this.lbHanDung);
    this.pnelBalance.Controls.Add((Control) this.label4);
    this.pnelBalance.Controls.Add((Control) this.label1);
    this.pnelBalance.Controls.Add((Control) this.lbGGPromo);
    this.pnelBalance.Controls.Add((Control) this.lbUsername);
    this.pnelBalance.Controls.Add((Control) this.label5);
    this.pnelBalance.Controls.Add((Control) this.label3);
    this.pnelBalance.Controls.Add((Control) this.lbGG);
    this.pnelBalance.Dock = DockStyle.Top;
    this.pnelBalance.Location = new Point(0, 48 /*0x30*/);
    this.pnelBalance.Name = "pnelBalance";
    this.pnelBalance.Size = new Size(314, 42);
    this.pnelBalance.TabIndex = 8;
    this.lbHanDung.AutoSize = true;
    this.lbHanDung.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
    this.lbHanDung.ForeColor = Color.Blue;
    this.lbHanDung.Location = new Point(224 /*0xE0*/, 5);
    this.lbHanDung.Name = "lbHanDung";
    this.lbHanDung.Size = new Size(25, 13);
    this.lbHanDung.TabIndex = 9;
    this.lbHanDung.Text = "___";
    this.label4.AutoSize = true;
    this.label4.Location = new Point(168, 5);
    this.label4.Name = "label4";
    this.label4.Size = new Size(57, 13);
    this.label4.TabIndex = 8;
    this.label4.Text = "Hạn dùng:";
    this.pnelUsage.Controls.Add((Control) this.btnRefresh);
    this.pnelUsage.Controls.Add((Control) this.lvHistory);
    this.pnelUsage.Controls.Add((Control) this.label2);
    this.pnelUsage.Dock = DockStyle.Bottom;
    this.pnelUsage.Location = new Point(0, 515);
    this.pnelUsage.Name = "pnelUsage";
    this.pnelUsage.Size = new Size(314, 140);
    this.pnelUsage.TabIndex = 10;
    this.btnRefresh.BackColor = SystemColors.Control;
    this.btnRefresh.FlatStyle = FlatStyle.Flat;
    this.btnRefresh.ForeColor = SystemColors.Control;
    this.btnRefresh.Image = (Image) Resources.refresh;
    this.btnRefresh.ImeMode = ImeMode.NoControl;
    this.btnRefresh.Location = new Point(158, 5);
    this.btnRefresh.Name = "btnRefresh";
    this.btnRefresh.Size = new Size(24, 20);
    this.btnRefresh.TabIndex = 74;
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
    this.lvHistory.Location = new Point(0, 26);
    this.lvHistory.Margin = new Padding(2);
    this.lvHistory.Name = "lvHistory";
    this.lvHistory.Size = new Size(314, 114);
    this.lvHistory.TabIndex = 73;
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
    this.colHist_Cost.Text = "Giá";
    this.colHist_Cost.TextAlign = HorizontalAlignment.Right;
    this.colHist_Cost.Width = 32 /*0x20*/;
    this.colHist_Remain.AspectName = "Balance";
    this.colHist_Remain.Groupable = false;
    this.colHist_Remain.HeaderCheckBoxUpdatesRowCheckBoxes = false;
    this.colHist_Remain.Hideable = false;
    this.colHist_Remain.IsEditable = false;
    this.colHist_Remain.Sortable = false;
    this.colHist_Remain.Text = "Còn (GG)";
    this.colHist_Remain.TextAlign = HorizontalAlignment.Right;
    this.colHist_Remain.Width = 57;
    this.label2.AutoSize = true;
    this.label2.Location = new Point(5, 9);
    this.label2.Name = "label2";
    this.label2.Size = new Size(155, 13);
    this.label2.TabIndex = 72;
    this.label2.Text = "Lịch sử hoạt động 10 ngày qua";
    this.pnelTinhNang.Controls.Add((Control) this.lvTinhnang);
    this.pnelTinhNang.Controls.Add((Control) this.label8);
    this.pnelTinhNang.Dock = DockStyle.Top;
    this.pnelTinhNang.Location = new Point(0, 90);
    this.pnelTinhNang.Name = "pnelTinhNang";
    this.pnelTinhNang.Size = new Size(314, 97);
    this.pnelTinhNang.TabIndex = 11;
    this.lvTinhnang.AllColumns.Add(this.col_Tinhnang);
    this.lvTinhnang.AllColumns.Add(this.col_Remain);
    this.lvTinhnang.AllColumns.Add(this.col_Comment);
    this.lvTinhnang.AllColumns.Add(this.col_GiaHan);
    this.lvTinhnang.AllColumns.Add(this.col_Buy);
    this.lvTinhnang.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
    this.lvTinhnang.CellEditActivation = ObjectListView.CellEditActivateMode.SingleClick;
    this.lvTinhnang.CellEditUseWholeCell = false;
    this.lvTinhnang.Columns.AddRange(new ColumnHeader[5]
    {
      (ColumnHeader) this.col_Tinhnang,
      (ColumnHeader) this.col_Remain,
      (ColumnHeader) this.col_Comment,
      (ColumnHeader) this.col_GiaHan,
      (ColumnHeader) this.col_Buy
    });
    this.lvTinhnang.Cursor = Cursors.Default;
    this.lvTinhnang.Dock = DockStyle.Bottom;
    this.lvTinhnang.ForeColor = Color.FromArgb(32 /*0x20*/, 32 /*0x20*/, 32 /*0x20*/);
    this.lvTinhnang.FullRowSelect = true;
    this.lvTinhnang.Location = new Point(0, 17);
    this.lvTinhnang.Margin = new Padding(2);
    this.lvTinhnang.Name = "lvTinhnang";
    this.lvTinhnang.Size = new Size(314, 80 /*0x50*/);
    this.lvTinhnang.TabIndex = 9;
    this.lvTinhnang.UseCompatibleStateImageBehavior = false;
    this.lvTinhnang.View = View.Details;
    this.lvTinhnang.CellEditFinished += new CellEditEventHandler(this.lvTinhnang_CellEditFinished);
    this.lvTinhnang.CellEditStarting += new CellEditEventHandler(this.lvTinhnang_CellEditStarting);
    this.lvTinhnang.CellClick += new EventHandler<CellClickEventArgs>(this.lvTinhnang_CellClick);
    this.lvTinhnang.ItemChecked += new ItemCheckedEventHandler(this.lvTinhnang_ItemChecked);
    this.col_Tinhnang.AspectName = "Tinhnang";
    this.col_Tinhnang.Groupable = false;
    this.col_Tinhnang.HeaderCheckBoxUpdatesRowCheckBoxes = false;
    this.col_Tinhnang.Hideable = false;
    this.col_Tinhnang.IsEditable = false;
    this.col_Tinhnang.Sortable = false;
    this.col_Tinhnang.Text = "Tính năng";
    this.col_Remain.AspectName = "Remain";
    this.col_Remain.Groupable = false;
    this.col_Remain.HeaderCheckBoxUpdatesRowCheckBoxes = false;
    this.col_Remain.Hideable = false;
    this.col_Remain.IsEditable = false;
    this.col_Remain.Sortable = false;
    this.col_Remain.Text = "Còn lại";
    this.col_Remain.TextAlign = HorizontalAlignment.Center;
    this.col_Remain.ToolTipText = "Thời gian còn lại";
    this.col_Remain.Width = 50;
    this.col_Comment.AspectName = "Comment";
    this.col_Comment.FillsFreeSpace = true;
    this.col_Comment.Groupable = false;
    this.col_Comment.HeaderCheckBoxUpdatesRowCheckBoxes = false;
    this.col_Comment.Hideable = false;
    this.col_Comment.IsEditable = false;
    this.col_Comment.Sortable = false;
    this.col_Comment.Text = "Gói đã mua";
    this.col_Comment.Width = 105;
    this.col_GiaHan.AspectName = "GiaHanTime";
    this.col_GiaHan.ButtonSizing = OLVColumn.ButtonSizingMode.CellBounds;
    this.col_GiaHan.Groupable = false;
    this.col_GiaHan.HeaderCheckBoxUpdatesRowCheckBoxes = false;
    this.col_GiaHan.Hideable = false;
    this.col_GiaHan.Searchable = false;
    this.col_GiaHan.Sortable = false;
    this.col_GiaHan.Text = "Thêm";
    this.col_GiaHan.UseFiltering = false;
    this.col_GiaHan.Width = 45;
    this.col_Buy.AspectName = "";
    this.col_Buy.Groupable = false;
    this.col_Buy.HeaderCheckBoxUpdatesRowCheckBoxes = false;
    this.col_Buy.Hideable = false;
    this.col_Buy.IsButton = true;
    this.col_Buy.IsEditable = false;
    this.col_Buy.Sortable = false;
    this.col_Buy.Text = "Gia hạn";
    this.col_Buy.TextAlign = HorizontalAlignment.Center;
    this.col_Buy.ToolTipText = "Gia hạn thêm giờ";
    this.col_Buy.Width = 47;
    this.label8.AutoSize = true;
    this.label8.Location = new Point(5, 2);
    this.label8.Name = "label8";
    this.label8.Size = new Size(217, 13);
    this.label8.TabIndex = 2;
    this.label8.Text = "Tính năng đang có (nhấn dấu + để gia hạn)";
    this.pnelMuaGio.Controls.Add((Control) this.groupLicenses);
    this.pnelMuaGio.Controls.Add((Control) this.pnelButtons);
    this.pnelMuaGio.Dock = DockStyle.Top;
    this.pnelMuaGio.Location = new Point(0, 206);
    this.pnelMuaGio.Name = "pnelMuaGio";
    this.pnelMuaGio.Size = new Size(314, 313);
    this.pnelMuaGio.TabIndex = 13;
    this.groupLicenses.Dock = DockStyle.Fill;
    this.groupLicenses.Location = new Point(0, 0);
    this.groupLicenses.Margin = new Padding(5);
    this.groupLicenses.Name = "groupLicenses";
    this.groupLicenses.Size = new Size(314, 258);
    this.groupLicenses.TabIndex = 3;
    this.groupLicenses.TabStop = false;
    this.groupLicenses.Text = "Gói Thuê bao";
    this.pnelButtons.Controls.Add((Control) this.lbCoupon);
    this.pnelButtons.Controls.Add((Control) this.btnCoupon);
    this.pnelButtons.Controls.Add((Control) this.label13);
    this.pnelButtons.Controls.Add((Control) this.txtCoupon);
    this.pnelButtons.Controls.Add((Control) this.btnBuyHour);
    this.pnelButtons.Dock = DockStyle.Bottom;
    this.pnelButtons.Location = new Point(0, 258);
    this.pnelButtons.Name = "pnelButtons";
    this.pnelButtons.Size = new Size(314, 55);
    this.pnelButtons.TabIndex = 13;
    this.pnelButtons.Paint += new PaintEventHandler(this.pnelButtons_Paint);
    this.lbCoupon.ForeColor = Color.DarkGreen;
    this.lbCoupon.ImeMode = ImeMode.NoControl;
    this.lbCoupon.Location = new Point(8, 35);
    this.lbCoupon.Name = "lbCoupon";
    this.lbCoupon.Size = new Size(300, 13);
    this.lbCoupon.TabIndex = 76;
    this.lbCoupon.TextAlign = ContentAlignment.MiddleLeft;
    this.btnCoupon.BackColor = SystemColors.Control;
    this.btnCoupon.FlatStyle = FlatStyle.Flat;
    this.btnCoupon.ForeColor = SystemColors.Control;
    this.btnCoupon.Image = (Image) Resources.refresh;
    this.btnCoupon.ImeMode = ImeMode.NoControl;
    this.btnCoupon.Location = new Point(178, 7);
    this.btnCoupon.Name = "btnCoupon";
    this.btnCoupon.Size = new Size(24, 20);
    this.btnCoupon.TabIndex = 75;
    this.btnCoupon.UseVisualStyleBackColor = false;
    this.btnCoupon.Click += new EventHandler(this.btnCoupon_Click);
    this.label13.AutoSize = true;
    this.label13.ImeMode = ImeMode.NoControl;
    this.label13.Location = new Point(5, 11);
    this.label13.Name = "label13";
    this.label13.Size = new Size(83, 13);
    this.label13.TabIndex = 25;
    this.label13.Text = "Mã KM (nếu có)";
    this.label13.TextAlign = ContentAlignment.MiddleRight;
    this.txtCoupon.BorderStyle = BorderStyle.FixedSingle;
    this.txtCoupon.Location = new Point(94, 7);
    this.txtCoupon.Name = "txtCoupon";
    this.txtCoupon.Size = new Size(81, 20);
    this.txtCoupon.TabIndex = 26;
    this.btnBuyHour.BackColor = Color.FromArgb(210, 249, 213);
    this.btnBuyHour.ForeColor = Color.DarkGreen;
    this.btnBuyHour.ImeMode = ImeMode.NoControl;
    this.btnBuyHour.Location = new Point(221, 5);
    this.btnBuyHour.Name = "btnBuyHour";
    this.btnBuyHour.Size = new Size(88, 23);
    this.btnBuyHour.TabIndex = 15;
    this.btnBuyHour.Text = "Xác nhận mua";
    this.btnBuyHour.UseVisualStyleBackColor = false;
    this.btnBuyHour.Click += new EventHandler(this.btnBuyHour_Click);
    this.btnPackageExpand.BackColor = Color.FromArgb(225, 225, 225);
    this.btnPackageExpand.FlatStyle = FlatStyle.Flat;
    this.btnPackageExpand.ForeColor = Color.FromArgb(225, 225, 225);
    this.btnPackageExpand.Image = (Image) componentResourceManager.GetObject("btnPackageExpand.Image");
    this.btnPackageExpand.ImeMode = ImeMode.NoControl;
    this.btnPackageExpand.Location = new Point(0, 0);
    this.btnPackageExpand.Margin = new Padding(0);
    this.btnPackageExpand.Name = "btnPackageExpand";
    this.btnPackageExpand.Size = new Size(19, 19);
    this.btnPackageExpand.TabIndex = 31 /*0x1F*/;
    this.btnPackageExpand.UseVisualStyleBackColor = false;
    this.btnPackageExpand.Click += new EventHandler(this.btnSkillPhaiExpand_Click);
    this.backgroundWorker1.DoWork += new DoWorkEventHandler(this.backgroundWorker1_DoWork);
    this.backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
    this.pnelMuaGioTitle.Controls.Add((Control) this.btnPackageExpand);
    this.pnelMuaGioTitle.Controls.Add((Control) this.label6);
    this.pnelMuaGioTitle.Dock = DockStyle.Top;
    this.pnelMuaGioTitle.Location = new Point(0, 187);
    this.pnelMuaGioTitle.Name = "pnelMuaGioTitle";
    this.pnelMuaGioTitle.Size = new Size(314, 19);
    this.pnelMuaGioTitle.TabIndex = 14;
    this.label6.Dock = DockStyle.Top;
    this.label6.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.label6.ForeColor = Color.Firebrick;
    this.label6.Location = new Point(0, 0);
    this.label6.Name = "label6";
    this.label6.Padding = new Padding(5, 3, 0, 0);
    this.label6.Size = new Size(314, 20);
    this.label6.TabIndex = 16 /*0x10*/;
    this.label6.Text = "     Mua gói Thuê Bao và Tính năng (bấm để mở)";
    this.label6.Click += new EventHandler(this.label6_Click);
    this.AutoScaleDimensions = new SizeF(6f, 13f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.ClientSize = new Size(314, 677);
    this.Controls.Add((Control) this.pnelMuaGio);
    this.Controls.Add((Control) this.pnelMuaGioTitle);
    this.Controls.Add((Control) this.pnelUsage);
    this.Controls.Add((Control) this.pnelTinhNang);
    this.Controls.Add((Control) this.pnelBalance);
    this.Controls.Add((Control) this.pnelTitle);
    this.Controls.Add((Control) this.statusStrip1);
    this.FormBorderStyle = FormBorderStyle.FixedDialog;
    this.MaximizeBox = false;
    this.MaximumSize = new Size(330, 999);
    this.MinimumSize = new Size(330, 468);
    this.Name = nameof (frmLiteBuy);
    this.StartPosition = FormStartPosition.CenterScreen;
    this.Tag = (object) "XC";
    this.Text = "Mua giờ chơi";
    this.FormClosing += new FormClosingEventHandler(this.frmLiteBuy_FormClosing);
    this.Load += new EventHandler(this.frmLiteBuy_Load);
    this.Shown += new EventHandler(this.frmLiteBuy_Shown);
    this.pnelTitle.ResumeLayout(false);
    this.statusStrip1.ResumeLayout(false);
    this.statusStrip1.PerformLayout();
    this.pnelBalance.ResumeLayout(false);
    this.pnelBalance.PerformLayout();
    this.pnelUsage.ResumeLayout(false);
    this.pnelUsage.PerformLayout();
    ((ISupportInitialize) this.lvHistory).EndInit();
    this.pnelTinhNang.ResumeLayout(false);
    this.pnelTinhNang.PerformLayout();
    ((ISupportInitialize) this.lvTinhnang).EndInit();
    this.pnelMuaGio.ResumeLayout(false);
    this.pnelButtons.ResumeLayout(false);
    this.pnelButtons.PerformLayout();
    this.pnelMuaGioTitle.ResumeLayout(false);
    this.ResumeLayout(false);
    this.PerformLayout();
  }
}
