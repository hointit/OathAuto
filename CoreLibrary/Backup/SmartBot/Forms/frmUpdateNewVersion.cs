// Decompiled with JetBrains decompiler
// Type: SmartBot.Forms.frmUpdateNewVersion
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using GAuto_Auto_None.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace SmartBot.Forms;

public class frmUpdateNewVersion : Form
{
  public static bool UpdateResult;
  private IContainer components;
  private Label label1;
  private PictureBox pictureBox1;
  private Button btnGetCurrentPos;
  private Button button1;
  private Button button2;

  public frmUpdateNewVersion() => this.InitializeComponent();

  private void btnGetCurrentPos_Click(object sender, EventArgs e) => GA.BrowseWhatsNew();

  private void button2_Click(object sender, EventArgs e) => this.Close();

  private void button1_Click(object sender, EventArgs e)
  {
    frmUpdateNewVersion.UpdateResult = true;
    GA.ExitAndCleanup();
    this.Close();
  }

  private void label2_Click(object sender, EventArgs e)
  {
  }

  private void frmUpdateNewVersion_Load(object sender, EventArgs e)
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
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmUpdateNewVersion));
    this.label1 = new Label();
    this.btnGetCurrentPos = new Button();
    this.button1 = new Button();
    this.button2 = new Button();
    this.pictureBox1 = new PictureBox();
    ((ISupportInitialize) this.pictureBox1).BeginInit();
    this.SuspendLayout();
    componentResourceManager.ApplyResources((object) this.label1, "label1");
    this.label1.Name = "label1";
    componentResourceManager.ApplyResources((object) this.btnGetCurrentPos, "btnGetCurrentPos");
    this.btnGetCurrentPos.Name = "btnGetCurrentPos";
    this.btnGetCurrentPos.UseVisualStyleBackColor = true;
    this.btnGetCurrentPos.Click += new EventHandler(this.btnGetCurrentPos_Click);
    componentResourceManager.ApplyResources((object) this.button1, "button1");
    this.button1.BackColor = Color.PaleGreen;
    this.button1.Name = "button1";
    this.button1.UseVisualStyleBackColor = false;
    this.button1.Click += new EventHandler(this.button1_Click);
    componentResourceManager.ApplyResources((object) this.button2, "button2");
    this.button2.Name = "button2";
    this.button2.UseVisualStyleBackColor = true;
    this.button2.Click += new EventHandler(this.button2_Click);
    componentResourceManager.ApplyResources((object) this.pictureBox1, "pictureBox1");
    this.pictureBox1.ErrorImage = (Image) Resources.info1;
    this.pictureBox1.Image = (Image) Resources.info1;
    this.pictureBox1.Name = "pictureBox1";
    this.pictureBox1.TabStop = false;
    componentResourceManager.ApplyResources((object) this, "$this");
    this.AutoScaleMode = AutoScaleMode.Font;
    this.Controls.Add((Control) this.button2);
    this.Controls.Add((Control) this.button1);
    this.Controls.Add((Control) this.btnGetCurrentPos);
    this.Controls.Add((Control) this.pictureBox1);
    this.Controls.Add((Control) this.label1);
    this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
    this.Name = nameof (frmUpdateNewVersion);
    this.ShowIcon = false;
    this.Load += new EventHandler(this.frmUpdateNewVersion_Load);
    ((ISupportInitialize) this.pictureBox1).EndInit();
    this.ResumeLayout(false);
    this.PerformLayout();
  }
}
