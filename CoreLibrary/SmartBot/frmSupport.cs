// Decompiled with JetBrains decompiler
// Type: SmartBot.frmSupport
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace SmartBot;

public class frmSupport : Form
{
  private IContainer components;
  private Button btnOKPassword;
  private TextBox txtSupportPassword;

  public frmSupport() => this.InitializeComponent();

  private void frmSupport_Load(object sender, EventArgs e)
  {
  }

  private void btnOKPassword_Click(object sender, EventArgs e)
  {
    if (!string.IsNullOrEmpty(this.txtSupportPassword.Text) && this.txtSupportPassword.Text == "messner")
      frmLogin.GAuto.Settings.ShowSupportLog = true;
    this.Dispose();
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.components != null)
      this.components.Dispose();
    base.Dispose(disposing);
  }

  private void InitializeComponent()
  {
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmSupport));
    this.btnOKPassword = new Button();
    this.txtSupportPassword = new TextBox();
    this.SuspendLayout();
    componentResourceManager.ApplyResources((object) this.btnOKPassword, "btnOKPassword");
    this.btnOKPassword.Name = "btnOKPassword";
    this.btnOKPassword.UseVisualStyleBackColor = true;
    this.btnOKPassword.Click += new EventHandler(this.btnOKPassword_Click);
    componentResourceManager.ApplyResources((object) this.txtSupportPassword, "txtSupportPassword");
    this.txtSupportPassword.BorderStyle = BorderStyle.FixedSingle;
    this.txtSupportPassword.Name = "txtSupportPassword";
    this.txtSupportPassword.UseSystemPasswordChar = true;
    componentResourceManager.ApplyResources((object) this, "$this");
    this.AutoScaleMode = AutoScaleMode.Font;
    this.Controls.Add((Control) this.btnOKPassword);
    this.Controls.Add((Control) this.txtSupportPassword);
    this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
    this.Name = nameof (frmSupport);
    this.Load += new EventHandler(this.frmSupport_Load);
    this.ResumeLayout(false);
    this.PerformLayout();
  }
}
