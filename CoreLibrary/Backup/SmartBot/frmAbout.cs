// Decompiled with JetBrains decompiler
// Type: SmartBot.frmAbout
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using GAuto_Auto_None.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace SmartBot;

internal class frmAbout : Form
{
  private IContainer components;
  private TableLayoutPanel tableLayoutPanel;
  private PictureBox logoPictureBox;
  private Label labelProductName;
  private Label labelVersion;
  private Label labelCopyright;
  private Label labelCompanyName;
  private TextBox textBoxDescription;
  private Button okButton;

  public frmAbout()
  {
    this.InitializeComponent();
    this.Text = string.Format(frmMain.lang_aboutIntroduce.ToString() + "Games Automation Team", (object) GlobalSettings.AutoName);
    this.labelProductName.Text = $"{GlobalSettings.AutoName}{frmMain.lang_aboutAProduct}Games Automation Team";
    this.labelVersion.Text = $"Version {this.AssemblyVersion}";
    this.labelCopyright.Text = this.AssemblyCopyright;
    this.labelCompanyName.Text = "Games Automation Team";
    if (frmLogin.CompilingLanguage == "VN")
      this.textBoxDescription.Text = "Games Automation Team xin giới thiệu tới các bạn TLBB Auto. Auto sẽ ngày càng có nhiều tính năng độc đáo hơn và thông minh hơn.\nThông tin về phiên bản mới liên tục được cập nhật tại trang chủ www.gameauto.net";
    else
      this.textBoxDescription.Text = "Games Automation Team is pleased to introduce Dragon Oath Auto. Auto is actively developed and will have more intelligent functions. Latest news about this auto are publised on www.tianlongauto.net";
  }

  public string AssemblyTitle
  {
    get
    {
      object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyTitleAttribute), false);
      if (customAttributes.Length > 0)
      {
        AssemblyTitleAttribute assemblyTitleAttribute = (AssemblyTitleAttribute) customAttributes[0];
        if (assemblyTitleAttribute.Title != "")
          return assemblyTitleAttribute.Title;
      }
      return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
    }
  }

  public string AssemblyVersion => Assembly.GetExecutingAssembly().GetName().Version.ToString();

  public string AssemblyDescription
  {
    get
    {
      object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyDescriptionAttribute), false);
      return customAttributes.Length == 0 ? "" : ((AssemblyDescriptionAttribute) customAttributes[0]).Description;
    }
  }

  public string AssemblyProduct
  {
    get
    {
      object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyProductAttribute), false);
      return customAttributes.Length == 0 ? "" : ((AssemblyProductAttribute) customAttributes[0]).Product;
    }
  }

  public string AssemblyCopyright
  {
    get
    {
      object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyCopyrightAttribute), false);
      return customAttributes.Length == 0 ? "" : ((AssemblyCopyrightAttribute) customAttributes[0]).Copyright;
    }
  }

  public string AssemblyCompany
  {
    get
    {
      object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyCompanyAttribute), false);
      return customAttributes.Length == 0 ? "" : ((AssemblyCompanyAttribute) customAttributes[0]).Company;
    }
  }

  private void frmAbout_Load(object sender, EventArgs e)
  {
  }

  private void okButton_Click(object sender, EventArgs e) => this.Close();

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.components != null)
      this.components.Dispose();
    base.Dispose(disposing);
  }

  private void InitializeComponent()
  {
    this.tableLayoutPanel = new TableLayoutPanel();
    this.logoPictureBox = new PictureBox();
    this.labelProductName = new Label();
    this.labelVersion = new Label();
    this.labelCopyright = new Label();
    this.labelCompanyName = new Label();
    this.textBoxDescription = new TextBox();
    this.okButton = new Button();
    this.tableLayoutPanel.SuspendLayout();
    ((ISupportInitialize) this.logoPictureBox).BeginInit();
    this.SuspendLayout();
    this.tableLayoutPanel.ColumnCount = 2;
    this.tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33f));
    this.tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 67f));
    this.tableLayoutPanel.Controls.Add((Control) this.logoPictureBox, 0, 0);
    this.tableLayoutPanel.Controls.Add((Control) this.labelProductName, 1, 0);
    this.tableLayoutPanel.Controls.Add((Control) this.labelVersion, 1, 1);
    this.tableLayoutPanel.Controls.Add((Control) this.labelCopyright, 1, 2);
    this.tableLayoutPanel.Controls.Add((Control) this.labelCompanyName, 1, 3);
    this.tableLayoutPanel.Controls.Add((Control) this.textBoxDescription, 1, 4);
    this.tableLayoutPanel.Controls.Add((Control) this.okButton, 1, 5);
    this.tableLayoutPanel.Dock = DockStyle.Fill;
    this.tableLayoutPanel.Location = new Point(9, 9);
    this.tableLayoutPanel.Name = "tableLayoutPanel";
    this.tableLayoutPanel.RowCount = 6;
    this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10f));
    this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10f));
    this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10f));
    this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10f));
    this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
    this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10f));
    this.tableLayoutPanel.Size = new Size(437, 271);
    this.tableLayoutPanel.TabIndex = 0;
    this.logoPictureBox.Dock = DockStyle.Fill;
    this.logoPictureBox.Image = (Image) Resources.AboutBox;
    this.logoPictureBox.Location = new Point(3, 3);
    this.logoPictureBox.Name = "logoPictureBox";
    this.tableLayoutPanel.SetRowSpan((Control) this.logoPictureBox, 6);
    this.logoPictureBox.Size = new Size(138, 265);
    this.logoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
    this.logoPictureBox.TabIndex = 12;
    this.logoPictureBox.TabStop = false;
    this.labelProductName.Dock = DockStyle.Fill;
    this.labelProductName.Location = new Point(150, 0);
    this.labelProductName.Margin = new Padding(6, 0, 3, 0);
    this.labelProductName.MaximumSize = new Size(0, 17);
    this.labelProductName.Name = "labelProductName";
    this.labelProductName.Size = new Size(284, 17);
    this.labelProductName.TabIndex = 19;
    this.labelProductName.Text = "Product Name";
    this.labelProductName.TextAlign = ContentAlignment.MiddleLeft;
    this.labelVersion.Dock = DockStyle.Fill;
    this.labelVersion.Location = new Point(150, 27);
    this.labelVersion.Margin = new Padding(6, 0, 3, 0);
    this.labelVersion.MaximumSize = new Size(0, 17);
    this.labelVersion.Name = "labelVersion";
    this.labelVersion.Size = new Size(284, 17);
    this.labelVersion.TabIndex = 0;
    this.labelVersion.Text = "Version";
    this.labelVersion.TextAlign = ContentAlignment.MiddleLeft;
    this.labelCopyright.Dock = DockStyle.Fill;
    this.labelCopyright.Location = new Point(150, 54);
    this.labelCopyright.Margin = new Padding(6, 0, 3, 0);
    this.labelCopyright.MaximumSize = new Size(0, 17);
    this.labelCopyright.Name = "labelCopyright";
    this.labelCopyright.Size = new Size(284, 17);
    this.labelCopyright.TabIndex = 21;
    this.labelCopyright.Text = "Copyright";
    this.labelCopyright.TextAlign = ContentAlignment.MiddleLeft;
    this.labelCompanyName.Dock = DockStyle.Fill;
    this.labelCompanyName.Location = new Point(150, 81);
    this.labelCompanyName.Margin = new Padding(6, 0, 3, 0);
    this.labelCompanyName.MaximumSize = new Size(0, 17);
    this.labelCompanyName.Name = "labelCompanyName";
    this.labelCompanyName.Size = new Size(284, 17);
    this.labelCompanyName.TabIndex = 22;
    this.labelCompanyName.Text = "Company Name";
    this.labelCompanyName.TextAlign = ContentAlignment.MiddleLeft;
    this.textBoxDescription.Dock = DockStyle.Fill;
    this.textBoxDescription.Location = new Point(150, 111);
    this.textBoxDescription.Margin = new Padding(6, 3, 3, 3);
    this.textBoxDescription.Multiline = true;
    this.textBoxDescription.Name = "textBoxDescription";
    this.textBoxDescription.ReadOnly = true;
    this.textBoxDescription.ScrollBars = ScrollBars.Both;
    this.textBoxDescription.Size = new Size(284, 129);
    this.textBoxDescription.TabIndex = 23;
    this.textBoxDescription.TabStop = false;
    this.textBoxDescription.Text = "Description";
    this.okButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
    this.okButton.DialogResult = DialogResult.Cancel;
    this.okButton.Location = new Point(359, 246);
    this.okButton.Name = "okButton";
    this.okButton.Size = new Size(75, 22);
    this.okButton.TabIndex = 24;
    this.okButton.Text = "&OK";
    this.okButton.Click += new EventHandler(this.okButton_Click);
    this.AcceptButton = (IButtonControl) this.okButton;
    this.AutoScaleDimensions = new SizeF(6f, 13f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.ClientSize = new Size(455, 289);
    this.Controls.Add((Control) this.tableLayoutPanel);
    this.FormBorderStyle = FormBorderStyle.FixedDialog;
    this.MaximizeBox = false;
    this.MinimizeBox = false;
    this.Name = nameof (frmAbout);
    this.Padding = new Padding(9);
    this.ShowIcon = false;
    this.ShowInTaskbar = false;
    this.StartPosition = FormStartPosition.CenterParent;
    this.Text = nameof (frmAbout);
    this.Load += new EventHandler(this.frmAbout_Load);
    this.tableLayoutPanel.ResumeLayout(false);
    this.tableLayoutPanel.PerformLayout();
    ((ISupportInitialize) this.logoPictureBox).EndInit();
    this.ResumeLayout(false);
  }
}
