// Decompiled with JetBrains decompiler
// Type: SmartBot.ItemToBuy
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

#nullable disable
namespace SmartBot;

public class ItemToBuy
{
  public string Name = "";
  public int ID;
  public AllEnums.BuyingItemTypes NPCType = AllEnums.BuyingItemTypes.Dược;
  public int MenuKNB1;
  public int MenuKNB2;
  public int MenuIndex;
  public int Amount = 20;
  public int RealAmountToBuy;
  public long buyStamp;
  public int buyStampMax;
  public int invenCount;
}
