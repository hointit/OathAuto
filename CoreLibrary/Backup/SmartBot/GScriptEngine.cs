// Decompiled with JetBrains decompiler
// Type: SmartBot.GScriptEngine
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System.Collections.Generic;

#nullable disable
namespace SmartBot;

public class GScriptEngine
{
  public bool IsOn;
  public GScript RunningScript;
  public GScript Script;
  public List<GScript> MinorScript = new List<GScript>();
  public bool IsRunningMinorScript;
  public GScriptCommand SingleCommand;
  public int Index;
  public GScriptCommand CurrentCommand;
  public GScriptCommand MinorCommand;
  public int RunTimes;

  public bool HasSingleCommand => this.SingleCommand != null;

  public bool CanCallCurrent => this.Script != null && this.Index < this.Script.Count;

  public bool CanCallNext => this.Script != null && this.Index < this.Script.Count - 1;

  public void ResetRunTimes() => this.RunTimes = 0;

  public void TurnOn() => this.IsOn = true;

  public void TurnOff() => this.IsOn = false;

  public void JumpToFirst()
  {
    this.Index = 0;
    if (this.Script == null)
      return;
    for (int index = 0; index < this.Script.Count; ++index)
    {
      this.Script.Commands[index].Status = AllEnums.ScriptStatuses.IDLE;
      this.Script.Commands[index].MinorStatus = AllEnums.ScriptStatuses.IDLE;
    }
  }

  public GScriptCommand GetCurrentCommand()
  {
    GScriptCommand currentCommand = (GScriptCommand) null;
    if (this.Script != null && this.Index < this.Script.Count)
      currentCommand = this.Script.Commands[this.Index];
    return currentCommand;
  }

  public void IndexInc() => ++this.Index;

  public void Reset()
  {
    for (int index = 0; index < this.Script.Count; ++index)
    {
      this.Script.Commands[index].Status = AllEnums.ScriptStatuses.IDLE;
      this.Script.Commands[index].MinorStatus = AllEnums.ScriptStatuses.IDLE;
    }
    this.Index = 0;
    ++this.RunTimes;
  }

  public static void ScriptMe(string stringcmd, GScriptCommand cmd)
  {
    if (string.IsNullOrEmpty(stringcmd))
      return;
    string[] strArray = stringcmd.Split(',');
    if (strArray.Length <= 0)
      return;
    cmd.Command = strArray[0];
    if (strArray.Length <= 1)
      return;
    for (int index = 1; index < strArray.Length; ++index)
      cmd.Params.Add((object) strArray[index]);
  }

  public static void ScriptMe(string stringcmd, GScript script)
  {
    if (string.IsNullOrEmpty(stringcmd))
      return;
    GScriptCommand gscriptCommand = new GScriptCommand();
    string[] strArray = stringcmd.Split(',');
    if (strArray.Length <= 0)
      return;
    gscriptCommand.Command = strArray[0];
    if (strArray.Length > 1)
    {
      for (int index = 1; index < strArray.Length; ++index)
        gscriptCommand.Params.Add((object) strArray[index]);
    }
    script.Commands.Add(gscriptCommand);
  }

  internal void Start()
  {
    this.ResetRunTimes();
    this.JumpToFirst();
    this.TurnOn();
  }
}
