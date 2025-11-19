// Decompiled with JetBrains decompiler
// Type: CS2PHPCryptography.ProxySettings
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

#nullable disable
namespace CS2PHPCryptography;

public struct ProxySettings
{
  public bool UseProxy;
  public string ProxyAddress;
  public string ProxyUsername;
  public string ProxyPassword;

  public ProxySettings(string address, string username, string password)
    : this()
  {
    this.UseProxy = true;
    this.ProxyAddress = address;
    this.ProxyUsername = username;
    this.ProxyPassword = password;
  }
}
