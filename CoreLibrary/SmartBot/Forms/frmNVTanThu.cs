// Decompiled with JetBrains decompiler
// Type: SmartBot.Forms.frmNVTanThu
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace SmartBot.Forms;

public class frmNVTanThu : Form
{
  public AutoAccount myAccount;
  private IContainer components;
  private CheckBox cboxTanThu;
  private Button btnDanhCo;
  private Button btnAcTac;
  private Button btnAcBa;
  private Timer timer1;

  public frmNVTanThu() => this.InitializeComponent();

  private void frmNVTanThu_Load(object sender, EventArgs e)
  {
  }

  private void timer1_Tick(object sender, EventArgs e)
  {
    if (this.myAccount == null)
      return;
    this.cboxTanThu.Checked = this.myAccount.Myself.isTanThu;
  }

  private void cboxTanThu_CheckedChanged(object sender, EventArgs e)
  {
    CheckBox checkBox = sender as CheckBox;
    if (this.myAccount == null || !checkBox.Focused)
      return;
    this.myAccount.Myself.isTanThu = checkBox.Checked;
  }

  private void frmNVTanThu_FormClosing(object sender, FormClosingEventArgs e)
  {
    e.Cancel = true;
    this.Hide();
  }

  private void btnDanhCo_Click(object sender, EventArgs e)
  {
    frmLogin.GAuto.CurrentAuto.Myself.QuestStep = 20;
    frmLogin.GAuto.CurrentAuto.MyFlag.counter = 0;
    if (frmLogin.GAuto.CurrentAuto.Myself.isTanThu)
      return;
    frmLogin.GAuto.CurrentAuto.MyFlag.DatLichFlag = true;
    frmMain.frmMainInstance.NVTanThu(frmLogin.GAuto.CurrentAuto);
  }

  private void btnAcTac_Click(object sender, EventArgs e)
  {
    frmLogin.GAuto.CurrentAuto.Myself.QuestStep = 22;
    frmLogin.GAuto.CurrentAuto.MyFlag.counter = 0;
    if (frmLogin.GAuto.CurrentAuto.Myself.isTanThu)
      return;
    frmLogin.GAuto.CurrentAuto.MyFlag.DatLichFlag = true;
    frmMain.frmMainInstance.NVTanThu(frmLogin.GAuto.CurrentAuto);
  }

  private void btnAcBa_Click(object sender, EventArgs e)
  {
    frmLogin.GAuto.CurrentAuto.Myself.QuestStep = 24;
    frmLogin.GAuto.CurrentAuto.MyFlag.counter = 0;
    if (frmLogin.GAuto.CurrentAuto.Myself.isTanThu)
      return;
    frmLogin.GAuto.CurrentAuto.MyFlag.DatLichFlag = true;
    frmMain.frmMainInstance.NVTanThu(frmLogin.GAuto.CurrentAuto);
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
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmNVTanThu));
    this.cboxTanThu = new CheckBox();
    this.btnDanhCo = new Button();
    this.btnAcTac = new Button();
    this.btnAcBa = new Button();
    this.timer1 = new Timer(this.components);
    this.SuspendLayout();
    componentResourceManager.ApplyResources((object) this.cboxTanThu, "cboxTanThu");
    this.cboxTanThu.Name = "cboxTanThu";
    this.cboxTanThu.UseVisualStyleBackColor = true;
    this.cboxTanThu.CheckedChanged += new EventHandler(this.cboxTanThu_CheckedChanged);
    componentResourceManager.ApplyResources((object) this.btnDanhCo, "btnDanhCo");
    this.btnDanhCo.Name = "btnDanhCo";
    this.btnDanhCo.UseVisualStyleBackColor = true;
    this.btnDanhCo.Click += new EventHandler(this.btnDanhCo_Click);
    componentResourceManager.ApplyResources((object) this.btnAcTac, "btnAcTac");
    this.btnAcTac.Name = "btnAcTac";
    this.btnAcTac.UseVisualStyleBackColor = true;
    this.btnAcTac.Click += new EventHandler(this.btnAcTac_Click);
    componentResourceManager.ApplyResources((object) this.btnAcBa, "btnAcBa");
    this.btnAcBa.Name = "btnAcBa";
    this.btnAcBa.UseVisualStyleBackColor = true;
    this.btnAcBa.Click += new EventHandler(this.btnAcBa_Click);
    this.timer1.Enabled = true;
    this.timer1.Interval = 300;
    this.timer1.Tick += new EventHandler(this.timer1_Tick);
    componentResourceManager.ApplyResources((object) this, "$this");
    this.AutoScaleMode = AutoScaleMode.Font;
    this.Controls.Add((Control) this.btnAcBa);
    this.Controls.Add((Control) this.btnAcTac);
    this.Controls.Add((Control) this.btnDanhCo);
    this.Controls.Add((Control) this.cboxTanThu);
    this.Name = nameof (frmNVTanThu);
    this.FormClosing += new FormClosingEventHandler(this.frmNVTanThu_FormClosing);
    this.Load += new EventHandler(this.frmNVTanThu_Load);
    this.ResumeLayout(false);
    this.PerformLayout();
  }
}
