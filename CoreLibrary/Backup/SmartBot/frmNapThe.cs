// Decompiled with JetBrains decompiler
// Type: SmartBot.frmNapThe
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using GAuto_Auto_None.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Security;
using System.Text;
using System.Web;
using System.Windows.Forms;

#nullable disable
namespace SmartBot;

public class frmNapThe : Form
{
  private int xpos;
  private int ypos;
  private string strPromotion = "Tặng 10% khi chuyển khoản ngân hàng 100K+";
  private SecureString myCaptcha = new SecureString();
  public string defaultAccount = "";
  public Bitmap captchaContent;
  public SmartClass myGrandAccount;
  private int failedCaptcha;
  private object sleepLock = new object();
  private IContainer components;
  private GroupBox grpCardAdd;
  private ComboBox txtCardType;
  private Label label7;
  private Label label6;
  private Label label5;
  private TextBox txtCardSerial;
  private TextBox txtCardCode;
  private Button btnHuy;
  private Button btnNapThe;
  private Label label1;
  private LinkLabel linkPrice;
  private Label lblStatus;
  private Label lblCoupon;
  private System.Windows.Forms.Timer timer1;
  private Label label2;
  private TextBox txtTenTaiKhoan;
  private Label label11;
  private Label label10;
  private Label label9;
  private Label label8;
  private PictureBox picCaptcha;
  private Label lblCaptcha;
  private TextBox txtCaptcha;
  private Label lblCaptcha2;
  private Button btnCaptcha;
  private Label lblCaptcha3;
  private Label lblLoaiTK;
  private Label label3;
  private RadioButton rdioGGold;
  private RadioButton rdioTien;
  private Label lbNaptien;
  private Label label12;
  private Label label13;
  private TextBox txtCoupon;
  private Button btnCoupon;
  private Label lblMaKMResult;
  private BackgroundWorker backgroundWorker1;
  private Button btnTheNoiDia;
  private Label label63;
  private Label label62;

  public frmNapThe()
  {
    this.InitializeComponent();
    this.ypos = this.lblCoupon.Location.Y;
    this.xpos = this.Width;
  }

  private void CheckPromotion()
  {
    this.strPromotion = GA.LoadWeb(frmLogin.MainGAutoServer.URL + frmLogin.GAuto.Settings.KhuyenMaiURL, "", "GET", frmLogin.GAuto.Settings.MainCookie);
  }

  private void linkPrice_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
  {
    Process.Start(frmLogin.GAuto.Settings.ProLicenseURL);
  }

  private void txtCardType_SelectedIndexChanged(object sender, EventArgs e)
  {
    if (this.txtCardType.SelectedItem.ToString().Contains("GAU"))
      this.txtCardSerial.Enabled = false;
    else
      this.txtCardSerial.Enabled = true;
  }

  private void btnHuy_Click(object sender, EventArgs e) => this.Close();

  private void btnNapThe_Click(object sender, EventArgs e)
  {
    try
    {
      if (this.backgroundWorker1.IsBusy)
        return;
      this.btnNapThe.Enabled = false;
      this.btnHuy.Enabled = false;
      this.btnCoupon.Enabled = false;
      this.backgroundWorker1.RunWorkerAsync((object) 2);
    }
    catch (Exception ex)
    {
    }
  }

  private void DONapThe()
  {
    bool flag1 = false;
    if (GA.CheckForSQLInjection(this.txtCardCode.Text) || GA.CheckForSQLInjection(this.txtCardSerial.Text) || GA.CheckForSQLInjection(this.txtTenTaiKhoan.Text) || GA.CheckForSQLInjection(this.txtCoupon.Text))
      flag1 = true;
    if (this.rdioTien.Checked || !this.rdioGGold.Checked)
      return;
    bool flag2 = false;
    if (this.picCaptcha.Visible)
    {
      if (GA.SecureStringToString(this.myCaptcha).ToLower() == this.txtCaptcha.Text.ToLower())
        flag2 = true;
      frmLogin.frmLoginInstance.txtUserPassword.Invoke((Delegate) (() => this.txtCaptcha.Text = ""));
      GC.Collect();
    }
    else if (frmLogin.GAuto.Settings.FailedCaptcha < 3)
      flag2 = true;
    if (flag2)
    {
      string telcoID = "GAU";
      string str1 = this.txtCardCode.Text.Trim();
      string str2 = this.txtCardSerial.Text.Trim();
      string gameId = frmLogin.GAuto.Settings.GameID;
      string str3 = this.txtCoupon.Text.Replace("%", "").Replace("'", "").Replace("\"", "");
      string text = this.txtTenTaiKhoan.Text;
      frmLogin.frmLoginInstance.txtUserPassword.Invoke((Delegate) (() => telcoID = this.txtCardType.SelectedItem.ToString().Split('|')[1].Trim()));
      bool flag3 = true;
      if (telcoID == "GAU")
      {
        str2 = "None";
        if (string.IsNullOrEmpty(str1))
          flag3 = false;
      }
      if (!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(str1) && flag3 && !flag1)
      {
        Dictionary<string, object> dictionary1 = new Dictionary<string, object>();
        Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
        dictionary2.Add("salt", (object) GA.GenerateRandomName(5));
        dictionary2.Add("action", (object) "napthe");
        dictionary2.Add("telcoid", (object) telcoID);
        dictionary2.Add("code", (object) str1);
        dictionary2.Add("seri", (object) str2);
        dictionary2.Add("gameid", (object) gameId);
        dictionary2.Add("uid", (object) text);
        dictionary2.Add("coupon", (object) str3);
        if (frmMain.frmMainInstance != null && frmLogin.GAuto.Settings.Account.UniqueSessionID != "-1")
          dictionary2.Add("gautoid", (object) frmLogin.GAuto.Settings.Account.UniqueSessionID);
        string jsonParams = HttpUtility.UrlEncode(GA.AES_encrypt(JsonConvert.SerializeObject((object) dictionary2), 1));
        Dictionary<string, object> askMeData = GA.GetAskMeData(frmLogin.MainGAutoServer.URL + frmLogin.GAuto.Settings.HouseKeeperURL, "POST", jsonParams);
        if (askMeData != null)
        {
          object obj = (object) null;
          string str4 = "";
          string message = "";
          string statuscode = "";
          askMeData.TryGetValue("status", out obj);
          if (obj != null)
            str4 = obj.ToString();
          askMeData.TryGetValue("message", out obj);
          if (obj != null)
            message = obj.ToString();
          askMeData.TryGetValue("statuscode", out obj);
          if (obj != null)
            statuscode = obj.ToString();
          switch (str4)
          {
            case "ERROR":
              frmLogin.frmLoginInstance.txtUserPassword.Invoke((Delegate) (() =>
              {
                if (message != "")
                  this.lblStatus.Text = $"Lỗi: {message} ({statuscode})";
                else
                  this.lblStatus.Text = $"Lỗi: {statuscode}";
                this.lblStatus.ForeColor = Color.Red;
                ++frmLogin.GAuto.Settings.FailedCaptcha;
              }));
              break;
            case "NAPTHEOK":
              if (message != "")
                frmLogin.frmLoginInstance.txtUserPassword.Invoke((Delegate) (() =>
                {
                  this.lblStatus.ForeColor = Color.DarkGreen;
                  this.lblStatus.Text = message;
                }));
              string s1 = "0";
              string s2 = "0";
              string str5 = "";
              string str6 = "";
              askMeData.TryGetValue("realamount", out obj);
              if (obj != null)
                s1 = obj.ToString();
              askMeData.TryGetValue("promoamount", out obj);
              if (obj != null)
                s2 = obj.ToString();
              askMeData.TryGetValue("cardSerial", out obj);
              if (obj != null)
                str5 = obj.ToString();
              askMeData.TryGetValue("cardPin", out obj);
              if (obj != null)
                str6 = obj.ToString();
              double result1 = 0.0;
              double.TryParse(s1, out result1);
              double result2 = 0.0;
              double.TryParse(s2, out result2);
              result1 += result2;
              result1 /= frmLogin.GGUnitDivision;
              if (s1 != "" && s1 != "0")
              {
                if (telcoID != "GAU")
                {
                  string _content = $"Nạp thành công thẻ {str5}/{str6} được {s1}.\nBạn đã nạp thêm {result1.ToString("0.0").Replace(".0", "")}{frmLogin.GGUnit} vào tải khoản {text}";
                  if (result2 > 0.0)
                    _content = string.Format("Nạp thành công thẻ {0}/{1} được {2}, khuyến mãi {5}.\nBạn đã nạp thêm {3}{4} vào tài khoản {6}", (object) str5, (object) str6, (object) s1, (object) result1.ToString("0.0").Replace(".0", ""), (object) frmLogin.GGUnit, (object) s2, (object) text);
                  GA.ShowMessage(_content, "Nạp thẻ thành công", 120000);
                }
                else
                  GA.ShowMessage($"Nạp mã thưởng {str6} thành công.\nThông báo: {message}", "Mã thưởng", 120000);
                if (frmLogin.GAuto.Settings.IsLoggedIn && frmLogin.GAuto.Settings.Account != null)
                  GA.SecureLoginPHPv2(new LoginParams()
                  {
                    Username = frmLogin.GAuto.Settings.Account.Username,
                    Password = frmLogin.GAuto.Settings.Account.Password,
                    ShowForm = false
                  });
                frmLogin.GAuto.Settings.FailedCaptcha = 0;
                break;
              }
              break;
            default:
              GA.ShowMessage("Nạp thẻ bị lỗi", "Lỗi", 60000);
              break;
          }
        }
        else
          frmLogin.frmLoginInstance.txtUserPassword.Invoke((Delegate) (() =>
          {
            this.lblStatus.Text = "Lỗi khi nạp thẻ, báo admin";
            this.lblStatus.ForeColor = Color.Red;
            ++frmLogin.GAuto.Settings.FailedCaptcha;
          }));
      }
    }
    else
    {
      int num = (int) MessageBox.Show("Vui lòng nhập câu hỏi chống bot đúng.", "Captcha", MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }
    if (frmLogin.GAuto.Settings.FailedCaptcha < 3 && !flag1)
      return;
    frmLogin.frmLoginInstance.txtUserPassword.Invoke((Delegate) (() =>
    {
      if (!this.picCaptcha.Visible)
        this.AdjustForm(true);
      this.GenNewCaptcha();
    }));
  }

  private void timer1_Tick(object sender, EventArgs e)
  {
    if (!string.IsNullOrEmpty(this.strPromotion) && this.strPromotion != this.lblCoupon.Text)
      this.lblCoupon.Text = this.strPromotion;
    if (string.IsNullOrEmpty(this.lblCoupon.Text))
      return;
    if (this.xpos <= this.lblCoupon.Width * -1)
    {
      this.lblCoupon.Location = new Point(this.Width, this.ypos);
      this.xpos = this.Width;
    }
    else
    {
      this.lblCoupon.Location = new Point(this.xpos, this.ypos);
      this.xpos -= 2;
    }
  }

  private void AdjustForm(bool extend)
  {
    int num = -108;
    bool flag1 = false;
    if (extend)
    {
      num = 108;
      flag1 = true;
    }
    bool flag2 = false;
    if (!this.picCaptcha.Visible && extend)
      flag2 = true;
    else if (this.picCaptcha.Visible && !extend)
      flag2 = true;
    if (!flag2)
      return;
    this.Height += num;
    this.lblStatus.Top += num;
    this.linkPrice.Top += num;
    this.lblCoupon.Top += num;
    this.btnHuy.Top += num;
    this.btnNapThe.Top += num;
    this.ypos = this.lblCoupon.Location.Y;
    this.btnCaptcha.Visible = flag1;
    this.picCaptcha.Visible = flag1;
    this.lblCaptcha.Visible = flag1;
    this.txtCaptcha.Visible = flag1;
    this.lblCaptcha3.Visible = flag1;
    this.lblCaptcha2.Visible = flag1;
  }

  private void frmNapThe_Load(object sender, EventArgs e)
  {
    if (frmLogin.GAuto.Settings.FailedCaptcha < 3)
    {
      this.AdjustForm(false);
    }
    else
    {
      this.AdjustForm(true);
      this.GenNewCaptcha();
    }
    if (!string.IsNullOrEmpty(this.defaultAccount))
      this.txtTenTaiKhoan.Text = this.defaultAccount;
    this.txtCardType.SelectedIndex = 0;
  }

  private void frmNapThe_Shown(object sender, EventArgs e)
  {
    ToolTip toolTip = new ToolTip();
    toolTip.OwnerDraw = true;
    toolTip.BackColor = Color.Yellow;
    toolTip.AutoPopDelay = 20000;
    toolTip.InitialDelay = 500;
    toolTip.ReshowDelay = 500;
    toolTip.ShowAlways = true;
    toolTip.IsBalloon = true;
    toolTip.SetToolTip((Control) this.rdioTien, "Tiền nạp vào dạng thuê bao, giá rẻ, trừ theo thời gian.");
    toolTip.SetToolTip((Control) this.rdioGGold, "GAuto Gold (G-Gold), Dùng GG để mua thời gian chơi.\nGG có thể sử dụng để mua giờ chế đồ, Q12, YTO.");
    this.timer1.Enabled = true;
    this.rdioGGold.Checked = true;
    this.rdioTien.Visible = false;
    this.lbNaptien.Text = "Thẻ nạp sẽ vào GG tài khoản. Bạn sử dụng \ntính năng 'Mua giờ' để mua giờ chơi và tính năng.";
    this.lbNaptien.ForeColor = Color.RosyBrown;
  }

  private void btnCaptcha_Click(object sender, EventArgs e) => this.GenNewCaptcha();

  private void GenNewCaptcha()
  {
    this.myCaptcha = GA.ConvertToSecureString(GA.GenerateRandomName(6));
    GC.Collect();
    this.picCaptcha.Image = (Image) GA.GenerateCaptcha(this.myCaptcha);
  }

  private void txtCardCode_TextChanged(object sender, EventArgs e)
  {
    if (this.txtCardType.SelectedItem == null || !(this.txtCardType.SelectedItem.ToString() == "GameAuto.net Code"))
      return;
    if (!string.IsNullOrEmpty(this.txtCardCode.Text))
    {
      if (this.txtCardCode.Text.Contains("-PRO-"))
      {
        this.rdioGGold.Enabled = true;
      }
      else
      {
        this.rdioGGold.Enabled = false;
        this.rdioTien.Checked = true;
      }
    }
    else
    {
      this.rdioGGold.Enabled = false;
      this.rdioTien.Checked = true;
    }
  }

  private void rdioTien_CheckedChanged(object sender, EventArgs e)
  {
  }

  private void rdioGGold_CheckedChanged(object sender, EventArgs e)
  {
  }

  private void rdioTien_Click(object sender, EventArgs e)
  {
    this.rdioTien.ForeColor = Color.Black;
    this.rdioGGold.ForeColor = Color.Black;
  }

  private void btnCoupon_Click(object sender, EventArgs e)
  {
    if (this.backgroundWorker1.IsBusy)
      return;
    this.btnCoupon.Enabled = false;
    this.backgroundWorker1.RunWorkerAsync((object) 1);
  }

  private void QueryCouponNew()
  {
    if (!(this.txtCoupon.Text != ""))
      return;
    string str = this.txtCoupon.Text.Replace("%", "");
    str = this.txtCoupon.Text.Replace("'", "");
    string coupon = this.txtCoupon.Text.Replace("\"", "");
    if (!(coupon != ""))
      return;
    Dictionary<string, object> dictionary = frmNapThe.CheckCoupon(coupon);
    if (dictionary.Count <= 0)
      return;
    object obj = (object) null;
    string maKMMsg = "";
    dictionary.TryGetValue("cpmsg", out obj);
    if (obj != null)
      maKMMsg = obj.ToString();
    frmLogin.frmLoginInstance.txtUserPassword.Invoke((Delegate) (() =>
    {
      if (maKMMsg.Contains("không hợp lệ") || maKMMsg.Contains("không đúng") || maKMMsg == "")
        this.lblMaKMResult.ForeColor = Color.Red;
      else
        this.lblMaKMResult.ForeColor = Color.Blue;
      if (maKMMsg != "")
        this.lblMaKMResult.Text = maKMMsg;
      else
        this.lblMaKMResult.Text = "Lỗi xử lý mã khuyến mãi";
    }));
  }

  public static Dictionary<string, object> CheckCoupon(string coupon, int fortime = 0)
  {
    Dictionary<string, object> dictionary = new Dictionary<string, object>();
    string jsonParams = HttpUtility.UrlEncode(GA.AES_encrypt(JsonConvert.SerializeObject((object) new Dictionary<string, object>()
    {
      {
        "salt",
        (object) GA.GenerateRandomName(5)
      },
      {
        "action",
        (object) nameof (coupon)
      },
      {
        nameof (fortime),
        (object) fortime
      },
      {
        nameof (coupon),
        (object) coupon
      }
    }), 1));
    return GA.GetAskMeData(frmLogin.MainGAutoServer.URL + frmLogin.GAuto.Settings.HouseKeeperURL, "POST", jsonParams);
  }

  private void QueryCoupon()
  {
    if (!(this.txtCoupon.Text != ""))
      return;
    string str1 = this.txtCoupon.Text.Replace("%", "");
    str1 = this.txtCoupon.Text.Replace("'", "");
    string str2 = this.txtCoupon.Text.Replace("\"", "");
    if (!(str2 != ""))
      return;
    string input = GA.LoadWebNoAlive(frmLogin.MainGAutoServer.URL + frmLogin.GAuto.Settings.CouponURL, "coupon=" + str2, "POST", (CookieContainer) null);
    if (!(input != "") || !(input != frmLogin.GAuto.Settings.LoadWebErrorMessage))
      return;
    string s = HttpUtility.UrlDecode(GA.GetMyField(input, "cpmsg"));
    try
    {
      s = Encoding.UTF8.GetString(Convert.FromBase64String(s));
    }
    catch (Exception ex)
    {
    }
    if (s.Contains("không hợp lệ"))
      this.lblMaKMResult.ForeColor = Color.Red;
    else
      this.lblMaKMResult.ForeColor = Color.Blue;
    this.lblMaKMResult.Text = s;
  }

  private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
  {
    if (e.Argument != null && e.Argument.GetType() == typeof (int) && (int) e.Argument == 1)
    {
      this.QueryCouponNew();
      e.Result = (object) 1;
    }
    else
    {
      if (e.Argument == null || e.Argument.GetType() != typeof (int) || (int) e.Argument != 2)
        return;
      this.DONapThe();
      e.Result = (object) 2;
    }
  }

  private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
  {
    if (e.Result != null && e.Result.GetType() == typeof (int) && (int) e.Result == 1)
    {
      this.btnCoupon.Enabled = true;
    }
    else
    {
      if (e.Result == null || e.Result.GetType() != typeof (int) || (int) e.Result != 2)
        return;
      this.btnCoupon.Enabled = true;
      this.btnNapThe.Enabled = true;
      this.btnHuy.Enabled = true;
    }
  }

  private void btnTheNoiDia_Click(object sender, EventArgs e)
  {
    Process.Start("http://pay.gameauto.net/payment/auto_bank.php");
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
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmNapThe));
    this.grpCardAdd = new GroupBox();
    this.btnCoupon = new Button();
    this.lblMaKMResult = new Label();
    this.label13 = new Label();
    this.txtCoupon = new TextBox();
    this.lbNaptien = new Label();
    this.label3 = new Label();
    this.rdioGGold = new RadioButton();
    this.rdioTien = new RadioButton();
    this.lblLoaiTK = new Label();
    this.label11 = new Label();
    this.label10 = new Label();
    this.label9 = new Label();
    this.label8 = new Label();
    this.label2 = new Label();
    this.txtTenTaiKhoan = new TextBox();
    this.txtCardType = new ComboBox();
    this.label7 = new Label();
    this.label6 = new Label();
    this.label5 = new Label();
    this.txtCardSerial = new TextBox();
    this.txtCardCode = new TextBox();
    this.btnHuy = new Button();
    this.btnNapThe = new Button();
    this.label1 = new Label();
    this.lblCoupon = new Label();
    this.linkPrice = new LinkLabel();
    this.lblStatus = new Label();
    this.timer1 = new System.Windows.Forms.Timer(this.components);
    this.lblCaptcha = new Label();
    this.txtCaptcha = new TextBox();
    this.lblCaptcha2 = new Label();
    this.lblCaptcha3 = new Label();
    this.btnCaptcha = new Button();
    this.picCaptcha = new PictureBox();
    this.label12 = new Label();
    this.backgroundWorker1 = new BackgroundWorker();
    this.btnTheNoiDia = new Button();
    this.label63 = new Label();
    this.label62 = new Label();
    this.grpCardAdd.SuspendLayout();
    ((ISupportInitialize) this.picCaptcha).BeginInit();
    this.SuspendLayout();
    this.grpCardAdd.Controls.Add((Control) this.btnCoupon);
    this.grpCardAdd.Controls.Add((Control) this.lblMaKMResult);
    this.grpCardAdd.Controls.Add((Control) this.label13);
    this.grpCardAdd.Controls.Add((Control) this.txtCoupon);
    this.grpCardAdd.Controls.Add((Control) this.lbNaptien);
    this.grpCardAdd.Controls.Add((Control) this.label3);
    this.grpCardAdd.Controls.Add((Control) this.rdioGGold);
    this.grpCardAdd.Controls.Add((Control) this.rdioTien);
    this.grpCardAdd.Controls.Add((Control) this.lblLoaiTK);
    this.grpCardAdd.Controls.Add((Control) this.label11);
    this.grpCardAdd.Controls.Add((Control) this.label10);
    this.grpCardAdd.Controls.Add((Control) this.label9);
    this.grpCardAdd.Controls.Add((Control) this.label8);
    this.grpCardAdd.Controls.Add((Control) this.label2);
    this.grpCardAdd.Controls.Add((Control) this.txtTenTaiKhoan);
    this.grpCardAdd.Controls.Add((Control) this.txtCardType);
    this.grpCardAdd.Controls.Add((Control) this.label7);
    this.grpCardAdd.Controls.Add((Control) this.label6);
    this.grpCardAdd.Controls.Add((Control) this.label5);
    this.grpCardAdd.Controls.Add((Control) this.txtCardSerial);
    this.grpCardAdd.Controls.Add((Control) this.txtCardCode);
    componentResourceManager.ApplyResources((object) this.grpCardAdd, "grpCardAdd");
    this.grpCardAdd.Name = "grpCardAdd";
    this.grpCardAdd.TabStop = false;
    this.btnCoupon.BackColor = Color.FromArgb(210, 249, 213);
    this.btnCoupon.ForeColor = Color.DarkGreen;
    componentResourceManager.ApplyResources((object) this.btnCoupon, "btnCoupon");
    this.btnCoupon.Name = "btnCoupon";
    this.btnCoupon.UseVisualStyleBackColor = false;
    this.btnCoupon.Click += new EventHandler(this.btnCoupon_Click);
    componentResourceManager.ApplyResources((object) this.lblMaKMResult, "lblMaKMResult");
    this.lblMaKMResult.ForeColor = Color.MediumBlue;
    this.lblMaKMResult.Name = "lblMaKMResult";
    componentResourceManager.ApplyResources((object) this.label13, "label13");
    this.label13.Name = "label13";
    this.txtCoupon.BorderStyle = BorderStyle.FixedSingle;
    componentResourceManager.ApplyResources((object) this.txtCoupon, "txtCoupon");
    this.txtCoupon.Name = "txtCoupon";
    componentResourceManager.ApplyResources((object) this.lbNaptien, "lbNaptien");
    this.lbNaptien.Name = "lbNaptien";
    componentResourceManager.ApplyResources((object) this.label3, "label3");
    this.label3.ForeColor = Color.Red;
    this.label3.Name = "label3";
    componentResourceManager.ApplyResources((object) this.rdioGGold, "rdioGGold");
    this.rdioGGold.ForeColor = Color.Black;
    this.rdioGGold.Name = "rdioGGold";
    this.rdioGGold.UseVisualStyleBackColor = true;
    this.rdioGGold.CheckedChanged += new EventHandler(this.rdioGGold_CheckedChanged);
    componentResourceManager.ApplyResources((object) this.rdioTien, "rdioTien");
    this.rdioTien.ForeColor = Color.Black;
    this.rdioTien.Name = "rdioTien";
    this.rdioTien.UseVisualStyleBackColor = true;
    this.rdioTien.CheckedChanged += new EventHandler(this.rdioTien_CheckedChanged);
    this.rdioTien.Click += new EventHandler(this.rdioTien_Click);
    componentResourceManager.ApplyResources((object) this.lblLoaiTK, "lblLoaiTK");
    this.lblLoaiTK.Name = "lblLoaiTK";
    componentResourceManager.ApplyResources((object) this.label11, "label11");
    this.label11.ForeColor = Color.Red;
    this.label11.Name = "label11";
    componentResourceManager.ApplyResources((object) this.label10, "label10");
    this.label10.ForeColor = Color.Red;
    this.label10.Name = "label10";
    componentResourceManager.ApplyResources((object) this.label9, "label9");
    this.label9.ForeColor = Color.Red;
    this.label9.Name = "label9";
    componentResourceManager.ApplyResources((object) this.label8, "label8");
    this.label8.ForeColor = Color.Red;
    this.label8.Name = "label8";
    componentResourceManager.ApplyResources((object) this.label2, "label2");
    this.label2.Name = "label2";
    this.txtTenTaiKhoan.BorderStyle = BorderStyle.FixedSingle;
    componentResourceManager.ApplyResources((object) this.txtTenTaiKhoan, "txtTenTaiKhoan");
    this.txtTenTaiKhoan.Name = "txtTenTaiKhoan";
    componentResourceManager.ApplyResources((object) this.txtCardType, "txtCardType");
    this.txtCardType.FormattingEnabled = true;
    this.txtCardType.Items.AddRange(new object[8]
    {
      (object) componentResourceManager.GetString("txtCardType.Items"),
      (object) componentResourceManager.GetString("txtCardType.Items1"),
      (object) componentResourceManager.GetString("txtCardType.Items2"),
      (object) componentResourceManager.GetString("txtCardType.Items3"),
      (object) componentResourceManager.GetString("txtCardType.Items4"),
      (object) componentResourceManager.GetString("txtCardType.Items5"),
      (object) componentResourceManager.GetString("txtCardType.Items6"),
      (object) componentResourceManager.GetString("txtCardType.Items7")
    });
    this.txtCardType.Name = "txtCardType";
    this.txtCardType.SelectedIndexChanged += new EventHandler(this.txtCardType_SelectedIndexChanged);
    componentResourceManager.ApplyResources((object) this.label7, "label7");
    this.label7.Name = "label7";
    componentResourceManager.ApplyResources((object) this.label6, "label6");
    this.label6.Name = "label6";
    componentResourceManager.ApplyResources((object) this.label5, "label5");
    this.label5.Name = "label5";
    this.txtCardSerial.BorderStyle = BorderStyle.FixedSingle;
    componentResourceManager.ApplyResources((object) this.txtCardSerial, "txtCardSerial");
    this.txtCardSerial.Name = "txtCardSerial";
    this.txtCardCode.BorderStyle = BorderStyle.FixedSingle;
    componentResourceManager.ApplyResources((object) this.txtCardCode, "txtCardCode");
    this.txtCardCode.Name = "txtCardCode";
    this.txtCardCode.TextChanged += new EventHandler(this.txtCardCode_TextChanged);
    this.btnHuy.BackColor = Color.FromArgb(247, 207, 142);
    this.btnHuy.ForeColor = Color.SaddleBrown;
    componentResourceManager.ApplyResources((object) this.btnHuy, "btnHuy");
    this.btnHuy.Name = "btnHuy";
    this.btnHuy.UseVisualStyleBackColor = false;
    this.btnHuy.Click += new EventHandler(this.btnHuy_Click);
    this.btnNapThe.BackColor = Color.FromArgb(210, 249, 213);
    this.btnNapThe.ForeColor = Color.DarkGreen;
    componentResourceManager.ApplyResources((object) this.btnNapThe, "btnNapThe");
    this.btnNapThe.Name = "btnNapThe";
    this.btnNapThe.UseVisualStyleBackColor = false;
    this.btnNapThe.Click += new EventHandler(this.btnNapThe_Click);
    componentResourceManager.ApplyResources((object) this.label1, "label1");
    this.label1.Name = "label1";
    componentResourceManager.ApplyResources((object) this.lblCoupon, "lblCoupon");
    this.lblCoupon.BackColor = Color.Transparent;
    this.lblCoupon.ForeColor = Color.Maroon;
    this.lblCoupon.Name = "lblCoupon";
    componentResourceManager.ApplyResources((object) this.linkPrice, "linkPrice");
    this.linkPrice.Name = "linkPrice";
    this.linkPrice.TabStop = true;
    this.linkPrice.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkPrice_LinkClicked);
    componentResourceManager.ApplyResources((object) this.lblStatus, "lblStatus");
    this.lblStatus.Name = "lblStatus";
    this.timer1.Interval = 20;
    this.timer1.Tick += new EventHandler(this.timer1_Tick);
    this.lblCaptcha.BackColor = Color.Transparent;
    componentResourceManager.ApplyResources((object) this.lblCaptcha, "lblCaptcha");
    this.lblCaptcha.Name = "lblCaptcha";
    this.txtCaptcha.BorderStyle = BorderStyle.FixedSingle;
    componentResourceManager.ApplyResources((object) this.txtCaptcha, "txtCaptcha");
    this.txtCaptcha.Name = "txtCaptcha";
    componentResourceManager.ApplyResources((object) this.lblCaptcha2, "lblCaptcha2");
    this.lblCaptcha2.ForeColor = Color.Red;
    this.lblCaptcha2.Name = "lblCaptcha2";
    this.lblCaptcha3.BackColor = Color.Transparent;
    componentResourceManager.ApplyResources((object) this.lblCaptcha3, "lblCaptcha3");
    this.lblCaptcha3.ForeColor = Color.SteelBlue;
    this.lblCaptcha3.Name = "lblCaptcha3";
    componentResourceManager.ApplyResources((object) this.btnCaptcha, "btnCaptcha");
    this.btnCaptcha.ForeColor = Color.DodgerBlue;
    this.btnCaptcha.Image = (Image) Resources.Refresh_icon;
    this.btnCaptcha.Name = "btnCaptcha";
    this.btnCaptcha.UseVisualStyleBackColor = true;
    this.btnCaptcha.Click += new EventHandler(this.btnCaptcha_Click);
    this.picCaptcha.BorderStyle = BorderStyle.FixedSingle;
    componentResourceManager.ApplyResources((object) this.picCaptcha, "picCaptcha");
    this.picCaptcha.Name = "picCaptcha";
    this.picCaptcha.TabStop = false;
    componentResourceManager.ApplyResources((object) this.label12, "label12");
    this.label12.Name = "label12";
    this.backgroundWorker1.DoWork += new DoWorkEventHandler(this.backgroundWorker1_DoWork);
    this.backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
    this.btnTheNoiDia.BackColor = Color.FromArgb(192 /*0xC0*/, 240 /*0xF0*/, 192 /*0xC0*/);
    componentResourceManager.ApplyResources((object) this.btnTheNoiDia, "btnTheNoiDia");
    this.btnTheNoiDia.ForeColor = Color.DarkGreen;
    this.btnTheNoiDia.Name = "btnTheNoiDia";
    this.btnTheNoiDia.UseVisualStyleBackColor = false;
    this.btnTheNoiDia.Click += new EventHandler(this.btnTheNoiDia_Click);
    componentResourceManager.ApplyResources((object) this.label63, "label63");
    this.label63.ForeColor = Color.Maroon;
    this.label63.Name = "label63";
    componentResourceManager.ApplyResources((object) this.label62, "label62");
    this.label62.ForeColor = Color.DodgerBlue;
    this.label62.Name = "label62";
    componentResourceManager.ApplyResources((object) this, "$this");
    this.AutoScaleMode = AutoScaleMode.Font;
    this.BackColor = Color.WhiteSmoke;
    this.Controls.Add((Control) this.btnTheNoiDia);
    this.Controls.Add((Control) this.label63);
    this.Controls.Add((Control) this.label62);
    this.Controls.Add((Control) this.label12);
    this.Controls.Add((Control) this.lblCaptcha3);
    this.Controls.Add((Control) this.lblCoupon);
    this.Controls.Add((Control) this.lblStatus);
    this.Controls.Add((Control) this.linkPrice);
    this.Controls.Add((Control) this.btnNapThe);
    this.Controls.Add((Control) this.btnHuy);
    this.Controls.Add((Control) this.btnCaptcha);
    this.Controls.Add((Control) this.lblCaptcha2);
    this.Controls.Add((Control) this.lblCaptcha);
    this.Controls.Add((Control) this.txtCaptcha);
    this.Controls.Add((Control) this.picCaptcha);
    this.Controls.Add((Control) this.label1);
    this.Controls.Add((Control) this.grpCardAdd);
    this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
    this.Name = nameof (frmNapThe);
    this.ShowIcon = false;
    this.Load += new EventHandler(this.frmNapThe_Load);
    this.Shown += new EventHandler(this.frmNapThe_Shown);
    this.grpCardAdd.ResumeLayout(false);
    this.grpCardAdd.PerformLayout();
    ((ISupportInitialize) this.picCaptcha).EndInit();
    this.ResumeLayout(false);
    this.PerformLayout();
  }
}
