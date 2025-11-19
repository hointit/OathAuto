// Decompiled with JetBrains decompiler
// Type: SmartBot.Forms.frmCheDo
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace SmartBot.Forms;

public class frmCheDo : Form
{
  public AutoAccount myAccount;
  private bool numCheDoAmountKeyed;
  private bool numCheDoSaoKeyed;
  private bool numCheDoDongKeyed;
  private bool numCheDoChiSoKeyed;
  private bool numCheDoSLmuaKeyed;
  private IContainer components;
  private ComboBox cboItemCheDo;
  private Label label2;
  private Label label1;
  private ComboBox cboCheDoDTD;
  private NumericUpDown numCheDoAmount;
  private Label label13;
  private NumericUpDown numCheDoSao;
  private CheckBox cboxHuyCheDo;
  private Label label3;
  private Label label4;
  private NumericUpDown numCheDoDong;
  private CheckBox cboxIsCheDo;
  private CheckBox cboxGiu2DongTM;
  private Button btnCheDoClose;
  private Timer timer1;
  private Label label5;
  private ComboBox cboCheDoXong;
  private NumericUpDown numCheDoSLmua;
  private Label label6;
  private NumericUpDown numCheDoChiSo;
  private Label label7;
  private ComboBox cboxCheDoMap;
  private CheckBox cboxBanChoNPC;
  private CheckBox cboxHuyNLThua;
  private ComboBox cboAutoGiaHan;
  private CheckBox cboxCDExtend;

  public frmCheDo() => this.InitializeComponent();

  private void frmCheDo_Load(object sender, EventArgs e)
  {
    if (frmLogin.GAuto.Settings.Account.BangGia.Count <= 0)
      return;
    List<string> stringList = new List<string>();
    for (int index = 0; index < frmLogin.GAuto.Settings.Account.BangGia.Count; ++index)
    {
      if (frmLogin.GAuto.Settings.Account.BangGia[index].Key == "tnchedo")
        stringList.Add(frmLogin.GAuto.Settings.Account.BangGia[index].ShortDisplay);
    }
    if (stringList.Count <= 0)
      return;
    this.cboAutoGiaHan.BeginUpdate();
    this.cboAutoGiaHan.Items.Clear();
    this.cboAutoGiaHan.Items.AddRange((object[]) stringList.ToArray());
    if (frmLogin.GAuto.Settings.cboCDExtend != "" && stringList.Contains(frmLogin.GAuto.Settings.cboCDExtend))
      this.cboAutoGiaHan.SelectedItem = (object) frmLogin.GAuto.Settings.cboCDExtend;
    else
      this.cboAutoGiaHan.SelectedIndex = 0;
    this.cboAutoGiaHan.EndUpdate();
  }

  private void timer1_Tick(object sender, EventArgs e)
  {
    if (!this.Visible)
      return;
    if (this.myAccount != null)
    {
      if (!this.cboxIsCheDo.Focused && this.myAccount.Myself != null)
        this.cboxIsCheDo.Checked = this.myAccount.Myself.IsCheDo;
      if (!this.cboCheDoXong.Focused)
        this.cboCheDoXong.SelectedItem = (object) this.myAccount.Settings.cboCheDoXong;
      if (!this.cboItemCheDo.Focused)
        this.cboItemCheDo.SelectedItem = (object) this.myAccount.Settings.cboItemCheDo;
      if (!this.cboCheDoDTD.Focused)
        this.cboCheDoDTD.SelectedItem = (object) this.myAccount.Settings.cboCheDoDTD;
      if (!this.numCheDoAmount.Focused)
        this.numCheDoAmount.Value = (Decimal) this.myAccount.Settings.numCheDoAmount;
      if (!this.cboxHuyCheDo.Focused)
        this.cboxHuyCheDo.Checked = this.myAccount.Settings.cboxHuyCheDo;
      if (!this.cboxBanChoNPC.Focused)
        this.cboxBanChoNPC.Checked = this.myAccount.Settings.cboxBanChoNPC;
      if (!this.cboxHuyNLThua.Focused)
        this.cboxHuyNLThua.Checked = this.myAccount.Settings.cboxHuyNLThua;
      if (!this.numCheDoSao.Focused)
        this.numCheDoSao.Value = (Decimal) this.myAccount.Settings.numCheDoSao;
      if (!this.numCheDoDong.Focused)
        this.numCheDoDong.Value = (Decimal) this.myAccount.Settings.numCheDoDong;
      if (!this.numCheDoChiSo.Focused)
        this.numCheDoChiSo.Value = (Decimal) this.myAccount.Settings.numCheDoChiSo;
      if (!this.numCheDoSLmua.Focused)
        this.numCheDoSLmua.Value = (Decimal) this.myAccount.Settings.numCheDoSLmua;
      if (!this.cboxGiu2DongTM.Focused)
        this.cboxGiu2DongTM.Checked = this.myAccount.Settings.cboxGiu2DongTM;
      if (!this.cboxCheDoMap.Focused)
      {
        string mapName = GA.GetMapName(this.myAccount.Settings.cboCheDoMap);
        if (this.cboxCheDoMap.Text != mapName)
          this.cboxCheDoMap.Text = mapName;
      }
    }
    if (!this.cboxCDExtend.Focused)
      this.cboxCDExtend.Checked = frmLogin.GAuto.Settings.cboxCDExtend;
    if (this.cboAutoGiaHan.Focused)
      return;
    this.cboAutoGiaHan.SelectedItem = (object) frmLogin.GAuto.Settings.cboCDExtend;
  }

  private void cboxHuyCheDo_CheckedChanged(object sender, EventArgs e)
  {
    CheckBox checkBox = sender as CheckBox;
    if (this.myAccount == null || !checkBox.Focused)
      return;
    this.myAccount.Settings.cboxHuyCheDo = checkBox.Checked;
  }

  private void cboItemCheDo_SelectedIndexChanged(object sender, EventArgs e)
  {
    if (this.myAccount == null)
      return;
    ComboBox comboBox = sender as ComboBox;
    if (!comboBox.Focused)
      return;
    string str = comboBox.SelectedItem.ToString();
    if (!(str != ""))
      return;
    this.myAccount.Settings.cboItemCheDo = str;
  }

  private void cboCheDoDTD_SelectedIndexChanged(object sender, EventArgs e)
  {
    if (this.myAccount == null)
      return;
    ComboBox comboBox = sender as ComboBox;
    if (!comboBox.Focused)
      return;
    string str = comboBox.SelectedItem.ToString();
    if (!(str != ""))
      return;
    this.myAccount.Settings.cboCheDoDTD = str;
  }

  private void cboxGiu2DongTM_CheckedChanged(object sender, EventArgs e)
  {
    CheckBox checkBox = sender as CheckBox;
    if (this.myAccount == null || !checkBox.Focused)
      return;
    this.myAccount.Settings.cboxGiu2DongTM = checkBox.Checked;
  }

  private void numCheDoAmount_ValueChanged(object sender, EventArgs e)
  {
    NumericUpDown numericUpDown = sender as NumericUpDown;
    if (this.myAccount == null || !numericUpDown.Focused && !this.numCheDoAmountKeyed)
      return;
    this.myAccount.Settings.numCheDoAmount = (int) numericUpDown.Value;
    this.numCheDoAmountKeyed = false;
  }

  private void numCheDoSao_ValueChanged(object sender, EventArgs e)
  {
    NumericUpDown numericUpDown = sender as NumericUpDown;
    if (this.myAccount == null || !numericUpDown.Focused && !this.numCheDoSaoKeyed)
      return;
    this.myAccount.Settings.numCheDoSao = (int) numericUpDown.Value;
    this.numCheDoSaoKeyed = false;
  }

  private void numCheDoDong_ValueChanged(object sender, EventArgs e)
  {
    NumericUpDown numericUpDown = sender as NumericUpDown;
    if (this.myAccount == null || !numericUpDown.Focused && !this.numCheDoDongKeyed)
      return;
    this.myAccount.Settings.numCheDoDong = (int) numericUpDown.Value;
    this.numCheDoDongKeyed = false;
  }

  private void btnCheDoClose_Click(object sender, EventArgs e) => this.Hide();

  private void cboxIsCheDo_CheckedChanged(object sender, EventArgs e)
  {
    try
    {
      if (!this.cboxIsCheDo.Focused)
        return;
      frmMain.frmMainInstance.cboxIsCheDo.Invoke((Delegate) (() =>
      {
        frmMain.frmMainInstance.cboxIsCheDo.Focus();
        frmMain.frmMainInstance.cboxCheDo_CheckedChanged(sender, e);
      }));
    }
    catch (Exception ex)
    {
      GA.WriteUserLog("Crafting [1]: " + ex.Message, this.myAccount);
    }
  }

  private void frmCheDo_Shown(object sender, EventArgs e)
  {
    this.btnCheDoClose.Focus();
    this.FillInToolTip();
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
    toolTip.SetToolTip((Control) this.numCheDoAmount, frmMain.langCheDoAmount);
    toolTip.SetToolTip((Control) this.cboxIsCheDo, frmMain.langAutoCheDo);
    toolTip.SetToolTip((Control) this.numCheDoChiSo, frmMain.langCheDoFilterNumbers);
    toolTip.SetToolTip((Control) this.cboxBanChoNPC, "Lựa chọn bán cho NPC hay là hủy vật phẩm\n- Nếu không tick chọn thì auto sẽ hủy");
    toolTip.SetToolTip((Control) this.cboxHuyNLThua, "Riêng cho Tình Kiếm: Lựa chọn khi nhận NL chế đồ\nở chỗ Tiêu Phong có hủy bớt NL thừa không\n- Nếu chế Vải Bông sẽ vứt Bí Ngân, Tinh Thiết");
  }

  private void numCheDoAmount_KeyPress(object sender, KeyPressEventArgs e)
  {
    if (this.myAccount == null)
      return;
    this.numCheDoAmountKeyed = true;
  }

  private void numCheDoSao_KeyPress(object sender, KeyPressEventArgs e)
  {
    if (this.myAccount == null)
      return;
    this.numCheDoSaoKeyed = true;
  }

  private void numCheDoDong_KeyPress(object sender, KeyPressEventArgs e)
  {
    if (this.myAccount == null)
      return;
    this.numCheDoDongKeyed = true;
  }

  private void cboCheDoXong_SelectedIndexChanged(object sender, EventArgs e)
  {
    if (this.myAccount == null)
      return;
    ComboBox comboBox = sender as ComboBox;
    if (!comboBox.Focused)
      return;
    string str = comboBox.SelectedItem.ToString();
    if (!(str != ""))
      return;
    this.myAccount.Settings.cboCheDoXong = str;
  }

  private void numCheDoChiSo_ValueChanged(object sender, EventArgs e)
  {
    NumericUpDown numericUpDown = sender as NumericUpDown;
    if (this.myAccount == null || !numericUpDown.Focused && !this.numCheDoChiSoKeyed)
      return;
    this.myAccount.Settings.numCheDoChiSo = (int) numericUpDown.Value;
    this.numCheDoChiSoKeyed = false;
  }

  private void numCheDoSLmua_ValueChanged(object sender, EventArgs e)
  {
    NumericUpDown numericUpDown = sender as NumericUpDown;
    if (this.myAccount == null || !numericUpDown.Focused && !this.numCheDoSLmuaKeyed)
      return;
    this.myAccount.Settings.numCheDoSLmua = (int) numericUpDown.Value;
    this.numCheDoSLmuaKeyed = false;
  }

  private void numCheDoSLmua_KeyPress(object sender, KeyPressEventArgs e)
  {
    if (this.myAccount == null)
      return;
    this.numCheDoSLmuaKeyed = true;
  }

  private void numCheDoChiSo_KeyPress(object sender, KeyPressEventArgs e)
  {
    if (this.myAccount == null)
      return;
    this.numCheDoChiSoKeyed = true;
  }

  private void cboxCheDoMap_SelectedIndexChanged(object sender, EventArgs e)
  {
    if (this.myAccount == null)
      return;
    ComboBox comboBox = sender as ComboBox;
    if (!(comboBox.Text != "") || !comboBox.Focused)
      return;
    int mapIdMini = GA.GetMapIDMini(comboBox.Text);
    if (mapIdMini < 0 || frmLogin.GAuto.CurrentAuto == null)
      return;
    frmLogin.GAuto.CurrentAuto.Settings.cboCheDoMap = mapIdMini;
  }

  private void frmCheDo_FormClosing(object sender, FormClosingEventArgs e)
  {
    e.Cancel = true;
    this.Hide();
  }

  private void cboxBanChoNPC_CheckedChanged(object sender, EventArgs e)
  {
    CheckBox checkBox = sender as CheckBox;
    if (this.myAccount == null || !checkBox.Focused)
      return;
    this.myAccount.Settings.cboxBanChoNPC = checkBox.Checked;
  }

  private void cboxHuyNLThua_CheckedChanged(object sender, EventArgs e)
  {
    CheckBox checkBox = sender as CheckBox;
    if (this.myAccount == null || !checkBox.Focused)
      return;
    this.myAccount.Settings.cboxHuyNLThua = checkBox.Checked;
  }

  private void cboxAutoGiaHan_CheckedChanged(object sender, EventArgs e)
  {
    CheckBox checkBox = sender as CheckBox;
    if (!checkBox.Focused)
      return;
    frmLogin.GAuto.Settings.cboxCDExtend = checkBox.Checked;
  }

  private void cboAutoGiaHan_SelectedIndexChanged(object sender, EventArgs e)
  {
    ComboBox comboBox = sender as ComboBox;
    if (!(comboBox.Text != "") || !comboBox.Focused)
      return;
    frmLogin.GAuto.Settings.cboCDExtend = comboBox.SelectedItem.ToString();
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
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmCheDo));
    this.cboItemCheDo = new ComboBox();
    this.label2 = new Label();
    this.label1 = new Label();
    this.cboCheDoDTD = new ComboBox();
    this.numCheDoAmount = new NumericUpDown();
    this.label13 = new Label();
    this.numCheDoSao = new NumericUpDown();
    this.cboxHuyCheDo = new CheckBox();
    this.label3 = new Label();
    this.label4 = new Label();
    this.numCheDoDong = new NumericUpDown();
    this.cboxIsCheDo = new CheckBox();
    this.cboxGiu2DongTM = new CheckBox();
    this.btnCheDoClose = new Button();
    this.timer1 = new Timer(this.components);
    this.label5 = new Label();
    this.cboCheDoXong = new ComboBox();
    this.numCheDoSLmua = new NumericUpDown();
    this.label6 = new Label();
    this.numCheDoChiSo = new NumericUpDown();
    this.label7 = new Label();
    this.cboxCheDoMap = new ComboBox();
    this.cboxBanChoNPC = new CheckBox();
    this.cboxHuyNLThua = new CheckBox();
    this.cboAutoGiaHan = new ComboBox();
    this.cboxCDExtend = new CheckBox();
    this.numCheDoAmount.BeginInit();
    this.numCheDoSao.BeginInit();
    this.numCheDoDong.BeginInit();
    this.numCheDoSLmua.BeginInit();
    this.numCheDoChiSo.BeginInit();
    this.SuspendLayout();
    this.cboItemCheDo.BackColor = Color.FromArgb(206, 233, 253);
    componentResourceManager.ApplyResources((object) this.cboItemCheDo, "cboItemCheDo");
    this.cboItemCheDo.FormattingEnabled = true;
    this.cboItemCheDo.Items.AddRange(new object[16 /*0x10*/]
    {
      (object) componentResourceManager.GetString("cboItemCheDo.Items"),
      (object) componentResourceManager.GetString("cboItemCheDo.Items1"),
      (object) componentResourceManager.GetString("cboItemCheDo.Items2"),
      (object) componentResourceManager.GetString("cboItemCheDo.Items3"),
      (object) componentResourceManager.GetString("cboItemCheDo.Items4"),
      (object) componentResourceManager.GetString("cboItemCheDo.Items5"),
      (object) componentResourceManager.GetString("cboItemCheDo.Items6"),
      (object) componentResourceManager.GetString("cboItemCheDo.Items7"),
      (object) componentResourceManager.GetString("cboItemCheDo.Items8"),
      (object) componentResourceManager.GetString("cboItemCheDo.Items9"),
      (object) componentResourceManager.GetString("cboItemCheDo.Items10"),
      (object) componentResourceManager.GetString("cboItemCheDo.Items11"),
      (object) componentResourceManager.GetString("cboItemCheDo.Items12"),
      (object) componentResourceManager.GetString("cboItemCheDo.Items13"),
      (object) componentResourceManager.GetString("cboItemCheDo.Items14"),
      (object) componentResourceManager.GetString("cboItemCheDo.Items15")
    });
    this.cboItemCheDo.Name = "cboItemCheDo";
    this.cboItemCheDo.SelectedIndexChanged += new EventHandler(this.cboItemCheDo_SelectedIndexChanged);
    componentResourceManager.ApplyResources((object) this.label2, "label2");
    this.label2.Name = "label2";
    componentResourceManager.ApplyResources((object) this.label1, "label1");
    this.label1.Name = "label1";
    this.cboCheDoDTD.BackColor = Color.FromArgb(206, 233, 253);
    componentResourceManager.ApplyResources((object) this.cboCheDoDTD, "cboCheDoDTD");
    this.cboCheDoDTD.FormattingEnabled = true;
    this.cboCheDoDTD.Items.AddRange(new object[8]
    {
      (object) componentResourceManager.GetString("cboCheDoDTD.Items"),
      (object) componentResourceManager.GetString("cboCheDoDTD.Items1"),
      (object) componentResourceManager.GetString("cboCheDoDTD.Items2"),
      (object) componentResourceManager.GetString("cboCheDoDTD.Items3"),
      (object) componentResourceManager.GetString("cboCheDoDTD.Items4"),
      (object) componentResourceManager.GetString("cboCheDoDTD.Items5"),
      (object) componentResourceManager.GetString("cboCheDoDTD.Items6"),
      (object) componentResourceManager.GetString("cboCheDoDTD.Items7")
    });
    this.cboCheDoDTD.Name = "cboCheDoDTD";
    this.cboCheDoDTD.SelectedIndexChanged += new EventHandler(this.cboCheDoDTD_SelectedIndexChanged);
    this.numCheDoAmount.BackColor = Color.FromArgb(206, 233, 253);
    componentResourceManager.ApplyResources((object) this.numCheDoAmount, "numCheDoAmount");
    this.numCheDoAmount.Maximum = new Decimal(new int[4]
    {
      99999,
      0,
      0,
      0
    });
    this.numCheDoAmount.Name = "numCheDoAmount";
    this.numCheDoAmount.Value = new Decimal(new int[4]
    {
      200,
      0,
      0,
      0
    });
    this.numCheDoAmount.ValueChanged += new EventHandler(this.numCheDoAmount_ValueChanged);
    this.numCheDoAmount.KeyPress += new KeyPressEventHandler(this.numCheDoAmount_KeyPress);
    componentResourceManager.ApplyResources((object) this.label13, "label13");
    this.label13.Name = "label13";
    this.numCheDoSao.BackColor = Color.FromArgb(206, 233, 253);
    componentResourceManager.ApplyResources((object) this.numCheDoSao, "numCheDoSao");
    this.numCheDoSao.Maximum = new Decimal(new int[4]
    {
      20,
      0,
      0,
      0
    });
    this.numCheDoSao.Minimum = new Decimal(new int[4]
    {
      1,
      0,
      0,
      0
    });
    this.numCheDoSao.Name = "numCheDoSao";
    this.numCheDoSao.Value = new Decimal(new int[4]
    {
      8,
      0,
      0,
      0
    });
    this.numCheDoSao.ValueChanged += new EventHandler(this.numCheDoSao_ValueChanged);
    this.numCheDoSao.KeyPress += new KeyPressEventHandler(this.numCheDoSao_KeyPress);
    componentResourceManager.ApplyResources((object) this.cboxHuyCheDo, "cboxHuyCheDo");
    this.cboxHuyCheDo.ForeColor = Color.Black;
    this.cboxHuyCheDo.Name = "cboxHuyCheDo";
    this.cboxHuyCheDo.UseVisualStyleBackColor = true;
    this.cboxHuyCheDo.CheckedChanged += new EventHandler(this.cboxHuyCheDo_CheckedChanged);
    componentResourceManager.ApplyResources((object) this.label3, "label3");
    this.label3.Name = "label3";
    componentResourceManager.ApplyResources((object) this.label4, "label4");
    this.label4.Name = "label4";
    this.numCheDoDong.BackColor = Color.FromArgb(206, 233, 253);
    componentResourceManager.ApplyResources((object) this.numCheDoDong, "numCheDoDong");
    this.numCheDoDong.Maximum = new Decimal(new int[4]
    {
      50,
      0,
      0,
      0
    });
    this.numCheDoDong.Minimum = new Decimal(new int[4]
    {
      1,
      0,
      0,
      0
    });
    this.numCheDoDong.Name = "numCheDoDong";
    this.numCheDoDong.Value = new Decimal(new int[4]
    {
      5,
      0,
      0,
      0
    });
    this.numCheDoDong.ValueChanged += new EventHandler(this.numCheDoDong_ValueChanged);
    this.numCheDoDong.KeyPress += new KeyPressEventHandler(this.numCheDoDong_KeyPress);
    componentResourceManager.ApplyResources((object) this.cboxIsCheDo, "cboxIsCheDo");
    this.cboxIsCheDo.Name = "cboxIsCheDo";
    this.cboxIsCheDo.UseVisualStyleBackColor = true;
    this.cboxIsCheDo.CheckedChanged += new EventHandler(this.cboxIsCheDo_CheckedChanged);
    componentResourceManager.ApplyResources((object) this.cboxGiu2DongTM, "cboxGiu2DongTM");
    this.cboxGiu2DongTM.ForeColor = Color.Black;
    this.cboxGiu2DongTM.Name = "cboxGiu2DongTM";
    this.cboxGiu2DongTM.UseVisualStyleBackColor = true;
    this.cboxGiu2DongTM.CheckedChanged += new EventHandler(this.cboxGiu2DongTM_CheckedChanged);
    this.btnCheDoClose.BackColor = Color.FromArgb(247, 207, 142);
    this.btnCheDoClose.ForeColor = Color.Black;
    componentResourceManager.ApplyResources((object) this.btnCheDoClose, "btnCheDoClose");
    this.btnCheDoClose.Name = "btnCheDoClose";
    this.btnCheDoClose.UseVisualStyleBackColor = false;
    this.btnCheDoClose.Click += new EventHandler(this.btnCheDoClose_Click);
    this.timer1.Enabled = true;
    this.timer1.Interval = 400;
    this.timer1.Tick += new EventHandler(this.timer1_Tick);
    componentResourceManager.ApplyResources((object) this.label5, "label5");
    this.label5.Name = "label5";
    this.cboCheDoXong.BackColor = Color.FromArgb(206, 233, 253);
    componentResourceManager.ApplyResources((object) this.cboCheDoXong, "cboCheDoXong");
    this.cboCheDoXong.FormattingEnabled = true;
    this.cboCheDoXong.Items.AddRange(new object[4]
    {
      (object) componentResourceManager.GetString("cboCheDoXong.Items"),
      (object) componentResourceManager.GetString("cboCheDoXong.Items1"),
      (object) componentResourceManager.GetString("cboCheDoXong.Items2"),
      (object) componentResourceManager.GetString("cboCheDoXong.Items3")
    });
    this.cboCheDoXong.Name = "cboCheDoXong";
    this.cboCheDoXong.SelectedIndexChanged += new EventHandler(this.cboCheDoXong_SelectedIndexChanged);
    this.numCheDoSLmua.BackColor = Color.FromArgb(206, 233, 253);
    componentResourceManager.ApplyResources((object) this.numCheDoSLmua, "numCheDoSLmua");
    this.numCheDoSLmua.Maximum = new Decimal(new int[4]
    {
      5000,
      0,
      0,
      0
    });
    this.numCheDoSLmua.Minimum = new Decimal(new int[4]
    {
      11,
      0,
      0,
      0
    });
    this.numCheDoSLmua.Name = "numCheDoSLmua";
    this.numCheDoSLmua.Value = new Decimal(new int[4]
    {
      30,
      0,
      0,
      0
    });
    this.numCheDoSLmua.ValueChanged += new EventHandler(this.numCheDoSLmua_ValueChanged);
    this.numCheDoSLmua.KeyPress += new KeyPressEventHandler(this.numCheDoSLmua_KeyPress);
    componentResourceManager.ApplyResources((object) this.label6, "label6");
    this.label6.Name = "label6";
    this.numCheDoChiSo.BackColor = Color.FromArgb(206, 233, 253);
    componentResourceManager.ApplyResources((object) this.numCheDoChiSo, "numCheDoChiSo");
    this.numCheDoChiSo.Maximum = new Decimal(new int[4]
    {
      200,
      0,
      0,
      0
    });
    this.numCheDoChiSo.Name = "numCheDoChiSo";
    this.numCheDoChiSo.Value = new Decimal(new int[4]
    {
      90,
      0,
      0,
      0
    });
    this.numCheDoChiSo.ValueChanged += new EventHandler(this.numCheDoChiSo_ValueChanged);
    this.numCheDoChiSo.KeyPress += new KeyPressEventHandler(this.numCheDoChiSo_KeyPress);
    componentResourceManager.ApplyResources((object) this.label7, "label7");
    this.label7.Name = "label7";
    this.cboxCheDoMap.BackColor = Color.FromArgb(206, 233, 253);
    componentResourceManager.ApplyResources((object) this.cboxCheDoMap, "cboxCheDoMap");
    this.cboxCheDoMap.FormattingEnabled = true;
    this.cboxCheDoMap.Items.AddRange(new object[4]
    {
      (object) componentResourceManager.GetString("cboxCheDoMap.Items"),
      (object) componentResourceManager.GetString("cboxCheDoMap.Items1"),
      (object) componentResourceManager.GetString("cboxCheDoMap.Items2"),
      (object) componentResourceManager.GetString("cboxCheDoMap.Items3")
    });
    this.cboxCheDoMap.Name = "cboxCheDoMap";
    this.cboxCheDoMap.SelectedIndexChanged += new EventHandler(this.cboxCheDoMap_SelectedIndexChanged);
    componentResourceManager.ApplyResources((object) this.cboxBanChoNPC, "cboxBanChoNPC");
    this.cboxBanChoNPC.ForeColor = Color.Black;
    this.cboxBanChoNPC.Name = "cboxBanChoNPC";
    this.cboxBanChoNPC.UseVisualStyleBackColor = true;
    this.cboxBanChoNPC.CheckedChanged += new EventHandler(this.cboxBanChoNPC_CheckedChanged);
    componentResourceManager.ApplyResources((object) this.cboxHuyNLThua, "cboxHuyNLThua");
    this.cboxHuyNLThua.ForeColor = Color.Black;
    this.cboxHuyNLThua.Name = "cboxHuyNLThua";
    this.cboxHuyNLThua.UseVisualStyleBackColor = true;
    this.cboxHuyNLThua.CheckedChanged += new EventHandler(this.cboxHuyNLThua_CheckedChanged);
    this.cboAutoGiaHan.BackColor = Color.FromArgb(206, 233, 253);
    componentResourceManager.ApplyResources((object) this.cboAutoGiaHan, "cboAutoGiaHan");
    this.cboAutoGiaHan.FormattingEnabled = true;
    this.cboAutoGiaHan.Items.AddRange(new object[3]
    {
      (object) componentResourceManager.GetString("cboAutoGiaHan.Items"),
      (object) componentResourceManager.GetString("cboAutoGiaHan.Items1"),
      (object) componentResourceManager.GetString("cboAutoGiaHan.Items2")
    });
    this.cboAutoGiaHan.Name = "cboAutoGiaHan";
    this.cboAutoGiaHan.SelectedIndexChanged += new EventHandler(this.cboAutoGiaHan_SelectedIndexChanged);
    componentResourceManager.ApplyResources((object) this.cboxCDExtend, "cboxCDExtend");
    this.cboxCDExtend.Name = "cboxCDExtend";
    this.cboxCDExtend.UseVisualStyleBackColor = true;
    this.cboxCDExtend.CheckedChanged += new EventHandler(this.cboxAutoGiaHan_CheckedChanged);
    componentResourceManager.ApplyResources((object) this, "$this");
    this.AutoScaleMode = AutoScaleMode.Font;
    this.Controls.Add((Control) this.cboAutoGiaHan);
    this.Controls.Add((Control) this.cboxCDExtend);
    this.Controls.Add((Control) this.cboxHuyNLThua);
    this.Controls.Add((Control) this.cboxBanChoNPC);
    this.Controls.Add((Control) this.cboxCheDoMap);
    this.Controls.Add((Control) this.label7);
    this.Controls.Add((Control) this.numCheDoChiSo);
    this.Controls.Add((Control) this.numCheDoSLmua);
    this.Controls.Add((Control) this.label6);
    this.Controls.Add((Control) this.label5);
    this.Controls.Add((Control) this.cboCheDoXong);
    this.Controls.Add((Control) this.btnCheDoClose);
    this.Controls.Add((Control) this.cboxGiu2DongTM);
    this.Controls.Add((Control) this.cboxIsCheDo);
    this.Controls.Add((Control) this.label4);
    this.Controls.Add((Control) this.numCheDoDong);
    this.Controls.Add((Control) this.label3);
    this.Controls.Add((Control) this.numCheDoSao);
    this.Controls.Add((Control) this.cboxHuyCheDo);
    this.Controls.Add((Control) this.numCheDoAmount);
    this.Controls.Add((Control) this.label13);
    this.Controls.Add((Control) this.label1);
    this.Controls.Add((Control) this.cboCheDoDTD);
    this.Controls.Add((Control) this.label2);
    this.Controls.Add((Control) this.cboItemCheDo);
    this.FormBorderStyle = FormBorderStyle.FixedSingle;
    this.MaximizeBox = false;
    this.Name = nameof (frmCheDo);
    this.ShowIcon = false;
    this.FormClosing += new FormClosingEventHandler(this.frmCheDo_FormClosing);
    this.Load += new EventHandler(this.frmCheDo_Load);
    this.Shown += new EventHandler(this.frmCheDo_Shown);
    this.numCheDoAmount.EndInit();
    this.numCheDoSao.EndInit();
    this.numCheDoDong.EndInit();
    this.numCheDoSLmua.EndInit();
    this.numCheDoChiSo.EndInit();
    this.ResumeLayout(false);
    this.PerformLayout();
  }
}
