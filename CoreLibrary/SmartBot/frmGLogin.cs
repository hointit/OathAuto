// Decompiled with JetBrains decompiler
// Type: SmartBot.frmGLogin
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using BrightIdeasSoftware;
using EXControls;
using GAuto_Auto_None.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace SmartBot;

public class frmGLogin : Form
{
  public static List<LoginProfileClass> paramProfiles = new List<LoginProfileClass>();
  public static object plistLock = new object();
  public static Thread MatchingThread = (Thread) null;
  private int savedCount;
  private bool updateLVFlag;
  private string firstLetter = "";
  private EXListView exlvAllProfiles;
  private long moveStamp;
  private int CurrentSelectIndex = -1;
  public static frmGLogin instance = (frmGLogin) null;
  private long delaySaveList = 2500;
  private long stampSaveList;
  private long stampAgreement;
  private static long stampStatus = 0;
  private long stampAccountLastDrop;
  private Dictionary<string, int> colIndex = new Dictionary<string, int>()
  {
    {
      "AI",
      0
    },
    {
      "entercaptcha",
      5
    },
    {
      "enter",
      7
    }
  };
  private static long delayRetry = 305000;
  private IContainer components;
  private TextBox tboxUsername;
  private ComboBox cboNPH;
  private Button btnThemProfile;
  private Button btnEditProfile;
  private Label label2;
  private Label label9;
  private Label lblAgreement;
  private Label lblAgreementTitle;
  private Label label4;
  private TextBox tboxPassword;
  private CheckBox cboxAgreement;
  private Label label5;
  private Label label6;
  private ComboBox cboServer;
  private Button btnDelProfile;
  private ComboBox cboHopKiem;
  private System.Windows.Forms.Timer timer1;
  private ColumnHeader columnHeader2;
  private ColumnHeader columnHeader1;
  private ColumnHeader columnHeader3;
  private ColumnHeader columnHeader4;
  private ColumnHeader columnHeader5;
  private Label label1;
  private TextBox tboxName;
  private ColumnHeader columnHeader6;
  private ColumnHeader columnHeader7;
  private ColumnHeader columnHeader8;
  private ColumnHeader columnHeader9;
  private ColumnHeader columnHeader10;
  private Label label3;
  private TextBox tboxGameFile;
  private Button btnBrowseVNG;
  private DataGridViewImageColumn dataGridViewImageColumn1;
  private ContextMenuStrip GLoginContextMenu;
  private ToolStripMenuItem mởGameTấtCảCácProfileNàyToolStripMenuItem;
  private OLVColumn colGLogin_Username;
  private OLVColumn colGLogin_Server;
  private OLVColumn colGLogin_TenNV;
  private OLVColumn colGLogin_Captcha;
  private OLVColumn colGLogin_NhapCaptcha;
  private OLVColumn colGLogin_VaoGame;
  private OLVColumn colGLogin_Open;
  private ToolStripSeparator toolStripMenuItem1;
  private ToolStripMenuItem xóaKhỏiDanhSáchToolStripMenuItem;
  public ObjectListView listGLogin;
  private ToolStripMenuItem cậpNhậtĐườngDẫnGameToolStripMenuItem;
  public Label lbStatus;
  public Label lbTotal;
  public Label label7;
  private ToolStripSeparator toolStripMenuItem2;
  private ToolStripMenuItem xếpLênĐầuDanhSáchToolStripMenuItem;
  private ToolStripMenuItem xếpXuốngCuốiDanhSáchToolStripMenuItem;
  private ToolStripSeparator toolStripMenuItem3;
  private ToolStripMenuItem mờiĐộiCảNhómToolStripMenuItem;
  private ToolStripMenuItem triệuTậpCảNhómToolStripMenuItem;
  private ToolStripMenuItem setNhómIDToolStripMenuItem;
  private ToolStripSeparator toolStripMenuItem4;
  private ToolStripMenuItem hiệnGameDoubleClickToolStripMenuItem;
  private ToolStripMenuItem hiệnGameVàThuXuốngTaskbarToolStripMenuItem;
  private ToolStripMenuItem ẩnGameKiểu1ToolStripMenuItem;
  private ToolStripMenuItem ẩnGameKiểu2ToolStripMenuItem;
  private ToolStripMenuItem hiệnGameBịMấtToolStripMenuItem;
  private ToolStripMenuItem thoátGameNhanhToolStripMenuItem;
  private ToolStripMenuItem kickAccountRaKhỏiAutoToolStripMenuItem;
  private OLVColumn colGLogin_AI;
  private ToolStripMenuItem đăngNhậpChạyQToolStripMenuItem;
  private ToolStripMenuItem báchHoaDuyênToolStripMenuItem;

  public frmGLogin()
  {
    this.InitializeComponent();
    if (frmGLogin.MatchingThread == null)
      frmGLogin.StartMatchingThread();
    this.SetupListView();
    if (frmLogin.GAuto.Settings.ListLoginProfile != null)
      this.listGLogin.SetObjects((IEnumerable) frmLogin.GAuto.Settings.ListLoginProfile);
    frmGLogin.instance = this;
  }

  public static void StartMatchingThread()
  {
    frmGLogin.MatchingThread = new Thread(new ThreadStart(frmGLogin.MatchingProfiles));
    frmGLogin.MatchingThread.IsBackground = true;
    frmGLogin.MatchingThread.Start();
  }

  public static void MatchingProfiles()
  {
    while (true)
    {
      if (frmGLogin.paramProfiles.Count > 0)
      {
        int count1 = frmLogin.GAuto.AllAutoAccounts.Count;
        long num1 = frmLogin.GlobalTimer.ElapsedMilliseconds + 300000L;
        long num2 = 0;
        int count2 = frmGLogin.paramProfiles.Count;
        while (frmLogin.GlobalTimer.ElapsedMilliseconds <= num1)
        {
          Thread.Sleep(100);
          bool flag = frmGLogin.paramProfiles.Count > 0;
          if (frmLogin.GAuto.AllAutoAccounts.Count > count1)
          {
            num2 = 0L;
            for (int index1 = frmGLogin.paramProfiles.Count - 1; index1 >= 0; --index1)
            {
              LoginProfileClass paramProfile = frmGLogin.paramProfiles[index1];
              if (paramProfile.retriesStamp == 0L)
              {
                paramProfile.retriesStamp = frmLogin.GlobalTimer.ElapsedMilliseconds + 45000L;
                paramProfile.retries = 0;
              }
              else if (0L <= paramProfile.retriesStamp)
              {
                if (paramProfile.retriesStamp < frmLogin.GlobalTimer.ElapsedMilliseconds)
                {
                  ++paramProfile.retries;
                  if (paramProfile.retries > 1)
                  {
                    frmGLogin.ResetProfile(paramProfile, frmGLogin.paramProfiles);
                    continue;
                  }
                }
              }
              try
              {
                for (int index2 = 0; index2 < frmLogin.GAuto.AllAutoAccounts.Count; ++index2)
                {
                  AutoAccount allAutoAccount = frmLogin.GAuto.AllAutoAccounts[index2];
                  if (allAutoAccount.AutoProfile == null && !allAutoAccount.MyFlag.IsInGame && allAutoAccount.MyFlag.InGameStatus < 2 && string.Equals(allAutoAccount.Target.ProcessExePath, paramProfile.GamePath, StringComparison.OrdinalIgnoreCase))
                  {
                    paramProfile.NeedHandle = true;
                    paramProfile.stampOpenGame = frmGLogin.nowStamp() + 30000L;
                    flag = true;
                    allAutoAccount.AutoProfile = paramProfile;
                    paramProfile.imgCaptcha = (Image) null;
                    paramProfile.retries = 0;
                    paramProfile.retriesStamp = 0L;
                    paramProfile.RefAutoAccount = allAutoAccount;
                    paramProfile.RefAutoAccount.MyFlag.LoginAction = paramProfile.flagAI;
                    paramProfile.ProcessID = paramProfile.RefAutoAccount.Target.ProcessID;
                    if (Monitor.TryEnter(frmGLogin.plistLock, 100))
                    {
                      frmGLogin.paramProfiles.Remove(paramProfile);
                      Monitor.Exit(frmGLogin.plistLock);
                      break;
                    }
                    break;
                  }
                }
              }
              catch (Exception ex)
              {
              }
            }
          }
          else
          {
            if (num2 == 0L)
              num2 = frmLogin.GlobalTimer.ElapsedMilliseconds + 45000L;
            if (frmLogin.GlobalTimer.ElapsedMilliseconds > num2)
            {
              if (frmGLogin.paramProfiles.Count > 0)
              {
                for (int index = frmGLogin.paramProfiles.Count - 1; index >= 0; --index)
                {
                  frmGLogin.paramProfiles[index].NeedHandle = false;
                  frmGLogin.paramProfiles[index].RefAutoAccount = (AutoAccount) null;
                  frmGLogin.paramProfiles[index].retries = 0;
                  frmGLogin.paramProfiles[index].retriesStamp = 0L;
                }
                if (Monitor.TryEnter(frmGLogin.plistLock, 100))
                {
                  frmGLogin.paramProfiles.Clear();
                  Monitor.Exit(frmGLogin.plistLock);
                  break;
                }
                break;
              }
              break;
            }
            flag = true;
          }
          if (!flag && frmLogin.GAuto.AllAutoAccounts.Count - count1 >= count2)
            break;
        }
      }
      Thread.Sleep(100);
    }
  }

  private void SetupListView()
  {
    this.listGLogin.RowHeight = 36;
    this.colGLogin_VaoGame.AspectGetter = (AspectGetterDelegate) (row => row != null ? (object) ((LoginProfileClass) row).GameStarted : (object) false);
    this.colGLogin_VaoGame.Renderer = (IRenderer) new MappedImageRenderer(new object[4]
    {
      (object) true,
      (object) Resources.cbox1,
      (object) false,
      (object) Resources.cbox2
    });
    this.colGLogin_Captcha.ImageGetter = (ImageGetterDelegate) (row =>
    {
      LoginProfileClass loginProfileClass = (LoginProfileClass) row;
      return loginProfileClass.RefAutoAccount != null && loginProfileClass.imgCaptcha != null ? (object) loginProfileClass.imgCaptcha : (object) null;
    });
  }

  private void frmGLogin_Load(object sender, EventArgs e)
  {
    this.colGLogin_VaoGame.AspectGetter = (AspectGetterDelegate) (row =>
    {
      if (row != null)
      {
        LoginProfileClass loginProfileClass = (LoginProfileClass) row;
        if (loginProfileClass.RefAutoAccount != null && loginProfileClass.RefAutoAccount.MyFlag.IsInGame)
          return (object) true;
      }
      return (object) false;
    });
    this.colGLogin_VaoGame.Renderer = (IRenderer) new MappedImageRenderer(new object[4]
    {
      (object) true,
      (object) Resources.cbox1,
      (object) false,
      (object) Resources.cbox2
    });
    this.colGLogin_AI.AspectGetter = (AspectGetterDelegate) (row =>
    {
      if (row != null)
      {
        LoginProfileClass loginProfileClass = (LoginProfileClass) row;
        if (loginProfileClass.RefAutoAccount != null && loginProfileClass.RefAutoAccount.IsAIEnabled)
          return (object) true;
      }
      return (object) false;
    });
    this.colGLogin_AI.Renderer = (IRenderer) new MappedImageRenderer(new object[4]
    {
      (object) true,
      (object) Resources.cbox1,
      (object) false,
      (object) Resources.cbox2
    });
    this.colGLogin_Open.AspectGetter = (AspectGetterDelegate) (row => (object) true);
    this.colGLogin_Open.Renderer = (IRenderer) new MappedImageRenderer(new object[4]
    {
      (object) true,
      (object) Resources.entergame,
      (object) false,
      (object) ""
    });
  }

  private void btnGetCurrentPos_Click(object sender, EventArgs e) => this.RepopulateProfile();

  private void cboNPH_SelectedIndexChanged(object sender, EventArgs e)
  {
  }

  private void cboxAgreement_CheckedChanged(object sender, EventArgs e)
  {
    CheckBox checkBox = sender as CheckBox;
    if (!checkBox.Focused)
      return;
    frmLogin.GAuto.Settings.cboxAgreement = checkBox.Checked;
  }

  private void timer1_Tick(object sender, EventArgs e)
  {
    if (frmLogin.GAuto.Settings.ListLoginProfile.Count != this.savedCount && this.Visible)
    {
      this.savedCount = frmLogin.GAuto.Settings.ListLoginProfile.Count;
      this.lbTotal.Text = string.Format(frmMain.lang_profileTotal, (object) this.savedCount);
    }
    if (!this.cboxAgreement.Focused)
      this.cboxAgreement.Checked = frmLogin.GAuto.Settings.cboxAgreement;
    if (frmLogin.GAuto.Settings.cboxAgreement && this.stampAgreement == 0L)
    {
      this.stampAgreement = frmGLogin.nowStamp() + 1000L;
      this.lblAgreement.ForeColor = Color.RosyBrown;
      this.lblAgreementTitle.ForeColor = Color.RosyBrown;
      this.cboxAgreement.ForeColor = Color.Gainsboro;
      this.cboxAgreement.Enabled = false;
    }
    if (0L < this.stampSaveList && this.stampSaveList <= frmGLogin.nowStamp() && frmLogin.GAuto.Settings.AllInformationLoaded)
    {
      this.stampSaveList = 0L;
      frmGLogin.SetStripStatus("Trạng thái: lưu danh sách profiles...", Color.DarkGreen);
      frmLogin.SaveProfileList((object) frmLogin.GAuto.Settings.ListLoginProfile, "ListLoginProfile");
    }
    if (0L < frmGLogin.stampStatus && frmGLogin.stampStatus <= frmGLogin.nowStamp())
    {
      this.lbStatus.Text = "Trạng thái: sẵn sàng đăng nhập";
      frmGLogin.stampStatus = 0L;
      this.lbStatus.ForeColor = Color.Black;
    }
    if (frmLogin.GAuto.Settings.ListLoginProfile.Count <= 0)
      return;
    for (int index = frmLogin.GAuto.Settings.ListLoginProfile.Count - 1; index >= 0; --index)
    {
      if (frmLogin.GAuto.Settings.ListLoginProfile[index].RefAutoAccount == null && frmLogin.GAuto.Settings.ListLoginProfile[index].imgCaptcha != null)
        frmLogin.GAuto.Settings.ListLoginProfile[index].imgCaptcha = (Image) null;
    }
  }

  private void frmGLogin_Shown(object sender, EventArgs e)
  {
    this.timer1.Enabled = true;
    if (!(frmLogin.GAuto.Settings.CompilingLanguage == "VN"))
    {
      if (frmLogin.GAuto.Settings.CompilingLanguage == "EN")
      {
        this.cboNPH.Items[0] = (object) "D.Oath";
        this.cboNPH.Items[1] = (object) "69Dragon";
        this.cboNPH.Items[2] = (object) "Others";
      }
      else if (frmLogin.GAuto.Settings.CompilingLanguage == "CN")
      {
        this.cboNPH.Items[0] = (object) "CIBMal";
        this.cboNPH.Items[1] = (object) "Changyou";
        this.cboNPH.Items[2] = (object) "Others";
      }
    }
    this.AttachToProfile();
  }

  private void AttachToProfile()
  {
    if (frmLogin.GAuto.AllAutoAccounts.Count <= 0)
      return;
    try
    {
      for (int index1 = frmLogin.GAuto.AllAutoAccounts.Count - 1; index1 >= 0; --index1)
      {
        AutoAccount allAutoAccount = frmLogin.GAuto.AllAutoAccounts[index1];
        for (int index2 = 0; index2 < frmLogin.GAuto.Settings.ListLoginProfile.Count; ++index2)
        {
          LoginProfileClass loginProfileClass = frmLogin.GAuto.Settings.ListLoginProfile[index2];
          if (loginProfileClass.RefAutoAccount == null)
          {
            bool flag1 = false;
            if (allAutoAccount.Myself.Username != "" && string.Compare(allAutoAccount.Myself.Username, loginProfileClass.Username, true) == 0)
              flag1 = true;
            bool flag2 = false;
            if (loginProfileClass.NPHShortName == "VNG" && allAutoAccount.Target.VersionNum <= 2 || loginProfileClass.NPHShortName == "TK" && allAutoAccount.Target.VersionNum == 3 || (loginProfileClass.NPHShortName == "OT" || loginProfileClass.NPHShortName == "Server khác") && allAutoAccount.Target.VersionNum > 3)
              flag2 = true;
            if (flag1 && flag2)
            {
              loginProfileClass.RefAutoAccount = allAutoAccount;
              allAutoAccount.AutoProfile = loginProfileClass;
              allAutoAccount.Target.GLoginAttached = true;
              if (allAutoAccount.Myself.Name != "")
              {
                loginProfileClass.CharName = allAutoAccount.Myself.Name;
                break;
              }
              break;
            }
          }
          else if (loginProfileClass.RefAutoAccount != null && loginProfileClass.RefAutoAccount == allAutoAccount)
            break;
        }
      }
    }
    catch (Exception ex)
    {
      GA.WriteUserLog("Error attaching profile to account. Msg: " + ex.Message);
    }
  }

  private void btnThemProfile_Click(object sender, EventArgs e) => this.SaveProfile();

  private void SaveProfile()
  {
    if (this.tboxUsername.Text != "" && this.tboxPassword.Text != "" && frmLogin.GAuto.Settings.cboxAgreement && this.tboxGameFile.Text != null)
    {
      bool flag1 = false;
      if (this.cboNPH.Text == "Vinagame" && this.cboServer.Text != "")
        flag1 = true;
      if ((this.cboNPH.Text == "Tình Kiếm" || this.cboNPH.Text == "69Dragon") && this.cboServer.Text != "")
        flag1 = true;
      if (this.cboNPH.Text == "D.Oath" && this.cboServer.Text != "")
        flag1 = true;
      if (this.cboNPH.Text == "CIBMal" && this.cboServer.Text != "")
        flag1 = true;
      if (this.cboNPH.Text == "Changyou" && this.cboServer.Text != "")
        flag1 = true;
      if ((this.cboNPH.Text == "Server khác" || this.cboNPH.Text == "Others") && this.cboServer.Text != "")
        flag1 = true;
      if (flag1)
      {
        LoginProfileClass loginProfileClass = new LoginProfileClass();
        loginProfileClass.Username = this.tboxUsername.Text;
        loginProfileClass.Password = GA.ConvertToSecureString(this.tboxPassword.Text);
        loginProfileClass.Server = this.cboServer.Text;
        loginProfileClass.NPH = this.cboNPH.Text;
        loginProfileClass.MinorServer = this.cboHopKiem.Text;
        loginProfileClass.CharName = this.tboxName.Text;
        loginProfileClass.GamePath = this.tboxGameFile.Text;
        bool flag2 = false;
        if (frmLogin.GAuto.Settings.ListLoginProfile.Count > 0)
        {
          for (int index = 0; index < frmLogin.GAuto.Settings.ListLoginProfile.Count; ++index)
          {
            LoginProfileClass modelObject = frmLogin.GAuto.Settings.ListLoginProfile[index];
            if (modelObject.Username == loginProfileClass.Username && modelObject.NPH == loginProfileClass.NPH)
            {
              flag2 = true;
              modelObject.Password = loginProfileClass.Password;
              modelObject.Server = loginProfileClass.Server;
              modelObject.NPH = loginProfileClass.NPH;
              modelObject.MinorServer = loginProfileClass.MinorServer;
              modelObject.CharName = loginProfileClass.CharName;
              modelObject.GamePath = loginProfileClass.GamePath;
              this.listGLogin.UpdateObject((object) modelObject);
              break;
            }
          }
        }
        if (!flag2)
        {
          frmLogin.GAuto.Settings.ListLoginProfile.Add(loginProfileClass);
          this.listGLogin.SetObjects((IEnumerable) frmLogin.GAuto.Settings.ListLoginProfile);
          if (frmLogin.GAuto.Settings.ListLoginProfile.Count > 0)
            this.listGLogin.EnsureVisible(this.listGLogin.GetItemCount() - 1);
        }
        this.stampSaveList = frmGLogin.nowStamp() + this.delaySaveList;
      }
    }
    if (frmLogin.GAuto.Settings.cboxAgreement)
      return;
    if (frmLogin.GAuto.Settings.CompilingLanguage == "VN")
    {
      int num1 = (int) MessageBox.Show("Để sử dụng tính năng này, bạn phải đồng ý với Điều khoản sử dụng", "Điều khoản sử dụng", MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }
    else
    {
      if (!(frmLogin.GAuto.Settings.CompilingLanguage == "EN"))
        return;
      int num2 = (int) MessageBox.Show("To use this feature, you must read and agree the terms of use.", "Terms of use", MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }
  }

  private void btnDelProfile_Click(object sender, EventArgs e) => this.RemoveProfile();

  private void RemoveProfile()
  {
    if (this.listGLogin.SelectedObjects == null || this.listGLogin.SelectedObjects.Count <= 0)
      return;
    int index1 = this.listGLogin.IndexOf(this.listGLogin.SelectedObjects[0]) - 1;
    if (index1 < 0)
      index1 = 0;
    for (int index2 = this.listGLogin.SelectedObjects.Count - 1; index2 >= 0; --index2)
    {
      try
      {
        frmLogin.GAuto.Settings.ListLoginProfile.Remove((LoginProfileClass) this.listGLogin.SelectedObjects[index2]);
      }
      catch (Exception ex)
      {
      }
    }
    this.listGLogin.SetObjects((IEnumerable) frmLogin.GAuto.Settings.ListLoginProfile);
    if (index1 > this.listGLogin.GetItemCount() - 1)
      index1 = this.listGLogin.GetItemCount() - 1;
    if (0 <= index1 && index1 <= this.listGLogin.Items.Count - 1)
    {
      this.listGLogin.SelectedIndex = index1;
      this.listGLogin.EnsureVisible(index1);
    }
    this.stampSaveList = frmGLogin.nowStamp() + this.delaySaveList;
  }

  private void lvAllProfiles_MouseDoubleClick(object sender, MouseEventArgs e)
  {
    if (0L < this.stampAccountLastDrop && this.stampAccountLastDrop < frmGLogin.nowStamp())
      return;
    this.RepopulateProfile();
  }

  private void RepopulateProfile()
  {
    if (this.listGLogin.SelectedObjects == null || this.listGLogin.SelectedObjects.Count <= 0)
      return;
    LoginProfileClass selectedObject = (LoginProfileClass) this.listGLogin.SelectedObjects[0];
    if (selectedObject == null)
      return;
    this.tboxUsername.Text = selectedObject.Username;
    this.tboxPassword.Text = GA.SecureStringToString(selectedObject.Password);
    this.tboxName.Text = selectedObject.CharName;
    this.cboNPH.Text = selectedObject.NPH;
    this.cboServer.Text = selectedObject.Server;
    this.cboHopKiem.Text = selectedObject.MinorServer;
    this.tboxGameFile.Text = selectedObject.GamePath;
  }

  private void btnBrowseVNG_Click(object sender, EventArgs e)
  {
    this.tboxGameFile.Text = this.BrowseGamePath();
  }

  private string BrowseGamePath()
  {
    string str = "";
    OpenFileDialog openFileDialog = new OpenFileDialog();
    openFileDialog.Filter = "TLBB Game.exe | Game.exe";
    if (openFileDialog.ShowDialog() == DialogResult.OK)
      str = openFileDialog.FileName;
    return str;
  }

  private void cboServer_SelectedIndexChanged(object sender, EventArgs e)
  {
  }

  private void cboServer_DropDown(object sender, EventArgs e)
  {
    bool flag = true;
    switch (frmLogin.CompilingLanguage)
    {
      case "VN":
        if (frmLogin.TKServers.Count == 0 || frmLogin.VNGServers.Count == 0 || frmLogin.TKMinorServers.Count == 0)
        {
          flag = false;
          break;
        }
        break;
      case "EN":
        if (frmLogin.TKServers.Count == 0 || frmLogin.TKMinorServers.Count == 0 || frmLogin.TLUSServers.Count == 0)
        {
          flag = false;
          break;
        }
        break;
    }
    if (!(this.cboNPH.Text == "Tình Kiếm") && !(this.cboNPH.Text == "69Dragon"))
    {
      if (this.cboNPH.Text == "Vinagame")
      {
        if (!flag)
          return;
        this.cboServer.BeginUpdate();
        this.cboServer.Items.Clear();
        this.cboServer.Items.AddRange((object[]) frmLogin.VNGServers.ToArray());
        this.cboServer.EndUpdate();
        this.cboHopKiem.Text = "";
      }
      else if (this.cboNPH.Text == "D.Oath")
      {
        if (!flag)
          return;
        this.cboServer.BeginUpdate();
        this.cboServer.Items.Clear();
        this.cboServer.Items.AddRange((object[]) frmLogin.TLUSServers.ToArray());
        this.cboServer.EndUpdate();
        this.cboHopKiem.Text = "";
      }
      else
      {
        if (!(this.cboNPH.Text == "Server khác") && !(this.cboNPH.Text == "Others"))
          return;
        this.cboServer.BeginUpdate();
        this.cboServer.Items.Clear();
        this.cboServer.Items.AddRange((object[]) new List<string>()
        {
          "1",
          "2",
          "3",
          "4",
          "5"
        }.ToArray());
        this.cboServer.EndUpdate();
      }
    }
    else if (flag)
    {
      this.cboServer.BeginUpdate();
      this.cboServer.Items.Clear();
      this.cboServer.Items.AddRange((object[]) frmLogin.TKServers.ToArray());
      this.cboServer.EndUpdate();
    }
    else
      frmMain.GetGLoginServers();
  }

  private void cboHopKiem_SelectedIndexChanged(object sender, EventArgs e)
  {
  }

  private void cboHopKiem_DropDown(object sender, EventArgs e)
  {
    if (this.cboNPH.Text == "Tình Kiếm" || this.cboNPH.Text == "69Dragon")
    {
      this.cboHopKiem.BeginUpdate();
      this.cboHopKiem.Items.Clear();
      this.cboHopKiem.Items.AddRange((object[]) frmLogin.TKMinorServers.ToArray());
      this.cboHopKiem.EndUpdate();
    }
    else
      this.cboHopKiem.Items.Clear();
  }

  private void mởGameTấtCảCácProfileNàyToolStripMenuItem_Click(object sender, EventArgs e)
  {
    frmGLogin.OpenGame();
  }

  private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
  {
  }

  private void GLoginContextMenu_Opening(object sender, CancelEventArgs e)
  {
  }

  private void gửiMãCaptchaChoCácProfileNàyToolStripMenuItem_Click(object sender, EventArgs e)
  {
    frmGLogin.OpenGame();
  }

  private void listGLogin_CellEditStarting(object sender, CellEditEventArgs e)
  {
    if (e.SubItemIndex != this.colIndex["entercaptcha"] || e.RowObject == null || ((LoginProfileClass) e.RowObject).RefAutoAccount == null)
      return;
    TextBox textBox = new TextBox();
    textBox.Bounds = e.CellBounds;
    textBox.Multiline = true;
    textBox.Font = new Font("Microsoft Sans Serif", 16f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    textBox.Text = this.firstLetter;
    textBox.Select(textBox.Text.Length, 0);
    e.Control = (Control) textBox;
  }

  private void listGLogin_CellClick(object sender, CellClickEventArgs e)
  {
    if (this.stampAccountLastDrop != 0L && (0L >= this.stampAccountLastDrop || this.stampAccountLastDrop >= frmGLogin.nowStamp()))
      return;
    if (e.ClickCount == 2)
    {
      if (e.ColumnIndex < 0 || e.RowIndex < 0)
        return;
      this.RepopulateProfile();
    }
    else if (e.ColumnIndex == this.colIndex["AI"])
    {
      LoginProfileClass model = (LoginProfileClass) e.Model;
      if (model == null || model.RefAutoAccount == null)
        return;
      if (e.Item.Text == "True")
        F.UncheckAI(model.RefAutoAccount);
      else
        F.CheckAI(model.RefAutoAccount);
    }
    else
    {
      if (e.ColumnIndex != this.colIndex["enter"])
        return;
      frmGLogin.OpenGame((LoginProfileClass) e.Model);
    }
  }

  private void RefreshCaptchaProfile(LoginProfileClass tempProfile)
  {
    if (tempProfile.clickCaptchaStamp > frmGLogin.nowStamp())
      return;
    tempProfile.clickCaptchaStamp = frmGLogin.nowStamp() + 1000L;
    if (tempProfile.RefAutoAccount == null || tempProfile.RefAutoAccount.MyFlag.IsInGame)
      return;
    tempProfile.RefAutoAccount.CallInterfaceClick(20);
  }

  public static long nowStamp() => frmLogin.GlobalTimer.ElapsedMilliseconds;

  private void listGLogin_ButtonClick(object sender, CellClickEventArgs e)
  {
  }

  private void listGLogin_SelectionChanged(object sender, EventArgs e)
  {
  }

  private void listGLogin_SelectedIndexChanged(object sender, EventArgs e)
  {
  }

  private void listGLogin_KeyPress(object sender, KeyPressEventArgs e)
  {
    if (e.KeyChar != '\r')
    {
      if ('0' > e.KeyChar || e.KeyChar > '9' || this.listGLogin.SelectedObject == null)
        return;
      LoginProfileClass selectedObject = (LoginProfileClass) this.listGLogin.SelectedObject;
      if (selectedObject.RefAutoAccount == null || selectedObject.RefAutoAccount.MyFlag.IsInGame || selectedObject.imgCaptcha == null)
        return;
      this.firstLetter = e.KeyChar.ToString();
      this.listGLogin.EditSubItem(this.listGLogin.ModelToItem((object) selectedObject), this.colIndex["entercaptcha"]);
    }
    else
    {
      int index1 = this.listGLogin.SelectedIndex;
      if (-1 < index1 && index1 < this.listGLogin.Items.Count - 1)
        ++index1;
      if (this.listGLogin.SelectedObjects != null && this.listGLogin.SelectedObjects.Count > 0)
      {
        for (int index2 = 0; index2 < this.listGLogin.SelectedObjects.Count; ++index2)
        {
          LoginProfileClass selectedObject = (LoginProfileClass) this.listGLogin.SelectedObjects[index2];
          if (selectedObject.captchaCode == "" && selectedObject.RefAutoAccount != null && !selectedObject.RefAutoAccount.MyFlag.IsInGame)
            this.RefreshCaptchaProfile(selectedObject);
          index1 = this.listGLogin.IndexOf((object) selectedObject);
        }
        if (-1 < index1 && index1 < this.listGLogin.Items.Count - 1)
          ++index1;
      }
      this.listGLogin.SelectedIndex = index1;
      this.listGLogin.FocusedItem = this.listGLogin.SelectedItems[0];
      if (index1 <= this.listGLogin.Items.Count - 1)
        this.listGLogin.EnsureVisible(index1);
      else
        this.listGLogin.EnsureVisible(this.listGLogin.Items.Count - 1);
    }
  }

  private void listGLogin_CellEditFinished(object sender, CellEditEventArgs e)
  {
    this.firstLetter = "";
    e.Cancel = true;
    e.AutoDispose = true;
    e.Control = (Control) null;
    if (e.NewValue == null || e.SubItemIndex != this.colIndex["entercaptcha"])
      return;
    string str = e.NewValue.ToString();
    bool flag1 = GA.IsDigitsOnly(str);
    LoginProfileClass rowObject = (LoginProfileClass) e.RowObject;
    bool flag2 = false;
    if (rowObject != null && rowObject.RefAutoAccount != null && !rowObject.RefAutoAccount.MyFlag.IsInGame)
      flag2 = true;
    if (str.Length == 4 && flag1 && flag2)
      frmGLogin.SendCaptcha((LoginProfileClass) e.RowObject);
    else if (flag2 && string.IsNullOrEmpty(e.NewValue.ToString()))
      this.RefreshCaptchaProfile(rowObject);
    int num = this.listGLogin.IndexOf((object) rowObject);
    if (num >= this.listGLogin.Items.Count - 1)
      return;
    this.listGLogin.SelectedIndex = num + 1;
    LoginProfileClass modelObject = (LoginProfileClass) this.listGLogin.GetModelObject(num + 1);
    if (modelObject == null || modelObject.RefAutoAccount == null || modelObject.RefAutoAccount.MyFlag.IsInGame)
      return;
    this.listGLogin.SelectedIndex = this.listGLogin.IndexOf((object) modelObject);
    this.listGLogin.FocusedItem = this.listGLogin.SelectedItems[0];
    if (0 <= this.listGLogin.SelectedIndex && this.listGLogin.SelectedIndex <= this.listGLogin.Items.Count - 1)
      this.listGLogin.EnsureVisible(this.listGLogin.SelectedIndex);
    else
      this.listGLogin.EnsureVisible(this.listGLogin.Items.Count - 1);
  }

  public static void OpenGame(LoginProfileClass profile = null, int _flagAI = -1)
  {
    List<LoginProfileClass> myList = new List<LoginProfileClass>();
    if (profile != null)
    {
      profile.flagAI = _flagAI;
      myList.Add(profile);
    }
    else if (frmGLogin.instance.listGLogin.SelectedObjects != null && frmGLogin.instance.listGLogin.SelectedObjects.Count > 0)
    {
      for (int index = 0; index < frmGLogin.instance.listGLogin.SelectedObjects.Count; ++index)
      {
        LoginProfileClass selectedObject = (LoginProfileClass) frmGLogin.instance.listGLogin.SelectedObjects[index];
        if (selectedObject != null)
        {
          selectedObject.flagAI = _flagAI;
          myList.Add(selectedObject);
        }
      }
    }
    List<string> stringList = new List<string>();
    if (myList.Count <= 0)
      return;
    for (int index1 = myList.Count - 1; index1 >= 0; --index1)
    {
      profile = myList[index1];
      bool fileExist = false;
      if (stringList.Count > 0)
      {
        for (int index2 = 0; index2 < stringList.Count; ++index2)
        {
          if (stringList[index2] == profile.GamePath)
          {
            fileExist = true;
            break;
          }
        }
      }
      if (!fileExist && File.Exists(profile.GamePath))
      {
        if (!stringList.Contains(profile.GamePath))
          stringList.Add(profile.GamePath);
        fileExist = true;
      }
      if (frmGLogin.StartGameProcess(profile, myList, fileExist) && Monitor.TryEnter(frmGLogin.plistLock, 200))
      {
        frmGLogin.paramProfiles.Add(profile);
        Monitor.Exit(frmGLogin.plistLock);
      }
    }
  }

  private static bool StartGameProcess(
    LoginProfileClass profile,
    List<LoginProfileClass> myList,
    bool fileExist = false)
  {
    bool flag = true;
    if (!fileExist && File.Exists(profile.GamePath))
      fileExist = true;
    if (fileExist)
    {
      if (!frmGLogin.SetupAndStartGame(profile))
      {
        frmGLogin.ResetProfile(profile, myList);
        flag = false;
      }
    }
    else
    {
      frmGLogin.ResetProfile(profile, myList);
      flag = false;
    }
    return flag;
  }

  private static void ResetProfile(
    LoginProfileClass profile,
    List<LoginProfileClass> myList,
    bool toRemove = true)
  {
    profile.NeedHandle = false;
    profile.retries = 0;
    profile.retriesStamp = 0L;
    if (!toRemove || !Monitor.TryEnter(frmGLogin.plistLock, 200))
      return;
    myList.Remove(profile);
    Monitor.Exit(frmGLogin.plistLock);
  }

  public static bool SetupAndStartGame(LoginProfileClass profile)
  {
    if (profile == null || !frmGLogin.CheckProfile(profile))
      return false;
    frmMain.RunGameEXE(1, profile.GamePath, profile.GamePath.Remove(profile.GamePath.LastIndexOf("\\"), 9));
    return true;
  }

  private static bool CheckProfile(LoginProfileClass profile, bool openGame = true)
  {
    bool flag = true;
    if (profile.RefAutoAccount != null)
    {
      if (openGame)
      {
        IntPtr zero = IntPtr.Zero;
        try
        {
          IntPtr hProcess = MyDLL.OpenProcess(33554432U /*0x02000000*/, 0, (uint) profile.RefAutoAccount.Target.ProcessID);
          if (hProcess != IntPtr.Zero)
          {
            StringBuilder lpBaseName = new StringBuilder((int) byte.MaxValue);
            if (MyDLL.GetModuleFileNameEx(hProcess, IntPtr.Zero, lpBaseName, (int) byte.MaxValue) > 0U)
              flag = false;
          }
        }
        catch (Exception ex)
        {
        }
      }
      if (flag && profile.RefAutoAccount.MyFlag.IsInGame)
        flag = false;
      if (flag)
      {
        profile.IsHandled = false;
        profile.NeedHandle = false;
      }
      if (profile.stampOpenGame <= frmGLogin.nowStamp())
      {
        if (flag)
        {
          try
          {
            profile.RefAutoAccount.AutoProfile = (LoginProfileClass) null;
          }
          catch (Exception ex)
          {
          }
          profile.RefAutoAccount = (AutoAccount) null;
          profile.imgCaptcha = (Image) null;
        }
      }
    }
    return flag;
  }

  public static void SendCaptcha(LoginProfileClass tempProfile)
  {
    if (tempProfile.RefAutoAccount == null || tempProfile.RefAutoAccount.MyFlag.IsInGame || tempProfile.imgCaptcha == null || !(tempProfile.captchaCode != "") || !(tempProfile.captchaCode != "Code...") || !GA.IsDigitsOnly(tempProfile.captchaCode))
      return;
    GA.SendMyString(tempProfile.RefAutoAccount.Target.MainWindowHandle, tempProfile.captchaCode);
    GA.SendMyKey(tempProfile.RefAutoAccount.Target.MainWindowHandle, 13);
    Thread.Sleep(100);
    tempProfile.RefAutoAccount.CallInterfaceClick(29);
    tempProfile.captchaCode = "";
    tempProfile.imgCaptcha = (Image) null;
  }

  private void listGLogin_MouseClick(object sender, MouseEventArgs e)
  {
    if (e.Button == MouseButtons.Right)
    {
      this.GLoginContextMenu.Show((Control) this.listGLogin, e.Location);
    }
    else
    {
      int button = (int) e.Button;
    }
  }

  private void listGLogin_MouseDoubleClick(object sender, MouseEventArgs e)
  {
  }

  private void đổiThôngTinToolStripMenuItem_Click(object sender, EventArgs e)
  {
    this.RepopulateProfile();
  }

  private void xóaKhỏiDanhSáchToolStripMenuItem_Click(object sender, EventArgs e)
  {
    this.RemoveProfile();
  }

  private void cậpNhậtĐườngDẫnGameToolStripMenuItem_Click(object sender, EventArgs e)
  {
    if (this.listGLogin.SelectedObjects == null || this.listGLogin.SelectedObjects.Count <= 0)
      return;
    string str = this.BrowseGamePath();
    if (!(str != ""))
      return;
    for (int index = 0; index < this.listGLogin.SelectedObjects.Count; ++index)
      ((LoginProfileClass) this.listGLogin.SelectedObjects[index]).GamePath = str;
    this.stampSaveList = frmGLogin.nowStamp() + this.delaySaveList;
  }

  public static void SetStripStatus(string text, Color color, int delay = 5000)
  {
    frmGLogin.instance.lbStatus.Invoke((Delegate) (() =>
    {
      frmGLogin.instance.lbStatus.Text = text;
      frmGLogin.instance.lbStatus.ForeColor = color;
      if (delay <= 1000)
        delay = 5000;
      frmGLogin.stampStatus = frmGLogin.nowStamp() + (long) delay;
    }));
  }

  private void lbStatus_Click(object sender, EventArgs e)
  {
  }

  private void frmGLogin_FormClosing(object sender, FormClosingEventArgs e)
  {
    e.Cancel = true;
    this.Hide();
  }

  private void listGLogin_CanDrop(object sender, OlvDropEventArgs e)
  {
    OLVDataObject dataObject = (OLVDataObject) e.DataObject;
    bool flag1 = true;
    if (dataObject.ModelObjects.Count > 0)
    {
      int num1 = -1;
      try
      {
        foreach (LoginProfileClass modelObject in (IEnumerable) dataObject.ModelObjects)
        {
          if (num1 == -1)
            num1 = frmLogin.GAuto.Settings.ListLoginProfile.IndexOf(modelObject);
          int num2 = frmLogin.GAuto.Settings.ListLoginProfile.IndexOf(modelObject);
          if (Math.Abs(num1 - num2) > 1)
          {
            flag1 = false;
            break;
          }
          num1 = num2;
        }
      }
      catch (Exception ex)
      {
        e.Effect = DragDropEffects.None;
        return;
      }
    }
    bool flag2 = false;
    if (0 <= e.DropTargetIndex && e.DropTargetIndex < this.listGLogin.Items.Count)
      flag2 = true;
    int num = this.listGLogin.Items.Count - e.DropTargetIndex;
    if (dataObject.ModelObjects.Count > 0 && dataObject.ModelObjects.Count <= num && flag2 && flag1)
    {
      e.Effect = DragDropEffects.Move;
    }
    else
    {
      if (!flag1)
        e.InfoMessage = frmMain.lang_infoCannotMove;
      e.Effect = DragDropEffects.None;
    }
  }

  private void listGLogin_Dropped(object sender, OlvDropEventArgs e)
  {
    OLVDataObject dataObject = (OLVDataObject) e.DataObject;
    if (dataObject.ModelObjects.Count > 0)
    {
      int count = this.listGLogin.Items.Count;
      int num1 = frmLogin.GAuto.Settings.ListLoginProfile.IndexOf((LoginProfileClass) dataObject.ModelObjects[0]);
      LoginProfileClass modelObject1 = (LoginProfileClass) this.listGLogin.GetModelObject(e.DropTargetIndex);
      int num2 = frmLogin.GAuto.Settings.ListLoginProfile.IndexOf(modelObject1);
      if (num2 < num1)
      {
        try
        {
          for (int index1 = dataObject.ModelObjects.Count - 1; index1 >= 0; --index1)
          {
            LoginProfileClass modelObject2 = (LoginProfileClass) dataObject.ModelObjects[index1];
            frmLogin.GAuto.Settings.ListLoginProfile.IndexOf(modelObject2);
            int index2 = num2 == 0 ? 0 : num2;
            frmLogin.GAuto.Settings.ListLoginProfile.Remove(modelObject2);
            frmLogin.GAuto.Settings.ListLoginProfile.Insert(index2, modelObject2);
          }
        }
        catch (Exception ex)
        {
        }
      }
      else if (num2 > num1)
      {
        try
        {
          for (int index3 = 0; index3 < dataObject.ModelObjects.Count; ++index3)
          {
            LoginProfileClass modelObject3 = (LoginProfileClass) dataObject.ModelObjects[index3];
            frmLogin.GAuto.Settings.ListLoginProfile.IndexOf(modelObject3);
            int index4 = num2 == count - 1 ? count - 1 : num2;
            frmLogin.GAuto.Settings.ListLoginProfile.Remove(modelObject3);
            frmLogin.GAuto.Settings.ListLoginProfile.Insert(index4, modelObject3);
          }
        }
        catch (Exception ex)
        {
        }
      }
      e.Handled = true;
    }
    if (e.Handled)
    {
      this.listGLogin.SetObjects((IEnumerable) frmLogin.GAuto.Settings.ListLoginProfile);
      this.stampSaveList = frmGLogin.nowStamp() + this.delaySaveList;
      if (this.listGLogin.Items.Count > 0)
        this.listGLogin.EnsureVisible(e.DropTargetIndex);
      this.listGLogin.SelectObjects(dataObject.ModelObjects);
      this.listGLogin.FocusedObject = dataObject.ModelObjects[0];
    }
    this.stampAccountLastDrop = frmGLogin.nowStamp() + 50L;
  }

  private void xếpLênĐầuDanhSáchToolStripMenuItem_Click(object sender, EventArgs e)
  {
    if (this.listGLogin.SelectedObjects.Count <= 0)
      return;
    for (int index = this.listGLogin.SelectedObjects.Count - 1; index >= 0; --index)
    {
      LoginProfileClass selectedObject = (LoginProfileClass) this.listGLogin.SelectedObjects[index];
      frmLogin.GAuto.Settings.ListLoginProfile.Remove(selectedObject);
      frmLogin.GAuto.Settings.ListLoginProfile.Insert(0, selectedObject);
    }
    this.listGLogin.SetObjects((IEnumerable) frmLogin.GAuto.Settings.ListLoginProfile);
    this.listGLogin.SelectedIndex = 0;
    this.listGLogin.EnsureVisible(0);
    this.stampSaveList = frmGLogin.nowStamp() + this.delaySaveList;
  }

  private void xếpXuốngCuốiDanhSáchToolStripMenuItem_Click(object sender, EventArgs e)
  {
    if (this.listGLogin.SelectedObjects.Count <= 0)
      return;
    for (int index = this.listGLogin.SelectedObjects.Count - 1; index >= 0; --index)
    {
      LoginProfileClass selectedObject = (LoginProfileClass) this.listGLogin.SelectedObjects[index];
      frmLogin.GAuto.Settings.ListLoginProfile.Remove(selectedObject);
      frmLogin.GAuto.Settings.ListLoginProfile.Insert(frmLogin.GAuto.Settings.ListLoginProfile.Count, selectedObject);
    }
    this.listGLogin.SetObjects((IEnumerable) frmLogin.GAuto.Settings.ListLoginProfile);
    this.listGLogin.SelectedIndex = this.listGLogin.Items.Count - 1;
    this.listGLogin.EnsureVisible(this.listGLogin.Items.Count - 1);
    this.stampSaveList = frmGLogin.nowStamp() + this.delaySaveList;
  }

  private void frmGLogin_KeyPress(object sender, KeyPressEventArgs e)
  {
  }

  private void frmGLogin_KeyDown(object sender, KeyEventArgs e)
  {
    if (this.listGLogin.Focused || e.KeyCode != Keys.Up && e.KeyCode != Keys.Down)
      return;
    int index = this.listGLogin.SelectedIndex;
    if (e.KeyCode == Keys.Up)
      --index;
    else if (e.KeyCode == Keys.Down)
      ++index;
    if (index < 0)
      index = 0;
    if (index > this.listGLogin.Items.Count - 1)
      index = this.listGLogin.Items.Count - 1;
    if (0 <= index && index <= this.listGLogin.Items.Count - 1)
    {
      this.listGLogin.Focus();
      this.listGLogin.SelectedIndex = index;
      this.listGLogin.FocusedItem = this.listGLogin.SelectedItems[0];
      if (index <= this.listGLogin.Items.Count - 1)
        this.listGLogin.EnsureVisible(index);
      else
        this.listGLogin.EnsureVisible(this.listGLogin.Items.Count - 1);
    }
    e.SuppressKeyPress = true;
  }

  private void mờiĐộiCảNhómToolStripMenuItem_Click(object sender, EventArgs e)
  {
    if (this.listGLogin.SelectedObject == null)
      return;
    LoginProfileClass selectedObject = (LoginProfileClass) this.listGLogin.SelectedObject;
    if (selectedObject.RefAutoAccount == null || !selectedObject.RefAutoAccount.MyFlag.IsInGame)
      return;
    F.MoiDoiCaNhom(selectedObject.RefAutoAccount);
  }

  private void triệuTậpCảNhómToolStripMenuItem_Click(object sender, EventArgs e)
  {
    if (this.listGLogin.SelectedObject == null)
      return;
    LoginProfileClass selectedObject = (LoginProfileClass) this.listGLogin.SelectedObject;
    if (selectedObject.RefAutoAccount == null || !selectedObject.RefAutoAccount.MyFlag.IsInGame)
      return;
    F.TrieuTapCaNhom(selectedObject.RefAutoAccount);
  }

  private void setNhómIDToolStripMenuItem_Click(object sender, EventArgs e)
  {
    List<AutoAccount> activeAccounts = this.GetActiveAccounts();
    if (activeAccounts.Count <= 0)
      return;
    F.SetNhomID(activeAccounts);
  }

  private List<AutoAccount> GetActiveAccounts()
  {
    List<AutoAccount> activeAccounts = new List<AutoAccount>();
    if (this.listGLogin.SelectedObjects != null && this.listGLogin.SelectedObjects.Count > 0)
    {
      for (int index = 0; index < this.listGLogin.SelectedObjects.Count; ++index)
      {
        LoginProfileClass selectedObject = (LoginProfileClass) this.listGLogin.SelectedObjects[index];
        if (selectedObject != null && selectedObject.RefAutoAccount != null)
          activeAccounts.Add(selectedObject.RefAutoAccount);
      }
    }
    return activeAccounts;
  }

  private void hiệnGameDoubleClickToolStripMenuItem_Click(object sender, EventArgs e)
  {
    List<AutoAccount> activeAccounts = this.GetActiveAccounts();
    if (activeAccounts.Count <= 0)
      return;
    F.HienGame(activeAccounts);
  }

  private void hiệnGameVàThuXuốngTaskbarToolStripMenuItem_Click(object sender, EventArgs e)
  {
    List<AutoAccount> activeAccounts = this.GetActiveAccounts();
    if (activeAccounts.Count <= 0)
      return;
    F.ShowHideToTaskBar(activeAccounts);
  }

  private void ẩnGameKiểu1ToolStripMenuItem_Click(object sender, EventArgs e)
  {
    List<AutoAccount> activeAccounts = this.GetActiveAccounts();
    if (activeAccounts.Count <= 0)
      return;
    F.HideMyWindow(activeAccounts);
  }

  private void ẩnGameKiểu2ToolStripMenuItem_Click(object sender, EventArgs e)
  {
    List<AutoAccount> activeAccounts = this.GetActiveAccounts();
    if (activeAccounts.Count <= 0)
      return;
    F.HideMyWindow(activeAccounts, 1);
  }

  private void hiệnGameBịMấtToolStripMenuItem_Click(object sender, EventArgs e)
  {
    List<AutoAccount> activeAccounts = this.GetActiveAccounts();
    if (activeAccounts.Count <= 0)
      return;
    F.HienGameBiMat(activeAccounts);
  }

  private void thoátGameNhanhToolStripMenuItem_Click(object sender, EventArgs e)
  {
    List<AutoAccount> activeAccounts = this.GetActiveAccounts();
    if (activeAccounts.Count <= 0)
      return;
    F.ThoatGameNhanh(activeAccounts);
  }

  private void kickAccountRaKhỏiAutoToolStripMenuItem_Click(object sender, EventArgs e)
  {
    List<AutoAccount> activeAccounts = this.GetActiveAccounts();
    if (activeAccounts.Count <= 0)
      return;
    F.KickAccAuto(activeAccounts);
  }

  private void tboxUsername_KeyPress(object sender, KeyPressEventArgs e) => this.InputKeyPress(e);

  private void InputKeyPress(KeyPressEventArgs e)
  {
    if (e.KeyChar != '\r' && e.KeyChar != '\r')
      return;
    this.SaveProfile();
  }

  public static void StartNewGameForProfile(LoginProfileClass profile)
  {
    if (!frmLogin.GAuto.Settings.optStartNewGame || !File.Exists(profile.GamePath))
      return;
    using (Process process = Process.Start(new ProcessStartInfo()
    {
      FileName = profile.GamePath,
      Arguments = "-fl",
      WorkingDirectory = profile.GamePath.Remove(profile.GamePath.LastIndexOf("\\"), 9)
    }))
    {
      if (!process.WaitForInputIdle(60000))
        return;
      profile.ProcessID = process.Id;
      long num1 = frmLogin.GlobalTimer.ElapsedMilliseconds + 30000L;
      long num2 = 0;
      bool flag = false;
      while (frmLogin.GlobalTimer.ElapsedMilliseconds <= num1)
      {
        Thread.Sleep(100);
        if (num2 <= frmLogin.GlobalTimer.ElapsedMilliseconds)
        {
          num2 = frmLogin.GlobalTimer.ElapsedMilliseconds + 1000L;
          if (frmLogin.GAuto.AllAutoAccounts.Count > 0)
          {
            try
            {
              for (int index = frmLogin.GAuto.AllAutoAccounts.Count - 1; index >= 0; --index)
              {
                if (frmLogin.GAuto.AllAutoAccounts[index].AutoProfile == null)
                  flag = true;
                if (!frmLogin.GAuto.AllAutoAccounts[index].MyFlag.IsInGame)
                  flag = true;
                if (frmLogin.GAuto.AllAutoAccounts[index].Target != null && frmLogin.GAuto.AllAutoAccounts[index].Target.ProcessID == profile.ProcessID && flag)
                {
                  profile.imgCaptcha = (Image) null;
                  frmLogin.GAuto.AllAutoAccounts[index].AutoProfile = profile;
                  profile.RefAutoAccount = frmLogin.GAuto.AllAutoAccounts[index];
                  profile.RefAutoAccount.MyFlag.LoginAction = profile.flagAI;
                  num1 = 0L;
                  break;
                }
              }
            }
            catch (Exception ex)
            {
            }
          }
        }
        if (num1 == 0L)
          break;
      }
    }
  }

  private void tboxPassword_KeyPress(object sender, KeyPressEventArgs e) => this.InputKeyPress(e);

  private void tboxName_KeyPress(object sender, KeyPressEventArgs e) => this.InputKeyPress(e);

  private void tboxGameFile_KeyPress(object sender, KeyPressEventArgs e) => this.InputKeyPress(e);

  private void cboNPH_KeyPress(object sender, KeyPressEventArgs e) => this.InputKeyPress(e);

  private void cboServer_KeyPress(object sender, KeyPressEventArgs e) => this.InputKeyPress(e);

  private void cboHopKiem_KeyPress(object sender, KeyPressEventArgs e) => this.InputKeyPress(e);

  private void báchHoaDuyênToolStripMenuItem_Click(object sender, EventArgs e)
  {
    frmGLogin.OpenGame(_flagAI: 1);
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
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmGLogin));
    this.tboxUsername = new TextBox();
    this.cboNPH = new ComboBox();
    this.btnThemProfile = new Button();
    this.btnEditProfile = new Button();
    this.label2 = new Label();
    this.label9 = new Label();
    this.lblAgreement = new Label();
    this.lblAgreementTitle = new Label();
    this.label4 = new Label();
    this.tboxPassword = new TextBox();
    this.cboxAgreement = new CheckBox();
    this.label5 = new Label();
    this.label6 = new Label();
    this.cboServer = new ComboBox();
    this.btnDelProfile = new Button();
    this.cboHopKiem = new ComboBox();
    this.timer1 = new System.Windows.Forms.Timer(this.components);
    this.label1 = new Label();
    this.tboxName = new TextBox();
    this.columnHeader1 = new ColumnHeader();
    this.columnHeader2 = new ColumnHeader();
    this.columnHeader3 = new ColumnHeader();
    this.columnHeader4 = new ColumnHeader();
    this.columnHeader5 = new ColumnHeader();
    this.label3 = new Label();
    this.tboxGameFile = new TextBox();
    this.btnBrowseVNG = new Button();
    this.dataGridViewImageColumn1 = new DataGridViewImageColumn();
    this.GLoginContextMenu = new ContextMenuStrip(this.components);
    this.mởGameTấtCảCácProfileNàyToolStripMenuItem = new ToolStripMenuItem();
    this.đăngNhậpChạyQToolStripMenuItem = new ToolStripMenuItem();
    this.báchHoaDuyênToolStripMenuItem = new ToolStripMenuItem();
    this.toolStripMenuItem1 = new ToolStripSeparator();
    this.cậpNhậtĐườngDẫnGameToolStripMenuItem = new ToolStripMenuItem();
    this.xóaKhỏiDanhSáchToolStripMenuItem = new ToolStripMenuItem();
    this.toolStripMenuItem2 = new ToolStripSeparator();
    this.xếpLênĐầuDanhSáchToolStripMenuItem = new ToolStripMenuItem();
    this.xếpXuốngCuốiDanhSáchToolStripMenuItem = new ToolStripMenuItem();
    this.toolStripMenuItem3 = new ToolStripSeparator();
    this.mờiĐộiCảNhómToolStripMenuItem = new ToolStripMenuItem();
    this.triệuTậpCảNhómToolStripMenuItem = new ToolStripMenuItem();
    this.setNhómIDToolStripMenuItem = new ToolStripMenuItem();
    this.toolStripMenuItem4 = new ToolStripSeparator();
    this.hiệnGameDoubleClickToolStripMenuItem = new ToolStripMenuItem();
    this.hiệnGameVàThuXuốngTaskbarToolStripMenuItem = new ToolStripMenuItem();
    this.ẩnGameKiểu1ToolStripMenuItem = new ToolStripMenuItem();
    this.ẩnGameKiểu2ToolStripMenuItem = new ToolStripMenuItem();
    this.hiệnGameBịMấtToolStripMenuItem = new ToolStripMenuItem();
    this.thoátGameNhanhToolStripMenuItem = new ToolStripMenuItem();
    this.kickAccountRaKhỏiAutoToolStripMenuItem = new ToolStripMenuItem();
    this.listGLogin = new ObjectListView();
    this.colGLogin_AI = new OLVColumn();
    this.colGLogin_Username = new OLVColumn();
    this.colGLogin_TenNV = new OLVColumn();
    this.colGLogin_Server = new OLVColumn();
    this.colGLogin_Captcha = new OLVColumn();
    this.colGLogin_NhapCaptcha = new OLVColumn();
    this.colGLogin_VaoGame = new OLVColumn();
    this.colGLogin_Open = new OLVColumn();
    this.columnHeader6 = new ColumnHeader();
    this.columnHeader7 = new ColumnHeader();
    this.columnHeader8 = new ColumnHeader();
    this.columnHeader9 = new ColumnHeader();
    this.columnHeader10 = new ColumnHeader();
    this.lbStatus = new Label();
    this.lbTotal = new Label();
    this.label7 = new Label();
    this.GLoginContextMenu.SuspendLayout();
    ((ISupportInitialize) this.listGLogin).BeginInit();
    this.SuspendLayout();
    this.tboxUsername.BackColor = Color.FromArgb(206, 233, 253);
    this.tboxUsername.ForeColor = Color.Maroon;
    componentResourceManager.ApplyResources((object) this.tboxUsername, "tboxUsername");
    this.tboxUsername.Name = "tboxUsername";
    this.tboxUsername.KeyPress += new KeyPressEventHandler(this.tboxUsername_KeyPress);
    this.cboNPH.BackColor = Color.FromArgb(206, 233, 253);
    this.cboNPH.DropDownWidth = 186;
    componentResourceManager.ApplyResources((object) this.cboNPH, "cboNPH");
    this.cboNPH.FormattingEnabled = true;
    this.cboNPH.Items.AddRange(new object[3]
    {
      (object) componentResourceManager.GetString("cboNPH.Items"),
      (object) componentResourceManager.GetString("cboNPH.Items1"),
      (object) componentResourceManager.GetString("cboNPH.Items2")
    });
    this.cboNPH.Name = "cboNPH";
    this.cboNPH.SelectedIndexChanged += new EventHandler(this.cboNPH_SelectedIndexChanged);
    this.cboNPH.KeyPress += new KeyPressEventHandler(this.cboNPH_KeyPress);
    this.btnThemProfile.BackColor = Color.FromArgb(210, 249, 213);
    this.btnThemProfile.ForeColor = Color.DarkGreen;
    componentResourceManager.ApplyResources((object) this.btnThemProfile, "btnThemProfile");
    this.btnThemProfile.Name = "btnThemProfile";
    this.btnThemProfile.UseVisualStyleBackColor = false;
    this.btnThemProfile.Click += new EventHandler(this.btnThemProfile_Click);
    componentResourceManager.ApplyResources((object) this.btnEditProfile, "btnEditProfile");
    this.btnEditProfile.BackColor = Color.FromArgb(247, 207, 142);
    this.btnEditProfile.ForeColor = Color.Black;
    this.btnEditProfile.Name = "btnEditProfile";
    this.btnEditProfile.UseVisualStyleBackColor = false;
    this.btnEditProfile.Click += new EventHandler(this.btnGetCurrentPos_Click);
    componentResourceManager.ApplyResources((object) this.label2, "label2");
    this.label2.Name = "label2";
    componentResourceManager.ApplyResources((object) this.label9, "label9");
    this.label9.Name = "label9";
    componentResourceManager.ApplyResources((object) this.lblAgreement, "lblAgreement");
    this.lblAgreement.ForeColor = Color.DarkRed;
    this.lblAgreement.Name = "lblAgreement";
    componentResourceManager.ApplyResources((object) this.lblAgreementTitle, "lblAgreementTitle");
    this.lblAgreementTitle.ForeColor = Color.Red;
    this.lblAgreementTitle.Name = "lblAgreementTitle";
    componentResourceManager.ApplyResources((object) this.label4, "label4");
    this.label4.Name = "label4";
    this.tboxPassword.BackColor = Color.FromArgb(206, 233, 253);
    this.tboxPassword.ForeColor = Color.Maroon;
    componentResourceManager.ApplyResources((object) this.tboxPassword, "tboxPassword");
    this.tboxPassword.Name = "tboxPassword";
    this.tboxPassword.KeyPress += new KeyPressEventHandler(this.tboxPassword_KeyPress);
    componentResourceManager.ApplyResources((object) this.cboxAgreement, "cboxAgreement");
    this.cboxAgreement.BackColor = Color.Transparent;
    this.cboxAgreement.ForeColor = Color.Black;
    this.cboxAgreement.Name = "cboxAgreement";
    this.cboxAgreement.UseVisualStyleBackColor = false;
    this.cboxAgreement.CheckedChanged += new EventHandler(this.cboxAgreement_CheckedChanged);
    componentResourceManager.ApplyResources((object) this.label5, "label5");
    this.label5.Name = "label5";
    componentResourceManager.ApplyResources((object) this.label6, "label6");
    this.label6.Name = "label6";
    this.cboServer.BackColor = Color.FromArgb(206, 233, 253);
    this.cboServer.DropDownWidth = 186;
    componentResourceManager.ApplyResources((object) this.cboServer, "cboServer");
    this.cboServer.FormattingEnabled = true;
    this.cboServer.Name = "cboServer";
    this.cboServer.DropDown += new EventHandler(this.cboServer_DropDown);
    this.cboServer.SelectedIndexChanged += new EventHandler(this.cboServer_SelectedIndexChanged);
    this.cboServer.KeyPress += new KeyPressEventHandler(this.cboServer_KeyPress);
    componentResourceManager.ApplyResources((object) this.btnDelProfile, "btnDelProfile");
    this.btnDelProfile.BackColor = Color.FromArgb(247, 207, 142);
    this.btnDelProfile.ForeColor = Color.Black;
    this.btnDelProfile.Name = "btnDelProfile";
    this.btnDelProfile.UseVisualStyleBackColor = false;
    this.btnDelProfile.Click += new EventHandler(this.btnDelProfile_Click);
    this.cboHopKiem.BackColor = Color.FromArgb(206, 233, 253);
    this.cboHopKiem.DropDownWidth = 186;
    componentResourceManager.ApplyResources((object) this.cboHopKiem, "cboHopKiem");
    this.cboHopKiem.FormattingEnabled = true;
    this.cboHopKiem.Name = "cboHopKiem";
    this.cboHopKiem.DropDown += new EventHandler(this.cboHopKiem_DropDown);
    this.cboHopKiem.SelectedIndexChanged += new EventHandler(this.cboHopKiem_SelectedIndexChanged);
    this.cboHopKiem.KeyPress += new KeyPressEventHandler(this.cboHopKiem_KeyPress);
    this.timer1.Interval = 400;
    this.timer1.Tick += new EventHandler(this.timer1_Tick);
    componentResourceManager.ApplyResources((object) this.label1, "label1");
    this.label1.Name = "label1";
    this.tboxName.BackColor = Color.FromArgb(206, 233, 253);
    this.tboxName.ForeColor = Color.Maroon;
    componentResourceManager.ApplyResources((object) this.tboxName, "tboxName");
    this.tboxName.Name = "tboxName";
    this.tboxName.KeyPress += new KeyPressEventHandler(this.tboxName_KeyPress);
    componentResourceManager.ApplyResources((object) this.columnHeader1, "columnHeader1");
    componentResourceManager.ApplyResources((object) this.columnHeader2, "columnHeader2");
    componentResourceManager.ApplyResources((object) this.columnHeader3, "columnHeader3");
    componentResourceManager.ApplyResources((object) this.columnHeader4, "columnHeader4");
    componentResourceManager.ApplyResources((object) this.columnHeader5, "columnHeader5");
    componentResourceManager.ApplyResources((object) this.label3, "label3");
    this.label3.Name = "label3";
    this.tboxGameFile.BackColor = Color.FromArgb(206, 233, 253);
    this.tboxGameFile.ForeColor = Color.Maroon;
    componentResourceManager.ApplyResources((object) this.tboxGameFile, "tboxGameFile");
    this.tboxGameFile.Name = "tboxGameFile";
    this.tboxGameFile.KeyPress += new KeyPressEventHandler(this.tboxGameFile_KeyPress);
    componentResourceManager.ApplyResources((object) this.btnBrowseVNG, "btnBrowseVNG");
    this.btnBrowseVNG.Name = "btnBrowseVNG";
    this.btnBrowseVNG.UseVisualStyleBackColor = true;
    this.btnBrowseVNG.Click += new EventHandler(this.btnBrowseVNG_Click);
    componentResourceManager.ApplyResources((object) this.dataGridViewImageColumn1, "dataGridViewImageColumn1");
    this.dataGridViewImageColumn1.Image = (Image) Resources.captchaplace;
    this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
    this.dataGridViewImageColumn1.ReadOnly = true;
    this.GLoginContextMenu.Items.AddRange(new ToolStripItem[20]
    {
      (ToolStripItem) this.mởGameTấtCảCácProfileNàyToolStripMenuItem,
      (ToolStripItem) this.đăngNhậpChạyQToolStripMenuItem,
      (ToolStripItem) this.toolStripMenuItem1,
      (ToolStripItem) this.cậpNhậtĐườngDẫnGameToolStripMenuItem,
      (ToolStripItem) this.xóaKhỏiDanhSáchToolStripMenuItem,
      (ToolStripItem) this.toolStripMenuItem2,
      (ToolStripItem) this.xếpLênĐầuDanhSáchToolStripMenuItem,
      (ToolStripItem) this.xếpXuốngCuốiDanhSáchToolStripMenuItem,
      (ToolStripItem) this.toolStripMenuItem3,
      (ToolStripItem) this.mờiĐộiCảNhómToolStripMenuItem,
      (ToolStripItem) this.triệuTậpCảNhómToolStripMenuItem,
      (ToolStripItem) this.setNhómIDToolStripMenuItem,
      (ToolStripItem) this.toolStripMenuItem4,
      (ToolStripItem) this.hiệnGameDoubleClickToolStripMenuItem,
      (ToolStripItem) this.hiệnGameVàThuXuốngTaskbarToolStripMenuItem,
      (ToolStripItem) this.ẩnGameKiểu1ToolStripMenuItem,
      (ToolStripItem) this.ẩnGameKiểu2ToolStripMenuItem,
      (ToolStripItem) this.hiệnGameBịMấtToolStripMenuItem,
      (ToolStripItem) this.thoátGameNhanhToolStripMenuItem,
      (ToolStripItem) this.kickAccountRaKhỏiAutoToolStripMenuItem
    });
    this.GLoginContextMenu.Name = "GLoginContextMenu";
    componentResourceManager.ApplyResources((object) this.GLoginContextMenu, "GLoginContextMenu");
    this.GLoginContextMenu.Opening += new CancelEventHandler(this.GLoginContextMenu_Opening);
    this.mởGameTấtCảCácProfileNàyToolStripMenuItem.Name = "mởGameTấtCảCácProfileNàyToolStripMenuItem";
    componentResourceManager.ApplyResources((object) this.mởGameTấtCảCácProfileNàyToolStripMenuItem, "mởGameTấtCảCácProfileNàyToolStripMenuItem");
    this.mởGameTấtCảCácProfileNàyToolStripMenuItem.Click += new EventHandler(this.mởGameTấtCảCácProfileNàyToolStripMenuItem_Click);
    this.đăngNhậpChạyQToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[1]
    {
      (ToolStripItem) this.báchHoaDuyênToolStripMenuItem
    });
    this.đăngNhậpChạyQToolStripMenuItem.Name = "đăngNhậpChạyQToolStripMenuItem";
    componentResourceManager.ApplyResources((object) this.đăngNhậpChạyQToolStripMenuItem, "đăngNhậpChạyQToolStripMenuItem");
    this.báchHoaDuyênToolStripMenuItem.Name = "báchHoaDuyênToolStripMenuItem";
    componentResourceManager.ApplyResources((object) this.báchHoaDuyênToolStripMenuItem, "báchHoaDuyênToolStripMenuItem");
    this.báchHoaDuyênToolStripMenuItem.Click += new EventHandler(this.báchHoaDuyênToolStripMenuItem_Click);
    this.toolStripMenuItem1.Name = "toolStripMenuItem1";
    componentResourceManager.ApplyResources((object) this.toolStripMenuItem1, "toolStripMenuItem1");
    this.cậpNhậtĐườngDẫnGameToolStripMenuItem.Name = "cậpNhậtĐườngDẫnGameToolStripMenuItem";
    componentResourceManager.ApplyResources((object) this.cậpNhậtĐườngDẫnGameToolStripMenuItem, "cậpNhậtĐườngDẫnGameToolStripMenuItem");
    this.cậpNhậtĐườngDẫnGameToolStripMenuItem.Click += new EventHandler(this.cậpNhậtĐườngDẫnGameToolStripMenuItem_Click);
    this.xóaKhỏiDanhSáchToolStripMenuItem.Name = "xóaKhỏiDanhSáchToolStripMenuItem";
    componentResourceManager.ApplyResources((object) this.xóaKhỏiDanhSáchToolStripMenuItem, "xóaKhỏiDanhSáchToolStripMenuItem");
    this.xóaKhỏiDanhSáchToolStripMenuItem.Click += new EventHandler(this.xóaKhỏiDanhSáchToolStripMenuItem_Click);
    this.toolStripMenuItem2.Name = "toolStripMenuItem2";
    componentResourceManager.ApplyResources((object) this.toolStripMenuItem2, "toolStripMenuItem2");
    this.xếpLênĐầuDanhSáchToolStripMenuItem.Name = "xếpLênĐầuDanhSáchToolStripMenuItem";
    componentResourceManager.ApplyResources((object) this.xếpLênĐầuDanhSáchToolStripMenuItem, "xếpLênĐầuDanhSáchToolStripMenuItem");
    this.xếpLênĐầuDanhSáchToolStripMenuItem.Click += new EventHandler(this.xếpLênĐầuDanhSáchToolStripMenuItem_Click);
    this.xếpXuốngCuốiDanhSáchToolStripMenuItem.Name = "xếpXuốngCuốiDanhSáchToolStripMenuItem";
    componentResourceManager.ApplyResources((object) this.xếpXuốngCuốiDanhSáchToolStripMenuItem, "xếpXuốngCuốiDanhSáchToolStripMenuItem");
    this.xếpXuốngCuốiDanhSáchToolStripMenuItem.Click += new EventHandler(this.xếpXuốngCuốiDanhSáchToolStripMenuItem_Click);
    this.toolStripMenuItem3.Name = "toolStripMenuItem3";
    componentResourceManager.ApplyResources((object) this.toolStripMenuItem3, "toolStripMenuItem3");
    this.mờiĐộiCảNhómToolStripMenuItem.Name = "mờiĐộiCảNhómToolStripMenuItem";
    componentResourceManager.ApplyResources((object) this.mờiĐộiCảNhómToolStripMenuItem, "mờiĐộiCảNhómToolStripMenuItem");
    this.mờiĐộiCảNhómToolStripMenuItem.Click += new EventHandler(this.mờiĐộiCảNhómToolStripMenuItem_Click);
    this.triệuTậpCảNhómToolStripMenuItem.Name = "triệuTậpCảNhómToolStripMenuItem";
    componentResourceManager.ApplyResources((object) this.triệuTậpCảNhómToolStripMenuItem, "triệuTậpCảNhómToolStripMenuItem");
    this.triệuTậpCảNhómToolStripMenuItem.Click += new EventHandler(this.triệuTậpCảNhómToolStripMenuItem_Click);
    this.setNhómIDToolStripMenuItem.Name = "setNhómIDToolStripMenuItem";
    componentResourceManager.ApplyResources((object) this.setNhómIDToolStripMenuItem, "setNhómIDToolStripMenuItem");
    this.setNhómIDToolStripMenuItem.Click += new EventHandler(this.setNhómIDToolStripMenuItem_Click);
    this.toolStripMenuItem4.Name = "toolStripMenuItem4";
    componentResourceManager.ApplyResources((object) this.toolStripMenuItem4, "toolStripMenuItem4");
    this.hiệnGameDoubleClickToolStripMenuItem.Name = "hiệnGameDoubleClickToolStripMenuItem";
    componentResourceManager.ApplyResources((object) this.hiệnGameDoubleClickToolStripMenuItem, "hiệnGameDoubleClickToolStripMenuItem");
    this.hiệnGameDoubleClickToolStripMenuItem.Click += new EventHandler(this.hiệnGameDoubleClickToolStripMenuItem_Click);
    this.hiệnGameVàThuXuốngTaskbarToolStripMenuItem.Name = "hiệnGameVàThuXuốngTaskbarToolStripMenuItem";
    componentResourceManager.ApplyResources((object) this.hiệnGameVàThuXuốngTaskbarToolStripMenuItem, "hiệnGameVàThuXuốngTaskbarToolStripMenuItem");
    this.hiệnGameVàThuXuốngTaskbarToolStripMenuItem.Click += new EventHandler(this.hiệnGameVàThuXuốngTaskbarToolStripMenuItem_Click);
    this.ẩnGameKiểu1ToolStripMenuItem.Name = "ẩnGameKiểu1ToolStripMenuItem";
    componentResourceManager.ApplyResources((object) this.ẩnGameKiểu1ToolStripMenuItem, "ẩnGameKiểu1ToolStripMenuItem");
    this.ẩnGameKiểu1ToolStripMenuItem.Click += new EventHandler(this.ẩnGameKiểu1ToolStripMenuItem_Click);
    this.ẩnGameKiểu2ToolStripMenuItem.Name = "ẩnGameKiểu2ToolStripMenuItem";
    componentResourceManager.ApplyResources((object) this.ẩnGameKiểu2ToolStripMenuItem, "ẩnGameKiểu2ToolStripMenuItem");
    this.ẩnGameKiểu2ToolStripMenuItem.Click += new EventHandler(this.ẩnGameKiểu2ToolStripMenuItem_Click);
    this.hiệnGameBịMấtToolStripMenuItem.Name = "hiệnGameBịMấtToolStripMenuItem";
    componentResourceManager.ApplyResources((object) this.hiệnGameBịMấtToolStripMenuItem, "hiệnGameBịMấtToolStripMenuItem");
    this.hiệnGameBịMấtToolStripMenuItem.Click += new EventHandler(this.hiệnGameBịMấtToolStripMenuItem_Click);
    this.thoátGameNhanhToolStripMenuItem.Name = "thoátGameNhanhToolStripMenuItem";
    componentResourceManager.ApplyResources((object) this.thoátGameNhanhToolStripMenuItem, "thoátGameNhanhToolStripMenuItem");
    this.thoátGameNhanhToolStripMenuItem.Click += new EventHandler(this.thoátGameNhanhToolStripMenuItem_Click);
    this.kickAccountRaKhỏiAutoToolStripMenuItem.Name = "kickAccountRaKhỏiAutoToolStripMenuItem";
    componentResourceManager.ApplyResources((object) this.kickAccountRaKhỏiAutoToolStripMenuItem, "kickAccountRaKhỏiAutoToolStripMenuItem");
    this.kickAccountRaKhỏiAutoToolStripMenuItem.Click += new EventHandler(this.kickAccountRaKhỏiAutoToolStripMenuItem_Click);
    this.listGLogin.AllColumns.Add(this.colGLogin_AI);
    this.listGLogin.AllColumns.Add(this.colGLogin_Username);
    this.listGLogin.AllColumns.Add(this.colGLogin_TenNV);
    this.listGLogin.AllColumns.Add(this.colGLogin_Server);
    this.listGLogin.AllColumns.Add(this.colGLogin_Captcha);
    this.listGLogin.AllColumns.Add(this.colGLogin_NhapCaptcha);
    this.listGLogin.AllColumns.Add(this.colGLogin_VaoGame);
    this.listGLogin.AllColumns.Add(this.colGLogin_Open);
    componentResourceManager.ApplyResources((object) this.listGLogin, "listGLogin");
    this.listGLogin.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
    this.listGLogin.CellEditActivation = ObjectListView.CellEditActivateMode.SingleClick;
    this.listGLogin.CellEditEnterChangesRows = true;
    this.listGLogin.CellEditTabChangesRows = true;
    this.listGLogin.CellEditUseWholeCell = false;
    this.listGLogin.Columns.AddRange(new ColumnHeader[8]
    {
      (ColumnHeader) this.colGLogin_AI,
      (ColumnHeader) this.colGLogin_Username,
      (ColumnHeader) this.colGLogin_TenNV,
      (ColumnHeader) this.colGLogin_Server,
      (ColumnHeader) this.colGLogin_Captcha,
      (ColumnHeader) this.colGLogin_NhapCaptcha,
      (ColumnHeader) this.colGLogin_VaoGame,
      (ColumnHeader) this.colGLogin_Open
    });
    this.listGLogin.Cursor = Cursors.Default;
    this.listGLogin.ForeColor = Color.FromArgb(32 /*0x20*/, 32 /*0x20*/, 32 /*0x20*/);
    this.listGLogin.FullRowSelect = true;
    this.listGLogin.HeaderStyle = ColumnHeaderStyle.Nonclickable;
    this.listGLogin.HideSelection = false;
    this.listGLogin.IsSimpleDragSource = true;
    this.listGLogin.IsSimpleDropSink = true;
    this.listGLogin.Name = "listGLogin";
    this.listGLogin.OwnerDraw = false;
    this.listGLogin.UseCompatibleStateImageBehavior = false;
    this.listGLogin.UseHotControls = false;
    this.listGLogin.UseOverlays = false;
    this.listGLogin.View = View.Details;
    this.listGLogin.ButtonClick += new EventHandler<CellClickEventArgs>(this.listGLogin_ButtonClick);
    this.listGLogin.CanDrop += new EventHandler<OlvDropEventArgs>(this.listGLogin_CanDrop);
    this.listGLogin.CellEditFinished += new CellEditEventHandler(this.listGLogin_CellEditFinished);
    this.listGLogin.CellEditStarting += new CellEditEventHandler(this.listGLogin_CellEditStarting);
    this.listGLogin.CellClick += new EventHandler<CellClickEventArgs>(this.listGLogin_CellClick);
    this.listGLogin.Dropped += new EventHandler<OlvDropEventArgs>(this.listGLogin_Dropped);
    this.listGLogin.SelectionChanged += new EventHandler(this.listGLogin_SelectionChanged);
    this.listGLogin.SelectedIndexChanged += new EventHandler(this.listGLogin_SelectedIndexChanged);
    this.listGLogin.KeyPress += new KeyPressEventHandler(this.listGLogin_KeyPress);
    this.listGLogin.MouseClick += new MouseEventHandler(this.listGLogin_MouseClick);
    this.listGLogin.MouseDoubleClick += new MouseEventHandler(this.listGLogin_MouseDoubleClick);
    this.colGLogin_AI.Groupable = false;
    this.colGLogin_AI.HeaderCheckBoxUpdatesRowCheckBoxes = false;
    this.colGLogin_AI.IsEditable = false;
    this.colGLogin_AI.Sortable = false;
    componentResourceManager.ApplyResources((object) this.colGLogin_AI, "colGLogin_AI");
    this.colGLogin_Username.AspectName = "Username";
    this.colGLogin_Username.FillsFreeSpace = true;
    this.colGLogin_Username.Groupable = false;
    this.colGLogin_Username.IsEditable = false;
    this.colGLogin_Username.Sortable = false;
    componentResourceManager.ApplyResources((object) this.colGLogin_Username, "colGLogin_Username");
    this.colGLogin_TenNV.AspectName = "CharName";
    this.colGLogin_TenNV.FillsFreeSpace = true;
    this.colGLogin_TenNV.Groupable = false;
    this.colGLogin_TenNV.IsEditable = false;
    this.colGLogin_TenNV.Sortable = false;
    componentResourceManager.ApplyResources((object) this.colGLogin_TenNV, "colGLogin_TenNV");
    this.colGLogin_Server.AspectName = "Server";
    this.colGLogin_Server.FillsFreeSpace = true;
    this.colGLogin_Server.IsEditable = false;
    this.colGLogin_Server.Sortable = false;
    componentResourceManager.ApplyResources((object) this.colGLogin_Server, "colGLogin_Server");
    this.colGLogin_Captcha.Groupable = false;
    this.colGLogin_Captcha.IsEditable = false;
    this.colGLogin_Captcha.Sortable = false;
    componentResourceManager.ApplyResources((object) this.colGLogin_Captcha, "colGLogin_Captcha");
    this.colGLogin_NhapCaptcha.AspectName = "captchaCode";
    this.colGLogin_NhapCaptcha.Groupable = false;
    this.colGLogin_NhapCaptcha.Sortable = false;
    componentResourceManager.ApplyResources((object) this.colGLogin_NhapCaptcha, "colGLogin_NhapCaptcha");
    this.colGLogin_VaoGame.AspectName = "";
    this.colGLogin_VaoGame.IsEditable = false;
    this.colGLogin_VaoGame.Sortable = false;
    componentResourceManager.ApplyResources((object) this.colGLogin_VaoGame, "colGLogin_VaoGame");
    this.colGLogin_Open.AspectName = "JustOpen";
    this.colGLogin_Open.ButtonSizing = OLVColumn.ButtonSizingMode.CellBounds;
    this.colGLogin_Open.Groupable = false;
    this.colGLogin_Open.HeaderCheckBoxUpdatesRowCheckBoxes = false;
    this.colGLogin_Open.IsButton = true;
    this.colGLogin_Open.IsEditable = false;
    this.colGLogin_Open.Sortable = false;
    componentResourceManager.ApplyResources((object) this.colGLogin_Open, "colGLogin_Open");
    componentResourceManager.ApplyResources((object) this.columnHeader6, "columnHeader6");
    componentResourceManager.ApplyResources((object) this.columnHeader7, "columnHeader7");
    componentResourceManager.ApplyResources((object) this.columnHeader8, "columnHeader8");
    componentResourceManager.ApplyResources((object) this.columnHeader9, "columnHeader9");
    componentResourceManager.ApplyResources((object) this.columnHeader10, "columnHeader10");
    componentResourceManager.ApplyResources((object) this.lbStatus, "lbStatus");
    this.lbStatus.Name = "lbStatus";
    this.lbStatus.Click += new EventHandler(this.lbStatus_Click);
    componentResourceManager.ApplyResources((object) this.lbTotal, "lbTotal");
    this.lbTotal.Name = "lbTotal";
    componentResourceManager.ApplyResources((object) this.label7, "label7");
    this.label7.Name = "label7";
    componentResourceManager.ApplyResources((object) this, "$this");
    this.AutoScaleMode = AutoScaleMode.Font;
    this.BackColor = Color.WhiteSmoke;
    this.Controls.Add((Control) this.label7);
    this.Controls.Add((Control) this.lbStatus);
    this.Controls.Add((Control) this.tboxPassword);
    this.Controls.Add((Control) this.listGLogin);
    this.Controls.Add((Control) this.btnBrowseVNG);
    this.Controls.Add((Control) this.tboxGameFile);
    this.Controls.Add((Control) this.label3);
    this.Controls.Add((Control) this.label1);
    this.Controls.Add((Control) this.tboxName);
    this.Controls.Add((Control) this.cboHopKiem);
    this.Controls.Add((Control) this.btnDelProfile);
    this.Controls.Add((Control) this.cboServer);
    this.Controls.Add((Control) this.label6);
    this.Controls.Add((Control) this.label5);
    this.Controls.Add((Control) this.cboxAgreement);
    this.Controls.Add((Control) this.label4);
    this.Controls.Add((Control) this.lblAgreementTitle);
    this.Controls.Add((Control) this.lblAgreement);
    this.Controls.Add((Control) this.label9);
    this.Controls.Add((Control) this.tboxUsername);
    this.Controls.Add((Control) this.cboNPH);
    this.Controls.Add((Control) this.btnThemProfile);
    this.Controls.Add((Control) this.btnEditProfile);
    this.Controls.Add((Control) this.label2);
    this.Controls.Add((Control) this.lbTotal);
    this.HelpButton = true;
    this.KeyPreview = true;
    this.MaximizeBox = false;
    this.Name = nameof (frmGLogin);
    this.FormClosing += new FormClosingEventHandler(this.frmGLogin_FormClosing);
    this.Load += new EventHandler(this.frmGLogin_Load);
    this.Shown += new EventHandler(this.frmGLogin_Shown);
    this.KeyDown += new KeyEventHandler(this.frmGLogin_KeyDown);
    this.KeyPress += new KeyPressEventHandler(this.frmGLogin_KeyPress);
    this.GLoginContextMenu.ResumeLayout(false);
    ((ISupportInitialize) this.listGLogin).EndInit();
    this.ResumeLayout(false);
    this.PerformLayout();
  }
}
