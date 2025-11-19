// Decompiled with JetBrains decompiler
// Type: SmartBot.TNNPCShopClass
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System;
using System.Collections.Generic;

#nullable disable
namespace SmartBot;

public class TNNPCShopClass
{
  private int ClassSize = 12;
  private int InventoryClassSize = 33;
  private TargetProcess localTarget;
  private List<TNNPCShopItem> AllTNNPCItems = new List<TNNPCShopItem>();

  public TNNPCShopClass(TargetProcess _tempTarget)
  {
    this.localTarget = _tempTarget;
    for (int index = 0; index < 12; ++index)
      this.AllTNNPCItems.Add(new TNNPCShopItem());
  }

  private unsafe bool EverythingOK()
  {
    return (IntPtr) (void*) this.localTarget._InventoryRef != IntPtr.Zero;
  }
}
