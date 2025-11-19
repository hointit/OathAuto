// Decompiled with JetBrains decompiler
// Type: CS2PHPCryptography.OnHttpResponseEventArgs
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

#nullable disable
namespace CS2PHPCryptography;

public class OnHttpResponseEventArgs
{
  public string ResponseBody { get; set; }

  public bool Error { get; set; }

  public OnHttpResponseEventArgs(string body, bool error)
  {
    this.ResponseBody = body;
    this.Error = error;
  }
}
