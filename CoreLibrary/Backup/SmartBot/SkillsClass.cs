// Decompiled with JetBrains decompiler
// Type: SmartBot.SkillsClass
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System.Collections.Generic;

#nullable disable
namespace SmartBot;

public class SkillsClass
{
  private TargetProcess localTarget;
  public List<SkillBufferItem> SkillBuffer = new List<SkillBufferItem>();
  public List<SkillPlayItem> SkillBuffList = new List<SkillPlayItem>();
  public List<SkillItemDelay> SkillDelays = new List<SkillItemDelay>()
  {
    new SkillItemDelay() { SkillBook = 1, BookSlot = 2 },
    new SkillItemDelay() { SkillBook = 1, BookSlot = 3 },
    new SkillItemDelay() { SkillBook = 2, BookSlot = 1 },
    new SkillItemDelay() { SkillBook = 2, BookSlot = 2 },
    new SkillItemDelay() { SkillBook = 2, BookSlot = 3 },
    new SkillItemDelay() { SkillBook = 2, BookSlot = 4 },
    new SkillItemDelay() { SkillBook = 3, BookSlot = 1 },
    new SkillItemDelay() { SkillBook = 3, BookSlot = 2 },
    new SkillItemDelay() { SkillBook = 3, BookSlot = 3 },
    new SkillItemDelay() { SkillBook = 4, BookSlot = 2 },
    new SkillItemDelay() { SkillBook = 4, BookSlot = 3 },
    new SkillItemDelay() { SkillBook = 4, BookSlot = 4 },
    new SkillItemDelay() { SkillBook = 5, BookSlot = 2 },
    new SkillItemDelay() { SkillBook = 5, BookSlot = 3 },
    new SkillItemDelay() { SkillBook = 5, BookSlot = 4 },
    new SkillItemDelay() { SkillBook = 6, BookSlot = 1 },
    new SkillItemDelay() { SkillBook = 6, BookSlot = 2 },
    new SkillItemDelay() { SkillBook = 6, BookSlot = 3 },
    new SkillItemDelay() { SkillBook = 7, BookSlot = 1 },
    new SkillItemDelay() { SkillBook = 7, BookSlot = 2 },
    new SkillItemDelay() { SkillBook = 7, BookSlot = 3 },
    new SkillItemDelay() { SkillBook = 8, BookSlot = 1 },
    new SkillItemDelay() { SkillBook = 8, BookSlot = 2 },
    new SkillItemDelay() { SkillBook = 99, BookSlot = 1 },
    new SkillItemDelay() { SkillBook = 99, BookSlot = 4 },
    new SkillItemDelay() { SkillBook = 99, BookSlot = 5 },
    new SkillItemDelay() { SkillBook = 99, BookSlot = 7 }
  };
  public List<int> IDChangeList = new List<int>();
  public List<SingleSkill> AllSkills = new List<SingleSkill>(51);
  public long usePhatQuangStamp;
  public int XungHuDelay;
  public int ThanhTamDelay;
  public int HoiSinhDelay;
  public int ChayNhanhDelay1;
  public int ChayNhanhDelay2;
  public int ChayNhanhDelay3;
  public int tempBasicSkill = 999;
  public int PhuDaiLyDelay;
  public bool LoadSkills;
  public int KhinhCongID;

  public void Initialize(TargetProcess _tempTarget) => this.localTarget = _tempTarget;

  public SkillsClass()
  {
    for (int index = 0; index < 51; ++index)
      this.AllSkills.Add(new SingleSkill());
  }

  private bool EverythingOK() => true;

  public bool HasSkill(int SkillID)
  {
    if (SkillID > 0 && SkillID < -1 && this.AllSkills.Count > 0)
    {
      for (int index = 0; index < this.AllSkills.Count; ++index)
      {
        if (this.AllSkills[index].ID == SkillID)
          return true;
      }
    }
    return false;
  }

  public int GetRemainWaitingTime(int skillID)
  {
    if (skillID > 0 && skillID < -1 && this.AllSkills.Count > 0)
    {
      for (int index = 0; index < this.AllSkills.Count; ++index)
      {
        SingleSkill allSkill = this.AllSkills[index];
        if (allSkill.ID == skillID)
          return allSkill.RemainWaitingTime;
      }
    }
    return 0;
  }

  public void SetRemainingTime(int skillID, int myTime)
  {
    if (skillID <= 0 || skillID >= -1 || this.AllSkills.Count <= 0)
      return;
    for (int index = 0; index < this.AllSkills.Count; ++index)
    {
      SingleSkill allSkill = this.AllSkills[index];
      if (allSkill.ID == skillID)
        allSkill.RemainWaitingTime = myTime;
    }
  }
}
