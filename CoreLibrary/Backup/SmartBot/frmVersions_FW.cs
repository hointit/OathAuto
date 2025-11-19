// Decompiled with JetBrains decompiler
// Type: SmartBot.frmVersions_FW
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace SmartBot;

public class frmVersions_FW : Form
{
  public string toVersion = "";
  public bool optUpdate = true;
  public bool forceUpdate;
  private IContainer components;
  private Label lbUpdateText;
  private Panel panel1;
  private Button btnLater;
  private Button btnUpdate;
  private Panel panel2;
  private RichTextBox richVersion;

  public frmVersions_FW(bool showLater)
  {
    this.InitializeComponent();
    this.optUpdate = showLater;
    if (!showLater)
    {
      this.btnLater.Enabled = false;
      this.btnLater.Visible = false;
    }
    this.Text = GlobalSettings.GameName;
  }

  private void frmVersions_FW_Load(object sender, EventArgs e)
  {
    this.richVersion.Text = GA.GetUpdateLog(this.toVersion);
    if (!this.forceUpdate)
      return;
    this.lbUpdateText.Text = "Có phiên bản auto mới, bạn cần phải cập nhật.\n\n(Auto tự lưu lại bản hiện tại vào thư mục auto. Nếu phiên bản mới hoạt động không ổn định bạn có thể dùng lại bản cũ và báo lỗi cho Admin)\n\nBấm 'Cập nhật' để tải phiên bản mới.";
  }

  private void btnLater_Click(object sender, EventArgs e)
  {
    frmLogin.updateResult = 2;
    this.Close();
  }

  private void frmVersions_FW_FormClosed(object sender, FormClosedEventArgs e)
  {
    if (!this.optUpdate)
    {
      frmLogin.updateResult = 1;
    }
    else
    {
      if (frmLogin.updateResult != 0)
        return;
      frmLogin.updateResult = 2;
    }
  }

  private void btnUpdate_Click(object sender, EventArgs e)
  {
    frmLogin.updateResult = 1;
    this.Close();
  }

  private void frmVersions_FW_Shown(object sender, EventArgs e) => this.TopMost = true;

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.components != null)
      this.components.Dispose();
    base.Dispose(disposing);
  }

  private void InitializeComponent()
  {
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmVersions_FW));
    this.lbUpdateText = new Label();
    this.panel1 = new Panel();
    this.btnLater = new Button();
    this.btnUpdate = new Button();
    this.panel2 = new Panel();
    this.richVersion = new RichTextBox();
    this.panel1.SuspendLayout();
    this.panel2.SuspendLayout();
    this.SuspendLayout();
    this.lbUpdateText.Dock = DockStyle.Top;
    this.lbUpdateText.Location = new Point(0, 0);
    this.lbUpdateText.Margin = new Padding(5, 5, 3, 0);
    this.lbUpdateText.Name = "lbUpdateText";
    this.lbUpdateText.Padding = new Padding(5, 10, 0, 0);
    this.lbUpdateText.Size = new Size(517, 110);
    this.lbUpdateText.TabIndex = 0;
    this.lbUpdateText.Text = componentResourceManager.GetString("lbUpdateText.Text");
    this.panel1.Controls.Add((Control) this.btnLater);
    this.panel1.Controls.Add((Control) this.btnUpdate);
    this.panel1.Dock = DockStyle.Bottom;
    this.panel1.Location = new Point(0, 414);
    this.panel1.Name = "panel1";
    this.panel1.Size = new Size(517, 34);
    this.panel1.TabIndex = 2;
    this.btnLater.BackColor = Color.FromArgb(210, 249, 213);
    this.btnLater.Location = new Point(369, 6);
    this.btnLater.Name = "btnLater";
    this.btnLater.Size = new Size(69, 21);
    this.btnLater.TabIndex = 74;
    this.btnLater.Text = "&Để sau";
    this.btnLater.UseVisualStyleBackColor = false;
    this.btnLater.Click += new EventHandler(this.btnLater_Click);
    this.btnUpdate.BackColor = Color.FromArgb(210, 249, 213);
    this.btnUpdate.Location = new Point(442, 6);
    this.btnUpdate.Name = "btnUpdate";
    this.btnUpdate.Size = new Size(69, 21);
    this.btnUpdate.TabIndex = 73;
    this.btnUpdate.Text = "&Cập nhật";
    this.btnUpdate.UseVisualStyleBackColor = false;
    this.btnUpdate.Click += new EventHandler(this.btnUpdate_Click);
    this.panel2.BackColor = SystemColors.Window;
    this.panel2.Controls.Add((Control) this.richVersion);
    this.panel2.Dock = DockStyle.Fill;
    this.panel2.Location = new Point(0, 110);
    this.panel2.Name = "panel2";
    this.panel2.Padding = new Padding(5);
    this.panel2.Size = new Size(517, 304);
    this.panel2.TabIndex = 3;
    this.richVersion.BorderStyle = BorderStyle.None;
    this.richVersion.Dock = DockStyle.Fill;
    this.richVersion.Font = new Font("Courier New", 10.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 177);
    this.richVersion.ForeColor = Color.FromArgb(0, 0, 0);
    this.richVersion.Location = new Point(5, 5);
    this.richVersion.Margin = new Padding(5, 3, 3, 3);
    this.richVersion.Name = "richVersion";
    this.richVersion.Size = new Size(507, 294);
    this.richVersion.TabIndex = 2;
    this.richVersion.Text = "Thử nghiệm tiếng Việt\nThis is a test message\nTest line 2\n\nTest line 3\n*** --- ***\n";
    this.AutoScaleDimensions = new SizeF(6f, 13f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.ClientSize = new Size(517, 448);
    this.Controls.Add((Control) this.panel2);
    this.Controls.Add((Control) this.panel1);
    this.Controls.Add((Control) this.lbUpdateText);
    this.MaximumSize = new Size(533, 486);
    this.MinimumSize = new Size(533, 486);
    this.Name = nameof (frmVersions_FW);
    this.ShowIcon = false;
    this.StartPosition = FormStartPosition.CenterParent;
    this.Tag = (object) "XC";
    this.Text = "Thông Thiên Tây Du";
    this.FormClosed += new FormClosedEventHandler(this.frmVersions_FW_FormClosed);
    this.Load += new EventHandler(this.frmVersions_FW_Load);
    this.Shown += new EventHandler(this.frmVersions_FW_Shown);
    this.panel1.ResumeLayout(false);
    this.panel2.ResumeLayout(false);
    this.ResumeLayout(false);
  }
}
