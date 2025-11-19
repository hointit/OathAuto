// Decompiled with JetBrains decompiler
// Type: SmartBot.QuaiClass
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System;
using System.Collections.Generic;

#nullable disable
namespace SmartBot;

public class QuaiClass
{
  private int ClassSize = 140;
  private TargetProcess localTarget;
  public List<int> PreviousTargetID = new List<int>() { -1 };
  public int CurrentIDIndex;
  public int TargetID = -1;
  public int TargetIDforPK = -1;
  public int CanAttackInt;
  public float TargetHPPercent;
  public List<QuaiIndividual> AllQuai;
  public int SavedTargetID = -1;
  public long SavedTargetStamp;
  public List<string> noAttackArray = new List<string>();
  public List<string> FirstAttackArray = new List<string>();
  public List<int> IgnoredQuaiID = new List<int>();

  public void Initialize(TargetProcess _tempTarget) => this.localTarget = _tempTarget;

  public QuaiClass() => this.AllQuai = new List<QuaiIndividual>();

  private unsafe bool EverythingOK()
  {
    return this.localTarget == null || (IntPtr) (void*) this.localTarget._NPCRef != IntPtr.Zero;
  }

  public string TargetIDHex => GA.ConvertIntToHex(this.TargetID, true);

  public QuaiIndividual GetQuaiByID(int id, bool checkHP = false)
  {
    if (this.AllQuai.Count > 0)
    {
      try
      {
        for (int index = this.AllQuai.Count - 1; index >= 0; --index)
        {
          QuaiIndividual quaiIndividual = this.AllQuai[index];
          if (quaiIndividual.ID == id)
            return !checkHP || (double) quaiIndividual.HPPercent > 0.0 ? quaiIndividual : (QuaiIndividual) null;
        }
      }
      catch (Exception ex)
      {
      }
    }
    return (QuaiIndividual) null;
  }
}
