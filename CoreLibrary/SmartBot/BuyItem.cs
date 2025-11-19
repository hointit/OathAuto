// Decompiled with JetBrains decompiler
// Type: SmartBot.BuyItem
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

#nullable disable
namespace SmartBot;

public class BuyItem
{
  public string SlotID = "";
  public string Key = "";
  public string Desc = "";
  public double Price;
  public int TimeCount;
  public string TimeCountUnit = "day";
  public int UnitCount;
  public string UnitCountUnit = "player";
  public int Index;

  public string Comment
  {
    get
    {
      return $"{this.TimeCount.ToString("0")} {this.TimeCountUnit} {this.UnitCount.ToString("0")} {this.UnitCountUnit}";
    }
  }
}
