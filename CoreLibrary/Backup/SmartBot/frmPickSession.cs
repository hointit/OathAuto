// Decompiled with JetBrains decompiler
// Type: SmartBot.frmPickSession
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using BrightIdeasSoftware;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace SmartBot;

public class frmPickSession : Form
{
  public List<SessionPick> propSessions = new List<SessionPick>();
  public bool flagAutoClose;
  private IContainer components;
  private Panel pnelTop;
  private Label label1;
  private Panel pnelMid;
  private ObjectListView lvSessions;
  private OLVColumn col_ID;
  private OLVColumn col_HWID;
  private OLVColumn col_LastSeen;
  private OLVColumn col_Exp;
  private OLVColumn col_Tinhnang;
  private Panel pnelBottom;
  private Button btnNewSession;
  private Button btnThoatAuto;
  private Button btnChonPhien;
  private Label lbHWID;
  private BackgroundWorker backgroundWorker1;
  private ComboBox cboPrice;
  private Label lbUsername;
  private Label lbTotalGG;

  public bool ProcessData(Dictionary<string, object>[] _data)
  {
    bool flag = false;
    if (_data != null)
    {
      if (_data.Length > 0)
      {
        try
        {
          int num = 1;
          for (int index = 0; index < _data.Length; ++index)
          {
            Dictionary<string, object> session = _data[index];
            SessionPick sessionPick = new SessionPick();
            sessionPick.autoid = session["autoid"].ToString();
            sessionPick.col_ID = num;
            string str1 = session["hwid"].ToString();
            sessionPick.col_HWID = str1.Substring(str1.Length - 7);
            string str2 = session["last_seen"].ToString();
            sessionPick.logout = session["logout"].ToString();
            if (sessionPick.logout == "0")
              str2 += " (Bận)";
            sessionPick.col_LastSeen = str2;
            sessionPick.col_Exp = session["expire"].ToString();
            try
            {
              string tn = "";
              sessionPick.LastPriceItem.Clear();
              PriceItem _lastPrice1 = (PriceItem) null;
              frmPickSession.CountTinhNang(session, ref tn, "tnchedo", ref _lastPrice1);
              if (_lastPrice1 != null)
                sessionPick.LastPriceItem.Add(_lastPrice1);
              PriceItem _lastPrice2 = (PriceItem) null;
              frmPickSession.CountTinhNang(session, ref tn, "tnyto", ref _lastPrice2);
              if (_lastPrice2 != null)
                sessionPick.LastPriceItem.Add(_lastPrice2);
              PriceItem _lastPrice3 = (PriceItem) null;
              frmPickSession.CountTinhNang(session, ref tn, "tntrader", ref _lastPrice3);
              if (_lastPrice3 != null)
                sessionPick.LastPriceItem.Add(_lastPrice3);
              PriceItem _lastPrice4 = (PriceItem) null;
              frmPickSession.CountTinhNang(session, ref tn, "tnq12", ref _lastPrice4);
              if (_lastPrice4 != null)
                sessionPick.LastPriceItem.Add(_lastPrice4);
              tn = tn.Trim(',');
              tn = tn.Replace(",", ", ");
              sessionPick.col_Tinhnang = tn;
            }
            catch (Exception ex)
            {
            }
            this.propSessions.Add(sessionPick);
            ++num;
          }
          flag = true;
        }
        catch (Exception ex)
        {
          flag = false;
        }
      }
    }
    if (flag)
      this.PopulateList();
    return flag;
  }

  private static void CountTinhNang(
    Dictionary<string, object> session,
    ref string tn,
    string myKey,
    ref PriceItem _lastPrice)
  {
    object obj1 = (object) null;
    if (!session.ContainsKey(myKey))
      return;
    int result1 = 0;
    Dictionary<string, object> dictionary1 = JsonConvert.DeserializeObject<Dictionary<string, object>>(session[myKey].ToString());
    dictionary1.TryGetValue("count", out obj1);
    if (obj1 != null)
      int.TryParse(obj1.ToString(), out result1);
    if (result1 <= 0)
      return;
    string str = GA.TranslateTNKey(myKey);
    tn = $"{tn}{$"{result1.ToString()} gói {str}"},";
    List<Dictionary<string, object>> dictionaryList = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(dictionary1["data"].ToString());
    if (dictionaryList.Count <= 0)
      return;
    int num = 999;
    foreach (Dictionary<string, object> dictionary2 in dictionaryList)
    {
      int result2 = 999;
      object obj2 = (object) null;
      dictionary2.TryGetValue("count", out obj2);
      if (obj2 != null)
        int.TryParse(obj2.ToString(), out result2);
      if (result2 > 0 && result2 < num)
      {
        num = result2;
        if (_lastPrice == null)
          _lastPrice = new PriceItem();
        _lastPrice.Key = myKey;
        _lastPrice.Slot = result2;
        _lastPrice.SlotUnit = dictionary2["countunit"].ToString();
        int.TryParse(dictionary2["slot"].ToString(), out _lastPrice.SlotCount);
        _lastPrice.SlotCountUnit = dictionary2["slotunit"].ToString();
      }
    }
  }

  private void PopulateList() => this.lvSessions.SetObjects((IEnumerable) this.propSessions);

  public frmPickSession() => this.InitializeComponent();

  private void frmPickSession_Load(object sender, EventArgs e)
  {
  }

  private void FillCombo()
  {
    if (frmLogin.GAuto.Settings.Account.BangGia.Count <= 0)
      return;
    List<string> stringList = new List<string>();
    foreach (PriceItem priceItem in frmLogin.GAuto.Settings.Account.BangGia)
    {
      if (priceItem.Key == "time")
        stringList.Add($"{priceItem.Price} GG | {priceItem.Desc}");
    }
    if (stringList.Count <= 0)
      return;
    this.cboPrice.BeginUpdate();
    this.cboPrice.Items.Clear();
    this.cboPrice.Items.AddRange((object[]) stringList.ToArray());
    this.cboPrice.EndUpdate();
    this.cboPrice.SelectedIndex = 0;
  }

  private void btnNewSession_Click(object sender, EventArgs e)
  {
    if (frmLogin.GAuto.Settings.Account.TotalBalance > 3.3)
    {
      Dictionary<string, object> dictionary1 = new Dictionary<string, object>();
      Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
      List<Dictionary<string, object>> inputArr = new List<Dictionary<string, object>>();
      if (frmLogin.GAuto.Settings.Account.BangGia.Count > 0)
      {
        PriceItem price = (PriceItem) null;
        string text = this.cboPrice.Text;
        for (int index = 0; index < frmLogin.GAuto.Settings.Account.BangGia.Count; ++index)
        {
          if (text == $"{frmLogin.GAuto.Settings.Account.BangGia[index].PriceDisplay} {frmLogin.GGUnit} | {frmLogin.GAuto.Settings.Account.BangGia[index].Desc}")
          {
            price = frmLogin.GAuto.Settings.Account.BangGia[index];
            break;
          }
        }
        if (price != null && frmLogin.GAuto.Settings.Account.TotalBalance > price.Price)
          GA.SetRequestTN(inputArr, price, "time");
        else if (price == null)
          GA.ShowMessage("Không tìm thấy gói giá hợp lý.\nVui lòng báo admin", "Không thấy giá");
        else
          GA.ShowMessage("Bạn không đủ tiền để mua gói giá này.\nNạp thêm tiền vào tài khoản.", "Không đủ tiền", 30000);
      }
      if (inputArr.Count > 0)
      {
        dictionary2.Add("request", (object) inputArr);
        dictionary2.Add("count", (object) "1");
        dictionary1.Add("reqtime", (object) dictionary2);
      }
      if (dictionary1.Count <= 0)
        return;
      this.btnChonPhien.Enabled = false;
      this.btnNewSession.Enabled = false;
      long num = frmLogin.GlobalTimer.ElapsedMilliseconds + 5000L;
      while (frmLogin.GlobalTimer.ElapsedMilliseconds <= num)
      {
        if (!this.backgroundWorker1.IsBusy)
        {
          this.backgroundWorker1.RunWorkerAsync((object) dictionary1);
          break;
        }
        Thread.Sleep(100);
      }
    }
    else
      GA.ShowMessage("Tài khoản đã hết tiền nên không thể đăng nhập ở nhiều máy.\nNạp thêm tiền để ủng hộ auto và đăng nhập ở nhiều máy cùng lúc.", "Tài khoản không đủ tiền", 30000);
  }

  private void btnChonPhien_Click(object sender, EventArgs e)
  {
    this.DoPickSession((SessionPick) this.lvSessions.SelectedObject);
  }

  private void DoPickSession(SessionPick pick)
  {
    if (pick == null)
      return;
    bool flag = true;
    if (pick.logout == "0" && MessageBox.Show($"Bạn sẽ chiếm phiên làm việc số {pick.col_ID}. Auto bên máy kia sẽ bị đóng.\nBạn có đồng ý không?", "Lấy phiên", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
      flag = false;
    if (!flag)
      return;
    if (frmLogin.frmBuyLicense == null)
      frmLogin.frmBuyLicense = new frmLiteBuy();
    frmLogin.frmBuyLicense.lastPrices = pick.LastPriceItem;
    long num = frmLogin.GlobalTimer.ElapsedMilliseconds + 10000L;
    this.btnChonPhien.Enabled = false;
    this.btnNewSession.Enabled = false;
    while (frmLogin.GlobalTimer.ElapsedMilliseconds <= num)
    {
      if (!this.backgroundWorker1.IsBusy)
      {
        this.backgroundWorker1.RunWorkerAsync((object) new LoginParams()
        {
          Username = frmLogin.GAuto.Settings.Account.Username,
          Password = frmLogin.GAuto.Settings.Account.Password,
          ShowForm = true,
          Action = "picksession",
          RequestID = pick.autoid
        });
        break;
      }
      Thread.Sleep(100);
    }
  }

  private void frmPickSession_Shown(object sender, EventArgs e)
  {
    if (frmLogin.HWID == string.Empty)
      frmLogin.HWID = new GA.HWID().Value;
    string hwid = frmLogin.HWID;
    this.lbHWID.Text = "Mã máy : " + hwid.Substring(hwid.Length - 7);
    this.lbUsername.Text = "Tài khoản: " + frmLogin.GAuto.Settings.Account.Username;
    string str1 = (frmLogin.GAuto.Settings.Account.RemainGGoldBalance / frmLogin.GGUnitDivision).ToString("0.0");
    if (str1.Contains(".0"))
      str1 = (frmLogin.GAuto.Settings.Account.RemainGGoldBalance / frmLogin.GGUnitDivision).ToString("0");
    string str2 = (frmLogin.GAuto.Settings.Account.RemainGGoldPromo / frmLogin.GGUnitDivision).ToString("0.0");
    if (str2.Contains(".0"))
      str2 = (frmLogin.GAuto.Settings.Account.RemainGGoldPromo / frmLogin.GGUnitDivision).ToString("0");
    string str3 = ((frmLogin.GAuto.Settings.Account.RemainGGoldBalance + frmLogin.GAuto.Settings.Account.RemainGGoldPromo) / frmLogin.GGUnitDivision).ToString("0.0");
    if (str3.Contains(".0"))
      str3 = ((frmLogin.GAuto.Settings.Account.RemainGGoldBalance + frmLogin.GAuto.Settings.Account.RemainGGoldPromo) / frmLogin.GGUnitDivision).ToString("0");
    this.lbTotalGG.Text = $"GG còn: {str1} + {str2} = {str3}";
    this.FillCombo();
  }

  private void btnThoatAuto_Click(object sender, EventArgs e) => this.CheckExitAuto();

  private void CheckExitAuto()
  {
    if (MessageBox.Show("Bạn có muốn thoát auto không?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
      return;
    GA.ExitAndCleanup();
  }

  private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
  {
    LoginResult result = (LoginResult) e.Result;
    this.btnChonPhien.Enabled = true;
    this.btnNewSession.Enabled = true;
    if (result.LoginCode != 1)
      return;
    frmLogin.CheckStartAuto();
    this.flagAutoClose = true;
    this.Close();
  }

  private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
  {
    if (e.Argument != null && e.Argument.GetType() == typeof (LoginParams))
    {
      LoginResult loginResult = GA.SecureLoginPHPv2((LoginParams) e.Argument);
      e.Result = (object) loginResult;
    }
    if (e.Argument == null || e.Argument.GetType() != typeof (Dictionary<string, object>))
      return;
    LoginResult loginResult1 = GA.SecureLoginPHPv2(new LoginParams()
    {
      Username = frmLogin.GAuto.Settings.Account.Username,
      Password = frmLogin.GAuto.Settings.Account.Password,
      ShowForm = true,
      Action = "picksession",
      RequestID = GA.GenerateRandomName(18)
    }, (Dictionary<string, object>) e.Argument);
    e.Result = (object) loginResult1;
  }

  private void cboPrice_SelectedIndexChanged(object sender, EventArgs e)
  {
  }

  private void lbUsername_Click(object sender, EventArgs e)
  {
  }

  private void frmPickSession_FormClosed(object sender, FormClosedEventArgs e)
  {
  }

  private void frmPickSession_FormClosing(object sender, FormClosingEventArgs e)
  {
    if (this.flagAutoClose)
      return;
    this.CheckExitAuto();
    e.Cancel = true;
  }

  private void lvSessions_DoubleClick(object sender, EventArgs e)
  {
  }

  private void lvSessions_CellClick(object sender, CellClickEventArgs e)
  {
  }

  private void lvSessions_ItemActivate(object sender, EventArgs e)
  {
    try
    {
      ObjectListView objectListView = sender as ObjectListView;
      if (objectListView.SelectedObject == null)
        return;
      this.DoPickSession((SessionPick) objectListView.SelectedObject);
    }
    catch (Exception ex)
    {
    }
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.components != null)
      this.components.Dispose();
    base.Dispose(disposing);
  }

  private void InitializeComponent()
  {
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmPickSession));
    this.pnelTop = new Panel();
    this.label1 = new Label();
    this.pnelMid = new Panel();
    this.lvSessions = new ObjectListView();
    this.col_ID = new OLVColumn();
    this.col_HWID = new OLVColumn();
    this.col_LastSeen = new OLVColumn();
    this.col_Exp = new OLVColumn();
    this.col_Tinhnang = new OLVColumn();
    this.pnelBottom = new Panel();
    this.lbTotalGG = new Label();
    this.lbUsername = new Label();
    this.cboPrice = new ComboBox();
    this.lbHWID = new Label();
    this.btnNewSession = new Button();
    this.btnThoatAuto = new Button();
    this.btnChonPhien = new Button();
    this.backgroundWorker1 = new BackgroundWorker();
    this.pnelTop.SuspendLayout();
    this.pnelMid.SuspendLayout();
    ((ISupportInitialize) this.lvSessions).BeginInit();
    this.pnelBottom.SuspendLayout();
    this.SuspendLayout();
    this.pnelTop.Controls.Add((Control) this.label1);
    this.pnelTop.Dock = DockStyle.Top;
    this.pnelTop.Location = new Point(0, 0);
    this.pnelTop.Margin = new Padding(2);
    this.pnelTop.Name = "pnelTop";
    this.pnelTop.Size = new Size(580, 52);
    this.pnelTop.TabIndex = 13;
    this.label1.Dock = DockStyle.Top;
    this.label1.Location = new Point(0, 0);
    this.label1.Margin = new Padding(2, 0, 2, 0);
    this.label1.Name = "label1";
    this.label1.Padding = new Padding(2, 3, 0, 0);
    this.label1.Size = new Size(580, 42);
    this.label1.TabIndex = 2;
    this.label1.Text = componentResourceManager.GetString("label1.Text");
    this.pnelMid.Controls.Add((Control) this.lvSessions);
    this.pnelMid.Dock = DockStyle.Fill;
    this.pnelMid.Location = new Point(0, 52);
    this.pnelMid.Margin = new Padding(2);
    this.pnelMid.Name = "pnelMid";
    this.pnelMid.Size = new Size(580, 109);
    this.pnelMid.TabIndex = 14;
    this.lvSessions.AllColumns.Add(this.col_ID);
    this.lvSessions.AllColumns.Add(this.col_HWID);
    this.lvSessions.AllColumns.Add(this.col_LastSeen);
    this.lvSessions.AllColumns.Add(this.col_Exp);
    this.lvSessions.AllColumns.Add(this.col_Tinhnang);
    this.lvSessions.AlternateRowBackColor = Color.FromArgb(224 /*0xE0*/, 224 /*0xE0*/, 224 /*0xE0*/);
    this.lvSessions.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
    this.lvSessions.CellEditUseWholeCell = false;
    this.lvSessions.Columns.AddRange(new ColumnHeader[5]
    {
      (ColumnHeader) this.col_ID,
      (ColumnHeader) this.col_HWID,
      (ColumnHeader) this.col_LastSeen,
      (ColumnHeader) this.col_Exp,
      (ColumnHeader) this.col_Tinhnang
    });
    this.lvSessions.Cursor = Cursors.Default;
    this.lvSessions.Dock = DockStyle.Fill;
    this.lvSessions.ForeColor = Color.FromArgb(32 /*0x20*/, 32 /*0x20*/, 32 /*0x20*/);
    this.lvSessions.FullRowSelect = true;
    this.lvSessions.GridLines = true;
    this.lvSessions.Location = new Point(0, 0);
    this.lvSessions.Margin = new Padding(5, 2, 5, 2);
    this.lvSessions.Name = "lvSessions";
    this.lvSessions.Size = new Size(580, 109);
    this.lvSessions.TabIndex = 1;
    this.lvSessions.UseCompatibleStateImageBehavior = false;
    this.lvSessions.View = View.Details;
    this.lvSessions.CellClick += new EventHandler<CellClickEventArgs>(this.lvSessions_CellClick);
    this.lvSessions.ItemActivate += new EventHandler(this.lvSessions_ItemActivate);
    this.lvSessions.DoubleClick += new EventHandler(this.lvSessions_DoubleClick);
    this.col_ID.AspectName = "col_ID";
    this.col_ID.Groupable = false;
    this.col_ID.HeaderCheckBoxUpdatesRowCheckBoxes = false;
    this.col_ID.Hideable = false;
    this.col_ID.IsEditable = false;
    this.col_ID.Searchable = false;
    this.col_ID.Sortable = false;
    this.col_ID.Text = "#";
    this.col_ID.Width = 25;
    this.col_HWID.AspectName = "col_HWID";
    this.col_HWID.Groupable = false;
    this.col_HWID.HeaderCheckBoxUpdatesRowCheckBoxes = false;
    this.col_HWID.Hideable = false;
    this.col_HWID.IsEditable = false;
    this.col_HWID.Searchable = false;
    this.col_HWID.Sortable = false;
    this.col_HWID.Text = "Mã máy";
    this.col_LastSeen.AspectName = "col_LastSeen";
    this.col_LastSeen.Groupable = false;
    this.col_LastSeen.HeaderCheckBoxUpdatesRowCheckBoxes = false;
    this.col_LastSeen.Hideable = false;
    this.col_LastSeen.IsEditable = false;
    this.col_LastSeen.Searchable = false;
    this.col_LastSeen.Sortable = false;
    this.col_LastSeen.Text = "Đăng nhập cuối";
    this.col_LastSeen.Width = 135;
    this.col_Exp.AspectName = "col_Exp";
    this.col_Exp.Groupable = false;
    this.col_Exp.HeaderCheckBoxUpdatesRowCheckBoxes = false;
    this.col_Exp.Hideable = false;
    this.col_Exp.IsEditable = false;
    this.col_Exp.Searchable = false;
    this.col_Exp.Sortable = false;
    this.col_Exp.Text = "Ngày hết hạn";
    this.col_Exp.Width = 110;
    this.col_Tinhnang.AspectName = "col_Tinhnang";
    this.col_Tinhnang.FillsFreeSpace = true;
    this.col_Tinhnang.Groupable = false;
    this.col_Tinhnang.HeaderCheckBoxUpdatesRowCheckBoxes = false;
    this.col_Tinhnang.Hideable = false;
    this.col_Tinhnang.IsEditable = false;
    this.col_Tinhnang.Searchable = false;
    this.col_Tinhnang.Sortable = false;
    this.col_Tinhnang.Text = "Tính năng";
    this.col_Tinhnang.Width = 90;
    this.pnelBottom.Controls.Add((Control) this.lbTotalGG);
    this.pnelBottom.Controls.Add((Control) this.lbUsername);
    this.pnelBottom.Controls.Add((Control) this.cboPrice);
    this.pnelBottom.Controls.Add((Control) this.lbHWID);
    this.pnelBottom.Controls.Add((Control) this.btnNewSession);
    this.pnelBottom.Controls.Add((Control) this.btnThoatAuto);
    this.pnelBottom.Controls.Add((Control) this.btnChonPhien);
    this.pnelBottom.Dock = DockStyle.Bottom;
    this.pnelBottom.Location = new Point(0, 161);
    this.pnelBottom.Margin = new Padding(2);
    this.pnelBottom.Name = "pnelBottom";
    this.pnelBottom.Size = new Size(580, 54);
    this.pnelBottom.TabIndex = 15;
    this.lbTotalGG.AutoSize = true;
    this.lbTotalGG.Location = new Point(300, 33);
    this.lbTotalGG.Margin = new Padding(2, 0, 2, 0);
    this.lbTotalGG.Name = "lbTotalGG";
    this.lbTotalGG.Size = new Size(47, 13);
    this.lbTotalGG.TabIndex = 19;
    this.lbTotalGG.Text = "GG còn:";
    this.lbUsername.AutoSize = true;
    this.lbUsername.Location = new Point(146, 33);
    this.lbUsername.Margin = new Padding(2, 0, 2, 0);
    this.lbUsername.Name = "lbUsername";
    this.lbUsername.Size = new Size(55, 13);
    this.lbUsername.TabIndex = 18;
    this.lbUsername.Text = "Tài khoản";
    this.lbUsername.Click += new EventHandler(this.lbUsername_Click);
    this.cboPrice.FormattingEnabled = true;
    this.cboPrice.Location = new Point(431, 6);
    this.cboPrice.Margin = new Padding(2);
    this.cboPrice.Name = "cboPrice";
    this.cboPrice.Size = new Size(145, 21);
    this.cboPrice.TabIndex = 17;
    this.cboPrice.SelectedIndexChanged += new EventHandler(this.cboPrice_SelectedIndexChanged);
    this.lbHWID.AutoSize = true;
    this.lbHWID.Location = new Point(6, 33);
    this.lbHWID.Margin = new Padding(2, 0, 2, 0);
    this.lbHWID.Name = "lbHWID";
    this.lbHWID.Size = new Size(47, 13);
    this.lbHWID.TabIndex = 16 /*0x10*/;
    this.lbHWID.Text = "Mã máy:";
    this.btnNewSession.BackColor = Color.FromArgb(210, 249, 213);
    this.btnNewSession.ForeColor = Color.DarkGreen;
    this.btnNewSession.ImeMode = ImeMode.NoControl;
    this.btnNewSession.Location = new Point(338, 5);
    this.btnNewSession.Name = "btnNewSession";
    this.btnNewSession.Size = new Size(88, 23);
    this.btnNewSession.TabIndex = 15;
    this.btnNewSession.Text = "Tạo phiên mới";
    this.btnNewSession.UseVisualStyleBackColor = false;
    this.btnNewSession.Click += new EventHandler(this.btnNewSession_Click);
    this.btnThoatAuto.BackColor = Color.FromArgb(247, 207, 142);
    this.btnThoatAuto.ForeColor = Color.Black;
    this.btnThoatAuto.ImeMode = ImeMode.NoControl;
    this.btnThoatAuto.Location = new Point(4, 5);
    this.btnThoatAuto.Margin = new Padding(0);
    this.btnThoatAuto.Name = "btnThoatAuto";
    this.btnThoatAuto.Size = new Size(69, 23);
    this.btnThoatAuto.TabIndex = 14;
    this.btnThoatAuto.Text = "Thoát Auto";
    this.btnThoatAuto.UseVisualStyleBackColor = false;
    this.btnThoatAuto.Click += new EventHandler(this.btnThoatAuto_Click);
    this.btnChonPhien.BackColor = Color.FromArgb(210, 249, 213);
    this.btnChonPhien.ForeColor = Color.DarkGreen;
    this.btnChonPhien.ImeMode = ImeMode.NoControl;
    this.btnChonPhien.Location = new Point(262, 5);
    this.btnChonPhien.Name = "btnChonPhien";
    this.btnChonPhien.Size = new Size(70, 23);
    this.btnChonPhien.TabIndex = 13;
    this.btnChonPhien.Text = "Chọn phiên";
    this.btnChonPhien.UseVisualStyleBackColor = false;
    this.btnChonPhien.Click += new EventHandler(this.btnChonPhien_Click);
    this.backgroundWorker1.DoWork += new DoWorkEventHandler(this.backgroundWorker1_DoWork);
    this.backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
    this.AutoScaleDimensions = new SizeF(6f, 13f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.ClientSize = new Size(580, 215);
    this.Controls.Add((Control) this.pnelMid);
    this.Controls.Add((Control) this.pnelTop);
    this.Controls.Add((Control) this.pnelBottom);
    this.FormBorderStyle = FormBorderStyle.FixedSingle;
    this.Margin = new Padding(2);
    this.MaximizeBox = false;
    this.Name = nameof (frmPickSession);
    this.ShowIcon = false;
    this.StartPosition = FormStartPosition.CenterScreen;
    this.Text = "Chọn phiên làm việc auto";
    this.FormClosing += new FormClosingEventHandler(this.frmPickSession_FormClosing);
    this.FormClosed += new FormClosedEventHandler(this.frmPickSession_FormClosed);
    this.Load += new EventHandler(this.frmPickSession_Load);
    this.Shown += new EventHandler(this.frmPickSession_Shown);
    this.pnelTop.ResumeLayout(false);
    this.pnelMid.ResumeLayout(false);
    ((ISupportInitialize) this.lvSessions).EndInit();
    this.pnelBottom.ResumeLayout(false);
    this.pnelBottom.PerformLayout();
    this.ResumeLayout(false);
  }
}
