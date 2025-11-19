// Decompiled with JetBrains decompiler
// Type: SmartBot.GScript
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System;
using System.Collections.Generic;

#nullable disable
namespace SmartBot;

public class GScript
{
  public Dictionary<string, object> ScriptOptions = new Dictionary<string, object>();
  public string Author = "GAuto Team";
  public DateTime Date = DateTime.Now;
  public string AuthorURL = "http://www.gameauto.net";
  public List<GScriptCommand> Commands = new List<GScriptCommand>();
  public List<GScriptCommand> CommandMinors = new List<GScriptCommand>();
  public List<string> CommandRel = new List<string>();
  public AllEnums.ScriptStatuses Status;

  public bool Ready => this.ScriptOptions.Count > 0 || this.Commands.Count > 0;

  public int Count => this.Commands != null ? this.Commands.Count : 0;

  public object GetOption(string key)
  {
    object option = (object) null;
    if (this.ScriptOptions.Count > 0 && this.ScriptOptions.ContainsKey(key.ToLower()))
      option = this.ScriptOptions[key.ToLower()];
    return option;
  }
}
