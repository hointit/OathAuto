// Decompiled with JetBrains decompiler
// Type: SmartBot.PriceItem
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

#nullable disable
namespace SmartBot;

public class PriceItem
{
  public string Key = "time";
  public int Slot = 1;
  public string SlotUnit = "day";
  public int SlotCount = 99;
  public string SlotCountUnit = "player";
  public double Price;
  public string Desc = "";
  public string TimeUnitShort = "";

  public string PriceDisplay
  {
    get
    {
      string str = this.Price.ToString("0.0");
      return str.Contains(".0") ? this.Price.ToString("0") : str;
    }
  }

  public string ShortDisplay
  {
    get
    {
      string str = "nhân vật";
      if (this.SlotCountUnit == "party")
        str = "party";
      return $"{this.SlotCount.ToString()} {str}";
    }
  }

  public string ItemDisplay
  {
    get
    {
      string str1 = this.Price.ToString("0.0") + " GG";
      if (str1.Contains(".0"))
        str1 = this.Price.ToString("0") + " GG";
      if (this.Price >= 500.0)
        str1 = "x GG";
      string str2 = GA.TranslateTNKey(this.Key);
      string str3 = !(this.SlotUnit == "day") || this.Slot != 30 ? (!(this.SlotUnit == "day") || this.Slot != 90 ? (!(this.SlotUnit == "day") || this.Slot != 180 ? (!(this.SlotUnit == "day") || this.Slot != 365 ? (!(this.SlotUnit == "day") || this.Slot != 9999 ? this.Slot.ToString("0") + " ngày" : "Vĩnh viễn") : "1 năm") : "6 tháng") : "3 tháng") : "1 tháng";
      if (this.SlotUnit == "hour")
        str3 = this.Slot.ToString() + " giờ";
      string itemDisplay;
      if (this.Key == "time")
      {
        itemDisplay = $"{str3} -- {str1}";
      }
      else
      {
        string str4 = !(this.SlotCountUnit == "party") ? (!(this.SlotCountUnit == "player") ? this.SlotCount.ToString() + " unit" : this.SlotCount.ToString() + " nv") : this.SlotCount.ToString() + " pt";
        if (this.SlotCount > 0)
          itemDisplay = $"{str2}, {str3} {str4} -- {str1:n1}";
        else
          itemDisplay = $"{this.Desc} {str1:n1}";
      }
      return itemDisplay;
    }
  }
}
