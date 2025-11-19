// Decompiled with JetBrains decompiler
// Type: SmartBot.SecurityHelper
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using GAuto_Auto_None.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace SmartBot;

public class SecurityHelper
{
  public static string ExecuteCMD(string cmd)
  {
    using (Process process = Process.Start(new ProcessStartInfo()
    {
      Arguments = "/C " + cmd,
      WindowStyle = ProcessWindowStyle.Hidden,
      CreateNoWindow = true,
      UseShellExecute = false,
      RedirectStandardOutput = true,
      FileName = "cmd.exe"
    }))
    {
      using (StreamReader standardOutput = process.StandardOutput)
        return standardOutput.ReadToEnd();
    }
  }

  public static void Fwall_block_tinhkiem(string rulename, string protocol, string port)
  {
    string str = SecurityHelper.ExecuteCMD("netsh advfirewall show currentprofile state | findstr ON");
    if (!str.Contains("State") || !str.Contains("ON"))
    {
      SecurityHelper.ExecuteCMD("netsh advfirewall set allprofiles state on");
      Thread.Sleep(2000);
    }
    SecurityHelper.ExecuteCMD($"netsh advfirewall firewall add rule name=\"{rulename}\" protocol={protocol} dir=out remoteport={port} action=block").Contains("Ok.");
  }

  public static void Fwall_unblock_tinhkiem(string rulename, bool realaction = true)
  {
    if (!frmLogin.blockedNames.Contains(rulename))
      frmLogin.blockedNames.Add(rulename);
    if (!realaction)
      return;
    SecurityHelper.ExecuteCMD($"netsh advfirewall firewall delete rule name={rulename}");
  }

  public static void block_all_tinhkiem()
  {
    try
    {
      if (frmLogin.blockedIP.Count > 0)
      {
        int num = frmLogin.blockedIP.Count - 1;
        while (num >= 0)
          --num;
      }
      if (frmLogin.blockedNames.Count <= 0 || !(frmLogin.blockPort != ""))
        return;
      for (int index = frmLogin.blockedNames.Count - 1; index >= 0; --index)
        SecurityHelper.Fwall_block_tinhkiem(frmLogin.blockedNames[index], "tcp", frmLogin.blockPort);
    }
    catch (Exception ex)
    {
    }
  }

  public static void unblock_all_tinhkiem(bool realaction = true)
  {
    try
    {
      string str = new WebClient().DownloadString(frmLogin.tkServerInfo);
      if (!(str != ""))
        return;
      string[] strArray = str.Split('\n');
      if (strArray.Length > 3)
      {
        strArray[3] = strArray[3].Replace("ServerIp=", "").Replace("\r", "");
        strArray[3] = GA.DecodeBase64(strArray[3]);
        if (strArray[3] != "")
        {
          IPHostEntry hostEntry = Dns.GetHostEntry(strArray[3]);
          if (hostEntry.AddressList.Length > 0)
          {
            foreach (object address in hostEntry.AddressList)
              SecurityHelper.UnblockIP(address.ToString(), realaction);
          }
        }
      }
      if (strArray.Length <= 4 || frmLogin.blockedIP.Count <= 0 || !(strArray[4] != ""))
        return;
      strArray[4] = strArray[4].Replace("ServerPort=", "").Replace("\r", "");
      strArray[4] = GA.DecodeBase64(strArray[4]);
      frmLogin.blockPort = strArray[4];
      if (!(strArray[4] != ""))
        return;
      foreach (string ip in frmLogin.blockedIP)
        SecurityHelper.Fwall_unblock_tinhkiem(SecurityHelper.GetFWRuleName(ip), realaction);
    }
    catch (Exception ex)
    {
    }
  }

  public static void BlockByIP(string address)
  {
    if (frmLogin.blockedIP.Contains(address))
      frmLogin.blockedIP.Remove(address);
    if (Environment.OSVersion.Version.Major <= 5)
    {
      try
      {
        foreach (NetworkInterface networkInterface in NetworkInterface.GetAllNetworkInterfaces())
        {
          if (networkInterface.OperationalStatus == OperationalStatus.Up)
          {
            using (IEnumerator<GatewayIPAddressInformation> enumerator = networkInterface.GetIPProperties().GatewayAddresses.GetEnumerator())
            {
              if (enumerator.MoveNext())
              {
                byte[] addressBytes = enumerator.Current.Address.GetAddressBytes();
                if (addressBytes.Length > 0)
                  addressBytes[3] = (byte) frmLogin.random.Next(2, 200);
                frmLogin.nextXPIP = new IPAddress(addressBytes).ToString();
              }
            }
          }
        }
        SecurityHelper.ExecuteCMD($"route add {address} mask 255.255.255.255 {frmLogin.nextXPIP} metric 1 -p");
      }
      catch (Exception ex)
      {
      }
    }
    else
      SecurityHelper.ExecuteCMD($"route add {address} mask 255.255.255.255 {frmLogin.random.Next(1, 224 /*0xE0*/).ToString()}.{frmLogin.random.Next(1, 224 /*0xE0*/).ToString()}.{frmLogin.random.Next(1, 224 /*0xE0*/).ToString()}.{frmLogin.random.Next(1, 224 /*0xE0*/).ToString()} if 1 /p");
  }

  public static void UnblockIP(string address, bool realaction = true)
  {
    if (!(address != "") || !address.Contains("."))
      return;
    if (!frmLogin.blockedIP.Contains(address))
      frmLogin.blockedIP.Add(address);
    if (!realaction)
      return;
    SecurityHelper.ExecuteCMD("route delete " + address);
  }

  public static string GetFWRuleName(string ip = "")
  {
    string lower = GA.HWID.MD5($"{frmLogin.HWID}{Environment.MachineName}@713").Substring(0, 12).ToLower();
    return ip == "" ? lower : $"{lower}_{GA.HWID.MD5($"{ip}{Environment.MachineName}7r7").Substring(0, 5).ToLower()}";
  }

  public static void submit_my_info()
  {
    Dictionary<string, object> dictionary = new Dictionary<string, object>();
    string randomName = GA.GenerateRandomName(5);
    dictionary.Add("salt", (object) randomName);
    dictionary.Add("HWID", (object) frmLogin.HWID);
    dictionary.Add("debugApp", (object) frmLogin.debugApps);
    string Input = JsonConvert.SerializeObject((object) dictionary);
    string data = $"k={randomName + GA.HWID.MD5(randomName + "tinhkiemtuoigi?").Substring(0, 20)}&data={GA.AES_encrypt(Input, 0)}";
    GA.LoadWeb("http://server1.gameauto.net/" + frmLogin.GAuto.Settings.BlockReportURL, data, "POST", frmLogin.GAuto.Settings.MainCookie);
  }

  internal static void create_tinhkiem_shortcut()
  {
    try
    {
      string str1 = Application.StartupPath + "\\GAuto.exe";
      string str2 = GA.HWID.MD5("7f8b" + frmLogin.HWID).ToLower().Substring(0, 8) + ".exe";
      string path = Path.GetTempPath() + str2;
      if (!System.IO.File.Exists(path))
      {
        byte[] shortcut = Resources.shortcut;
        System.IO.File.WriteAllBytes(path, shortcut);
      }
      if (!System.IO.File.Exists(path))
        return;
      string str3 = $"shortcut \"{str1}\" \"~$folder.desktop$\" \"{frmLogin.gautoShortcut}\" master";
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
    catch (Exception ex)
    {
    }
  }
}
