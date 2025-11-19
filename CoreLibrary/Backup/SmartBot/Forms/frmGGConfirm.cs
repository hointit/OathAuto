// Decompiled with JetBrains decompiler
// Type: SmartBot.Forms.frmGGConfirm
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace SmartBot.Forms;

public class frmGGConfirm : Form
{
  public string textQuestion = frmMain.langAccountInUse;
  private IContainer components;
  private Label lblContent;
  private Label label1;
  private TextBox tboxConfirm;
  private Button btnConfirm;
  private Button btnExit;

  public frmGGConfirm() => this.InitializeComponent();

  private void btnExit_Click(object sender, EventArgs e)
  {
    frmLogin.GAuto.ConfirmBoxResult = DialogResult.No;
    this.Close();
  }

  private void tboxConfirm_TextChanged(object sender, EventArgs e)
  {
    if (this.tboxConfirm.Text.ToLower() == "ok")
      this.btnConfirm.Enabled = true;
    else
      this.btnConfirm.Enabled = false;
  }

  private void btnConfirm_Click(object sender, EventArgs e)
  {
    if (this.tboxConfirm.Text.ToLower() != "ok")
    {
      int num = (int) MessageBox.Show(frmMain.langNeedOK, frmMain.langNeedConfirm, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
    }
    else
    {
      frmLogin.GAuto.ConfirmBoxResult = DialogResult.Yes;
      this.Close();
    }
  }

  private void frmGGConfirm_Shown(object sender, EventArgs e)
  {
    this.lblContent.Text = this.textQuestion;
  }

  private void frmGGConfirm_Load(object sender, EventArgs e)
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
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmGGConfirm));
    this.lblContent = new Label();
    this.label1 = new Label();
    this.tboxConfirm = new TextBox();
    this.btnConfirm = new Button();
    this.btnExit = new Button();
    this.SuspendLayout();
    componentResourceManager.ApplyResources((object) this.lblContent, "lblContent");
    this.lblContent.ForeColor = Color.Red;
    this.lblContent.Name = "lblContent";
    componentResourceManager.ApplyResources((object) this.label1, "label1");
    this.label1.Name = "label1";
    componentResourceManager.ApplyResources((object) this.tboxConfirm, "tboxConfirm");
    this.tboxConfirm.BackColor = Color.LightGreen;
    this.tboxConfirm.Name = "tboxConfirm";
    this.tboxConfirm.TextChanged += new EventHandler(this.tboxConfirm_TextChanged);
    componentResourceManager.ApplyResources((object) this.btnConfirm, "btnConfirm");
    this.btnConfirm.Name = "btnConfirm";
    this.btnConfirm.UseVisualStyleBackColor = true;
    this.btnConfirm.Click += new EventHandler(this.btnConfirm_Click);
    componentResourceManager.ApplyResources((object) this.btnExit, "btnExit");
    this.btnExit.Name = "btnExit";
    this.btnExit.UseVisualStyleBackColor = true;
    this.btnExit.Click += new EventHandler(this.btnExit_Click);
    componentResourceManager.ApplyResources((object) this, "$this");
    this.AutoScaleMode = AutoScaleMode.Font;
    this.Controls.Add((Control) this.btnExit);
    this.Controls.Add((Control) this.btnConfirm);
    this.Controls.Add((Control) this.tboxConfirm);
    this.Controls.Add((Control) this.label1);
    this.Controls.Add((Control) this.lblContent);
    this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
    this.Name = nameof (frmGGConfirm);
    this.ShowIcon = false;
    this.Load += new EventHandler(this.frmGGConfirm_Load);
    this.Shown += new EventHandler(this.frmGGConfirm_Shown);
    this.ResumeLayout(false);
    this.PerformLayout();
  }
}
