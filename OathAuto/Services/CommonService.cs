using Newtonsoft.Json;
using OathAuto.AppState;
using SmartBot;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace OathAuto.Services
{
  public class CommonService
  {
    public static readonly Random _random = new Random();
    public static int CheckGameVersion(int VersionNum)
    {
      switch (VersionNum)
      {
        case 1:
        case 2:
        case 5:
        case 6:
        case 7:
        case 8:
          return 356;
        case 3:
          return 301;
        case 4:
          return 201;
        default:
          return 0;
      }
    }
    
    internal static byte[] CheckVISCII(string message, int versionNum)
    {
      byte[] bytes = Encoding.ASCII.GetBytes(message);
      StringBuilder stringBuilder = new StringBuilder(message);
      for (int index = 0; index < stringBuilder.Length; ++index)
      {
        byte key = (byte)stringBuilder[index];
        if (StringConverterState.VISCII.ContainsKey((int)key))
        {
          foreach (KeyValuePair<int, char> keyValuePair in StringConverterState.VISCII)
          {
            if (keyValuePair.Key == (int)key)
            {
              bytes[index] = (byte)keyValuePair.Key;
              break;
            }
          }
        }
      }
      return bytes;
    }


    public static string GetMidString(
    string input,
    string first,
    string second,
    int firstIndex = 1,
    int secondIndex = 1)
    {
      if (!string.IsNullOrEmpty(input))
      {
        int length1 = input.Length;
        int startIndex = -1;
        int length2 = -1;
        for (int index = 1; index <= firstIndex; ++index)
        {
          startIndex = input.IndexOf(first);
          if (startIndex != -1)
          {
            startIndex += first.Length;
            input = input.Substring(startIndex, input.Length - startIndex);
          }
        }
        if (startIndex != -1 && startIndex < length1)
        {
          for (int index = 1; index <= secondIndex; ++index)
            length2 = input.IndexOf(second);
          if (length2 != -1 && length2 < input.Length)
          {
            input = input.Substring(0, length2);
            return input;
          }
        }
      }
      return "";
    }

    public static string XOREncrypt(string data, string key)
    {
      byte[] bytes1 = Encoding.ASCII.GetBytes(data);
      byte[] bytes2 = Encoding.ASCII.GetBytes(key);
      byte[] bytes3 = bytes1.Clone() as byte[];
      int index1 = 0;
      for (int index2 = 0; index2 < bytes1.Length; ++index2)
      {
        bytes3[index2] = (byte)((uint)bytes1[index2] ^ (uint)bytes2[index1]);
        ++index1;
        if (index1 >= bytes2.Length)
          index1 = 0;
      }
      key = (string)null;
      GC.Collect();
      return Encoding.ASCII.GetString(bytes3);
    }

    public static List<BaseInfo> GetListBaseInfo()
    {
      Dictionary<string, object>[] dictionaryArray = JsonConvert.DeserializeObject<Dictionary<string, object>[]>(BaseHashState.StringHash);
      var lst = new List<BaseInfo>();
      foreach (Dictionary<string, object> dictionary2 in dictionaryArray)
        lst.Add(new BaseInfo()
        {
          myHash = dictionary2["hash"].ToString(),
          myVersion = dictionary2["version"].ToString(),
          myProvider = dictionary2["provider"].ToString(),
          myInfo = XOREncrypt(dictionary2["addr"].ToString(), "TDTthangancap")
        });
      return lst;
    } 
  }
}
