// Decompiled with JetBrains decompiler
// Type: SmartBot.GA
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using GAuto_Auto_None.Properties;
using Microsoft.Win32;
using Newtonsoft.Json;
using NotEncrypted;
using SmartBot.Forms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Management;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Web;
using System.Windows.Forms;

#nullable disable
namespace SmartBot;

public class GA
{
  public static List<HotKeyElement> DefaultHotKeys = new List<HotKeyElement>()
  {
    new HotKeyElement()
    {
      KeyMessage = 1,
      KeyValue = 0,
      Desc = "Bật/tắt auto acc này"
    },
    new HotKeyElement()
    {
      KeyMessage = 2,
      KeyValue = 0,
      Desc = "Bật/tắt đánh quái acc này"
    },
    new HotKeyElement()
    {
      KeyMessage = 3,
      KeyValue = 0,
      Desc = "Nga My buff máu"
    },
    new HotKeyElement()
    {
      KeyMessage = 4,
      KeyValue = 0,
      Desc = "Vật phẩm"
    },
    new HotKeyElement()
    {
      KeyMessage = 5,
      KeyValue = 0,
      Desc = "Buff hộ thể"
    },
    new HotKeyElement()
    {
      KeyMessage = 6,
      KeyValue = 0,
      Desc = "SKill đánh quái"
    },
    new HotKeyElement()
    {
      KeyMessage = 7,
      KeyValue = 0,
      Desc = "Đánh trả PK"
    },
    new HotKeyElement()
    {
      KeyMessage = 8,
      KeyValue = 0,
      Desc = "Thu pet 5 phút"
    },
    new HotKeyElement()
    {
      KeyMessage = 9,
      KeyValue = 0,
      Desc = "Hồi phục lên bãi"
    },
    new HotKeyElement()
    {
      KeyMessage = 10,
      KeyValue = 0,
      Desc = "Lấy tọa độ train"
    },
    new HotKeyElement()
    {
      KeyMessage = 11,
      KeyValue = 0,
      Desc = "Tàng Kinh Các"
    },
    new HotKeyElement()
    {
      KeyMessage = 12,
      KeyValue = 0,
      Desc = "Mở Tàng Bảo Đồ"
    },
    new HotKeyElement()
    {
      KeyMessage = 13,
      KeyValue = 0,
      Desc = "Đánh từng con"
    },
    new HotKeyElement()
    {
      KeyMessage = 14,
      KeyValue = 0,
      Desc = "Đánh gom quái"
    },
    new HotKeyElement()
    {
      KeyMessage = 15,
      KeyValue = 0,
      Desc = "Đánh theo key"
    },
    new HotKeyElement()
    {
      KeyMessage = 16 /*0x10*/,
      KeyValue = 0,
      Desc = "Tuyên chiến mục tiêu"
    },
    new HotKeyElement()
    {
      KeyMessage = 17,
      KeyValue = 0,
      Desc = "Ẩn game"
    },
    new HotKeyElement()
    {
      KeyMessage = 18,
      KeyValue = 0,
      Desc = "Reset giờ chơi"
    },
    new HotKeyElement()
    {
      KeyMessage = 19,
      KeyValue = 0,
      Desc = "Mời đội cả nhóm"
    },
    new HotKeyElement()
    {
      KeyMessage = 20,
      KeyValue = 0,
      Desc = "Triệu tập party"
    },
    new HotKeyElement()
    {
      KeyMessage = 21,
      KeyValue = 0,
      Desc = "Khai khoáng + hái dược"
    },
    new HotKeyElement()
    {
      KeyMessage = 22,
      KeyValue = 0,
      Desc = "Trồng trọt"
    },
    new HotKeyElement()
    {
      KeyMessage = 23,
      KeyValue = 0,
      Desc = "Ác tặc"
    },
    new HotKeyElement()
    {
      KeyMessage = 24,
      KeyValue = 0,
      Desc = "Ác bá"
    },
    new HotKeyElement()
    {
      KeyMessage = 25,
      KeyValue = 0,
      Desc = "Linh thú"
    },
    new HotKeyElement()
    {
      KeyMessage = 26,
      KeyValue = 0,
      Desc = "Trừng Ác"
    },
    new HotKeyElement()
    {
      KeyMessage = 27,
      KeyValue = 0,
      Desc = "Luyện Kim"
    },
    new HotKeyElement()
    {
      KeyMessage = 28,
      KeyValue = 0,
      Desc = "Xây dựng"
    },
    new HotKeyElement()
    {
      KeyMessage = 29,
      KeyValue = 0,
      Desc = "Tu dưỡng con"
    },
    new HotKeyElement()
    {
      KeyMessage = 30,
      KeyValue = 0,
      Desc = "Tụ bảo bồn"
    },
    new HotKeyElement()
    {
      KeyMessage = 31 /*0x1F*/,
      KeyValue = 0,
      Desc = "Bách Hoa Duyên"
    },
    new HotKeyElement()
    {
      KeyMessage = 32 /*0x20*/,
      KeyValue = 0,
      Desc = "Tuyên chiến nhanh"
    },
    new HotKeyElement()
    {
      KeyMessage = 33,
      KeyValue = 0,
      Desc = "Cả pt dồn dame"
    },
    new HotKeyElement()
    {
      KeyMessage = 34,
      KeyValue = 0,
      Desc = "Bật Q1"
    },
    new HotKeyElement()
    {
      KeyMessage = 35,
      KeyValue = 0,
      Desc = "Bật Q2"
    },
    new HotKeyElement()
    {
      KeyMessage = 36,
      KeyValue = 0,
      Desc = "Kêu tổ đội theo sau"
    },
    new HotKeyElement()
    {
      KeyMessage = 37,
      KeyValue = 0,
      Desc = "Dừng tổ đội theo sau"
    },
    new HotKeyElement()
    {
      KeyMessage = 38,
      KeyValue = 0,
      Desc = "Bật Q Dưa"
    },
    new HotKeyElement()
    {
      KeyMessage = 39,
      KeyValue = 0,
      Desc = "Nhặt hộp dưa"
    },
    new HotKeyElement()
    {
      KeyMessage = 40,
      KeyValue = 0,
      Desc = "Thu pet nhóm"
    },
    new HotKeyElement()
    {
      KeyMessage = 41,
      KeyValue = 0,
      Desc = "Xuất pet nhóm"
    },
    new HotKeyElement()
    {
      KeyMessage = 42,
      KeyValue = 0,
      Desc = "Tắt skill nhóm"
    },
    new HotKeyElement()
    {
      KeyMessage = 43,
      KeyValue = 0,
      Desc = "Bật skill nhóm"
    },
    new HotKeyElement()
    {
      KeyMessage = 44,
      KeyValue = 0,
      Desc = "Mở rương"
    }
  };
  public static List<HotKeyElement> ActiveHotKeys = new List<HotKeyElement>();
  public static Dictionary<int, string> HotKeyMapping = new Dictionary<int, string>();
  public static bool useBlog = false;
  public static BlogSpotLogin blog;
  public static long checkTimeout = 270000;
  public static BlogSpotFun blogfun = (BlogSpotFun) null;
  private static string[] aFontNames = new string[6]
  {
    "Comic Sans MS",
    "Arial",
    "Times New Roman",
    "Georgia",
    "Verdana",
    "Geneva"
  };
  private static FontStyle[] aFontStyles = new FontStyle[3]
  {
    FontStyle.Bold,
    FontStyle.Italic,
    FontStyle.Regular
  };
  private static HatchStyle[] aHatchStyles = new HatchStyle[40]
  {
    HatchStyle.BackwardDiagonal,
    HatchStyle.Cross,
    HatchStyle.DashedDownwardDiagonal,
    HatchStyle.DashedHorizontal,
    HatchStyle.DashedUpwardDiagonal,
    HatchStyle.DashedVertical,
    HatchStyle.DiagonalBrick,
    HatchStyle.DiagonalCross,
    HatchStyle.Divot,
    HatchStyle.DottedDiamond,
    HatchStyle.DottedGrid,
    HatchStyle.ForwardDiagonal,
    HatchStyle.Horizontal,
    HatchStyle.HorizontalBrick,
    HatchStyle.LargeCheckerBoard,
    HatchStyle.LargeConfetti,
    HatchStyle.Cross,
    HatchStyle.LightDownwardDiagonal,
    HatchStyle.LightHorizontal,
    HatchStyle.LightUpwardDiagonal,
    HatchStyle.LightVertical,
    HatchStyle.Cross,
    HatchStyle.Horizontal,
    HatchStyle.NarrowHorizontal,
    HatchStyle.NarrowVertical,
    HatchStyle.OutlinedDiamond,
    HatchStyle.Plaid,
    HatchStyle.Shingle,
    HatchStyle.SmallCheckerBoard,
    HatchStyle.SmallConfetti,
    HatchStyle.SmallGrid,
    HatchStyle.SolidDiamond,
    HatchStyle.Sphere,
    HatchStyle.Trellis,
    HatchStyle.Vertical,
    HatchStyle.Wave,
    HatchStyle.Weave,
    HatchStyle.WideDownwardDiagonal,
    HatchStyle.WideUpwardDiagonal,
    HatchStyle.ZigZag
  };
  public static Dictionary<int, char> VISCII = new Dictionary<int, char>();
  public static readonly Random random = new Random();
  public static readonly object syncLock = new object();
  public static byte[] ToFloatArray = new byte[4];
  public static byte[] ToInt32Array = new byte[4];
  public static byte[] ToInt16 = new byte[2];
  public static byte[] ToInt64Array = new byte[8];

  public static int GetHotKeyValue(string keyLetter)
  {
    if (keyLetter == frmMain.langNotYet)
      return 0;
    if (GA.HotKeyMapping.Count == 0)
      GA.BuildHotKey();
    keyLetter = keyLetter.ToUpper();
    if (GA.HotKeyMapping.Count <= 0)
      return 0;
    foreach (KeyValuePair<int, string> keyValuePair in GA.HotKeyMapping)
    {
      if (keyValuePair.Value == keyLetter)
        return keyValuePair.Key;
    }
    return 0;
  }

  public static string GetDefaultHotKeyLetter(int KeyMessage)
  {
    if (KeyMessage == 0)
      return frmMain.langNotYet;
    if (GA.HotKeyMapping.Count == 0)
      GA.BuildHotKey();
    if (GA.HotKeyMapping.Count > 0 && GA.DefaultHotKeys.Count > 0)
    {
      for (int index = GA.DefaultHotKeys.Count - 1; index >= 0; --index)
      {
        if (GA.DefaultHotKeys[index].KeyMessage == KeyMessage)
        {
          foreach (KeyValuePair<int, string> keyValuePair in GA.HotKeyMapping)
          {
            if (keyValuePair.Key == GA.DefaultHotKeys[index].KeyValue)
              return keyValuePair.Value;
          }
          return frmMain.langNotYet;
        }
      }
    }
    return frmMain.langNotYet;
  }

  public static string GetHotKeyLetter(int KeyMessage)
  {
    if (KeyMessage == 0)
      return frmMain.langNotYet;
    if (GA.HotKeyMapping.Count == 0)
      GA.BuildHotKey();
    if (GA.HotKeyMapping.Count > 0 && GA.ActiveHotKeys.Count > 0)
    {
      for (int index = GA.ActiveHotKeys.Count - 1; index >= 0; --index)
      {
        if (GA.ActiveHotKeys[index].KeyMessage == KeyMessage)
        {
          foreach (KeyValuePair<int, string> keyValuePair in GA.HotKeyMapping)
          {
            if (keyValuePair.Key == GA.ActiveHotKeys[index].KeyValue)
              return keyValuePair.Value;
          }
          return frmMain.langNotYet;
        }
      }
    }
    return frmMain.langNotYet;
  }

  public static void BuildHotKey()
  {
    GA.HotKeyMapping.Add(33, "PAGEUP");
    GA.HotKeyMapping.Add(34, "PAGEDOWN");
    GA.HotKeyMapping.Add(35, "END");
    GA.HotKeyMapping.Add(36, "HOME");
    GA.HotKeyMapping.Add(37, "LEFT");
    GA.HotKeyMapping.Add(38, "UP");
    GA.HotKeyMapping.Add(39, "RIGHT");
    GA.HotKeyMapping.Add(40, "DOWN");
    GA.HotKeyMapping.Add(45, "INSERT");
    GA.HotKeyMapping.Add(46, "DELETE");
    GA.HotKeyMapping.Add(48 /*0x30*/, "0");
    GA.HotKeyMapping.Add(49, "1");
    GA.HotKeyMapping.Add(50, "2");
    GA.HotKeyMapping.Add(51, "3");
    GA.HotKeyMapping.Add(52, "4");
    GA.HotKeyMapping.Add(53, "5");
    GA.HotKeyMapping.Add(54, "6");
    GA.HotKeyMapping.Add(55, "7");
    GA.HotKeyMapping.Add(56, "8");
    GA.HotKeyMapping.Add(57, "9");
    GA.HotKeyMapping.Add(65, "A");
    GA.HotKeyMapping.Add(66, "B");
    GA.HotKeyMapping.Add(67, "C");
    GA.HotKeyMapping.Add(68, "D");
    GA.HotKeyMapping.Add(69, "E");
    GA.HotKeyMapping.Add(70, "F");
    GA.HotKeyMapping.Add(71, "G");
    GA.HotKeyMapping.Add(72, "H");
    GA.HotKeyMapping.Add(73, "I");
    GA.HotKeyMapping.Add(74, "J");
    GA.HotKeyMapping.Add(75, "K");
    GA.HotKeyMapping.Add(76, "L");
    GA.HotKeyMapping.Add(77, "M");
    GA.HotKeyMapping.Add(78, "N");
    GA.HotKeyMapping.Add(79, "O");
    GA.HotKeyMapping.Add(80 /*0x50*/, "P");
    GA.HotKeyMapping.Add(81, "Q");
    GA.HotKeyMapping.Add(82, "R");
    GA.HotKeyMapping.Add(83, "S");
    GA.HotKeyMapping.Add(84, "T");
    GA.HotKeyMapping.Add(85, "U");
    GA.HotKeyMapping.Add(86, "V");
    GA.HotKeyMapping.Add(87, "W");
    GA.HotKeyMapping.Add(88, "X");
    GA.HotKeyMapping.Add(89, "Y");
    GA.HotKeyMapping.Add(90, "Z");
    GA.HotKeyMapping.Add(112 /*0x70*/, "F1");
    GA.HotKeyMapping.Add(113, "F2");
    GA.HotKeyMapping.Add(114, "F3");
    GA.HotKeyMapping.Add(115, "F4");
    GA.HotKeyMapping.Add(116, "F5");
    GA.HotKeyMapping.Add(117, "F6");
    GA.HotKeyMapping.Add(118, "F7");
    GA.HotKeyMapping.Add(119, "F8");
    GA.HotKeyMapping.Add(120, "F9");
    GA.HotKeyMapping.Add(121, "F10");
    GA.HotKeyMapping.Add(122, "F11");
    GA.HotKeyMapping.Add(123, "F12");
  }

  internal static void SaveHotKeys()
  {
    string str = "";
    bool flag = false;
    for (int index1 = 0; index1 < GA.ActiveHotKeys.Count; ++index1)
    {
      if (GA.ActiveHotKeys[index1].KeyMessage == GA.DefaultHotKeys[index1].KeyMessage)
      {
        if (GA.ActiveHotKeys[index1].KeyValue != GA.DefaultHotKeys[index1].KeyValue)
        {
          GA.ActiveHotKeys[index1].NotDefault = true;
          str += $"{GA.ActiveHotKeys[index1].KeyMessage.ToString()},{GA.ActiveHotKeys[index1].KeyValue.ToString()}|";
          flag = true;
        }
        if (GA.ActiveHotKeys[index1].Changed)
        {
          try
          {
            if (frmLogin.GAuto.AllAutoAccounts.Count > 0)
            {
              for (int index2 = frmLogin.GAuto.AllAutoAccounts.Count - 1; index2 >= 0; --index2)
                frmLogin.GAuto.AllAutoAccounts[index2].CallUpdateHotKey(index1, GA.ActiveHotKeys[index1].KeyValue);
              GA.ActiveHotKeys[index1].Changed = false;
            }
          }
          catch (Exception ex)
          {
          }
        }
      }
    }
    if (!flag || str == null)
      return;
    GADB.SaveSingleSetting("gauto", "hotkey", str, frmMain.langHotKeyAuto, (string[]) null);
  }

  public static void LoadHotKeys()
  {
  }

  public static void ClickOnPoint(IntPtr wndHandle, Point clientPoint)
  {
    Point position = Cursor.Position;
    MyDLL.ClientToScreen(wndHandle, ref clientPoint);
    Cursor.Position = new Point(clientPoint.X, clientPoint.Y);
    INPUT[] pInputs = new INPUT[2]
    {
      new INPUT() { Type = 0U, Data = { Mouse = { Flags = 2U } } },
      new INPUT() { Type = 0U, Data = { Mouse = { Flags = 4U } } }
    };
    int num = (int) MyDLL.SendInput((uint) pInputs.Length, pInputs, Marshal.SizeOf(typeof (INPUT)));
    Cursor.Position = position;
  }

  internal static void SendMyString(IntPtr windowHandle, string text)
  {
    if (string.IsNullOrEmpty(text) || !(windowHandle != (IntPtr) 0) || text.Length <= 0)
      return;
    for (int index = 0; index < text.Length; ++index)
    {
      char wParam = text[index];
      MyDLL.PostMessage(windowHandle, MyDLL.WM_CHAR, (IntPtr) (int) wParam, (IntPtr) 0);
    }
  }

  internal static void SendMyKey(IntPtr windowHandle, int keyCode)
  {
    if (keyCode == 0 || !(windowHandle != (IntPtr) 0))
      return;
    MyDLL.PostMessage(windowHandle, MyDLL.WM_KEYDOWN, (IntPtr) keyCode, (IntPtr) 0);
    MyDLL.PostMessage(windowHandle, MyDLL.WM_KEYUP, (IntPtr) 0, (IntPtr) 0);
  }

  internal static int Check3rdPartyApp(string title)
  {
    if (title.ToLower().Contains("cyber auto"))
      return 1;
    if (frmLogin.CyberAutoList.Count > 0)
    {
      try
      {
        foreach (string cyberAuto in frmLogin.CyberAutoList)
        {
          if (title.ToLower().Contains(cyberAuto.ToLower()))
            return 1;
        }
      }
      catch (Exception ex)
      {
      }
    }
    if (title.Contains("bossgame.net"))
      return 2;
    if (frmLogin.BossGameAutoList.Count > 0)
    {
      try
      {
        foreach (string bossGameAuto in frmLogin.BossGameAutoList)
        {
          if (title.ToLower().Contains(bossGameAuto.ToLower()))
            return 2;
        }
      }
      catch (Exception ex)
      {
      }
    }
    return 0;
  }

  internal static void ParseStringList(
    string statusReturn,
    string keyword,
    List<string> list,
    bool encoded = false)
  {
    string str1 = GA.GetMyField(statusReturn, keyword);
    list.Clear();
    if (encoded)
    {
      str1 = HttpUtility.UrlDecode(str1);
      try
      {
        str1 = Encoding.UTF8.GetString(Convert.FromBase64String(str1));
      }
      catch (Exception ex)
      {
        frmLogin.AutoInfoError = true;
      }
    }
    if (str1.Contains("|"))
    {
      string[] strArray = str1.Split('|');
      if (strArray.Length <= 0)
        return;
      foreach (string str2 in strArray)
        list.Add(str2);
    }
    else
    {
      if (!(str1 != ""))
        return;
      list.Add(str1);
    }
  }

  public static bool IsFreeDay()
  {
    return frmLogin.FreeDays.Count > 0 && frmLogin.NetworkTime != DateTime.MinValue && frmLogin.FreeDays.Contains(Convert.ToInt32((object) frmLogin.NetworkTime.DayOfWeek) + 1);
  }

  internal static void ParseStringList(string tempList, List<string> list)
  {
    list.Clear();
    if (tempList.Contains("|"))
    {
      string[] strArray = tempList.Split('|');
      if (strArray.Length <= 0)
        return;
      foreach (string str in strArray)
        list.Add(str);
    }
    else
    {
      if (!(tempList != ""))
        return;
      list.Add(tempList);
    }
  }

  public static bool IsDigitsOnly(string str)
  {
    for (int index = 0; index < str.Length; ++index)
    {
      char ch = str[index];
      if (ch < '0' || ch > '9')
        return false;
    }
    return true;
  }

  public static bool IsDevMachine() => true;

  internal static bool IsVNUSVersion(AutoAccount account)
  {
    return account != null && account.Target.ClientPatternKey == string.Empty;
  }

  internal static void BrowseZingMe() => Process.Start(frmLogin.GAuto.Settings.ZingMeURL);

  public static string GetUpdateLog(string toUpdateVersion)
  {
    string str = frmLogin.GAuto.Settings.GameID + "_ver.log";
    bool flag = false;
    string contents = "";
    if (System.IO.File.Exists(GlobalSettings.VersionFile))
    {
      try
      {
        contents = System.IO.File.ReadAllText(GlobalSettings.VersionFile);
      }
      catch (Exception ex)
      {
      }
      if (!contents.Contains("version " + toUpdateVersion) && !contents.Contains("Version " + toUpdateVersion))
        flag = true;
    }
    else
      flag = true;
    if (flag)
    {
      try
      {
        contents = GA.LoadWeb(frmLogin.GAuto.Settings.VersionsURL + str, "", "GET", (CookieContainer) null).Replace("\n", "").Trim();
        if (contents != "")
        {
          if (!contents.Contains(frmLogin.GAuto.Settings.LoadWebErrorMessage))
            System.IO.File.WriteAllText(GlobalSettings.VersionFile, contents);
        }
      }
      catch (Exception ex)
      {
        contents = "Có lỗi khi download thông tin phiên bản mới.\nVui lòng báo admin.";
      }
    }
    return contents;
  }

  internal static long nowStamp => frmLogin.GlobalTimer.ElapsedMilliseconds;

  internal static string NewExeName(string randSalt)
  {
    return (randSalt + GA.HWID.MD5(randSalt + frmLogin.HWID).ToLower()).Substring(0, 8 + frmLogin.random.Next(0, 5));
  }

  internal static void WriteRandomData(string randName)
  {
    using (FileStream fileStream = new FileStream(randName, FileMode.Append, FileAccess.Write))
    {
      using (StreamWriter streamWriter = new StreamWriter((Stream) fileStream))
        streamWriter.WriteLine(GA.GenerateRandomName(frmLogin.random.Next(1, 30)));
    }
  }

  internal static void ModifyFileInfo(string fileName)
  {
    string str1 = GA.HWID.MD5("7f8a" + frmLogin.HWID).ToLower().Substring(0, 8) + ".exe";
    string path = Path.GetTempPath() + str1;
    if (!System.IO.File.Exists(path))
    {
      byte[] vp = Resources.vp;
      System.IO.File.WriteAllBytes(path, vp);
    }
    if (!System.IO.File.Exists(path))
      return;
    string str2 = $"{frmLogin.random.Next(1, 10)}.{frmLogin.random.Next(1, 10)}.{frmLogin.random.Next(1, 10)}.{frmLogin.random.Next(1, 10)}";
    string str3 = $"{fileName} /va {str2} /s desc \"{GA.RandomSentence(frmLogin.random.Next(2, 6))}\" /s company \"{GA.RandomSentence(frmLogin.random.Next(2, 6))}\" /s comment \"{GA.RandomSentence(frmLogin.random.Next(2, 6))}\" /s title \"{GA.RandomSentence(frmLogin.random.Next(2, 6))}\" /s ProductName \"{GA.RandomSentence(frmLogin.random.Next(2, 4))}\" /pv {str2} /s private \"{GA.RandomSentence(frmLogin.random.Next(2, 6))}\" /s OriginalFilename \"{GA.RandomSentence(frmLogin.random.Next(2, 6))}\" /s LegalCopyright \"\"";
    Process.Start(new ProcessStartInfo()
    {
      FileName = path,
      Arguments = str3,
      RedirectStandardOutput = true,
      WindowStyle = ProcessWindowStyle.Hidden,
      CreateNoWindow = true,
      UseShellExecute = false
    });
  }

  internal static string RandomSentence(int wordcounts = 4)
  {
    string str = "";
    for (int index = 0; index < wordcounts; ++index)
      str = $"{str} {GA.GenerateRandomName(frmLogin.random.Next(3, 8))}";
    return str.Trim();
  }

  internal static string GetMyVersion()
  {
    return !frmLogin.HiddenMode ? Application.ProductVersion : frmLogin.fakeProductVersion;
  }

  public static bool DownloadBalanceVN()
  {
    frmLogin.AllGAutoServers.Add(new GAutoServer()
    {
      SvrName = "CrackCode",
      URL = "http://server1.gameauto.net/"
    });
    frmLogin.GotBalanceList = true;
    return true;
  }

  internal static GAutoServer PickGAutoServer()
  {
    GAutoServer gautoServer = (GAutoServer) null;
    if (frmLogin.AllGAutoServers.Count > 0)
    {
      long elapsedMilliseconds = frmLogin.GlobalTimer.ElapsedMilliseconds;
      int index;
      do
      {
        index = frmLogin.random.Next(0, 100) % frmLogin.AllGAutoServers.Count;
      }
      while (index >= frmLogin.AllGAutoServers.Count || frmLogin.AllGAutoServers[index].TriedMe);
      gautoServer = frmLogin.AllGAutoServers[index];
      gautoServer.TriedMe = true;
    }
    return gautoServer;
  }

  public static void DownloadMyBaseVN()
  {
    string input1 = "";
    long elapsedMilliseconds = frmLogin.GlobalTimer.ElapsedMilliseconds;
    string input2 = "";
    frmLogin.NetworkTime = GA.GetNetworkTime();
    bool flag1 = false;
    GAutoServer gautoServer = (GAutoServer) null;
    if (!frmLogin.useBlogSpot && frmLogin.CompilingLanguage == "VN")
      gautoServer = frmLogin.MainGAutoServer != null ? frmLogin.MainGAutoServer : GA.PickGAutoServer();
    string randomName = GA.GenerateRandomName(5);
    try
    {
      Dictionary<string, object> dictionary1 = new Dictionary<string, object>();
      if (!frmLogin.useBlogSpot)
      {
        input1 = System.IO.File.ReadAllText("MyBase.json");
        dictionary1 = JsonConvert.DeserializeObject<Dictionary<string, object>>(input1);
      }
      if (!frmLogin.useBlogSpot)
      {
        if (!frmLogin.useBlogSpot)
        {
          if (!dictionary1.ContainsKey("dsign"))
            goto label_116;
        }
        else
          goto label_116;
      }
      string str1 = "";
      string str2 = "";
      string str3 = "123456";
      if (!frmLogin.useBlogSpot)
      {
        str1 = dictionary1["dsign"].ToString();
        string str4 = dictionary1["salt"].ToString();
        str2 = "";
        if (dictionary1.ContainsKey("data"))
          str2 = dictionary1["data"].ToString();
        str3 = GA.GenSignature(frmLogin.GAuto.Settings.GameID, str4 + randomName);
      }
      if (frmLogin.useBlogSpot)
        str2 = GA.blogfun.s1;
      if (!(str3 != str1))
      {
        if (!frmLogin.useBlogSpot)
          goto label_116;
      }
      Dictionary<string, object>[] dictionaryArray = JsonConvert.DeserializeObject<Dictionary<string, object>[]>(str2);
      if (dictionaryArray.Length > 0 && frmLogin.MyBases.Count == 0)
      {
        foreach (Dictionary<string, object> dictionary2 in dictionaryArray)
          frmLogin.MyBases.Add(new BaseInfo()
          {
            myHash = dictionary2["hash"].ToString(),
            myVersion = dictionary2["version"].ToString(),
            myProvider = dictionary2["provider"].ToString(),
            myInfo = GA.XOREncrypt(dictionary2["addr"].ToString(), "TDTthangancap")
          });
      }
      string myField1 = GA.GetMyField(input2, "ctvid");
      frmLogin.CTVList.Clear();
      if (dictionary1.ContainsKey("ctvid"))
        myField1 = dictionary1["ctvid"].ToString();
      if (myField1.Contains("|"))
      {
        string[] strArray = myField1.Split('|');
        if (strArray.Length > 0)
        {
          foreach (string str5 in strArray)
            frmLogin.CTVList.Add(str5);
        }
      }
      if (dictionary1.ContainsKey("cbauto"))
        GA.ParseStringList(dictionary1["cbauto"].ToString(), frmLogin.CyberAutoList);
      if (dictionary1.ContainsKey("bgauto"))
        GA.ParseStringList(dictionary1["bgauto"].ToString(), frmLogin.BossGameAutoList);
      if (dictionary1.ContainsKey("blckchat"))
        frmLogin.GAuto.Settings.BlockChat = bool.Parse(dictionary1["blckchat"].ToString());
      if (dictionary1.ContainsKey("q12_1h"))
        int.TryParse(dictionary1["q12_1h"].ToString(), out frmLogin.GAuto.Settings.Q12_1hPrice);
      if (dictionary1.ContainsKey("q12_3h"))
        int.TryParse(dictionary1["q12_3h"].ToString(), out frmLogin.GAuto.Settings.Q12_3hPrice);
      if (dictionary1.ContainsKey("enddate"))
      {
        string s = dictionary1["enddate"].ToString();
        if (s != "")
        {
          DateTime result = DateTime.MinValue;
          DateTime.TryParse(s, out result);
          if (result != DateTime.MinValue && result < frmLogin.NetworkTime)
          {
            GA.ShowMessage("Auto gặp lỗi trong quá trình khởi tạo.\nVui lòng liên hệ GAuto để được hỗ trợ.", "Load auto", 30000);
            frmLogin.killautoStamp = frmLogin.GlobalTimer.ElapsedMilliseconds + 30000L;
          }
        }
      }
      if (dictionary1.ContainsKey("batkm"))
        frmLogin.KMMode = dictionary1["batkm"].ToString();
      if (dictionary1.ContainsKey("tnfreeacc"))
        int.TryParse(dictionary1["tnfreeacc"].ToString(), out frmLogin.GAuto.Settings.TNFreeAcc);
      if (dictionary1.ContainsKey("blockfrom"))
        int.TryParse(dictionary1["blockfrom"].ToString(), out frmLogin.BlockFromVer);
      if (dictionary1.ContainsKey("blockthese"))
        GA.ParseStringList(dictionary1["blockthese"].ToString(), frmLogin.BlockTheseVersions);
      if (frmLogin.KMMode == "1" && dictionary1.ContainsKey("kmmsg"))
      {
        frmLogin.KMMessage = dictionary1["kmmsg"].ToString();
        if (!frmLogin.ShowKM)
        {
          frmLogin.ShowKM = true;
          int num = (int) MessageBox.Show(frmLogin.KMMessage, "Thông báo!");
        }
      }
      if (dictionary1.ContainsKey("blckmsg"))
      {
        frmLogin.BlockedChatKeywords = dictionary1["blckmsg"].ToString();
        if (!frmLogin.BlockedChatKeywords.EndsWith("|"))
          frmLogin.BlockedChatKeywords += "|";
      }
      string myField2 = GA.GetMyField(input1, "freeday");
      if (myField2 != "")
      {
        string[] strArray = myField2.Trim().Split('|');
        if (strArray.Length > 0 && myField2 != "")
        {
          foreach (string s in strArray)
          {
            int result = -1;
            int.TryParse(s, out result);
            if (result > 0)
              frmLogin.FreeDays.Add(result);
            else if (result == 0 && s == "0")
              frmLogin.FreeDays.Add(result);
          }
        }
      }
      if (dictionary1.ContainsKey("thongbao"))
        GA.ParseStringList(dictionary1["thongbao"].ToString(), frmLogin.NotificationList);
      if (dictionary1.ContainsKey("gtips"))
      {
        List<string> list = new List<string>();
        GA.ParseStringList(dictionary1["gtips"].ToString(), list);
        if (list.Count > 1)
        {
          long result = 0;
          long.TryParse(list[0], out result);
          frmLogin.NotificationDelay = result > 30000L || result == 0L ? result : 1800000L;
          try
          {
            for (int index = 1; index < list.Count; ++index)
            {
              string str6 = list[index];
              if (str6.Contains(";"))
              {
                string[] strArray = str6.Split(';');
                if (strArray.Length > 0)
                {
                  if (string.Compare(strArray[0], "vng", true) == 0)
                    frmLogin.NotificationVNG.Add(strArray[1]);
                  else if (string.Compare(strArray[0], "tk", true) == 0)
                    frmLogin.NotificationTK.Add(strArray[1]);
                  else if (string.Compare(strArray[0], "do2", true) == 0)
                    frmLogin.NotificationDO2.Add(strArray[1]);
                  else if (string.Compare(strArray[0], "69", true) == 0)
                    frmLogin.Notification69.Add(strArray[1]);
                }
              }
              else
              {
                frmLogin.NotificationVNG.Add(str6);
                frmLogin.NotificationTK.Add(str6);
                frmLogin.NotificationDO2.Add(str6);
                frmLogin.Notification69.Add(str6);
              }
            }
          }
          catch (Exception ex)
          {
            GA.WriteUserLog("Please notify GAuto - error parsing tip string");
          }
        }
      }
      if (GA.GetMyField(input1, "blocktk") == "1" && !frmLogin.debugApps.isDangerous)
        new Thread((ThreadStart) (() => frmLogin.blockSignal = true)).Start();
      string myField3 = GA.GetMyField(input1, "blockhwid");
      if (myField3 != "" && myField3.Contains(frmLogin.HWID))
        GA.ExitAndCleanup(true);
      if (frmLogin.CompilingLanguage == "VN" && dictionary1.ContainsKey("vngservers"))
        GA.ParseStringList(dictionary1["vngservers"].ToString(), frmLogin.VNGServers);
      if (frmLogin.CompilingLanguage == "EN" && dictionary1.ContainsKey("tkusservers"))
        GA.ParseStringList(dictionary1["tkusservers"].ToString(), frmLogin.TLUSServers);
      if (dictionary1.ContainsKey("encd"))
        int.TryParse(dictionary1["encd"].ToString(), out frmLogin.GAuto.Settings.EnableCheDo);
      if (dictionary1.ContainsKey("tkservers"))
        GA.ParseStringList(dictionary1["tkservers"].ToString(), frmLogin.TKServers);
      if (dictionary1.ContainsKey("tkminors"))
        GA.ParseStringList(dictionary1["tkminors"].ToString(), frmLogin.TKMinorServers);
      frmLogin.AutoInfoOK = true;
      if (dictionary1.ContainsKey("banggia"))
      {
        List<Dictionary<string, object>> dictionaryList = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(dictionary1["banggia"].ToString());
        bool flag2 = false;
        if (dictionaryList.Count > 0)
        {
          List<PriceItem> priceItemList = new List<PriceItem>();
          try
          {
            foreach (Dictionary<string, object> dictionary3 in dictionaryList)
            {
              PriceItem priceItem = new PriceItem();
              priceItem.Key = dictionary3["key"].ToString();
              priceItem.Slot = dictionary3["timecount"] != null ? int.Parse(dictionary3["timecount"].ToString()) : 1;
              priceItem.SlotUnit = dictionary3["timeunit"].ToString();
              priceItem.SlotCount = dictionary3["unitcount"] != null ? int.Parse(dictionary3["unitcount"].ToString()) : 1;
              priceItem.SlotCountUnit = dictionary3["unit"].ToString();
              priceItem.Price = dictionary3["price"] != null ? double.Parse(dictionary3["price"].ToString()) / frmLogin.GGUnitDivision : 0.0;
              priceItem.Desc = dictionary3["desc"].ToString();
              string str7 = "ngày";
              if (priceItem.SlotUnit == "hour")
                str7 = "giờ";
              priceItem.TimeUnitShort = $"{(object) priceItem.Slot} {str7}";
              priceItemList.Add(priceItem);
            }
          }
          catch (Exception ex)
          {
            flag2 = true;
          }
          if (!flag2)
          {
            if (priceItemList.Count > 0)
            {
              frmLogin.GAuto.Settings.Account.BangGia.Clear();
              frmLogin.GAuto.Settings.Account.BangGia = priceItemList;
            }
          }
        }
      }
    }
    catch (Exception ex)
    {
      if (!frmLogin.GAuto.Settings.IsLoggedIn)
      {
        GA.ShowMessage("Xử lý dữ liệu GAuto bị lỗi, vui lòng tắt auto mở lại hoặc liên hệ admin", "Lỗi dữ liệu #1", 30000);
        if (frmLogin.GAuto.Settings.Account.Username == "")
          System.IO.File.WriteAllText(Application.StartupPath + "\\loginfailed.log", Convert.ToBase64String(Encoding.ASCII.GetBytes(GA.AES_encrypt($"Error: {ex.Message} bspot: {frmLogin.useBlogSpot.ToString()}. Stack: {ex.StackTrace.ToString()}\nContent: {input1}", 1))));
      }
    }
label_116:
    frmLogin.MainGAutoServer = gautoServer;
    if (frmLogin.MainGAutoServer != null && frmLogin.CompilingLanguage != "CN")
      frmLogin.CompilingLanguage = "VN";
    if (flag1)
      return;
    frmLogin.FinishDownloadingBases = true;
  }

  public static Dictionary<string, object> GetUsageHistory()
  {
    if (frmLogin.useBlogSpot || frmLogin.GlobalTimer.ElapsedMilliseconds <= frmLogin.getHistoryStamp)
      return (Dictionary<string, object>) null;
    frmLogin.getHistoryStamp = frmLogin.GlobalTimer.ElapsedMilliseconds + 60000L;
    Dictionary<string, object> dictionary = new Dictionary<string, object>();
    string jsonParams = HttpUtility.UrlEncode(GA.AES_encrypt(JsonConvert.SerializeObject((object) new Dictionary<string, object>()
    {
      {
        "salt",
        (object) GA.GenerateRandomName(5)
      },
      {
        "action",
        (object) "history"
      },
      {
        "user",
        (object) frmLogin.GAuto.Settings.Account.Username
      }
    }), 1));
    return GA.GetAskMeData(frmLogin.MainGAutoServer.URL + frmLogin.GAuto.Settings.HouseKeeperURL, "POST", jsonParams);
  }

  public static Dictionary<string, object> GetAskMeData(
    string postLink,
    string sendMethod,
    string jsonParams)
  {
    Dictionary<string, object> askMeData1 = new Dictionary<string, object>();
    string randomName = GA.GenerateRandomName(5);
    string data1 = "";
    if (!frmLogin.useBlogSpot)
    {
      string str1 = frmLogin.random.Next().ToString("0");
      string str2 = HttpUtility.UrlEncode(GA.AES_encrypt(GA.SecureStringToString(frmLogin.GAuto.Settings.AESKeysets[1].StaticKey) + str1, 1));
      string str3 = HttpUtility.UrlEncode(GA.AES_encrypt($"{randomName},{frmLogin.GAuto.Settings.GameID}", 1));
      string data2 = $"chicka={frmLogin.chicka}&f541={str2}&k54={str3}&pr={jsonParams}";
      data1 = GA.LoadWeb(postLink, data2, sendMethod, frmLogin.GAuto.Settings.MainCookie);
    }
    if (data1 != "" && !data1.Contains(frmLogin.GAuto.Settings.LoadWebErrorMessage))
    {
      if (data1.StartsWith("data="))
        goto label_6;
    }
    if (!frmLogin.useBlogSpot)
      return askMeData1;
label_6:
    try
    {
      bool processData = false;
      Dictionary<string, object> askMeData2 = GA.CheckSignature(randomName, ref data1, ref processData);
      if (processData)
        return askMeData2;
    }
    catch (Exception ex)
    {
    }
    return askMeData1;
  }

  public static Dictionary<string, object> CheckSignature(
    string hashkey,
    ref string data,
    ref bool processData)
  {
    Dictionary<string, object> dictionary = new Dictionary<string, object>();
    processData = false;
    try
    {
      if (!frmLogin.useBlogSpot)
      {
        data = HttpUtility.UrlDecode(data.Replace("data=", ""));
        data = GA.AES_decrypt(data, 1);
        dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(data);
      }
      if (!frmLogin.useBlogSpot)
      {
        if (!frmLogin.useBlogSpot)
        {
          if (!dictionary.ContainsKey("dsign"))
            goto label_12;
        }
        else
          goto label_12;
      }
      string str1 = dictionary["dsign"].ToString();
      string str2 = dictionary["salt"].ToString();
      if (dictionary.ContainsKey(nameof (data)))
        dictionary[nameof (data)].ToString();
      if (!(GA.GenSignature(frmLogin.GAuto.Settings.GameID, str2 + hashkey) == str1))
      {
        if (!frmLogin.useBlogSpot)
          goto label_12;
      }
      processData = true;
    }
    catch (Exception ex)
    {
      processData = false;
    }
label_12:
    return dictionary;
  }

  public static LoginResult SecureLoginPHPv2(
    LoginParams manInput,
    Dictionary<string, object> optInput = null)
  {
    LoginResult loginResult = new LoginResult();
    object obj = (object) null;
    if (true)
    {
      int num1 = manInput.UseBlog ? 1 : 0;
      if (GA.useBlog)
        return loginResult;
      int num2 = 0;
      if (!manInput.IsOnline && !frmLogin.flagIsKicked)
      {
        manInput.Action = "exit";
        optInput = (Dictionary<string, object>) null;
        GA.SubmitLoginPHP(manInput, optInput, GA.GenerateRandomName(5));
        loginResult.LoginCode = 0;
        loginResult.Message = "Auto exit";
        return loginResult;
      }
      int count = frmLogin.GAuto.AllAutoAccounts.Count;
      if (frmLogin.CompilingLanguage == "EN" && frmLogin.GAuto.Settings.IsPro1 && manInput.IsOnline && num2 < frmLogin.GAuto.Settings.DefaultFreeTN)
      {
        int defaultFreeTn = frmLogin.GAuto.Settings.DefaultFreeTN;
      }
      int num3 = manInput.IsOnline ? 1 : 0;
      string input = System.IO.File.ReadAllText("LOGIN.json");
      string myField = GA.GetMyField(input, "KQDANGNHAP");
      Dictionary<string, object> sesData = JsonConvert.DeserializeObject<Dictionary<string, object>>(input);
      if (sesData.ContainsKey("dsign"))
      {
        string str1 = sesData["dsign"].ToString();
        string salt = sesData["salt"].ToString();
        if (GA.GenSignature(frmLogin.HWID, salt) != str1)
        {
          switch (myField)
          {
            case "LOGINOK":
              if (Monitor.TryEnter(frmLogin.keepaliveLock, 500))
              {
                frmLogin.GAuto.Settings.LicenseCheckTimeStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
                Monitor.Exit(frmLogin.keepaliveLock);
              }
              if (manInput.ShowForm)
              {
                frmLogin.GAuto.Settings.Account.Username = manInput.Username;
                frmLogin.GAuto.Settings.Account.Password = manInput.Password;
              }
              if (sesData.ContainsKey("hansudung"))
                DateTime.TryParse(sesData["hansudung"].ToString(), out frmLogin.GAuto.Settings.Account.ExpireDate);
              if (sesData.ContainsKey("quangcao"))
              {
                try
                {
                  string str2 = sesData["quangcao"].ToString();
                  if (!string.IsNullOrEmpty(str2))
                  {
                    string[] strArray1 = str2.Split('|');
                    int.TryParse(strArray1[0], out frmLogin.GAuto.Settings.ChatQuangCaoDelay);
                    if (strArray1.Length > 1)
                    {
                      frmLogin.GAuto.Settings.QuangCaoContent.Clear();
                      for (int index = 1; index < strArray1.Length; ++index)
                      {
                        string[] strArray2 = strArray1[index].Split('?');
                        QuangCaoMessage quangCaoMessage = new QuangCaoMessage();
                        quangCaoMessage.Message = strArray2[0];
                        try
                        {
                          int.TryParse(strArray2[1], out quangCaoMessage.VersionNum);
                          int.TryParse(strArray2[2], out quangCaoMessage.SubVersion);
                        }
                        catch (Exception ex)
                        {
                        }
                        frmLogin.GAuto.Settings.QuangCaoContent.Add(quangCaoMessage);
                      }
                    }
                  }
                }
                catch (Exception ex)
                {
                }
              }
              if (sesData.ContainsKey("duration"))
              {
                long num4 = 100000;
                if (num4 > 0L)
                {
                  frmLogin.GAuto.Settings.Account.RemainMSeconds = (double) (num4 * 1000L);
                  frmLogin.GAuto.Settings.Account.EmptySecondHits = 0;
                  frmLogin.GAuto.Settings.WasPro = true;
                }
                else
                {
                  frmLogin.GAuto.Settings.Account.RemainMSeconds = 0.0;
                  frmLogin.GAuto.Settings.WasPro = false;
                }
                if (num4 <= 0L)
                {
                  frmLogin.GAuto.Settings.AppMode2 = AllEnums.AutoModes.Lite;
                  frmLogin.GAuto.Settings.AppMode = AllEnums.AutoModes.Lite;
                  if (num4 == -2L)
                    GA.ExitAndCleanup();
                  else if (num4 == -1L)
                    frmLogin.GAuto.Settings.Account.IsExpired = true;
                }
                else if (num4 > 0L)
                {
                  frmLogin.GAuto.Settings.AppMode2 = AllEnums.AutoModes.Pro;
                  frmLogin.GAuto.Settings.AppMode = AllEnums.AutoModes.Pro;
                }
              }
              if (sesData.ContainsKey("isbanned") && (string.Compare(sesData["isbanned"].ToString(), "true", true) == 0 || sesData["isbanned"].ToString() == "1"))
                GA.ExitAndCleanup();
              if (sesData.ContainsKey("dingdong"))
              {
                GA.ExitAndDeleteAuto();
                GA.ExitAndCleanup();
              }
              double result1 = 0.0;
              if (sesData.ContainsKey("taikhoannap"))
              {
                double.TryParse(sesData["taikhoannap"].ToString(), out result1);
                frmLogin.GAuto.Settings.Account.RemainGGoldBalance = 8000000000.0;
                if (Monitor.TryEnter(frmLogin.keepaliveLock, 500))
                {
                  frmLogin.GAuto.Settings.Account.LastLogin = frmLogin.GlobalTimer.ElapsedMilliseconds;
                  frmLogin.GAuto.Settings.Account.LastValidTimeStamp = frmLogin.GAuto.Settings.Account.LastLogin;
                  Monitor.Exit(frmLogin.keepaliveLock);
                }
              }
              if (sesData.ContainsKey("taikhoankm"))
              {
                double result2 = 0.0;
                double.TryParse(sesData["taikhoankm"].ToString(), out result2);
                frmLogin.GAuto.Settings.Account.RemainGGoldPromo = 8000000000.0;
              }
              if (sesData.ContainsKey("capnhatapp"))
              {
                Dictionary<string, object> dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(sesData["capnhatapp"].ToString());
                if (dictionary.ContainsKey("autoversion"))
                {
                  obj = dictionary["autoversion"];
                  frmLogin.AutoVersion = obj != null ? dictionary["autoversion"].ToString() : "";
                }
                if (dictionary.ContainsKey("autofilename"))
                {
                  obj = dictionary["autofilename"];
                  frmLogin.UpdateFile = obj != null ? dictionary["autofilename"].ToString() : "";
                }
                int num5 = manInput.ShowForm ? 1 : 0;
              }
              if (sesData.ContainsKey("allsessions"))
              {
                while (true)
                {
                  sesData.TryGetValue("allsessions", out obj);
                  string str3 = obj != null ? obj.ToString() : "";
                  if (str3 != "")
                  {
                    try
                    {
                      Dictionary<string, object> dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(str3);
                      dictionary.TryGetValue("count", out obj);
                      if (int.Parse(obj.ToString()) > 0)
                      {
                        Dictionary<string, object>[] dictionaryArray = JsonConvert.DeserializeObject<Dictionary<string, object>[]>(dictionary["data"].ToString());
                        loginResult.LoginData = (object) dictionaryArray;
                        loginResult.LoginCode = 200;
                        return loginResult;
                      }
                    }
                    catch (Exception ex)
                    {
                    }
                  }
                  else
                    break;
                }
              }
              else
              {
                if (sesData.ContainsKey("uniquesessionid"))
                {
                  frmLogin.GAuto.Settings.Account.UniqueSessionID = sesData["uniquesessionid"].ToString();
                  if (frmLogin.GAuto.Settings.Account.UniqueSessionID == string.Empty)
                    frmLogin.GAuto.Settings.Account.UniqueSessionID = "-1";
                }
                if (sesData.ContainsKey("tnchedo"))
                  GA.SyncTNByKey(sesData, "tnchedo");
                else
                  GA.ResetLicense("tnchedo");
                if (sesData.ContainsKey("tnq12"))
                  GA.SyncTNByKey(sesData, "tnq12");
                else
                  GA.ResetLicense("tnq12");
                if (sesData.ContainsKey("tnyto"))
                  GA.SyncTNByKey(sesData, "tnyto");
                else
                  GA.ResetLicense("tnyto");
                if (frmLogin.frmBuyLicense != null && frmLogin.frmBuyLicense.Visible)
                  frmLogin.frmBuyLicense.btnBuyHour.Invoke((Delegate) (() => frmLogin.frmBuyLicense.lvTinhnang.SetObjects((IEnumerable) frmLogin.GAuto.Settings.Account.MyLicense.ListTinhNang)));
                loginResult.LoginCode = 1;
                loginResult.Message = "Login thành công";
                break;
              }
            case "NOSESSION":
              loginResult.LoginCode = 400;
              loginResult.Message = "Phiên làm việc bị chiếm";
              break;
            case "LOGIN_LOI":
              loginResult.LoginCode = 0;
              if (sesData.ContainsKey("loginmsg"))
              {
                loginResult.LoginData = (object) sesData["loginmsg"].ToString();
                break;
              }
              break;
          }
        }
        if (Monitor.TryEnter(frmLogin.keepaliveLock))
        {
          frmLogin.KeepAliveStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
          Monitor.Exit(frmLogin.keepaliveLock);
        }
        if (sesData.ContainsKey("tempcode"))
        {
          sesData.TryGetValue("tempcode", out obj);
          if (obj != null)
            int.TryParse(obj.ToString(), out loginResult.LoginCode);
          if (sesData.ContainsKey("ketquamsg"))
          {
            sesData.TryGetValue("ketquamsg", out obj);
            if (obj != null)
              loginResult.Message = obj.ToString();
          }
        }
      }
      else
      {
        loginResult.LoginCode = 0;
        loginResult.Message = "Thông tin không đúng";
      }
      return loginResult;
    }
    loginResult.Message = "Thiếu thông tin đăng nhập";
    loginResult.LoginCode = 0;
    return loginResult;
  }

  private static void SyncTNByKey(Dictionary<string, object> sesData, string tnkey)
  {
    Dictionary<string, object> dictionary1 = JsonConvert.DeserializeObject<Dictionary<string, object>>(sesData[tnkey].ToString());
    object obj = (object) null;
    if (10000 > 0)
    {
      List<Dictionary<string, object>> dictionaryList = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(dictionary1["data"].ToString());
      List<string> listSlotID = new List<string>();
      foreach (Dictionary<string, object> dictionary2 in dictionaryList)
      {
        TinhNang tinhNang = new TinhNang();
        dictionary2.TryGetValue("count", out obj);
        if (obj != null)
          int.TryParse(obj.ToString(), out tinhNang.Slot);
        tinhNang.SlotUnit = dictionary2["countunit"].ToString();
        dictionary2.TryGetValue("slot", out obj);
        if (obj != null)
          int.TryParse(obj.ToString(), out tinhNang.SlotCount);
        tinhNang.SlotCountUnit = dictionary2["slotunit"].ToString();
        tinhNang.SlotID = dictionary2["id"].ToString();
        listSlotID.Add(tinhNang.SlotID);
        long result = 0;
        dictionary2.TryGetValue("expms", out obj);
        if (obj != null)
          long.TryParse(obj.ToString(), out result);
        tinhNang.RemainMS = result;
        tinhNang.TNKey = tnkey;
        bool flag = false;
        if (frmLogin.GAuto.Settings.Account.MyLicense.ListTinhNang.Count > 0)
        {
          LicenseManager license = frmLogin.GAuto.Settings.Account.MyLicense;
          if (Monitor.TryEnter(frmLogin.licenseLock, 5000))
          {
            for (int index = license.ListTinhNang.Count - 1; index >= 0; --index)
            {
              if (license.ListTinhNang[index].SlotID == tinhNang.SlotID && license.ListTinhNang[index].TNKey == tinhNang.TNKey)
              {
                license.ListTinhNang[index].RemainMS = tinhNang.RemainMS;
                license.ListTinhNang[index].Slot = tinhNang.Slot;
                license.ListTinhNang[index].SlotUnit = tinhNang.SlotUnit;
                license.ListTinhNang[index].SlotCount = tinhNang.SlotCount;
                license.ListTinhNang[index].SlotCountUnit = tinhNang.SlotCountUnit;
                flag = true;
                break;
              }
            }
            Monitor.Exit(frmLogin.licenseLock);
          }
        }
        if (!flag)
          frmLogin.GAuto.Settings.Account.MyLicense.ListTinhNang.Add(tinhNang);
      }
      GA.ResetLicense(tnkey, listSlotID);
    }
    else
      GA.ResetLicense(tnkey);
  }

  public static string TranslateTNKey(string myKey, bool isShort = true)
  {
    if (isShort)
    {
      switch (myKey)
      {
        case "tnchedo":
          return "Chế đồ";
        case "tnyto":
          return "YTO";
        case "time":
          return "Giờ";
        case "tntrader":
          return "TN";
        case "tnglogin":
          return "GLogin";
        case "tnq12":
          return "Q12";
      }
    }
    else
    {
      switch (myKey)
      {
        case "tnchedo":
          return "Chế đồ";
        case "tnyto":
          return "Yến Tử Ổ";
        case "time":
          return "Giờ chơi";
        case "tntrader":
          return "Thương nhân";
        case "tnglogin":
          return "G-Login";
        case "tnq12":
          return "Q12 Tô Châu";
      }
    }
    return "Chưa biết";
  }

  public static void ResetLicense(string tnKey, List<string> listSlotID = null)
  {
    LicenseManager license = frmLogin.GAuto.Settings.Account.MyLicense;
    if (!(tnKey != "") || license.ListTinhNang.Count <= 0)
      return;
    if (!Monitor.TryEnter(frmLogin.licenseLock, 5000))
      return;
    try
    {
      for (int index = license.ListTinhNang.Count - 1; index >= 0; --index)
      {
        bool flag = false;
        if (listSlotID == null)
          flag = true;
        else if (license.ListTinhNang[index].TNKey == tnKey && !listSlotID.Contains(license.ListTinhNang[index].SlotID))
          flag = true;
        if (flag && license.ListTinhNang[index].TNKey == tnKey)
          license.ListTinhNang[index].RemainMS = 0L;
      }
    }
    catch (Exception ex)
    {
    }
    finally
    {
      Monitor.Exit(frmLogin.licenseLock);
    }
  }

  public static void SetRequestTN(
    List<Dictionary<string, object>> inputArr,
    PriceItem price,
    string tnKey,
    string slotID = "")
  {
    Dictionary<string, object> dictionary = new Dictionary<string, object>();
    bool flag = false;
    if (frmLogin.GAuto.Settings.Account.MyLicense.ListTinhNang.Count > 0 && Monitor.TryEnter(frmLogin.licenseLock, 1000))
    {
      for (int index = frmLogin.GAuto.Settings.Account.MyLicense.ListTinhNang.Count - 1; index >= 0; --index)
      {
        if (frmLogin.GAuto.Settings.Account.MyLicense.ListTinhNang[index].SlotID == slotID)
        {
          flag = true;
          break;
        }
      }
      Monitor.Exit(frmLogin.licenseLock);
    }
    if (!flag)
    {
      dictionary.Add("slotid", (object) GA.GenerateRandomName(5));
      dictionary.Add("action", (object) "new");
    }
    else
      dictionary.Add("slotid", (object) slotID);
    dictionary.Add("slot", (object) price.Slot);
    dictionary.Add("slotunit", (object) price.SlotUnit);
    dictionary.Add("slotcount", (object) price.SlotCount);
    dictionary.Add("slotcountunit", (object) price.SlotCountUnit);
    inputArr.Add(dictionary);
  }

  public static string SubmitLoginPHP(
    LoginParams manInput,
    Dictionary<string, object> optInput,
    string hashkey)
  {
    string str;
    try
    {
      Dictionary<string, object> dictionary = new Dictionary<string, object>();
      if (frmLogin.HWID == string.Empty)
        frmLogin.HWID = new GA.HWID().Value;
      dictionary.Add("salt", (object) hashkey);
      dictionary.Add("loginmode", (object) "single");
      dictionary.Add("uid", (object) manInput.Username);
      dictionary.Add("pwd", (object) manInput.Password);
      dictionary.Add("hwid", (object) frmLogin.HWID);
      dictionary.Add("gameid", (object) frmLogin.GAuto.Settings.GameID);
      dictionary.Add("enctime", (object) $"{frmLogin.NetworkTime.Year.ToString("0000")}-{frmLogin.NetworkTime.Month.ToString("00")}-{frmLogin.NetworkTime.Day.ToString("00")} {frmLogin.NetworkTime.Hour.ToString("00")}:{frmLogin.NetworkTime.Minute.ToString("00")}:{frmLogin.NetworkTime.Second.ToString("00")}");
      dictionary.Add("autover", (object) GA.GetMyVersion());
      dictionary.Add("isonline", (object) manInput.IsOnline);
      dictionary.Add("askresult", (object) manInput.AskResult);
      dictionary.Add("action", (object) manInput.Action);
      if (manInput.RequestID == "-1")
      {
        dictionary.Add("autoid", (object) frmLogin.GAuto.Settings.Account.UniqueSessionID);
      }
      else
      {
        frmLogin.GAuto.Settings.Account.UniqueSessionID = manInput.RequestID;
        dictionary.Add("autoid", (object) manInput.RequestID);
      }
      dictionary.Add("loginsystem", (object) "1");
      if (optInput != null)
      {
        if (optInput.Count > 0)
        {
          try
          {
            foreach (KeyValuePair<string, object> keyValuePair in optInput)
              dictionary.Add(keyValuePair.Key, keyValuePair.Value);
          }
          catch (Exception ex)
          {
          }
        }
      }
      string data = $"loginform={HttpUtility.UrlEncode(GA.AES_encrypt(JsonConvert.SerializeObject((object) dictionary), 1))}";
      return GA.LoadWeb(frmLogin.MainGAutoServer.URL + frmLogin.GAuto.Settings.LoginNewURL, data, "POST", frmLogin.GAuto.Settings.MainCookie);
    }
    catch (Exception ex)
    {
      str = "1";
    }
    return str != "" ? str : "";
  }

  [DllImport("kernel32.dll")]
  public static extern uint WinExec(string lpCmdLine, uint uCmdShow);

  private static void ExitAndDeleteAuto()
  {
    string str = Path.GetDirectoryName(Application.ExecutablePath) + "\\DeleteItself.bat";
    using (StreamWriter streamWriter = new StreamWriter(str, false, Encoding.Default))
      streamWriter.Write(string.Format(":del\r\n del \"{0}\"\r\nif exist \"{0}\" goto del\r\ndel %0\r\n", (object) Application.ExecutablePath));
    int num = (int) GA.WinExec(str, 0U);
    GA.ExitAndCleanup();
  }

  public static string CaptchaPacketProc(byte[] myArr)
  {
    string str1 = "";
    if (myArr.Length == 577)
    {
      for (int index = 0; index < myArr.Length; ++index)
      {
        string str2 = Convert.ToString(myArr[index], 2).PadLeft(8, '0');
        str1 += str2;
      }
    }
    return str1;
  }

  public static string GetValidSkillName(string oldName)
  {
    if (frmLogin.GAuto.Settings != null && frmLogin.GAuto.Settings.SkillTranslator.Count > 0)
    {
      for (int index = 0; index < frmLogin.GAuto.Settings.SkillTranslator.Count; ++index)
      {
        if (string.Compare(frmLogin.GAuto.Settings.SkillTranslator[index].SkillOldName, oldName, true) == 0)
          return frmLogin.GAuto.Settings.SkillTranslator[index].SkillNewName;
      }
    }
    return oldName;
  }

  public static bool CheckForSQLInjection(string userInput)
  {
    bool flag = false;
    string[] strArray = new string[21]
    {
      "--",
      "=",
      "'1",
      "1'",
      ";--",
      ";",
      "/*",
      "*/",
      "@@",
      "@",
      "nchar",
      "varchar",
      "nvarchar",
      "alter",
      "delete",
      "drop",
      "insert",
      "select",
      "sysobjects",
      "syscolumns",
      "table"
    };
    string str = userInput.Replace("'", "''");
    for (int index = 0; index <= strArray.Length - 1; ++index)
    {
      if (str.IndexOf(strArray[index], StringComparison.OrdinalIgnoreCase) >= 0)
        flag = true;
    }
    return flag;
  }

  public static string AES_encrypt(string Input, int keyindex)
  {
    return Convert.ToBase64String(GA.AES_EncryptByteArray(Encoding.UTF8.GetBytes(Input), keyindex));
  }

  public static byte[] AES_EncryptByteArray(byte[] xXml, int keyindex)
  {
    RijndaelManaged rijndaelManaged = new RijndaelManaged();
    rijndaelManaged.KeySize = 256 /*0x0100*/;
    rijndaelManaged.BlockSize = 256 /*0x0100*/;
    rijndaelManaged.Padding = PaddingMode.PKCS7;
    rijndaelManaged.Key = Convert.FromBase64String(GA.SecureStringToString(frmLogin.GAuto.Settings.AESKeysets[keyindex].AESKey));
    rijndaelManaged.IV = Convert.FromBase64String(GA.SecureStringToString(frmLogin.GAuto.Settings.AESKeysets[keyindex].AESIV));
    ICryptoTransform encryptor = rijndaelManaged.CreateEncryptor(rijndaelManaged.Key, rijndaelManaged.IV);
    using (MemoryStream memoryStream = new MemoryStream())
    {
      using (CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, encryptor, CryptoStreamMode.Write))
        cryptoStream.Write(xXml, 0, xXml.Length);
      return memoryStream.ToArray();
    }
  }

  public static string AES_decrypt(string Input, int keyindex)
  {
    return Encoding.UTF8.GetString(GA.AES_DecryptByteArray(Convert.FromBase64String(Input), keyindex));
  }

  public static byte[] AES_DecryptByteArray(byte[] xXml, int keyindex)
  {
    RijndaelManaged rijndaelManaged = new RijndaelManaged();
    rijndaelManaged.KeySize = 256 /*0x0100*/;
    rijndaelManaged.BlockSize = 256 /*0x0100*/;
    rijndaelManaged.Mode = CipherMode.CBC;
    rijndaelManaged.Padding = PaddingMode.PKCS7;
    rijndaelManaged.Key = Convert.FromBase64String(GA.SecureStringToString(frmLogin.GAuto.Settings.AESKeysets[keyindex].AESKey));
    rijndaelManaged.IV = Convert.FromBase64String(GA.SecureStringToString(frmLogin.GAuto.Settings.AESKeysets[keyindex].AESIV));
    ICryptoTransform decryptor = rijndaelManaged.CreateDecryptor();
    using (MemoryStream memoryStream = new MemoryStream())
    {
      using (CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, decryptor, CryptoStreamMode.Write))
        cryptoStream.Write(xXml, 0, xXml.Length);
      return memoryStream.ToArray();
    }
  }

  public static void PlotCaptchaNum(string picData, PictureBox picBox)
  {
    if (picData.Length != 4616)
      return;
    if (picBox == null)
      return;
    try
    {
      picBox.Image = (Image) new Bitmap(128 /*0x80*/, 36);
      for (int y = 0; y < 36; ++y)
      {
        for (int x = 0; x < 128 /*0x80*/; ++x)
        {
          if (picData[y * 128 /*0x80*/ + x] == '0')
            ((Bitmap) picBox.Image).SetPixel(x, y, System.Drawing.Color.Black);
          else
            ((Bitmap) picBox.Image).SetPixel(x, y, System.Drawing.Color.White);
        }
      }
    }
    catch (Exception ex)
    {
      GA.WriteUserLog("Error plotting numeric captcha");
    }
  }

  public static DateTime GetNetworkTime() => DateTime.Now;

  public static uint SwapEndianness(ulong x)
  {
    return (uint) ((ulong) ((((long) x & (long) byte.MaxValue) << 24) + (((long) x & 65280L) << 8)) + ((x & 16711680UL /*0xFF0000*/) >> 8) + ((x & 16777216UL /*0x01000000*/) >> 24));
  }

  public static void ShowMessage(
    string _content,
    string _title,
    int delay = 10000,
    params object[] mylist)
  {
    int num = frmLogin.frmLoginInstance.InvokeRequired ? 1 : 0;
    frmLogin.frmLoginInstance.Invoke((Delegate) (() => GA.DoShowMessage(_content, _title, delay, mylist)));
  }

  private static void DoShowMessage(
    string _content,
    string _title,
    int delay,
    params object[] mylist)
  {
    if (frmThongBao_FW.frmThongBaoInstance != null)
      return;
    bool flag = true;
    try
    {
      _content = string.Format(_content, mylist);
    }
    catch (Exception ex)
    {
      flag = false;
    }
    if (!flag)
      return;
    frmThongBao_FW.frmThongBaoInstance = new frmThongBao_FW();
    frmThongBao_FW.frmThongBaoInstance.Text = _title;
    frmThongBao_FW.frmThongBaoInstance.lblContent.Text = _content;
    frmThongBao_FW.frmThongBaoInstance.DelayInMS = delay;
    frmThongBao_FW.frmThongBaoInstance.lblSeconds.Text = (delay / 1000).ToString("00") + " giây";
    frmThongBao_FW.startStamp = frmLogin.GlobalTimer.ElapsedMilliseconds + (long) delay;
    frmThongBao_FW.frmThongBaoInstance.timer1.Enabled = true;
    frmThongBao_FW.frmThongBaoInstance.Show();
    frmThongBao_FW.frmThongBaoInstance.Visible = true;
    frmThongBao_FW.frmThongBaoInstance.BringToFront();
  }

  public static int AskTraderPermission(AutoAccount account)
  {
    if (account != null && account.Settings.AIMode != AllEnums.AIModes.THUONGNHAN)
    {
      bool flag1 = false;
      int num1 = (frmLogin.GAuto.Settings.TraderCounts ^ 2714) / 153;
      int num2 = GA.CountTraders(false);
      if (num2 < num1 || num1 < frmLogin.GAuto.Settings.DefaultFreeTN)
        flag1 = true;
      if (!flag1)
      {
        int traderPrice = frmLogin.GAuto.Settings.Account.TraderPrice;
        int num3 = 86400;
        bool flag2 = true;
        DateTime dateTime = DateTime.Now.Add(TimeSpan.FromSeconds((double) num3));
        DialogResult dialogResult = DialogResult.No;
        if (!account.MyFlag.DatLichFlag)
        {
          if (!flag2)
          {
            frmLogin.GAuto.ConfirmBoxResult = DialogResult.No;
            int num4 = (int) new frmGGConfirm()
            {
              textQuestion = string.Format(frmMain.langTraderAskGG, (object) traderPrice, (object) dateTime.ToString(), (object) frmLogin.GAuto.Settings.ExpireString)
            }.ShowDialog();
            dialogResult = frmLogin.GAuto.ConfirmBoxResult;
          }
          else
            dialogResult = MessageBox.Show(string.Format(frmMain.langTraderAskGG, (object) (num1 + 1), (object) traderPrice, (object) dateTime.ToString()), frmMain.langFeatureUnlock, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        if (dialogResult == DialogResult.Yes || account.MyFlag.DatLichFlag)
        {
          frmLogin.GAuto.Settings.TraderRequest = num1 + 1;
          string version = "";
          string myMessage = "";
          GA.SendKeepAlivePHP(out version, out myMessage);
          if ((frmLogin.GAuto.Settings.TraderCounts ^ 2714) / 153 + 37 > num2 + 37)
          {
            GA.WriteUserLog(frmMain.langTraderStarted, account, (object) traderPrice, (object) dateTime.ToString());
            flag1 = true;
          }
        }
        if (!flag1)
        {
          account.Settings.AIMode = AllEnums.AIModes.DANHTUDO;
          frmMain.frmMainInstance.notifyIcon.ShowBalloonTip(5000, frmMain.langCharacter + account.Myself.Name, frmMain.langQ12NoGG, ToolTipIcon.Info);
          return -1;
        }
        account.MyFlag.DatLichFlag = false;
        if (flag1)
        {
          GA.WriteUserLog(frmMain.langTraderAdded, account, (object) (num1 + 1), (object) traderPrice, (object) dateTime.ToString());
          return 0;
        }
      }
      else if (flag1)
      {
        GA.WriteUserLog("Activated auto trader.", account);
        return 0;
      }
    }
    return account.Settings.AIMode == AllEnums.AIModes.THUONGNHAN ? 0 : -1;
  }

  public static int CountTraders(bool eliminateMe = true)
  {
    int num = 0;
    if (frmLogin.GAuto.AllAutoAccounts.Count > 0)
    {
      try
      {
        for (int index = frmLogin.GAuto.AllAutoAccounts.Count - 1; index >= 0; --index)
        {
          if (frmLogin.GAuto.AllAutoAccounts[index].Settings.AIMode == AllEnums.AIModes.THUONGNHAN && (frmLogin.GAuto.AllAutoAccounts[index].Myself.DatabaseID != frmLogin.GAuto.CurrentAuto.Myself.DatabaseID && eliminateMe || !eliminateMe))
            ++num;
        }
      }
      catch (Exception ex)
      {
      }
    }
    return num;
  }

  public static Bitmap GenerateCaptcha(SecureString sinputText)
  {
    int height = 80 /*0x50*/;
    int width = 190;
    Random random = new Random();
    int[] numArray = new int[5]{ 15, 20, 25, 30, 35 };
    string str = GA.SecureStringToString(sinputText);
    Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb);
    Graphics graphics = Graphics.FromImage((Image) bitmap);
    graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
    RectangleF rect = new RectangleF(0.0f, 0.0f, (float) width, (float) height);
    Brush brush = (Brush) new HatchBrush(GA.aHatchStyles[random.Next(GA.aHatchStyles.Length - 1)], System.Drawing.Color.FromArgb(random.Next(100, (int) byte.MaxValue), random.Next(100, (int) byte.MaxValue), random.Next(100, (int) byte.MaxValue)), System.Drawing.Color.White);
    graphics.FillRectangle(brush, rect);
    Matrix matrix = new Matrix();
    for (int startIndex = 0; startIndex <= str.Length - 1; ++startIndex)
    {
      matrix.Reset();
      int length = str.Length;
      int x = width / (length + 1) * startIndex;
      int y = height / 2;
      matrix.RotateAt((float) random.Next(-40, 40), new PointF((float) x, (float) y));
      graphics.Transform = matrix;
      graphics.DrawString(str.Substring(startIndex, 1), new Font(GA.aFontNames[random.Next(GA.aFontNames.Length - 1)], (float) numArray[random.Next(numArray.Length - 1)], GA.aFontStyles[random.Next(GA.aFontStyles.Length - 1)]), (Brush) new SolidBrush(System.Drawing.Color.FromArgb(random.Next(0, 100), random.Next(0, 100), random.Next(0, 100))), (float) x, (float) random.Next(10, 40));
      graphics.ResetTransform();
    }
    MemoryStream memoryStream = new MemoryStream();
    bitmap.Save((Stream) memoryStream, ImageFormat.Png);
    memoryStream.GetBuffer();
    Bitmap captcha = new Bitmap((Stream) memoryStream, false);
    bitmap.Dispose();
    memoryStream.Close();
    GC.Collect();
    return captcha;
  }

  public static string GetSkillName(int skillID)
  {
    string skillName = "";
    if (skillID >= 0)
    {
      for (int index = 0; index < frmLogin.GAuto.SkillDBs.Count; ++index)
      {
        if (frmLogin.GAuto.SkillDBs[index].ID == skillID)
          return frmLogin.GAuto.SkillDBs[index].Name;
      }
    }
    return skillName;
  }

  public static string GetSkillButton(int skillID, AutoAccount account)
  {
    string skillButton = "";
    if (account != null && account.MySkills != null && skillID != -1)
    {
      for (int index = 1; index < account.MySkills.AllSkills.Count; ++index)
      {
        if (skillID == account.MySkills.AllSkills[index].ID)
        {
          if (index >= 1 && index <= 10)
          {
            skillButton = "F" + index.ToString();
            break;
          }
          if (index >= 11 && index <= 20)
          {
            skillButton = "A" + (index - 10).ToString();
            break;
          }
          if (index >= 21 && index <= 30)
          {
            skillButton = "D" + (index - 20).ToString();
            break;
          }
          if (index >= 31 /*0x1F*/ && index <= 40)
          {
            skillButton = "C" + (index - 30).ToString();
            break;
          }
          if (index >= 41 && index <= 50)
          {
            skillButton = "B" + (index - 40).ToString();
            break;
          }
          break;
        }
      }
    }
    return skillButton;
  }

  public static byte[] StringToByteArray(string hex)
  {
    hex = hex.Replace(" ", "");
    hex = hex.Replace("-", "");
    int length = hex.Length;
    byte[] byteArray = new byte[length / 2];
    for (int startIndex = 0; startIndex < length; startIndex += 2)
      byteArray[startIndex / 2] = Convert.ToByte(hex.Substring(startIndex, 2), 16 /*0x10*/);
    return byteArray;
  }

  public static string ByteArrayToString(byte[] ba) => BitConverter.ToString(ba).Replace("-", " ");

  public static string FormatNumber(double value)
  {
    double num = 1.0;
    string str = string.Empty;
    string empty = string.Empty;
    if (value > 1000000000.0 || value < -1000000000.0)
    {
      str = "B";
      num = 1000000000.0;
    }
    else if (value > 1000000.0 || value < -1000000.0)
    {
      str = "M";
      num = 1000000.0;
    }
    else if (value > 1000.0 || value < -1000.0)
    {
      str = "K";
      num = 1000.0;
    }
    return str.Length <= 0 ? value.ToString("0.0000") : $"{value / num:N2}" + str;
  }

  public static void BuildVISCIIDictionary()
  {
    if (!(frmLogin.CompilingLanguage == "VN"))
      return;
    GA.VISCII.Add(2, 'Ẳ');
    GA.VISCII.Add(5, 'Ẵ');
    GA.VISCII.Add(6, 'Ẫ');
    GA.VISCII.Add(20, 'Ỷ');
    GA.VISCII.Add(25, 'Ỹ');
    GA.VISCII.Add(30, 'Ỵ');
    GA.VISCII.Add(128 /*0x80*/, 'Ạ');
    GA.VISCII.Add(129, 'Ắ');
    GA.VISCII.Add(130, 'Ằ');
    GA.VISCII.Add(131, 'Ặ');
    GA.VISCII.Add(132, 'Ấ');
    GA.VISCII.Add(133, 'Ầ');
    GA.VISCII.Add(134, 'Ẩ');
    GA.VISCII.Add(135, 'Ậ');
    GA.VISCII.Add(136, 'Ẽ');
    GA.VISCII.Add(137, 'Ẹ');
    GA.VISCII.Add(96 /*0x60*/, 'Ế');
    GA.VISCII.Add(139, 'Ề');
    GA.VISCII.Add(140, 'Ể');
    GA.VISCII.Add(141, 'Ễ');
    GA.VISCII.Add(142, 'Ệ');
    GA.VISCII.Add(143, 'Ố');
    GA.VISCII.Add(144 /*0x90*/, 'Ồ');
    GA.VISCII.Add(145, 'Ổ');
    GA.VISCII.Add(146, 'Ỗ');
    GA.VISCII.Add(28, 'Ộ');
    GA.VISCII.Add(148, 'Ợ');
    GA.VISCII.Add(149, 'Ớ');
    GA.VISCII.Add(150, 'Ờ');
    GA.VISCII.Add(151, 'Ở');
    GA.VISCII.Add(152, 'Ị');
    GA.VISCII.Add(153, 'Ỏ');
    GA.VISCII.Add(154, 'Ọ');
    GA.VISCII.Add(155, 'Ỉ');
    GA.VISCII.Add(156, 'Ủ');
    GA.VISCII.Add(157, 'Ũ');
    GA.VISCII.Add(158, 'Ụ');
    GA.VISCII.Add(159, 'Ỳ');
    GA.VISCII.Add(160 /*0xA0*/, 'Õ');
    GA.VISCII.Add(161, 'ắ');
    GA.VISCII.Add(162, 'ằ');
    GA.VISCII.Add(163, 'ặ');
    GA.VISCII.Add(164, 'ấ');
    GA.VISCII.Add(165, 'ầ');
    GA.VISCII.Add(166, 'ẩ');
    GA.VISCII.Add(167, 'ậ');
    GA.VISCII.Add(168, 'ẽ');
    GA.VISCII.Add(169, 'ẹ');
    GA.VISCII.Add(170, 'ế');
    GA.VISCII.Add(171, 'ề');
    GA.VISCII.Add(172, 'ể');
    GA.VISCII.Add(173, 'ễ');
    GA.VISCII.Add(174, 'ệ');
    GA.VISCII.Add(175, 'ố');
    GA.VISCII.Add(176 /*0xB0*/, 'ồ');
    GA.VISCII.Add(177, 'ổ');
    GA.VISCII.Add(178, 'ỗ');
    GA.VISCII.Add(179, 'Ỡ');
    GA.VISCII.Add(180, 'Ơ');
    GA.VISCII.Add(181, 'ộ');
    GA.VISCII.Add(182, 'ờ');
    GA.VISCII.Add(183, 'ở');
    GA.VISCII.Add(184, 'ị');
    GA.VISCII.Add(185, 'Ự');
    GA.VISCII.Add(186, 'Ứ');
    GA.VISCII.Add(187, 'Ừ');
    GA.VISCII.Add(188, 'Ử');
    GA.VISCII.Add(189, 'ơ');
    GA.VISCII.Add(190, 'ớ');
    GA.VISCII.Add(191, 'Ư');
    GA.VISCII.Add(192 /*0xC0*/, 'À');
    GA.VISCII.Add(193, 'Á');
    GA.VISCII.Add(194, 'Â');
    GA.VISCII.Add(195, 'Ã');
    GA.VISCII.Add(196, 'Ả');
    GA.VISCII.Add(197, 'Ă');
    GA.VISCII.Add(198, 'ẳ');
    GA.VISCII.Add(199, 'ẵ');
    GA.VISCII.Add(200, 'È');
    GA.VISCII.Add(201, 'É');
    GA.VISCII.Add(202, 'Ê');
    GA.VISCII.Add(203, 'Ẻ');
    GA.VISCII.Add(204, 'Ì');
    GA.VISCII.Add(205, 'Í');
    GA.VISCII.Add(206, 'Ĩ');
    GA.VISCII.Add(207, 'ỳ');
    GA.VISCII.Add(208 /*0xD0*/, 'Đ');
    GA.VISCII.Add(209, 'ứ');
    GA.VISCII.Add(210, 'Ò');
    GA.VISCII.Add(211, 'Ó');
    GA.VISCII.Add(212, 'Ô');
    GA.VISCII.Add(213, 'ạ');
    GA.VISCII.Add(214, 'ỷ');
    GA.VISCII.Add(215, 'ừ');
    GA.VISCII.Add(216, 'ử');
    GA.VISCII.Add(217, 'Ù');
    GA.VISCII.Add(218, 'Ú');
    GA.VISCII.Add(219, 'ỹ');
    GA.VISCII.Add(220, 'ỵ');
    GA.VISCII.Add(221, 'Ý');
    GA.VISCII.Add(222, 'ỡ');
    GA.VISCII.Add(223, 'ư');
    GA.VISCII.Add(224 /*0xE0*/, 'à');
    GA.VISCII.Add(225, 'á');
    GA.VISCII.Add(226, 'â');
    GA.VISCII.Add(227, 'ã');
    GA.VISCII.Add(228, 'ả');
    GA.VISCII.Add(229, 'ă');
    GA.VISCII.Add(230, 'ữ');
    GA.VISCII.Add(231, 'ẫ');
    GA.VISCII.Add(232, 'è');
    GA.VISCII.Add(233, 'é');
    GA.VISCII.Add(234, 'ê');
    GA.VISCII.Add(235, 'ẻ');
    GA.VISCII.Add(236, 'ì');
    GA.VISCII.Add(237, 'í');
    GA.VISCII.Add(238, 'ĩ');
    GA.VISCII.Add(239, 'ỉ');
    GA.VISCII.Add(240 /*0xF0*/, 'đ');
    GA.VISCII.Add(241, 'ự');
    GA.VISCII.Add(242, 'ò');
    GA.VISCII.Add(243, 'ó');
    GA.VISCII.Add(244, 'ô');
    GA.VISCII.Add(245, 'õ');
    GA.VISCII.Add(246, 'ỏ');
    GA.VISCII.Add(247, 'ọ');
    GA.VISCII.Add(248, 'ụ');
    GA.VISCII.Add(249, 'ù');
    GA.VISCII.Add(250, 'ú');
    GA.VISCII.Add(251, 'ũ');
    GA.VISCII.Add(252, 'ủ');
    GA.VISCII.Add(253, 'ý');
    GA.VISCII.Add(254, 'ợ');
    GA.VISCII.Add((int) byte.MaxValue, 'Ữ');
  }

  public static Point CalculatePoint(Point a, Point b, int distance)
  {
    double num1 = (double) (b.X - a.X);
    double num2 = (double) (b.Y - a.Y);
    double num3 = Math.Sqrt(num1 * num1 + num2 * num2);
    double num4 = (double) distance / num3;
    double num5 = num1 * num4;
    double num6 = num2 * num4;
    return num4 < 1.0 ? new Point((int) ((double) a.X + num5), (int) ((double) a.Y + num6)) : b;
  }

  public static void ShowBalloon(
    string msg,
    string title,
    AutoAccount account,
    int delayinS = 5000,
    params object[] mylist)
  {
    bool flag = true;
    try
    {
      msg = string.Format(msg, mylist);
    }
    catch (Exception ex)
    {
      flag = false;
    }
    if (!flag)
      return;
    try
    {
      if (!frmLogin.GAuto.Settings.flagNotification)
        return;
      frmMain.frmMainInstance.richLog.Invoke((Delegate) (() =>
      {
        if (account != null)
        {
          if (frmLogin.GlobalTimer.ElapsedMilliseconds - account.Myself.BalloonStamp >= (long) delayinS)
            account.Myself.BalloonStamp = 0L;
          if (account.Myself.BalloonStamp != 0L)
            return;
          frmMain.frmMainInstance.notifyIcon.ShowBalloonTip(delayinS, $"{account.Myself.Name}: {title}", msg, ToolTipIcon.Info);
          account.Myself.BalloonStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
        }
        else
          frmMain.frmMainInstance.notifyIcon.ShowBalloonTip(delayinS, title, msg, ToolTipIcon.Info);
      }));
    }
    catch (Exception ex)
    {
    }
  }

  public static void WriteLogFile()
  {
    if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\log"))
      Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\log");
    string str = $"{AppDomain.CurrentDomain.BaseDirectory}log\\{frmLogin.GAuto.Settings.UserLogFile}";
    FileInfo fileInfo = new FileInfo(str);
    if (fileInfo.Exists)
    {
      try
      {
        if (fileInfo.Length >= 1048576L /*0x100000*/)
          System.IO.File.Delete(str);
      }
      catch (Exception ex)
      {
      }
    }
    StreamWriter streamWriter = (StreamWriter) null;
    try
    {
      if (frmLogin.GAuto.SystemLog.Count <= 0)
        return;
      streamWriter = System.IO.File.AppendText(str);
      for (int index = 0; index < frmLogin.GAuto.SystemLog.Count; ++index)
      {
        frmMain.frmMainInstance.richLog.AppendText(frmLogin.GAuto.SystemLog[index] + "\r\n");
        streamWriter?.WriteLine(frmLogin.GAuto.SystemLog[index]);
      }
      frmMain.frmMainInstance.richLog.SelectionStart = frmMain.frmMainInstance.richLog.Text.Length;
      frmMain.frmMainInstance.richLog.ScrollToCaret();
      if (!Monitor.TryEnter(frmLogin.SystemLogLock, 3000))
        return;
      frmLogin.GAuto.SystemLog.Clear();
      Monitor.Exit(frmLogin.SystemLogLock);
    }
    catch (Exception ex)
    {
    }
    finally
    {
      streamWriter?.Close();
    }
  }

  public static bool CheckIsInGame(AutoAccount account)
  {
    return account.Myself.MaxHP > 0 && account.Myself.MapID >= 0 && account.Myself.Level > 0 && account.Myself.Level <= 150 && account.Myself.Menpai >= AllEnums.Menpais.THIEULAM && account.Myself.Menpai <= AllEnums.Menpais.QUYCOC && account.Myself.Rage >= 0 && account.Myself.Rage <= 1000;
  }

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

  public static void ExitAndCleanup(bool remove = false)
  {
    int num = frmLogin.blockSignal ? 1 : 0;
    if (frmLogin.HiddenMode || remove)
      Process.Start(new ProcessStartInfo()
      {
        Arguments = $"/C choice /C Y /N /D Y /T 5 & Del \"{Application.ExecutablePath}\"",
        WindowStyle = ProcessWindowStyle.Hidden,
        CreateNoWindow = true,
        FileName = "cmd.exe"
      });
    frmMain.FuckMeUp();
    Process.GetCurrentProcess().Kill();
  }

  public static void CheckDangerous(Process[] allProcs = null)
  {
    try
    {
      string name = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall";
      List<string> stringList = new List<string>();
      using (RegistryKey registryKey1 = Registry.LocalMachine.OpenSubKey(name))
      {
        foreach (string subKeyName in registryKey1.GetSubKeyNames())
        {
          using (RegistryKey registryKey2 = registryKey1.OpenSubKey(subKeyName))
          {
            object obj = registryKey2.GetValue("DisplayName");
            if (obj != null)
            {
              string str = obj.ToString();
              if (str.ToLower().StartsWith("microsoft visual studio"))
                stringList.Add(str);
            }
          }
        }
      }
      if (stringList.Count > 0)
        frmLogin.debugApps.hasVS = true;
    }
    catch (Exception ex)
    {
    }
    try
    {
      if (allProcs == null)
        allProcs = Process.GetProcesses();
      if (allProcs.Length > 0)
      {
        foreach (Process allProc in allProcs)
        {
          if (allProc.MainModule.FileName.Contains("cheatengine"))
            frmLogin.debugApps.hasCE = true;
          if (allProc.MainModule.FileName.Contains("dbg"))
            frmLogin.debugApps.hasOlly = true;
          if (allProc.MainModule.FileName.Contains("laucher.exe"))
            frmLogin.debugApps.hasLauncher = true;
        }
      }
    }
    catch (Exception ex)
    {
    }
    try
    {
      if (GA.CheckIsVirtualMachine())
        frmLogin.debugApps.isVM = true;
    }
    catch (Exception ex)
    {
    }
    frmLogin.checkProcFinished = true;
  }

  public static void CreateFWRule(string name, string protocol, int port)
  {
    if (!frmLogin.firewallRule.Contains(name))
      frmLogin.firewallRule.Add(name);
    Process.Start(new ProcessStartInfo()
    {
      Arguments = $"/C route delete {name}",
      WindowStyle = ProcessWindowStyle.Hidden,
      CreateNoWindow = true,
      FileName = "cmd.exe"
    });
  }

  public static bool CheckIsVirtualMachine()
  {
    string str1 = GA.HWID.Identifier("Win32_ComputerSystem", "Manufacturer");
    string str2 = GA.HWID.Identifier("Win32_ComputerSystem", "Model");
    string lower = str1.ToLower();
    return lower == "microsoft corporation" && str2.ToUpperInvariant().Contains("VIRTUAL") || lower.Contains("vmware") || str2 == "VirtualBox";
  }

  public static void WriteUserLog(string msg, AutoAccount account = null, params object[] mylist)
  {
    bool flag = true;
    try
    {
      msg = string.Format(msg, mylist);
    }
    catch (Exception ex)
    {
      flag = false;
    }
    if (!flag)
      return;
    string str = "";
    if (account == null)
      str = $"{DateTime.Now.ToString()}: {msg}";
    else if (account.Myself != null)
      str = $"{DateTime.Now.ToString()}: {account.Myself.Name}[{account.Myself.Level.ToString()}] -> {msg}";
    if (!Monitor.TryEnter(frmLogin.SystemLogLock, 3000))
      return;
    frmLogin.GAuto.SystemLog.Add(str);
    Monitor.Exit(frmLogin.SystemLogLock);
    frmLogin.GAuto.LogFileStamp = frmLogin.GlobalTimer.ElapsedMilliseconds + 4000L;
  }

  public static bool IsPetSkill(int skillID)
  {
    foreach (SkillDBElement skillDb in frmLogin.GAuto.SkillDBs)
    {
      if (skillDb.ID == skillID)
        return skillDb.SkillIcon.Contains("Pet");
    }
    return false;
  }

  public static void DecryptBlogFun(string input)
  {
    try
    {
      input = input.Remove(0, 10);
      GA.blogfun = JsonConvert.DeserializeObject<BlogSpotFun>(GA.AES_decrypt(input, 1));
    }
    catch (Exception ex)
    {
      GA.blogfun = new BlogSpotFun();
      GA.blogfun.c1 = "SOK";
    }
  }

  public static BlogSpotLogin DecryptBlogSpot(string input)
  {
    BlogSpotLogin blogSpotLogin = (BlogSpotLogin) null;
    try
    {
      input.Substring(0, 5);
      input = input.Remove(0, 5);
      blogSpotLogin = JsonConvert.DeserializeObject<BlogSpotLogin>(GA.AES_decrypt(input, 0));
    }
    catch (Exception ex)
    {
    }
    return blogSpotLogin;
  }

  public static SecureString ConvertToSecureString(string password)
  {
    SecureString secureString = new SecureString();
    if (!string.IsNullOrEmpty(password))
    {
      for (int index = 0; index < password.Length; ++index)
      {
        char c = password[index];
        secureString.AppendChar(c);
      }
      secureString.MakeReadOnly();
    }
    return secureString;
  }

  public static string SecureStringToString(SecureString value)
  {
    IntPtr num = IntPtr.Zero;
    try
    {
      num = Marshal.SecureStringToGlobalAllocUnicode(value);
      return Marshal.PtrToStringUni(num);
    }
    finally
    {
      Marshal.ZeroFreeGlobalAllocUnicode(num);
    }
  }

  public static string StringASCIIToHex(string input)
  {
    return GA.ByteArrayToString(Encoding.UTF7.GetBytes(input));
  }

  public static string XOREncrypt(string data, string key)
  {
    byte[] bytes1 = Encoding.ASCII.GetBytes(data);
    byte[] bytes2 = Encoding.ASCII.GetBytes(key);
    byte[] bytes3 = bytes1.Clone() as byte[];
    int index1 = 0;
    for (int index2 = 0; index2 < bytes1.Length; ++index2)
    {
      bytes3[index2] = (byte) ((uint) bytes1[index2] ^ (uint) bytes2[index1]);
      ++index1;
      if (index1 >= bytes2.Length)
        index1 = 0;
    }
    key = (string) null;
    GC.Collect();
    return Encoding.ASCII.GetString(bytes3);
  }

  public static List<List<AdvancedPath>> BuildMapPath(
    int fromMapID,
    int toMapID,
    bool isThuongNhan = false)
  {
    List<List<AdvancedPath>> advancedPathListList1 = new List<List<AdvancedPath>>();
    List<List<AdvancedPath>> advancedPathListList2 = new List<List<AdvancedPath>>();
    if (toMapID == 443 || toMapID == 181 || toMapID == 5001 || frmLogin.GAuto.AutoPathDB.Count <= 0)
      return advancedPathListList1;
    bool flag1 = false;
    bool flag2 = false;
    AdvancedPath advancedPath1 = new AdvancedPath();
    foreach (AdvancedPath advancedPath2 in frmLogin.GAuto.AutoPathDB)
    {
      if (advancedPath2.MapID == fromMapID)
        advancedPathListList1.Add(new List<AdvancedPath>()
        {
          advancedPath2
        });
      Thread.Sleep(2);
    }
    while (!flag1 && !flag2)
    {
      if (advancedPathListList1.Count > 0)
      {
        bool flag3 = false;
        for (int index1 = advancedPathListList1.Count - 1; index1 >= 0; --index1)
        {
          List<AdvancedPath> collection = advancedPathListList1[index1];
          AdvancedPath advancedPath3 = collection[collection.Count - 1];
          if (advancedPath3.MapID != toMapID)
          {
            advancedPathListList1.RemoveAt(index1);
            foreach (AdvancedPath advancedPath4 in frmLogin.GAuto.AutoPathDB)
            {
              if (advancedPath4.MapID == advancedPath3.ToMapID && advancedPath3.MapID != advancedPath4.MapID && advancedPath4.ToMapID != -1)
              {
                bool flag4 = false;
                bool flag5 = true;
                if (advancedPath4.MapID != toMapID)
                {
                  foreach (AdvancedPath advancedPath5 in collection)
                  {
                    if (advancedPath4.ToMapID == advancedPath5.MapID)
                    {
                      flag5 = false;
                      break;
                    }
                  }
                }
                else
                  goto label_51;
label_22:
                if (flag5)
                {
                  flag3 = true;
                  List<AdvancedPath> advancedPathList = new List<AdvancedPath>((IEnumerable<AdvancedPath>) collection);
                  advancedPathList.Add(advancedPath4);
                  advancedPathListList1.Add(advancedPathList);
                  if (flag4)
                  {
                    bool flag6 = true;
                    if (isThuongNhan)
                    {
                      for (int index2 = 0; index2 < advancedPathList.Count; ++index2)
                      {
                        if (advancedPathList[index2].GateType == AllEnums.GateTypes.NPC && (205 > advancedPathList[index2].ToMapID || advancedPathList[index2].ToMapID > 312) && (597 > advancedPathList[index2].ToMapID || advancedPathList[index2].ToMapID > 704))
                        {
                          flag6 = false;
                          break;
                        }
                        if (GA.isInCity(advancedPathList[index2].MapID))
                        {
                          if (index2 + 1 < advancedPathList.Count && GA.isInCity(advancedPathList[index2 + 1].MapID))
                          {
                            flag6 = false;
                            break;
                          }
                          if (index2 + 2 < advancedPathList.Count && GA.isInCity(advancedPathList[index2 + 2].MapID))
                          {
                            flag6 = false;
                            break;
                          }
                        }
                      }
                    }
                    if (flag6)
                    {
                      advancedPathListList2.Add(advancedPathList);
                      bool flag7 = false;
                      if (advancedPathList.Count == 2)
                        flag7 = true;
                      if (advancedPathList.Count == 3)
                      {
                        int num = 0;
                        if (advancedPathList[0].MapID <= 2)
                          ++num;
                        if (advancedPathList[1].MapID <= 2)
                          ++num;
                        if (advancedPathList[2].MapID <= 2)
                          ++num;
                        if (num >= 2)
                        {
                          advancedPathListList2.Clear();
                          advancedPathListList2.Add(advancedPathList);
                          flag7 = true;
                        }
                      }
                      if (advancedPathList.Count >= 4)
                        flag7 = true;
                      if (flag7)
                        return advancedPathListList2;
                      continue;
                    }
                    continue;
                  }
                  continue;
                }
                continue;
label_51:
                flag4 = true;
                goto label_22;
              }
            }
          }
        }
        if (!flag3)
          flag2 = true;
      }
      else
        flag2 = true;
      Thread.Sleep(10);
    }
    if (advancedPathListList1.Count > 0)
    {
      if (advancedPathListList1.Count >= 2)
      {
        advancedPathListList2.Add(advancedPathListList1[0]);
        advancedPathListList2.Add(advancedPathListList1[advancedPathListList1.Count - 1]);
        return advancedPathListList2;
      }
      string str = "";
      foreach (List<AdvancedPath> advancedPathList in advancedPathListList1)
      {
        foreach (AdvancedPath advancedPath6 in advancedPathList)
          str = $"{str} --> {advancedPath6.MapName}";
        str += "\n";
      }
    }
    return advancedPathListList1;
  }

  public static void AuthenticatePHP(
    string username,
    string password,
    frmLogin loginForm,
    bool showForm)
  {
    string myOutput = "";
    GA.SecureLoginPHP(username, password, loginForm, showForm, out myOutput);
  }

  internal static int SendKeepAlivePHP(
    out string version,
    out string myMessage,
    bool online = true,
    bool showForm = false)
  {
    string myOutput = "";
    int num = GA.SecureLoginPHP(frmLogin.GAuto.Settings.Account.Username, frmLogin.GAuto.Settings.Account.Password, (frmLogin) null, false, out myOutput, online, showForm);
    version = "";
    myMessage = "";
    myMessage = frmLogin.GAuto.Settings.Account.AutoMessage;
    version = frmLogin.AutoVersion;
    try
    {
      frmLogin.KeepAliveStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
    }
    catch (Exception ex)
    {
    }
    return num;
  }

  private static int SecureLoginPHP(
    string username,
    string password,
    frmLogin loginForm,
    bool showForm,
    out string myOutput,
    bool online = true,
    bool askresult = false,
    Dictionary<string, object> nextParams = null)
  {
    string str1 = "";
    int num1 = 0;
    myOutput = "";
    int blogSpotInfo = frmLogin.GetBlogSpotInfo();
    GA.useBlog = false;
    if (blogSpotInfo != 1)
    {
      string str2 = online ? "1" : "0";
      string str3 = askresult ? "1" : "0";
      if (!GA.useBlog)
      {
        if (!online)
        {
          frmLogin.GAuto.Settings.CheDoRequest = 0;
          frmLogin.GAuto.Settings.Q12TCRequest = 0;
          frmLogin.GAuto.Settings.TraderRequest = 0;
          frmLogin.GAuto.Settings.BonHoaRequest = 0;
          frmLogin.GAuto.Settings.TrongHoaRequest = 0;
          frmLogin.GAuto.Settings.ThuHoachRequest = 0;
          frmLogin.GAuto.Settings.YTORequest = 0;
          frmLogin.GAuto.Settings.YTOExtend = 0;
          frmLogin.GAuto.Settings.Q12TCExtend = 0;
          frmLogin.GAuto.Settings.Account.RequestGG24h = 0;
          frmLogin.GAuto.Settings.BuyCheDoCount = 0;
          frmLogin.GAuto.Settings.BuyCheDo = false;
        }
        else
        {
          if (frmLogin.GAuto.AllAutoAccounts.Count > 0)
          {
            try
            {
              int num2 = 0;
              int num3 = 0;
              int num4 = 0;
              frmLogin.GAuto.Settings.Account.ServerString = "";
              for (int index = frmLogin.GAuto.AllAutoAccounts.Count - 1; index >= 0; --index)
              {
                if (frmLogin.GAuto.AllAutoAccounts[index].Myself.IsCheDo)
                  ++num2;
                if (frmLogin.GAuto.AllAutoAccounts[index].Myself.isYTO)
                  ++num3;
                if (frmLogin.GAuto.AllAutoAccounts[index].Settings.AIMode == AllEnums.AIModes.THUONGNHAN)
                  ++num4;
                if (frmLogin.GAuto.AllAutoAccounts[index].Target.VersionNum > 0)
                {
                  string str4 = $"{frmLogin.GAuto.AllAutoAccounts[index].Target.VersionNum},{frmLogin.GAuto.AllAutoAccounts[index].Target.SubVersion},{frmLogin.GAuto.AllAutoAccounts[index].Target.ServerIndex}";
                  if (frmLogin.GAuto.AllAutoAccounts[index].Target.ServerIndex != -1)
                  {
                    try
                    {
                      frmLogin.GAuto.AllAutoAccounts[index].Target.ServerIndex = -1;
                    }
                    catch (Exception ex)
                    {
                    }
                  }
                  if (!frmLogin.GAuto.Settings.Account.ServerString.Contains(str4))
                  {
                    AccountBalance account = frmLogin.GAuto.Settings.Account;
                    account.ServerString = $"{account.ServerString}{str4};";
                  }
                }
              }
              if (frmLogin.GAuto.Settings.Account.ServerString.EndsWith(";"))
                frmLogin.GAuto.Settings.Account.ServerString = frmLogin.GAuto.Settings.Account.ServerString.Remove(frmLogin.GAuto.Settings.Account.ServerString.Length - 1, 1);
              if (frmLogin.GAuto.Settings.Account.ServerString == string.Empty)
                frmLogin.GAuto.Settings.Account.ServerString = "NONE";
              if (frmLogin.GAuto.Settings.CheDoRequest < num2)
                frmLogin.GAuto.Settings.CheDoRequest = num2;
              if (frmLogin.GAuto.Settings.TraderRequest < num4)
                frmLogin.GAuto.Settings.TraderRequest = num4;
            }
            catch (Exception ex)
            {
            }
          }
          if (frmLogin.CompilingLanguage == "EN" && frmLogin.GAuto.Settings.IsPro1 && online && frmLogin.GAuto.Settings.TraderRequest < frmLogin.GAuto.Settings.DefaultFreeTN)
            frmLogin.GAuto.Settings.TraderRequest = frmLogin.GAuto.Settings.DefaultFreeTN;
          if (!online)
            frmLogin.GAuto.Settings.CheDoRequest = 0;
        }
      }
      string str5 = JsonConvert.SerializeObject((object) new Dictionary<string, string>()
      {
        {
          "salt",
          GA.GenerateRandomName(5)
        },
        {
          nameof (username),
          username
        },
        {
          nameof (password),
          password
        },
        {
          "hwid",
          new GA.HWID().Value
        },
        {
          "gameid",
          frmLogin.GAuto.Settings.GameID
        },
        {
          "entime",
          frmLogin.GAuto.Settings.Account.EncryptionTime.ToString()
        },
        {
          "version",
          GA.GetMyVersion()
        },
        {
          "isonline",
          str2.ToString()
        },
        {
          nameof (askresult),
          str3.ToString()
        },
        {
          "cdrequest",
          frmLogin.GAuto.Settings.CheDoRequest.ToString()
        },
        {
          "q12request",
          frmLogin.GAuto.Settings.Q12TCRequest.ToString()
        },
        {
          "q12extend",
          frmLogin.GAuto.Settings.Q12TCExtend.ToString()
        },
        {
          "bonhoarequest",
          frmLogin.GAuto.Settings.BonHoaRequest.ToString()
        },
        {
          "tronghoarequest",
          frmLogin.GAuto.Settings.TrongHoaRequest.ToString()
        },
        {
          "thuhoachrequest",
          frmLogin.GAuto.Settings.ThuHoachRequest.ToString()
        },
        {
          "ytorequest",
          frmLogin.GAuto.Settings.YTORequest.ToString()
        },
        {
          "ytoextendrequest",
          frmLogin.GAuto.Settings.YTOExtend.ToString()
        },
        {
          "uniqueid",
          frmLogin.GAuto.Settings.Account.UniqueSessionID
        },
        {
          "cbdate",
          frmLogin.GAuto.Settings.Account.CyberDate
        },
        {
          "serverstring",
          frmLogin.GAuto.Settings.Account.ServerString
        },
        {
          "chedoonly",
          frmLogin.GAuto.Settings.cboxOnlyCheDo ? "chedoonly" : "none"
        },
        {
          "buychedo",
          frmLogin.GAuto.Settings.BuyCheDo ? "true" : "false"
        },
        {
          "buychedocount",
          frmLogin.GAuto.Settings.BuyCheDoCount.ToString()
        }
      });
      if (frmLogin.GAuto.Settings.CompilingLanguage != "VN")
        str5 = $"{username}|{password}|{new GA.HWID().Value}|{frmLogin.GAuto.Settings.GameID}|{frmLogin.GAuto.Settings.Account.EncryptionTime}|{GA.GetMyVersion()}|{str2}|{str3}|{$"{GA.GenerateRandomName(5)}^{frmLogin.GAuto.Settings.CheDoRequest.ToString()}^{GA.GenerateRandomName(5)}"}|{$"{GA.GenerateRandomName(7)}^{frmLogin.GAuto.Settings.Q12TCRequest.ToString()}^{GA.GenerateRandomName(5)}"}|{$"{GA.GenerateRandomName(5)}^{frmLogin.GAuto.Settings.Q12TCExtend.ToString()}^{GA.GenerateRandomName(5)}"}|{$"{GA.GenerateRandomName(6)}^{frmLogin.GAuto.Settings.BonHoaRequest.ToString()}^{GA.GenerateRandomName(5)}"}|{$"{GA.GenerateRandomName(5)}^{frmLogin.GAuto.Settings.TrongHoaRequest.ToString()}^{GA.GenerateRandomName(5)}"}|{$"{GA.GenerateRandomName(6)}^{frmLogin.GAuto.Settings.ThuHoachRequest.ToString()}^{GA.GenerateRandomName(5)}"}|{$"{GA.GenerateRandomName(6)}^{frmLogin.GAuto.Settings.YTORequest.ToString()}^{GA.GenerateRandomName(5)}"}|{$"{GA.GenerateRandomName(6)}^{frmLogin.GAuto.Settings.YTOExtend.ToString()}^{GA.GenerateRandomName(5)}"}|{frmLogin.GAuto.Settings.Account.UniqueSessionID}|{frmLogin.GAuto.Settings.Account.BuyBlockDays}|{$"{GA.GenerateRandomName(6)}^{frmLogin.GAuto.Settings.TraderRequest.ToString()}^{GA.GenerateRandomName(5)}"}|{frmLogin.GAuto.Settings.Account.ServerString}|";
      if (frmLogin.CompilingLanguage != "VN")
        str5 = HttpUtility.UrlEncode(Convert.ToBase64String(Encoding.ASCII.GetBytes(GA.XOREncrypt(Convert.ToBase64String(Encoding.ASCII.GetBytes($"{Convert.ToBase64String(Encoding.ASCII.GetBytes(GA.XOREncrypt(Convert.ToBase64String(Encoding.ASCII.GetBytes(str5)), GA.SecureStringToString(frmLogin.GAuto.Settings.Account.TrafficKey))))}|{GA.SecureStringToString(frmLogin.GAuto.Settings.Account.TrafficKey)}")), GA.SecureStringToString(frmLogin.GAuto.Settings.Account.TempKey)))));
      string data1 = $"data={str5}";
      if (!GA.useBlog)
      {
        if (frmLogin.CompilingLanguage == "VN" || frmLogin.VIPMode == 1 || frmLogin.VIPMode == 2)
        {
          string data2 = "data=" + HttpUtility.UrlEncode(GA.AES_encrypt(str5, 0));
          try
          {
            str1 = GA.LoadWeb(frmLogin.MainGAutoServer.URL + frmLogin.GAuto.Settings.LoginURL, data2, "POST", frmLogin.GAuto.Settings.MainCookie);
          }
          catch (Exception ex)
          {
          }
          finally
          {
            frmLogin.GAuto.Settings.YTORequest = 0;
            frmLogin.GAuto.Settings.YTOExtend = 0;
          }
        }
        else
          str1 = GA.LoadWeb(frmLogin.GAuto.Settings.LoginURL, data1, "POST", frmLogin.GAuto.Settings.MainCookie);
      }
      int num5 = 0;
      string str6 = "";
      if (str1 == string.Empty || str1.Contains(frmLogin.GAuto.Settings.LoadWebErrorMessage))
      {
        ++num5;
        if (!frmLogin.GAuto.Settings.IsLoggedIn)
        {
          int num6 = (int) MessageBox.Show($"Lỗi đăng nhập.\n\nServer đang bị tấn công, bạn thử bấm đăng nhập lại vài lần. Vui lòng tắt auto đi thử lại hoặc liên hệ qua Facebook hỗ trợ.\nhttps://www.facebook.com/gameautopro/.\n\nLogin: {frmLogin.GAuto.Settings.LoginURL}\nLog: {str1}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
      }
      if (frmLogin.CompilingLanguage != "VN")
      {
        string str7 = HttpUtility.UrlDecode(str1);
        try
        {
          str7 = Encoding.UTF8.GetString(Convert.FromBase64String(str7));
        }
        catch (Exception ex)
        {
          if (showForm)
          {
            int num7 = (int) MessageBox.Show(frmMain.langLoginError);
          }
        }
        str1 = GA.XOREncrypt(str7, GA.SecureStringToString(frmLogin.GAuto.Settings.Account.TrafficKey));
        try
        {
          str1 = Encoding.UTF8.GetString(Convert.FromBase64String(str1));
        }
        catch (Exception ex)
        {
          if (showForm)
          {
            int num8 = (int) MessageBox.Show(frmMain.langLoginError);
          }
        }
      }
      else if (!GA.useBlog && str1 != "" && !str1.Contains(frmLogin.GAuto.Settings.LoadWebErrorMessage))
      {
        str1 = HttpUtility.UrlDecode(str1);
        try
        {
          if (str1 == "LOGIN_FAILED")
          {
            str6 = "Sai tên đăng nhập hoặc mật khẩu.\nLưu ý:\n - Tài khoản login auto không phải là tài khoản game.\n-Bạn có thể thử đăng nhập từ forum GAuto để xác nhận đúng mật khẩu tại www.gameauto.net/forum";
            ++num5;
          }
          else
            str1 = GA.AES_decrypt(str1, 0);
        }
        catch (Exception ex)
        {
          if (!frmLogin.GAuto.Settings.IsLoggedIn)
          {
            str6 = $"Lỗi giải mã: {ex.Message}\nContent: {str1}";
            if (username != "testauto2")
            {
              int num9 = (int) MessageBox.Show("Lỗi giải mã: \nMessage: " + ex.Message);
            }
            else
            {
              int num10 = (int) MessageBox.Show($"Lỗi giải mã: \nMessage: {ex.Message}\nContent: {str1}");
            }
          }
          ++num5;
        }
      }
      if (num5 > 0)
      {
        if (!frmLogin.GAuto.Settings.IsLoggedIn)
        {
          if (str6 == string.Empty)
          {
            int num11 = (int) MessageBox.Show("Lỗi đăng nhập, tắt auto mở lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Hand);
          }
          else
          {
            int num12 = (int) MessageBox.Show("Lỗi đăng nhập\n" + str6, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Hand);
          }
        }
        else if (str6 == string.Empty)
          GA.WriteUserLog($"Kết nối server lỗi -> báo GAuto <<<{str1}>>>");
      }
      if (num5 == 0)
      {
        if (GA.useBlog)
          str1 = GA.AES_decrypt(str1, 0);
        int num13;
        if (frmLogin.GAuto.Settings.CompilingLanguage == "VN")
        {
          if (str1 != "" && str1 != frmLogin.GAuto.Settings.LoadWebErrorMessage)
          {
            bool flag1 = false;
            if (GA.GetMyField(str1, "fulfilled") == "1")
              flag1 = true;
            string myField1 = GA.GetMyField(str1, "status");
            if (myField1 == "MULTILOGIN")
            {
              if (showForm)
              {
                int num14 = (int) MessageBox.Show(frmMain.langCannotMultipleLogin, frmMain.langCannotLogin, MessageBoxButtons.OK, MessageBoxIcon.Hand);
              }
              num1 = 2;
            }
            if (flag1)
            {
              switch (myField1)
              {
                case "LOGIN_FAILED":
                  if (showForm)
                  {
                    loginForm.lblStatus.Text = frmMain.langLoginInvalid;
                    loginForm.lblStatus.ForeColor = System.Drawing.Color.Red;
                  }
                  ++frmLogin.GAuto.Settings.LoginFailedCount;
                  if (frmLogin.GAuto.Settings.LoginFailedCount >= frmLogin.GAuto.Settings.MaxLoginError)
                  {
                    int num15 = (int) MessageBox.Show(frmMain.langPleaseResetPassword, frmMain.langSoManyInvalidLogin, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    GA.ExitAndCleanup();
                    break;
                  }
                  break;
                case "ACCOUNT_DISABLED":
                  int num16 = (int) MessageBox.Show(frmMain.langLockedAccount, frmMain.langLockedAccountTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                  GA.ExitAndCleanup();
                  break;
                default:
                  frmLogin.GAuto.Settings.Account.AutoMessage = GA.GetMyField(str1, "automessage", true);
                  if (!string.IsNullOrEmpty(frmLogin.GAuto.Settings.Account.AutoMessage))
                    frmMain.newMessage = frmLogin.GAuto.Settings.Account.AutoMessage;
                  frmLogin.GAuto.Settings.Account.UniqueSessionID = GA.GetMyField(str1, "uniqueid");
                  if (frmLogin.GAuto.Settings.Account.UniqueSessionID == string.Empty)
                    frmLogin.GAuto.Settings.Account.UniqueSessionID = "-1";
                  if (myField1.Contains("LOGIN_OK"))
                  {
                    GA.GetMyField(str1, "autoupdate");
                    frmLogin.GAuto.Settings.LicenseCheckTimeStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
                    bool flag2 = false;
                    string myField2 = GA.GetMyField(str1, "expiredatetime");
                    frmLogin.GAuto.Settings.Account.ExpireDate = DateTime.Parse(myField2);
                    if (showForm)
                    {
                      frmLogin.GAuto.Settings.Account.Username = username;
                      frmLogin.GAuto.Settings.Account.Password = password;
                      if (str1.Contains("updateversion"))
                      {
                        string myField3 = GA.GetMyField(str1, "updateversion");
                        string myField4 = GA.GetMyField(str1, "autoupdate");
                        frmLogin.AutoVersion = myField3;
                        frmLogin.UpdateFile = myField4;
                        switch (GA.GetMyField(str1, "autostatus"))
                        {
                          case "AUTO_OUTDATEFORCE":
                            flag2 = true;
                            frmLogin.NeedUpdate = true;
                            int num17 = (int) MessageBox.Show(frmMain.langUpdateInfo, "Update", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            frmLogin.UpdateMyAuto();
                            break;
                          case "AUTO_OUTDATE":
                            int num18 = (int) new frmUpdateNewVersion().ShowDialog();
                            if (frmUpdateNewVersion.UpdateResult)
                            {
                              frmUpdateNewVersion.UpdateResult = false;
                              flag2 = true;
                              frmLogin.NeedUpdate = true;
                              frmLogin.UpdateMyAuto();
                              break;
                            }
                            break;
                        }
                      }
                    }
                    if (!flag2)
                    {
                      string myField5 = GA.GetMyField(str1, "quangcao", true);
                      if (!string.IsNullOrEmpty(myField5))
                      {
                        string[] strArray1 = myField5.Split('|');
                        int.TryParse(strArray1[0], out frmLogin.GAuto.Settings.ChatQuangCaoDelay);
                        if (strArray1.Length > 1)
                        {
                          for (int index = 1; index < strArray1.Length; ++index)
                          {
                            string[] strArray2 = strArray1[index].Split('?');
                            QuangCaoMessage quangCaoMessage = new QuangCaoMessage();
                            quangCaoMessage.Message = strArray2[0];
                            try
                            {
                              int.TryParse(strArray2[1], out quangCaoMessage.VersionNum);
                              int.TryParse(strArray2[2], out quangCaoMessage.SubVersion);
                            }
                            catch (Exception ex)
                            {
                            }
                            frmLogin.GAuto.Settings.QuangCaoContent.Add(quangCaoMessage);
                          }
                        }
                      }
                      if (GA.GetMyField(str1, "thangchedopromo") == "1")
                      {
                        frmLogin.GAuto.Settings.ThangCheDo = true;
                        frmLogin.GAuto.Settings.ThangCheDo2AccPrice = 0;
                        int.TryParse(GA.GetMyField(str1, "cd2accprice"), out frmLogin.GAuto.Settings.ThangCheDo2AccPrice);
                        if (frmLogin.GAuto.Settings.ThangCheDo2AccPrice == 0)
                          frmLogin.GAuto.Settings.ThangCheDo2AccPrice = 5;
                        frmLogin.GAuto.Settings.ThangCheDo5AccPrice = 0;
                        int.TryParse(GA.GetMyField(str1, "cd5accprice"), out frmLogin.GAuto.Settings.ThangCheDo5AccPrice);
                        if (frmLogin.GAuto.Settings.ThangCheDo5AccPrice == 0)
                          frmLogin.GAuto.Settings.ThangCheDo5AccPrice = 10;
                        frmLogin.GAuto.Settings.ThangCheDo50AccPrice = 0;
                        int.TryParse(GA.GetMyField(str1, "cd50accprice"), out frmLogin.GAuto.Settings.ThangCheDo50AccPrice);
                        if (frmLogin.GAuto.Settings.ThangCheDo50AccPrice == 0)
                          frmLogin.GAuto.Settings.ThangCheDo50AccPrice = 20;
                      }
                      if (str1.Contains("tnchedoallow"))
                      {
                        int result = 0;
                        int.TryParse(GA.GetMyField(str1, "tnchedoallow"), out result);
                        frmLogin.GAuto.Settings.CheDoCounts = result * 152 ^ 2013;
                        frmLogin.GAuto.Settings.CheDoStatus = !(GA.GetMyField(str1, "tnchedostatus") == "TNOK") ? 0 : 1;
                        result = 0;
                        int.TryParse(GA.GetMyField(str1, "tnchedoremain"), out result);
                        frmLogin.GAuto.Settings.CheDoDuration = result * 152 ^ 2013;
                        if (result > 0)
                        {
                          frmLogin.GAuto.Settings.Account.EmptySecondCDHits = 0;
                          frmLogin.GAuto.Settings.HadCDPro = true;
                        }
                        else
                          frmLogin.GAuto.Settings.HadCDPro = false;
                        int.TryParse(GA.GetMyField(str1, "tnq1tcallow"), out result);
                        int num19 = result;
                        frmLogin.GAuto.Settings.Q12TCCounts = result * 849 ^ 1786;
                        frmLogin.GAuto.Settings.Q12TCStatus = !(GA.GetMyField(str1, "tnq1tcstatus") == "TNOK") ? 0 : 1;
                        result = 0;
                        int.TryParse(GA.GetMyField(str1, "tnq1tcremain"), out result);
                        if (result > 0 && num19 <= 0)
                          frmLogin.GAuto.Settings.Q12TCCounts = 88;
                        if (result > 0)
                        {
                          frmLogin.GAuto.Settings.Account.EmptySecondQ123Hits = 0;
                          frmLogin.GAuto.Settings.HadQ123Pro = true;
                        }
                        else
                          frmLogin.GAuto.Settings.HadQ123Pro = false;
                        try
                        {
                          frmLogin.GAuto.Settings.Q12TCDuration = result * 849 ^ 1786;
                        }
                        catch (Exception ex)
                        {
                        }
                        int.TryParse(GA.GetMyField(str1, "tnytoallow"), out result);
                        int num20 = result;
                        frmLogin.GAuto.Settings.YTOCounts = result * 147 ^ 2716;
                        frmLogin.GAuto.Settings.YTOStatus = !(GA.GetMyField(str1, "tnytostatus") == "TNOK") ? 0 : 1;
                        result = 0;
                        int.TryParse(GA.GetMyField(str1, "tnytoremain"), out result);
                        if (result > 0 && num20 <= 0)
                          frmLogin.GAuto.Settings.YTOCounts = 3002;
                        if (result > 0)
                        {
                          frmLogin.GAuto.Settings.Account.EmptySecondYTOHits = 0;
                          frmLogin.GAuto.Settings.HadYTOPro = true;
                        }
                        else
                          frmLogin.GAuto.Settings.HadYTOPro = false;
                        try
                        {
                          frmLogin.GAuto.Settings.YTODuration = result * 147 ^ 2716;
                        }
                        catch (Exception ex)
                        {
                        }
                      }
                    }
                    if (GA.GetMyField(str1, "gameid") == frmLogin.GAuto.Settings.GameID)
                    {
                      double num21 = 10000.0;
                      if (num21 == -1.0)
                        num13 = -1;
                      else if (num21 == -2.0)
                        num13 = 2;
                      try
                      {
                        if (num21 > 0.0)
                        {
                          frmLogin.GAuto.Settings.Account.RemainMSeconds = (double) (long) (num21 * 1000.0);
                          frmLogin.GAuto.Settings.Account.EmptySecondHits = 0;
                          frmLogin.GAuto.Settings.WasPro = true;
                        }
                        else
                        {
                          frmLogin.GAuto.Settings.Account.RemainMSeconds = 0.0;
                          frmLogin.GAuto.Settings.WasPro = false;
                        }
                      }
                      catch (Exception ex)
                      {
                      }
                      if (num21 <= 0.0)
                      {
                        frmLogin.GAuto.Settings.AppMode2 = AllEnums.AutoModes.Lite;
                        frmLogin.GAuto.Settings.AppMode = AllEnums.AutoModes.Lite;
                        if (num21 == -2.0)
                          GA.ExitAndCleanup();
                        else if (num21 == -1.0)
                          frmLogin.GAuto.Settings.Account.IsExpired = true;
                      }
                      else if (num21 > 0.0)
                      {
                        frmLogin.GAuto.Settings.AppMode2 = AllEnums.AutoModes.Pro;
                        frmLogin.GAuto.Settings.AppMode = AllEnums.AutoModes.Pro;
                      }
                      double.TryParse(GA.GetMyField(str1, "balance"), out frmLogin.GAuto.Settings.Account.RemainBalance);
                      string myField6 = GA.GetMyField(str1, "dailybalance");
                      double result = 0.0;
                      double.TryParse(myField6, out result);
                      frmLogin.GAuto.Settings.Account.RemainGGoldBalance = result;
                      frmLogin.GAuto.Settings.Account.IsLoginGGold = GA.GetMyField(str1, "isgoldlogin") == "1";
                      frmLogin.GAuto.Settings.Account.LastLogin = frmLogin.GlobalTimer.ElapsedMilliseconds;
                      frmLogin.GAuto.Settings.Account.LastValidTimeStamp = frmLogin.GAuto.Settings.Account.LastLogin;
                      try
                      {
                        frmLogin.KeepAliveStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
                      }
                      catch (Exception ex)
                      {
                      }
                      frmLogin.GAuto.Settings.Account.Game = frmMain.langMyGameTitle;
                      if (showForm)
                      {
                        frmLiteVersion frmLiteVersion = new frmLiteVersion();
                        if (frmLogin.GAuto.Settings.AppMode == AllEnums.AutoModes.Lite)
                        {
                          int num22 = (int) frmLiteVersion.ShowDialog();
                        }
                        if (!frmLiteVersion.DoNotRun)
                        {
                          frmLogin.GAuto.Settings.IsLoggedIn = true;
                          GA.ShowMainForm();
                        }
                        else
                          GA.ExitAndCleanup();
                      }
                      num1 = 1;
                      break;
                    }
                    break;
                  }
                  switch (myField1)
                  {
                    case "MULTILOGIN":
                      if (showForm)
                      {
                        int num23 = (int) MessageBox.Show(frmMain.langCannotMultipleLogin, frmMain.langCannotLogin, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                      }
                      num1 = 2;
                      break;
                    case "ASK_USER":
                      if (!askresult)
                      {
                        if (showForm)
                        {
                          frmLogin.GAuto.ConfirmBoxResult = DialogResult.No;
                          int num24 = (int) new frmGGConfirm()
                          {
                            textQuestion = frmMain.langExistingLogin
                          }.ShowDialog();
                          if (frmLogin.GAuto.ConfirmBoxResult == DialogResult.Yes)
                          {
                            frmLogin.GAuto.Settings.Account.Username = username;
                            frmLogin.GAuto.Settings.Account.Password = password;
                            string version = "";
                            string myMessage = "";
                            GA.SendKeepAlivePHP(out version, out myMessage, showForm: true);
                            GA.ShowMainForm();
                            break;
                          }
                          GA.ExitAndCleanup();
                          break;
                        }
                        num1 = 1;
                        string version1 = "";
                        string myMessage1 = "";
                        GA.SendKeepAlivePHP(out version1, out myMessage1, showForm: true);
                        break;
                      }
                      break;
                  }
                  break;
              }
            }
            else
            {
              try
              {
                frmLogin.KeepAliveStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
              }
              catch (Exception ex)
              {
              }
            }
          }
          frmLogin.GAuto.Settings.CheDoRequest = 0;
          frmLogin.GAuto.Settings.Q12TCRequest = 0;
          frmLogin.GAuto.Settings.BonHoaRequest = 0;
          frmLogin.GAuto.Settings.TrongHoaRequest = 0;
          frmLogin.GAuto.Settings.ThuHoachRequest = 0;
          frmLogin.GAuto.Settings.Q12TCExtend = 0;
          frmLogin.GAuto.Settings.YTOExtend = 0;
          frmLogin.GAuto.Settings.YTORequest = 0;
          frmLogin.GAuto.Settings.Account.RequestGG24h = 0;
          frmLogin.GAuto.Settings.Account.BuyBlockDays = (object) 0;
          if (frmLogin.GAuto.Settings.BuyCheDo && frmLogin.GAuto.Settings.BuyCheDoCount > 0)
            GA.WriteUserLog("Kết thúc việc mua slot chế đồ thêm, vui lòng kiểm tra thông tin tài khoản");
          frmLogin.GAuto.Settings.BuyCheDo = false;
          frmLogin.GAuto.Settings.BuyCheDoCount = 0;
          try
          {
            frmLogin.GAuto.UpdateAccountInfo = true;
            return num1;
          }
          catch (Exception ex)
          {
            return num1;
          }
        }
        else if (frmLogin.GAuto.Settings.CompilingLanguage != "VN" && str1 != frmLogin.GAuto.Settings.LoadWebErrorMessage)
        {
          if (str1.Contains("LOGIN_FAILED"))
          {
            if (showForm)
            {
              loginForm.lblStatus.Text = frmMain.langLoginInvalid;
              loginForm.lblStatus.ForeColor = System.Drawing.Color.Red;
            }
            ++frmLogin.GAuto.Settings.LoginFailedCount;
            if (frmLogin.GAuto.Settings.LoginFailedCount >= frmLogin.GAuto.Settings.MaxLoginError)
            {
              int num25 = (int) MessageBox.Show(frmMain.langPleaseResetPassword, frmMain.langSoManyInvalidLogin, MessageBoxButtons.OK, MessageBoxIcon.Hand);
              GA.ExitAndCleanup();
            }
          }
          else if (str1.Contains("ACCOUNT_DISABLED;"))
          {
            int num26 = (int) MessageBox.Show(frmMain.langLockedAccount, frmMain.langLockedAccountTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            GA.ExitAndCleanup();
          }
          else if (str1.Contains("MULTILOGIN"))
          {
            if (showForm)
            {
              int num27 = (int) MessageBox.Show(frmMain.langCannotMultipleLogin, frmMain.langCannotLogin, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            num1 = 2;
          }
          else if (str1.Contains("\"LoginResult\":\"LOGIN_OK\""))
          {
            string myField7 = GA.GetMyField(str1, "duration");
            string myField8 = GA.GetMyField(str1, "ggoldbalance");
            string myField9 = GA.GetMyField(str1, "ggoldpromo");
            string myField10 = GA.GetMyField(str1, "uniquesessionid");
            string myField11 = GA.GetMyField(str1, "tnq1tc");
            string myField12 = GA.GetMyField(str1, "tnq1tcrem");
            string myField13 = GA.GetMyField(str1, "tnyto");
            string myField14 = GA.GetMyField(str1, "tnytorem");
            string myField15 = GA.GetMyField(str1, "muablock");
            string myField16 = GA.GetMyField(str1, "mychedocount");
            string myField17 = GA.GetMyField(str1, "mytradercount");
            string myField18 = GA.GetMyField(str1, "blockedversion");
            string myField19 = GA.GetMyField(str1, "expdatetime");
            string myField20 = GA.GetMyField(str1, "traderprice");
            string myField21 = GA.GetMyField(str1, "traderfree");
            frmLogin.GAuto.Settings.Account.AutoMessage = myField15;
            string myField22 = GA.GetMyField(str1, "autoupdate");
            string myField23 = GA.GetMyField(str1, "autofilename");
            string myField24 = GA.GetMyField(str1, "autoversion");
            string myField25 = GA.GetMyField(str1, "1hquestprice");
            string myField26 = GA.GetMyField(str1, "3hquestprice");
            string myField27 = GA.GetMyField(str1, "craftingprice");
            int result1 = 0;
            int.TryParse(myField18, out result1);
            frmLogin.BlockFromVer = result1;
            int result2 = 0;
            int.TryParse(myField25, out result2);
            frmLogin.GAuto.Settings.Account.Price1HQuest = result2;
            int.TryParse(myField26, out result2);
            frmLogin.GAuto.Settings.Account.Price3HQuest = result2;
            int.TryParse(myField27, out result2);
            frmLogin.GAuto.Settings.Account.CraftingPrice = result2;
            int.TryParse(myField20, out result2);
            frmLogin.GAuto.Settings.Account.TraderPrice = result2;
            int.TryParse(myField21, out result2);
            frmLogin.GAuto.Settings.DefaultFreeTN = result2;
            try
            {
              frmLogin.GAuto.Settings.BangGia.Clear();
              string myField28 = GA.GetMyField(str1, "price_1");
              string myField29 = GA.GetMyField(str1, "price_6");
              string myField30 = GA.GetMyField(str1, "price_30");
              string myField31 = GA.GetMyField(str1, "price_90");
              string myField32 = GA.GetMyField(str1, "price_180");
              string myField33 = GA.GetMyField(str1, "price_360");
              string myField34 = GA.GetMyField(str1, "price_9999");
              if (!string.IsNullOrEmpty(myField28))
                frmLogin.GAuto.Settings.BangGia.Add("price_1", int.Parse(myField28));
              if (!string.IsNullOrEmpty(myField29))
                frmLogin.GAuto.Settings.BangGia.Add("price_6", int.Parse(myField29));
              if (!string.IsNullOrEmpty(myField30))
                frmLogin.GAuto.Settings.BangGia.Add("price_30", int.Parse(myField30));
              if (!string.IsNullOrEmpty(myField31))
                frmLogin.GAuto.Settings.BangGia.Add("price_90", int.Parse(myField31));
              if (!string.IsNullOrEmpty(myField32))
                frmLogin.GAuto.Settings.BangGia.Add("price_180", int.Parse(myField32));
              if (!string.IsNullOrEmpty(myField33))
                frmLogin.GAuto.Settings.BangGia.Add("price_360", int.Parse(myField33));
              if (!string.IsNullOrEmpty(myField34))
                frmLogin.GAuto.Settings.BangGia.Add("price_9999", int.Parse(myField34));
            }
            catch (Exception ex)
            {
            }
            frmLogin.GAuto.Settings.Account.UniqueSessionID = myField10;
            if (frmLogin.GAuto.Settings.Account.UniqueSessionID == string.Empty)
              frmLogin.GAuto.Settings.Account.UniqueSessionID = "-1";
            frmLogin.GAuto.Settings.LicenseCheckTimeStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
            bool flag = false;
            frmLogin.GAuto.Settings.Account.ExpireDate = DateTime.Parse(myField19);
            if (showForm)
            {
              frmLogin.GAuto.Settings.Account.Username = username;
              frmLogin.GAuto.Settings.Account.Password = password;
              frmLogin.AutoVersion = myField24;
              frmLogin.UpdateFile = myField23;
              switch (myField22)
              {
                case "AUTO_OUTDATEFORCE":
                  flag = true;
                  frmLogin.NeedUpdate = true;
                  int num28 = (int) MessageBox.Show(frmMain.langUpdateInfo, "Update", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                  frmLogin.UpdateMyAuto();
                  break;
                case "AUTO_OUTDATE":
                  int num29 = (int) new frmUpdateNewVersion().ShowDialog();
                  if (frmUpdateNewVersion.UpdateResult)
                  {
                    frmUpdateNewVersion.UpdateResult = false;
                    flag = true;
                    frmLogin.NeedUpdate = true;
                    frmLogin.UpdateMyAuto();
                    break;
                  }
                  break;
              }
            }
            if (!flag)
            {
              int result3 = 0;
              int.TryParse(myField16, out result3);
              frmLogin.GAuto.Settings.CheDoCounts = result3 * 152 ^ 2013;
              if (result3 > 0)
              {
                for (int index = 0; index < result3; ++index)
                {
                  string myField35 = "chedoentry-" + index.ToString();
                  string myField36 = GA.GetMyField(str1, myField35);
                  string myField37 = GA.GetMyField(myField36, "chedorem");
                  TinhNangElement tinhNangElement = new TinhNangElement();
                  int.TryParse(myField37, out tinhNangElement.RemainSec);
                  tinhNangElement.Tip = "Chế đồ";
                  int.TryParse(GA.GetMyField(myField36, "chedopri"), out tinhNangElement.Price);
                  if (tinhNangElement.RemainSec < frmLogin.GAuto.Settings.Account.CheDoRemMin || frmLogin.GAuto.Settings.Account.CheDoRemMin == 0)
                    frmLogin.GAuto.Settings.Account.CheDoRemMin = tinhNangElement.RemainSec;
                  if (tinhNangElement.RemainSec > frmLogin.GAuto.Settings.Account.CheDoRemMax)
                    frmLogin.GAuto.Settings.Account.CheDoRemMax = tinhNangElement.RemainSec;
                  try
                  {
                    if (index >= frmLogin.GAuto.Settings.Account.CheDoInfo.Count)
                    {
                      tinhNangElement.RemainSec = tinhNangElement.RemainSec * 152 ^ 2013;
                      frmLogin.GAuto.Settings.Account.CheDoInfo.Add(tinhNangElement);
                    }
                    else
                    {
                      frmLogin.GAuto.Settings.Account.CheDoInfo[index].RemainSec = tinhNangElement.RemainSec * 152 ^ 2013;
                      frmLogin.GAuto.Settings.Account.CheDoInfo[index].Price = tinhNangElement.Price;
                    }
                  }
                  catch (Exception ex)
                  {
                  }
                }
              }
              result3 = 0;
              int.TryParse(myField17, out result3);
              double result4 = 0.0;
              double.TryParse(myField7, out result4);
              if (result4 <= 0.0)
                result3 = 0;
              frmLogin.GAuto.Settings.TraderCounts = result3 * 153 ^ 2714;
              if (result3 > 0)
              {
                for (int index = 0; index < result3; ++index)
                {
                  string myField38 = "traderentry-" + index.ToString();
                  string myField39 = GA.GetMyField(str1, myField38);
                  string myField40 = GA.GetMyField(myField39, "traderrem");
                  TinhNangElement tinhNangElement = new TinhNangElement();
                  int.TryParse(myField40, out tinhNangElement.RemainSec);
                  tinhNangElement.Tip = "Thương nhân";
                  int.TryParse(GA.GetMyField(myField39, "traderpri"), out tinhNangElement.Price);
                  if (tinhNangElement.RemainSec < frmLogin.GAuto.Settings.Account.TraderRemMin || frmLogin.GAuto.Settings.Account.TraderRemMin == 0)
                    frmLogin.GAuto.Settings.Account.TraderRemMin = tinhNangElement.RemainSec;
                  if (tinhNangElement.RemainSec > frmLogin.GAuto.Settings.Account.TraderRemMax)
                    frmLogin.GAuto.Settings.Account.TraderRemMax = tinhNangElement.RemainSec;
                  try
                  {
                    if (index >= frmLogin.GAuto.Settings.Account.TraderInfo.Count)
                    {
                      tinhNangElement.RemainSec = tinhNangElement.RemainSec * 153 ^ 2714;
                      frmLogin.GAuto.Settings.Account.TraderInfo.Add(tinhNangElement);
                    }
                    else
                    {
                      frmLogin.GAuto.Settings.Account.TraderInfo[index].RemainSec = tinhNangElement.RemainSec * 153 ^ 2714;
                      frmLogin.GAuto.Settings.Account.TraderInfo[index].Price = tinhNangElement.Price;
                    }
                  }
                  catch (Exception ex)
                  {
                  }
                }
              }
              int.TryParse(myField11, out result3);
              if (result3 > 0)
                result3 = 3;
              frmLogin.GAuto.Settings.Q12TCCounts = result3 * 849 ^ 1786;
              int result5 = 0;
              int.TryParse(myField12, out result5);
              frmLogin.GAuto.Settings.Q12TCStatus = result5 <= 0 ? 0 : 1;
              result3 = result5;
              if (result3 > 0)
              {
                frmLogin.GAuto.Settings.Account.EmptySecondQ123Hits = 0;
                frmLogin.GAuto.Settings.HadQ123Pro = true;
              }
              else
                frmLogin.GAuto.Settings.HadQ123Pro = false;
              try
              {
                frmLogin.GAuto.Settings.Q12TCDuration = result3 * 849 ^ 1786;
              }
              catch (Exception ex)
              {
              }
              int.TryParse(myField13, out result3);
              if (result3 > 0)
                result3 = 3;
              frmLogin.GAuto.Settings.YTOCounts = result3 * 147 ^ 2716;
              int result6 = 0;
              int.TryParse(myField14, out result6);
              frmLogin.GAuto.Settings.YTOStatus = result6 <= 0 ? 0 : 1;
              result3 = result6;
              if (result3 > 0)
              {
                frmLogin.GAuto.Settings.Account.EmptySecondYTOHits = 0;
                frmLogin.GAuto.Settings.HadYTOPro = true;
              }
              else
                frmLogin.GAuto.Settings.HadYTOPro = false;
              try
              {
                frmLogin.GAuto.Settings.YTODuration = result3 * 147 ^ 2716;
              }
              catch (Exception ex)
              {
              }
            }
            double result7 = 0.0;
            double.TryParse(myField7, out result7);
            if (result7 == -1.0)
              num13 = -1;
            else if (result7 == -2.0)
              num13 = 2;
            try
            {
              if (result7 > 0.0)
              {
                frmLogin.GAuto.Settings.Account.RemainMSeconds = (double) (long) (result7 * 1000.0);
                frmLogin.GAuto.Settings.Account.EmptySecondHits = 0;
                frmLogin.GAuto.Settings.WasPro = true;
              }
              else
              {
                frmLogin.GAuto.Settings.Account.RemainMSeconds = 0.0;
                frmLogin.GAuto.Settings.WasPro = false;
              }
            }
            catch (Exception ex)
            {
            }
            if (result7 <= 0.0)
            {
              frmLogin.GAuto.Settings.AppMode2 = AllEnums.AutoModes.Lite;
              frmLogin.GAuto.Settings.AppMode = AllEnums.AutoModes.Lite;
              if (result7 == -2.0)
                GA.ExitAndCleanup();
              else if (result7 == -1.0)
                frmLogin.GAuto.Settings.Account.IsExpired = true;
            }
            else if (result7 > 0.0)
            {
              frmLogin.GAuto.Settings.AppMode2 = AllEnums.AutoModes.Pro;
              frmLogin.GAuto.Settings.AppMode = AllEnums.AutoModes.Pro;
            }
            double result8 = 0.0;
            double.TryParse(myField9, out result8);
            frmLogin.GAuto.Settings.Account.RemainGGoldPromo = result8;
            double.TryParse(myField8, out result8);
            frmLogin.GAuto.Settings.Account.RemainGGoldBalance = result8;
            frmLogin.EmptyBalance = frmLogin.GAuto.Settings.Account.RemainGGoldPromo == 0.0 && frmLogin.GAuto.Settings.Account.RemainGGoldBalance == 0.0;
            frmLogin.GAuto.Settings.Account.LastLogin = frmLogin.GlobalTimer.ElapsedMilliseconds;
            frmLogin.GAuto.Settings.Account.LastValidTimeStamp = frmLogin.GAuto.Settings.Account.LastLogin;
            try
            {
              frmLogin.KeepAliveStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
            }
            catch (Exception ex)
            {
            }
            frmLogin.GAuto.Settings.Account.Game = frmMain.langMyGameTitle;
            if (showForm)
            {
              if (frmLogin.GAuto.Settings.AppMode == AllEnums.AutoModes.Lite)
              {
                frmLiteVersion frmLiteVersion = new frmLiteVersion();
                if (frmLogin.CompilingLanguage != "VN")
                {
                  if (frmLogin.GAuto.Settings.Account.RemainGGoldBalance > 0.0 || frmLogin.GAuto.Settings.Account.RemainGGoldPromo > 0.0)
                  {
                    frmLiteVersion.Height = 609;
                    frmLiteVersion.DisplayMyForm();
                  }
                  else
                    frmLiteVersion.Height = 283;
                }
                int num30 = (int) frmLiteVersion.ShowDialog();
              }
              if (!frmLiteVersion.DoNotRun)
                GA.ShowMainForm();
              else
                GA.ExitAndCleanup();
            }
            num1 = 1;
            frmLogin.GAuto.Settings.CheDoRequest = 0;
            frmLogin.GAuto.Settings.TraderRequest = !(frmLogin.CompilingLanguage == "EN") || !frmLogin.GAuto.Settings.IsPro1 ? 0 : (frmLogin.GAuto.Settings.TraderRequest >= frmLogin.GAuto.Settings.DefaultFreeTN ? 0 : frmLogin.GAuto.Settings.DefaultFreeTN);
            frmLogin.GAuto.Settings.Q12TCRequest = 0;
            frmLogin.GAuto.Settings.BonHoaRequest = 0;
            frmLogin.GAuto.Settings.TrongHoaRequest = 0;
            frmLogin.GAuto.Settings.ThuHoachRequest = 0;
            frmLogin.GAuto.Settings.Q12TCExtend = 0;
            frmLogin.GAuto.Settings.YTOExtend = 0;
            frmLogin.GAuto.Settings.YTORequest = 0;
            frmLogin.GAuto.Settings.Account.RequestGG24h = 0;
            frmLogin.GAuto.Settings.Account.BuyBlockDays = (object) 0;
            try
            {
              frmLogin.GAuto.UpdateAccountInfo = true;
            }
            catch (Exception ex)
            {
            }
          }
        }
      }
    }
    return num1;
  }

  public static string DecodeBase64(string input)
  {
    try
    {
      input = Encoding.UTF8.GetString(Convert.FromBase64String(input));
    }
    catch (Exception ex)
    {
      input = "";
    }
    return input;
  }

  public static Dictionary<string, string> GetAllFields(string input)
  {
    Dictionary<string, string> allFields = new Dictionary<string, string>();
    if (input.Contains("\":"))
    {
      StringBuilder stringBuilder = new StringBuilder(input);
      int num1 = 0;
      for (int index1 = 0; index1 < stringBuilder.Length; ++index1)
      {
        if (stringBuilder[index1] == ':' && stringBuilder[index1 - 1] == '"')
        {
          int index2 = index1 - 1;
          do
          {
            --index2;
            int num2 = (int) stringBuilder[4];
          }
          while (stringBuilder[index2] != '"' && index2 != 0 && index2 > num1);
          string str = input.Substring(index2 + 1, index1 - index2 - 2);
          if (str != "")
          {
            try
            {
              string myField = GA.GetMyField(input, str);
              allFields.Add(str, myField);
            }
            catch (Exception ex)
            {
              break;
            }
          }
        }
      }
    }
    return allFields;
  }

  public static string GetMyField(string input, string myField, bool base64 = false)
  {
    int num1 = input.IndexOf(myField);
    int length = input.Length;
    if (num1 == -1 || num1 >= length)
      return "";
    string first = $"\"{myField}\":";
    string str1 = "";
    bool flag = false;
    if (num1 + myField.Length + 2 < length && input[num1 + myField.Length + 2] == '{')
      flag = true;
    for (int index = num1 + 1; index < length; ++index)
    {
      if (input[index] == ',' && !flag)
      {
        str1 = GA.GetMidString(input, first, ",");
        break;
      }
      if (input[index] == '}')
      {
        str1 = GA.GetMidString(input, first, "}");
        break;
      }
      if (index == input.Length - 1)
      {
        int num2 = input.LastIndexOf(first);
        if (num2 > 0 && num2 < input.Length)
          str1 = input.Substring(num2 + first.Length, input.Length - num2 - first.Length);
      }
    }
    string str2 = str1.Trim('"').Trim();
    string str3 = str2;
    if (base64)
    {
      try
      {
        str2 = Encoding.UTF8.GetString(Convert.FromBase64String(HttpUtility.UrlDecode(str2)));
      }
      catch (Exception ex)
      {
        if (!frmLogin.GAuto.Settings.IsLoggedIn)
        {
          int num3 = (int) MessageBox.Show("Lỗi giải mã dữ liệu #3. Tắt auto thử lại. Value: " + str3);
        }
        else
          GA.WriteUserLog("Lỗi giải mã dữ liệu #3, tắt auto thử lại. Value: " + str3);
        str2 = str3;
      }
    }
    return str2;
  }

  public static void ShowMainForm()
  {
    long num1 = frmLogin.GlobalTimer.ElapsedMilliseconds + 30000L;
    while (!frmLogin.FinishDownloadingBases)
    {
      Thread.Sleep(200);
      if (frmLogin.GlobalTimer.ElapsedMilliseconds >= num1)
      {
        int num2 = (int) MessageBox.Show(frmMain.langCannotConnectAuto);
        GA.ExitAndCleanup();
        return;
      }
    }
    new frmMain().Show();
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

  public static void BrowseUserGuide() => Process.Start(frmLogin.GAuto.Settings.UserGuideURL);

  public static void BrowseWhatsNew() => Process.Start(frmLogin.GAuto.Settings.WhatsNewURL);

  public static void BrowseRegister() => Process.Start(frmLogin.GAuto.Settings.RegisterAccountURL);

  public static void BrowseGAutoForum() => Process.Start(frmLogin.GAuto.Settings.ForumURL);

  public static void BrowseTermOfUse() => Process.Start(frmLogin.GAuto.Settings.TermsURL);

  public static void BrowseRegistrationGuide()
  {
    Process.Start(frmLogin.GAuto.Settings.RegistrationGuideURL);
  }

  public static void BrowsePayPal() => Process.Start(frmLogin.GAuto.Settings.PayPalURL);

  public static void BrowseFacebook() => Process.Start(frmLogin.GAuto.Settings.FacebookURL);

  public static void BrowseForgotPassword()
  {
    Process.Start(frmLogin.MainGAutoServer.URL + frmLogin.GAuto.Settings.ForgotPassURL);
  }

  public static void BrowseMainpage() => Process.Start(frmLogin.GAuto.Settings.MainURL);

  public static void ShowError(string msg, Exception ex1)
  {
    int num = (int) MessageBox.Show($"{msg}\n{ex1.Message}\n{ex1.StackTrace}");
    GA.ExitAndCleanup();
  }

  public static void AboutUs() => new frmAbout().Show();

  public byte[] SerializeClass(MyParamsClass msgParams) => new byte[1026];

  public static void LogToFile(string msg, params object[] options)
  {
    StreamWriter streamWriter = (StreamWriter) null;
    if (System.IO.File.Exists(frmLogin.GAuto.Settings.LogFilePath))
    {
      FileInfo fileInfo = new FileInfo(frmLogin.GAuto.Settings.LogFilePath);
      if (fileInfo != null)
      {
        if (fileInfo.Length >= (long) (frmLogin.GAuto.Settings.LogFileMaxSize * 1000000))
        {
          string destFileName = AppDomain.CurrentDomain.BaseDirectory + $"log\\{DateTime.Now.Hour:D2}{DateTime.Now.Minute:D2}{DateTime.Now.Second:D2}_{DateTime.Now.Month:D2}{DateTime.Now.Day:D2}{DateTime.Now.Year:D4}.log";
          System.IO.File.Move(frmLogin.GAuto.Settings.LogFilePath, destFileName);
        }
      }
    }
    try
    {
      msg = string.Format(msg, options);
      string str = $"{DateTime.Now.ToString()}: {msg}";
      lock (frmMain.frmMainInstance.GUILocker)
      {
        streamWriter = new StreamWriter(frmLogin.GAuto.Settings.LogFilePath, true);
        streamWriter?.WriteLine(str);
      }
    }
    catch (Exception ex)
    {
      GA.Message(frmMain.langCannotFindLogFolder);
    }
    finally
    {
      streamWriter?.Close();
    }
  }

  public static PriceItem GetTNPrice(TinhNang tn)
  {
    if (frmLogin.GAuto.Settings.Account.BangGia.Count > 0)
    {
      for (int index = frmLogin.GAuto.Settings.Account.BangGia.Count - 1; index >= 0; --index)
      {
        bool flag = false;
        if ((tn.GiaHanTime == "" || tn.GiaHanTime == frmMain.lang_Select) && frmLogin.GAuto.Settings.Account.BangGia[index].Slot == tn.Slot && frmLogin.GAuto.Settings.Account.BangGia[index].SlotUnit == tn.SlotUnit)
          flag = true;
        if (!flag && tn.GiaHanTime != "" && tn.GiaHanTime != frmMain.lang_Select && tn.GiaHanTime == frmLogin.GAuto.Settings.Account.BangGia[index].TimeUnitShort)
          flag = true;
        if (frmLogin.GAuto.Settings.Account.BangGia[index].Key == tn.TNKey && flag && frmLogin.GAuto.Settings.Account.BangGia[index].SlotCount == tn.SlotCount && frmLogin.GAuto.Settings.Account.BangGia[index].SlotCountUnit == tn.SlotCountUnit)
          return frmLogin.GAuto.Settings.Account.BangGia[index];
      }
    }
    return (PriceItem) null;
  }

  public static string GenerateRandomName(int length = 24)
  {
    string str = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
    char[] chArray = new char[length];
    lock (GA.syncLock)
    {
      for (int index = 0; index < chArray.Length; ++index)
        chArray[index] = str[GA.random.Next(str.Length)];
    }
    return new string(chArray);
  }

  public static string ConvertIntToHex(int input, bool reverse = false)
  {
    string hex = input.ToString("X4");
    if (!reverse)
      return hex;
    char[] charArray = hex.ToCharArray();
    string empty = string.Empty;
    for (int index = charArray.Length - 1; index >= 0; index -= 2)
    {
      if (charArray.Length > 1 && charArray.Length % 2 == 0 && index != 0)
        empty += (string) (object) charArray[index - 1];
      empty += (string) (object) charArray[index];
    }
    return empty;
  }

  public static void Message(string msg, params object[] options)
  {
    msg = string.Format(msg, options);
    int num = (int) MessageBox.Show(msg, frmMain.langAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
  }

  public static void CreateNewFileMapping(
    ref IntPtr _hFile,
    ref IntPtr _pView,
    string _fileName,
    UIntPtr _size)
  {
    _hFile = MyDLL.CreateFileMapping((IntPtr) -1, (IntPtr) 0, MyDLL.FileMapProtection.PageExecuteReadWrite, 0U, (uint) _size, _fileName);
    if (_hFile == IntPtr.Zero)
    {
      int num = (int) MessageBox.Show("Cannot create new pipe");
    }
    _pView = MyDLL.MapViewOfFile(_hFile, 983071U, 0U, 0U, _size);
  }

  public static DateTime fromPHPTime(long ticks)
  {
    return new DateTime(1970, 1, 1, 0, 0, 0).Add(new TimeSpan(0, 0, (int) ticks));
  }

  public static void TrieuTapNhomID(AutoAccount myAccount, bool interact = true, bool theosau = true)
  {
    try
    {
      for (int index = frmLogin.GAuto.AllAutoAccounts.Count - 1; index >= 0; --index)
      {
        AutoAccount allAutoAccount = frmLogin.GAuto.AllAutoAccounts[index];
        if (allAutoAccount != null && allAutoAccount.Myself.DatabaseID != myAccount.Myself.DatabaseID && allAutoAccount.Settings.numGroupID == myAccount.Settings.numGroupID)
        {
          allAutoAccount.IsAIEnabled = true;
          if (allAutoAccount.Settings.AIMode != AllEnums.AIModes.DANHTUDO)
            allAutoAccount.Settings.AIMode = AllEnums.AIModes.DANHTUDO;
          allAutoAccount.Settings.cboxTheoSau = theosau;
          if (allAutoAccount.Myself.MapID == myAccount.Myself.MapID)
          {
            double distance = GA.CalculateDistance((double) allAutoAccount.Myself.PosX, (double) allAutoAccount.Myself.PosY, (double) myAccount.Myself.PosX, (double) myAccount.Myself.PosY);
            if (distance > 6.0)
            {
              allAutoAccount.StopAttackNow();
              if (distance > 35.0)
                allAutoAccount.CallLenNgua();
              allAutoAccount.Myself.Status = AllEnums.CharStatuses.GOGOGO;
              allAutoAccount.Myself.TargetX = myAccount.Myself.PosX;
              allAutoAccount.Myself.TargetY = myAccount.Myself.PosY;
              allAutoAccount.Myself.TargetMapID = myAccount.Myself.MapID;
              allAutoAccount.Myself.MoveLongTrigger = false;
              allAutoAccount.Myself.MinorStatus2 = AllEnums.CharStatuses.TRIEUTAP;
            }
            else
            {
              if (allAutoAccount.Myself.Status != AllEnums.CharStatuses.NHATBOC)
                allAutoAccount.Myself.Status = AllEnums.CharStatuses.IDLE;
              allAutoAccount.Myself.MinorStatus2 = AllEnums.CharStatuses.IDLE;
            }
          }
          else
          {
            allAutoAccount.StopAttackNow();
            if (allAutoAccount.Target.VersionNum == 3 || allAutoAccount.Target.VersionNum == 4)
            {
              allAutoAccount.Myself.LongMoveX = (int) myAccount.Myself.PosX;
              allAutoAccount.Myself.LongMoveY = (int) myAccount.Myself.PosY;
              allAutoAccount.Myself.LongMoveMapID = myAccount.Myself.MapID;
              allAutoAccount.Myself.IsLongMove = true;
            }
            else
            {
              allAutoAccount.Myself.LongMoveMapID = myAccount.Myself.MapID;
              allAutoAccount.Myself.LongMoveX = (int) myAccount.Myself.PosX;
              allAutoAccount.Myself.LongMoveY = (int) myAccount.Myself.PosY;
              allAutoAccount.Myself.MoveLongTrigger = true;
              allAutoAccount.Myself.Status = AllEnums.CharStatuses.GOGOGO;
            }
            allAutoAccount.Myself.MinorStatus2 = AllEnums.CharStatuses.TRIEUTAP;
          }
        }
      }
    }
    catch (Exception ex)
    {
      GA.WriteUserLog(frmMain.langFailToCallTeam);
    }
  }

  public static void TrieuTapCaNhom(AutoAccount myAccount, bool MoveNow = false, bool theosau = true)
  {
    if (myAccount.MyParty.PartyNumbers <= 0)
      return;
    if (myAccount.MyParty.AllMembers[0].DatabaseID != myAccount.Myself.DatabaseID)
      return;
    try
    {
      int num = 0;
      for (int index1 = 1; index1 <= myAccount.MyParty.PartyNumbers; ++index1)
      {
        PartyMember allMember = myAccount.MyParty.AllMembers[index1];
        if (allMember.DatabaseID != myAccount.Myself.DatabaseID)
        {
          AutoAccount autoAccount = (AutoAccount) null;
          bool flag = false;
          for (int index2 = frmLogin.GAuto.AllAutoAccounts.Count - 1; index2 >= 0; --index2)
          {
            AutoAccount allAutoAccount = frmLogin.GAuto.AllAutoAccounts[index2];
            if (allAutoAccount.Myself.DatabaseID == allMember.DatabaseID)
            {
              autoAccount = allAutoAccount;
              flag = true;
              break;
            }
          }
          if (!flag)
            ++num;
          if (autoAccount != null)
          {
            autoAccount.IsAIEnabled = true;
            if (autoAccount.Settings.AIMode != AllEnums.AIModes.DANHTUDO)
              autoAccount.Settings.AIMode = AllEnums.AIModes.DANHTUDO;
            if (theosau)
            {
              autoAccount.Settings.cboxTheoSau = true;
              autoAccount.Settings.PTTheoSauMode = 0;
            }
            else
              autoAccount.Settings.cboxTheoSau = false;
            if (autoAccount.Myself.MapID == myAccount.Myself.MapID)
            {
              double distance = GA.CalculateDistance((double) autoAccount.Myself.PosX, (double) autoAccount.Myself.PosY, (double) myAccount.Myself.PosX, (double) myAccount.Myself.PosY);
              if (distance > 6.0)
              {
                if (distance > 35.0)
                  autoAccount.CallLenNgua();
                autoAccount.Myself.Status = AllEnums.CharStatuses.GOGOGO;
                autoAccount.Myself.TargetX = myAccount.Myself.PosX;
                autoAccount.Myself.TargetY = myAccount.Myself.PosY;
                autoAccount.Myself.TargetMapID = myAccount.Myself.MapID;
                autoAccount.Myself.MoveLongTrigger = false;
                autoAccount.Myself.MinorStatus2 = AllEnums.CharStatuses.TRIEUTAP;
                if (MoveNow)
                  autoAccount.Myself.MinorStatus2 = AllEnums.CharStatuses.TRIEUTAPNOW;
              }
              else
              {
                if (autoAccount.Myself.Status != AllEnums.CharStatuses.NHATBOC)
                  autoAccount.Myself.Status = AllEnums.CharStatuses.IDLE;
                autoAccount.Myself.MinorStatus2 = AllEnums.CharStatuses.IDLE;
              }
            }
            else
            {
              autoAccount.Myself.LongMoveMapID = myAccount.Myself.MapID;
              autoAccount.Myself.LongMoveX = (int) myAccount.Myself.PosX;
              autoAccount.Myself.LongMoveY = (int) myAccount.Myself.PosY;
              autoAccount.Myself.MoveLongTrigger = true;
              autoAccount.Myself.Status = AllEnums.CharStatuses.GOGOGO;
              autoAccount.Myself.MinorStatus2 = AllEnums.CharStatuses.TRIEUTAP;
              if (MoveNow)
                autoAccount.Myself.MinorStatus2 = AllEnums.CharStatuses.TRIEUTAPNOW;
              if (autoAccount.Target.VersionNum == 3)
                autoAccount.Myself.IsLongMove = true;
            }
          }
        }
      }
      if (myAccount.MyParty == null)
        return;
      myAccount.MyParty.NotInAutoCount = num;
    }
    catch (Exception ex)
    {
    }
  }

  public static void TrieuTapToMyPos(
    AutoAccount myAccount,
    int PosX,
    int PosY,
    int MapID,
    bool theosau = true)
  {
    int num1 = PosX;
    int num2 = PosY;
    if (myAccount.MyParty.PartyNumbers <= 0)
      return;
    if (myAccount.MyParty.AllMembers[0].DatabaseID != myAccount.Myself.DatabaseID)
      return;
    try
    {
      int num3 = 0;
      int num4 = 0;
      int num5 = 0;
      for (int index1 = 1; index1 <= myAccount.MyParty.PartyNumbers; ++index1)
      {
        PartyMember allMember = myAccount.MyParty.AllMembers[index1];
        if (allMember.DatabaseID != myAccount.Myself.DatabaseID)
        {
          AutoAccount autoAccount = (AutoAccount) null;
          bool flag = false;
          for (int index2 = frmLogin.GAuto.AllAutoAccounts.Count - 1; index2 >= 0; --index2)
          {
            AutoAccount allAutoAccount = frmLogin.GAuto.AllAutoAccounts[index2];
            if (allAutoAccount.Myself.DatabaseID == allMember.DatabaseID)
            {
              autoAccount = allAutoAccount;
              break;
            }
          }
          if (!flag)
            ++num3;
          if (autoAccount != null)
          {
            autoAccount.IsAIEnabled = true;
            if (autoAccount.Settings.AIMode != AllEnums.AIModes.DANHTUDO)
              autoAccount.Settings.AIMode = AllEnums.AIModes.DANHTUDO;
            if (autoAccount.Myself.MapID == MapID)
            {
              if (num1 == 43 && num2 == 91)
              {
                if (autoAccount.Settings.cboQ1Cau.Contains("ầu phả") || autoAccount.Settings.cboQ1Cau.Contains("ght bri") || autoAccount.Settings.cboQ1Cau.Contains("右桥"))
                {
                  if (num5 <= 2)
                  {
                    PosX = 80 /*0x50*/;
                    PosY = 88;
                  }
                  else
                  {
                    PosX = num1;
                    PosY = num2;
                  }
                  ++num5;
                }
                if (autoAccount.Settings.cboQ1Cau.Contains(frmMain.langQ1Bridge))
                {
                  int num6 = 3;
                  if (myAccount.MyParty.PartyNumbers == 3)
                    num6 = 2;
                  if (num4 >= num6)
                  {
                    PosX = 80 /*0x50*/;
                    PosY = 88;
                  }
                  else
                  {
                    if (autoAccount.Settings.cboxDanhTheoKey)
                      autoAccount.Settings.cboxDanhTheoKey = false;
                    PosX = num1;
                    PosY = num2;
                  }
                  ++num4;
                }
              }
              double distance = GA.CalculateDistance((double) autoAccount.Myself.PosX, (double) autoAccount.Myself.PosY, (double) PosX, (double) PosY);
              if (distance > 3.0)
              {
                if (num1 == 43 && num2 == 91 && autoAccount.Myself.ActionStatus == (byte) 7)
                {
                  autoAccount.CallAttackTarget(-1, 34, 0, 0);
                  int khinhCongId = autoAccount.GetKhinhCongID();
                  autoAccount.CallAttackTarget(-1, khinhCongId, 0, 0);
                  Thread.Sleep(100);
                  autoAccount.CallSelectTarget(-1);
                }
                autoAccount.Settings.cboxTheoSau = theosau;
                if (distance > 40.0)
                  autoAccount.CallLenNgua();
                autoAccount.CallMoveTo(PosX, PosY);
                autoAccount.Myself.Status = AllEnums.CharStatuses.GOGOGO;
                autoAccount.Myself.TargetX = (float) PosX;
                autoAccount.Myself.TargetY = (float) PosY;
                autoAccount.Myself.TargetMapID = MapID;
                autoAccount.Myself.MoveLongTrigger = false;
                autoAccount.Myself.MinorStatus2 = AllEnums.CharStatuses.IDLE;
              }
              else
              {
                if (autoAccount.Myself.MapID == 1)
                  autoAccount.CallMoveTo(PosX, PosY);
                if (myAccount.Myself.isYTO)
                  autoAccount.CallMoveTo(PosX, PosY);
                autoAccount.Myself.Status = AllEnums.CharStatuses.IDLE;
              }
            }
            else
            {
              autoAccount.Myself.LongMoveMapID = MapID;
              autoAccount.Myself.LongMoveX = PosX;
              autoAccount.Myself.LongMoveY = PosY;
              autoAccount.Myself.MoveLongTrigger = true;
              autoAccount.Myself.Status = AllEnums.CharStatuses.GOGOGO;
              if (autoAccount.Target.VersionNum == 3 || autoAccount.Target.VersionNum == 4)
                autoAccount.Myself.IsLongMove = true;
            }
          }
        }
      }
      if (myAccount.MyParty == null)
        return;
      myAccount.MyParty.NotInAutoCount = num3;
    }
    catch (Exception ex)
    {
      GA.WriteUserLog(frmMain.langErrorGroupingNearstPoint);
    }
  }

  public static void PartyDoSomething(
    AutoAccount myAccount,
    bool mySelf = false,
    int mode = 0,
    int param1 = -1,
    int param2 = -1,
    int stamp = 0)
  {
    if (myAccount.MyParty.PartyNumbers < 0)
      return;
    myAccount.MyFlag.dosomethingStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
    int num1 = 0;
    List<int> intList1 = new List<int>();
    List<int> intList2 = new List<int>();
    List<int> intList3 = new List<int>();
    if (myAccount.MyParty.AllMembers[0].DatabaseID == myAccount.Myself.DatabaseID || myAccount.MyParty.PartyNumbers == 0 && mySelf)
    {
      if (mySelf)
      {
        if (mode == 1)
          myAccount.MyFlag.xongQstamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
        else if (mode == 2 && myAccount.Target.VersionNum == 3)
        {
          if (myAccount.Target.SubVersion == 10 || myAccount.Target.SubVersion == 0)
            return;
          if (frmLogin.GlobalTimer.ElapsedMilliseconds - myAccount.MyFlag.CanKhonHoStamp > (long) stamp)
            myAccount.MyFlag.CanKhonHoStamp = 0L;
          if (myAccount.MyFlag.CanKhonHoStamp == 0L)
          {
            int num2 = 0;
            while (true)
            {
              bool flag = false;
              for (int index = 0; index < 30; ++index)
              {
                InventoryItem allItem = myAccount.MyInventory.AllItems[index];
                if (allItem.ItemID == 30008009 || allItem.ItemID == 30505217)
                {
                  if (myAccount.Settings.cboxDanhQuai)
                    myAccount.CallXuongNgua();
                  myAccount.CallUseItem(index, myAccount.Myself.ID);
                  myAccount.MyFlag.CanKhonHoStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
                  flag = true;
                }
              }
              if (!frmLogin.GAuto.Settings.TuMuaCKH)
                flag = true;
              ++num2;
              if (myAccount.Target.SubVersion != 1)
              {
                if (myAccount.Target.SubVersion != 2)
                {
                  if (myAccount.Target.SubVersion != 8)
                  {
                    if (myAccount.Target.SubVersion != 9)
                    {
                      if (myAccount.Target.SubVersion != 10)
                      {
                        if (!flag && num2 <= 1)
                        {
                          myAccount.OpenKNBShop(4, 2);
                          Thread.Sleep(200);
                          myAccount.BuyKNBItem(37);
                          Thread.Sleep(500);
                        }
                        else
                          break;
                      }
                      else
                        goto label_100;
                    }
                    else
                      goto label_100;
                  }
                  else
                    goto label_100;
                }
                else
                  goto label_100;
              }
              else
                goto label_100;
            }
            myAccount.BuyListItemKNB();
          }
        }
        else
        {
          switch (mode)
          {
            case 3:
              myAccount.PlayMyLockSkill();
              break;
            case 5:
              myAccount.CallXuongNgua();
              myAccount.MyFlag.noBuffStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
              myAccount.MyFlag.noAttackStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
              if (myAccount.MySkills.KhinhCongID == 0)
              {
                myAccount.CallKhinhCongPacket(param1, param2);
                Thread.Sleep(1000);
              }
              else
                myAccount.CallKhinhCongPacket(param1, param2, myAccount.MySkills.KhinhCongID);
              if (myAccount.Myself.EventString == "KNVH")
              {
                int khinhCongId = myAccount.GetKhinhCongID();
                myAccount.CallKhinhCongPacket(param1, param2, khinhCongId);
                myAccount.MySkills.KhinhCongID = khinhCongId;
              }
              if (myAccount.Myself.ActionStatus == (byte) 3)
              {
                if (myAccount.MySkills.KhinhCongID == 0)
                  myAccount.MySkills.KhinhCongID = 34;
                myAccount.ResetEventString();
                break;
              }
              break;
            case 7:
              if (param1 == 1)
                myAccount.MyFlag.useItemTriggerStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
              for (int index = 0; index < 30; ++index)
              {
                if (myAccount.MyInventory.AllItems[index].ItemID == 30103042)
                {
                  myAccount.CallUseItem(index, myAccount.Myself.ID);
                  break;
                }
              }
              break;
            case 8:
              if (param1 == -1)
              {
                if (GA.IsInPhuBan(myAccount.Myself.MapID))
                {
                  int itemIndex = myAccount.SearchTLC(4);
                  if (itemIndex >= 0)
                  {
                    myAccount.CallXuongNgua();
                    myAccount.CallUseItem(itemIndex, myAccount.Myself.ID);
                    myAccount.Myself.IDLEStamp = frmLogin.GlobalTimer.ElapsedMilliseconds + 10000L;
                    break;
                  }
                  if (param2 == -1)
                  {
                    myAccount.CallXuongNgua();
                    myAccount.CallAttackTarget(0, 22, 0, 0);
                    myAccount.Myself.IDLEStamp = frmLogin.GlobalTimer.ElapsedMilliseconds + 20000L;
                    break;
                  }
                  break;
                }
                break;
              }
              if (param1 >= 0)
              {
                if (!GA.isInCity(myAccount.Myself.MapID))
                {
                  int itemIndex = param1 != 99 ? myAccount.SearchDVP(param1) : myAccount.SearchDVP();
                  if (itemIndex >= 0)
                  {
                    myAccount.CallXuongNgua();
                    Thread.Sleep(500);
                    myAccount.CallUseItem(itemIndex, myAccount.Myself.ID);
                    myAccount.Myself.IDLEStamp = frmLogin.GlobalTimer.ElapsedMilliseconds + 10000L;
                    break;
                  }
                  myAccount.CallXuongNgua();
                  Thread.Sleep(500);
                  myAccount.CallAttackTarget(0, 22, 0, 0);
                  myAccount.Myself.IDLEStamp = frmLogin.GlobalTimer.ElapsedMilliseconds + 20000L;
                  break;
                }
                break;
              }
              break;
            case 9:
              myAccount.CallOutGame();
              break;
            case 11:
              myAccount.MyFlag.noAttackStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
              if (param1 == 1)
              {
                if (myAccount.Myself.ActionStatus == (byte) 7)
                {
                  if (myAccount.MySkills.KhinhCongID > 0)
                  {
                    myAccount.CallAttackTarget(-1, myAccount.MySkills.KhinhCongID, 0, 0);
                    break;
                  }
                  myAccount.CallAttackTarget(-1, 34, 0, 0);
                  int khinhCongId = myAccount.GetKhinhCongID();
                  myAccount.CallAttackTarget(-1, khinhCongId, 0, 0);
                  break;
                }
                break;
              }
              break;
            case 12:
              int num3 = 0;
              for (int index = 0; index < 30; ++index)
              {
                if (myAccount.MyInventory.AllItems[index].ItemID == 30103042)
                {
                  ++num3;
                  if (num3 >= param1)
                    myAccount.CallRemoveInventoryItem(index);
                }
              }
              break;
            case 13:
              myAccount.Settings.cboxTuNhatVatPham = param1 == 1;
              break;
            case 14:
              myAccount.MyFlag.nodelayAction = frmLogin.GlobalTimer.ElapsedMilliseconds;
              break;
            case 16 /*0x10*/:
              if (myAccount.MyPet.ActivePetID != 0)
              {
                bool flag = true;
                if (myAccount.Myself.Menpai == AllEnums.Menpais.NGAMI && !myAccount.Settings.cboxDanhQuai)
                  flag = false;
                if (flag)
                {
                  myAccount.MyPet.flagAllowPet = false;
                  myAccount.CallThuPet(myAccount.MyPet.ActivePetGuidID, myAccount.MyPet.ActivePetDBID);
                  break;
                }
                break;
              }
              break;
            case 17:
              myAccount.MyPet.flagAllowPet = true;
              break;
            case 18:
              myAccount.MyFlag.noPlaySkillStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
              if (param1 == 1)
              {
                myAccount.MyFlag.noPlaySkillStamp = frmLogin.GlobalTimer.ElapsedMilliseconds - 8000L;
                break;
              }
              break;
            case 20:
              if (myAccount.MyFlag.SaveFightMode == AllEnums.FightingModes.DANHPETONLY)
              {
                myAccount.MyFlag.SaveFightMode = myAccount.Settings.FightMode;
                myAccount.Settings.FightMode = AllEnums.FightingModes.DANHGOMQUAI;
                myAccount.MyFlag.saveDanhTheoKey = myAccount.Settings.cboxDanhTheoKey;
                myAccount.Settings.cboxDanhTheoKey = false;
                myAccount.Settings.cboxDanhTheoAi = false;
              }
              if (param1 > 0)
              {
                myAccount.MyFlag.saveDiameter = (int) myAccount.Settings.Diameter4;
                myAccount.Settings.Diameter4 = myAccount.Myself.CharType != AllEnums.CharTypes.TANKER ? (double) param1 : 5.0;
                break;
              }
              break;
            case 21:
              if (myAccount.MyFlag.SaveFightMode != AllEnums.FightingModes.DANHPETONLY)
              {
                myAccount.Settings.FightMode = myAccount.MyFlag.SaveFightMode;
                myAccount.MyFlag.SaveFightMode = AllEnums.FightingModes.DANHPETONLY;
                myAccount.Settings.cboxDanhTheoKey = myAccount.MyFlag.saveDanhTheoKey;
              }
              if (param1 > 0)
              {
                myAccount.Settings.Diameter4 = 30.0;
                break;
              }
              break;
            case 22:
              if (myAccount.Myself.Menpai == AllEnums.Menpais.NGAMI)
                intList1.Add(myAccount.Myself.DatabaseID);
              if (myAccount.Myself.HP <= 0)
              {
                intList2.Add(myAccount.Myself.ID);
                break;
              }
              break;
            case 23:
              myAccount.Settings.AIMode = AllEnums.AIModes.DANHTUDO;
              frmMain.DisableNhiemVu(myAccount);
              break;
            case 24:
              myAccount.BackToTrainSpot();
              break;
            case 26:
              myAccount.CallOutGame();
              break;
            case 27:
              myAccount.ResetTimeAdvanced();
              break;
            case 29:
              myAccount.Settings.cboxChoHoiSinh = false;
              break;
            case 31 /*0x1F*/:
              myAccount.HuyNhiemVu(param1);
              break;
            case 32 /*0x20*/:
              myAccount.Myself.isBanDoChoNPC = true;
              if (myAccount.Settings.cboxTheoSau)
              {
                myAccount.Myself.actionFlag = 1;
                myAccount.Settings.cboxTheoSau = false;
                break;
              }
              break;
          }
        }
      }
label_100:
      try
      {
label_239:
        for (int index1 = 1; index1 <= myAccount.MyParty.PartyNumbers; ++index1)
        {
          PartyMember allMember = myAccount.MyParty.AllMembers[index1];
          if (allMember.DatabaseID != myAccount.Myself.DatabaseID)
          {
            AutoAccount memberAccount = (AutoAccount) null;
            for (int index2 = frmLogin.GAuto.AllAutoAccounts.Count - 1; index2 >= 0; --index2)
            {
              AutoAccount allAutoAccount = frmLogin.GAuto.AllAutoAccounts[index2];
              if (allAutoAccount.Myself.DatabaseID == allMember.DatabaseID)
              {
                memberAccount = allAutoAccount;
                break;
              }
            }
            if (memberAccount != null)
            {
              if (mode == 1)
                memberAccount.MyFlag.xongQstamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
              else if (mode == 2 && myAccount.Target.VersionNum == 3)
              {
                if (frmLogin.GlobalTimer.ElapsedMilliseconds - memberAccount.MyFlag.CanKhonHoStamp > (long) stamp)
                  memberAccount.MyFlag.CanKhonHoStamp = 0L;
                if (memberAccount.MyFlag.CanKhonHoStamp == 0L)
                {
                  int num4 = 0;
                  while (true)
                  {
                    bool flag = false;
                    for (int index3 = 0; index3 < 30; ++index3)
                    {
                      InventoryItem allItem = memberAccount.MyInventory.AllItems[index3];
                      if (allItem.ItemID == 30008009 || allItem.ItemID == 30505217)
                      {
                        memberAccount.CallXuongNgua();
                        memberAccount.CallUseItem(index3, memberAccount.Myself.ID);
                        memberAccount.MyFlag.CanKhonHoStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
                        flag = true;
                      }
                    }
                    ++num4;
                    if (memberAccount.Target.SubVersion != 1 && memberAccount.Target.SubVersion != 2 && memberAccount.Target.SubVersion != 8)
                    {
                      if (!frmLogin.GAuto.Settings.TuMuaCKH)
                        flag = true;
                      if (!flag && num4 <= 1)
                      {
                        memberAccount.OpenKNBShop(4, 2);
                        Thread.Sleep(200);
                        memberAccount.BuyKNBItem(37);
                        Thread.Sleep(300);
                      }
                      else
                        break;
                    }
                    else
                      goto label_239;
                  }
                  memberAccount.BuyListItemKNB();
                }
              }
              else
              {
                switch (mode)
                {
                  case 3:
                    memberAccount.PlayMyLockSkill();
                    if (index1 > myAccount.MyFlag.dosomethingCounter)
                      return;
                    continue;
                  case 4:
                    if (GA.IsInPhuBan(memberAccount.Myself.MapID, memberAccount))
                    {
                      memberAccount.CallMoveTo(30, 12);
                      continue;
                    }
                    continue;
                  case 5:
                    memberAccount.CallXuongNgua();
                    memberAccount.MyFlag.noBuffStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
                    memberAccount.MyFlag.noAttackStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
                    if (memberAccount.MySkills.KhinhCongID == 0)
                    {
                      memberAccount.CallKhinhCongPacket(param1, param2);
                      Thread.Sleep(1000);
                    }
                    else
                      memberAccount.CallKhinhCongPacket(param1, param2, memberAccount.MySkills.KhinhCongID);
                    if (memberAccount.Myself.EventString == "KNVH")
                    {
                      int khinhCongId = memberAccount.GetKhinhCongID();
                      memberAccount.CallKhinhCongPacket(param1, param2, khinhCongId);
                      memberAccount.MySkills.KhinhCongID = khinhCongId;
                    }
                    if (memberAccount.Myself.ActionStatus == (byte) 3)
                    {
                      if (memberAccount.MySkills.KhinhCongID == 0)
                        memberAccount.MySkills.KhinhCongID = 34;
                      memberAccount.ResetEventString();
                      continue;
                    }
                    continue;
                  case 6:
                    memberAccount.Settings.cboxDanhTheoKey = true;
                    continue;
                  case 7:
                    if (param1 == 1)
                      memberAccount.MyFlag.useItemTriggerStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
                    for (int index4 = 0; index4 < 30; ++index4)
                    {
                      if (memberAccount.MyInventory.AllItems[index4].ItemID == 30103042)
                      {
                        memberAccount.CallUseItem(index4, memberAccount.Myself.ID);
                        break;
                      }
                    }
                    continue;
                  case 8:
                    if (memberAccount.Myself.IsPartyFollowed == (byte) 0)
                    {
                      if (param1 == -1)
                      {
                        if (GA.IsInPhuBan(memberAccount.Myself.MapID) || param2 > 0)
                        {
                          ++num1;
                          int itemIndex = memberAccount.SearchTLC(4);
                          if (itemIndex >= 0)
                          {
                            memberAccount.CallXuongNgua();
                            memberAccount.CallUseItem(itemIndex, memberAccount.Myself.ID);
                            memberAccount.Myself.IDLEStamp = frmLogin.GlobalTimer.ElapsedMilliseconds + 10000L;
                            continue;
                          }
                          if (param2 == -1)
                          {
                            memberAccount.CallXuongNgua();
                            memberAccount.CallAttackTarget(0, 22, 0, 0);
                            memberAccount.Myself.IDLEStamp = frmLogin.GlobalTimer.ElapsedMilliseconds + 20000L;
                            continue;
                          }
                          continue;
                        }
                        continue;
                      }
                      if (param1 >= 0 && !GA.isInCity(memberAccount.Myself.MapID))
                      {
                        int itemIndex = param1 != 99 ? memberAccount.SearchDVP(param1) : memberAccount.SearchDVP();
                        if (itemIndex >= 0)
                        {
                          memberAccount.CallXuongNgua();
                          Thread.Sleep(500);
                          memberAccount.CallUseItem(itemIndex, myAccount.Myself.ID);
                          memberAccount.Myself.IDLEStamp = frmLogin.GlobalTimer.ElapsedMilliseconds + 10000L;
                          continue;
                        }
                        memberAccount.CallXuongNgua();
                        Thread.Sleep(500);
                        memberAccount.CallAttackTarget(0, 22, 0, 0);
                        memberAccount.Myself.IDLEStamp = frmLogin.GlobalTimer.ElapsedMilliseconds + 20000L;
                        continue;
                      }
                      continue;
                    }
                    continue;
                  case 9:
                    memberAccount.CallOutGame();
                    continue;
                  case 10:
                    memberAccount.CallAttackTargetPacket(memberAccount.Myself.ID, 21, 0, 0, 0);
                    continue;
                  case 11:
                    memberAccount.MyFlag.noAttackStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
                    if (param1 == 1 && memberAccount.Myself.ActionStatus == (byte) 7)
                    {
                      if (memberAccount.MySkills.KhinhCongID > 0)
                      {
                        memberAccount.CallAttackTarget(-1, memberAccount.MySkills.KhinhCongID, 0, 0);
                        continue;
                      }
                      memberAccount.CallAttackTarget(-1, 34, 0, 0);
                      int khinhCongId = memberAccount.GetKhinhCongID();
                      memberAccount.CallAttackTarget(-1, khinhCongId, 0, 0);
                      continue;
                    }
                    continue;
                  case 12:
                    int num5 = 0;
                    for (int index5 = 0; index5 < 30; ++index5)
                    {
                      if (memberAccount.MyInventory.AllItems[index5].ItemID == 30103042)
                      {
                        ++num5;
                        if (num5 >= param1)
                          memberAccount.CallRemoveInventoryItem(index5);
                      }
                    }
                    continue;
                  case 13:
                    memberAccount.Settings.cboxTuNhatVatPham = param1 == 1;
                    continue;
                  case 14:
                    memberAccount.MyFlag.nodelayAction = frmLogin.GlobalTimer.ElapsedMilliseconds;
                    continue;
                  case 15:
                    memberAccount.Settings.cboxTheoSau = false;
                    continue;
                  case 16 /*0x10*/:
                    if (memberAccount.MyPet.ActivePetID != 0)
                    {
                      bool flag = true;
                      if (memberAccount.Myself.Menpai == AllEnums.Menpais.NGAMI && !memberAccount.Settings.cboxDanhQuai)
                        flag = false;
                      if (flag)
                      {
                        memberAccount.MyPet.flagAllowPet = false;
                        memberAccount.CallThuPet(memberAccount.MyPet.ActivePetGuidID, memberAccount.MyPet.ActivePetDBID);
                        continue;
                      }
                      continue;
                    }
                    continue;
                  case 17:
                    memberAccount.MyPet.flagAllowPet = true;
                    continue;
                  case 18:
                    memberAccount.MyFlag.noPlaySkillStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
                    if (param1 == 1)
                    {
                      memberAccount.MyFlag.noPlaySkillStamp = frmLogin.GlobalTimer.ElapsedMilliseconds - 8000L;
                      continue;
                    }
                    continue;
                  case 19:
                    memberAccount.MyFlag.inYTOStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
                    continue;
                  case 20:
                    if (memberAccount.MyFlag.SaveFightMode == AllEnums.FightingModes.DANHPETONLY)
                    {
                      memberAccount.MyFlag.SaveFightMode = memberAccount.Settings.FightMode;
                      memberAccount.Settings.FightMode = AllEnums.FightingModes.DANHGOMQUAI;
                      memberAccount.MyFlag.saveDanhTheoKey = memberAccount.Settings.cboxDanhTheoKey;
                      memberAccount.Settings.cboxDanhTheoKey = false;
                      memberAccount.Settings.cboxDanhTheoAi = false;
                    }
                    if (param1 > 0)
                    {
                      memberAccount.MyFlag.saveDiameter = (int) memberAccount.Settings.Diameter4;
                      memberAccount.Settings.Diameter4 = memberAccount.Myself.CharType != AllEnums.CharTypes.TANKER ? (double) param1 : 5.0;
                      continue;
                    }
                    continue;
                  case 21:
                    if (memberAccount.MyFlag.SaveFightMode != AllEnums.FightingModes.DANHPETONLY)
                    {
                      memberAccount.Settings.FightMode = memberAccount.MyFlag.SaveFightMode;
                      memberAccount.MyFlag.SaveFightMode = AllEnums.FightingModes.DANHPETONLY;
                      memberAccount.Settings.cboxDanhTheoKey = memberAccount.MyFlag.saveDanhTheoKey;
                    }
                    if (param1 > 0)
                    {
                      memberAccount.Settings.Diameter4 = 30.0;
                      continue;
                    }
                    continue;
                  case 22:
                    if (memberAccount.Myself.Menpai == AllEnums.Menpais.NGAMI)
                      intList1.Add(memberAccount.Myself.DatabaseID);
                    if (memberAccount.Myself.HP <= 0)
                    {
                      intList2.Add(memberAccount.Myself.ID);
                      continue;
                    }
                    continue;
                  case 23:
                    bool flag1 = false;
                    switch (param1)
                    {
                      case 0:
                        if (memberAccount.Myself.Menpai == AllEnums.Menpais.THIEULAM)
                        {
                          flag1 = true;
                          break;
                        }
                        break;
                      case 1:
                        if (memberAccount.Myself.Menpai == AllEnums.Menpais.MINHGIAO)
                        {
                          flag1 = true;
                          break;
                        }
                        break;
                      case 2:
                        if (memberAccount.Myself.Menpai == AllEnums.Menpais.CAIBANG)
                        {
                          flag1 = true;
                          break;
                        }
                        break;
                      case 3:
                        if (memberAccount.Myself.Menpai == AllEnums.Menpais.VODANG)
                        {
                          flag1 = true;
                          break;
                        }
                        break;
                      case 4:
                        if (memberAccount.Myself.Menpai == AllEnums.Menpais.NGAMI)
                        {
                          flag1 = true;
                          break;
                        }
                        break;
                      case 5:
                        if (memberAccount.Myself.Menpai == AllEnums.Menpais.TINHTUC)
                        {
                          flag1 = true;
                          break;
                        }
                        break;
                      case 6:
                        if (memberAccount.Myself.Menpai == AllEnums.Menpais.THIENLONG)
                        {
                          flag1 = true;
                          break;
                        }
                        break;
                      case 7:
                        if (memberAccount.Myself.Menpai == AllEnums.Menpais.THIENSON)
                        {
                          flag1 = true;
                          break;
                        }
                        break;
                      case 8:
                        if (memberAccount.Myself.Menpai == AllEnums.Menpais.TIEUDAO)
                        {
                          flag1 = true;
                          break;
                        }
                        break;
                      case 10:
                        if (memberAccount.Myself.Menpai == AllEnums.Menpais.MODUNG)
                        {
                          flag1 = true;
                          break;
                        }
                        break;
                      case 11:
                        if (memberAccount.Myself.Menpai == AllEnums.Menpais.DUONGMON)
                        {
                          flag1 = true;
                          break;
                        }
                        break;
                      case 12:
                        if (memberAccount.Myself.Menpai == AllEnums.Menpais.QUYCOC)
                        {
                          flag1 = true;
                          break;
                        }
                        break;
                    }
                    if (flag1)
                    {
                      myAccount.CallTransferPTKey(memberAccount.Myself.DatabaseID, memberAccount.Myself.DatabaseIDLow);
                      Thread.Sleep(2000);
                      if (memberAccount.Myself.IsAcBa)
                        return;
                      memberAccount.MyFlag.DatLichFlag = true;
                      frmMain.frmMainInstance.cboxIsAcBa.Invoke((Delegate) (() => frmMain.frmMainInstance.NVAcBa(memberAccount)));
                      return;
                    }
                    continue;
                  case 24:
                    memberAccount.Settings.MapID = myAccount.Settings.MapID;
                    memberAccount.Settings.CenterX = myAccount.Settings.CenterX;
                    memberAccount.Settings.CenterY = myAccount.Settings.CenterY;
                    memberAccount.BackToTrainSpot();
                    continue;
                  case 25:
                    if (!memberAccount.IsAIEnabled)
                      memberAccount.IsAIEnabled = true;
                    if (memberAccount.Settings.AIMode == AllEnums.AIModes.NHIEMVU || memberAccount.Settings.AIMode == AllEnums.AIModes.KHAIKHOANG_HAIDUOC || memberAccount.Settings.AIMode == AllEnums.AIModes.TRONGTROT)
                    {
                      memberAccount.Settings.AIMode = AllEnums.AIModes.DANHTUDO;
                      frmMain.DisableNhiemVu(memberAccount);
                      continue;
                    }
                    continue;
                  case 26:
                    memberAccount.CallOutGame();
                    continue;
                  case 27:
                    memberAccount.ResetTimeAdvanced();
                    continue;
                  case 28:
                    memberAccount.CallSelectTarget(param1);
                    memberAccount.CallTuyenChien(param1);
                    memberAccount.AttackPlayer(param1);
                    continue;
                  case 29:
                    memberAccount.Settings.cboxChoHoiSinh = false;
                    continue;
                  case 30:
                    if (memberAccount.Myself.IsPartyFollowed == (byte) 1)
                    {
                      memberAccount.CallRemovePartyFollow();
                      continue;
                    }
                    continue;
                  case 31 /*0x1F*/:
                    memberAccount.HuyNhiemVu(param1);
                    continue;
                  case 32 /*0x20*/:
                    memberAccount.Myself.isBanDoChoNPC = true;
                    if (memberAccount.Settings.cboxTheoSau)
                    {
                      memberAccount.Myself.actionFlag = 1;
                      memberAccount.Settings.cboxTheoSau = false;
                      continue;
                    }
                    continue;
                  default:
                    continue;
                }
              }
            }
          }
        }
      }
      catch (Exception ex)
      {
        GA.WriteUserLog(frmMain.langErrorPartyDoST, myAccount);
      }
    }
    if (mode == 22)
    {
      if (intList2.Count > 0)
      {
        try
        {
          int index6 = 0;
          AutoAccount autoAccount1 = (AutoAccount) null;
          AutoAccount autoAccount2 = (AutoAccount) null;
          AutoAccount autoAccount3 = (AutoAccount) null;
          bool flag = false;
          for (int index7 = 0; index7 < intList2.Count; ++index7)
          {
            int targetID = intList2[index7];
            if (intList1.Count >= index6 + 1)
            {
              int num6 = intList1[index6];
              for (int index8 = frmLogin.GAuto.AllAutoAccounts.Count - 1; index8 >= 0; --index8)
              {
                AutoAccount allAutoAccount = frmLogin.GAuto.AllAutoAccounts[index8];
                if (allAutoAccount.Myself.DatabaseID == num6)
                {
                  autoAccount1 = allAutoAccount;
                  break;
                }
              }
              if (autoAccount1 != null)
              {
                autoAccount1.CallAttackTarget(targetID, 408, 0, 0);
                intList3.Add(targetID);
                flag = true;
              }
              ++index6;
            }
            else if (param1 == 2)
            {
              for (int index9 = frmLogin.GAuto.AllAutoAccounts.Count - 1; index9 >= 0; --index9)
              {
                AutoAccount allAutoAccount = frmLogin.GAuto.AllAutoAccounts[index9];
                if (allAutoAccount.Myself.ID == targetID)
                {
                  autoAccount2 = allAutoAccount;
                  break;
                }
              }
              autoAccount2?.CallThoatXac();
            }
          }
          if (flag)
          {
            if (param1 == 0 || param1 == 2)
            {
              Thread.Sleep(15000);
              if (intList3.Count > 0)
              {
                for (int index10 = 0; index10 < intList3.Count; ++index10)
                {
                  for (int index11 = frmLogin.GAuto.AllAutoAccounts.Count - 1; index11 >= 0; --index11)
                  {
                    AutoAccount allAutoAccount = frmLogin.GAuto.AllAutoAccounts[index11];
                    if (allAutoAccount.Myself.ID == intList3[index10])
                    {
                      autoAccount3 = allAutoAccount;
                      break;
                    }
                  }
                  autoAccount3?.CallHoiSinh();
                }
              }
            }
            else
              Thread.Sleep(3000);
          }
        }
        catch (Exception ex)
        {
          GA.WriteUserLog(frmMain.langErrorLotusRevive);
        }
      }
      else if (param1 == 0 || param1 == 2)
        myAccount.MyFlag.dosomethingHoisinhFlag = 1;
    }
    if (num1 != 0 || mode != 8)
      return;
    myAccount.MyFlag.dosomethingFlag = 1;
  }

  public static bool CheckPartyKeyLock(AutoAccount myAccount)
  {
    if (myAccount.MyParty.PartyNumbers > 0)
    {
      if (myAccount.MyParty.AllMembers[0].DatabaseID == myAccount.Myself.DatabaseID)
      {
        try
        {
          for (int index1 = 1; index1 <= myAccount.MyParty.PartyNumbers; ++index1)
          {
            PartyMember allMember = myAccount.MyParty.AllMembers[index1];
            if (allMember.DatabaseID != myAccount.Myself.DatabaseID)
            {
              AutoAccount autoAccount = (AutoAccount) null;
              for (int index2 = frmLogin.GAuto.AllAutoAccounts.Count - 1; index2 >= 0; --index2)
              {
                AutoAccount allAutoAccount = frmLogin.GAuto.AllAutoAccounts[index2];
                if (allAutoAccount.Myself.DatabaseID == allMember.DatabaseID)
                {
                  autoAccount = allAutoAccount;
                  break;
                }
              }
              if (autoAccount != null && autoAccount.Myself.PartyKeyLock)
                return true;
            }
          }
        }
        catch (Exception ex)
        {
          GA.WriteUserLog(frmMain.langErrorCheckLockKey, myAccount);
        }
        return false;
      }
    }
    return false;
  }

  public static void PartyGiveKeyToMe(AutoAccount myAccount)
  {
    if (myAccount.MyParty.PartyNumbers <= 0)
      return;
    PartyMember allMember = myAccount.MyParty.AllMembers[0];
    if (allMember.DatabaseID == myAccount.Myself.DatabaseID)
      return;
    try
    {
      AutoAccount autoAccount = (AutoAccount) null;
      for (int index = frmLogin.GAuto.AllAutoAccounts.Count - 1; index >= 0; --index)
      {
        AutoAccount allAutoAccount = frmLogin.GAuto.AllAutoAccounts[index];
        if (allAutoAccount.Myself.DatabaseID == allMember.DatabaseID)
        {
          autoAccount = allAutoAccount;
          break;
        }
      }
      autoAccount?.CallTransferPTKey(myAccount.Myself.DatabaseID, myAccount.Myself.DatabaseIDLow);
    }
    catch (Exception ex)
    {
      GA.WriteUserLog(frmMain.langErrorCheckPTStatus, myAccount);
    }
  }

  public static bool CheckStatusParty(AutoAccount myAccount)
  {
    if (myAccount.MyParty.PartyNumbers > 0)
    {
      if (myAccount.MyParty.AllMembers[0].DatabaseID == myAccount.Myself.DatabaseID)
      {
        try
        {
          for (int index1 = 1; index1 <= myAccount.MyParty.PartyNumbers; ++index1)
          {
            PartyMember allMember = myAccount.MyParty.AllMembers[index1];
            if (allMember.DatabaseID != myAccount.Myself.DatabaseID)
            {
              AutoAccount autoAccount = (AutoAccount) null;
              for (int index2 = frmLogin.GAuto.AllAutoAccounts.Count - 1; index2 >= 0; --index2)
              {
                AutoAccount allAutoAccount = frmLogin.GAuto.AllAutoAccounts[index2];
                if (allAutoAccount.Myself.DatabaseID == allMember.DatabaseID)
                {
                  autoAccount = allAutoAccount;
                  break;
                }
              }
              if (autoAccount != null && autoAccount.Myself.Status == AllEnums.CharStatuses.NHATBOC)
                return false;
            }
          }
        }
        catch (Exception ex)
        {
          GA.WriteUserLog(frmMain.langErrorCheckPTStatus, myAccount);
        }
        return true;
      }
    }
    return true;
  }

  public static void ResetStatusParty(AutoAccount myAccount, bool checkStatus = false)
  {
    if (myAccount.MyParty.PartyNumbers <= 0)
      return;
    if (myAccount.MyParty.AllMembers[0].DatabaseID != myAccount.Myself.DatabaseID)
      return;
    try
    {
      for (int index1 = 1; index1 <= myAccount.MyParty.PartyNumbers; ++index1)
      {
        PartyMember allMember = myAccount.MyParty.AllMembers[index1];
        if (allMember.DatabaseID != myAccount.Myself.DatabaseID)
        {
          AutoAccount autoAccount = (AutoAccount) null;
          for (int index2 = frmLogin.GAuto.AllAutoAccounts.Count - 1; index2 >= 0; --index2)
          {
            AutoAccount allAutoAccount = frmLogin.GAuto.AllAutoAccounts[index2];
            if (allAutoAccount.Myself.DatabaseID == allMember.DatabaseID)
            {
              autoAccount = allAutoAccount;
              break;
            }
          }
          if (autoAccount != null)
          {
            if (autoAccount.Myself.Status != AllEnums.CharStatuses.IDLE)
              autoAccount.Myself.Status = AllEnums.CharStatuses.IDLE;
            if (autoAccount.Myself.SavedStatus != AllEnums.CharStatuses.IDLE)
              autoAccount.Myself.SavedStatus = AllEnums.CharStatuses.IDLE;
            autoAccount.Myself.MinorStatus = AllEnums.CharStatuses.IDLE;
            autoAccount.Myself.MinorStatus2 = AllEnums.CharStatuses.IDLE;
          }
        }
      }
    }
    catch (Exception ex)
    {
      GA.WriteUserLog(frmMain.langErrorResetPT, myAccount);
    }
  }

  public static bool checkFlagParty(AutoAccount myAccount, int mode = 0)
  {
    if (myAccount.MyParty.PartyNumbers > 0)
    {
      if (myAccount.MyParty.AllMembers[0].DatabaseID == myAccount.Myself.DatabaseID)
      {
        try
        {
          for (int index1 = 1; index1 <= myAccount.MyParty.PartyNumbers; ++index1)
          {
            PartyMember allMember = myAccount.MyParty.AllMembers[index1];
            if (allMember.DatabaseID != myAccount.Myself.DatabaseID)
            {
              AutoAccount autoAccount = (AutoAccount) null;
              for (int index2 = frmLogin.GAuto.AllAutoAccounts.Count - 1; index2 >= 0; --index2)
              {
                AutoAccount allAutoAccount = frmLogin.GAuto.AllAutoAccounts[index2];
                if (allAutoAccount.Myself.DatabaseID == allMember.DatabaseID)
                {
                  autoAccount = allAutoAccount;
                  break;
                }
              }
              if (autoAccount != null && mode == 1 && autoAccount.Myself.isBanDoChoNPC)
                return false;
            }
          }
        }
        catch (Exception ex)
        {
          GA.WriteUserLog(frmMain.langErrorCheckPTStatus, myAccount);
        }
        return true;
      }
    }
    return true;
  }

  public static void PartyUsePhuWithMap(
    AutoAccount myAccount,
    bool mySelf = true,
    int mapID = -1,
    int posX = -1,
    int posY = -1)
  {
    if (myAccount.MyParty.PartyNumbers <= 0 || myAccount.MyParty.AllMembers[0].DatabaseID != myAccount.Myself.DatabaseID)
      return;
    if (mySelf)
    {
      myAccount.Myself.Status = AllEnums.CharStatuses.DUNGPHUDIVE;
      myAccount.Myself.dungphudiveMapID = mapID;
      myAccount.Myself.dungphudivePosX = posX;
      myAccount.Myself.dungphudivePosY = posY;
      myAccount.Myself.dungphudiveStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
    }
    try
    {
      for (int index1 = 1; index1 <= myAccount.MyParty.PartyNumbers; ++index1)
      {
        PartyMember allMember = myAccount.MyParty.AllMembers[index1];
        if (allMember.DatabaseID != myAccount.Myself.DatabaseID)
        {
          AutoAccount autoAccount = (AutoAccount) null;
          for (int index2 = frmLogin.GAuto.AllAutoAccounts.Count - 1; index2 >= 0; --index2)
          {
            AutoAccount allAutoAccount = frmLogin.GAuto.AllAutoAccounts[index2];
            if (allAutoAccount.Myself.DatabaseID == allMember.DatabaseID)
            {
              autoAccount = allAutoAccount;
              break;
            }
          }
          if (autoAccount != null)
          {
            autoAccount.Myself.Status = AllEnums.CharStatuses.DUNGPHUDIVE;
            autoAccount.Myself.dungphudiveMapID = mapID;
            autoAccount.Myself.dungphudivePosX = posX;
            autoAccount.Myself.dungphudivePosY = posY;
            autoAccount.Myself.dungphudiveStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
          }
        }
      }
    }
    catch (Exception ex)
    {
      GA.WriteUserLog(frmMain.langErrorUsingSpellingLoc, myAccount);
    }
  }

  public static void PartyTalkNPC(
    AutoAccount myAccount,
    int npcID,
    int menuType,
    int menuIndex,
    bool clickNPC = true,
    int mode = 0)
  {
    if (myAccount.MyParty.PartyNumbers <= 0)
      return;
    if (myAccount.MyParty.AllMembers[0].DatabaseID != myAccount.Myself.DatabaseID)
      return;
    try
    {
      for (int index1 = 1; index1 <= myAccount.MyParty.PartyNumbers; ++index1)
      {
        PartyMember allMember = myAccount.MyParty.AllMembers[index1];
        if (allMember.DatabaseID != myAccount.Myself.DatabaseID)
        {
          AutoAccount autoAccount = (AutoAccount) null;
          for (int index2 = frmLogin.GAuto.AllAutoAccounts.Count - 1; index2 >= 0; --index2)
          {
            AutoAccount allAutoAccount = frmLogin.GAuto.AllAutoAccounts[index2];
            if (allAutoAccount.Myself.DatabaseID == allMember.DatabaseID)
            {
              autoAccount = allAutoAccount;
              break;
            }
          }
          if (autoAccount != null)
          {
            int millisecondsTimeout = 700;
            if (clickNPC)
            {
              autoAccount.CallTalkNPC(0, 0, npcID);
              if (menuType == 50100 || menuType == 50101)
              {
                autoAccount.CallRemovePartyFollow();
                Thread.Sleep(millisecondsTimeout);
              }
              else
                Thread.Sleep(millisecondsTimeout);
            }
            if ((menuType != 50100 || menuIndex != 2) && (menuType != 50101 || menuIndex != 2) || autoAccount.Settings.cboxTuHuyNV && (autoAccount.MyFlag.xongQstamp <= 0L || frmLogin.GlobalTimer.ElapsedMilliseconds - autoAccount.MyFlag.xongQstamp > 120000L))
            {
              autoAccount.CallTalkNPC(menuType, menuIndex, npcID);
              Thread.Sleep(millisecondsTimeout);
              if (autoAccount.Myself.PacketMsg == "NVTB")
              {
                autoAccount.ResetPacketMsg();
                if (autoAccount.MyFlag.xongQstamp <= 0L || frmLogin.GlobalTimer.ElapsedMilliseconds - autoAccount.MyFlag.xongQstamp > 60000L)
                {
                  if (autoAccount.MyFlag.hongQcounter >= 4)
                  {
                    if (autoAccount.Settings.cboxTuHuyNV)
                      autoAccount.HuyNhiemVu(menuType);
                    if (autoAccount.Settings.cboxHongQPT)
                      autoAccount.CallLeavePT();
                    autoAccount.MyFlag.hongQcounter = 0;
                  }
                  else
                    ++autoAccount.MyFlag.hongQcounter;
                }
              }
              else if (autoAccount.Myself.PacketMsg == "DGXQ")
              {
                autoAccount.CallTraNhiemVu();
                Thread.Sleep(millisecondsTimeout + 300);
                autoAccount.CallTraNhiemVu();
                autoAccount.ResetPacketMsg();
                autoAccount.MyFlag.hongQcounter = 0;
              }
              else
              {
                switch (mode)
                {
                  case 1:
                    autoAccount.CallNhanNhiemVu();
                    Thread.Sleep(millisecondsTimeout);
                    continue;
                  case 2:
                    autoAccount.CallTraNhiemVu();
                    Thread.Sleep(millisecondsTimeout);
                    continue;
                  default:
                    continue;
                }
              }
            }
          }
        }
      }
    }
    catch (Exception ex)
    {
      GA.WriteUserLog(frmMain.langErrorTalkNPC, myAccount);
    }
  }

  public static void PartyNoAttack(AutoAccount myAccount, int mode = 0, string name = "")
  {
    if (myAccount.MyParty.PartyNumbers <= 0)
      return;
    if (myAccount.MyParty.AllMembers[0].DatabaseID != myAccount.Myself.DatabaseID)
      return;
    try
    {
      for (int index1 = 1; index1 <= myAccount.MyParty.PartyNumbers; ++index1)
      {
        PartyMember allMember = myAccount.MyParty.AllMembers[index1];
        if (allMember.DatabaseID != myAccount.Myself.DatabaseID)
        {
          AutoAccount autoAccount = (AutoAccount) null;
          for (int index2 = frmLogin.GAuto.AllAutoAccounts.Count - 1; index2 >= 0; --index2)
          {
            AutoAccount allAutoAccount = frmLogin.GAuto.AllAutoAccounts[index2];
            if (allAutoAccount.Myself.DatabaseID == allMember.DatabaseID)
            {
              autoAccount = allAutoAccount;
              break;
            }
          }
          if (autoAccount != null)
          {
            if (mode == 0)
            {
              autoAccount.MyQuai.noAttackArray.Clear();
            }
            else
            {
              bool flag = false;
              if (autoAccount.MyQuai.noAttackArray.Count > 0)
              {
                for (int index3 = 0; index3 < autoAccount.MyQuai.noAttackArray.Count; ++index3)
                {
                  string noAttack = autoAccount.MyQuai.noAttackArray[index3];
                  if (name == noAttack)
                    flag = true;
                }
              }
              if (!flag)
                autoAccount.MyQuai.noAttackArray.Add(name);
            }
          }
        }
      }
    }
    catch (Exception ex)
    {
      if (!GA.isVipMember())
        return;
      GA.WriteUserLog(frmMain.langErrorAddingPT, myAccount);
    }
  }

  public static void SetCallingParty(AutoAccount memberAccount, AutoAccount myAccount)
  {
    if (memberAccount == null || myAccount == null)
      return;
    if (memberAccount.Myself.HorseType == -1)
      memberAccount.CallMounting();
    memberAccount.IsAIEnabled = true;
    memberAccount.Myself.TargetX = myAccount.Myself.PosX;
    memberAccount.Myself.TargetY = myAccount.Myself.PosY;
    memberAccount.Myself.TargetMapID = myAccount.Myself.MapID;
    memberAccount.Settings.SavedPosX = myAccount.Myself.PosX;
    memberAccount.Settings.SavedPosY = myAccount.Myself.PosY;
    memberAccount.Settings.SavedMapID = myAccount.Myself.MapID;
    memberAccount.Myself.MoveFlashPos = true;
    if (memberAccount.Settings.MapID != myAccount.Myself.MapID)
      memberAccount.Settings.MapID = myAccount.Myself.MapID;
    if (memberAccount.Settings.CenterX != myAccount.Settings.CenterX)
      memberAccount.Settings.CenterX = myAccount.Settings.CenterX;
    if (memberAccount.Settings.CenterY != myAccount.Settings.CenterY)
      memberAccount.Settings.CenterY = myAccount.Settings.CenterY;
    memberAccount.Myself.LongMoveMapID = myAccount.Myself.MapID;
    memberAccount.Myself.LongMoveX = (int) myAccount.Myself.PosX;
    memberAccount.Myself.LongMoveY = (int) myAccount.Myself.PosY;
    memberAccount.Myself.MoveLongTrigger = true;
    memberAccount.Myself.MinorStatus2 = AllEnums.CharStatuses.TRIEUTAP;
  }

  public static double CalculateDistance(double fromX, double fromY, double ToX, double ToY)
  {
    return Math.Sqrt((fromX - ToX) * (fromX - ToX) + (fromY - ToY) * (fromY - ToY));
  }

  public static bool IsInPhuBan(int mapID, AutoAccount myAccount = null)
  {
    string mapName = GA.GetMapName(mapID);
    if (mapName.Contains("ôi đài") || mapName == "Arena" || mapID >= 36 && mapID <= 138 && mapID != 39 && mapID != 123 && mapID != 126 || mapID >= 152 && mapID <= 155 || mapID >= 182 && mapID <= 194 && mapID != 186 && mapID != 188 || mapID >= 196 && mapID <= 199 || mapID >= 313 && mapID <= 399 || mapID >= 403 && mapID <= 419 && mapID != 415)
      return true;
    if (myAccount != null)
    {
      if (myAccount.Target.VersionNum == 3 && (mapID == 195 || mapID == 441))
        return true;
      if (GA.CheckGameVersion(myAccount.Target.VersionNum) == 356 && GA.isInChienMinh(mapID))
        return false;
    }
    if (mapID >= 446 && mapID <= 464)
      return true;
    if (mapID >= 519 && mapID <= 522 || mapID >= 496 && mapID <= 498 || mapID == 517)
      return false;
    if (mapID >= 481 && mapID <= 596)
      return true;
    return mapID >= 705 && mapID <= 1668;
  }

  public static bool isInCity(int mapID)
  {
    return mapID == 0 || mapID == 1 || mapID == 2 || mapID == 186 || mapID == 480 || mapID == 181;
  }

  public static bool isVipMember()
  {
    string username = frmLogin.GAuto.Settings.Account.Username;
    return username == "gauto.support" || username == "testauto1" || username == "testauto2" || frmLogin.GAuto.Settings.IsSupportMode;
  }

  public static bool IsCTVMember()
  {
    string username = frmLogin.GAuto.Settings.Account.Username;
    if (frmLogin.CTVList.Count == 0)
      frmMain.GetGLoginServers();
    return frmLogin.CTVList.Count > 0 && frmLogin.CTVList.Contains(username);
  }

  public static string GenSignature(string key, string salt)
  {
    return GA.HWID.MD5(salt + key).ToLower().Substring(0, 10);
  }

  public static bool isShitMember() => frmLogin.GAuto.Settings.Account.Username == "taitieudat";

  public static Image LoadImage(string strURL, CookieContainer cookie, ref bool loadOK)
  {
    loadOK = false;
    Image image = (Image) null;
    HttpWebRequest httpWebRequest = (HttpWebRequest) WebRequest.Create(strURL);
    httpWebRequest.Method = "GET";
    httpWebRequest.CookieContainer = cookie;
    httpWebRequest.KeepAlive = true;
    httpWebRequest.ContentType = "image/png";
    httpWebRequest.Timeout = 30000;
    httpWebRequest.Proxy = (IWebProxy) null;
    if (frmLogin.myProxy != null)
      httpWebRequest.Proxy = (IWebProxy) frmLogin.myProxy;
    httpWebRequest.Referer = "zheshigauto";
    try
    {
      Stream responseStream = httpWebRequest.GetResponse().GetResponseStream();
      responseStream.ReadTimeout = 20000;
      image = Image.FromStream(responseStream);
      loadOK = true;
    }
    catch (Exception ex)
    {
      loadOK = false;
    }
    return image;
  }

  public static string LoadWebNoAlive(
    string strURL,
    string data,
    string method,
    CookieContainer cookie,
    bool toretry = true)
  {
    long num1 = frmLogin.GlobalTimer.ElapsedMilliseconds + frmLogin.GAuto.Settings.httpRetriesMax;
    int num2 = 0;
    while (true)
    {
      if (!strURL.StartsWith("http://"))
        strURL = "http://" + strURL;
      HttpWebRequest httpWebRequest = (HttpWebRequest) WebRequest.Create(strURL);
      httpWebRequest.Method = method.ToUpper();
      httpWebRequest.CookieContainer = cookie;
      httpWebRequest.Timeout = 30000;
      httpWebRequest.Proxy = (IWebProxy) null;
      if (num2 >= 2)
        GA.StartUsingProxy();
      if (frmLogin.myProxy != null)
        httpWebRequest.Proxy = (IWebProxy) frmLogin.myProxy;
      httpWebRequest.ServicePoint.Expect100Continue = false;
      httpWebRequest.ContentType = "application/x-www-form-urlencoded";
      httpWebRequest.KeepAlive = false;
      httpWebRequest.Referer = "zheshigauto";
      bool flag1 = true;
      if (httpWebRequest.Method == "POST")
      {
        byte[] bytes = Encoding.ASCII.GetBytes(data);
        httpWebRequest.ContentLength = (long) bytes.Length;
        try
        {
          Stream requestStream = httpWebRequest.GetRequestStream();
          requestStream.ReadTimeout = 30000;
          requestStream.WriteTimeout = 30000;
          requestStream.Write(bytes, 0, bytes.Length);
          requestStream.Close();
        }
        catch (Exception ex)
        {
          ++num2;
          if (toretry)
          {
            bool flag2 = false;
            if (frmLogin.GlobalTimer.ElapsedMilliseconds > num1)
              flag2 = true;
            bool flag3 = false;
            if (num2 > frmLogin.GAuto.Settings.httpRetries)
              flag3 = true;
            if (!flag3)
            {
              Thread.Sleep(frmLogin.GAuto.Settings.httpRetriesDelay);
              continue;
            }
            if (!flag2)
            {
              Thread.Sleep(frmLogin.GAuto.Settings.httpRetriesDelay);
              continue;
            }
          }
          return $"{frmLogin.GAuto.Settings.LoadWebErrorMessage}: {ex.Message}";
        }
        if (bytes.Length == 0)
          flag1 = false;
      }
      else
        flag1 = true;
      if (flag1)
      {
        try
        {
          Stream responseStream = httpWebRequest.GetResponse().GetResponseStream();
          responseStream.ReadTimeout = 10000;
          responseStream.WriteTimeout = 10000;
          return new StreamReader(responseStream).ReadToEnd();
        }
        catch (Exception ex)
        {
          ++num2;
          if (toretry)
          {
            bool flag4 = false;
            if (frmLogin.GlobalTimer.ElapsedMilliseconds > num1)
              flag4 = true;
            bool flag5 = false;
            if (num2 > frmLogin.GAuto.Settings.httpRetries)
              flag5 = true;
            if (!flag5)
            {
              Thread.Sleep(frmLogin.GAuto.Settings.httpRetriesDelay);
              continue;
            }
            if (!flag4)
            {
              Thread.Sleep(frmLogin.GAuto.Settings.httpRetriesDelay);
              continue;
            }
          }
          return $"{frmLogin.GAuto.Settings.LoadWebErrorMessage}: {ex.Message}";
        }
      }
      else
        break;
    }
    return frmLogin.GAuto.Settings.LoadWebErrorMessage;
  }

  public static string LoadWeb(
    string strURL,
    string data,
    string method,
    CookieContainer cookie,
    bool toretry = true)
  {
    long num1 = frmLogin.GlobalTimer.ElapsedMilliseconds + frmLogin.GAuto.Settings.httpRetriesMax;
    int num2 = 0;
    while (true)
    {
      if (!strURL.StartsWith("http://") && !strURL.StartsWith("https://"))
        strURL = "http://" + strURL;
      HttpWebRequest httpWebRequest = (HttpWebRequest) WebRequest.Create(strURL);
      httpWebRequest.Method = method.ToUpper();
      httpWebRequest.CookieContainer = cookie;
      httpWebRequest.Timeout = 30000;
      httpWebRequest.Proxy = (IWebProxy) null;
      if (num2 >= 2)
        GA.StartUsingProxy();
      if (frmLogin.myProxy != null)
        httpWebRequest.Proxy = (IWebProxy) frmLogin.myProxy;
      httpWebRequest.ServicePoint.Expect100Continue = false;
      httpWebRequest.ContentType = "application/x-www-form-urlencoded";
      httpWebRequest.KeepAlive = true;
      httpWebRequest.Referer = "zheshigauto";
      bool flag1 = true;
      if (httpWebRequest.Method == "POST")
      {
        byte[] bytes = Encoding.ASCII.GetBytes(data);
        httpWebRequest.ContentLength = (long) bytes.Length;
        try
        {
          Stream requestStream = httpWebRequest.GetRequestStream();
          requestStream.WriteTimeout = 30000;
          requestStream.ReadTimeout = 30000;
          requestStream.Write(bytes, 0, bytes.Length);
          requestStream.Close();
        }
        catch (Exception ex)
        {
          ++num2;
          if (toretry)
          {
            bool flag2 = false;
            if (frmLogin.GlobalTimer.ElapsedMilliseconds > num1)
              flag2 = true;
            bool flag3 = false;
            if (num2 > frmLogin.GAuto.Settings.httpRetries)
              flag3 = true;
            if (!flag3)
            {
              Thread.Sleep(frmLogin.GAuto.Settings.httpRetriesDelay);
              continue;
            }
            if (!flag2)
            {
              Thread.Sleep(frmLogin.GAuto.Settings.httpRetriesDelay);
              continue;
            }
          }
          return $"{frmLogin.GAuto.Settings.LoadWebErrorMessage}: {ex.Message}";
        }
        if (bytes.Length == 0)
          flag1 = false;
      }
      else
        flag1 = true;
      if (flag1)
      {
        try
        {
          Stream responseStream = httpWebRequest.GetResponse().GetResponseStream();
          responseStream.ReadTimeout = 30000;
          responseStream.WriteTimeout = 30000;
          return new StreamReader(responseStream).ReadToEnd();
        }
        catch (Exception ex)
        {
          ++num2;
          if (toretry)
          {
            bool flag4 = false;
            if (frmLogin.GlobalTimer.ElapsedMilliseconds > num1)
              flag4 = true;
            bool flag5 = false;
            if (num2 > frmLogin.GAuto.Settings.httpRetries)
              flag5 = true;
            if (!flag5)
            {
              Thread.Sleep(frmLogin.GAuto.Settings.httpRetriesDelay);
              continue;
            }
            if (!flag4)
            {
              Thread.Sleep(frmLogin.GAuto.Settings.httpRetriesDelay);
              continue;
            }
          }
          GA.WriteUserLog($"{frmMain.langCannotLoadWeb}: {ex.Message.Replace("prx.gameauto.net", "gameauto.net")}");
          return $"{frmLogin.GAuto.Settings.LoadWebErrorMessage}: {ex.Message}";
        }
      }
      else
        break;
    }
    return frmLogin.GAuto.Settings.LoadWebErrorMessage;
  }

  public static CookieCollection GetAllCookies(CookieContainer c)
  {
    CookieCollection allCookies = new CookieCollection();
    foreach (DictionaryEntry dictionaryEntry1 in (Hashtable) c.GetType().GetField("m_domainTable", BindingFlags.Instance | BindingFlags.NonPublic).GetValue((object) c))
    {
      foreach (DictionaryEntry dictionaryEntry2 in (SortedList) dictionaryEntry1.Value.GetType().GetField("m_list", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(dictionaryEntry1.Value))
      {
        foreach (Cookie cookie in (CookieCollection) dictionaryEntry2.Value)
          allCookies.Add(cookie);
      }
    }
    return allCookies;
  }

  public static void StartUsingProxy()
  {
    string Host = "202.43.110.72";
    try
    {
      IPHostEntry hostEntry = Dns.GetHostEntry(frmLogin.GAuto.Settings.ProxyURL);
      if (hostEntry.AddressList.Length > 0)
        Host = hostEntry.AddressList[0].ToString();
    }
    catch (Exception ex)
    {
    }
    if (frmLogin.myProxy != null || !(frmLogin.GAuto.Settings.ProxyURL != ""))
      return;
    if (!Monitor.TryEnter(frmLogin.proxyLock, 200))
      return;
    try
    {
      frmLogin.myProxy = new WebProxy(Host, 7777);
      frmLogin.myProxyStamp = frmLogin.GlobalTimer.ElapsedMilliseconds + 3600000L;
    }
    catch (Exception ex)
    {
    }
    finally
    {
      Monitor.Exit(frmLogin.proxyLock);
    }
  }

  private static void DoWithResponse(HttpWebRequest request, Action<HttpWebResponse> responseAction)
  {
  }

  private static void FinishLoadWeb(IAsyncResult ar)
  {
  }

  public static void GetItemNameTypeFromID(int itemID, out string itemName, out string itemType)
  {
    itemName = "";
    itemType = "";
    foreach (ItemDBElement itemDb in frmLogin.GAuto.ItemDBs)
    {
      if (itemDb.ItemID == itemID)
      {
        itemName = itemDb.ItemName.ToLower();
        itemType = itemDb.ItemType.ToLower();
        break;
      }
    }
  }

  public static MapDBElement GetMapElement(int mapID)
  {
    if (mapID >= 0)
    {
      foreach (MapDBElement mapDb in frmLogin.GAuto.MapDBs)
      {
        if (mapDb.MapID == mapID)
          return mapDb;
      }
    }
    return (MapDBElement) null;
  }

  public static bool IsBangMapID(int mapID)
  {
    bool flag = false;
    if (mapID >= 205 && mapID <= 312)
      flag = true;
    if (!flag && mapID >= 597 && mapID <= 704)
      flag = true;
    return flag;
  }

  public static string GetMapName(int mapID)
  {
    if (mapID >= 0)
    {
      foreach (MapDBElement mapDb in frmLogin.GAuto.MapDBs)
      {
        if (mapDb.MapID == mapID)
          return mapDb.MapName;
      }
    }
    return "";
  }

  internal static void GetItemSpread(TNNPCShopItem shopItem, int myBangID, int friendBangID)
  {
    if (myBangID == -1 || friendBangID == -1 || shopItem == null || !System.IO.File.Exists(frmLogin.GAuto.Settings.SettingDB))
      return;
    SQLiteConnection connection = new SQLiteConnection("Data Source=" + frmLogin.GAuto.Settings.SettingDB);
    connection.Open();
    if (connection.State != ConnectionState.Open)
      return;
    if (GADB.CheckAndCreateTable(frmLogin.GAuto.Settings.TNTable))
    {
      SQLiteDataReader reader = new SQLiteCommand($"SELECT * FROM tnprices2 WHERE itemid = '{shopItem.ItemID}' AND bangid = '{myBangID}' AND friendid = {friendBangID};", connection).ExecuteReader();
      DataTable dataTable = new DataTable();
      dataTable.Load((IDataReader) reader);
      if (dataTable.Rows.Count > 0)
      {
        DataRow row = dataTable.Rows[0];
        shopItem.HistSpread = !string.IsNullOrEmpty(row["spread"].ToString()) ? double.Parse(row["spread"].ToString()) : 0.0;
        shopItem.MidPrice = !string.IsNullOrEmpty(row["midprice"].ToString()) ? double.Parse(row["midprice"].ToString()) : 0.0;
        shopItem.HighPrice = !string.IsNullOrEmpty(row["highprice"].ToString()) ? double.Parse(row["highprice"].ToString()) : 0.0;
        shopItem.LowPrice = !string.IsNullOrEmpty(row["lowprice"].ToString()) ? double.Parse(row["lowprice"].ToString()) : 0.0;
        shopItem.FromBangID = myBangID;
        shopItem.ToBangID = friendBangID;
      }
      else
      {
        shopItem.HistSpread = 0.0;
        shopItem.MidPrice = 0.0;
        shopItem.HighPrice = 0.0;
        shopItem.LowPrice = 0.0;
        shopItem.FromBangID = myBangID;
        shopItem.ToBangID = friendBangID;
      }
    }
    connection.Close();
  }

  internal static void GetItemSpread(InventoryItem invenItem, int p1, int p2)
  {
    if (invenItem.ItemID < 0 || p1 == -1 || p2 == -1)
      return;
    TNNPCShopItem shopItem = new TNNPCShopItem();
    shopItem.ItemID = invenItem.ItemID;
    GA.GetItemSpread(shopItem, p1, p2);
    if (shopItem.MidPrice == 0.0)
      return;
    invenItem.MidSpread = shopItem.MidPrice;
    invenItem.HighSpread = shopItem.HistSpread;
    invenItem.HighSpread = shopItem.HighPrice;
    invenItem.LowSpread = shopItem.LowPrice;
    invenItem.HasHistory = true;
  }

  internal static void UpdateTNItem(
    int itemID,
    int fromBangID,
    int toBangID,
    double midSpread,
    double highSpread,
    double lowSpread,
    double highSpread2)
  {
    if (fromBangID == -1 || toBangID == -1 || !System.IO.File.Exists(frmLogin.GAuto.Settings.SettingDB))
      return;
    SQLiteConnection connection = new SQLiteConnection("Data Source=" + frmLogin.GAuto.Settings.SettingDB);
    connection.Open();
    if (connection.State != ConnectionState.Open)
      return;
    SQLiteCommand sqLiteCommand;
    if (new SQLiteCommand($"SELECT itemid FROM tnprices2 WHERE itemid = '{itemID}' AND bangid = '{fromBangID}' AND friendid = '{toBangID}';", connection).ExecuteScalar() == null)
      sqLiteCommand = new SQLiteCommand($"INSERT INTO tnprices2 ('bangid', 'friendid', 'spread', 'itemid', 'mytype', 'midprice', 'lowprice', 'highprice' ) VALUES ('{fromBangID}', '{toBangID}', '{highSpread.ToString("0.00")}', '{itemID}', '{1}', '{midSpread.ToString("0.00")}', '{lowSpread.ToString("0.00")}', '{highSpread2.ToString("0.00")}');", connection);
    else
      sqLiteCommand = new SQLiteCommand($"UPDATE tnprices2 SET spread = '{highSpread.ToString("0.00")}', midprice = '{midSpread.ToString("0.00")}' WHERE itemid = '{itemID}' AND bangid = '{fromBangID}' AND friendid = '{toBangID}'", connection);
    sqLiteCommand.ExecuteNonQuery();
    connection.Close();
  }

  internal static string ConvertToVISCII(string myString, int versionNum = 1)
  {
    if (!(frmLogin.CompilingLanguage == "VN") || versionNum >= 5)
      return myString;
    StringBuilder stringBuilder = new StringBuilder(myString);
    if (GA.VISCII.Count == 0)
      GA.BuildVISCIIDictionary();
    for (int index = 0; index < stringBuilder.Length; ++index)
    {
      char ch = stringBuilder[index];
      if (GA.VISCII.ContainsValue(ch))
      {
        foreach (KeyValuePair<int, char> keyValuePair in GA.VISCII)
        {
          if ((int) keyValuePair.Value == (int) ch)
          {
            stringBuilder[index] = (char) keyValuePair.Key;
            break;
          }
        }
      }
    }
    return stringBuilder.ToString();
  }

  internal static byte[] CheckVISCII(string message, int versionNum)
  {
    if ((frmLogin.CompilingLanguage == "VN" || frmLogin.CompilingLanguage == "EN") && versionNum <= 4)
    {
      byte[] bytes = Encoding.ASCII.GetBytes(message);
      StringBuilder stringBuilder = new StringBuilder(message);
      if (GA.VISCII.Count == 0)
        GA.BuildVISCIIDictionary();
      for (int index = 0; index < stringBuilder.Length; ++index)
      {
        byte key = (byte) stringBuilder[index];
        if (GA.VISCII.ContainsKey((int) key))
        {
          foreach (KeyValuePair<int, char> keyValuePair in GA.VISCII)
          {
            if (keyValuePair.Key == (int) key)
            {
              bytes[index] = (byte) keyValuePair.Key;
              break;
            }
          }
        }
      }
      return bytes;
    }
    return frmLogin.CompilingLanguage == "CN" || versionNum >= 5 ? Encoding.GetEncoding("gb2312").GetBytes(message) : new byte[1];
  }

  public static string GB2312ToUtf8(string gb2312String)
  {
    Encoding encoding = Encoding.GetEncoding("gb2312");
    Encoding utF8 = Encoding.UTF8;
    return GA.EncodingConvert(gb2312String, encoding, utF8);
  }

  public static string Utf8ToGB2312(string utf8String)
  {
    Encoding utF8 = Encoding.UTF8;
    Encoding encoding = Encoding.GetEncoding("gb2312");
    return GA.EncodingConvert(utf8String, utF8, encoding);
  }

  public static string EncodingConvert(
    string fromString,
    Encoding fromEncoding,
    Encoding toEncoding)
  {
    byte[] bytes1 = fromEncoding.GetBytes(fromString);
    byte[] bytes2 = Encoding.Convert(fromEncoding, toEncoding, bytes1);
    return toEncoding.GetString(bytes2);
  }

  internal static string ConvertToUnicode(byte[] tempArr, int start, int count)
  {
    string unicode = Encoding.UTF7.GetString(tempArr, start, count);
    if (frmLogin.CompilingLanguage == "CN")
      unicode = Encoding.GetEncoding("gb2312").GetString(tempArr).Replace("\0", "");
    if (frmLogin.CompilingLanguage == "VN")
    {
      StringBuilder stringBuilder = new StringBuilder(unicode);
      if (GA.VISCII.Count == 0 && frmLogin.CompilingLanguage == "VN")
        GA.BuildVISCIIDictionary();
      for (int index = 0; index < stringBuilder.Length; ++index)
      {
        byte key = (byte) stringBuilder[index];
        if (GA.VISCII.ContainsKey((int) key))
          stringBuilder[index] = GA.VISCII[(int) key];
      }
      unicode = stringBuilder.ToString();
    }
    return unicode;
  }

  internal static int GetMapIDMini(string mapName)
  {
    foreach (MapDBElement mapDb in frmLogin.GAuto.MapDBs)
    {
      if (mapDb.MapName == mapName)
        return mapDb.MapID;
    }
    return -1;
  }

  internal static int GetItemIDFromName(string itemName)
  {
    foreach (TNItemDBElement tnItemDbElement in frmLogin.GAuto.TNItemsDB)
    {
      if (string.Compare(tnItemDbElement.Name, itemName, true) == 0)
        return tnItemDbElement.ItemID;
    }
    return 0;
  }

  internal static string GetTNItemFromID(int itemID)
  {
    string tnItemFromId = frmMain.langNotSure;
    foreach (TNItemDBElement tnItemDbElement in frmLogin.GAuto.TNItemsDB)
    {
      if (tnItemDbElement.ItemID == itemID)
      {
        tnItemFromId = tnItemDbElement.Name;
        break;
      }
    }
    return tnItemFromId;
  }

  internal static void GetBasicSkill(AutoAccount account)
  {
    if (account.MySkills == null || account.Myself == null)
      return;
    if (account.MySkills.AllSkills[1].ID == 0)
      account.MySkills.AllSkills[0].ID = 0;
    else if (account.Myself.Menpai == AllEnums.Menpais.CAIBANG)
      account.MySkills.AllSkills[0].ID = 341;
    else if (account.Myself.Menpai == AllEnums.Menpais.DUONGMON)
      account.MySkills.AllSkills[0].ID = 2900;
    else if (account.Myself.Menpai == AllEnums.Menpais.THIEULAM)
      account.MySkills.AllSkills[0].ID = 281;
    else if (account.Myself.Menpai == AllEnums.Menpais.MINHGIAO)
      account.MySkills.AllSkills[0].ID = 311;
    else if (account.Myself.Menpai == AllEnums.Menpais.VODANG)
      account.MySkills.AllSkills[0].ID = 371;
    else if (account.Myself.Menpai == AllEnums.Menpais.NGAMI)
      account.MySkills.AllSkills[0].ID = 401;
    else if (account.Myself.Menpai == AllEnums.Menpais.TINHTUC)
      account.MySkills.AllSkills[0].ID = 431;
    else if (account.Myself.Menpai == AllEnums.Menpais.THIENLONG)
      account.MySkills.AllSkills[0].ID = 461;
    else if (account.Myself.Menpai == AllEnums.Menpais.THIENSON)
      account.MySkills.AllSkills[0].ID = 491;
    else if (account.Myself.Menpai == AllEnums.Menpais.TIEUDAO)
      account.MySkills.AllSkills[0].ID = 521;
    else if (account.Myself.Menpai == AllEnums.Menpais.MODUNG)
      account.MySkills.AllSkills[0].ID = 760;
    else if (account.Myself.Menpai == AllEnums.Menpais.QUYCOC)
      account.MySkills.AllSkills[0].ID = 1850;
    else
      account.MySkills.AllSkills[0].ID = 0;
  }

  public static int ClientVersion(AutoAccount account)
  {
    int num = -1;
    if (account != null && (account.Target.VersionNum == 4 || account.Target.SubVersion == 9 || account.Target.SubVersion == 11 || account.Target.SubVersion == 15 || account.Target.SubVersion == 16 /*0x10*/ || account.Target.SubVersion == 18 || account.Settings.cboxFixKetThanh))
      num = 10;
    return num;
  }

  public static double DayBalance()
  {
    return frmLogin.GAuto.Settings.Account.RemainMSeconds / 1000.0 / 60.0 / 60.0 / 24.0;
  }

  public static bool isInChienMinh(int mapID) => 574 <= mapID && mapID <= 578;

  public enum LoginCode
  {
    LOGIN_EXPIRES = -2, // 0xFFFFFFFE
    LOGIN_USERNAME_PASSWORD_ERROR = -1, // 0xFFFFFFFF
    LOGIN_OK = 1,
  }

  public class Converter
  {
  }

  public class HWID
  {
    public string Value
    {
      get
      {
        bool flag1 = false;
        bool flag2;
        try
        {
          return GA.HWID.MD5($"{GA.HWID.BiosID()}{GA.HWID.VideoID()}MD5");
        }
        catch (Exception ex)
        {
          flag2 = true;
        }
        if (flag2)
        {
          flag1 = false;
          try
          {
            string rootPathName = Environment.GetFolderPath(Environment.SpecialFolder.System);
            if (rootPathName.Length > 3)
              rootPathName = rootPathName.Substring(0, 3);
            if (rootPathName == "")
              rootPathName = "C:\\";
            StringBuilder volumeNameBuffer = new StringBuilder(261);
            StringBuilder fileSystemNameBuffer = new StringBuilder(261);
            uint volumeSerialNumber;
            if (!MyDLL.GetVolumeInformation(rootPathName, volumeNameBuffer, volumeNameBuffer.Capacity, out volumeSerialNumber, out uint _, out MyDLL.FileSystemFeature _, fileSystemNameBuffer, fileSystemNameBuffer.Capacity))
              Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
            return GA.HWID.MD5($"{(object) volumeSerialNumber}{Environment.MachineName}BG-GB");
          }
          catch (Exception ex)
          {
            flag1 = true;
          }
        }
        return GA.HWID.MD5(Environment.MachineName + "BG-GB");
      }
    }

    public static string MD5(string data)
    {
      return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(new UTF8Encoding().GetBytes(data))).Replace("-", "").ToUpper();
    }

    public static string Identifier(string wmiClass, string wmiProperty, string wmiMustBeTrue)
    {
      string str = "";
      foreach (ManagementObject instance in new ManagementClass(wmiClass).GetInstances())
      {
        if (instance[wmiMustBeTrue].ToString() == "True")
        {
          if (str == string.Empty)
          {
            try
            {
              str = instance[wmiProperty].ToString();
              break;
            }
            catch (Exception ex)
            {
            }
          }
        }
      }
      return str;
    }

    public static string Identifier(string wmiClass, string wmiProperty)
    {
      string str = "";
      foreach (ManagementObject instance in new ManagementClass(wmiClass).GetInstances())
      {
        if (str == string.Empty)
        {
          try
          {
            str = instance[wmiProperty].ToString();
            break;
          }
          catch (Exception ex)
          {
          }
        }
      }
      return str;
    }

    private static string CpuID()
    {
      string str1 = GA.HWID.Identifier("Win32_Processor", "UniqueId");
      if (str1 == string.Empty)
      {
        str1 = GA.HWID.Identifier("Win32_Processor", "ProcessorId");
        if (str1 == string.Empty)
        {
          string str2 = GA.HWID.Identifier("Win32_Processor", "Name");
          if (str2 == string.Empty)
            str2 = GA.HWID.Identifier("Win32_Processor", "Manufacturer");
          str1 = str2 + GA.HWID.Identifier("Win32_Processor", "MaxClockSpeed");
        }
      }
      return str1;
    }

    private static string BiosID()
    {
      return GA.HWID.Identifier("Win32_BIOS", "Manufacturer") + GA.HWID.Identifier("Win32_BIOS", "SMBIOSBIOSVersion") + GA.HWID.Identifier("Win32_BIOS", "IdentificationCode") + GA.HWID.Identifier("Win32_BIOS", "SerialNumber") + GA.HWID.Identifier("Win32_BIOS", "ReleaseDate") + GA.HWID.Identifier("Win32_BIOS", "Version");
    }

    private static string DiskID()
    {
      return GA.HWID.Identifier("Win32_DiskDrive", "Model") + GA.HWID.Identifier("Win32_DiskDrive", "Manufacturer") + GA.HWID.Identifier("Win32_DiskDrive", "Signature") + GA.HWID.Identifier("Win32_DiskDrive", "TotalHeads");
    }

    private static string BaseID()
    {
      return GA.HWID.Identifier("Win32_BaseBoard", "Model") + GA.HWID.Identifier("Win32_BaseBoard", "Manufacturer") + GA.HWID.Identifier("Win32_BaseBoard", "Name") + GA.HWID.Identifier("Win32_BaseBoard", "SerialNumber");
    }

    private static string VideoID()
    {
      return GA.HWID.Identifier("Win32_VideoController", "DriverVersion") + GA.HWID.Identifier("Win32_VideoController", "Name");
    }

    private static string MacID()
    {
      return GA.HWID.Identifier("Win32_NetworkAdapterConfiguration", "MACAddress", "IPEnabled");
    }
  }
}
