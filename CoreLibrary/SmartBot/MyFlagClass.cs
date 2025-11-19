// Decompiled with JetBrains decompiler
// Type: SmartBot.MyFlagClass
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace SmartBot;

public class MyFlagClass
{
  public AutoAccount refAccount;
  public bool ThisTestFlag;
  public long TestTimeStamp;
  public long SpamCount;
  public int hongQcounter;
  public int dietgonCounter;
  public int truhaiCounter;
  public int YTOCounter;
  public int truhaiFoundBoss;
  public int CanKhonHoCounter;
  public int phubanActionCounter;
  public int removePTFollowCounter;
  public object CaptchaLock = new object();
  public int fullQCounter;
  public long fullQStamp;
  public bool xonglinhQ1;
  public bool sotquaiQ1;
  public bool Q1UuTien;
  public bool Q2UuTien;
  public int dosomethingCounter;
  public int dosomethingFlag;
  public int dosomethingHoisinhFlag;
  public long dosomethingStamp;
  public long thuhoachHoaStamp;
  public long xongQstamp;
  public long CanKhonHoStamp;
  public long nodelayAction;
  public long noBuffStamp;
  public long nhanQstamp;
  public long noAttackStamp;
  public long noPlaySkillStamp;
  public long removePartyFollowStamp;
  public long useItemTriggerStamp;
  public long inYTOStamp;
  public long VuotQuaPhamViStamp;
  public int VuotQuaPhamViCount;
  public long cotrangdenStamp;
  public long tempStamp;
  public long tempStamp2;
  public bool nearMe;
  public int phubanFlag;
  public bool tuyenChienFlag;
  public bool donDameFlag;
  public List<string> NamePartyArray = new List<string>();
  public byte[] CaptchaNum = new byte[577];
  public long CaptchaNumStamp;
  public bool CaptchaNumRefresh;
  public AllEnums.FightingModes SaveFightMode = AllEnums.FightingModes.DANHPETONLY;
  public int saveDiameter;
  public bool saveDanhTheoKey;
  public bool ChatRecorded;
  public long MDPPlayDCTD;
  public long InGameStamp;
  private bool _isInGame;
  public int InGameStatus;
  public int tempInt = -1;
  public long InGameFinishLoadingStamp;
  public bool NeedAutoLogin = true;
  public bool ServerDisconnected;
  public int CEHandle1;
  public int CEHandle2;
  public int LUAHandle;
  public long GetDLLStamp;
  public bool EndAI;
  public bool EndBG;
  public long HookStamp;
  public bool HookOK;
  public long TryHookStamp;
  public long ResetStamp;
  public bool DatLichFlag;
  public bool HotkeyFlag;
  public bool JustNewAccount;
  public long LoadSettingStamp;
  public bool ReadMenPai;
  public int ReadSkillDBCount;
  public long ReadSkillDBStamp;
  public int Q2_ppCounter;
  public bool OKToInject;
  public int counter;
  public long ClickYesStamp;
  public int tempLevel;
  public long NoMoveStamp;
  public long moveEXStamp;
  public long talkNPCStamp;
  public int BHDcounter;
  public int SavedTargetID = -1;
  public int SkillNguTongID = -1;
  public long SkillNguTongReadmemChangeStamp;
  public long SkillNguTongAttackStamp;
  public long dungphuStamp;
  public bool waitMsgBox;
  public string PlayerPKMe;
  public long WriteUserLogStamp;
  public long PMStamp;
  public long IgnoredQuaiID_Reset_Stamp;
  public int savedMucTieuID;
  public int savedMucTieuID_Count;
  public int savedBocID;
  public int savedBocID_Count;
  public int savedBocDangPickID;
  public int savedItemTrongBocID;
  public int savedItemTrongBocID_Count;
  public bool IsBlockedChat;
  public long BlockChatStamp;
  public int BlockChatMinutes;
  public long TLCStamp;
  public bool HuyItemNhiemVuFlag;
  public long Slow3000ReadStamp;
  public long Slow1000ReadStamp;
  public long Slow500ReadStamp;
  public long Slow1MinReadStamp;
  public bool Slow3000Read;
  public bool Slow1000Read;
  public bool Slow500Read;
  public bool Slow1MinRead;
  public int Random_ResetTime;
  public bool DLLReady;
  public object DLLReadyLock = new object();
  public long ngamyMoveStamp;
  public long ngamyBuffXaStamp;
  public long isDisconnectBoxShowStamp;
  public int PMPCounter;
  public int menuPMP = 402276;
  public long YTOxongStamp;
  public int BocID_Saved;
  public long seenTangThoCongStamp;
  public int chedoCheckItemMode;
  public int chedoItemNeedCount = 10;
  public int chedoTalkNPCMode;
  public long checkNhatBocStamp;
  public float posX_Saved;
  public float posY_Saved;
  public int MapID_Saved;
  public int BHDCheckQuestCounter;
  public List<long> CustomSleepStamp = new List<long>();
  public bool TrongHoaFirstMove;
  public List<MyFlagClass.ToaDoTrongHoaClass> ToaDoTrongHoaList = new List<MyFlagClass.ToaDoTrongHoaClass>();
  public int TrongHoaListMax = 100;
  public int actionAI;
  public int posX_TrongHoa;
  public int posY_TrongHoa;
  public int huyQcounter;
  public int DinhViPhuWarningCounter;
  public long RunStamp;
  public int AIAction;
  public object AIActionLock = new object();
  public long RunQuestStamp;
  public object MyFlagLock = new object();
  public int QuestType;
  public long CalcTimeOutStamp;
  public long NoTrongHoaBonHoaStamp;
  public object CustomSleepLock = new object();
  public int PetXuatChienIndex = -1;
  public int PetCongSinhIndex = -1;
  public int PetHuyetTeIndex = -1;
  public long ReadQuanDoanStamp;
  public List<MyFlagClass.SkillDelayReadClass> SkillDelayReadStamp = new List<MyFlagClass.SkillDelayReadClass>();
  public int LoginAction;
  public long inPKTinhKiemStamp;
  public long StartReconnectStamp;

  public MyFlagClass(AutoAccount _refAcc) => this.refAccount = _refAcc;

  public bool IsInGame
  {
    get => this._isInGame;
    set
    {
      if (value == this._isInGame)
        return;
      this._isInGame = value;
      if (this.refAccount == null || this.refAccount.AutoProfile == null)
        return;
      this.refAccount.AutoProfile.GameStarted = value;
      if (!value || this.refAccount.AutoProfile.imgCaptcha == null)
        return;
      this.refAccount.AutoProfile.imgCaptcha = (Image) null;
    }
  }

  public class ToaDoTrongHoaClass
  {
    public int posX;
    public int posY;
    public long noPutStamp;
  }

  public class SkillDelayReadClass
  {
    public long stamp;
    public int delay = 3000;
  }
}
