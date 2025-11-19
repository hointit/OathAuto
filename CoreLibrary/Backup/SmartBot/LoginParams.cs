// Decompiled with JetBrains decompiler
// Type: SmartBot.LoginParams
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

#nullable disable
namespace SmartBot;

public class LoginParams
{
  public string Username = "";
  public string Password = "";
  public frmLogin LoginForm;
  public bool UseBlog;
  public bool ShowForm;
  public bool AskResult;
  public string Action = "login";
  public string RequestID = "-1";

  public bool IsOnline => !(this.Action == "exit");
}
