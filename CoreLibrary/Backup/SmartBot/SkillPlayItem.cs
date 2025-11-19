// Decompiled with JetBrains decompiler
// Type: SmartBot.SkillPlayItem
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

#nullable disable
namespace SmartBot;

public class SkillPlayItem
{
  public SingleSkill SkillItem;
  public bool Played;
  public int SkillDelayInSecond = 1;
  public long LastPlayTimeStamp;
  public bool IsEnabled = true;
  public int WaitingTime = 1;
  public bool BuffSelf = true;
  public bool BuffParty;
  public bool BuffList;
  public bool BuffArmy;
  public string SkillButton = "";
  public GAutoList<BuffedPlayer> BuffPlayerList = new GAutoList<BuffedPlayer>();
}
