// Decompiled with JetBrains decompiler
// Type: SmartBot.frmReg
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using CS2PHPCryptography;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Windows.Forms;

#nullable disable
namespace SmartBot;

public class frmReg : Form
{
  public Dictionary<string, string> userInfo = frmLogin.GAuto.Settings.LoginInfo;
  public Dictionary<string, string> regInfo = new Dictionary<string, string>();
  private SecurePHPConnection secureConnect = new SecurePHPConnection();
  public string DongY = "";
  public string CreationTime = "";
  public string FormToken = "";
  private string confirm_id = "";
  private string picturePath = "";
  private long LastColorStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
  private long lastTextChange = frmLogin.GlobalTimer.ElapsedMilliseconds;
  private bool needCheck;
  private bool canReg;
  private bool preworkAgain;
  private long stampCaptcha;
  private static bool termAgreed;
  private IContainer components;
  private GroupBox grpInfo;
  private Button btnCheckUserName;
  private TextBox txtUserLogin;
  private Label label1;
  private TextBox txtUserPass;
  private Label label2;
  private TextBox txtRePass;
  private Label label3;
  private TextBox txtUserEmail;
  private Label label4;
  private Button btnDoReg;
  private TextBox txtCode;
  private Label label8;
  private PictureBox picCaptcha;
  private CheckBox cboxTerms;
  private LinkLabel lblTermLink;
  private Label lblStatus;
  private System.Windows.Forms.Timer timer1;
  private BackgroundWorker backgroundWorker1;
  private Button btnRegCaptcha;

  public frmReg()
  {
    this.InitializeComponent();
    this.btnDoReg.Enabled = false;
  }

  private void secureConnectn_OnConnectionEstablished(
    object sender,
    OnConnectionEstablishedEventArgs e)
  {
  }

  private void secureConnect_OnResponseReceived(object sender, ResponseReceivedEventArgs e)
  {
  }

  public static bool IsValidUserName(string username)
  {
    Regex regex = new Regex("^[A-Za-z\\d_-]+$");
    return !string.IsNullOrEmpty(username) && regex.IsMatch(username);
  }

  public static bool IsValidEmail(string mailAddress)
  {
    Regex regex = new Regex("[\\w-]+@([\\w-]+\\.)+[\\w-]+");
    return !string.IsNullOrEmpty(mailAddress) && regex.IsMatch(mailAddress);
  }

  public static Image GetImageFromUrl(string url)
  {
    using (WebClient webClient = new WebClient())
      return frmReg.ByteArrayToImage(webClient.DownloadData(url));
  }

  public static Image ByteArrayToImage(byte[] fileBytes)
  {
    using (MemoryStream memoryStream = new MemoryStream(fileBytes))
      return Image.FromStream((Stream) memoryStream);
  }

  private void frmReg_Load(object sender, EventArgs e)
  {
    if (frmLogin.GAuto.Settings.CompilingLanguage == "VN")
    {
      this.txtUserLogin.Text = "";
      this.txtUserPass.Text = "";
      this.txtRePass.Text = "";
      this.txtUserEmail.Text = "";
      this.txtCode.Text = "Vui lòng chờ";
      this.txtCode.Enabled = false;
      this.backgroundWorker1.RunWorkerAsync((object) 1);
    }
    else if (frmLogin.GAuto.Settings.CompilingLanguage == "EN")
    {
      this.PreRegistrationEN();
    }
    else
    {
      if (!(frmLogin.GAuto.Settings.CompilingLanguage == "CN"))
        return;
      this.PreRegistrationCN();
    }
  }

  private void PreRegistrationCN()
  {
    GA.LoadWeb(frmLogin.GAuto.Settings.RegisterAccountURL, "", "GET", frmLogin.GAuto.Settings.MainCookie);
    bool loadOK = false;
    this.picCaptcha.Image = GA.LoadImage(frmLogin.GAuto.Settings.RegURL, frmLogin.GAuto.Settings.MainCookie, ref loadOK);
  }

  private void PreRegistrationEN()
  {
    GA.LoadWeb(frmLogin.GAuto.Settings.RegisterAccountURL, "", "GET", frmLogin.GAuto.Settings.MainCookie);
    bool loadOK = false;
    this.picCaptcha.Image = GA.LoadImage("http://www.tianlongauto.net/autotl/models/captcha.php", frmLogin.GAuto.Settings.MainCookie, ref loadOK);
  }

  private bool PreRegistrationVN()
  {
    bool flag1 = false;
    int num1 = 0;
    string input1;
    Image myImage;
    do
    {
      string input2;
      do
      {
        frmLogin.GAuto.Settings.MainCookie = new CookieContainer();
        input2 = GA.LoadWeb(frmLogin.MainGAutoServer.URL + frmLogin.GAuto.Settings.RegisterAccountURL, "", "GET", frmLogin.GAuto.Settings.MainCookie, false);
        if (input2 == string.Empty || input2 == frmLogin.GAuto.Settings.LoadWebErrorMessage)
          ++num1;
        else
          goto label_3;
      }
      while (num1 <= frmLogin.GAuto.Settings.httpRetries * 2);
      goto label_5;
label_3:
      this.DongY = GA.GetMidString(input2, "id=\"agreed\" value=\"", "\" class=\"button1");
      this.CreationTime = GA.GetMidString(input2, "creation_time\" value=\"", "\" />");
      this.FormToken = GA.GetMidString(input2, "form_token\" value=\"", "\" />");
      string data = $"agreed={this.DongY}&change_lang=&creation_time={this.CreationTime}&form_token={this.FormToken}";
      input1 = GA.LoadWeb(frmLogin.MainGAutoServer.URL + frmLogin.GAuto.Settings.RegisterAccountURL, data, "POST", frmLogin.GAuto.Settings.MainCookie, false);
      this.CreationTime = GA.GetMidString(input1, "creation_time\" value=\"", "\" />");
      this.FormToken = GA.GetMidString(input1, "form_token\" value=\"", "\" />");
      this.picturePath = GA.GetMidString(input1, "name=\"confirm_id\" value=\"", "\" />");
      string strURL = $"{frmLogin.MainGAutoServer.URL}forum/ucp.php?mode=confirm&confirm_id={this.picturePath}&type=1";
      bool loadOK = false;
      myImage = GA.LoadImage(strURL, frmLogin.GAuto.Settings.MainCookie, ref loadOK);
      if (!loadOK)
        ++num1;
      else
        goto label_6;
    }
    while (num1 <= frmLogin.GAuto.Settings.httpRetries * 2);
    goto label_7;
label_5:
    flag1 = true;
    goto label_8;
label_6:
    this.Invoke((Delegate) (() => this.picCaptcha.Image = myImage));
    this.confirm_id = GA.GetMidString(input1, "name=\"confirm_id\" value=\"", "\" />");
    goto label_8;
label_7:
    flag1 = true;
label_8:
    bool flag2;
    if (flag1)
    {
      flag2 = false;
      int num2 = (int) MessageBox.Show("Server đang bị kẻ xấu tấn công nên đăng ký hơi khó. Bạn có thể đăng ký tại trang chủ:\n\nwww.gameauto.net/forum/", "Đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }
    else
      flag2 = true;
    if (this.InvokeRequired)
      this.Invoke((Delegate) (() => this.btnDoReg.Enabled = true));
    else
      this.btnDoReg.Enabled = true;
    return flag2;
  }

  private bool PreRegistrationVNNew()
  {
    bool flag1 = false;
    int num1 = 0;
    Image myCaptcha;
    do
    {
      if (frmLogin.GAuto.Settings.MainCookie == null)
        frmLogin.GAuto.Settings.MainCookie = new CookieContainer();
      bool loadOK = false;
      myCaptcha = GA.LoadImage(frmLogin.MainGAutoServer.URL + frmLogin.GAuto.Settings.CaptchaURL, frmLogin.GAuto.Settings.MainCookie, ref loadOK);
      if (!loadOK)
        ++num1;
      else
        goto label_5;
    }
    while (num1 <= frmLogin.GAuto.Settings.httpRetries * 2);
    goto label_6;
label_5:
    this.Invoke((Delegate) (() => this.picCaptcha.Image = myCaptcha));
    goto label_7;
label_6:
    flag1 = true;
label_7:
    bool flag2;
    if (flag1)
    {
      flag2 = false;
      int num2 = (int) MessageBox.Show("Server đang bị kẻ xấu tấn công nên đăng ký hơi khó. Bạn có thể đăng ký tại trang chủ:\n\nwww.gameauto.net/forum/", "Đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }
    else
      flag2 = true;
    if (this.InvokeRequired)
      this.Invoke((Delegate) (() => this.btnDoReg.Enabled = true));
    else
      this.btnDoReg.Enabled = true;
    return flag2;
  }

  private void frmReg_FormClosed(object sender, FormClosedEventArgs e) => this.Dispose();

  private void btnCheckUserName_Click(object sender, EventArgs e)
  {
    if (!this.backgroundWorker1.IsBusy)
    {
      this.backgroundWorker1.RunWorkerAsync((object) 2);
    }
    else
    {
      long num = frmLogin.GlobalTimer.ElapsedMilliseconds + 500L;
      while (frmLogin.GlobalTimer.ElapsedMilliseconds <= num)
      {
        if (!this.backgroundWorker1.IsBusy)
        {
          this.backgroundWorker1.RunWorkerAsync((object) 2);
          break;
        }
        Thread.Sleep(100);
      }
    }
  }

  private void CheckUserVNNew()
  {
    this.needCheck = false;
    if (!(frmLogin.CompilingLanguage == "VN") || !(this.txtUserLogin.Text != ""))
      return;
    string str = this.txtUserLogin.Text.Replace("%", "");
    str = this.txtUserLogin.Text.Replace("'", "");
    string userInput = this.txtUserLogin.Text.Replace("\"", "");
    bool flag = false;
    if (GA.CheckForSQLInjection(userInput))
      flag = true;
    if (flag)
    {
      this.lblStatus.ForeColor = Color.Red;
      this.Invoke((Delegate) (() => this.lblStatus.Text = "Tên tài khoản có từ không hợp lệ (sys, table,...)"));
    }
    if (string.IsNullOrEmpty(userInput) || flag)
      return;
    Dictionary<string, object> dictionary = new Dictionary<string, object>();
    string jsonParams = HttpUtility.UrlEncode(GA.AES_encrypt(JsonConvert.SerializeObject((object) new Dictionary<string, object>()
    {
      {
        "salt",
        (object) GA.GenerateRandomName(5)
      },
      {
        "action",
        (object) "checkuser"
      },
      {
        "user",
        (object) userInput
      }
    }), 1));
    Dictionary<string, object> askMeData = GA.GetAskMeData(frmLogin.MainGAutoServer.URL + frmLogin.GAuto.Settings.HouseKeeperURL, "POST", jsonParams);
    string msg = "";
    if (askMeData.ContainsKey("msg"))
      msg = askMeData["msg"].ToString();
    this.Invoke((Delegate) (() =>
    {
      if (msg.Contains("đã có"))
        this.lblStatus.ForeColor = Color.Red;
      else
        this.lblStatus.ForeColor = Color.Blue;
      this.lblStatus.Text = msg;
    }));
    this.LastColorStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
  }

  private void CheckuserVN()
  {
    this.needCheck = false;
    if (!(frmLogin.CompilingLanguage == "VN") || !(this.txtUserLogin.Text != ""))
      return;
    string str = this.txtUserLogin.Text.Replace("%", "");
    str = this.txtUserLogin.Text.Replace("'", "");
    string userInput = this.txtUserLogin.Text.Replace("\"", "");
    bool flag = false;
    if (GA.CheckForSQLInjection(userInput))
      flag = true;
    if (flag)
    {
      this.lblStatus.ForeColor = Color.Red;
      this.Invoke((Delegate) (() => this.lblStatus.Text = "Tên tài khoản có từ không hợp lệ (sys, table,...)"));
    }
    if (string.IsNullOrEmpty(userInput) || flag)
      return;
    string input = !frmLogin.GAuto.Settings.CheckUserURL.StartsWith("http") ? GA.LoadWebNoAlive(frmLogin.MainGAutoServer.URL + frmLogin.GAuto.Settings.CheckUserURL, "newuser=" + userInput, "POST", (CookieContainer) null) : GA.LoadWebNoAlive(frmLogin.GAuto.Settings.CheckUserURL, "newuser=" + userInput, "POST", (CookieContainer) null);
    if (!(input != "") || !(input != frmLogin.GAuto.Settings.LoadWebErrorMessage))
      return;
    string maKMMsg = GA.GetMyField(input, "msg");
    maKMMsg = HttpUtility.UrlDecode(maKMMsg);
    try
    {
      maKMMsg = Encoding.UTF8.GetString(Convert.FromBase64String(maKMMsg));
    }
    catch (Exception ex)
    {
    }
    this.Invoke((Delegate) (() =>
    {
      if (maKMMsg.Contains("đã có"))
        this.lblStatus.ForeColor = Color.Red;
      else
        this.lblStatus.ForeColor = Color.Blue;
      this.lblStatus.Text = maKMMsg;
    }));
    this.LastColorStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
  }

  private void btnDoReg_Click(object sender, EventArgs e)
  {
    if (this.txtUserPass.Text != this.txtRePass.Text)
    {
      int num = (int) MessageBox.Show(frmMain.langPasswordMatching, frmMain.langPasswordMatching2, MessageBoxButtons.OK, MessageBoxIcon.Hand);
      this.txtUserPass.Text = "";
      this.txtRePass.Text = "";
    }
    else if (!this.cboxTerms.Checked)
    {
      int num = (int) MessageBox.Show(frmMain.langMustTOS, frmMain.langTOS, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      this.cboxTerms.ForeColor = Color.Red;
    }
    else
    {
      if (this.backgroundWorker1.IsBusy)
        return;
      this.btnDoReg.Enabled = false;
      this.backgroundWorker1.RunWorkerAsync((object) 3);
    }
  }

  private void clickRegister()
  {
    bool flag = false;
    if (GA.CheckForSQLInjection(this.txtUserLogin.Text) && GA.CheckForSQLInjection(this.txtUserEmail.Text) && GA.CheckForSQLInjection(this.txtCode.Text))
      flag = true;
    if (flag)
      return;
    if (frmLogin.GAuto.Settings.CompilingLanguage == "VN")
    {
      string username = this.txtUserLogin.Text;
      string text1 = this.txtUserEmail.Text;
      string password = this.txtUserPass.Text;
      string text2 = this.txtCode.Text;
      Dictionary<string, object> dictionary = new Dictionary<string, object>();
      string jsonParams = HttpUtility.UrlEncode(GA.AES_encrypt(JsonConvert.SerializeObject((object) new Dictionary<string, object>()
      {
        {
          "salt",
          (object) GA.GenerateRandomName(5)
        },
        {
          "action",
          (object) "register"
        },
        {
          "username",
          (object) username
        },
        {
          "displayname",
          (object) username
        },
        {
          "email",
          (object) text1
        },
        {
          "password",
          (object) password
        },
        {
          "passwordc",
          (object) password
        },
        {
          "captcha",
          (object) text2
        }
      }), 1));
      Dictionary<string, object> askMeData = GA.GetAskMeData(frmLogin.MainGAutoServer.URL + frmLogin.GAuto.Settings.HouseKeeperURL, "POST", jsonParams);
      if (askMeData.Count <= 0 || !askMeData.ContainsKey("ketqua"))
        return;
      if (askMeData["ketqua"].ToString() == "REGOK")
      {
        GA.ShowMessage($"Tài khoản {username} đã được tạo thành công", "Đăng ký thành công", 60000);
        this.Invoke((Delegate) (() =>
        {
          frmLogin.frmLoginInstance.txtUserID.Text = username;
          frmLogin.frmLoginInstance.txtUserPassword.Text = password;
          this.Close();
        }));
      }
      else
      {
        GA.ShowMessage("Đăng ký không thành công.\n\nLỗi: " + askMeData["msg"].ToString(), "Lỗi đăng ký", 60000);
        this.PreRegistrationVNNew();
      }
    }
    else
    {
      if (!(frmLogin.GAuto.Settings.CompilingLanguage == "EN") && !(frmLogin.GAuto.Settings.CompilingLanguage == "CN"))
        return;
      string data = $"username={this.txtUserLogin.Text}&displayname={this.txtUserLogin.Text}&password={this.txtUserPass.Text}&passwordc={this.txtUserPass.Text}&email={this.txtUserEmail.Text}&captcha={this.txtCode.Text}";
      string str = GA.LoadWeb(frmLogin.GAuto.Settings.RegisterAccountURL, data, "POST", frmLogin.GAuto.Settings.MainCookie);
      if (frmLogin.GAuto.Settings.CompilingLanguage == "EN")
      {
        string text = GA.GetMidString(str, "<ul><li>", "</li></ul></div>").Replace(" <a href=\"login.php\">here</a>.", ".");
        if (!(text != ""))
        {
          int num1 = (int) MessageBox.Show(str, "Registration");
        }
        else
        {
          int num2 = (int) MessageBox.Show(text, "Registration");
          if (!text.Contains("successfully registered"))
            return;
          frmLogin.frmLoginInstance.txtUserID.Text = this.txtUserLogin.Text;
          frmLogin.frmLoginInstance.txtUserPassword.Text = this.txtUserPass.Text;
          this.Close();
        }
      }
      else if (str.Contains("账号注册成功"))
      {
        int num = (int) MessageBox.Show(str, "注册", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        frmLogin.frmLoginInstance.txtUserID.Text = this.txtUserLogin.Text;
        frmLogin.frmLoginInstance.txtUserPassword.Text = this.txtUserPass.Text;
        this.Close();
      }
      else
      {
        int num = (int) MessageBox.Show(str, "错误注册", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        this.PreRegistrationCN();
      }
    }
  }

  private void txtCardType_TextChanged(object sender, EventArgs e)
  {
  }

  private void lblTermLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
  {
    GA.BrowseTermOfUse();
  }

  private void cboxTerms_CheckedChanged(object sender, EventArgs e)
  {
    this.cboxTerms.ForeColor = Color.Black;
    if (!(frmLogin.CompilingLanguage == "VN"))
      return;
    if (!this.cboxTerms.Checked)
      this.ShowTerms();
    if (!this.cboxTerms.Checked || frmReg.termAgreed)
      return;
    this.cboxTerms.Checked = false;
  }

  private void ShowTerms()
  {
    if (!(frmLogin.CompilingLanguage == "VN"))
      return;
    switch (MessageBox.Show($"- Khi đăng ký {GlobalSettings.AutoName} bạn chắc chắn rằng đã tìm hiểu và xem xét kỹ nguồn gốc auto và tải auto từ trang chủ {GlobalSettings.AutoHomeURL}, bạn đồng ý rằng:\n- Auto chất lượng, an toàn và không hack tài khoản của bạn.\n- Auto chỉ hỗ trợ tự làm các hoạt động trong game, không hỗ trợ hack\n- Auto luôn có bản miễn phí hỗ trợ anh em train quái.\n - Bạn có thể nạp GG để mua giờ sử dụng\n\n===============================================\n- Nếu không đồng ý với điều khoản này, bạn lập tức xóa ngay auto.\n- Nếu đồng ý rồi thì chơi vui vẻ không được khóc hay méc má\n===============================================\n\nNhấn YES để đồng ý 2 tay 3 chân\nNhấn NO - Chúng ta không thuộc về nhau", "Điều khoản sử dụng", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
    {
      case DialogResult.Yes:
        frmReg.termAgreed = true;
        this.cboxTerms.Checked = true;
        break;
      case DialogResult.No:
        frmReg.termAgreed = false;
        this.Close();
        break;
    }
  }

  private void txtUserLogin_TextChanged(object sender, EventArgs e)
  {
    this.lblStatus.Text = "";
    this.lastTextChange = frmLogin.GlobalTimer.ElapsedMilliseconds;
    this.needCheck = true;
  }

  private void timer1_Tick(object sender, EventArgs e)
  {
    if (frmLogin.GlobalTimer.ElapsedMilliseconds - this.LastColorStamp >= 10000L)
      this.lblStatus.Text = "";
    if (!this.needCheck || frmLogin.GlobalTimer.ElapsedMilliseconds - this.lastTextChange < 3000L)
      return;
    if (!this.backgroundWorker1.IsBusy)
      this.backgroundWorker1.RunWorkerAsync((object) 2);
    else
      this.lastTextChange = frmLogin.GlobalTimer.ElapsedMilliseconds;
  }

  private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
  {
    if (e.Argument != null && e.Argument.GetType() == typeof (int) && (int) e.Argument == 1)
    {
      this.canReg = this.PreRegistrationVNNew();
      e.Result = (object) 1;
    }
    else if (e.Argument != null && e.Argument.GetType() == typeof (int) && (int) e.Argument == 2)
    {
      this.CheckUserVNNew();
    }
    else
    {
      if (e.Argument == null || e.Argument.GetType() != typeof (int) || (int) e.Argument != 3)
        return;
      this.clickRegister();
      e.Result = (object) 3;
    }
  }

  private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
  {
    if (e.Result != null && e.Result.GetType() == typeof (int) && (int) e.Result == 1 && this.canReg)
    {
      this.btnDoReg.Enabled = true;
      this.btnRegCaptcha.Enabled = true;
      this.txtCode.Text = "";
      this.txtCode.Enabled = true;
    }
    if (e.Result == null || e.Result.GetType() != typeof (int) || (int) e.Result != 3)
      return;
    this.btnDoReg.Enabled = true;
    if (!this.preworkAgain)
      return;
    this.preworkAgain = false;
    if (this.backgroundWorker1.IsBusy)
      return;
    this.btnDoReg.Enabled = false;
    this.txtCode.Text = "Vui lòng chờ";
    this.txtCode.Enabled = false;
    this.backgroundWorker1.RunWorkerAsync((object) 1);
  }

  private void btnRegCaptcha_Click(object sender, EventArgs e)
  {
    if (this.stampCaptcha != 0L && (this.stampCaptcha <= 0L || frmLogin.GlobalTimer.ElapsedMilliseconds <= this.stampCaptcha))
      return;
    this.stampCaptcha = frmLogin.GlobalTimer.ElapsedMilliseconds + 2000L;
    this.btnRegCaptcha.Enabled = false;
    if (this.backgroundWorker1.IsBusy)
      return;
    this.backgroundWorker1.RunWorkerAsync((object) 1);
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
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmReg));
    this.grpInfo = new GroupBox();
    this.lblStatus = new Label();
    this.picCaptcha = new PictureBox();
    this.btnCheckUserName = new Button();
    this.txtRePass = new TextBox();
    this.label3 = new Label();
    this.txtUserPass = new TextBox();
    this.label2 = new Label();
    this.txtCode = new TextBox();
    this.txtUserEmail = new TextBox();
    this.label8 = new Label();
    this.label4 = new Label();
    this.txtUserLogin = new TextBox();
    this.label1 = new Label();
    this.btnDoReg = new Button();
    this.cboxTerms = new CheckBox();
    this.lblTermLink = new LinkLabel();
    this.timer1 = new System.Windows.Forms.Timer(this.components);
    this.backgroundWorker1 = new BackgroundWorker();
    this.btnRegCaptcha = new Button();
    this.grpInfo.SuspendLayout();
    ((ISupportInitialize) this.picCaptcha).BeginInit();
    this.SuspendLayout();
    this.grpInfo.Controls.Add((Control) this.btnRegCaptcha);
    this.grpInfo.Controls.Add((Control) this.lblStatus);
    this.grpInfo.Controls.Add((Control) this.picCaptcha);
    this.grpInfo.Controls.Add((Control) this.btnCheckUserName);
    this.grpInfo.Controls.Add((Control) this.txtRePass);
    this.grpInfo.Controls.Add((Control) this.label3);
    this.grpInfo.Controls.Add((Control) this.txtUserPass);
    this.grpInfo.Controls.Add((Control) this.label2);
    this.grpInfo.Controls.Add((Control) this.txtCode);
    this.grpInfo.Controls.Add((Control) this.txtUserEmail);
    this.grpInfo.Controls.Add((Control) this.label8);
    this.grpInfo.Controls.Add((Control) this.label4);
    this.grpInfo.Controls.Add((Control) this.txtUserLogin);
    this.grpInfo.Controls.Add((Control) this.label1);
    componentResourceManager.ApplyResources((object) this.grpInfo, "grpInfo");
    this.grpInfo.Name = "grpInfo";
    this.grpInfo.TabStop = false;
    componentResourceManager.ApplyResources((object) this.lblStatus, "lblStatus");
    this.lblStatus.Name = "lblStatus";
    componentResourceManager.ApplyResources((object) this.picCaptcha, "picCaptcha");
    this.picCaptcha.Name = "picCaptcha";
    this.picCaptcha.TabStop = false;
    componentResourceManager.ApplyResources((object) this.btnCheckUserName, "btnCheckUserName");
    this.btnCheckUserName.Name = "btnCheckUserName";
    this.btnCheckUserName.TabStop = false;
    this.btnCheckUserName.UseVisualStyleBackColor = true;
    this.btnCheckUserName.Click += new EventHandler(this.btnCheckUserName_Click);
    this.txtRePass.BorderStyle = BorderStyle.FixedSingle;
    componentResourceManager.ApplyResources((object) this.txtRePass, "txtRePass");
    this.txtRePass.Name = "txtRePass";
    this.txtRePass.UseSystemPasswordChar = true;
    componentResourceManager.ApplyResources((object) this.label3, "label3");
    this.label3.Name = "label3";
    this.txtUserPass.BorderStyle = BorderStyle.FixedSingle;
    componentResourceManager.ApplyResources((object) this.txtUserPass, "txtUserPass");
    this.txtUserPass.Name = "txtUserPass";
    this.txtUserPass.UseSystemPasswordChar = true;
    componentResourceManager.ApplyResources((object) this.label2, "label2");
    this.label2.Name = "label2";
    this.txtCode.BorderStyle = BorderStyle.FixedSingle;
    componentResourceManager.ApplyResources((object) this.txtCode, "txtCode");
    this.txtCode.Name = "txtCode";
    this.txtUserEmail.BorderStyle = BorderStyle.FixedSingle;
    componentResourceManager.ApplyResources((object) this.txtUserEmail, "txtUserEmail");
    this.txtUserEmail.Name = "txtUserEmail";
    componentResourceManager.ApplyResources((object) this.label8, "label8");
    this.label8.Name = "label8";
    componentResourceManager.ApplyResources((object) this.label4, "label4");
    this.label4.Name = "label4";
    this.txtUserLogin.BorderStyle = BorderStyle.FixedSingle;
    componentResourceManager.ApplyResources((object) this.txtUserLogin, "txtUserLogin");
    this.txtUserLogin.Name = "txtUserLogin";
    this.txtUserLogin.TextChanged += new EventHandler(this.txtUserLogin_TextChanged);
    componentResourceManager.ApplyResources((object) this.label1, "label1");
    this.label1.Name = "label1";
    componentResourceManager.ApplyResources((object) this.btnDoReg, "btnDoReg");
    this.btnDoReg.Name = "btnDoReg";
    this.btnDoReg.UseVisualStyleBackColor = true;
    this.btnDoReg.Click += new EventHandler(this.btnDoReg_Click);
    componentResourceManager.ApplyResources((object) this.cboxTerms, "cboxTerms");
    this.cboxTerms.Name = "cboxTerms";
    this.cboxTerms.UseVisualStyleBackColor = true;
    this.cboxTerms.CheckedChanged += new EventHandler(this.cboxTerms_CheckedChanged);
    componentResourceManager.ApplyResources((object) this.lblTermLink, "lblTermLink");
    this.lblTermLink.BackColor = Color.FromArgb(238, 241, 243);
    this.lblTermLink.Name = "lblTermLink";
    this.lblTermLink.TabStop = true;
    this.lblTermLink.LinkClicked += new LinkLabelLinkClickedEventHandler(this.lblTermLink_LinkClicked);
    this.timer1.Enabled = true;
    this.timer1.Interval = 700;
    this.timer1.Tick += new EventHandler(this.timer1_Tick);
    this.backgroundWorker1.DoWork += new DoWorkEventHandler(this.backgroundWorker1_DoWork);
    this.backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
    this.btnRegCaptcha.BackColor = Color.WhiteSmoke;
    componentResourceManager.ApplyResources((object) this.btnRegCaptcha, "btnRegCaptcha");
    this.btnRegCaptcha.ForeColor = Color.WhiteSmoke;
    this.btnRegCaptcha.Name = "btnRegCaptcha";
    this.btnRegCaptcha.UseVisualStyleBackColor = false;
    this.btnRegCaptcha.Click += new EventHandler(this.btnRegCaptcha_Click);
    componentResourceManager.ApplyResources((object) this, "$this");
    this.AutoScaleMode = AutoScaleMode.Font;
    this.Controls.Add((Control) this.lblTermLink);
    this.Controls.Add((Control) this.cboxTerms);
    this.Controls.Add((Control) this.btnDoReg);
    this.Controls.Add((Control) this.grpInfo);
    this.FormBorderStyle = FormBorderStyle.FixedSingle;
    this.MaximizeBox = false;
    this.MinimizeBox = false;
    this.Name = nameof (frmReg);
    this.ShowIcon = false;
    this.ShowInTaskbar = false;
    this.TopMost = true;
    this.FormClosed += new FormClosedEventHandler(this.frmReg_FormClosed);
    this.Load += new EventHandler(this.frmReg_Load);
    this.grpInfo.ResumeLayout(false);
    this.grpInfo.PerformLayout();
    ((ISupportInitialize) this.picCaptcha).EndInit();
    this.ResumeLayout(false);
    this.PerformLayout();
  }
}
