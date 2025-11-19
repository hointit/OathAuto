// Decompiled with JetBrains decompiler
// Type: SmartBot.GGameMemory
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System.Collections.Generic;

#nullable disable
namespace SmartBot;

public class GGameMemory
{
  public bool IsFilled;
  public string GameHash = "";
  public string GameKey = "";
  public List<string> GameVersionCode = new List<string>();
  public bool IsLocalLoaded;
  public List<GPattern> Patterns = new List<GPattern>();
  public List<GMemBase> Membases = new List<GMemBase>();
  public List<GReadMem> Readmems = new List<GReadMem>();
  public List<GOpcode> Opcodes = new List<GOpcode>();
  public int ProcessID;
  public long FirstSeen;
}
