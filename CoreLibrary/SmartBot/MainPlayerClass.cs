// Decompiled with JetBrains decompiler
// Type: SmartBot.MainPlayerClass
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace SmartBot;

public class MainPlayerClass : INotifyPropertyChanged
{
  private TargetProcess localTarget;
  public List<PlayerVIP> PlayerAroundList = new List<PlayerVIP>();
  public List<int> CheckedItemList = new List<int>();
  public long LastActionTimeStamp;
  public long LastSkillTimeStamp;
  public bool Initialized;
  public List<KhoangDuocEntry> KhoangDuocList = new List<KhoangDuocEntry>();
  public List<AllEnums.CharStatuses> ListStatusNoAttack = new List<AllEnums.CharStatuses>()
  {
    AllEnums.CharStatuses.BUYING_NPC,
    AllEnums.CharStatuses.SELLING_NPC,
    AllEnums.CharStatuses.EATING,
    AllEnums.CharStatuses.MOUNT,
    AllEnums.CharStatuses.GOGOGO,
    AllEnums.CharStatuses.SELF_HEALING,
    AllEnums.CharStatuses.NMBUFFMAU,
    AllEnums.CharStatuses.VETHANH
  };
  public string Username = "";
  public AllEnums.ActionResults ActionResult;
  public AllEnums.Menpais Menpai;
  public long RunSkillStamp;
  private AllEnums.CharStatuses _Status;
  private List<AllEnums.Menpais> TankerList = new List<AllEnums.Menpais>()
  {
    AllEnums.Menpais.NOMENPAI,
    AllEnums.Menpais.CAIBANG,
    AllEnums.Menpais.THIENSON,
    AllEnums.Menpais.MINHGIAO,
    AllEnums.Menpais.THIEULAM,
    AllEnums.Menpais.MODUNG
  };
  public int[] PlayerLvlExp = new int[150]
  {
    0,
    90,
    324,
    630,
    1152,
    1620,
    1800,
    1980,
    2160,
    2340,
    6300,
    7020,
    7776,
    8874,
    10044,
    11628,
    13320,
    15498,
    18216,
    21528,
    25488,
    30150,
    35568,
    41796,
    48888,
    57420,
    67500,
    78678,
    91008,
    104544,
    123624,
    144270,
    166536,
    190476,
    216144,
    243594,
    272880,
    304056,
    337176,
    372294,
    409860,
    449955,
    492660,
    538056,
    586224,
    637245,
    691200,
    748170,
    808236,
    871479,
    937980,
    1007820,
    1081080,
    1157841,
    1238184,
    1322190,
    1409940,
    1501515,
    1596996,
    1696464,
    1800000,
    1907685,
    2019600,
    2135826,
    2256444,
    2381535,
    2516850,
    2667825,
    2835000,
    3018915,
    3220110,
    3439125,
    3676500,
    3932775,
    4208490,
    4518405,
    4863600,
    5245155,
    5664150,
    6121665,
    6739740,
    7676775,
    9098370,
    11177325,
    14093640,
    18034515,
    23194350,
    29774745,
    37984500,
    48039615,
    60163290,
    74585925,
    91545120,
    111285675,
    134059590,
    160126065,
    189751500,
    223209495,
    260780850,
    302753565,
    307564920,
    312506775,
    317581830,
    322792785,
    328142340,
    333633195,
    339268050,
    345049605,
    350980560,
    357063615,
    363301470,
    369696825,
    376252380,
    382970835,
    389854890,
    396907245,
    404130600,
    411527655,
    419101110,
    426853665,
    434788020,
    442906875,
    451212930,
    459708885,
    468397440,
    477281295,
    486363150,
    495645705,
    505131660,
    514823715,
    524724570,
    534836925,
    545163480,
    555706935,
    566469990,
    577455345,
    588665700,
    600103755,
    611772210,
    623673765,
    635811120,
    648186975,
    660804030,
    673664985,
    686772540,
    724294215,
    766577250,
    813979845,
    866867400,
    925612515
  };
  public List<int> GreenList = new List<int>();
  public QuaiIndividual CurrentTarget;
  public int LastTargetIDIndex;
  public int LastTargetID = -1;
  public int TargetBocID;
  public int BocShowID;
  public int CurrentTargetID = -1;
  public AllEnums.FightingModes TempFightMode;
  public List<SkillsClass> SkillSet = new List<SkillsClass>();
  public bool ReadyToAttack = true;
  public Stopwatch ResetTimeStamp = new Stopwatch();
  public long CleanUpInventoryStamp;
  public int BocShow;
  public int SynthesizeShow;
  public int InventoryShow;
  public int ID;
  public int KSModeValue = -1;
  public int DatabaseID;
  public int DatabaseIDLow;
  public int CaptchaRemaining;
  public long CaptchaTKStamp;
  public int AttackedID = -1;
  public long AttackedIDStamp;
  private int mapID_ = -1;
  public string QuestInfo = "";
  public string QuestInfoHex = "";
  public string Name = "";
  public int HP;
  public int MaxHP;
  private string _hpPerDisplay = "0%";
  public int MP;
  public int MaxMP;
  public int Rage;
  public int MaxRage = 1000;
  public int IsAttacked;
  public int AttackerID = -1;
  public int CurentExp;
  public int OnlineTime;
  public float PosX;
  public List<AdvancedPath> PossiblePaths;
  public List<AdvancedPath> EntirePaths;
  public bool CannotReadInventory;
  public int ReadInventoryStamp;
  public bool ResetPathLabels;
  public float FromX;
  public float FromY;
  public long LastMoveStamp;
  public int MoveStuckDelay = 3000;
  public float PreviousX;
  public float PreviousY;
  public float PosY;
  public Stopwatch LastTimeMove = new Stopwatch();
  public Stopwatch TargetTimestamp = new Stopwatch();
  public float TargetLastHPPercent;
  public Stopwatch TangHinhTimeStamp = new Stopwatch();
  public AllEnums.CharStatuses SavedStatus;
  public int TargetMapID = -1;
  public bool MoveAcrossMap;
  public bool UseAutoMove;
  public bool IsMounted;
  public int veThanhTimeStamp;
  public bool tempResetFlag;
  public bool veThanhAutoFlag;
  public Stopwatch veThanhFlagTimeStamp = new Stopwatch();
  public long ChatQuangCaoStamp;
  public Stopwatch AutoChatStamp = new Stopwatch();
  public long newChatStamp;
  public long LastChatStamp;
  public long RemainingChatTime = 5000;
  public int ChatTimes;
  public bool IsTrader;
  public bool IsManualMove;
  public AdvancedPath LUAStartMap = new AdvancedPath();
  public AdvancedPath LUAEndMap = new AdvancedPath();
  public AllEnums.CharStatuses MinorStatus;
  public Stopwatch MoveLongStamp = new Stopwatch();
  public Stopwatch AutoMoveStamp = new Stopwatch();
  public Stopwatch CalcPathStamp = new Stopwatch();
  public bool AutoMoveConfirm;
  public Stopwatch LastPostStamp = new Stopwatch();
  public Stopwatch JustWarpedStamp = new Stopwatch();
  public float Last3SecX;
  public float last3SecY;
  public float SavedPosY = -1f;
  public float SavedPosX = -1f;
  public int SavedMapID = -1;
  public bool MoveLongTrigger;
  public int LongMoveMapID = -1;
  public int LongMoveX;
  public int LongMoveY;
  public bool TNDirectionXuoi = true;
  public bool MoveFlashPos;
  public int tempTNRounds;
  public Stopwatch CheckPhieuStamp = new Stopwatch();
  public List<Label> AllLabels = new List<Label>();
  public bool LastTNStatus;
  public long RemoveItemStamp;
  public bool CaptchaAlerted;
  public Stopwatch CaptchaAlertStamp = new Stopwatch();
  public bool PKAlerted;
  public Stopwatch PKAlertStamp = new Stopwatch();
  public bool CaptchaGUI;
  public long NMSkillStamp;
  public Stopwatch NhatBocStamp = new Stopwatch();
  public long petAOEStamp;
  public bool CanNhatBoc = true;
  public long CanNhatBocStamp;
  public bool cboxAnHienGame = true;
  public float TargetX;
  public float ToX;
  public float ToXnow;
  public float TargetY;
  public float ToY;
  public float ToYnow;
  public double distMove;
  public int distMoveCounter;
  public byte FlagPartyFollowRequest;
  public byte IsPartyFollowed;
  public byte AttackStatus;
  public int HorseType = -1;
  public byte CharStatus2;
  public byte _ActionStatus;
  public byte ActionStatusPrevious;
  public bool FlagHetThucAn;
  public bool FlagFullBoc;
  public bool FullThungRoi;
  public bool FlagBeingAttacked;
  public int Level;
  public bool HasTarget;
  public long CaptchaAlertAudioStamp;
  public bool CaptchaSendDisconnected;
  public bool tempcboxVeThanhHetMau;
  public bool tempcboxVeThanhHetThucAn;
  public bool tempcboxVeThanhHetBNM;
  public bool tempcboxFullThungVE;
  public Stopwatch petAOECheckStamp = new Stopwatch();
  public int ChatQuangCaoDelayDelta;
  public long TargetLagStamp;
  public long RunSkillStamp2;
  public AllEnums.LogActions LogLastAction = AllEnums.LogActions.MuaTN;
  public long CheckVeThanhStamp;
  public int PreviousIsPartyFollowed;
  public Stopwatch PartyFollowStamp = new Stopwatch();
  public Stopwatch MovingDirectionStamp = new Stopwatch();
  public MovingPath PathHistory;
  public long PTInviteStamp;
  public long CheckExitGameStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
  public int Pass2BoxShow;
  private int _isSceneTrans;
  public int isAcceptBox;
  public int isMessageBox_Self;
  public int isQuestFrameShow;
  public int X2Remaining;
  public long X2TimeStamp;
  public int CheckEnforceFollow;
  public int X2CheckInterval = 60000;
  public Stopwatch PartyGroupingStamp = new Stopwatch();
  public AllEnums.CharStatuses MinorStatus2;
  public bool TriedHoiSinh;
  public long HoiSinhStamp;
  public bool IsPK;
  public long LastPKStamp;
  public Stopwatch IsPKStamp = new Stopwatch();
  public bool PreviousIsPK;
  public Stopwatch PKReturnStamp = new Stopwatch();
  public Stopwatch CheckSkillDelayStamp = new Stopwatch();
  public long DiedStamp;
  public int VeThanhReset = 25000;
  public int VeThanhRecheck = 900000;
  public bool IsTrongTrot;
  public bool TrongTrotNPC1;
  public List<NewBoc> TrongTrotBoc1 = new List<NewBoc>();
  public List<NewBoc> TrongTrotBoc2 = new List<NewBoc>();
  public bool TrongTrotNPC2;
  public Stopwatch TrongTrotStamp = new Stopwatch();
  public bool IsKhaiKhoang;
  public bool IsHaiDua;
  public Stopwatch LastScriptStamp = new Stopwatch();
  public bool IsHaiDuaChet;
  public int DuaNPCID = 7;
  public bool IsAcTac;
  public bool IsAcBa;
  public long TNStamp;
  public bool IsBuffMode;
  public Stopwatch SkillActionStamp = new Stopwatch();
  public Stopwatch TransitioningStamp = new Stopwatch();
  public string SavedDisplayName = "";
  public Stopwatch DisplayNameStamp = new Stopwatch();
  public bool TradeMoveTemp;
  public bool IsHaiDuaCarrying;
  public int trainExpSource;
  public int trainExpDiff;
  public DateTime trainExpStamp;
  public TimeSpan trainExpSpan;
  public Stopwatch NotTransitioningStamp = new Stopwatch();
  public int prevNotTransitioning;
  public long targetKeyStamp;
  public bool JustWarped;
  public object JustWarpedLock = new object();
  public int Last3SecMapID = -1;
  public Stopwatch Pass2Stamp = new Stopwatch();
  public int MyAttackerID = -1;
  public long LastNullTargetStamp;
  public bool BusyXuatPet;
  public bool IsTrungAc;
  public long CheckLenhBaiTAStamp;
  public bool TrungAcItemUsed;
  public int NhiemVuType = -1;
  public string NhiemVuString1 = "";
  public string NhiemVuString2 = "";
  public int NhiemVuQuaiID = -1;
  public int NhiemVuInt_1 = -1;
  public int NhiemVuCounter;
  public bool NhiemVuFinish;
  public int SlotDC;
  public int SlotNL;
  private int _NhiemVuPosX;
  public int NhiemVuPosX;
  public int NhiemVuPosX_Save;
  public int NhiemVuPosY_Save;
  public int NhiemVuMapID_Save;
  public int NhiemVuItemIndex = -1;
  public int QLKF1;
  public int QLKF2;
  public int QLKF3;
  public int QLKF4;
  private int _NhiemVuPosY;
  public int NhiemVuPosY;
  public int TempPosX;
  public int TempPosY;
  public string EventString = "";
  private int _NhiemVuMapID = -1;
  public int NhiemVuMapID = -1;
  public List<InMapPoint> InMapPathPoints = new List<InMapPoint>();
  public List<InMapPoint> OutMapPathPoints = new List<InMapPoint>();
  public long TrungAcMoveStamp;
  public bool TrungAcFoundQuai;
  public bool TrungAcFinished;
  public bool TrungAcQuaiDied;
  public bool TrungAcCheckMap;
  public bool TrungAcFoundBoc;
  public bool IsLuyenKim;
  public long LinhThuStamp;
  public long TangKinhCacStamp;
  public long DiPhuBanStamp;
  public long DietGonStamp;
  public int DietGonFlag;
  public bool indexPPcalc = true;
  public int TruHaiFlag;
  public long QSMStamp;
  public long DungPhuStamp;
  public long batPetStamp;
  public long NhatHopBaoRuongStamp;
  public long ActionStamp;
  public long UpLevelStamp;
  public long LuyenKimStamp;
  public bool LuyenKimNhanQ;
  public bool LuyenKimFoundBoc;
  public bool LuyenKimHetBoc;
  public bool LuyenKimPlaySkill;
  public long LuyenKimBocStamp;
  public bool LuyenKimFinished;
  public int LuyenKimIntraTour;
  public bool LuyenKimCheckMap;
  public long TrungAcHetQuaiStamp;
  public bool LuyenKimVanChuyen;
  public bool IsMuaKNB;
  public long KNBStamp;
  public List<QuaiIndividual> TrungAcQuaiList = new List<QuaiIndividual>();
  public long TrungAcItemUsedStamp;
  public bool LuyenKimHasInfo;
  public bool IsXayDung;
  public bool IsTuDuongCon;
  public bool isDaoBTD;
  public bool isQSM;
  public bool isCauPhuc;
  public bool isCauNguyen;
  public bool isDoatBaoRuong;
  public bool isMuaDoTrain;
  public bool isBanDoChoNPC;
  public bool hotkeyisQSM;
  public bool isBachHoaDuyen;
  public long XayDungStamp;
  public bool XayDungFinished;
  public bool XayDungFly;
  public bool XayDungDichChuyen;
  public bool XayDungNhanQ;
  public bool XayDungInMap;
  public bool flagXayDungFinished;
  public bool XayDungCheckQ;
  public bool XayDungDanhQuai;
  public string OldQuestInfo = "";
  public long XayDungStamp2;
  public bool XayDungCongTruong;
  public int PathPointIndex;
  public bool IsTBB;
  public bool IsTKC;
  public long MyLastStamp;
  public long LenNguaStamp;
  public long NoTargetStamp;
  public long QuaiDiedStamp;
  public long FoundQuaiStamp;
  public long hetquaiStamp;
  public long EventStamp;
  public long BalloonStamp;
  public long ThoatGameStamp;
  public long ThocBocDanhQuaiStamp;
  public long checkDLLStamp;
  public long VutDoStamp;
  public long YeuCauPass2Stamp;
  public bool PBEnding;
  public bool PBxong1vong;
  public bool hasQuai;
  public int TBBCounter;
  public long TBBStamp;
  public bool TBBNhanQ;
  public bool TBBF1Played;
  public bool TBBF2Played;
  public bool TBBNhanPhiThuy;
  public int actionCounter;
  public int talkCounter;
  public int trieutapCounter;
  public int moveCounter;
  public int lockCounter;
  public int pass2Counter;
  public int thocbocCounter;
  public int nhatbocCounter;
  public int actionFlag;
  public int sellItemFlag;
  public int phubanFlag;
  public int xaydungCounter;
  public int luyenkimCounter;
  public int tuduongconCounter;
  public int trungacCounter;
  public int acbaCounter;
  public int trongtrotCounter;
  public int kkhdCounter;
  public int haihoaCounter;
  public int btdCounter;
  public int tkcCounter;
  public int linhthuCounter;
  public int phlmCounter;
  public long ThreadStampStamp;
  public int QuestStep;
  public string LogString = "";
  public int ThreadStampSaved;
  public bool XayDungVaoCongTruong;
  public int OutPathPointIndex;
  public int InPathPointIndex;
  public bool groupMuaKNBExpanded;
  public bool groupTBBExpanded;
  public bool groupTKCExpanded;
  public bool groupDuaHauExpanded;
  public bool groupKKExpanded;
  public bool groupLKExpanded;
  public bool groupTrungAcExpanded;
  public bool groupTrongTrotExpanded;
  public bool groupAcTacExpanded;
  public bool PhuBanAB;
  public int PhoBanSavedMapID;
  public bool PhoBanTheoSau;
  public bool PhoBanVaoMap;
  public long MyLastOutStamp;
  public bool IsLinhThu;
  public bool PhuBanLinhThu;
  public long PacketReadIndex;
  public long QuaiReadIndex;
  public long NguoiReadIndex;
  public long BocReadIndex;
  public long MsgReadIndex;
  public long HKReadIndex;
  public long FlagCheckJustHit;
  public long CheckBocStamp;
  public int CurrentGold;
  public int ActivePetGuidID;
  public long FlagHetThucAnStamp;
  public long PartyInviteStamp;
  public long LastTimeSeenInvite;
  public long FlagFullBocStamp;
  public long FlagBeingAttackedStamp;
  public long IsAttackedTimeStamp;
  public string ErrorMsg = "";
  public string PacketMsg = "";
  public bool ReadyToNhatBoc = true;
  public long AcBaStampReset;
  public bool PhoBanPoint0;
  public bool groupSkillBuffExpanded;
  public bool groupKyNangExpanded;
  public bool groupPetAOEExpanded;
  public bool groupPKExpanded;
  public int previousMapID = -1;
  public int previousMapID_2 = -1;
  public int previousMapID_3 = -1;
  public bool groupTuyChonExpanded;
  public bool groupChatExpanded;
  public bool groupSpeedExpanded;
  public int CaptchaAddress = -1;
  public bool IsTestNPC;
  public long NhatBocStatusStamp;
  public bool groupVeThanhExpanded;
  public long ResetTargetStamp;
  public long HasTargetStamp;
  public bool KNBConfirm;
  public bool DDorDD;
  public int KNBTabType = -1;
  public bool StopTrain;
  public bool ManaRunOut;
  public long ManaRunOutStamp;
  public bool groupToDoiExpanded;
  public AllEnums.Menpais tempMenpai = AllEnums.Menpais.NOMENPAI;
  public bool flagMoveStuck;
  public float savedStuckX;
  public float savedStuckY;
  public long flagMoveStuckStamp;
  public bool IsMoveTest;
  public bool flagMoveForward;
  public long Lastx2UsedStamp;
  public string tempQuestInfo;
  public long Lastx4UsedStamp;
  public long LastReceiveExpStamp;
  public long X4TimeStamp;
  public long TestMessageStamp;
  public float Last10SecX;
  public float Last10SecY;
  public long Last10SecXYStamp;
  public bool SetHotKey;
  public long stampErrorPacket;
  public bool cboxAnHienGame2 = true;
  public bool flagPetOnOff = true;
  public bool IsMinimized;
  public bool hotkeyIsTuDuongCon;
  public bool hotkeyIsTBB;
  public bool hotkeyLuyenKim;
  public bool hotkeyIsXayDung;
  public bool hotkeyIsTrungAc;
  public bool hotkeyIsBachHoaDuyen;
  public bool hotkeyIsAcTac;
  public bool hotkeyIsTrongTrot;
  public bool hotkeyIsKhaiKhoang;
  public bool hotkeyIsAcBa;
  public bool hotkeyIsLinhThu;
  public bool hotkeyIsPHLM;
  public bool IsPHLM;
  public bool IsPhuBanTuyChinh;
  public bool IsKyCuoc;
  public bool isDietGon;
  public long AnGame2Stamp;
  public bool groupQSMExpanded;
  public bool groupBaoRuongExpanded;
  public long AnGame1Stamp;
  public bool AnGameFlip;
  public AllEnums.CharStatuses Last3SecStatus;
  public long Last3SecStatusStamp;
  public bool IsCheDo;
  public List<int> itemXinArrayGlobal = new List<int>();
  public bool isGiamDinh;
  public bool IsLongMove;
  public long LastSkillSent;
  public int SavedSeq;
  public long WarpStamp;
  public bool IsQ1;
  public bool IsQ2;
  public bool isTrongHoa;
  public bool isBonHoa;
  public List<int> HoaDaBonArrayGlobal = new List<int>();
  public bool isThuHoach;
  public List<MainPlayerClass.HoaThuHoachClass> HoaThuHoachData = new List<MainPlayerClass.HoaThuHoachClass>();
  public bool isYTO;
  public bool Q12GroupExpanded;
  public long StartingStamp;
  public long CheckItemStamp;
  public int dungphudiveMapID = -1;
  public int dungphudivePosX = -1;
  public int dungphudivePosY = -1;
  public long dungphudiveStamp = -1;
  public long CheckDVPStamp;
  public bool PartyKeyLock;
  public bool isNhatTuyet;
  public string ChatRecordedMessage = "";
  public bool groupMuaDoExpanded;
  public bool groupUseItemExpanded;
  public bool YTOGroupExpanded;
  public bool groupPlayersExpanded;
  public bool groupIDBangExpanded;
  public bool IsScheduled;
  public int BangID;
  public int DongMinhID;
  public long ScheduledStamp;
  public bool groupBlacklistExpanded;
  public long IDLEStamp;
  public bool isTanThu;
  public bool isDoiKimTamTi;
  public bool isDoiChiTonCH;
  public bool isThuTaiVanMay;
  public bool isThienLongTueHong;
  public bool isNguHanhPhapThiep;
  public bool isLoLyHoa;
  public bool isDoiKimTinhThach;
  public bool isBuonDuaHau;
  public bool isHuyItemNhiemVu;
  public bool isDoiThoiVang;
  public bool isNhanLeBao;
  public bool isNhanBongCauPhuc;
  public int MyPreBocID;
  public List<AdvancedPath> bestPathPublic;
  public long isSceneTransStamp;
  public long isSceneTransNoClickStamp;
  public bool isDoiLinhHonToaiPhien;
  public int DoiLinhHonToaiPhienMode;
  public bool isDoiPhieuTienVang;
  public int DoiPhieuTienVangMode;
  public bool isDoiThanBinhPhu;
  public int DoiThanBinhPhuMode;
  public bool isNhanX2EXP;
  public int NhanX2EXPMode;
  public bool isPMP;
  public long XuongNguaStamp;
  public bool isLLTB;
  public bool isThuyLao;
  public bool isThuBiChienMinh;

  public event PropertyChangedEventHandler PropertyChanged;

  protected void OnPropertyChanged(string propertyName)
  {
    PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
    if (propertyChanged == null)
      return;
    propertyChanged((object) this, new PropertyChangedEventArgs(propertyName));
  }


  // remove becasue it not used
  //private static unsafe T[] MakeArray<T>(void* t, int length, int tSizeInBytes) where T : struct
  //{
  //  T[] objArray = new T[length];
  //  for (int index = 0; index < length; ++index)
  //  {
  //    IntPtr ptr = new IntPtr((void*) ((IntPtr) (t + index * tSizeInBytes)));
  //    objArray[index] = (T) Marshal.PtrToStructure(ptr, typeof (T));
  //  }
  //  return objArray;
  //}

  public static unsafe void FuckEncAndMemalloc_new()
  {
    IntPtr num1 = MyDLL.OpenProcess(33554432U /*0x02000000*/, 0, (uint) Process.GetCurrentProcess().Id);
    byte[] Pattern1 = new byte[16 /*0x10*/]
    {
      (byte) 77,
      (byte) 105,
      (byte) 4,
      (byte) 61,
      (byte) 166,
      (byte) 5,
      (byte) 231,
      (byte) 43,
      (byte) 184,
      (byte) 244,
      (byte) 140,
      (byte) 241,
      (byte) 196,
      (byte) 204,
      (byte) 181,
      (byte) 106
    };
    if (!frmLogin.encPatched)
    {
      int num2 = 0;
      bool flag = false;
      for (int index = 0; index <= 20; ++index)
      {
        num2 = MyDLL.SearchBytesPattern(num1, Pattern1, index);
        if (num2 > 0)
        {
          byte[] lpBuffer = new byte[4];
          int lpNumberOfBytesRead = 0;
          MyDLL.ReadProcessMemory((int) num1, (IntPtr) (num2 + Pattern1.Length), lpBuffer, 4U, ref lpNumberOfBytesRead);
          if (lpBuffer[0] == (byte) 243 && lpBuffer[1] == (byte) 64 /*0x40*/ && lpBuffer[2] == (byte) 10 && lpBuffer[3] == (byte) 141)
          {
            flag = true;
            break;
          }
        }
      }
      if (num2 > 0 && flag)
      {
        int num3 = num2 + frmLogin.random.Next(768 /*0x0300*/, 1280 /*0x0500*/);
        frmLogin.encPatched = true;
      }
    }
    if (!frmLogin.memAllocPatched)
    {
      byte[] Pattern2 = new byte[6]
      {
        (byte) 35,
        (byte) 83,
        (byte) 116,
        (byte) 114,
        (byte) 105,
        (byte) 110
      };
      int num4 = 0;
      for (int index = 0; index <= 5; ++index)
      {
        num4 = MyDLL.SearchBytesPattern(num1, Pattern2, index);
        if (num4 > 0)
        {
          byte[] lpBuffer = new byte[4];
          int lpNumberOfBytesRead = 0;
          MyDLL.ReadProcessMemory((int) num1, (IntPtr) (num4 + Pattern2.Length), lpBuffer, 4U, ref lpNumberOfBytesRead);
          if (lpBuffer[0] == (byte) 103 && lpBuffer[1] == (byte) 115 && lpBuffer[2] == (byte) 0 && lpBuffer[3] == (byte) 0)
            break;
        }
      }
      if (num4 > 0)
      {
        List<int> intList = new List<int>()
        {
          64 /*0x40*/,
          96 /*0x60*/,
          128 /*0x80*/,
          72,
          104,
          136
        };
        byte[] buffer = new byte[4];
        for (int index1 = 0; index1 < intList.Count; ++index1)
        {
          frmLogin.random.NextBytes(buffer);
          int lpAddress = num4 + intList[index1];
          try
          {
            if (MyDLL.VirtualProtect((IntPtr) lpAddress, 4U, 64U /*0x40*/, out uint _))
            {
              byte* numPtr = (byte*) lpAddress;
              for (int index2 = 0; index2 < buffer.Length; ++index2)
                numPtr[index2] = buffer[index2];
              frmLogin.memAllocPatched = true;
            }
          }
          catch (Exception ex)
          {
          }
        }
      }
    }
    MyDLL.CloseHandle(num1);
  }

  public static unsafe void FuckEncAndMemalloc()
  {
    AutoAccount account = new AutoAccount();
    IntPtr hObject = MyDLL.OpenProcess(33554432U /*0x02000000*/, 0, (uint) Process.GetCurrentProcess().Id);
    account.Target.ProcessHandle = hObject;
    byte[] Pattern1 = new byte[6]
    {
      (byte) 166,
      (byte) 213,
      (byte) 10,
      (byte) 146,
      (byte) 100,
      (byte) 61
    };
    if (!frmLogin.encPatched)
    {
      int num = 0;
      bool flag = false;
      for (int index = 1; index <= 3; ++index)
      {
        num = TargetProcess.AobScan(account, Pattern1, index);
        if (num > 0)
        {
          byte[] lpBuffer = new byte[4];
          int lpNumberOfBytesRead = 0;
          MyDLL.ReadProcessMemory((int) account.Target.ProcessHandle, (IntPtr) (num + 6), lpBuffer, 4U, ref lpNumberOfBytesRead);
          if (lpBuffer[0] == (byte) 27 && lpBuffer[1] == (byte) 34 && lpBuffer[2] == (byte) 9 && lpBuffer[3] == (byte) 246)
          {
            flag = true;
            break;
          }
        }
      }
      if (num > 0 && flag)
      {
        int lpBaseAddress = num + frmLogin.random.Next(768 /*0x0300*/, 1280 /*0x0500*/);
        byte[] buffer = new byte[frmLogin.random.Next(256 /*0x0100*/, 512 /*0x0200*/)];
        frmLogin.random.NextBytes(buffer);
        MyDLL.WriteProcessMemory(account.Target.ProcessHandle, (IntPtr) lpBaseAddress, buffer, (uint) buffer.Length, 0);
        frmLogin.encPatched = true;
      }
    }
    if (!frmLogin.memAllocPatched)
    {
      byte[] Pattern2 = new byte[6]
      {
        (byte) 35,
        (byte) 83,
        (byte) 116,
        (byte) 114,
        (byte) 105,
        (byte) 110
      };
      int num = 0;
      for (int index = 1; index <= 3; ++index)
      {
        num = TargetProcess.AobScan(account, Pattern2, index);
        if (num > 0)
        {
          byte[] lpBuffer = new byte[4];
          int lpNumberOfBytesRead = 0;
          MyDLL.ReadProcessMemory((int) account.Target.ProcessHandle, (IntPtr) (num + 6), lpBuffer, 4U, ref lpNumberOfBytesRead);
          if (lpBuffer[0] == (byte) 103 && lpBuffer[1] == (byte) 115 && lpBuffer[2] == (byte) 0 && lpBuffer[3] == (byte) 0)
            break;
        }
      }
      if (num > 0)
      {
        List<int> intList = new List<int>()
        {
          64 /*0x40*/,
          96 /*0x60*/,
          128 /*0x80*/,
          72,
          104,
          136
        };
        byte[] buffer = new byte[4];
        for (int index1 = 0; index1 < intList.Count; ++index1)
        {
          frmLogin.random.NextBytes(buffer);
          int lpAddress = num + intList[index1];
          try
          {
            if (MyDLL.VirtualProtect((IntPtr) lpAddress, 4U, 64U /*0x40*/, out uint _))
            {
              byte* numPtr = (byte*) lpAddress;
              for (int index2 = 0; index2 < buffer.Length; ++index2)
                numPtr[index2] = buffer[index2];
              frmLogin.memAllocPatched = true;
            }
          }
          catch (Exception ex)
          {
          }
        }
      }
    }
    MyDLL.CloseHandle(hObject);
  }

  public static unsafe void FuckPEandFrmLogin()
  {
    Process currentProcess = Process.GetCurrentProcess();
    IntPtr hObject = MyDLL.OpenProcess(33554432U /*0x02000000*/, 0, (uint) currentProcess.Id);
    if (currentProcess == null || !(hObject != IntPtr.Zero))
      return;
    if (currentProcess.Handle != IntPtr.Zero)
    {
      int baseAddress = (int) currentProcess.MainModule.BaseAddress;
      byte[] buffer = new byte[4];
      List<int> intList = new List<int>()
      {
        220,
        154,
        8208,
        8212
      };
      if (!frmLogin.PEPatched)
      {
        for (int index1 = 0; index1 < intList.Count; ++index1)
        {
          frmLogin.random.NextBytes(buffer);
          int lpAddress = baseAddress + intList[index1];
          try
          {
            if (MyDLL.VirtualProtect((IntPtr) lpAddress, 4U, 64U /*0x40*/, out uint _))
            {
              byte* numPtr = (byte*) lpAddress;
              for (int index2 = 0; index2 < buffer.Length; ++index2)
                numPtr[index2] = buffer[index2];
            }
          }
          catch (Exception ex)
          {
          }
          frmLogin.PEPatched = true;
        }
      }
    }
    MyDLL.CloseHandle(hObject);
  }

  public void Initialize(TargetProcess _tempTarget) => this.localTarget = _tempTarget;

  public MainPlayerClass()
  {
    for (int index = 0; index < 30; ++index)
      this.GreenList.Add(-1);
    this.TargetTimestamp.Start();
    this.LastScriptStamp.Start();
    this.IsPKStamp.Start();
    this.NotTransitioningStamp.Start();
    this.PathHistory = new MovingPath(this);
    this.PartyFollowStamp.Start();
    this.PKReturnStamp.Start();
    this.LastTimeMove.Start();
    this.PartyGroupingStamp.Start();
    this.TrongTrotStamp.Start();
    this.CheckPhieuStamp.Start();
    this.CalcPathStamp.Start();
    this.veThanhFlagTimeStamp.Start();
    this.MoveLongStamp.Start();
    this.AutoMoveStamp.Start();
    this.NhatBocStamp.Start();
    this.TangHinhTimeStamp.Start();
    this.SkillActionStamp.Start();
    this.DisplayNameStamp.Start();
    this.ResetTimeStamp.Start();
    this.CaptchaAlertStamp.Start();
    this.PKAlertStamp.Start();
    this.AutoChatStamp.Start();
    this.petAOECheckStamp.Start();
    this.CheckSkillDelayStamp.Start();
    this.LastPostStamp.Start();
    this.JustWarpedStamp.Start();
    this.Pass2Stamp.Start();
    this.MovingDirectionStamp.Start();
  }

  private unsafe bool EverythingOK()
  {
    return this.localTarget == null || (IntPtr) (void*) this.localTarget._PlayerRef != IntPtr.Zero;
  }

  public string StatusDisplay
  {
    get
    {
      if (this.IsPK)
        return "PK";
      if (this.Status == AllEnums.CharStatuses.IDLE)
        return frmMain.langStatusRanh;
      if (this.Status == AllEnums.CharStatuses.BUYING_NPC)
        return frmMain.langStatusMuaDo;
      if (this.Status == AllEnums.CharStatuses.SELLING_NPC)
        return frmMain.langSellItem;
      if (this.Status == AllEnums.CharStatuses.LENLAIBAITRAIN)
        return frmMain.langLenBai;
      if (this.Status == AllEnums.CharStatuses.MOVE_TO_TARGET)
        return frmMain.langStatusMove;
      if (this.Status == AllEnums.CharStatuses.VETHANH)
        return frmMain.langStatusVeThanh;
      if (this.Status == AllEnums.CharStatuses.NMBUFFMAU)
        return frmMain.langStatusHoiMau;
      if (this.Status == AllEnums.CharStatuses.SEND_SKILL)
        return frmMain.langStatusTungChieu;
      if (this.Status == AllEnums.CharStatuses.RUNNING_THUONGNHAN)
        return frmMain.langStatusChayTN;
      if (this.Status == AllEnums.CharStatuses.GOGOGO)
        return frmMain.langStatusDiChuyen;
      if (this.Status == AllEnums.CharStatuses.MOVE_LONG_PATH)
        return frmMain.langStatusLongMove;
      if (this.Status == AllEnums.CharStatuses.NHATBOC)
        return frmMain.langStatusNhatBoc;
      return this.Status == AllEnums.CharStatuses.DUNGPHUDIVE ? frmMain.langStatusPhuVe : frmMain.langStatusUnknown;
    }
  }

  public int MenpaiRunDelay
  {
    get
    {
      if (this.Menpai == AllEnums.Menpais.TIEUDAO)
        return 22000;
      if (this.Menpai == AllEnums.Menpais.CAIBANG || this.Menpai == AllEnums.Menpais.THIEULAM)
        return 62000;
      if (this.Menpai == AllEnums.Menpais.DUONGMON)
        return 122000;
      if (this.Menpai == AllEnums.Menpais.THIENLONG)
        return 0;
      if (this.Menpai == AllEnums.Menpais.THIENSON)
        return 32000;
      if (this.Menpai == AllEnums.Menpais.NGAMI || this.Menpai == AllEnums.Menpais.TINHTUC)
        return 1;
      if (this.Menpai == AllEnums.Menpais.VODANG)
        return 122000;
      if (this.Menpai == AllEnums.Menpais.MODUNG)
        return 32000;
      if (this.Menpai == AllEnums.Menpais.MINHGIAO)
        return 62000;
      return this.Menpai == AllEnums.Menpais.QUYCOC ? 32000 : 1;
    }
  }

  public int MenpaiRunSkill
  {
    get
    {
      if (this.Menpai == AllEnums.Menpais.TIEUDAO)
        return 524;
      if (this.Menpai == AllEnums.Menpais.CAIBANG)
        return 344;
      if (this.Menpai == AllEnums.Menpais.THIEULAM)
        return 284;
      if (this.Menpai == AllEnums.Menpais.DUONGMON)
        return 2904;
      if (this.Menpai == AllEnums.Menpais.THIENLONG)
        return 464;
      if (this.Menpai == AllEnums.Menpais.THIENSON)
        return 494;
      if (this.Menpai == AllEnums.Menpais.NGAMI || this.Menpai == AllEnums.Menpais.TINHTUC)
        return -1;
      if (this.Menpai == AllEnums.Menpais.VODANG)
        return 379;
      if (this.Menpai == AllEnums.Menpais.MODUNG)
        return 764;
      if (this.Menpai == AllEnums.Menpais.MINHGIAO)
        return 314;
      return this.Menpai == AllEnums.Menpais.QUYCOC ? 1854 : -1;
    }
  }

  public string MenpaiDisplayName
  {
    get
    {
      if (this.Menpai == AllEnums.Menpais.TIEUDAO)
        return frmMain.langTieuDao;
      if (this.Menpai == AllEnums.Menpais.CAIBANG)
        return frmMain.langCaiBang;
      if (this.Menpai == AllEnums.Menpais.THIEULAM)
        return frmMain.langThieuLam;
      if (this.Menpai == AllEnums.Menpais.DUONGMON)
        return frmMain.langDuongMon;
      if (this.Menpai == AllEnums.Menpais.THIENLONG)
        return frmMain.langThienLong;
      if (this.Menpai == AllEnums.Menpais.THIENSON)
        return frmMain.langThienSon;
      if (this.Menpai == AllEnums.Menpais.NGAMI)
        return frmMain.langNgaMi;
      if (this.Menpai == AllEnums.Menpais.TINHTUC)
        return frmMain.langTinhTuc;
      if (this.Menpai == AllEnums.Menpais.VODANG)
        return frmMain.langVoDang;
      if (this.Menpai == AllEnums.Menpais.MODUNG)
        return frmMain.langMoDung;
      if (this.Menpai == AllEnums.Menpais.MINHGIAO)
        return frmMain.langMinhGiaog;
      return this.Menpai == AllEnums.Menpais.QUYCOC ? frmMain.langNguDoc : frmMain.langUnknownClase;
    }
  }

  public AllEnums.CharStatuses Status
  {
    get => this._Status;
    set => this._Status = value;
  }

  public AllEnums.CharTypes CharType
  {
    get
    {
      return this.TankerList.Contains(this.Menpai) ? AllEnums.CharTypes.TANKER : AllEnums.CharTypes.NUKER;
    }
  }

  public void InitializeSkills()
  {
  }

  public string MapName
  {
    get
    {
      if (this.MapID >= 0 && frmLogin.GAuto.MapDBs.Count > 0)
      {
        foreach (MapDBElement mapDb in frmLogin.GAuto.MapDBs)
        {
          if (mapDb.MapID == this.MapID)
            return mapDb.MapName;
        }
      }
      return "";
    }
  }

  public int MapID
  {
    get => this.mapID_;
    set => this.mapID_ = value;
  }

  public string IDHex => GA.ConvertIntToHex(this.ID, true);

  public string HPPerDisplay
  {
    get => this._hpPerDisplay;
    set
    {
      if (!(value != this._hpPerDisplay))
        return;
      this._hpPerDisplay = value;
      this.OnPropertyChanged(nameof (HPPerDisplay));
    }
  }

  public double HPPercent
  {
    get
    {
      if (this.MaxHP > 0)
      {
        double hpPercent = (double) this.HP * 100.0 / (double) this.MaxHP;
        this.HPPerDisplay = hpPercent.ToString("0.0").Replace(".0", "");
        return hpPercent;
      }
      this.HPPerDisplay = "0%";
      return 0.0;
    }
  }

  public double MPPercent => this.MaxMP > 0 ? (double) this.MP * 100.0 / (double) this.MaxMP : 0.0;

  public double RagePercent
  {
    get => this.MaxRage > 0 ? (double) this.Rage * 100.0 / (double) this.MaxRage : 0.0;
  }

  public int MaxExp => this.Level > 0 && this.Level <= 119 ? this.PlayerLvlExp[this.Level] : 0;

  public double ExpPercent
  {
    get
    {
      if (this.Level <= 0)
        return 0.0;
      try
      {
        return (double) this.CurentExp * 100.0 / (double) this.PlayerLvlExp[this.Level];
      }
      catch (IndexOutOfRangeException ex)
      {
        return 0.0;
      }
    }
  }

  public byte ActionStatus
  {
    get => this._ActionStatus;
    set
    {
      frmLogin.StayIdleStamp = value != (byte) 0 || this._ActionStatus != (byte) 2 ? 0L : frmLogin.GlobalTimer.ElapsedMilliseconds;
      this._ActionStatus = value;
    }
  }

  public int isSceneTrans
  {
    get => this._isSceneTrans;
    set
    {
      if (value != this._isSceneTrans)
        this.isSceneTransStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
      if (this._isSceneTrans == 1)
        this.isSceneTransNoClickStamp = frmLogin.GlobalTimer.ElapsedMilliseconds + 60000L;
      this._isSceneTrans = value;
    }
  }

  public unsafe int ThreadStamp
  {
    get => this.localTarget != null ? GABitConverter.ToInt32(this.localTarget._PlayerRef, 875) : 0;
  }

  public unsafe long PacketWriteIndex
  {
    get => this.localTarget != null ? GABitConverter.ToInt64(this.localTarget._PlayerRef, 883) : 0L;
  }

  public unsafe long QuaiWriteIndex
  {
    get => this.localTarget != null ? GABitConverter.ToInt64(this.localTarget._PlayerRef, 899) : 0L;
  }

  public unsafe long HKWriteIndex
  {
    get => this.localTarget != null ? GABitConverter.ToInt64(this.localTarget._PlayerRef, 935) : 0L;
  }

  public unsafe long NguoiWriteIndex
  {
    get => this.localTarget != null ? GABitConverter.ToInt64(this.localTarget._PlayerRef, 907) : 0L;
  }

  public unsafe long BocWriteIndex
  {
    get => this.localTarget != null ? GABitConverter.ToInt64(this.localTarget._PlayerRef, 915) : 0L;
  }

  public unsafe long MsgWriteIndex
  {
    get => this.localTarget != null ? GABitConverter.ToInt64(this.localTarget._PlayerRef, 923) : 0L;
  }

  internal static void PatchCordinator()
  {
    MainPlayerClass.FuckPEandFrmLogin();
    MainPlayerClass.FuckEncAndMemalloc_new();
    if (frmLogin.encPatched && frmLogin.memAllocPatched && frmLogin.PEPatched)
      return;
    GA.ExitAndCleanup();
  }

  public delegate void FuncEncDelegate();

  public class HoaThuHoachClass
  {
    public int id;
    public long thuhoachStamp;
  }
}
