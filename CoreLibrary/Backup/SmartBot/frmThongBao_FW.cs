// Decompiled with JetBrains decompiler
// Type: SmartBot.frmThongBao_FW
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace SmartBot;

public class frmThongBao_FW : Form
{
  public static int ExitAuto;
  public static frmThongBao_FW frmThongBaoInstance;
  public static long startStamp;
  public long remainMS;
  public int DelayInMS = 5000;
  public BGMessageButtons msgButtons;
  private IContainer components;
  private Button btnYes;
  public Timer timer1;
  private Label label2;
  public Label lblSeconds;
  public Label lblContent;

  public frmThongBao_FW() => this.InitializeComponent();

  private void frmThongBao_FW_Load(object sender, EventArgs e) => this.TopMost = true;

  private void timer1_Tick(object sender, EventArgs e)
  {
    if (frmLogin.GlobalTimer.ElapsedMilliseconds > frmThongBao_FW.startStamp)
    {
      this.CloseThisForm();
    }
    else
    {
      this.remainMS = Math.Abs(frmLogin.GlobalTimer.ElapsedMilliseconds - frmThongBao_FW.startStamp) / 1000L;
      if (this.remainMS <= 5L)
        this.lblSeconds.ForeColor = Color.Red;
      this.lblSeconds.Text = this.remainMS.ToString("00") + " giây";
    }
  }

  private void CloseThisForm()
  {
    this.Close();
    frmThongBao_FW.frmThongBaoInstance = (frmThongBao_FW) null;
    frmThongBao_FW.startStamp = 0L;
  }

  private void btnYes_Click(object sender, EventArgs e) => this.CloseThisForm();

  private void frmThongBao_FW_FormClosed(object sender, FormClosedEventArgs e)
  {
    frmThongBao_FW.frmThongBaoInstance = (frmThongBao_FW) null;
    frmThongBao_FW.startStamp = 0L;
    if (frmThongBao_FW.ExitAuto == 1)
      SmartClass.ForceExitAuto();
    if (frmThongBao_FW.ExitAuto != 2)
      return;
    frmLogin.flagIsKicked = true;
    SmartClass.ForceExitAuto();
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
    this.lblContent = new Label();
    this.btnYes = new Button();
    this.timer1 = new Timer(this.components);
    this.label2 = new Label();
    this.lblSeconds = new Label();
    this.SuspendLayout();
    this.lblContent.Location = new Point(12, 10);
    this.lblContent.Name = "lblContent";
    this.lblContent.Size = new Size(315, 138);
    this.lblContent.TabIndex = 0;
    this.lblContent.Text = "Nội dung thông báo";
    this.btnYes.Location = new Point(254, 151);
    this.btnYes.Name = "btnYes";
    this.btnYes.Size = new Size(75, 23);
    this.btnYes.TabIndex = 1;
    this.btnYes.Text = "Đóng";
    this.btnYes.UseVisualStyleBackColor = true;
    this.btnYes.Click += new EventHandler(this.btnYes_Click);
    this.timer1.Interval = 400;
    this.timer1.Tick += new EventHandler(this.timer1_Tick);
    this.label2.AutoSize = true;
    this.label2.Location = new Point(13, 151);
    this.label2.Name = "label2";
    this.label2.Size = new Size(92, 13);
    this.label2.TabIndex = 2;
    this.label2.Text = "Bảng tự đóng sau";
    this.lblSeconds.AutoSize = true;
    this.lblSeconds.Location = new Point(37, 169);
    this.lblSeconds.Name = "lblSeconds";
    this.lblSeconds.Size = new Size(35, 13);
    this.lblSeconds.TabIndex = 3;
    this.lblSeconds.Text = "label3";
    this.AutoScaleDimensions = new SizeF(6f, 13f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.ClientSize = new Size(339, 182);
    this.Controls.Add((Control) this.lblSeconds);
    this.Controls.Add((Control) this.label2);
    this.Controls.Add((Control) this.btnYes);
    this.Controls.Add((Control) this.lblContent);
    this.FormBorderStyle = FormBorderStyle.FixedSingle;
    this.MaximizeBox = false;
    this.MaximumSize = new Size(355, 220);
    this.MinimumSize = new Size(355, 220);
    this.Name = nameof (frmThongBao_FW);
    this.ShowIcon = false;
    this.StartPosition = FormStartPosition.CenterScreen;
    this.Text = "Thông báo";
    this.FormClosed += new FormClosedEventHandler(this.frmThongBao_FW_FormClosed);
    this.Load += new EventHandler(this.frmThongBao_FW_Load);
    this.ResumeLayout(false);
    this.PerformLayout();
  }
}
