// Decompiled with JetBrains decompiler
// Type: SmartBot.RunningApp
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using Newtonsoft.Json;
using System.Collections.Generic;

#nullable disable
namespace SmartBot;

public class RunningApp
{
  [JsonProperty("_hasVS")]
  public bool hasVS;
  [JsonProperty("_hasCE")]
  public bool hasCE;
  [JsonProperty("_hasOlly")]
  public bool hasOlly;
  [JsonProperty("_isVM")]
  public bool isVM;
  [JsonProperty("_itsdata")]
  public Dictionary<string, object> machineData = new Dictionary<string, object>();
  public bool hasLauncher;

  [JsonIgnore]
  public bool isDangerous => this.hasVS || this.hasCE || this.hasOlly || this.isVM;
}
