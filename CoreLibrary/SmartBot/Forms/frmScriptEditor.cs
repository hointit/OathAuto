// Decompiled with JetBrains decompiler
// Type: SmartBot.Forms.frmScriptEditor
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace SmartBot.Forms;

public class frmScriptEditor : Form
{
  private IContainer components;
  private Button btnGetCurrentPos;
  private MenuStrip menuStrip1;
  private ToolStripMenuItem scriptsToolStripMenuItem;
  private ToolStripMenuItem mởScriptCóSẵnToolStripMenuItem;
  private ToolStripMenuItem lưuScriptHiệnTạiToolStripMenuItem;
  private ToolStripMenuItem thoátToolStripMenuItem;
  private ToolStripMenuItem quảnLýScriptToolStripMenuItem;
  private ToolStripMenuItem scriptManagerToolStripMenuItem;
  private SplitContainer splitContainer1;
  private RichTextBox richTextBox1;
  private Button button2;
  private Button button1;
  private Label label1;
  private ListView listView2;
  private ColumnHeader columnHeader2;
  private ColumnHeader columnHeader3;
  private Splitter splitter1;
  private ListView listView1;
  private ColumnHeader clmKey;
  private ColumnHeader columnHeader1;
  private StatusStrip statusStrip1;

  public frmScriptEditor() => this.InitializeComponent();

  private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
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
    this.btnGetCurrentPos = new Button();
    this.menuStrip1 = new MenuStrip();
    this.scriptsToolStripMenuItem = new ToolStripMenuItem();
    this.mởScriptCóSẵnToolStripMenuItem = new ToolStripMenuItem();
    this.lưuScriptHiệnTạiToolStripMenuItem = new ToolStripMenuItem();
    this.thoátToolStripMenuItem = new ToolStripMenuItem();
    this.quảnLýScriptToolStripMenuItem = new ToolStripMenuItem();
    this.scriptManagerToolStripMenuItem = new ToolStripMenuItem();
    this.splitContainer1 = new SplitContainer();
    this.listView1 = new ListView();
    this.clmKey = new ColumnHeader();
    this.columnHeader1 = new ColumnHeader();
    this.richTextBox1 = new RichTextBox();
    this.statusStrip1 = new StatusStrip();
    this.splitter1 = new Splitter();
    this.listView2 = new ListView();
    this.columnHeader2 = new ColumnHeader();
    this.columnHeader3 = new ColumnHeader();
    this.label1 = new Label();
    this.button1 = new Button();
    this.button2 = new Button();
    this.menuStrip1.SuspendLayout();
    this.splitContainer1.Panel1.SuspendLayout();
    this.splitContainer1.Panel2.SuspendLayout();
    this.splitContainer1.SuspendLayout();
    this.SuspendLayout();
    this.btnGetCurrentPos.FlatStyle = FlatStyle.Flat;
    this.btnGetCurrentPos.Location = new Point(9, 622);
    this.btnGetCurrentPos.Margin = new Padding(0);
    this.btnGetCurrentPos.Name = "btnGetCurrentPos";
    this.btnGetCurrentPos.Size = new Size(69, 23);
    this.btnGetCurrentPos.TabIndex = 6;
    this.btnGetCurrentPos.Text = "Lấy tọa độ";
    this.btnGetCurrentPos.UseVisualStyleBackColor = true;
    this.menuStrip1.Items.AddRange(new ToolStripItem[2]
    {
      (ToolStripItem) this.scriptsToolStripMenuItem,
      (ToolStripItem) this.quảnLýScriptToolStripMenuItem
    });
    this.menuStrip1.Location = new Point(0, 0);
    this.menuStrip1.Name = "menuStrip1";
    this.menuStrip1.Size = new Size(571, 24);
    this.menuStrip1.TabIndex = 8;
    this.menuStrip1.Text = "menuStrip1";
    this.scriptsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[3]
    {
      (ToolStripItem) this.mởScriptCóSẵnToolStripMenuItem,
      (ToolStripItem) this.lưuScriptHiệnTạiToolStripMenuItem,
      (ToolStripItem) this.thoátToolStripMenuItem
    });
    this.scriptsToolStripMenuItem.Name = "scriptsToolStripMenuItem";
    this.scriptsToolStripMenuItem.Size = new Size(72, 20);
    this.scriptsToolStripMenuItem.Text = "Soạn thảo";
    this.mởScriptCóSẵnToolStripMenuItem.Name = "mởScriptCóSẵnToolStripMenuItem";
    this.mởScriptCóSẵnToolStripMenuItem.Size = new Size(168, 22);
    this.mởScriptCóSẵnToolStripMenuItem.Text = "Mở script có sẵn";
    this.lưuScriptHiệnTạiToolStripMenuItem.Name = "lưuScriptHiệnTạiToolStripMenuItem";
    this.lưuScriptHiệnTạiToolStripMenuItem.Size = new Size(168, 22);
    this.lưuScriptHiệnTạiToolStripMenuItem.Text = "Lưu script hiện tại";
    this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
    this.thoátToolStripMenuItem.Size = new Size(168, 22);
    this.thoátToolStripMenuItem.Text = "Thoát";
    this.quảnLýScriptToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[1]
    {
      (ToolStripItem) this.scriptManagerToolStripMenuItem
    });
    this.quảnLýScriptToolStripMenuItem.Name = "quảnLýScriptToolStripMenuItem";
    this.quảnLýScriptToolStripMenuItem.Size = new Size(93, 20);
    this.quảnLýScriptToolStripMenuItem.Text = "Quản lý Script";
    this.scriptManagerToolStripMenuItem.Name = "scriptManagerToolStripMenuItem";
    this.scriptManagerToolStripMenuItem.Size = new Size(154, 22);
    this.scriptManagerToolStripMenuItem.Text = "Script Manager";
    this.splitContainer1.Location = new Point(9, 48 /*0x30*/);
    this.splitContainer1.Name = "splitContainer1";
    this.splitContainer1.Panel1.Controls.Add((Control) this.richTextBox1);
    this.splitContainer1.Panel2.Controls.Add((Control) this.button2);
    this.splitContainer1.Panel2.Controls.Add((Control) this.button1);
    this.splitContainer1.Panel2.Controls.Add((Control) this.label1);
    this.splitContainer1.Panel2.Controls.Add((Control) this.listView2);
    this.splitContainer1.Panel2.Controls.Add((Control) this.splitter1);
    this.splitContainer1.Panel2.Controls.Add((Control) this.listView1);
    this.splitContainer1.Panel2.Paint += new PaintEventHandler(this.splitContainer1_Panel2_Paint);
    this.splitContainer1.Size = new Size(549, 567);
    this.splitContainer1.SplitterDistance = 372;
    this.splitContainer1.TabIndex = 12;
    this.listView1.Columns.AddRange(new ColumnHeader[2]
    {
      this.clmKey,
      this.columnHeader1
    });
    this.listView1.Dock = DockStyle.Top;
    this.listView1.Location = new Point(0, 0);
    this.listView1.Name = "listView1";
    this.listView1.Size = new Size(173, 257);
    this.listView1.TabIndex = 11;
    this.listView1.UseCompatibleStateImageBehavior = false;
    this.listView1.View = View.Details;
    this.clmKey.Text = "Từ khóa";
    this.columnHeader1.Text = "Chức năng";
    this.richTextBox1.BackColor = Color.OldLace;
    this.richTextBox1.Dock = DockStyle.Top;
    this.richTextBox1.Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
    this.richTextBox1.Location = new Point(0, 0);
    this.richTextBox1.Name = "richTextBox1";
    this.richTextBox1.Size = new Size(372, 609);
    this.richTextBox1.TabIndex = 8;
    this.richTextBox1.Text = "# Script sử dụng đi ác tặc\n# Tạo bởi GATeam\n# Cập nhật  ngày 20/04/2015\n\n# Script header\n\n\n# Script loop";
    this.statusStrip1.Location = new Point(0, 650);
    this.statusStrip1.Name = "statusStrip1";
    this.statusStrip1.Size = new Size(571, 22);
    this.statusStrip1.TabIndex = 13;
    this.statusStrip1.Text = "statusStrip1";
    this.splitter1.Cursor = Cursors.HSplit;
    this.splitter1.Dock = DockStyle.Top;
    this.splitter1.Location = new Point(0, 257);
    this.splitter1.Name = "splitter1";
    this.splitter1.Size = new Size(173, 10);
    this.splitter1.TabIndex = 12;
    this.splitter1.TabStop = false;
    this.listView2.Columns.AddRange(new ColumnHeader[2]
    {
      this.columnHeader2,
      this.columnHeader3
    });
    this.listView2.Location = new Point(0, 290);
    this.listView2.Name = "listView2";
    this.listView2.Size = new Size(173, 244);
    this.listView2.TabIndex = 14;
    this.listView2.UseCompatibleStateImageBehavior = false;
    this.listView2.View = View.Details;
    this.columnHeader2.Text = "Từ khóa";
    this.columnHeader3.Text = "Chức năng";
    this.label1.AutoSize = true;
    this.label1.Location = new Point(4, 274);
    this.label1.Name = "label1";
    this.label1.Size = new Size(79, 13);
    this.label1.TabIndex = 15;
    this.label1.Text = "Script Manager";
    this.button1.FlatStyle = FlatStyle.Flat;
    this.button1.Location = new Point(7, 537);
    this.button1.Margin = new Padding(0);
    this.button1.Name = "button1";
    this.button1.Size = new Size(69, 23);
    this.button1.TabIndex = 16 /*0x10*/;
    this.button1.Text = "Xóa";
    this.button1.UseVisualStyleBackColor = true;
    this.button2.FlatStyle = FlatStyle.Flat;
    this.button2.Location = new Point(78, 538);
    this.button2.Margin = new Padding(0);
    this.button2.Name = "button2";
    this.button2.Size = new Size(69, 23);
    this.button2.TabIndex = 17;
    this.button2.Text = "Mở";
    this.button2.UseVisualStyleBackColor = true;
    this.AutoScaleDimensions = new SizeF(6f, 13f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.ClientSize = new Size(571, 672);
    this.Controls.Add((Control) this.statusStrip1);
    this.Controls.Add((Control) this.splitContainer1);
    this.Controls.Add((Control) this.btnGetCurrentPos);
    this.Controls.Add((Control) this.menuStrip1);
    this.MainMenuStrip = this.menuStrip1;
    this.Name = nameof (frmScriptEditor);
    this.Text = nameof (frmScriptEditor);
    this.menuStrip1.ResumeLayout(false);
    this.menuStrip1.PerformLayout();
    this.splitContainer1.Panel1.ResumeLayout(false);
    this.splitContainer1.Panel2.ResumeLayout(false);
    this.splitContainer1.Panel2.PerformLayout();
    this.splitContainer1.ResumeLayout(false);
    this.ResumeLayout(false);
    this.PerformLayout();
  }
}
