// Decompiled with JetBrains decompiler
// Type: SmartBot.ArmyClass
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System.Collections.Generic;

#nullable disable
namespace SmartBot;

public class ArmyClass
{
  private int ClassSize = 66;
  private TargetProcess localTarget;
  public List<PartyMember> AllMembers = new List<PartyMember>(30);

  public void Initialize(TargetProcess _tempTarget) => this.localTarget = _tempTarget;

  public ArmyClass()
  {
    for (int index = 0; index < 30; ++index)
      this.AllMembers.Add(new PartyMember());
  }

  private bool EverythingOK() => true;

  public bool HasQuanDoan
  {
    get
    {
      if (this.AllMembers.Count > 0)
      {
        for (int index = 0; index < 30; ++index)
        {
          if (this.AllMembers[index].DatabaseID != 0)
            return true;
        }
      }
      return false;
    }
  }
}
