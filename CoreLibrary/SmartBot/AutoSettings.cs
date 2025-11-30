// Decompiled with JetBrains decompiler
// Type: SmartBot.AutoSettings
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System;
using System.Collections.Generic;
using System.Text;

#nullable disable
namespace SmartBot;

[Serializable]
public class AutoSettings : AllEnums
{
  private GAutoList<SkillPlayItem> _SkillPlayerList = new GAutoList<SkillPlayItem>();
  private GAutoList<SkillPlayItem> _SkillBuffList = new GAutoList<SkillPlayItem>();
  private GAutoList<SkillPlayItem> _SkillPKList = new GAutoList<SkillPlayItem>();
  private GAutoList<ItemToUse> _ListItemToUse = new GAutoList<ItemToUse>();
  private GAutoList<ItemToBuy> _ListItemToBuy = new GAutoList<ItemToBuy>();
  private AllEnums.NhatItemModes _NhatItemMode;
  private GAutoList<GEventClass> _ListScheduler = new GAutoList<GEventClass>();
  private bool _AllInformationLoaded;
  private AllEnums.AfterDeathSettings _AfterDeathSetting = AllEnums.AfterDeathSettings.BackToTrainSpot;
  private GAutoList<string> _ListItemNhatIgnore = frmLogin.__ListItemNhatIgnore;
  public AllEnums.AIModes AIMode = AllEnums.AIModes.DANHTUDO;
  private int _NgaMiSkillID;
  private int _numNgaMyBuff = 80 /*0x50*/;
  private bool _usePhatQuangPhoChieu;
  private bool _cboxBuffPet;
  private int _numBuffPet = 50;
  private AllEnums.NgaMyBuffModes _nmBuffMode = AllEnums.NgaMyBuffModes.BuffParty;
  public bool cboxNMBuffParty = true;
  private int _numBuffPartyXH = 70;
  private bool _cboxTuNhatVatPham = true;
  private bool _cboxCongSinh;
  private int _numPetChoi = 85;
  private int _numPetHPPercent = 80 /*0x50*/;
  private int _cboTKCMaps = 24;
  private int _numMPPercent = 65;
  private int _numHPPercent = 60;
  public int MultiAccPatch = 4221135;
  public bool AIWhileLoop = true;
  private bool _cboxTuUpLevel;
  private int _numUpLevel = 30;
  private int _numPhatQuangDelay = 5;
  public int numGiuDoSao = 4;
  public int numGiuDoDong = 10;
  private bool _cboxVutDoKhiFull;
  private bool _cboxVeThanhKhiFull = true;
  private bool _cboxTuMuaBan = true;
  private bool _cboxVeThanhHetThucAn;
  private bool _cboxVeThanhHetBNM;
  private int _numVeThanhHP = 10;
  private int _numVeThanhMP = 5;
  private int _HealMapID;
  private int _cboPetFoodType = 2;
  private bool _cboxVeThanhHetMau;
  private bool _cboxHelpChat = true;
  public bool cboxAutoChat;
  private int _cboKenhChat = 2;
  private int _numAutoChat = 185;
  private string _AutoChatContent = "";
  private int _tboxIDBang = -1;
  private int _tBoxIDFriend = -1;
  private bool _cboxTNFullAuto = true;
  public AllEnums.TraderModes TraderMode = AllEnums.TraderModes.IDLE;
  public AllEnums.CharStatuses TraderStatus;
  private int _numTNRounds = 20;
  private bool _cboxTNAlert = true;
  private bool _cboxTNAlertPK = true;
  private bool _cboItemTuHuy = true;
  private bool _cboTNTuNhanPhieu = true;
  public bool cboxFixKetThanh;
  private bool _cboxFullThungVE;
  private int _numFullThung = 1;
  private int _numBanKinhNhat = 30;
  private bool _cboxFullStopNhat;
  private string _TNLastDirection = "";
  public int numPetAOE = 20;
  public int PetAOESkillID;
  private List<PetSkillPlay> _PetSkillPlays = new List<PetSkillPlay>();
  public int PetAOEDBID;
  private bool _cboxPetAOE;
  public string AOEPetName = "";
  public string PetAOESkillName;
  private int _TKCLeftX = 26;
  private int _TKCLeftY = 63 /*0x3F*/;
  private int _TKCRightX = 99;
  private int _TKCRightY = 57;
  private double _CenterX;
  private double _CenterY;
  private bool _cboxHuyetTe;
  private double _Diameter3 = 30.0;
  private double _MoveRange = 7.0;
  private int _MapID = -1;
  public float SavedPosX;
  public float SavedPosY;
  public int SavedMapID = -1;
  private int _CharDBID;
  private bool _cboxCaptchaReset = true;
  public bool cboxTangHinh = true;
  private bool _cboxTheoSau;
  private bool _cboxTurboMode = true;
  public int numGomQuai = 99;
  private int _numGroupID = 1;
  private AllEnums.FightingModes _FightMode;
  private bool _cboxDanhTheoKey;
  private bool _cboxTNChayNhanh = true;
  public bool cboxTuTheoDoi = true;
  private int _PartySavedPosX;
  private int _PartySavedPosY;
  private int _PartySavedMapID = -1;
  private GAutoList<string> _PTBlacklist = new GAutoList<string>();
  private GAutoList<string> _QuaiNoAttackList = new GAutoList<string>();
  private GAutoList<string> _AutoPartyList = new GAutoList<string>();
  private bool _cboxTuVaoPT;
  private bool _cboxCanX2;
  public bool cboxNMBuffSelf = true;
  private bool _cboxNMBuffBang;
  private int _numTheoSau = 7;
  private bool _cboxKhongResetGio;
  private bool _cboxPKTuVe = true;
  public bool cboxPKGiupDoAuto;
  public bool cboxPhuDaiLy = true;
  public bool cboxPhuMonPhai = true;
  public bool cboxDinhViPhu = true;
  private bool _cboxThoLinhChau = true;
  private bool _cboxChoHoiSinh;
  private int _numChoHoiSinh = 30;
  private bool _cboxNMHoiSinhPT = true;
  private bool _cboTTThuHoach = true;
  private int _txtTTNPC1_ID = -1;
  private int _txtTTNPC1_X;
  private int _txtTTNPC1_Y;
  private int _txtTTNPC2_ID = -1;
  private int _txtTTNPC2_X;
  private int _txtTTNPC2_Y;
  private long _TrongTrotNPCTime1;
  private long _TrongTrotNPCTime2;
  private bool _cboxDanhHoTro;
  private string _TrongTrotTime = "";
  private int _TrongTrotMapID = -1;
  private int _TTLoaiThuHoach = 1;
  private string _TTCaySeTrong = "";
  private bool _cboxKhaiKhoang = true;
  private bool _cboxHaiDuoc = true;
  private int _KhoangDuocMapID = -1;
  public bool cboxATAB;
  private int _cboxDuaHauCity = 2;
  private bool _cboDHAlertTuu = true;
  private bool _cboDHAutoNV = true;
  private bool _cboDHAutoPick;
  private bool _cboDHFromCity = true;
  private int _cboxDuaHauMaps = 24;
  private int _txtDHBangID = -1;
  public long txtDHBangIDStamp;
  public long txtDHBangIDStampFalse;
  public long nhathopDuaHauStamp;
  private bool _cboxNMPKBuff = true;
  private int _cboATMaps = 4;
  private int _TNBuyingMode;
  private bool _cboxTNMinhGiaHigher = true;
  private bool _cboxTNFriendGiaHigher = true;
  private int _txtTNMinhGiaHigher = 6500;
  private int _txtTNFriendGia = 6500;
  private int _cboTNMinhItem = 20400069;
  private int _cboTNFriendItem = 20400069;
  private bool _cboxCanX4;
  public bool cboxGomQuaiKS = true;
  private bool _cboxNMBuffQuanDoan;
  private bool _cboxBuffQuanDoan;
  private bool _cboxNMBuffList;
  private bool _cboxBuffHoTroOnOff = true;
  public bool cboxTNRunOnly;
  private bool _cboxSkillOnOff = true;
  private int _PTTheoSauMode;
  private string _txtTheoSauName = "";
  private int _cboTrainExpMode;
  private bool _cboxPhuVeThanh;
  public bool cboxNoTheoSau;
  private bool _cboxPassCap2;
  public bool cboxGomXongVeTam = true;
  private bool _cboxTuClickYes;
  private string _txtPassCap2 = "";
  private bool _cboxPKThoatGame;
  private int _numPKThoatGame = 30;
  private bool _cboxTANhanNV = true;
  private bool _cboxTAHoiPhuc = true;
  private bool _cboxTADungPhu = true;
  private bool _cboxPhuQuaLD;
  private bool _cboxPhuQuaDaiLy;
  private bool _cboxLKTuNhanNV = true;
  private int _txtKNB50 = 30;
  private int _txtKNB200 = 120;
  private int _txtKNB500 = 220;
  private bool _cboxXayDung = true;
  public bool cboxLuyenKimCham;
  private bool _cboxXayDungPhu = true;
  private bool _cboxPTChoVao;
  private bool _cboxPTLevel;
  private int _numPTLevel = 1;
  private bool _cboxXDHoiMau = true;
  private bool _cboxTBBPhiThuy = true;
  public int cboABMaps = -1;
  public int cboABMenuID;
  private bool _cboxNMBuff = true;
  public bool cboxDebugLog;
  private bool _cboxXDXaPhu = true;
  private bool _cboxTAXaPhu = true;
  private int _cboTuDuongCon = 1;
  public string AcBaPhai = frmMain.langABPhai;
  public bool cboxABChayTim = true;
  private bool _cboxLTNhanVN = true;
  public long AcBaPhaiStamp;
  private bool _cboxDanhTheoAi;
  private string _txtDanhTheoAi = "";
  private int _cboTuBaoBon;
  private bool _cboxDanhQuai = true;
  private bool _cboxBanKinh;
  private bool _cboxAOE = true;
  private bool _cboxTBBchaynhanh;
  private bool _cboxNMUutienself = true;
  public bool checkDanhHieu;
  private bool _cboxGiuVuKhi;
  private bool _cboxDuY = true;
  private int _numBHDMax = 100;
  private int _numBHDBanKinh = 30;
  private bool _cboxBTDPhuVe = true;
  private bool _cboxTKCNhanh = true;
  private string _PathPointSection = "Chưa có";
  private bool _cboxBTDXaPhu = true;
  private bool _cboxPetList;
  private bool _cboxNhatHop;
  private bool _cboxNhanHop;
  private int _cboBaoRuongMap = -1;
  private bool _cboxBRXaPhu = true;
  private bool _cboxBRTLC;
  private bool _cboxDongMon = true;
  private string _cboItemCheDo = "Nón";
  private string _cboCheDoDTD = "Cấp 10";
  private int _cboCheDoMap;
  private string _cboCheDoXong = frmMain.langSitIdle;
  private int _numCheDoAmount = 50;
  private bool _cboxHuyCheDo = true;
  private bool _cboxBanChoNPC = true;
  private bool _cboxHuyNLThua;
  private int _numCheDoSao = 8;
  private int _numCheDoDong = 7;
  private int _numCheDoChiSo;
  private int _numCheDoSLmua = 35;
  private bool _cboxGiu2DongTM;
  private string _cboQ1Cau = frmMain.langQ1Bridge;
  private bool _cboxTuHuyNV;
  private bool _cboxHongQPT;
  private bool _cboxDiTheoPP;
  private int _numQ12ChoPT = 3;
  public bool cboxChatSavedMsg;
  private string _cboQ12Xong = frmMain.langSitIdle;
  private bool _cboxChoParty = true;
  private string _cboLocDuoc = frmMain.langNotFoundStr;
  private bool _cboxNMUutienboc = true;
  public bool _cboxPKAnyOne;
  public bool _cboxPKNgaMyFirst = true;
  public bool _cboxPKThieuLamLast = true;
  public bool _cboxPKPlayerList;
  public bool _cboxPKBangList;
  public bool cboxPKEnable;
  private GAutoList<string> _PKPlayerList = new GAutoList<string>();
  private GAutoList<string> _PKBlackList = new GAutoList<string>();
  private GAutoList<int> _PKBangList = new GAutoList<int>();
  private int _numGomMode = 1;
  private bool _cboxOnlyPet;
  private bool _ptYeu;
  private bool _cboxBlacklist = true;
  private bool _ChatAlert = true;
  public bool DungNgua = true;
  public bool cboxVIPPM;
  private int _numBuffPhamVi = 25;
  private bool _cboxHuyNVDanhQuai;
  private bool _cboxHuyNVNhatDo;
  private bool _cboxThuHoachHoaChinhMinh;
  private bool _cboxBHDThoatKhiXong = true;
  private bool _cboxNhatTuyetDungIm;
  private bool _FixLoiCuongChe;
  private bool _cboxKyCuocNhanh;
  private bool _cboxLLTBNhanh;
  private bool _menuTestGame;
  private bool _cboxTiepTucNhiemVuNgay = true;

  public GAutoList<SkillPlayItem> SkillPlayList
  {
    get => this._SkillPlayerList;
    set => this._SkillPlayerList = value;
  }

  public GAutoList<SkillPlayItem> SkillBuffList
  {
    get => this._SkillBuffList;
    set => this._SkillBuffList = value;
  }

  public GAutoList<SkillPlayItem> SkillPKList
  {
    get => this._SkillPKList;
    set => this._SkillPKList = value;
  }

  public GAutoList<ItemToUse> ListItemToUse
  {
    get => this._ListItemToUse;
    set => this._ListItemToUse = value;
  }

  public GAutoList<ItemToBuy> ListItemToBuy
  {
    get => this._ListItemToBuy;
    set => this._ListItemToBuy = value;
  }

  public AllEnums.NhatItemModes NhatItemMode
  {
    get => this._NhatItemMode;
    set
    {
      if (this.AllInformationLoaded && this._NhatItemMode != value)
        this.SaveSingleSetting(nameof (NhatItemMode), value.ToString());
      this._NhatItemMode = value;
    }
  }

  public GAutoList<GEventClass> ListScheduler
  {
    get => this._ListScheduler;
    set => this._ListScheduler = value;
  }

  public bool AllInformationLoaded
  {
    get => this._AllInformationLoaded;
    set => this._AllInformationLoaded = value;
  }

  public AllEnums.AfterDeathSettings AfterDeathSetting
  {
    get => this._AfterDeathSetting;
    set
    {
      if (this.AllInformationLoaded && this._AfterDeathSetting != value)
        this.SaveSingleSetting(nameof (AfterDeathSetting), value.ToString());
      this._AfterDeathSetting = value;
    }
  }

  public GAutoList<string> ListItemNhatIgnore
  {
    get => this._ListItemNhatIgnore;
    set => this._ListItemNhatIgnore = value;
  }

  public int NgaMiSkillBuffID
  {
    get => this._NgaMiSkillID;
    set
    {
      if (value == 424 && this.AllInformationLoaded && this._NgaMiSkillID != value)
        this.SaveSingleSetting(nameof (NgaMiSkillBuffID), value.ToString());
      this._NgaMiSkillID = value;
    }
  }

  public int numNgaMyBuff
  {
    get => this._numNgaMyBuff;
    set
    {
      if (this.AllInformationLoaded && this._numNgaMyBuff != value)
        this.SaveSingleSetting(nameof (numNgaMyBuff), value.ToString());
      this._numNgaMyBuff = value;
    }
  }

  public bool usePhatQuangPhoChieu
  {
    get => this._usePhatQuangPhoChieu;
    set
    {
      if (this.AllInformationLoaded && this._usePhatQuangPhoChieu != value)
        this.SaveSingleSetting(nameof (usePhatQuangPhoChieu), value.ToString());
      this._usePhatQuangPhoChieu = value;
    }
  }

  public bool cboxBuffPet
  {
    get => this._cboxBuffPet;
    set
    {
      if (this.AllInformationLoaded && this._cboxBuffPet != value)
        this.SaveSingleSetting(nameof (cboxBuffPet), value.ToString());
      this._cboxBuffPet = value;
    }
  }

  public int numBuffPet
  {
    get => this._numBuffPet;
    set
    {
      if (this.AllInformationLoaded && this._numBuffPet != value)
        this.SaveSingleSetting(nameof (numBuffPet), value.ToString());
      this._numBuffPet = value;
    }
  }

  public AllEnums.NgaMyBuffModes nmBuffMode
  {
    get => this._nmBuffMode;
    set
    {
      if (this.AllInformationLoaded && this._nmBuffMode != value)
        this.SaveSingleSetting(nameof (nmBuffMode), value.ToString());
      this._nmBuffMode = value;
    }
  }

  public int numBuffPartyXH
  {
    get => this._numBuffPartyXH;
    set
    {
      if (this.AllInformationLoaded && this._numBuffPartyXH != value)
        this.SaveSingleSetting(nameof (numBuffPartyXH), value.ToString());
      this._numBuffPartyXH = value;
    }
  }

  public bool cboxTuNhatVatPham
  {
    get => this._cboxTuNhatVatPham;
    set
    {
      if (this.AllInformationLoaded && this._cboxTuNhatVatPham != value)
        this.SaveSingleSetting(nameof (cboxTuNhatVatPham), value.ToString());
      this._cboxTuNhatVatPham = value;
    }
  }

  public bool cboxCongSinh
  {
    get => this._cboxCongSinh;
    set
    {
      if (this.AllInformationLoaded && this._cboxCongSinh != value)
        this.SaveSingleSetting(nameof (cboxCongSinh), value.ToString());
      this._cboxCongSinh = value;
    }
  }

  public int numPetChoi
  {
    get => this._numPetChoi;
    set
    {
      if (this.AllInformationLoaded && this._numPetChoi != value)
        this.SaveSingleSetting(nameof (numPetChoi), value.ToString());
      this._numPetChoi = value;
    }
  }

  public int numPetHPPercent
  {
    get => this._numPetHPPercent;
    set
    {
      if (this.AllInformationLoaded && this._numPetHPPercent != value)
        this.SaveSingleSetting(nameof (numPetHPPercent), value.ToString());
      this._numPetHPPercent = value;
    }
  }

  public int cboTKCMaps
  {
    get => this._cboTKCMaps;
    set
    {
      if (this.AllInformationLoaded && this._cboTKCMaps != value)
        this.SaveSingleSetting(nameof (cboTKCMaps), value.ToString());
      this._cboTKCMaps = value;
    }
  }

  public int numMPPercent
  {
    get => this._numMPPercent;
    set
    {
      if (this.AllInformationLoaded && this._numMPPercent != value)
        this.SaveSingleSetting(nameof (numMPPercent), value.ToString());
      this._numMPPercent = value;
    }
  }

  public int numHPPercent
  {
    get => this._numHPPercent;
    set
    {
      if (this.AllInformationLoaded && this._numHPPercent != value)
        this.SaveSingleSetting(nameof (numHPPercent), value.ToString());
      this._numHPPercent = value;
    }
  }

  public bool cboxTuUpLevel
  {
    get => this._cboxTuUpLevel;
    set
    {
      if (this.AllInformationLoaded && this._cboxTuUpLevel != value)
        this.SaveSingleSetting(nameof (cboxTuUpLevel), value.ToString());
      this._cboxTuUpLevel = value;
    }
  }

  public int numUpLevel
  {
    get => this._numUpLevel;
    set
    {
      if (this.AllInformationLoaded && this._numUpLevel != value)
        this.SaveSingleSetting(nameof (numUpLevel), value.ToString());
      this._numUpLevel = value;
    }
  }

  public int numPhatQuangDelay
  {
    get => this._numPhatQuangDelay;
    set
    {
      if (this.AllInformationLoaded && this._numPhatQuangDelay != value)
        this.SaveSingleSetting(nameof (numPhatQuangDelay), value.ToString());
      this._numPhatQuangDelay = value;
    }
  }

  public bool cboxVutDoKhiFull
  {
    get => this._cboxVutDoKhiFull;
    set
    {
      if (this.AllInformationLoaded && this._cboxVutDoKhiFull != value)
        this.SaveSingleSetting(nameof (cboxVutDoKhiFull), value.ToString());
      this._cboxVutDoKhiFull = value;
    }
  }

  public bool cboxVeThanhKhiFull
  {
    get => this._cboxVeThanhKhiFull;
    set
    {
      if (this.AllInformationLoaded && this._cboxVeThanhKhiFull != value)
        this.SaveSingleSetting(nameof (cboxVeThanhKhiFull), value.ToString());
      this._cboxVeThanhKhiFull = value;
    }
  }

  public bool cboxTuMuaBan
  {
    get => this._cboxTuMuaBan;
    set
    {
      if (this.AllInformationLoaded && this._cboxTuMuaBan != value)
        this.SaveSingleSetting(nameof (cboxTuMuaBan), value.ToString());
      this._cboxTuMuaBan = value;
    }
  }

  public bool cboxVeThanhHetThucAn
  {
    get => this._cboxVeThanhHetThucAn;
    set
    {
      if (this.AllInformationLoaded && this._cboxVeThanhHetThucAn != value)
        this.SaveSingleSetting(nameof (cboxVeThanhHetThucAn), value.ToString());
      this._cboxVeThanhHetThucAn = value;
    }
  }

  public bool cboxVeThanhHetBNM
  {
    get => this._cboxVeThanhHetBNM;
    set
    {
      if (this.AllInformationLoaded && this._cboxVeThanhHetBNM != value)
        this.SaveSingleSetting(nameof (cboxVeThanhHetBNM), value.ToString());
      this._cboxVeThanhHetBNM = value;
    }
  }

  public int numVeThanhHP
  {
    get => this._numVeThanhHP;
    set
    {
      if (this.AllInformationLoaded && this._numVeThanhHP != value)
        this.SaveSingleSetting(nameof (numVeThanhHP), value.ToString());
      this._numVeThanhHP = value;
    }
  }

  public int numVeThanhMP
  {
    get => this._numVeThanhMP;
    set
    {
      if (this.AllInformationLoaded && this._numVeThanhMP != value)
        this.SaveSingleSetting(nameof (numVeThanhMP), value.ToString());
      this._numVeThanhMP = value;
    }
  }

  public int HealMapID
  {
    get => this._HealMapID;
    set
    {
      if (this.AllInformationLoaded && this._HealMapID != value)
        this.SaveSingleSetting(nameof (HealMapID), value.ToString());
      this._HealMapID = value;
    }
  }

  public int cboPetFoodType
  {
    get => this._cboPetFoodType;
    set
    {
      if (this.AllInformationLoaded && this._cboPetFoodType != value)
        this.SaveSingleSetting(nameof (cboPetFoodType), value.ToString());
      this._cboPetFoodType = value;
    }
  }

  public bool cboxVeThanhHetMau
  {
    get => this._cboxVeThanhHetMau;
    set
    {
      if (this.AllInformationLoaded && this._cboxVeThanhHetMau != value)
        this.SaveSingleSetting(nameof (cboxVeThanhHetMau), value.ToString());
      this._cboxVeThanhHetMau = value;
    }
  }

  public bool cboxHelpChat
  {
    get => this._cboxHelpChat;
    set
    {
      if (this.AllInformationLoaded && this._cboxHelpChat != value)
        this.SaveSingleSetting(nameof (cboxHelpChat), value.ToString());
      this._cboxHelpChat = value;
    }
  }

  public int cboKenhChat
  {
    get => this._cboKenhChat;
    set
    {
      if (this.AllInformationLoaded && this._cboKenhChat != value)
        this.SaveSingleSetting(nameof (cboKenhChat), value.ToString());
      this._cboKenhChat = value;
    }
  }

  public int numAutoChat
  {
    get => this._numAutoChat;
    set
    {
      if (this.AllInformationLoaded && this._numAutoChat != value)
        this.SaveSingleSetting(nameof (numAutoChat), value.ToString());
      this._numAutoChat = value;
    }
  }

  public string AutoChatContent
  {
    get => this._AutoChatContent;
    set
    {
      if (this.AllInformationLoaded && this._AutoChatContent != value)
        this.SaveSingleSetting(nameof (AutoChatContent), value.ToString());
      this._AutoChatContent = value;
    }
  }

  public int tboxIDBang
  {
    get => this._tboxIDBang;
    set
    {
      if (this.AllInformationLoaded && this._tboxIDBang != value)
        this.SaveSingleSetting(nameof (tboxIDBang), value.ToString());
      this._tboxIDBang = value;
    }
  }

  public int tBoxIDFriend
  {
    get => this._tBoxIDFriend;
    set
    {
      if (this.AllInformationLoaded && this._tBoxIDFriend != value)
        this.SaveSingleSetting(nameof (tBoxIDFriend), value.ToString());
      this._tBoxIDFriend = value;
    }
  }

  public bool cboxTNFullAuto
  {
    get => this._cboxTNFullAuto;
    set
    {
      if (this.AllInformationLoaded && this._cboxTNFullAuto != value)
        this.SaveSingleSetting(nameof (cboxTNFullAuto), value.ToString());
      this._cboxTNFullAuto = value;
    }
  }

  public int numTNRounds
  {
    get => this._numTNRounds;
    set
    {
      if (this.AllInformationLoaded && this._numTNRounds != value)
        this.SaveSingleSetting(nameof (numTNRounds), value.ToString());
      this._numTNRounds = value;
    }
  }

  public bool cboxTNAlert
  {
    get => this._cboxTNAlert;
    set
    {
      if (this.AllInformationLoaded && this._cboxTNAlert != value)
        this.SaveSingleSetting(nameof (cboxTNAlert), value.ToString());
      this._cboxTNAlert = value;
    }
  }

  public bool cboxTNAlertPK
  {
    get => this._cboxTNAlertPK;
    set
    {
      if (this.AllInformationLoaded && this._cboxTNAlertPK != value)
        this.SaveSingleSetting(nameof (cboxTNAlertPK), value.ToString());
      this._cboxTNAlertPK = value;
    }
  }

  public bool cboItemTuHuy
  {
    get => this._cboItemTuHuy;
    set
    {
      if (this.AllInformationLoaded && this._cboItemTuHuy != value)
        this.SaveSingleSetting(nameof (cboItemTuHuy), value.ToString());
      this._cboItemTuHuy = value;
    }
  }

  public bool cboTNTuNhanPhieu
  {
    get => this._cboTNTuNhanPhieu;
    set
    {
      if (this.AllInformationLoaded && this._cboTNTuNhanPhieu != value)
        this.SaveSingleSetting(nameof (cboTNTuNhanPhieu), value.ToString());
      this._cboTNTuNhanPhieu = value;
    }
  }

  public bool cboxFullThungVE
  {
    get => this._cboxFullThungVE;
    set
    {
      if (this.AllInformationLoaded && this._cboxFullThungVE != value)
        this.SaveSingleSetting(nameof (cboxFullThungVE), value.ToString());
      this._cboxFullThungVE = value;
    }
  }

  public int numFullThung
  {
    get => this._numFullThung;
    set
    {
      if (this.AllInformationLoaded && this._numFullThung != value)
        this.SaveSingleSetting(nameof (numFullThung), value.ToString());
      this._numFullThung = value;
    }
  }

  public int numBanKinhNhat
  {
    get => this._numBanKinhNhat;
    set
    {
      if (this.AllInformationLoaded && this._numBanKinhNhat != value)
        this.SaveSingleSetting(nameof (numBanKinhNhat), value.ToString());
      this._numBanKinhNhat = value;
    }
  }

  public bool cboxFullStopNhat
  {
    get => this._cboxFullStopNhat;
    set
    {
      if (this.AllInformationLoaded && this._cboxFullStopNhat != value)
        this.SaveSingleSetting(nameof (cboxFullStopNhat), value.ToString());
      this._cboxFullStopNhat = value;
    }
  }

  public string TNLastDirection
  {
    get => this._TNLastDirection;
    set
    {
      if (this.AllInformationLoaded && this._TNLastDirection != value)
        this.SaveSingleSetting(nameof (TNLastDirection), value, "TN chuyến cuối hướng nào");
      this._TNLastDirection = value;
    }
  }

  public void SaveSingleSetting(
    string keyName,
    string value,
    string desc = "",
    params string[] parameters)
  {
    return;
  }

  public string AIModeDisplay
  {
    get
    {
      if (this.AIMode == AllEnums.AIModes.DANHQUANHDIEM)
      {
        if (frmLogin.GAuto.Settings.CompilingLanguage == "VN")
          return "Đánh quanh điểm";
        return frmLogin.GAuto.Settings.CompilingLanguage == "EN" ? "Fight around spot" : "围绕一个点打";
      }
      if (this.AIMode == AllEnums.AIModes.DANHTUDO)
      {
        if (frmLogin.GAuto.Settings.CompilingLanguage == "VN")
          return "Đánh tự do";
        return frmLogin.GAuto.Settings.CompilingLanguage == "EN" ? "Fight moving free" : "自由移动和战斗";
      }
      if (this.AIMode == AllEnums.AIModes.HOTRO)
      {
        if (frmLogin.GAuto.Settings.CompilingLanguage == "VN")
          return "Hỗ trợ tổ đội";
        return frmLogin.GAuto.Settings.CompilingLanguage == "EN" ? "Team support" : "支持团队";
      }
      if (this.AIMode == AllEnums.AIModes.KHAIKHOANG_HAIDUOC)
      {
        if (frmLogin.GAuto.Settings.CompilingLanguage == "VN")
          return "KK H. dược";
        return frmLogin.GAuto.Settings.CompilingLanguage == "EN" ? "Mining - Picking" : "采矿和香草采摘";
      }
      if (this.AIMode == AllEnums.AIModes.SCRIPTING)
      {
        if (frmLogin.GAuto.Settings.CompilingLanguage == "VN")
          return "Theo kịch bản";
        return frmLogin.GAuto.Settings.CompilingLanguage == "EN" ? "Scripted" : "脚本";
      }
      if (this.AIMode == AllEnums.AIModes.TRONGTROT)
      {
        if (frmLogin.GAuto.Settings.CompilingLanguage == "VN")
          return "Trồng trọt";
        return frmLogin.GAuto.Settings.CompilingLanguage == "EN" ? "Planting" : "作物";
      }
      if (this.AIMode == AllEnums.AIModes.THUONGNHAN && this.TraderMode == AllEnums.TraderModes.Chạy_Đi)
      {
        if (frmLogin.GAuto.Settings.CompilingLanguage == "VN")
          return "TN Chạy đi";
        return frmLogin.GAuto.Settings.CompilingLanguage == "EN" ? "Trading forward" : "交易去前进";
      }
      if (this.AIMode == AllEnums.AIModes.THUONGNHAN && this.TraderMode == AllEnums.TraderModes.Chạy_Về)
      {
        if (frmLogin.GAuto.Settings.CompilingLanguage == "VN")
          return "TN Chạy về";
        return frmLogin.GAuto.Settings.CompilingLanguage == "EN" ? "Trading backward" : "交易落后";
      }
      if (this.AIMode == AllEnums.AIModes.THUONGNHAN && this.TraderMode == AllEnums.TraderModes.SellBuy)
      {
        if (frmLogin.GAuto.Settings.CompilingLanguage == "VN")
          return "TN Mua bán";
        return frmLogin.GAuto.Settings.CompilingLanguage == "EN" ? "Trading buy-sell" : "交易买和卖";
      }
      if (this.AIMode == AllEnums.AIModes.THUONGNHAN && this.TraderMode == AllEnums.TraderModes.IDLE)
      {
        if (frmLogin.GAuto.Settings.CompilingLanguage == "VN")
          return "TN rảnh";
        return frmLogin.GAuto.Settings.CompilingLanguage == "EN" ? "Trading idle" : "交易袖手旁观";
      }
      if (this.AIMode == AllEnums.AIModes.NHIEMVU)
      {
        if (frmLogin.GAuto.Settings.CompilingLanguage == "VN")
          return "Nhiệm vụ";
        return frmLogin.GAuto.Settings.CompilingLanguage == "EN" ? "Quest" : "任务";
      }
      if (frmLogin.GAuto.Settings.CompilingLanguage == "VN")
        return "Không biết";
      return frmLogin.GAuto.Settings.CompilingLanguage == "EN" ? "Unknown" : "未知";
    }
  }

  public List<PetSkillPlay> PetSkillPlays
  {
    get => this._PetSkillPlays;
    set => this._PetSkillPlays = value;
  }

  public bool cboxPetAOE
  {
    get => this._cboxPetAOE;
    set
    {
      if (this.AllInformationLoaded && this._cboxPetAOE != value)
        this.SaveSingleSetting(nameof (cboxPetAOE), value.ToString(), "Cho pet chơi AOE hay không");
      this._cboxPetAOE = value;
    }
  }

  public int TKCLeftX
  {
    get => this._TKCLeftX;
    set
    {
      if (this.AllInformationLoaded && this._TKCLeftX != value)
        this.SaveSingleSetting(nameof (TKCLeftX), value.ToString());
      this._TKCLeftX = value;
    }
  }

  public int TKCLeftY
  {
    get => this._TKCLeftY;
    set
    {
      if (this.AllInformationLoaded && this._TKCLeftY != value)
        this.SaveSingleSetting(nameof (TKCLeftY), value.ToString());
      this._TKCLeftY = value;
    }
  }

  public int TKCRightX
  {
    get => this._TKCRightX;
    set
    {
      if (this.AllInformationLoaded && this._TKCRightX != value)
        this.SaveSingleSetting(nameof (TKCRightX), value.ToString());
      this._TKCRightX = value;
    }
  }

  public int TKCRightY
  {
    get => this._TKCRightY;
    set
    {
      if (this.AllInformationLoaded && this._TKCRightY != value)
        this.SaveSingleSetting(nameof (TKCRightY), value.ToString());
      this._TKCRightY = value;
    }
  }

  public double CenterX
  {
    get => this._CenterX;
    set
    {
      if (this.AllInformationLoaded && this._CenterX != value)
        this.SaveSingleSetting(nameof (CenterX), value.ToString());
      this._CenterX = value;
    }
  }

  public double CenterY
  {
    get => this._CenterY;
    set
    {
      if (this.AllInformationLoaded && this._CenterY != value)
        this.SaveSingleSetting(nameof (CenterY), value.ToString());
      this._CenterY = value;
    }
  }

  public bool cboxHuyetTe
  {
    get => this._cboxHuyetTe;
    set
    {
      if (this.AllInformationLoaded && this._cboxHuyetTe != value)
        this.SaveSingleSetting(nameof (cboxHuyetTe), value.ToString());
      this._cboxHuyetTe = value;
    }
  }

  public double Diameter4
  {
    get => this._Diameter3;
    set
    {
      if (this.AllInformationLoaded && this._Diameter3 != value)
        this.SaveSingleSetting(nameof (Diameter4), value.ToString());
      this._Diameter3 = value;
    }
  }

  public double MoveRange
  {
    get => this._MoveRange;
    set
    {
      if (this.AllInformationLoaded && this._MoveRange != value)
        this.SaveSingleSetting(nameof (MoveRange), value.ToString());
      this._MoveRange = value;
    }
  }

  public int MapID
  {
    get => this._MapID;
    set
    {
      if (this.AllInformationLoaded && this._MapID != value)
        this.SaveSingleSetting(nameof (MapID), value.ToString());
      this._MapID = value;
    }
  }

  public string MapName => GA.GetMapName(this.MapID);

  public int CharDBID
  {
    get => this._CharDBID;
    set
    {
      if (this._CharDBID == value)
        return;
      this._CharDBID = value;
    }
  }

  public bool cboxCaptchaReset
  {
    get => this._cboxCaptchaReset;
    set
    {
      if (this.AllInformationLoaded && this._cboxCaptchaReset != value)
        this.SaveSingleSetting(nameof (cboxCaptchaReset), value.ToString());
      this._cboxCaptchaReset = value;
    }
  }

  public bool cboxTheoSau
  {
    get => this._cboxTheoSau;
    set
    {
      if (this.AllInformationLoaded && this._cboxTheoSau != value)
        this.SaveSingleSetting(nameof (cboxTheoSau), value.ToString());
      this._cboxTheoSau = value;
    }
  }

  public bool cboxTurboMode
  {
    get => this._cboxTurboMode;
    set
    {
      if (this.AllInformationLoaded && this._cboxTurboMode != value)
        this.SaveSingleSetting(nameof (cboxTurboMode), value.ToString());
      this._cboxTurboMode = value;
    }
  }

  public int numGroupID
  {
    get => this._numGroupID;
    set
    {
      if (this.AllInformationLoaded && this._numGroupID != value)
        this.SaveSingleSetting(nameof (numGroupID), value.ToString());
      this._numGroupID = value;
    }
  }

  public AllEnums.FightingModes FightMode
  {
    get => this._FightMode;
    set
    {
      if (this.AllInformationLoaded && this._FightMode != value)
        this.SaveSingleSetting(nameof (FightMode), value.ToString());
      this._FightMode = value;
    }
  }

  public bool cboxDanhTheoKey
  {
    get => this._cboxDanhTheoKey;
    set
    {
      if (this.AllInformationLoaded && this._cboxDanhTheoKey != value)
        this.SaveSingleSetting(nameof (cboxDanhTheoKey), value.ToString());
      this._cboxDanhTheoKey = value;
    }
  }

  public bool cboxTNChayNhanh
  {
    get => this._cboxTNChayNhanh;
    set
    {
      if (this.AllInformationLoaded && this._cboxTNChayNhanh != value)
        this.SaveSingleSetting(nameof (cboxTNChayNhanh), value.ToString());
      this._cboxTNChayNhanh = value;
    }
  }

  public int PartySavedPosX
  {
    get => this._PartySavedPosX;
    set
    {
      if (this.AllInformationLoaded && this._PartySavedPosX != value)
        this.SaveSingleSetting(nameof (PartySavedPosX), value.ToString());
      this._PartySavedPosX = value;
    }
  }

  public int PartySavedPosY
  {
    get => this._PartySavedPosY;
    set
    {
      if (this.AllInformationLoaded && this._PartySavedPosY != value)
        this.SaveSingleSetting(nameof (PartySavedPosY), value.ToString());
      this._PartySavedPosY = value;
    }
  }

  public GAutoList<string> PTBlacklist
  {
    get => this._PTBlacklist;
    set => this._PTBlacklist = value;
  }

  public GAutoList<string> QuaiNoAttackList
  {
    get => this._QuaiNoAttackList;
    set => this._QuaiNoAttackList = value;
  }

  public GAutoList<string> AutoPartyList
  {
    get => this._AutoPartyList;
    set => this._AutoPartyList = value;
  }

  public int PartySavedMapID
  {
    get => this._PartySavedMapID;
    set
    {
      if (this.AllInformationLoaded && this._PartySavedMapID != value)
        this.SaveSingleSetting(nameof (PartySavedMapID), value.ToString());
      this._PartySavedMapID = value;
    }
  }

  public bool cboxTuVaoPT
  {
    get => this._cboxTuVaoPT;
    set
    {
      if (this.AllInformationLoaded && this._cboxTuVaoPT != value)
        this.SaveSingleSetting(nameof (cboxTuVaoPT), value.ToString());
      this._cboxTuVaoPT = value;
    }
  }

  public bool cboxCanX2
  {
    get => this._cboxCanX2;
    set
    {
      if (this.AllInformationLoaded && this._cboxCanX2 != value)
        this.SaveSingleSetting(nameof (cboxCanX2), value.ToString());
      this._cboxCanX2 = value;
    }
  }

  public bool cboxNMBuffBang
  {
    get => this._cboxNMBuffBang;
    set
    {
      if (this.AllInformationLoaded && this._cboxNMBuffBang != value)
        this.SaveSingleSetting(nameof (cboxNMBuffBang), value.ToString());
      this._cboxNMBuffBang = value;
    }
  }

  public int numTheoSau
  {
    get => this._numTheoSau;
    set
    {
      if (this.AllInformationLoaded && this._numTheoSau != value)
        this.SaveSingleSetting(nameof (numTheoSau), value.ToString());
      this._numTheoSau = value;
    }
  }

  public bool cboxKhongResetGio
  {
    get => this._cboxKhongResetGio;
    set
    {
      if (this.AllInformationLoaded && this._cboxKhongResetGio != value)
        this.SaveSingleSetting(nameof (cboxKhongResetGio), value.ToString());
      this._cboxKhongResetGio = value;
    }
  }

  public bool cboxPKTuVe
  {
    get => this._cboxPKTuVe;
    set
    {
      if (this.AllInformationLoaded && this._cboxPKTuVe != value)
        this.SaveSingleSetting(nameof (cboxPKTuVe), value.ToString());
      this._cboxPKTuVe = value;
    }
  }

  public bool cboxThoLinhChau
  {
    get => this._cboxThoLinhChau;
    set
    {
      if (this.AllInformationLoaded && this._cboxThoLinhChau != value)
        this.SaveSingleSetting(nameof (cboxThoLinhChau), value.ToString());
      this._cboxThoLinhChau = value;
    }
  }

  public bool cboxChoHoiSinh
  {
    get => this._cboxChoHoiSinh;
    set
    {
      if (this.AllInformationLoaded && this._cboxChoHoiSinh != value)
        this.SaveSingleSetting(nameof (cboxChoHoiSinh), value.ToString());
      this._cboxChoHoiSinh = value;
    }
  }

  public int numChoHoiSinh
  {
    get => this._numChoHoiSinh;
    set
    {
      if (this.AllInformationLoaded && this._numChoHoiSinh != value)
        this.SaveSingleSetting(nameof (numChoHoiSinh), value.ToString());
      this._numChoHoiSinh = value;
    }
  }

  public bool cboxNMHoiSinhPT
  {
    get => this._cboxNMHoiSinhPT;
    set
    {
      if (this.AllInformationLoaded && this._cboxNMHoiSinhPT != value)
        this.SaveSingleSetting(nameof (cboxNMHoiSinhPT), value.ToString());
      this._cboxNMHoiSinhPT = value;
    }
  }

  public bool cboTTThuHoach
  {
    get => this._cboTTThuHoach;
    set
    {
      if (this.AllInformationLoaded && this._cboTTThuHoach != value)
        this.SaveSingleSetting(nameof (cboTTThuHoach), value.ToString());
      this._cboTTThuHoach = value;
    }
  }

  public int txtTTNPC1_ID
  {
    get => this._txtTTNPC1_ID;
    set
    {
      if (this.AllInformationLoaded && this._txtTTNPC1_ID != value)
        this.SaveSingleSetting(nameof (txtTTNPC1_ID), value.ToString());
      this._txtTTNPC1_ID = value;
    }
  }

  public int txtTTNPC1_X
  {
    get => this._txtTTNPC1_X;
    set
    {
      if (this.AllInformationLoaded && this._txtTTNPC1_X != value)
        this.SaveSingleSetting(nameof (txtTTNPC1_X), value.ToString());
      this._txtTTNPC1_X = value;
    }
  }

  public int txtTTNPC1_Y
  {
    get => this._txtTTNPC1_Y;
    set
    {
      if (this.AllInformationLoaded && this._txtTTNPC1_Y != value)
        this.SaveSingleSetting(nameof (txtTTNPC1_Y), value.ToString());
      this._txtTTNPC1_Y = value;
    }
  }

  public int txtTTNPC2_ID
  {
    get => this._txtTTNPC2_ID;
    set
    {
      if (this.AllInformationLoaded && this._txtTTNPC2_ID != value)
        this.SaveSingleSetting(nameof (txtTTNPC2_ID), value.ToString());
      this._txtTTNPC2_ID = value;
    }
  }

  public int txtTTNPC2_X
  {
    get => this._txtTTNPC2_X;
    set
    {
      if (this.AllInformationLoaded && this._txtTTNPC2_X != value)
        this.SaveSingleSetting(nameof (txtTTNPC2_X), value.ToString());
      this._txtTTNPC2_X = value;
    }
  }

  public int txtTTNPC2_Y
  {
    get => this._txtTTNPC2_Y;
    set
    {
      if (this.AllInformationLoaded && this._txtTTNPC2_Y != value)
        this.SaveSingleSetting(nameof (txtTTNPC2_Y), value.ToString());
      this._txtTTNPC2_Y = value;
    }
  }

  public long TrongTrotNPCTime1
  {
    get => this._TrongTrotNPCTime1;
    set
    {
      if (this.AllInformationLoaded && this._TrongTrotNPCTime1 != value)
        this.SaveSingleSetting(nameof (TrongTrotNPCTime1), value.ToString());
      this._TrongTrotNPCTime1 = value;
    }
  }

  public long TrongTrotNPCTime2
  {
    get => this._TrongTrotNPCTime2;
    set
    {
      if (this.AllInformationLoaded && this._TrongTrotNPCTime2 != value)
        this.SaveSingleSetting(nameof (TrongTrotNPCTime2), value.ToString());
      this._TrongTrotNPCTime2 = value;
    }
  }

  public bool cboxDanhHoTro
  {
    get => this._cboxDanhHoTro;
    set
    {
      if (this.AllInformationLoaded && this._cboxDanhHoTro != value)
        this.SaveSingleSetting(nameof (cboxDanhHoTro), value.ToString());
      this._cboxDanhHoTro = value;
    }
  }

  public string TrongTrotTime
  {
    get => this._TrongTrotTime;
    set
    {
      if (this.AllInformationLoaded && this._TrongTrotTime != value)
        this.SaveSingleSetting(nameof (TrongTrotTime), value.ToString());
      this._TrongTrotTime = value;
    }
  }

  public int TrongTrotMapID
  {
    get => this._TrongTrotMapID;
    set
    {
      if (this.AllInformationLoaded && this._TrongTrotMapID != value)
        this.SaveSingleSetting(nameof (TrongTrotMapID), value.ToString());
      this._TrongTrotMapID = value;
    }
  }

  public int TTLoaiThuHoach
  {
    get => this._TTLoaiThuHoach;
    set
    {
      if (this.AllInformationLoaded && this._TTLoaiThuHoach != value)
        this.SaveSingleSetting(nameof (TTLoaiThuHoach), value.ToString());
      this._TTLoaiThuHoach = value;
    }
  }

  public string TTCaySeTrong
  {
    get => this._TTCaySeTrong;
    set
    {
      if (this.AllInformationLoaded && this._TTCaySeTrong != value)
        this.SaveSingleSetting(nameof (TTCaySeTrong), value.ToString());
      this._TTCaySeTrong = value;
    }
  }

  public bool cboxKhaiKhoang
  {
    get => this._cboxKhaiKhoang;
    set
    {
      if (this.AllInformationLoaded && this._cboxKhaiKhoang != value)
        this.SaveSingleSetting(nameof (cboxKhaiKhoang), value.ToString());
      this._cboxKhaiKhoang = value;
    }
  }

  public bool cboxHaiDuoc
  {
    get => this._cboxHaiDuoc;
    set
    {
      if (this.AllInformationLoaded && this._cboxHaiDuoc != value)
        this.SaveSingleSetting(nameof (cboxHaiDuoc), value.ToString());
      this._cboxHaiDuoc = value;
    }
  }

  public bool cboxKhoangDuoc { get; set; }

  public string KhoangDuocMapName => GA.GetMapName(this.KhoangDuocMapID);

  public int KhoangDuocMapID
  {
    get => this._KhoangDuocMapID;
    set
    {
      if (this.AllInformationLoaded && this._KhoangDuocMapID != value)
        this.SaveSingleSetting(nameof (KhoangDuocMapID), value.ToString());
      this._KhoangDuocMapID = value;
    }
  }

  public int cboxDuaHauCity
  {
    get => this._cboxDuaHauCity;
    set
    {
      if (this.AllInformationLoaded && this._cboxDuaHauCity != value)
        this.SaveSingleSetting(nameof (cboxDuaHauCity), value.ToString());
      this._cboxDuaHauCity = value;
    }
  }

  public bool cboDHAlertTuu
  {
    get => this._cboDHAlertTuu;
    set
    {
      if (this.AllInformationLoaded && this._cboDHAlertTuu != value)
        this.SaveSingleSetting(nameof (cboDHAlertTuu), value.ToString());
      this._cboDHAlertTuu = value;
    }
  }

  public bool cboDHAutoNV
  {
    get => this._cboDHAutoNV;
    set
    {
      if (this.AllInformationLoaded && this._cboDHAutoNV != value)
        this.SaveSingleSetting(nameof (cboDHAutoNV), value.ToString());
      this._cboDHAutoNV = value;
    }
  }

  public bool cboDHAutoPick
  {
    get => this._cboDHAutoPick;
    set
    {
      if (this.AllInformationLoaded && this._cboDHAutoPick != value)
        this.SaveSingleSetting(nameof (cboDHAutoPick), value.ToString());
      this._cboDHAutoPick = value;
    }
  }

  public bool cboDHFromCity
  {
    get => this._cboDHFromCity;
    set
    {
      if (this.AllInformationLoaded && this._cboDHFromCity != value)
        this.SaveSingleSetting(nameof (cboDHFromCity), value.ToString());
      this._cboDHFromCity = value;
    }
  }

  public int cboxDuaHauMaps
  {
    get => this._cboxDuaHauMaps;
    set
    {
      if (this.AllInformationLoaded && this._cboxDuaHauMaps != value)
        this.SaveSingleSetting(nameof (cboxDuaHauMaps), value.ToString());
      this._cboxDuaHauMaps = value;
    }
  }

  public int txtDHBangID
  {
    get => this._txtDHBangID;
    set
    {
      if (this.AllInformationLoaded && this._txtDHBangID != value)
        this.SaveSingleSetting(nameof (txtDHBangID), value.ToString());
      this._txtDHBangID = value;
    }
  }

  public bool cboxNMPKBuff
  {
    get => this._cboxNMPKBuff;
    set
    {
      if (this.AllInformationLoaded && this._cboxNMPKBuff != value)
        this.SaveSingleSetting(nameof (cboxNMPKBuff), value.ToString());
      this._cboxNMPKBuff = value;
    }
  }

  public int cboATMaps
  {
    get => this._cboATMaps;
    set
    {
      if (this.AllInformationLoaded && this._cboATMaps != value)
        this.SaveSingleSetting(nameof (cboATMaps), value.ToString());
      this._cboATMaps = value;
    }
  }

  public int TNBuyingMode
  {
    get => this._TNBuyingMode;
    set
    {
      if (this.AllInformationLoaded && this._TNBuyingMode != value)
        this.SaveSingleSetting(nameof (TNBuyingMode), value.ToString());
      this._TNBuyingMode = value;
    }
  }

  public bool cboxTNMinhGiaHigher
  {
    get => this._cboxTNMinhGiaHigher;
    set
    {
      if (this.AllInformationLoaded && this._cboxTNMinhGiaHigher != value)
        this.SaveSingleSetting(nameof (cboxTNMinhGiaHigher), value.ToString());
      this._cboxTNMinhGiaHigher = value;
    }
  }

  public bool cboxTNFriendGiaHigher
  {
    get => this._cboxTNFriendGiaHigher;
    set
    {
      if (this.AllInformationLoaded && this._cboxTNFriendGiaHigher != value)
        this.SaveSingleSetting(nameof (cboxTNFriendGiaHigher), value.ToString());
      this._cboxTNFriendGiaHigher = value;
    }
  }

  public int txtTNMinhGiaHigher
  {
    get => this._txtTNMinhGiaHigher;
    set
    {
      if (this.AllInformationLoaded && this._txtTNMinhGiaHigher != value)
        this.SaveSingleSetting(nameof (txtTNMinhGiaHigher), value.ToString());
      this._txtTNMinhGiaHigher = value;
    }
  }

  public int txtTNFriendGia
  {
    get => this._txtTNFriendGia;
    set
    {
      if (this.AllInformationLoaded && this._txtTNFriendGia != value)
        this.SaveSingleSetting(nameof (txtTNFriendGia), value.ToString());
      this._txtTNFriendGia = value;
    }
  }

  public int cboTNMinhItem
  {
    get => this._cboTNMinhItem;
    set
    {
      if (this.AllInformationLoaded && this._cboTNMinhItem != value)
        this.SaveSingleSetting(nameof (cboTNMinhItem), value.ToString());
      this._cboTNMinhItem = value;
    }
  }

  public int cboTNFriendItem
  {
    get => this._cboTNFriendItem;
    set
    {
      if (this.AllInformationLoaded && this._cboTNFriendItem != value)
        this.SaveSingleSetting(nameof (cboTNFriendItem), value.ToString());
      this._cboTNFriendItem = value;
    }
  }

  public string cboTNMinhItemName => GA.GetTNItemFromID(this.cboTNMinhItem);

  public string cboTNFriendItemName => GA.GetTNItemFromID(this.cboTNFriendItem);

  public bool cboxCanX4
  {
    get => this._cboxCanX4;
    set
    {
      if (this.AllInformationLoaded && this._cboxCanX4 != value)
        this.SaveSingleSetting(nameof (cboxCanX4), value.ToString());
      this._cboxCanX4 = value;
    }
  }

  public bool cboxNMBuffQuanDoan
  {
    get => this._cboxNMBuffQuanDoan;
    set
    {
      if (this.AllInformationLoaded && this._cboxNMBuffQuanDoan != value)
        this.SaveSingleSetting(nameof (cboxNMBuffQuanDoan), value.ToString());
      this._cboxNMBuffQuanDoan = value;
    }
  }

  public bool cboxBuffQuanDoan
  {
    get => this._cboxBuffQuanDoan;
    set
    {
      if (this.AllInformationLoaded && this._cboxBuffQuanDoan != value)
        this.SaveSingleSetting(nameof (cboxBuffQuanDoan), value.ToString());
      this._cboxBuffQuanDoan = value;
    }
  }

  public bool cboxNMBuffList
  {
    get => this._cboxNMBuffList;
    set
    {
      if (this.AllInformationLoaded && this._cboxNMBuffList != value)
        this.SaveSingleSetting(nameof (cboxNMBuffList), value.ToString());
      this._cboxNMBuffList = value;
    }
  }

  public bool cboxBuffHoTroOnOff
  {
    get => this._cboxBuffHoTroOnOff;
    set
    {
      if (this.AllInformationLoaded && this._cboxBuffHoTroOnOff != value)
        this.SaveSingleSetting(nameof (cboxBuffHoTroOnOff), value.ToString());
      this._cboxBuffHoTroOnOff = value;
    }
  }

  public bool cboxSkillOnOff
  {
    get => this._cboxSkillOnOff;
    set
    {
      if (this.AllInformationLoaded && this._cboxSkillOnOff != value)
        this.SaveSingleSetting(nameof (cboxSkillOnOff), value.ToString());
      this._cboxSkillOnOff = value;
    }
  }

  public int PTTheoSauMode
  {
    get => this._PTTheoSauMode;
    set
    {
      if (this.AllInformationLoaded && this._PTTheoSauMode != value)
        this.SaveSingleSetting(nameof (PTTheoSauMode), value.ToString());
      this._PTTheoSauMode = value;
    }
  }

  public string txtTheoSauName
  {
    get => this._txtTheoSauName;
    set
    {
      if (this.AllInformationLoaded && this._txtTheoSauName != value)
        this.SaveSingleSetting(nameof (txtTheoSauName), value.ToString());
      this._txtTheoSauName = value;
    }
  }

  public string txtTrainExpMode
  {
    get
    {
      switch (this.cboTrainExpMode)
      {
        case 1:
          switch (frmLogin.CompilingLanguage)
          {
            case "VN":
              return "5 phút";
            case "EN":
              return "5 mins";
            default:
              return "5 分钟";
          }
        case 2:
          switch (frmLogin.CompilingLanguage)
          {
            case "VN":
              return "1 phút";
            case "EN":
              return "1 min";
            default:
              return "1 分钟";
          }
        default:
          switch (frmLogin.CompilingLanguage)
          {
            case "VN":
              return "giờ";
            case "EN":
              return "hour";
            default:
              return "小时";
          }
      }
    }
  }

  public int cboTrainExpMode
  {
    get => this._cboTrainExpMode;
    set
    {
      if (this.AllInformationLoaded && this._cboTrainExpMode != value)
        this.SaveSingleSetting(nameof (cboTrainExpMode), value.ToString());
      this._cboTrainExpMode = value;
    }
  }

  public bool cboxPhuVeThanh
  {
    get => this._cboxPhuVeThanh;
    set
    {
      if (this.AllInformationLoaded && this._cboxPhuVeThanh != value)
        this.SaveSingleSetting(nameof (cboxPhuVeThanh), value.ToString());
      this._cboxPhuVeThanh = value;
    }
  }

  public bool cboxPassCap2
  {
    get => this._cboxPassCap2;
    set
    {
      if (this.AllInformationLoaded && this._cboxPassCap2 != value)
        this.SaveSingleSetting(nameof (cboxPassCap2), value.ToString());
      this._cboxPassCap2 = value;
    }
  }

  public bool cboxTuClickYes2
  {
    get => this._cboxTuClickYes;
    set
    {
      if (this.AllInformationLoaded && this._cboxTuClickYes != value)
        this.SaveSingleSetting(nameof (cboxTuClickYes2), value.ToString());
      this._cboxTuClickYes = value;
    }
  }

  public string txtPassCap2
  {
    get => this._txtPassCap2;
    set
    {
      if (this.AllInformationLoaded && this._txtPassCap2 != value)
      {
        string s = GA.XOREncrypt($"Peter{value}mary", "8u43!29");
        this.SaveSingleSetting(nameof (txtPassCap2), Convert.ToBase64String(Encoding.ASCII.GetBytes(s), 0, s.Length));
      }
      this._txtPassCap2 = value;
    }
  }

  public bool cboxPKThoatGame
  {
    get => this._cboxPKThoatGame;
    set
    {
      if (this.AllInformationLoaded && this._cboxPKThoatGame != value)
        this.SaveSingleSetting(nameof (cboxPKThoatGame), value.ToString());
      this._cboxPKThoatGame = value;
    }
  }

  public int numPKThoatGame
  {
    get => this._numPKThoatGame;
    set
    {
      if (this.AllInformationLoaded && this._numPKThoatGame != value)
        this.SaveSingleSetting(nameof (numPKThoatGame), value.ToString());
      this._numPKThoatGame = value;
    }
  }

  public bool cboxTANhanNV
  {
    get => this._cboxTANhanNV;
    set
    {
      if (this.AllInformationLoaded && this._cboxTANhanNV != value)
        this.SaveSingleSetting(nameof (cboxTANhanNV), value.ToString());
      this._cboxTANhanNV = value;
    }
  }

  public bool cboxTAHoiPhuc
  {
    get => this._cboxTAHoiPhuc;
    set
    {
      if (this.AllInformationLoaded && this._cboxTAHoiPhuc != value)
        this.SaveSingleSetting(nameof (cboxTAHoiPhuc), value.ToString());
      this._cboxTAHoiPhuc = value;
    }
  }

  public bool cboxTADungPhu
  {
    get => this._cboxTADungPhu;
    set
    {
      if (this.AllInformationLoaded && this._cboxTADungPhu != value)
        this.SaveSingleSetting(nameof (cboxTADungPhu), value.ToString());
      this._cboxTADungPhu = value;
    }
  }

  public bool cboxPhuQuaLD
  {
    get => this._cboxPhuQuaLD;
    set
    {
      if (this.AllInformationLoaded && this._cboxPhuQuaLD != value)
        this.SaveSingleSetting(nameof (cboxPhuQuaLD), value.ToString());
      this._cboxPhuQuaLD = value;
    }
  }

  public bool cboxPhuQuaDaiLy
  {
    get => this._cboxPhuQuaDaiLy;
    set
    {
      if (this.AllInformationLoaded && this._cboxPhuQuaDaiLy != value)
        this.SaveSingleSetting(nameof (cboxPhuQuaDaiLy), value.ToString());
      this._cboxPhuQuaDaiLy = value;
    }
  }

  public bool cboxLKTuNhanNV
  {
    get => this._cboxLKTuNhanNV;
    set
    {
      if (this.AllInformationLoaded && this._cboxLKTuNhanNV != value)
        this.SaveSingleSetting(nameof (cboxLKTuNhanNV), value.ToString());
      this._cboxLKTuNhanNV = value;
    }
  }

  public int txtKNB50
  {
    get => this._txtKNB50;
    set
    {
      if (this.AllInformationLoaded && this._txtKNB50 != value)
        this.SaveSingleSetting(nameof (txtKNB50), value.ToString());
      this._txtKNB50 = value;
    }
  }

  public int txtKNB200
  {
    get => this._txtKNB200;
    set
    {
      if (this.AllInformationLoaded && this._txtKNB200 != value)
        this.SaveSingleSetting(nameof (txtKNB200), value.ToString());
      this._txtKNB200 = value;
    }
  }

  public int txtKNB500
  {
    get => this._txtKNB500;
    set
    {
      if (this.AllInformationLoaded && this._txtKNB500 != value)
        this.SaveSingleSetting(nameof (txtKNB500), value.ToString());
      this._txtKNB500 = value;
    }
  }

  public bool cboxXayDung
  {
    get => this._cboxXayDung;
    set
    {
      if (this.AllInformationLoaded && this._cboxXayDung != value)
        this.SaveSingleSetting(nameof (cboxXayDung), value.ToString());
      this._cboxXayDung = value;
    }
  }

  public bool cboxXayDungPhu
  {
    get => this._cboxXayDungPhu;
    set
    {
      if (this.AllInformationLoaded && this._cboxXayDungPhu != value)
        this.SaveSingleSetting(nameof (cboxXayDungPhu), value.ToString());
      this._cboxXayDungPhu = value;
    }
  }

  public bool cboxPTChoVao
  {
    get => this._cboxPTChoVao;
    set
    {
      if (this.AllInformationLoaded && this._cboxPTChoVao != value)
        this.SaveSingleSetting(nameof (cboxPTChoVao), value.ToString());
      this._cboxPTChoVao = value;
    }
  }

  public bool cboxPTLevel
  {
    get => this._cboxPTLevel;
    set
    {
      if (this.AllInformationLoaded && this._cboxPTLevel != value)
        this.SaveSingleSetting(nameof (cboxPTLevel), value.ToString());
      this._cboxPTLevel = value;
    }
  }

  public int numPTLevel
  {
    get => this._numPTLevel;
    set
    {
      if (this.AllInformationLoaded && this._numPTLevel != value)
        this.SaveSingleSetting(nameof (numPTLevel), value.ToString());
      this._numPTLevel = value;
    }
  }

  public bool cboxXDHoiMau
  {
    get => this._cboxXDHoiMau;
    set
    {
      if (this.AllInformationLoaded && this._cboxXDHoiMau != value)
        this.SaveSingleSetting(nameof (cboxXDHoiMau), value.ToString());
      this._cboxXDHoiMau = value;
    }
  }

  public bool cboxTBBPhiThuy
  {
    get => this._cboxTBBPhiThuy;
    set
    {
      if (this.AllInformationLoaded && this._cboxTBBPhiThuy != value)
        this.SaveSingleSetting(nameof (cboxTBBPhiThuy), value.ToString());
      this._cboxTBBPhiThuy = value;
    }
  }

  public bool cboxNMBuff
  {
    get => this._cboxNMBuff;
    set
    {
      if (this.AllInformationLoaded && this._cboxNMBuff != value)
        this.SaveSingleSetting(nameof (cboxNMBuff), value.ToString());
      this._cboxNMBuff = value;
    }
  }

  public bool cboxXDXaPhu
  {
    get => this._cboxXDXaPhu;
    set
    {
      if (this.AllInformationLoaded && this._cboxXDXaPhu != value)
        this.SaveSingleSetting(nameof (cboxXDXaPhu), value.ToString());
      this._cboxXDXaPhu = value;
    }
  }

  public bool cboxTAXaPhu
  {
    get => this._cboxTAXaPhu;
    set
    {
      if (this.AllInformationLoaded && this._cboxTAXaPhu != value)
        this.SaveSingleSetting(nameof (cboxTAXaPhu), value.ToString());
      this._cboxTAXaPhu = value;
    }
  }

  public int cboTuDuongCon
  {
    get => this._cboTuDuongCon;
    set
    {
      if (this.AllInformationLoaded && this._cboTuDuongCon != value)
        this.SaveSingleSetting(nameof (cboTuDuongCon), value.ToString());
      this._cboTuDuongCon = value;
    }
  }

  public bool cboxLTNhanVN
  {
    get => this._cboxLTNhanVN;
    set
    {
      if (this.AllInformationLoaded && this._cboxLTNhanVN != value)
        this.SaveSingleSetting(nameof (cboxLTNhanVN), value.ToString());
      this._cboxLTNhanVN = value;
    }
  }

  public bool cboxDanhTheoAi
  {
    get => this._cboxDanhTheoAi;
    set
    {
      if (this.AllInformationLoaded && this._cboxDanhTheoAi != value)
        this.SaveSingleSetting(nameof (cboxDanhTheoAi), value.ToString());
      this._cboxDanhTheoAi = value;
    }
  }

  public string txtDanhTheoAi
  {
    get => this._txtDanhTheoAi;
    set
    {
      if (this.AllInformationLoaded && this._txtDanhTheoAi != value)
        this.SaveSingleSetting(nameof (txtDanhTheoAi), value.ToString());
      this._txtDanhTheoAi = value;
    }
  }

  public int cboTuBaoBon
  {
    get => this._cboTuBaoBon;
    set
    {
      if (this.AllInformationLoaded && this._cboTuBaoBon != value)
        this.SaveSingleSetting(nameof (cboTuBaoBon), value.ToString());
      this._cboTuBaoBon = value;
    }
  }

  public bool cboxDanhQuai
  {
    get => this._cboxDanhQuai;
    set
    {
      if (this.AllInformationLoaded && this._cboxDanhQuai != value)
        this.SaveSingleSetting(nameof (cboxDanhQuai), value.ToString());
      this._cboxDanhQuai = value;
    }
  }

  public bool cboxBanKinh
  {
    get => this._cboxBanKinh;
    set
    {
      if (this.AllInformationLoaded && this._cboxBanKinh != value)
        this.SaveSingleSetting(nameof (cboxBanKinh), value.ToString());
      this._cboxBanKinh = value;
    }
  }

  public bool cboxTBBchaynhanh
  {
    get => this._cboxTBBchaynhanh;
    set
    {
      if (this.AllInformationLoaded && this._cboxTBBchaynhanh != value)
        this.SaveSingleSetting(nameof (cboxTBBchaynhanh), value.ToString());
      this._cboxTBBchaynhanh = value;
    }
  }

  public bool cboxAOE
  {
    get => this._cboxAOE;
    set
    {
      if (this.AllInformationLoaded && this._cboxAOE != value)
        this.SaveSingleSetting(nameof (cboxAOE), value.ToString());
      this._cboxAOE = value;
    }
  }

  public bool cboxNMUutienself { get; set; }

  public bool cboxGiuVuKhi
  {
    get => this._cboxGiuVuKhi;
    set
    {
      if (this.AllInformationLoaded && this._cboxGiuVuKhi != value)
        this.SaveSingleSetting(nameof (cboxGiuVuKhi), value.ToString());
      this._cboxGiuVuKhi = value;
    }
  }

  public bool cboxDuY
  {
    get => this._cboxDuY;
    set
    {
      if (this.AllInformationLoaded && this._cboxDuY != value)
        this.SaveSingleSetting(nameof (cboxDuY), value.ToString());
      this._cboxDuY = value;
    }
  }

  public int numBHDMax
  {
    get => this._numBHDMax;
    set
    {
      if (this.AllInformationLoaded && this._numBHDMax != value)
        this.SaveSingleSetting(nameof (numBHDMax), value.ToString());
      this._numBHDMax = value;
    }
  }

  public int numBHDBanKinh
  {
    get => this._numBHDBanKinh;
    set
    {
      if (this.AllInformationLoaded && this._numBHDBanKinh != value)
        this.SaveSingleSetting(nameof (numBHDBanKinh), value.ToString());
      this._numBHDBanKinh = value;
    }
  }

  public bool cboxBTDPhuVe
  {
    get => this._cboxBTDPhuVe;
    set
    {
      if (this.AllInformationLoaded && this._cboxBTDPhuVe != value)
        this.SaveSingleSetting(nameof (cboxBTDPhuVe), value.ToString());
      this._cboxBTDPhuVe = value;
    }
  }

  public bool cboxTKCNhanh
  {
    get => this._cboxTKCNhanh;
    set
    {
      if (this.AllInformationLoaded && this._cboxTKCNhanh != value)
        this.SaveSingleSetting(nameof (cboxTKCNhanh), value.ToString());
      this._cboxTKCNhanh = value;
    }
  }

  public string PathPointSection
  {
    get => this._PathPointSection;
    set
    {
      if (this.AllInformationLoaded && this._PathPointSection != value)
        this.SaveSingleSetting(nameof (PathPointSection), value.ToString());
      this._PathPointSection = value;
    }
  }

  public bool cboxBTDXaPhu
  {
    get => this._cboxBTDXaPhu;
    set
    {
      if (this.AllInformationLoaded && this._cboxBTDXaPhu != value)
        this.SaveSingleSetting(nameof (cboxBTDXaPhu), value.ToString());
      this._cboxBTDXaPhu = value;
    }
  }

  public bool cboxPetList
  {
    get => this._cboxPetList;
    set
    {
      if (this.AllInformationLoaded && this._cboxPetList != value)
        this.SaveSingleSetting(nameof (cboxPetList), value.ToString());
      this._cboxPetList = value;
    }
  }

  public bool cboxNhatHop
  {
    get => this._cboxNhatHop;
    set
    {
      if (this.AllInformationLoaded && this._cboxNhatHop != value)
        this.SaveSingleSetting(nameof (cboxNhatHop), value.ToString());
      this._cboxNhatHop = value;
    }
  }

  public bool cboxNhanHop
  {
    get => this._cboxNhanHop;
    set
    {
      if (this.AllInformationLoaded && this._cboxNhanHop != value)
        this.SaveSingleSetting(nameof (cboxNhanHop), value.ToString());
      this._cboxNhanHop = value;
    }
  }

  public int cboBaoRuongMap
  {
    get => this._cboBaoRuongMap;
    set
    {
      if (this.AllInformationLoaded && this._cboBaoRuongMap != value)
        this.SaveSingleSetting(nameof (cboBaoRuongMap), value.ToString());
      this._cboBaoRuongMap = value;
    }
  }

  public bool cboxBRXaPhu
  {
    get => this._cboxBRXaPhu;
    set
    {
      if (this.AllInformationLoaded && this._cboxBRXaPhu != value)
        this.SaveSingleSetting(nameof (cboxBRXaPhu), value.ToString());
      this._cboxBRXaPhu = value;
    }
  }

  public bool cboxBRTLC
  {
    get => this._cboxBRTLC;
    set
    {
      if (this.AllInformationLoaded && this._cboxBRTLC != value)
        this.SaveSingleSetting(nameof (cboxBRTLC), value.ToString());
      this._cboxBRTLC = value;
    }
  }

  public bool cboxDongMon
  {
    get => this._cboxDongMon;
    set
    {
      if (this.AllInformationLoaded && this._cboxDongMon != value)
        this.SaveSingleSetting(nameof (cboxDongMon), value.ToString());
      this._cboxDongMon = value;
    }
  }

  public string cboItemCheDo
  {
    get => this._cboItemCheDo;
    set
    {
      if (this.AllInformationLoaded && this._cboItemCheDo != value)
        this.SaveSingleSetting(nameof (cboItemCheDo), value);
      this._cboItemCheDo = value;
    }
  }

  public string cboCheDoDTD
  {
    get => this._cboCheDoDTD;
    set
    {
      if (this.AllInformationLoaded && this._cboCheDoDTD != value)
        this.SaveSingleSetting(nameof (cboCheDoDTD), value);
      this._cboCheDoDTD = value;
    }
  }

  public int cboCheDoMap
  {
    get => this._cboCheDoMap;
    set
    {
      if (this.AllInformationLoaded && this._cboCheDoMap != value)
        this.SaveSingleSetting(nameof (cboCheDoMap), value.ToString());
      this._cboCheDoMap = value;
    }
  }

  public string cboCheDoXong
  {
    get => this._cboCheDoXong;
    set
    {
      if (this.AllInformationLoaded && this._cboCheDoXong != value)
        this.SaveSingleSetting(nameof (cboCheDoXong), value);
      this._cboCheDoXong = value;
    }
  }

  public int numCheDoAmount
  {
    get => this._numCheDoAmount;
    set
    {
      if (this.AllInformationLoaded && this._numCheDoAmount != value)
        this.SaveSingleSetting(nameof (numCheDoAmount), value.ToString());
      this._numCheDoAmount = value;
    }
  }

  public bool cboxHuyCheDo
  {
    get => this._cboxHuyCheDo;
    set
    {
      if (this.AllInformationLoaded && this._cboxHuyCheDo != value)
        this.SaveSingleSetting(nameof (cboxHuyCheDo), value.ToString());
      this._cboxHuyCheDo = value;
    }
  }

  public bool cboxBanChoNPC
  {
    get => this._cboxBanChoNPC;
    set
    {
      if (this.AllInformationLoaded && this._cboxBanChoNPC != value)
        this.SaveSingleSetting(nameof (cboxBanChoNPC), value.ToString());
      this._cboxBanChoNPC = value;
    }
  }

  public bool cboxHuyNLThua
  {
    get => this._cboxHuyNLThua;
    set
    {
      if (this.AllInformationLoaded && this._cboxHuyNLThua != value)
        this.SaveSingleSetting(nameof (cboxHuyNLThua), value.ToString());
      this._cboxHuyNLThua = value;
    }
  }

  public int numCheDoSao
  {
    get => this._numCheDoSao;
    set
    {
      if (this.AllInformationLoaded && this._numCheDoSao != value)
        this.SaveSingleSetting(nameof (numCheDoSao), value.ToString());
      this._numCheDoSao = value;
    }
  }

  public int numCheDoDong
  {
    get => this._numCheDoDong;
    set
    {
      if (this.AllInformationLoaded && this._numCheDoDong != value)
        this.SaveSingleSetting(nameof (numCheDoDong), value.ToString());
      this._numCheDoDong = value;
    }
  }

  public int numCheDoChiSo
  {
    get => this._numCheDoChiSo;
    set
    {
      if (this.AllInformationLoaded && this._numCheDoChiSo != value)
        this.SaveSingleSetting(nameof (numCheDoChiSo), value.ToString());
      this._numCheDoChiSo = value;
    }
  }

  public int numCheDoSLmua
  {
    get => this._numCheDoSLmua;
    set
    {
      if (this.AllInformationLoaded && this._numCheDoSLmua != value)
        this.SaveSingleSetting(nameof (numCheDoSLmua), value.ToString());
      this._numCheDoSLmua = value;
    }
  }

  public bool cboxGiu2DongTM
  {
    get => this._cboxGiu2DongTM;
    set
    {
      if (this.AllInformationLoaded && this._cboxGiu2DongTM != value)
        this.SaveSingleSetting(nameof (cboxGiu2DongTM), value.ToString());
      this._cboxGiu2DongTM = value;
    }
  }

  public string cboQ1Cau
  {
    get => this._cboQ1Cau;
    set
    {
      if (this.AllInformationLoaded && this._cboQ1Cau != value)
        this.SaveSingleSetting(nameof (cboQ1Cau), value);
      this._cboQ1Cau = value;
    }
  }

  public bool cboxTuHuyNV
  {
    get => this._cboxTuHuyNV;
    set
    {
      if (this.AllInformationLoaded && this._cboxTuHuyNV != value)
        this.SaveSingleSetting(nameof (cboxTuHuyNV), value.ToString());
      this._cboxTuHuyNV = value;
    }
  }

  public bool cboxHongQPT
  {
    get => this._cboxHongQPT;
    set
    {
      if (this.AllInformationLoaded && this._cboxHongQPT != value)
        this.SaveSingleSetting(nameof (cboxHongQPT), value.ToString());
      this._cboxHongQPT = value;
    }
  }

  public bool cboxDiTheoPP
  {
    get => this._cboxDiTheoPP;
    set
    {
      if (this.AllInformationLoaded && this._cboxDiTheoPP != value)
        this.SaveSingleSetting(nameof (cboxDiTheoPP), value.ToString());
      this._cboxDiTheoPP = value;
    }
  }

  public int numQ12ChoPT
  {
    get => this._numQ12ChoPT;
    set
    {
      if (this.AllInformationLoaded && this._numQ12ChoPT != value)
        this.SaveSingleSetting(nameof (numQ12ChoPT), value.ToString());
      this._numQ12ChoPT = value;
    }
  }

  public string cboQ12Xong
  {
    get => this._cboQ12Xong;
    set
    {
      if (this.AllInformationLoaded && this._cboQ12Xong != value)
        this.SaveSingleSetting(nameof (cboQ12Xong), value);
      this._cboQ12Xong = value;
    }
  }

  public bool cboxChoParty
  {
    get => this._cboxChoParty;
    set
    {
      if (this.AllInformationLoaded && this._cboxChoParty != value)
        this.SaveSingleSetting(nameof (cboxChoParty), value.ToString());
      this._cboxChoParty = value;
    }
  }

  public string cboLocDuoc
  {
    get => this._cboLocDuoc;
    set
    {
      if (this.AllInformationLoaded && this._cboLocDuoc != value)
        this.SaveSingleSetting(nameof (cboLocDuoc), value.ToString());
      this._cboLocDuoc = value;
    }
  }

  public bool cboxNMUutienboc
  {
    get => this._cboxNMUutienboc;
    set
    {
      if (this.AllInformationLoaded && this._cboxNMUutienboc != value)
        this.SaveSingleSetting(nameof (cboxNMUutienboc), value.ToString());
      this._cboxNMUutienboc = value;
    }
  }

  public bool cboxPKAnyOne
  {
    get => this._cboxPKAnyOne;
    set
    {
      if (this.AllInformationLoaded && this._cboxPKAnyOne != value)
        this.SaveSingleSetting(nameof (cboxPKAnyOne), value.ToString());
      this._cboxPKAnyOne = value;
    }
  }

  public bool cboxPKNgaMyFirst
  {
    get => this._cboxPKNgaMyFirst;
    set
    {
      if (this.AllInformationLoaded && this._cboxPKNgaMyFirst != value)
        this.SaveSingleSetting(nameof (cboxPKNgaMyFirst), value.ToString());
      this._cboxPKNgaMyFirst = value;
    }
  }

  public bool cboxPKThieuLamLast
  {
    get => this._cboxPKThieuLamLast;
    set
    {
      if (this.AllInformationLoaded && this._cboxPKThieuLamLast != value)
        this.SaveSingleSetting(nameof (cboxPKThieuLamLast), value.ToString());
      this._cboxPKThieuLamLast = value;
    }
  }

  public bool cboxPKPlayerList
  {
    get => this._cboxPKPlayerList;
    set
    {
      if (this.AllInformationLoaded && this._cboxPKPlayerList != value)
        this.SaveSingleSetting(nameof (cboxPKPlayerList), value.ToString());
      this._cboxPKPlayerList = value;
    }
  }

  public bool cboxPKBangList
  {
    get => this._cboxPKBangList;
    set
    {
      if (this.AllInformationLoaded && this._cboxPKBangList != value)
        this.SaveSingleSetting(nameof (cboxPKBangList), value.ToString());
      this._cboxPKBangList = value;
    }
  }

  public GAutoList<string> PKPlayerList
  {
    get => this._PKPlayerList;
    set => this._PKPlayerList = value;
  }

  public GAutoList<string> PKBlackList
  {
    get => this._PKBlackList;
    set => this._PKBlackList = value;
  }

  public GAutoList<int> PKBangList
  {
    get => this._PKBangList;
    set => this._PKBangList = value;
  }

  public int numGomMode
  {
    get => this._numGomMode;
    set
    {
      if (this.AllInformationLoaded && this._numGomMode != value)
        this.SaveSingleSetting(nameof (numGomMode), value.ToString());
      this._numGomMode = value;
    }
  }

  public bool cboxOnlyPet
  {
    get => this._cboxOnlyPet;
    set
    {
      if (this.AllInformationLoaded && this._cboxOnlyPet != value)
        this.SaveSingleSetting(nameof (cboxOnlyPet), value.ToString());
      this._cboxOnlyPet = value;
    }
  }

  public bool PTYeu
  {
    get => this._ptYeu;
    set
    {
      if (this.AllInformationLoaded && this._ptYeu != value)
        this.SaveSingleSetting(nameof (PTYeu), value.ToString());
      this._ptYeu = value;
    }
  }

  public bool cboxBlacklist
  {
    get => this._cboxBlacklist;
    set
    {
      if (this.AllInformationLoaded && this._cboxBlacklist != value)
        this.SaveSingleSetting(nameof (cboxBlacklist), value.ToString());
      this._cboxBlacklist = value;
    }
  }

  public bool ChatAlert
  {
    get => this._ChatAlert;
    set
    {
      if (this.AllInformationLoaded && this._ChatAlert != value)
        this.SaveSingleSetting(nameof (ChatAlert), value.ToString());
      this._ChatAlert = value;
    }
  }

  public int numBuffPhamVi
  {
    get => this._numBuffPhamVi;
    set
    {
      if (this.AllInformationLoaded && this._numBuffPhamVi != value)
        this.SaveSingleSetting(nameof (numBuffPhamVi), value.ToString());
      this._numBuffPhamVi = value;
    }
  }

  public bool cboxHuyNVDanhQuai
  {
    get => this._cboxHuyNVDanhQuai;
    set
    {
      if (this.AllInformationLoaded && this._cboxHuyNVDanhQuai != value)
        this.SaveSingleSetting(nameof (cboxHuyNVDanhQuai), value.ToString());
      this._cboxHuyNVDanhQuai = value;
    }
  }

  public bool cboxHuyNVNhatDo
  {
    get => this._cboxHuyNVNhatDo;
    set
    {
      if (this.AllInformationLoaded && this._cboxHuyNVNhatDo != value)
        this.SaveSingleSetting(nameof (cboxHuyNVNhatDo), value.ToString());
      this._cboxHuyNVNhatDo = value;
    }
  }

  public bool cboxThuHoachHoaChinhMinh
  {
    get => this._cboxThuHoachHoaChinhMinh;
    set
    {
      if (this.AllInformationLoaded && this._cboxThuHoachHoaChinhMinh != value)
        this.SaveSingleSetting(nameof (cboxThuHoachHoaChinhMinh), value.ToString());
      this._cboxThuHoachHoaChinhMinh = value;
    }
  }

  public bool cboxBHDThoatKhiXong
  {
    get => this._cboxBHDThoatKhiXong;
    set
    {
      if (this.AllInformationLoaded && this._cboxBHDThoatKhiXong != value)
        this.SaveSingleSetting(nameof (cboxBHDThoatKhiXong), value.ToString());
      this._cboxBHDThoatKhiXong = value;
    }
  }

  public bool cboxNhatTuyetDungIm
  {
    get => this._cboxNhatTuyetDungIm;
    set
    {
      if (this.AllInformationLoaded && this._cboxNhatTuyetDungIm != value)
        this.SaveSingleSetting(nameof (cboxNhatTuyetDungIm), value.ToString());
      this._cboxNhatTuyetDungIm = value;
    }
  }

  public bool FixLoiCuongChe
  {
    get => this._FixLoiCuongChe;
    set
    {
      if (this.AllInformationLoaded && this._FixLoiCuongChe != value)
        this.SaveSingleSetting(nameof (FixLoiCuongChe), value.ToString());
      this._FixLoiCuongChe = value;
    }
  }

  public bool cboxKyCuocNhanh
  {
    get => this._cboxKyCuocNhanh;
    set
    {
      if (this.AllInformationLoaded && this._cboxKyCuocNhanh != value)
        this.SaveSingleSetting(nameof (cboxKyCuocNhanh), value.ToString());
      this._cboxKyCuocNhanh = value;
    }
  }

  public bool cboxLLTBNhanh
  {
    get => this._cboxLLTBNhanh;
    set
    {
      if (this.AllInformationLoaded && this._cboxLLTBNhanh != value)
        this.SaveSingleSetting(nameof (cboxLLTBNhanh), value.ToString());
      this._cboxLLTBNhanh = value;
    }
  }

  public bool menuTestGame
  {
    get => this._menuTestGame;
    set
    {
      if (this.AllInformationLoaded && this._menuTestGame != value)
        this.SaveSingleSetting(nameof (menuTestGame), value.ToString());
      this._menuTestGame = value;
    }
  }

  public bool cboxTiepTucNhiemVuNgay
  {
    get => this._cboxTiepTucNhiemVuNgay;
    set
    {
      if (this.AllInformationLoaded && this._cboxTiepTucNhiemVuNgay != value)
        this.SaveSingleSetting(nameof (cboxTiepTucNhiemVuNgay), value.ToString());
      this._cboxTiepTucNhiemVuNgay = value;
    }
  }
}
