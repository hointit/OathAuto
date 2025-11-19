// Decompiled with JetBrains decompiler
// Type: SmartBot.QuaiIndividual
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

#nullable disable
namespace SmartBot;

public class QuaiIndividual
{
  public int ID = -1;
  public int HPPointer;
  public int DatabaseID;
  public float PosX;
  public float PosY;
  public float ToX;
  public float ToY;
  public int OwnerID;
  public int HPValue;
  public string Name = "";
  public string DanhHieu = "";
  public float HPPercent;
  public byte CanAttack;
  public byte HPStolen;
  public float MPPercent;
  public byte RagePercent;
  public byte CastleID;
  public int Level;
  public byte Type;
  public byte NullData;
  public byte KSMode;
  public byte PKMode;
  public bool IsHitByMe;
  public int NPCVal1;
  public int NPCVal2;
  public int NPCVal3;
  public int MapID = -1;
  public byte QuaiType;
  public int BangID = -1;
  public int Menpai;
  public int Rage;
  public byte JustHit;
  public int TaoHitStamp;
  public bool TaoHit;
  public int IsBossValue;
  public long LastHitStamp;
  public long LastTimeSeen;
  public long noAttackStamp;

  public string IDHex => GA.ConvertIntToHex(this.ID, true);

  public string CanAttackHex => GA.ConvertIntToHex((int) this.CanAttack, true);
}
