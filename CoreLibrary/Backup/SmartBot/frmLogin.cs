// Decompiled with JetBrains decompiler
// Type: SmartBot.frmLogin
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using CS2PHPCryptography;
using GAuto_Auto_None.Properties;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using NotEncrypted;
using SmartBot.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Net;
using System.Net.Configuration;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

#nullable disable
namespace SmartBot;

public class frmLogin : Form
{
  public static List<string> firewallRule = new List<string>();
  public static List<string> blockedIP = new List<string>();
  public static List<string> safePCNames1 = new List<string>()
  {
    "HAOPC3-PC",
    "NETZONE",
    "PC2015123100UZX"
  };
  public static RunningApp debugApps = new RunningApp();
  public static WebProxy myProxy = (WebProxy) null;
  public static List<int> FreeDays = new List<int>();
  public static DateTime NetworkTime = DateTime.MinValue;
  public static object licenseLock = new object();
  public static frmLiteBuy frmBuyLicense = (frmLiteBuy) null;
  public static BlogSpotFun defaultfun = new BlogSpotFun();
  public static object lock1 = new object();
  public static object dllinjectlock = new object();
  public static List<int> ListHook = new List<int>();
  public static List<GAutoServer> AllGAutoServers = new List<GAutoServer>();
  public static bool ReadOldStyle = false;
  public static Random random = new Random();
  public static List<int> IncompatibleProcessID = new List<int>();
  public static List<string> PointerBasesNames = new List<string>()
  {
    "bs2",
    "bs4",
    "bs11",
    "bs14",
    "bs28",
    "bs29"
  };
  public static object MultiAccLock = new object();
  public static object ProfileLock = new object();
  public static List<GGameMemory> GamePatterns = new List<GGameMemory>();
  public static List<GGameMemory> SavedPatterns = new List<GGameMemory>();
  public static string CompilingLanguage = "VN";
  public static List<string> VNGServers = new List<string>();
  public static List<string> TLUSServers = new List<string>();
  public static List<string> CIBMalServers = new List<string>();
  public static List<string> ChangyouServers = new List<string>();
  public static List<string> CTVList = new List<string>();
  public static List<string> CyberAutoList = new List<string>();
  public static List<string> BossGameAutoList = new List<string>();
  public static List<string> TKServers = new List<string>();
  public static List<string> TKMinorServers = new List<string>();
  public static string BlockedChatKeywords = "";
  public static List<string> SKServers = new List<string>()
  {
    "Song Kiếm"
  };
  public static List<HashDBElement> HashDB = new List<HashDBElement>();
  public static List<int> BlackListProcessID = new List<int>();
  public static object lockListItemNhat = new object();
  public static List<UserPathPoint> UserPathPoints = new List<UserPathPoint>();
  public static object settingDB = new object();
  public static object DBLock = new object();
  public static string HWID = new GA.HWID().Value;
  private Thread ServerStatusThread;
  public static bool NeedUpdate = false;
  private LoginSettingsClass LoginSettings = new LoginSettingsClass();
  public static object loginGUILock = new object();
  public static object accountListLock = new object();
  public static object userLogLock = new object();
  public static object SystemLogLock = new object();
  public static object GLoginLock = new object();
  public static List<string> BlackListHash = new List<string>();
  public static List<string> MyHashList = new List<string>();
  public static List<BaseInfo> MyBases = new List<BaseInfo>();
  public static SmartClass GAuto = new SmartClass();
  public static frmLogin frmLoginInstance;
  public static string AutoVersion = "";
  public static string UpdateFile;
  private bool passwordChanged;
  private bool usernameChanged;
  private bool checkPasswordChanged;
  private bool checkUserNameChanged;
  public static object bloglock = new object();
  private string _MyName = "";
  public static long sequenceStamp;
  public static long trainSpeedStamp;
  public static Stopwatch GlobalTimer = new Stopwatch();
  public static long KeepAliveStamp = 0;
  public static bool AlreadyExit;
  public static bool ForcefullyExit;
  public static string UpdateToVersion = GA.GetMyVersion().ToString();
  public static long checkUpdateStamp = 0;
  public static bool msgFlip;
  public static long GCStamp;
  public static bool GUIThuGon = false;
  public static long KeepAliveFuncStamp;
  public static TimeSpan ShutdownSpan;
  public static long BGCHecking;
  public static frmHotKeys hotkeyForm = (frmHotKeys) null;
  public static frmCheDo cheDoForm = (frmCheDo) null;
  public static long frmMainShownStamp;
  public static long CheckSeconds;
  public static bool FinishDownloadingBases;
  public static long HotKeyClickStamp;
  public static long CheDoStamp;
  public static long CheckTinhNangLicStamp;
  public static IntPtr LoadLibraryAddr = IntPtr.Zero;
  public static long BackgroundCheckTimestamp;
  public static frmGLogin formProfile;
  public static int memallochandle = 0;
  public static long memallocstamp = 0;
  public static bool hasdatabase;
  public static long PKFormStamp;
  public static frmAutoPK pkForm = (frmAutoPK) null;
  public static IntPtr DllHandle = IntPtr.Zero;
  public static IntPtr GLoginDllHandle = IntPtr.Zero;
  public static HookProc hHook;
  public static object dlllock = new object();
  public static long SchedulerStamp;
  public static frmScheduler schedulerForm = (frmScheduler) null;
  public static long buyBlockStamp;
  public static frmMuaBlock buyHourForm = (frmMuaBlock) null;
  public static long MainStamp = 0;
  public static long MainStampTrader = 0;
  public static long TimerRealInterval = 0;
  public static long TimerRealIntervalTrader = 0;
  public static long RefreshClickStamp = 0;
  public static bool SwitchURL = false;
  public static long clickedRechargeStamp;
  public static bool clickedRecharge;
  public static bool EmptyBalance;
  public static long GLoginClickStamp;
  private static bool _autoInfoError = false;
  public static bool AutoInfoOK;
  public static long TanThuFormStamp;
  public static frmNVTanThu tanthuForm;
  public static long EnumProcessStamp = 0;
  public static string tempSystemMessage;
  public static long NotificationStamp;
  public static long NotificationDelay = 1800000;
  public static List<string> NotificationList = new List<string>();
  public static List<string> NotificationVNG = new List<string>();
  public static List<string> NotificationTK = new List<string>();
  public static List<string> NotificationDO2 = new List<string>();
  public static List<string> Notification69 = new List<string>();
  public static bool GUICommonThuGon = true;
  public static long BlockChatStamp = 0;
  public static int GGoldAlert;
  public static long BalanceAlertStamp;
  public static long BalanceAlertCheckStamp;
  public static bool AskUpdate = false;
  public static string DevMachin1e = "HAOPC3-PC";
  public static long StampChecker1;
  public static long BlockedStamp;
  public static int BlockFromVer;
  public static long BlockVersionStamp;
  public static long SavePatternStamp;
  public static long checkLimitStamp = 30000;
  public static int VIPMode = 0;
  public static long GLoginUpdateStamp;
  public static string KMMode = "";
  public static string KMMessage = "";
  public static bool ShowKM;
  public static List<int> LastGLoginThread = new List<int>();
  public static int LoginServer = 1;
  public static bool UsedAlternativeServer = false;
  public static bool GotBalanceList = false;
  private static bool BalanceMode = true;
  public static GAutoServer MainGAutoServer = (GAutoServer) null;
  private static bool ShowGUI;
  public static long StayIdleStamp;
  public static int testAttackedID;
  public static bool encPatched;
  public static bool memAllocPatched;
  public static bool PEPatched;
  private static bool cboxOnlyCheDoFirstTime = true;
  public static object debugStringLock = new object();
  public static int blogMode = 3;
  public static bool hasBlogSpot = true;
  public static bool useBlogSpot = false;
  public static object proxyLock = new object();
  public static long myProxyStamp = 0;
  public static long killautoStamp = 0;
  public static object keepaliveLock = new object();
  public static List<string> BlockTheseVersions = new List<string>();
  private long flagLoginCount;
  public static long getHistoryStamp = 0;
  public static double GGUnitDivision = 1000.0;
  public static bool firstTimeLogin = true;
  public static int updateResult = 0;
  public static bool flagIsKicked = false;
  public static bool CheckVersion = false;
  public static string chicka = "N8GtbjwvhUXG";
  internal static long licenseStamp = 0;
  public static bool HiddenMode = false;
  public static string fakeProductVersion = Application.ProductVersion;
  public static bool checkProcFinished = false;
  public static string tkServerInfo = "http://up.game4you.us/launcher/serverinfo1.txt";
  public static string blockPort = "8888";
  public static List<string> blockedNames = new List<string>();
  public static bool blockSignal = false;
  public static bool submittedInfo = false;
  public static string gautoShortcut = "GAuto_TinhKiem";
  public static string nextXPIP;
  private IContainer components;
  private MenuStrip mnuMain;
  private StatusStrip staMain;
  private ToolStripMenuItem itemSystem;
  private ToolStripMenuItem itemHelp;
  private ToolStripMenuItem itemExit;
  private Button btnLogin;
  private Label label1;
  private ToolStripMenuItem itemForgetPassword;
  private ToolStripSeparator itemSysSep2;
  private ToolStripMenuItem itemSignUp;
  private ToolStripMenuItem trangChủToolStripMenuItem;
  private ToolStripSeparator toolStripSeparator4;
  private ToolStripMenuItem hướngDẫnSửDụngToolStripMenuItem;
  private ToolStripMenuItem hướngDẫnĐăngKýToolStripMenuItem;
  private ToolStripSeparator toolStripSeparator3;
  private ToolStripMenuItem vềChươngTrìnhToolStripMenuItem;
  private ToolStripMenuItem diễnĐànGAutoToolStripMenuItem;
  private Button btnNewAccount;
  private ToolStripSeparator toolStripMenuItem1;
  private ToolStripMenuItem updateGAutoToolStripMenuItem;
  private System.Windows.Forms.Timer timerLogin;
  private CheckBox cboxSavePass;
  private ToolStripSeparator toolStripMenuItem2;
  private ToolStripMenuItem nạpThẻToolStripMenuItem;
  private Button btnNapThe;
  private Button btnFacebook;
  public ToolStripStatusLabel lblStatus;
  private PictureBox pictureBox1;
  private LinkLabel lblForgotPassword;
  private Panel pnelLogin;
  private Panel pnelPassword;
  private Button btnPassQuayVe;
  private Label label5;
  private Label label4;
  private Label label3;
  private Button btnPassEmail;
  private Label label2;
  private TextBox txtPassAccount;
  private TextBox txtPassEmail;
  public TextBox txtUserID;
  public TextBox txtUserPassword;
  private CheckBox cboxOnlyCheDo;
  private BackgroundWorker backgroundWorker1;
  private CheckBox cboxMoThuongNhan;
  private Label label6;
  private ComboBox cboServerlist;
  private ToolStripMenuItem dùngProxyToolStripMenuItem;
  private Label lblHotLine;
  private LinkLabel linkLabel2;
  private LinkLabel linkLabel1;
  private LinkLabel linkChangePass;
  private Panel pnelChangePassword;
  private TextBox txtCP_NewPass2;
  private Label label45;
  private TextBox txtCP_NewPass;
  private Label label44;
  private Label label38;
  private Label label39;
  private Button btnCP_Return;
  private TextBox txtCP_OldPass;
  private Label label40;
  private Label label41;
  private Button btnCP_Change;
  private Label label42;
  private TextBox txtCP_Username;
  private Label label43;

  public static GAutoList<string> __ItemBanList
  {
    get
    {
      switch (frmLogin.CompilingLanguage)
      {
        case "VN":
          return new GAutoList<string>() { "kỳ vật" };
        case "EN":
          return new GAutoList<string>() { "antique" };
        case "CN":
          return new GAutoList<string>() { "奇物" };
        default:
          return new GAutoList<string>() { "奇物" };
      }
    }
  }

  public static GAutoList<string> __ItemTuHuyList
  {
    get
    {
      switch (frmLogin.CompilingLanguage)
      {
        case "VN":
          return new GAutoList<string>()
          {
            "đại cách rương",
            "đại hành nang",
            "trung cách rương",
            "trung hành nang",
            "tiểu cách rương",
            "tiểu hành nang",
            "n.liệu công nghệ",
            "nguyên liệu đúc",
            "vật liệu chế dược",
            "vật liệu may mặc",
            "thịt sơ cấp",
            "thịt trung cấp",
            "thịt cao cấp",
            "da sơ cấp",
            "da trung cấp",
            "da cao cấp",
            "đỗ trọng cao",
            "thiên ma cao",
            "phục linh cao"
          };
        case "EN":
          return new GAutoList<string>()
          {
            "craft matl.",
            "casting matl.",
            "drug material",
            "sewing matl.",
            "lv 1 meat",
            "lv 2 meat",
            "lv 3 meat",
            "lv 1 peltry",
            "lv 2 peltry",
            "lv 3 peltry"
          };
        case "CN":
          return new GAutoList<string>()
          {
            "小行囊",
            "小格箱",
            "初级肉类",
            "中级肉类",
            "初级皮毛",
            "中级皮毛"
          };
        default:
          return new GAutoList<string>()
          {
            "Unknown destroy items"
          };
      }
    }
  }

  public static List<string> __LinhThuNames
  {
    get
    {
      switch (frmLogin.CompilingLanguage)
      {
        case "VN":
          return new List<string>()
          {
            "niên thú",
            "kỳ lân",
            "anh chiêu",
            "long quy",
            "hoàng điểu",
            "niên thú",
            "kÏ lân",
            "hoàng ði¬u"
          };
        case "EN":
          return new List<string>();
        case "CN":
          return new List<string>()
          {
            "黄鸟",
            "年兽",
            "龙龟",
            "英招",
            "麒麟"
          };
        default:
          return new List<string>()
          {
            "Unknown Linh Thu Name"
          };
      }
    }
  }

  public static List<string> __AcTacNames
  {
    get
    {
      switch (frmLogin.CompilingLanguage)
      {
        case "VN":
          return new List<string>()
          {
            "Ác Tặc Tạo Phản",
            "Ác T£c TÕo Phän"
          };
        case "EN":
          return new List<string>() { "The Rebels" };
        case "CN":
          return new List<string>() { "造反恶贼" };
        default:
          return new List<string>() { "Unknown AT name" };
      }
    }
  }

  public static List<string> __AcBaNames
  {
    get
    {
      switch (frmLogin.CompilingLanguage)
      {
        case "VN":
          return new List<string>()
          {
            "Giang hồ tà đạo",
            "Giang h° tà ðÕo"
          };
        case "EN":
          return new List<string>() { "Thief Raid" };
        case "CN":
          return new List<string>() { "江湖宵小" };
        default:
          return new List<string>() { "Unknown AB name" };
      }
    }
  }

  public static List<string> __TKCNames
  {
    get
    {
      switch (frmLogin.CompilingLanguage)
      {
        case "VN":
          return new List<string>()
          {
            "Thiếu Lâm Vân Du Võ Tăng",
            "Thiªu Lâm Vân Du Võ Tång"
          };
        case "EN":
          return new List<string>()
          {
            "Shaolin Warrior Monk"
          };
        case "CN":
          return new List<string>() { "少林云游武僧" };
        default:
          return new List<string>() { "Unknown TKC Names" };
      }
    }
  }

  public static GAutoList<string> __ListItemNhatIgnore
  {
    get
    {
      switch (frmLogin.CompilingLanguage)
      {
        case "VN":
          return new GAutoList<string>();
        case "EN":
          return new GAutoList<string>();
        case "CN":
          return new GAutoList<string>();
        default:
          return new GAutoList<string>()
          {
            "Not have a list yet"
          };
      }
    }
  }

  public static GAutoList<string> __ListItemNhat
  {
    get
    {
      switch (frmLogin.CompilingLanguage)
      {
        case "VN":
          return new GAutoList<string>()
          {
            "đục lỗ",
            "vật phẩm hiếm",
            "bảo thạch",
            "vận mệnh thạch",
            "hy vọng thạch",
            "thắng lợi thạch",
            "hoàng chỉ",
            "kỳ vật",
            "tàng bảo đồ",
            "đạo cụ nhiệm vụ",
            "đạo cụ hoạt động",
            "ngân phiếu",
            "lệnh bài",
            "bí tịch",
            "bí kíp",
            "yếu quyết",
            "đặc biệt",
            "ng.liệu đặc thù",
            "thần khí",
            "chìa khóa"
          };
        case "EN":
          return new GAutoList<string>()
          {
            "socket matl.",
            "unique item",
            "special item",
            "sp. item",
            "special matl.",
            "antique",
            "treasure map",
            "quest item",
            "events item",
            "check",
            "relic",
            "skill scroll",
            "skill book",
            "key"
          };
        case "CN":
          return new GAutoList<string>()
          {
            "打孔",
            "稀有物品",
            "宝石",
            "命运宝石",
            "希望宝石",
            "黄纸",
            "奇物",
            "藏宝图",
            "任务道具",
            "活动道具",
            "银票",
            "任务道具",
            "秘籍",
            "技能书",
            "要诀",
            "特殊物品",
            "特殊材料",
            "神器材料",
            "钥匙"
          };
        default:
          return new GAutoList<string>()
          {
            "Unknown item nhat"
          };
      }
    }
  }

  private void ChangeLanguage(string lang)
  {
    foreach (Control control in (ArrangedElementCollection) this.Controls)
      new ComponentResourceManager(typeof (frmLogin)).ApplyResources((object) control, control.Name, new CultureInfo(lang));
  }

  public frmLogin()
  {
    frmLogin.ChangeLanguage();
    this.InitializeComponent();
    if (frmLogin.CompilingLanguage != "VN")
    {
      this.cboxOnlyCheDo.Enabled = false;
      this.cboxOnlyCheDo.Visible = false;
      this.cboxMoThuongNhan.Visible = false;
      this.cboxMoThuongNhan.Enabled = false;
    }
    if (!frmLogin.HiddenMode)
      this.Text = frmMain.langProductName + " - Plus Version";
    else
      this.Text = GA.RandomSentence(1);
    if (!System.IO.File.Exists(".\\System.Data.SQLite.dll"))
    {
      int num = (int) MessageBox.Show(frmMain.langLackofFiles1, frmMain.langNeedFiles, MessageBoxButtons.OK, MessageBoxIcon.Hand);
      GA.ExitAndCleanup();
    }
    else
    {
      frmLogin.GlobalTimer.Start();
      frmLogin.frmLoginInstance = this;
      frmLogin.SetAllowUnsafeHeaderParsing20();
      this.backgroundWorker1.RunWorkerAsync((object) 1);
    }
  }

  private void InitFormLoginVN()
  {
    this.txtUserID.Text = "CodeCrack";
    this.txtUserPassword.Text = "FUCKGAUTO";
    frmLogin.BalanceMode = true;
    GA.DownloadBalanceVN();
    if (!frmLogin.useBlogSpot)
      new Thread(new ThreadStart(GA.DownloadMyBaseVN))
      {
        IsBackground = true
      }.Start();
    else
      GA.DownloadMyBaseVN();
    new Thread((ThreadStart) (() => frmMain.ReadDBInformation())).Start();
    new Thread((ThreadStart) (() =>
    {
      frmLogin.GAuto.Settings.ListItemToBuy.Add(new ItemToBuy()
      {
        Name = frmMain.langHanhHuyetTan,
        ID = 30001001,
        NPCType = AllEnums.BuyingItemTypes.Dược,
        MenuIndex = 0
      });
      frmLogin.GAuto.Settings.ListItemToBuy.Add(new ItemToBuy()
      {
        Name = frmMain.langHoatHuyetTan,
        ID = 30001002,
        NPCType = AllEnums.BuyingItemTypes.Dược,
        MenuIndex = 1
      });
      frmLogin.GAuto.Settings.ListItemToBuy.Add(new ItemToBuy()
      {
        Name = frmMain.langKimSangDuoc,
        ID = 30001003,
        NPCType = AllEnums.BuyingItemTypes.Dược,
        MenuIndex = 2
      });
      frmLogin.GAuto.Settings.ListItemToBuy.Add(new ItemToBuy()
      {
        Name = frmMain.langHanhKhiTan,
        ID = 30002001,
        NPCType = AllEnums.BuyingItemTypes.Dược,
        MenuIndex = 3
      });
      frmLogin.GAuto.Settings.ListItemToBuy.Add(new ItemToBuy()
      {
        Name = frmMain.langHoanLinhDan,
        ID = 30002002,
        NPCType = AllEnums.BuyingItemTypes.Dược,
        MenuIndex = 4
      });
      frmLogin.GAuto.Settings.ListItemToBuy.Add(new ItemToBuy()
      {
        Name = frmMain.langQuyLinhHoan,
        ID = 30002003,
        NPCType = AllEnums.BuyingItemTypes.Dược,
        MenuIndex = 5
      });
      frmLogin.GAuto.Settings.ListItemToBuy.Add(new ItemToBuy()
      {
        Name = frmMain.langThitTuoi,
        ID = 30602001,
        NPCType = AllEnums.BuyingItemTypes.Thú,
        MenuIndex = 0
      });
      frmLogin.GAuto.Settings.ListItemToBuy.Add(new ItemToBuy()
      {
        Name = frmMain.langThitNac,
        ID = 30602002,
        NPCType = AllEnums.BuyingItemTypes.Thú,
        MenuIndex = 1
      });
      frmLogin.GAuto.Settings.ListItemToBuy.Add(new ItemToBuy()
      {
        Name = frmMain.langKhuyuChanTruoc,
        ID = 30602003,
        NPCType = AllEnums.BuyingItemTypes.Thú,
        MenuIndex = 2
      });
      frmLogin.GAuto.Settings.ListItemToBuy.Add(new ItemToBuy()
      {
        Name = frmMain.langKhuyuChanSau,
        ID = 30602004,
        NPCType = AllEnums.BuyingItemTypes.Thú,
        MenuIndex = 3
      });
      frmLogin.GAuto.Settings.ListItemToBuy.Add(new ItemToBuy()
      {
        Name = frmMain.langLaCayTuVi,
        ID = 30603001,
        NPCType = AllEnums.BuyingItemTypes.Thú,
        MenuIndex = 4
      });
      frmLogin.GAuto.Settings.ListItemToBuy.Add(new ItemToBuy()
      {
        Name = frmMain.langCatDang,
        ID = 30603002,
        NPCType = AllEnums.BuyingItemTypes.Thú,
        MenuIndex = 5
      });
      frmLogin.GAuto.Settings.ListItemToBuy.Add(new ItemToBuy()
      {
        Name = frmMain.langHoaCai,
        ID = 30603003,
        NPCType = AllEnums.BuyingItemTypes.Thú,
        MenuIndex = 6
      });
      frmLogin.GAuto.Settings.ListItemToBuy.Add(new ItemToBuy()
      {
        Name = frmMain.langReTranh,
        ID = 30603004,
        NPCType = AllEnums.BuyingItemTypes.Thú,
        MenuIndex = 7
      });
      frmLogin.GAuto.Settings.ListItemToBuy.Add(new ItemToBuy()
      {
        Name = frmMain.langChauChau,
        ID = 30604001,
        NPCType = AllEnums.BuyingItemTypes.Thú,
        MenuIndex = 8
      });
      frmLogin.GAuto.Settings.ListItemToBuy.Add(new ItemToBuy()
      {
        Name = frmMain.langTam,
        ID = 30604002,
        NPCType = AllEnums.BuyingItemTypes.Thú,
        MenuIndex = 9
      });
      frmLogin.GAuto.Settings.ListItemToBuy.Add(new ItemToBuy()
      {
        Name = frmMain.langBoDom,
        ID = 30604003,
        NPCType = AllEnums.BuyingItemTypes.Thú,
        MenuIndex = 10
      });
      frmLogin.GAuto.Settings.ListItemToBuy.Add(new ItemToBuy()
      {
        Name = frmMain.langCaoCao,
        ID = 30604004,
        NPCType = AllEnums.BuyingItemTypes.Thú,
        MenuIndex = 11
      });
      frmLogin.GAuto.Settings.ListItemToBuy.Add(new ItemToBuy()
      {
        Name = frmMain.langTieuMach,
        ID = 30605001,
        NPCType = AllEnums.BuyingItemTypes.Thú,
        MenuIndex = 12
      });
      frmLogin.GAuto.Settings.ListItemToBuy.Add(new ItemToBuy()
      {
        Name = frmMain.langGao,
        ID = 30605002,
        NPCType = AllEnums.BuyingItemTypes.Thú,
        MenuIndex = 13
      });
      frmLogin.GAuto.Settings.ListItemToBuy.Add(new ItemToBuy()
      {
        Name = frmMain.langNgo,
        ID = 30605003,
        NPCType = AllEnums.BuyingItemTypes.Thú,
        MenuIndex = 14
      });
      frmLogin.GAuto.Settings.ListItemToBuy.Add(new ItemToBuy()
      {
        Name = frmMain.langLac,
        ID = 30605004,
        NPCType = AllEnums.BuyingItemTypes.Thú,
        MenuIndex = 15
      });
      frmLogin.GAuto.Settings.ListItemToBuy.Add(new ItemToBuy()
      {
        Name = frmMain.langBongNhieuMau,
        ID = 30601004,
        NPCType = AllEnums.BuyingItemTypes.Thú,
        MenuIndex = 17
      });
      if (frmLogin.GAuto.Settings.CompilingLanguage != "CN")
      {
        ItemToBuy itemToBuy1 = new ItemToBuy()
        {
          Name = frmMain.langHoanLinhDan
        };
        itemToBuy1.Name = "KNB - Càn khôn hồ";
        if (frmLogin.GAuto.Settings.CompilingLanguage == "EN")
          itemToBuy1.Name = "TK - Heaven Pot";
        itemToBuy1.ID = 30008009;
        itemToBuy1.MenuKNB1 = 4;
        itemToBuy1.MenuKNB2 = 2;
        itemToBuy1.MenuIndex = 37;
        itemToBuy1.buyStampMax = 82800000;
        itemToBuy1.NPCType = AllEnums.BuyingItemTypes.KNB;
        frmLogin.GAuto.Settings.ListItemToBuy.Add(itemToBuy1);
        ItemToBuy itemToBuy2 = new ItemToBuy();
        itemToBuy2.Name = "KNB - Trân thú hồi xuân đan";
        if (frmLogin.GAuto.Settings.CompilingLanguage == "EN")
          itemToBuy2.Name = "TK - Lv 2 Pet Life Tonic";
        itemToBuy2.ID = 30607001;
        itemToBuy2.MenuKNB1 = 3;
        itemToBuy2.MenuKNB2 = 5;
        itemToBuy2.MenuIndex = 10;
        itemToBuy2.buyStampMax = 60000;
        itemToBuy2.NPCType = AllEnums.BuyingItemTypes.KNB;
        frmLogin.GAuto.Settings.ListItemToBuy.Add(itemToBuy2);
        ItemToBuy itemToBuy3 = new ItemToBuy();
        itemToBuy3.Name = "KNB - Tiên đan hồ lô";
        if (frmLogin.GAuto.Settings.CompilingLanguage == "EN")
          itemToBuy3.Name = "TK - Gild Gourd";
        itemToBuy3.ID = 31000001;
        itemToBuy3.MenuKNB1 = 4;
        itemToBuy3.MenuKNB2 = 1;
        itemToBuy3.MenuIndex = 4;
        itemToBuy3.buyStampMax = 60000;
        itemToBuy3.NPCType = AllEnums.BuyingItemTypes.KNB;
        frmLogin.GAuto.Settings.ListItemToBuy.Add(itemToBuy3);
        ItemToBuy itemToBuy4 = new ItemToBuy();
        itemToBuy4.Name = "KNB - Tiên lộ tịnh bình";
        if (frmLogin.GAuto.Settings.CompilingLanguage == "EN")
          itemToBuy4.Name = "TK - Angel's Wine Bottle";
        itemToBuy4.ID = 31000003;
        itemToBuy4.MenuKNB1 = 4;
        itemToBuy4.MenuKNB2 = 1;
        itemToBuy4.MenuIndex = 5;
        itemToBuy4.buyStampMax = 60000;
        itemToBuy4.NPCType = AllEnums.BuyingItemTypes.KNB;
        frmLogin.GAuto.Settings.ListItemToBuy.Add(itemToBuy4);
        ItemToBuy itemToBuy5 = new ItemToBuy();
        itemToBuy5.Name = "KNB - Thiên Linh Đan";
        if (frmLogin.GAuto.Settings.CompilingLanguage == "EN")
          itemToBuy5.Name = "TK - Blue Ball of Brilliance";
        itemToBuy5.ID = 30008002;
        itemToBuy5.MenuKNB1 = 4;
        itemToBuy5.MenuKNB2 = 1;
        itemToBuy5.MenuIndex = 7;
        itemToBuy5.buyStampMax = 60;
        itemToBuy5.NPCType = AllEnums.BuyingItemTypes.KNB;
        frmLogin.GAuto.Settings.ListItemToBuy.Add(itemToBuy5);
        ItemToBuy itemToBuy6 = new ItemToBuy();
        itemToBuy6.Name = "KNB - Mã yên";
        if (frmLogin.GAuto.Settings.CompilingLanguage == "EN")
          itemToBuy6.Name = "TK - Saddle";
        itemToBuy6.ID = 30008006;
        itemToBuy6.MenuKNB1 = 4;
        itemToBuy6.MenuKNB2 = 2;
        itemToBuy6.MenuIndex = 38;
        itemToBuy6.buyStampMax = 18000000;
        itemToBuy6.NPCType = AllEnums.BuyingItemTypes.KNB;
        frmLogin.GAuto.Settings.ListItemToBuy.Add(itemToBuy6);
        ItemToBuy itemToBuy7 = new ItemToBuy();
        itemToBuy7.Name = "KNB - Âm nguyệt tán (Băng)";
        if (frmLogin.GAuto.Settings.CompilingLanguage == "EN")
          itemToBuy7.Name = "TK - Moonlight Powder (Ice)";
        itemToBuy7.ID = 30005021;
        itemToBuy7.MenuKNB1 = 4;
        itemToBuy7.MenuKNB2 = 2;
        itemToBuy7.MenuIndex = 18;
        itemToBuy7.buyStampMax = 1800000;
        itemToBuy7.NPCType = AllEnums.BuyingItemTypes.KNB;
        frmLogin.GAuto.Settings.ListItemToBuy.Add(itemToBuy7);
        ItemToBuy itemToBuy8 = new ItemToBuy();
        itemToBuy8.Name = "KNB - Thiên nhãn đan (Huyền)";
        if (frmLogin.GAuto.Settings.CompilingLanguage == "EN")
          itemToBuy8.Name = "TK - Amber Capsule (Thunder)";
        itemToBuy8.ID = 30005022;
        itemToBuy8.MenuKNB1 = 4;
        itemToBuy8.MenuKNB2 = 2;
        itemToBuy8.MenuIndex = 19;
        itemToBuy8.buyStampMax = 1800000;
        itemToBuy8.NPCType = AllEnums.BuyingItemTypes.KNB;
        frmLogin.GAuto.Settings.ListItemToBuy.Add(itemToBuy8);
        ItemToBuy itemToBuy9 = new ItemToBuy();
        itemToBuy9.Name = "KNB - Bá vương hoàn (Hỏa)";
        if (frmLogin.GAuto.Settings.CompilingLanguage == "EN")
          itemToBuy9.Name = "TK - Lordly Capsule (Fire)";
        itemToBuy9.ID = 30005023;
        itemToBuy9.MenuKNB1 = 4;
        itemToBuy9.MenuKNB2 = 2;
        itemToBuy9.MenuIndex = 22;
        itemToBuy9.buyStampMax = 1800000;
        itemToBuy9.NPCType = AllEnums.BuyingItemTypes.KNB;
        frmLogin.GAuto.Settings.ListItemToBuy.Add(itemToBuy9);
        ItemToBuy itemToBuy10 = new ItemToBuy();
        itemToBuy10.Name = "KNB - Băng linh tán (Độc)";
        if (frmLogin.GAuto.Settings.CompilingLanguage == "EN")
          itemToBuy10.Name = "TK - Dark Olive Powder (Poison)";
        itemToBuy10.ID = 30005024;
        itemToBuy10.MenuKNB1 = 4;
        itemToBuy10.MenuKNB2 = 2;
        itemToBuy10.MenuIndex = 33;
        itemToBuy10.buyStampMax = 1800000;
        itemToBuy10.NPCType = AllEnums.BuyingItemTypes.KNB;
        frmLogin.GAuto.Settings.ListItemToBuy.Add(itemToBuy10);
        ItemToBuy itemToBuy11 = new ItemToBuy();
        itemToBuy11.Name = "KNB - Tuyền tinh tán (Băng)";
        if (frmLogin.GAuto.Settings.CompilingLanguage == "EN")
          itemToBuy11.Name = "TK - Rainbow Powder (Ice)";
        itemToBuy11.ID = 30005025;
        itemToBuy11.MenuKNB1 = 4;
        itemToBuy11.MenuKNB2 = 2;
        itemToBuy11.MenuIndex = 34;
        itemToBuy11.buyStampMax = 1800000;
        itemToBuy11.NPCType = AllEnums.BuyingItemTypes.KNB;
        frmLogin.GAuto.Settings.ListItemToBuy.Add(itemToBuy11);
        ItemToBuy itemToBuy12 = new ItemToBuy();
        itemToBuy12.Name = "KNB - Hổ nhãn tinh hoa 7";
        if (frmLogin.GAuto.Settings.CompilingLanguage == "EN")
          itemToBuy12.Name = "TK - Tigereye Essence (Lv 7)";
        itemToBuy12.ID = 30501180;
        itemToBuy12.MenuKNB1 = 2;
        itemToBuy12.MenuKNB2 = 2;
        itemToBuy12.MenuIndex = 24;
        itemToBuy12.buyStampMax = 172800000;
        itemToBuy12.NPCType = AllEnums.BuyingItemTypes.KNB;
        frmLogin.GAuto.Settings.ListItemToBuy.Add(itemToBuy12);
        ItemToBuy itemToBuy13 = new ItemToBuy();
        itemToBuy13.Name = "KNB - Miêu nhãn tinh hoa 7";
        if (frmLogin.GAuto.Settings.CompilingLanguage == "EN")
          itemToBuy13.Name = "TK - Opal Essence (Lv 7)";
        itemToBuy13.ID = 30501189;
        itemToBuy13.MenuKNB1 = 2;
        itemToBuy13.MenuKNB2 = 2;
        itemToBuy13.MenuIndex = 25;
        itemToBuy13.buyStampMax = 172800000;
        itemToBuy13.NPCType = AllEnums.BuyingItemTypes.KNB;
        frmLogin.GAuto.Settings.ListItemToBuy.Add(itemToBuy13);
        ItemToBuy itemToBuy14 = new ItemToBuy();
        itemToBuy14.Name = "KNB - Tử ngọc tinh hoa 7";
        if (frmLogin.GAuto.Settings.CompilingLanguage == "EN")
          itemToBuy14.Name = "TK - Amethyst Essence (Lv 7)";
        itemToBuy14.ID = 30501198;
        itemToBuy14.MenuKNB1 = 2;
        itemToBuy14.MenuKNB2 = 2;
        itemToBuy14.MenuIndex = 26;
        itemToBuy14.buyStampMax = 172800000;
        itemToBuy14.NPCType = AllEnums.BuyingItemTypes.KNB;
        frmLogin.GAuto.Settings.ListItemToBuy.Add(itemToBuy14);
        ItemToBuy itemToBuy15 = new ItemToBuy();
        itemToBuy15.Name = "KNB - Tổ mẫu lục tinh hoa 7";
        if (frmLogin.GAuto.Settings.CompilingLanguage == "EN")
          itemToBuy15.Name = "TK - Emerald Essence (Lv 7)";
        itemToBuy15.ID = 30501207;
        itemToBuy15.MenuKNB1 = 2;
        itemToBuy15.MenuKNB2 = 2;
        itemToBuy15.MenuIndex = 27;
        itemToBuy15.buyStampMax = 172800000;
        itemToBuy15.NPCType = AllEnums.BuyingItemTypes.KNB;
        frmLogin.GAuto.Settings.ListItemToBuy.Add(itemToBuy15);
        ItemToBuy itemToBuy16 = new ItemToBuy();
        itemToBuy16.Name = "KNB - Hồng tinh hoa 7 (Hỏa)";
        if (frmLogin.GAuto.Settings.CompilingLanguage == "EN")
          itemToBuy16.Name = "TK - Balas Essence (Lv 7) (Fire)";
        itemToBuy16.ID = 30501216;
        itemToBuy16.MenuKNB1 = 2;
        itemToBuy16.MenuKNB2 = 2;
        itemToBuy16.MenuIndex = 28;
        itemToBuy16.buyStampMax = 172800000;
        itemToBuy16.NPCType = AllEnums.BuyingItemTypes.KNB;
        frmLogin.GAuto.Settings.ListItemToBuy.Add(itemToBuy16);
        ItemToBuy itemToBuy17 = new ItemToBuy();
        itemToBuy17.Name = "KNB - Lam tinh hoa 7 (Băng)";
        if (frmLogin.GAuto.Settings.CompilingLanguage == "EN")
          itemToBuy17.Name = "TK - Cyanite Essence (Lv 7) (Ice)";
        itemToBuy17.ID = 30501225;
        itemToBuy17.MenuKNB1 = 2;
        itemToBuy17.MenuKNB2 = 2;
        itemToBuy17.MenuIndex = 29;
        itemToBuy17.buyStampMax = 172800000;
        itemToBuy17.NPCType = AllEnums.BuyingItemTypes.KNB;
        frmLogin.GAuto.Settings.ListItemToBuy.Add(itemToBuy17);
        ItemToBuy itemToBuy18 = new ItemToBuy();
        itemToBuy18.Name = "KNB - Hoàng tinh hoa 7 (Huyền)";
        if (frmLogin.GAuto.Settings.CompilingLanguage == "EN")
          itemToBuy18.Name = "TK - Citrine Essence (Lv 7) (Thunder)";
        itemToBuy18.ID = 30501234;
        itemToBuy18.MenuKNB1 = 2;
        itemToBuy18.MenuKNB2 = 2;
        itemToBuy18.MenuIndex = 30;
        itemToBuy18.buyStampMax = 172800000;
        itemToBuy18.NPCType = AllEnums.BuyingItemTypes.KNB;
        frmLogin.GAuto.Settings.ListItemToBuy.Add(itemToBuy18);
        ItemToBuy itemToBuy19 = new ItemToBuy();
        itemToBuy19.Name = "KNB - Lục tinh hoa 7 (Độc)";
        if (frmLogin.GAuto.Settings.CompilingLanguage == "EN")
          itemToBuy19.Name = "TK - Epidote Essence (Lv 7) (Poison)";
        itemToBuy19.ID = 30501243;
        itemToBuy19.MenuKNB1 = 2;
        itemToBuy19.MenuKNB2 = 2;
        itemToBuy19.MenuIndex = 31 /*0x1F*/;
        itemToBuy19.buyStampMax = 172800000;
        itemToBuy19.NPCType = AllEnums.BuyingItemTypes.KNB;
        frmLogin.GAuto.Settings.ListItemToBuy.Add(itemToBuy19);
      }
      foreach (HotKeyElement defaultHotKey in GA.DefaultHotKeys)
        GA.ActiveHotKeys.Add(new HotKeyElement()
        {
          Desc = defaultHotKey.Desc,
          KeyValue = defaultHotKey.KeyValue,
          KeyMessage = defaultHotKey.KeyMessage,
          NotDefault = false
        });
      GADB.LoadGlobalSettings();
      frmLogin.GAuto.Settings.AllInformationLoaded = true;
    })).Start();
  }

  public static int GetBlogSpotInfo()
  {
    int blogSpotInfo = 1;
    int num1 = 0;
    bool flag = false;
    string strURL = "http://kkksocial.blogspot.com/2016/12/have-fun.html";
    if (Monitor.TryEnter(frmLogin.bloglock))
    {
      try
      {
        while (true)
        {
          do
          {
            string input1 = GA.LoadWeb(strURL, "", "GET", (CookieContainer) null);
            if (input1.Contains(frmLogin.GAuto.Settings.LoadWebErrorMessage))
            {
              flag = true;
              if (frmLogin.GAuto.Settings.IsLoggedIn)
              {
                GA.WriteUserLog("Không lấy được link BS.");
              }
              else
              {
                int num2 = (int) MessageBox.Show("Không lấy được link BS #1. Click để tiếp tục đăng nhập", "Lỗi lấy thông tin", MessageBoxButtons.OK, MessageBoxIcon.Hand);
              }
            }
            if (num1 == 2)
            {
              strURL = GA.GetMidString(input1, "\"preview_url\": null, \"href\": \"", "\",");
              if (strURL != "")
              {
                input1 = GA.LoadWeb(strURL, "", "GET", (CookieContainer) null);
                if (input1.Contains(frmLogin.GAuto.Settings.LoadWebErrorMessage))
                {
                  flag = true;
                  if (frmLogin.GAuto.Settings.IsLoggedIn)
                  {
                    GA.WriteUserLog("Không lấy được link BS.");
                  }
                  else
                  {
                    int num3 = (int) MessageBox.Show("Không lấy được link BS.", "Lỗi lấy thông tin", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                  }
                }
              }
            }
            if (!flag)
            {
              if (input1.Contains("~190PA|") && input1.Contains("|=193SE") && !input1.Contains("hf899=="))
              {
                string input2 = "";
                try
                {
                  switch (num1)
                  {
                    case 0:
                      input2 = GA.GetMidString(input1, "itemprop='description articleBody'>", "<div style=").Replace("\n", "");
                      break;
                    case 1:
                      input2 = GA.GetMidString(input1, "meta name=\"description\" content=\"", "\" />");
                      break;
                    case 2:
                      input2 = GA.GetMidString(input1, "<pre id=\"code\" class=\"brush: text; plain-text\">", "</pre>");
                      break;
                    case 3:
                      input2 = GA.GetMidString(input1, "name-content-1\"><div dir=\"ltr\">", "</div>");
                      break;
                  }
                  input2 = GA.GetMidString(input2, "~190PA|", "|=193SE");
                  GA.DecryptBlogFun(input2);
                  if (GA.blogfun != null)
                  {
                    if (!GA.blogfun.servers.Contains("server1"))
                    {
                      if (frmLogin.GAuto.Settings.IsLoggedIn)
                      {
                        GA.WriteUserLog($"Không lấy được danh sách server. SV: <<<{GA.blogfun.servers}>>>");
                      }
                      else
                      {
                        int num4 = (int) MessageBox.Show($"Không lấy được danh sách server. SV: <<<{GA.blogfun.servers}>>>.\nLink: {strURL}", "Lỗi lấy thông tin", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                      }
                    }
                    GA.checkTimeout = (long) (GA.blogfun.i1 * 60000);
                    if (GA.blogfun.c1 == "DNF")
                      blogSpotInfo = 1;
                    else if (GA.blogfun.c1 == "SOK")
                      blogSpotInfo = 2;
                    else if (GA.blogfun.c1 == "SKO")
                      blogSpotInfo = 3;
                  }
                  else
                    flag = true;
                }
                catch (Exception ex)
                {
                  flag = true;
                  GA.blogfun = (BlogSpotFun) null;
                  GA.WriteUserLog($"Báo GAuto, giải mã BF bị lỗi [1]. Mykey: <<<{input2}>>>");
                }
              }
              else
              {
                GA.useBlog = false;
                GA.blogfun = new BlogSpotFun();
                flag = true;
              }
            }
            if (flag)
            {
              if (num1 <= 1)
              {
                flag = false;
                ++num1;
                if (num1 == 1)
                  strURL = "https://kkksocial.wordpress.com/2016/12/19/have-fun/";
                else if (num1 == 2)
                  strURL = "https://www.dropbox.com/s/ffj5n7965ugadj5/freemode.txt?dl=0";
              }
              else
                goto label_46;
            }
            else
              goto label_46;
          }
          while (num1 != 3);
          strURL = "https://sites.google.com/site/sgatokie/svlist/mysvlist";
        }
      }
      catch (Exception ex)
      {
        GA.useBlog = false;
        GA.blogfun = (BlogSpotFun) null;
        GA.WriteUserLog("Báo GAuto, giải mã BF bị lỗi [2]");
      }
      finally
      {
        if (GA.blogfun == null)
        {
          GA.blogfun = new BlogSpotFun();
          blogSpotInfo = 2;
        }
        else
          frmLogin.hasBlogSpot = true;
        Monitor.Exit(frmLogin.bloglock);
      }
    }
label_46:
    return blogSpotInfo;
  }

  public static bool CheckBlotSpot()
  {
    bool flag = false;
    int num = 0;
    string strURL = "http://kkksocial.blogspot.com/2016/12/just-login.html";
    if (Monitor.TryEnter(frmLogin.bloglock))
    {
      try
      {
        while (true)
        {
          string input = GA.LoadWeb(strURL, "", "GET", (CookieContainer) null);
          if (input.Contains("startkey|") && input.Contains("|endkey"))
          {
            if (!input.Contains("hf899=="))
            {
              try
              {
                string str;
                switch (num)
                {
                  case 0:
                    str = GA.GetMidString(input, "itemprop='description articleBody'>", "<div style=").Replace("\n", "");
                    break;
                  case 1:
                    str = GA.GetMidString(input, "meta name=\"description\" content=\"", "\" />");
                    break;
                }
                GA.blog = GA.DecryptBlogSpot(GA.GetMidString(input, "startkey|", "|endkey"));
                if (GA.blog == null)
                {
                  GA.useBlog = false;
                  GA.checkTimeout = 600000L;
                }
                else
                  GA.checkTimeout = 600000L;
              }
              catch (Exception ex)
              {
                GA.useBlog = false;
              }
            }
            else
              goto label_16;
          }
          else
            goto label_16;
label_10:
          if (input.Contains("hf899=="))
          {
            flag = true;
            GA.useBlog = true;
            GA.blog = new BlogSpotLogin();
            GA.blog.u = GA.GenerateRandomName(10);
            GA.blog.p = GA.GenerateRandomName(10);
          }
          if (!GA.useBlog)
          {
            if (GA.blog == null)
            {
              if (num == 0)
              {
                ++num;
                strURL = "https://kkksocial.wordpress.com/2016/12/17/first-blog-post/";
                continue;
              }
              break;
            }
            break;
          }
          break;
label_16:
          GA.useBlog = false;
          goto label_10;
        }
      }
      catch (Exception ex)
      {
        GA.useBlog = false;
        GA.blog = (BlogSpotLogin) null;
      }
      finally
      {
        Monitor.Exit(frmLogin.bloglock);
      }
    }
    return flag;
  }

  private void DownloadBalanceMod()
  {
    string[] strArray1 = frmLogin.GAuto.Settings.MainURL2.Split('|');
    int index = 0;
    do
    {
      string servers = GA.blogfun.servers;
      if (servers != "")
      {
        string str1 = servers;
        if (!str1.Contains("fack outta"))
        {
          if (!frmLogin.AutoInfoError)
          {
            try
            {
              string[] strArray2 = str1.Split('|');
              if (strArray2.Length > 0)
              {
                foreach (string str2 in strArray2)
                  frmLogin.AllGAutoServers.Add(new GAutoServer()
                  {
                    URL = str2.StartsWith("http://") ? (str2.EndsWith("/") ? str2 : str2 + "/") : (str2.EndsWith("/") ? "http://" + str2 : $"http://{str2}/")
                  });
              }
              frmLogin.GotBalanceList = true;
              break;
            }
            catch (Exception ex)
            {
            }
          }
        }
      }
      ++index;
    }
    while (index < strArray1.Length && !string.IsNullOrEmpty(strArray1[index]));
  }

  private void DownloadBalanceModV2()
  {
    string[] strArray1 = frmLogin.GAuto.Settings.MainURL2.Split('|');
    int index = 0;
    do
    {
      string str1 = GA.LoadWebNoAlive(strArray1[index] + frmLogin.GAuto.Settings.ServerListURL, "check=8190526", "POST", (CookieContainer) null);
      if (!str1.Contains(frmLogin.GAuto.Settings.LoadWebErrorMessage))
      {
        string str2 = HttpUtility.UrlDecode(str1);
        try
        {
          str2 = Encoding.UTF8.GetString(Convert.FromBase64String(str2));
        }
        catch (Exception ex)
        {
          frmLogin.AutoInfoError = true;
        }
        string str3 = GA.XOREncrypt(str2, "(of-?aK@@");
        try
        {
          str3 = Encoding.UTF8.GetString(Convert.FromBase64String(str3));
        }
        catch (Exception ex)
        {
          frmLogin.AutoInfoError = true;
        }
        string myField = GA.GetMyField(str3, "msg");
        if (!myField.Contains("fack outta"))
        {
          if (!frmLogin.AutoInfoError)
          {
            try
            {
              string[] strArray2 = myField.Split('|');
              if (strArray2.Length > 0)
              {
                foreach (string str4 in strArray2)
                  frmLogin.AllGAutoServers.Add(new GAutoServer()
                  {
                    URL = str4.StartsWith("http://") ? (str4.EndsWith("/") ? str4 : str4 + "/") : (str4.EndsWith("/") ? "http://" + str4 : $"http://{str4}/")
                  });
              }
              frmLogin.GotBalanceList = true;
              break;
            }
            catch (Exception ex)
            {
            }
          }
        }
      }
      ++index;
    }
    while (index < strArray1.Length && !string.IsNullOrEmpty(strArray1[index]));
  }

  private void DownloadBalance()
  {
    string[] strArray1 = frmLogin.GAuto.Settings.MainURL2.Split('|');
    int index = 0;
    do
    {
      string str1 = GA.LoadWebNoAlive(strArray1[index] + frmLogin.GAuto.Settings.ServerListURL, "check=8190526", "POST", (CookieContainer) null);
      if (!str1.Contains(frmLogin.GAuto.Settings.LoadWebErrorMessage))
      {
        string str2 = HttpUtility.UrlDecode(str1);
        try
        {
          str2 = Encoding.UTF8.GetString(Convert.FromBase64String(str2));
        }
        catch (Exception ex)
        {
          frmLogin.AutoInfoError = true;
        }
        string str3 = GA.XOREncrypt(str2, "(of-?aK@@");
        try
        {
          str3 = Encoding.UTF8.GetString(Convert.FromBase64String(str3));
        }
        catch (Exception ex)
        {
          frmLogin.AutoInfoError = true;
        }
        string myField = GA.GetMyField(str3, "msg");
        if (!myField.Contains("fack outta"))
        {
          if (!frmLogin.AutoInfoError)
          {
            try
            {
              string[] strArray2 = myField.Split('|');
              if (strArray2.Length > 0)
              {
                foreach (string str4 in strArray2)
                  frmLogin.AllGAutoServers.Add(new GAutoServer()
                  {
                    URL = str4.StartsWith("http://") ? (str4.EndsWith("/") ? str4 : str4 + "/") : (str4.EndsWith("/") ? "http://" + str4 : $"http://{str4}/")
                  });
              }
              frmLogin.GotBalanceList = true;
              break;
            }
            catch (Exception ex)
            {
            }
          }
        }
      }
      ++index;
    }
    while (index < strArray1.Length && !string.IsNullOrEmpty(strArray1[index]));
  }

  public static void ChangeLanguage()
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
  }

  public static void DownloadMyBaseMod()
  {
    long elapsedMilliseconds = frmLogin.GlobalTimer.ElapsedMilliseconds;
    string str = "";
    if (GA.blogfun != null && GA.blogfun.s1 != "")
      str = GA.blogfun.s1;
    bool flag = false;
    GAutoServer gautoServer = (GAutoServer) null;
    if (frmLogin.CompilingLanguage == "VN" || frmLogin.VIPMode == 2 || frmLogin.VIPMode == 3)
      gautoServer = frmLogin.MainGAutoServer != null ? frmLogin.MainGAutoServer : GA.PickGAutoServer();
    if (!str.Contains(frmLogin.GAuto.Settings.LoadWebErrorMessage))
    {
      if ((frmLogin.CompilingLanguage != "CN" || frmLogin.VIPMode == 1 || frmLogin.VIPMode == 2) && (frmLogin.VIPMode != 3 || frmLogin.ReadOldStyle) && !str.Contains(frmLogin.GAuto.Settings.LoadWebErrorMessage))
      {
        string[] strArray = str.Split(':');
        int result = 0;
        if (strArray.Length >= 5)
        {
          int.TryParse(strArray[0], out result);
          if (result > 0)
          {
            for (int index = 0; index < result; ++index)
              frmLogin.MyBases.Add(new BaseInfo()
              {
                myHash = strArray[index * 4 + 1],
                myVersion = strArray[index * 4 + 2],
                myProvider = strArray[index * 4 + 3],
                myInfo = GA.XOREncrypt(strArray[index * 4 + 4], "TDTthangancap")
              });
          }
        }
      }
      if (!flag)
        frmLogin.MainGAutoServer = gautoServer;
    }
    if (frmLogin.MainGAutoServer != null && frmLogin.CompilingLanguage != "CN" || frmLogin.CompilingLanguage == "CN" || frmLogin.CompilingLanguage == "EN")
    {
      if (frmLogin.CompilingLanguage != "VN")
        new Thread(new ThreadStart(frmMain.GetGLoginServers))
        {
          IsBackground = true
        }.Start();
      else
        frmMain.GetGLoginServersMod();
    }
    else
    {
      int num = (int) MessageBox.Show(frmMain.langCheckConnection);
      GA.ExitAndCleanup();
    }
    if (flag)
      return;
    frmLogin.FinishDownloadingBases = true;
  }

  public static void DownloadMyBase()
  {
    long elapsedMilliseconds = frmLogin.GlobalTimer.ElapsedMilliseconds;
    string str1 = "";
    bool flag1 = false;
    GAutoServer gautoServer = (GAutoServer) null;
    if (!GA.useBlog)
    {
      if (frmLogin.CompilingLanguage == "VN" || frmLogin.VIPMode == 2 || frmLogin.VIPMode == 3)
        gautoServer = frmLogin.MainGAutoServer != null ? frmLogin.MainGAutoServer : GA.PickGAutoServer();
    }
    else
    {
      gautoServer = new GAutoServer();
      gautoServer.LastOption = true;
      gautoServer.Percent = 100;
      gautoServer.TriedMe = true;
      gautoServer.URL = "http://server1.gameauto.net/";
    }
    string data = $"data={HttpUtility.UrlEncode(Convert.ToBase64String(Encoding.ASCII.GetBytes(GA.XOREncrypt(Convert.ToBase64String(Encoding.ASCII.GetBytes("Tieu Dat Tai la thang an cap - Than Long la thang 2 mat =))")), "TDTthangancap(TL2mat@#1"))))}";
    string randomName = GA.GenerateRandomName(13);
    if (!GA.useBlog)
    {
      if ((frmLogin.CompilingLanguage != "CN" || frmLogin.VIPMode == 1 || frmLogin.VIPMode == 2) && frmLogin.VIPMode != 3)
      {
        if (frmLogin.CompilingLanguage == "EN" || frmLogin.VIPMode == 2)
          str1 = GA.LoadWeb(frmLogin.GAuto.Settings.GetAddressURL, data, "POST", frmLogin.GAuto.Settings.MainCookie);
        else if (frmLogin.CompilingLanguage == "VN" || frmLogin.VIPMode == 1)
          str1 = GA.LoadWeb(gautoServer.URL + frmLogin.GAuto.Settings.GetAddressURL, data, "POST", frmLogin.GAuto.Settings.MainCookie);
      }
      else
        str1 = frmLogin.ReadOldStyle ? GA.LoadWeb(frmLogin.GAuto.Settings.GetAddressURL, data, "POST", frmLogin.GAuto.Settings.MainCookie) : GA.LoadWeb(frmLogin.GAuto.Settings.GetAddressURL, "check=1589&vbb=" + randomName, "POST", frmLogin.GAuto.Settings.MainCookie);
      str1 = HttpUtility.UrlDecode(str1);
    }
    if (!str1.Contains(frmLogin.GAuto.Settings.LoadWebErrorMessage))
    {
      if ((frmLogin.CompilingLanguage != "CN" || frmLogin.VIPMode == 1 || frmLogin.VIPMode == 2) && (frmLogin.VIPMode != 3 || frmLogin.ReadOldStyle))
      {
        if (!GA.useBlog)
        {
          try
          {
            str1 = Encoding.UTF8.GetString(Convert.FromBase64String(str1));
          }
          catch (Exception ex)
          {
            flag1 = true;
          }
          if (str1.Contains("GETADDRESS_OK:"))
            str1 = str1.Remove(0, 14);
          str1 = GA.XOREncrypt(str1, "TDTthangancap(TL2mat@#1");
          try
          {
            str1 = Encoding.UTF8.GetString(Convert.FromBase64String(str1));
          }
          catch (Exception ex)
          {
            flag1 = true;
          }
        }
        if (!str1.Contains(frmLogin.GAuto.Settings.LoadWebErrorMessage))
        {
          string[] strArray = str1.Split(':');
          int result = 0;
          if (strArray.Length >= 5)
          {
            int.TryParse(strArray[0], out result);
            if (result > 0)
            {
              for (int index = 0; index < result; ++index)
                frmLogin.MyBases.Add(new BaseInfo()
                {
                  myHash = strArray[index * 4 + 1],
                  myVersion = strArray[index * 4 + 2],
                  myProvider = strArray[index * 4 + 3],
                  myInfo = GA.XOREncrypt(strArray[index * 4 + 4], "TDTthangancap")
                });
            }
          }
        }
      }
      else
      {
        if (!(frmLogin.CompilingLanguage == "CN"))
        {
          if (frmLogin.VIPMode != 3)
            goto label_97;
        }
        try
        {
          str1 = Encoding.UTF8.GetString(Convert.FromBase64String(str1));
        }
        catch (Exception ex)
        {
          flag1 = true;
        }
        string str2 = GA.XOREncrypt(GA.XOREncrypt(str1, "508f7!2=fhaA]|a"), randomName);
        try
        {
          str2 = Encoding.UTF8.GetString(Convert.FromBase64String(str2));
        }
        catch (Exception ex)
        {
          flag1 = true;
        }
        string myField = GA.GetMyField(str2, "count");
        int result = 0;
        int.TryParse(myField, out result);
        if (result > 0)
        {
          for (int index1 = 1; index1 <= result; ++index1)
          {
            Dictionary<string, string> allFields = GA.GetAllFields(GA.GetMyField(str2, "base-" + index1.ToString("00")));
            string str3 = "";
            allFields.TryGetValue("key", out str3);
            bool flag2 = false;
            if (str3 != "" && frmLogin.GamePatterns.Count > 0)
            {
              for (int index2 = 0; index2 < frmLogin.GamePatterns.Count; ++index2)
              {
                if (frmLogin.GamePatterns[index2].GameKey == str3)
                {
                  flag2 = true;
                  break;
                }
              }
            }
            if (!flag2)
            {
              GGameMemory ggameMemory = new GGameMemory();
              ggameMemory.GameKey = str3;
              string str4 = "";
              allFields.TryGetValue("vercode", out str4);
              if (str4 != "")
              {
                if (str4.Contains("|"))
                {
                  string str5 = str4;
                  char[] chArray = new char[1]{ '|' };
                  foreach (string str6 in str5.Split(chArray))
                  {
                    if (str6 != "")
                      ggameMemory.GameVersionCode.Add(str6);
                  }
                }
                else
                  ggameMemory.GameVersionCode.Add(str4);
              }
              foreach (KeyValuePair<string, string> keyValuePair in allFields)
              {
                if (keyValuePair.Key.StartsWith("pat_"))
                  ggameMemory.Patterns.Add(new GPattern()
                  {
                    Name = keyValuePair.Key,
                    Pattern = GA.StringToByteArray(keyValuePair.Value)
                  });
                else if (keyValuePair.Key.StartsWith("bs"))
                {
                  GMemBase gmemBase = new GMemBase();
                  string[] strArray = keyValuePair.Value.Split('|');
                  gmemBase.Name = keyValuePair.Key;
                  if (strArray[1] != "_")
                  {
                    if (ggameMemory.Patterns.Count > 0)
                    {
                      foreach (GPattern pattern in ggameMemory.Patterns)
                      {
                        if (pattern.Name == strArray[1])
                        {
                          gmemBase.Pattern = pattern;
                          break;
                        }
                      }
                    }
                    gmemBase.ReadMem = strArray[2] == "1";
                    int.TryParse(strArray[3], out gmemBase.Index);
                    if (strArray[4].StartsWith("-"))
                    {
                      int int32 = Convert.ToInt32(strArray[4].Substring(1, strArray[4].Length - 1), 16 /*0x10*/);
                      gmemBase.Offset = int32 * -1;
                    }
                    else
                    {
                      strArray[4] = strArray[4].Replace(" ", "");
                      gmemBase.Offset = Convert.ToInt32(strArray[4], 16 /*0x10*/);
                    }
                    if (strArray[5].StartsWith("-"))
                    {
                      int int32 = Convert.ToInt32(strArray[5].Substring(1, strArray[5].Length - 1), 16 /*0x10*/);
                      gmemBase.AddSub = int32 * -1;
                    }
                    else
                    {
                      strArray[5] = strArray[5].Replace(" ", "");
                      gmemBase.AddSub = Convert.ToInt32(strArray[5], 16 /*0x10*/);
                    }
                  }
                  else
                  {
                    gmemBase.Value = Convert.ToInt32(strArray[2], 16 /*0x10*/);
                    gmemBase.IsRead = true;
                  }
                  ggameMemory.Membases.Add(gmemBase);
                }
                else if (keyValuePair.Key.StartsWith("op_"))
                {
                  GOpcode gopcode = new GOpcode();
                  string[] strArray1 = keyValuePair.Value.Split('|');
                  gopcode.Desc = strArray1[0];
                  string[] strArray2 = strArray1[1].Split(';');
                  int.TryParse(strArray2[1], out gopcode.Index);
                  int.TryParse(strArray2[2], out gopcode.NOPFills);
                  if (ggameMemory.Membases.Count > 0)
                  {
                    foreach (GMemBase membase in ggameMemory.Membases)
                    {
                      if (membase.Name == strArray2[0])
                      {
                        gopcode.MyBase = membase;
                        break;
                      }
                    }
                  }
                  ggameMemory.Opcodes.Add(gopcode);
                }
                else if (keyValuePair.Key.StartsWith("rm_") && keyValuePair.Value != "")
                {
                  GReadMem greadMem = new GReadMem();
                  string[] strArray = keyValuePair.Value.Split('|');
                  greadMem.Desc = strArray[0];
                  greadMem.Name = strArray[1];
                  greadMem.DataType = strArray[2];
                  if (strArray[3].Contains(";"))
                  {
                    string str7 = strArray[3];
                    char[] chArray = new char[1]{ ';' };
                    foreach (string str8 in str7.Split(chArray))
                      greadMem.DataString.Add(str8);
                  }
                  else
                    greadMem.DataString.Add(strArray[3]);
                  greadMem.HasFinalOffset = greadMem.Name.Contains(".");
                  if (greadMem.HasFinalOffset)
                    greadMem.FinalOffsetName = greadMem.Name.Split('.')[1];
                  ggameMemory.Readmems.Add(greadMem);
                }
              }
              frmLogin.GamePatterns.Add(ggameMemory);
            }
          }
        }
      }
label_97:
      if (!flag1)
        frmLogin.MainGAutoServer = gautoServer;
    }
    if (frmLogin.MainGAutoServer != null && frmLogin.CompilingLanguage != "CN")
      frmLogin.CompilingLanguage = "VN";
    if (frmLogin.MainGAutoServer != null && frmLogin.CompilingLanguage != "CN" || frmLogin.CompilingLanguage == "CN" || frmLogin.CompilingLanguage == "EN")
    {
      new Thread(new ThreadStart(frmMain.GetGLoginServers))
      {
        IsBackground = true
      }.Start();
    }
    else
    {
      int num = (int) MessageBox.Show(frmMain.langCheckConnection);
      GA.ExitAndCleanup();
    }
    if (flag1)
      return;
    frmLogin.FinishDownloadingBases = true;
  }

  public static bool SetAllowUnsafeHeaderParsing20()
  {
    Assembly assembly = Assembly.GetAssembly(typeof (SettingsSection));
    if (assembly != null)
    {
      System.Type type = assembly.GetType("System.Net.Configuration.SettingsSectionInternal");
      if (type != null)
      {
        object obj = type.InvokeMember("Section", BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.GetProperty, (Binder) null, (object) null, new object[0]);
        if (obj != null)
        {
          FieldInfo field = type.GetField("useUnsafeHeaderParsing", BindingFlags.Instance | BindingFlags.NonPublic);
          if (field != null)
          {
            field.SetValue(obj, (object) true);
            return true;
          }
        }
      }
    }
    return false;
  }

  private void secureLogon_OnConnectionEstablished(
    object sender,
    OnConnectionEstablishedEventArgs e)
  {
  }

  private void secureLogon_OnResponseReceived(object sender, ResponseReceivedEventArgs e)
  {
  }

  private void LogonProcess(string strResponse) => this.btnLogin.Enabled = true;

  private void LoginProcess(string strResponse)
  {
    switch (frmLogin.GAuto.Settings.LoginInfo["response"])
    {
      case "LOGIN_OK":
        new frmMain().Show();
        break;
      case "LOGIN_EXPIRES":
        this.btnLogin.Enabled = true;
        GA.Message("Tài khoản của bạn đã hết hạn.\nVui lòng nạp thẻ để có thể tiếp tục sử dụng.");
        new frmReg().Show();
        break;
    }
  }

  private void itemSignUp_Click(object sender, EventArgs e) => frmLogin.RegisterNewAccountForm();

  private static void RegisterNewAccountForm()
  {
    if (frmLogin.CompilingLanguage == "VN")
      frmLogin.OpenRegisterForm();
    else
      frmLogin.OpenEnglishRegForm();
  }

  private static void OpenEnglishRegForm()
  {
    int num = (int) new frmReg().ShowDialog();
  }

  private static void OpenRegisterForm()
  {
    int num = (int) new frmReg().ShowDialog();
  }

  private void itemForgetPassword_Click(object sender, EventArgs e)
  {
    if (!(frmLogin.CompilingLanguage == "VN"))
      return;
    Process.Start("http://server1.gameauto.net/forum/ucp.php?mode=sendpassword");
  }

  private void btnLogin_Click(object sender, EventArgs e)
  {
    this.btnLogin.Enabled = false;
    this.btnLoginClick();
  }

  private void btnLoginClick()
  {
    bool flag = false;
    this.txtUserID.Text = "CodeCrack";
    this.txtUserPassword.Text = "FUCKGAUTO";
    if (GA.CheckForSQLInjection(this.txtUserID.Text))
      flag = true;
    if (flag)
    {
      int num = (int) MessageBox.Show("Tên đăng nhập của bạn có ký tự đặc biệt, vui lòng tạo tài khoản mới", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }
    if (string.IsNullOrEmpty(this.txtUserID.Text) || string.IsNullOrEmpty(this.txtUserPassword.Text) || flag)
      return;
    this.lblStatus.ForeColor = Color.Green;
    this.lblStatus.Text = frmMain.langLoggingIn;
    frmLogin.SwitchURL = string.Compare(this.txtUserID.Text, "gautofree", StringComparison.CurrentCulture) == 0;
    if (this.cboxSavePass.Checked && (this.passwordChanged || this.usernameChanged))
    {
      DBInfoClass info1 = new DBInfoClass();
      info1.Key = "autousername";
      info1.Value = this.txtUserID.Text;
      info1.Description = "Tên đăng nhập vào auto";
      GADB.ProcessInfoDB("", true, info1.Key, info1);
      DBInfoClass info2 = new DBInfoClass()
      {
        Key = "autopassword",
        Value = GA.XOREncrypt(this.txtUserPassword.Text, frmLogin.GAuto.Settings.PasswordEncKey)
      };
      info2.Value = Convert.ToBase64String(Encoding.UTF8.GetBytes(info2.Value));
      GADB.ProcessInfoDB("", true, info2.Key, info2);
      DBInfoClass info3 = new DBInfoClass();
      info3.Key = "savepass";
      info3.Value = "1";
      GADB.ProcessInfoDB("", true, info3.Key, info3);
    }
    else if (!this.cboxSavePass.Checked)
    {
      DBInfoClass info4 = new DBInfoClass();
      info4.Key = "autousername";
      info4.Value = "";
      info4.Description = "Tên đăng nhập vào auto";
      GADB.ProcessInfoDB("", true, info4.Key, info4);
      DBInfoClass info5 = new DBInfoClass();
      info5.Key = "autopassword";
      info5.Value = "";
      GADB.ProcessInfoDB("", true, info5.Key, info5);
      DBInfoClass info6 = new DBInfoClass();
      info6.Key = "savepass";
      info6.Value = "0";
      GADB.ProcessInfoDB("", true, info6.Key, info6);
    }
    if (frmLogin.CompilingLanguage == "VN")
    {
      DBInfoClass info = new DBInfoClass();
      info.Key = "chedoonly";
      info.Value = this.cboxOnlyCheDo.Checked ? "1" : "0";
      GADB.ProcessInfoDB("", true, info.Key, info);
      info.Key = "cboxMoThuongNhan";
      info.Value = this.cboxMoThuongNhan.Checked ? "1" : "0";
      GADB.ProcessInfoDB("", true, info.Key, info);
    }
    if (!this.backgroundWorker1.IsBusy)
    {
      LoginParams loginParams = new LoginParams();
      loginParams.Username = this.txtUserID.Text;
      loginParams.Password = this.txtUserPassword.Text;
      loginParams.ShowForm = true;
      loginParams.Action = "login";
      this.btnLogin.Enabled = false;
      this.flagLoginCount = frmLogin.GlobalTimer.ElapsedMilliseconds;
      this.backgroundWorker1.RunWorkerAsync((object) loginParams);
    }
    else
      GA.ShowMessage("Hệ thống đang bận, vui lòng bấm đăng nhập lần nữa.", "Hệ thống bận");
  }

  private void frmLogin_Load(object sender, EventArgs e)
  {
    this.cboxOnlyCheDo.Visible = false;
    if (!System.IO.File.Exists(".\\System.Data.SQLite.dll"))
    {
      int num = (int) MessageBox.Show(frmMain.langLackofFiles1, frmMain.langNeedFiles, MessageBoxButtons.OK, MessageBoxIcon.Hand);
      GA.ExitAndCleanup();
    }
    else
    {
      frmLogin.GAuto.Settings.Account.EncryptionTime = Math.Abs(Environment.TickCount);
      frmLogin.GAuto.Settings.Account.TrafficKey = GA.ConvertToSecureString(frmLogin.GAuto.Settings.Account.EncryptionTime.ToString("0") + "fuckTDT-TL");
      this.ProcessToolTip();
      DBInfoClass info1 = new DBInfoClass();
      GADB.ProcessInfoDB((string) null, false, "savepass", info1);
      if (info1.Value == "1")
      {
        this.cboxSavePass.Checked = true;
        GADB.ProcessInfoDB((string) null, false, "autousername", info1);
        this.txtUserID.Text = info1.Value;
        GADB.ProcessInfoDB((string) null, false, "autopassword", info1);
        byte[] bytes = Convert.FromBase64String(info1.Value);
        info1.Value = Encoding.UTF8.GetString(bytes);
        info1.Value = GA.XOREncrypt(info1.Value, frmLogin.GAuto.Settings.PasswordEncKey);
        this.txtUserPassword.Text = info1.Value;
      }
      else
        this.cboxSavePass.Checked = false;
      if (frmLogin.CompilingLanguage == "VN")
      {
        DBInfoClass info2 = new DBInfoClass();
        GADB.ProcessInfoDB((string) null, false, "chedoonly", info2);
        if (info2.Value == "1")
        {
          this.cboxOnlyCheDo.Checked = true;
          frmLogin.GAuto.Settings.cboxOnlyCheDo = true;
        }
        else
        {
          this.cboxOnlyCheDo.Checked = false;
          frmLogin.GAuto.Settings.cboxOnlyCheDo = false;
        }
        GADB.ProcessInfoDB((string) null, false, "cboxMoThuongNhan", info2);
        if (info2.Value == "1")
        {
          this.cboxMoThuongNhan.Checked = true;
          frmLogin.GAuto.Settings.cboxMoThuongNhan = true;
        }
        else
        {
          this.cboxMoThuongNhan.Checked = false;
          frmLogin.GAuto.Settings.cboxMoThuongNhan = false;
        }
      }
      this.checkPasswordChanged = true;
      this.checkUserNameChanged = true;
    }
  }

  private void ProcessToolTip()
  {
    ToolTip toolTip = new ToolTip();
    toolTip.OwnerDraw = true;
    toolTip.BackColor = Color.Yellow;
    toolTip.AutoPopDelay = 20000;
    toolTip.InitialDelay = 500;
    toolTip.ReshowDelay = 500;
    toolTip.ShowAlways = true;
    toolTip.IsBalloon = true;
    toolTip.SetToolTip((Control) this.cboxSavePass, frmMain.langSecurePassword1);
    toolTip.SetToolTip((Control) this.txtUserID, frmMain.langUsernameWarning);
    toolTip.SetToolTip((Control) this.txtUserPassword, frmMain.langPasswordWarning);
  }

  public static void SaveProfileList(object list, string key)
  {
    string str = "";
    foreach (LoginProfileClass loginProfileClass in (List<LoginProfileClass>) (list as GAutoList<LoginProfileClass>))
    {
      if (key == "ListLoginProfile")
      {
        string base64String = Convert.ToBase64String(Encoding.UTF8.GetBytes(GA.XOREncrypt(GA.SecureStringToString(loginProfileClass.Password), "%6fhru4?")));
        str += $"{loginProfileClass.Username};{base64String};{loginProfileClass.NPH};{loginProfileClass.Server};{loginProfileClass.MinorServer};{loginProfileClass.CharName};{loginProfileClass.GamePath}|";
      }
    }
    frmLogin.GAuto.Settings.SaveSingleSetting(key, str);
    GC.Collect();
  }

  private void SaveStringList(object list, string keyname)
  {
    string str1 = "";
    foreach (string str2 in (List<string>) (list as GAutoList<string>))
      str1 = $"{str1}{str2}|";
    frmLogin.GAuto.Settings.SaveSingleSetting(keyname, str1, "Danh sách các món đồ cần nhặt");
  }

  public void ItemBanList_OnRemove(object sender, EventArgs e)
  {
    this.SaveStringList(sender, "ItemBanList");
  }

  public void ListLoginProfile_OnRemove(object sender, EventArgs e)
  {
    frmLogin.SaveProfileList(sender, "ListLoginProfile");
  }

  public void ListLoginProfile_OnAdd(object sender, EventArgs e)
  {
  }

  public void ItemBanList_OnAdd(object sender, EventArgs e)
  {
    this.SaveStringList(sender, "ItemBanList");
  }

  public void ListBuffPetID_OnAdd(object sender, EventArgs e)
  {
    this.SaveStringList(sender, "ListBuffPetID");
  }

  public void ListBuffPetID_OnRemove(object sender, EventArgs e)
  {
    this.SaveStringList(sender, "ListBuffPetID");
  }

  public void BuffNameList_OnAdd(object sender, EventArgs e)
  {
    this.SaveStringList(sender, "BuffNameList");
  }

  public void BuffNameList_Remove(object sender, EventArgs e)
  {
    this.SaveStringList(sender, "BuffNameList");
  }

  public void ItemKhongNhatList_OnRemove(object sender, EventArgs e)
  {
    this.SaveStringList(sender, "ItemTuHuyList");
  }

  public void ItemKhongNhatList_OnAdd(object sender, EventArgs e)
  {
    this.SaveStringList(sender, "ItemTuHuyList");
  }

  public void ListItemNhat_OnRemove(object sender, EventArgs e)
  {
    this.SaveStringList(sender, "ListItemNhat");
  }

  public void ListItemNhat_OnAdd(object sender, EventArgs e)
  {
    this.SaveStringList(sender, "ListItemNhat");
  }

  private void CheckServerStatus()
  {
  }

  private void vềChươngTrìnhToolStripMenuItem_Click(object sender, EventArgs e) => GA.AboutUs();

  private void trangChủToolStripMenuItem_Click(object sender, EventArgs e) => GA.BrowseMainpage();

  private string GetServerGoogle()
  {
    string serverGoogle = "server1.gameauto.net|server2.gameauto.net";
    string input = GA.LoadWeb("https://sites.google.com/site/sgatokie/svlist/mysvlist", "", "GET", frmLogin.GAuto.Settings.MainCookie);
    if (!input.Contains(frmLogin.GAuto.Settings.LoadWebErrorMessage))
    {
      string midString = GA.GetMidString(input, "name-content-1\"><div dir=\"ltr\">", "</div>");
      if (midString != "")
      {
        string Input = midString.Remove(0, 10);
        try
        {
          serverGoogle = JsonConvert.DeserializeObject<BlogServers>(GA.AES_decrypt(Input, 1)).servers;
        }
        catch (Exception ex)
        {
        }
      }
    }
    return serverGoogle;
  }

  private void hướngDẫnĐăngKýToolStripMenuItem_Click(object sender, EventArgs e)
  {
    GA.BrowseRegistrationGuide();
  }

  private void hướngDẫnSửDụngToolStripMenuItem_Click(object sender, EventArgs e)
  {
    GA.BrowseUserGuide();
  }

  private void diễnĐànGAutoToolStripMenuItem_Click(object sender, EventArgs e)
  {
    GA.BrowseGAutoForum();
  }

  private void button1_Click(object sender, EventArgs e)
  {
    if (SmartClass.servermode != 2)
    {
      frmLogin.RegisterNewAccountForm();
    }
    else
    {
      int num = (int) MessageBox.Show("Auto đang miễn phí, bạn dùng tài khoản: \"gauto\" password: \"gautofree\" để đăng nhập.");
    }
  }

  private void updateGAutoToolStripMenuItem_Click(object sender, EventArgs e)
  {
    frmLogin.UpdateMyAuto();
  }

  public static void UpdateMyAuto(bool forcefully = false)
  {
    if (frmLogin.AutoVersion == GA.GetMyVersion())
    {
      frmLogin.NeedUpdate = false;
      forcefully = false;
    }
    if (forcefully)
      frmLogin.UpdateFile = "anything.zip";
    if (!frmLogin.NeedUpdate && !forcefully)
      return;
    ProcessStartInfo startInfo = new ProcessStartInfo();
    startInfo.FileName = frmLogin.GAuto.Settings.UpdaterEXE;
    string str = GA.GetMyVersion().Replace(".", "");
    startInfo.Arguments = string.Format("{3} {0} {1} {2}", (object) frmLogin.UpdateFile, (object) AppDomain.CurrentDomain.FriendlyName, (object) str, (object) frmLogin.GAuto.Settings.GameID);
    startInfo.WindowStyle = ProcessWindowStyle.Normal;
    Process.Start(startInfo);
    if (forcefully)
      frmLogin.ForcefullyExit = true;
    else
      GA.ExitAndCleanup();
  }

  private void timerLogin_Tick(object sender, EventArgs e)
  {
    if (!frmLogin.ShowGUI)
    {
      if (frmLogin.CompilingLanguage == "VN" || frmLogin.VIPMode == 1 || frmLogin.VIPMode == 2)
      {
        if (frmLogin.MainGAutoServer != null && frmLogin.FinishDownloadingBases)
        {
          this.btnLogin.Enabled = true;
          this.btnNapThe.Enabled = true;
          this.lblForgotPassword.Enabled = true;
          this.linkChangePass.Enabled = true;
          this.btnNewAccount.Enabled = true;
          frmLogin.ShowGUI = true;
        }
      }
      else
      {
        this.btnLogin.Enabled = true;
        this.btnNapThe.Enabled = true;
        this.lblForgotPassword.Enabled = true;
        this.linkChangePass.Enabled = true;
        this.btnNewAccount.Enabled = true;
        frmLogin.ShowGUI = true;
      }
    }
    if (this.Visible && this.flagLoginCount > 0L)
      this.btnLogin.Text = frmMain.langLogIn + $" ({Math.Round((double) (frmLogin.GlobalTimer.ElapsedMilliseconds - this.flagLoginCount) / 1000.0)})s";
    if (frmLogin.killautoStamp <= 0L || frmLogin.GlobalTimer.ElapsedMilliseconds <= frmLogin.killautoStamp)
      return;
    GA.ExitAndCleanup();
  }

  public string Myname
  {
    get => this._MyName;
    set
    {
      this._MyName = value;
      DBInfoClass dbInfoClass = new DBInfoClass();
      FieldInfo field = this.GetType().GetField("Name");
      dbInfoClass.Key = field.Name;
      dbInfoClass.Value = value;
      dbInfoClass.Description = "Chuyến cuối đi TN là hướng nào";
    }
  }

  private void label1_Click(object sender, EventArgs e)
  {
  }

  private void myList_OnAdd(object sender, EventArgs e)
  {
  }

  private void pictureBox1_Click(object sender, EventArgs e) => GA.BrowseMainpage();

  private void txtUserPassword_TextChanged(object sender, EventArgs e)
  {
    if (!this.checkPasswordChanged)
      return;
    this.passwordChanged = true;
  }

  private void cboxSavePass_CheckedChanged(object sender, EventArgs e)
  {
  }

  public static void OpenNapTheForm(string username = "")
  {
    frmNapThe frmNapThe = new frmNapThe();
    frmNapThe.myGrandAccount = frmLogin.GAuto;
    if (!string.IsNullOrEmpty(username))
      frmNapThe.defaultAccount = username;
    int num = (int) frmNapThe.ShowDialog();
  }

  private void nạpThẻToolStripMenuItem_Click(object sender, EventArgs e)
  {
    frmLogin.OpenNapTheForm();
  }

  private void txtUserID_TextChanged(object sender, EventArgs e)
  {
    if (!this.checkUserNameChanged)
      return;
    this.usernameChanged = true;
  }

  private void btnNapThe_Click(object sender, EventArgs e) => frmMain.MyFormNapThe();

  private static bool EnumWindowStationsCallback(string windowStation, IntPtr lParam)
  {
    IList<string> target = (IList<string>) (GCHandle.FromIntPtr(lParam).Target as List<string>);
    if (target == null)
      return false;
    target.Add(windowStation);
    return true;
  }

  private void btnFacebook_Click(object sender, EventArgs e) => GA.BrowseFacebook();

  private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
  {
    frmLogin.ShowKM = true;
    GA.ExitAndCleanup();
  }

  private void newsBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
  {
    if (!((sender as WebBrowser).Url == e.Url))
      return;
    Application.ExitThread();
  }

  private void button2_Click(object sender, EventArgs e)
  {
  }

  private void lblForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
  {
    if (frmLogin.CompilingLanguage == "VN" || frmLogin.CompilingLanguage == "EN")
    {
      this.pnelPassword.BringToFront();
      if (this.txtUserID.Text != "")
        this.txtPassAccount.Text = this.txtUserID.Text;
      this.SetForgotPassFormGUI(true);
      this.SetChangePasswordGUI(false);
      this.SetLoginFormGUI(false);
    }
    else
    {
      this.pnelPassword.BringToFront();
      if (this.txtUserID.Text != "")
        this.txtPassAccount.Text = this.txtUserID.Text;
      this.SetForgotPassFormGUI(true);
      this.SetChangePasswordGUI(false);
      this.SetLoginFormGUI(false);
    }
  }

  private void SetLoginFormGUI(bool status)
  {
    this.txtUserID.Enabled = status;
    this.txtUserPassword.Enabled = status;
    this.btnNapThe.Enabled = status;
    this.btnNewAccount.Enabled = status;
    this.btnLogin.Enabled = status;
    this.cboxSavePass.Enabled = status;
    this.lblForgotPassword.Enabled = status;
    this.btnFacebook.Enabled = status;
  }

  public static bool AutoInfoError
  {
    get => frmLogin._autoInfoError;
    set
    {
      if (value)
        GA.WriteUserLog("Error loading auto information. Please notify GAuto team.");
      frmLogin._autoInfoError = value;
    }
  }

  public static string GGUnit
  {
    get
    {
      switch (frmLogin.CompilingLanguage)
      {
        case "VN":
          return "GG";
        case "EN":
          return "TK";
        default:
          return "GG";
      }
    }
  }

  private void btnPassQuayVe_Click(object sender, EventArgs e)
  {
    this.staMain.BringToFront();
    this.SetLoginFormGUI(true);
    this.pnelLogin.BringToFront();
    this.pnelPassword.SendToBack();
    this.SetForgotPassFormGUI(false);
    this.SetChangePasswordGUI(false);
  }

  private void SetChangePasswordGUI(bool status)
  {
    this.txtCP_NewPass.Enabled = status;
    this.txtCP_NewPass2.Enabled = status;
    this.txtCP_OldPass.Enabled = status;
    this.txtCP_Username.Enabled = status;
    this.btnCP_Change.Enabled = status;
    this.btnCP_Return.Enabled = status;
  }

  private void SetForgotPassFormGUI(bool status)
  {
    this.txtPassAccount.Enabled = status;
    this.btnPassEmail.Enabled = status;
    this.btnPassQuayVe.Enabled = status;
    this.btnPassEmail.Enabled = status;
  }

  private void btnPassEmail_Click(object sender, EventArgs e)
  {
    if (!(frmLogin.CompilingLanguage == "CN") && !(frmLogin.CompilingLanguage == "VN"))
      return;
    int num1 = 0;
    if (!this.txtPassEmail.Text.Contains("@") || !this.txtPassEmail.Text.Contains("."))
    {
      int num2 = (int) MessageBox.Show(frmMain.langEmailWrongFormat, frmMain.langEmailWrongFormatTitle, MessageBoxButtons.OK, MessageBoxIcon.Hand);
      ++num1;
    }
    if (num1 != 0)
      return;
    string data = $"username={this.txtPassAccount.Text}&email={this.txtPassEmail.Text.ToLower()}";
    string text = !frmLogin.GAuto.Settings.ForgotPassURL.StartsWith("http") ? GA.LoadWeb("http://server1.gameauto.net/" + frmLogin.GAuto.Settings.ForgotPassURL, data, "POST", frmLogin.GAuto.Settings.MainCookie) : GA.LoadWeb(frmLogin.GAuto.Settings.ForgotPassURL, data, "POST", frmLogin.GAuto.Settings.MainCookie);
    if (text.Contains(frmMain.langForgotPassEmail))
    {
      switch (frmLogin.CompilingLanguage)
      {
        case "VN":
          int num3 = (int) MessageBox.Show($"Link phục hồi mật khẩu đã được gửi về email {this.txtPassEmail.Text.ToLower()}\nKiểm tra hộp thư rác nếu không tìm thấy trong inbox", "Đã gửi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          break;
        case "CN":
          int num4 = (int) MessageBox.Show($"密码恢复链接被发送至电子邮箱：{this.txtPassEmail.Text.ToLower()}\n检查垃圾邮件，如果在收件箱中未发现", "帖子", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          break;
      }
      this.btnPassQuayVe_Click((object) null, (EventArgs) null);
    }
    else
    {
      int num5 = (int) MessageBox.Show(text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }
  }

  private void cboxOnlyCheDo_CheckedChanged(object sender, EventArgs e)
  {
    CheckBox checkBox = sender as CheckBox;
    bool flag = true;
    if (checkBox.Checked && checkBox.Focused)
    {
      switch (MessageBox.Show("Bạn bật tùy chọn đăng nhập chế đồ?\nBạn sẽ tiêu phí 5GG khi đăng nhập và được cấp 24h chế đồ 1 tài khoản \nKhi đăng nhập chế đồ sẽ không thể bật auto đánh quái\nBạn có đồng ý tiếp tục không?", "Chế độ chế đồ", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
      {
        case DialogResult.None:
        case DialogResult.No:
          flag = false;
          break;
      }
    }
    if (flag)
      frmLogin.GAuto.Settings.cboxOnlyCheDo = checkBox.Checked;
    else
      checkBox.Checked = !checkBox.Checked;
  }

  private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
  {
    if (e.Argument != null && e.Argument.GetType() == typeof (int) && (int) e.Argument == 1)
    {
      this.InitFormLoginVN();
      e.Result = (object) 1;
    }
    if (e.Argument != null && e.Argument.GetType() == typeof (int) && (int) e.Argument == 2)
    {
      this.btnLoginClick();
      e.Result = (object) 2;
    }
    if (e.Argument == null || e.Argument.GetType() != typeof (LoginParams))
      return;
    e.Result = (object) GA.SecureLoginPHPv2((LoginParams) e.Argument);
  }

  private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
  {
    if (e.Result != null && e.Result.GetType() == typeof (int) && (int) e.Result == 1)
    {
      if (frmLogin.CompilingLanguage == "VN")
      {
        try
        {
          if (frmLogin.AllGAutoServers.Count > 0)
          {
            this.cboServerlist.BeginUpdate();
            foreach (GAutoServer allGautoServer in frmLogin.AllGAutoServers)
              this.cboServerlist.Items.Add((object) allGautoServer.SvrName);
            this.cboServerlist.EndUpdate();
            if (frmLogin.MainGAutoServer != null)
              this.cboServerlist.Text = frmLogin.MainGAutoServer.SvrName;
            else
              this.cboServerlist.SelectedIndex = 0;
          }
        }
        catch (Exception ex)
        {
        }
      }
    }
    if (e.Result != null && e.Result.GetType() == typeof (int) && (int) e.Result == 2)
      this.btnLogin.Enabled = true;
    if (e.Result == null || e.Result.GetType() != typeof (LoginResult))
      return;
    this.flagLoginCount = 0L;
    this.btnLogin.Enabled = true;
    this.btnLogin.Text = frmMain.langLogIn;
    LoginResult result = (LoginResult) e.Result;
    if (result.LoginCode == 1)
      frmLogin.CheckStartAuto();
    else if (result.LoginCode == 200)
    {
      frmPickSession frmPickSession = new frmPickSession();
      frmPickSession.ProcessData((Dictionary<string, object>[]) result.LoginData);
      int num = (int) frmPickSession.ShowDialog();
    }
    else
    {
      if (result.LoginCode == 300 || result.LoginCode == 301)
        return;
      string _content = "Đăng nhập gặp sự cố, vui lòng liên hệ admin.";
      if (result.LoginData != null && result.LoginData.ToString() != "")
        _content = result.LoginData.ToString();
      else if (result.Message != "")
        _content = result.Message;
      GA.ShowMessage(_content, "Login", 60000);
    }
  }

  public static void CheckStartAuto()
  {
    if (frmLogin.GAuto.Settings.AppMode == AllEnums.AutoModes.Lite && frmLogin.GAuto.Settings.Account.TotalBalance <= 0.0)
    {
      int num = (int) new frmLiteVersion().ShowDialog();
    }
    if (!frmLiteVersion.DoNotRun)
    {
      frmLogin.GAuto.Settings.IsLoggedIn = true;
      GA.ShowMainForm();
    }
    else
      GA.ExitAndCleanup();
  }

  private void cboxMoThuongNhan_CheckedChanged(object sender, EventArgs e)
  {
    CheckBox checkBox = sender as CheckBox;
    bool flag = true;
    if (checkBox.Checked && checkBox.Focused)
    {
      switch (MessageBox.Show("Bạn bật tùy chọn mở chức năng Thương Nhân?\nKhi vào game sẽ có thêm Tab Thương Nhân\nBạn có đồng ý tiếp tục không?", "Mở chức năng Thương Nhân", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
      {
        case DialogResult.None:
        case DialogResult.No:
          flag = false;
          break;
      }
    }
    if (flag)
      frmLogin.GAuto.Settings.cboxMoThuongNhan = checkBox.Checked;
    else
      checkBox.Checked = !checkBox.Checked;
  }

  private void cboServerlist_SelectedIndexChanged(object sender, EventArgs e)
  {
    if (!this.cboServerlist.Focused)
      return;
    string str = this.cboServerlist.SelectedItem.ToString();
    if (!(str != "") || frmLogin.AllGAutoServers.Count <= 0)
      return;
    for (int index = frmLogin.AllGAutoServers.Count - 1; index >= 0; --index)
    {
      if (frmLogin.AllGAutoServers[index].SvrName == str)
      {
        frmLogin.MainGAutoServer = frmLogin.AllGAutoServers[index];
        break;
      }
    }
  }

  private void label6_Click(object sender, EventArgs e)
  {
  }

  private void dùngProxyToolStripMenuItem_Click(object sender, EventArgs e)
  {
    string str = Interaction.InputBox("Điền vào thông tin proxy serverIP:port", "Proxy settings");
    if (str != "" && str.Contains(":"))
    {
      string[] strArray = str.Split(':');
      if (strArray.Length < 2)
        return;
      int result = 0;
      int.TryParse(strArray[1], out result);
      frmLogin.myProxy = new WebProxy(strArray[0], result);
    }
    else
    {
      int num = (int) MessageBox.Show("Proxy phải có format dạng địa-chỉ-IP:cổng", "Sai định dạng", MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }
  }

  private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
  {
    GA.BrowseFacebook();
  }

  private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
  {
    GA.BrowseZingMe();
  }

  private void linkChangePass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
  {
    if (frmLogin.CompilingLanguage == "VN")
    {
      this.pnelChangePassword.BringToFront();
      if (this.txtUserID.Text != "")
        this.txtCP_Username.Text = this.txtUserID.Text;
      this.SetChangePasswordGUI(true);
      this.SetForgotPassFormGUI(false);
      this.SetLoginFormGUI(false);
    }
    else
    {
      this.pnelChangePassword.BringToFront();
      if (this.txtUserID.Text != "")
        this.txtCP_Username.Text = this.txtUserID.Text;
      this.SetChangePasswordGUI(true);
      this.SetForgotPassFormGUI(false);
      this.SetLoginFormGUI(false);
    }
  }

  private void btnCP_Return_Click(object sender, EventArgs e)
  {
    this.staMain.BringToFront();
    this.SetLoginFormGUI(true);
    this.pnelLogin.BringToFront();
    this.pnelChangePassword.SendToBack();
    this.SetForgotPassFormGUI(false);
    this.SetChangePasswordGUI(false);
  }

  private void btnCP_Change_Click(object sender, EventArgs e)
  {
    bool flag = false;
    if (this.txtCP_NewPass.Text == this.txtCP_OldPass.Text)
    {
      flag = true;
      int num = (int) MessageBox.Show("Mật khẩu mới phải khác với mật khẩu cũ", "Không có gì thay đổi", MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }
    if (!flag && this.txtCP_NewPass.Text.Length < 6 || this.txtCP_NewPass.Text.Length > 50)
    {
      int num = (int) MessageBox.Show("Mật khẩu mới phải dài hơn 6 ký tự và ít hơn 50 ký tự", "Mật khẩu mới không đạt tiêu chuẩn", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      flag = true;
    }
    if (!flag && this.txtCP_NewPass.Text != this.txtCP_NewPass2.Text)
    {
      int num = (int) MessageBox.Show("Mật khẩu mới phải được nhập vào 2 lần giống nhau", "Mật khẩu mới không khớp", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      flag = true;
    }
    if (!flag && this.txtCP_Username.Text == string.Empty)
    {
      int num = (int) MessageBox.Show("Tên sử dụng không được để trống", "Tên sử dụng không đúng", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      this.txtCP_Username.Focus();
      flag = true;
    }
    if (!flag && this.txtCP_OldPass.Text == string.Empty)
    {
      int num = (int) MessageBox.Show("Mật khẩu hiện tại không được để trống", "Mật khẩu không đúng", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      this.txtCP_OldPass.Focus();
      flag = true;
    }
    if (flag)
      return;
    string data = string.Format("username={0}&password={1}&newpass={2}&newpass2={2}", (object) this.txtCP_Username.Text, (object) this.txtCP_OldPass.Text, (object) this.txtCP_NewPass.Text);
    string text = !frmLogin.GAuto.Settings.ChangePasswordURL.StartsWith("http") ? GA.LoadWeb(frmLogin.MainGAutoServer.URL + frmLogin.GAuto.Settings.ChangePasswordURL, data, "POST", frmLogin.GAuto.Settings.MainCookie) : GA.LoadWeb(frmLogin.GAuto.Settings.ChangePasswordURL, data, "POST", frmLogin.GAuto.Settings.MainCookie);
    if (text.Contains("Mật khẩu đã được đổi thành công."))
    {
      int num = (int) MessageBox.Show(text, "Đổi mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      this.txtUserID.Text = this.txtCP_Username.Text;
      this.txtPassAccount.Text = this.txtCP_NewPass.Text;
      this.btnCP_Return_Click((object) null, (EventArgs) null);
    }
    else
    {
      int num1 = (int) MessageBox.Show(text, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
    this.components = (IContainer) new System.ComponentModel.Container();
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmLogin));
    this.mnuMain = new MenuStrip();
    this.itemSystem = new ToolStripMenuItem();
    this.itemSignUp = new ToolStripMenuItem();
    this.itemForgetPassword = new ToolStripMenuItem();
    this.toolStripMenuItem2 = new ToolStripSeparator();
    this.nạpThẻToolStripMenuItem = new ToolStripMenuItem();
    this.itemSysSep2 = new ToolStripSeparator();
    this.itemExit = new ToolStripMenuItem();
    this.itemHelp = new ToolStripMenuItem();
    this.trangChủToolStripMenuItem = new ToolStripMenuItem();
    this.diễnĐànGAutoToolStripMenuItem = new ToolStripMenuItem();
    this.toolStripMenuItem1 = new ToolStripSeparator();
    this.updateGAutoToolStripMenuItem = new ToolStripMenuItem();
    this.dùngProxyToolStripMenuItem = new ToolStripMenuItem();
    this.toolStripSeparator4 = new ToolStripSeparator();
    this.hướngDẫnSửDụngToolStripMenuItem = new ToolStripMenuItem();
    this.hướngDẫnĐăngKýToolStripMenuItem = new ToolStripMenuItem();
    this.toolStripSeparator3 = new ToolStripSeparator();
    this.vềChươngTrìnhToolStripMenuItem = new ToolStripMenuItem();
    this.staMain = new StatusStrip();
    this.lblStatus = new ToolStripStatusLabel();
    this.btnLogin = new Button();
    this.txtUserPassword = new TextBox();
    this.txtUserID = new TextBox();
    this.label1 = new Label();
    this.btnNewAccount = new Button();
    this.timerLogin = new System.Windows.Forms.Timer(this.components);
    this.cboxSavePass = new CheckBox();
    this.btnNapThe = new Button();
    this.lblForgotPassword = new LinkLabel();
    this.pnelLogin = new Panel();
    this.linkChangePass = new LinkLabel();
    this.linkLabel2 = new LinkLabel();
    this.linkLabel1 = new LinkLabel();
    this.lblHotLine = new Label();
    this.label6 = new Label();
    this.cboServerlist = new ComboBox();
    this.cboxMoThuongNhan = new CheckBox();
    this.cboxOnlyCheDo = new CheckBox();
    this.pictureBox1 = new PictureBox();
    this.btnFacebook = new Button();
    this.pnelPassword = new Panel();
    this.txtPassEmail = new TextBox();
    this.btnPassQuayVe = new Button();
    this.label5 = new Label();
    this.label4 = new Label();
    this.label3 = new Label();
    this.btnPassEmail = new Button();
    this.label2 = new Label();
    this.txtPassAccount = new TextBox();
    this.backgroundWorker1 = new BackgroundWorker();
    this.pnelChangePassword = new Panel();
    this.txtCP_NewPass2 = new TextBox();
    this.label45 = new Label();
    this.txtCP_NewPass = new TextBox();
    this.label44 = new Label();
    this.label38 = new Label();
    this.label39 = new Label();
    this.btnCP_Return = new Button();
    this.txtCP_OldPass = new TextBox();
    this.label40 = new Label();
    this.label41 = new Label();
    this.btnCP_Change = new Button();
    this.label42 = new Label();
    this.txtCP_Username = new TextBox();
    this.label43 = new Label();
    this.mnuMain.SuspendLayout();
    this.staMain.SuspendLayout();
    this.pnelLogin.SuspendLayout();
    ((ISupportInitialize) this.pictureBox1).BeginInit();
    this.pnelPassword.SuspendLayout();
    this.pnelChangePassword.SuspendLayout();
    this.SuspendLayout();
    this.mnuMain.BackColor = SystemColors.Control;
    this.mnuMain.Items.AddRange(new ToolStripItem[2]
    {
      (ToolStripItem) this.itemSystem,
      (ToolStripItem) this.itemHelp
    });
    componentResourceManager.ApplyResources((object) this.mnuMain, "mnuMain");
    this.mnuMain.Name = "mnuMain";
    this.itemSystem.DropDownItems.AddRange(new ToolStripItem[6]
    {
      (ToolStripItem) this.itemSignUp,
      (ToolStripItem) this.itemForgetPassword,
      (ToolStripItem) this.toolStripMenuItem2,
      (ToolStripItem) this.nạpThẻToolStripMenuItem,
      (ToolStripItem) this.itemSysSep2,
      (ToolStripItem) this.itemExit
    });
    this.itemSystem.Name = "itemSystem";
    componentResourceManager.ApplyResources((object) this.itemSystem, "itemSystem");
    this.itemSignUp.Name = "itemSignUp";
    componentResourceManager.ApplyResources((object) this.itemSignUp, "itemSignUp");
    this.itemSignUp.Click += new EventHandler(this.itemSignUp_Click);
    this.itemForgetPassword.Name = "itemForgetPassword";
    componentResourceManager.ApplyResources((object) this.itemForgetPassword, "itemForgetPassword");
    this.itemForgetPassword.Click += new EventHandler(this.itemForgetPassword_Click);
    this.toolStripMenuItem2.Name = "toolStripMenuItem2";
    componentResourceManager.ApplyResources((object) this.toolStripMenuItem2, "toolStripMenuItem2");
    this.nạpThẻToolStripMenuItem.Name = "nạpThẻToolStripMenuItem";
    componentResourceManager.ApplyResources((object) this.nạpThẻToolStripMenuItem, "nạpThẻToolStripMenuItem");
    this.nạpThẻToolStripMenuItem.Click += new EventHandler(this.nạpThẻToolStripMenuItem_Click);
    this.itemSysSep2.Name = "itemSysSep2";
    componentResourceManager.ApplyResources((object) this.itemSysSep2, "itemSysSep2");
    this.itemExit.Name = "itemExit";
    componentResourceManager.ApplyResources((object) this.itemExit, "itemExit");
    this.itemHelp.DropDownItems.AddRange(new ToolStripItem[10]
    {
      (ToolStripItem) this.trangChủToolStripMenuItem,
      (ToolStripItem) this.diễnĐànGAutoToolStripMenuItem,
      (ToolStripItem) this.toolStripMenuItem1,
      (ToolStripItem) this.updateGAutoToolStripMenuItem,
      (ToolStripItem) this.dùngProxyToolStripMenuItem,
      (ToolStripItem) this.toolStripSeparator4,
      (ToolStripItem) this.hướngDẫnSửDụngToolStripMenuItem,
      (ToolStripItem) this.hướngDẫnĐăngKýToolStripMenuItem,
      (ToolStripItem) this.toolStripSeparator3,
      (ToolStripItem) this.vềChươngTrìnhToolStripMenuItem
    });
    this.itemHelp.Name = "itemHelp";
    componentResourceManager.ApplyResources((object) this.itemHelp, "itemHelp");
    this.trangChủToolStripMenuItem.Name = "trangChủToolStripMenuItem";
    componentResourceManager.ApplyResources((object) this.trangChủToolStripMenuItem, "trangChủToolStripMenuItem");
    this.trangChủToolStripMenuItem.Click += new EventHandler(this.trangChủToolStripMenuItem_Click);
    this.diễnĐànGAutoToolStripMenuItem.Name = "diễnĐànGAutoToolStripMenuItem";
    componentResourceManager.ApplyResources((object) this.diễnĐànGAutoToolStripMenuItem, "diễnĐànGAutoToolStripMenuItem");
    this.diễnĐànGAutoToolStripMenuItem.Click += new EventHandler(this.diễnĐànGAutoToolStripMenuItem_Click);
    this.toolStripMenuItem1.Name = "toolStripMenuItem1";
    componentResourceManager.ApplyResources((object) this.toolStripMenuItem1, "toolStripMenuItem1");
    this.updateGAutoToolStripMenuItem.Name = "updateGAutoToolStripMenuItem";
    componentResourceManager.ApplyResources((object) this.updateGAutoToolStripMenuItem, "updateGAutoToolStripMenuItem");
    this.updateGAutoToolStripMenuItem.Click += new EventHandler(this.updateGAutoToolStripMenuItem_Click);
    this.dùngProxyToolStripMenuItem.Name = "dùngProxyToolStripMenuItem";
    componentResourceManager.ApplyResources((object) this.dùngProxyToolStripMenuItem, "dùngProxyToolStripMenuItem");
    this.dùngProxyToolStripMenuItem.Click += new EventHandler(this.dùngProxyToolStripMenuItem_Click);
    this.toolStripSeparator4.Name = "toolStripSeparator4";
    componentResourceManager.ApplyResources((object) this.toolStripSeparator4, "toolStripSeparator4");
    this.hướngDẫnSửDụngToolStripMenuItem.Name = "hướngDẫnSửDụngToolStripMenuItem";
    componentResourceManager.ApplyResources((object) this.hướngDẫnSửDụngToolStripMenuItem, "hướngDẫnSửDụngToolStripMenuItem");
    this.hướngDẫnSửDụngToolStripMenuItem.Click += new EventHandler(this.hướngDẫnSửDụngToolStripMenuItem_Click);
    this.hướngDẫnĐăngKýToolStripMenuItem.Name = "hướngDẫnĐăngKýToolStripMenuItem";
    componentResourceManager.ApplyResources((object) this.hướngDẫnĐăngKýToolStripMenuItem, "hướngDẫnĐăngKýToolStripMenuItem");
    this.hướngDẫnĐăngKýToolStripMenuItem.Click += new EventHandler(this.hướngDẫnĐăngKýToolStripMenuItem_Click);
    this.toolStripSeparator3.Name = "toolStripSeparator3";
    componentResourceManager.ApplyResources((object) this.toolStripSeparator3, "toolStripSeparator3");
    this.vềChươngTrìnhToolStripMenuItem.Name = "vềChươngTrìnhToolStripMenuItem";
    componentResourceManager.ApplyResources((object) this.vềChươngTrìnhToolStripMenuItem, "vềChươngTrìnhToolStripMenuItem");
    this.vềChươngTrìnhToolStripMenuItem.Click += new EventHandler(this.vềChươngTrìnhToolStripMenuItem_Click);
    this.staMain.BackColor = SystemColors.Control;
    this.staMain.Items.AddRange(new ToolStripItem[1]
    {
      (ToolStripItem) this.lblStatus
    });
    componentResourceManager.ApplyResources((object) this.staMain, "staMain");
    this.staMain.Name = "staMain";
    this.lblStatus.ActiveLinkColor = Color.Green;
    this.lblStatus.ForeColor = Color.Green;
    this.lblStatus.Name = "lblStatus";
    componentResourceManager.ApplyResources((object) this.lblStatus, "lblStatus");
    this.lblStatus.Spring = true;
    this.btnLogin.BackColor = Color.FromArgb(210, 249, 213);
    componentResourceManager.ApplyResources((object) this.btnLogin, "btnLogin");
    this.btnLogin.Name = "btnLogin";
    this.btnLogin.UseVisualStyleBackColor = false;
    this.btnLogin.Click += new EventHandler(this.btnLogin_Click);
    this.txtUserPassword.BorderStyle = BorderStyle.FixedSingle;
    componentResourceManager.ApplyResources((object) this.txtUserPassword, "txtUserPassword");
    this.txtUserPassword.Name = "txtUserPassword";
    this.txtUserPassword.UseSystemPasswordChar = true;
    this.txtUserPassword.TextChanged += new EventHandler(this.txtUserPassword_TextChanged);
    this.txtUserID.BorderStyle = BorderStyle.FixedSingle;
    componentResourceManager.ApplyResources((object) this.txtUserID, "txtUserID");
    this.txtUserID.Name = "txtUserID";
    this.txtUserID.TextChanged += new EventHandler(this.txtUserID_TextChanged);
    componentResourceManager.ApplyResources((object) this.label1, "label1");
    this.label1.Name = "label1";
    this.label1.Click += new EventHandler(this.label1_Click);
    this.btnNewAccount.BackColor = Color.FromArgb(210, 249, 213);
    componentResourceManager.ApplyResources((object) this.btnNewAccount, "btnNewAccount");
    this.btnNewAccount.Name = "btnNewAccount";
    this.btnNewAccount.UseVisualStyleBackColor = false;
    this.btnNewAccount.Click += new EventHandler(this.button1_Click);
    this.timerLogin.Enabled = true;
    this.timerLogin.Interval = 200;
    this.timerLogin.Tick += new EventHandler(this.timerLogin_Tick);
    componentResourceManager.ApplyResources((object) this.cboxSavePass, "cboxSavePass");
    this.cboxSavePass.Name = "cboxSavePass";
    this.cboxSavePass.UseVisualStyleBackColor = true;
    this.cboxSavePass.CheckedChanged += new EventHandler(this.cboxSavePass_CheckedChanged);
    this.btnNapThe.BackColor = Color.FromArgb(247, 207, 142);
    componentResourceManager.ApplyResources((object) this.btnNapThe, "btnNapThe");
    this.btnNapThe.ForeColor = Color.Black;
    this.btnNapThe.Name = "btnNapThe";
    this.btnNapThe.UseVisualStyleBackColor = false;
    this.btnNapThe.Click += new EventHandler(this.btnNapThe_Click);
    componentResourceManager.ApplyResources((object) this.lblForgotPassword, "lblForgotPassword");
    this.lblForgotPassword.Name = "lblForgotPassword";
    this.lblForgotPassword.TabStop = true;
    this.lblForgotPassword.LinkClicked += new LinkLabelLinkClickedEventHandler(this.lblForgotPassword_LinkClicked);
    this.pnelLogin.Controls.Add((Control) this.linkChangePass);
    this.pnelLogin.Controls.Add((Control) this.linkLabel2);
    this.pnelLogin.Controls.Add((Control) this.linkLabel1);
    this.pnelLogin.Controls.Add((Control) this.lblHotLine);
    this.pnelLogin.Controls.Add((Control) this.label6);
    this.pnelLogin.Controls.Add((Control) this.cboServerlist);
    this.pnelLogin.Controls.Add((Control) this.cboxMoThuongNhan);
    this.pnelLogin.Controls.Add((Control) this.cboxOnlyCheDo);
    this.pnelLogin.Controls.Add((Control) this.lblForgotPassword);
    this.pnelLogin.Controls.Add((Control) this.pictureBox1);
    this.pnelLogin.Controls.Add((Control) this.btnFacebook);
    this.pnelLogin.Controls.Add((Control) this.btnNapThe);
    this.pnelLogin.Controls.Add((Control) this.cboxSavePass);
    this.pnelLogin.Controls.Add((Control) this.btnNewAccount);
    this.pnelLogin.Controls.Add((Control) this.label1);
    this.pnelLogin.Controls.Add((Control) this.txtUserPassword);
    this.pnelLogin.Controls.Add((Control) this.txtUserID);
    this.pnelLogin.Controls.Add((Control) this.btnLogin);
    this.pnelLogin.Controls.Add((Control) this.staMain);
    componentResourceManager.ApplyResources((object) this.pnelLogin, "pnelLogin");
    this.pnelLogin.Name = "pnelLogin";
    componentResourceManager.ApplyResources((object) this.linkChangePass, "linkChangePass");
    this.linkChangePass.Name = "linkChangePass";
    this.linkChangePass.TabStop = true;
    this.linkChangePass.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkChangePass_LinkClicked);
    componentResourceManager.ApplyResources((object) this.linkLabel2, "linkLabel2");
    this.linkLabel2.Name = "linkLabel2";
    this.linkLabel2.TabStop = true;
    this.linkLabel2.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
    componentResourceManager.ApplyResources((object) this.linkLabel1, "linkLabel1");
    this.linkLabel1.Name = "linkLabel1";
    this.linkLabel1.TabStop = true;
    this.linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
    componentResourceManager.ApplyResources((object) this.lblHotLine, "lblHotLine");
    this.lblHotLine.ForeColor = Color.Navy;
    this.lblHotLine.Name = "lblHotLine";
    componentResourceManager.ApplyResources((object) this.label6, "label6");
    this.label6.Name = "label6";
    this.label6.Click += new EventHandler(this.label6_Click);
    this.cboServerlist.FormattingEnabled = true;
    componentResourceManager.ApplyResources((object) this.cboServerlist, "cboServerlist");
    this.cboServerlist.Name = "cboServerlist";
    this.cboServerlist.SelectedIndexChanged += new EventHandler(this.cboServerlist_SelectedIndexChanged);
    componentResourceManager.ApplyResources((object) this.cboxMoThuongNhan, "cboxMoThuongNhan");
    this.cboxMoThuongNhan.Name = "cboxMoThuongNhan";
    this.cboxMoThuongNhan.UseVisualStyleBackColor = true;
    this.cboxMoThuongNhan.CheckedChanged += new EventHandler(this.cboxMoThuongNhan_CheckedChanged);
    componentResourceManager.ApplyResources((object) this.cboxOnlyCheDo, "cboxOnlyCheDo");
    this.cboxOnlyCheDo.Name = "cboxOnlyCheDo";
    this.cboxOnlyCheDo.UseVisualStyleBackColor = true;
    this.cboxOnlyCheDo.CheckedChanged += new EventHandler(this.cboxOnlyCheDo_CheckedChanged);
    this.pictureBox1.Image = (Image) Resources.cooltext143093550107300__2_;
    componentResourceManager.ApplyResources((object) this.pictureBox1, "pictureBox1");
    this.pictureBox1.Name = "pictureBox1";
    this.pictureBox1.TabStop = false;
    this.btnFacebook.BackColor = Color.Transparent;
    componentResourceManager.ApplyResources((object) this.btnFacebook, "btnFacebook");
    this.btnFacebook.ForeColor = Color.Transparent;
    this.btnFacebook.Image = (Image) Resources.facebook;
    this.btnFacebook.Name = "btnFacebook";
    this.btnFacebook.UseVisualStyleBackColor = false;
    this.btnFacebook.Click += new EventHandler(this.btnFacebook_Click);
    this.pnelPassword.Controls.Add((Control) this.txtPassEmail);
    this.pnelPassword.Controls.Add((Control) this.btnPassQuayVe);
    this.pnelPassword.Controls.Add((Control) this.label5);
    this.pnelPassword.Controls.Add((Control) this.label4);
    this.pnelPassword.Controls.Add((Control) this.label3);
    this.pnelPassword.Controls.Add((Control) this.btnPassEmail);
    this.pnelPassword.Controls.Add((Control) this.label2);
    this.pnelPassword.Controls.Add((Control) this.txtPassAccount);
    componentResourceManager.ApplyResources((object) this.pnelPassword, "pnelPassword");
    this.pnelPassword.Name = "pnelPassword";
    this.txtPassEmail.BorderStyle = BorderStyle.FixedSingle;
    componentResourceManager.ApplyResources((object) this.txtPassEmail, "txtPassEmail");
    this.txtPassEmail.Name = "txtPassEmail";
    this.btnPassQuayVe.BackColor = Color.FromArgb(210, 249, 213);
    componentResourceManager.ApplyResources((object) this.btnPassQuayVe, "btnPassQuayVe");
    this.btnPassQuayVe.Name = "btnPassQuayVe";
    this.btnPassQuayVe.UseVisualStyleBackColor = false;
    this.btnPassQuayVe.Click += new EventHandler(this.btnPassQuayVe_Click);
    componentResourceManager.ApplyResources((object) this.label5, "label5");
    this.label5.Name = "label5";
    componentResourceManager.ApplyResources((object) this.label4, "label4");
    this.label4.Name = "label4";
    componentResourceManager.ApplyResources((object) this.label3, "label3");
    this.label3.ForeColor = Color.Chocolate;
    this.label3.Name = "label3";
    this.btnPassEmail.BackColor = Color.FromArgb(210, 249, 213);
    componentResourceManager.ApplyResources((object) this.btnPassEmail, "btnPassEmail");
    this.btnPassEmail.Name = "btnPassEmail";
    this.btnPassEmail.UseVisualStyleBackColor = false;
    this.btnPassEmail.Click += new EventHandler(this.btnPassEmail_Click);
    componentResourceManager.ApplyResources((object) this.label2, "label2");
    this.label2.Name = "label2";
    this.txtPassAccount.BorderStyle = BorderStyle.FixedSingle;
    componentResourceManager.ApplyResources((object) this.txtPassAccount, "txtPassAccount");
    this.txtPassAccount.Name = "txtPassAccount";
    this.backgroundWorker1.DoWork += new DoWorkEventHandler(this.backgroundWorker1_DoWork);
    this.backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
    this.pnelChangePassword.Controls.Add((Control) this.txtCP_NewPass2);
    this.pnelChangePassword.Controls.Add((Control) this.label45);
    this.pnelChangePassword.Controls.Add((Control) this.txtCP_NewPass);
    this.pnelChangePassword.Controls.Add((Control) this.label44);
    this.pnelChangePassword.Controls.Add((Control) this.label38);
    this.pnelChangePassword.Controls.Add((Control) this.label39);
    this.pnelChangePassword.Controls.Add((Control) this.btnCP_Return);
    this.pnelChangePassword.Controls.Add((Control) this.txtCP_OldPass);
    this.pnelChangePassword.Controls.Add((Control) this.label40);
    this.pnelChangePassword.Controls.Add((Control) this.label41);
    this.pnelChangePassword.Controls.Add((Control) this.btnCP_Change);
    this.pnelChangePassword.Controls.Add((Control) this.label42);
    this.pnelChangePassword.Controls.Add((Control) this.txtCP_Username);
    this.pnelChangePassword.Controls.Add((Control) this.label43);
    componentResourceManager.ApplyResources((object) this.pnelChangePassword, "pnelChangePassword");
    this.pnelChangePassword.Name = "pnelChangePassword";
    this.txtCP_NewPass2.BorderStyle = BorderStyle.FixedSingle;
    componentResourceManager.ApplyResources((object) this.txtCP_NewPass2, "txtCP_NewPass2");
    this.txtCP_NewPass2.Name = "txtCP_NewPass2";
    componentResourceManager.ApplyResources((object) this.label45, "label45");
    this.label45.Name = "label45";
    this.txtCP_NewPass.BorderStyle = BorderStyle.FixedSingle;
    componentResourceManager.ApplyResources((object) this.txtCP_NewPass, "txtCP_NewPass");
    this.txtCP_NewPass.Name = "txtCP_NewPass";
    componentResourceManager.ApplyResources((object) this.label44, "label44");
    this.label44.Name = "label44";
    componentResourceManager.ApplyResources((object) this.label38, "label38");
    this.label38.Name = "label38";
    componentResourceManager.ApplyResources((object) this.label39, "label39");
    this.label39.ForeColor = Color.Peru;
    this.label39.Name = "label39";
    this.btnCP_Return.BackColor = Color.FromArgb(210, 249, 213);
    componentResourceManager.ApplyResources((object) this.btnCP_Return, "btnCP_Return");
    this.btnCP_Return.Name = "btnCP_Return";
    this.btnCP_Return.UseVisualStyleBackColor = false;
    this.btnCP_Return.Click += new EventHandler(this.btnCP_Return_Click);
    this.txtCP_OldPass.BorderStyle = BorderStyle.FixedSingle;
    componentResourceManager.ApplyResources((object) this.txtCP_OldPass, "txtCP_OldPass");
    this.txtCP_OldPass.Name = "txtCP_OldPass";
    componentResourceManager.ApplyResources((object) this.label40, "label40");
    this.label40.Name = "label40";
    componentResourceManager.ApplyResources((object) this.label41, "label41");
    this.label41.Name = "label41";
    this.btnCP_Change.BackColor = Color.FromArgb(210, 249, 213);
    componentResourceManager.ApplyResources((object) this.btnCP_Change, "btnCP_Change");
    this.btnCP_Change.Name = "btnCP_Change";
    this.btnCP_Change.UseVisualStyleBackColor = false;
    this.btnCP_Change.Click += new EventHandler(this.btnCP_Change_Click);
    componentResourceManager.ApplyResources((object) this.label42, "label42");
    this.label42.Name = "label42";
    this.txtCP_Username.BorderStyle = BorderStyle.FixedSingle;
    componentResourceManager.ApplyResources((object) this.txtCP_Username, "txtCP_Username");
    this.txtCP_Username.Name = "txtCP_Username";
    componentResourceManager.ApplyResources((object) this.label43, "label43");
    this.label43.ForeColor = Color.Chocolate;
    this.label43.Name = "label43";
    this.AcceptButton = (IButtonControl) this.btnLogin;
    componentResourceManager.ApplyResources((object) this, "$this");
    this.AutoScaleMode = AutoScaleMode.Font;
    this.BackColor = Color.WhiteSmoke;
    this.Controls.Add((Control) this.mnuMain);
    this.Controls.Add((Control) this.pnelLogin);
    this.Controls.Add((Control) this.pnelChangePassword);
    this.Controls.Add((Control) this.pnelPassword);
    this.FormBorderStyle = FormBorderStyle.FixedSingle;
    this.MainMenuStrip = this.mnuMain;
    this.MaximizeBox = false;
    this.Name = nameof (frmLogin);
    this.ShowIcon = false;
    this.FormClosed += new FormClosedEventHandler(this.frmLogin_FormClosed);
    this.Load += new EventHandler(this.frmLogin_Load);
    this.mnuMain.ResumeLayout(false);
    this.mnuMain.PerformLayout();
    this.staMain.ResumeLayout(false);
    this.staMain.PerformLayout();
    this.pnelLogin.ResumeLayout(false);
    this.pnelLogin.PerformLayout();
    ((ISupportInitialize) this.pictureBox1).EndInit();
    this.pnelPassword.ResumeLayout(false);
    this.pnelPassword.PerformLayout();
    this.pnelChangePassword.ResumeLayout(false);
    this.pnelChangePassword.PerformLayout();
    this.ResumeLayout(false);
    this.PerformLayout();
  }
}
