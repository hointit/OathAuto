// Decompiled with JetBrains decompiler
// Type: SmartBot.LicenseSlot
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System;

#nullable disable
namespace SmartBot;

public class LicenseSlot
{
  public bool Renew = true;
  public string SlotID = "-1";
  public string SlotUnit = "hour";
  public string SlotCountUnit = "player";
  public int SlotCount;
  public string TNkey = "";
  public string CharName = "";
  public DateTime exp = DateTime.MinValue;
  public long expms;

  public string TNDisplay
  {
    get
    {
      if (this.TNkey == "chedo")
      {
        switch (frmLogin.CompilingLanguage)
        {
          case "VN":
            return "Chế đồ";
          case "EN":
            return "Crafting";
          default:
            return "Chế đồ CN";
        }
      }
      else if (this.TNkey == "yto")
      {
        switch (frmLogin.CompilingLanguage)
        {
          case "VN":
            return "Yến Tử Ổ";
          case "EN":
            return "Shallow Deck";
          default:
            return "Yến Tử Ổ CN";
        }
      }
      else
      {
        if (!(this.TNkey == "trader"))
          return "Chưa rõ";
        switch (frmLogin.CompilingLanguage)
        {
          case "VN":
            return "Thương Nhân";
          case "EN":
            return "Trader";
          default:
            return "Thương Nhân CN";
        }
      }
    }
  }
}
