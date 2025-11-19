// Decompiled with JetBrains decompiler
// Type: CS2PHPCryptography.Utility
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System;

#nullable disable
namespace CS2PHPCryptography;

public static class Utility
{
  public static string ToUrlSafeBase64(byte[] input)
  {
    return Convert.ToBase64String(input).Replace("+", "-").Replace("/", "_");
  }

  public static byte[] FromUrlSafeBase64(string input)
  {
    return Convert.FromBase64String(input.Replace("-", "+").Replace("_", "/"));
  }
}
