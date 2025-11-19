// Decompiled with JetBrains decompiler
// Type: SmartBot.GMemBase
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

#nullable disable
namespace SmartBot;

public class GMemBase
{
  public string Desc = "";
  public string Name = "";
  public int Errors;
  public GPattern Pattern;
  public int Index = 1;
  public int Offset;
  public bool ReadMem;
  public bool IsRead;
  public int AddSub;
  private int _value;

  public int Value
  {
    get => this._value;
    set
    {
      this._value = value;
      if (this._value <= 0)
        return;
      this.IsRead = true;
    }
  }

  public void AssignValue(int myvalue) => this.Value = myvalue;
}
