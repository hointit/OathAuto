// Decompiled with JetBrains decompiler
// Type: SmartBot.frmHotKeys
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace SmartBot;

public class frmHotKeys : Form
{
  private List<ComboBox> AllKeys = new List<ComboBox>();
  private bool AllLoaded;
  private int cboIndex;
  private bool flagNeedToSave = true;
  private IContainer components;
  private Label label1;
  private Button btnHKClose;
  private Label label11;
  private Panel pnelAutoKey;
  private Label label3;
  private Label label2;
  private Panel pnelMain;
  private Panel pnelAuto;
  private Label label8;
  private Panel pnelGame;
  private Label label9;
  private Panel pnelGameKey;
  private Button btnHKDefault;
  private Label label58;
  private Label label59;
  private Label label56;
  private Label label57;
  private Label label54;
  private Label label55;
  private Label label52;
  private Label label53;
  private Label label50;
  private Label label51;
  private Label label48;
  private Label label49;
  private Label label46;
  private Label label47;
  private Label label44;
  private Label label45;
  private Label label42;
  private Label label43;
  private Label label40;
  private Label label41;
  private Label label38;
  private Label label39;
  private Label label36;
  private Label lblTrongTrot;
  private Label label34;
  private Label label35;
  private Label label33;
  private Label label31;
  private Label label32;
  private Label label29;
  private Label label30;
  private Label label27;
  private Label label28;
  private Label label25;
  private Label label26;
  private Label label23;
  private Label label24;
  private Label label21;
  private Label label22;
  private Label label19;
  private Label label20;
  private Label label17;
  private Label label18;
  private Label label15;
  private Label label16;
  private Label label13;
  private Label label14;
  private Label label10;
  private Label label12;
  private Label label6;
  private Label label7;
  private Label label4;
  private Label label5;
  private Label label60;
  private Label label61;
  private Label label64;
  private Label label62;
  private Label label63;
  private Label label65;
  private Label label66;
  private Label label67;
  private Label label68;
  private Label label71;
  private Label label72;
  private Label label69;
  private Label label70;
  private Label label75;
  private Label label76;
  private Label label73;
  private Label label74;
  private Label label79;
  private Label label80;
  private Label label77;
  private Label label78;
  private Label label81;
  private Label lblNgungDanhNgay;
  public ComboBox cbo_6;
  public ComboBox cbo_5;
  public ComboBox cbo_31;
  public ComboBox cbo_30;
  public ComboBox cbo_29;
  public ComboBox cbo_28;
  public ComboBox cbo_27;
  public ComboBox cbo_26;
  public ComboBox cbo_25;
  public ComboBox cbo_24;
  public ComboBox cbo_23;
  public ComboBox cbo_22;
  public ComboBox cbo_21;
  public ComboBox cbo_20;
  public ComboBox cbo_19;
  public ComboBox cbo_18;
  public ComboBox cbo_17;
  public ComboBox cbo_15;
  public ComboBox cbo_14;
  public ComboBox cbo_13;
  public ComboBox cbo_12;
  public ComboBox cbo_11;
  public ComboBox cbo_4;
  public ComboBox cbo_3;
  public ComboBox cbo_2;
  public ComboBox cbo_1;
  public ComboBox cbo_7;
  public ComboBox cbo_8;
  public ComboBox cbo_10;
  public ComboBox cbo_9;
  public ComboBox cbo_16;
  public ComboBox cbo_33;
  private Label label82;
  private Label label83;
  public ComboBox cbo_32;
  private Label label84;
  private Label label85;
  private Label label37;
  public ComboBox cbo_37;
  public ComboBox cbo_36;
  private Label label86;
  private Label label88;
  private Label label87;
  private Label label89;
  public ComboBox cbo_35;
  private Label label90;
  private Label label91;
  public ComboBox cbo_34;
  private Label label92;
  private Label label93;
  public ComboBox cbo_38;
  private Label label94;
  private Label label95;
  public ComboBox cbo_40;
  private Label label96;
  private Label label97;
  public ComboBox cbo_39;
  private Label label98;
  private Label label99;
  public ComboBox cbo_43;
  private Label label100;
  private Label label101;
  public ComboBox cbo_42;
  private Label label102;
  private Label label103;
  public ComboBox cbo_41;
  private Label label104;
  private Label label105;
  public ComboBox cbo_44;
  private Label label106;
  private Label label107;

  public frmHotKeys()
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
    this.AllKeys.Add(this.cbo_1);
    this.AllKeys.Add(this.cbo_2);
    this.AllKeys.Add(this.cbo_3);
    this.AllKeys.Add(this.cbo_4);
    this.AllKeys.Add(this.cbo_5);
    this.AllKeys.Add(this.cbo_6);
    this.AllKeys.Add(this.cbo_7);
    this.AllKeys.Add(this.cbo_8);
    this.AllKeys.Add(this.cbo_9);
    this.AllKeys.Add(this.cbo_10);
    this.AllKeys.Add(this.cbo_11);
    this.AllKeys.Add(this.cbo_12);
    this.AllKeys.Add(this.cbo_13);
    this.AllKeys.Add(this.cbo_14);
    this.AllKeys.Add(this.cbo_15);
    this.AllKeys.Add(this.cbo_16);
    this.AllKeys.Add(this.cbo_17);
    this.AllKeys.Add(this.cbo_18);
    this.AllKeys.Add(this.cbo_19);
    this.AllKeys.Add(this.cbo_20);
    this.AllKeys.Add(this.cbo_21);
    this.AllKeys.Add(this.cbo_22);
    this.AllKeys.Add(this.cbo_23);
    this.AllKeys.Add(this.cbo_24);
    this.AllKeys.Add(this.cbo_25);
    this.AllKeys.Add(this.cbo_26);
    this.AllKeys.Add(this.cbo_27);
    this.AllKeys.Add(this.cbo_28);
    this.AllKeys.Add(this.cbo_29);
    this.AllKeys.Add(this.cbo_30);
    this.AllKeys.Add(this.cbo_31);
    this.AllKeys.Add(this.cbo_32);
    this.AllKeys.Add(this.cbo_33);
    this.AllKeys.Add(this.cbo_34);
    this.AllKeys.Add(this.cbo_35);
    this.AllKeys.Add(this.cbo_36);
    this.AllKeys.Add(this.cbo_37);
    this.AllKeys.Add(this.cbo_38);
    this.AllKeys.Add(this.cbo_39);
    this.AllKeys.Add(this.cbo_40);
    this.AllKeys.Add(this.cbo_41);
    this.AllKeys.Add(this.cbo_42);
    this.AllKeys.Add(this.cbo_43);
    this.AllKeys.Add(this.cbo_44);
  }

  private void FillInToolTip()
  {
    ToolTip toolTip = new ToolTip();
    toolTip.OwnerDraw = true;
    toolTip.BackColor = Color.Yellow;
    toolTip.AutoPopDelay = 20000;
    toolTip.InitialDelay = 500;
    toolTip.ReshowDelay = 500;
    toolTip.ShowAlways = true;
    toolTip.IsBalloon = true;
    toolTip.SetToolTip((Control) this.lblTrongTrot, frmMain.langTrongTrotTip);
    toolTip.SetToolTip((Control) this.lblNgungDanhNgay, frmMain.langNgungDanhNgay);
  }

  private void frmHotKeys_Load(object sender, EventArgs e)
  {
  }

  private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
  {
  }

  private void btnHKClose_Click(object sender, EventArgs e) => this.Hide();

  private void btnHKDefault_Click(object sender, EventArgs e)
  {
    if (GA.ActiveHotKeys.Count <= 0)
      return;
    bool flag = false;
    for (int index1 = 0; index1 < GA.DefaultHotKeys.Count; ++index1)
    {
      if (GA.DefaultHotKeys[index1].KeyMessage == GA.ActiveHotKeys[index1].KeyMessage && GA.DefaultHotKeys[index1].KeyValue != GA.ActiveHotKeys[index1].KeyValue)
      {
        GA.ActiveHotKeys[index1].KeyValue = GA.DefaultHotKeys[index1].KeyValue;
        GA.ActiveHotKeys[index1].Changed = false;
        if (frmLogin.GAuto.AllAutoAccounts.Count > 0)
        {
          try
          {
            for (int index2 = frmLogin.GAuto.AllAutoAccounts.Count - 1; index2 >= 0; --index2)
              frmLogin.GAuto.AllAutoAccounts[index2].CallUpdateHotKey(index1, GA.DefaultHotKeys[index1].KeyValue);
          }
          catch (Exception ex)
          {
          }
        }
        this.AllKeys[index1].BeginUpdate();
        this.AllKeys[index1].Text = GA.GetDefaultHotKeyLetter(index1 + 1);
        if (this.AllKeys[index1].Text == frmMain.langNotYet)
        {
          if (this.AllKeys[index1].BackColor != Color.FromArgb(253, 206, 206))
            this.AllKeys[index1].BackColor = Color.FromArgb(253, 206, 206);
        }
        else if (this.AllKeys[index1].BackColor != Color.FromArgb(206, 233, 253))
          this.AllKeys[index1].BackColor = Color.FromArgb(206, 233, 253);
        this.AllKeys[index1].EndUpdate();
        flag = true;
      }
    }
    if (!flag)
      return;
  }

  public int MyTest { get; set; }

  private void frmHotKeys_Shown(object sender, EventArgs e)
  {
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();
    for (int index = 0; index < this.AllKeys.Count; ++index)
    {
      this.AllKeys[index].BeginUpdate();
      this.AllKeys[index].Text = GA.GetHotKeyLetter(index + 1);
      if (this.AllKeys[index].Text == frmMain.langNotYet)
        this.AllKeys[index].BackColor = Color.FromArgb(253, 206, 206);
      this.AllKeys[index].EndUpdate();
    }
    this.AllLoaded = true;
    stopwatch.Stop();
    stopwatch.Reset();
  }

  private void ComboIndexChanged(ComboBox combo)
  {
    this.cboIndex = combo.SelectedIndex;
    string name = combo.Name;
    string[] strArray = combo.Name.Split('_');
    int result = 0;
    int.TryParse(strArray[1], out result);
    if (this.cboIndex != 0)
    {
      if (result <= 0 || result > this.AllKeys.Count)
        return;
      int keyValue = GA.ActiveHotKeys[result - 1].KeyValue;
      int hotKeyValue = GA.GetHotKeyValue(combo.Text);
      if (hotKeyValue == keyValue)
        return;
      GA.ActiveHotKeys[result - 1].KeyValue = hotKeyValue;
      GA.ActiveHotKeys[result - 1].Changed = true;
      combo.BackColor = Color.FromArgb(206, 233, 253);
      for (int index = 0; index < this.AllKeys.Count; ++index)
      {
        if (index != result - 1 && this.AllKeys[index].Text == combo.Text && this.AllKeys[index].Text != frmMain.langNotYet)
        {
          this.AllKeys[index].BeginUpdate();
          this.flagNeedToSave = false;
          this.AllKeys[index].SelectedIndex = 0;
          this.AllKeys[index].EndUpdate();
          break;
        }
      }
      GA.SaveHotKeys();
      this.flagNeedToSave = true;
    }
    else
    {
      if (this.cboIndex != 0)
        return;
      GA.ActiveHotKeys[result - 1].KeyValue = 0;
      GA.ActiveHotKeys[result - 1].Changed = true;
      this.AllKeys[result - 1].BackColor = Color.FromArgb(253, 206, 206);
      if (!this.flagNeedToSave)
        return;
      GA.SaveHotKeys();
    }
  }

  private void cbo_1_SelectedIndexChanged(object sender, EventArgs e)
  {
    if (!this.AllLoaded)
      return;
    this.ComboIndexChanged(sender as ComboBox);
  }

  private void frmHotKeys_FormClosing(object sender, FormClosingEventArgs e)
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
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmHotKeys));
    this.label1 = new Label();
    this.btnHKClose = new Button();
    this.label11 = new Label();
    this.pnelAutoKey = new Panel();
    this.label75 = new Label();
    this.label76 = new Label();
    this.label73 = new Label();
    this.label74 = new Label();
    this.label71 = new Label();
    this.label72 = new Label();
    this.label69 = new Label();
    this.label70 = new Label();
    this.label67 = new Label();
    this.label68 = new Label();
    this.label65 = new Label();
    this.label66 = new Label();
    this.label3 = new Label();
    this.label2 = new Label();
    this.pnelMain = new Panel();
    this.btnHKDefault = new Button();
    this.pnelAuto = new Panel();
    this.label8 = new Label();
    this.pnelGame = new Panel();
    this.label9 = new Label();
    this.pnelGameKey = new Panel();
    this.cbo_40 = new ComboBox();
    this.label96 = new Label();
    this.label97 = new Label();
    this.cbo_39 = new ComboBox();
    this.label98 = new Label();
    this.label99 = new Label();
    this.cbo_43 = new ComboBox();
    this.label100 = new Label();
    this.label101 = new Label();
    this.cbo_42 = new ComboBox();
    this.label102 = new Label();
    this.label103 = new Label();
    this.cbo_41 = new ComboBox();
    this.label104 = new Label();
    this.label105 = new Label();
    this.cbo_38 = new ComboBox();
    this.label94 = new Label();
    this.label95 = new Label();
    this.cbo_35 = new ComboBox();
    this.label90 = new Label();
    this.label91 = new Label();
    this.cbo_34 = new ComboBox();
    this.label92 = new Label();
    this.label93 = new Label();
    this.cbo_37 = new ComboBox();
    this.cbo_36 = new ComboBox();
    this.label86 = new Label();
    this.label88 = new Label();
    this.label87 = new Label();
    this.cbo_33 = new ComboBox();
    this.label89 = new Label();
    this.label82 = new Label();
    this.label83 = new Label();
    this.cbo_32 = new ComboBox();
    this.label84 = new Label();
    this.label85 = new Label();
    this.label37 = new Label();
    this.cbo_16 = new ComboBox();
    this.label81 = new Label();
    this.lblNgungDanhNgay = new Label();
    this.cbo_10 = new ComboBox();
    this.label79 = new Label();
    this.label80 = new Label();
    this.cbo_9 = new ComboBox();
    this.label77 = new Label();
    this.label78 = new Label();
    this.label64 = new Label();
    this.cbo_8 = new ComboBox();
    this.label62 = new Label();
    this.label63 = new Label();
    this.cbo_7 = new ComboBox();
    this.label60 = new Label();
    this.label61 = new Label();
    this.cbo_6 = new ComboBox();
    this.label58 = new Label();
    this.label59 = new Label();
    this.cbo_5 = new ComboBox();
    this.label56 = new Label();
    this.label57 = new Label();
    this.cbo_31 = new ComboBox();
    this.label54 = new Label();
    this.label55 = new Label();
    this.cbo_30 = new ComboBox();
    this.label52 = new Label();
    this.label53 = new Label();
    this.cbo_29 = new ComboBox();
    this.label50 = new Label();
    this.label51 = new Label();
    this.cbo_28 = new ComboBox();
    this.label48 = new Label();
    this.label49 = new Label();
    this.cbo_27 = new ComboBox();
    this.label46 = new Label();
    this.label47 = new Label();
    this.cbo_26 = new ComboBox();
    this.label44 = new Label();
    this.label45 = new Label();
    this.cbo_25 = new ComboBox();
    this.label42 = new Label();
    this.label43 = new Label();
    this.cbo_24 = new ComboBox();
    this.label40 = new Label();
    this.label41 = new Label();
    this.cbo_23 = new ComboBox();
    this.label38 = new Label();
    this.label39 = new Label();
    this.cbo_22 = new ComboBox();
    this.label36 = new Label();
    this.lblTrongTrot = new Label();
    this.cbo_21 = new ComboBox();
    this.label34 = new Label();
    this.label35 = new Label();
    this.label33 = new Label();
    this.cbo_20 = new ComboBox();
    this.label31 = new Label();
    this.label32 = new Label();
    this.cbo_19 = new ComboBox();
    this.label29 = new Label();
    this.label30 = new Label();
    this.cbo_18 = new ComboBox();
    this.label27 = new Label();
    this.label28 = new Label();
    this.cbo_17 = new ComboBox();
    this.label25 = new Label();
    this.label26 = new Label();
    this.cbo_15 = new ComboBox();
    this.label23 = new Label();
    this.label24 = new Label();
    this.cbo_14 = new ComboBox();
    this.label21 = new Label();
    this.label22 = new Label();
    this.cbo_13 = new ComboBox();
    this.label19 = new Label();
    this.label20 = new Label();
    this.cbo_12 = new ComboBox();
    this.label17 = new Label();
    this.label18 = new Label();
    this.cbo_11 = new ComboBox();
    this.label15 = new Label();
    this.label16 = new Label();
    this.cbo_4 = new ComboBox();
    this.label13 = new Label();
    this.label14 = new Label();
    this.cbo_3 = new ComboBox();
    this.label10 = new Label();
    this.label12 = new Label();
    this.cbo_2 = new ComboBox();
    this.label6 = new Label();
    this.label7 = new Label();
    this.cbo_1 = new ComboBox();
    this.label4 = new Label();
    this.label5 = new Label();
    this.cbo_44 = new ComboBox();
    this.label106 = new Label();
    this.label107 = new Label();
    this.pnelAutoKey.SuspendLayout();
    this.pnelMain.SuspendLayout();
    this.pnelAuto.SuspendLayout();
    this.pnelGame.SuspendLayout();
    this.pnelGameKey.SuspendLayout();
    this.SuspendLayout();
    componentResourceManager.ApplyResources((object) this.label1, "label1");
    this.label1.ForeColor = Color.MidnightBlue;
    this.label1.Name = "label1";
    this.btnHKClose.BackColor = Color.FromArgb(247, 207, 142);
    this.btnHKClose.ForeColor = Color.Black;
    componentResourceManager.ApplyResources((object) this.btnHKClose, "btnHKClose");
    this.btnHKClose.Name = "btnHKClose";
    this.btnHKClose.UseVisualStyleBackColor = false;
    this.btnHKClose.Click += new EventHandler(this.btnHKClose_Click);
    this.label11.ForeColor = Color.FromArgb(15, 15, 15);
    componentResourceManager.ApplyResources((object) this.label11, "label11");
    this.label11.Name = "label11";
    componentResourceManager.ApplyResources((object) this.pnelAutoKey, "pnelAutoKey");
    this.pnelAutoKey.BackColor = Color.White;
    this.pnelAutoKey.Controls.Add((Control) this.label75);
    this.pnelAutoKey.Controls.Add((Control) this.label76);
    this.pnelAutoKey.Controls.Add((Control) this.label73);
    this.pnelAutoKey.Controls.Add((Control) this.label74);
    this.pnelAutoKey.Controls.Add((Control) this.label71);
    this.pnelAutoKey.Controls.Add((Control) this.label72);
    this.pnelAutoKey.Controls.Add((Control) this.label69);
    this.pnelAutoKey.Controls.Add((Control) this.label70);
    this.pnelAutoKey.Controls.Add((Control) this.label67);
    this.pnelAutoKey.Controls.Add((Control) this.label68);
    this.pnelAutoKey.Controls.Add((Control) this.label65);
    this.pnelAutoKey.Controls.Add((Control) this.label66);
    this.pnelAutoKey.Controls.Add((Control) this.label3);
    this.pnelAutoKey.Controls.Add((Control) this.label2);
    this.pnelAutoKey.ForeColor = Color.FromArgb(30, 30, 30);
    this.pnelAutoKey.Name = "pnelAutoKey";
    componentResourceManager.ApplyResources((object) this.label75, "label75");
    this.label75.Name = "label75";
    componentResourceManager.ApplyResources((object) this.label76, "label76");
    this.label76.Name = "label76";
    componentResourceManager.ApplyResources((object) this.label73, "label73");
    this.label73.Name = "label73";
    componentResourceManager.ApplyResources((object) this.label74, "label74");
    this.label74.Name = "label74";
    componentResourceManager.ApplyResources((object) this.label71, "label71");
    this.label71.Name = "label71";
    componentResourceManager.ApplyResources((object) this.label72, "label72");
    this.label72.Name = "label72";
    componentResourceManager.ApplyResources((object) this.label69, "label69");
    this.label69.Name = "label69";
    componentResourceManager.ApplyResources((object) this.label70, "label70");
    this.label70.Name = "label70";
    componentResourceManager.ApplyResources((object) this.label67, "label67");
    this.label67.Name = "label67";
    componentResourceManager.ApplyResources((object) this.label68, "label68");
    this.label68.Name = "label68";
    componentResourceManager.ApplyResources((object) this.label65, "label65");
    this.label65.Name = "label65";
    componentResourceManager.ApplyResources((object) this.label66, "label66");
    this.label66.Name = "label66";
    componentResourceManager.ApplyResources((object) this.label3, "label3");
    this.label3.Name = "label3";
    componentResourceManager.ApplyResources((object) this.label2, "label2");
    this.label2.Name = "label2";
    this.pnelMain.BackColor = Color.White;
    this.pnelMain.Controls.Add((Control) this.btnHKDefault);
    this.pnelMain.Controls.Add((Control) this.btnHKClose);
    this.pnelMain.Controls.Add((Control) this.label1);
    this.pnelMain.Controls.Add((Control) this.label11);
    componentResourceManager.ApplyResources((object) this.pnelMain, "pnelMain");
    this.pnelMain.ForeColor = Color.FromArgb(30, 30, 30);
    this.pnelMain.Name = "pnelMain";
    this.btnHKDefault.BackColor = Color.FromArgb(247, 207, 142);
    this.btnHKDefault.ForeColor = Color.Black;
    componentResourceManager.ApplyResources((object) this.btnHKDefault, "btnHKDefault");
    this.btnHKDefault.Name = "btnHKDefault";
    this.btnHKDefault.UseVisualStyleBackColor = false;
    this.btnHKDefault.Click += new EventHandler(this.btnHKDefault_Click);
    this.pnelAuto.BackColor = Color.White;
    this.pnelAuto.Controls.Add((Control) this.label8);
    componentResourceManager.ApplyResources((object) this.pnelAuto, "pnelAuto");
    this.pnelAuto.Name = "pnelAuto";
    componentResourceManager.ApplyResources((object) this.label8, "label8");
    this.label8.ForeColor = Color.MidnightBlue;
    this.label8.Name = "label8";
    this.pnelGame.BackColor = Color.White;
    this.pnelGame.Controls.Add((Control) this.label9);
    componentResourceManager.ApplyResources((object) this.pnelGame, "pnelGame");
    this.pnelGame.Name = "pnelGame";
    componentResourceManager.ApplyResources((object) this.label9, "label9");
    this.label9.ForeColor = Color.MidnightBlue;
    this.label9.Name = "label9";
    componentResourceManager.ApplyResources((object) this.pnelGameKey, "pnelGameKey");
    this.pnelGameKey.BackColor = Color.White;
    this.pnelGameKey.Controls.Add((Control) this.cbo_44);
    this.pnelGameKey.Controls.Add((Control) this.label106);
    this.pnelGameKey.Controls.Add((Control) this.label107);
    this.pnelGameKey.Controls.Add((Control) this.cbo_40);
    this.pnelGameKey.Controls.Add((Control) this.label96);
    this.pnelGameKey.Controls.Add((Control) this.label97);
    this.pnelGameKey.Controls.Add((Control) this.cbo_39);
    this.pnelGameKey.Controls.Add((Control) this.label98);
    this.pnelGameKey.Controls.Add((Control) this.label99);
    this.pnelGameKey.Controls.Add((Control) this.cbo_43);
    this.pnelGameKey.Controls.Add((Control) this.label100);
    this.pnelGameKey.Controls.Add((Control) this.label101);
    this.pnelGameKey.Controls.Add((Control) this.cbo_42);
    this.pnelGameKey.Controls.Add((Control) this.label102);
    this.pnelGameKey.Controls.Add((Control) this.label103);
    this.pnelGameKey.Controls.Add((Control) this.cbo_41);
    this.pnelGameKey.Controls.Add((Control) this.label104);
    this.pnelGameKey.Controls.Add((Control) this.label105);
    this.pnelGameKey.Controls.Add((Control) this.cbo_38);
    this.pnelGameKey.Controls.Add((Control) this.label94);
    this.pnelGameKey.Controls.Add((Control) this.label95);
    this.pnelGameKey.Controls.Add((Control) this.cbo_35);
    this.pnelGameKey.Controls.Add((Control) this.label90);
    this.pnelGameKey.Controls.Add((Control) this.label91);
    this.pnelGameKey.Controls.Add((Control) this.cbo_34);
    this.pnelGameKey.Controls.Add((Control) this.label92);
    this.pnelGameKey.Controls.Add((Control) this.label93);
    this.pnelGameKey.Controls.Add((Control) this.cbo_37);
    this.pnelGameKey.Controls.Add((Control) this.cbo_36);
    this.pnelGameKey.Controls.Add((Control) this.label86);
    this.pnelGameKey.Controls.Add((Control) this.label88);
    this.pnelGameKey.Controls.Add((Control) this.label87);
    this.pnelGameKey.Controls.Add((Control) this.cbo_33);
    this.pnelGameKey.Controls.Add((Control) this.label89);
    this.pnelGameKey.Controls.Add((Control) this.label82);
    this.pnelGameKey.Controls.Add((Control) this.label83);
    this.pnelGameKey.Controls.Add((Control) this.cbo_32);
    this.pnelGameKey.Controls.Add((Control) this.label84);
    this.pnelGameKey.Controls.Add((Control) this.label85);
    this.pnelGameKey.Controls.Add((Control) this.label37);
    this.pnelGameKey.Controls.Add((Control) this.cbo_16);
    this.pnelGameKey.Controls.Add((Control) this.label81);
    this.pnelGameKey.Controls.Add((Control) this.lblNgungDanhNgay);
    this.pnelGameKey.Controls.Add((Control) this.cbo_10);
    this.pnelGameKey.Controls.Add((Control) this.label79);
    this.pnelGameKey.Controls.Add((Control) this.label80);
    this.pnelGameKey.Controls.Add((Control) this.cbo_9);
    this.pnelGameKey.Controls.Add((Control) this.label77);
    this.pnelGameKey.Controls.Add((Control) this.label78);
    this.pnelGameKey.Controls.Add((Control) this.label64);
    this.pnelGameKey.Controls.Add((Control) this.cbo_8);
    this.pnelGameKey.Controls.Add((Control) this.label62);
    this.pnelGameKey.Controls.Add((Control) this.label63);
    this.pnelGameKey.Controls.Add((Control) this.cbo_7);
    this.pnelGameKey.Controls.Add((Control) this.label60);
    this.pnelGameKey.Controls.Add((Control) this.label61);
    this.pnelGameKey.Controls.Add((Control) this.cbo_6);
    this.pnelGameKey.Controls.Add((Control) this.label58);
    this.pnelGameKey.Controls.Add((Control) this.label59);
    this.pnelGameKey.Controls.Add((Control) this.cbo_5);
    this.pnelGameKey.Controls.Add((Control) this.label56);
    this.pnelGameKey.Controls.Add((Control) this.label57);
    this.pnelGameKey.Controls.Add((Control) this.cbo_31);
    this.pnelGameKey.Controls.Add((Control) this.label54);
    this.pnelGameKey.Controls.Add((Control) this.label55);
    this.pnelGameKey.Controls.Add((Control) this.cbo_30);
    this.pnelGameKey.Controls.Add((Control) this.label52);
    this.pnelGameKey.Controls.Add((Control) this.label53);
    this.pnelGameKey.Controls.Add((Control) this.cbo_29);
    this.pnelGameKey.Controls.Add((Control) this.label50);
    this.pnelGameKey.Controls.Add((Control) this.label51);
    this.pnelGameKey.Controls.Add((Control) this.cbo_28);
    this.pnelGameKey.Controls.Add((Control) this.label48);
    this.pnelGameKey.Controls.Add((Control) this.label49);
    this.pnelGameKey.Controls.Add((Control) this.cbo_27);
    this.pnelGameKey.Controls.Add((Control) this.label46);
    this.pnelGameKey.Controls.Add((Control) this.label47);
    this.pnelGameKey.Controls.Add((Control) this.cbo_26);
    this.pnelGameKey.Controls.Add((Control) this.label44);
    this.pnelGameKey.Controls.Add((Control) this.label45);
    this.pnelGameKey.Controls.Add((Control) this.cbo_25);
    this.pnelGameKey.Controls.Add((Control) this.label42);
    this.pnelGameKey.Controls.Add((Control) this.label43);
    this.pnelGameKey.Controls.Add((Control) this.cbo_24);
    this.pnelGameKey.Controls.Add((Control) this.label40);
    this.pnelGameKey.Controls.Add((Control) this.label41);
    this.pnelGameKey.Controls.Add((Control) this.cbo_23);
    this.pnelGameKey.Controls.Add((Control) this.label38);
    this.pnelGameKey.Controls.Add((Control) this.label39);
    this.pnelGameKey.Controls.Add((Control) this.cbo_22);
    this.pnelGameKey.Controls.Add((Control) this.label36);
    this.pnelGameKey.Controls.Add((Control) this.lblTrongTrot);
    this.pnelGameKey.Controls.Add((Control) this.cbo_21);
    this.pnelGameKey.Controls.Add((Control) this.label34);
    this.pnelGameKey.Controls.Add((Control) this.label35);
    this.pnelGameKey.Controls.Add((Control) this.label33);
    this.pnelGameKey.Controls.Add((Control) this.cbo_20);
    this.pnelGameKey.Controls.Add((Control) this.label31);
    this.pnelGameKey.Controls.Add((Control) this.label32);
    this.pnelGameKey.Controls.Add((Control) this.cbo_19);
    this.pnelGameKey.Controls.Add((Control) this.label29);
    this.pnelGameKey.Controls.Add((Control) this.label30);
    this.pnelGameKey.Controls.Add((Control) this.cbo_18);
    this.pnelGameKey.Controls.Add((Control) this.label27);
    this.pnelGameKey.Controls.Add((Control) this.label28);
    this.pnelGameKey.Controls.Add((Control) this.cbo_17);
    this.pnelGameKey.Controls.Add((Control) this.label25);
    this.pnelGameKey.Controls.Add((Control) this.label26);
    this.pnelGameKey.Controls.Add((Control) this.cbo_15);
    this.pnelGameKey.Controls.Add((Control) this.label23);
    this.pnelGameKey.Controls.Add((Control) this.label24);
    this.pnelGameKey.Controls.Add((Control) this.cbo_14);
    this.pnelGameKey.Controls.Add((Control) this.label21);
    this.pnelGameKey.Controls.Add((Control) this.label22);
    this.pnelGameKey.Controls.Add((Control) this.cbo_13);
    this.pnelGameKey.Controls.Add((Control) this.label19);
    this.pnelGameKey.Controls.Add((Control) this.label20);
    this.pnelGameKey.Controls.Add((Control) this.cbo_12);
    this.pnelGameKey.Controls.Add((Control) this.label17);
    this.pnelGameKey.Controls.Add((Control) this.label18);
    this.pnelGameKey.Controls.Add((Control) this.cbo_11);
    this.pnelGameKey.Controls.Add((Control) this.label15);
    this.pnelGameKey.Controls.Add((Control) this.label16);
    this.pnelGameKey.Controls.Add((Control) this.cbo_4);
    this.pnelGameKey.Controls.Add((Control) this.label13);
    this.pnelGameKey.Controls.Add((Control) this.label14);
    this.pnelGameKey.Controls.Add((Control) this.cbo_3);
    this.pnelGameKey.Controls.Add((Control) this.label10);
    this.pnelGameKey.Controls.Add((Control) this.label12);
    this.pnelGameKey.Controls.Add((Control) this.cbo_2);
    this.pnelGameKey.Controls.Add((Control) this.label6);
    this.pnelGameKey.Controls.Add((Control) this.label7);
    this.pnelGameKey.Controls.Add((Control) this.cbo_1);
    this.pnelGameKey.Controls.Add((Control) this.label4);
    this.pnelGameKey.Controls.Add((Control) this.label5);
    this.pnelGameKey.ForeColor = Color.FromArgb(30, 30, 30);
    this.pnelGameKey.Name = "pnelGameKey";
    this.cbo_40.BackColor = Color.FromArgb(206, 233, 253);
    componentResourceManager.ApplyResources((object) this.cbo_40, "cbo_40");
    this.cbo_40.FormattingEnabled = true;
    this.cbo_40.Items.AddRange(new object[60]
    {
      (object) componentResourceManager.GetString("cbo_40.Items"),
      (object) componentResourceManager.GetString("cbo_40.Items1"),
      (object) componentResourceManager.GetString("cbo_40.Items2"),
      (object) componentResourceManager.GetString("cbo_40.Items3"),
      (object) componentResourceManager.GetString("cbo_40.Items4"),
      (object) componentResourceManager.GetString("cbo_40.Items5"),
      (object) componentResourceManager.GetString("cbo_40.Items6"),
      (object) componentResourceManager.GetString("cbo_40.Items7"),
      (object) componentResourceManager.GetString("cbo_40.Items8"),
      (object) componentResourceManager.GetString("cbo_40.Items9"),
      (object) componentResourceManager.GetString("cbo_40.Items10"),
      (object) componentResourceManager.GetString("cbo_40.Items11"),
      (object) componentResourceManager.GetString("cbo_40.Items12"),
      (object) componentResourceManager.GetString("cbo_40.Items13"),
      (object) componentResourceManager.GetString("cbo_40.Items14"),
      (object) componentResourceManager.GetString("cbo_40.Items15"),
      (object) componentResourceManager.GetString("cbo_40.Items16"),
      (object) componentResourceManager.GetString("cbo_40.Items17"),
      (object) componentResourceManager.GetString("cbo_40.Items18"),
      (object) componentResourceManager.GetString("cbo_40.Items19"),
      (object) componentResourceManager.GetString("cbo_40.Items20"),
      (object) componentResourceManager.GetString("cbo_40.Items21"),
      (object) componentResourceManager.GetString("cbo_40.Items22"),
      (object) componentResourceManager.GetString("cbo_40.Items23"),
      (object) componentResourceManager.GetString("cbo_40.Items24"),
      (object) componentResourceManager.GetString("cbo_40.Items25"),
      (object) componentResourceManager.GetString("cbo_40.Items26"),
      (object) componentResourceManager.GetString("cbo_40.Items27"),
      (object) componentResourceManager.GetString("cbo_40.Items28"),
      (object) componentResourceManager.GetString("cbo_40.Items29"),
      (object) componentResourceManager.GetString("cbo_40.Items30"),
      (object) componentResourceManager.GetString("cbo_40.Items31"),
      (object) componentResourceManager.GetString("cbo_40.Items32"),
      (object) componentResourceManager.GetString("cbo_40.Items33"),
      (object) componentResourceManager.GetString("cbo_40.Items34"),
      (object) componentResourceManager.GetString("cbo_40.Items35"),
      (object) componentResourceManager.GetString("cbo_40.Items36"),
      (object) componentResourceManager.GetString("cbo_40.Items37"),
      (object) componentResourceManager.GetString("cbo_40.Items38"),
      (object) componentResourceManager.GetString("cbo_40.Items39"),
      (object) componentResourceManager.GetString("cbo_40.Items40"),
      (object) componentResourceManager.GetString("cbo_40.Items41"),
      (object) componentResourceManager.GetString("cbo_40.Items42"),
      (object) componentResourceManager.GetString("cbo_40.Items43"),
      (object) componentResourceManager.GetString("cbo_40.Items44"),
      (object) componentResourceManager.GetString("cbo_40.Items45"),
      (object) componentResourceManager.GetString("cbo_40.Items46"),
      (object) componentResourceManager.GetString("cbo_40.Items47"),
      (object) componentResourceManager.GetString("cbo_40.Items48"),
      (object) componentResourceManager.GetString("cbo_40.Items49"),
      (object) componentResourceManager.GetString("cbo_40.Items50"),
      (object) componentResourceManager.GetString("cbo_40.Items51"),
      (object) componentResourceManager.GetString("cbo_40.Items52"),
      (object) componentResourceManager.GetString("cbo_40.Items53"),
      (object) componentResourceManager.GetString("cbo_40.Items54"),
      (object) componentResourceManager.GetString("cbo_40.Items55"),
      (object) componentResourceManager.GetString("cbo_40.Items56"),
      (object) componentResourceManager.GetString("cbo_40.Items57"),
      (object) componentResourceManager.GetString("cbo_40.Items58"),
      (object) componentResourceManager.GetString("cbo_40.Items59")
    });
    this.cbo_40.Name = "cbo_40";
    this.cbo_40.SelectedIndexChanged += new EventHandler(this.cbo_1_SelectedIndexChanged);
    componentResourceManager.ApplyResources((object) this.label96, "label96");
    this.label96.Name = "label96";
    componentResourceManager.ApplyResources((object) this.label97, "label97");
    this.label97.Name = "label97";
    this.cbo_39.BackColor = Color.FromArgb(206, 233, 253);
    componentResourceManager.ApplyResources((object) this.cbo_39, "cbo_39");
    this.cbo_39.FormattingEnabled = true;
    this.cbo_39.Items.AddRange(new object[60]
    {
      (object) componentResourceManager.GetString("cbo_39.Items"),
      (object) componentResourceManager.GetString("cbo_39.Items1"),
      (object) componentResourceManager.GetString("cbo_39.Items2"),
      (object) componentResourceManager.GetString("cbo_39.Items3"),
      (object) componentResourceManager.GetString("cbo_39.Items4"),
      (object) componentResourceManager.GetString("cbo_39.Items5"),
      (object) componentResourceManager.GetString("cbo_39.Items6"),
      (object) componentResourceManager.GetString("cbo_39.Items7"),
      (object) componentResourceManager.GetString("cbo_39.Items8"),
      (object) componentResourceManager.GetString("cbo_39.Items9"),
      (object) componentResourceManager.GetString("cbo_39.Items10"),
      (object) componentResourceManager.GetString("cbo_39.Items11"),
      (object) componentResourceManager.GetString("cbo_39.Items12"),
      (object) componentResourceManager.GetString("cbo_39.Items13"),
      (object) componentResourceManager.GetString("cbo_39.Items14"),
      (object) componentResourceManager.GetString("cbo_39.Items15"),
      (object) componentResourceManager.GetString("cbo_39.Items16"),
      (object) componentResourceManager.GetString("cbo_39.Items17"),
      (object) componentResourceManager.GetString("cbo_39.Items18"),
      (object) componentResourceManager.GetString("cbo_39.Items19"),
      (object) componentResourceManager.GetString("cbo_39.Items20"),
      (object) componentResourceManager.GetString("cbo_39.Items21"),
      (object) componentResourceManager.GetString("cbo_39.Items22"),
      (object) componentResourceManager.GetString("cbo_39.Items23"),
      (object) componentResourceManager.GetString("cbo_39.Items24"),
      (object) componentResourceManager.GetString("cbo_39.Items25"),
      (object) componentResourceManager.GetString("cbo_39.Items26"),
      (object) componentResourceManager.GetString("cbo_39.Items27"),
      (object) componentResourceManager.GetString("cbo_39.Items28"),
      (object) componentResourceManager.GetString("cbo_39.Items29"),
      (object) componentResourceManager.GetString("cbo_39.Items30"),
      (object) componentResourceManager.GetString("cbo_39.Items31"),
      (object) componentResourceManager.GetString("cbo_39.Items32"),
      (object) componentResourceManager.GetString("cbo_39.Items33"),
      (object) componentResourceManager.GetString("cbo_39.Items34"),
      (object) componentResourceManager.GetString("cbo_39.Items35"),
      (object) componentResourceManager.GetString("cbo_39.Items36"),
      (object) componentResourceManager.GetString("cbo_39.Items37"),
      (object) componentResourceManager.GetString("cbo_39.Items38"),
      (object) componentResourceManager.GetString("cbo_39.Items39"),
      (object) componentResourceManager.GetString("cbo_39.Items40"),
      (object) componentResourceManager.GetString("cbo_39.Items41"),
      (object) componentResourceManager.GetString("cbo_39.Items42"),
      (object) componentResourceManager.GetString("cbo_39.Items43"),
      (object) componentResourceManager.GetString("cbo_39.Items44"),
      (object) componentResourceManager.GetString("cbo_39.Items45"),
      (object) componentResourceManager.GetString("cbo_39.Items46"),
      (object) componentResourceManager.GetString("cbo_39.Items47"),
      (object) componentResourceManager.GetString("cbo_39.Items48"),
      (object) componentResourceManager.GetString("cbo_39.Items49"),
      (object) componentResourceManager.GetString("cbo_39.Items50"),
      (object) componentResourceManager.GetString("cbo_39.Items51"),
      (object) componentResourceManager.GetString("cbo_39.Items52"),
      (object) componentResourceManager.GetString("cbo_39.Items53"),
      (object) componentResourceManager.GetString("cbo_39.Items54"),
      (object) componentResourceManager.GetString("cbo_39.Items55"),
      (object) componentResourceManager.GetString("cbo_39.Items56"),
      (object) componentResourceManager.GetString("cbo_39.Items57"),
      (object) componentResourceManager.GetString("cbo_39.Items58"),
      (object) componentResourceManager.GetString("cbo_39.Items59")
    });
    this.cbo_39.Name = "cbo_39";
    this.cbo_39.SelectedIndexChanged += new EventHandler(this.cbo_1_SelectedIndexChanged);
    componentResourceManager.ApplyResources((object) this.label98, "label98");
    this.label98.Name = "label98";
    componentResourceManager.ApplyResources((object) this.label99, "label99");
    this.label99.Name = "label99";
    this.cbo_43.BackColor = Color.FromArgb(206, 233, 253);
    componentResourceManager.ApplyResources((object) this.cbo_43, "cbo_43");
    this.cbo_43.FormattingEnabled = true;
    this.cbo_43.Items.AddRange(new object[60]
    {
      (object) componentResourceManager.GetString("cbo_43.Items"),
      (object) componentResourceManager.GetString("cbo_43.Items1"),
      (object) componentResourceManager.GetString("cbo_43.Items2"),
      (object) componentResourceManager.GetString("cbo_43.Items3"),
      (object) componentResourceManager.GetString("cbo_43.Items4"),
      (object) componentResourceManager.GetString("cbo_43.Items5"),
      (object) componentResourceManager.GetString("cbo_43.Items6"),
      (object) componentResourceManager.GetString("cbo_43.Items7"),
      (object) componentResourceManager.GetString("cbo_43.Items8"),
      (object) componentResourceManager.GetString("cbo_43.Items9"),
      (object) componentResourceManager.GetString("cbo_43.Items10"),
      (object) componentResourceManager.GetString("cbo_43.Items11"),
      (object) componentResourceManager.GetString("cbo_43.Items12"),
      (object) componentResourceManager.GetString("cbo_43.Items13"),
      (object) componentResourceManager.GetString("cbo_43.Items14"),
      (object) componentResourceManager.GetString("cbo_43.Items15"),
      (object) componentResourceManager.GetString("cbo_43.Items16"),
      (object) componentResourceManager.GetString("cbo_43.Items17"),
      (object) componentResourceManager.GetString("cbo_43.Items18"),
      (object) componentResourceManager.GetString("cbo_43.Items19"),
      (object) componentResourceManager.GetString("cbo_43.Items20"),
      (object) componentResourceManager.GetString("cbo_43.Items21"),
      (object) componentResourceManager.GetString("cbo_43.Items22"),
      (object) componentResourceManager.GetString("cbo_43.Items23"),
      (object) componentResourceManager.GetString("cbo_43.Items24"),
      (object) componentResourceManager.GetString("cbo_43.Items25"),
      (object) componentResourceManager.GetString("cbo_43.Items26"),
      (object) componentResourceManager.GetString("cbo_43.Items27"),
      (object) componentResourceManager.GetString("cbo_43.Items28"),
      (object) componentResourceManager.GetString("cbo_43.Items29"),
      (object) componentResourceManager.GetString("cbo_43.Items30"),
      (object) componentResourceManager.GetString("cbo_43.Items31"),
      (object) componentResourceManager.GetString("cbo_43.Items32"),
      (object) componentResourceManager.GetString("cbo_43.Items33"),
      (object) componentResourceManager.GetString("cbo_43.Items34"),
      (object) componentResourceManager.GetString("cbo_43.Items35"),
      (object) componentResourceManager.GetString("cbo_43.Items36"),
      (object) componentResourceManager.GetString("cbo_43.Items37"),
      (object) componentResourceManager.GetString("cbo_43.Items38"),
      (object) componentResourceManager.GetString("cbo_43.Items39"),
      (object) componentResourceManager.GetString("cbo_43.Items40"),
      (object) componentResourceManager.GetString("cbo_43.Items41"),
      (object) componentResourceManager.GetString("cbo_43.Items42"),
      (object) componentResourceManager.GetString("cbo_43.Items43"),
      (object) componentResourceManager.GetString("cbo_43.Items44"),
      (object) componentResourceManager.GetString("cbo_43.Items45"),
      (object) componentResourceManager.GetString("cbo_43.Items46"),
      (object) componentResourceManager.GetString("cbo_43.Items47"),
      (object) componentResourceManager.GetString("cbo_43.Items48"),
      (object) componentResourceManager.GetString("cbo_43.Items49"),
      (object) componentResourceManager.GetString("cbo_43.Items50"),
      (object) componentResourceManager.GetString("cbo_43.Items51"),
      (object) componentResourceManager.GetString("cbo_43.Items52"),
      (object) componentResourceManager.GetString("cbo_43.Items53"),
      (object) componentResourceManager.GetString("cbo_43.Items54"),
      (object) componentResourceManager.GetString("cbo_43.Items55"),
      (object) componentResourceManager.GetString("cbo_43.Items56"),
      (object) componentResourceManager.GetString("cbo_43.Items57"),
      (object) componentResourceManager.GetString("cbo_43.Items58"),
      (object) componentResourceManager.GetString("cbo_43.Items59")
    });
    this.cbo_43.Name = "cbo_43";
    this.cbo_43.SelectedIndexChanged += new EventHandler(this.cbo_1_SelectedIndexChanged);
    componentResourceManager.ApplyResources((object) this.label100, "label100");
    this.label100.Name = "label100";
    componentResourceManager.ApplyResources((object) this.label101, "label101");
    this.label101.Name = "label101";
    this.cbo_42.BackColor = Color.FromArgb(206, 233, 253);
    componentResourceManager.ApplyResources((object) this.cbo_42, "cbo_42");
    this.cbo_42.FormattingEnabled = true;
    this.cbo_42.Items.AddRange(new object[60]
    {
      (object) componentResourceManager.GetString("cbo_42.Items"),
      (object) componentResourceManager.GetString("cbo_42.Items1"),
      (object) componentResourceManager.GetString("cbo_42.Items2"),
      (object) componentResourceManager.GetString("cbo_42.Items3"),
      (object) componentResourceManager.GetString("cbo_42.Items4"),
      (object) componentResourceManager.GetString("cbo_42.Items5"),
      (object) componentResourceManager.GetString("cbo_42.Items6"),
      (object) componentResourceManager.GetString("cbo_42.Items7"),
      (object) componentResourceManager.GetString("cbo_42.Items8"),
      (object) componentResourceManager.GetString("cbo_42.Items9"),
      (object) componentResourceManager.GetString("cbo_42.Items10"),
      (object) componentResourceManager.GetString("cbo_42.Items11"),
      (object) componentResourceManager.GetString("cbo_42.Items12"),
      (object) componentResourceManager.GetString("cbo_42.Items13"),
      (object) componentResourceManager.GetString("cbo_42.Items14"),
      (object) componentResourceManager.GetString("cbo_42.Items15"),
      (object) componentResourceManager.GetString("cbo_42.Items16"),
      (object) componentResourceManager.GetString("cbo_42.Items17"),
      (object) componentResourceManager.GetString("cbo_42.Items18"),
      (object) componentResourceManager.GetString("cbo_42.Items19"),
      (object) componentResourceManager.GetString("cbo_42.Items20"),
      (object) componentResourceManager.GetString("cbo_42.Items21"),
      (object) componentResourceManager.GetString("cbo_42.Items22"),
      (object) componentResourceManager.GetString("cbo_42.Items23"),
      (object) componentResourceManager.GetString("cbo_42.Items24"),
      (object) componentResourceManager.GetString("cbo_42.Items25"),
      (object) componentResourceManager.GetString("cbo_42.Items26"),
      (object) componentResourceManager.GetString("cbo_42.Items27"),
      (object) componentResourceManager.GetString("cbo_42.Items28"),
      (object) componentResourceManager.GetString("cbo_42.Items29"),
      (object) componentResourceManager.GetString("cbo_42.Items30"),
      (object) componentResourceManager.GetString("cbo_42.Items31"),
      (object) componentResourceManager.GetString("cbo_42.Items32"),
      (object) componentResourceManager.GetString("cbo_42.Items33"),
      (object) componentResourceManager.GetString("cbo_42.Items34"),
      (object) componentResourceManager.GetString("cbo_42.Items35"),
      (object) componentResourceManager.GetString("cbo_42.Items36"),
      (object) componentResourceManager.GetString("cbo_42.Items37"),
      (object) componentResourceManager.GetString("cbo_42.Items38"),
      (object) componentResourceManager.GetString("cbo_42.Items39"),
      (object) componentResourceManager.GetString("cbo_42.Items40"),
      (object) componentResourceManager.GetString("cbo_42.Items41"),
      (object) componentResourceManager.GetString("cbo_42.Items42"),
      (object) componentResourceManager.GetString("cbo_42.Items43"),
      (object) componentResourceManager.GetString("cbo_42.Items44"),
      (object) componentResourceManager.GetString("cbo_42.Items45"),
      (object) componentResourceManager.GetString("cbo_42.Items46"),
      (object) componentResourceManager.GetString("cbo_42.Items47"),
      (object) componentResourceManager.GetString("cbo_42.Items48"),
      (object) componentResourceManager.GetString("cbo_42.Items49"),
      (object) componentResourceManager.GetString("cbo_42.Items50"),
      (object) componentResourceManager.GetString("cbo_42.Items51"),
      (object) componentResourceManager.GetString("cbo_42.Items52"),
      (object) componentResourceManager.GetString("cbo_42.Items53"),
      (object) componentResourceManager.GetString("cbo_42.Items54"),
      (object) componentResourceManager.GetString("cbo_42.Items55"),
      (object) componentResourceManager.GetString("cbo_42.Items56"),
      (object) componentResourceManager.GetString("cbo_42.Items57"),
      (object) componentResourceManager.GetString("cbo_42.Items58"),
      (object) componentResourceManager.GetString("cbo_42.Items59")
    });
    this.cbo_42.Name = "cbo_42";
    this.cbo_42.SelectedIndexChanged += new EventHandler(this.cbo_1_SelectedIndexChanged);
    componentResourceManager.ApplyResources((object) this.label102, "label102");
    this.label102.Name = "label102";
    componentResourceManager.ApplyResources((object) this.label103, "label103");
    this.label103.Name = "label103";
    this.cbo_41.BackColor = Color.FromArgb(206, 233, 253);
    componentResourceManager.ApplyResources((object) this.cbo_41, "cbo_41");
    this.cbo_41.FormattingEnabled = true;
    this.cbo_41.Items.AddRange(new object[60]
    {
      (object) componentResourceManager.GetString("cbo_41.Items"),
      (object) componentResourceManager.GetString("cbo_41.Items1"),
      (object) componentResourceManager.GetString("cbo_41.Items2"),
      (object) componentResourceManager.GetString("cbo_41.Items3"),
      (object) componentResourceManager.GetString("cbo_41.Items4"),
      (object) componentResourceManager.GetString("cbo_41.Items5"),
      (object) componentResourceManager.GetString("cbo_41.Items6"),
      (object) componentResourceManager.GetString("cbo_41.Items7"),
      (object) componentResourceManager.GetString("cbo_41.Items8"),
      (object) componentResourceManager.GetString("cbo_41.Items9"),
      (object) componentResourceManager.GetString("cbo_41.Items10"),
      (object) componentResourceManager.GetString("cbo_41.Items11"),
      (object) componentResourceManager.GetString("cbo_41.Items12"),
      (object) componentResourceManager.GetString("cbo_41.Items13"),
      (object) componentResourceManager.GetString("cbo_41.Items14"),
      (object) componentResourceManager.GetString("cbo_41.Items15"),
      (object) componentResourceManager.GetString("cbo_41.Items16"),
      (object) componentResourceManager.GetString("cbo_41.Items17"),
      (object) componentResourceManager.GetString("cbo_41.Items18"),
      (object) componentResourceManager.GetString("cbo_41.Items19"),
      (object) componentResourceManager.GetString("cbo_41.Items20"),
      (object) componentResourceManager.GetString("cbo_41.Items21"),
      (object) componentResourceManager.GetString("cbo_41.Items22"),
      (object) componentResourceManager.GetString("cbo_41.Items23"),
      (object) componentResourceManager.GetString("cbo_41.Items24"),
      (object) componentResourceManager.GetString("cbo_41.Items25"),
      (object) componentResourceManager.GetString("cbo_41.Items26"),
      (object) componentResourceManager.GetString("cbo_41.Items27"),
      (object) componentResourceManager.GetString("cbo_41.Items28"),
      (object) componentResourceManager.GetString("cbo_41.Items29"),
      (object) componentResourceManager.GetString("cbo_41.Items30"),
      (object) componentResourceManager.GetString("cbo_41.Items31"),
      (object) componentResourceManager.GetString("cbo_41.Items32"),
      (object) componentResourceManager.GetString("cbo_41.Items33"),
      (object) componentResourceManager.GetString("cbo_41.Items34"),
      (object) componentResourceManager.GetString("cbo_41.Items35"),
      (object) componentResourceManager.GetString("cbo_41.Items36"),
      (object) componentResourceManager.GetString("cbo_41.Items37"),
      (object) componentResourceManager.GetString("cbo_41.Items38"),
      (object) componentResourceManager.GetString("cbo_41.Items39"),
      (object) componentResourceManager.GetString("cbo_41.Items40"),
      (object) componentResourceManager.GetString("cbo_41.Items41"),
      (object) componentResourceManager.GetString("cbo_41.Items42"),
      (object) componentResourceManager.GetString("cbo_41.Items43"),
      (object) componentResourceManager.GetString("cbo_41.Items44"),
      (object) componentResourceManager.GetString("cbo_41.Items45"),
      (object) componentResourceManager.GetString("cbo_41.Items46"),
      (object) componentResourceManager.GetString("cbo_41.Items47"),
      (object) componentResourceManager.GetString("cbo_41.Items48"),
      (object) componentResourceManager.GetString("cbo_41.Items49"),
      (object) componentResourceManager.GetString("cbo_41.Items50"),
      (object) componentResourceManager.GetString("cbo_41.Items51"),
      (object) componentResourceManager.GetString("cbo_41.Items52"),
      (object) componentResourceManager.GetString("cbo_41.Items53"),
      (object) componentResourceManager.GetString("cbo_41.Items54"),
      (object) componentResourceManager.GetString("cbo_41.Items55"),
      (object) componentResourceManager.GetString("cbo_41.Items56"),
      (object) componentResourceManager.GetString("cbo_41.Items57"),
      (object) componentResourceManager.GetString("cbo_41.Items58"),
      (object) componentResourceManager.GetString("cbo_41.Items59")
    });
    this.cbo_41.Name = "cbo_41";
    this.cbo_41.SelectedIndexChanged += new EventHandler(this.cbo_1_SelectedIndexChanged);
    componentResourceManager.ApplyResources((object) this.label104, "label104");
    this.label104.Name = "label104";
    componentResourceManager.ApplyResources((object) this.label105, "label105");
    this.label105.Name = "label105";
    this.cbo_38.BackColor = Color.FromArgb(206, 233, 253);
    componentResourceManager.ApplyResources((object) this.cbo_38, "cbo_38");
    this.cbo_38.FormattingEnabled = true;
    this.cbo_38.Items.AddRange(new object[60]
    {
      (object) componentResourceManager.GetString("cbo_38.Items"),
      (object) componentResourceManager.GetString("cbo_38.Items1"),
      (object) componentResourceManager.GetString("cbo_38.Items2"),
      (object) componentResourceManager.GetString("cbo_38.Items3"),
      (object) componentResourceManager.GetString("cbo_38.Items4"),
      (object) componentResourceManager.GetString("cbo_38.Items5"),
      (object) componentResourceManager.GetString("cbo_38.Items6"),
      (object) componentResourceManager.GetString("cbo_38.Items7"),
      (object) componentResourceManager.GetString("cbo_38.Items8"),
      (object) componentResourceManager.GetString("cbo_38.Items9"),
      (object) componentResourceManager.GetString("cbo_38.Items10"),
      (object) componentResourceManager.GetString("cbo_38.Items11"),
      (object) componentResourceManager.GetString("cbo_38.Items12"),
      (object) componentResourceManager.GetString("cbo_38.Items13"),
      (object) componentResourceManager.GetString("cbo_38.Items14"),
      (object) componentResourceManager.GetString("cbo_38.Items15"),
      (object) componentResourceManager.GetString("cbo_38.Items16"),
      (object) componentResourceManager.GetString("cbo_38.Items17"),
      (object) componentResourceManager.GetString("cbo_38.Items18"),
      (object) componentResourceManager.GetString("cbo_38.Items19"),
      (object) componentResourceManager.GetString("cbo_38.Items20"),
      (object) componentResourceManager.GetString("cbo_38.Items21"),
      (object) componentResourceManager.GetString("cbo_38.Items22"),
      (object) componentResourceManager.GetString("cbo_38.Items23"),
      (object) componentResourceManager.GetString("cbo_38.Items24"),
      (object) componentResourceManager.GetString("cbo_38.Items25"),
      (object) componentResourceManager.GetString("cbo_38.Items26"),
      (object) componentResourceManager.GetString("cbo_38.Items27"),
      (object) componentResourceManager.GetString("cbo_38.Items28"),
      (object) componentResourceManager.GetString("cbo_38.Items29"),
      (object) componentResourceManager.GetString("cbo_38.Items30"),
      (object) componentResourceManager.GetString("cbo_38.Items31"),
      (object) componentResourceManager.GetString("cbo_38.Items32"),
      (object) componentResourceManager.GetString("cbo_38.Items33"),
      (object) componentResourceManager.GetString("cbo_38.Items34"),
      (object) componentResourceManager.GetString("cbo_38.Items35"),
      (object) componentResourceManager.GetString("cbo_38.Items36"),
      (object) componentResourceManager.GetString("cbo_38.Items37"),
      (object) componentResourceManager.GetString("cbo_38.Items38"),
      (object) componentResourceManager.GetString("cbo_38.Items39"),
      (object) componentResourceManager.GetString("cbo_38.Items40"),
      (object) componentResourceManager.GetString("cbo_38.Items41"),
      (object) componentResourceManager.GetString("cbo_38.Items42"),
      (object) componentResourceManager.GetString("cbo_38.Items43"),
      (object) componentResourceManager.GetString("cbo_38.Items44"),
      (object) componentResourceManager.GetString("cbo_38.Items45"),
      (object) componentResourceManager.GetString("cbo_38.Items46"),
      (object) componentResourceManager.GetString("cbo_38.Items47"),
      (object) componentResourceManager.GetString("cbo_38.Items48"),
      (object) componentResourceManager.GetString("cbo_38.Items49"),
      (object) componentResourceManager.GetString("cbo_38.Items50"),
      (object) componentResourceManager.GetString("cbo_38.Items51"),
      (object) componentResourceManager.GetString("cbo_38.Items52"),
      (object) componentResourceManager.GetString("cbo_38.Items53"),
      (object) componentResourceManager.GetString("cbo_38.Items54"),
      (object) componentResourceManager.GetString("cbo_38.Items55"),
      (object) componentResourceManager.GetString("cbo_38.Items56"),
      (object) componentResourceManager.GetString("cbo_38.Items57"),
      (object) componentResourceManager.GetString("cbo_38.Items58"),
      (object) componentResourceManager.GetString("cbo_38.Items59")
    });
    this.cbo_38.Name = "cbo_38";
    this.cbo_38.SelectedIndexChanged += new EventHandler(this.cbo_1_SelectedIndexChanged);
    componentResourceManager.ApplyResources((object) this.label94, "label94");
    this.label94.Name = "label94";
    componentResourceManager.ApplyResources((object) this.label95, "label95");
    this.label95.Name = "label95";
    this.cbo_35.BackColor = Color.FromArgb(206, 233, 253);
    componentResourceManager.ApplyResources((object) this.cbo_35, "cbo_35");
    this.cbo_35.FormattingEnabled = true;
    this.cbo_35.Items.AddRange(new object[60]
    {
      (object) componentResourceManager.GetString("cbo_35.Items"),
      (object) componentResourceManager.GetString("cbo_35.Items1"),
      (object) componentResourceManager.GetString("cbo_35.Items2"),
      (object) componentResourceManager.GetString("cbo_35.Items3"),
      (object) componentResourceManager.GetString("cbo_35.Items4"),
      (object) componentResourceManager.GetString("cbo_35.Items5"),
      (object) componentResourceManager.GetString("cbo_35.Items6"),
      (object) componentResourceManager.GetString("cbo_35.Items7"),
      (object) componentResourceManager.GetString("cbo_35.Items8"),
      (object) componentResourceManager.GetString("cbo_35.Items9"),
      (object) componentResourceManager.GetString("cbo_35.Items10"),
      (object) componentResourceManager.GetString("cbo_35.Items11"),
      (object) componentResourceManager.GetString("cbo_35.Items12"),
      (object) componentResourceManager.GetString("cbo_35.Items13"),
      (object) componentResourceManager.GetString("cbo_35.Items14"),
      (object) componentResourceManager.GetString("cbo_35.Items15"),
      (object) componentResourceManager.GetString("cbo_35.Items16"),
      (object) componentResourceManager.GetString("cbo_35.Items17"),
      (object) componentResourceManager.GetString("cbo_35.Items18"),
      (object) componentResourceManager.GetString("cbo_35.Items19"),
      (object) componentResourceManager.GetString("cbo_35.Items20"),
      (object) componentResourceManager.GetString("cbo_35.Items21"),
      (object) componentResourceManager.GetString("cbo_35.Items22"),
      (object) componentResourceManager.GetString("cbo_35.Items23"),
      (object) componentResourceManager.GetString("cbo_35.Items24"),
      (object) componentResourceManager.GetString("cbo_35.Items25"),
      (object) componentResourceManager.GetString("cbo_35.Items26"),
      (object) componentResourceManager.GetString("cbo_35.Items27"),
      (object) componentResourceManager.GetString("cbo_35.Items28"),
      (object) componentResourceManager.GetString("cbo_35.Items29"),
      (object) componentResourceManager.GetString("cbo_35.Items30"),
      (object) componentResourceManager.GetString("cbo_35.Items31"),
      (object) componentResourceManager.GetString("cbo_35.Items32"),
      (object) componentResourceManager.GetString("cbo_35.Items33"),
      (object) componentResourceManager.GetString("cbo_35.Items34"),
      (object) componentResourceManager.GetString("cbo_35.Items35"),
      (object) componentResourceManager.GetString("cbo_35.Items36"),
      (object) componentResourceManager.GetString("cbo_35.Items37"),
      (object) componentResourceManager.GetString("cbo_35.Items38"),
      (object) componentResourceManager.GetString("cbo_35.Items39"),
      (object) componentResourceManager.GetString("cbo_35.Items40"),
      (object) componentResourceManager.GetString("cbo_35.Items41"),
      (object) componentResourceManager.GetString("cbo_35.Items42"),
      (object) componentResourceManager.GetString("cbo_35.Items43"),
      (object) componentResourceManager.GetString("cbo_35.Items44"),
      (object) componentResourceManager.GetString("cbo_35.Items45"),
      (object) componentResourceManager.GetString("cbo_35.Items46"),
      (object) componentResourceManager.GetString("cbo_35.Items47"),
      (object) componentResourceManager.GetString("cbo_35.Items48"),
      (object) componentResourceManager.GetString("cbo_35.Items49"),
      (object) componentResourceManager.GetString("cbo_35.Items50"),
      (object) componentResourceManager.GetString("cbo_35.Items51"),
      (object) componentResourceManager.GetString("cbo_35.Items52"),
      (object) componentResourceManager.GetString("cbo_35.Items53"),
      (object) componentResourceManager.GetString("cbo_35.Items54"),
      (object) componentResourceManager.GetString("cbo_35.Items55"),
      (object) componentResourceManager.GetString("cbo_35.Items56"),
      (object) componentResourceManager.GetString("cbo_35.Items57"),
      (object) componentResourceManager.GetString("cbo_35.Items58"),
      (object) componentResourceManager.GetString("cbo_35.Items59")
    });
    this.cbo_35.Name = "cbo_35";
    this.cbo_35.SelectedIndexChanged += new EventHandler(this.cbo_1_SelectedIndexChanged);
    componentResourceManager.ApplyResources((object) this.label90, "label90");
    this.label90.Name = "label90";
    componentResourceManager.ApplyResources((object) this.label91, "label91");
    this.label91.Name = "label91";
    this.cbo_34.BackColor = Color.FromArgb(206, 233, 253);
    componentResourceManager.ApplyResources((object) this.cbo_34, "cbo_34");
    this.cbo_34.FormattingEnabled = true;
    this.cbo_34.Items.AddRange(new object[60]
    {
      (object) componentResourceManager.GetString("cbo_34.Items"),
      (object) componentResourceManager.GetString("cbo_34.Items1"),
      (object) componentResourceManager.GetString("cbo_34.Items2"),
      (object) componentResourceManager.GetString("cbo_34.Items3"),
      (object) componentResourceManager.GetString("cbo_34.Items4"),
      (object) componentResourceManager.GetString("cbo_34.Items5"),
      (object) componentResourceManager.GetString("cbo_34.Items6"),
      (object) componentResourceManager.GetString("cbo_34.Items7"),
      (object) componentResourceManager.GetString("cbo_34.Items8"),
      (object) componentResourceManager.GetString("cbo_34.Items9"),
      (object) componentResourceManager.GetString("cbo_34.Items10"),
      (object) componentResourceManager.GetString("cbo_34.Items11"),
      (object) componentResourceManager.GetString("cbo_34.Items12"),
      (object) componentResourceManager.GetString("cbo_34.Items13"),
      (object) componentResourceManager.GetString("cbo_34.Items14"),
      (object) componentResourceManager.GetString("cbo_34.Items15"),
      (object) componentResourceManager.GetString("cbo_34.Items16"),
      (object) componentResourceManager.GetString("cbo_34.Items17"),
      (object) componentResourceManager.GetString("cbo_34.Items18"),
      (object) componentResourceManager.GetString("cbo_34.Items19"),
      (object) componentResourceManager.GetString("cbo_34.Items20"),
      (object) componentResourceManager.GetString("cbo_34.Items21"),
      (object) componentResourceManager.GetString("cbo_34.Items22"),
      (object) componentResourceManager.GetString("cbo_34.Items23"),
      (object) componentResourceManager.GetString("cbo_34.Items24"),
      (object) componentResourceManager.GetString("cbo_34.Items25"),
      (object) componentResourceManager.GetString("cbo_34.Items26"),
      (object) componentResourceManager.GetString("cbo_34.Items27"),
      (object) componentResourceManager.GetString("cbo_34.Items28"),
      (object) componentResourceManager.GetString("cbo_34.Items29"),
      (object) componentResourceManager.GetString("cbo_34.Items30"),
      (object) componentResourceManager.GetString("cbo_34.Items31"),
      (object) componentResourceManager.GetString("cbo_34.Items32"),
      (object) componentResourceManager.GetString("cbo_34.Items33"),
      (object) componentResourceManager.GetString("cbo_34.Items34"),
      (object) componentResourceManager.GetString("cbo_34.Items35"),
      (object) componentResourceManager.GetString("cbo_34.Items36"),
      (object) componentResourceManager.GetString("cbo_34.Items37"),
      (object) componentResourceManager.GetString("cbo_34.Items38"),
      (object) componentResourceManager.GetString("cbo_34.Items39"),
      (object) componentResourceManager.GetString("cbo_34.Items40"),
      (object) componentResourceManager.GetString("cbo_34.Items41"),
      (object) componentResourceManager.GetString("cbo_34.Items42"),
      (object) componentResourceManager.GetString("cbo_34.Items43"),
      (object) componentResourceManager.GetString("cbo_34.Items44"),
      (object) componentResourceManager.GetString("cbo_34.Items45"),
      (object) componentResourceManager.GetString("cbo_34.Items46"),
      (object) componentResourceManager.GetString("cbo_34.Items47"),
      (object) componentResourceManager.GetString("cbo_34.Items48"),
      (object) componentResourceManager.GetString("cbo_34.Items49"),
      (object) componentResourceManager.GetString("cbo_34.Items50"),
      (object) componentResourceManager.GetString("cbo_34.Items51"),
      (object) componentResourceManager.GetString("cbo_34.Items52"),
      (object) componentResourceManager.GetString("cbo_34.Items53"),
      (object) componentResourceManager.GetString("cbo_34.Items54"),
      (object) componentResourceManager.GetString("cbo_34.Items55"),
      (object) componentResourceManager.GetString("cbo_34.Items56"),
      (object) componentResourceManager.GetString("cbo_34.Items57"),
      (object) componentResourceManager.GetString("cbo_34.Items58"),
      (object) componentResourceManager.GetString("cbo_34.Items59")
    });
    this.cbo_34.Name = "cbo_34";
    this.cbo_34.SelectedIndexChanged += new EventHandler(this.cbo_1_SelectedIndexChanged);
    componentResourceManager.ApplyResources((object) this.label92, "label92");
    this.label92.Name = "label92";
    componentResourceManager.ApplyResources((object) this.label93, "label93");
    this.label93.Name = "label93";
    this.cbo_37.BackColor = Color.FromArgb(206, 233, 253);
    componentResourceManager.ApplyResources((object) this.cbo_37, "cbo_37");
    this.cbo_37.FormattingEnabled = true;
    this.cbo_37.Items.AddRange(new object[60]
    {
      (object) componentResourceManager.GetString("cbo_37.Items"),
      (object) componentResourceManager.GetString("cbo_37.Items1"),
      (object) componentResourceManager.GetString("cbo_37.Items2"),
      (object) componentResourceManager.GetString("cbo_37.Items3"),
      (object) componentResourceManager.GetString("cbo_37.Items4"),
      (object) componentResourceManager.GetString("cbo_37.Items5"),
      (object) componentResourceManager.GetString("cbo_37.Items6"),
      (object) componentResourceManager.GetString("cbo_37.Items7"),
      (object) componentResourceManager.GetString("cbo_37.Items8"),
      (object) componentResourceManager.GetString("cbo_37.Items9"),
      (object) componentResourceManager.GetString("cbo_37.Items10"),
      (object) componentResourceManager.GetString("cbo_37.Items11"),
      (object) componentResourceManager.GetString("cbo_37.Items12"),
      (object) componentResourceManager.GetString("cbo_37.Items13"),
      (object) componentResourceManager.GetString("cbo_37.Items14"),
      (object) componentResourceManager.GetString("cbo_37.Items15"),
      (object) componentResourceManager.GetString("cbo_37.Items16"),
      (object) componentResourceManager.GetString("cbo_37.Items17"),
      (object) componentResourceManager.GetString("cbo_37.Items18"),
      (object) componentResourceManager.GetString("cbo_37.Items19"),
      (object) componentResourceManager.GetString("cbo_37.Items20"),
      (object) componentResourceManager.GetString("cbo_37.Items21"),
      (object) componentResourceManager.GetString("cbo_37.Items22"),
      (object) componentResourceManager.GetString("cbo_37.Items23"),
      (object) componentResourceManager.GetString("cbo_37.Items24"),
      (object) componentResourceManager.GetString("cbo_37.Items25"),
      (object) componentResourceManager.GetString("cbo_37.Items26"),
      (object) componentResourceManager.GetString("cbo_37.Items27"),
      (object) componentResourceManager.GetString("cbo_37.Items28"),
      (object) componentResourceManager.GetString("cbo_37.Items29"),
      (object) componentResourceManager.GetString("cbo_37.Items30"),
      (object) componentResourceManager.GetString("cbo_37.Items31"),
      (object) componentResourceManager.GetString("cbo_37.Items32"),
      (object) componentResourceManager.GetString("cbo_37.Items33"),
      (object) componentResourceManager.GetString("cbo_37.Items34"),
      (object) componentResourceManager.GetString("cbo_37.Items35"),
      (object) componentResourceManager.GetString("cbo_37.Items36"),
      (object) componentResourceManager.GetString("cbo_37.Items37"),
      (object) componentResourceManager.GetString("cbo_37.Items38"),
      (object) componentResourceManager.GetString("cbo_37.Items39"),
      (object) componentResourceManager.GetString("cbo_37.Items40"),
      (object) componentResourceManager.GetString("cbo_37.Items41"),
      (object) componentResourceManager.GetString("cbo_37.Items42"),
      (object) componentResourceManager.GetString("cbo_37.Items43"),
      (object) componentResourceManager.GetString("cbo_37.Items44"),
      (object) componentResourceManager.GetString("cbo_37.Items45"),
      (object) componentResourceManager.GetString("cbo_37.Items46"),
      (object) componentResourceManager.GetString("cbo_37.Items47"),
      (object) componentResourceManager.GetString("cbo_37.Items48"),
      (object) componentResourceManager.GetString("cbo_37.Items49"),
      (object) componentResourceManager.GetString("cbo_37.Items50"),
      (object) componentResourceManager.GetString("cbo_37.Items51"),
      (object) componentResourceManager.GetString("cbo_37.Items52"),
      (object) componentResourceManager.GetString("cbo_37.Items53"),
      (object) componentResourceManager.GetString("cbo_37.Items54"),
      (object) componentResourceManager.GetString("cbo_37.Items55"),
      (object) componentResourceManager.GetString("cbo_37.Items56"),
      (object) componentResourceManager.GetString("cbo_37.Items57"),
      (object) componentResourceManager.GetString("cbo_37.Items58"),
      (object) componentResourceManager.GetString("cbo_37.Items59")
    });
    this.cbo_37.Name = "cbo_37";
    this.cbo_37.SelectedIndexChanged += new EventHandler(this.cbo_1_SelectedIndexChanged);
    this.cbo_36.BackColor = Color.FromArgb(206, 233, 253);
    componentResourceManager.ApplyResources((object) this.cbo_36, "cbo_36");
    this.cbo_36.FormattingEnabled = true;
    this.cbo_36.Items.AddRange(new object[60]
    {
      (object) componentResourceManager.GetString("cbo_36.Items"),
      (object) componentResourceManager.GetString("cbo_36.Items1"),
      (object) componentResourceManager.GetString("cbo_36.Items2"),
      (object) componentResourceManager.GetString("cbo_36.Items3"),
      (object) componentResourceManager.GetString("cbo_36.Items4"),
      (object) componentResourceManager.GetString("cbo_36.Items5"),
      (object) componentResourceManager.GetString("cbo_36.Items6"),
      (object) componentResourceManager.GetString("cbo_36.Items7"),
      (object) componentResourceManager.GetString("cbo_36.Items8"),
      (object) componentResourceManager.GetString("cbo_36.Items9"),
      (object) componentResourceManager.GetString("cbo_36.Items10"),
      (object) componentResourceManager.GetString("cbo_36.Items11"),
      (object) componentResourceManager.GetString("cbo_36.Items12"),
      (object) componentResourceManager.GetString("cbo_36.Items13"),
      (object) componentResourceManager.GetString("cbo_36.Items14"),
      (object) componentResourceManager.GetString("cbo_36.Items15"),
      (object) componentResourceManager.GetString("cbo_36.Items16"),
      (object) componentResourceManager.GetString("cbo_36.Items17"),
      (object) componentResourceManager.GetString("cbo_36.Items18"),
      (object) componentResourceManager.GetString("cbo_36.Items19"),
      (object) componentResourceManager.GetString("cbo_36.Items20"),
      (object) componentResourceManager.GetString("cbo_36.Items21"),
      (object) componentResourceManager.GetString("cbo_36.Items22"),
      (object) componentResourceManager.GetString("cbo_36.Items23"),
      (object) componentResourceManager.GetString("cbo_36.Items24"),
      (object) componentResourceManager.GetString("cbo_36.Items25"),
      (object) componentResourceManager.GetString("cbo_36.Items26"),
      (object) componentResourceManager.GetString("cbo_36.Items27"),
      (object) componentResourceManager.GetString("cbo_36.Items28"),
      (object) componentResourceManager.GetString("cbo_36.Items29"),
      (object) componentResourceManager.GetString("cbo_36.Items30"),
      (object) componentResourceManager.GetString("cbo_36.Items31"),
      (object) componentResourceManager.GetString("cbo_36.Items32"),
      (object) componentResourceManager.GetString("cbo_36.Items33"),
      (object) componentResourceManager.GetString("cbo_36.Items34"),
      (object) componentResourceManager.GetString("cbo_36.Items35"),
      (object) componentResourceManager.GetString("cbo_36.Items36"),
      (object) componentResourceManager.GetString("cbo_36.Items37"),
      (object) componentResourceManager.GetString("cbo_36.Items38"),
      (object) componentResourceManager.GetString("cbo_36.Items39"),
      (object) componentResourceManager.GetString("cbo_36.Items40"),
      (object) componentResourceManager.GetString("cbo_36.Items41"),
      (object) componentResourceManager.GetString("cbo_36.Items42"),
      (object) componentResourceManager.GetString("cbo_36.Items43"),
      (object) componentResourceManager.GetString("cbo_36.Items44"),
      (object) componentResourceManager.GetString("cbo_36.Items45"),
      (object) componentResourceManager.GetString("cbo_36.Items46"),
      (object) componentResourceManager.GetString("cbo_36.Items47"),
      (object) componentResourceManager.GetString("cbo_36.Items48"),
      (object) componentResourceManager.GetString("cbo_36.Items49"),
      (object) componentResourceManager.GetString("cbo_36.Items50"),
      (object) componentResourceManager.GetString("cbo_36.Items51"),
      (object) componentResourceManager.GetString("cbo_36.Items52"),
      (object) componentResourceManager.GetString("cbo_36.Items53"),
      (object) componentResourceManager.GetString("cbo_36.Items54"),
      (object) componentResourceManager.GetString("cbo_36.Items55"),
      (object) componentResourceManager.GetString("cbo_36.Items56"),
      (object) componentResourceManager.GetString("cbo_36.Items57"),
      (object) componentResourceManager.GetString("cbo_36.Items58"),
      (object) componentResourceManager.GetString("cbo_36.Items59")
    });
    this.cbo_36.Name = "cbo_36";
    this.cbo_36.SelectedIndexChanged += new EventHandler(this.cbo_1_SelectedIndexChanged);
    componentResourceManager.ApplyResources((object) this.label86, "label86");
    this.label86.Name = "label86";
    componentResourceManager.ApplyResources((object) this.label88, "label88");
    this.label88.Name = "label88";
    componentResourceManager.ApplyResources((object) this.label87, "label87");
    this.label87.Name = "label87";
    this.cbo_33.BackColor = Color.FromArgb(206, 233, 253);
    componentResourceManager.ApplyResources((object) this.cbo_33, "cbo_33");
    this.cbo_33.FormattingEnabled = true;
    this.cbo_33.Items.AddRange(new object[60]
    {
      (object) componentResourceManager.GetString("cbo_33.Items"),
      (object) componentResourceManager.GetString("cbo_33.Items1"),
      (object) componentResourceManager.GetString("cbo_33.Items2"),
      (object) componentResourceManager.GetString("cbo_33.Items3"),
      (object) componentResourceManager.GetString("cbo_33.Items4"),
      (object) componentResourceManager.GetString("cbo_33.Items5"),
      (object) componentResourceManager.GetString("cbo_33.Items6"),
      (object) componentResourceManager.GetString("cbo_33.Items7"),
      (object) componentResourceManager.GetString("cbo_33.Items8"),
      (object) componentResourceManager.GetString("cbo_33.Items9"),
      (object) componentResourceManager.GetString("cbo_33.Items10"),
      (object) componentResourceManager.GetString("cbo_33.Items11"),
      (object) componentResourceManager.GetString("cbo_33.Items12"),
      (object) componentResourceManager.GetString("cbo_33.Items13"),
      (object) componentResourceManager.GetString("cbo_33.Items14"),
      (object) componentResourceManager.GetString("cbo_33.Items15"),
      (object) componentResourceManager.GetString("cbo_33.Items16"),
      (object) componentResourceManager.GetString("cbo_33.Items17"),
      (object) componentResourceManager.GetString("cbo_33.Items18"),
      (object) componentResourceManager.GetString("cbo_33.Items19"),
      (object) componentResourceManager.GetString("cbo_33.Items20"),
      (object) componentResourceManager.GetString("cbo_33.Items21"),
      (object) componentResourceManager.GetString("cbo_33.Items22"),
      (object) componentResourceManager.GetString("cbo_33.Items23"),
      (object) componentResourceManager.GetString("cbo_33.Items24"),
      (object) componentResourceManager.GetString("cbo_33.Items25"),
      (object) componentResourceManager.GetString("cbo_33.Items26"),
      (object) componentResourceManager.GetString("cbo_33.Items27"),
      (object) componentResourceManager.GetString("cbo_33.Items28"),
      (object) componentResourceManager.GetString("cbo_33.Items29"),
      (object) componentResourceManager.GetString("cbo_33.Items30"),
      (object) componentResourceManager.GetString("cbo_33.Items31"),
      (object) componentResourceManager.GetString("cbo_33.Items32"),
      (object) componentResourceManager.GetString("cbo_33.Items33"),
      (object) componentResourceManager.GetString("cbo_33.Items34"),
      (object) componentResourceManager.GetString("cbo_33.Items35"),
      (object) componentResourceManager.GetString("cbo_33.Items36"),
      (object) componentResourceManager.GetString("cbo_33.Items37"),
      (object) componentResourceManager.GetString("cbo_33.Items38"),
      (object) componentResourceManager.GetString("cbo_33.Items39"),
      (object) componentResourceManager.GetString("cbo_33.Items40"),
      (object) componentResourceManager.GetString("cbo_33.Items41"),
      (object) componentResourceManager.GetString("cbo_33.Items42"),
      (object) componentResourceManager.GetString("cbo_33.Items43"),
      (object) componentResourceManager.GetString("cbo_33.Items44"),
      (object) componentResourceManager.GetString("cbo_33.Items45"),
      (object) componentResourceManager.GetString("cbo_33.Items46"),
      (object) componentResourceManager.GetString("cbo_33.Items47"),
      (object) componentResourceManager.GetString("cbo_33.Items48"),
      (object) componentResourceManager.GetString("cbo_33.Items49"),
      (object) componentResourceManager.GetString("cbo_33.Items50"),
      (object) componentResourceManager.GetString("cbo_33.Items51"),
      (object) componentResourceManager.GetString("cbo_33.Items52"),
      (object) componentResourceManager.GetString("cbo_33.Items53"),
      (object) componentResourceManager.GetString("cbo_33.Items54"),
      (object) componentResourceManager.GetString("cbo_33.Items55"),
      (object) componentResourceManager.GetString("cbo_33.Items56"),
      (object) componentResourceManager.GetString("cbo_33.Items57"),
      (object) componentResourceManager.GetString("cbo_33.Items58"),
      (object) componentResourceManager.GetString("cbo_33.Items59")
    });
    this.cbo_33.Name = "cbo_33";
    this.cbo_33.SelectedIndexChanged += new EventHandler(this.cbo_1_SelectedIndexChanged);
    componentResourceManager.ApplyResources((object) this.label89, "label89");
    this.label89.Name = "label89";
    componentResourceManager.ApplyResources((object) this.label82, "label82");
    this.label82.Name = "label82";
    componentResourceManager.ApplyResources((object) this.label83, "label83");
    this.label83.Name = "label83";
    this.cbo_32.BackColor = Color.FromArgb(206, 233, 253);
    componentResourceManager.ApplyResources((object) this.cbo_32, "cbo_32");
    this.cbo_32.FormattingEnabled = true;
    this.cbo_32.Items.AddRange(new object[60]
    {
      (object) componentResourceManager.GetString("cbo_32.Items"),
      (object) componentResourceManager.GetString("cbo_32.Items1"),
      (object) componentResourceManager.GetString("cbo_32.Items2"),
      (object) componentResourceManager.GetString("cbo_32.Items3"),
      (object) componentResourceManager.GetString("cbo_32.Items4"),
      (object) componentResourceManager.GetString("cbo_32.Items5"),
      (object) componentResourceManager.GetString("cbo_32.Items6"),
      (object) componentResourceManager.GetString("cbo_32.Items7"),
      (object) componentResourceManager.GetString("cbo_32.Items8"),
      (object) componentResourceManager.GetString("cbo_32.Items9"),
      (object) componentResourceManager.GetString("cbo_32.Items10"),
      (object) componentResourceManager.GetString("cbo_32.Items11"),
      (object) componentResourceManager.GetString("cbo_32.Items12"),
      (object) componentResourceManager.GetString("cbo_32.Items13"),
      (object) componentResourceManager.GetString("cbo_32.Items14"),
      (object) componentResourceManager.GetString("cbo_32.Items15"),
      (object) componentResourceManager.GetString("cbo_32.Items16"),
      (object) componentResourceManager.GetString("cbo_32.Items17"),
      (object) componentResourceManager.GetString("cbo_32.Items18"),
      (object) componentResourceManager.GetString("cbo_32.Items19"),
      (object) componentResourceManager.GetString("cbo_32.Items20"),
      (object) componentResourceManager.GetString("cbo_32.Items21"),
      (object) componentResourceManager.GetString("cbo_32.Items22"),
      (object) componentResourceManager.GetString("cbo_32.Items23"),
      (object) componentResourceManager.GetString("cbo_32.Items24"),
      (object) componentResourceManager.GetString("cbo_32.Items25"),
      (object) componentResourceManager.GetString("cbo_32.Items26"),
      (object) componentResourceManager.GetString("cbo_32.Items27"),
      (object) componentResourceManager.GetString("cbo_32.Items28"),
      (object) componentResourceManager.GetString("cbo_32.Items29"),
      (object) componentResourceManager.GetString("cbo_32.Items30"),
      (object) componentResourceManager.GetString("cbo_32.Items31"),
      (object) componentResourceManager.GetString("cbo_32.Items32"),
      (object) componentResourceManager.GetString("cbo_32.Items33"),
      (object) componentResourceManager.GetString("cbo_32.Items34"),
      (object) componentResourceManager.GetString("cbo_32.Items35"),
      (object) componentResourceManager.GetString("cbo_32.Items36"),
      (object) componentResourceManager.GetString("cbo_32.Items37"),
      (object) componentResourceManager.GetString("cbo_32.Items38"),
      (object) componentResourceManager.GetString("cbo_32.Items39"),
      (object) componentResourceManager.GetString("cbo_32.Items40"),
      (object) componentResourceManager.GetString("cbo_32.Items41"),
      (object) componentResourceManager.GetString("cbo_32.Items42"),
      (object) componentResourceManager.GetString("cbo_32.Items43"),
      (object) componentResourceManager.GetString("cbo_32.Items44"),
      (object) componentResourceManager.GetString("cbo_32.Items45"),
      (object) componentResourceManager.GetString("cbo_32.Items46"),
      (object) componentResourceManager.GetString("cbo_32.Items47"),
      (object) componentResourceManager.GetString("cbo_32.Items48"),
      (object) componentResourceManager.GetString("cbo_32.Items49"),
      (object) componentResourceManager.GetString("cbo_32.Items50"),
      (object) componentResourceManager.GetString("cbo_32.Items51"),
      (object) componentResourceManager.GetString("cbo_32.Items52"),
      (object) componentResourceManager.GetString("cbo_32.Items53"),
      (object) componentResourceManager.GetString("cbo_32.Items54"),
      (object) componentResourceManager.GetString("cbo_32.Items55"),
      (object) componentResourceManager.GetString("cbo_32.Items56"),
      (object) componentResourceManager.GetString("cbo_32.Items57"),
      (object) componentResourceManager.GetString("cbo_32.Items58"),
      (object) componentResourceManager.GetString("cbo_32.Items59")
    });
    this.cbo_32.Name = "cbo_32";
    this.cbo_32.SelectedIndexChanged += new EventHandler(this.cbo_1_SelectedIndexChanged);
    componentResourceManager.ApplyResources((object) this.label84, "label84");
    this.label84.Name = "label84";
    componentResourceManager.ApplyResources((object) this.label85, "label85");
    this.label85.Name = "label85";
    componentResourceManager.ApplyResources((object) this.label37, "label37");
    this.label37.ForeColor = Color.MidnightBlue;
    this.label37.Name = "label37";
    this.cbo_16.BackColor = Color.FromArgb(206, 233, 253);
    componentResourceManager.ApplyResources((object) this.cbo_16, "cbo_16");
    this.cbo_16.FormattingEnabled = true;
    this.cbo_16.Items.AddRange(new object[60]
    {
      (object) componentResourceManager.GetString("cbo_16.Items"),
      (object) componentResourceManager.GetString("cbo_16.Items1"),
      (object) componentResourceManager.GetString("cbo_16.Items2"),
      (object) componentResourceManager.GetString("cbo_16.Items3"),
      (object) componentResourceManager.GetString("cbo_16.Items4"),
      (object) componentResourceManager.GetString("cbo_16.Items5"),
      (object) componentResourceManager.GetString("cbo_16.Items6"),
      (object) componentResourceManager.GetString("cbo_16.Items7"),
      (object) componentResourceManager.GetString("cbo_16.Items8"),
      (object) componentResourceManager.GetString("cbo_16.Items9"),
      (object) componentResourceManager.GetString("cbo_16.Items10"),
      (object) componentResourceManager.GetString("cbo_16.Items11"),
      (object) componentResourceManager.GetString("cbo_16.Items12"),
      (object) componentResourceManager.GetString("cbo_16.Items13"),
      (object) componentResourceManager.GetString("cbo_16.Items14"),
      (object) componentResourceManager.GetString("cbo_16.Items15"),
      (object) componentResourceManager.GetString("cbo_16.Items16"),
      (object) componentResourceManager.GetString("cbo_16.Items17"),
      (object) componentResourceManager.GetString("cbo_16.Items18"),
      (object) componentResourceManager.GetString("cbo_16.Items19"),
      (object) componentResourceManager.GetString("cbo_16.Items20"),
      (object) componentResourceManager.GetString("cbo_16.Items21"),
      (object) componentResourceManager.GetString("cbo_16.Items22"),
      (object) componentResourceManager.GetString("cbo_16.Items23"),
      (object) componentResourceManager.GetString("cbo_16.Items24"),
      (object) componentResourceManager.GetString("cbo_16.Items25"),
      (object) componentResourceManager.GetString("cbo_16.Items26"),
      (object) componentResourceManager.GetString("cbo_16.Items27"),
      (object) componentResourceManager.GetString("cbo_16.Items28"),
      (object) componentResourceManager.GetString("cbo_16.Items29"),
      (object) componentResourceManager.GetString("cbo_16.Items30"),
      (object) componentResourceManager.GetString("cbo_16.Items31"),
      (object) componentResourceManager.GetString("cbo_16.Items32"),
      (object) componentResourceManager.GetString("cbo_16.Items33"),
      (object) componentResourceManager.GetString("cbo_16.Items34"),
      (object) componentResourceManager.GetString("cbo_16.Items35"),
      (object) componentResourceManager.GetString("cbo_16.Items36"),
      (object) componentResourceManager.GetString("cbo_16.Items37"),
      (object) componentResourceManager.GetString("cbo_16.Items38"),
      (object) componentResourceManager.GetString("cbo_16.Items39"),
      (object) componentResourceManager.GetString("cbo_16.Items40"),
      (object) componentResourceManager.GetString("cbo_16.Items41"),
      (object) componentResourceManager.GetString("cbo_16.Items42"),
      (object) componentResourceManager.GetString("cbo_16.Items43"),
      (object) componentResourceManager.GetString("cbo_16.Items44"),
      (object) componentResourceManager.GetString("cbo_16.Items45"),
      (object) componentResourceManager.GetString("cbo_16.Items46"),
      (object) componentResourceManager.GetString("cbo_16.Items47"),
      (object) componentResourceManager.GetString("cbo_16.Items48"),
      (object) componentResourceManager.GetString("cbo_16.Items49"),
      (object) componentResourceManager.GetString("cbo_16.Items50"),
      (object) componentResourceManager.GetString("cbo_16.Items51"),
      (object) componentResourceManager.GetString("cbo_16.Items52"),
      (object) componentResourceManager.GetString("cbo_16.Items53"),
      (object) componentResourceManager.GetString("cbo_16.Items54"),
      (object) componentResourceManager.GetString("cbo_16.Items55"),
      (object) componentResourceManager.GetString("cbo_16.Items56"),
      (object) componentResourceManager.GetString("cbo_16.Items57"),
      (object) componentResourceManager.GetString("cbo_16.Items58"),
      (object) componentResourceManager.GetString("cbo_16.Items59")
    });
    this.cbo_16.Name = "cbo_16";
    this.cbo_16.SelectedIndexChanged += new EventHandler(this.cbo_1_SelectedIndexChanged);
    componentResourceManager.ApplyResources((object) this.label81, "label81");
    this.label81.Name = "label81";
    componentResourceManager.ApplyResources((object) this.lblNgungDanhNgay, "lblNgungDanhNgay");
    this.lblNgungDanhNgay.Name = "lblNgungDanhNgay";
    this.cbo_10.BackColor = Color.FromArgb(206, 233, 253);
    componentResourceManager.ApplyResources((object) this.cbo_10, "cbo_10");
    this.cbo_10.FormattingEnabled = true;
    this.cbo_10.Items.AddRange(new object[60]
    {
      (object) componentResourceManager.GetString("cbo_10.Items"),
      (object) componentResourceManager.GetString("cbo_10.Items1"),
      (object) componentResourceManager.GetString("cbo_10.Items2"),
      (object) componentResourceManager.GetString("cbo_10.Items3"),
      (object) componentResourceManager.GetString("cbo_10.Items4"),
      (object) componentResourceManager.GetString("cbo_10.Items5"),
      (object) componentResourceManager.GetString("cbo_10.Items6"),
      (object) componentResourceManager.GetString("cbo_10.Items7"),
      (object) componentResourceManager.GetString("cbo_10.Items8"),
      (object) componentResourceManager.GetString("cbo_10.Items9"),
      (object) componentResourceManager.GetString("cbo_10.Items10"),
      (object) componentResourceManager.GetString("cbo_10.Items11"),
      (object) componentResourceManager.GetString("cbo_10.Items12"),
      (object) componentResourceManager.GetString("cbo_10.Items13"),
      (object) componentResourceManager.GetString("cbo_10.Items14"),
      (object) componentResourceManager.GetString("cbo_10.Items15"),
      (object) componentResourceManager.GetString("cbo_10.Items16"),
      (object) componentResourceManager.GetString("cbo_10.Items17"),
      (object) componentResourceManager.GetString("cbo_10.Items18"),
      (object) componentResourceManager.GetString("cbo_10.Items19"),
      (object) componentResourceManager.GetString("cbo_10.Items20"),
      (object) componentResourceManager.GetString("cbo_10.Items21"),
      (object) componentResourceManager.GetString("cbo_10.Items22"),
      (object) componentResourceManager.GetString("cbo_10.Items23"),
      (object) componentResourceManager.GetString("cbo_10.Items24"),
      (object) componentResourceManager.GetString("cbo_10.Items25"),
      (object) componentResourceManager.GetString("cbo_10.Items26"),
      (object) componentResourceManager.GetString("cbo_10.Items27"),
      (object) componentResourceManager.GetString("cbo_10.Items28"),
      (object) componentResourceManager.GetString("cbo_10.Items29"),
      (object) componentResourceManager.GetString("cbo_10.Items30"),
      (object) componentResourceManager.GetString("cbo_10.Items31"),
      (object) componentResourceManager.GetString("cbo_10.Items32"),
      (object) componentResourceManager.GetString("cbo_10.Items33"),
      (object) componentResourceManager.GetString("cbo_10.Items34"),
      (object) componentResourceManager.GetString("cbo_10.Items35"),
      (object) componentResourceManager.GetString("cbo_10.Items36"),
      (object) componentResourceManager.GetString("cbo_10.Items37"),
      (object) componentResourceManager.GetString("cbo_10.Items38"),
      (object) componentResourceManager.GetString("cbo_10.Items39"),
      (object) componentResourceManager.GetString("cbo_10.Items40"),
      (object) componentResourceManager.GetString("cbo_10.Items41"),
      (object) componentResourceManager.GetString("cbo_10.Items42"),
      (object) componentResourceManager.GetString("cbo_10.Items43"),
      (object) componentResourceManager.GetString("cbo_10.Items44"),
      (object) componentResourceManager.GetString("cbo_10.Items45"),
      (object) componentResourceManager.GetString("cbo_10.Items46"),
      (object) componentResourceManager.GetString("cbo_10.Items47"),
      (object) componentResourceManager.GetString("cbo_10.Items48"),
      (object) componentResourceManager.GetString("cbo_10.Items49"),
      (object) componentResourceManager.GetString("cbo_10.Items50"),
      (object) componentResourceManager.GetString("cbo_10.Items51"),
      (object) componentResourceManager.GetString("cbo_10.Items52"),
      (object) componentResourceManager.GetString("cbo_10.Items53"),
      (object) componentResourceManager.GetString("cbo_10.Items54"),
      (object) componentResourceManager.GetString("cbo_10.Items55"),
      (object) componentResourceManager.GetString("cbo_10.Items56"),
      (object) componentResourceManager.GetString("cbo_10.Items57"),
      (object) componentResourceManager.GetString("cbo_10.Items58"),
      (object) componentResourceManager.GetString("cbo_10.Items59")
    });
    this.cbo_10.Name = "cbo_10";
    this.cbo_10.SelectedIndexChanged += new EventHandler(this.cbo_1_SelectedIndexChanged);
    componentResourceManager.ApplyResources((object) this.label79, "label79");
    this.label79.Name = "label79";
    componentResourceManager.ApplyResources((object) this.label80, "label80");
    this.label80.Name = "label80";
    this.cbo_9.BackColor = Color.FromArgb(206, 233, 253);
    componentResourceManager.ApplyResources((object) this.cbo_9, "cbo_9");
    this.cbo_9.FormattingEnabled = true;
    this.cbo_9.Items.AddRange(new object[60]
    {
      (object) componentResourceManager.GetString("cbo_9.Items"),
      (object) componentResourceManager.GetString("cbo_9.Items1"),
      (object) componentResourceManager.GetString("cbo_9.Items2"),
      (object) componentResourceManager.GetString("cbo_9.Items3"),
      (object) componentResourceManager.GetString("cbo_9.Items4"),
      (object) componentResourceManager.GetString("cbo_9.Items5"),
      (object) componentResourceManager.GetString("cbo_9.Items6"),
      (object) componentResourceManager.GetString("cbo_9.Items7"),
      (object) componentResourceManager.GetString("cbo_9.Items8"),
      (object) componentResourceManager.GetString("cbo_9.Items9"),
      (object) componentResourceManager.GetString("cbo_9.Items10"),
      (object) componentResourceManager.GetString("cbo_9.Items11"),
      (object) componentResourceManager.GetString("cbo_9.Items12"),
      (object) componentResourceManager.GetString("cbo_9.Items13"),
      (object) componentResourceManager.GetString("cbo_9.Items14"),
      (object) componentResourceManager.GetString("cbo_9.Items15"),
      (object) componentResourceManager.GetString("cbo_9.Items16"),
      (object) componentResourceManager.GetString("cbo_9.Items17"),
      (object) componentResourceManager.GetString("cbo_9.Items18"),
      (object) componentResourceManager.GetString("cbo_9.Items19"),
      (object) componentResourceManager.GetString("cbo_9.Items20"),
      (object) componentResourceManager.GetString("cbo_9.Items21"),
      (object) componentResourceManager.GetString("cbo_9.Items22"),
      (object) componentResourceManager.GetString("cbo_9.Items23"),
      (object) componentResourceManager.GetString("cbo_9.Items24"),
      (object) componentResourceManager.GetString("cbo_9.Items25"),
      (object) componentResourceManager.GetString("cbo_9.Items26"),
      (object) componentResourceManager.GetString("cbo_9.Items27"),
      (object) componentResourceManager.GetString("cbo_9.Items28"),
      (object) componentResourceManager.GetString("cbo_9.Items29"),
      (object) componentResourceManager.GetString("cbo_9.Items30"),
      (object) componentResourceManager.GetString("cbo_9.Items31"),
      (object) componentResourceManager.GetString("cbo_9.Items32"),
      (object) componentResourceManager.GetString("cbo_9.Items33"),
      (object) componentResourceManager.GetString("cbo_9.Items34"),
      (object) componentResourceManager.GetString("cbo_9.Items35"),
      (object) componentResourceManager.GetString("cbo_9.Items36"),
      (object) componentResourceManager.GetString("cbo_9.Items37"),
      (object) componentResourceManager.GetString("cbo_9.Items38"),
      (object) componentResourceManager.GetString("cbo_9.Items39"),
      (object) componentResourceManager.GetString("cbo_9.Items40"),
      (object) componentResourceManager.GetString("cbo_9.Items41"),
      (object) componentResourceManager.GetString("cbo_9.Items42"),
      (object) componentResourceManager.GetString("cbo_9.Items43"),
      (object) componentResourceManager.GetString("cbo_9.Items44"),
      (object) componentResourceManager.GetString("cbo_9.Items45"),
      (object) componentResourceManager.GetString("cbo_9.Items46"),
      (object) componentResourceManager.GetString("cbo_9.Items47"),
      (object) componentResourceManager.GetString("cbo_9.Items48"),
      (object) componentResourceManager.GetString("cbo_9.Items49"),
      (object) componentResourceManager.GetString("cbo_9.Items50"),
      (object) componentResourceManager.GetString("cbo_9.Items51"),
      (object) componentResourceManager.GetString("cbo_9.Items52"),
      (object) componentResourceManager.GetString("cbo_9.Items53"),
      (object) componentResourceManager.GetString("cbo_9.Items54"),
      (object) componentResourceManager.GetString("cbo_9.Items55"),
      (object) componentResourceManager.GetString("cbo_9.Items56"),
      (object) componentResourceManager.GetString("cbo_9.Items57"),
      (object) componentResourceManager.GetString("cbo_9.Items58"),
      (object) componentResourceManager.GetString("cbo_9.Items59")
    });
    this.cbo_9.Name = "cbo_9";
    this.cbo_9.SelectedIndexChanged += new EventHandler(this.cbo_1_SelectedIndexChanged);
    componentResourceManager.ApplyResources((object) this.label77, "label77");
    this.label77.Name = "label77";
    componentResourceManager.ApplyResources((object) this.label78, "label78");
    this.label78.Name = "label78";
    componentResourceManager.ApplyResources((object) this.label64, "label64");
    this.label64.ForeColor = Color.MidnightBlue;
    this.label64.Name = "label64";
    this.cbo_8.BackColor = Color.FromArgb(206, 233, 253);
    componentResourceManager.ApplyResources((object) this.cbo_8, "cbo_8");
    this.cbo_8.FormattingEnabled = true;
    this.cbo_8.Items.AddRange(new object[60]
    {
      (object) componentResourceManager.GetString("cbo_8.Items"),
      (object) componentResourceManager.GetString("cbo_8.Items1"),
      (object) componentResourceManager.GetString("cbo_8.Items2"),
      (object) componentResourceManager.GetString("cbo_8.Items3"),
      (object) componentResourceManager.GetString("cbo_8.Items4"),
      (object) componentResourceManager.GetString("cbo_8.Items5"),
      (object) componentResourceManager.GetString("cbo_8.Items6"),
      (object) componentResourceManager.GetString("cbo_8.Items7"),
      (object) componentResourceManager.GetString("cbo_8.Items8"),
      (object) componentResourceManager.GetString("cbo_8.Items9"),
      (object) componentResourceManager.GetString("cbo_8.Items10"),
      (object) componentResourceManager.GetString("cbo_8.Items11"),
      (object) componentResourceManager.GetString("cbo_8.Items12"),
      (object) componentResourceManager.GetString("cbo_8.Items13"),
      (object) componentResourceManager.GetString("cbo_8.Items14"),
      (object) componentResourceManager.GetString("cbo_8.Items15"),
      (object) componentResourceManager.GetString("cbo_8.Items16"),
      (object) componentResourceManager.GetString("cbo_8.Items17"),
      (object) componentResourceManager.GetString("cbo_8.Items18"),
      (object) componentResourceManager.GetString("cbo_8.Items19"),
      (object) componentResourceManager.GetString("cbo_8.Items20"),
      (object) componentResourceManager.GetString("cbo_8.Items21"),
      (object) componentResourceManager.GetString("cbo_8.Items22"),
      (object) componentResourceManager.GetString("cbo_8.Items23"),
      (object) componentResourceManager.GetString("cbo_8.Items24"),
      (object) componentResourceManager.GetString("cbo_8.Items25"),
      (object) componentResourceManager.GetString("cbo_8.Items26"),
      (object) componentResourceManager.GetString("cbo_8.Items27"),
      (object) componentResourceManager.GetString("cbo_8.Items28"),
      (object) componentResourceManager.GetString("cbo_8.Items29"),
      (object) componentResourceManager.GetString("cbo_8.Items30"),
      (object) componentResourceManager.GetString("cbo_8.Items31"),
      (object) componentResourceManager.GetString("cbo_8.Items32"),
      (object) componentResourceManager.GetString("cbo_8.Items33"),
      (object) componentResourceManager.GetString("cbo_8.Items34"),
      (object) componentResourceManager.GetString("cbo_8.Items35"),
      (object) componentResourceManager.GetString("cbo_8.Items36"),
      (object) componentResourceManager.GetString("cbo_8.Items37"),
      (object) componentResourceManager.GetString("cbo_8.Items38"),
      (object) componentResourceManager.GetString("cbo_8.Items39"),
      (object) componentResourceManager.GetString("cbo_8.Items40"),
      (object) componentResourceManager.GetString("cbo_8.Items41"),
      (object) componentResourceManager.GetString("cbo_8.Items42"),
      (object) componentResourceManager.GetString("cbo_8.Items43"),
      (object) componentResourceManager.GetString("cbo_8.Items44"),
      (object) componentResourceManager.GetString("cbo_8.Items45"),
      (object) componentResourceManager.GetString("cbo_8.Items46"),
      (object) componentResourceManager.GetString("cbo_8.Items47"),
      (object) componentResourceManager.GetString("cbo_8.Items48"),
      (object) componentResourceManager.GetString("cbo_8.Items49"),
      (object) componentResourceManager.GetString("cbo_8.Items50"),
      (object) componentResourceManager.GetString("cbo_8.Items51"),
      (object) componentResourceManager.GetString("cbo_8.Items52"),
      (object) componentResourceManager.GetString("cbo_8.Items53"),
      (object) componentResourceManager.GetString("cbo_8.Items54"),
      (object) componentResourceManager.GetString("cbo_8.Items55"),
      (object) componentResourceManager.GetString("cbo_8.Items56"),
      (object) componentResourceManager.GetString("cbo_8.Items57"),
      (object) componentResourceManager.GetString("cbo_8.Items58"),
      (object) componentResourceManager.GetString("cbo_8.Items59")
    });
    this.cbo_8.Name = "cbo_8";
    this.cbo_8.SelectedIndexChanged += new EventHandler(this.cbo_1_SelectedIndexChanged);
    componentResourceManager.ApplyResources((object) this.label62, "label62");
    this.label62.Name = "label62";
    componentResourceManager.ApplyResources((object) this.label63, "label63");
    this.label63.Name = "label63";
    this.cbo_7.BackColor = Color.FromArgb(206, 233, 253);
    componentResourceManager.ApplyResources((object) this.cbo_7, "cbo_7");
    this.cbo_7.FormattingEnabled = true;
    this.cbo_7.Items.AddRange(new object[60]
    {
      (object) componentResourceManager.GetString("cbo_7.Items"),
      (object) componentResourceManager.GetString("cbo_7.Items1"),
      (object) componentResourceManager.GetString("cbo_7.Items2"),
      (object) componentResourceManager.GetString("cbo_7.Items3"),
      (object) componentResourceManager.GetString("cbo_7.Items4"),
      (object) componentResourceManager.GetString("cbo_7.Items5"),
      (object) componentResourceManager.GetString("cbo_7.Items6"),
      (object) componentResourceManager.GetString("cbo_7.Items7"),
      (object) componentResourceManager.GetString("cbo_7.Items8"),
      (object) componentResourceManager.GetString("cbo_7.Items9"),
      (object) componentResourceManager.GetString("cbo_7.Items10"),
      (object) componentResourceManager.GetString("cbo_7.Items11"),
      (object) componentResourceManager.GetString("cbo_7.Items12"),
      (object) componentResourceManager.GetString("cbo_7.Items13"),
      (object) componentResourceManager.GetString("cbo_7.Items14"),
      (object) componentResourceManager.GetString("cbo_7.Items15"),
      (object) componentResourceManager.GetString("cbo_7.Items16"),
      (object) componentResourceManager.GetString("cbo_7.Items17"),
      (object) componentResourceManager.GetString("cbo_7.Items18"),
      (object) componentResourceManager.GetString("cbo_7.Items19"),
      (object) componentResourceManager.GetString("cbo_7.Items20"),
      (object) componentResourceManager.GetString("cbo_7.Items21"),
      (object) componentResourceManager.GetString("cbo_7.Items22"),
      (object) componentResourceManager.GetString("cbo_7.Items23"),
      (object) componentResourceManager.GetString("cbo_7.Items24"),
      (object) componentResourceManager.GetString("cbo_7.Items25"),
      (object) componentResourceManager.GetString("cbo_7.Items26"),
      (object) componentResourceManager.GetString("cbo_7.Items27"),
      (object) componentResourceManager.GetString("cbo_7.Items28"),
      (object) componentResourceManager.GetString("cbo_7.Items29"),
      (object) componentResourceManager.GetString("cbo_7.Items30"),
      (object) componentResourceManager.GetString("cbo_7.Items31"),
      (object) componentResourceManager.GetString("cbo_7.Items32"),
      (object) componentResourceManager.GetString("cbo_7.Items33"),
      (object) componentResourceManager.GetString("cbo_7.Items34"),
      (object) componentResourceManager.GetString("cbo_7.Items35"),
      (object) componentResourceManager.GetString("cbo_7.Items36"),
      (object) componentResourceManager.GetString("cbo_7.Items37"),
      (object) componentResourceManager.GetString("cbo_7.Items38"),
      (object) componentResourceManager.GetString("cbo_7.Items39"),
      (object) componentResourceManager.GetString("cbo_7.Items40"),
      (object) componentResourceManager.GetString("cbo_7.Items41"),
      (object) componentResourceManager.GetString("cbo_7.Items42"),
      (object) componentResourceManager.GetString("cbo_7.Items43"),
      (object) componentResourceManager.GetString("cbo_7.Items44"),
      (object) componentResourceManager.GetString("cbo_7.Items45"),
      (object) componentResourceManager.GetString("cbo_7.Items46"),
      (object) componentResourceManager.GetString("cbo_7.Items47"),
      (object) componentResourceManager.GetString("cbo_7.Items48"),
      (object) componentResourceManager.GetString("cbo_7.Items49"),
      (object) componentResourceManager.GetString("cbo_7.Items50"),
      (object) componentResourceManager.GetString("cbo_7.Items51"),
      (object) componentResourceManager.GetString("cbo_7.Items52"),
      (object) componentResourceManager.GetString("cbo_7.Items53"),
      (object) componentResourceManager.GetString("cbo_7.Items54"),
      (object) componentResourceManager.GetString("cbo_7.Items55"),
      (object) componentResourceManager.GetString("cbo_7.Items56"),
      (object) componentResourceManager.GetString("cbo_7.Items57"),
      (object) componentResourceManager.GetString("cbo_7.Items58"),
      (object) componentResourceManager.GetString("cbo_7.Items59")
    });
    this.cbo_7.Name = "cbo_7";
    this.cbo_7.SelectedIndexChanged += new EventHandler(this.cbo_1_SelectedIndexChanged);
    componentResourceManager.ApplyResources((object) this.label60, "label60");
    this.label60.Name = "label60";
    componentResourceManager.ApplyResources((object) this.label61, "label61");
    this.label61.Name = "label61";
    this.cbo_6.BackColor = Color.FromArgb(206, 233, 253);
    componentResourceManager.ApplyResources((object) this.cbo_6, "cbo_6");
    this.cbo_6.FormattingEnabled = true;
    this.cbo_6.Items.AddRange(new object[60]
    {
      (object) componentResourceManager.GetString("cbo_6.Items"),
      (object) componentResourceManager.GetString("cbo_6.Items1"),
      (object) componentResourceManager.GetString("cbo_6.Items2"),
      (object) componentResourceManager.GetString("cbo_6.Items3"),
      (object) componentResourceManager.GetString("cbo_6.Items4"),
      (object) componentResourceManager.GetString("cbo_6.Items5"),
      (object) componentResourceManager.GetString("cbo_6.Items6"),
      (object) componentResourceManager.GetString("cbo_6.Items7"),
      (object) componentResourceManager.GetString("cbo_6.Items8"),
      (object) componentResourceManager.GetString("cbo_6.Items9"),
      (object) componentResourceManager.GetString("cbo_6.Items10"),
      (object) componentResourceManager.GetString("cbo_6.Items11"),
      (object) componentResourceManager.GetString("cbo_6.Items12"),
      (object) componentResourceManager.GetString("cbo_6.Items13"),
      (object) componentResourceManager.GetString("cbo_6.Items14"),
      (object) componentResourceManager.GetString("cbo_6.Items15"),
      (object) componentResourceManager.GetString("cbo_6.Items16"),
      (object) componentResourceManager.GetString("cbo_6.Items17"),
      (object) componentResourceManager.GetString("cbo_6.Items18"),
      (object) componentResourceManager.GetString("cbo_6.Items19"),
      (object) componentResourceManager.GetString("cbo_6.Items20"),
      (object) componentResourceManager.GetString("cbo_6.Items21"),
      (object) componentResourceManager.GetString("cbo_6.Items22"),
      (object) componentResourceManager.GetString("cbo_6.Items23"),
      (object) componentResourceManager.GetString("cbo_6.Items24"),
      (object) componentResourceManager.GetString("cbo_6.Items25"),
      (object) componentResourceManager.GetString("cbo_6.Items26"),
      (object) componentResourceManager.GetString("cbo_6.Items27"),
      (object) componentResourceManager.GetString("cbo_6.Items28"),
      (object) componentResourceManager.GetString("cbo_6.Items29"),
      (object) componentResourceManager.GetString("cbo_6.Items30"),
      (object) componentResourceManager.GetString("cbo_6.Items31"),
      (object) componentResourceManager.GetString("cbo_6.Items32"),
      (object) componentResourceManager.GetString("cbo_6.Items33"),
      (object) componentResourceManager.GetString("cbo_6.Items34"),
      (object) componentResourceManager.GetString("cbo_6.Items35"),
      (object) componentResourceManager.GetString("cbo_6.Items36"),
      (object) componentResourceManager.GetString("cbo_6.Items37"),
      (object) componentResourceManager.GetString("cbo_6.Items38"),
      (object) componentResourceManager.GetString("cbo_6.Items39"),
      (object) componentResourceManager.GetString("cbo_6.Items40"),
      (object) componentResourceManager.GetString("cbo_6.Items41"),
      (object) componentResourceManager.GetString("cbo_6.Items42"),
      (object) componentResourceManager.GetString("cbo_6.Items43"),
      (object) componentResourceManager.GetString("cbo_6.Items44"),
      (object) componentResourceManager.GetString("cbo_6.Items45"),
      (object) componentResourceManager.GetString("cbo_6.Items46"),
      (object) componentResourceManager.GetString("cbo_6.Items47"),
      (object) componentResourceManager.GetString("cbo_6.Items48"),
      (object) componentResourceManager.GetString("cbo_6.Items49"),
      (object) componentResourceManager.GetString("cbo_6.Items50"),
      (object) componentResourceManager.GetString("cbo_6.Items51"),
      (object) componentResourceManager.GetString("cbo_6.Items52"),
      (object) componentResourceManager.GetString("cbo_6.Items53"),
      (object) componentResourceManager.GetString("cbo_6.Items54"),
      (object) componentResourceManager.GetString("cbo_6.Items55"),
      (object) componentResourceManager.GetString("cbo_6.Items56"),
      (object) componentResourceManager.GetString("cbo_6.Items57"),
      (object) componentResourceManager.GetString("cbo_6.Items58"),
      (object) componentResourceManager.GetString("cbo_6.Items59")
    });
    this.cbo_6.Name = "cbo_6";
    this.cbo_6.SelectedIndexChanged += new EventHandler(this.cbo_1_SelectedIndexChanged);
    componentResourceManager.ApplyResources((object) this.label58, "label58");
    this.label58.Name = "label58";
    componentResourceManager.ApplyResources((object) this.label59, "label59");
    this.label59.Name = "label59";
    this.cbo_5.BackColor = Color.FromArgb(206, 233, 253);
    componentResourceManager.ApplyResources((object) this.cbo_5, "cbo_5");
    this.cbo_5.FormattingEnabled = true;
    this.cbo_5.Items.AddRange(new object[60]
    {
      (object) componentResourceManager.GetString("cbo_5.Items"),
      (object) componentResourceManager.GetString("cbo_5.Items1"),
      (object) componentResourceManager.GetString("cbo_5.Items2"),
      (object) componentResourceManager.GetString("cbo_5.Items3"),
      (object) componentResourceManager.GetString("cbo_5.Items4"),
      (object) componentResourceManager.GetString("cbo_5.Items5"),
      (object) componentResourceManager.GetString("cbo_5.Items6"),
      (object) componentResourceManager.GetString("cbo_5.Items7"),
      (object) componentResourceManager.GetString("cbo_5.Items8"),
      (object) componentResourceManager.GetString("cbo_5.Items9"),
      (object) componentResourceManager.GetString("cbo_5.Items10"),
      (object) componentResourceManager.GetString("cbo_5.Items11"),
      (object) componentResourceManager.GetString("cbo_5.Items12"),
      (object) componentResourceManager.GetString("cbo_5.Items13"),
      (object) componentResourceManager.GetString("cbo_5.Items14"),
      (object) componentResourceManager.GetString("cbo_5.Items15"),
      (object) componentResourceManager.GetString("cbo_5.Items16"),
      (object) componentResourceManager.GetString("cbo_5.Items17"),
      (object) componentResourceManager.GetString("cbo_5.Items18"),
      (object) componentResourceManager.GetString("cbo_5.Items19"),
      (object) componentResourceManager.GetString("cbo_5.Items20"),
      (object) componentResourceManager.GetString("cbo_5.Items21"),
      (object) componentResourceManager.GetString("cbo_5.Items22"),
      (object) componentResourceManager.GetString("cbo_5.Items23"),
      (object) componentResourceManager.GetString("cbo_5.Items24"),
      (object) componentResourceManager.GetString("cbo_5.Items25"),
      (object) componentResourceManager.GetString("cbo_5.Items26"),
      (object) componentResourceManager.GetString("cbo_5.Items27"),
      (object) componentResourceManager.GetString("cbo_5.Items28"),
      (object) componentResourceManager.GetString("cbo_5.Items29"),
      (object) componentResourceManager.GetString("cbo_5.Items30"),
      (object) componentResourceManager.GetString("cbo_5.Items31"),
      (object) componentResourceManager.GetString("cbo_5.Items32"),
      (object) componentResourceManager.GetString("cbo_5.Items33"),
      (object) componentResourceManager.GetString("cbo_5.Items34"),
      (object) componentResourceManager.GetString("cbo_5.Items35"),
      (object) componentResourceManager.GetString("cbo_5.Items36"),
      (object) componentResourceManager.GetString("cbo_5.Items37"),
      (object) componentResourceManager.GetString("cbo_5.Items38"),
      (object) componentResourceManager.GetString("cbo_5.Items39"),
      (object) componentResourceManager.GetString("cbo_5.Items40"),
      (object) componentResourceManager.GetString("cbo_5.Items41"),
      (object) componentResourceManager.GetString("cbo_5.Items42"),
      (object) componentResourceManager.GetString("cbo_5.Items43"),
      (object) componentResourceManager.GetString("cbo_5.Items44"),
      (object) componentResourceManager.GetString("cbo_5.Items45"),
      (object) componentResourceManager.GetString("cbo_5.Items46"),
      (object) componentResourceManager.GetString("cbo_5.Items47"),
      (object) componentResourceManager.GetString("cbo_5.Items48"),
      (object) componentResourceManager.GetString("cbo_5.Items49"),
      (object) componentResourceManager.GetString("cbo_5.Items50"),
      (object) componentResourceManager.GetString("cbo_5.Items51"),
      (object) componentResourceManager.GetString("cbo_5.Items52"),
      (object) componentResourceManager.GetString("cbo_5.Items53"),
      (object) componentResourceManager.GetString("cbo_5.Items54"),
      (object) componentResourceManager.GetString("cbo_5.Items55"),
      (object) componentResourceManager.GetString("cbo_5.Items56"),
      (object) componentResourceManager.GetString("cbo_5.Items57"),
      (object) componentResourceManager.GetString("cbo_5.Items58"),
      (object) componentResourceManager.GetString("cbo_5.Items59")
    });
    this.cbo_5.Name = "cbo_5";
    this.cbo_5.SelectedIndexChanged += new EventHandler(this.cbo_1_SelectedIndexChanged);
    componentResourceManager.ApplyResources((object) this.label56, "label56");
    this.label56.Name = "label56";
    componentResourceManager.ApplyResources((object) this.label57, "label57");
    this.label57.Name = "label57";
    this.cbo_31.BackColor = Color.FromArgb(206, 233, 253);
    componentResourceManager.ApplyResources((object) this.cbo_31, "cbo_31");
    this.cbo_31.FormattingEnabled = true;
    this.cbo_31.Items.AddRange(new object[60]
    {
      (object) componentResourceManager.GetString("cbo_31.Items"),
      (object) componentResourceManager.GetString("cbo_31.Items1"),
      (object) componentResourceManager.GetString("cbo_31.Items2"),
      (object) componentResourceManager.GetString("cbo_31.Items3"),
      (object) componentResourceManager.GetString("cbo_31.Items4"),
      (object) componentResourceManager.GetString("cbo_31.Items5"),
      (object) componentResourceManager.GetString("cbo_31.Items6"),
      (object) componentResourceManager.GetString("cbo_31.Items7"),
      (object) componentResourceManager.GetString("cbo_31.Items8"),
      (object) componentResourceManager.GetString("cbo_31.Items9"),
      (object) componentResourceManager.GetString("cbo_31.Items10"),
      (object) componentResourceManager.GetString("cbo_31.Items11"),
      (object) componentResourceManager.GetString("cbo_31.Items12"),
      (object) componentResourceManager.GetString("cbo_31.Items13"),
      (object) componentResourceManager.GetString("cbo_31.Items14"),
      (object) componentResourceManager.GetString("cbo_31.Items15"),
      (object) componentResourceManager.GetString("cbo_31.Items16"),
      (object) componentResourceManager.GetString("cbo_31.Items17"),
      (object) componentResourceManager.GetString("cbo_31.Items18"),
      (object) componentResourceManager.GetString("cbo_31.Items19"),
      (object) componentResourceManager.GetString("cbo_31.Items20"),
      (object) componentResourceManager.GetString("cbo_31.Items21"),
      (object) componentResourceManager.GetString("cbo_31.Items22"),
      (object) componentResourceManager.GetString("cbo_31.Items23"),
      (object) componentResourceManager.GetString("cbo_31.Items24"),
      (object) componentResourceManager.GetString("cbo_31.Items25"),
      (object) componentResourceManager.GetString("cbo_31.Items26"),
      (object) componentResourceManager.GetString("cbo_31.Items27"),
      (object) componentResourceManager.GetString("cbo_31.Items28"),
      (object) componentResourceManager.GetString("cbo_31.Items29"),
      (object) componentResourceManager.GetString("cbo_31.Items30"),
      (object) componentResourceManager.GetString("cbo_31.Items31"),
      (object) componentResourceManager.GetString("cbo_31.Items32"),
      (object) componentResourceManager.GetString("cbo_31.Items33"),
      (object) componentResourceManager.GetString("cbo_31.Items34"),
      (object) componentResourceManager.GetString("cbo_31.Items35"),
      (object) componentResourceManager.GetString("cbo_31.Items36"),
      (object) componentResourceManager.GetString("cbo_31.Items37"),
      (object) componentResourceManager.GetString("cbo_31.Items38"),
      (object) componentResourceManager.GetString("cbo_31.Items39"),
      (object) componentResourceManager.GetString("cbo_31.Items40"),
      (object) componentResourceManager.GetString("cbo_31.Items41"),
      (object) componentResourceManager.GetString("cbo_31.Items42"),
      (object) componentResourceManager.GetString("cbo_31.Items43"),
      (object) componentResourceManager.GetString("cbo_31.Items44"),
      (object) componentResourceManager.GetString("cbo_31.Items45"),
      (object) componentResourceManager.GetString("cbo_31.Items46"),
      (object) componentResourceManager.GetString("cbo_31.Items47"),
      (object) componentResourceManager.GetString("cbo_31.Items48"),
      (object) componentResourceManager.GetString("cbo_31.Items49"),
      (object) componentResourceManager.GetString("cbo_31.Items50"),
      (object) componentResourceManager.GetString("cbo_31.Items51"),
      (object) componentResourceManager.GetString("cbo_31.Items52"),
      (object) componentResourceManager.GetString("cbo_31.Items53"),
      (object) componentResourceManager.GetString("cbo_31.Items54"),
      (object) componentResourceManager.GetString("cbo_31.Items55"),
      (object) componentResourceManager.GetString("cbo_31.Items56"),
      (object) componentResourceManager.GetString("cbo_31.Items57"),
      (object) componentResourceManager.GetString("cbo_31.Items58"),
      (object) componentResourceManager.GetString("cbo_31.Items59")
    });
    this.cbo_31.Name = "cbo_31";
    this.cbo_31.SelectedIndexChanged += new EventHandler(this.cbo_1_SelectedIndexChanged);
    componentResourceManager.ApplyResources((object) this.label54, "label54");
    this.label54.Name = "label54";
    componentResourceManager.ApplyResources((object) this.label55, "label55");
    this.label55.Name = "label55";
    this.cbo_30.BackColor = Color.FromArgb(206, 233, 253);
    componentResourceManager.ApplyResources((object) this.cbo_30, "cbo_30");
    this.cbo_30.FormattingEnabled = true;
    this.cbo_30.Items.AddRange(new object[60]
    {
      (object) componentResourceManager.GetString("cbo_30.Items"),
      (object) componentResourceManager.GetString("cbo_30.Items1"),
      (object) componentResourceManager.GetString("cbo_30.Items2"),
      (object) componentResourceManager.GetString("cbo_30.Items3"),
      (object) componentResourceManager.GetString("cbo_30.Items4"),
      (object) componentResourceManager.GetString("cbo_30.Items5"),
      (object) componentResourceManager.GetString("cbo_30.Items6"),
      (object) componentResourceManager.GetString("cbo_30.Items7"),
      (object) componentResourceManager.GetString("cbo_30.Items8"),
      (object) componentResourceManager.GetString("cbo_30.Items9"),
      (object) componentResourceManager.GetString("cbo_30.Items10"),
      (object) componentResourceManager.GetString("cbo_30.Items11"),
      (object) componentResourceManager.GetString("cbo_30.Items12"),
      (object) componentResourceManager.GetString("cbo_30.Items13"),
      (object) componentResourceManager.GetString("cbo_30.Items14"),
      (object) componentResourceManager.GetString("cbo_30.Items15"),
      (object) componentResourceManager.GetString("cbo_30.Items16"),
      (object) componentResourceManager.GetString("cbo_30.Items17"),
      (object) componentResourceManager.GetString("cbo_30.Items18"),
      (object) componentResourceManager.GetString("cbo_30.Items19"),
      (object) componentResourceManager.GetString("cbo_30.Items20"),
      (object) componentResourceManager.GetString("cbo_30.Items21"),
      (object) componentResourceManager.GetString("cbo_30.Items22"),
      (object) componentResourceManager.GetString("cbo_30.Items23"),
      (object) componentResourceManager.GetString("cbo_30.Items24"),
      (object) componentResourceManager.GetString("cbo_30.Items25"),
      (object) componentResourceManager.GetString("cbo_30.Items26"),
      (object) componentResourceManager.GetString("cbo_30.Items27"),
      (object) componentResourceManager.GetString("cbo_30.Items28"),
      (object) componentResourceManager.GetString("cbo_30.Items29"),
      (object) componentResourceManager.GetString("cbo_30.Items30"),
      (object) componentResourceManager.GetString("cbo_30.Items31"),
      (object) componentResourceManager.GetString("cbo_30.Items32"),
      (object) componentResourceManager.GetString("cbo_30.Items33"),
      (object) componentResourceManager.GetString("cbo_30.Items34"),
      (object) componentResourceManager.GetString("cbo_30.Items35"),
      (object) componentResourceManager.GetString("cbo_30.Items36"),
      (object) componentResourceManager.GetString("cbo_30.Items37"),
      (object) componentResourceManager.GetString("cbo_30.Items38"),
      (object) componentResourceManager.GetString("cbo_30.Items39"),
      (object) componentResourceManager.GetString("cbo_30.Items40"),
      (object) componentResourceManager.GetString("cbo_30.Items41"),
      (object) componentResourceManager.GetString("cbo_30.Items42"),
      (object) componentResourceManager.GetString("cbo_30.Items43"),
      (object) componentResourceManager.GetString("cbo_30.Items44"),
      (object) componentResourceManager.GetString("cbo_30.Items45"),
      (object) componentResourceManager.GetString("cbo_30.Items46"),
      (object) componentResourceManager.GetString("cbo_30.Items47"),
      (object) componentResourceManager.GetString("cbo_30.Items48"),
      (object) componentResourceManager.GetString("cbo_30.Items49"),
      (object) componentResourceManager.GetString("cbo_30.Items50"),
      (object) componentResourceManager.GetString("cbo_30.Items51"),
      (object) componentResourceManager.GetString("cbo_30.Items52"),
      (object) componentResourceManager.GetString("cbo_30.Items53"),
      (object) componentResourceManager.GetString("cbo_30.Items54"),
      (object) componentResourceManager.GetString("cbo_30.Items55"),
      (object) componentResourceManager.GetString("cbo_30.Items56"),
      (object) componentResourceManager.GetString("cbo_30.Items57"),
      (object) componentResourceManager.GetString("cbo_30.Items58"),
      (object) componentResourceManager.GetString("cbo_30.Items59")
    });
    this.cbo_30.Name = "cbo_30";
    this.cbo_30.SelectedIndexChanged += new EventHandler(this.cbo_1_SelectedIndexChanged);
    componentResourceManager.ApplyResources((object) this.label52, "label52");
    this.label52.Name = "label52";
    componentResourceManager.ApplyResources((object) this.label53, "label53");
    this.label53.Name = "label53";
    this.cbo_29.BackColor = Color.FromArgb(206, 233, 253);
    componentResourceManager.ApplyResources((object) this.cbo_29, "cbo_29");
    this.cbo_29.FormattingEnabled = true;
    this.cbo_29.Items.AddRange(new object[60]
    {
      (object) componentResourceManager.GetString("cbo_29.Items"),
      (object) componentResourceManager.GetString("cbo_29.Items1"),
      (object) componentResourceManager.GetString("cbo_29.Items2"),
      (object) componentResourceManager.GetString("cbo_29.Items3"),
      (object) componentResourceManager.GetString("cbo_29.Items4"),
      (object) componentResourceManager.GetString("cbo_29.Items5"),
      (object) componentResourceManager.GetString("cbo_29.Items6"),
      (object) componentResourceManager.GetString("cbo_29.Items7"),
      (object) componentResourceManager.GetString("cbo_29.Items8"),
      (object) componentResourceManager.GetString("cbo_29.Items9"),
      (object) componentResourceManager.GetString("cbo_29.Items10"),
      (object) componentResourceManager.GetString("cbo_29.Items11"),
      (object) componentResourceManager.GetString("cbo_29.Items12"),
      (object) componentResourceManager.GetString("cbo_29.Items13"),
      (object) componentResourceManager.GetString("cbo_29.Items14"),
      (object) componentResourceManager.GetString("cbo_29.Items15"),
      (object) componentResourceManager.GetString("cbo_29.Items16"),
      (object) componentResourceManager.GetString("cbo_29.Items17"),
      (object) componentResourceManager.GetString("cbo_29.Items18"),
      (object) componentResourceManager.GetString("cbo_29.Items19"),
      (object) componentResourceManager.GetString("cbo_29.Items20"),
      (object) componentResourceManager.GetString("cbo_29.Items21"),
      (object) componentResourceManager.GetString("cbo_29.Items22"),
      (object) componentResourceManager.GetString("cbo_29.Items23"),
      (object) componentResourceManager.GetString("cbo_29.Items24"),
      (object) componentResourceManager.GetString("cbo_29.Items25"),
      (object) componentResourceManager.GetString("cbo_29.Items26"),
      (object) componentResourceManager.GetString("cbo_29.Items27"),
      (object) componentResourceManager.GetString("cbo_29.Items28"),
      (object) componentResourceManager.GetString("cbo_29.Items29"),
      (object) componentResourceManager.GetString("cbo_29.Items30"),
      (object) componentResourceManager.GetString("cbo_29.Items31"),
      (object) componentResourceManager.GetString("cbo_29.Items32"),
      (object) componentResourceManager.GetString("cbo_29.Items33"),
      (object) componentResourceManager.GetString("cbo_29.Items34"),
      (object) componentResourceManager.GetString("cbo_29.Items35"),
      (object) componentResourceManager.GetString("cbo_29.Items36"),
      (object) componentResourceManager.GetString("cbo_29.Items37"),
      (object) componentResourceManager.GetString("cbo_29.Items38"),
      (object) componentResourceManager.GetString("cbo_29.Items39"),
      (object) componentResourceManager.GetString("cbo_29.Items40"),
      (object) componentResourceManager.GetString("cbo_29.Items41"),
      (object) componentResourceManager.GetString("cbo_29.Items42"),
      (object) componentResourceManager.GetString("cbo_29.Items43"),
      (object) componentResourceManager.GetString("cbo_29.Items44"),
      (object) componentResourceManager.GetString("cbo_29.Items45"),
      (object) componentResourceManager.GetString("cbo_29.Items46"),
      (object) componentResourceManager.GetString("cbo_29.Items47"),
      (object) componentResourceManager.GetString("cbo_29.Items48"),
      (object) componentResourceManager.GetString("cbo_29.Items49"),
      (object) componentResourceManager.GetString("cbo_29.Items50"),
      (object) componentResourceManager.GetString("cbo_29.Items51"),
      (object) componentResourceManager.GetString("cbo_29.Items52"),
      (object) componentResourceManager.GetString("cbo_29.Items53"),
      (object) componentResourceManager.GetString("cbo_29.Items54"),
      (object) componentResourceManager.GetString("cbo_29.Items55"),
      (object) componentResourceManager.GetString("cbo_29.Items56"),
      (object) componentResourceManager.GetString("cbo_29.Items57"),
      (object) componentResourceManager.GetString("cbo_29.Items58"),
      (object) componentResourceManager.GetString("cbo_29.Items59")
    });
    this.cbo_29.Name = "cbo_29";
    this.cbo_29.SelectedIndexChanged += new EventHandler(this.cbo_1_SelectedIndexChanged);
    componentResourceManager.ApplyResources((object) this.label50, "label50");
    this.label50.Name = "label50";
    componentResourceManager.ApplyResources((object) this.label51, "label51");
    this.label51.Name = "label51";
    this.cbo_28.BackColor = Color.FromArgb(206, 233, 253);
    componentResourceManager.ApplyResources((object) this.cbo_28, "cbo_28");
    this.cbo_28.FormattingEnabled = true;
    this.cbo_28.Items.AddRange(new object[60]
    {
      (object) componentResourceManager.GetString("cbo_28.Items"),
      (object) componentResourceManager.GetString("cbo_28.Items1"),
      (object) componentResourceManager.GetString("cbo_28.Items2"),
      (object) componentResourceManager.GetString("cbo_28.Items3"),
      (object) componentResourceManager.GetString("cbo_28.Items4"),
      (object) componentResourceManager.GetString("cbo_28.Items5"),
      (object) componentResourceManager.GetString("cbo_28.Items6"),
      (object) componentResourceManager.GetString("cbo_28.Items7"),
      (object) componentResourceManager.GetString("cbo_28.Items8"),
      (object) componentResourceManager.GetString("cbo_28.Items9"),
      (object) componentResourceManager.GetString("cbo_28.Items10"),
      (object) componentResourceManager.GetString("cbo_28.Items11"),
      (object) componentResourceManager.GetString("cbo_28.Items12"),
      (object) componentResourceManager.GetString("cbo_28.Items13"),
      (object) componentResourceManager.GetString("cbo_28.Items14"),
      (object) componentResourceManager.GetString("cbo_28.Items15"),
      (object) componentResourceManager.GetString("cbo_28.Items16"),
      (object) componentResourceManager.GetString("cbo_28.Items17"),
      (object) componentResourceManager.GetString("cbo_28.Items18"),
      (object) componentResourceManager.GetString("cbo_28.Items19"),
      (object) componentResourceManager.GetString("cbo_28.Items20"),
      (object) componentResourceManager.GetString("cbo_28.Items21"),
      (object) componentResourceManager.GetString("cbo_28.Items22"),
      (object) componentResourceManager.GetString("cbo_28.Items23"),
      (object) componentResourceManager.GetString("cbo_28.Items24"),
      (object) componentResourceManager.GetString("cbo_28.Items25"),
      (object) componentResourceManager.GetString("cbo_28.Items26"),
      (object) componentResourceManager.GetString("cbo_28.Items27"),
      (object) componentResourceManager.GetString("cbo_28.Items28"),
      (object) componentResourceManager.GetString("cbo_28.Items29"),
      (object) componentResourceManager.GetString("cbo_28.Items30"),
      (object) componentResourceManager.GetString("cbo_28.Items31"),
      (object) componentResourceManager.GetString("cbo_28.Items32"),
      (object) componentResourceManager.GetString("cbo_28.Items33"),
      (object) componentResourceManager.GetString("cbo_28.Items34"),
      (object) componentResourceManager.GetString("cbo_28.Items35"),
      (object) componentResourceManager.GetString("cbo_28.Items36"),
      (object) componentResourceManager.GetString("cbo_28.Items37"),
      (object) componentResourceManager.GetString("cbo_28.Items38"),
      (object) componentResourceManager.GetString("cbo_28.Items39"),
      (object) componentResourceManager.GetString("cbo_28.Items40"),
      (object) componentResourceManager.GetString("cbo_28.Items41"),
      (object) componentResourceManager.GetString("cbo_28.Items42"),
      (object) componentResourceManager.GetString("cbo_28.Items43"),
      (object) componentResourceManager.GetString("cbo_28.Items44"),
      (object) componentResourceManager.GetString("cbo_28.Items45"),
      (object) componentResourceManager.GetString("cbo_28.Items46"),
      (object) componentResourceManager.GetString("cbo_28.Items47"),
      (object) componentResourceManager.GetString("cbo_28.Items48"),
      (object) componentResourceManager.GetString("cbo_28.Items49"),
      (object) componentResourceManager.GetString("cbo_28.Items50"),
      (object) componentResourceManager.GetString("cbo_28.Items51"),
      (object) componentResourceManager.GetString("cbo_28.Items52"),
      (object) componentResourceManager.GetString("cbo_28.Items53"),
      (object) componentResourceManager.GetString("cbo_28.Items54"),
      (object) componentResourceManager.GetString("cbo_28.Items55"),
      (object) componentResourceManager.GetString("cbo_28.Items56"),
      (object) componentResourceManager.GetString("cbo_28.Items57"),
      (object) componentResourceManager.GetString("cbo_28.Items58"),
      (object) componentResourceManager.GetString("cbo_28.Items59")
    });
    this.cbo_28.Name = "cbo_28";
    this.cbo_28.SelectedIndexChanged += new EventHandler(this.cbo_1_SelectedIndexChanged);
    componentResourceManager.ApplyResources((object) this.label48, "label48");
    this.label48.Name = "label48";
    componentResourceManager.ApplyResources((object) this.label49, "label49");
    this.label49.Name = "label49";
    this.cbo_27.BackColor = Color.FromArgb(206, 233, 253);
    componentResourceManager.ApplyResources((object) this.cbo_27, "cbo_27");
    this.cbo_27.FormattingEnabled = true;
    this.cbo_27.Items.AddRange(new object[60]
    {
      (object) componentResourceManager.GetString("cbo_27.Items"),
      (object) componentResourceManager.GetString("cbo_27.Items1"),
      (object) componentResourceManager.GetString("cbo_27.Items2"),
      (object) componentResourceManager.GetString("cbo_27.Items3"),
      (object) componentResourceManager.GetString("cbo_27.Items4"),
      (object) componentResourceManager.GetString("cbo_27.Items5"),
      (object) componentResourceManager.GetString("cbo_27.Items6"),
      (object) componentResourceManager.GetString("cbo_27.Items7"),
      (object) componentResourceManager.GetString("cbo_27.Items8"),
      (object) componentResourceManager.GetString("cbo_27.Items9"),
      (object) componentResourceManager.GetString("cbo_27.Items10"),
      (object) componentResourceManager.GetString("cbo_27.Items11"),
      (object) componentResourceManager.GetString("cbo_27.Items12"),
      (object) componentResourceManager.GetString("cbo_27.Items13"),
      (object) componentResourceManager.GetString("cbo_27.Items14"),
      (object) componentResourceManager.GetString("cbo_27.Items15"),
      (object) componentResourceManager.GetString("cbo_27.Items16"),
      (object) componentResourceManager.GetString("cbo_27.Items17"),
      (object) componentResourceManager.GetString("cbo_27.Items18"),
      (object) componentResourceManager.GetString("cbo_27.Items19"),
      (object) componentResourceManager.GetString("cbo_27.Items20"),
      (object) componentResourceManager.GetString("cbo_27.Items21"),
      (object) componentResourceManager.GetString("cbo_27.Items22"),
      (object) componentResourceManager.GetString("cbo_27.Items23"),
      (object) componentResourceManager.GetString("cbo_27.Items24"),
      (object) componentResourceManager.GetString("cbo_27.Items25"),
      (object) componentResourceManager.GetString("cbo_27.Items26"),
      (object) componentResourceManager.GetString("cbo_27.Items27"),
      (object) componentResourceManager.GetString("cbo_27.Items28"),
      (object) componentResourceManager.GetString("cbo_27.Items29"),
      (object) componentResourceManager.GetString("cbo_27.Items30"),
      (object) componentResourceManager.GetString("cbo_27.Items31"),
      (object) componentResourceManager.GetString("cbo_27.Items32"),
      (object) componentResourceManager.GetString("cbo_27.Items33"),
      (object) componentResourceManager.GetString("cbo_27.Items34"),
      (object) componentResourceManager.GetString("cbo_27.Items35"),
      (object) componentResourceManager.GetString("cbo_27.Items36"),
      (object) componentResourceManager.GetString("cbo_27.Items37"),
      (object) componentResourceManager.GetString("cbo_27.Items38"),
      (object) componentResourceManager.GetString("cbo_27.Items39"),
      (object) componentResourceManager.GetString("cbo_27.Items40"),
      (object) componentResourceManager.GetString("cbo_27.Items41"),
      (object) componentResourceManager.GetString("cbo_27.Items42"),
      (object) componentResourceManager.GetString("cbo_27.Items43"),
      (object) componentResourceManager.GetString("cbo_27.Items44"),
      (object) componentResourceManager.GetString("cbo_27.Items45"),
      (object) componentResourceManager.GetString("cbo_27.Items46"),
      (object) componentResourceManager.GetString("cbo_27.Items47"),
      (object) componentResourceManager.GetString("cbo_27.Items48"),
      (object) componentResourceManager.GetString("cbo_27.Items49"),
      (object) componentResourceManager.GetString("cbo_27.Items50"),
      (object) componentResourceManager.GetString("cbo_27.Items51"),
      (object) componentResourceManager.GetString("cbo_27.Items52"),
      (object) componentResourceManager.GetString("cbo_27.Items53"),
      (object) componentResourceManager.GetString("cbo_27.Items54"),
      (object) componentResourceManager.GetString("cbo_27.Items55"),
      (object) componentResourceManager.GetString("cbo_27.Items56"),
      (object) componentResourceManager.GetString("cbo_27.Items57"),
      (object) componentResourceManager.GetString("cbo_27.Items58"),
      (object) componentResourceManager.GetString("cbo_27.Items59")
    });
    this.cbo_27.Name = "cbo_27";
    this.cbo_27.SelectedIndexChanged += new EventHandler(this.cbo_1_SelectedIndexChanged);
    componentResourceManager.ApplyResources((object) this.label46, "label46");
    this.label46.Name = "label46";
    componentResourceManager.ApplyResources((object) this.label47, "label47");
    this.label47.Name = "label47";
    this.cbo_26.BackColor = Color.FromArgb(206, 233, 253);
    componentResourceManager.ApplyResources((object) this.cbo_26, "cbo_26");
    this.cbo_26.FormattingEnabled = true;
    this.cbo_26.Items.AddRange(new object[60]
    {
      (object) componentResourceManager.GetString("cbo_26.Items"),
      (object) componentResourceManager.GetString("cbo_26.Items1"),
      (object) componentResourceManager.GetString("cbo_26.Items2"),
      (object) componentResourceManager.GetString("cbo_26.Items3"),
      (object) componentResourceManager.GetString("cbo_26.Items4"),
      (object) componentResourceManager.GetString("cbo_26.Items5"),
      (object) componentResourceManager.GetString("cbo_26.Items6"),
      (object) componentResourceManager.GetString("cbo_26.Items7"),
      (object) componentResourceManager.GetString("cbo_26.Items8"),
      (object) componentResourceManager.GetString("cbo_26.Items9"),
      (object) componentResourceManager.GetString("cbo_26.Items10"),
      (object) componentResourceManager.GetString("cbo_26.Items11"),
      (object) componentResourceManager.GetString("cbo_26.Items12"),
      (object) componentResourceManager.GetString("cbo_26.Items13"),
      (object) componentResourceManager.GetString("cbo_26.Items14"),
      (object) componentResourceManager.GetString("cbo_26.Items15"),
      (object) componentResourceManager.GetString("cbo_26.Items16"),
      (object) componentResourceManager.GetString("cbo_26.Items17"),
      (object) componentResourceManager.GetString("cbo_26.Items18"),
      (object) componentResourceManager.GetString("cbo_26.Items19"),
      (object) componentResourceManager.GetString("cbo_26.Items20"),
      (object) componentResourceManager.GetString("cbo_26.Items21"),
      (object) componentResourceManager.GetString("cbo_26.Items22"),
      (object) componentResourceManager.GetString("cbo_26.Items23"),
      (object) componentResourceManager.GetString("cbo_26.Items24"),
      (object) componentResourceManager.GetString("cbo_26.Items25"),
      (object) componentResourceManager.GetString("cbo_26.Items26"),
      (object) componentResourceManager.GetString("cbo_26.Items27"),
      (object) componentResourceManager.GetString("cbo_26.Items28"),
      (object) componentResourceManager.GetString("cbo_26.Items29"),
      (object) componentResourceManager.GetString("cbo_26.Items30"),
      (object) componentResourceManager.GetString("cbo_26.Items31"),
      (object) componentResourceManager.GetString("cbo_26.Items32"),
      (object) componentResourceManager.GetString("cbo_26.Items33"),
      (object) componentResourceManager.GetString("cbo_26.Items34"),
      (object) componentResourceManager.GetString("cbo_26.Items35"),
      (object) componentResourceManager.GetString("cbo_26.Items36"),
      (object) componentResourceManager.GetString("cbo_26.Items37"),
      (object) componentResourceManager.GetString("cbo_26.Items38"),
      (object) componentResourceManager.GetString("cbo_26.Items39"),
      (object) componentResourceManager.GetString("cbo_26.Items40"),
      (object) componentResourceManager.GetString("cbo_26.Items41"),
      (object) componentResourceManager.GetString("cbo_26.Items42"),
      (object) componentResourceManager.GetString("cbo_26.Items43"),
      (object) componentResourceManager.GetString("cbo_26.Items44"),
      (object) componentResourceManager.GetString("cbo_26.Items45"),
      (object) componentResourceManager.GetString("cbo_26.Items46"),
      (object) componentResourceManager.GetString("cbo_26.Items47"),
      (object) componentResourceManager.GetString("cbo_26.Items48"),
      (object) componentResourceManager.GetString("cbo_26.Items49"),
      (object) componentResourceManager.GetString("cbo_26.Items50"),
      (object) componentResourceManager.GetString("cbo_26.Items51"),
      (object) componentResourceManager.GetString("cbo_26.Items52"),
      (object) componentResourceManager.GetString("cbo_26.Items53"),
      (object) componentResourceManager.GetString("cbo_26.Items54"),
      (object) componentResourceManager.GetString("cbo_26.Items55"),
      (object) componentResourceManager.GetString("cbo_26.Items56"),
      (object) componentResourceManager.GetString("cbo_26.Items57"),
      (object) componentResourceManager.GetString("cbo_26.Items58"),
      (object) componentResourceManager.GetString("cbo_26.Items59")
    });
    this.cbo_26.Name = "cbo_26";
    this.cbo_26.SelectedIndexChanged += new EventHandler(this.cbo_1_SelectedIndexChanged);
    componentResourceManager.ApplyResources((object) this.label44, "label44");
    this.label44.Name = "label44";
    componentResourceManager.ApplyResources((object) this.label45, "label45");
    this.label45.Name = "label45";
    this.cbo_25.BackColor = Color.FromArgb(206, 233, 253);
    componentResourceManager.ApplyResources((object) this.cbo_25, "cbo_25");
    this.cbo_25.FormattingEnabled = true;
    this.cbo_25.Items.AddRange(new object[60]
    {
      (object) componentResourceManager.GetString("cbo_25.Items"),
      (object) componentResourceManager.GetString("cbo_25.Items1"),
      (object) componentResourceManager.GetString("cbo_25.Items2"),
      (object) componentResourceManager.GetString("cbo_25.Items3"),
      (object) componentResourceManager.GetString("cbo_25.Items4"),
      (object) componentResourceManager.GetString("cbo_25.Items5"),
      (object) componentResourceManager.GetString("cbo_25.Items6"),
      (object) componentResourceManager.GetString("cbo_25.Items7"),
      (object) componentResourceManager.GetString("cbo_25.Items8"),
      (object) componentResourceManager.GetString("cbo_25.Items9"),
      (object) componentResourceManager.GetString("cbo_25.Items10"),
      (object) componentResourceManager.GetString("cbo_25.Items11"),
      (object) componentResourceManager.GetString("cbo_25.Items12"),
      (object) componentResourceManager.GetString("cbo_25.Items13"),
      (object) componentResourceManager.GetString("cbo_25.Items14"),
      (object) componentResourceManager.GetString("cbo_25.Items15"),
      (object) componentResourceManager.GetString("cbo_25.Items16"),
      (object) componentResourceManager.GetString("cbo_25.Items17"),
      (object) componentResourceManager.GetString("cbo_25.Items18"),
      (object) componentResourceManager.GetString("cbo_25.Items19"),
      (object) componentResourceManager.GetString("cbo_25.Items20"),
      (object) componentResourceManager.GetString("cbo_25.Items21"),
      (object) componentResourceManager.GetString("cbo_25.Items22"),
      (object) componentResourceManager.GetString("cbo_25.Items23"),
      (object) componentResourceManager.GetString("cbo_25.Items24"),
      (object) componentResourceManager.GetString("cbo_25.Items25"),
      (object) componentResourceManager.GetString("cbo_25.Items26"),
      (object) componentResourceManager.GetString("cbo_25.Items27"),
      (object) componentResourceManager.GetString("cbo_25.Items28"),
      (object) componentResourceManager.GetString("cbo_25.Items29"),
      (object) componentResourceManager.GetString("cbo_25.Items30"),
      (object) componentResourceManager.GetString("cbo_25.Items31"),
      (object) componentResourceManager.GetString("cbo_25.Items32"),
      (object) componentResourceManager.GetString("cbo_25.Items33"),
      (object) componentResourceManager.GetString("cbo_25.Items34"),
      (object) componentResourceManager.GetString("cbo_25.Items35"),
      (object) componentResourceManager.GetString("cbo_25.Items36"),
      (object) componentResourceManager.GetString("cbo_25.Items37"),
      (object) componentResourceManager.GetString("cbo_25.Items38"),
      (object) componentResourceManager.GetString("cbo_25.Items39"),
      (object) componentResourceManager.GetString("cbo_25.Items40"),
      (object) componentResourceManager.GetString("cbo_25.Items41"),
      (object) componentResourceManager.GetString("cbo_25.Items42"),
      (object) componentResourceManager.GetString("cbo_25.Items43"),
      (object) componentResourceManager.GetString("cbo_25.Items44"),
      (object) componentResourceManager.GetString("cbo_25.Items45"),
      (object) componentResourceManager.GetString("cbo_25.Items46"),
      (object) componentResourceManager.GetString("cbo_25.Items47"),
      (object) componentResourceManager.GetString("cbo_25.Items48"),
      (object) componentResourceManager.GetString("cbo_25.Items49"),
      (object) componentResourceManager.GetString("cbo_25.Items50"),
      (object) componentResourceManager.GetString("cbo_25.Items51"),
      (object) componentResourceManager.GetString("cbo_25.Items52"),
      (object) componentResourceManager.GetString("cbo_25.Items53"),
      (object) componentResourceManager.GetString("cbo_25.Items54"),
      (object) componentResourceManager.GetString("cbo_25.Items55"),
      (object) componentResourceManager.GetString("cbo_25.Items56"),
      (object) componentResourceManager.GetString("cbo_25.Items57"),
      (object) componentResourceManager.GetString("cbo_25.Items58"),
      (object) componentResourceManager.GetString("cbo_25.Items59")
    });
    this.cbo_25.Name = "cbo_25";
    this.cbo_25.SelectedIndexChanged += new EventHandler(this.cbo_1_SelectedIndexChanged);
    componentResourceManager.ApplyResources((object) this.label42, "label42");
    this.label42.Name = "label42";
    componentResourceManager.ApplyResources((object) this.label43, "label43");
    this.label43.Name = "label43";
    this.cbo_24.BackColor = Color.FromArgb(206, 233, 253);
    componentResourceManager.ApplyResources((object) this.cbo_24, "cbo_24");
    this.cbo_24.FormattingEnabled = true;
    this.cbo_24.Items.AddRange(new object[60]
    {
      (object) componentResourceManager.GetString("cbo_24.Items"),
      (object) componentResourceManager.GetString("cbo_24.Items1"),
      (object) componentResourceManager.GetString("cbo_24.Items2"),
      (object) componentResourceManager.GetString("cbo_24.Items3"),
      (object) componentResourceManager.GetString("cbo_24.Items4"),
      (object) componentResourceManager.GetString("cbo_24.Items5"),
      (object) componentResourceManager.GetString("cbo_24.Items6"),
      (object) componentResourceManager.GetString("cbo_24.Items7"),
      (object) componentResourceManager.GetString("cbo_24.Items8"),
      (object) componentResourceManager.GetString("cbo_24.Items9"),
      (object) componentResourceManager.GetString("cbo_24.Items10"),
      (object) componentResourceManager.GetString("cbo_24.Items11"),
      (object) componentResourceManager.GetString("cbo_24.Items12"),
      (object) componentResourceManager.GetString("cbo_24.Items13"),
      (object) componentResourceManager.GetString("cbo_24.Items14"),
      (object) componentResourceManager.GetString("cbo_24.Items15"),
      (object) componentResourceManager.GetString("cbo_24.Items16"),
      (object) componentResourceManager.GetString("cbo_24.Items17"),
      (object) componentResourceManager.GetString("cbo_24.Items18"),
      (object) componentResourceManager.GetString("cbo_24.Items19"),
      (object) componentResourceManager.GetString("cbo_24.Items20"),
      (object) componentResourceManager.GetString("cbo_24.Items21"),
      (object) componentResourceManager.GetString("cbo_24.Items22"),
      (object) componentResourceManager.GetString("cbo_24.Items23"),
      (object) componentResourceManager.GetString("cbo_24.Items24"),
      (object) componentResourceManager.GetString("cbo_24.Items25"),
      (object) componentResourceManager.GetString("cbo_24.Items26"),
      (object) componentResourceManager.GetString("cbo_24.Items27"),
      (object) componentResourceManager.GetString("cbo_24.Items28"),
      (object) componentResourceManager.GetString("cbo_24.Items29"),
      (object) componentResourceManager.GetString("cbo_24.Items30"),
      (object) componentResourceManager.GetString("cbo_24.Items31"),
      (object) componentResourceManager.GetString("cbo_24.Items32"),
      (object) componentResourceManager.GetString("cbo_24.Items33"),
      (object) componentResourceManager.GetString("cbo_24.Items34"),
      (object) componentResourceManager.GetString("cbo_24.Items35"),
      (object) componentResourceManager.GetString("cbo_24.Items36"),
      (object) componentResourceManager.GetString("cbo_24.Items37"),
      (object) componentResourceManager.GetString("cbo_24.Items38"),
      (object) componentResourceManager.GetString("cbo_24.Items39"),
      (object) componentResourceManager.GetString("cbo_24.Items40"),
      (object) componentResourceManager.GetString("cbo_24.Items41"),
      (object) componentResourceManager.GetString("cbo_24.Items42"),
      (object) componentResourceManager.GetString("cbo_24.Items43"),
      (object) componentResourceManager.GetString("cbo_24.Items44"),
      (object) componentResourceManager.GetString("cbo_24.Items45"),
      (object) componentResourceManager.GetString("cbo_24.Items46"),
      (object) componentResourceManager.GetString("cbo_24.Items47"),
      (object) componentResourceManager.GetString("cbo_24.Items48"),
      (object) componentResourceManager.GetString("cbo_24.Items49"),
      (object) componentResourceManager.GetString("cbo_24.Items50"),
      (object) componentResourceManager.GetString("cbo_24.Items51"),
      (object) componentResourceManager.GetString("cbo_24.Items52"),
      (object) componentResourceManager.GetString("cbo_24.Items53"),
      (object) componentResourceManager.GetString("cbo_24.Items54"),
      (object) componentResourceManager.GetString("cbo_24.Items55"),
      (object) componentResourceManager.GetString("cbo_24.Items56"),
      (object) componentResourceManager.GetString("cbo_24.Items57"),
      (object) componentResourceManager.GetString("cbo_24.Items58"),
      (object) componentResourceManager.GetString("cbo_24.Items59")
    });
    this.cbo_24.Name = "cbo_24";
    this.cbo_24.SelectedIndexChanged += new EventHandler(this.cbo_1_SelectedIndexChanged);
    componentResourceManager.ApplyResources((object) this.label40, "label40");
    this.label40.Name = "label40";
    componentResourceManager.ApplyResources((object) this.label41, "label41");
    this.label41.Name = "label41";
    this.cbo_23.BackColor = Color.FromArgb(206, 233, 253);
    componentResourceManager.ApplyResources((object) this.cbo_23, "cbo_23");
    this.cbo_23.FormattingEnabled = true;
    this.cbo_23.Items.AddRange(new object[60]
    {
      (object) componentResourceManager.GetString("cbo_23.Items"),
      (object) componentResourceManager.GetString("cbo_23.Items1"),
      (object) componentResourceManager.GetString("cbo_23.Items2"),
      (object) componentResourceManager.GetString("cbo_23.Items3"),
      (object) componentResourceManager.GetString("cbo_23.Items4"),
      (object) componentResourceManager.GetString("cbo_23.Items5"),
      (object) componentResourceManager.GetString("cbo_23.Items6"),
      (object) componentResourceManager.GetString("cbo_23.Items7"),
      (object) componentResourceManager.GetString("cbo_23.Items8"),
      (object) componentResourceManager.GetString("cbo_23.Items9"),
      (object) componentResourceManager.GetString("cbo_23.Items10"),
      (object) componentResourceManager.GetString("cbo_23.Items11"),
      (object) componentResourceManager.GetString("cbo_23.Items12"),
      (object) componentResourceManager.GetString("cbo_23.Items13"),
      (object) componentResourceManager.GetString("cbo_23.Items14"),
      (object) componentResourceManager.GetString("cbo_23.Items15"),
      (object) componentResourceManager.GetString("cbo_23.Items16"),
      (object) componentResourceManager.GetString("cbo_23.Items17"),
      (object) componentResourceManager.GetString("cbo_23.Items18"),
      (object) componentResourceManager.GetString("cbo_23.Items19"),
      (object) componentResourceManager.GetString("cbo_23.Items20"),
      (object) componentResourceManager.GetString("cbo_23.Items21"),
      (object) componentResourceManager.GetString("cbo_23.Items22"),
      (object) componentResourceManager.GetString("cbo_23.Items23"),
      (object) componentResourceManager.GetString("cbo_23.Items24"),
      (object) componentResourceManager.GetString("cbo_23.Items25"),
      (object) componentResourceManager.GetString("cbo_23.Items26"),
      (object) componentResourceManager.GetString("cbo_23.Items27"),
      (object) componentResourceManager.GetString("cbo_23.Items28"),
      (object) componentResourceManager.GetString("cbo_23.Items29"),
      (object) componentResourceManager.GetString("cbo_23.Items30"),
      (object) componentResourceManager.GetString("cbo_23.Items31"),
      (object) componentResourceManager.GetString("cbo_23.Items32"),
      (object) componentResourceManager.GetString("cbo_23.Items33"),
      (object) componentResourceManager.GetString("cbo_23.Items34"),
      (object) componentResourceManager.GetString("cbo_23.Items35"),
      (object) componentResourceManager.GetString("cbo_23.Items36"),
      (object) componentResourceManager.GetString("cbo_23.Items37"),
      (object) componentResourceManager.GetString("cbo_23.Items38"),
      (object) componentResourceManager.GetString("cbo_23.Items39"),
      (object) componentResourceManager.GetString("cbo_23.Items40"),
      (object) componentResourceManager.GetString("cbo_23.Items41"),
      (object) componentResourceManager.GetString("cbo_23.Items42"),
      (object) componentResourceManager.GetString("cbo_23.Items43"),
      (object) componentResourceManager.GetString("cbo_23.Items44"),
      (object) componentResourceManager.GetString("cbo_23.Items45"),
      (object) componentResourceManager.GetString("cbo_23.Items46"),
      (object) componentResourceManager.GetString("cbo_23.Items47"),
      (object) componentResourceManager.GetString("cbo_23.Items48"),
      (object) componentResourceManager.GetString("cbo_23.Items49"),
      (object) componentResourceManager.GetString("cbo_23.Items50"),
      (object) componentResourceManager.GetString("cbo_23.Items51"),
      (object) componentResourceManager.GetString("cbo_23.Items52"),
      (object) componentResourceManager.GetString("cbo_23.Items53"),
      (object) componentResourceManager.GetString("cbo_23.Items54"),
      (object) componentResourceManager.GetString("cbo_23.Items55"),
      (object) componentResourceManager.GetString("cbo_23.Items56"),
      (object) componentResourceManager.GetString("cbo_23.Items57"),
      (object) componentResourceManager.GetString("cbo_23.Items58"),
      (object) componentResourceManager.GetString("cbo_23.Items59")
    });
    this.cbo_23.Name = "cbo_23";
    this.cbo_23.SelectedIndexChanged += new EventHandler(this.cbo_1_SelectedIndexChanged);
    componentResourceManager.ApplyResources((object) this.label38, "label38");
    this.label38.Name = "label38";
    componentResourceManager.ApplyResources((object) this.label39, "label39");
    this.label39.Name = "label39";
    this.cbo_22.BackColor = Color.FromArgb(206, 233, 253);
    componentResourceManager.ApplyResources((object) this.cbo_22, "cbo_22");
    this.cbo_22.FormattingEnabled = true;
    this.cbo_22.Items.AddRange(new object[60]
    {
      (object) componentResourceManager.GetString("cbo_22.Items"),
      (object) componentResourceManager.GetString("cbo_22.Items1"),
      (object) componentResourceManager.GetString("cbo_22.Items2"),
      (object) componentResourceManager.GetString("cbo_22.Items3"),
      (object) componentResourceManager.GetString("cbo_22.Items4"),
      (object) componentResourceManager.GetString("cbo_22.Items5"),
      (object) componentResourceManager.GetString("cbo_22.Items6"),
      (object) componentResourceManager.GetString("cbo_22.Items7"),
      (object) componentResourceManager.GetString("cbo_22.Items8"),
      (object) componentResourceManager.GetString("cbo_22.Items9"),
      (object) componentResourceManager.GetString("cbo_22.Items10"),
      (object) componentResourceManager.GetString("cbo_22.Items11"),
      (object) componentResourceManager.GetString("cbo_22.Items12"),
      (object) componentResourceManager.GetString("cbo_22.Items13"),
      (object) componentResourceManager.GetString("cbo_22.Items14"),
      (object) componentResourceManager.GetString("cbo_22.Items15"),
      (object) componentResourceManager.GetString("cbo_22.Items16"),
      (object) componentResourceManager.GetString("cbo_22.Items17"),
      (object) componentResourceManager.GetString("cbo_22.Items18"),
      (object) componentResourceManager.GetString("cbo_22.Items19"),
      (object) componentResourceManager.GetString("cbo_22.Items20"),
      (object) componentResourceManager.GetString("cbo_22.Items21"),
      (object) componentResourceManager.GetString("cbo_22.Items22"),
      (object) componentResourceManager.GetString("cbo_22.Items23"),
      (object) componentResourceManager.GetString("cbo_22.Items24"),
      (object) componentResourceManager.GetString("cbo_22.Items25"),
      (object) componentResourceManager.GetString("cbo_22.Items26"),
      (object) componentResourceManager.GetString("cbo_22.Items27"),
      (object) componentResourceManager.GetString("cbo_22.Items28"),
      (object) componentResourceManager.GetString("cbo_22.Items29"),
      (object) componentResourceManager.GetString("cbo_22.Items30"),
      (object) componentResourceManager.GetString("cbo_22.Items31"),
      (object) componentResourceManager.GetString("cbo_22.Items32"),
      (object) componentResourceManager.GetString("cbo_22.Items33"),
      (object) componentResourceManager.GetString("cbo_22.Items34"),
      (object) componentResourceManager.GetString("cbo_22.Items35"),
      (object) componentResourceManager.GetString("cbo_22.Items36"),
      (object) componentResourceManager.GetString("cbo_22.Items37"),
      (object) componentResourceManager.GetString("cbo_22.Items38"),
      (object) componentResourceManager.GetString("cbo_22.Items39"),
      (object) componentResourceManager.GetString("cbo_22.Items40"),
      (object) componentResourceManager.GetString("cbo_22.Items41"),
      (object) componentResourceManager.GetString("cbo_22.Items42"),
      (object) componentResourceManager.GetString("cbo_22.Items43"),
      (object) componentResourceManager.GetString("cbo_22.Items44"),
      (object) componentResourceManager.GetString("cbo_22.Items45"),
      (object) componentResourceManager.GetString("cbo_22.Items46"),
      (object) componentResourceManager.GetString("cbo_22.Items47"),
      (object) componentResourceManager.GetString("cbo_22.Items48"),
      (object) componentResourceManager.GetString("cbo_22.Items49"),
      (object) componentResourceManager.GetString("cbo_22.Items50"),
      (object) componentResourceManager.GetString("cbo_22.Items51"),
      (object) componentResourceManager.GetString("cbo_22.Items52"),
      (object) componentResourceManager.GetString("cbo_22.Items53"),
      (object) componentResourceManager.GetString("cbo_22.Items54"),
      (object) componentResourceManager.GetString("cbo_22.Items55"),
      (object) componentResourceManager.GetString("cbo_22.Items56"),
      (object) componentResourceManager.GetString("cbo_22.Items57"),
      (object) componentResourceManager.GetString("cbo_22.Items58"),
      (object) componentResourceManager.GetString("cbo_22.Items59")
    });
    this.cbo_22.Name = "cbo_22";
    this.cbo_22.SelectedIndexChanged += new EventHandler(this.cbo_1_SelectedIndexChanged);
    componentResourceManager.ApplyResources((object) this.label36, "label36");
    this.label36.Name = "label36";
    componentResourceManager.ApplyResources((object) this.lblTrongTrot, "lblTrongTrot");
    this.lblTrongTrot.Name = "lblTrongTrot";
    this.cbo_21.BackColor = Color.FromArgb(206, 233, 253);
    componentResourceManager.ApplyResources((object) this.cbo_21, "cbo_21");
    this.cbo_21.FormattingEnabled = true;
    this.cbo_21.Items.AddRange(new object[60]
    {
      (object) componentResourceManager.GetString("cbo_21.Items"),
      (object) componentResourceManager.GetString("cbo_21.Items1"),
      (object) componentResourceManager.GetString("cbo_21.Items2"),
      (object) componentResourceManager.GetString("cbo_21.Items3"),
      (object) componentResourceManager.GetString("cbo_21.Items4"),
      (object) componentResourceManager.GetString("cbo_21.Items5"),
      (object) componentResourceManager.GetString("cbo_21.Items6"),
      (object) componentResourceManager.GetString("cbo_21.Items7"),
      (object) componentResourceManager.GetString("cbo_21.Items8"),
      (object) componentResourceManager.GetString("cbo_21.Items9"),
      (object) componentResourceManager.GetString("cbo_21.Items10"),
      (object) componentResourceManager.GetString("cbo_21.Items11"),
      (object) componentResourceManager.GetString("cbo_21.Items12"),
      (object) componentResourceManager.GetString("cbo_21.Items13"),
      (object) componentResourceManager.GetString("cbo_21.Items14"),
      (object) componentResourceManager.GetString("cbo_21.Items15"),
      (object) componentResourceManager.GetString("cbo_21.Items16"),
      (object) componentResourceManager.GetString("cbo_21.Items17"),
      (object) componentResourceManager.GetString("cbo_21.Items18"),
      (object) componentResourceManager.GetString("cbo_21.Items19"),
      (object) componentResourceManager.GetString("cbo_21.Items20"),
      (object) componentResourceManager.GetString("cbo_21.Items21"),
      (object) componentResourceManager.GetString("cbo_21.Items22"),
      (object) componentResourceManager.GetString("cbo_21.Items23"),
      (object) componentResourceManager.GetString("cbo_21.Items24"),
      (object) componentResourceManager.GetString("cbo_21.Items25"),
      (object) componentResourceManager.GetString("cbo_21.Items26"),
      (object) componentResourceManager.GetString("cbo_21.Items27"),
      (object) componentResourceManager.GetString("cbo_21.Items28"),
      (object) componentResourceManager.GetString("cbo_21.Items29"),
      (object) componentResourceManager.GetString("cbo_21.Items30"),
      (object) componentResourceManager.GetString("cbo_21.Items31"),
      (object) componentResourceManager.GetString("cbo_21.Items32"),
      (object) componentResourceManager.GetString("cbo_21.Items33"),
      (object) componentResourceManager.GetString("cbo_21.Items34"),
      (object) componentResourceManager.GetString("cbo_21.Items35"),
      (object) componentResourceManager.GetString("cbo_21.Items36"),
      (object) componentResourceManager.GetString("cbo_21.Items37"),
      (object) componentResourceManager.GetString("cbo_21.Items38"),
      (object) componentResourceManager.GetString("cbo_21.Items39"),
      (object) componentResourceManager.GetString("cbo_21.Items40"),
      (object) componentResourceManager.GetString("cbo_21.Items41"),
      (object) componentResourceManager.GetString("cbo_21.Items42"),
      (object) componentResourceManager.GetString("cbo_21.Items43"),
      (object) componentResourceManager.GetString("cbo_21.Items44"),
      (object) componentResourceManager.GetString("cbo_21.Items45"),
      (object) componentResourceManager.GetString("cbo_21.Items46"),
      (object) componentResourceManager.GetString("cbo_21.Items47"),
      (object) componentResourceManager.GetString("cbo_21.Items48"),
      (object) componentResourceManager.GetString("cbo_21.Items49"),
      (object) componentResourceManager.GetString("cbo_21.Items50"),
      (object) componentResourceManager.GetString("cbo_21.Items51"),
      (object) componentResourceManager.GetString("cbo_21.Items52"),
      (object) componentResourceManager.GetString("cbo_21.Items53"),
      (object) componentResourceManager.GetString("cbo_21.Items54"),
      (object) componentResourceManager.GetString("cbo_21.Items55"),
      (object) componentResourceManager.GetString("cbo_21.Items56"),
      (object) componentResourceManager.GetString("cbo_21.Items57"),
      (object) componentResourceManager.GetString("cbo_21.Items58"),
      (object) componentResourceManager.GetString("cbo_21.Items59")
    });
    this.cbo_21.Name = "cbo_21";
    this.cbo_21.SelectedIndexChanged += new EventHandler(this.cbo_1_SelectedIndexChanged);
    componentResourceManager.ApplyResources((object) this.label34, "label34");
    this.label34.Name = "label34";
    componentResourceManager.ApplyResources((object) this.label35, "label35");
    this.label35.Name = "label35";
    componentResourceManager.ApplyResources((object) this.label33, "label33");
    this.label33.ForeColor = Color.MidnightBlue;
    this.label33.Name = "label33";
    this.cbo_20.BackColor = Color.FromArgb(206, 233, 253);
    componentResourceManager.ApplyResources((object) this.cbo_20, "cbo_20");
    this.cbo_20.FormattingEnabled = true;
    this.cbo_20.Items.AddRange(new object[60]
    {
      (object) componentResourceManager.GetString("cbo_20.Items"),
      (object) componentResourceManager.GetString("cbo_20.Items1"),
      (object) componentResourceManager.GetString("cbo_20.Items2"),
      (object) componentResourceManager.GetString("cbo_20.Items3"),
      (object) componentResourceManager.GetString("cbo_20.Items4"),
      (object) componentResourceManager.GetString("cbo_20.Items5"),
      (object) componentResourceManager.GetString("cbo_20.Items6"),
      (object) componentResourceManager.GetString("cbo_20.Items7"),
      (object) componentResourceManager.GetString("cbo_20.Items8"),
      (object) componentResourceManager.GetString("cbo_20.Items9"),
      (object) componentResourceManager.GetString("cbo_20.Items10"),
      (object) componentResourceManager.GetString("cbo_20.Items11"),
      (object) componentResourceManager.GetString("cbo_20.Items12"),
      (object) componentResourceManager.GetString("cbo_20.Items13"),
      (object) componentResourceManager.GetString("cbo_20.Items14"),
      (object) componentResourceManager.GetString("cbo_20.Items15"),
      (object) componentResourceManager.GetString("cbo_20.Items16"),
      (object) componentResourceManager.GetString("cbo_20.Items17"),
      (object) componentResourceManager.GetString("cbo_20.Items18"),
      (object) componentResourceManager.GetString("cbo_20.Items19"),
      (object) componentResourceManager.GetString("cbo_20.Items20"),
      (object) componentResourceManager.GetString("cbo_20.Items21"),
      (object) componentResourceManager.GetString("cbo_20.Items22"),
      (object) componentResourceManager.GetString("cbo_20.Items23"),
      (object) componentResourceManager.GetString("cbo_20.Items24"),
      (object) componentResourceManager.GetString("cbo_20.Items25"),
      (object) componentResourceManager.GetString("cbo_20.Items26"),
      (object) componentResourceManager.GetString("cbo_20.Items27"),
      (object) componentResourceManager.GetString("cbo_20.Items28"),
      (object) componentResourceManager.GetString("cbo_20.Items29"),
      (object) componentResourceManager.GetString("cbo_20.Items30"),
      (object) componentResourceManager.GetString("cbo_20.Items31"),
      (object) componentResourceManager.GetString("cbo_20.Items32"),
      (object) componentResourceManager.GetString("cbo_20.Items33"),
      (object) componentResourceManager.GetString("cbo_20.Items34"),
      (object) componentResourceManager.GetString("cbo_20.Items35"),
      (object) componentResourceManager.GetString("cbo_20.Items36"),
      (object) componentResourceManager.GetString("cbo_20.Items37"),
      (object) componentResourceManager.GetString("cbo_20.Items38"),
      (object) componentResourceManager.GetString("cbo_20.Items39"),
      (object) componentResourceManager.GetString("cbo_20.Items40"),
      (object) componentResourceManager.GetString("cbo_20.Items41"),
      (object) componentResourceManager.GetString("cbo_20.Items42"),
      (object) componentResourceManager.GetString("cbo_20.Items43"),
      (object) componentResourceManager.GetString("cbo_20.Items44"),
      (object) componentResourceManager.GetString("cbo_20.Items45"),
      (object) componentResourceManager.GetString("cbo_20.Items46"),
      (object) componentResourceManager.GetString("cbo_20.Items47"),
      (object) componentResourceManager.GetString("cbo_20.Items48"),
      (object) componentResourceManager.GetString("cbo_20.Items49"),
      (object) componentResourceManager.GetString("cbo_20.Items50"),
      (object) componentResourceManager.GetString("cbo_20.Items51"),
      (object) componentResourceManager.GetString("cbo_20.Items52"),
      (object) componentResourceManager.GetString("cbo_20.Items53"),
      (object) componentResourceManager.GetString("cbo_20.Items54"),
      (object) componentResourceManager.GetString("cbo_20.Items55"),
      (object) componentResourceManager.GetString("cbo_20.Items56"),
      (object) componentResourceManager.GetString("cbo_20.Items57"),
      (object) componentResourceManager.GetString("cbo_20.Items58"),
      (object) componentResourceManager.GetString("cbo_20.Items59")
    });
    this.cbo_20.Name = "cbo_20";
    this.cbo_20.SelectedIndexChanged += new EventHandler(this.cbo_1_SelectedIndexChanged);
    componentResourceManager.ApplyResources((object) this.label31, "label31");
    this.label31.Name = "label31";
    componentResourceManager.ApplyResources((object) this.label32, "label32");
    this.label32.Name = "label32";
    this.cbo_19.BackColor = Color.FromArgb(206, 233, 253);
    componentResourceManager.ApplyResources((object) this.cbo_19, "cbo_19");
    this.cbo_19.FormattingEnabled = true;
    this.cbo_19.Items.AddRange(new object[60]
    {
      (object) componentResourceManager.GetString("cbo_19.Items"),
      (object) componentResourceManager.GetString("cbo_19.Items1"),
      (object) componentResourceManager.GetString("cbo_19.Items2"),
      (object) componentResourceManager.GetString("cbo_19.Items3"),
      (object) componentResourceManager.GetString("cbo_19.Items4"),
      (object) componentResourceManager.GetString("cbo_19.Items5"),
      (object) componentResourceManager.GetString("cbo_19.Items6"),
      (object) componentResourceManager.GetString("cbo_19.Items7"),
      (object) componentResourceManager.GetString("cbo_19.Items8"),
      (object) componentResourceManager.GetString("cbo_19.Items9"),
      (object) componentResourceManager.GetString("cbo_19.Items10"),
      (object) componentResourceManager.GetString("cbo_19.Items11"),
      (object) componentResourceManager.GetString("cbo_19.Items12"),
      (object) componentResourceManager.GetString("cbo_19.Items13"),
      (object) componentResourceManager.GetString("cbo_19.Items14"),
      (object) componentResourceManager.GetString("cbo_19.Items15"),
      (object) componentResourceManager.GetString("cbo_19.Items16"),
      (object) componentResourceManager.GetString("cbo_19.Items17"),
      (object) componentResourceManager.GetString("cbo_19.Items18"),
      (object) componentResourceManager.GetString("cbo_19.Items19"),
      (object) componentResourceManager.GetString("cbo_19.Items20"),
      (object) componentResourceManager.GetString("cbo_19.Items21"),
      (object) componentResourceManager.GetString("cbo_19.Items22"),
      (object) componentResourceManager.GetString("cbo_19.Items23"),
      (object) componentResourceManager.GetString("cbo_19.Items24"),
      (object) componentResourceManager.GetString("cbo_19.Items25"),
      (object) componentResourceManager.GetString("cbo_19.Items26"),
      (object) componentResourceManager.GetString("cbo_19.Items27"),
      (object) componentResourceManager.GetString("cbo_19.Items28"),
      (object) componentResourceManager.GetString("cbo_19.Items29"),
      (object) componentResourceManager.GetString("cbo_19.Items30"),
      (object) componentResourceManager.GetString("cbo_19.Items31"),
      (object) componentResourceManager.GetString("cbo_19.Items32"),
      (object) componentResourceManager.GetString("cbo_19.Items33"),
      (object) componentResourceManager.GetString("cbo_19.Items34"),
      (object) componentResourceManager.GetString("cbo_19.Items35"),
      (object) componentResourceManager.GetString("cbo_19.Items36"),
      (object) componentResourceManager.GetString("cbo_19.Items37"),
      (object) componentResourceManager.GetString("cbo_19.Items38"),
      (object) componentResourceManager.GetString("cbo_19.Items39"),
      (object) componentResourceManager.GetString("cbo_19.Items40"),
      (object) componentResourceManager.GetString("cbo_19.Items41"),
      (object) componentResourceManager.GetString("cbo_19.Items42"),
      (object) componentResourceManager.GetString("cbo_19.Items43"),
      (object) componentResourceManager.GetString("cbo_19.Items44"),
      (object) componentResourceManager.GetString("cbo_19.Items45"),
      (object) componentResourceManager.GetString("cbo_19.Items46"),
      (object) componentResourceManager.GetString("cbo_19.Items47"),
      (object) componentResourceManager.GetString("cbo_19.Items48"),
      (object) componentResourceManager.GetString("cbo_19.Items49"),
      (object) componentResourceManager.GetString("cbo_19.Items50"),
      (object) componentResourceManager.GetString("cbo_19.Items51"),
      (object) componentResourceManager.GetString("cbo_19.Items52"),
      (object) componentResourceManager.GetString("cbo_19.Items53"),
      (object) componentResourceManager.GetString("cbo_19.Items54"),
      (object) componentResourceManager.GetString("cbo_19.Items55"),
      (object) componentResourceManager.GetString("cbo_19.Items56"),
      (object) componentResourceManager.GetString("cbo_19.Items57"),
      (object) componentResourceManager.GetString("cbo_19.Items58"),
      (object) componentResourceManager.GetString("cbo_19.Items59")
    });
    this.cbo_19.Name = "cbo_19";
    this.cbo_19.SelectedIndexChanged += new EventHandler(this.cbo_1_SelectedIndexChanged);
    componentResourceManager.ApplyResources((object) this.label29, "label29");
    this.label29.Name = "label29";
    componentResourceManager.ApplyResources((object) this.label30, "label30");
    this.label30.Name = "label30";
    this.cbo_18.BackColor = Color.FromArgb(206, 233, 253);
    componentResourceManager.ApplyResources((object) this.cbo_18, "cbo_18");
    this.cbo_18.FormattingEnabled = true;
    this.cbo_18.Items.AddRange(new object[60]
    {
      (object) componentResourceManager.GetString("cbo_18.Items"),
      (object) componentResourceManager.GetString("cbo_18.Items1"),
      (object) componentResourceManager.GetString("cbo_18.Items2"),
      (object) componentResourceManager.GetString("cbo_18.Items3"),
      (object) componentResourceManager.GetString("cbo_18.Items4"),
      (object) componentResourceManager.GetString("cbo_18.Items5"),
      (object) componentResourceManager.GetString("cbo_18.Items6"),
      (object) componentResourceManager.GetString("cbo_18.Items7"),
      (object) componentResourceManager.GetString("cbo_18.Items8"),
      (object) componentResourceManager.GetString("cbo_18.Items9"),
      (object) componentResourceManager.GetString("cbo_18.Items10"),
      (object) componentResourceManager.GetString("cbo_18.Items11"),
      (object) componentResourceManager.GetString("cbo_18.Items12"),
      (object) componentResourceManager.GetString("cbo_18.Items13"),
      (object) componentResourceManager.GetString("cbo_18.Items14"),
      (object) componentResourceManager.GetString("cbo_18.Items15"),
      (object) componentResourceManager.GetString("cbo_18.Items16"),
      (object) componentResourceManager.GetString("cbo_18.Items17"),
      (object) componentResourceManager.GetString("cbo_18.Items18"),
      (object) componentResourceManager.GetString("cbo_18.Items19"),
      (object) componentResourceManager.GetString("cbo_18.Items20"),
      (object) componentResourceManager.GetString("cbo_18.Items21"),
      (object) componentResourceManager.GetString("cbo_18.Items22"),
      (object) componentResourceManager.GetString("cbo_18.Items23"),
      (object) componentResourceManager.GetString("cbo_18.Items24"),
      (object) componentResourceManager.GetString("cbo_18.Items25"),
      (object) componentResourceManager.GetString("cbo_18.Items26"),
      (object) componentResourceManager.GetString("cbo_18.Items27"),
      (object) componentResourceManager.GetString("cbo_18.Items28"),
      (object) componentResourceManager.GetString("cbo_18.Items29"),
      (object) componentResourceManager.GetString("cbo_18.Items30"),
      (object) componentResourceManager.GetString("cbo_18.Items31"),
      (object) componentResourceManager.GetString("cbo_18.Items32"),
      (object) componentResourceManager.GetString("cbo_18.Items33"),
      (object) componentResourceManager.GetString("cbo_18.Items34"),
      (object) componentResourceManager.GetString("cbo_18.Items35"),
      (object) componentResourceManager.GetString("cbo_18.Items36"),
      (object) componentResourceManager.GetString("cbo_18.Items37"),
      (object) componentResourceManager.GetString("cbo_18.Items38"),
      (object) componentResourceManager.GetString("cbo_18.Items39"),
      (object) componentResourceManager.GetString("cbo_18.Items40"),
      (object) componentResourceManager.GetString("cbo_18.Items41"),
      (object) componentResourceManager.GetString("cbo_18.Items42"),
      (object) componentResourceManager.GetString("cbo_18.Items43"),
      (object) componentResourceManager.GetString("cbo_18.Items44"),
      (object) componentResourceManager.GetString("cbo_18.Items45"),
      (object) componentResourceManager.GetString("cbo_18.Items46"),
      (object) componentResourceManager.GetString("cbo_18.Items47"),
      (object) componentResourceManager.GetString("cbo_18.Items48"),
      (object) componentResourceManager.GetString("cbo_18.Items49"),
      (object) componentResourceManager.GetString("cbo_18.Items50"),
      (object) componentResourceManager.GetString("cbo_18.Items51"),
      (object) componentResourceManager.GetString("cbo_18.Items52"),
      (object) componentResourceManager.GetString("cbo_18.Items53"),
      (object) componentResourceManager.GetString("cbo_18.Items54"),
      (object) componentResourceManager.GetString("cbo_18.Items55"),
      (object) componentResourceManager.GetString("cbo_18.Items56"),
      (object) componentResourceManager.GetString("cbo_18.Items57"),
      (object) componentResourceManager.GetString("cbo_18.Items58"),
      (object) componentResourceManager.GetString("cbo_18.Items59")
    });
    this.cbo_18.Name = "cbo_18";
    this.cbo_18.SelectedIndexChanged += new EventHandler(this.cbo_1_SelectedIndexChanged);
    componentResourceManager.ApplyResources((object) this.label27, "label27");
    this.label27.Name = "label27";
    componentResourceManager.ApplyResources((object) this.label28, "label28");
    this.label28.Name = "label28";
    this.cbo_17.BackColor = Color.FromArgb(206, 233, 253);
    componentResourceManager.ApplyResources((object) this.cbo_17, "cbo_17");
    this.cbo_17.FormattingEnabled = true;
    this.cbo_17.Items.AddRange(new object[60]
    {
      (object) componentResourceManager.GetString("cbo_17.Items"),
      (object) componentResourceManager.GetString("cbo_17.Items1"),
      (object) componentResourceManager.GetString("cbo_17.Items2"),
      (object) componentResourceManager.GetString("cbo_17.Items3"),
      (object) componentResourceManager.GetString("cbo_17.Items4"),
      (object) componentResourceManager.GetString("cbo_17.Items5"),
      (object) componentResourceManager.GetString("cbo_17.Items6"),
      (object) componentResourceManager.GetString("cbo_17.Items7"),
      (object) componentResourceManager.GetString("cbo_17.Items8"),
      (object) componentResourceManager.GetString("cbo_17.Items9"),
      (object) componentResourceManager.GetString("cbo_17.Items10"),
      (object) componentResourceManager.GetString("cbo_17.Items11"),
      (object) componentResourceManager.GetString("cbo_17.Items12"),
      (object) componentResourceManager.GetString("cbo_17.Items13"),
      (object) componentResourceManager.GetString("cbo_17.Items14"),
      (object) componentResourceManager.GetString("cbo_17.Items15"),
      (object) componentResourceManager.GetString("cbo_17.Items16"),
      (object) componentResourceManager.GetString("cbo_17.Items17"),
      (object) componentResourceManager.GetString("cbo_17.Items18"),
      (object) componentResourceManager.GetString("cbo_17.Items19"),
      (object) componentResourceManager.GetString("cbo_17.Items20"),
      (object) componentResourceManager.GetString("cbo_17.Items21"),
      (object) componentResourceManager.GetString("cbo_17.Items22"),
      (object) componentResourceManager.GetString("cbo_17.Items23"),
      (object) componentResourceManager.GetString("cbo_17.Items24"),
      (object) componentResourceManager.GetString("cbo_17.Items25"),
      (object) componentResourceManager.GetString("cbo_17.Items26"),
      (object) componentResourceManager.GetString("cbo_17.Items27"),
      (object) componentResourceManager.GetString("cbo_17.Items28"),
      (object) componentResourceManager.GetString("cbo_17.Items29"),
      (object) componentResourceManager.GetString("cbo_17.Items30"),
      (object) componentResourceManager.GetString("cbo_17.Items31"),
      (object) componentResourceManager.GetString("cbo_17.Items32"),
      (object) componentResourceManager.GetString("cbo_17.Items33"),
      (object) componentResourceManager.GetString("cbo_17.Items34"),
      (object) componentResourceManager.GetString("cbo_17.Items35"),
      (object) componentResourceManager.GetString("cbo_17.Items36"),
      (object) componentResourceManager.GetString("cbo_17.Items37"),
      (object) componentResourceManager.GetString("cbo_17.Items38"),
      (object) componentResourceManager.GetString("cbo_17.Items39"),
      (object) componentResourceManager.GetString("cbo_17.Items40"),
      (object) componentResourceManager.GetString("cbo_17.Items41"),
      (object) componentResourceManager.GetString("cbo_17.Items42"),
      (object) componentResourceManager.GetString("cbo_17.Items43"),
      (object) componentResourceManager.GetString("cbo_17.Items44"),
      (object) componentResourceManager.GetString("cbo_17.Items45"),
      (object) componentResourceManager.GetString("cbo_17.Items46"),
      (object) componentResourceManager.GetString("cbo_17.Items47"),
      (object) componentResourceManager.GetString("cbo_17.Items48"),
      (object) componentResourceManager.GetString("cbo_17.Items49"),
      (object) componentResourceManager.GetString("cbo_17.Items50"),
      (object) componentResourceManager.GetString("cbo_17.Items51"),
      (object) componentResourceManager.GetString("cbo_17.Items52"),
      (object) componentResourceManager.GetString("cbo_17.Items53"),
      (object) componentResourceManager.GetString("cbo_17.Items54"),
      (object) componentResourceManager.GetString("cbo_17.Items55"),
      (object) componentResourceManager.GetString("cbo_17.Items56"),
      (object) componentResourceManager.GetString("cbo_17.Items57"),
      (object) componentResourceManager.GetString("cbo_17.Items58"),
      (object) componentResourceManager.GetString("cbo_17.Items59")
    });
    this.cbo_17.Name = "cbo_17";
    this.cbo_17.SelectedIndexChanged += new EventHandler(this.cbo_1_SelectedIndexChanged);
    componentResourceManager.ApplyResources((object) this.label25, "label25");
    this.label25.Name = "label25";
    componentResourceManager.ApplyResources((object) this.label26, "label26");
    this.label26.Name = "label26";
    this.cbo_15.BackColor = Color.FromArgb(206, 233, 253);
    componentResourceManager.ApplyResources((object) this.cbo_15, "cbo_15");
    this.cbo_15.FormattingEnabled = true;
    this.cbo_15.Items.AddRange(new object[60]
    {
      (object) componentResourceManager.GetString("cbo_15.Items"),
      (object) componentResourceManager.GetString("cbo_15.Items1"),
      (object) componentResourceManager.GetString("cbo_15.Items2"),
      (object) componentResourceManager.GetString("cbo_15.Items3"),
      (object) componentResourceManager.GetString("cbo_15.Items4"),
      (object) componentResourceManager.GetString("cbo_15.Items5"),
      (object) componentResourceManager.GetString("cbo_15.Items6"),
      (object) componentResourceManager.GetString("cbo_15.Items7"),
      (object) componentResourceManager.GetString("cbo_15.Items8"),
      (object) componentResourceManager.GetString("cbo_15.Items9"),
      (object) componentResourceManager.GetString("cbo_15.Items10"),
      (object) componentResourceManager.GetString("cbo_15.Items11"),
      (object) componentResourceManager.GetString("cbo_15.Items12"),
      (object) componentResourceManager.GetString("cbo_15.Items13"),
      (object) componentResourceManager.GetString("cbo_15.Items14"),
      (object) componentResourceManager.GetString("cbo_15.Items15"),
      (object) componentResourceManager.GetString("cbo_15.Items16"),
      (object) componentResourceManager.GetString("cbo_15.Items17"),
      (object) componentResourceManager.GetString("cbo_15.Items18"),
      (object) componentResourceManager.GetString("cbo_15.Items19"),
      (object) componentResourceManager.GetString("cbo_15.Items20"),
      (object) componentResourceManager.GetString("cbo_15.Items21"),
      (object) componentResourceManager.GetString("cbo_15.Items22"),
      (object) componentResourceManager.GetString("cbo_15.Items23"),
      (object) componentResourceManager.GetString("cbo_15.Items24"),
      (object) componentResourceManager.GetString("cbo_15.Items25"),
      (object) componentResourceManager.GetString("cbo_15.Items26"),
      (object) componentResourceManager.GetString("cbo_15.Items27"),
      (object) componentResourceManager.GetString("cbo_15.Items28"),
      (object) componentResourceManager.GetString("cbo_15.Items29"),
      (object) componentResourceManager.GetString("cbo_15.Items30"),
      (object) componentResourceManager.GetString("cbo_15.Items31"),
      (object) componentResourceManager.GetString("cbo_15.Items32"),
      (object) componentResourceManager.GetString("cbo_15.Items33"),
      (object) componentResourceManager.GetString("cbo_15.Items34"),
      (object) componentResourceManager.GetString("cbo_15.Items35"),
      (object) componentResourceManager.GetString("cbo_15.Items36"),
      (object) componentResourceManager.GetString("cbo_15.Items37"),
      (object) componentResourceManager.GetString("cbo_15.Items38"),
      (object) componentResourceManager.GetString("cbo_15.Items39"),
      (object) componentResourceManager.GetString("cbo_15.Items40"),
      (object) componentResourceManager.GetString("cbo_15.Items41"),
      (object) componentResourceManager.GetString("cbo_15.Items42"),
      (object) componentResourceManager.GetString("cbo_15.Items43"),
      (object) componentResourceManager.GetString("cbo_15.Items44"),
      (object) componentResourceManager.GetString("cbo_15.Items45"),
      (object) componentResourceManager.GetString("cbo_15.Items46"),
      (object) componentResourceManager.GetString("cbo_15.Items47"),
      (object) componentResourceManager.GetString("cbo_15.Items48"),
      (object) componentResourceManager.GetString("cbo_15.Items49"),
      (object) componentResourceManager.GetString("cbo_15.Items50"),
      (object) componentResourceManager.GetString("cbo_15.Items51"),
      (object) componentResourceManager.GetString("cbo_15.Items52"),
      (object) componentResourceManager.GetString("cbo_15.Items53"),
      (object) componentResourceManager.GetString("cbo_15.Items54"),
      (object) componentResourceManager.GetString("cbo_15.Items55"),
      (object) componentResourceManager.GetString("cbo_15.Items56"),
      (object) componentResourceManager.GetString("cbo_15.Items57"),
      (object) componentResourceManager.GetString("cbo_15.Items58"),
      (object) componentResourceManager.GetString("cbo_15.Items59")
    });
    this.cbo_15.Name = "cbo_15";
    this.cbo_15.SelectedIndexChanged += new EventHandler(this.cbo_1_SelectedIndexChanged);
    componentResourceManager.ApplyResources((object) this.label23, "label23");
    this.label23.Name = "label23";
    componentResourceManager.ApplyResources((object) this.label24, "label24");
    this.label24.Name = "label24";
    this.cbo_14.BackColor = Color.FromArgb(206, 233, 253);
    componentResourceManager.ApplyResources((object) this.cbo_14, "cbo_14");
    this.cbo_14.FormattingEnabled = true;
    this.cbo_14.Items.AddRange(new object[60]
    {
      (object) componentResourceManager.GetString("cbo_14.Items"),
      (object) componentResourceManager.GetString("cbo_14.Items1"),
      (object) componentResourceManager.GetString("cbo_14.Items2"),
      (object) componentResourceManager.GetString("cbo_14.Items3"),
      (object) componentResourceManager.GetString("cbo_14.Items4"),
      (object) componentResourceManager.GetString("cbo_14.Items5"),
      (object) componentResourceManager.GetString("cbo_14.Items6"),
      (object) componentResourceManager.GetString("cbo_14.Items7"),
      (object) componentResourceManager.GetString("cbo_14.Items8"),
      (object) componentResourceManager.GetString("cbo_14.Items9"),
      (object) componentResourceManager.GetString("cbo_14.Items10"),
      (object) componentResourceManager.GetString("cbo_14.Items11"),
      (object) componentResourceManager.GetString("cbo_14.Items12"),
      (object) componentResourceManager.GetString("cbo_14.Items13"),
      (object) componentResourceManager.GetString("cbo_14.Items14"),
      (object) componentResourceManager.GetString("cbo_14.Items15"),
      (object) componentResourceManager.GetString("cbo_14.Items16"),
      (object) componentResourceManager.GetString("cbo_14.Items17"),
      (object) componentResourceManager.GetString("cbo_14.Items18"),
      (object) componentResourceManager.GetString("cbo_14.Items19"),
      (object) componentResourceManager.GetString("cbo_14.Items20"),
      (object) componentResourceManager.GetString("cbo_14.Items21"),
      (object) componentResourceManager.GetString("cbo_14.Items22"),
      (object) componentResourceManager.GetString("cbo_14.Items23"),
      (object) componentResourceManager.GetString("cbo_14.Items24"),
      (object) componentResourceManager.GetString("cbo_14.Items25"),
      (object) componentResourceManager.GetString("cbo_14.Items26"),
      (object) componentResourceManager.GetString("cbo_14.Items27"),
      (object) componentResourceManager.GetString("cbo_14.Items28"),
      (object) componentResourceManager.GetString("cbo_14.Items29"),
      (object) componentResourceManager.GetString("cbo_14.Items30"),
      (object) componentResourceManager.GetString("cbo_14.Items31"),
      (object) componentResourceManager.GetString("cbo_14.Items32"),
      (object) componentResourceManager.GetString("cbo_14.Items33"),
      (object) componentResourceManager.GetString("cbo_14.Items34"),
      (object) componentResourceManager.GetString("cbo_14.Items35"),
      (object) componentResourceManager.GetString("cbo_14.Items36"),
      (object) componentResourceManager.GetString("cbo_14.Items37"),
      (object) componentResourceManager.GetString("cbo_14.Items38"),
      (object) componentResourceManager.GetString("cbo_14.Items39"),
      (object) componentResourceManager.GetString("cbo_14.Items40"),
      (object) componentResourceManager.GetString("cbo_14.Items41"),
      (object) componentResourceManager.GetString("cbo_14.Items42"),
      (object) componentResourceManager.GetString("cbo_14.Items43"),
      (object) componentResourceManager.GetString("cbo_14.Items44"),
      (object) componentResourceManager.GetString("cbo_14.Items45"),
      (object) componentResourceManager.GetString("cbo_14.Items46"),
      (object) componentResourceManager.GetString("cbo_14.Items47"),
      (object) componentResourceManager.GetString("cbo_14.Items48"),
      (object) componentResourceManager.GetString("cbo_14.Items49"),
      (object) componentResourceManager.GetString("cbo_14.Items50"),
      (object) componentResourceManager.GetString("cbo_14.Items51"),
      (object) componentResourceManager.GetString("cbo_14.Items52"),
      (object) componentResourceManager.GetString("cbo_14.Items53"),
      (object) componentResourceManager.GetString("cbo_14.Items54"),
      (object) componentResourceManager.GetString("cbo_14.Items55"),
      (object) componentResourceManager.GetString("cbo_14.Items56"),
      (object) componentResourceManager.GetString("cbo_14.Items57"),
      (object) componentResourceManager.GetString("cbo_14.Items58"),
      (object) componentResourceManager.GetString("cbo_14.Items59")
    });
    this.cbo_14.Name = "cbo_14";
    this.cbo_14.SelectedIndexChanged += new EventHandler(this.cbo_1_SelectedIndexChanged);
    componentResourceManager.ApplyResources((object) this.label21, "label21");
    this.label21.Name = "label21";
    componentResourceManager.ApplyResources((object) this.label22, "label22");
    this.label22.Name = "label22";
    this.cbo_13.BackColor = Color.FromArgb(206, 233, 253);
    componentResourceManager.ApplyResources((object) this.cbo_13, "cbo_13");
    this.cbo_13.FormattingEnabled = true;
    this.cbo_13.Items.AddRange(new object[60]
    {
      (object) componentResourceManager.GetString("cbo_13.Items"),
      (object) componentResourceManager.GetString("cbo_13.Items1"),
      (object) componentResourceManager.GetString("cbo_13.Items2"),
      (object) componentResourceManager.GetString("cbo_13.Items3"),
      (object) componentResourceManager.GetString("cbo_13.Items4"),
      (object) componentResourceManager.GetString("cbo_13.Items5"),
      (object) componentResourceManager.GetString("cbo_13.Items6"),
      (object) componentResourceManager.GetString("cbo_13.Items7"),
      (object) componentResourceManager.GetString("cbo_13.Items8"),
      (object) componentResourceManager.GetString("cbo_13.Items9"),
      (object) componentResourceManager.GetString("cbo_13.Items10"),
      (object) componentResourceManager.GetString("cbo_13.Items11"),
      (object) componentResourceManager.GetString("cbo_13.Items12"),
      (object) componentResourceManager.GetString("cbo_13.Items13"),
      (object) componentResourceManager.GetString("cbo_13.Items14"),
      (object) componentResourceManager.GetString("cbo_13.Items15"),
      (object) componentResourceManager.GetString("cbo_13.Items16"),
      (object) componentResourceManager.GetString("cbo_13.Items17"),
      (object) componentResourceManager.GetString("cbo_13.Items18"),
      (object) componentResourceManager.GetString("cbo_13.Items19"),
      (object) componentResourceManager.GetString("cbo_13.Items20"),
      (object) componentResourceManager.GetString("cbo_13.Items21"),
      (object) componentResourceManager.GetString("cbo_13.Items22"),
      (object) componentResourceManager.GetString("cbo_13.Items23"),
      (object) componentResourceManager.GetString("cbo_13.Items24"),
      (object) componentResourceManager.GetString("cbo_13.Items25"),
      (object) componentResourceManager.GetString("cbo_13.Items26"),
      (object) componentResourceManager.GetString("cbo_13.Items27"),
      (object) componentResourceManager.GetString("cbo_13.Items28"),
      (object) componentResourceManager.GetString("cbo_13.Items29"),
      (object) componentResourceManager.GetString("cbo_13.Items30"),
      (object) componentResourceManager.GetString("cbo_13.Items31"),
      (object) componentResourceManager.GetString("cbo_13.Items32"),
      (object) componentResourceManager.GetString("cbo_13.Items33"),
      (object) componentResourceManager.GetString("cbo_13.Items34"),
      (object) componentResourceManager.GetString("cbo_13.Items35"),
      (object) componentResourceManager.GetString("cbo_13.Items36"),
      (object) componentResourceManager.GetString("cbo_13.Items37"),
      (object) componentResourceManager.GetString("cbo_13.Items38"),
      (object) componentResourceManager.GetString("cbo_13.Items39"),
      (object) componentResourceManager.GetString("cbo_13.Items40"),
      (object) componentResourceManager.GetString("cbo_13.Items41"),
      (object) componentResourceManager.GetString("cbo_13.Items42"),
      (object) componentResourceManager.GetString("cbo_13.Items43"),
      (object) componentResourceManager.GetString("cbo_13.Items44"),
      (object) componentResourceManager.GetString("cbo_13.Items45"),
      (object) componentResourceManager.GetString("cbo_13.Items46"),
      (object) componentResourceManager.GetString("cbo_13.Items47"),
      (object) componentResourceManager.GetString("cbo_13.Items48"),
      (object) componentResourceManager.GetString("cbo_13.Items49"),
      (object) componentResourceManager.GetString("cbo_13.Items50"),
      (object) componentResourceManager.GetString("cbo_13.Items51"),
      (object) componentResourceManager.GetString("cbo_13.Items52"),
      (object) componentResourceManager.GetString("cbo_13.Items53"),
      (object) componentResourceManager.GetString("cbo_13.Items54"),
      (object) componentResourceManager.GetString("cbo_13.Items55"),
      (object) componentResourceManager.GetString("cbo_13.Items56"),
      (object) componentResourceManager.GetString("cbo_13.Items57"),
      (object) componentResourceManager.GetString("cbo_13.Items58"),
      (object) componentResourceManager.GetString("cbo_13.Items59")
    });
    this.cbo_13.Name = "cbo_13";
    this.cbo_13.SelectedIndexChanged += new EventHandler(this.cbo_1_SelectedIndexChanged);
    componentResourceManager.ApplyResources((object) this.label19, "label19");
    this.label19.Name = "label19";
    componentResourceManager.ApplyResources((object) this.label20, "label20");
    this.label20.Name = "label20";
    this.cbo_12.BackColor = Color.FromArgb(206, 233, 253);
    componentResourceManager.ApplyResources((object) this.cbo_12, "cbo_12");
    this.cbo_12.FormattingEnabled = true;
    this.cbo_12.Items.AddRange(new object[60]
    {
      (object) componentResourceManager.GetString("cbo_12.Items"),
      (object) componentResourceManager.GetString("cbo_12.Items1"),
      (object) componentResourceManager.GetString("cbo_12.Items2"),
      (object) componentResourceManager.GetString("cbo_12.Items3"),
      (object) componentResourceManager.GetString("cbo_12.Items4"),
      (object) componentResourceManager.GetString("cbo_12.Items5"),
      (object) componentResourceManager.GetString("cbo_12.Items6"),
      (object) componentResourceManager.GetString("cbo_12.Items7"),
      (object) componentResourceManager.GetString("cbo_12.Items8"),
      (object) componentResourceManager.GetString("cbo_12.Items9"),
      (object) componentResourceManager.GetString("cbo_12.Items10"),
      (object) componentResourceManager.GetString("cbo_12.Items11"),
      (object) componentResourceManager.GetString("cbo_12.Items12"),
      (object) componentResourceManager.GetString("cbo_12.Items13"),
      (object) componentResourceManager.GetString("cbo_12.Items14"),
      (object) componentResourceManager.GetString("cbo_12.Items15"),
      (object) componentResourceManager.GetString("cbo_12.Items16"),
      (object) componentResourceManager.GetString("cbo_12.Items17"),
      (object) componentResourceManager.GetString("cbo_12.Items18"),
      (object) componentResourceManager.GetString("cbo_12.Items19"),
      (object) componentResourceManager.GetString("cbo_12.Items20"),
      (object) componentResourceManager.GetString("cbo_12.Items21"),
      (object) componentResourceManager.GetString("cbo_12.Items22"),
      (object) componentResourceManager.GetString("cbo_12.Items23"),
      (object) componentResourceManager.GetString("cbo_12.Items24"),
      (object) componentResourceManager.GetString("cbo_12.Items25"),
      (object) componentResourceManager.GetString("cbo_12.Items26"),
      (object) componentResourceManager.GetString("cbo_12.Items27"),
      (object) componentResourceManager.GetString("cbo_12.Items28"),
      (object) componentResourceManager.GetString("cbo_12.Items29"),
      (object) componentResourceManager.GetString("cbo_12.Items30"),
      (object) componentResourceManager.GetString("cbo_12.Items31"),
      (object) componentResourceManager.GetString("cbo_12.Items32"),
      (object) componentResourceManager.GetString("cbo_12.Items33"),
      (object) componentResourceManager.GetString("cbo_12.Items34"),
      (object) componentResourceManager.GetString("cbo_12.Items35"),
      (object) componentResourceManager.GetString("cbo_12.Items36"),
      (object) componentResourceManager.GetString("cbo_12.Items37"),
      (object) componentResourceManager.GetString("cbo_12.Items38"),
      (object) componentResourceManager.GetString("cbo_12.Items39"),
      (object) componentResourceManager.GetString("cbo_12.Items40"),
      (object) componentResourceManager.GetString("cbo_12.Items41"),
      (object) componentResourceManager.GetString("cbo_12.Items42"),
      (object) componentResourceManager.GetString("cbo_12.Items43"),
      (object) componentResourceManager.GetString("cbo_12.Items44"),
      (object) componentResourceManager.GetString("cbo_12.Items45"),
      (object) componentResourceManager.GetString("cbo_12.Items46"),
      (object) componentResourceManager.GetString("cbo_12.Items47"),
      (object) componentResourceManager.GetString("cbo_12.Items48"),
      (object) componentResourceManager.GetString("cbo_12.Items49"),
      (object) componentResourceManager.GetString("cbo_12.Items50"),
      (object) componentResourceManager.GetString("cbo_12.Items51"),
      (object) componentResourceManager.GetString("cbo_12.Items52"),
      (object) componentResourceManager.GetString("cbo_12.Items53"),
      (object) componentResourceManager.GetString("cbo_12.Items54"),
      (object) componentResourceManager.GetString("cbo_12.Items55"),
      (object) componentResourceManager.GetString("cbo_12.Items56"),
      (object) componentResourceManager.GetString("cbo_12.Items57"),
      (object) componentResourceManager.GetString("cbo_12.Items58"),
      (object) componentResourceManager.GetString("cbo_12.Items59")
    });
    this.cbo_12.Name = "cbo_12";
    this.cbo_12.SelectedIndexChanged += new EventHandler(this.cbo_1_SelectedIndexChanged);
    componentResourceManager.ApplyResources((object) this.label17, "label17");
    this.label17.Name = "label17";
    componentResourceManager.ApplyResources((object) this.label18, "label18");
    this.label18.Name = "label18";
    this.cbo_11.BackColor = Color.FromArgb(206, 233, 253);
    componentResourceManager.ApplyResources((object) this.cbo_11, "cbo_11");
    this.cbo_11.FormattingEnabled = true;
    this.cbo_11.Items.AddRange(new object[60]
    {
      (object) componentResourceManager.GetString("cbo_11.Items"),
      (object) componentResourceManager.GetString("cbo_11.Items1"),
      (object) componentResourceManager.GetString("cbo_11.Items2"),
      (object) componentResourceManager.GetString("cbo_11.Items3"),
      (object) componentResourceManager.GetString("cbo_11.Items4"),
      (object) componentResourceManager.GetString("cbo_11.Items5"),
      (object) componentResourceManager.GetString("cbo_11.Items6"),
      (object) componentResourceManager.GetString("cbo_11.Items7"),
      (object) componentResourceManager.GetString("cbo_11.Items8"),
      (object) componentResourceManager.GetString("cbo_11.Items9"),
      (object) componentResourceManager.GetString("cbo_11.Items10"),
      (object) componentResourceManager.GetString("cbo_11.Items11"),
      (object) componentResourceManager.GetString("cbo_11.Items12"),
      (object) componentResourceManager.GetString("cbo_11.Items13"),
      (object) componentResourceManager.GetString("cbo_11.Items14"),
      (object) componentResourceManager.GetString("cbo_11.Items15"),
      (object) componentResourceManager.GetString("cbo_11.Items16"),
      (object) componentResourceManager.GetString("cbo_11.Items17"),
      (object) componentResourceManager.GetString("cbo_11.Items18"),
      (object) componentResourceManager.GetString("cbo_11.Items19"),
      (object) componentResourceManager.GetString("cbo_11.Items20"),
      (object) componentResourceManager.GetString("cbo_11.Items21"),
      (object) componentResourceManager.GetString("cbo_11.Items22"),
      (object) componentResourceManager.GetString("cbo_11.Items23"),
      (object) componentResourceManager.GetString("cbo_11.Items24"),
      (object) componentResourceManager.GetString("cbo_11.Items25"),
      (object) componentResourceManager.GetString("cbo_11.Items26"),
      (object) componentResourceManager.GetString("cbo_11.Items27"),
      (object) componentResourceManager.GetString("cbo_11.Items28"),
      (object) componentResourceManager.GetString("cbo_11.Items29"),
      (object) componentResourceManager.GetString("cbo_11.Items30"),
      (object) componentResourceManager.GetString("cbo_11.Items31"),
      (object) componentResourceManager.GetString("cbo_11.Items32"),
      (object) componentResourceManager.GetString("cbo_11.Items33"),
      (object) componentResourceManager.GetString("cbo_11.Items34"),
      (object) componentResourceManager.GetString("cbo_11.Items35"),
      (object) componentResourceManager.GetString("cbo_11.Items36"),
      (object) componentResourceManager.GetString("cbo_11.Items37"),
      (object) componentResourceManager.GetString("cbo_11.Items38"),
      (object) componentResourceManager.GetString("cbo_11.Items39"),
      (object) componentResourceManager.GetString("cbo_11.Items40"),
      (object) componentResourceManager.GetString("cbo_11.Items41"),
      (object) componentResourceManager.GetString("cbo_11.Items42"),
      (object) componentResourceManager.GetString("cbo_11.Items43"),
      (object) componentResourceManager.GetString("cbo_11.Items44"),
      (object) componentResourceManager.GetString("cbo_11.Items45"),
      (object) componentResourceManager.GetString("cbo_11.Items46"),
      (object) componentResourceManager.GetString("cbo_11.Items47"),
      (object) componentResourceManager.GetString("cbo_11.Items48"),
      (object) componentResourceManager.GetString("cbo_11.Items49"),
      (object) componentResourceManager.GetString("cbo_11.Items50"),
      (object) componentResourceManager.GetString("cbo_11.Items51"),
      (object) componentResourceManager.GetString("cbo_11.Items52"),
      (object) componentResourceManager.GetString("cbo_11.Items53"),
      (object) componentResourceManager.GetString("cbo_11.Items54"),
      (object) componentResourceManager.GetString("cbo_11.Items55"),
      (object) componentResourceManager.GetString("cbo_11.Items56"),
      (object) componentResourceManager.GetString("cbo_11.Items57"),
      (object) componentResourceManager.GetString("cbo_11.Items58"),
      (object) componentResourceManager.GetString("cbo_11.Items59")
    });
    this.cbo_11.Name = "cbo_11";
    this.cbo_11.SelectedIndexChanged += new EventHandler(this.cbo_1_SelectedIndexChanged);
    componentResourceManager.ApplyResources((object) this.label15, "label15");
    this.label15.Name = "label15";
    componentResourceManager.ApplyResources((object) this.label16, "label16");
    this.label16.Name = "label16";
    this.cbo_4.BackColor = Color.FromArgb(206, 233, 253);
    componentResourceManager.ApplyResources((object) this.cbo_4, "cbo_4");
    this.cbo_4.FormattingEnabled = true;
    this.cbo_4.Items.AddRange(new object[60]
    {
      (object) componentResourceManager.GetString("cbo_4.Items"),
      (object) componentResourceManager.GetString("cbo_4.Items1"),
      (object) componentResourceManager.GetString("cbo_4.Items2"),
      (object) componentResourceManager.GetString("cbo_4.Items3"),
      (object) componentResourceManager.GetString("cbo_4.Items4"),
      (object) componentResourceManager.GetString("cbo_4.Items5"),
      (object) componentResourceManager.GetString("cbo_4.Items6"),
      (object) componentResourceManager.GetString("cbo_4.Items7"),
      (object) componentResourceManager.GetString("cbo_4.Items8"),
      (object) componentResourceManager.GetString("cbo_4.Items9"),
      (object) componentResourceManager.GetString("cbo_4.Items10"),
      (object) componentResourceManager.GetString("cbo_4.Items11"),
      (object) componentResourceManager.GetString("cbo_4.Items12"),
      (object) componentResourceManager.GetString("cbo_4.Items13"),
      (object) componentResourceManager.GetString("cbo_4.Items14"),
      (object) componentResourceManager.GetString("cbo_4.Items15"),
      (object) componentResourceManager.GetString("cbo_4.Items16"),
      (object) componentResourceManager.GetString("cbo_4.Items17"),
      (object) componentResourceManager.GetString("cbo_4.Items18"),
      (object) componentResourceManager.GetString("cbo_4.Items19"),
      (object) componentResourceManager.GetString("cbo_4.Items20"),
      (object) componentResourceManager.GetString("cbo_4.Items21"),
      (object) componentResourceManager.GetString("cbo_4.Items22"),
      (object) componentResourceManager.GetString("cbo_4.Items23"),
      (object) componentResourceManager.GetString("cbo_4.Items24"),
      (object) componentResourceManager.GetString("cbo_4.Items25"),
      (object) componentResourceManager.GetString("cbo_4.Items26"),
      (object) componentResourceManager.GetString("cbo_4.Items27"),
      (object) componentResourceManager.GetString("cbo_4.Items28"),
      (object) componentResourceManager.GetString("cbo_4.Items29"),
      (object) componentResourceManager.GetString("cbo_4.Items30"),
      (object) componentResourceManager.GetString("cbo_4.Items31"),
      (object) componentResourceManager.GetString("cbo_4.Items32"),
      (object) componentResourceManager.GetString("cbo_4.Items33"),
      (object) componentResourceManager.GetString("cbo_4.Items34"),
      (object) componentResourceManager.GetString("cbo_4.Items35"),
      (object) componentResourceManager.GetString("cbo_4.Items36"),
      (object) componentResourceManager.GetString("cbo_4.Items37"),
      (object) componentResourceManager.GetString("cbo_4.Items38"),
      (object) componentResourceManager.GetString("cbo_4.Items39"),
      (object) componentResourceManager.GetString("cbo_4.Items40"),
      (object) componentResourceManager.GetString("cbo_4.Items41"),
      (object) componentResourceManager.GetString("cbo_4.Items42"),
      (object) componentResourceManager.GetString("cbo_4.Items43"),
      (object) componentResourceManager.GetString("cbo_4.Items44"),
      (object) componentResourceManager.GetString("cbo_4.Items45"),
      (object) componentResourceManager.GetString("cbo_4.Items46"),
      (object) componentResourceManager.GetString("cbo_4.Items47"),
      (object) componentResourceManager.GetString("cbo_4.Items48"),
      (object) componentResourceManager.GetString("cbo_4.Items49"),
      (object) componentResourceManager.GetString("cbo_4.Items50"),
      (object) componentResourceManager.GetString("cbo_4.Items51"),
      (object) componentResourceManager.GetString("cbo_4.Items52"),
      (object) componentResourceManager.GetString("cbo_4.Items53"),
      (object) componentResourceManager.GetString("cbo_4.Items54"),
      (object) componentResourceManager.GetString("cbo_4.Items55"),
      (object) componentResourceManager.GetString("cbo_4.Items56"),
      (object) componentResourceManager.GetString("cbo_4.Items57"),
      (object) componentResourceManager.GetString("cbo_4.Items58"),
      (object) componentResourceManager.GetString("cbo_4.Items59")
    });
    this.cbo_4.Name = "cbo_4";
    this.cbo_4.SelectedIndexChanged += new EventHandler(this.cbo_1_SelectedIndexChanged);
    componentResourceManager.ApplyResources((object) this.label13, "label13");
    this.label13.Name = "label13";
    componentResourceManager.ApplyResources((object) this.label14, "label14");
    this.label14.Name = "label14";
    this.cbo_3.BackColor = Color.FromArgb(206, 233, 253);
    componentResourceManager.ApplyResources((object) this.cbo_3, "cbo_3");
    this.cbo_3.FormattingEnabled = true;
    this.cbo_3.Items.AddRange(new object[60]
    {
      (object) componentResourceManager.GetString("cbo_3.Items"),
      (object) componentResourceManager.GetString("cbo_3.Items1"),
      (object) componentResourceManager.GetString("cbo_3.Items2"),
      (object) componentResourceManager.GetString("cbo_3.Items3"),
      (object) componentResourceManager.GetString("cbo_3.Items4"),
      (object) componentResourceManager.GetString("cbo_3.Items5"),
      (object) componentResourceManager.GetString("cbo_3.Items6"),
      (object) componentResourceManager.GetString("cbo_3.Items7"),
      (object) componentResourceManager.GetString("cbo_3.Items8"),
      (object) componentResourceManager.GetString("cbo_3.Items9"),
      (object) componentResourceManager.GetString("cbo_3.Items10"),
      (object) componentResourceManager.GetString("cbo_3.Items11"),
      (object) componentResourceManager.GetString("cbo_3.Items12"),
      (object) componentResourceManager.GetString("cbo_3.Items13"),
      (object) componentResourceManager.GetString("cbo_3.Items14"),
      (object) componentResourceManager.GetString("cbo_3.Items15"),
      (object) componentResourceManager.GetString("cbo_3.Items16"),
      (object) componentResourceManager.GetString("cbo_3.Items17"),
      (object) componentResourceManager.GetString("cbo_3.Items18"),
      (object) componentResourceManager.GetString("cbo_3.Items19"),
      (object) componentResourceManager.GetString("cbo_3.Items20"),
      (object) componentResourceManager.GetString("cbo_3.Items21"),
      (object) componentResourceManager.GetString("cbo_3.Items22"),
      (object) componentResourceManager.GetString("cbo_3.Items23"),
      (object) componentResourceManager.GetString("cbo_3.Items24"),
      (object) componentResourceManager.GetString("cbo_3.Items25"),
      (object) componentResourceManager.GetString("cbo_3.Items26"),
      (object) componentResourceManager.GetString("cbo_3.Items27"),
      (object) componentResourceManager.GetString("cbo_3.Items28"),
      (object) componentResourceManager.GetString("cbo_3.Items29"),
      (object) componentResourceManager.GetString("cbo_3.Items30"),
      (object) componentResourceManager.GetString("cbo_3.Items31"),
      (object) componentResourceManager.GetString("cbo_3.Items32"),
      (object) componentResourceManager.GetString("cbo_3.Items33"),
      (object) componentResourceManager.GetString("cbo_3.Items34"),
      (object) componentResourceManager.GetString("cbo_3.Items35"),
      (object) componentResourceManager.GetString("cbo_3.Items36"),
      (object) componentResourceManager.GetString("cbo_3.Items37"),
      (object) componentResourceManager.GetString("cbo_3.Items38"),
      (object) componentResourceManager.GetString("cbo_3.Items39"),
      (object) componentResourceManager.GetString("cbo_3.Items40"),
      (object) componentResourceManager.GetString("cbo_3.Items41"),
      (object) componentResourceManager.GetString("cbo_3.Items42"),
      (object) componentResourceManager.GetString("cbo_3.Items43"),
      (object) componentResourceManager.GetString("cbo_3.Items44"),
      (object) componentResourceManager.GetString("cbo_3.Items45"),
      (object) componentResourceManager.GetString("cbo_3.Items46"),
      (object) componentResourceManager.GetString("cbo_3.Items47"),
      (object) componentResourceManager.GetString("cbo_3.Items48"),
      (object) componentResourceManager.GetString("cbo_3.Items49"),
      (object) componentResourceManager.GetString("cbo_3.Items50"),
      (object) componentResourceManager.GetString("cbo_3.Items51"),
      (object) componentResourceManager.GetString("cbo_3.Items52"),
      (object) componentResourceManager.GetString("cbo_3.Items53"),
      (object) componentResourceManager.GetString("cbo_3.Items54"),
      (object) componentResourceManager.GetString("cbo_3.Items55"),
      (object) componentResourceManager.GetString("cbo_3.Items56"),
      (object) componentResourceManager.GetString("cbo_3.Items57"),
      (object) componentResourceManager.GetString("cbo_3.Items58"),
      (object) componentResourceManager.GetString("cbo_3.Items59")
    });
    this.cbo_3.Name = "cbo_3";
    this.cbo_3.SelectedIndexChanged += new EventHandler(this.cbo_1_SelectedIndexChanged);
    componentResourceManager.ApplyResources((object) this.label10, "label10");
    this.label10.Name = "label10";
    componentResourceManager.ApplyResources((object) this.label12, "label12");
    this.label12.Name = "label12";
    this.cbo_2.BackColor = Color.FromArgb(206, 233, 253);
    componentResourceManager.ApplyResources((object) this.cbo_2, "cbo_2");
    this.cbo_2.FormattingEnabled = true;
    this.cbo_2.Items.AddRange(new object[60]
    {
      (object) componentResourceManager.GetString("cbo_2.Items"),
      (object) componentResourceManager.GetString("cbo_2.Items1"),
      (object) componentResourceManager.GetString("cbo_2.Items2"),
      (object) componentResourceManager.GetString("cbo_2.Items3"),
      (object) componentResourceManager.GetString("cbo_2.Items4"),
      (object) componentResourceManager.GetString("cbo_2.Items5"),
      (object) componentResourceManager.GetString("cbo_2.Items6"),
      (object) componentResourceManager.GetString("cbo_2.Items7"),
      (object) componentResourceManager.GetString("cbo_2.Items8"),
      (object) componentResourceManager.GetString("cbo_2.Items9"),
      (object) componentResourceManager.GetString("cbo_2.Items10"),
      (object) componentResourceManager.GetString("cbo_2.Items11"),
      (object) componentResourceManager.GetString("cbo_2.Items12"),
      (object) componentResourceManager.GetString("cbo_2.Items13"),
      (object) componentResourceManager.GetString("cbo_2.Items14"),
      (object) componentResourceManager.GetString("cbo_2.Items15"),
      (object) componentResourceManager.GetString("cbo_2.Items16"),
      (object) componentResourceManager.GetString("cbo_2.Items17"),
      (object) componentResourceManager.GetString("cbo_2.Items18"),
      (object) componentResourceManager.GetString("cbo_2.Items19"),
      (object) componentResourceManager.GetString("cbo_2.Items20"),
      (object) componentResourceManager.GetString("cbo_2.Items21"),
      (object) componentResourceManager.GetString("cbo_2.Items22"),
      (object) componentResourceManager.GetString("cbo_2.Items23"),
      (object) componentResourceManager.GetString("cbo_2.Items24"),
      (object) componentResourceManager.GetString("cbo_2.Items25"),
      (object) componentResourceManager.GetString("cbo_2.Items26"),
      (object) componentResourceManager.GetString("cbo_2.Items27"),
      (object) componentResourceManager.GetString("cbo_2.Items28"),
      (object) componentResourceManager.GetString("cbo_2.Items29"),
      (object) componentResourceManager.GetString("cbo_2.Items30"),
      (object) componentResourceManager.GetString("cbo_2.Items31"),
      (object) componentResourceManager.GetString("cbo_2.Items32"),
      (object) componentResourceManager.GetString("cbo_2.Items33"),
      (object) componentResourceManager.GetString("cbo_2.Items34"),
      (object) componentResourceManager.GetString("cbo_2.Items35"),
      (object) componentResourceManager.GetString("cbo_2.Items36"),
      (object) componentResourceManager.GetString("cbo_2.Items37"),
      (object) componentResourceManager.GetString("cbo_2.Items38"),
      (object) componentResourceManager.GetString("cbo_2.Items39"),
      (object) componentResourceManager.GetString("cbo_2.Items40"),
      (object) componentResourceManager.GetString("cbo_2.Items41"),
      (object) componentResourceManager.GetString("cbo_2.Items42"),
      (object) componentResourceManager.GetString("cbo_2.Items43"),
      (object) componentResourceManager.GetString("cbo_2.Items44"),
      (object) componentResourceManager.GetString("cbo_2.Items45"),
      (object) componentResourceManager.GetString("cbo_2.Items46"),
      (object) componentResourceManager.GetString("cbo_2.Items47"),
      (object) componentResourceManager.GetString("cbo_2.Items48"),
      (object) componentResourceManager.GetString("cbo_2.Items49"),
      (object) componentResourceManager.GetString("cbo_2.Items50"),
      (object) componentResourceManager.GetString("cbo_2.Items51"),
      (object) componentResourceManager.GetString("cbo_2.Items52"),
      (object) componentResourceManager.GetString("cbo_2.Items53"),
      (object) componentResourceManager.GetString("cbo_2.Items54"),
      (object) componentResourceManager.GetString("cbo_2.Items55"),
      (object) componentResourceManager.GetString("cbo_2.Items56"),
      (object) componentResourceManager.GetString("cbo_2.Items57"),
      (object) componentResourceManager.GetString("cbo_2.Items58"),
      (object) componentResourceManager.GetString("cbo_2.Items59")
    });
    this.cbo_2.Name = "cbo_2";
    this.cbo_2.SelectedIndexChanged += new EventHandler(this.cbo_1_SelectedIndexChanged);
    componentResourceManager.ApplyResources((object) this.label6, "label6");
    this.label6.Name = "label6";
    componentResourceManager.ApplyResources((object) this.label7, "label7");
    this.label7.Name = "label7";
    this.cbo_1.BackColor = Color.FromArgb(206, 233, 253);
    componentResourceManager.ApplyResources((object) this.cbo_1, "cbo_1");
    this.cbo_1.FormattingEnabled = true;
    this.cbo_1.Items.AddRange(new object[60]
    {
      (object) componentResourceManager.GetString("cbo_1.Items"),
      (object) componentResourceManager.GetString("cbo_1.Items1"),
      (object) componentResourceManager.GetString("cbo_1.Items2"),
      (object) componentResourceManager.GetString("cbo_1.Items3"),
      (object) componentResourceManager.GetString("cbo_1.Items4"),
      (object) componentResourceManager.GetString("cbo_1.Items5"),
      (object) componentResourceManager.GetString("cbo_1.Items6"),
      (object) componentResourceManager.GetString("cbo_1.Items7"),
      (object) componentResourceManager.GetString("cbo_1.Items8"),
      (object) componentResourceManager.GetString("cbo_1.Items9"),
      (object) componentResourceManager.GetString("cbo_1.Items10"),
      (object) componentResourceManager.GetString("cbo_1.Items11"),
      (object) componentResourceManager.GetString("cbo_1.Items12"),
      (object) componentResourceManager.GetString("cbo_1.Items13"),
      (object) componentResourceManager.GetString("cbo_1.Items14"),
      (object) componentResourceManager.GetString("cbo_1.Items15"),
      (object) componentResourceManager.GetString("cbo_1.Items16"),
      (object) componentResourceManager.GetString("cbo_1.Items17"),
      (object) componentResourceManager.GetString("cbo_1.Items18"),
      (object) componentResourceManager.GetString("cbo_1.Items19"),
      (object) componentResourceManager.GetString("cbo_1.Items20"),
      (object) componentResourceManager.GetString("cbo_1.Items21"),
      (object) componentResourceManager.GetString("cbo_1.Items22"),
      (object) componentResourceManager.GetString("cbo_1.Items23"),
      (object) componentResourceManager.GetString("cbo_1.Items24"),
      (object) componentResourceManager.GetString("cbo_1.Items25"),
      (object) componentResourceManager.GetString("cbo_1.Items26"),
      (object) componentResourceManager.GetString("cbo_1.Items27"),
      (object) componentResourceManager.GetString("cbo_1.Items28"),
      (object) componentResourceManager.GetString("cbo_1.Items29"),
      (object) componentResourceManager.GetString("cbo_1.Items30"),
      (object) componentResourceManager.GetString("cbo_1.Items31"),
      (object) componentResourceManager.GetString("cbo_1.Items32"),
      (object) componentResourceManager.GetString("cbo_1.Items33"),
      (object) componentResourceManager.GetString("cbo_1.Items34"),
      (object) componentResourceManager.GetString("cbo_1.Items35"),
      (object) componentResourceManager.GetString("cbo_1.Items36"),
      (object) componentResourceManager.GetString("cbo_1.Items37"),
      (object) componentResourceManager.GetString("cbo_1.Items38"),
      (object) componentResourceManager.GetString("cbo_1.Items39"),
      (object) componentResourceManager.GetString("cbo_1.Items40"),
      (object) componentResourceManager.GetString("cbo_1.Items41"),
      (object) componentResourceManager.GetString("cbo_1.Items42"),
      (object) componentResourceManager.GetString("cbo_1.Items43"),
      (object) componentResourceManager.GetString("cbo_1.Items44"),
      (object) componentResourceManager.GetString("cbo_1.Items45"),
      (object) componentResourceManager.GetString("cbo_1.Items46"),
      (object) componentResourceManager.GetString("cbo_1.Items47"),
      (object) componentResourceManager.GetString("cbo_1.Items48"),
      (object) componentResourceManager.GetString("cbo_1.Items49"),
      (object) componentResourceManager.GetString("cbo_1.Items50"),
      (object) componentResourceManager.GetString("cbo_1.Items51"),
      (object) componentResourceManager.GetString("cbo_1.Items52"),
      (object) componentResourceManager.GetString("cbo_1.Items53"),
      (object) componentResourceManager.GetString("cbo_1.Items54"),
      (object) componentResourceManager.GetString("cbo_1.Items55"),
      (object) componentResourceManager.GetString("cbo_1.Items56"),
      (object) componentResourceManager.GetString("cbo_1.Items57"),
      (object) componentResourceManager.GetString("cbo_1.Items58"),
      (object) componentResourceManager.GetString("cbo_1.Items59")
    });
    this.cbo_1.Name = "cbo_1";
    this.cbo_1.SelectedIndexChanged += new EventHandler(this.cbo_1_SelectedIndexChanged);
    componentResourceManager.ApplyResources((object) this.label4, "label4");
    this.label4.Name = "label4";
    componentResourceManager.ApplyResources((object) this.label5, "label5");
    this.label5.Name = "label5";
    this.cbo_44.BackColor = Color.FromArgb(206, 233, 253);
    componentResourceManager.ApplyResources((object) this.cbo_44, "cbo_44");
    this.cbo_44.FormattingEnabled = true;
    this.cbo_44.Items.AddRange(new object[60]
    {
      (object) componentResourceManager.GetString("cbo_44.Items"),
      (object) componentResourceManager.GetString("cbo_44.Items1"),
      (object) componentResourceManager.GetString("cbo_44.Items2"),
      (object) componentResourceManager.GetString("cbo_44.Items3"),
      (object) componentResourceManager.GetString("cbo_44.Items4"),
      (object) componentResourceManager.GetString("cbo_44.Items5"),
      (object) componentResourceManager.GetString("cbo_44.Items6"),
      (object) componentResourceManager.GetString("cbo_44.Items7"),
      (object) componentResourceManager.GetString("cbo_44.Items8"),
      (object) componentResourceManager.GetString("cbo_44.Items9"),
      (object) componentResourceManager.GetString("cbo_44.Items10"),
      (object) componentResourceManager.GetString("cbo_44.Items11"),
      (object) componentResourceManager.GetString("cbo_44.Items12"),
      (object) componentResourceManager.GetString("cbo_44.Items13"),
      (object) componentResourceManager.GetString("cbo_44.Items14"),
      (object) componentResourceManager.GetString("cbo_44.Items15"),
      (object) componentResourceManager.GetString("cbo_44.Items16"),
      (object) componentResourceManager.GetString("cbo_44.Items17"),
      (object) componentResourceManager.GetString("cbo_44.Items18"),
      (object) componentResourceManager.GetString("cbo_44.Items19"),
      (object) componentResourceManager.GetString("cbo_44.Items20"),
      (object) componentResourceManager.GetString("cbo_44.Items21"),
      (object) componentResourceManager.GetString("cbo_44.Items22"),
      (object) componentResourceManager.GetString("cbo_44.Items23"),
      (object) componentResourceManager.GetString("cbo_44.Items24"),
      (object) componentResourceManager.GetString("cbo_44.Items25"),
      (object) componentResourceManager.GetString("cbo_44.Items26"),
      (object) componentResourceManager.GetString("cbo_44.Items27"),
      (object) componentResourceManager.GetString("cbo_44.Items28"),
      (object) componentResourceManager.GetString("cbo_44.Items29"),
      (object) componentResourceManager.GetString("cbo_44.Items30"),
      (object) componentResourceManager.GetString("cbo_44.Items31"),
      (object) componentResourceManager.GetString("cbo_44.Items32"),
      (object) componentResourceManager.GetString("cbo_44.Items33"),
      (object) componentResourceManager.GetString("cbo_44.Items34"),
      (object) componentResourceManager.GetString("cbo_44.Items35"),
      (object) componentResourceManager.GetString("cbo_44.Items36"),
      (object) componentResourceManager.GetString("cbo_44.Items37"),
      (object) componentResourceManager.GetString("cbo_44.Items38"),
      (object) componentResourceManager.GetString("cbo_44.Items39"),
      (object) componentResourceManager.GetString("cbo_44.Items40"),
      (object) componentResourceManager.GetString("cbo_44.Items41"),
      (object) componentResourceManager.GetString("cbo_44.Items42"),
      (object) componentResourceManager.GetString("cbo_44.Items43"),
      (object) componentResourceManager.GetString("cbo_44.Items44"),
      (object) componentResourceManager.GetString("cbo_44.Items45"),
      (object) componentResourceManager.GetString("cbo_44.Items46"),
      (object) componentResourceManager.GetString("cbo_44.Items47"),
      (object) componentResourceManager.GetString("cbo_44.Items48"),
      (object) componentResourceManager.GetString("cbo_44.Items49"),
      (object) componentResourceManager.GetString("cbo_44.Items50"),
      (object) componentResourceManager.GetString("cbo_44.Items51"),
      (object) componentResourceManager.GetString("cbo_44.Items52"),
      (object) componentResourceManager.GetString("cbo_44.Items53"),
      (object) componentResourceManager.GetString("cbo_44.Items54"),
      (object) componentResourceManager.GetString("cbo_44.Items55"),
      (object) componentResourceManager.GetString("cbo_44.Items56"),
      (object) componentResourceManager.GetString("cbo_44.Items57"),
      (object) componentResourceManager.GetString("cbo_44.Items58"),
      (object) componentResourceManager.GetString("cbo_44.Items59")
    });
    this.cbo_44.Name = "cbo_44";
    this.cbo_44.SelectedIndexChanged += new EventHandler(this.cbo_1_SelectedIndexChanged);
    componentResourceManager.ApplyResources((object) this.label106, "label106");
    this.label106.Name = "label106";
    componentResourceManager.ApplyResources((object) this.label107, "label107");
    this.label107.Name = "label107";
    componentResourceManager.ApplyResources((object) this, "$this");
    this.AutoScaleMode = AutoScaleMode.Font;
    this.Controls.Add((Control) this.pnelGame);
    this.Controls.Add((Control) this.pnelGameKey);
    this.Controls.Add((Control) this.pnelAutoKey);
    this.Controls.Add((Control) this.pnelAuto);
    this.Controls.Add((Control) this.pnelMain);
    this.MaximizeBox = false;
    this.Name = nameof (frmHotKeys);
    this.FormClosing += new FormClosingEventHandler(this.frmHotKeys_FormClosing);
    this.Load += new EventHandler(this.frmHotKeys_Load);
    this.Shown += new EventHandler(this.frmHotKeys_Shown);
    this.pnelAutoKey.ResumeLayout(false);
    this.pnelAutoKey.PerformLayout();
    this.pnelMain.ResumeLayout(false);
    this.pnelMain.PerformLayout();
    this.pnelAuto.ResumeLayout(false);
    this.pnelAuto.PerformLayout();
    this.pnelGame.ResumeLayout(false);
    this.pnelGame.PerformLayout();
    this.pnelGameKey.ResumeLayout(false);
    this.pnelGameKey.PerformLayout();
    this.ResumeLayout(false);
  }
}
