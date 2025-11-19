// Decompiled with JetBrains decompiler
// Type: CS2PHPCryptography.PostPackageBuilder
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

#nullable disable
namespace CS2PHPCryptography;

public class PostPackageBuilder
{
  private string data;
  private bool firstVariable;

  public string PostDataString => this.data;

  public PostPackageBuilder()
  {
    this.firstVariable = false;
    this.data = "";
  }

  public void AddVariable(string postVariableName, string postVariableValue)
  {
    this.data = $"{this.data}{(this.firstVariable ? "" : "&")}{postVariableName}={postVariableValue}";
    this.firstVariable = false;
  }
}
