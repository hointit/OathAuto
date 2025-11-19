// Decompiled with JetBrains decompiler
// Type: SmartBot.GScriptCommand
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System.Collections.Generic;

#nullable disable
namespace SmartBot;

public class GScriptCommand
{
  public AllEnums.ScriptStatuses Status;
  public AllEnums.ScriptStatuses MinorStatus;
  public string Command = "";
  public int Delay;
  public List<object> Params = new List<object>();

  public int Count => this.Params != null ? this.Params.Count : 0;
}
