// Decompiled with JetBrains decompiler
// Type: SmartBot.frmUserInfo
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

#nullable disable
namespace SmartBot;

public class frmUserInfo : Form
{
  public static Dictionary<string, string> userInfo = frmLogin.GAuto.Settings.LoginInfo;
  private List<NapTheClass> NapTheLog = new List<NapTheClass>();
  private List<ActionLogClass> ActionLog = new List<ActionLogClass>();
  private IContainer components;
  private GroupBox grpUser;
  private TextBox userExpDate;
  private Label label4;
  private TextBox remainTime;
  private Label label3;
  private TextBox remainCash;
  private Label label2;
  private TextBox userID;
  private Label label1;
  private Label label5;
  private TextBox remainGGold;
  private Label label6;
  private TextBox txtQ1TC;
  private Label label8;
  private TextBox txtCheDo;
  private Label label11;
  private Label label7;
  private TextBox txtYTO;
  private Label label9;
  private Button btnNapThe;
  private Button btnThem24h;
  private System.Windows.Forms.Timer timer1;
  private GroupBox groupBox1;
  private Label label10;
  private ListView lvTheDaNap;
  private ColumnHeader columnHeader1;
  private ColumnHeader columnHeader2;
  private ColumnHeader columnHeader3;
  private ColumnHeader columnHeader4;
  private Label label12;
  private ListView lvHoatDong;
  private ColumnHeader columnHeader5;
  private ColumnHeader columnHeader6;
  private ColumnHeader columnHeader7;
  private ColumnHeader columnHeader8;
  private Button btnRefresh;
  private TextBox txtTrading;
  private Label lblTrading;
  private Button btnRefreshInfo;

  public frmUserInfo()
  {
    this.InitializeComponent();
    this.UpdateMyGUI();
    this.PopulateHistoryInfo();
  }

  private void UpdateMyGUI()
  {
    this.userID.Text = frmLogin.GAuto.Settings.Account.Username;
    bool flag1 = false;
    bool flag2 = false;
    if (frmLogin.GAuto.Settings.Account.RemainBalance <= 0.0)
    {
      if (frmLogin.GAuto.Settings.CompilingLanguage == "VN")
        this.remainCash.Text = "Hết hạn sử dụng.";
      else if (frmLogin.GAuto.Settings.CompilingLanguage == "EN")
        this.remainCash.Text = "Subscription expired.";
      else if (frmLogin.GAuto.Settings.CompilingLanguage == "CN")
        this.remainCash.Text = "订阅过期.";
    }
    else
    {
      double num = frmLogin.GAuto.Settings.Account.RemainMSeconds * 10.0 / 518400.0;
      double remainBalance = frmLogin.GAuto.Settings.Account.RemainBalance;
      if (!frmLogin.GAuto.Settings.Account.IsLoginGGold)
      {
        flag1 = true;
        if (frmLogin.GAuto.Settings.CompilingLanguage == "VN")
          this.remainCash.Text = $"(Đang dùng) {remainBalance.ToString("0.00")} VNĐ";
        else if (frmLogin.GAuto.Settings.CompilingLanguage == "EN")
          this.remainCash.Text = $"(In use) {remainBalance.ToString("0.00")} USD";
        else if (frmLogin.GAuto.Settings.CompilingLanguage == "CN")
          this.remainCash.Text = $"(正在使用) {remainBalance.ToString("0.00")} {frmLogin.GAuto.Settings.CompilingCurrency}";
      }
      else if (frmLogin.GAuto.Settings.CompilingLanguage == "VN")
      {
        this.remainCash.Text = remainBalance.ToString("0.00") + " VNĐ";
        this.label4.Text = "Dùng thêm G-Gold:";
      }
      else if (frmLogin.GAuto.Settings.CompilingLanguage == "EN")
      {
        this.remainCash.Text = remainBalance.ToString("0.00") + " USD";
        this.label4.Text = "Use more G-Gold:";
      }
      else if (frmLogin.GAuto.Settings.CompilingLanguage == "CN")
      {
        this.remainCash.Text = $"{remainBalance.ToString("0.00")} {frmLogin.GAuto.Settings.CompilingCurrency}";
        this.label4.Text = "使用 G-Gold:";
      }
    }
    if (frmLogin.GAuto.Settings.Account.RemainGGoldBalance <= 0.0 && frmLogin.GAuto.Settings.Account.RemainGGoldPromo <= 0.0)
    {
      if (frmLogin.GAuto.Settings.CompilingLanguage == "VN")
        this.remainGGold.Text = "Đã cạn";
      else if (frmLogin.GAuto.Settings.CompilingLanguage == "EN")
        this.remainGGold.Text = "Empty";
      else if (frmLogin.GAuto.Settings.CompilingLanguage == "CN")
        this.remainGGold.Text = "出的GG";
    }
    else
    {
      int num = 1000;
      if (frmLogin.GAuto.Settings.CompilingLanguage != "VN")
        num = 1;
      this.remainGGold.Text = (frmLogin.GAuto.Settings.Account.RemainGGoldBalance / (double) num).ToString("0.0") + " GG";
      this.remainCash.Text = (frmLogin.GAuto.Settings.Account.RemainGGoldPromo / (double) num).ToString("0.0") + " GG+";
      flag2 = true;
    }
    if (!flag2 && !flag1)
    {
      if (frmLogin.GAuto.Settings.CompilingLanguage == "VN")
        this.Text = "Thông tin tài khoản - Lite version";
      else if (frmLogin.GAuto.Settings.CompilingLanguage == "EN")
        this.Text = "Account information - Lite version";
      else if (frmLogin.GAuto.Settings.CompilingLanguage == "CN")
        this.Text = "账户信息 - 免费版";
    }
    else if (!frmLogin.GAuto.Settings.Account.IsLoginGGold)
    {
      if (frmLogin.GAuto.Settings.CompilingLanguage == "VN")
        this.Text = "Tài khoản - Pro version";
      else if (frmLogin.GAuto.Settings.CompilingLanguage == "EN")
        this.Text = "Account information - Pro version";
      else if (frmLogin.GAuto.Settings.CompilingLanguage == "CN")
        this.Text = "账户信息 - PRO版";
    }
    else if (frmLogin.GAuto.Settings.CompilingLanguage == "VN")
      this.Text = "Tài khoản Pro (G-Gold)";
    else if (frmLogin.GAuto.Settings.CompilingLanguage == "EN")
      this.Text = "Account - Pro (G-Gold)";
    else if (frmLogin.GAuto.Settings.CompilingLanguage == "CN")
      this.Text = "账户信息 - Pro版 (G-Gold)";
    if (frmLogin.GAuto.Settings.Account.RemainMSeconds <= 0.0)
    {
      if (frmLogin.GAuto.Settings.CompilingLanguage == "VN")
        this.remainTime.Text = "Hết hạn";
      else if (frmLogin.GAuto.Settings.CompilingLanguage == "EN")
        this.remainTime.Text = "Expired";
      else if (frmLogin.GAuto.Settings.CompilingLanguage == "CN")
        this.remainTime.Text = "过期";
      this.userExpDate.Text = DateTime.MinValue.ToShortDateString();
    }
    else
    {
      TimeSpan timeSpan = TimeSpan.FromMilliseconds(frmLogin.GAuto.Settings.Account.RemainMSeconds);
      if (frmLogin.GAuto.Settings.CompilingLanguage == "VN")
        this.remainTime.Text = $"{timeSpan.Days.ToString()} ngày, {timeSpan.Hours.ToString()} giờ {timeSpan.Minutes.ToString()} phút";
      else if (frmLogin.GAuto.Settings.CompilingLanguage == "EN")
        this.remainTime.Text = $"{timeSpan.Days.ToString()} day, {timeSpan.Hours.ToString()} hour {timeSpan.Minutes.ToString()} minute";
      else if (frmLogin.GAuto.Settings.CompilingLanguage == "CN")
        this.remainTime.Text = $"{timeSpan.Days.ToString()} 天, {timeSpan.Hours.ToString()} 小时 {timeSpan.Minutes.ToString()} 分钟";
      this.userExpDate.Text = DateTime.Now.AddMilliseconds(frmLogin.GAuto.Settings.Account.RemainMSeconds).ToString();
    }
    int num1 = !(frmLogin.CompilingLanguage == "VN") ? frmLogin.GAuto.Settings.Account.CheDoInfo.Count : (frmLogin.GAuto.Settings.CheDoCounts ^ 2013) / 152;
    int num2 = (frmLogin.GAuto.Settings.CheDoDuration ^ 2013) / 152;
    TimeSpan timeSpan1 = TimeSpan.FromSeconds((double) frmLogin.GAuto.Settings.Account.CheDoRemMin);
    TimeSpan timeSpan2 = TimeSpan.FromSeconds((double) frmLogin.GAuto.Settings.Account.CheDoRemMax);
    TimeSpan timeSpan3 = TimeSpan.FromSeconds((double) (num2 - 1));
    if (num1 > 0)
    {
      if (frmLogin.GAuto.Settings.CompilingLanguage == "VN")
        this.txtCheDo.Text = $"{num1} nhân vật. Còn {timeSpan3.Hours.ToString("00")} giờ {timeSpan3.Minutes.ToString("00")} phút";
      else if (frmLogin.GAuto.Settings.CompilingLanguage == "EN")
      {
        string str1 = timeSpan1.TotalHours.ToString("00") + " h";
        if (timeSpan1.TotalHours <= 0.0)
          str1 = timeSpan1.TotalMinutes.ToString("00") + " m";
        string str2 = timeSpan2.TotalHours.ToString("00") + " h";
        if (timeSpan2.TotalHours <= 0.0)
          str2 = timeSpan2.TotalMinutes.ToString("00") + " m";
        this.txtCheDo.Text = $"{num1} char. Rem: {str1} -> {str2}";
      }
      else if (frmLogin.GAuto.Settings.CompilingLanguage == "CN")
        this.txtCheDo.Text = $"{num1} 人物. 休息 {timeSpan3.Hours.ToString("00")} 小时 {timeSpan3.Minutes.ToString("00")} 分钟";
    }
    else if (frmLogin.GAuto.Settings.CompilingLanguage == "VN")
      this.txtCheDo.Text = "Chưa mở chế đồ";
    else if (frmLogin.GAuto.Settings.CompilingLanguage == "EN")
      this.txtCheDo.Text = "Not activated crafting";
    else if (frmLogin.GAuto.Settings.CompilingLanguage == "CN")
      this.txtCheDo.Text = "家具制造-未启用";
    int num3 = (frmLogin.GAuto.Settings.TraderCounts ^ 2714) / 153;
    if (num3 < frmLogin.GAuto.Settings.DefaultFreeTN && frmLogin.GAuto.Settings.Account.RemainMSeconds > 0.0)
      num3 = frmLogin.GAuto.Settings.DefaultFreeTN;
    TimeSpan timeSpan4 = TimeSpan.FromSeconds((double) frmLogin.GAuto.Settings.Account.TraderRemMin);
    TimeSpan timeSpan5 = TimeSpan.FromSeconds((double) frmLogin.GAuto.Settings.Account.TraderRemMax);
    if (num3 > 0)
    {
      if (frmLogin.GAuto.Settings.CompilingLanguage == "EN")
      {
        string str3 = timeSpan4.TotalHours.ToString("00") + " h";
        if (timeSpan4.TotalHours <= 0.0)
          str3 = timeSpan4.TotalMinutes.ToString("00") + " m";
        string str4 = timeSpan5.TotalHours.ToString("00") + " h";
        if (timeSpan5.TotalHours <= 0.0)
          str4 = timeSpan5.TotalMinutes.ToString("00") + " m";
        this.txtTrading.Text = $"{num3} char. Rem: {str3} -> {str4}";
      }
    }
    else if (frmLogin.GAuto.Settings.CompilingLanguage == "VN")
      this.txtTrading.Text = "Chưa mở thương nhân";
    else if (frmLogin.GAuto.Settings.CompilingLanguage == "EN")
      this.txtTrading.Text = "Not activated trading";
    else if (frmLogin.GAuto.Settings.CompilingLanguage == "CN")
      this.txtTrading.Text = "未激活的交易功能";
    int num4 = (frmLogin.GAuto.Settings.Q12TCCounts ^ 1786) / 849;
    TimeSpan timeSpan6 = TimeSpan.FromSeconds((double) ((frmLogin.GAuto.Settings.Q12TCDuration ^ 1786) / 849 - 1));
    if (num4 > 0)
    {
      if (frmLogin.GAuto.Settings.CompilingLanguage == "VN")
        this.txtQ1TC.Text = $"{num4} party. Còn {timeSpan6.Hours.ToString("00")} giờ {timeSpan6.Minutes.ToString("00")} phút";
      else if (frmLogin.GAuto.Settings.CompilingLanguage == "EN")
        this.txtQ1TC.Text = $"{num4} team. Left {timeSpan6.Hours.ToString("00")} h {timeSpan6.Minutes.ToString("00")} min";
      else if (frmLogin.GAuto.Settings.CompilingLanguage == "CN")
        this.txtQ1TC.Text = $"{num4}团队.剩{timeSpan6.Hours.ToString("00")}小时{timeSpan6.Minutes.ToString("00")}分钟";
    }
    else if (frmLogin.GAuto.Settings.CompilingLanguage == "VN")
      this.txtQ1TC.Text = "Chưa mở Q12 TC";
    else if (frmLogin.GAuto.Settings.CompilingLanguage == "EN")
      this.txtQ1TC.Text = "Not activated Q12 SZ";
    else if (frmLogin.GAuto.Settings.CompilingLanguage == "CN")
      this.txtQ1TC.Text = "从未激活Q12苏州";
    int num5 = (frmLogin.GAuto.Settings.YTOCounts ^ 2716) / 147;
    TimeSpan timeSpan7 = TimeSpan.FromSeconds((double) ((frmLogin.GAuto.Settings.YTODuration ^ 2716) / 147 - 1));
    if (num5 > 0)
    {
      if (frmLogin.GAuto.Settings.CompilingLanguage == "VN")
        this.txtYTO.Text = $"{num5} party. Còn {timeSpan7.Hours.ToString("00")} giờ {timeSpan7.Minutes.ToString("00")} phút";
      else if (frmLogin.GAuto.Settings.CompilingLanguage == "EN")
      {
        this.txtYTO.Text = $"{num5} team. Left {timeSpan7.Hours.ToString("00")} h {timeSpan7.Minutes.ToString("00")} min";
      }
      else
      {
        if (!(frmLogin.GAuto.Settings.CompilingLanguage == "CN"))
          return;
        this.txtYTO.Text = $"{num5}团队.剩{timeSpan7.Hours.ToString("00")}小时{timeSpan7.Minutes.ToString("00")}分钟";
      }
    }
    else if (frmLogin.GAuto.Settings.CompilingLanguage == "VN")
      this.txtYTO.Text = "Chưa mở YTO";
    else if (frmLogin.GAuto.Settings.CompilingLanguage == "EN")
    {
      this.txtYTO.Text = "Not activated SD";
    }
    else
    {
      if (!(frmLogin.GAuto.Settings.CompilingLanguage == "CN"))
        return;
      this.txtYTO.Text = "从未激活日元涂驱动器";
    }
  }

  private void frmUserInfo_Load(object sender, EventArgs e)
  {
  }

  private void btnNapThe_Click(object sender, EventArgs e) => frmMain.MyFormNapThe();

  private void btnThem24h_Click(object sender, EventArgs e)
  {
  }

  private void frmUserInfo_Shown(object sender, EventArgs e)
  {
  }

  private void timer1_Tick(object sender, EventArgs e)
  {
    if (!frmLogin.GAuto.UpdateAccountInfo)
      return;
    this.UpdateMyGUI();
    this.PopulateHistoryInfo();
    try
    {
      frmLogin.GAuto.UpdateAccountInfo = false;
    }
    catch (Exception ex)
    {
    }
  }

  private void btnRefresh_Click(object sender, EventArgs e) => this.PopulateHistoryInfo();

  private void PopulateHistoryInfo()
  {
    if (GA.useBlog || GA.blog != null || !(frmLogin.GAuto.Settings.Account.Username != "") || frmLogin.MainGAutoServer == null)
      return;
    string data = $"userid={frmLogin.GAuto.Settings.Account.Username}&isauto=auto";
    string input1 = GA.LoadWebNoAlive(frmLogin.MainGAutoServer.URL + frmLogin.GAuto.Settings.UsageURL, data, "POST", (CookieContainer) null);
    this.NapTheLog.Clear();
    this.ActionLog.Clear();
    if (string.IsNullOrEmpty(input1) || !(input1 != frmLogin.GAuto.Settings.LoadWebErrorMessage))
      return;
    DateTime.MinValue.ToString();
    GA.GetMidString(input1, "{\"handung\":\"", "\",\"");
    GA.GetMidString(input1, "\"subexpdate\":\"", "\",\"");
    GA.GetMidString(input1, "remaingg\":", ",\"sothenap");
    if (input1.Contains("napthe") && input1.Contains("actioncount"))
    {
      string[] strArray = GA.GetMidString(input1, "\"napthe\":[", "],\"actioncount").Split('}');
      if (strArray.Length > 0)
      {
        foreach (string input2 in strArray)
        {
          if (!string.IsNullOrEmpty(input2))
          {
            NapTheClass napTheClass = new NapTheClass();
            napTheClass.NapTime = GA.GetMidString(input2, "thetime\":\"", "\",\"");
            napTheClass.Telco = GA.GetMidString(input2, "telco\":\"", "\",\"");
            napTheClass.Serial = GA.GetMidString(input2, "serial\":\"", "\",\"");
            napTheClass.Loai = GA.GetMidString(input2, "loaitk\":\"", "\"", secondIndex: 3);
            napTheClass.Amount = GA.GetMidString(input2, "amount\":\"", "\",\"");
            if (napTheClass.Serial.Length > 4)
            {
              char[] charArray = napTheClass.Serial.ToCharArray();
              for (int index = 0; index < charArray.Length - 4; ++index)
                charArray[index] = '*';
              napTheClass.Serial = new string(charArray);
            }
            this.NapTheLog.Add(napTheClass);
          }
        }
        this.lvTheDaNap.BeginUpdate();
        this.lvTheDaNap.Items.Clear();
        if (this.NapTheLog.Count > 0)
        {
          foreach (NapTheClass napTheClass in this.NapTheLog)
            this.lvTheDaNap.Items.Add(new ListViewItem()
            {
              Text = napTheClass.NapTime,
              SubItems = {
                napTheClass.Amount,
                napTheClass.Loai,
                $"{napTheClass.Telco}-{napTheClass.Serial}"
              }
            });
        }
        this.lvTheDaNap.EndUpdate();
      }
    }
    if (!input1.Contains("actionlog") || !input1.Contains("actioncount"))
      return;
    string[] strArray1 = GA.GetMidString(input1, "\"actionlog\":[", "]}").Split('}');
    if (strArray1.Length <= 0)
      return;
    foreach (string input3 in strArray1)
    {
      if (!string.IsNullOrEmpty(input3))
      {
        ActionLogClass actionLogClass1 = new ActionLogClass();
        ActionLogClass actionLogClass2 = (ActionLogClass) null;
        if (this.ActionLog.Count > 1)
          actionLogClass2 = this.ActionLog[this.ActionLog.Count - 1];
        actionLogClass1.ActionTime = GA.GetMyField(input3, "actiontime");
        actionLogClass1.ActionType = GA.GetMyField(input3, "actiontype");
        actionLogClass1.GGRemain = GA.GetMyField(input3, "actionremain");
        bool flag = false;
        if (actionLogClass2 != null)
        {
          int result1 = 0;
          int.TryParse(actionLogClass2.GGRemain, out result1);
          int result2 = 0;
          int.TryParse(actionLogClass1.GGRemain, out result2);
          if (result1 > result2)
          {
            actionLogClass1.ActionCost = (result1 - result2).ToString();
            if (actionLogClass1.ActionCost == "3")
              actionLogClass1.ActionType = "LOGIN";
          }
          else if (result1 == result2)
            flag = true;
        }
        else
          actionLogClass1.ActionCost = GA.GetMyField(input3, "actioncost");
        if (!flag)
          this.ActionLog.Add(actionLogClass1);
      }
    }
    if (this.ActionLog.Count <= 0)
      return;
    bool flag1 = false;
    for (int index = this.ActionLog.Count - 1; index >= 0; --index)
    {
      bool flag2 = false;
      if (index < this.ActionLog.Count - 1 && this.ActionLog[index].ActionTime == this.ActionLog[index + 1].ActionTime && this.ActionLog[index].GGRemain == this.ActionLog[index + 1].GGRemain && this.ActionLog[index].ActionType != this.ActionLog[index + 1].ActionType)
        flag2 = true;
      bool flag3 = false;
      if (index > 0 && this.ActionLog[index].ActionTime == this.ActionLog[index - 1].ActionTime && this.ActionLog[index].GGRemain == this.ActionLog[index - 1].GGRemain && this.ActionLog[index].ActionType != this.ActionLog[index - 1].ActionType)
        flag3 = true;
      if (flag2 || flag3)
      {
        this.ActionLog[index].IsDup = true;
        flag1 = true;
      }
    }
    if (flag1)
    {
      for (int index = this.ActionLog.Count - 1; index >= 0; --index)
      {
        if (this.ActionLog[index].IsDup && this.ActionLog[index].ActionType.Contains("CD-"))
        {
          this.ActionLog.RemoveAt(index);
          ++index;
        }
      }
    }
    this.lvHoatDong.BeginUpdate();
    this.lvHoatDong.Items.Clear();
    foreach (ActionLogClass actionLogClass in this.ActionLog)
    {
      if (actionLogClass.ActionCost != "")
      {
        ListViewItem listViewItem = new ListViewItem();
        listViewItem.Text = actionLogClass.ActionTime;
        if (actionLogClass.ActionType.Contains("Q12-") || actionLogClass.ActionType.Contains("YTO-"))
          actionLogClass.ActionType += " giờ";
        else if (actionLogClass.ActionType.Contains("CD-"))
        {
          string[] strArray2 = actionLogClass.ActionType.Split('-');
          actionLogClass.ActionType = "Chế đồ lượt " + strArray2[1];
        }
        else if (actionLogClass.ActionType.Contains("CDRN-"))
        {
          string[] strArray3 = actionLogClass.ActionType.Split('-');
          actionLogClass.ActionType = $"Chế renew {strArray3[1]} acc";
        }
        if (!actionLogClass.IsDup)
          listViewItem.SubItems.Add(actionLogClass.ActionType);
        else
          listViewItem.SubItems.Add(actionLogClass.ActionType + " *");
        listViewItem.SubItems.Add(actionLogClass.ActionCost + " GG");
        listViewItem.SubItems.Add(actionLogClass.GGRemain + " GG");
        this.lvHoatDong.Items.Add(listViewItem);
      }
    }
    this.lvHoatDong.EndUpdate();
  }

  private void txtTrading_TextChanged(object sender, EventArgs e)
  {
  }

  private void btnRefreshInfo_Click(object sender, EventArgs e)
  {
    if (frmLogin.GlobalTimer.ElapsedMilliseconds - frmLogin.RefreshClickStamp < 3000L)
      return;
    frmLogin.RefreshClickStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
    string version = "";
    string myMessage = "";
    GA.SendKeepAlivePHP(out version, out myMessage);
  }

  private void groupBox1_Enter(object sender, EventArgs e)
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
    this.components = (IContainer) new System.ComponentModel.Container();
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmUserInfo));
    this.grpUser = new GroupBox();
    this.txtYTO = new TextBox();
    this.label9 = new Label();
    this.btnRefreshInfo = new Button();
    this.lblTrading = new Label();
    this.txtTrading = new TextBox();
    this.btnNapThe = new Button();
    this.btnThem24h = new Button();
    this.txtQ1TC = new TextBox();
    this.label8 = new Label();
    this.txtCheDo = new TextBox();
    this.label11 = new Label();
    this.label7 = new Label();
    this.remainGGold = new TextBox();
    this.label6 = new Label();
    this.label5 = new Label();
    this.userExpDate = new TextBox();
    this.label4 = new Label();
    this.remainTime = new TextBox();
    this.label3 = new Label();
    this.remainCash = new TextBox();
    this.label2 = new Label();
    this.userID = new TextBox();
    this.label1 = new Label();
    this.timer1 = new System.Windows.Forms.Timer(this.components);
    this.groupBox1 = new GroupBox();
    this.btnRefresh = new Button();
    this.label12 = new Label();
    this.lvHoatDong = new ListView();
    this.columnHeader5 = new ColumnHeader();
    this.columnHeader6 = new ColumnHeader();
    this.columnHeader7 = new ColumnHeader();
    this.columnHeader8 = new ColumnHeader();
    this.label10 = new Label();
    this.lvTheDaNap = new ListView();
    this.columnHeader1 = new ColumnHeader();
    this.columnHeader2 = new ColumnHeader();
    this.columnHeader3 = new ColumnHeader();
    this.columnHeader4 = new ColumnHeader();
    this.grpUser.SuspendLayout();
    this.groupBox1.SuspendLayout();
    this.SuspendLayout();
    this.grpUser.BackColor = Color.WhiteSmoke;
    this.grpUser.Controls.Add((Control) this.txtYTO);
    this.grpUser.Controls.Add((Control) this.label9);
    this.grpUser.Controls.Add((Control) this.btnRefreshInfo);
    this.grpUser.Controls.Add((Control) this.lblTrading);
    this.grpUser.Controls.Add((Control) this.txtTrading);
    this.grpUser.Controls.Add((Control) this.btnNapThe);
    this.grpUser.Controls.Add((Control) this.btnThem24h);
    this.grpUser.Controls.Add((Control) this.txtQ1TC);
    this.grpUser.Controls.Add((Control) this.label8);
    this.grpUser.Controls.Add((Control) this.txtCheDo);
    this.grpUser.Controls.Add((Control) this.label11);
    this.grpUser.Controls.Add((Control) this.label7);
    this.grpUser.Controls.Add((Control) this.remainGGold);
    this.grpUser.Controls.Add((Control) this.label6);
    this.grpUser.Controls.Add((Control) this.label5);
    this.grpUser.Controls.Add((Control) this.userExpDate);
    this.grpUser.Controls.Add((Control) this.label4);
    this.grpUser.Controls.Add((Control) this.remainTime);
    this.grpUser.Controls.Add((Control) this.label3);
    this.grpUser.Controls.Add((Control) this.remainCash);
    this.grpUser.Controls.Add((Control) this.label2);
    this.grpUser.Controls.Add((Control) this.userID);
    this.grpUser.Controls.Add((Control) this.label1);
    componentResourceManager.ApplyResources((object) this.grpUser, "grpUser");
    this.grpUser.Name = "grpUser";
    this.grpUser.TabStop = false;
    this.txtYTO.BackColor = Color.FromArgb(206, 233, 253);
    this.txtYTO.BorderStyle = BorderStyle.FixedSingle;
    this.txtYTO.ForeColor = Color.FromArgb(15, 15, 15);
    componentResourceManager.ApplyResources((object) this.txtYTO, "txtYTO");
    this.txtYTO.Name = "txtYTO";
    this.txtYTO.ReadOnly = true;
    this.txtYTO.TabStop = false;
    componentResourceManager.ApplyResources((object) this.label9, "label9");
    this.label9.Name = "label9";
    this.btnRefreshInfo.BackColor = Color.FromArgb(210, 249, 213);
    this.btnRefreshInfo.ForeColor = Color.DarkGreen;
    componentResourceManager.ApplyResources((object) this.btnRefreshInfo, "btnRefreshInfo");
    this.btnRefreshInfo.Name = "btnRefreshInfo";
    this.btnRefreshInfo.UseVisualStyleBackColor = false;
    this.btnRefreshInfo.Click += new EventHandler(this.btnRefreshInfo_Click);
    componentResourceManager.ApplyResources((object) this.lblTrading, "lblTrading");
    this.lblTrading.Name = "lblTrading";
    this.txtTrading.BackColor = Color.FromArgb(206, 233, 253);
    this.txtTrading.BorderStyle = BorderStyle.FixedSingle;
    this.txtTrading.ForeColor = Color.FromArgb(15, 15, 15);
    componentResourceManager.ApplyResources((object) this.txtTrading, "txtTrading");
    this.txtTrading.Name = "txtTrading";
    this.txtTrading.ReadOnly = true;
    this.txtTrading.TabStop = false;
    this.txtTrading.TextChanged += new EventHandler(this.txtTrading_TextChanged);
    this.btnNapThe.BackColor = Color.FromArgb(210, 249, 213);
    this.btnNapThe.ForeColor = Color.DarkGreen;
    componentResourceManager.ApplyResources((object) this.btnNapThe, "btnNapThe");
    this.btnNapThe.Name = "btnNapThe";
    this.btnNapThe.UseVisualStyleBackColor = false;
    this.btnNapThe.Click += new EventHandler(this.btnNapThe_Click);
    this.btnThem24h.BackColor = Color.FromArgb(210, 249, 213);
    this.btnThem24h.ForeColor = Color.DarkGreen;
    componentResourceManager.ApplyResources((object) this.btnThem24h, "btnThem24h");
    this.btnThem24h.Name = "btnThem24h";
    this.btnThem24h.UseVisualStyleBackColor = false;
    this.btnThem24h.Click += new EventHandler(this.btnThem24h_Click);
    this.txtQ1TC.BackColor = Color.FromArgb(206, 233, 253);
    this.txtQ1TC.BorderStyle = BorderStyle.FixedSingle;
    this.txtQ1TC.ForeColor = Color.FromArgb(15, 15, 15);
    componentResourceManager.ApplyResources((object) this.txtQ1TC, "txtQ1TC");
    this.txtQ1TC.Name = "txtQ1TC";
    this.txtQ1TC.ReadOnly = true;
    this.txtQ1TC.TabStop = false;
    componentResourceManager.ApplyResources((object) this.label8, "label8");
    this.label8.Name = "label8";
    this.txtCheDo.BackColor = Color.FromArgb(206, 233, 253);
    this.txtCheDo.BorderStyle = BorderStyle.FixedSingle;
    this.txtCheDo.ForeColor = Color.FromArgb(15, 15, 15);
    componentResourceManager.ApplyResources((object) this.txtCheDo, "txtCheDo");
    this.txtCheDo.Name = "txtCheDo";
    this.txtCheDo.ReadOnly = true;
    this.txtCheDo.TabStop = false;
    componentResourceManager.ApplyResources((object) this.label11, "label11");
    this.label11.Name = "label11";
    componentResourceManager.ApplyResources((object) this.label7, "label7");
    this.label7.Name = "label7";
    this.remainGGold.BackColor = Color.FromArgb(206, 233, 253);
    this.remainGGold.BorderStyle = BorderStyle.FixedSingle;
    this.remainGGold.ForeColor = Color.FromArgb(15, 15, 15);
    componentResourceManager.ApplyResources((object) this.remainGGold, "remainGGold");
    this.remainGGold.Name = "remainGGold";
    this.remainGGold.ReadOnly = true;
    this.remainGGold.TabStop = false;
    componentResourceManager.ApplyResources((object) this.label6, "label6");
    this.label6.Name = "label6";
    this.label5.ForeColor = Color.DarkRed;
    componentResourceManager.ApplyResources((object) this.label5, "label5");
    this.label5.Name = "label5";
    this.userExpDate.BackColor = Color.FromArgb(206, 233, 253);
    this.userExpDate.BorderStyle = BorderStyle.FixedSingle;
    this.userExpDate.ForeColor = Color.FromArgb(15, 15, 15);
    componentResourceManager.ApplyResources((object) this.userExpDate, "userExpDate");
    this.userExpDate.Name = "userExpDate";
    this.userExpDate.ReadOnly = true;
    this.userExpDate.TabStop = false;
    componentResourceManager.ApplyResources((object) this.label4, "label4");
    this.label4.Name = "label4";
    this.remainTime.BackColor = Color.FromArgb(206, 233, 253);
    this.remainTime.BorderStyle = BorderStyle.FixedSingle;
    this.remainTime.ForeColor = Color.FromArgb(15, 15, 15);
    componentResourceManager.ApplyResources((object) this.remainTime, "remainTime");
    this.remainTime.Name = "remainTime";
    this.remainTime.ReadOnly = true;
    this.remainTime.TabStop = false;
    componentResourceManager.ApplyResources((object) this.label3, "label3");
    this.label3.Name = "label3";
    this.remainCash.BackColor = Color.FromArgb(206, 233, 253);
    this.remainCash.BorderStyle = BorderStyle.FixedSingle;
    this.remainCash.ForeColor = Color.FromArgb(15, 15, 15);
    componentResourceManager.ApplyResources((object) this.remainCash, "remainCash");
    this.remainCash.Name = "remainCash";
    this.remainCash.ReadOnly = true;
    this.remainCash.TabStop = false;
    componentResourceManager.ApplyResources((object) this.label2, "label2");
    this.label2.Name = "label2";
    this.userID.BackColor = Color.FromArgb(206, 233, 253);
    this.userID.BorderStyle = BorderStyle.FixedSingle;
    this.userID.ForeColor = Color.FromArgb(15, 15, 15);
    componentResourceManager.ApplyResources((object) this.userID, "userID");
    this.userID.Name = "userID";
    this.userID.ReadOnly = true;
    this.userID.TabStop = false;
    componentResourceManager.ApplyResources((object) this.label1, "label1");
    this.label1.Name = "label1";
    this.timer1.Enabled = true;
    this.timer1.Interval = 500;
    this.timer1.Tick += new EventHandler(this.timer1_Tick);
    this.groupBox1.Controls.Add((Control) this.btnRefresh);
    this.groupBox1.Controls.Add((Control) this.label12);
    this.groupBox1.Controls.Add((Control) this.lvHoatDong);
    this.groupBox1.Controls.Add((Control) this.label10);
    this.groupBox1.Controls.Add((Control) this.lvTheDaNap);
    componentResourceManager.ApplyResources((object) this.groupBox1, "groupBox1");
    this.groupBox1.Name = "groupBox1";
    this.groupBox1.TabStop = false;
    this.groupBox1.Enter += new EventHandler(this.groupBox1_Enter);
    this.btnRefresh.BackColor = Color.FromArgb(210, 249, 213);
    this.btnRefresh.ForeColor = Color.DarkGreen;
    componentResourceManager.ApplyResources((object) this.btnRefresh, "btnRefresh");
    this.btnRefresh.Name = "btnRefresh";
    this.btnRefresh.UseVisualStyleBackColor = false;
    this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);
    componentResourceManager.ApplyResources((object) this.label12, "label12");
    this.label12.Name = "label12";
    this.lvHoatDong.Columns.AddRange(new ColumnHeader[4]
    {
      this.columnHeader5,
      this.columnHeader6,
      this.columnHeader7,
      this.columnHeader8
    });
    this.lvHoatDong.FullRowSelect = true;
    this.lvHoatDong.GridLines = true;
    componentResourceManager.ApplyResources((object) this.lvHoatDong, "lvHoatDong");
    this.lvHoatDong.Name = "lvHoatDong";
    this.lvHoatDong.UseCompatibleStateImageBehavior = false;
    this.lvHoatDong.View = View.Details;
    componentResourceManager.ApplyResources((object) this.columnHeader5, "columnHeader5");
    componentResourceManager.ApplyResources((object) this.columnHeader6, "columnHeader6");
    componentResourceManager.ApplyResources((object) this.columnHeader7, "columnHeader7");
    componentResourceManager.ApplyResources((object) this.columnHeader8, "columnHeader8");
    componentResourceManager.ApplyResources((object) this.label10, "label10");
    this.label10.Name = "label10";
    this.lvTheDaNap.Columns.AddRange(new ColumnHeader[4]
    {
      this.columnHeader1,
      this.columnHeader2,
      this.columnHeader3,
      this.columnHeader4
    });
    this.lvTheDaNap.FullRowSelect = true;
    this.lvTheDaNap.GridLines = true;
    componentResourceManager.ApplyResources((object) this.lvTheDaNap, "lvTheDaNap");
    this.lvTheDaNap.Name = "lvTheDaNap";
    this.lvTheDaNap.UseCompatibleStateImageBehavior = false;
    this.lvTheDaNap.View = View.Details;
    componentResourceManager.ApplyResources((object) this.columnHeader1, "columnHeader1");
    componentResourceManager.ApplyResources((object) this.columnHeader2, "columnHeader2");
    componentResourceManager.ApplyResources((object) this.columnHeader3, "columnHeader3");
    componentResourceManager.ApplyResources((object) this.columnHeader4, "columnHeader4");
    componentResourceManager.ApplyResources((object) this, "$this");
    this.AutoScaleMode = AutoScaleMode.Font;
    this.Controls.Add((Control) this.groupBox1);
    this.Controls.Add((Control) this.grpUser);
    this.FormBorderStyle = FormBorderStyle.FixedDialog;
    this.MaximizeBox = false;
    this.MinimizeBox = false;
    this.Name = nameof (frmUserInfo);
    this.ShowIcon = false;
    this.ShowInTaskbar = false;
    this.TopMost = true;
    this.Load += new EventHandler(this.frmUserInfo_Load);
    this.Shown += new EventHandler(this.frmUserInfo_Shown);
    this.grpUser.ResumeLayout(false);
    this.grpUser.PerformLayout();
    this.groupBox1.ResumeLayout(false);
    this.groupBox1.PerformLayout();
    this.ResumeLayout(false);
  }
}
