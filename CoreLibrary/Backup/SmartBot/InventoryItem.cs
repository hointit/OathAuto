// Decompiled with JetBrains decompiler
// Type: SmartBot.InventoryItem
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System.Collections.Generic;

#nullable disable
namespace SmartBot;

public class InventoryItem
{
  public int ItemID = -1;
  public bool NeedToWait;
  public int BuyingPrice;
  public int SellingPrice;
  public double RealSpread;
  public double MidSpread;
  public double HighSpread;
  public double LowSpread;
  public bool HasHistory;
  public byte ItemCount;
  public string ItemName = "";
  public int SaveNameCode;
  public int ItemGUID1;
  public int ItemGUID2;
  public byte Lines;
  public List<int> LineValueArray = new List<int>();
  public int SavedCode;
  public string ItemType = "";
  public byte ItemStars;
  public AllEnums.ItemSources ItemSource;
  public byte DinhViPhuTime;
  public int ItemMapID;
  public int BTDMapID;
  public int BTDposX;
  public int BTDposY;
  public long LastTimeSeen;
}
