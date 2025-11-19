// Decompiled with JetBrains decompiler
// Type: SmartBot.SinglePetClass
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

#nullable disable
namespace SmartBot;

public class SinglePetClass
{
  public int HP;
  public int MaxHP;
  public int Happiness;
  public int ID;
  public int Level;
  public string PetName = "";
  public int DatabaseID = -1;
  public int PetOwnerDBID;
  public int KhaiDuongDelay = 9999;
  public int PetSkill1;
  public int PetSkill2;
  public int PetSkill3;
  public int PetSkill4;
  public int PhaQuanDelay = 9999;

  public string IDHex => GA.ConvertIntToHex(this.ID, true);

  public string DatabaseIDHex => GA.ConvertIntToHex(this.DatabaseID, true);

  public string PetGUIDHex => GA.ConvertIntToHex(this.PetOwnerDBID, true);

  public double HPPercent => this.MaxHP > 0 ? (double) this.HP * 100.0 / (double) this.MaxHP : 0.0;
}
