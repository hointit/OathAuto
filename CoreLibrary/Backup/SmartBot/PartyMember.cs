// Decompiled with JetBrains decompiler
// Type: SmartBot.PartyMember
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

#nullable disable
namespace SmartBot;

public class PartyMember
{
  public int DatabaseID;
  public int DatabaseIDLow;
  public int ID;
  public int MapID;
  public int HP;
  public int MaxHP;
  public int Menpai = 9;
  public int Level;
  public float PosX;
  public float PosY;
  public string Name = "";
  public bool flagPartyFollowed;

  public string IDHex => GA.ConvertIntToHex(this.ID, true);

  public double HPPercent => this.MaxHP > 0 ? (double) this.HP * 100.0 / (double) this.MaxHP : 0.0;
}
