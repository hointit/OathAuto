// Decompiled with JetBrains decompiler
// Type: SmartBot.GlobalSettings
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

#nullable disable
namespace SmartBot;

[Serializable]
public class GlobalSettings
{
  public static string VersionFile = "versions.txt";
  public List<SkillTransItem> SkillTranslator = new List<SkillTransItem>();
  public List<AESKeyset> AESKeysets = new List<AESKeyset>();
  public string CompilingLanguage = frmLogin.CompilingLanguage;
  public string CompilingCurrency = "USD";
  public Dictionary<string, int> BangGia = new Dictionary<string, int>();
  private GAutoList<string> _ListItemNhat = frmLogin.__ListItemNhat;
  private GAutoList<string> _ListBuffPetID = new GAutoList<string>();
  private GAutoList<LoginProfileClass> _ListLoginProfile = new GAutoList<LoginProfileClass>();
  public List<int> AOEPetSkills = new List<int>()
  {
    742,
    743,
    744,
    745,
    747,
    672,
    673,
    674,
    675,
    676,
    677,
    678,
    679,
    680,
    681
  };
  public List<int> AOEBuffSkills = new List<int>()
  {
    696,
    697,
    686,
    687
  };
  private GAutoList<string> _ItemBanList = frmLogin.__ItemBanList;
  private GAutoList<string> _BuffNameList = new GAutoList<string>();
  private GAutoList<string> _ItemTuHuyList = frmLogin.__ItemTuHuyList;
  private int _numDelay = 2;
  public int numDelayTrue;
  private string _MyTest = "";
  public bool AllInformationLoaded;
  public List<int> QXDCTMapID = new List<int>()
  {
    36,
    37,
    38,
    39,
    40,
    41,
    42,
    43,
    44,
    45,
    46,
    47,
    48 /*0x30*/,
    49
  };
  public List<SavedAI> SavedAIStatus = new List<SavedAI>();
  public List<int> ItemNotRemove = new List<int>()
  {
    30008002,
    30008117,
    30008130,
    38000654,
    30008127,
    30008028,
    30008003,
    30008015,
    30008016,
    30504784,
    30504785,
    30504786,
    30504787,
    30008082,
    30008083,
    30008084,
    30008085,
    30008086,
    10155002
  };
  private AllEnums.AutoModes _appMode = AllEnums.AutoModes.Lite;
  public List<GScriptCommand> SampleScript = new List<GScriptCommand>();
  public List<int> ProcessList = new List<int>();
  public List<IgnoredProcess> ProcessListIgnored = new List<IgnoredProcess>();
  public List<HashAddressPatch> CharInfoBriefBases = new List<HashAddressPatch>();
  public List<HashAddressPatch> AutoVersions = new List<HashAddressPatch>();
  public List<HashAddressPatch> MultiAccPatches = new List<HashAddressPatch>();
  private AllEnums.AutoModes _appMode2 = AllEnums.AutoModes.Lite;
  public List<int> MenpaiBasicSkills = new List<int>()
  {
    0,
    281,
    311,
    341,
    371,
    401,
    431,
    461,
    491,
    521,
    760,
    2900
  };
  public List<ItemToBuy> ListItemToBuy = new List<ItemToBuy>();
  public string BaseDllName = "tinydll.dll";
  public string TempPath = Path.GetTempPath();
  public int ActionDelay = 1000;
  public int ReadInfoDelay = 300;
  public int EnumProcessDelay = 500;
  public int EnumListViewDelay = 500;
  public long EnumListViewTimeStamp;
  public long ModeCheckTimeStamp;
  public int ModeCheckDelay = 1800000;
  public List<byte> CheDoPrices = new List<byte>()
  {
    (byte) 5,
    (byte) 7,
    (byte) 9,
    (byte) 5,
    (byte) 7,
    (byte) 9,
    (byte) 5,
    (byte) 7,
    (byte) 9,
    (byte) 5,
    (byte) 7,
    (byte) 9
  };
  public long EnumProcessTimeStamp;
  public string LogFilePath = AppDomain.CurrentDomain.BaseDirectory + "log\\support.log";
  public int LogFileMaxSize = 5;
  public Dictionary<string, string> LoginInfo = new Dictionary<string, string>();
  public string NoSkillName = "Tên skill";
  public string TabKyNangName = "tabKyNang";
  public string TabPhucHoiPetName = "tabPhucHoiPet";
  public string TabTienIchName = "tabTienIch";
  public string TabVatPhamName = "tabVatPham";
  public string tabCoBanName = "tabCoBan";
  public string tabDebugName = "tabDebug";
  public string tabDebugBocName = "tabDebugBoc";
  public string TabChatName = "tabChatName";
  public byte releaseHPPercent;
  public int HookCount;
  public uint WM_SELECTTARGET = MyDLL.RegisterWindowMessage(nameof (WM_SELECTTARGET));
  public uint WM_PSEUDOCODE = MyDLL.RegisterWindowMessage(nameof (WM_PSEUDOCODE));
  public uint WM_TITLECHANGE = MyDLL.RegisterWindowMessage(nameof (WM_TITLECHANGE));
  public uint WM_TESTMEM = MyDLL.RegisterWindowMessage(nameof (WM_TESTMEM));
  public uint WM_REMOVEDLL = MyDLL.RegisterWindowMessage(nameof (WM_REMOVEDLL));
  public uint WM_DUAHAUCONFIRM = MyDLL.RegisterWindowMessage(nameof (WM_DUAHAUCONFIRM));
  public uint WM_SEQUENCE = MyDLL.RegisterWindowMessage(nameof (WM_SEQUENCE));
  public uint WM_HOISINH = MyDLL.RegisterWindowMessage(nameof (WM_HOISINH));
  public uint WM_THOATXAC = MyDLL.RegisterWindowMessage(nameof (WM_THOATXAC));
  public uint WM_OKPARTYFOLLOW = MyDLL.RegisterWindowMessage(nameof (WM_OKPARTYFOLLOW));
  public uint WM_ASKPARTYFOLLOW = MyDLL.RegisterWindowMessage(nameof (WM_ASKPARTYFOLLOW));
  public uint WM_ACCEPTPTINVITE = MyDLL.RegisterWindowMessage(nameof (WM_ACCEPTPTINVITE));
  public uint WM_CLOSECONFIRMBOX = MyDLL.RegisterWindowMessage(nameof (WM_CLOSECONFIRMBOX));
  public uint WM_CLOSECONFIRMBOX_1 = MyDLL.RegisterWindowMessage(nameof (WM_CLOSECONFIRMBOX_1));
  public uint WM_SELECTTARGETOF = MyDLL.RegisterWindowMessage(nameof (WM_SELECTTARGETOF));
  public uint WM_TUYENCHIEN = MyDLL.RegisterWindowMessage(nameof (WM_TUYENCHIEN));
  public uint WM_REMOVEPARTYFOLLOW = MyDLL.RegisterWindowMessage(nameof (WM_REMOVEPARTYFOLLOW));
  public uint WM_DENYPTINVITE = MyDLL.RegisterWindowMessage(nameof (WM_DENYPTINVITE));
  public uint WM_REMOVEINVITE = MyDLL.RegisterWindowMessage(nameof (WM_REMOVEINVITE));
  public uint WM_INVITEPARTY = MyDLL.RegisterWindowMessage(nameof (WM_INVITEPARTY));
  public uint WM_OUTGAME = MyDLL.RegisterWindowMessage(nameof (WM_OUTGAME));
  public uint WM_CONSOLE = MyDLL.RegisterWindowMessage(nameof (WM_CONSOLE));
  public uint WM_STARTTHREAD = MyDLL.RegisterWindowMessage(nameof (WM_STARTTHREAD));
  public uint WM_READMEMORY = MyDLL.RegisterWindowMessage(nameof (WM_READMEMORY));
  public uint WM_CALLFUNCTION = MyDLL.RegisterWindowMessage(nameof (WM_CALLFUNCTION));
  public uint WM_ENTERRECONNECT = MyDLL.RegisterWindowMessage(nameof (WM_ENTERRECONNECT));
  public uint WM_DISCONNECT = MyDLL.RegisterWindowMessage(nameof (WM_DISCONNECT));
  public uint WM_CALLMOVETO = MyDLL.RegisterWindowMessage(nameof (WM_CALLMOVETO));
  public uint WM_ATTACKTARGET = MyDLL.RegisterWindowMessage(nameof (WM_ATTACKTARGET));
  public uint WM_INVENTORYDETAIL = MyDLL.RegisterWindowMessage(nameof (WM_INVENTORYDETAIL));
  public uint WM_REMOVEINVENTORYITEM = MyDLL.RegisterWindowMessage(nameof (WM_REMOVEINVENTORYITEM));
  public uint WM_REMOVEINVENTORYITEM_1 = MyDLL.RegisterWindowMessage(nameof (WM_REMOVEINVENTORYITEM_1));
  public uint WM_NPCSELLITEM = MyDLL.RegisterWindowMessage(nameof (WM_NPCSELLITEM));
  public uint WM_PETXUATCHIEN = MyDLL.RegisterWindowMessage(nameof (WM_PETXUATCHIEN));
  public uint WM_ATTACKTARGETPACKET = MyDLL.RegisterWindowMessage(nameof (WM_ATTACKTARGETPACKET));
  public uint WM_ATTACKTARGETPACKET_1 = MyDLL.RegisterWindowMessage(nameof (WM_ATTACKTARGETPACKET_1));
  public uint WM_ATTACKTARGETPACKET_2 = MyDLL.RegisterWindowMessage(nameof (WM_ATTACKTARGETPACKET_2));
  public uint WM_TALKNPC = MyDLL.RegisterWindowMessage(nameof (WM_TALKNPC));
  public uint WM_TALKNPC_1 = MyDLL.RegisterWindowMessage(nameof (WM_TALKNPC_1));
  public uint WM_BUYITEM = MyDLL.RegisterWindowMessage(nameof (WM_BUYITEM));
  public uint WM_BUYITEM_1 = MyDLL.RegisterWindowMessage(nameof (WM_BUYITEM_1));
  public uint WM_REMOVELOCK = MyDLL.RegisterWindowMessage(nameof (WM_REMOVELOCK));
  public uint WM_SETLOCK = MyDLL.RegisterWindowMessage(nameof (WM_SETLOCK));
  public uint WM_AUTOMOVE = MyDLL.RegisterWindowMessage(nameof (WM_AUTOMOVE));
  public uint WM_AUTOMOVE_1 = MyDLL.RegisterWindowMessage(nameof (WM_AUTOMOVE_1));
  public uint WM_STARTAUTOMOVE = MyDLL.RegisterWindowMessage(nameof (WM_STARTAUTOMOVE));
  public uint WM_STARTPOTALMOVE = MyDLL.RegisterWindowMessage(nameof (WM_STARTPOTALMOVE));
  public uint WM_UPLEVEL = MyDLL.RegisterWindowMessage(nameof (WM_UPLEVEL));
  public uint WM_USEITEM = MyDLL.RegisterWindowMessage(nameof (WM_USEITEM));
  public uint WM_USEITEM_1 = MyDLL.RegisterWindowMessage(nameof (WM_USEITEM_1));
  public uint WM_USEITEM_2 = MyDLL.RegisterWindowMessage(nameof (WM_USEITEM_2));
  public uint WM_USEITEM_3 = MyDLL.RegisterWindowMessage(nameof (WM_USEITEM_3));
  public uint WM_USEITEM_4 = MyDLL.RegisterWindowMessage(nameof (WM_USEITEM_4));
  public uint WM_THOCBOC = MyDLL.RegisterWindowMessage(nameof (WM_THOCBOC));
  public uint WM_PICKITEM = MyDLL.RegisterWindowMessage(nameof (WM_PICKITEM));
  public uint WM_PICKITEM_1 = MyDLL.RegisterWindowMessage(nameof (WM_PICKITEM_1));
  public uint WM_UNLOAD = MyDLL.RegisterWindowMessage(nameof (WM_UNLOAD));
  public uint WM_CLEARBOC = MyDLL.RegisterWindowMessage(nameof (WM_CLEARBOC));
  public uint WM_RESETQUAI = MyDLL.RegisterWindowMessage(nameof (WM_RESETQUAI));
  public uint WM_ATTACKTARGET_1 = MyDLL.RegisterWindowMessage(nameof (WM_ATTACKTARGET_1));
  public uint WM_ATTACKTARGET_2 = MyDLL.RegisterWindowMessage(nameof (WM_ATTACKTARGET_2));
  public uint WM_NPCSELLITEM_1 = MyDLL.RegisterWindowMessage(nameof (WM_NPCSELLITEM_1));
  public uint WM_NPCSELLITEM_2 = MyDLL.RegisterWindowMessage(nameof (WM_NPCSELLITEM_2));
  public uint WM_CONTROLMSG = MyDLL.RegisterWindowMessage(nameof (WM_CONTROLMSG));
  public uint WM_SIGNALMSG = MyDLL.RegisterWindowMessage(nameof (WM_SIGNALMSG));
  public uint WM_HIDEGAME = MyDLL.RegisterWindowMessage(nameof (WM_HIDEGAME));
  public uint WM_SAVEHANDLE = MyDLL.RegisterWindowMessage(nameof (WM_SAVEHANDLE));
  public uint WM_SENDCHAT = MyDLL.RegisterWindowMessage(nameof (WM_SENDCHAT));
  public uint WM_SENDCHATID = MyDLL.RegisterWindowMessage(nameof (WM_SENDCHATID));
  public uint WM_PORTALCONFIRM_1 = MyDLL.RegisterWindowMessage(nameof (WM_PORTALCONFIRM_1));
  public uint WM_TNSELLITEM = MyDLL.RegisterWindowMessage(nameof (WM_TNSELLITEM));
  public uint WM_TNBUYITEM = MyDLL.RegisterWindowMessage(nameof (WM_TNBUYITEM));
  public uint WM_PICKALLITEMS = MyDLL.RegisterWindowMessage(nameof (WM_PICKALLITEMS));
  public uint WM_CALLMOVEFLASHPOS = MyDLL.RegisterWindowMessage(nameof (WM_CALLMOVEFLASHPOS));
  public uint WM_PETCARE = MyDLL.RegisterWindowMessage(nameof (WM_PETCARE));
  public uint WM_PICKKSCOLOR = MyDLL.RegisterWindowMessage(nameof (WM_PICKKSCOLOR));
  public uint WM_PHATTEST = MyDLL.RegisterWindowMessage(nameof (WM_PHATTEST));
  public uint WM_PHATTEST2 = MyDLL.RegisterWindowMessage(nameof (WM_PHATTEST2));
  public uint WM_PHATTEST3 = MyDLL.RegisterWindowMessage(nameof (WM_PHATTEST3));
  public uint WM_GETQUAIID = MyDLL.RegisterWindowMessage(nameof (WM_GETQUAIID));
  public uint WM_PASSCAP2 = MyDLL.RegisterWindowMessage(nameof (WM_PASSCAP2));
  public uint WM_BRINGMEUP = MyDLL.RegisterWindowMessage(nameof (WM_BRINGMEUP));
  public uint WM_SETATTACKERID = MyDLL.RegisterWindowMessage(nameof (WM_SETATTACKERID));
  public uint WM_TRUNGAC = MyDLL.RegisterWindowMessage(nameof (WM_TRUNGAC));
  public uint WM_RESETNHIEMVU = MyDLL.RegisterWindowMessage(nameof (WM_RESETNHIEMVU));
  public uint WM_SETKNB = MyDLL.RegisterWindowMessage(nameof (WM_SETKNB));
  public uint WM_TOGGLEMISSION = MyDLL.RegisterWindowMessage(nameof (WM_TOGGLEMISSION));
  public uint WM_ALLOWPTJOIN = MyDLL.RegisterWindowMessage(nameof (WM_ALLOWPTJOIN));
  public uint WM_SETDELAY = MyDLL.RegisterWindowMessage(nameof (WM_SETDELAY));
  public uint WM_THOCBOCPACKET = MyDLL.RegisterWindowMessage(nameof (WM_THOCBOCPACKET));
  public uint WM_TITLEONOFF = MyDLL.RegisterWindowMessage(nameof (WM_TITLEONOFF));
  public uint WM_THUPET = MyDLL.RegisterWindowMessage(nameof (WM_THUPET));
  public uint WM_UPDATEHOTKEY = MyDLL.RegisterWindowMessage(nameof (WM_UPDATEHOTKEY));
  public uint WM_RESETRING = MyDLL.RegisterWindowMessage(nameof (WM_RESETRING));
  public uint WM_SPLITITEM = MyDLL.RegisterWindowMessage(nameof (WM_SPLITITEM));
  public uint WM_JOINITEM = MyDLL.RegisterWindowMessage(nameof (WM_JOINITEM));
  public uint WM_TALKNPCPET_1 = MyDLL.RegisterWindowMessage(nameof (WM_TALKNPCPET_1));
  public uint WM_TALKNPCPET_2 = MyDLL.RegisterWindowMessage(nameof (WM_TALKNPCPET_2));
  public uint WM_TALKNPCPET = MyDLL.RegisterWindowMessage(nameof (WM_TALKNPCPET));
  public uint WM_HUYNHIEMVU = MyDLL.RegisterWindowMessage(nameof (WM_HUYNHIEMVU));
  public uint WM_OPENSHOPKNB = MyDLL.RegisterWindowMessage(nameof (WM_OPENSHOPKNB));
  public uint WM_BUYITEMKNB = MyDLL.RegisterWindowMessage(nameof (WM_BUYITEMKNB));
  public uint WM_SIFLAG = MyDLL.RegisterWindowMessage(nameof (WM_SIFLAG));
  public uint WM_ALLOWPTJOINTK = MyDLL.RegisterWindowMessage(nameof (WM_ALLOWPTJOINTK));
  public uint WM_JUSTWARPED = MyDLL.RegisterWindowMessage(nameof (WM_JUSTWARPED));
  public uint WM_PTLEAVE = MyDLL.RegisterWindowMessage(nameof (WM_PTLEAVE));
  public uint WM_PTTRANSFER = MyDLL.RegisterWindowMessage(nameof (WM_PTTRANSFER));
  public uint WM_PTTRANSFER_1 = MyDLL.RegisterWindowMessage(nameof (WM_PTTRANSFER_1));
  public uint WM_XINVAOPARTY = MyDLL.RegisterWindowMessage(nameof (WM_XINVAOPARTY));
  public uint WM_RECORDCHAT = MyDLL.RegisterWindowMessage(nameof (WM_RECORDCHAT));
  public uint WM_SENDSAVEDCHAT = MyDLL.RegisterWindowMessage(nameof (WM_SENDSAVEDCHAT));
  public uint WM_ISINGAME = MyDLL.RegisterWindowMessage(nameof (WM_ISINGAME));
  public uint WM_KHINHCONGPACKET = MyDLL.RegisterWindowMessage(nameof (WM_KHINHCONGPACKET));
  public uint WM_KHINHCONGPACKET_1 = MyDLL.RegisterWindowMessage(nameof (WM_KHINHCONGPACKET_1));
  public uint WM_MEMALLOC = MyDLL.RegisterWindowMessage(nameof (WM_MEMALLOC));
  public uint WM_CALLHVD = MyDLL.RegisterWindowMessage(nameof (WM_CALLHVD));
  public uint WM_CRITDLL = MyDLL.RegisterWindowMessage(nameof (WM_CRITDLL));
  public uint WM_PORTALCONFIRM = MyDLL.RegisterWindowMessage(nameof (WM_PORTALCONFIRM));
  public uint WM_ADDPETPOINT_1 = MyDLL.RegisterWindowMessage(nameof (WM_ADDPETPOINT_1));
  public uint WM_ADDPETPOINT_2 = MyDLL.RegisterWindowMessage(nameof (WM_ADDPETPOINT_2));
  public uint WM_QUESTITEMCHOICE = MyDLL.RegisterWindowMessage(nameof (WM_QUESTITEMCHOICE));
  public uint WM_BLOCKCHAT = MyDLL.RegisterWindowMessage("WM_TAHCKLB");
  public uint WM_DUMPPACKET = MyDLL.RegisterWindowMessage(nameof (WM_DUMPPACKET));
  public uint WM_HUYITEMNHIEMVU = MyDLL.RegisterWindowMessage(nameof (WM_HUYITEMNHIEMVU));
  public uint WM_DOSOMETHING = MyDLL.RegisterWindowMessage(nameof (WM_DOSOMETHING));
  public uint WM_TKSERVERS = MyDLL.RegisterWindowMessage(nameof (WM_TKSERVERS));
  public uint HAOTESTMSG = MyDLL.RegisterWindowMessage(nameof (HAOTESTMSG));
  public CookieContainer MainCookie = new CookieContainer();
  public string KhuyenMaiURL = "forum/auto_khuyenmai.php";
  public string ProLicenseURL = "http://server1.gameauto.net/tan-thien-long-3d-vng/huong-dan-su-dung-gauto-tlbb-auto-thien-long-bat-bo/";
  public string LoadWebErrorMessage = "Error reading web";
  public int LoginFailedCount;
  public int MaxLoginError = 5;
  public string ServerStatusText = "";
  public AccountBalance Account = new AccountBalance();
  public long LicenseCheckTimeStamp;
  public int LicenseCheckDelay = 900000;
  public List<QuangCaoMessage> QuangCaoContent = new List<QuangCaoMessage>();
  public int ChatQuangCaoDelay = 1800000;
  public string tabThuongNhanName = "tabThuongNhan";
  public float TNNPC_X = 149f;
  public float TNNPC_Y = 56f;
  public string SettingTable = "gauto";
  public string PasswordEncKey = "mariaOzawa1";
  public uint WM_ENABLETHREAD;
  public string TNTable = "tnprices2";
  public string UserLogFile = "glog.txt";
  public string AdminKhoangFile = "khoang.csv";
  public string AdminNPCFile = "atabnpc.csv";
  public bool IsSupportMode;
  public bool ShowSupportLog;
  public bool AllowReadMem = true;
  public bool cboxTatMay;
  public long TatMayStamp;
  public string TabToDoiName = "tabToDoi";
  public string TabPKName = "tabPKName";
  public string tabNhiemVuName = "tabNhiemVu";
  public bool optTrainSpeed = true;
  public int AliveFailedCounts;
  public int FailedCaptcha;
  public int GiftCodeCaptchas;
  public int TrungAcItemID = 40004000;
  public long NVActionDelay = 2000;
  public List<string> LinhThuNames = frmLogin.__LinhThuNames;
  public List<string> AcTacNames = frmLogin.__AcTacNames;
  public List<string> TestNPCNames = new List<string>()
  {
    "Thiên Toàn Tử"
  };
  public List<string> AcBaNames = frmLogin.__AcBaNames;
  public List<string> TKCNames = frmLogin.__TKCNames;
  public double MaxDistance = 49.0;
  public bool cboxCanNhatBoc = true;
  private bool _DanhHieuOnOff;
  public int RingQuaiSize = 800;
  public int RingNguoiSize = 800;
  public int RingBocSize = 50;
  public int RingMsgSize = 50;
  public int RingHKSize = 20;
  public int HTPetPercent = 95;
  public long ShutdownStamp;
  public int numShutdownH = 2;
  public int numShutdownM;
  public long ShutdownTotalMS;
  public long TriedShutdownStamp;
  public bool flagNotification = true;
  public bool flagHideAuto;
  public bool flagEnableAuto;
  public bool flagPetOn;
  public bool flagNhatBoc;
  public bool flagDanhQuai;
  public bool flagNMBuff;
  public bool flagAnAllGame;
  public string PathPointFile = ".\\pathpoints.txt";
  public bool WasPro;
  private string _ExeFilePath = "";
  private bool _cboxNoKS = true;
  private bool _optKinhMachNghichHanh = true;
  private bool _optPhuBanKeoDoi;
  private bool _optSuDungF1;
  public bool optAcceptNewGame = true;
  public int CheDoRequest;
  public int TraderRequest;
  public int Q12TCRequest;
  public int YTORequest;
  public int YTOExtend;
  public int Q12TCExtend;
  public int BonHoaRequest;
  public int TrongHoaRequest;
  public int ThuHoachRequest;
  public int TrongHoaStatus;
  public int TrongHoaDuration;
  public int ThuHoachStatus;
  public int ThuHoachDuration;
  public int TrongHoaCounts;
  public int ThuHoachCounts;
  private int _CheDoCounts;
  public int TraderCounts;
  public int CheDoCounts;
  public int CheDoDuration;
  public int Q12TCDuration;
  public int BonHoaDuration;
  public int CheDoStatus;
  public int Q12TCStatus;
  public int YTOStatus;
  public int BonHoaStatus;
  private int _Q1TCCounts;
  public int Q12TCCounts;
  private int _BonHoaCounts;
  public int BonHoaCounts;
  private bool _optArrangeSkillByName;
  public bool HadQ123Pro;
  public bool HadYTOPro;
  public bool cboxQ12AutoExtend;
  public bool optKhongDungNgua;
  private bool _cboxAgreement;
  private int _optLoginCungLuc = 2;
  public bool optStopGlogin;
  private bool _optStartNewGame = true;
  public string UpdaterEXE = "update.exe";
  public int YTOCounts;
  public int YTODuration;
  private bool _optNoSkillLag;
  public bool cboxYTOGiaHan;
  public string ExpireString = "(***LƯU Ý: Hạn dùng lượt GG sắp hết nên thời gian tính năng bạn mua sẽ không đủ. Kiểm tra hạn dùng menu 'Hệ thống'->'Thông tin tài khoản'. Bạn nên mua gói nhỏ hơn hoặc chờ lượt dùng mới)";
  private bool _optGomQuai2;
  public int ChatLimit = 2;
  public int DefaultFreeTN;
  public bool optGCafe;
  private long _TimeGiaiDoHoa = 180000;
  private bool _optChangeTargetFast;
  public int EnableAT = 1;
  public int EnableAB = 1;
  public int EnableQ12 = 1;
  public int EnableYTO = 1;
  public int EnableCheDo = 1;
  public int EnableKyCuoc = 1;
  public int RefreshGameCount;
  private int _soVongQHoa = 100;
  private int _soHangTrongHoa = 4;
  private int _soVongQSM = 40;
  public bool BlockChat = true;
  private bool _cboxATRunPP;
  private bool _TipHuongDan = true;
  public List<int> DuaHauBangMapIDArray = new List<int>();
  public int preBocID;
  public int MaxBaseError = 5;
  public bool HadCDPro;
  public int TotalPKLimit = 319;
  public int TotalPKLimit_TinhKiem = 319;
  public long WriteLogStamp;
  private bool _cboxNMBuffSelectTarget;
  private bool _LamNheAuto;
  public string DLLHash = "";
  public bool cboxOnlyCheDo;
  public bool cboxMoThuongNhan;
  private bool _DongYPhuDoi;
  public bool IsLoggedIn;
  public bool ThangCheDo;
  public int ThangCheDo2AccPrice;
  public int ThangCheDo5AccPrice;
  public int ThangCheDo50AccPrice;
  public bool BuyCheDo;
  public int BuyCheDoCount;
  private bool _TuKetNoiLai = true;
  private bool _TuMuaCKH = true;
  private bool _TuThoatGameDis;
  private bool _TuDongYChuyenCanh = true;
  public long PlayCaptchaSoundStamp;
  public int Q12_1hPrice = 2;
  public int Q12_3hPrice = 5;
  public int httpRetries = 5;
  public int httpRetriesDelay = 2000;
  public long httpRetriesMax = 30000;
  public string ZingMeURL = "http://me.zing.vn/u/gameautovip#wall";
  public long YTOStamp;
  public bool GLoginHideGame;
  public bool cboxCDExtend = true;
  public int TNFreeAcc;
  public string _cboCDExtend = "2 nhân vật";

  public static string AutoName
  {
    get
    {
      switch (frmLogin.CompilingLanguage)
      {
        case "VN":
          return "GAuto";
        case "EN":
          return "AutoTL";
        default:
          return "TLBB";
      }
    }
  }

  public static string AutoHomeURL
  {
    get
    {
      switch (frmLogin.CompilingLanguage)
      {
        case "VN":
          return "www.gameauto.net";
        case "EN":
          return "www.tianlongauto.net";
        default:
          return "TLBB";
      }
    }
  }

  public static string GameName
  {
    get
    {
      switch (frmLogin.CompilingLanguage)
      {
        case "VN":
          return "Thiên Long Bát Bộ";
        case "EN":
          return "Dragon Oath";
        default:
          return "TLBB";
      }
    }
  }

  public GlobalSettings()
  {
    this.AESKeysets.Add(new AESKeyset()
    {
      AESKey = GA.ConvertToSecureString("SmFaTlFAXTltWUt5QnhEcEphWk5RQF05bVlLeUJ4RHA="),
      AESIV = GA.ConvertToSecureString("end+bjRCRU5eWlhjWyxfa3p3fm40QkVOXlpYY1ssX2s="),
      StaticKey = GA.ConvertToSecureString("7amWVWjM2yyB2xbN")
    });
    this.AESKeysets.Add(new AESKeyset()
    {
      AESKey = GA.ConvertToSecureString("VipxMn1nKCksbiImY0IqL3lwaFBEeFJmVEJrSFI2aHA="),
      AESIV = GA.ConvertToSecureString("IUBHcXddY2VyJUZTMTVHfXJYOChMJGoiRStKYyRgTW4="),
      StaticKey = GA.ConvertToSecureString("xjAJS7aenHB5J380")
    });
    this.SkillTranslator.Add(new SkillTransItem()
    {
      SkillID = 1850,
      SkillOldName = "Huyền Quy Kỳ Huyết Thú Sức-Pri",
      SkillNewName = "Càn Khôn Dẫn"
    });
    this.SkillTranslator.Add(new SkillTransItem()
    {
      SkillID = 1851,
      SkillOldName = "Lục Hợp Kiếm-Khí Tông-Pri",
      SkillNewName = "Thái Thượng Vong Tình"
    });
    this.SkillTranslator.Add(new SkillTransItem()
    {
      SkillID = 1852,
      SkillOldName = "Linh Phong Kiếm-Khí Tông-Pri",
      SkillNewName = "Tạo Hóa Tam Sinh"
    });
    this.SkillTranslator.Add(new SkillTransItem()
    {
      SkillID = 1853,
      SkillOldName = "Vân Thuỷ Kiếm-Khí Tông-Pri",
      SkillNewName = "Nhất Khí Tam Sinh"
    });
    this.SkillTranslator.Add(new SkillTransItem()
    {
      SkillID = 1854,
      SkillOldName = "Phi Hồng Kiến Nhật-Nho Tông-Pri",
      SkillNewName = "Phù Diêu Thực Trượng"
    });
    this.SkillTranslator.Add(new SkillTransItem()
    {
      SkillID = 1855,
      SkillOldName = "Thái Vân Song Phi-Nho Tông-Pri",
      SkillNewName = "Đào Nhiên Nhất Túy"
    });
    this.SkillTranslator.Add(new SkillTransItem()
    {
      SkillID = 1856,
      SkillOldName = "Thần Du Lăng Vân-Nho Tông-Pri",
      SkillNewName = "Bảo Nguyên Thủ Nhất"
    });
    this.SkillTranslator.Add(new SkillTransItem()
    {
      SkillID = 1857,
      SkillOldName = "Mạnh Tiên Chỉ Lộ-Kiếm Tông-Pri",
      SkillNewName = "Mê Hoặc Thủ Tâm"
    });
    this.SkillTranslator.Add(new SkillTransItem()
    {
      SkillID = 1858,
      SkillOldName = "Hắc Bạch Đoạt Phách-Kiếm Tông-Pri",
      SkillNewName = "Tu Tinh Trận - Trường Sinh"
    });
    this.SkillTranslator.Add(new SkillTransItem()
    {
      SkillID = 1859,
      SkillOldName = "Mệnh Quy Minh Tiên-Kiếm Tông-Pri",
      SkillNewName = "Tuyệt Tình Trận - Phá Quân"
    });
    this.SkillTranslator.Add(new SkillTransItem()
    {
      SkillID = 1861,
      SkillOldName = "Tử Kinh Trạch Lộ-Ma Tông-Pri",
      SkillNewName = "Vi Lão Tiên Suy"
    });
    this.SkillTranslator.Add(new SkillTransItem()
    {
      SkillID = 1862,
      SkillOldName = "Đỗ Nhược Lưu Phương-Ma Tông-Pri",
      SkillNewName = "Tiêu Dao Du"
    });
    this.SkillTranslator.Add(new SkillTransItem()
    {
      SkillID = 1863,
      SkillOldName = "Phật Vân Chưởng-Phật Tông-Pri",
      SkillNewName = "Ngũ Khí Triệu Nguyên"
    });
    this.SkillTranslator.Add(new SkillTransItem()
    {
      SkillID = 1865,
      SkillOldName = "Từ Bi Thiên Diệp Thủ-Phật Tông-Pri",
      SkillNewName = "Phong Vân Phản Phúc"
    });
    this.SkillTranslator.Add(new SkillTransItem()
    {
      SkillID = 1866,
      SkillOldName = "Hàn Băng Quyết-Khí Tông-Pri",
      SkillNewName = "Ý Tung Hoành"
    });
    this.SkillTranslator.Add(new SkillTransItem()
    {
      SkillID = 1867,
      SkillOldName = "Ngự Khí Quyết-Khí Tông-Pri",
      SkillNewName = "Tu Tinh Trận - Âm Dương"
    });
    this.SkillTranslator.Add(new SkillTransItem()
    {
      SkillID = 1868,
      SkillOldName = "Hàn Tụ Phật Huyệt-Khí Tông-Pri",
      SkillNewName = "Thanh Khê Trường Ca"
    });
    this.SkillTranslator.Add(new SkillTransItem()
    {
      SkillID = 1869,
      SkillOldName = "Quảng Lăng Tán- Nho Tông-Pri",
      SkillNewName = "Thiên Nhân Hợp Nhất"
    });
    this.SkillTranslator.Add(new SkillTransItem()
    {
      SkillID = 1870,
      SkillOldName = "Huyền Thiên Hắc Bạch Chỉ-Nho Tông-Pri",
      SkillNewName = "Trích Tiên Mộng Ảnh"
    });
    this.SkillTranslator.Add(new SkillTransItem()
    {
      SkillID = 1871,
      SkillOldName = "Thạch Thượng Thanh Lộ-Nho Tông-Pri",
      SkillNewName = "Tuyệt Tình Trận - Thất Sát"
    });
    this.SkillTranslator.Add(new SkillTransItem()
    {
      SkillID = 1872,
      SkillOldName = "Thương Tùng Bát Vân-Kiếm Tông-Pri",
      SkillNewName = "Súc Địa Thành Thân"
    });
    this.SkillTranslator.Add(new SkillTransItem()
    {
      SkillID = 1873,
      SkillOldName = "Tuỳ Vụ Phiêu Linh-Kiếm Tông-Pri",
      SkillNewName = "Tuyệt Tình Trận - Tham Lang"
    });
    this.SkillTranslator.Add(new SkillTransItem()
    {
      SkillID = 1874,
      SkillOldName = "Hành Vân Lưu Thuỷ-Kiếm Tông-Pri",
      SkillNewName = "Vạn Phúc Thần Quan"
    });
    this.SkillTranslator.Add(new SkillTransItem()
    {
      SkillID = 1875,
      SkillOldName = "Ngũ Độc Thất Hồn Dẫn-Ma Tông-Pri",
      SkillNewName = "Bộ Cương Đạp Đấu"
    });
  }

  public bool IsPro1 => true;

  public GAutoList<string> ListItemNhat
  {
    get => this._ListItemNhat;
    set => this._ListItemNhat = value;
  }

  public GAutoList<string> ListBuffPetID
  {
    get => this._ListBuffPetID;
    set => this._ListBuffPetID = value;
  }

  public GAutoList<LoginProfileClass> ListLoginProfile
  {
    get => this._ListLoginProfile;
    set => this._ListLoginProfile = value;
  }

  public GAutoList<string> ItemBanList
  {
    get => this._ItemBanList;
    set => this._ItemBanList = value;
  }

  public GAutoList<string> BuffNameList
  {
    get => this._BuffNameList;
    set => this._BuffNameList = value;
  }

  public GAutoList<string> ItemTuHuyList
  {
    get => this._ItemTuHuyList;
    set => this._ItemTuHuyList = value;
  }

  public int numDelay
  {
    get
    {
      this.numDelayTrue = this._numDelay * 100;
      return this._numDelay;
    }
    set
    {
      if (this.AllInformationLoaded && this._numDelay != value)
        this.SaveSingleSetting(nameof (numDelay), value.ToString(), "Delay của threads");
      this.numDelayTrue = value * 100;
      if (this.numDelayTrue == 0)
        this.numDelayTrue = 100;
      this._numDelay = value;
    }
  }

  public string MyTest
  {
    get => this._MyTest;
    set
    {
      if (this.AllInformationLoaded && this._MyTest != value)
        this.SaveSingleSetting(nameof (MyTest), value, "TN chuyến cuối hướng nào");
      this._MyTest = value;
    }
  }

  public void SaveSingleSetting(
    string keyName,
    string value,
    string desc = "",
    params string[] parameters)
  {
  }

  public bool IsPro2 => this.AppMode2 == AllEnums.AutoModes.Pro;

  public AllEnums.AutoModes AppMode
  {
    get => AllEnums.AutoModes.Pro;
    set => this._appMode = AllEnums.AutoModes.Pro;
  }

  public AllEnums.AutoModes AppMode2
  {
    get => AllEnums.AutoModes.Pro;
    set => this._appMode2 = AllEnums.AutoModes.Pro;
  }

  public string NoPetName
  {
    get
    {
      if (frmLogin.GAuto.Settings.CompilingLanguage == "VN")
        return "Không có";
      return frmLogin.GAuto.Settings.CompilingLanguage == "EN" ? "No need" : "没有";
    }
  }

  public string GameID
  {
    get
    {
      if (frmLogin.GAuto.Settings.CompilingLanguage == "VN")
        return "tlbbvng";
      return frmLogin.GAuto.Settings.CompilingLanguage == "EN" || frmLogin.GAuto.Settings.CompilingLanguage == "CN" ? "tlenglish" : "tlchinese";
    }
  }

  public string ProxyURL
  {
    get => frmLogin.GAuto.Settings.CompilingLanguage == "VN" ? "prx.gameauto.net" : "";
  }

  public string FacebookURL
  {
    get
    {
      if (frmLogin.GAuto.Settings.CompilingLanguage == "VN")
        return "http://facebook.com/gameautopro";
      if (frmLogin.GAuto.Settings.CompilingLanguage == "EN")
        return "http://facebook.com/tianlongauto";
      return frmLogin.GAuto.Settings.CompilingLanguage == "CN" ? "http://facebook.com/1139173952767898" : "tlchinese";
    }
  }

  public string PayPalURL
  {
    get
    {
      if (frmLogin.GAuto.Settings.CompilingLanguage == "EN")
        return "http://www.tianlongauto.net/autotl/auto_buy.php";
      return frmLogin.GAuto.Settings.CompilingLanguage == "CN" ? "http://www.123bot.net/payment/auto_buy.php" : "tlchinese";
    }
  }

  public string WhatsNewURL
  {
    get
    {
      if (frmLogin.GAuto.Settings.CompilingLanguage == "VN")
        return "http://server1.gameauto.net/tan-thien-long-3d-vng/cap-nhat-thong-tin-fix-loi-cac-phien-ban";
      if (frmLogin.GAuto.Settings.CompilingLanguage == "EN")
        return "http://www.tianlongauto.net";
      return frmLogin.GAuto.Settings.CompilingLanguage == "CN" ? "http://www.123bot.net" : "tlchinese";
    }
  }

  public string CheckUserURL
  {
    get => frmLogin.CompilingLanguage == "VN" ? "payment/auto_checkuser.php" : "tlenglish";
  }

  public string CouponURL
  {
    get => frmLogin.CompilingLanguage == "VN" ? "forum/auto_coupon.php" : "tlenglish";
  }

  public string NapTheURL
  {
    get => frmLogin.CompilingLanguage == "VN" ? "forum/auto_chargev2_2.php" : "tlenglish";
  }

  public string GiftCodeURL
  {
    get
    {
      if (frmLogin.GAuto.Settings.CompilingLanguage == "VN")
        return "forum/auto_gift.php";
      if (frmLogin.GAuto.Settings.CompilingLanguage == "EN")
        return "http://www.tianlongauto.net/autotl/auto_gift.php";
      return frmLogin.GAuto.Settings.CompilingLanguage == "CN" ? "http://www.123bot.net/payment/auto_gift.php" : "tlenglish";
    }
  }

  public string ServerListURL
  {
    get => frmLogin.GAuto.Settings.CompilingLanguage == "VN" ? "payment/auto_balance.php" : "error";
  }

  public string AutoInfoURL
  {
    get
    {
      if (frmLogin.GAuto.Settings.CompilingLanguage == "VN")
        return "payment/auto_info.php";
      if (frmLogin.GAuto.Settings.CompilingLanguage == "EN")
        return "http://www.tianlongauto.net/autotl/auto_info.php";
      return frmLogin.GAuto.Settings.CompilingLanguage == "CN" ? "http://www.123bot.net/payment/auto_info.php" : "tlenglish";
    }
  }

  public string RegURL
  {
    get
    {
      if (frmLogin.GAuto.Settings.CompilingLanguage == "VN")
        return frmLogin.SwitchURL ? "http://server1.gameauto.net" : "http://server1.gameauto.net";
      if (frmLogin.GAuto.Settings.CompilingLanguage == "EN")
        return "http://www.tianlongauto.net/autotl/models/captcha.php";
      return frmLogin.GAuto.Settings.CompilingLanguage == "CN" && !frmLogin.SwitchURL ? "http://www.123bot.net/payment/models/captcha.php" : "tlenglish";
    }
  }

  public string CaptchaURL
  {
    get
    {
      if (frmLogin.GAuto.Settings.CompilingLanguage == "VN")
        return "payment/models/captcha.php";
      if (frmLogin.GAuto.Settings.CompilingLanguage == "EN")
        return "http://www.tianlongauto.net/autotl/auto_login_003.php";
      return frmLogin.GAuto.Settings.CompilingLanguage == "CN" && !frmLogin.SwitchURL ? "http://www.123bot.net/payment/auto_login.php" : "tlenglish";
    }
  }

  public string ChangePasswordURL
  {
    get
    {
      if (frmLogin.GAuto.Settings.CompilingLanguage == "VN")
        return "payment/auto_changepwd.php";
      if (frmLogin.GAuto.Settings.CompilingLanguage == "EN")
        return "http://www.tianlongauto.net/autotl/auto_login_003.php";
      return frmLogin.GAuto.Settings.CompilingLanguage == "CN" && !frmLogin.SwitchURL ? "http://www.123bot.net/payment/auto_login.php" : "tlenglish";
    }
  }

  public string LoginNewURL
  {
    get
    {
      if (frmLogin.GAuto.Settings.CompilingLanguage == "VN")
        return "payment/auto_login.php";
      if (frmLogin.GAuto.Settings.CompilingLanguage == "EN")
        return "http://www.tianlongauto.net/autotl/auto_login_003.php";
      return frmLogin.GAuto.Settings.CompilingLanguage == "CN" && !frmLogin.SwitchURL ? "http://www.123bot.net/payment/auto_login.php" : "tlenglish";
    }
  }

  public string BlockReportURL => "payment/auto_getinfo.php";

  public string LoginURL
  {
    get
    {
      if (frmLogin.GAuto.Settings.CompilingLanguage == "VN")
        return "forum/auto_loginv2_42.php";
      if (frmLogin.GAuto.Settings.CompilingLanguage == "EN")
        return "http://www.tianlongauto.net/autotl/auto_login_003.php";
      return frmLogin.GAuto.Settings.CompilingLanguage == "CN" && !frmLogin.SwitchURL ? "http://www.123bot.net/payment/auto_login.php" : "tlenglish";
    }
  }

  public string VersionsURL
  {
    get
    {
      if (frmLogin.GAuto.Settings.CompilingLanguage == "VN")
        return "http://update.gameauto.net/downloads/";
      if (frmLogin.GAuto.Settings.CompilingLanguage == "EN")
        return "http://server1.gameauto.net/payment/";
      return frmLogin.GAuto.Settings.CompilingLanguage == "CN" ? "http://update.gameauto.net/downloads/" : "tlenglish";
    }
  }

  public string UsageURL
  {
    get
    {
      if (frmLogin.GAuto.Settings.CompilingLanguage == "VN")
        return "mod/myusagedev.php";
      if (frmLogin.GAuto.Settings.CompilingLanguage == "EN")
        return "http://www.tianlongauto.net/autotl/myusage.php";
      return frmLogin.GAuto.Settings.CompilingLanguage == "CN" ? "http://www.123bot.net/payment/myusage.php" : "tlenglish";
    }
  }

  public string HouseKeeperURL
  {
    get
    {
      if (frmLogin.GAuto.Settings.CompilingLanguage == "VN" && frmLogin.VIPMode <= 1)
        return "payment/auto_askme.php";
      if (frmLogin.GAuto.Settings.CompilingLanguage == "EN" || frmLogin.VIPMode == 2)
        return "http://www.tianlongauto.net/autotl/auto_getaddressv2_15.php";
      if (!(frmLogin.GAuto.Settings.CompilingLanguage == "CN") && frmLogin.VIPMode != 3)
        return "tlenglish";
      return !frmLogin.ReadOldStyle ? "http://www.123bot.net/payment/auto_get001.php" : "http://www.123bot.net/autotl/auto_getaddressv2_15.php";
    }
  }

  public string GetDataURL
  {
    get
    {
      if (frmLogin.GAuto.Settings.CompilingLanguage == "VN" && frmLogin.VIPMode <= 1)
        return "payment/auto_data.php";
      if (frmLogin.GAuto.Settings.CompilingLanguage == "EN" || frmLogin.VIPMode == 2)
        return "http://www.tianlongauto.net/autotl/auto_getaddressv2_15.php";
      if (!(frmLogin.GAuto.Settings.CompilingLanguage == "CN") && frmLogin.VIPMode != 3)
        return "tlenglish";
      return !frmLogin.ReadOldStyle ? "http://www.123bot.net/payment/auto_get001.php" : "http://www.123bot.net/autotl/auto_getaddressv2_15.php";
    }
  }

  public string GetAddressURL
  {
    get
    {
      if (frmLogin.GAuto.Settings.CompilingLanguage == "VN" && frmLogin.VIPMode <= 1)
        return "forum/auto_getaddressv2_23.php";
      if (frmLogin.GAuto.Settings.CompilingLanguage == "EN" || frmLogin.VIPMode == 2)
        return "http://www.tianlongauto.net/autotl/auto_getaddressv2_15.php";
      if (!(frmLogin.GAuto.Settings.CompilingLanguage == "CN") && frmLogin.VIPMode != 3)
        return "tlenglish";
      return !frmLogin.ReadOldStyle ? "http://www.123bot.net/payment/auto_get001.php" : "http://www.123bot.net/autotl/auto_getaddressv2_15.php";
    }
  }

  public string MainURL2
  {
    get
    {
      if (frmLogin.GAuto.Settings.CompilingLanguage == "VN")
        return "http://server1.gameauto.net/|http://server2.gameauto.net/|http://gautovn.gameauto.net/|http://server3.gameauto.net/";
      return frmLogin.GAuto.Settings.CompilingLanguage != "VN" ? "http://server1.gameauto.net/|http://server2.gameauto.net/|http://server3.plaintutorials.com/" : "error";
    }
  }

  public string MainURL
  {
    get
    {
      if (frmLogin.GAuto.Settings.CompilingLanguage == "VN")
      {
        if (frmLogin.SwitchURL)
          return "http://51.254.128.197/";
        switch (frmLogin.LoginServer)
        {
          case 1:
            return "http://server1.gameauto.net/";
          case 2:
            return "http://server2.gameauto.net/";
          case 3:
            return "http://www2.plaintutorials.com/";
        }
      }
      else
      {
        if (frmLogin.GAuto.Settings.CompilingLanguage == "EN")
          return "http://www.tianlongauto.net/";
        if (frmLogin.GAuto.Settings.CompilingLanguage == "CN")
          return "http://www.123bot.net/";
      }
      return "tlenglish";
    }
  }

  public string UserGuideURL
  {
    get
    {
      if (frmLogin.GAuto.Settings.CompilingLanguage == "VN")
        return frmLogin.SwitchURL ? "http://51.254.128.197/tan-thien-long-3d-vng/huong-dan-su-dung-gauto-tlbb-auto-thien-long-bat-bo/" : "http://server1.gameauto.net/tan-thien-long-3d-vng/huong-dan-su-dung-gauto-tlbb-auto-thien-long-bat-bo/";
      if (frmLogin.GAuto.Settings.CompilingLanguage == "EN")
        return "http://www.tianlongauto.net/how-to-use";
      return frmLogin.GAuto.Settings.CompilingLanguage == "CN" ? "http://www.123bot.net/how-to-use" : "tnchinese";
    }
  }

  public string RegistrationGuideURL
  {
    get
    {
      if (frmLogin.GAuto.Settings.CompilingLanguage == "VN")
        return frmLogin.SwitchURL ? "http://51.254.128.197/?p=36" : "http://server1.gameauto.net/?p=36";
      if (frmLogin.GAuto.Settings.CompilingLanguage == "EN")
        return "http://www.tianlongauto.net/howto-register";
      return frmLogin.GAuto.Settings.CompilingLanguage == "EN" ? "http://www.123bot.net/howto-register" : "tnchinese";
    }
  }

  public string ForumURL
  {
    get
    {
      if (frmLogin.GAuto.Settings.CompilingLanguage == "VN")
        return "http://server1.gameauto.net/forum/index.php";
      if (frmLogin.GAuto.Settings.CompilingLanguage == "EN")
        return "http://www.tianlongauto.net";
      return frmLogin.GAuto.Settings.CompilingLanguage == "EN" ? "http://www.123bot.net/forum" : "tnchinese";
    }
  }

  public string ForgotPassURL
  {
    get
    {
      if (frmLogin.GAuto.Settings.CompilingLanguage == "VN")
        return "payment/quenmk.php";
      if (frmLogin.GAuto.Settings.CompilingLanguage == "EN")
        return "http://www.tianlongauto.net/autotl/forgot-password.php";
      return frmLogin.GAuto.Settings.CompilingLanguage == "CN" ? "http://www.123bot.net/payment/auto_forgot.php" : "tlchinese";
    }
  }

  public string RegisterAccountURL
  {
    get
    {
      if (frmLogin.GAuto.Settings.CompilingLanguage == "VN")
        return "forum/ucp.php?mode=register";
      if (frmLogin.GAuto.Settings.CompilingLanguage == "EN")
        return "http://www.tianlongauto.net/autotl/register.php";
      return frmLogin.GAuto.Settings.CompilingLanguage == "CN" ? "http://www.123bot.net/payment/auto_reg.php" : "tlchinese";
    }
  }

  public string TermsURL
  {
    get
    {
      if (frmLogin.GAuto.Settings.CompilingLanguage == "VN")
        return "http://gameauto.net/dieu-khoan-su-dung-gauto-tlbb/";
      if (frmLogin.GAuto.Settings.CompilingLanguage == "EN")
        return "http://tianlongauto.net/term-of-service/";
      return frmLogin.GAuto.Settings.CompilingLanguage == "CN" ? "http://123bot.net/term-of-service/" : "tlenglish";
    }
  }

  public string MainDB
  {
    get
    {
      if (frmLogin.GAuto.Settings.CompilingLanguage == "VN")
        return "TLBB.db";
      if (frmLogin.GAuto.Settings.CompilingLanguage == "EN")
        return "TLBBUS.db";
      return frmLogin.GAuto.Settings.CompilingLanguage == "CN" ? "TLBBCN.db" : "TLBBCN.db";
    }
  }

  public bool DanhHieuOnOff
  {
    get => this._DanhHieuOnOff;
    set
    {
      if (this.AllInformationLoaded && this._DanhHieuOnOff != value)
        this.SaveSingleSetting(nameof (DanhHieuOnOff), value.ToString(), "Bật tắt tên và danh hiệu");
      this._DanhHieuOnOff = value;
    }
  }

  public string ExeFilePath
  {
    get => this._ExeFilePath;
    set
    {
      if (this.AllInformationLoaded && this._ExeFilePath != value)
        this.SaveSingleSetting(nameof (ExeFilePath), value.ToString(), "File game exe");
      this._ExeFilePath = value;
    }
  }

  public bool cboxNoKS
  {
    get => this._cboxNoKS;
    set
    {
      if (this.AllInformationLoaded && this._cboxNoKS != value)
        this.SaveSingleSetting(nameof (cboxNoKS), value.ToString(), "Chống KS quái");
      this._cboxNoKS = value;
    }
  }

  public bool optKinhMachNghichHanh
  {
    get => this._optKinhMachNghichHanh;
    set
    {
      if (this.AllInformationLoaded && this._optKinhMachNghichHanh != value)
        this.SaveSingleSetting(nameof (optKinhMachNghichHanh), value.ToString(), "Dùng KMNH hay không");
      this._optKinhMachNghichHanh = value;
    }
  }

  public bool optPhuBanKeoDoi
  {
    get => this._optPhuBanKeoDoi;
    set
    {
      if (this.AllInformationLoaded && this._optPhuBanKeoDoi != value)
        this.SaveSingleSetting(nameof (optPhuBanKeoDoi), value.ToString(), "Kéo đội phụ bản");
      this._optPhuBanKeoDoi = value;
    }
  }

  public bool optSuDungF1
  {
    get => this._optSuDungF1;
    set
    {
      if (this.AllInformationLoaded && this._optSuDungF1 != value)
        this.SaveSingleSetting(nameof (optSuDungF1), value.ToString(), "Kéo đội phụ bản");
      this._optSuDungF1 = value;
    }
  }

  public bool optArrangeSkillByName
  {
    get => this._optArrangeSkillByName;
    set
    {
      if (this.AllInformationLoaded && this._optArrangeSkillByName != value)
        this.SaveSingleSetting(nameof (optArrangeSkillByName), value.ToString(), "Xếp skill theo tên skill");
      this._optArrangeSkillByName = value;
    }
  }

  public bool cboxAgreement
  {
    get => this._cboxAgreement;
    set
    {
      if (this.AllInformationLoaded && this._cboxAgreement != value)
        this.SaveSingleSetting(nameof (cboxAgreement), value.ToString(), "Agreement cho phần profile");
      this._cboxAgreement = value;
    }
  }

  public int optLoginCungLuc
  {
    get => this._optLoginCungLuc;
    set
    {
      if (this.AllInformationLoaded && this._optLoginCungLuc != value)
        this.SaveSingleSetting(nameof (optLoginCungLuc), value.ToString(), "Login cùng lúc");
      this._optLoginCungLuc = value;
    }
  }

  public bool optStartNewGame
  {
    get => this._optStartNewGame;
    set
    {
      if (this.AllInformationLoaded && this._optStartNewGame != value)
        this.SaveSingleSetting(nameof (optStartNewGame), value.ToString(), "Nhìn gì...");
      this._optStartNewGame = value;
    }
  }

  public bool optNoSkillLag
  {
    get => this._optNoSkillLag;
    set
    {
      if (this.AllInformationLoaded && this._optNoSkillLag != value)
        this.SaveSingleSetting(nameof (optNoSkillLag), value.ToString(), "Nhìn gì...");
      this._optNoSkillLag = value;
    }
  }

  public bool optGomQuai2
  {
    get => this._optGomQuai2;
    set
    {
      if (this.AllInformationLoaded && this._optGomQuai2 != value)
        this.SaveSingleSetting(nameof (optGomQuai2), value.ToString(), "Nhìn gì...");
      this._optGomQuai2 = value;
    }
  }

  public long TimeGiaiDoHoa
  {
    get => this._TimeGiaiDoHoa;
    set
    {
      if (this.AllInformationLoaded && this._TimeGiaiDoHoa != value)
        this.SaveSingleSetting(nameof (TimeGiaiDoHoa), value.ToString(), "Nhìn gì...");
      this._TimeGiaiDoHoa = value;
    }
  }

  public bool optChangeTargetFast
  {
    get => this._optChangeTargetFast;
    set
    {
      if (this.AllInformationLoaded && this._optChangeTargetFast != value)
        this.SaveSingleSetting(nameof (optChangeTargetFast), value.ToString(), "Nhìn gì...");
      this._optChangeTargetFast = value;
    }
  }

  public int soVongQHoa
  {
    get => this._soVongQHoa;
    set
    {
      if (this.AllInformationLoaded && this._soVongQHoa != value)
        this.SaveSingleSetting(nameof (soVongQHoa), value.ToString(), "Nhìn gì...");
      this._soVongQHoa = value;
    }
  }

  public int soHangTrongHoa
  {
    get => this._soHangTrongHoa;
    set
    {
      if (this.AllInformationLoaded && this._soHangTrongHoa != value)
        this.SaveSingleSetting(nameof (soHangTrongHoa), value.ToString(), "Nhìn gì...");
      this._soHangTrongHoa = value;
    }
  }

  public int soVongQSM
  {
    get => this._soVongQSM;
    set
    {
      if (this.AllInformationLoaded && this._soVongQSM != value)
        this.SaveSingleSetting(nameof (soVongQSM), value.ToString(), "Nhìn gì...");
      this._soVongQSM = value;
    }
  }

  public bool cboxATRunPP
  {
    get => this._cboxATRunPP;
    set
    {
      if (this.AllInformationLoaded && this._cboxATRunPP != value)
        this.SaveSingleSetting(nameof (cboxATRunPP), value.ToString(), "Nhìn gì...");
      this._cboxATRunPP = value;
    }
  }

  public bool TipHuongDan
  {
    get => this._TipHuongDan;
    set
    {
      if (this.AllInformationLoaded && this._TipHuongDan != value)
        this.SaveSingleSetting(nameof (TipHuongDan), value.ToString(), "Nhìn gì...");
      this._TipHuongDan = value;
    }
  }

  public bool cboxNMBuffSelectTarget
  {
    get => this._cboxNMBuffSelectTarget;
    set
    {
      if (this.AllInformationLoaded && this._cboxNMBuffSelectTarget != value)
        this.SaveSingleSetting(nameof (cboxNMBuffSelectTarget), value.ToString(), "Nhìn gì...");
      this._cboxNMBuffSelectTarget = value;
    }
  }

  public bool LamNheAuto
  {
    get => this._LamNheAuto;
    set
    {
      if (this.AllInformationLoaded && this._LamNheAuto != value)
        this.SaveSingleSetting(nameof (LamNheAuto), value.ToString(), "Nhìn gì...");
      this._LamNheAuto = value;
    }
  }

  public bool DongYPhuDoi
  {
    get => this._DongYPhuDoi;
    set
    {
      if (this.AllInformationLoaded && this._DongYPhuDoi != value)
        this.SaveSingleSetting(nameof (DongYPhuDoi), value.ToString());
      this._DongYPhuDoi = value;
    }
  }

  public bool TuKetNoiLai
  {
    get => this._TuKetNoiLai;
    set
    {
      if (this.AllInformationLoaded && this._TuKetNoiLai != value)
        this.SaveSingleSetting(nameof (TuKetNoiLai), value.ToString());
      this._TuKetNoiLai = value;
    }
  }

  public bool TuMuaCKH
  {
    get => this._TuMuaCKH;
    set
    {
      if (this.AllInformationLoaded && this._TuMuaCKH != value)
        this.SaveSingleSetting(nameof (TuMuaCKH), value.ToString());
      this._TuMuaCKH = value;
    }
  }

  public bool TuThoatGameDis
  {
    get => this._TuThoatGameDis;
    set
    {
      if (this.AllInformationLoaded && this._TuThoatGameDis != value)
        this.SaveSingleSetting(nameof (TuThoatGameDis), value.ToString());
      this._TuThoatGameDis = value;
    }
  }

  public bool TuDongYChuyenCanh
  {
    get => this._TuDongYChuyenCanh;
    set
    {
      if (this.AllInformationLoaded && this._TuDongYChuyenCanh != value)
        this.SaveSingleSetting(nameof (TuDongYChuyenCanh), value.ToString());
      this._TuDongYChuyenCanh = value;
    }
  }

  public string cboCDExtend
  {
    get => this._cboCDExtend;
    set
    {
      if (this.AllInformationLoaded && this._cboCDExtend != value)
        this.SaveSingleSetting(nameof (cboCDExtend), value.ToString());
      this._cboCDExtend = value;
    }
  }
}
