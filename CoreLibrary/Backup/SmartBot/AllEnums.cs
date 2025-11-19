// Decompiled with JetBrains decompiler
// Type: SmartBot.AllEnums
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System.ComponentModel;

#nullable disable
namespace SmartBot;

public abstract class AllEnums : INotifyPropertyChanged
{
  public event PropertyChangedEventHandler PropertyChanged;

  protected void OnPropertyChanged(string propertyName)
  {
    PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
    if (propertyChanged == null)
      return;
    propertyChanged((object) this, new PropertyChangedEventArgs(propertyName));
  }

  public enum LogActions
  {
    NhanPhieu = 1,
    MuaTN = 2,
    BanTN = 3,
    TraPhieu = 4,
    NgatKetNoi = 5,
    ChetDiaPhu = 6,
    SavePKName = 7,
    None = 8,
    PKKilled = 9,
  }

  public enum ScriptStatuses
  {
    IDLE = 0,
    RUNNING = 2,
    FINISHED = 4,
    LOADED = 5,
  }

  public enum InjectionStatus
  {
    FoundProcess,
    Started,
    Injected,
    ThreadStarted,
    Ejected,
  }

  public enum NPCStates
  {
    RUNNING,
    FIGHTING,
    WALKING,
    STALLING,
    MEDITATING,
    TRADING,
    MOUTING,
    IDLE,
  }

  public enum NPCTypes
  {
    SELF,
    PLAYERS,
    NPC,
    MOBS,
  }

  public enum NgaMyBuffModes
  {
    BuffSelfOnly,
    BuffParty,
  }

  public enum GateTypes
  {
    NPC,
    Portal,
  }

  public enum ItemSources
  {
    Chưa_biết = 0,
    Đồ_nhặt = 1,
    Đồ_full = 2,
    Đồ_Quest = 3,
    Đồ_cần_GĐ = 21, // 0x00000015
    Đồ_Chế = 22, // 0x00000016
  }

  public enum AutoModes
  {
    Lite = 5,
    Deluxe = 4088, // 0x00000FF8
    Pro = 1045820, // 0x000FF53C
  }

  public enum PetActions
  {
    XuatChien = 1,
    CS_HT = 2,
  }

  public enum ActionResults
  {
    NORMAL,
    MTVOHIEU,
    THANHCONG,
  }

  public enum CharTypes
  {
    TANKER,
    NUKER,
  }

  public enum Menpais
  {
    THIEULAM = 0,
    [Description("Minh Giáo")] MINHGIAO = 1,
    CAIBANG = 2,
    VODANG = 3,
    [Description("Nga My")] NGAMI = 4,
    TINHTUC = 5,
    THIENLONG = 6,
    THIENSON = 7,
    [Description("Tiêu Dao")] TIEUDAO = 8,
    [Description("Chưa vào phái")] NOMENPAI = 9,
    MODUNG = 10, // 0x0000000A
    DUONGMON = 11, // 0x0000000B
    QUYCOC = 12, // 0x0000000C
    ALLPHAI = 99, // 0x00000063
  }

  public enum BuyingItemTypes
  {
    Dược = 1,
    Thú = 2,
    KNB = 3,
  }

  public enum CharStatuses
  {
    IDLE = 0,
    REG_MOVE = 2,
    MOUNT = 100, // 0x00000064
    EATING = 101, // 0x00000065
    STALLING = 102, // 0x00000066
    SEND_SKILL = 200, // 0x000000C8
    CLEAN_INVENTORY = 201, // 0x000000C9
    MOVE_TO_TARGET = 205, // 0x000000CD
    GOGOGO = 250, // 0x000000FA
    NHATBOC = 251, // 0x000000FB
    VETHANH = 350, // 0x0000015E
    NMBUFFMAU = 351, // 0x0000015F
    SELLING_NPC = 352, // 0x00000160
    BUYING_NPC = 353, // 0x00000161
    LENLAIBAITRAIN = 354, // 0x00000162
    RUNNING_THUONGNHAN = 9996, // 0x0000270C
    MOVE_LONG_PATH = 9997, // 0x0000270D
    PET_HEALING = 9998, // 0x0000270E
    SELF_HEALING = 9999, // 0x0000270F
    TRIEUTAP = 10000, // 0x00002710
    TRIEUTAPNOW = 10001, // 0x00002711
    DUNGPHUDIVE = 10002, // 0x00002712
  }

  public enum AfterDeathSettings
  {
    ExitGame,
    BackToTrainSpot,
    HappyTea,
  }

  public enum NhatItemModes
  {
    NHATHET,
    NHATLIST,
    NHATLOAITRU,
  }

  public enum FightingModes
  {
    DANHTUNGCON,
    DANHGOMQUAI,
    DANHPETONLY,
  }

  public enum TraderModes
  {
    Chạy_Đi,
    Chạy_Về,
    Chạy_Full_Trip,
    Về_Thành_Lớn,
    IDLE,
    SellBuy,
  }

  public enum AIModes
  {
    DANHQUANHDIEM,
    DANHTUDO,
    HOTRO,
    KHAIKHOANG_HAIDUOC,
    TRONGTROT,
    THUONGNHAN,
    SCRIPTING,
    NHIEMVU,
  }
}
