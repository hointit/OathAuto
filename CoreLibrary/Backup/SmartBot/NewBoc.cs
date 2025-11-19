// Decompiled with JetBrains decompiler
// Type: SmartBot.NewBoc
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

#nullable disable
namespace SmartBot;

public class NewBoc
{
  public int PrevBocID;
  public int BocID;
  public float PosX;
  public float PosY;
  public int BocType;
  public long LastTimeSeen;
  public int OwnerDatabaseID;
  public int OwnerDatabaseIDLow;
  public bool IsQuaXa;
  public long QuaXaStamp;

  public string BocIDHex => GA.ConvertIntToHex(this.BocID, true);

  public bool Picked => this.BocID == 0 || this.BocID == this.PrevBocID;
}
