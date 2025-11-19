// Decompiled with JetBrains decompiler
// Type: SmartBot.GAutoList`1
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System;
using System.Collections.Generic;

#nullable disable
namespace SmartBot;

public class GAutoList<T> : List<T>
{
  public event EventHandler OnAdd;

  public event EventHandler OnRemove;

  public void Remove(T item)
  {
    base.Remove(item);
    if (this.OnRemove == null)
      return;
    this.OnRemove((object) this, (EventArgs) null);
  }

  public new void Add(T item)
  {
    base.Add(item);
    if (this.OnAdd == null)
      return;
    this.OnAdd((object) this, (EventArgs) null);
  }
}
