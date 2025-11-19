// Decompiled with JetBrains decompiler
// Type: SmartBot.GReadMem
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System.Collections.Generic;

#nullable disable
namespace SmartBot;

public class GReadMem
{
  public string Desc = "";
  public string Name = "";
  public string FinalOffsetName = "";
  public string DataType = "int";
  public List<string> DataString = new List<string>();
  public bool IsRead;
  public bool HasFinalOffset;
  private int _value;

  public int Value => this._value != 0 ? this._value : this._value;
}
