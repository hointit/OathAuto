// Decompiled with JetBrains decompiler
// Type: SmartBot.ActiveBocItems
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

#nullable disable
namespace SmartBot;

public class ActiveBocItems
{
  private int ClassSize = 13;
  private TargetProcess localTarget;

  public void Initialize(TargetProcess _tempTarget) => this.localTarget = _tempTarget;

  private bool EverythingOK() => true;

  public unsafe ItemTrongBoc this[int index]
  {
    get
    {
      ItemTrongBoc itemTrongBoc = new ItemTrongBoc();
      if (this.EverythingOK())
      {
        int index1 = 24 + this.ClassSize * index;
        itemTrongBoc.itemGUID1 = GABitConverter.ToInt32(this.localTarget._BocRef, index1);
        itemTrongBoc.itemGUID2 = GABitConverter.ToInt32(this.localTarget._BocRef, index1 + 4);
        itemTrongBoc.ItemID = GABitConverter.ToInt32(this.localTarget._BocRef, index1 + 8);
        itemTrongBoc.Picked = this.localTarget._BocRef[index1 + 12] != (byte) 0;
      }
      return itemTrongBoc;
    }
  }
}
