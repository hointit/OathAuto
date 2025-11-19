// Decompiled with JetBrains decompiler
// Type: SmartBot.frmHashPick
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace SmartBot;

public class frmHashPick : Form
{
  private long StartStamp;
  public int ProcessID;
  public List<int> BlackListProcessID;
  public string TempHash = "";
  private IContainer components;
  private Label label1;
  private Label label2;
  private ComboBox cboNPH;
  private Button btnHashChon;
  private Button btnHashHuy;
  private System.Windows.Forms.Timer timer1;
  private Label lblTimer;

  public frmHashPick()
  {
    switch (frmLogin.CompilingLanguage)
    {
      case "EN":
        CultureInfo cultureInfo1 = new CultureInfo("en-GB");
        Thread.CurrentThread.CurrentCulture = cultureInfo1;
        Thread.CurrentThread.CurrentUICulture = cultureInfo1;
        break;
      case "CN":
        CultureInfo cultureInfo2 = new CultureInfo("zh-Hans");
        Thread.CurrentThread.CurrentCulture = new CultureInfo("zh-CN");
        Thread.CurrentThread.CurrentUICulture = cultureInfo2;
        break;
    }
    this.InitializeComponent();
  }

  private void frmHashPick_Load(object sender, EventArgs e)
  {
    if (frmMain.frmMainInstance.stampAdsLicense <= 0L)
      return;
    frmMain.frmMainInstance.stampAdsLicense = frmLogin.GlobalTimer.ElapsedMilliseconds + 5000L;
  }

  private void frmHashPick_Shown(object sender, EventArgs e)
  {
    this.StartStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
    this.cboNPH.SelectedIndex = -1;
    this.timer1.Enabled = true;
    this.TopMost = true;
  }

  private void timer1_Tick(object sender, EventArgs e)
  {
    if (this.StartStamp == 0L)
      return;
    if (frmLogin.GlobalTimer.ElapsedMilliseconds - this.StartStamp >= 15000L)
    {
      if (this.cboNPH.SelectedIndex >= 0)
        this.AddMyHash();
      else if (!frmLogin.BlackListHash.Contains(this.TempHash))
        frmLogin.BlackListHash.Add(this.TempHash);
      this.Close();
    }
    else
      this.lblTimer.Text = string.Format(frmMain.langAutoClose, (object) TimeSpan.FromMilliseconds((double) (15000L - (frmLogin.GlobalTimer.ElapsedMilliseconds - this.StartStamp))).Seconds.ToString("00"));
  }

  private void cboPetCongSinh_SelectedIndexChanged(object sender, EventArgs e)
  {
  }

  private void btnLenBai_Click(object sender, EventArgs e)
  {
    this.AddMyHash();
    this.Close();
  }

  private void AddMyHash()
  {
    if (frmLogin.MyBases.Count <= 0)
      return;
    string str = "Vinagame 2D";
    if (this.cboNPH.SelectedIndex >= 0 && this.cboNPH.SelectedIndex < this.cboNPH.Items.Count)
      str = this.cboNPH.Items[this.cboNPH.SelectedIndex].ToString();
    switch (str)
    {
      case "Vinagame 2D":
        using (List<BaseInfo>.Enumerator enumerator = frmLogin.MyBases.GetEnumerator())
        {
          while (enumerator.MoveNext())
          {
            BaseInfo current = enumerator.Current;
            if (current.myProvider == "2d")
            {
              frmLogin.HashDB.Add(new HashDBElement()
              {
                NewHash = this.TempHash,
                MatchingHash = current.myHash
              });
              frmLogin.MyHashList.Add(this.TempHash);
              break;
            }
          }
          break;
        }
      case "Vinagame 3D":
        using (List<BaseInfo>.Enumerator enumerator = frmLogin.MyBases.GetEnumerator())
        {
          while (enumerator.MoveNext())
          {
            BaseInfo current = enumerator.Current;
            if (current.myProvider == "3d")
            {
              frmLogin.HashDB.Add(new HashDBElement()
              {
                NewHash = this.TempHash,
                MatchingHash = current.myHash
              });
              frmLogin.MyHashList.Add(this.TempHash);
              break;
            }
          }
          break;
        }
      case "Tình Kiếm":
      case "69Dragon":
        using (List<BaseInfo>.Enumerator enumerator = frmLogin.MyBases.GetEnumerator())
        {
          while (enumerator.MoveNext())
          {
            BaseInfo current = enumerator.Current;
            if (current.myProvider == "tk" && current.myVersion == "3.66.0000")
            {
              frmLogin.HashDB.Add(new HashDBElement()
              {
                NewHash = this.TempHash,
                MatchingHash = current.myHash
              });
              frmLogin.MyHashList.Add(this.TempHash);
              break;
            }
          }
          break;
        }
      default:
        using (List<BaseInfo>.Enumerator enumerator = frmLogin.MyBases.GetEnumerator())
        {
          while (enumerator.MoveNext())
          {
            BaseInfo current = enumerator.Current;
            if (current.myProvider == "tk" && current.myVersion != "3.66.0000")
            {
              frmLogin.HashDB.Add(new HashDBElement()
              {
                NewHash = this.TempHash,
                MatchingHash = current.myHash
              });
              frmLogin.MyHashList.Add(this.TempHash);
              break;
            }
          }
          break;
        }
    }
  }

  private void btnHashHuy_Click(object sender, EventArgs e)
  {
    if (!frmLogin.BlackListHash.Contains(this.TempHash))
      frmLogin.BlackListHash.Add(this.TempHash);
    this.Close();
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
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmHashPick));
    this.label1 = new Label();
    this.label2 = new Label();
    this.cboNPH = new ComboBox();
    this.btnHashChon = new Button();
    this.btnHashHuy = new Button();
    this.timer1 = new System.Windows.Forms.Timer(this.components);
    this.lblTimer = new Label();
    this.SuspendLayout();
    componentResourceManager.ApplyResources((object) this.label1, "label1");
    this.label1.Name = "label1";
    componentResourceManager.ApplyResources((object) this.label2, "label2");
    this.label2.Name = "label2";
    componentResourceManager.ApplyResources((object) this.cboNPH, "cboNPH");
    this.cboNPH.BackColor = Color.FromArgb(206, 233, 253);
    this.cboNPH.FormattingEnabled = true;
    this.cboNPH.Items.AddRange(new object[4]
    {
      (object) componentResourceManager.GetString("cboNPH.Items"),
      (object) componentResourceManager.GetString("cboNPH.Items1"),
      (object) componentResourceManager.GetString("cboNPH.Items2"),
      (object) componentResourceManager.GetString("cboNPH.Items3")
    });
    this.cboNPH.Name = "cboNPH";
    this.cboNPH.SelectedIndexChanged += new EventHandler(this.cboPetCongSinh_SelectedIndexChanged);
    componentResourceManager.ApplyResources((object) this.btnHashChon, "btnHashChon");
    this.btnHashChon.BackColor = Color.FromArgb(210, 249, 213);
    this.btnHashChon.ForeColor = Color.DarkGreen;
    this.btnHashChon.Name = "btnHashChon";
    this.btnHashChon.UseVisualStyleBackColor = false;
    this.btnHashChon.Click += new EventHandler(this.btnLenBai_Click);
    componentResourceManager.ApplyResources((object) this.btnHashHuy, "btnHashHuy");
    this.btnHashHuy.BackColor = Color.FromArgb(247, 207, 142);
    this.btnHashHuy.ForeColor = Color.Black;
    this.btnHashHuy.Name = "btnHashHuy";
    this.btnHashHuy.UseVisualStyleBackColor = false;
    this.btnHashHuy.Click += new EventHandler(this.btnHashHuy_Click);
    this.timer1.Interval = 500;
    this.timer1.Tick += new EventHandler(this.timer1_Tick);
    componentResourceManager.ApplyResources((object) this.lblTimer, "lblTimer");
    this.lblTimer.Name = "lblTimer";
    componentResourceManager.ApplyResources((object) this, "$this");
    this.AutoScaleMode = AutoScaleMode.Font;
    this.Controls.Add((Control) this.lblTimer);
    this.Controls.Add((Control) this.btnHashChon);
    this.Controls.Add((Control) this.btnHashHuy);
    this.Controls.Add((Control) this.cboNPH);
    this.Controls.Add((Control) this.label2);
    this.Controls.Add((Control) this.label1);
    this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
    this.Name = nameof (frmHashPick);
    this.ShowIcon = false;
    this.Load += new EventHandler(this.frmHashPick_Load);
    this.Shown += new EventHandler(this.frmHashPick_Shown);
    this.ResumeLayout(false);
    this.PerformLayout();
  }
}
