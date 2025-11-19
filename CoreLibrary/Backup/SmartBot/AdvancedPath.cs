// Decompiled with JetBrains decompiler
// Type: SmartBot.AdvancedPath
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System.Collections.Generic;

#nullable disable
namespace SmartBot;

public class AdvancedPath
{
  public AdvancedPath PreviousPath;
  public List<AdvancedPath> Neighbors;
  public double Cost = double.PositiveInfinity;
  public int MapID = -1;
  public string MapName = "";
  public AllEnums.GateTypes GateType;
  public int GatePosX = -1;
  public int GatePosY = -1;
  public int NPC_ID = -1;
  public int NPCMenuTypeID_1 = -1;
  public int NPCMenuIndex_1 = -1;
  public int NPCMenuTypeID_2 = -1;
  public int NPCMenuIndex_2 = -1;
  public int NPCMenuTypeID_3 = -1;
  public int NPCMenuIndex_3 = -1;
  public int NPCMenuType_4 = -1;
  public int NPCMenuIndex_4 = -1;
  public bool PortalConfirm;
  public int ToMapID = -1;
  public string ToMapName = "";
  public int ToMapX = -1;
  public int TempToX = -1;
  public int TempToY = -1;
  public int ToMapY = -1;
  public string Reserved_1 = "";
  public string Reserved_2 = "";

  public AdvancedPath() => this.Neighbors = new List<AdvancedPath>();

  public bool IsVisited { get; set; }

  public bool LUASupport { get; set; }
}
