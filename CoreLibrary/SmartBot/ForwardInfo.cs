// Decompiled with JetBrains decompiler
// Type: SmartBot.ForwardInfo
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using Newtonsoft.Json;

#nullable disable
namespace SmartBot;

public class ForwardInfo
{
  [JsonProperty("clientport")]
  public int clientport = 6002;
  [JsonProperty("loginserver")]
  public string loginserver = "";
  [JsonProperty("loginport")]
  public int loginport = 6002;
  [JsonProperty("gameserver")]
  public string gameserver = "";
  [JsonProperty("gameport")]
  public int gameport = 8002;
}
