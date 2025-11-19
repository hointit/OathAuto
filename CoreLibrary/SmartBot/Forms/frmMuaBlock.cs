// Decompiled with JetBrains decompiler
// Type: SmartBot.Forms.frmMuaBlock
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace SmartBot.Forms;

public class frmMuaBlock : Form
{
  private IContainer components;
  private GroupBox groupBox1;
  private Label label1;
  private Label lblAccountName;
  private Label lblGGBalance;
  private RadioButton rdio_360_day;
  private RadioButton rdio_180_day;
  private RadioButton rdio_90_day;
  private RadioButton rdio_30_day;
  private RadioButton rdio_6_day;
  private RadioButton rdio_1_day;
  private Button btnMuaBlock;
  private RadioButton rdio_9999_day;
  private Label label2;

  public frmMuaBlock() => this.InitializeComponent();

  private void frmMuaBlock_Load(object sender, EventArgs e)
  {
  }

  private void frmMuaBlock_Shown(object sender, EventArgs e) => this.DisplayMyForm();

  public void DisplayMyForm()
  {
    this.lblAccountName.Text = string.Format(frmMain.langMuaBlockAccount, (object) frmLogin.GAuto.Settings.Account.Username);
    this.lblGGBalance.Text = string.Format(frmMain.langMuaBlockBalance, (object) frmLogin.GAuto.Settings.Account.RemainGGoldBalance.ToString("0"), (object) frmLogin.GAuto.Settings.Account.RemainGGoldPromo.ToString("0"));
    string str = "ngày";
    switch (frmLogin.CompilingLanguage)
    {
      case "EN":
        str = "days";
        break;
      case "CN":
        str = "天";
        break;
    }
    this.rdio_1_day.Text = $"1 {str} - {frmLogin.GAuto.Settings.BangGia["price_1"]} GG";
    if (frmLogin.CompilingLanguage == "EN")
      str = "days";
    this.rdio_6_day.Text = $"6 {str} - {frmLogin.GAuto.Settings.BangGia["price_6"]} GG";
    this.rdio_30_day.Text = $"30 {str} - {frmLogin.GAuto.Settings.BangGia["price_30"]} GG";
    this.rdio_90_day.Text = $"90 {str} - {frmLogin.GAuto.Settings.BangGia["price_90"]} GG";
    this.rdio_180_day.Text = $"180 {str} - {frmLogin.GAuto.Settings.BangGia["price_180"]} GG";
    this.rdio_360_day.Text = $"360 {str} - {frmLogin.GAuto.Settings.BangGia["price_360"]} GG";
    this.rdio_9999_day.Text = $"Lifetime - {frmLogin.GAuto.Settings.BangGia["price_9999"]} GG";
  }

  private void btnMuaBlock_Click(object sender, EventArgs e)
  {
    int num1 = 1;
    int num2 = 30;
    if (this.rdio_1_day.Checked)
    {
      num1 = 1;
      num2 = frmLogin.GAuto.Settings.BangGia["price_1"];
    }
    else if (this.rdio_6_day.Checked)
    {
      num1 = 6;
      num2 = frmLogin.GAuto.Settings.BangGia["price_6"];
    }
    else if (this.rdio_30_day.Checked)
    {
      num1 = 30;
      num2 = frmLogin.GAuto.Settings.BangGia["price_30"];
    }
    else if (this.rdio_90_day.Checked)
    {
      num1 = 90;
      num2 = frmLogin.GAuto.Settings.BangGia["price_90"];
    }
    else if (this.rdio_180_day.Checked)
    {
      num1 = 180;
      num2 = frmLogin.GAuto.Settings.BangGia["price_180"];
    }
    else if (this.rdio_360_day.Checked)
    {
      num1 = 360;
      num2 = frmLogin.GAuto.Settings.BangGia["price_360"];
    }
    else if (this.rdio_9999_day.Checked)
    {
      num1 = 9999;
      num2 = frmLogin.GAuto.Settings.BangGia["price_9999"];
    }
    if (MessageBox.Show(string.Format(frmMain.langBuyHours, (object) num1.ToString(), (object) num2.ToString()), frmMain.langBuyHoursTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
      return;
    frmLogin.GAuto.Settings.Account.BuyBlockDays = (object) num1;
    string version = "";
    string myMessage = "";
    GA.SendKeepAlivePHP(out version, out myMessage);
    this.DisplayMyForm();
    int num3 = (int) MessageBox.Show(myMessage, frmMain.langCheckBlockHourTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
    if (!myMessage.Contains("successfully.") && !myMessage.Contains("thành công.") && !myMessage.Contains("购买成功"))
      return;
    this.Close();
  }

  private void frmMuaBlock_FormClosing(object sender, FormClosingEventArgs e)
  {
    e.Cancel = true;
    this.Hide();
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.components != null)
      this.components.Dispose();
    base.Dispose(disposing);
  }

  private void InitializeComponent()
  {
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmMuaBlock));
    this.groupBox1 = new GroupBox();
    this.rdio_9999_day = new RadioButton();
    this.rdio_360_day = new RadioButton();
    this.rdio_180_day = new RadioButton();
    this.rdio_90_day = new RadioButton();
    this.rdio_30_day = new RadioButton();
    this.rdio_6_day = new RadioButton();
    this.rdio_1_day = new RadioButton();
    this.label1 = new Label();
    this.lblAccountName = new Label();
    this.lblGGBalance = new Label();
    this.btnMuaBlock = new Button();
    this.label2 = new Label();
    this.groupBox1.SuspendLayout();
    this.SuspendLayout();
    componentResourceManager.ApplyResources((object) this.groupBox1, "groupBox1");
    this.groupBox1.Controls.Add((Control) this.rdio_9999_day);
    this.groupBox1.Controls.Add((Control) this.rdio_360_day);
    this.groupBox1.Controls.Add((Control) this.rdio_180_day);
    this.groupBox1.Controls.Add((Control) this.rdio_90_day);
    this.groupBox1.Controls.Add((Control) this.rdio_30_day);
    this.groupBox1.Controls.Add((Control) this.rdio_6_day);
    this.groupBox1.Controls.Add((Control) this.rdio_1_day);
    this.groupBox1.Name = "groupBox1";
    this.groupBox1.TabStop = false;
    componentResourceManager.ApplyResources((object) this.rdio_9999_day, "rdio_9999_day");
    this.rdio_9999_day.Name = "rdio_9999_day";
    this.rdio_9999_day.TabStop = true;
    this.rdio_9999_day.UseVisualStyleBackColor = true;
    componentResourceManager.ApplyResources((object) this.rdio_360_day, "rdio_360_day");
    this.rdio_360_day.Name = "rdio_360_day";
    this.rdio_360_day.TabStop = true;
    this.rdio_360_day.UseVisualStyleBackColor = true;
    componentResourceManager.ApplyResources((object) this.rdio_180_day, "rdio_180_day");
    this.rdio_180_day.Name = "rdio_180_day";
    this.rdio_180_day.TabStop = true;
    this.rdio_180_day.UseVisualStyleBackColor = true;
    componentResourceManager.ApplyResources((object) this.rdio_90_day, "rdio_90_day");
    this.rdio_90_day.Name = "rdio_90_day";
    this.rdio_90_day.TabStop = true;
    this.rdio_90_day.UseVisualStyleBackColor = true;
    componentResourceManager.ApplyResources((object) this.rdio_30_day, "rdio_30_day");
    this.rdio_30_day.Name = "rdio_30_day";
    this.rdio_30_day.TabStop = true;
    this.rdio_30_day.UseVisualStyleBackColor = true;
    componentResourceManager.ApplyResources((object) this.rdio_6_day, "rdio_6_day");
    this.rdio_6_day.Name = "rdio_6_day";
    this.rdio_6_day.TabStop = true;
    this.rdio_6_day.UseVisualStyleBackColor = true;
    componentResourceManager.ApplyResources((object) this.rdio_1_day, "rdio_1_day");
    this.rdio_1_day.Name = "rdio_1_day";
    this.rdio_1_day.TabStop = true;
    this.rdio_1_day.UseVisualStyleBackColor = true;
    componentResourceManager.ApplyResources((object) this.label1, "label1");
    this.label1.Name = "label1";
    componentResourceManager.ApplyResources((object) this.lblAccountName, "lblAccountName");
    this.lblAccountName.Name = "lblAccountName";
    componentResourceManager.ApplyResources((object) this.lblGGBalance, "lblGGBalance");
    this.lblGGBalance.Name = "lblGGBalance";
    componentResourceManager.ApplyResources((object) this.btnMuaBlock, "btnMuaBlock");
    this.btnMuaBlock.BackColor = Color.FromArgb(210, 249, 213);
    this.btnMuaBlock.ForeColor = Color.DarkGreen;
    this.btnMuaBlock.Name = "btnMuaBlock";
    this.btnMuaBlock.UseVisualStyleBackColor = false;
    this.btnMuaBlock.Click += new EventHandler(this.btnMuaBlock_Click);
    componentResourceManager.ApplyResources((object) this.label2, "label2");
    this.label2.Name = "label2";
    componentResourceManager.ApplyResources((object) this, "$this");
    this.AutoScaleMode = AutoScaleMode.Font;
    this.Controls.Add((Control) this.label2);
    this.Controls.Add((Control) this.btnMuaBlock);
    this.Controls.Add((Control) this.lblGGBalance);
    this.Controls.Add((Control) this.lblAccountName);
    this.Controls.Add((Control) this.label1);
    this.Controls.Add((Control) this.groupBox1);
    this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
    this.MaximizeBox = false;
    this.Name = nameof (frmMuaBlock);
    this.FormClosing += new FormClosingEventHandler(this.frmMuaBlock_FormClosing);
    this.Load += new EventHandler(this.frmMuaBlock_Load);
    this.Shown += new EventHandler(this.frmMuaBlock_Shown);
    this.groupBox1.ResumeLayout(false);
    this.groupBox1.PerformLayout();
    this.ResumeLayout(false);
    this.PerformLayout();
  }
}
