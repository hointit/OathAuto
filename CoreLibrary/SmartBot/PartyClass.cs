// Decompiled with JetBrains decompiler
// Type: SmartBot.PartyClass
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System;
using System.Collections.Generic;

#nullable disable
namespace SmartBot;

public class PartyClass
{
  private int ClassSize = 66;
  private TargetProcess localTarget;
  public int PartyNumbers;
  public int PartyNumbers_Saved;
  public int PartyNumbers_Counter;
  public int PTAskDBAsked;
  public int PTAskDBAskedLow;
  public int PTAskDBAsker;
  public int PTAskDBAskerLow;
  public int PTAskLevel;
  public int PTAskSequence = -1;
  public int PTAskMenpai = 9;
  public long LastTimeSeenInvite;
  public string PTAskName = "";
  public List<PartyMember> AllMembers = new List<PartyMember>();
  public string Name = "";
  public int InviterDB;
  public int InviterDBLow;
  public int PartyCount;
  public int InviterLevel;
  public int NotInAutoCount;

  public void Initialize(TargetProcess _tempTarget) => this.localTarget = _tempTarget;

  public PartyClass()
  {
    for (int index = 0; index < 6; ++index)
      this.AllMembers.Add(new PartyMember());
  }

  private unsafe bool EverythingOK()
  {
    return this.localTarget == null || (IntPtr) (void*) this.localTarget._PartyRef != IntPtr.Zero;
  }
}
