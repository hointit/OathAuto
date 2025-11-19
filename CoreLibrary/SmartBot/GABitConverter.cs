// Decompiled with JetBrains decompiler
// Type: SmartBot.GABitConverter
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System;
using System.Text;

#nullable disable
namespace SmartBot;

public class GABitConverter
{
  public static unsafe short ToInt16(byte* array, int index)
  {
    return (short) ((int) array[index] | (int) array[index + 1] << 8);
  }

  public static unsafe ushort ToUInt16(byte* array, int index)
  {
    return (ushort) ((uint) array[index] | (uint) array[index + 1] << 8);
  }

  public static unsafe int ToInt32(byte* array, int index)
  {
    return (int) array[index] | (int) array[index + 1] << 8 | (int) array[index + 2] << 16 /*0x10*/ | (int) array[index + 3] << 24;
  }

  public static unsafe long ToInt64(byte* array, int index)
  {
    byte[] numArray = new byte[8];
    for (int index1 = index; index1 < index + 8; ++index1)
      numArray[index1 - index] = array[index1];
    return BitConverter.ToInt64(numArray, 0);
  }

  public static unsafe double ToDouble(byte* array, int index)
  {
    byte[] numArray = new byte[8];
    for (int index1 = index; index1 < index + 8; ++index1)
      numArray[index1 - index] = array[index1];
    return BitConverter.ToDouble(numArray, 0);
  }

  public static unsafe float ToSingle(byte* array, int index)
  {
    return GABitConverter.ToFloat(array, index);
  }

  public static unsafe float ToFloat(byte* array, int index)
  {
    try
    {
      byte[] numArray = new byte[4];
      for (int index1 = index; index1 < index + 4; ++index1)
        numArray[index1 - index] = array[index1];
      return BitConverter.ToSingle(numArray, 0);
    }
    catch (Exception ex)
    {
    }
    return 0.0f;
  }

  public static unsafe string ToString(byte* array)
  {
    byte[] bytes = new byte[10];
    for (int index = 0; index < 10; ++index)
      bytes[index] = array[index];
    return frmLogin.CompilingLanguage == "CN" ? Encoding.GetEncoding("gb2312").GetString(bytes) : Encoding.UTF7.GetString(bytes);
  }
}
