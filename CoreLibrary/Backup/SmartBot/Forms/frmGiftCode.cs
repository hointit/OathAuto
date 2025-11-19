// Decompiled with JetBrains decompiler
// Type: SmartBot.Forms.frmGiftCode
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using GAuto_Auto_None.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Security;
using System.Text;
using System.Web;
using System.Windows.Forms;

#nullable disable
namespace SmartBot.Forms;

public class frmGiftCode : Form
{
  public AutoAccount myAccount;
  private SecureString myCaptcha = new SecureString();
  private IContainer components;
  private Label label1;
  private RadioButton rdioGGold;
  private RadioButton rdioTien;
  private Label lblLoaiTK;
  private Label label6;
  private TextBox txtGiftCode;
  private Label lblCaptcha3;
  private Label lblStatus;
  private Button btnNapThe;
  private Button btnHuy;
  private Button btnCaptcha;
  private Label lblCaptcha;
  private TextBox txtCaptcha;
  private PictureBox picCaptcha;
  private Timer timer1;
  private Label label2;
  private TextBox txtUsername;

  public frmGiftCode() => this.InitializeComponent();

  private void btnHuy_Click(object sender, EventArgs e) => this.Close();

  private void timer1_Tick(object sender, EventArgs e)
  {
  }

  private void btnNapThe_Click(object sender, EventArgs e)
  {
    if (this.rdioTien.Checked || this.rdioGGold.Checked)
    {
      bool flag = false;
      if (this.picCaptcha.Visible)
      {
        if (GA.SecureStringToString(this.myCaptcha).ToLower() == this.txtCaptcha.Text.ToLower())
          flag = true;
        this.txtCaptcha.Text = "";
        GC.Collect();
      }
      else if (frmLogin.GAuto.Settings.GiftCodeCaptchas < 3)
        flag = true;
      if (flag)
      {
        if (!string.IsNullOrEmpty(this.txtGiftCode.Text) && !string.IsNullOrEmpty(this.txtUsername.Text))
        {
          string data = $"giftcode={HttpUtility.UrlEncode(this.txtGiftCode.Text)}&giftuser={HttpUtility.UrlEncode(this.txtUsername.Text)}&giftid={HttpUtility.UrlEncode(frmLogin.GAuto.Settings.Account.UniqueSessionID)}&giftmode={HttpUtility.UrlEncode(this.rdioTien.Checked ? "ss" : "gg")}";
          string str1 = !(frmLogin.CompilingLanguage == "VN") ? GA.LoadWeb(frmLogin.GAuto.Settings.GiftCodeURL, data, "POST", frmLogin.GAuto.Settings.MainCookie) : GA.LoadWeb(frmLogin.MainGAutoServer.URL + frmLogin.GAuto.Settings.GiftCodeURL, data, "POST", frmLogin.GAuto.Settings.MainCookie);
          if (str1 != frmLogin.GAuto.Settings.LoadWebErrorMessage)
          {
            string str2 = HttpUtility.UrlDecode(str1);
            try
            {
              str2 = Encoding.UTF8.GetString(Convert.FromBase64String(str2));
            }
            catch (Exception ex)
            {
              this.lblStatus.Text = string.Format("Error decrypting data.");
              this.lblStatus.ForeColor = Color.Red;
            }
            string str3 = GA.GetMyField(str2, "gmessage");
            if (str3.Contains("%2"))
              str3 = HttpUtility.UrlDecode(str3);
            if (!str3.EndsWith("="))
            {
              if (str3.Contains(" "))
                goto label_19;
            }
            try
            {
              str3 = Encoding.UTF8.GetString(Convert.FromBase64String(str3));
            }
            catch (Exception ex)
            {
              this.lblStatus.Text = string.Format("Error decrypting data.");
              this.lblStatus.ForeColor = Color.Red;
            }
label_19:
            if (str3.Contains("someone else") || str3.Contains("đã sử dụng"))
              ++frmLogin.GAuto.Settings.GiftCodeCaptchas;
            if (str3.Contains("Great!") || str3.Contains("Đã cộng") || str3.Contains("Added "))
            {
              frmLogin.GAuto.Settings.GiftCodeCaptchas = 0;
              string version = "";
              string myMessage = "";
              GA.SendKeepAlivePHP(out version, out myMessage);
            }
            this.lblStatus.Text = $"{frmMain.langStatus}: {string.Format(str3)}";
            this.lblStatus.ForeColor = Color.Blue;
          }
          else
          {
            this.lblStatus.Text = string.Format("Error connecting to the auto server.");
            this.lblStatus.ForeColor = Color.Red;
          }
        }
      }
      else
      {
        int num = (int) MessageBox.Show(frmMain.langCaptchaRequired, "Captcha", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      if (frmLogin.GAuto.Settings.GiftCodeCaptchas >= 3)
      {
        if (!this.picCaptcha.Visible)
          this.AdjustForm(true);
        this.GenNewCaptcha();
      }
    }
    if (this.rdioTien.Checked || this.rdioGGold.Checked)
      return;
    this.rdioTien.ForeColor = Color.Red;
    this.rdioGGold.ForeColor = Color.Red;
    int num1 = (int) MessageBox.Show(frmMain.langCharging, frmMain.langChargingTitle, MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
    this.btnHuy.Top += num;
    this.btnNapThe.Top += num;
    this.btnCaptcha.Visible = flag1;
    this.picCaptcha.Visible = flag1;
    this.lblCaptcha.Visible = flag1;
    this.txtCaptcha.Visible = flag1;
    this.lblCaptcha3.Visible = flag1;
  }

  private void GenNewCaptcha()
  {
    this.myCaptcha = GA.ConvertToSecureString(GA.GenerateRandomName(6));
    GC.Collect();
    this.picCaptcha.Image = (Image) GA.GenerateCaptcha(this.myCaptcha);
  }

  private void frmGiftCode_Load(object sender, EventArgs e)
  {
    if (frmLogin.GAuto.Settings.GiftCodeCaptchas < 3)
    {
      this.AdjustForm(false);
    }
    else
    {
      this.AdjustForm(true);
      this.GenNewCaptcha();
    }
  }

  private void btnCaptcha_Click(object sender, EventArgs e) => this.GenNewCaptcha();

  private void txtGiftCode_TextChanged(object sender, EventArgs e)
  {
    if (string.IsNullOrEmpty(this.txtGiftCode.Text))
    {
      this.rdioGGold.Enabled = false;
      this.rdioTien.Checked = true;
    }
    else if (this.txtGiftCode.Text.Contains("-PRO-"))
    {
      this.rdioGGold.Enabled = true;
    }
    else
    {
      this.rdioGGold.Enabled = false;
      this.rdioTien.Checked = true;
    }
  }

  private void frmGiftCode_Shown(object sender, EventArgs e)
  {
    if (frmLogin.GAuto.Settings.Account == null)
      return;
    this.txtUsername.Text = frmLogin.GAuto.Settings.Account.Username;
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
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmGiftCode));
    this.label1 = new Label();
    this.rdioGGold = new RadioButton();
    this.rdioTien = new RadioButton();
    this.lblLoaiTK = new Label();
    this.label6 = new Label();
    this.txtGiftCode = new TextBox();
    this.lblCaptcha3 = new Label();
    this.lblStatus = new Label();
    this.btnNapThe = new Button();
    this.btnHuy = new Button();
    this.lblCaptcha = new Label();
    this.txtCaptcha = new TextBox();
    this.timer1 = new Timer(this.components);
    this.btnCaptcha = new Button();
    this.picCaptcha = new PictureBox();
    this.label2 = new Label();
    this.txtUsername = new TextBox();
    ((ISupportInitialize) this.picCaptcha).BeginInit();
    this.SuspendLayout();
    componentResourceManager.ApplyResources((object) this.label1, "label1");
    this.label1.Name = "label1";
    componentResourceManager.ApplyResources((object) this.rdioGGold, "rdioGGold");
    this.rdioGGold.ForeColor = Color.Black;
    this.rdioGGold.Name = "rdioGGold";
    this.rdioGGold.UseVisualStyleBackColor = true;
    componentResourceManager.ApplyResources((object) this.rdioTien, "rdioTien");
    this.rdioTien.ForeColor = Color.Black;
    this.rdioTien.Name = "rdioTien";
    this.rdioTien.UseVisualStyleBackColor = true;
    componentResourceManager.ApplyResources((object) this.lblLoaiTK, "lblLoaiTK");
    this.lblLoaiTK.Name = "lblLoaiTK";
    componentResourceManager.ApplyResources((object) this.label6, "label6");
    this.label6.Name = "label6";
    componentResourceManager.ApplyResources((object) this.txtGiftCode, "txtGiftCode");
    this.txtGiftCode.BorderStyle = BorderStyle.FixedSingle;
    this.txtGiftCode.Name = "txtGiftCode";
    this.txtGiftCode.TextChanged += new EventHandler(this.txtGiftCode_TextChanged);
    componentResourceManager.ApplyResources((object) this.lblCaptcha3, "lblCaptcha3");
    this.lblCaptcha3.BackColor = Color.Transparent;
    this.lblCaptcha3.ForeColor = Color.SteelBlue;
    this.lblCaptcha3.Name = "lblCaptcha3";
    componentResourceManager.ApplyResources((object) this.lblStatus, "lblStatus");
    this.lblStatus.Name = "lblStatus";
    componentResourceManager.ApplyResources((object) this.btnNapThe, "btnNapThe");
    this.btnNapThe.BackColor = Color.FromArgb(210, 249, 213);
    this.btnNapThe.ForeColor = Color.DarkGreen;
    this.btnNapThe.Name = "btnNapThe";
    this.btnNapThe.UseVisualStyleBackColor = false;
    this.btnNapThe.Click += new EventHandler(this.btnNapThe_Click);
    componentResourceManager.ApplyResources((object) this.btnHuy, "btnHuy");
    this.btnHuy.BackColor = Color.FromArgb(247, 207, 142);
    this.btnHuy.ForeColor = Color.SaddleBrown;
    this.btnHuy.Name = "btnHuy";
    this.btnHuy.UseVisualStyleBackColor = false;
    this.btnHuy.Click += new EventHandler(this.btnHuy_Click);
    componentResourceManager.ApplyResources((object) this.lblCaptcha, "lblCaptcha");
    this.lblCaptcha.BackColor = Color.Transparent;
    this.lblCaptcha.Name = "lblCaptcha";
    componentResourceManager.ApplyResources((object) this.txtCaptcha, "txtCaptcha");
    this.txtCaptcha.BorderStyle = BorderStyle.FixedSingle;
    this.txtCaptcha.Name = "txtCaptcha";
    this.timer1.Enabled = true;
    this.timer1.Interval = 300;
    this.timer1.Tick += new EventHandler(this.timer1_Tick);
    componentResourceManager.ApplyResources((object) this.btnCaptcha, "btnCaptcha");
    this.btnCaptcha.ForeColor = Color.DodgerBlue;
    this.btnCaptcha.Image = (Image) Resources.Refresh_icon;
    this.btnCaptcha.Name = "btnCaptcha";
    this.btnCaptcha.UseVisualStyleBackColor = true;
    this.btnCaptcha.Click += new EventHandler(this.btnCaptcha_Click);
    componentResourceManager.ApplyResources((object) this.picCaptcha, "picCaptcha");
    this.picCaptcha.BorderStyle = BorderStyle.FixedSingle;
    this.picCaptcha.Name = "picCaptcha";
    this.picCaptcha.TabStop = false;
    componentResourceManager.ApplyResources((object) this.label2, "label2");
    this.label2.Name = "label2";
    componentResourceManager.ApplyResources((object) this.txtUsername, "txtUsername");
    this.txtUsername.BorderStyle = BorderStyle.FixedSingle;
    this.txtUsername.Name = "txtUsername";
    componentResourceManager.ApplyResources((object) this, "$this");
    this.AutoScaleMode = AutoScaleMode.Font;
    this.Controls.Add((Control) this.label2);
    this.Controls.Add((Control) this.txtUsername);
    this.Controls.Add((Control) this.label1);
    this.Controls.Add((Control) this.rdioGGold);
    this.Controls.Add((Control) this.rdioTien);
    this.Controls.Add((Control) this.lblLoaiTK);
    this.Controls.Add((Control) this.label6);
    this.Controls.Add((Control) this.txtGiftCode);
    this.Controls.Add((Control) this.lblCaptcha3);
    this.Controls.Add((Control) this.lblStatus);
    this.Controls.Add((Control) this.btnNapThe);
    this.Controls.Add((Control) this.btnHuy);
    this.Controls.Add((Control) this.btnCaptcha);
    this.Controls.Add((Control) this.lblCaptcha);
    this.Controls.Add((Control) this.txtCaptcha);
    this.Controls.Add((Control) this.picCaptcha);
    this.Name = nameof (frmGiftCode);
    this.Load += new EventHandler(this.frmGiftCode_Load);
    this.Shown += new EventHandler(this.frmGiftCode_Shown);
    ((ISupportInitialize) this.picCaptcha).EndInit();
    this.ResumeLayout(false);
    this.PerformLayout();
  }
}
