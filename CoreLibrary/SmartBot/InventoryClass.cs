// Decompiled with JetBrains decompiler
// Type: SmartBot.InventoryClass
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System.Collections.Generic;

#nullable disable
namespace SmartBot;

public class InventoryClass
{
  private int ClassSize = 33;
  private TargetProcess localTarget;
  public List<int> CheckItemBuffer = new List<int>();
  public string tempName = "";
  public string tempType = "";
  public List<InventoryItem> AllItems = new List<InventoryItem>();
  public string HPItemAte = "Chưa ăn món nào";

  public void Initialize(TargetProcess _tempTarget) => this.localTarget = _tempTarget;

  public InventoryClass()
  {
    for (int index = 0; index < 90; ++index)
      this.AllItems.Add(new InventoryItem());
  }

  private bool EverythingOK() => true;
}
