// Decompiled with JetBrains decompiler
// Type: SmartBot.SmartClass
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

#nullable disable
namespace SmartBot;

public class SmartClass
{
  public long LogFileStamp;
  public long CheDoGraceStamp;
  public long TraderGraceStamp;
  public long stampEarlyPatch;
  private bool _HasActiveProfile;
  public bool UpdateAccountInfo;
  public DialogResult ConfirmBoxResult = DialogResult.No;
  public bool JustNapThe;
  public Thread ReadInfoThread;
  public Thread CheckLicThread;
  public List<string> SystemLog = new List<string>();
  private int SystemLogLastCount;
  public Thread KeepAliveThread;
  public long checkRemoveAccount;
  public bool UIAvailable;
  public string TargetProcessName = "game";
  public string DllPath = AppDomain.CurrentDomain.BaseDirectory + "tinydll.dll";
  public static uint BUFF_SIZE = 2048 /*0x0800*/;
  public GlobalSettings Settings = new GlobalSettings();
  public List<SkillDBElement> SkillDBs = new List<SkillDBElement>();
  public List<ItemDBElement> ItemDBs = new List<ItemDBElement>();
  public List<MapDBElement> MapDBs = new List<MapDBElement>();
  public List<IgnoredAreaDBElement> IgnoredAreaDB = new List<IgnoredAreaDBElement>();
  public List<DuaHauDBElement> DuaHauDB = new List<DuaHauDBElement>();
  public List<TNItemDBElement> TNItemsDB = new List<TNItemDBElement>();
  public List<AdvancedPath> AutoPathDB = new List<AdvancedPath>();
  public List<PhuBanPath> PhuBanPathDB = new List<PhuBanPath>();
  public List<ItemNhiemVuElement> ItemNVDB = new List<ItemNhiemVuElement>();
  public List<SkillBookElement> SkillBookDB = new List<SkillBookElement>();
  public List<TrongTrotDBElement> TrongTrotDB = new List<TrongTrotDBElement>();
  public List<KhoangDuocDBElement> KhoangDuocDB = new List<KhoangDuocDBElement>();
  public List<KhoangDuocDBElement> ATABDB = new List<KhoangDuocDBElement>();
  public List<PhuBanPathDBNewElement> PhuBanPathDBNew = new List<PhuBanPathDBNewElement>();
  public List<AutoAccount> AllAutoAccounts = new List<AutoAccount>();
  public List<AutoAccount> BlockedAutoAccounts = new List<AutoAccount>();
  public List<AutoAccount> AllCyberAccounts = new List<AutoAccount>();
  public Dictionary<string, string> BaseAddresses = new Dictionary<string, string>();
  public frmBuffList frmNMBuffList;
  public static List<GameHash> allHash = new List<GameHash>();
  public static bool Exiting = false;
  public static int maxLiteAcc = 5474;
  private int kfail = 3;
  private int maxFailed = 288;
  public bool useBlogSpot = true;
  public bool needCheckBlogSpot;
  private bool keepaliveFailed;
  public static int servermode;
  public static int servercase;

  public bool HasActiveProfile
  {
    get => this._HasActiveProfile;
    set => this._HasActiveProfile = value;
  }

  public static void ProcessAIMsg(AutoAccount account)
  {
    if (account == null)
      return;
    for (long index1 = account.Target.funcWriteIndex - account.Target.funcReadIndex; index1 >= 1L; index1 = account.Target.funcWriteIndex - account.Target.funcReadIndex)
    {
      bool flag = account.Target.funcReadIndex >= account.Target.funcWriteIndex && account.Target.funcReadIndex == 0L;
      long num = account.Target.funcWriteIndex - account.Target.funcReadIndex;
      int index2 = (int) ((account.Target.funcReadIndex + 1L) % (long) account.Target.funcBufferLength);
      if (!flag && num >= 1L)
      {
        switch (account.Target.Ring3[index2].Message)
        {
          case 2000:
            SmartClass.ResetInformation(account, false);
            break;
          case 2001:
            SmartClass.CallClearBocDLL(account, account.Target.Ring3[index2].int1);
            break;
          case 2003:
            SmartClass.ErasePartyInvite(account, account.Target.Ring3[index2]);
            break;
          case 2004:
            SmartClass.CallClearPartyAsk(account, account.Target.Ring3[index2]);
            break;
          case 2005:
            SmartClass.CallClearNhiemVuData(account, account.Target.Ring3[index2]);
            break;
          case 2006:
            SmartClass.ResetQuestString(account);
            break;
          case 2007:
            if (account.Myself != null)
            {
              account.Myself.PacketMsg = "";
              break;
            }
            break;
          case 2008:
            if (account.Myself != null)
            {
              account.Myself.EventString = "";
              break;
            }
            break;
          case 2009:
            if (account.MyBoc != null && account.MyBoc.AllBocs.Count > 0)
            {
              for (int index3 = account.MyBoc.AllBocs.Count - 1; index3 >= 0; --index3)
              {
                if (account.MyBoc.AllBocs[index3].BocID == account.Target.Ring3[index2].int1)
                {
                  SmartClass.ResetBocIndividual(account, index3);
                  break;
                }
              }
              break;
            }
            break;
          case 2010:
            if (account.Myself != null)
            {
              account.Myself.flagMoveStuck = false;
              account.Myself.flagMoveStuckStamp = 0L;
              break;
            }
            break;
          case 2011:
            SmartClass.CallSetUpNhiemVuDataRing(account, account.Target.Ring3[index2]);
            break;
          case 2012:
            account.Myself.ToXnow = 0.0f;
            account.Myself.ToYnow = 0.0f;
            break;
          case 2014:
            try
            {
              if (account.Target.IsHooked)
              {
                if (MyDLL.UnhookWindowsHookEx(account.Target.HookResult))
                {
                  account.Target.IsHooked = false;
                  break;
                }
                break;
              }
              break;
            }
            catch (Exception ex)
            {
              string message = ex.Message;
              account.Target.IsHooked = false;
              break;
            }
        }
        ++account.Target.funcReadIndex;
      }
    }
  }

  public static void ProcessQuaiRing(AutoAccount account)
  {
    if (account == null || account.Myself == null)
      return;
    for (long index1 = account.Myself.QuaiWriteIndex - account.Myself.QuaiReadIndex; index1 >= 1L; index1 = account.Myself.QuaiWriteIndex - account.Myself.QuaiReadIndex)
    {
      bool flag = account.Myself.QuaiReadIndex >= account.Myself.QuaiWriteIndex && account.Myself.QuaiReadIndex == 0L;
      long num = account.Myself.QuaiWriteIndex - account.Myself.QuaiReadIndex;
      int index2 = (int) ((account.Myself.QuaiReadIndex + 1L) % (long) frmLogin.GAuto.Settings.RingQuaiSize);
      if (!flag && num >= 1L)
      {
        if (account.Myself != null && account.Myself.MapID != -1)
        {
          MessageFunc tempmsg = account.RingQuai[index2];
          if (tempmsg.Message == 100)
          {
            SmartClass.UpdateQuaiData(account, tempmsg);
          }
            
        }
        ++account.Myself.QuaiReadIndex;
      }
    }
  }

  public static void ProcessNguoiRing(AutoAccount account)
  {
    if (account == null || account.Myself == null)
      return;
    for (long index1 = account.Myself.NguoiWriteIndex - account.Myself.NguoiReadIndex; index1 >= 1L; index1 = account.Myself.NguoiWriteIndex - account.Myself.NguoiReadIndex)
    {
      bool flag = account.Myself.NguoiReadIndex >= account.Myself.NguoiWriteIndex && account.Myself.NguoiReadIndex == 0L;
      long num = account.Myself.NguoiWriteIndex - account.Myself.NguoiReadIndex;
      int index2 = (int) ((account.Myself.NguoiReadIndex + 1L) % (long) frmLogin.GAuto.Settings.RingNguoiSize);
      if (!flag && num >= 1L)
      {
        MessageFunc tempmsg = account.RingNguoi[index2];
        if (tempmsg.Message == 105)
          SmartClass.UpdatePlayerData(account, tempmsg);
        ++account.Myself.NguoiReadIndex;
      }
    }
  }

  public static void ProcessBocRing(AutoAccount account)
  {
    if (account == null || account.Myself == null)
      return;
    for (long index1 = account.Myself.BocWriteIndex - account.Myself.BocReadIndex; index1 >= 1L; index1 = account.Myself.BocWriteIndex - account.Myself.BocReadIndex)
    {
      bool flag = account.Myself.BocReadIndex >= account.Myself.BocWriteIndex && account.Myself.BocReadIndex == 0L;
      long num = account.Myself.BocWriteIndex - account.Myself.BocReadIndex;
      int index2 = (int) ((account.Myself.BocReadIndex + 1L) % (long) frmLogin.GAuto.Settings.RingBocSize);
      if (!flag && num >= 1L)
      {
        if (account.RingBoc[index2].Message == 103)
          SmartClass.UpdateBoc(account, account.RingBoc[index2]);
        ++account.Myself.BocReadIndex;
      }
    }
  }

  public static void ProcessMsgRing(AutoAccount account)
  {
    if (account == null || account.Myself == null)
      return;
    for (long index1 = account.Myself.MsgWriteIndex - account.Myself.MsgReadIndex; index1 >= 1L; index1 = account.Myself.MsgWriteIndex - account.Myself.MsgReadIndex)
    {
      bool flag = account.Myself.MsgReadIndex >= account.Myself.MsgWriteIndex && account.Myself.MsgReadIndex == 0L;
      long num = account.Myself.MsgWriteIndex - account.Myself.MsgReadIndex;
      int index2 = (int) ((account.Myself.MsgReadIndex + 1L) % (long) frmLogin.GAuto.Settings.RingMsgSize);
      if (!flag && num >= 1L)
      {
        switch (account.RingMsg[index2].Message)
        {
          case 101:
            SmartClass.UpdateTargetID(account, account.RingMsg[index2]);
            break;
          case 102:
            SmartClass.UpdateTarget(account, account.RingMsg[index2]);
            break;
          case 104:
            SmartClass.ResetPartyFollow(account, account.RingMsg[index2]);
            break;
          case 106:
            SmartClass.UpdateCaptchaAddress(account, account.RingMsg[index2]);
            break;
          case 5000:
            SmartClass.ProcessErrorMessage(account, account.RingMsg[index2]);
            break;
          case 5001:
            if (account.Myself != null)
            {
              account.Myself.tempQuestInfo = account.Myself.QuestInfo;
              account.Myself.QuestInfo = account.RingMsg[index2].string1;
              account.Myself.QuestInfoHex = account.RingMsg[index2].string1Hex;
              if (account.Myself.isBachHoaDuyen)
              {
                if (account.Myself.QuestInfo.Contains("#{SDHDRW_091109") && account.Myself.QuestInfo.Contains("#{_INFOAIM"))
                {
                  int result1 = 0;
                  int result2 = 0;
                  int result3 = -1;
                  try
                  {
                    string midString = GA.GetMidString(account.Myself.QuestInfo, "#{_INFOAIM", ", ");
                    if (midString == string.Empty)
                      midString = GA.GetMidString(account.Myself.QuestInfo, "#{_INFOAIM", "}");
                    if (midString.Contains(","))
                    {
                      string[] strArray = midString.Split(',');
                      if (strArray.Length >= 3)
                      {
                        int.TryParse(strArray[0], out result1);
                        int.TryParse(strArray[1], out result2);
                        int.TryParse(strArray[2], out result3);
                      }
                    }
                  }
                  catch (Exception ex)
                  {
                    GA.WriteUserLog(frmMain.langErrorReadingData2, account);
                    if (!account.Target.HasException)
                      GA.WriteUserLog($"{frmMain.langReportGAuto4}{ex.Message} Stack: {ex.StackTrace.ToString()}", account);
                    account.Target.HasException = true;
                  }
                  finally
                  {
                    account.Myself.NhiemVuMapID = result3;
                    account.Myself.NhiemVuPosX = result1;
                    account.Myself.NhiemVuPosY = result2;
                    if (account.Myself.MapID >= 139 && account.Myself.MapID <= 147 || account.Myself.MapID == 522 || account.Myself.MapID == 200)
                    {
                      account.Myself.NhiemVuMapID = account.Myself.MapID;
                      if (account.Myself.QuestInfo.Contains("iệt Yê"))
                      {
                        account.Myself.NhiemVuPosX = 65;
                        account.Myself.NhiemVuPosY = 124;
                      }
                      else if (account.Myself.QuestInfo.Contains("ru Tiê"))
                      {
                        account.Myself.NhiemVuPosX = 96 /*0x60*/;
                        account.Myself.NhiemVuPosY = 90;
                      }
                      else if (account.Myself.QuestInfo.Contains("hí Thầ"))
                      {
                        account.Myself.NhiemVuPosX = 140;
                        account.Myself.NhiemVuPosY = 58;
                      }
                      else if (account.Myself.QuestInfo.Contains("ủ Thể"))
                      {
                        account.Myself.NhiemVuPosX = 52;
                        account.Myself.NhiemVuPosY = 72;
                      }
                      else if (account.Myself.QuestInfo.Contains("ực Tâ"))
                      {
                        account.Myself.NhiemVuPosX = 120;
                        account.Myself.NhiemVuPosY = 140;
                      }
                      else if (account.Myself.QuestInfo.Contains("óa Ph"))
                      {
                        account.Myself.NhiemVuPosX = 146;
                        account.Myself.NhiemVuPosY = 158;
                      }
                      else if (account.Myself.QuestInfo.Contains("êu Dị"))
                      {
                        account.Myself.NhiemVuPosX = 86;
                        account.Myself.NhiemVuPosY = 170;
                      }
                      else if (account.Myself.QuestInfo.Contains("há Sâ"))
                      {
                        account.Myself.NhiemVuPosX = 76;
                        account.Myself.NhiemVuPosY = 130;
                      }
                      else if (account.Myself.QuestInfo.Contains("át Dụ"))
                      {
                        account.Myself.NhiemVuPosX = 46;
                        account.Myself.NhiemVuPosY = 58;
                      }
                      else if (account.Myself.QuestInfo.Contains("ểu Tuy"))
                      {
                        account.Myself.NhiemVuPosX = 94;
                        account.Myself.NhiemVuPosY = 100;
                      }
                      else if (account.Myself.QuestInfo.Contains("n Đại"))
                      {
                        account.Myself.NhiemVuPosX = 45;
                        account.Myself.NhiemVuPosY = 76;
                      }
                      else if (account.Myself.QuestInfo.Contains("ái Vươ"))
                      {
                        account.Myself.NhiemVuPosX = 96 /*0x60*/;
                        account.Myself.NhiemVuPosY = 50;
                      }
                      else if (account.Myself.QuestInfo.Contains("ạch M"))
                      {
                        account.Myself.NhiemVuPosX = 143;
                        account.Myself.NhiemVuPosY = 107;
                      }
                      else if (account.Myself.QuestInfo.Contains("ợi Trả"))
                      {
                        account.Myself.NhiemVuPosX = 94;
                        account.Myself.NhiemVuPosY = 65;
                      }
                      else if (account.Myself.QuestInfo.Contains("ung Nh"))
                      {
                        account.Myself.NhiemVuPosX = 54;
                        account.Myself.NhiemVuPosY = 140;
                      }
                      else if (account.Myself.QuestInfo.Contains("ộc Vươ"))
                      {
                        account.Myself.NhiemVuPosX = 130;
                        account.Myself.NhiemVuPosY = 149;
                      }
                      else if (account.Myself.QuestInfo.Contains("hủy Vư"))
                      {
                        account.Myself.NhiemVuPosX = 140;
                        account.Myself.NhiemVuPosY = 97;
                      }
                      else if (account.Myself.QuestInfo.Contains("ỏa Vươ"))
                      {
                        account.Myself.NhiemVuPosX = 96 /*0x60*/;
                        account.Myself.NhiemVuPosY = 91;
                      }
                      else if (account.Myself.QuestInfo.Contains("ộc Vươ"))
                      {
                        account.Myself.NhiemVuPosX = 130;
                        account.Myself.NhiemVuPosY = 149;
                      }
                      else if (account.Myself.QuestInfo.Contains("hủy Vư"))
                      {
                        account.Myself.NhiemVuPosX = 140;
                        account.Myself.NhiemVuPosY = 97;
                      }
                      else if (account.Myself.QuestInfo.Contains("ỏa Vươ"))
                      {
                        account.Myself.NhiemVuPosX = 96 /*0x60*/;
                        account.Myself.NhiemVuPosY = 91;
                      }
                      else if (account.Myself.QuestInfo.Contains("âu La"))
                      {
                        account.Myself.NhiemVuPosX = 126;
                        account.Myself.NhiemVuPosY = 106;
                      }
                      else if (account.Myself.QuestInfo.Contains("ân Tinh An"))
                      {
                        account.Myself.NhiemVuPosX = 69;
                        account.Myself.NhiemVuPosY = 68;
                      }
                      else if (account.Myself.QuestInfo.Contains("ân võ s"))
                      {
                        account.Myself.NhiemVuPosX = 40;
                        account.Myself.NhiemVuPosY = 98;
                      }
                      else if (account.Myself.QuestInfo.Contains("hám Ti"))
                      {
                        account.Myself.NhiemVuPosX = 96 /*0x60*/;
                        account.Myself.NhiemVuPosY = 110;
                      }
                      else if (account.Myself.QuestInfo.Contains("hanh K"))
                      {
                        account.Myself.NhiemVuPosX = 150;
                        account.Myself.NhiemVuPosY = 118;
                      }
                      else if (account.Myself.QuestInfo.Contains("am Kỳ Th"))
                      {
                        account.Myself.NhiemVuPosX = 95;
                        account.Myself.NhiemVuPosY = 76;
                      }
                    }
                  }
                }
                if (account.Myself.QuestStep != 1)
                {
                  string viscii = GA.ConvertToVISCII(account.Myself.QuestInfo);
                  if (account.Myself.QuestInfo.Contains("Đã gặp:") || viscii.Contains("Ðã g£p:"))
                    account.Myself.NhiemVuType = 1;
                  else if (account.Myself.QuestInfo.Contains("được Bát Kê") || viscii.Contains("ðßþc Bát Kê") || account.Myself.QuestInfo.Contains("SDHDRW_091109_44"))
                    account.Myself.NhiemVuType = 2;
                  else if (account.Myself.QuestInfo.Contains("Đã thu thập") || viscii.Contains("Ðã thu th§p") || account.Myself.QuestInfo.Contains("SDHDRW_091109_41"))
                  {
                    account.Myself.NhiemVuType = 3;
                    if (!account.Myself.NhiemVuFinish && account.Myself.QuestStep < 2)
                      account.Myself.QuestStep = 2;
                  }
                  else if (account.Myself.QuestInfo.Contains("Đã tìm được") || viscii.Contains("Ðã tìm ðßþc"))
                    account.Myself.NhiemVuType = 4;
                  else if (account.Myself.QuestInfo.Contains("Thu thập bình") || viscii.Contains("Thu th§p bình"))
                    account.Myself.NhiemVuType = 5;
                }
              }
              else if (account.Myself.isQSM)
              {
                if (account.Myself.QuestInfo.Contains("#{SMRW_") || account.Myself.QuestInfo.Contains("#{yuenan") || account.Myself.QuestInfo.Contains("ụ Sư Mô") || account.Myself.QuestInfo.Contains("ã lâu không g"))
                {
                  if (account.Myself.QuestInfo.Contains("#{_INFOAIM"))
                  {
                    int result4 = 0;
                    int result5 = 0;
                    int result6 = -1;
                    try
                    {
                      string midString = GA.GetMidString(account.Myself.QuestInfo, "#{_INFOAIM", "}");
                      if (midString.Contains(","))
                      {
                        string[] strArray = midString.Split(',');
                        if (strArray.Length >= 3)
                        {
                          int.TryParse(strArray[0], out result4);
                          int.TryParse(strArray[1], out result5);
                          int.TryParse(strArray[2], out result6);
                        }
                      }
                    }
                    catch (Exception ex)
                    {
                      GA.WriteUserLog(frmMain.langQSMErrorData, account);
                      if (!account.Target.HasException)
                        GA.WriteUserLog($"{frmMain.langReportGAuto5}{ex.Message} Stack: {ex.StackTrace.ToString()}", account);
                      account.Target.HasException = true;
                    }
                    finally
                    {
                      if (!account.Myself.QuestInfo.Contains("SMFB_120214_") && !account.Myself.QuestInfo.Contains("TMSM_130808_"))
                      {
                        account.Myself.NhiemVuMapID = result6;
                        if (account.Myself.NhiemVuMapID == 112 /*0x70*/)
                          account.Myself.NhiemVuMapID = 39;
                        else if (account.Myself.NhiemVuMapID == 201)
                          account.Myself.NhiemVuMapID = 158;
                        else if (account.Myself.NhiemVuMapID == 615)
                          account.Myself.NhiemVuMapID = 521;
                        else if (account.Myself.NhiemVuMapID == 284)
                          account.Myself.NhiemVuMapID = 195;
                        account.Myself.NhiemVuPosX = result4;
                        account.Myself.NhiemVuPosY = result5;
                      }
                    }
                  }
                  if (account.Myself.QuestInfo.Contains("ủa ta sao khôn"))
                    account.Myself.NhiemVuType = 1;
                  else if (account.Myself.QuestInfo.Contains("a bắt 1"))
                  {
                    account.Myself.NhiemVuType = 2;
                    account.Myself.NhiemVuString1 = GA.GetMidString(account.Myself.QuestInfo, "#G#R", "#W(");
                    account.Myself.NhiemVuString1 = account.Myself.NhiemVuString1.Trim();
                  }
                  else if (account.Myself.QuestInfo.Contains("{yuenan"))
                  {
                    account.Myself.NhiemVuType = 3;
                    if (account.Myself.NhiemVuPosX == 99 && account.Myself.NhiemVuPosY == 45)
                      account.Myself.NhiemVuPosX = 101;
                  }
                  else if (account.Myself.QuestInfo.Contains("âu không gặ"))
                  {
                    account.Myself.NhiemVuType = 4;
                    account.Myself.NhiemVuString1 = GA.GetMidString(account.Myself.QuestInfo, "#R", "#W", 2);
                    account.Myself.NhiemVuString1 = account.Myself.NhiemVuString1.Trim();
                    if (account.Myself.NhiemVuPosX == 209 && account.Myself.NhiemVuPosY == 180 && account.Myself.NhiemVuMapID == 1)
                      account.Myself.NhiemVuPosY = 179;
                  }
                  else if (account.Myself.QuestInfo.Contains("hấp phả") || account.Myself.QuestInfo.Contains("dùng #Y"))
                  {
                    account.Myself.NhiemVuType = 5;
                    account.Myself.NhiemVuString1 = GA.GetMidString(account.Myself.QuestInfo, "dùng #Y", "#W");
                    account.Myself.NhiemVuString1 = account.Myself.NhiemVuString1.Trim();
                    if (account.Myself.NhiemVuString1 == string.Empty)
                    {
                      account.Myself.NhiemVuString1 = GA.GetMidString(account.Myself.QuestInfo, "#Y", "#W");
                      account.Myself.NhiemVuString1 = account.Myself.NhiemVuString1.Trim();
                    }
                    if (account.Myself.QuestInfo.Contains("gười đồn"))
                    {
                      account.Myself.NhiemVuPosX = 85;
                      account.Myself.NhiemVuPosY = 85;
                    }
                    else if (account.Myself.QuestInfo.ToLower().Contains("ơng minh v"))
                    {
                      account.Myself.NhiemVuPosX = 103;
                      account.Myself.NhiemVuPosY = 82;
                    }
                    else if (account.Myself.QuestInfo.ToLower().Contains("ái âm ph"))
                    {
                      account.Myself.NhiemVuPosX = 62;
                      account.Myself.NhiemVuPosY = 92;
                    }
                    else if (account.Myself.QuestInfo.ToLower().Contains("ái âm t"))
                    {
                      account.Myself.NhiemVuPosX = (int) sbyte.MaxValue;
                      account.Myself.NhiemVuPosY = 92;
                    }
                    else if (account.Myself.QuestInfo.Contains("ết Độ"))
                    {
                      account.Myself.NhiemVuPosX = 87;
                      account.Myself.NhiemVuPosY = 98;
                    }
                    else if (account.Myself.QuestInfo.Contains("ện Độ"))
                    {
                      account.Myself.NhiemVuPosX = 105;
                      account.Myself.NhiemVuPosY = 98;
                    }
                    else if (account.Myself.QuestInfo.Contains("ạp Độ"))
                    {
                      account.Myself.NhiemVuPosX = (int) sbyte.MaxValue;
                      account.Myself.NhiemVuPosY = 72;
                    }
                    else if (account.Myself.QuestInfo.Contains("óc Độ"))
                    {
                      account.Myself.NhiemVuPosX = 95;
                      account.Myself.NhiemVuPosY = 56;
                    }
                    else if (account.Myself.QuestInfo.Contains("hanh Họa"))
                    {
                      account.Myself.NhiemVuPosX = 144 /*0x90*/;
                      account.Myself.NhiemVuPosY = 57;
                    }
                    else if (account.Myself.QuestInfo.ToLower().Contains("ạn kha k"))
                    {
                      account.Myself.NhiemVuPosX = 150;
                      account.Myself.NhiemVuPosY = 149;
                    }
                    else if (account.Myself.QuestInfo.ToLower().Contains("ánh hiề"))
                    {
                      account.Myself.NhiemVuPosX = 55;
                      account.Myself.NhiemVuPosY = 64 /*0x40*/;
                    }
                    else if (account.Myself.QuestInfo.ToLower().Contains("ng hoàng c"))
                    {
                      account.Myself.NhiemVuPosX = 51;
                      account.Myself.NhiemVuPosY = 149;
                    }
                    else if (account.Myself.QuestInfo.Contains("oái Bă"))
                    {
                      account.Myself.NhiemVuPosX = 123;
                      account.Myself.NhiemVuPosY = 90;
                    }
                    else if (account.Myself.QuestInfo.Contains("ham Băn"))
                    {
                      account.Myself.NhiemVuPosX = 128 /*0x80*/;
                      account.Myself.NhiemVuPosY = 50;
                    }
                    else if (account.Myself.QuestInfo.Contains("yền Bă"))
                    {
                      account.Myself.NhiemVuPosX = 61;
                      account.Myself.NhiemVuPosY = 38;
                    }
                    else if (account.Myself.QuestInfo.Contains("àn Băn"))
                    {
                      account.Myself.NhiemVuPosX = 74;
                      account.Myself.NhiemVuPosY = 63 /*0x3F*/;
                    }
                    else if (account.Myself.QuestInfo.ToLower().Contains("ơn môn"))
                    {
                      account.Myself.NhiemVuPosX = 96 /*0x60*/;
                      account.Myself.NhiemVuPosY = 121;
                    }
                    else if (account.Myself.QuestInfo.ToLower().Contains("ại hùn"))
                    {
                      account.Myself.NhiemVuPosX = 95;
                      account.Myself.NhiemVuPosY = 83;
                    }
                    else if (account.Myself.QuestInfo.ToLower().Contains("hung lâ"))
                    {
                      account.Myself.NhiemVuPosX = 70;
                      account.Myself.NhiemVuPosY = 66;
                    }
                    else if (account.Myself.QuestInfo.ToLower().Contains("àng kinh c"))
                    {
                      account.Myself.NhiemVuPosX = 134;
                      account.Myself.NhiemVuPosY = 135;
                    }
                    else if (account.Myself.QuestInfo.ToLower().Contains("ồi long đ"))
                    {
                      account.Myself.NhiemVuPosX = 77;
                      account.Myself.NhiemVuPosY = 130;
                    }
                    else if (account.Myself.QuestInfo.ToLower().Contains("iên giớ"))
                    {
                      account.Myself.NhiemVuPosX = 45;
                      account.Myself.NhiemVuPosY = 84;
                    }
                    else if (account.Myself.QuestInfo.ToLower().Contains("kim điệ"))
                    {
                      account.Myself.NhiemVuPosX = 74;
                      account.Myself.NhiemVuPosY = 58;
                    }
                    else if (account.Myself.QuestInfo.ToLower().Contains("ải kiếm t"))
                    {
                      account.Myself.NhiemVuPosX = 46;
                      account.Myself.NhiemVuPosY = 171;
                    }
                    else if (account.Myself.QuestInfo.ToLower().Contains("ạch kim k"))
                    {
                      account.Myself.NhiemVuPosX = 49;
                      account.Myself.NhiemVuPosY = 152;
                    }
                    else if (account.Myself.QuestInfo.ToLower().Contains("nh mộc k"))
                    {
                      account.Myself.NhiemVuPosX = 138;
                      account.Myself.NhiemVuPosY = 146;
                    }
                    else if (account.Myself.QuestInfo.ToLower().Contains("ắc thủy"))
                    {
                      account.Myself.NhiemVuPosX = 137;
                      account.Myself.NhiemVuPosY = 35;
                    }
                    else if (account.Myself.QuestInfo.ToLower().Contains("àng thổ "))
                    {
                      account.Myself.NhiemVuPosX = 54;
                      account.Myself.NhiemVuPosY = 36;
                    }
                    else if (account.Myself.QuestInfo.ToLower().Contains("ờng sinh đi"))
                    {
                      account.Myself.NhiemVuPosX = 150;
                      account.Myself.NhiemVuPosY = 152;
                    }
                    else if (account.Myself.QuestInfo.ToLower().Contains("ạch thủ"))
                    {
                      account.Myself.NhiemVuPosX = 142;
                      account.Myself.NhiemVuPosY = 52;
                    }
                    else if (account.Myself.QuestInfo.ToLower().Contains("uân hiể"))
                    {
                      account.Myself.NhiemVuPosX = 43;
                      account.Myself.NhiemVuPosY = 43;
                    }
                    else if (account.Myself.QuestInfo.ToLower().Contains("ư ngữ đ"))
                    {
                      account.Myself.NhiemVuPosX = 39;
                      account.Myself.NhiemVuPosY = 147;
                    }
                    else if (account.Myself.QuestInfo.ToLower().Contains("ễn binh đà"))
                    {
                      account.Myself.NhiemVuPosX = 44;
                      account.Myself.NhiemVuPosY = 36;
                    }
                    else if (account.Myself.QuestInfo.ToLower().Contains("ỗ khang từ"))
                    {
                      account.Myself.NhiemVuPosX = 128 /*0x80*/;
                      account.Myself.NhiemVuPosY = 111;
                    }
                    else if (account.Myself.QuestInfo.ToLower().Contains("ương phò"))
                    {
                      account.Myself.NhiemVuPosX = 56;
                      account.Myself.NhiemVuPosY = 89;
                    }
                    else if (account.Myself.QuestInfo.ToLower().Contains("đào viê"))
                    {
                      account.Myself.NhiemVuPosX = 42;
                      account.Myself.NhiemVuPosY = 146;
                    }
                  }
                  else if (account.Myself.QuestInfo.Contains("hỏ góc trê") || account.Myself.QuestInfo.Contains("ản đồ nhỏ"))
                  {
                    account.Myself.NhiemVuType = 6;
                    account.Myself.NhiemVuString1 = GA.GetMidString(account.Myself.QuestInfo, "#G", "#W");
                    account.Myself.NhiemVuString1 = account.Myself.NhiemVuString1.Trim();
                  }
                  else if (account.Myself.QuestInfo.Contains("SMFB_120214_") || account.Myself.QuestInfo.Contains("TMSM_130808_"))
                    account.Myself.NhiemVuType = 7;
                }
              }
              else if (account.Myself.isCauNguyen)
              {
                if (account.Myself.QuestInfo.Contains("SQXY_09061_11"))
                  account.Myself.PacketMsg = "CNVCNR";
              }
              else if (account.Myself.isThuBiChienMinh && (account.Myself.QuestInfo.Contains("MZPVE_150812_64}") || account.Myself.QuestInfo.Contains("MZPVE_150812_1562}") || account.Myself.QuestInfo.Contains("MZPVE_150812_816}") || account.Myself.QuestInfo.Contains("MZPVE_150812_1188}") || account.Myself.QuestInfo.Contains("MZPVE_150812_1935}")))
                account.Myself.EventString = "VCTB";
              if (GA.isVipMember() && account.Settings.cboxDebugLog && account.Myself.tempQuestInfo != account.Myself.QuestInfo)
              {
                GA.WriteUserLog("QuestInfo: " + account.Myself.QuestInfo, account);
                break;
              }
              break;
            }
            break;
          case 5002:
            if (account.Myself != null)
            {
              account.Myself.IsMinimized = account.RingMsg[index2].bool1;
              break;
            }
            break;
          case 5003:
            if (account.Target.VersionNum == account.RingMsg[index2].int2 && account.Target.VersionNum != 0)
            {
              account.Target.SubVersion = account.RingMsg[index2].int1;
              if (account.RingMsg[index2].int3 != -1)
              {
                try
                {
                  account.Target.ServerIndex = account.RingMsg[index2].int3;
                  break;
                }
                catch (Exception ex)
                {
                  break;
                }
              }
              else
                break;
            }
            else
              break;
          case 5004:
            if (account.Myself != null)
            {
              if (account.RingMsg[index2].string1 != "")
              {
                account.Myself.ChatRecordedMessage = account.RingMsg[index2].string1;
                account.MyFlag.ChatRecorded = true;
                break;
              }
              account.MyFlag.ChatRecorded = false;
              account.Myself.ChatRecordedMessage = "";
              break;
            }
            break;
          case 5005:
            frmLogin.memallochandle = account.RingMsg[index2].int1;
            break;
          case 5006:
            account.MyFlag.CEHandle1 = account.RingMsg[index2].int1;
            account.MyFlag.LUAHandle = account.RingMsg[index2].int2;
            account.MyFlag.CEHandle2 = account.RingMsg[index2].int3;
            break;
          case 5007:
            account.MyFlag.HookOK = true;
            account.SaveWindowHandle();
            break;
          case 5008:
            account.SaveWindowHandle();
            break;
          case 5009:
            try
            {
              account.Target.PacketStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
              break;
            }
            catch (Exception ex)
            {
              break;
            }
          case 5010:
            try
            {
              account.Target.DLLCounter = frmLogin.GlobalTimer.ElapsedMilliseconds;
              break;
            }
            catch (Exception ex)
            {
              break;
            }
          case 5011:
            try
            {
              account.Myself.CaptchaTKStamp = 0L;
              break;
            }
            catch (Exception ex)
            {
              break;
            }
          case 5012:
            try
            {
              if (account.Myself != null)
              {
                string string1 = account.RingMsg[index2].string1;
                break;
              }
              break;
            }
            catch (Exception ex)
            {
              break;
            }
        }
        ++account.Myself.MsgReadIndex;
      }
    }
  }

  public static void ProcessErrorMessage(AutoAccount account, MessageFunc tempmsg)
  {
    if (account.Myself == null)
      return;
    string str = tempmsg.string1;
    string viscii = GA.ConvertToVISCII(str);
    str.Contains("Combat_Miss");
    if (GA.isVipMember() && account.Settings.cboxDebugLog && !str.Contains("Combat_Miss"))
    {
      str = str.Replace("{", "{{").Replace("}", "}}");
      GA.WriteUserLog("ErrorString: " + str, account);
    }
    if ((str.Contains("roduce_login_I") && str.Contains("fo_Connecting_Serv") || str.Contains("roduce_login_I") && str.Contains("o_Checking_Passw") || str.Contains("CRetLoginHand") && str.Contains("nfo_SafeSig")) && account.MyFlag.IsInGame)
    {
      account.MyFlag.IsInGame = false;
      lock (account.MyFlag.DLLReadyLock)
        account.MyFlag.DLLReady = false;
      for (int k = frmLogin.GAuto.AllAutoAccounts.Count - 1; k >= 0; --k)
      {
        if (frmLogin.GAuto.AllAutoAccounts[k].Target.ProcessID == account.Target.ProcessID)
        {
          if (account.Target.NeedToAbort4 == 0)
          {
            account.Target.NeedToAbort4 = 4;
            new Thread((ThreadStart) (() => SmartClass.RemoveAutoAccount(k))).Start();
            break;
          }
          break;
        }
      }
    }
    if (!account.MyFlag.IsInGame && account.MyFlag.NeedAutoLogin)
    {
      if (account.MyFlag.InGameStatus == 0 && str.Contains("Tip_PVP_Moral"))
        account.MyFlag.InGameStatus = 1;
      if ((str.Contains("Tip_PVP_FreeForTeam") || str.Contains("Tip_PVP_Peace")) && account.MyFlag.InGameStatus < 2)
      {
        account.MyFlag.InGameStatus = 2;
        account.MyFlag.InGameFinishLoadingStamp = frmLogin.GlobalTimer.ElapsedMilliseconds + 3000L;
      }
      if (account.MyFlag.InGameStatus == 3 && str.Contains("netManager_Info_Connect_OverTime") || account.Target.VersionNum == 4 && str.Contains("produce_char_sel_Info_Readying_To_Ent"))
        account.MyFlag.InGameStatus = 4;
    }
    if (str.Contains("#{ResultText_167}"))
      account.Myself.EventString = "CLXN";
    else if (!str.Contains("netManager_Info_Server_Not_Work") || account.MyFlag.ServerDisconnected)
    {
      if (str.Contains("át khỏi độ") || viscii.Contains("át khöi ðµ") || str.Contains("ped followi"))
      {
        string midString = GA.GetMidString(str, "#e010101", " ");
        if (!string.IsNullOrEmpty(midString) && account.IsPartyKey() && account.MyParty.AllMembers.Count > 0)
        {
          for (int index = account.MyParty.AllMembers.Count - 1; index >= 1; --index)
          {
            PartyMember allMember = account.MyParty.AllMembers[index];
            if (allMember.Name == midString)
            {
              allMember.flagPartyFollowed = false;
              break;
            }
          }
        }
      }
      else if (str.Contains("am gia đội n") || viscii.Contains("am gia ðµi n") || str.Contains("ed the request to fo"))
      {
        string midString = GA.GetMidString(str, "#e010101", " ");
        if (!string.IsNullOrEmpty(midString) && account.IsPartyKey() && account.MyParty.AllMembers.Count > 0)
        {
          for (int index = account.MyParty.AllMembers.Count - 1; index >= 1; --index)
          {
            PartyMember allMember = account.MyParty.AllMembers[index];
            if (allMember.Name == midString)
            {
              allMember.flagPartyFollowed = true;
              break;
            }
          }
        }
      }
      else if (str.Contains("ăng này khôn") || viscii.Contains("ång này khôn"))
      {
        account.MyQuai.TargetHPPercent = 0.0f;
        account.MyQuai.TargetID = -1;
      }
      else if (!str.Contains("#{ResultText_130}"))
      {
        if (str.Contains("#{ResultText_8}"))
        {
          account.CallSelectTarget(-1);
          account.MyQuai.TargetID = -1;
        }
        else if (!str.Contains("#{ResultText_129}"))
        {
          if (str.Contains("ân khí khô"))
          {
            account.Myself.ManaRunOut = true;
            account.Myself.ManaRunOutStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
          }
          else if (!str.Contains("#{ResultText_45}"))
          {
            if (str.Contains("UI_NOTICE_BEATTACKED_ENEMYNAME") || str.Contains("ừ đâu cô"))
            {
              if (!account.Myself.FlagBeingAttacked)
              {
                account.Myself.FlagBeingAttacked = true;
                account.Myself.FlagBeingAttackedStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
                account.Myself.IsAttackedTimeStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
                account.Myself.IsAttacked = 1;
                account.Myself.AttackerID = 1;
              }
            }
            else if (str.Contains("GCDetailExp_Human_NormalAndAdditionalExp") || str.Contains("GCDetailExp_Human_NormalExp"))
              account.Myself.LastReceiveExpStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
            else if (str.Contains("GCPickResultHandler_Info_package_Full"))
            {
              account.Myself.FlagFullBoc = true;
              account.Myself.FlagFullBocStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
            }
            else if (str.Contains("Sử dụng nhân đôi kinh nghiệm trong"))
            {
              if (account.Myself != null)
                account.Myself.Lastx2UsedStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
            }
            else if (str.Contains("#c00FFFF#e010101#{APALJ_110303_8}"))
            {
              if (account.Myself != null)
                account.Myself.Lastx4UsedStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
            }
            else if (str.Contains("ó đạo cụ đ") || viscii.Contains("ó ðÕo cø ð"))
            {
              account.MyPet.NoToy = true;
              account.MyPet.NoToyStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
            }
            else if (str.Contains("ương thực thí") || str.Contains("pt_Pet_NoFe"))
            {
              if (!account.Myself.FlagHetThucAn)
              {
                account.Myself.FlagHetThucAn = true;
                account.Myself.FlagHetThucAnStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
              }
            }
            else if (str.Contains("ông thể t") && str.Contains("iêu nà"))
            {
              if (account.MyQuai != null && account.MyQuai.TargetID != -1 && account.MyQuai.AllQuai.Count > 0)
              {
                account.MyQuai.CanAttackInt = 1;
                account.CallSelectTarget(-1);
                for (int index = account.MyQuai.AllQuai.Count - 1; index >= 0; --index)
                {
                  QuaiIndividual quaiIndividual = account.MyQuai.AllQuai[index];
                  if (quaiIndividual.ID == account.MyQuai.TargetID && !account.Myself.IsPK && account.MyQuai.AllQuai[index].CanAttack != (byte) 11)
                  {
                    quaiIndividual.CanAttack = (byte) 1;
                    break;
                  }
                }
                account.MyQuai.IgnoredQuaiID.Add(account.MyQuai.TargetID);
              }
            }
            else if (!str.Contains("GMDP_Struct_Skill_Info_Peace_Mode_Warning"))
            {
              if (str.Contains("010101Các hạ đang tự tìm đườ") || str.Contains("010101Các hÕ đang tự t́m đườ") || viscii.Contains("010101Các hÕ ðang tñ tìm ðß¶"))
              {
                lock (account.Myself.JustWarpedLock)
                  account.MyFlag.NoMoveStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
              }
              else if (str.Contains("ILFER_LOC"))
                account.Myself.VutDoStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
              else if (str.Contains("ở khóa thấ") || viscii.Contains("· khóa th¤"))
              {
                ++account.Myself.pass2Counter;
                if (account.Myself.lockCounter >= 2)
                {
                  account.Myself.pass2Counter = 0;
                  account.Settings.cboxPassCap2 = false;
                  GA.WriteUserLog("Pass 2 bạn nhập sai. Vui lòng nhập pass khác rồi bật lại chức năng để thử lại.", account);
                }
              }
              else if (str.Contains("{ResultText_71}"))
              {
                if (account.Myself.YeuCauPass2Stamp == 0L)
                  account.Myself.YeuCauPass2Stamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
                else if (frmLogin.GlobalTimer.ElapsedMilliseconds - account.Myself.YeuCauPass2Stamp >= 60000L)
                {
                  account.Myself.lockCounter = 0;
                  account.Myself.YeuCauPass2Stamp = 0L;
                }
                else if (frmLogin.GlobalTimer.ElapsedMilliseconds - account.Myself.YeuCauPass2Stamp >= 5000L)
                {
                  ++account.Myself.lockCounter;
                  if (account.Myself.lockCounter >= 5)
                  {
                    account.Myself.lockCounter = 0;
                    account.Myself.YeuCauPass2Stamp = 0L;
                    account.Settings.cboItemTuHuy = false;
                    account.Settings.cboxVutDoKhiFull = false;
                    GA.WriteUserLog("Chức năng hủy vật phẩm cần nhập pass 2. Auto tạm tắt chức năng này nếu bạn cần dùng thì nhập pass 2 và bật lại sau nhé.", account);
                  }
                }
              }
              else if (str.Contains("{ResultText_75}"))
                account.Settings.DungNgua = false;
              else if (str.Contains("{ResultText_12}"))
                account.AIActionSet(1);
            }
          }
        }
      }
    }
    if (account.Myself.IsXayDung)
    {
      if (str.Contains("ường nh") || viscii.Contains("ß¶ng nh"))
        account.Myself.EventString = "XDTT";
      else if (str.Contains("ng Cho Ng") || str.Contains("oàn thà") || str.Contains("ược nhặ") || viscii.Contains("ßþc nh£") || str.Contains("{BHJS_"))
        account.Myself.EventString = "XDXQ";
      else if (str.Contains(": 10/10"))
        account.Myself.EventString = "XDCTF";
    }
    else if (account.Myself.IsTrungAc)
    {
      if (account.Myself.MapID == 1)
      {
        if (str.Contains("ận được#{") || str.Contains("ou received") || str.Contains("ận đưềc #{") || viscii.Contains("§n ðßþc#{"))
          account.Myself.EventString = "TAXQ";
      }
      else if (str.Contains("ã đánh bại ác") || str.Contains("illed villain") || str.Contains("ă đánh bÕi á") || viscii.Contains("ã ðánh bÕi ác"))
        account.Myself.EventString = "DCTAB";
    }
    else if (account.Myself.IsTuDuongCon)
    {
      if (account.Myself.QuestStep == 1)
      {
        if (str.Contains("SXPY_130826_27") || str.Contains("SXPY_130826_533") || str.Contains("SXPY_130826_535") || str.Contains("SXPY_130826_537") || str.Contains("SXPY_130826_539") || str.Contains("SXPY_130826_25") || str.Contains("SXPY_130826_73") || str.Contains("SXPY_130826_105") || str.Contains("SXPY_130826_141") || str.Contains("SXPY_130826_185"))
          account.Myself.EventString = "QCMR";
        else if (str.Contains("101#{SXPY_130826_"))
          account.Myself.EventString = "QCNNV";
      }
      else if (str.Contains("SXPY_130826_69") || str.Contains("SXPY_130826_102") || str.Contains("SXPY_130826_138") || str.Contains("SXPY_130826_183") || str.Contains("SXPY_130826_209"))
        account.Myself.EventString = "QCTNV";
      else if (str.Contains("SXPY_130826_48") || str.Contains("SXPY_130826_127") || str.Contains("SXPY_130826_160") || str.Contains("SXPY_130826_198"))
        account.Myself.EventString = "QCTLS";
      else if (str.Contains("SXPY_130826_46") || str.Contains("SXPY_130826_131") || str.Contains("SXPY_130826_158") || str.Contains("SXPY_130826_199"))
        account.Myself.EventString = "QCTLD";
      else if (str.Contains("SXPY_130826_62") || str.Contains("SXPY_130826_89") || str.Contains("SXPY_130826_128") || str.Contains("SXPY_130826_114") || str.Contains("SXPY_130826_174") || str.Contains("SXPY_130826_201") || str.Contains("SXPY_130826_192"))
        account.Myself.EventString = "QCXNV";
    }
    else if (account.Myself.IsLuyenKim)
    {
      if (str.Contains("BHRWSC_110331_176") || str.Contains("BHRWSC_110331_41"))
        account.Myself.EventString = "LKXQ";
    }
    else if (account.Myself.IsAcTac || account.Myself.IsAcBa || account.Myself.IsPHLM)
    {
      if (str.Contains(": 30/30") || str.Contains(": 30/31") || str.Contains("}43/43"))
        account.Myself.EventString = "ATXQ";
      if (account.IsPartyKey())
      {
        if (str.Contains("Ác Bá: 1/1") || str.Contains("Thieves: 1/1"))
        {
          if (account.Settings.cboABMaps != 16 /*0x10*/ || account.Target.VersionNum != 3)
          {
            account.Myself.EventString = "ATKT";
            ++account.Myself.acbaCounter;
            GA.WriteUserLog(frmMain.langCompleteAcBa, account, (object) account.Myself.acbaCounter);
          }
        }
        else if (str.Contains(": 31/31"))
        {
          account.Myself.EventString = "ATKT";
          ++account.Myself.acbaCounter;
          GA.WriteUserLog(frmMain.langCompleteAcTac, account, (object) account.Myself.acbaCounter);
        }
        else if (str.Contains("FHGC_090706_22"))
          account.Myself.EventString = "ATKT";
        else if (str.Contains("ẽ rời k"))
        {
          if (str.Contains("u 10 gi"))
            account.Myself.EventString = "PBKT10";
          if (str.Contains("u 5 gi"))
            account.Myself.EventString = "PBKT5";
        }
        else if (str.Contains("ill leave her"))
        {
          if (str.Contains("er 10 sec"))
            account.Myself.EventString = "PBKT10";
          if (str.Contains("er 5 sec"))
            account.Myself.EventString = "PBKT5";
        }
      }
    }
    else if (account.Myself.IsTKC)
    {
      if (str.Contains("}Trái#{"))
        account.Myself.EventString = "QRBT";
      else if (str.Contains("}Phải#{") || viscii.Contains("}Phäi#{"))
        account.Myself.EventString = "QRBP";
      if (str.Contains("}10/10#{") || str.Contains("ông Diệ"))
        account.Myself.EventStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
    }
    else if (account.Myself.IsKhaiKhoang)
    {
      if (str.Contains("ần Há") || viscii.Contains("¥n Há") || str.Contains("ần Kha") || viscii.Contains("¥n Kha") || str.Contains("n kỹ nă") || viscii.Contains("n kÛ nå"))
        account.Myself.EventString = "KDCD";
      else if (str.Contains("ộ thành t") || viscii.Contains("µ thành t"))
      {
        ++account.Myself.kkhdCounter;
        GA.WriteUserLog("Tăng được {0} độ thành thạo", account, (object) account.Myself.kkhdCounter);
      }
    }
    else if (account.Myself.isBachHoaDuyen)
    {
      if (str.Contains("SDHDRW_091109_26"))
      {
        account.Myself.EventString = "HHOK";
        if (str.Contains("3/3"))
          account.Myself.EventString = "HHXR";
      }
      if (str.Contains("SDHDRW_091109_28"))
        account.Myself.EventString = "HHXR";
      else if (str.Contains("SDHDRW_091109_24"))
      {
        account.Myself.EventString = "HHOK";
        if (str.Contains("5/5"))
          account.Myself.EventString = "HHXR";
      }
      else if (str.Contains("SDHDRW_091109_29"))
      {
        account.Myself.EventString = GA.GetMidString(str, "9_29}", "#{S");
        if (account.Myself.EventString != "")
        {
          GA.WriteUserLog("Xong vòng {0} nv Hoa", account, (object) account.Myself.EventString);
          int.TryParse(account.Myself.EventString, out account.Myself.haihoaCounter);
          if (account.Myself.haihoaCounter >= frmLogin.GAuto.Settings.soVongQHoa)
            account.Myself.EventString = "HVQH";
        }
        if (account.Myself.EventString != "HVQH")
          account.Myself.EventString = "NVHF";
      }
    }
    else if (account.Myself.isDaoBTD)
    {
      if (str.Contains("ất bạ"))
        account.Myself.EventString = "PCTB";
      else if (str.Contains("hông thể ph"))
        account.Myself.EventString = "KTPC";
      else if (str.Contains("úi củ"))
        account.Myself.NhiemVuType = 1;
      else if (str.Contains("ụng phả"))
        account.Myself.NhiemVuType = 2;
      else if (str.Contains("ơi đã đạ"))
        account.Myself.NhiemVuType = 3;
      else if (str.Contains("ào đượ"))
        account.Myself.NhiemVuType = 4;
      else if (str.Contains("hả bọ"))
        account.Myself.NhiemVuType = 5;
      else if (str.Contains("ẩn thậ"))
        account.Myself.NhiemVuType = 6;
      else if (str.Contains("ơi và"))
        account.Myself.NhiemVuType = 7;
    }
    else if (account.Myself.isCauPhuc)
    {
      if (str.Contains("TGQF_100111_53"))
        account.Myself.EventString = "CPTC";
    }
    else if (account.Myself.isQSM)
    {
      if (str.Contains("ã đạt") && str.Contains("ởng Thà") || str.Contains("ắt thành côn"))
        account.Myself.EventString = "BDPR";
      else if (str.Contains("oàn thà") && str.Contains("ư mô"))
      {
        account.Myself.EventString = "QSMFN";
        string s = GA.GetMidString(str, "xong", "vò").Trim();
        GA.WriteUserLog("Xong vòng {0} nv Sư Môn", account, (object) s);
        int result = 0;
        int.TryParse(s, out result);
        if (result >= frmLogin.GAuto.Settings.soVongQSM)
        {
          GA.WriteUserLog("Đã xong {0} vòng QSM, dừng nhiệm vụ", account, (object) s);
          account.Myself.isQSM = false;
          account.IsAIEnabled = false;
        }
      }
      if (account.Myself.NhiemVuType == 6)
      {
        if (str.Contains("5/5") || str.Contains("ext_43}"))
          account.Myself.EventString = "TDXR";
      }
      else if (account.Myself.NhiemVuType == 5 && str.Contains("ệm vụ đã ho"))
        account.Myself.EventString = "SMXQ";
    }
    else if (account.Myself.IsCheDo)
    {
      if (str.Contains("ltText_15}"))
        account.Myself.EventString = "TDTKG";
      else if (str.Contains("rget_Bo") || str.Contains("ương đ"))
        account.Myself.EventString = "RDDD";
      else if (str.Contains("ệu không đ") || str.Contains("ỗỪừãặắ") || str.Contains("ient materia"))
        account.Myself.EventString = "HDTR";
      else if (str.Contains("ED_SPEC_ST"))
        account.Myself.EventString = "HNLR";
    }
    else if (account.Myself.IsQ1)
    {
      if (str.Contains(frmMain.langDDPL))
        account.Myself.EventString = "DDPL";
      else if (str.Contains(frmMain.langTDDD))
        account.Myself.EventString = "TDDD";
      else if (str.Contains(frmMain.langDDQDT))
        account.Myself.EventString = "DDQDT";
      else if (str.Contains(frmMain.langDXNTB))
        account.Myself.EventString = "DXNTB";
      else if (str.Contains("ã hoàn thà") || str.Contains("finish"))
        account.MyFlag.xongQstamp = 0L;
    }
    else if (account.Myself.IsQ2)
    {
      if (str.Contains(frmMain.langDDDH))
        account.Myself.EventString = "DDDH";
      else if (str.Contains(frmMain.langDDHV))
        account.Myself.EventString = "DDHV";
      else if (str.Contains("ã hoàn thà") || str.Contains("finish"))
        account.MyFlag.xongQstamp = 0L;
      if (str.Contains("ã Hùng: "))
      {
        string midString = GA.GetMidString(str, "ùng: ", "/80");
        int result = -1;
        int.TryParse(midString, out result);
        account.Myself.NhiemVuCounter = 80 /*0x50*/ - result;
      }
      else if (str.Contains("d Bear: "))
      {
        string midString = GA.GetMidString(str, "Bear: ", "/80");
        int result = -1;
        int.TryParse(midString, out result);
        account.Myself.NhiemVuCounter = 80 /*0x50*/ - result;
      }
      else if (str.Contains("野熊: "))
      {
        string midString = GA.GetMidString(str, "野熊", "/80");
        int result = -1;
        int.TryParse(midString, out result);
        account.Myself.NhiemVuCounter = 80 /*0x50*/ - result;
      }
    }
    else if (account.Myself.isTrongHoa)
    {
      if (str.Contains("{ResultText_6}"))
        account.Myself.EventString = "SCHP";
    }
    else if (account.Myself.isYTO)
    {
      if (str.Contains("{ResultText_159}"))
        account.Myself.EventString = "TTBQC";
      if (str.Contains("ã bị đánh bạ") && str.Contains("ung Ph") || str.Contains("Fu Rong") && str.Contains("defe"))
        account.Myself.EventString = "TDMDP";
    }
    else if (account.Myself.isThuBiChienMinh && str.Contains("hành côn"))
      account.Myself.EventString = "TBTC";
    if (frmLogin.GlobalTimer.ElapsedMilliseconds - account.MyFlag.MDPPlayDCTD <= 120000L && frmLogin.GlobalTimer.ElapsedMilliseconds - account.MyFlag.inYTOStamp <= 300000L)
    {
      if (str.Contains("ớng li"))
      {
        string midString = GA.GetMidString(str, "u [", "]");
        if (account.Myself.Name == midString)
        {
          if (account.Myself.ActionStatus == (byte) 7)
          {
            if (account.MySkills.KhinhCongID > 0)
            {
              account.CallAttackTarget(-1, account.MySkills.KhinhCongID, 0, 0);
            }
            else
            {
              account.CallAttackTarget(-1, 34, 0, 0);
              int khinhCongId = account.GetKhinhCongID();
              account.CallAttackTarget(-1, khinhCongId, 0, 0);
            }
            Thread.Sleep(300);
          }
          account.Settings.cboxTheoSau = false;
          account.CallMoveTo(46, 83);
        }
        else
          account.Settings.cboxTheoSau = true;
      }
      if ((account.Target.SubVersion == 12 || account.Target.VersionNum == 4) && str.Contains("s looking at"))
      {
        string midString = GA.GetMidString(str, "at [", "]");
        if (account.Myself.Name == midString)
        {
          if (account.Myself.ActionStatus == (byte) 7)
          {
            if (account.MySkills.KhinhCongID > 0)
            {
              account.CallAttackTarget(-1, account.MySkills.KhinhCongID, 0, 0);
            }
            else
            {
              account.CallAttackTarget(-1, 34, 0, 0);
              int khinhCongId = account.GetKhinhCongID();
              account.CallAttackTarget(-1, khinhCongId, 0, 0);
            }
            Thread.Sleep(300);
          }
          account.Settings.cboxTheoSau = false;
          account.CallMoveTo(46, 83);
        }
        else
          account.Settings.cboxTheoSau = true;
      }
    }
    if ((frmLogin.GlobalTimer.ElapsedMilliseconds - account.MyFlag.useItemTriggerStamp <= 300000L || frmLogin.GlobalTimer.ElapsedMilliseconds - account.MyFlag.inYTOStamp <= 300000L) && str.Contains("{ResultText_159}"))
    {
      for (int index = 0; index < 30; ++index)
      {
        if (account.MyInventory.AllItems[index].ItemID == 30103042)
        {
          account.CallUseItem(index, account.Myself.ID);
          break;
        }
      }
    }
    if (str.Contains("{ResultText_3}"))
      account.Myself.EventString = "KNVH";
    else if (str.Contains("{ResultText_9}"))
    {
      if (account.MyFlag.VuotQuaPhamViStamp == 0L)
        account.MyFlag.VuotQuaPhamViStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
      if (frmLogin.GlobalTimer.ElapsedMilliseconds - account.MyFlag.VuotQuaPhamViStamp <= 3000L)
        ++account.MyFlag.VuotQuaPhamViCount;
      if (frmLogin.GlobalTimer.ElapsedMilliseconds - account.MyFlag.VuotQuaPhamViStamp > 3000L)
      {
        account.MyFlag.VuotQuaPhamViStamp = 0L;
        account.MyFlag.VuotQuaPhamViCount = 0;
      }
    }
    if (str.Contains("TDGZ_100809_21") || str.Contains("ã gia nhập Quâ"))
      account.MyFlag.ReadQuanDoanStamp = SmartClass.nowStamp() + 3000L;
    if (!GA.isShitMember() || new Random().Next(0, 10000) > 7000)
      return;
    account.Myself.EventString = "";
  }

  public static unsafe void ProcessPackets(AutoAccount account)
  {
    if (account == null || account.Myself == null)
      return;
    if (account.Myself.PacketReadIndex > account.Myself.PacketWriteIndex)
      account.Myself.PacketReadIndex = 0L;
    long num1 = account.Myself.PacketWriteIndex - account.Myself.PacketReadIndex;
    bool flag1 = false;
    SmartClass.IsBufferEmpty(account);
    byte[] numArray1 = new byte[2];
    byte[] numArray2 = new byte[2];
    while (!account.Target.bufferEmpty && num1 >= 6L && !flag1)
    {
      SmartClass.IsBufferEmpty(account);
      numArray1[0] = (byte) 0;
      numArray1[1] = (byte) 0;
      numArray2[0] = (byte) 0;
      numArray2[1] = (byte) 0;
      long packetReadIndex = account.Myself.PacketReadIndex;
      int index1 = (int) ((packetReadIndex + 1L) % (long) (uint) account.Target.RingPacketSize);
      int uint16_1 = (int) GABitConverter.ToUInt16(account.Target._RingRef, index1);
      int index2 = (int) ((packetReadIndex + 2L + 1L) % (long) (uint) account.Target.RingPacketSize);
      int uint16_2 = (int) GABitConverter.ToUInt16(account.Target._RingRef, index2);
      int packetLength = uint16_2 + 6;
      int num2 = packetLength;
      num1 = account.Myself.PacketWriteIndex - account.Myself.PacketReadIndex;
      int readRealIndex = (int) ((account.Myself.PacketReadIndex + 1L) % (long) (uint) account.Target.RingPacketSize);
      int readLeftOver = (int) (uint) account.Target.RingPacketSize - readRealIndex;
      bool flag2 = false;
      if ((uint16_1 == 456 || uint16_1 == 0 || packetLength > 4000 || num1 > (long) (ulong) account.Target.RingPacketSize) && account.Myself.stampErrorPacket == 0L)
      {
        account.Myself.stampErrorPacket = frmLogin.GlobalTimer.ElapsedMilliseconds;
        flag2 = true;
      }
      if (account.Myself.stampErrorPacket != 0L && frmLogin.GlobalTimer.ElapsedMilliseconds - account.Myself.stampErrorPacket >= 7000L)
      {
        if (GA.isVipMember())
          GA.WriteUserLog(frmMain.langInvalidData, account, (object) (int) account.Myself.PosX, (object) (int) account.Myself.PosY, (object) account.Myself.MapID);
        account.Myself.PacketReadIndex = 0L;
        account.CallResetPacketRing();
        account.Myself.stampErrorPacket = 0L;
        break;
      }
      if (!flag2)
      {
        if (!account.Target.bufferEmpty && num1 >= (long) num2 && uint16_1 != 0 && num2 > 0)
        {
          if (packetLength < 4000 && account.Myself != null)
          {
            if (!account.MyFlag.IsInGame && account.MyFlag.NeedAutoLogin)
            {
              if (uint16_1 == 319 && (account.Target.VersionNum == 1 || account.Target.VersionNum == 2 || account.Target.VersionNum == 4) || uint16_1 == 622 && account.Target.VersionNum == 3)
              {
                if (account.MyFlag.InGameStatus == 3)
                {
                  account.MyFlag.InGameStatus = 100;
                  account.MyFlag.InGameFinishLoadingStamp = frmLogin.GlobalTimer.ElapsedMilliseconds + 4500L;
                }
              }
              else if (uint16_1 == 223 && (account.Target.VersionNum == 1 || account.Target.VersionNum == 2 || account.Target.VersionNum == 4))
              {
                if (account.MyFlag.InGameStatus == 3)
                {
                  SmartClass.StripPacket(account, packetLength, readLeftOver, readRealIndex);
                  if (account.Target.tempNewPacket[56] == (byte) 8)
                    account.MyFlag.InGameFinishLoadingStamp = frmLogin.GlobalTimer.ElapsedMilliseconds + 22000L;
                  else if (account.Target.tempNewPacket[56] == (byte) 1 && account.AutoProfile != null)
                  {
                    account.AutoProfile.InvalidPassword = true;
                    account.MyFlag.InGameStatus = 4;
                  }
                }
              }
              else if (uint16_1 == 506 && (account.Target.VersionNum == 1 || account.Target.VersionNum == 2 || account.Target.VersionNum == 4) || uint16_1 == 670 && account.Target.VersionNum == 3)
              {
                SmartClass.StripPacket(account, packetLength, readLeftOver, readRealIndex);
                SmartClass.PacketNumCaptcha(account, uint16_2, packetLength);
              }
            }
            if (account.Myself.MapID != -1)
            {
              if (uint16_1 == 1062 && GA.CheckGameVersion(account.Target.VersionNum) == 356 || uint16_1 == 492 && account.Target.VersionNum == 3 || uint16_1 == 655 && account.Target.VersionNum == 4)
              {
                SmartClass.StripPacket(account, packetLength, readLeftOver, readRealIndex);
                SmartClass.PacketItemDetails(account, uint16_2, packetLength);
              }
              else if (uint16_1 == 717 && GA.CheckGameVersion(account.Target.VersionNum) == 356 || uint16_1 == 510 && account.Target.VersionNum == 3 || uint16_1 == 251 && account.Target.VersionNum == 4)
              {
                SmartClass.StripPacket(account, packetLength, readLeftOver, readRealIndex);
                SmartClass.PacketPartyJoin(account, uint16_2, packetLength);
              }
              else if (uint16_1 == 188 && GA.CheckGameVersion(account.Target.VersionNum) == 356 || uint16_1 == 514 && account.Target.VersionNum == 3 || uint16_1 == 537 && account.Target.VersionNum == 4)
              {
                SmartClass.StripPacket(account, packetLength, readLeftOver, readRealIndex);
                SmartClass.PacketPartyMemberInviteOther(account, uint16_2, packetLength);
              }
              else if (uint16_1 == 642 && GA.CheckGameVersion(account.Target.VersionNum) == 356 || uint16_1 == 504 && account.Target.VersionNum == 3 || uint16_1 == 673 && account.Target.VersionNum == 4)
              {
                SmartClass.StripPacket(account, packetLength, readLeftOver, readRealIndex);
                SmartClass.PacketQuaiAppear(account, uint16_2, packetLength);
              }
              else if (uint16_1 == 799 && GA.CheckGameVersion(account.Target.VersionNum) == 356 || uint16_1 == 447 && account.Target.VersionNum == 3)
              {
                SmartClass.StripPacket(account, packetLength, readLeftOver, readRealIndex);
                SmartClass.PacketStuckAlert(account, uint16_2, packetLength);
              }
              else if (uint16_1 == 964 && GA.CheckGameVersion(account.Target.VersionNum) == 356 || uint16_1 == 206 && account.Target.VersionNum == 3 || uint16_1 == 806 && account.Target.VersionNum == 4)
              {
                SmartClass.StripPacket(account, packetLength, readLeftOver, readRealIndex);
                SmartClass.PacketQuaiDisappear(account, uint16_2, packetLength);
              }
              else if (uint16_1 == 681 && GA.CheckGameVersion(account.Target.VersionNum) == 356)
              {
                SmartClass.StripPacket(account, packetLength, readLeftOver, readRealIndex);
                SmartClass.PacketBocDisappear(account, uint16_2, packetLength);
              }
              else if (uint16_1 == 129 && GA.CheckGameVersion(account.Target.VersionNum) == 356 || uint16_1 == 606 && account.Target.VersionNum == 3 || uint16_1 == 696 && account.Target.VersionNum == 4)
              {
                SmartClass.StripPacket(account, packetLength, readLeftOver, readRealIndex);
                SmartClass.PacketPartyInvite(account, uint16_2, packetLength);
              }
              else if (uint16_1 == 793 && GA.CheckGameVersion(account.Target.VersionNum) == 356 || uint16_1 == 22 && account.Target.VersionNum == 3 && account.Target.SubVersion != 4)
              {
                SmartClass.StripPacket(account, packetLength, readLeftOver, readRealIndex);
                SmartClass.PacketPartyRequestFollow(account, uint16_2, packetLength);
              }
              else if (uint16_1 == 1003 && GA.CheckGameVersion(account.Target.VersionNum) == 356 || uint16_1 == 310 && account.Target.VersionNum == 3 || uint16_1 == 752 && account.Target.VersionNum == 4)
              {
                SmartClass.StripPacket(account, packetLength, readLeftOver, readRealIndex);
                SmartClass.ProcPacketString(account, uint16_2, packetLength);
              }
              else if (uint16_1 == 1015 && GA.CheckGameVersion(account.Target.VersionNum) == 356 || uint16_1 == 250 && account.Target.VersionNum == 3 || uint16_1 == 46 && account.Target.VersionNum == 4)
              {
                SmartClass.StripPacket(account, packetLength, readLeftOver, readRealIndex);
                SmartClass.PacketBocDetails(account, uint16_2, packetLength);
              }
              else if (uint16_1 == 986 && GA.CheckGameVersion(account.Target.VersionNum) == 356 || uint16_1 == 542 && account.Target.VersionNum == 3 || uint16_1 == 130 && account.Target.VersionNum == 4)
              {
                bool flag3 = false;
                if (account.Target._RingRef[readRealIndex + 6] == (byte) 4 && account.Target._RingRef[readRealIndex + 11] == (byte) 196 && (account.Target.VersionNum == 7 || account.Target.VersionNum == 8))
                  flag3 = true;
                if ((account.Target._RingRef[readRealIndex + 8] == (byte) 64 /*0x40*/ || account.Target._RingRef[readRealIndex + 11] == (byte) 64 /*0x40*/) && account.Target._RingRef[readRealIndex + 6] == (byte) 4 || GA.isVipMember() && flag3)
                {
                  SmartClass.StripPacket(account, packetLength, readLeftOver, readRealIndex);
                  SmartClass.PacketChat(account, uint16_2, packetLength);
                }
                if (account.Target._RingRef[readRealIndex + 6] == (byte) 3)
                {
                  SmartClass.StripPacket(account, packetLength, readLeftOver, readRealIndex);
                  SmartClass.PacketChat(account, uint16_2, packetLength, 1);
                }
              }
              else if (uint16_1 == 651 && GA.CheckGameVersion(account.Target.VersionNum) == 356 || uint16_1 == 295 && account.Target.VersionNum == 3 || uint16_1 == 62 && account.Target.VersionNum == 4)
              {
                SmartClass.StripPacket(account, packetLength, readLeftOver, readRealIndex);
                SmartClass.PacketAiDanhAiDo(account, uint16_2, packetLength);
              }
              else if (uint16_1 == 68 && account.Target.VersionNum == 3 || uint16_1 == 824 && account.Target.VersionNum == 4)
              {
                SmartClass.StripPacket(account, packetLength, readLeftOver, readRealIndex);
                SmartClass.PacketTNShop(account, uint16_2, packetLength);
              }
              else if (uint16_1 == 458 && account.Target.VersionNum == 3)
              {
                SmartClass.StripPacket(account, packetLength, readLeftOver, readRealIndex);
                SmartClass.PacketThoDonChau(account, uint16_2, packetLength);
              }
              else if (uint16_1 == 1200 && GA.CheckGameVersion(account.Target.VersionNum) == 356)
              {
                SmartClass.StripPacket(account, packetLength, readLeftOver, readRealIndex);
                SmartClass.PacketThongThienPhu(account, uint16_2, packetLength);
              }
            }
          }
          account.Myself.PacketReadIndex += (long) num2;
          num1 = account.Myself.PacketWriteIndex - account.Myself.PacketReadIndex;
        }
        else
          flag1 = true;
      }
    }
  }

  public static unsafe void StripPacket(
    AutoAccount account,
    int packetLength,
    int readLeftOver,
    int readRealIndex)
  {
    try
    {
      Array.Clear((Array) account.Target.tempNewPacket, 0, account.Target.tempNewPacket.Length);
      int num1;
      int num2;
      if (packetLength > readLeftOver)
      {
        num1 = readLeftOver;
        num2 = packetLength - readLeftOver;
      }
      else
      {
        num1 = packetLength;
        num2 = 0;
      }
      if (num1 > 0)
      {
        for (int index = readRealIndex; index < readRealIndex + num1; ++index)
          account.Target.tempNewPacket[index - readRealIndex] = account.Target._RingRef[index];
      }
      if (num2 > 0)
      {
        for (int index = 0; index < num2; ++index)
          account.Target.tempNewPacket[index + num1] = account.Target._RingRef[index];
      }
      GA.ByteArrayToString(account.Target.tempNewPacket);
    }
    catch (Exception ex)
    {
      if (!account.Target.HasException)
        GA.WriteUserLog($"Báo ngay GAuto [2]: {ex.Message} Stack: {ex.StackTrace.ToString()}", account);
      account.Target.HasException = true;
    }
  }

  public static void PacketChat(AutoAccount account, int dataLength, int packetLength, int mode = 0)
  {
    string unicode1 = GA.ConvertToUnicode(account.Target.tempNewPacket, 0, packetLength);
    if (account.Target.VersionNum == 7 || account.Target.VersionNum == 8 || account.Target.VersionNum == 5 || account.Target.VersionNum == 6)
    {
      unicode1 = Encoding.GetEncoding("gb2312").GetString(account.Target.tempNewPacket);
      if (unicode1.Contains("您已经被禁言") && GA.isVipMember())
      {
        account.MyFlag.IsBlockedChat = true;
        string midString = GA.GetMidString(unicode1, "剩余", "分钟");
        int result = 0;
        int.TryParse(midString, out result);
        account.MyFlag.BlockChatMinutes = result + 1;
        account.MyFlag.BlockChatStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
        GA.WriteUserLog($"Blocked chat {result.ToString()} minutes", account);
      }
    }
    if (mode == 1)
    {
      try
      {
        int int32 = (int) account.Target.tempNewPacket[7];
        int num1 = 0;
        if (GA.CheckGameVersion(account.Target.VersionNum) == 356)
        {
          num1 = 3;
          int32 = BitConverter.ToInt32(account.Target.tempNewPacket, 7);
        }
        int num2 = 8 + num1;
        byte[] tempArr1 = new byte[260];
        int index1 = 0;
        for (int index2 = num2; index2 < num2 + int32; ++index2)
        {
          tempArr1[index1] = account.Target.tempNewPacket[index2];
          ++index1;
        }
        string unicode2 = GA.ConvertToUnicode(tempArr1, 0, int32);
        int count = (int) account.Target.tempNewPacket[int32 + num2];
        int num3 = int32 + num2 + 1;
        byte[] tempArr2 = new byte[30];
        int index3 = 0;
        for (int index4 = num3; index4 < num3 + count; ++index4)
        {
          tempArr2[index3] = account.Target.tempNewPacket[index4];
          ++index3;
        }
        string unicode3 = GA.ConvertToUnicode(tempArr2, 0, count);
        if (unicode2 == "#cc66422#18#19#26#25#24#13#75#74#83#97#78#77#29")
          account.CallSendMessage(0, "Happy New Year");
        else
          GA.WriteUserLog($"{unicode3}: {unicode2}", account);
      }
      catch (Exception ex)
      {
        GA.WriteUserLog("Lỗi khi xử lý chat", account);
      }
      if (account.Settings.ChatAlert)
      {
        try
        {
          new SoundPlayer("chat.wav").Play();
        }
        catch (Exception ex)
        {
        }
      }
    }
    if (!unicode1.Contains("@*;SrvMsg") || !unicode1.Contains("ang Hồ Tiể") && !unicode1.ToLower().Contains("ang hồ tiể") && !unicode1.ToLower().Contains("ief rai") && !unicode1.ToLower().Contains("thieves"))
      return;
    string str = account.Target.VersionNum != 3 ? GA.GetMidString(unicode1, "#P: Phái #Y", "#P ta đang") : GA.GetMidString(unicode1, ": Ta #Y", "#P đột");
    if (account.Target.SubVersion == 12)
      str = GA.GetMidString(unicode1, ": I'm #Y", "#P sudd");
    if (account.Target.VersionNum == 4)
      str = GA.GetMidString(unicode1, "#Y", "#P A group");
    if (str == "Mộ Dung Thế Gia")
      str = "Mộ Dung";
    account.Settings.AcBaPhai = str;
    account.Settings.AcBaPhaiStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
    if (account.IsPartyKeyInt() != 2 && account.IsPartyKeyInt() != 0)
      return;
    GA.WriteUserLog(frmMain.langABPhaiLog, account, (object) str);
  }

  public static void ProcPacketString(AutoAccount account, int dataLength, int packetLength)
  {
    if (dataLength <= 6 || dataLength >= account.Target.tempNewPacket.Length)
      return;
    string str1 = GA.ConvertToUnicode(account.Target.tempNewPacket, 0, packetLength);
    int num1 = -1;
    int num2 = -1;
    for (int index = 6; index < 6 + dataLength - 2; ++index)
    {
      if (account.Target.tempNewPacket[index] == (byte) 123 && account.Target.tempNewPacket[index - 1] == (byte) 35)
      {
        num1 = index + 1;
        break;
      }
    }
    if (num1 != -1 && num1 < 6 + dataLength)
    {
      for (int index = num1; index < 6 + dataLength; ++index)
      {
        if (account.Target.tempNewPacket[index] == (byte) 125 || account.Target.tempNewPacket[index] == (byte) 42)
        {
          num2 = index - 1;
          break;
        }
      }
    }
    bool flag1 = false;
    if (num1 != -1 && num2 != -1 && num1 < num2 && num2 < packetLength)
    {
      GA.GetMidString(str1, "#{", "}");
      flag1 = true;
    }
    string viscii = GA.ConvertToVISCII(str1);
    if (GA.isVipMember() && account.Settings.cboxDebugLog)
    {
      str1 = str1.Replace("Ầ", "").Replace("Ẵ", "").Replace("Ẳ", "").Replace("Ù", "").Replace("Ố", "").Replace("Ớ", "").Replace("Ữ", "").Replace("Ự", "").Replace("Ẫ", "").Replace("\r", "").Replace("\0", "").Replace("{", "{{").Replace("}", "}}");
      GA.WriteUserLog("packetString: " + str1, account);
    }
    bool flag2 = false;
    if (account.Myself.IsXayDung)
    {
      if (str1.Contains("Nhiệm vụ xây dựng"))
      {
        if (str1.Contains("cướp đi mất,") || viscii.Contains("cß\u00BEp ði m¤t,"))
          account.Myself.PacketMsg = "XDDC";
        else if (str1.Contains("không may đánh mất") || viscii.Contains("không may ðánh m¤t"))
          account.Myself.PacketMsg = "XDMD";
        else if (str1.Contains("cầm đầu đám giang hồ") || viscii.Contains("c¥m ð¥u ðám giang h"))
          account.Myself.PacketMsg = "XDCT";
        else if (str1.Contains("iến triển nh") || viscii.Contains("iªn tri¬n nh"))
          account.Myself.PacketMsg = "XDTQ";
      }
      if (str1.Contains("cần các hạ đi đoạt lại") || viscii.Contains("c¥n các hÕ ði ðoÕt lÕi"))
        account.Myself.PacketMsg = "XDDQ";
    }
    else if (account.Myself.IsLuyenKim)
    {
      if (flag1 && !flag2)
      {
        if (str1.Contains("BHRWSC_110331_22"))
        {
          int index1 = num2 + 5;
          int num3 = 0;
          string s1 = "";
          string s2 = "";
          if (index1 < packetLength)
            num3 = (int) account.Target.tempNewPacket[index1];
          int num4 = index1 + 1;
          if (num4 + num3 < packetLength && num3 <= 4)
          {
            for (int index2 = num4; index2 < num4 + num3; ++index2)
              s1 += (string) (object) (char) account.Target.tempNewPacket[index2];
          }
          int index3 = num4 + num3 + 1;
          if (index3 < packetLength)
            num3 = (int) account.Target.tempNewPacket[index3];
          int num5 = index3 + 1;
          if (num5 + num3 < packetLength && num3 <= 4)
          {
            for (int index4 = num5; index4 < num5 + num3; ++index4)
              s2 += (string) (object) (char) account.Target.tempNewPacket[index4];
          }
          if (s1 != "" && s2 != "")
          {
            int result1 = 0;
            int result2 = 0;
            int.TryParse(s1, out result1);
            int.TryParse(s2, out result2);
            account.Myself.NhiemVuPosX = result1;
            account.Myself.NhiemVuPosY = result2;
          }
        }
        else if (str1.Contains("BHRWSC_110331_75"))
        {
          account.Myself.PacketMsg = "LK";
          account.Myself.NhiemVuPosX = 66;
          account.Myself.NhiemVuPosY = 135;
        }
        else if (str1.Contains("BHRWSC_110331_23"))
          account.Myself.PacketMsg = "DDXR";
        else if (str1.Contains("BHRWSC_110331_156") || str1.Contains("{LJYH_141105_05"))
          account.Myself.PacketMsg = "NNVLK";
        else if (str1.Contains("BHRWSC_110331_174") || str1.Contains("BHRWSC_110331_41"))
          account.Myself.PacketMsg = "LKXQ";
        else if (str1.Contains("LJYH_141105_06"))
          account.Myself.PacketMsg = "HDLKN";
        else if (str1.Contains("DJBHGZ_110511_08"))
          account.Myself.PacketMsg = "HDHD";
        if (str1.Contains("BHXH_RWLQ"))
          account.Myself.PacketMsg = "CTNV";
        if (str1.Contains("BHRWSC_110331_157"))
          account.Myself.PacketMsg = !str1.Contains("BHRWSC_110331_178") ? "NNVL" : "CNBT";
      }
    }
    else if (account.Myself.IsTBB)
    {
      if (str1.Contains("BHCJ_140523_89"))
        account.Myself.PacketMsg = "PTTC";
      else if (str1.Contains("BHCJ_140523_96"))
        account.Myself.PacketMsg = "DPTX";
      else if (str1.Contains("BHCJ_140523_90"))
        account.Myself.PacketMsg = "CNPT";
      else if (str1.Contains("BHCJ_140523_84"))
        account.Myself.PacketMsg = "CDVB";
      else if (str1.Contains("BHCJ_140523_128"))
      {
        account.Myself.PacketMsg = "BBKT";
        account.Myself.NhiemVuFinish = true;
      }
      else if (str1.Contains("BHCJ_140523_193"))
        account.Myself.PacketMsg = "NPTD";
      else if (str1.Contains("BHCJ_140523_105"))
        account.Myself.PacketMsg = "NPTR";
      else if (str1.Contains("BHCJ_140523_103"))
        account.Myself.PacketMsg = "CKTBB";
    }
    else if (account.Myself.IsTuDuongCon && account.Myself.QuestStep == 1)
    {
      if (str1.Contains("SXPY_130826_"))
      {
        account.PacketInfoGetPos(str1);
        if (account.Settings.cboTuDuongCon == 3)
        {
          if (str1.Contains("Toàn Tiểu Nhan") || viscii.Contains("Toàn Ti¬u Nhan"))
            account.Myself.PacketMsg = "QCTTN";
          else if (str1.Contains("Tào Tiểu Minh") || viscii.Contains("Tào Ti¬u Minh"))
            account.Myself.PacketMsg = "QCTTM";
          else if (str1.Contains("Lục Tiểu Kỳ") || viscii.Contains("Løc Ti¬u KÏ"))
            account.Myself.PacketMsg = "QCLTK";
        }
      }
    }
    else if (account.Myself.IsTKC)
    {
      if (str1.Contains("CJG_090413_26") || str1.Contains("hết Mông Diệ"))
        account.Myself.PacketMsg = "KTTKC";
    }
    else if (account.Myself.IsTrungAc)
    {
      if (account.Target.VersionNum == 4)
      {
        if (str1.Contains("Punishment Order can on"))
        {
          int result3 = 0;
          int result4 = 0;
          int num6 = -1;
          string midString1 = GA.GetMidString(str1, "[", "]");
          if (midString1 != "")
          {
            string[] strArray = midString1.Split(',');
            if (strArray.Length >= 2)
            {
              int.TryParse(strArray[0], out result3);
              int.TryParse(strArray[1], out result4);
            }
          }
          string midString2 = GA.GetMidString(str1, "used at", "[");
          if (midString2 != "")
          {
            string str2 = midString2.Trim(' ');
            if (frmLogin.GAuto.MapDBs.Count > 0)
            {
              foreach (MapDBElement mapDb in frmLogin.GAuto.MapDBs)
              {
                if (mapDb.MapName == str2)
                {
                  num6 = mapDb.MapID;
                  break;
                }
              }
            }
          }
          if (result3 > 0 && result4 > 0 && num6 > -1 && account.Myself != null)
          {
            account.Myself.NhiemVuPosX = result3;
            account.Myself.NhiemVuPosY = result4;
            account.Myself.NhiemVuMapID = num6;
            account.Myself.PacketMsg = "TAREADY";
          }
        }
      }
      else if (str1.Contains("DTYH_121009_18"))
      {
        string midString = GA.GetMidString(str1, "*", "}", 3);
        if (midString != "")
        {
          string[] strArray = midString.Split('*');
          if (strArray.Length >= 3)
          {
            strArray[strArray.Length - 3] = strArray[strArray.Length - 3].Substring(1, strArray[strArray.Length - 3].Length - 1);
            strArray[strArray.Length - 2] = strArray[strArray.Length - 2].Substring(1, strArray[strArray.Length - 2].Length - 1);
            strArray[strArray.Length - 1] = strArray[strArray.Length - 1].Substring(1, strArray[strArray.Length - 1].Length - 1);
            int result5 = 0;
            int result6 = 0;
            int result7 = -1;
            int.TryParse(strArray[strArray.Length - 3], out result5);
            int.TryParse(strArray[strArray.Length - 2], out result6);
            int.TryParse(strArray[strArray.Length - 1], out result7);
            if (result5 > 0 && result6 > 0 && result7 != -1 && account.Myself != null)
            {
              account.Myself.NhiemVuPosX = result5;
              account.Myself.NhiemVuPosY = result6;
              account.Myself.NhiemVuMapID = result7;
              account.Myself.PacketMsg = "TAREADY";
            }
          }
        }
      }
    }
    else if (account.Myself.isBachHoaDuyen)
    {
      if (str1.Contains("SDHDRW"))
        account.Myself.PacketMsg = "NVBHD";
      if (account.Myself.NhiemVuType == 4 && str1.Contains("10/10"))
        account.Myself.PacketMsg = "NDDR";
      if (str1.Contains("SDHDRW_091109_10"))
        account.Myself.NhiemVuType = 1;
      else if (str1.Contains("SDHDRW_091109_17"))
        account.Myself.NhiemVuType = 2;
      else if (str1.Contains("SDHDRW_091109_09"))
        account.Myself.NhiemVuType = 3;
      else if (str1.Contains("SDHDRW_091109_03"))
        account.Myself.NhiemVuType = 4;
      else if (str1.Contains("SDHDRW_091109_07"))
        account.Myself.NhiemVuType = 5;
    }
    else if (account.Myself.isQSM)
    {
      if (str1.Contains("ụ Sư Mô"))
      {
        if (str1.Contains("ạc đãi n"))
          account.Myself.NhiemVuType = 1;
        else if (str1.Contains("ắt cho t"))
        {
          account.Myself.NhiemVuType = 2;
          str1 = str1.Replace("  ", " ");
          account.Myself.NhiemVuString1 = GA.GetMidString(str1, "con", "về");
          account.Myself.NhiemVuString1 = account.Myself.NhiemVuString1.Trim();
        }
        else if (str1.Contains("Bổ câu đưa thư"))
          account.Myself.NhiemVuType = 3;
        else if (str1.Contains("âu lắm k"))
        {
          account.Myself.NhiemVuType = 4;
          account.Myself.NhiemVuString1 = GA.GetMidString(str1, "gặp", ", ngươi");
          account.Myself.NhiemVuString1 = account.Myself.NhiemVuString1.Replace("Tô Châu", "");
          account.Myself.NhiemVuString1 = account.Myself.NhiemVuString1.Replace("Lạc Dương", "");
          account.Myself.NhiemVuString1 = account.Myself.NhiemVuString1.Replace("Đại Lý", "");
          account.Myself.NhiemVuString1 = account.Myself.NhiemVuString1.Replace("  ", " ");
          account.Myself.NhiemVuString1 = account.Myself.NhiemVuString1.Trim();
        }
        else if (str1.Contains("ơi hãy ở "))
          account.Myself.NhiemVuType = 5;
        else if (str1.Contains("iúp ta ki"))
        {
          account.Myself.NhiemVuType = 6;
          str1 = str1.Replace("  ", " ");
          account.Myself.NhiemVuString1 = GA.GetMidString(str1, "5", "về");
          account.Myself.NhiemVuString1 = account.Myself.NhiemVuString1.Trim();
        }
        else if (str1.Contains("SMFB_") || str1.Contains("TMSM_130808_"))
          account.Myself.NhiemVuType = 7;
      }
      if (str1.Contains("ất cần thi"))
        account.Myself.PacketMsg = "SMXQ";
      if (str1.Contains("ong 15 ph"))
        account.Myself.PacketMsg = "SM15M";
    }
    else if (account.Myself.isCauPhuc)
    {
      if (str1.Contains("TGQF_XML_47"))
        account.Myself.PacketMsg = "CPID1";
      else if (str1.Contains("TGQF_XML_48"))
        account.Myself.PacketMsg = "CPID2";
      else if (str1.Contains("TGQF_100111_53"))
        account.Myself.PacketMsg = "CPTC";
    }
    else if (account.Myself.isCauNguyen)
    {
      if (str1.Contains("XML_570") || str1.Contains("BHRW_081124_01") || str1.Contains("SQXY_09061_19"))
        account.Myself.PacketMsg = "CNNQ";
      else if (str1.Contains("YLQ_091229_1}"))
        account.Myself.PacketMsg = "KTCN";
      else if (str1.Contains("SQXY_09061_21"))
        account.Myself.PacketMsg = "CNTQOK";
      else if (str1.Contains("SQXY_09061_7"))
        account.Myself.PacketMsg = "HLCN";
    }
    else if (account.Myself.isDoatBaoRuong && str1.Contains("YDBX_151028_09"))
      account.Myself.PacketMsg = "DBRW";
    if (account.Myself.isTrongHoa || account.Myself.isBonHoa)
    {
      if (str1.Contains("SDJZH_091106_18"))
        account.Myself.PacketMsg = "HCTH";
      if (str1.Contains("SDJZH_091106_21"))
        account.Myself.PacketMsg = "HDBR";
    }
    if (account.Myself.isThuHoach)
    {
      if (str1.Contains("SDJZH_091106_08") && str1.Contains("SDJZH_091106_09"))
      {
        string midString = GA.GetMidString(str1, "08}", "#{S");
        account.Myself.PacketMsg = "Time:" + midString;
      }
    }
    else if (account.Myself.IsQ1 || account.Myself.IsQ2)
    {
      if ((str1.Contains("ã hoàn th") || str1.Contains("finish")) && account.Myself.MapID == 1)
      {
        account.MyFlag.xongQstamp = 0L;
        if (account.Myself.IsQ1)
        {
          ++account.MyFlag.dietgonCounter;
          GA.WriteUserLog(frmMain.langFinishedXRoundQ1, account, (object) account.MyFlag.dietgonCounter);
        }
        else if (account.Myself.IsQ2)
        {
          ++account.MyFlag.truhaiCounter;
          GA.WriteUserLog(frmMain.langFinishedXRoundQ2, account, (object) account.MyFlag.truhaiCounter);
        }
      }
      if (str1.Contains("uay lại nhậ"))
        account.Myself.PacketMsg = "NVFQ";
      else if (str1.Contains("ITEM40004315}"))
        account.Myself.PacketMsg = "CDDLB";
      if (account.Myself.IsQ1)
      {
        if (str1.Contains("ng Quân Đô Thống: 1/1") || str1.Contains("ear Knight: 1/1"))
          account.Myself.PacketMsg = "DDQDT";
        else if (str1.Contains("ng binh: 50/50") || str1.Contains("ong Soldier: 50/50"))
          account.Myself.PacketMsg = "DXNTB";
        else if (str1.Contains("ộc: 1/1") || str1.Contains("ider Yu: 1/1"))
          account.Myself.PacketMsg = "TDDD";
        if (str1.Contains("oại: 10/10") || str1.Contains("ng Gangsters: 10/10"))
          account.Myself.PacketMsg = "DDPL";
      }
      if (account.Myself.IsQ2)
      {
        if (str1.Contains("ùng: 80/80") || str1.Contains("d Bear: 80/80"))
          account.Myself.PacketMsg = "DDDH";
        else if (str1.Contains("ơng: 1/1") || str1.Contains("ar King: 1/1"))
          account.Myself.PacketMsg = "DDHV";
      }
    }
    else if (account.Myself.isYTO)
    {
      if (str1.Contains("hủ hạ") && str1.Contains("n Diê") || str1.Contains("ruel Tuan defea"))
        account.Myself.PacketMsg = "TDDDK";
      else if (str1.Contains("ao thủ v") && str1.Contains("hản tặ") || str1.Contains("zhan_yzw_003") || str1.Contains("rotect Captain Chi"))
        account.Myself.PacketMsg = "XQTTR";
      else if (str1.Contains("bại") && str1.Contains("u Ma Tr") || str1.Contains("hiskered was def"))
        account.Myself.PacketMsg = "TDCMT";
      else if (str1.Contains("còn lại") || str1.Contains("tiến đến") && str1.Contains("iện quân") || str1.Contains("times left"))
        account.Myself.PacketMsg = "NCTHVR";
      else if (str1.Contains("zhan_yzw_006"))
        account.Myself.PacketMsg = "DCTXR";
      else if (str1.Contains("ộ Dung P") && str1.Contains("bại") || str1.Contains("Fu Rong") && str1.Contains("defe"))
        account.Myself.PacketMsg = "TDMDP";
    }
    else if (account.Myself.IsKyCuoc)
    {
      if (str1.Contains("200/200"))
        account.Myself.PacketMsg = "KCXQ";
      else if (str1.Contains("hoàn thành") || str1.Contains("finish"))
        account.Myself.PacketMsg = "KCKT";
    }
    else if (account.Myself.isLLTB)
    {
      if (str1.Contains("200/200"))
        account.Myself.PacketMsg = "TBXQ";
      else if (str1.Contains("hoàn thành") || str1.Contains("finish"))
        account.Myself.PacketMsg = "TBKT";
    }
    else if (account.Myself.isDoiKimTamTi)
    {
      if (str1.Contains("MGZL_130117_03"))
        account.Myself.PacketMsg = "D5KTT";
      else if (str1.Contains("MGZL_130117_02"))
        account.Myself.PacketMsg = "CKTT";
      else if (str1.Contains("MGZL_130117_05"))
        account.Myself.PacketMsg = "KTTTC";
    }
    else if (account.Myself.isDoiChiTonCH)
    {
      if (str1.Contains("YWBOSS_140117_09"))
        account.Myself.PacketMsg = "CDMD";
      else if (str1.Contains("YWBOSS_140117_15"))
        account.Myself.PacketMsg = "CCTCH";
      else if (str1.Contains("YWBOSS_140117_19"))
        account.Myself.PacketMsg = "DCTTC";
    }
    else if (account.Myself.isThuTaiVanMay)
    {
      if (str1.Contains("m nay") && str1.Contains("ham gia"))
        account.Myself.PacketMsg = "TTVMR";
      else if (str1.Contains("XYLP_20071222_08"))
        account.Myself.PacketMsg = "TTPC";
    }
    else if (account.Myself.isThienLongTueHong)
    {
      if (str1.Contains("QNG_090716_05"))
        account.Myself.PacketMsg = "HNHR";
      else if (str1.Contains("QNG_090716_14") || str1.Contains("QNG_090716_09") || str1.Contains("QNG_090716_19"))
        account.Myself.PacketMsg = "CTNV";
      else if (str1.Contains("M_MUBIAO"))
        account.Myself.PacketMsg = "CNNV";
      else if (str1.Contains("QNG_090716_02"))
        account.Myself.PacketMsg = "NVTTH";
    }
    else if (account.Myself.isNguHanhPhapThiep)
    {
      if (str1.Contains("hận đư") || str1.Contains("DRFB_130111_254"))
        account.Myself.PacketMsg = "DNXR";
    }
    else if (account.Myself.isLoLyHoa)
    {
      if (str1.Contains("LHLL_130624_33"))
        account.Myself.PacketMsg = "DCXR";
      else if (str1.Contains("LHLL_130624_50"))
        account.Myself.PacketMsg = "LDTC";
    }
    else if (account.Myself.isDoiKimTinhThach)
    {
      if (str1.Contains("LHLL_130624_25"))
        account.Myself.PacketMsg = "HDDR";
      else if (str1.Contains("LHLL_130624_27"))
        account.Myself.PacketMsg = "DKTC";
    }
    else if (account.Myself.isBuonDuaHau)
    {
      if (str1.Contains("_140521_2"))
        account.Myself.PacketMsg = "DLBM";
    }
    else if (account.Myself.isDoiThoiVang)
    {
      if (str1.Contains("hành côn"))
        account.Myself.PacketMsg = "TDTC";
      else if (str1.Contains("ng mang "))
        account.Myself.PacketMsg = "TDTB";
    }
    else if (account.Myself.IsCheDo)
    {
      if (str1.Contains("n nguyên liệu ch") || str1.Contains("ần ít nhấ"))
        account.Myself.PacketMsg = "TDTC";
    }
    else if (account.Myself.isDoiLinhHonToaiPhien)
    {
      if (str1.Contains("hành côn"))
        account.Myself.PacketMsg = "TDTC";
      else if (str1.Contains(" không "))
        account.Myself.PacketMsg = "TDTB";
    }
    else if (account.Myself.isDoiPhieuTienVang)
    {
      if (str1.Contains("hành côn"))
        account.Myself.PacketMsg = "TDTC";
      else if (str1.Contains("hông đ"))
        account.Myself.PacketMsg = "TDTB";
    }
    else if (account.Myself.isDoiThanBinhPhu)
    {
      if (str1.Contains("hành côn"))
        account.Myself.PacketMsg = "TDTC";
      else if (str1.Contains("hông có"))
        account.Myself.PacketMsg = "TDTB";
    }
    else if (account.Myself.isPMP)
    {
      if (str1.Contains("u sau ") || str1.Contains("chiến đấu"))
        account.Myself.PacketMsg = "CDBD";
      else if (str1.Contains("XPMCZ_081108_1"))
        account.Myself.PacketMsg = "HLSC";
      else if (str1.Contains(" Thu Thu"))
        account.Myself.PacketMsg = "DLTT";
      else if (str1.Contains("kinh nghiệm") && account.Myself.InPathPointIndex >= 12)
        account.Myself.PacketMsg = "DXPB";
    }
    else if (account.Myself.isThuyLao)
    {
      if (str1.Contains("hủy trại tì"))
        account.Myself.PacketMsg = "CNNV";
      else if (str1.Contains("hận nhiệm v") || str1.Contains("ao chưa"))
        account.Myself.PacketMsg = "DNTL";
      else if (str1.Contains("10/60"))
        account.Myself.PacketMsg = "KTTL";
    }
    else if (account.Myself.isThuBiChienMinh)
    {
      if (str1.Contains("MZPVE_150812_467") || str1.Contains("MZPVE_150812_463") || str1.Contains("MZPVE_150812_2271") || str1.Contains("MZPVE_150812_1036") || str1.Contains("MZPVE_150812_1413") || str1.Contains("MZPVE_150812_2160"))
        account.PacketInfoGetXY(str1);
      else if (!str1.Contains("MZPVE_150812_1044}"))
      {
        if (str1.Contains("MZPVE_150812_473}") || str1.Contains("MZPVE_150812_255}") || str1.Contains("MZPVE_150812_200}") || str1.Contains("MZPVE_150812_395}") || str1.Contains("MZPVE_150812_1791}") || str1.Contains("MZPVE_150812_1661}") || str1.Contains("MZPVE_150812_1741}") || str1.Contains("MZPVE_150812_1631}") || str1.Contains("MZPVE_150812_912}") || str1.Contains("MZPVE_150812_1041}") || str1.Contains("MZPVE_150812_991}") || str1.Contains("MZPVE_150812_883}") || str1.Contains("MZPVE_150812_1287}") || str1.Contains("MZPVE_150812_1417}") || str1.Contains("MZPVE_150812_1257}") || str1.Contains("MZPVE_150812_1367}") || str1.Contains("MZPVE_150812_2034}") || str1.Contains("MZPVE_150812_2165}") || str1.Contains("MZPVE_150812_2115}") || str1.Contains("MZPVE_150812_2004}"))
          account.Myself.PacketMsg = "XQTB";
        else if (str1.Contains("MZPVE_150812_258") || str1.Contains("MZPVE_150812_1664") || str1.Contains("MZPVE_150812_915") || str1.Contains("MZPVE_150812_1290") || str1.Contains("MZPVE_150812_2037"))
          account.PacketInfoGetXY(str1);
        else if (str1.Contains("MZPVE_150812_259}") || str1.Contains("MZPVE_150812_1665}") || str1.Contains("MZPVE_150812_916}") || str1.Contains("MZPVE_150812_1291}") || str1.Contains("MZPVE_150812_2038}"))
          account.Myself.PacketMsg = "XHTGR";
        else if (str1.Contains("MZPVE_150812_43}"))
          account.Myself.PacketMsg = "HQTB";
        else if (str1.Contains("MZPVE_150812_45}"))
          account.Myself.PacketMsg = "DNTB";
        else if (str1.Contains("MZPVE_150812_381"))
        {
          string midString = GA.GetMidString(str1, "*", "}");
          if (midString.Contains("ơn Khu"))
            account.Myself.PacketMsg = "38001371";
          else if (midString.Contains("ạt Huyề"))
            account.Myself.PacketMsg = "38001370";
          else if (midString.Contains("à Nư"))
            account.Myself.PacketMsg = "38001369";
          else if (midString.Contains("im Trả"))
            account.Myself.PacketMsg = "38001368";
          else if (midString.Contains("ơng B"))
            account.Myself.PacketMsg = "38001367";
        }
        else if (str1.Contains("MZPVE_150812_1733"))
        {
          string midString = GA.GetMidString(str1, "*", "}");
          if (midString.Contains("ồng Ngu"))
            account.Myself.PacketMsg = "38001421";
          else if (midString.Contains("hiết Ngu"))
            account.Myself.PacketMsg = "38001422";
          else if (midString.Contains("im Ngu"))
            account.Myself.PacketMsg = "38001423";
          else if (midString.Contains("ích Ngu"))
            account.Myself.PacketMsg = "38001424";
          else if (midString.Contains("hái Ngu"))
            account.Myself.PacketMsg = "38001425";
        }
        else if (str1.Contains("MZPVE_150812_984"))
        {
          string midString = GA.GetMidString(str1, "*", "}");
          if (midString.Contains("m Cắt C"))
            account.Myself.PacketMsg = "38001401";
          else if (midString.Contains("Chổi"))
            account.Myself.PacketMsg = "38001402";
          else if (midString.Contains("ến Tế T"))
            account.Myself.PacketMsg = "38001403";
          else if (midString.Contains("ch Hợp H"))
            account.Myself.PacketMsg = "38001404";
          else if (midString.Contains("iện Th"))
            account.Myself.PacketMsg = "38001405";
        }
        else if (str1.Contains("MZPVE_150812_1359"))
        {
          string midString = GA.GetMidString(str1, "*", "}");
          if (midString.Contains("ăng Ng"))
            account.Myself.PacketMsg = "38001411";
          else if (midString.Contains("ồng Ng"))
            account.Myself.PacketMsg = "38001412";
          else if (midString.Contains("uỷ Ng"))
            account.Myself.PacketMsg = "38001413";
          else if (midString.Contains("ồi Câu"))
            account.Myself.PacketMsg = "38001414";
          else if (midString.Contains("gư Đườ"))
            account.Myself.PacketMsg = "38001415";
        }
        else if (str1.Contains("MZPVE_150812_2107"))
        {
          string midString = GA.GetMidString(str1, "*", "}");
          if (midString.Contains("yết Thi"))
            account.Myself.PacketMsg = "38001431";
          else if (midString.Contains("anh Đồ"))
            account.Myself.PacketMsg = "38001432";
          else if (midString.Contains("húy Ng"))
            account.Myself.PacketMsg = "38001433";
          else if (midString.Contains("àn Thi"))
            account.Myself.PacketMsg = "38001434";
          else if (midString.Contains("ồng Đồ"))
            account.Myself.PacketMsg = "38001435";
        }
        else if (str1.Contains("MZPVE_150812_2319}") || str1.Contains("MZPVE_150812_2322}") || str1.Contains("MZPVE_150812_2320}") || str1.Contains("MZPVE_150812_2321}") || str1.Contains("MZPVE_150812_2323}"))
          account.Myself.PacketMsg = "DDTV";
      }
    }
    if (account.Myself.MapID == 1)
    {
      if (GA.CalculateDistance((double) account.Myself.PosX, (double) account.Myself.PosY, 133.0, 260.0) <= 10.0)
      {
        if (str1.Contains("ất ti") && str1.Contains("hất b"))
          account.Myself.PacketMsg = "NVTB";
        else if (str1.Contains("àm thế nà") || str1.Contains("ou do this missio"))
          account.Myself.PacketMsg = "DGXQ";
      }
      if (GA.CalculateDistance((double) account.Myself.PosX, (double) account.Myself.PosY, 353.0, 203.0) <= 10.0)
      {
        if (str1.Contains("ất ti") && str1.Contains("hất b") || str1.Contains("on was failed"))
          account.Myself.PacketMsg = "NVTB";
        else if (str1.Contains("àm thế nà") || str1.Contains("ou do this missio") || str1.Contains("your mission"))
          account.Myself.PacketMsg = "DGXQ";
      }
    }
    if (account.Target.VersionNum == 3 && account.Target.SubVersion == 4 && GA.isInCity(account.Myself.MapID) && str1.Contains("- Tô Châu") && str1.Contains("- Thiết tường phố"))
      account.Myself.PacketMsg = "MNKC";
    if (str1.Contains("QZDZ_100715_05") || str1.Contains("CLCZ_101207_09"))
    {
      lock (account.Myself.JustWarpedLock)
      {
        account.Myself.WarpStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
        account.Myself.JustWarped = true;
        account.Myself.JustWarpedStamp.Reset();
        account.Myself.JustWarpedStamp.Start();
        account.SetJustWarpedFlag(1);
      }
    }
    if ((str1.Contains("ội hữu củ") || viscii.Contains("µi hæu cü") || str1.Contains("ãy tập t") || viscii.Contains("ãy t§p t")) && account.IsPartyKey())
    {
      account.CallRemovePartyFollow();
      GA.TrieuTapCaNhom(account, true);
    }
    if (!GA.isShitMember() || new Random().Next(0, 10000) > 7000)
      return;
    account.Myself.PacketMsg = "";
  }

  public static void ProcPacket006B(AutoAccount account, int dataLength, int packetLength)
  {
    byte num1 = account.Target.tempNewPacket[10];
    int num2 = 16 /*0x10*/;
    int num3 = (int) account.Target.tempNewPacket[12];
    if (!account.Myself.IsMuaKNB || num1 <= (byte) 0)
      return;
    for (int index = 0; index < (int) num1; ++index)
    {
      int num4 = (int) account.Target.tempNewPacket[num2 + 5];
      int int32 = BitConverter.ToInt32(account.Target.tempNewPacket, num2 + 9);
      bool flag = false;
      if (int32 <= account.Myself.CurrentGold)
      {
        if (int32 <= account.Settings.txtKNB50 && account.Settings.txtKNB50 > 0 && num4 == 50)
          flag = true;
        if (!flag && int32 <= account.Settings.txtKNB200 && account.Settings.txtKNB200 > 0 && num4 == 200)
          flag = true;
        if (!flag && int32 <= account.Settings.txtKNB500 && account.Settings.txtKNB500 > 0 && num4 == 500)
          flag = true;
      }
      if (flag)
      {
        account.Myself.KNBStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
        break;
      }
      num2 += 17;
    }
  }

  public static void PacketAiDanhAiDo(AutoAccount account, int dataLength, int packetLength)
  {
    if (account.Myself == null || account.MyQuai == null || account.MyPet == null || dataLength != 15 && (dataLength != 24 || account.Target.VersionNum != 3) && (dataLength != 24 || account.Target.VersionNum != 4))
      return;
    int int32_1 = BitConverter.ToInt32(account.Target.tempNewPacket, 6);
    int int32_2 = BitConverter.ToInt32(account.Target.tempNewPacket, 16 /*0x10*/);
    if (BitConverter.ToInt16(account.Target.tempNewPacket, 14) == (short) 1016)
    {
      account.MyFlag.MDPPlayDCTD = frmLogin.GlobalTimer.ElapsedMilliseconds;
      account.CallAttackTarget(-1, 34, 0, 0);
      int khinhCongId = account.GetKhinhCongID();
      account.CallAttackTarget(-1, khinhCongId, 0, 0);
      if (frmLogin.GlobalTimer.ElapsedMilliseconds - account.MyFlag.MDPPlayDCTD >= 60000L && account.MyFlag.MDPPlayDCTD > 0L)
        account.MyFlag.MDPPlayDCTD = 0L;
    }
    if (int32_1 == 0)
      return;
    bool flag1 = false;
    bool flag2 = false;
    if (account.Myself.ID == int32_1)
      flag1 = true;
    if (account.Myself.MyAttackerID == int32_1)
    {
      account.Myself.AttackedID = int32_2;
      account.Myself.AttackedIDStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
    }
    if (!flag1 && account.MyPet.ActivePetID == int32_1)
      flag2 = true;
    if (!flag2 && !flag1 || int32_2 < 0 || account.MyQuai.AllQuai.Count <= 0)
      return;
    for (int index = account.MyQuai.AllQuai.Count - 1; index >= 0; --index)
    {
      if (account.MyQuai.AllQuai[index].ID == int32_2)
      {
        try
        {
          account.MyQuai.AllQuai[index].JustHit = (byte) 1;
          account.MyQuai.AllQuai[index].LastHitStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
        }
        catch (Exception ex)
        {
        }
        account.MyQuai.AllQuai[index].LastTimeSeen = frmLogin.GlobalTimer.ElapsedMilliseconds;
        break;
      }
    }
  }

  public static void PacketBocDetails(AutoAccount account, int dataLength, int packetLength)
  {
    int int32_1 = BitConverter.ToInt32(account.Target.tempNewPacket, 6);
    int num = (int) account.Target.tempNewPacket[10];
    if (account.MyBoc == null || int32_1 == 0)
      return;
    account.MyBoc.TotalItems = num;
    account.MyBoc.ActiveBocID = int32_1;
    account.MyBoc.LastTimeSeen = frmLogin.GlobalTimer.ElapsedMilliseconds;
    int sourceIndex = 11;
    int startIndex = sourceIndex + 57;
    int int32_2 = BitConverter.ToInt32(account.Target.tempNewPacket, 13);
    account.MyBoc.AllItems.Clear();
    for (int index = 0; index < num; ++index)
    {
      bool flag = false;
      while (!flag)
      {
        if (startIndex <= packetLength - 4)
        {
          int int32_3 = BitConverter.ToInt32(account.Target.tempNewPacket, startIndex);
          if (int32_3 == int32_2 || GA.CheckGameVersion(account.Target.VersionNum) == 356 && int32_3 == int32_2 + index + 1)
            flag = true;
          else
            ++startIndex;
        }
        else
        {
          ++startIndex;
          flag = true;
        }
      }
      Array.Clear((Array) account.Target.bocTempItemData, 0, account.Target.bocTempItemData.Length);
      Array.Copy((Array) account.Target.tempNewPacket, sourceIndex, (Array) account.Target.bocTempItemData, 0, startIndex - sourceIndex);
      sourceIndex = startIndex;
      startIndex = sourceIndex + 57;
      int int32_4 = BitConverter.ToInt32(account.Target.bocTempItemData, 2);
      int int32_5 = BitConverter.ToInt32(account.Target.bocTempItemData, 6);
      int int32_6 = BitConverter.ToInt32(account.Target.bocTempItemData, 10);
      if (index > 0)
      {
        int32_4 = BitConverter.ToInt32(account.Target.bocTempItemData, 0);
        int32_5 = BitConverter.ToInt32(account.Target.bocTempItemData, 4);
        int32_6 = BitConverter.ToInt32(account.Target.bocTempItemData, 8);
      }
      account.MyBoc.TotalItems = num;
      account.MyBoc.ActiveBocID = int32_1;
      ItemTrongBoc itemTrongBoc = new ItemTrongBoc();
      itemTrongBoc.itemGUID1 = int32_4;
      itemTrongBoc.itemGUID2 = int32_5;
      itemTrongBoc.ItemID = int32_6;
      account.MyBoc.LastTimeSeen = frmLogin.GlobalTimer.ElapsedMilliseconds;
      account.MyBoc.AllItems.Add(itemTrongBoc);
    }
  }

  public static void PacketPartyRequestFollow(
    AutoAccount account,
    int dataLength,
    int packetLength)
  {
    if (dataLength != 0 || account.Myself == null)
      return;
    account.Myself.FlagPartyFollowRequest = (byte) 1;
  }

  public static void PacketPartyInvite(AutoAccount account, int dataLength, int packetLength)
  {
    if (account.MyParty == null)
      return;
    int int32 = BitConverter.ToInt32(account.Target.tempNewPacket, 6);
    int num1 = 0;
    if (GA.CheckGameVersion(account.Target.VersionNum) == 356)
    {
      num1 = 4;
      account.MyParty.InviterDBLow = BitConverter.ToInt32(account.Target.tempNewPacket, 10);
    }
    int num2 = account.Target.VersionNum == 3 || account.Target.VersionNum == 4 ? (int) account.Target.tempNewPacket[40] : (int) account.Target.tempNewPacket[42 + num1];
    int num3 = (int) account.Target.tempNewPacket[44 + num1];
    if (account.Target.VersionNum == 3 || account.Target.VersionNum == 4)
      num3 = (int) account.Target.tempNewPacket[42];
    int num4 = 44 + num3 + 7;
    if (account.Target.VersionNum == 3 || account.Target.VersionNum == 4)
      num4 = 42 + num3 + 7;
    int num5 = (int) account.Target.tempNewPacket[num4 + num1];
    account.MyParty.InviterDB = int32;
    account.MyParty.LastTimeSeenInvite = frmLogin.GlobalTimer.ElapsedMilliseconds;
    account.MyParty.PartyCount = num2;
    account.MyParty.InviterLevel = num5;
    int count = 0;
    byte[] tempArr = new byte[30];
    int num6 = 10 + num1;
    for (int index = num6; index < 40 && account.Target.tempNewPacket[index] != (byte) 0; ++index)
    {
      tempArr[index - num6] = account.Target.tempNewPacket[index];
      ++count;
    }
    account.MyParty.Name = GA.ConvertToUnicode(tempArr, 0, count);
  }

  public static void PacketStuckAlert(AutoAccount account, int dataLength, int packetLength)
  {
    if (account.Myself == null)
      return;
    try
    {
      if (BitConverter.ToInt32(account.Target.tempNewPacket, 6) != account.Myself.ID)
        return;
      float single1;
      float single2;
      if (account.Target.VersionNum == 3)
      {
        single1 = BitConverter.ToSingle(account.Target.tempNewPacket, 10);
        single2 = BitConverter.ToSingle(account.Target.tempNewPacket, 14);
      }
      else if (GA.CheckGameVersion(account.Target.VersionNum) == 356)
      {
        single1 = BitConverter.ToSingle(account.Target.tempNewPacket, 15);
        single2 = BitConverter.ToSingle(account.Target.tempNewPacket, 19);
      }
      else
      {
        single1 = BitConverter.ToSingle(account.Target.tempNewPacket, 12);
        single2 = BitConverter.ToSingle(account.Target.tempNewPacket, 16 /*0x10*/);
      }
      if ((double) account.Myself.Last10SecX == (double) single1 && (double) account.Myself.Last10SecY == (double) single2)
      {
        account.Myself.flagMoveStuck = true;
        account.Myself.flagMoveStuckStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
        account.Myself.Last10SecXYStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
      }
      if ((double) account.Myself.Last10SecX == (double) single1 && (double) account.Myself.Last10SecY == (double) single2)
        return;
      account.Myself.Last10SecX = single1;
      account.Myself.Last10SecY = single2;
      account.Myself.Last10SecXYStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
    }
    catch (Exception ex)
    {
      if (!account.Target.HasException)
        GA.WriteUserLog($"{frmMain.langReportGAuto3}{ex.Message} Stack: {ex.StackTrace.ToString()}", account);
      account.Target.HasException = true;
    }
  }

  public static void PacketQuaiAppear(AutoAccount account, int dataLength, int packetLength)
  {
    if (account.MyQuai == null)
      return;
    int int32 = BitConverter.ToInt32(account.Target.tempNewPacket, 7);
    if (account.Target.VersionNum == 3 || account.Target.VersionNum == 4 || account.Target.VersionNum == 5 || account.Target.VersionNum == 6)
      int32 = BitConverter.ToInt32(account.Target.tempNewPacket, 6);
    if (int32 < 0)
      return;
    if (dataLength >= 84)
    {
      int count = -1;
      int num1 = -1;
      int num2 = -1;
      int attackByte = -1;
      if (account.Target.VersionNum == 3 || account.Target.VersionNum == 4)
      {
        count = (int) account.Target.tempNewPacket[22];
        int num3 = 22 + count;
        num1 = 23;
        num2 = (int) account.Target.tempNewPacket[num3 + 4];
        attackByte = (int) account.Target.tempNewPacket[num3 + 49];
      }
      if (GA.CheckGameVersion(account.Target.VersionNum) == 356)
      {
        count = (int) account.Target.tempNewPacket[29];
        int num4 = 29 + count;
        num1 = 30;
        num2 = (int) account.Target.tempNewPacket[num4 + 4];
        attackByte = (int) account.Target.tempNewPacket[num4 + 49 + 11];
      }
      if (account.Target.VersionNum == 7 || account.Target.VersionNum == 8)
      {
        count = (int) account.Target.tempNewPacket[29];
        num1 = 30;
        int num5 = 29 + count;
        num2 = (int) account.Target.tempNewPacket[num5 + 4 + 3];
        attackByte = (int) account.Target.tempNewPacket[num5 + 49 + 11 + 3];
      }
      byte[] tempArr = new byte[260];
      int index1 = 0;
      for (int index2 = num1; index2 < num1 + count; ++index2)
      {
        tempArr[index1] = account.Target.tempNewPacket[index2];
        ++index1;
      }
      string unicode = GA.ConvertToUnicode(tempArr, 0, count);
      // hoint: pk ne
      if (!account.CanAttackCheckValue(attackByte))
        return;
      if (account.Settings.cboxDanhQuai && account.IsAIEnabled && !account.Myself.IsPK && !GA.IsInPhuBan(account.Myself.MapID, account) && account.Myself.Status != AllEnums.CharStatuses.GOGOGO && account.Myself.Status != AllEnums.CharStatuses.NMBUFFMAU && account.Myself.Status != AllEnums.CharStatuses.NHATBOC && (account.Settings.FightMode == AllEnums.FightingModes.DANHGOMQUAI || account.MyQuai.AllQuai.Count <= 1) && account.Myself.ActionStatus != (byte) 5 && (account.Settings.AIMode == AllEnums.AIModes.DANHQUANHDIEM || account.Settings.AIMode == AllEnums.AIModes.DANHTUDO))
      {
        bool flag = true;
        if (account.Settings.QuaiNoAttackList.Count > 0)
        {
          for (int index3 = 0; index3 < account.Settings.QuaiNoAttackList.Count; ++index3)
          {
            if (unicode == account.Settings.QuaiNoAttackList[index3])
            {
              flag = false;
              break;
            }
          }
        }
        if ((account.Target.VersionNum == 1 || account.Target.VersionNum == 2) && account.Myself.OnlineTime < 20000)
          flag = false;
        if (account.Myself.IDLEStamp - frmLogin.GlobalTimer.ElapsedMilliseconds > 0L)
          flag = false;
        if (flag)
        {
          if (account.Settings.cboxOnlyPet && account.HasActivePet())
            account.CallAttackTargetPacket(account.Myself.ID, -1, int32, 0, 0);
          else
            account.CallAttackTarget(int32, account.MySkills.AllSkills[0].ID, 0, 0);
          account.CallSelectTarget(int32);
        }
      }
      bool flag1 = false;
      if (account.MyQuai.AllQuai.Count > 0)
      {
        for (int index4 = account.MyQuai.AllQuai.Count - 1; index4 >= 0; --index4)
        {
          if (account.MyQuai.AllQuai[index4].ID == int32)
          {
            account.MyQuai.AllQuai[index4].HPPercent = (float) num2;
            account.MyQuai.AllQuai[index4].IsHitByMe = false;
            try
            {
              account.MyQuai.AllQuai[index4].JustHit = (byte) 0;
            }
            catch (Exception ex)
            {
            }
            account.MyQuai.AllQuai[index4].CanAttack = (byte) attackByte;
            account.MyQuai.AllQuai[index4].Name = unicode;
            flag1 = true;
            break;
          }
        }
      }
      if (flag1)
        return;
      QuaiIndividual quaiIndividual = new QuaiIndividual();
      quaiIndividual.ID = int32;
      quaiIndividual.HPPercent = (float) num2;
      quaiIndividual.IsHitByMe = false;
      try
      {
        quaiIndividual.JustHit = (byte) 0;
      }
      catch (Exception ex)
      {
      }
      quaiIndividual.CanAttack = (byte) attackByte;
      quaiIndividual.LastTimeSeen = frmLogin.GlobalTimer.ElapsedMilliseconds;
      account.MyQuai.AllQuai.Add(quaiIndividual);
    }
    else
    {
      if (GA.isInCity(account.Myself.MapID) || GA.IsBangMapID(account.Myself.MapID))
        return;
      int num = (int) account.Target.tempNewPacket[15];
      if (account.Target.VersionNum == 3 || account.Target.VersionNum == 4)
        num = (int) account.Target.tempNewPacket[18];
      if (account.Target.VersionNum == 5 || account.Target.VersionNum == 6)
        num = (int) account.Target.tempNewPacket[21];
      if (int32 < 0 || int32 > 10000 || num != 100)
        return;
      if (account.Settings.cboxDanhQuai && account.IsAIEnabled && !account.Myself.IsPK && !GA.IsInPhuBan(account.Myself.MapID, account) && account.Myself.Status != AllEnums.CharStatuses.GOGOGO && account.Myself.Status != AllEnums.CharStatuses.NMBUFFMAU && account.Myself.Status != AllEnums.CharStatuses.NHATBOC && (account.Settings.FightMode == AllEnums.FightingModes.DANHGOMQUAI || account.MyQuai.AllQuai.Count <= 1 && account.Settings.QuaiNoAttackList.Count == 0) && account.Myself.ActionStatus != (byte) 5 && (account.Settings.AIMode == AllEnums.AIModes.DANHQUANHDIEM || account.Settings.AIMode == AllEnums.AIModes.DANHTUDO))
      {
        if (account.Settings.cboxOnlyPet && account.HasActivePet())
          account.CallAttackTargetPacket(account.Myself.ID, -1, int32, 0, 0);
        else
          account.CallAttackTarget(int32, account.MySkills.AllSkills[0].ID, 0, 0);
        account.CallSelectTarget(int32);
      }
      bool flag = false;
      if (account.MyQuai.AllQuai.Count > 0)
      {
        for (int index = account.MyQuai.AllQuai.Count - 1; index >= 0; --index)
        {
          if (account.MyQuai.AllQuai[index].ID == int32)
          {
            flag = true;
            break;
          }
        }
      }
      if (flag)
        return;
      QuaiIndividual quaiIndividual = new QuaiIndividual();
      quaiIndividual.ID = int32;
      quaiIndividual.HPPercent = (float) num;
      quaiIndividual.IsHitByMe = false;
      try
      {
        quaiIndividual.JustHit = (byte) 0;
      }
      catch (Exception ex)
      {
      }
      quaiIndividual.CanAttack = (byte) 29;
      quaiIndividual.LastTimeSeen = frmLogin.GlobalTimer.ElapsedMilliseconds;
      account.MyQuai.AllQuai.Add(quaiIndividual);
    }
  }

  public static void PacketNumCaptcha(AutoAccount account, int dataLength, int packetLength)
  {
    switch (dataLength)
    {
      case 577:
        if (account.Target.VersionNum != 3 && account.Target.VersionNum != 4)
          break;
        goto case 578;
      case 578:
        byte num1 = account.Target.tempNewPacket[583];
        int num2 = 7;
        int num3 = 583;
        if (account.MyFlag.IsInGame || account.AutoProfile == null)
          break;
        if (account.Target.VersionNum == 3)
        {
          num1 = (byte) 0;
          num2 = 7;
          num3 = 583;
        }
        byte[] myArr = new byte[577];
        for (int index = num2; index <= num3; ++index)
          myArr[index - num2] = (byte) ((uint) account.Target.tempNewPacket[index] - (uint) num1);
        string picData = GA.CaptchaPacketProc(myArr);
        PictureBox picBox = new PictureBox();
        GA.PlotCaptchaNum(picData, picBox);
        account.AutoProfile.imgCaptcha = picBox.Image;
        break;
    }
  }

  public static void PacketQuaiDisappear(AutoAccount account, int dataLength, int packetLength)
  {
    if (dataLength == 6)
    {
      int int32 = BitConverter.ToInt32(account.Target.tempNewPacket, 6);
      SmartClass.RemoveBocQuaiPlayerList(account, int32);
    }
    else if (account.Target.VersionNum == 7 || account.Target.VersionNum == 8)
    {
      int int32_1 = BitConverter.ToInt32(account.Target.tempNewPacket, 6);
      if (int32_1 < 1)
        return;
      int num = 10;
      for (int index = 0; index < int32_1; ++index)
      {
        int int32_2 = BitConverter.ToInt32(account.Target.tempNewPacket, num + index * 4);
        SmartClass.RemoveBocQuaiPlayerList(account, int32_2);
      }
    }
    else
    {
      if (GA.CheckGameVersion(account.Target.VersionNum) != 356)
        return;
      int num1 = (int) account.Target.tempNewPacket[6];
      if (num1 < 1)
        return;
      int num2 = 7;
      for (int index = 0; index < num1; ++index)
      {
        int int32 = BitConverter.ToInt32(account.Target.tempNewPacket, num2 + index * 4);
        SmartClass.RemoveBocQuaiPlayerList(account, int32);
      }
    }
  }

  public static void PacketBocDisappear(AutoAccount account, int dataLength, int packetLength)
  {
    if (dataLength != 6)
      return;
    int int32 = BitConverter.ToInt32(account.Target.tempNewPacket, 6);
    SmartClass.RemoveBocQuaiPlayerList(account, int32);
  }

  private static void RemoveBocQuaiPlayerList(AutoAccount account, int tempBocID, int mode = 0)
  {
    bool flag = true;
    if (account.MyBoc != null && mode <= 1 && tempBocID != 0)
    {
      for (int index = account.MyBoc.AllBocs.Count - 1; index >= 0; --index)
      {
        if (account.MyBoc.AllBocs[index].BocID == tempBocID)
        {
          if (GA.isVipMember())
          {
            int num = account.Settings.cboxTNRunOnly ? 1 : 0;
          }
          SmartClass.ResetBocIndividual(account, index);
          flag = false;
          break;
        }
      }
      if (tempBocID == account.MyBoc.ActiveBocID)
      {
        account.MyBoc.AllItems.Clear();
        account.MyBoc.ActiveBocID = 0;
      }
    }
    if (mode != 0 && mode != 2)
      return;
    if (account.MyQuai != null && flag && account.MyQuai.AllQuai.Count > 0)
    {
      for (int index = account.MyQuai.AllQuai.Count - 1; index >= 0; --index)
      {
        if (account.MyQuai.AllQuai[index].ID == tempBocID)
        {
          account.MyQuai.AllQuai.RemoveAt(index);
          flag = false;
          break;
        }
      }
    }
    if (account.MyPlayers == null || !flag || account.MyPlayers.AllPlayers.Count <= 0)
      return;
    for (int index = account.MyPlayers.AllPlayers.Count - 1; index >= 0; --index)
    {
      if (account.MyPlayers.AllPlayers[index].ID == tempBocID)
      {
        account.MyPlayers.AllPlayers.RemoveAt(index);
        break;
      }
    }
  }

  public static void PacketTNShop(AutoAccount account, int dataLength, int packetLength)
  {
    if (dataLength < 813)
      return;
    bool flag = false;
    int num = 15;
    int index1 = 0;
    for (int index2 = 0; index2 < 12; ++index2)
    {
      account.TNNPCShopInstance[index2].ItemID = -1;
      account.TNNPCShopInstance[index2].Price = 0;
      account.TNNPCShopInstance[index2].Amount = 0;
    }
    while (!flag)
    {
      int int32_1 = BitConverter.ToInt32(account.Target.tempNewPacket, num + 20 * index1);
      int int32_2 = BitConverter.ToInt32(account.Target.tempNewPacket, num + 20 * index1 + 8);
      int int32_3 = BitConverter.ToInt32(account.Target.tempNewPacket, num + 20 * index1 + 16 /*0x10*/);
      if (int32_1 == 0)
      {
        flag = true;
      }
      else
      {
        account.TNNPCShopInstance[index1].ItemID = int32_1;
        account.TNNPCShopInstance[index1].Price = int32_2;
        account.TNNPCShopInstance[index1].Amount = int32_3;
        ++index1;
        if (index1 >= 12)
          flag = true;
      }
    }
  }

  public static void PacketThoDonChau(AutoAccount account, int dataLength, int packetLength)
  {
    if (account.Target.tempNewPacket[6] == (byte) 10 && account.Target.tempNewPacket[7] == (byte) 8)
      account.Myself.CaptchaTKStamp = frmLogin.GlobalTimer.ElapsedMilliseconds + 29000L;
    else if (account.Target.tempNewPacket[6] == (byte) 0 && account.Target.tempNewPacket[7] == (byte) 4)
    {
      account.Myself.CaptchaTKStamp = frmLogin.GlobalTimer.ElapsedMilliseconds + 59000L;
    }
    else
    {
      if (account.Target.tempNewPacket[31 /*0x1F*/] != (byte) 208 /*0xD0*/ || account.Target.tempNewPacket[32 /*0x20*/] != (byte) 181 || account.Target.tempNewPacket[33] != (byte) 105 || !frmLogin.GAuto.Settings.DongYPhuDoi)
        return;
      Thread.Sleep(500);
      account.CallStringWithEnv(31 /*0x1F*/);
    }
  }

  public static void PacketThongThienPhu(AutoAccount account, int dataLength, int packetLength)
  {
    if (account.Myself.isThuBiChienMinh && account.IsAIEnabled)
    {
      string unicode = GA.ConvertToUnicode(account.Target.tempNewPacket, 0, packetLength);
      string midString1 = GA.GetMidString(unicode, "#{", "}");
      if (midString1 == "MZPVE_150812_80" || midString1 == "MZPVE_150812_1577" || midString1 == "MZPVE_150812_831" || midString1 == "MZPVE_150812_1203" || midString1 == "MZPVE_150812_1950")
      {
        string midString2 = GA.GetMidString(unicode, "*", "\0", 2);
        account.PacketInfoGetXY(midString2, 1);
      }
      else
        unicode.Contains("MZPVE_150812_363");
      if (!GA.isVipMember() || !account.Settings.cboxDebugLog)
        return;
      GA.WriteUserLog("PacketThongThien: " + unicode.Replace("Ầ", "").Replace("Ẵ", "").Replace("Ẳ", "").Replace("Ù", "").Replace("Ố", "").Replace("Ớ", "").Replace("Ữ", "").Replace("Ự", "").Replace("Ẫ", "").Replace("\r", "").Replace("\0", "").Replace("{", "{{").Replace("}", "}}"), account);
    }
    else if (account.Target.tempNewPacket[41] == (byte) 67 && account.Target.tempNewPacket[42] == (byte) 97 && account.Target.tempNewPacket[43] == (byte) 108)
    {
      if (!frmLogin.GAuto.Settings.DongYPhuDoi)
        return;
      Thread.Sleep(500);
      account.CallStringWithEnv(31 /*0x1F*/);
    }
    else
    {
      if (!GA.ConvertToUnicode(account.Target.tempNewPacket, 0, packetLength).Contains("CallMe") || !frmLogin.GAuto.Settings.DongYPhuDoi)
        return;
      Thread.Sleep(500);
      account.CallStringWithEnv(31 /*0x1F*/);
    }
  }

  public static void ResetBocIndividual(AutoAccount account, int index)
  {
    account.Myself.FlagFullBoc = false;
    if (account.MyBoc == null || index >= account.MyBoc.AllBocs.Count)
      return;
    if (account.MyBoc.AllBocs[index].BocID == account.MyBoc.ActiveBocID)
    {
      account.MyBoc.ActiveBocID = 0;
      account.MyBoc.LastTimeSeen = 0L;
      account.MyBoc.PosX = 0.0f;
      account.MyBoc.PosY = 0.0f;
    }
    bool flag = true;
    if (account.MyBoc.RemovedBocList.Count > 0)
    {
      for (int index1 = 0; index1 < account.MyBoc.RemovedBocList.Count; ++index1)
      {
        if (account.MyBoc.RemovedBocList[index1].BocID == account.MyBoc.AllBocs[index].BocID)
        {
          account.MyBoc.RemovedBocList[index1].PosX = account.MyBoc.AllBocs[index].PosX;
          account.MyBoc.RemovedBocList[index1].PosY = account.MyBoc.AllBocs[index].PosY;
          account.MyBoc.RemovedBocList[index1].LastTimeSeen = account.MyBoc.AllBocs[index].LastTimeSeen;
          flag = false;
          break;
        }
      }
    }
    if (flag)
    {
      int index2 = 0;
      long num = long.MaxValue;
      if (account.MyBoc.RemovedBocList.Count >= 50)
      {
        for (int index3 = 0; index3 < account.MyBoc.RemovedBocList.Count; ++index3)
        {
          if (account.MyBoc.RemovedBocList[index3].LastTimeSeen < num)
          {
            num = account.MyBoc.RemovedBocList[index3].LastTimeSeen;
            index2 = index3;
          }
        }
        account.MyBoc.RemovedBocList.RemoveAt(index2);
      }
      account.MyBoc.RemovedBocList.Add(new NewBoc()
      {
        BocID = account.MyBoc.AllBocs[index].BocID,
        PosX = account.MyBoc.AllBocs[index].PosX,
        PosY = account.MyBoc.AllBocs[index].PosY,
        LastTimeSeen = account.MyBoc.AllBocs[index].LastTimeSeen
      });
    }
    account.MyBoc.AllBocs.RemoveAt(index);
  }

  public static void ProcPacket9999(AutoAccount account, int dataLength, int packetLength)
  {
    if (account == null || BitConverter.ToInt32(account.Target.tempNewPacket, 6) != account.Myself.ID)
      return;
    float single1 = BitConverter.ToSingle(account.Target.tempNewPacket, 12);
    float single2 = BitConverter.ToSingle(account.Target.tempNewPacket, 16 /*0x10*/);
    if ((double) Math.Abs(single1 - account.Myself.savedStuckX) > 1.0 || (double) Math.Abs(single2 - account.Myself.savedStuckY) > 1.0)
      return;
    account.Myself.savedStuckX = single1;
    account.Myself.savedStuckY = single2;
    account.Myself.flagMoveStuck = true;
    account.Myself.flagMoveStuckStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
  }

  public static void PacketPartyMemberInviteOther(
    AutoAccount account,
    int dataLength,
    int packetLength)
  {
    if (account == null || account.MyParty == null)
      return;
    int num1 = 0;
    if (GA.CheckGameVersion(account.Target.VersionNum) == 356)
    {
      num1 = 8;
      account.MyParty.PTAskDBAsked = BitConverter.ToInt32(account.Target.tempNewPacket, 6);
      account.MyParty.PTAskDBAskedLow = BitConverter.ToInt32(account.Target.tempNewPacket, 10);
      account.MyParty.PTAskDBAsker = BitConverter.ToInt32(account.Target.tempNewPacket, 14);
      account.MyParty.PTAskDBAskerLow = BitConverter.ToInt32(account.Target.tempNewPacket, 18);
    }
    else
    {
      account.MyParty.PTAskDBAsked = BitConverter.ToInt32(account.Target.tempNewPacket, 6);
      account.MyParty.PTAskDBAsker = BitConverter.ToInt32(account.Target.tempNewPacket, 10);
    }
    int count = (int) account.Target.tempNewPacket[14 + num1];
    int num2 = (int) account.Target.tempNewPacket[15 + num1];
    int num3 = 16 /*0x10*/ + num1;
    if (count <= 30)
    {
      byte[] tempArr = new byte[30];
      for (int index = num3; index < num3 + count; ++index)
        tempArr[index - num3] = account.Target.tempNewPacket[index];
      account.MyParty.PTAskName = GA.ConvertToUnicode(tempArr, 0, count);
    }
    int num4 = num3 + count;
    account.MyParty.PTAskLevel = BitConverter.ToInt32(account.Target.tempNewPacket, num4 + num2);
    int startIndex = num4 + (num2 + 4);
    account.MyParty.PTAskMenpai = BitConverter.ToInt32(account.Target.tempNewPacket, startIndex);
    account.MyParty.PTAskSequence = BitConverter.ToInt32(account.Target.tempNewPacket, packetLength - 4);
  }

  public static void PacketPartyJoin(AutoAccount account, int dataLength, int packetLength)
  {
    if (account == null || account.MyParty == null)
      return;
    int num1 = 0;
    if (GA.CheckGameVersion(account.Target.VersionNum) == 356)
    {
      num1 = 8;
      account.MyParty.PTAskDBAsker = BitConverter.ToInt32(account.Target.tempNewPacket, 6);
      account.MyParty.PTAskDBAskerLow = BitConverter.ToInt32(account.Target.tempNewPacket, 10);
      account.MyParty.PTAskDBAsked = BitConverter.ToInt32(account.Target.tempNewPacket, 14);
      account.MyParty.PTAskDBAskedLow = BitConverter.ToInt32(account.Target.tempNewPacket, 18);
    }
    else
    {
      account.MyParty.PTAskDBAsker = BitConverter.ToInt32(account.Target.tempNewPacket, 6);
      account.MyParty.PTAskDBAsked = BitConverter.ToInt32(account.Target.tempNewPacket, 10);
    }
    int count = (int) account.Target.tempNewPacket[14 + num1];
    int num2 = (int) account.Target.tempNewPacket[15 + num1];
    int num3 = 16 /*0x10*/ + num1;
    if (count <= 30)
    {
      byte[] tempArr = new byte[30];
      for (int index = num3; index < num3 + count; ++index)
        tempArr[index - num3] = account.Target.tempNewPacket[index];
      account.MyParty.PTAskName = GA.ConvertToUnicode(tempArr, 0, count);
    }
    int num4 = num3 + count;
    account.MyParty.PTAskMenpai = BitConverter.ToInt32(account.Target.tempNewPacket, num4 + num2);
    int startIndex = num4 + (num2 + 6);
    account.MyParty.PTAskLevel = BitConverter.ToInt32(account.Target.tempNewPacket, startIndex);
    account.MyParty.PTAskSequence = BitConverter.ToInt32(account.Target.tempNewPacket, packetLength - 4);
  }

  public static void PacketItemDetails(AutoAccount account, int dataLength, int packetLength)
  {
    if (dataLength < 100 && (dataLength < 68 || account.Target.VersionNum != 3) && (dataLength < 96 /*0x60*/ || account.Target.VersionNum != 5 && account.Target.VersionNum != 6) && (dataLength < 100 || GA.CheckGameVersion(account.Target.VersionNum) != 356))
      return;
    int int32_1 = BitConverter.ToInt32(account.Target.tempNewPacket, 12);
    int int32_2 = BitConverter.ToInt32(account.Target.tempNewPacket, 16 /*0x10*/);
    int int32_3 = BitConverter.ToInt32(account.Target.tempNewPacket, 20);
    byte num1 = account.Target.tempNewPacket[44];
    byte num2 = account.Target.tempNewPacket[24];
    List<int> intList = new List<int>();
    if (num2 == (byte) 22)
    {
      for (int index = 0; index < (int) num1; ++index)
      {
        int int16 = (int) BitConverter.ToInt16(account.Target.tempNewPacket, 45 + 2 * index);
        intList.Add(int16);
      }
    }
    byte num3 = account.Target.tempNewPacket[45 + ((int) num1 - 1) * 2 + 29];
    for (int index1 = 0; index1 < 30; ++index1)
    {
      if (account.MyInventory.AllItems[index1].ItemID == int32_3 && account.MyInventory.AllItems[index1].ItemGUID1 == int32_1 && account.MyInventory.AllItems[index1].ItemGUID2 == int32_2)
      {
        account.MyInventory.AllItems[index1].Lines = num1;
        account.MyInventory.AllItems[index1].ItemSource = (AllEnums.ItemSources) num2;
        account.MyInventory.AllItems[index1].ItemStars = num3;
        account.MyInventory.AllItems[index1].SavedCode = int32_3;
        if (intList.Count <= 0)
          break;
        for (int index2 = 0; index2 < intList.Count; ++index2)
        {
          int num4 = intList[index2];
          account.MyInventory.AllItems[index1].LineValueArray.Add(num4);
        }
        break;
      }
    }
  }

  public static void ProcessVariables(AutoAccount account)
  {
    if (account.MyPet != null)
    {
      if (account.MyPet.NoToy && account.MyFlag.Slow3000Read && frmLogin.GlobalTimer.ElapsedMilliseconds - account.MyPet.NoToyStamp >= 15000L)
        account.MyPet.NoToy = false;
      if (!account.MyPet.flagAllowPet && account.MyPet.btnThuPetStamp != 0L && account.MyFlag.Slow3000Read)
      {
        if (frmLogin.GlobalTimer.ElapsedMilliseconds - account.MyPet.btnThuPetStamp >= 300000L)
        {
          try
          {
            account.MyPet.btnThuPetStamp = 0L;
            account.MyPet.flagAllowPet = true;
          }
          catch (Exception ex)
          {
            if (Monitor.TryEnter(frmLogin.lock1, 2000))
            {
              account.MyPet.btnThuPetStamp = 0L;
              account.MyPet.flagAllowPet = true;
              Monitor.Exit(frmLogin.lock1);
            }
          }
        }
      }
    }
    if (account.Myself != null)
    {
      if (account.MyFlag.IsBlockedChat && account.MyFlag.BlockChatMinutes > 0 && frmLogin.GlobalTimer.ElapsedMilliseconds - account.MyFlag.BlockChatStamp > (long) (account.MyFlag.BlockChatMinutes * 60000) && account.MyFlag.BlockChatStamp > 0L)
        account.MyFlag.IsBlockedChat = false;
      if (account.MyFlag.Slow1000Read)
      {
        int myref = 0;
        if (account.Myself.CaptchaAddress != -1)
        {
          SmartClass.ReadMyValueInt(account, ref myref, account.Myself.CaptchaAddress);
          account.Myself.CaptchaRemaining = myref;
        }
        else
          account.Myself.CaptchaRemaining = 0;
      }
      if (account.Myself.FlagHetThucAnStamp > 0L && account.Myself.FlagHetThucAn && account.MyFlag.Slow1000Read && frmLogin.GlobalTimer.ElapsedMilliseconds - account.Myself.FlagHetThucAnStamp >= 15000L)
      {
        account.Myself.FlagHetThucAnStamp = 0L;
        account.Myself.FlagHetThucAn = false;
      }
      if (account.Myself.ManaRunOut && frmLogin.GlobalTimer.ElapsedMilliseconds - account.Myself.ManaRunOutStamp >= 5000L)
        account.Myself.ManaRunOut = false;
      if (account.Myself.FlagBeingAttackedStamp > 0L && account.Myself.FlagBeingAttacked && frmLogin.GlobalTimer.ElapsedMilliseconds - account.Myself.FlagBeingAttackedStamp >= 2000L)
      {
        account.Myself.FlagBeingAttackedStamp = 0L;
        account.Myself.FlagBeingAttacked = false;
      }
      if (account.Myself.IsAttacked == 1 && account.Myself.IsAttackedTimeStamp > 0L && frmLogin.GlobalTimer.ElapsedMilliseconds - account.Myself.IsAttackedTimeStamp >= 30000L)
      {
        account.Myself.IsAttackedTimeStamp = 0L;
        account.Myself.IsAttacked = 0;
        account.Myself.AttackerID = 0;
      }
      if (frmLogin.GlobalTimer.ElapsedMilliseconds - account.Myself.AcBaStampReset >= 1200000L)
      {
        account.Myself.AcBaStampReset = frmLogin.GlobalTimer.ElapsedMilliseconds;
        if (account.Settings.AcBaPhai != frmMain.langABPhai && frmLogin.GlobalTimer.ElapsedMilliseconds - account.Settings.AcBaPhaiStamp >= 3600000L)
        {
          account.Settings.AcBaPhaiStamp = 0L;
          account.Settings.AcBaPhai = frmMain.langABPhai;
        }
      }
      if (account.Myself.Last10SecXYStamp != 0L && frmLogin.GlobalTimer.ElapsedMilliseconds - account.Myself.Last10SecXYStamp >= 30000L)
      {
        account.Myself.Last10SecXYStamp = 0L;
        account.Myself.Last10SecX = 0.0f;
        account.Myself.Last10SecY = 0.0f;
      }
      if (account.Myself.flagMoveStuckStamp != 0L && frmLogin.GlobalTimer.ElapsedMilliseconds - account.Myself.flagMoveStuckStamp > 65000L && account.Myself.flagMoveStuck)
      {
        account.Myself.flagMoveStuckStamp = 0L;
        account.Myself.flagMoveStuck = false;
      }
    }
    if (account.MyBoc != null && account.MyBoc.AllBocs.Count > 0 && frmLogin.GlobalTimer.ElapsedMilliseconds - account.Myself.CheckBocStamp >= 4000L)
    {
      account.Myself.CheckBocStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
      for (int index = account.MyBoc.AllBocs.Count - 1; index >= 0; --index)
      {
        NewBoc allBoc = account.MyBoc.AllBocs[index];
        bool flag = false;
        if (allBoc.BocID != 0 && allBoc.LastTimeSeen > 0L)
        {
          if (allBoc.BocType == 5000 && frmLogin.GlobalTimer.ElapsedMilliseconds - allBoc.LastTimeSeen >= 62000L)
          {
            SmartClass.ResetBocIndividual(account, index);
            flag = true;
          }
          if ((allBoc.BocType == 808 || allBoc.BocType == 807) && frmLogin.GlobalTimer.ElapsedMilliseconds - allBoc.LastTimeSeen >= 300000L)
          {
            SmartClass.ResetBocIndividual(account, index);
            flag = true;
          }
        }
        if (!flag && GA.CalculateDistance((double) allBoc.PosX, (double) allBoc.PosY, (double) account.Myself.PosX, (double) account.Myself.PosY) > frmLogin.GAuto.Settings.MaxDistance)
          SmartClass.ResetBocIndividual(account, index);
      }
    }
    if (account.MyQuai != null && account.Myself != null)
    {
      if (account.Myself.Last3SecStatus != account.Myself.Status)
      {
        account.Myself.Last3SecStatus = account.Myself.Status;
        account.Myself.Last3SecStatusStamp = account.Myself.Status != AllEnums.CharStatuses.IDLE ? 0L : frmLogin.GlobalTimer.ElapsedMilliseconds;
      }
      if (account.Myself.Last3SecStatus == account.Myself.Status && account.Myself.Status == AllEnums.CharStatuses.IDLE && frmLogin.GlobalTimer.ElapsedMilliseconds - account.Myself.Last3SecStatusStamp >= 2000L && account.Myself.Last3SecStatusStamp != 0L)
      {
        if (account.MyQuai.IgnoredQuaiID.Count > 0)
          account.MyQuai.IgnoredQuaiID.Clear();
        account.Myself.Last3SecStatusStamp = 0L;
      }
      if (account.MyQuai.IgnoredQuaiID.Count > 0)
      {
        if (account.MyFlag.IgnoredQuaiID_Reset_Stamp == 0L)
          account.MyFlag.IgnoredQuaiID_Reset_Stamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
        if (frmLogin.GlobalTimer.ElapsedMilliseconds - account.MyFlag.IgnoredQuaiID_Reset_Stamp > 3000L)
        {
          account.MyQuai.IgnoredQuaiID.Clear();
          account.MyFlag.IgnoredQuaiID_Reset_Stamp = 0L;
        }
      }
      if (account.MyQuai.AllQuai.Count > 0)
      {
        if (account.Settings.FightMode == AllEnums.FightingModes.DANHGOMQUAI && frmLogin.GlobalTimer.ElapsedMilliseconds - account.Myself.FlagCheckJustHit >= 1500L)
        {
          account.Myself.FlagCheckJustHit = frmLogin.GlobalTimer.ElapsedMilliseconds;
          for (int index = account.MyQuai.AllQuai.Count - 1; index >= 0; --index)
          {
            QuaiIndividual quaiIndividual = account.MyQuai.AllQuai[index];
            if (quaiIndividual.JustHit == (byte) 1 && frmLogin.GlobalTimer.ElapsedMilliseconds - quaiIndividual.LastHitStamp >= 1000L)
            {
              if ((double) quaiIndividual.HPPercent >= 100.0)
              {
                try
                {
                  quaiIndividual.JustHit = (byte) 0;
                }
                catch (Exception ex)
                {
                }
              }
            }
          }
        }
        for (int index = account.MyQuai.AllQuai.Count - 1; index >= 0; --index)
        {
          QuaiIndividual quaiIndividual = account.MyQuai.AllQuai[index];
          bool flag1 = false;
          // TODO: lỗi
          if (quaiIndividual.ID != -1 && quaiIndividual.HPPointer > 0 && quaiIndividual.QuaiType != (byte) 4)
          {
            byte[] lpBuffer = new byte[4];
            int lpNumberOfBytesRead = 0;
            lpBuffer[0] = (byte) 0;
            lpBuffer[1] = (byte) 0;
            lpBuffer[2] = (byte) 0;
            lpBuffer[3] = (byte) 0;
            MyDLL.ReadProcessMemory((int) account.Target.ProcessHandle, (IntPtr) quaiIndividual.HPPointer, lpBuffer, 4U, ref lpNumberOfBytesRead);
            float single = BitConverter.ToSingle(lpBuffer, 0);
            quaiIndividual.HPPercent = single * 100f;
            if ((double) single <= 0.0)
            {
              SmartClass.ResetQuaiByIndex(account, index);
              flag1 = true;
            }
          }
          else
          {
            quaiIndividual.HPPercent = 0.0f;
            if (quaiIndividual.HPPointer == 0)
              SmartClass.ResetQuaiByIndex(account, index);
            flag1 = true;
          }
          if (!flag1 && quaiIndividual.ID != -1 && account.Myself != null)
          {
            double distance = GA.CalculateDistance((double) quaiIndividual.PosX, (double) quaiIndividual.PosY, (double) account.Myself.PosX, (double) account.Myself.PosY);
            bool flag2 = false;
            if (distance > frmLogin.GAuto.Settings.MaxDistance)
              flag2 = true;
            bool flag3 = false;
            int num = 30000;
            if (account.Target.VersionNum == 3 || account.Target.VersionNum == 4)
              num = 120000;
            if (frmLogin.GlobalTimer.ElapsedMilliseconds - quaiIndividual.LastTimeSeen >= (long) num)
              flag3 = true;
            if (flag2 || flag3)
              SmartClass.ResetQuaiByIndex(account, index);
          }
        }
      }
      if (account.MyQuai.AllQuai.Count <= 0 && account.MyQuai.TargetID >= 0 && !account.isPlayerChinhXac())
        SmartClass.ResetTarget(account);
      if (!account.Myself.HasTarget && frmLogin.GlobalTimer.ElapsedMilliseconds - account.Myself.HasTargetStamp >= 1000L && (account.MyQuai.TargetID != -1 || (double) account.MyQuai.TargetHPPercent > 0.0) && !frmLogin.GAuto.Settings.optNoSkillLag)
        SmartClass.ResetTarget(account);
      if ((account.MyQuai.TargetID != -1 || (double) account.MyQuai.TargetHPPercent > 0.0) && account.MyQuai.TargetID == account.MyQuai.SavedTargetID && account.MyQuai.SavedTargetID != -1 && frmLogin.GlobalTimer.ElapsedMilliseconds - account.MyQuai.SavedTargetStamp >= 2000L && account.MyQuai.SavedTargetStamp != 0L && account.MyQuai.AllQuai.Count > 0)
      {
        bool flag = false;
        for (int index = account.MyQuai.AllQuai.Count - 1; index >= 0; --index)
        {
          if (account.MyQuai.AllQuai[index].ID == account.MyQuai.TargetID && (double) account.MyQuai.AllQuai[index].HPPercent > 0.0)
          {
            if (GA.CalculateDistance((double) account.Myself.PosX, (double) account.Myself.PosY, (double) account.MyQuai.AllQuai[index].PosX, (double) account.MyQuai.AllQuai[index].PosY) <= 35.0)
            {
              flag = true;
              break;
            }
            break;
          }
        }
        if (!flag)
          SmartClass.ResetTarget(account);
      }
    }
    if (account.MyParty != null && account.MyParty.InviterDB != 0 && frmLogin.GlobalTimer.ElapsedMilliseconds - account.Myself.PartyInviteStamp >= 4000L && account.Myself.LastTimeSeenInvite > 0L)
    {
      account.Myself.PartyInviteStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
      if (frmLogin.GlobalTimer.ElapsedMilliseconds - account.Myself.LastTimeSeenInvite >= 45000L)
      {
        account.MyParty.InviterDB = 0;
        account.MyParty.LastTimeSeenInvite = 0L;
        account.MyParty.Name = "";
      }
    }
    if (account.MyPlayers == null || account.Myself == null || !account.MyFlag.Slow1000Read || account.MyPlayers.AllPlayers.Count <= 0)
      return;
    for (int index = account.MyPlayers.AllPlayers.Count - 1; index >= 0; --index)
    {
      PlayerIndividual allPlayer = account.MyPlayers.AllPlayers[index];
      if (allPlayer.ID != 0)
      {
        double distance = GA.CalculateDistance((double) allPlayer.PosX, (double) allPlayer.PosY, (double) account.Myself.PosX, (double) account.Myself.PosY);
        bool flag = false;
        if (distance > frmLogin.GAuto.Settings.MaxDistance && frmLogin.GlobalTimer.ElapsedMilliseconds - allPlayer.LastTimeSeen >= 3000L)
          flag = true;
        if (!flag)
        {
          int num = 30000;
          if (account.Target.VersionNum == 3 || account.Target.VersionNum == 4)
            num = 180000;
          if (frmLogin.GlobalTimer.ElapsedMilliseconds - allPlayer.LastTimeSeen >= (long) num)
            flag = true;
        }
        if (flag)
          account.MyPlayers.AllPlayers.RemoveAt(index);
      }
    }
  }

  public static void ResetTarget(AutoAccount account)
  {
    account.MyQuai.TargetID = -1;
    account.MyQuai.SavedTargetID = -1;
    account.MyQuai.TargetHPPercent = 0.0f;
    account.MyQuai.CanAttackInt = 0;
  }

  public static void Reset30(byte[] buffer)
  {
    buffer[0] = (byte) 0;
    buffer[1] = (byte) 0;
    buffer[2] = (byte) 0;
    buffer[3] = (byte) 0;
    buffer[4] = (byte) 0;
    buffer[5] = (byte) 0;
    buffer[6] = (byte) 0;
    buffer[7] = (byte) 0;
    buffer[8] = (byte) 0;
    buffer[9] = (byte) 0;
    buffer[10] = (byte) 0;
    buffer[11] = (byte) 0;
    buffer[12] = (byte) 0;
    buffer[13] = (byte) 0;
    buffer[14] = (byte) 0;
    buffer[15] = (byte) 0;
    buffer[16 /*0x10*/] = (byte) 0;
    buffer[17] = (byte) 0;
    buffer[18] = (byte) 0;
    buffer[19] = (byte) 0;
    buffer[20] = (byte) 0;
    buffer[21] = (byte) 0;
    buffer[22] = (byte) 0;
    buffer[23] = (byte) 0;
    buffer[24] = (byte) 0;
    buffer[25] = (byte) 0;
    buffer[26] = (byte) 0;
    buffer[27] = (byte) 0;
    buffer[28] = (byte) 0;
    buffer[29] = (byte) 0;
  }

  public static void Reset30(AutoAccount account)
  {
    account.Target.tempBuffer[0] = (byte) 0;
    account.Target.tempBuffer[1] = (byte) 0;
    account.Target.tempBuffer[2] = (byte) 0;
    account.Target.tempBuffer[3] = (byte) 0;
    account.Target.tempBuffer[4] = (byte) 0;
    account.Target.tempBuffer[5] = (byte) 0;
    account.Target.tempBuffer[6] = (byte) 0;
    account.Target.tempBuffer[7] = (byte) 0;
    account.Target.tempBuffer[8] = (byte) 0;
    account.Target.tempBuffer[9] = (byte) 0;
    account.Target.tempBuffer[10] = (byte) 0;
    account.Target.tempBuffer[11] = (byte) 0;
    account.Target.tempBuffer[12] = (byte) 0;
    account.Target.tempBuffer[13] = (byte) 0;
    account.Target.tempBuffer[14] = (byte) 0;
    account.Target.tempBuffer[15] = (byte) 0;
    account.Target.tempBuffer[16 /*0x10*/] = (byte) 0;
    account.Target.tempBuffer[17] = (byte) 0;
    account.Target.tempBuffer[18] = (byte) 0;
    account.Target.tempBuffer[19] = (byte) 0;
    account.Target.tempBuffer[20] = (byte) 0;
    account.Target.tempBuffer[21] = (byte) 0;
    account.Target.tempBuffer[22] = (byte) 0;
    account.Target.tempBuffer[23] = (byte) 0;
    account.Target.tempBuffer[24] = (byte) 0;
    account.Target.tempBuffer[25] = (byte) 0;
    account.Target.tempBuffer[26] = (byte) 0;
    account.Target.tempBuffer[27] = (byte) 0;
    account.Target.tempBuffer[28] = (byte) 0;
    account.Target.tempBuffer[29] = (byte) 0;
  }

  public static void ReadMemory(AutoAccount account)
  {
    if (account.Target.ProcessID == 0 || !(account.Target.ProcessHandle != IntPtr.Zero))
      return;
    int lpNumberOfBytesRead = 0;
    int num1 = 0;
    int processHandle = (int) account.Target.ProcessHandle;
    for (int index1 = 0; index1 < account.Target.ReadmemContainer.Count; ++index1)
    {
      ReadMemEntry readMemEntry = account.Target.ReadmemContainer[index1];
      string identifier = readMemEntry.Identifier;
      int versionNum = account.Target.VersionNum;
      if (!(identifier == "rm14") && (versionNum != 3 || !(identifier == "rm17") && !(identifier == "rm24") && !(identifier == "rm39")))
      {
        int num2 = account.MyFlag.Slow3000Read ? 1 : 0;
        if ((account.MyFlag.Slow1MinRead || !(identifier == "rm39") || !(account.Myself.Username != "")) && (!(identifier == "rm9") || account.MyParty != null && account.MyParty.PartyNumbers != 0))
        {
          if (identifier == "rm24")
          {
            if (account.MyFlag.ReadQuanDoanStamp == 0L && account.Myself.ID > 0 || account.Myself.Menpai == AllEnums.Menpais.NGAMI)
              account.MyFlag.ReadQuanDoanStamp = SmartClass.nowStamp() + 60000L;
            if (account.MyFlag.ReadQuanDoanStamp < SmartClass.nowStamp())
              continue;
          }
          if ((!(identifier == "rm23") || account.Settings.cboxPKTuVe) && (!(identifier == "rm29") || account.Settings.cboxPassCap2 && !(account.Settings.txtPassCap2 == "")) && (account.Myself.MapID >= 0 && account.Myself.ID > 0 || identifier == "rm1" || identifier == "rm2" || identifier == "rm27" || identifier == "rm19") && (!(identifier == "rm31") || !(account.MyPet.AlwaysActivePetName == "") || !(account.MyPet.CongSinhPetName == "") && account.Settings.cboxCongSinh || !(account.MyPet.HuyetTePetName == "") && account.Settings.cboxHuyetTe || account.MyPet.ActivePetID > 0 || !(account.MyPet.AllPets[0].PetName != "")))
          {
            int tempIntValue = -1;
            int myref1 = 0;
            string myref2 = "";
            byte num3 = 0;
            int mybase1 = 0;
            float myref3 = 0.0f;
            int myref4 = 0;
            int num4 = account.Target.ExeBase + readMemEntry.OffsetToRead[0];
            account.Target.tempBuffer[0] = (byte) 0;
            account.Target.tempBuffer[1] = (byte) 0;
            account.Target.tempBuffer[2] = (byte) 0;
            account.Target.tempBuffer[3] = (byte) 0;
            MyDLL.ReadProcessMemory(processHandle, (IntPtr) num4, account.Target.tempBuffer, 4U, ref lpNumberOfBytesRead);
            int lpBaseAddress1 = (int) account.Target.tempBuffer[0] | (int) account.Target.tempBuffer[1] << 8 | (int) account.Target.tempBuffer[2] << 16 /*0x10*/ | (int) account.Target.tempBuffer[3] << 24;
            if (identifier == "rm39" && account.Myself != null && num4 > 0)
            {
              myref2 = "";
              SmartClass.ReadMyValueString(account, ref myref2, num4);
              account.Myself.Username = myref2;
            }
            if (lpBaseAddress1 >= 0 && lpNumberOfBytesRead > 0)
            {
              for (int index2 = 1; index2 < (int) readMemEntry.Count - 1; ++index2)
              {
                int num5 = readMemEntry.OffsetToRead[index2];
                lpNumberOfBytesRead = 0;
                if (lpBaseAddress1 != 0)
                {
                  int lpBaseAddress2 = lpBaseAddress1 + num5;
                  account.Target.tempBuffer[0] = (byte) 0;
                  account.Target.tempBuffer[1] = (byte) 0;
                  account.Target.tempBuffer[2] = (byte) 0;
                  account.Target.tempBuffer[3] = (byte) 0;
                  MyDLL.ReadProcessMemory((int) account.Target.ProcessHandle, (IntPtr) lpBaseAddress2, account.Target.tempBuffer, 4U, ref lpNumberOfBytesRead);
                  lpBaseAddress1 = (int) account.Target.tempBuffer[0] | (int) account.Target.tempBuffer[1] << 8 | (int) account.Target.tempBuffer[2] << 16 /*0x10*/ | (int) account.Target.tempBuffer[3] << 24;
                }
                if (lpBaseAddress1 == 0)
                  break;
              }
              int index3 = (int) readMemEntry.Count - 1;
              int num6 = readMemEntry.OffsetToRead[index3];
              if (lpBaseAddress1 != 0)
                lpBaseAddress1 += num6;
              if (lpBaseAddress1 != 0)
              {
                lpNumberOfBytesRead = 0;
                if (readMemEntry.MemType == "int")
                {
                  account.Target.tempBuffer[0] = (byte) 0;
                  account.Target.tempBuffer[1] = (byte) 0;
                  account.Target.tempBuffer[2] = (byte) 0;
                  account.Target.tempBuffer[3] = (byte) 0;
                  MyDLL.ReadProcessMemory((int) account.Target.ProcessHandle, (IntPtr) lpBaseAddress1, account.Target.tempBuffer, 4U, ref lpNumberOfBytesRead);
                  tempIntValue = (int) account.Target.tempBuffer[0] | (int) account.Target.tempBuffer[1] << 8 | (int) account.Target.tempBuffer[2] << 16 /*0x10*/ | (int) account.Target.tempBuffer[3] << 24;
                }
                else if (readMemEntry.MemType == "float")
                {
                  account.Target.tempBuffer[0] = (byte) 0;
                  account.Target.tempBuffer[1] = (byte) 0;
                  account.Target.tempBuffer[2] = (byte) 0;
                  account.Target.tempBuffer[3] = (byte) 0;
                  MyDLL.ReadProcessMemory((int) account.Target.ProcessHandle, (IntPtr) lpBaseAddress1, account.Target.tempBuffer, 4U, ref lpNumberOfBytesRead);
                  double single = (double) BitConverter.ToSingle(account.Target.tempBuffer, 0);
                }
                else if (readMemEntry.MemType == "string")
                {
                  SmartClass.Reset30(account);
                  MyDLL.ReadProcessMemory((int) account.Target.ProcessHandle, (IntPtr) lpBaseAddress1, account.Target.tempBuffer, 30U, ref lpNumberOfBytesRead);
                  myref2 = BitConverter.ToString(account.Target.tempBuffer, 0);
                }
                else if (readMemEntry.MemType == "byte")
                {
                  account.Target.tempBuffer[0] = (byte) 0;
                  MyDLL.ReadProcessMemory((int) account.Target.ProcessHandle, (IntPtr) lpBaseAddress1, account.Target.tempBuffer, 1U, ref lpNumberOfBytesRead);
                  num3 = account.Target.tempBuffer[0];
                }
              }
            }
            bool flag1 = false;
            switch (identifier)
            {
              case "rm2":
                if (account.Myself != null)
                {
                  account.Myself.ID = tempIntValue;
                  break;
                }
                break;
              case "rm27":
                if (account.Myself != null)
                {
                  if (tempIntValue != 0 && tempIntValue != 1)
                  {
                    if (account.MyFlag.IsInGame && account.Myself.ID > 0 && frmLogin.GAuto.Settings.TipHuongDan && (account.MyFlag.WriteUserLogStamp == 0L || account.nowStamp() - account.MyFlag.WriteUserLogStamp > 300000L))
                    {
                      GA.WriteUserLog($"{frmMain.langLoiDuLieuAuto} - code SceneTrans {(object) tempIntValue}", account);
                      account.MyFlag.WriteUserLogStamp = account.nowStamp();
                      break;
                    }
                    break;
                  }
                  account.Myself.isSceneTrans = tempIntValue;
                  break;
                }
                break;
            }
            if (account.Myself.ID <= 0 || account.Myself.isSceneTrans == 1)
              account.Myself.ID = 0;
            else
              flag1 = true;
            if (flag1)
            {
              switch (identifier)
              {
                case "rm13":
                  if (account.Myself != null && tempIntValue > 0)
                  {
                    num1 = 0;
                    int mybase2;
                    switch (versionNum)
                    {
                      case 3:
                        mybase2 = tempIntValue + 68;
                        break;
                      case 4:
                        mybase2 = tempIntValue + 72;
                        break;
                      case 5:
                      case 6:
                        mybase2 = tempIntValue + 72;
                        break;
                      case 7:
                      case 8:
                        mybase2 = tempIntValue + 72;
                        break;
                      default:
                        mybase2 = tempIntValue + 96 /*0x60*/;
                        break;
                    }
                    float myref5 = 0.0f;
                    SmartClass.ReadMyValueFloat(account, ref myref5, mybase2);
                    account.Myself.PosX = myref5;
                    int mybase3;
                    switch (versionNum)
                    {
                      case 3:
                        mybase3 = tempIntValue + 76;
                        break;
                      case 4:
                        mybase3 = tempIntValue + 80 /*0x50*/;
                        break;
                      case 5:
                      case 6:
                        mybase3 = tempIntValue + 80 /*0x50*/;
                        break;
                      case 7:
                      case 8:
                        mybase3 = tempIntValue + 80 /*0x50*/;
                        break;
                      default:
                        mybase3 = tempIntValue + 104;
                        break;
                    }
                    float myref6 = 0.0f;
                    SmartClass.ReadMyValueFloat(account, ref myref6, mybase3);
                    account.Myself.PosY = myref6;
                    continue;
                  }
                  continue;
                case "rm1":
                  if (account.Myself != null && tempIntValue > 0)
                  {
                    int num7 = GA.CheckGameVersion(versionNum);
                    if (num7 == 356)
                    {
                      mybase1 = tempIntValue + 10080;
                    }
                    else
                    {
                      switch (versionNum)
                      {
                        case 1:
                        case 2:
                          mybase1 = tempIntValue + 10032;
                          break;
                        case 3:
                          mybase1 = tempIntValue + 1752;
                          break;
                        case 4:
                          mybase1 = tempIntValue + 2468;
                          break;
                        case 5:
                        case 6:
                          mybase1 = tempIntValue + 9304;
                          break;
                        case 7:
                        case 8:
                          mybase1 = tempIntValue + 10080;
                          break;
                      }
                    }
                    myref4 = 0;
                    SmartClass.ReadMyValueInt(account, ref myref4, mybase1);
                    account.Myself.HP = myref4;
                    int mybase4;
                    if (num7 == 356)
                    {
                      mybase4 = tempIntValue + 10084;
                    }
                    else
                    {
                      switch (versionNum)
                      {
                        case 1:
                        case 2:
                          mybase4 = tempIntValue + 10036;
                          break;
                        case 3:
                          mybase4 = tempIntValue + 1756;
                          break;
                        case 4:
                          mybase4 = tempIntValue + 2472;
                          break;
                        case 5:
                        case 6:
                          mybase4 = tempIntValue + 9308;
                          break;
                        case 7:
                        case 8:
                          mybase4 = tempIntValue + 10084;
                          break;
                        default:
                          mybase4 = tempIntValue + 9372;
                          break;
                      }
                    }
                    myref4 = 0;
                    SmartClass.ReadMyValueInt(account, ref myref4, mybase4);
                    account.Myself.MP = myref4;
                    if (account.MyFlag.Slow3000Read)
                    {
                      int mybase5;
                      if (num7 == 356)
                      {
                        mybase5 = tempIntValue + 10200;
                      }
                      else
                      {
                        switch (versionNum)
                        {
                          case 1:
                          case 2:
                            mybase5 = tempIntValue + 10160;
                            break;
                          case 3:
                            mybase5 = tempIntValue + 1856;
                            break;
                          case 4:
                            mybase5 = tempIntValue + 2584;
                            break;
                          case 5:
                          case 6:
                            mybase5 = tempIntValue + 9432;
                            break;
                          case 7:
                          case 8:
                            mybase5 = tempIntValue + 10200;
                            break;
                          default:
                            mybase5 = tempIntValue + 9496;
                            break;
                        }
                      }
                      myref4 = 0;
                      SmartClass.ReadMyValueInt(account, ref myref4, mybase5);
                      account.Myself.MaxHP = myref4;
                      if (num7 == 356)
                      {
                        mybase4 = tempIntValue + 10204;
                      }
                      else
                      {
                        switch (versionNum)
                        {
                          case 1:
                          case 2:
                            mybase4 = tempIntValue + 10164;
                            break;
                          case 3:
                            mybase4 = tempIntValue + 1860;
                            break;
                          case 4:
                            mybase4 = tempIntValue + 2588;
                            break;
                          case 5:
                          case 6:
                            mybase4 = tempIntValue + 9436;
                            break;
                          case 7:
                          case 8:
                            mybase4 = tempIntValue + 10204;
                            break;
                          default:
                            mybase4 = tempIntValue + 9500;
                            break;
                        }
                      }
                      myref4 = 0;
                      SmartClass.ReadMyValueInt(account, ref myref4, mybase4);
                      account.Myself.MaxMP = myref4;
                    }
                    if (account.MyFlag.Slow1000Read)
                    {
                      switch (versionNum)
                      {
                        case 1:
                        case 2:
                          mybase4 = tempIntValue + 112 /*0x70*/;
                          break;
                        case 3:
                          mybase4 = tempIntValue + 96 /*0x60*/;
                          break;
                        case 4:
                          mybase4 = tempIntValue + 100;
                          break;
                        case 5:
                        case 6:
                          mybase4 = tempIntValue + 104;
                          break;
                        case 7:
                        case 8:
                          mybase4 = tempIntValue + 112 /*0x70*/;
                          break;
                      }
                      myref4 = 0;
                      SmartClass.ReadMyValueInt(account, ref myref4, mybase4);
                      account.Myself.Rage = myref4;
                      if (versionNum == 3)
                        mybase4 = tempIntValue + 160 /*0xA0*/;
                      else if (versionNum == 4)
                        mybase4 = tempIntValue + 160 /*0xA0*/;
                      else if (versionNum == 5 || versionNum == 6)
                        mybase4 = tempIntValue + 232;
                      else if (versionNum == 7 || versionNum == 8)
                        mybase4 = tempIntValue + 240 /*0xF0*/;
                      else if (versionNum == 1 || versionNum == 2)
                        mybase4 = tempIntValue + 236;
                      myref4 = 0;
                      SmartClass.ReadMyValueInt(account, ref myref4, mybase4);
                      account.Myself.BangID = myref4;
                      switch (versionNum)
                      {
                        case 3:
                          mybase4 = tempIntValue + 164;
                          break;
                        case 4:
                          mybase4 = tempIntValue + 164;
                          break;
                        default:
                          if (versionNum == 5 || versionNum == 6)
                          {
                            mybase4 = tempIntValue + 236;
                            break;
                          }
                          if (versionNum == 7 || versionNum == 8)
                          {
                            mybase4 = tempIntValue + 244;
                            break;
                          }
                          if (versionNum == 1 || versionNum == 2)
                          {
                            mybase4 = tempIntValue + 240 /*0xF0*/;
                            break;
                          }
                          break;
                      }
                      myref4 = 0;
                      SmartClass.ReadMyValueInt(account, ref myref4, mybase4);
                      account.Myself.DongMinhID = myref4;
                      switch (versionNum)
                      {
                        case 3:
                          mybase4 = tempIntValue + 92;
                          break;
                        case 4:
                          mybase4 = tempIntValue + 96 /*0x60*/;
                          break;
                        default:
                          if (versionNum == 7 || versionNum == 8)
                          {
                            mybase4 = tempIntValue + 108;
                            break;
                          }
                          if (versionNum == 1 || versionNum == 2)
                          {
                            mybase4 = tempIntValue + 108;
                            break;
                          }
                          if (versionNum == 5 || versionNum == 6)
                          {
                            mybase4 = tempIntValue + 100;
                            break;
                          }
                          break;
                      }
                      myref4 = 0;
                      SmartClass.ReadMyValueInt(account, ref myref4, mybase4);
                      account.Myself.Level = myref4;
                      if (num7 == 356)
                      {
                        mybase4 = tempIntValue + 10088;
                      }
                      else
                      {
                        switch (versionNum)
                        {
                          case 1:
                          case 2:
                            mybase4 = tempIntValue + 10040;
                            break;
                          case 3:
                            mybase4 = tempIntValue + 1760;
                            break;
                          case 4:
                            mybase4 = tempIntValue + 2476;
                            break;
                          case 5:
                          case 6:
                            mybase4 = tempIntValue + 9312;
                            break;
                          case 7:
                          case 8:
                            mybase4 = tempIntValue + 10088;
                            break;
                        }
                      }
                      myref4 = 0;
                      SmartClass.ReadMyValueInt(account, ref myref4, mybase4);
                      account.Myself.CurentExp = myref4;
                      if (num7 == 356)
                        mybase4 = tempIntValue + 10092;
                      else if (versionNum <= 2)
                        mybase4 = tempIntValue + 10044;
                      myref4 = 0;
                      SmartClass.ReadMyValueInt(account, ref myref4, mybase4);
                      account.Myself.CurrentGold = myref4;
                    }
                    switch (versionNum)
                    {
                      case 1:
                      case 2:
                        mybase4 = tempIntValue + 164;
                        break;
                      case 3:
                        mybase4 = tempIntValue + 148;
                        break;
                      case 4:
                        mybase4 = tempIntValue + 152;
                        break;
                      case 5:
                      case 6:
                        mybase4 = tempIntValue + 156;
                        break;
                      case 7:
                      case 8:
                        mybase4 = tempIntValue + 164;
                        break;
                    }
                    myref4 = -1;
                    SmartClass.ReadMyValueInt(account, ref myref4, mybase4);
                    account.Myself.HorseType = myref4;
                    if (num7 == 356)
                    {
                      mybase4 = tempIntValue + 244;
                    }
                    else
                    {
                      switch (versionNum)
                      {
                        case 1:
                        case 2:
                          mybase4 = tempIntValue + 236;
                          break;
                        case 3:
                          mybase4 = tempIntValue + 168;
                          break;
                        case 4:
                          mybase4 = tempIntValue + 172;
                          break;
                        case 5:
                        case 6:
                          mybase4 = tempIntValue + 240 /*0xF0*/;
                          break;
                        case 7:
                        case 8:
                          mybase4 = tempIntValue + 244;
                          break;
                      }
                    }
                    myref4 = 0;
                    account.Myself.tempMenpai = account.Myself.Menpai;
                    SmartClass.ReadMyValueInt(account, ref myref4, mybase4);
                    account.Myself.Menpai = (AllEnums.Menpais) myref4;
                    account.MyFlag.ReadMenPai = true;
                    if (account.MyFlag.Slow3000Read)
                    {
                      switch (versionNum)
                      {
                        case 1:
                        case 2:
                          mybase4 = tempIntValue + 24;
                          break;
                        case 3:
                        case 4:
                          mybase4 = tempIntValue + 16 /*0x10*/;
                          break;
                        case 5:
                        case 6:
                          mybase4 = tempIntValue + 24;
                          break;
                        case 7:
                        case 8:
                          mybase4 = tempIntValue + 24;
                          break;
                        default:
                          mybase4 = tempIntValue + 20;
                          break;
                      }
                      myref4 = 0;
                      SmartClass.ReadMyValueInt(account, ref myref4, mybase4);
                      account.Myself.DatabaseID = myref4;
                      if (versionNum == 7 || versionNum == 8 || versionNum == 1 || versionNum == 2)
                      {
                        mybase4 = tempIntValue + 20;
                        myref4 = 0;
                        SmartClass.ReadMyValueInt(account, ref myref4, mybase4);
                        account.Myself.DatabaseIDLow = myref4;
                      }
                    }
                    if (account.MyPet != null && account.MyFlag.Slow1000Read)
                    {
                      if (num7 == 356)
                      {
                        mybase4 = tempIntValue + 10140;
                      }
                      else
                      {
                        switch (versionNum)
                        {
                          case 1:
                          case 2:
                            mybase4 = tempIntValue + 10092;
                            break;
                          case 3:
                            mybase4 = tempIntValue + 1808;
                            break;
                          case 4:
                            mybase4 = tempIntValue + 2528;
                            break;
                          case 5:
                          case 6:
                            mybase4 = tempIntValue + 9364;
                            break;
                          case 7:
                          case 8:
                            mybase4 = tempIntValue + 10140;
                            break;
                        }
                      }
                      myref4 = 0;
                      SmartClass.ReadMyValueInt(account, ref myref4, mybase4);
                      account.MyPet.ActivePetGuidID = myref4;
                      if (num7 == 356)
                      {
                        mybase4 = tempIntValue + 10144;
                      }
                      else
                      {
                        switch (versionNum)
                        {
                          case 1:
                          case 2:
                            mybase4 = tempIntValue + 10096;
                            break;
                          case 3:
                            mybase4 = tempIntValue + 1812;
                            break;
                          case 4:
                            mybase4 = tempIntValue + 2532;
                            break;
                          case 5:
                          case 6:
                            mybase4 = tempIntValue + 9368;
                            break;
                          case 7:
                          case 8:
                            mybase4 = tempIntValue + 10144;
                            break;
                          default:
                            mybase4 = tempIntValue + 9432;
                            break;
                        }
                      }
                      myref4 = 0;
                      SmartClass.ReadMyValueInt(account, ref myref4, mybase4);
                      account.MyPet.ActivePetDBID = myref4;
                    }
                    if (account.Myself.MapID >= 0)
                    {
                      if (!account.MyFlag.IsInGame && account.MyFlag.Slow1000Read)
                      {
                        if ((account.MyFlag.CEHandle1 == 0 || account.MyFlag.CEHandle2 == 0 || account.MyFlag.LUAHandle == 0) && account.nowStamp() - account.MyFlag.GetDLLStamp >= 2000L)
                        {
                          account.MyFlag.GetDLLStamp = account.nowStamp();
                          account.CallGetVIPdll();
                        }
                        if (account.MyFlag.CEHandle1 != 0 && account.MyFlag.CEHandle2 != 0 && account.MyFlag.LUAHandle != 0)
                        {
                          lock (account.MyFlag.DLLReadyLock)
                            account.MyFlag.DLLReady = true;
                        }
                        if (GA.CheckIsInGame(account) && frmLogin.GAuto.Settings.optGCafe && !account.MyFlag.OKToInject)
                          account.MyFlag.OKToInject = true;
                        if (GA.CheckIsInGame(account) && account.MyFlag.InGameStamp == 0L)
                          account.MyFlag.InGameStamp = account.nowStamp();
                        if (account.nowStamp() - account.MyFlag.InGameStamp >= 500L && account.MyFlag.InGameStamp != 0L && account.MyFlag.DLLReady)
                        {
                          account.CallSetIsInGame(1);
                          account.SetDLLValue(1, -1);
                          account.MyFlag.IsInGame = true;
                          account.MyFlag.NeedAutoLogin = false;
                          account.MyFlag.ReadQuanDoanStamp = 0L;
                          if (account.MyFlag.LoginAction > 0)
                          {
                            if (account.MyFlag.LoginAction == 1)
                              account.Myself.isBachHoaDuyen = true;
                            account.MyFlag.LoginAction = 0;
                          }
                        }
                      }
                      if (account.MyFlag.IsInGame)
                      {
                        if (account.MyFlag.Slow1000Read)
                        {
                          switch (versionNum)
                          {
                            case 1:
                            case 2:
                              mybase4 = tempIntValue + 60;
                              break;
                            case 3:
                            case 4:
                              mybase4 = tempIntValue + 48 /*0x30*/;
                              break;
                            case 7:
                            case 8:
                              mybase4 = tempIntValue + 60;
                              break;
                            default:
                              mybase4 = tempIntValue + 52;
                              break;
                          }
                          string myref7 = "";
                          SmartClass.ReadMyValueString(account, ref myref7, mybase4);
                          account.Myself.SavedDisplayName = account.Myself.Name;
                          account.Myself.Name = myref7;
                          if (account.Myself.Name != account.Myself.SavedDisplayName)
                          {
                            if (account.Myself.Name != "")
                            {
                              try
                              {
                                account.MyFlag.JustNewAccount = true;
                                if (account.AutoProfile != null)
                                {
                                  if (frmGLogin.instance != null)
                                  {
                                    if (frmGLogin.instance.Visible)
                                      frmGLogin.instance.lbStatus.Invoke((Delegate) (() => account.AutoProfile.CharName = account.Myself.Name));
                                  }
                                }
                              }
                              catch (Exception ex)
                              {
                              }
                            }
                          }
                        }
                        if (account.MyFlag.Slow3000Read)
                        {
                          switch (versionNum)
                          {
                            case 3:
                              mybase4 = tempIntValue + 1696;
                              break;
                            case 4:
                              mybase4 = tempIntValue + 2408;
                              break;
                            case 5:
                            case 6:
                              mybase4 = tempIntValue + 9172;
                              break;
                            case 7:
                            case 8:
                              mybase4 = tempIntValue + 9888;
                              break;
                          }
                          if (versionNum > 2)
                          {
                            string myref8 = "";
                            SmartClass.ReadMyValueString(account, ref myref8, mybase4);
                            account.Myself.Username = myref8;
                            continue;
                          }
                          continue;
                        }
                        continue;
                      }
                      continue;
                    }
                    continue;
                  }
                  continue;
                case "rm10":
                  if (account.MyParty != null)
                  {
                    switch (tempIntValue)
                    {
                      case 0:
                        if (account.MyParty.PartyNumbers > 0)
                        {
                          account.MyFlag.ReadQuanDoanStamp = SmartClass.nowStamp() + 10000L;
                          goto case 1;
                        }
                        goto case 1;
                      case 1:
                      case 2:
                      case 3:
                      case 4:
                      case 5:
                        if (tempIntValue < account.MyParty.PartyNumbers_Saved)
                        {
                          ++account.MyParty.PartyNumbers_Counter;
                        }
                        else
                        {
                          account.MyParty.PartyNumbers = tempIntValue;
                          account.MyParty.PartyNumbers_Saved = tempIntValue;
                          account.MyParty.PartyNumbers_Counter = 0;
                        }
                        if (account.MyParty.PartyNumbers_Counter >= 4)
                        {
                          account.MyParty.PartyNumbers = tempIntValue;
                          account.MyParty.PartyNumbers_Saved = tempIntValue;
                          account.MyParty.PartyNumbers_Counter = 0;
                          continue;
                        }
                        continue;
                      default:
                        continue;
                    }
                  }
                  else
                    continue;
                default:
                  if (identifier == "rm17" && account.MyFlag.Slow3000Read)
                  {
                    if (account.Myself != null)
                    {
                      account.Myself.OnlineTime = tempIntValue;
                      continue;
                    }
                    continue;
                  }
                  if (identifier == "rm15")
                  {
                    if (account.Myself != null)
                    {
                      if (tempIntValue != 0 && tempIntValue != 1)
                      {
                        if (account.MyFlag.IsInGame && account.Myself.isSceneTrans == 0 && account.Myself.ID > 0 && frmLogin.GAuto.Settings.TipHuongDan && (account.MyFlag.WriteUserLogStamp == 0L || account.nowStamp() - account.MyFlag.WriteUserLogStamp > 300000L))
                        {
                          GA.WriteUserLog($"{frmMain.langLoiDuLieuAuto} - code BocShow {(object) tempIntValue}", account);
                          account.MyFlag.WriteUserLogStamp = account.nowStamp();
                        }
                      }
                      else
                        account.Myself.BocShow = tempIntValue;
                      if (account.MyBoc != null && account.Myself.BocShow == 0 && account.MyBoc.ActiveBocID != 0)
                      {
                        account.MyBoc.ActiveBocID = 0;
                        account.MyBoc.AllItems.Clear();
                        continue;
                      }
                      continue;
                    }
                    continue;
                  }
                  if (identifier == "rm36" && account.Myself.IsCheDo)
                  {
                    if (account.Myself != null && versionNum == 3)
                    {
                      if (tempIntValue != 0 && tempIntValue != 1)
                      {
                        if (account.MyFlag.IsInGame && account.Myself.isSceneTrans == 0 && account.Myself.ID > 0 && frmLogin.GAuto.Settings.TipHuongDan && (account.MyFlag.WriteUserLogStamp == 0L || account.nowStamp() - account.MyFlag.WriteUserLogStamp > 300000L))
                        {
                          GA.WriteUserLog($"{frmMain.langLoiDuLieuAuto} - code SynthShow {(object) tempIntValue}", account);
                          account.MyFlag.WriteUserLogStamp = account.nowStamp();
                          continue;
                        }
                        continue;
                      }
                      account.Myself.SynthesizeShow = tempIntValue;
                      continue;
                    }
                    continue;
                  }
                  if (identifier == "rm37" && (account.Myself.IsCheDo || account.Myself.isHuyItemNhiemVu))
                  {
                    if (account.Myself != null && versionNum == 3)
                    {
                      if (tempIntValue != 0 && tempIntValue != 1)
                      {
                        if (account.MyFlag.IsInGame && account.Myself.isSceneTrans == 0 && account.Myself.ID > 0 && frmLogin.GAuto.Settings.TipHuongDan && (account.MyFlag.WriteUserLogStamp == 0L || account.nowStamp() - account.MyFlag.WriteUserLogStamp > 300000L))
                        {
                          GA.WriteUserLog($"{frmMain.langLoiDuLieuAuto} - code InvenShow {(object) tempIntValue}", account);
                          account.MyFlag.WriteUserLogStamp = account.nowStamp();
                          continue;
                        }
                        continue;
                      }
                      account.Myself.InventoryShow = tempIntValue;
                      continue;
                    }
                    continue;
                  }
                  switch (identifier)
                  {
                    case "rm32":
                      if (account.Myself != null && tempIntValue > 0)
                      {
                        switch (versionNum)
                        {
                          case 1:
                          case 2:
                            mybase1 = tempIntValue + 564;
                            break;
                          case 3:
                            mybase1 = tempIntValue + 404;
                            break;
                          case 4:
                            mybase1 = tempIntValue + 500;
                            break;
                          case 5:
                          case 6:
                            mybase1 = tempIntValue + 548;
                            break;
                          case 7:
                          case 8:
                            mybase1 = tempIntValue + 564;
                            break;
                        }
                        float myref9 = 0.0f;
                        SmartClass.ReadMyValueFloat(account, ref myref9, mybase1);
                        if ((double) account.Myself.ToX != (double) myref9)
                        {
                          account.Myself.ToX = myref9;
                          account.Myself.ToXnow = myref9;
                        }
                        switch (versionNum)
                        {
                          case 1:
                          case 2:
                            mybase1 = tempIntValue + 568;
                            break;
                          case 3:
                            mybase1 = tempIntValue + 408;
                            break;
                          case 4:
                            mybase1 = tempIntValue + 504;
                            break;
                          case 5:
                          case 6:
                            mybase1 = tempIntValue + 552;
                            break;
                          case 7:
                          case 8:
                            mybase1 = tempIntValue + 568;
                            break;
                        }
                        float myref10 = 0.0f;
                        SmartClass.ReadMyValueFloat(account, ref myref10, mybase1);
                        if ((double) account.Myself.ToY != (double) myref10)
                        {
                          account.Myself.ToY = myref10;
                          account.Myself.ToYnow = myref10;
                          continue;
                        }
                        continue;
                      }
                      continue;
                    case "rm7":
                      if (account.MyPet != null && tempIntValue > 0)
                      {
                        num1 = 0;
                        switch (versionNum)
                        {
                          case 1:
                          case 2:
                            myref4 = 416;
                            break;
                          case 3:
                            myref4 = 240 /*0xF0*/;
                            break;
                          case 4:
                            myref4 = 316;
                            break;
                          case 5:
                          case 6:
                            myref4 = 360;
                            break;
                          case 7:
                          case 8:
                            myref4 = 416;
                            break;
                        }
                        for (int index4 = 0; index4 < 10; ++index4)
                        {
                          myref1 = 0;
                          bool flag2 = false;
                          string petName = account.MyPet.AllPets[index4].PetName;
                          if (account.MyFlag.Slow1000Read)
                          {
                            if (petName == "")
                              flag2 = true;
                            if (petName == account.MyPet.AlwaysActivePetName || petName == account.MyPet.CongSinhPetName || petName == account.MyPet.HuyetTePetName || flag2 || account.MyPet.AllPets[index4].DatabaseID == account.MyPet.ActivePetDBID)
                            {
                              flag2 = true;
                              int mybase6 = versionNum == 3 || versionNum == 4 ? tempIntValue + index4 * myref4 + 60 : tempIntValue + index4 * myref4 + 72;
                              myref1 = 0;
                              SmartClass.ReadMyValueInt(account, ref myref1, mybase6);
                              account.MyPet.AllPets[index4].HP = myref1;
                              if (myref1 == -1)
                              {
                                if (account.MyPet.AllPets[index4].PetName != "")
                                {
                                  account.MyPet.AllPets[index4].PetName = "";
                                  break;
                                }
                                break;
                              }
                            }
                          }
                          if (account.MyFlag.Slow1000Read)
                          {
                            int mybase7 = versionNum == 3 || versionNum == 4 ? tempIntValue + index4 * myref4 + 8 : tempIntValue + index4 * myref4 + 12;
                            myref1 = 0;
                            SmartClass.ReadMyValueInt(account, ref myref1, mybase7);
                            bool flag3 = true;
                            if (account.MyPet.AllPets[index4].DatabaseID != myref1)
                              account.MyPet.AllPets[index4].DatabaseID = myref1;
                            else
                              flag3 = false;
                            if (myref1 < 1)
                            {
                              if (account.MyPet.AllPets[index4].PetName != "")
                              {
                                account.MyPet.AllPets[index4].PetName = "";
                                break;
                              }
                              break;
                            }
                            if (flag2 && (petName == account.MyPet.AlwaysActivePetName || petName == account.MyPet.CongSinhPetName || petName == account.MyPet.HuyetTePetName || account.MyPet.AllPets[index4].DatabaseID == account.MyPet.ActivePetDBID))
                            {
                              int mybase8 = versionNum == 3 || versionNum == 4 ? tempIntValue + index4 * myref4 + 76 : tempIntValue + index4 * myref4 + 88;
                              myref1 = 0;
                              SmartClass.ReadMyValueInt(account, ref myref1, mybase8);
                              account.MyPet.AllPets[index4].Happiness = myref1;
                              int mybase9 = versionNum == 3 || versionNum == 4 ? tempIntValue + index4 * myref4 + 12 : tempIntValue + index4 * myref4 + 16 /*0x10*/;
                              myref1 = 0;
                              SmartClass.ReadMyValueInt(account, ref myref1, mybase9);
                              account.MyPet.AllPets[index4].ID = myref1;
                              mybase7 = versionNum == 3 || versionNum == 4 ? tempIntValue + index4 * myref4 + 64 /*0x40*/ : tempIntValue + index4 * myref4 + 76;
                              myref1 = 0;
                              SmartClass.ReadMyValueInt(account, ref myref1, mybase7);
                              account.MyPet.AllPets[index4].MaxHP = myref1;
                            }
                            if (flag3 || petName == "")
                            {
                              // hoint: fix get pet LV để gọi pet
                              if (versionNum == 1 || versionNum == 2)
                              {
                                mybase7 = tempIntValue + index4 * myref4 + 72;
                              }
                              else
                              {
                                mybase7 = tempIntValue + index4 * myref4 + 52;
                              }
                              myref1 = 0;
                              SmartClass.ReadMyValueInt(account, ref myref1, mybase7);

                              account.MyPet.AllPets[index4].Level = myref1;
                              int myref11 = versionNum == 3 || versionNum == 4 ? tempIntValue + index4 * myref4 + 48 /*0x30*/ : tempIntValue + index4 * myref4 + 56;
                              SmartClass.ReadMyValueInt(account, ref myref11, myref11);
                              int myref12;
                              if (myref11 == 31 /*0x1F*/)
                              {
                                myref12 = versionNum == 3 || versionNum == 4 ? tempIntValue + index4 * myref4 + 28 : tempIntValue + index4 * myref4 + 36;
                                SmartClass.ReadMyValueInt(account, ref myref12, myref12);
                              }
                              else
                                myref12 = versionNum == 3 || versionNum == 4 ? tempIntValue + index4 * myref4 + 28 : tempIntValue + index4 * myref4 + 36;
                              if (account.Myself != null && account.Myself.MapID >= 0)
                              {
                                SmartClass.ReadMyValueString(account, ref myref2, myref12);
                                account.MyPet.AllPets[index4].PetName = myref2;
                              }
                              int mybase10 = versionNum == 3 || versionNum == 4 ? tempIntValue + index4 * myref4 + 4 : tempIntValue + index4 * myref4 + 8;
                              myref1 = 0;
                              SmartClass.ReadMyValueInt(account, ref myref1, mybase10);
                              account.MyPet.AllPets[index4].PetOwnerDBID = myref1;
                              if (account.MyFlag.Slow1000Read)
                              {
                                int mybase11;
                                switch (versionNum)
                                {
                                  case 3:
                                    mybase11 = tempIntValue + index4 * myref4 + 204;
                                    break;
                                  case 4:
                                    mybase11 = tempIntValue + index4 * myref4 + 256 /*0x0100*/;
                                    break;
                                  default:
                                    mybase11 = tempIntValue + index4 * myref4 + 288;
                                    break;
                                }
                                myref1 = 0;
                                SmartClass.ReadMyValueInt(account, ref myref1, mybase11);
                                SmartClass.ReadMyValueInt(account, ref myref1, myref1);
                                SmartClass.ReadMyValueInt(account, ref myref1, myref1);
                                SmartClass.ReadMyValueInt(account, ref myref1, myref1);
                                account.MyPet.AllPets[index4].PetSkill1 = myref1;
                                myref1 = 0;
                                SmartClass.ReadMyValueInt(account, ref myref1, mybase11);
                                SmartClass.ReadMyValueInt(account, ref myref1, myref1 + 4);
                                SmartClass.ReadMyValueInt(account, ref myref1, myref1);
                                SmartClass.ReadMyValueInt(account, ref myref1, myref1);
                                account.MyPet.AllPets[index4].PetSkill2 = myref1;
                                myref1 = 0;
                                SmartClass.ReadMyValueInt(account, ref myref1, mybase11);
                                SmartClass.ReadMyValueInt(account, ref myref1, myref1 + 8);
                                SmartClass.ReadMyValueInt(account, ref myref1, myref1);
                                SmartClass.ReadMyValueInt(account, ref myref1, myref1);
                                account.MyPet.AllPets[index4].PetSkill3 = myref1;
                                myref1 = 0;
                                SmartClass.ReadMyValueInt(account, ref myref1, mybase11);
                                SmartClass.ReadMyValueInt(account, ref myref1, myref1 + 12);
                                SmartClass.ReadMyValueInt(account, ref myref1, myref1);
                                SmartClass.ReadMyValueInt(account, ref myref1, myref1);
                                account.MyPet.AllPets[index4].PetSkill4 = myref1;
                              }
                            }
                          }
                        }
                        continue;
                      }
                      continue;
                    case "rm19":
                      if (account.Myself != null)
                      {
                        if (tempIntValue != account.Myself.MapID)
                        {
                          if (account.MyQuai != null)
                          {
                            account.MyQuai.AllQuai.Clear();
                            account.MyQuai.TargetID = -1;
                            account.MyQuai.SavedTargetID = -1;
                            account.MyQuai.TargetHPPercent = 0.0f;
                            account.MyQuai.CanAttackInt = 0;
                          }
                          if (account.MyQuai.IgnoredQuaiID.Count > 0)
                            account.MyQuai.IgnoredQuaiID.Clear();
                          if (account.MyBoc != null)
                          {
                            account.MyBoc.AllBocs.Clear();
                            account.MyBoc.ActiveBocID = 0;
                            account.MyBoc.PosX = 0.0f;
                            account.MyBoc.PosY = 0.0f;
                            account.MyBoc.LastTimeSeen = 0L;
                          }
                        }
                        account.Myself.MapID = tempIntValue;
                        continue;
                      }
                      continue;
                    case "rm23":
                      if (account.Myself != null)
                      {
                        for (int index5 = 0; index5 < 30; ++index5)
                        {
                          int mybase12;
                          switch (versionNum)
                          {
                            case 1:
                            case 2:
                              mybase12 = 260 + tempIntValue + index5 * 8;
                              break;
                            case 3:
                              mybase12 = 180 + tempIntValue + index5 * 8;
                              break;
                            case 4:
                              mybase12 = 184 + tempIntValue + index5 * 8;
                              break;
                            case 7:
                            case 8:
                              mybase12 = 252 + tempIntValue + index5 * 12;
                              break;
                            default:
                              mybase12 = 252 + tempIntValue + index5 * 8;
                              break;
                          }
                          int myref13 = -1;
                          SmartClass.ReadMyValueInt(account, ref myref13, mybase12);
                          account.Myself.GreenList[index5] = myref13;
                        }
                        continue;
                      }
                      continue;
                    case "rm9":
                      if (account.MyParty != null && tempIntValue > 0)
                      {
                        num1 = 0;
                        myref1 = 0;
                        myref4 = 0;
                        for (int index6 = 0; index6 <= account.MyParty.PartyNumbers; ++index6)
                        {
                          int mybase13 = tempIntValue + index6 * 4;
                          SmartClass.ReadMyValueInt(account, ref myref1, mybase13);
                          int num8 = 0;
                          if (versionNum == 7 || versionNum == 8 || versionNum == 1 || versionNum == 2)
                            num8 = 4;
                          bool flag4 = true;
                          if (versionNum == 7 || versionNum == 8 || versionNum == 1 || versionNum == 2)
                          {
                            int mybase14 = myref1;
                            myref4 = 0;
                            SmartClass.ReadMyValueInt(account, ref myref4, mybase14);
                            account.MyParty.AllMembers[index6].DatabaseIDLow = myref4;
                          }
                          int mybase15 = myref1 + num8;
                          myref4 = 0;
                          SmartClass.ReadMyValueInt(account, ref myref4, mybase15);
                          if (account.MyParty.AllMembers[index6].DatabaseID != myref4)
                          {
                            account.MyParty.AllMembers[index6].DatabaseID = myref4;
                            flag4 = false;
                          }
                          if (account.MyFlag.Slow1000Read)
                          {
                            int mybase16 = myref1 + 4 + num8;
                            myref4 = 0;
                            SmartClass.ReadMyValueInt(account, ref myref4, mybase16);
                            account.MyParty.AllMembers[index6].ID = myref4;
                            int mybase17 = myref1 + 8 + num8;
                            SmartClass.ReadMyValueInt16(account, ref myref4, mybase17);
                            account.MyParty.AllMembers[index6].MapID = myref4;
                          }
                          if (versionNum == 1 || versionNum == 2)
                            num8 += 40;
                          if (!flag4 || account.MyParty.AllMembers[index6].Name == "")
                          {
                            int mybase18 = versionNum == 3 || versionNum == 4 ? myref1 + 16 /*0x10*/ : myref1 + 20 + num8;
                            if (account.Myself != null && account.Myself.MapID >= 0)
                            {
                              SmartClass.ReadMyValueString(account, ref myref2, mybase18);
                              account.MyParty.AllMembers[index6].Name = myref2;
                            }
                            int mybase19 = versionNum == 3 || versionNum == 4 ? myref1 + 48 /*0x30*/ : myref1 + 52 + num8;
                            myref4 = 0;
                            SmartClass.ReadMyValueInt(account, ref myref4, mybase19);
                            account.MyParty.AllMembers[index6].Menpai = myref4;
                          }
                          if (account.MyFlag.Slow3000Read || !flag4)
                          {
                            int mybase20 = versionNum == 3 || versionNum == 4 ? myref1 + 56 : myref1 + 60 + num8;
                            myref4 = 0;
                            SmartClass.ReadMyValueInt(account, ref myref4, mybase20);
                            account.MyParty.AllMembers[index6].Level = myref4;
                          }
                          if (account.MyFlag.Slow3000Read)
                          {
                            int mybase21 = versionNum == 3 || versionNum == 4 ? myref1 + 76 : myref1 + 80 /*0x50*/ + num8;
                            myref4 = 0;
                            SmartClass.ReadMyValueInt(account, ref myref4, mybase21);
                            account.MyParty.AllMembers[index6].MaxHP = myref4;
                          }
                          int mybase22 = versionNum == 3 || versionNum == 4 ? myref1 + 64 /*0x40*/ : myref1 + 68 + num8;
                          float myref14 = 0.0f;
                          SmartClass.ReadMyValueFloat(account, ref myref14, mybase22);
                          account.MyParty.AllMembers[index6].PosX = myref14;
                          int mybase23 = versionNum == 3 || versionNum == 4 ? myref1 + 68 : myref1 + 72 + num8;
                          float myref15 = 0.0f;
                          SmartClass.ReadMyValueFloat(account, ref myref15, mybase23);
                          account.MyParty.AllMembers[index6].PosY = myref15;
                          int mybase24 = versionNum == 3 || versionNum == 4 ? myref1 + 72 : myref1 + 76 + num8;
                          myref4 = 0;
                          SmartClass.ReadMyValueInt(account, ref myref4, mybase24);
                          account.MyParty.AllMembers[index6].HP = myref4;
                        }
                        continue;
                      }
                      continue;
                    case "rm18":
                      if (account.Myself != null)
                      {
                        account.Myself.ActionStatus = num3;
                        continue;
                      }
                      continue;
                    case "rm11":
                      if (account.MySkills != null && account.MyFlag.ReadMenPai)
                      {
                        num1 = 0;
                        myref4 = 0;
                        account.MySkills.tempBasicSkill = account.MySkills.AllSkills[1].ID;
                        for (int index7 = 0; index7 < 10; ++index7)
                        {
                          int mybase25 = tempIntValue + 4 + index7 * 24;
                          myref4 = 0;
                          SmartClass.ReadMyValueInt(account, ref myref4, mybase25);
                          myref1 = account.MySkills.AllSkills[index7 + 1].ID;
                          account.MySkills.AllSkills[index7 + 1].ID = myref4;
                          if (myref1 != myref4 || !account.MySkills.AllSkills[index7 + 1].Searched)
                          {
                            account.MySkills.IDChangeList.Add(index7 + 1);
                            if (account.isSkillNguTong(myref4))
                            {
                              if (myref1 == myref4 - 1)
                              {
                                account.MyFlag.SkillNguTongID = myref4;
                                account.MyFlag.SkillNguTongReadmemChangeStamp = account.nowStamp();
                              }
                              else
                                account.MyFlag.SkillNguTongID = -1;
                            }
                          }
                        }
                        if (account.MySkills.tempBasicSkill != account.MySkills.AllSkills[1].ID)
                          GA.GetBasicSkill(account);
                        if (account.MyFlag.Slow1000Read)
                        {
                          for (int index8 = 10; index8 < 30; ++index8)
                          {
                            int mybase26 = tempIntValue + 724 + (index8 - 10) * 24;
                            myref4 = 0;
                            SmartClass.ReadMyValueInt(account, ref myref4, mybase26);
                            myref1 = account.MySkills.AllSkills[index8 + 1].ID;
                            account.MySkills.AllSkills[index8 + 1].ID = myref4;
                            if (myref1 != myref4 || !account.MySkills.AllSkills[index8 + 1].Searched)
                            {
                              account.MySkills.IDChangeList.Add(index8 + 1);
                              if (account.isSkillNguTong(myref4))
                              {
                                if (myref1 == myref4 - 1)
                                {
                                  account.MyFlag.SkillNguTongID = myref4;
                                  account.MyFlag.SkillNguTongReadmemChangeStamp = account.nowStamp();
                                }
                                else
                                  account.MyFlag.SkillNguTongID = -1;
                              }
                            }
                          }
                          for (int index9 = 30; index9 < 40; ++index9)
                          {
                            int mybase27 = versionNum == 3 || versionNum == 4 ? tempIntValue + 484 + (index9 - 30) * 24 : tempIntValue + 1444 + (index9 - 30) * 24;
                            myref4 = 0;
                            SmartClass.ReadMyValueInt(account, ref myref4, mybase27);
                            myref1 = account.MySkills.AllSkills[index9 + 1].ID;
                            account.MySkills.AllSkills[index9 + 1].ID = myref4;
                            if (myref1 != myref4 || !account.MySkills.AllSkills[index9 + 1].Searched)
                            {
                              account.MySkills.IDChangeList.Add(index9 + 1);
                              if (account.isSkillNguTong(myref4))
                              {
                                if (myref1 == myref4 - 1)
                                {
                                  account.MyFlag.SkillNguTongID = myref4;
                                  account.MyFlag.SkillNguTongReadmemChangeStamp = account.nowStamp();
                                }
                                else
                                  account.MyFlag.SkillNguTongID = -1;
                              }
                            }
                          }
                          for (int index10 = 40; index10 < 50; ++index10)
                          {
                            int mybase28 = versionNum == 3 || versionNum == 4 ? tempIntValue + 244 + (index10 - 40) * 24 : tempIntValue + 1684 + (index10 - 40) * 24;
                            myref4 = 0;
                            SmartClass.ReadMyValueInt(account, ref myref4, mybase28);
                            myref1 = account.MySkills.AllSkills[index10 + 1].ID;
                            account.MySkills.AllSkills[index10 + 1].ID = myref4;
                            if (myref1 != myref4 || !account.MySkills.AllSkills[index10 + 1].Searched)
                            {
                              account.MySkills.IDChangeList.Add(index10 + 1);
                              if (account.isSkillNguTong(myref4))
                              {
                                if (myref1 == myref4 - 1)
                                {
                                  account.MyFlag.SkillNguTongID = myref4;
                                  account.MyFlag.SkillNguTongReadmemChangeStamp = account.nowStamp();
                                }
                                else
                                  account.MyFlag.SkillNguTongID = -1;
                              }
                            }
                          }
                        }
                        if (!account.MySkills.LoadSkills && account.MyFlag.ReadMenPai || account.MyFlag.ReadSkillDBStamp != 0L && account.nowStamp() - account.MyFlag.ReadSkillDBStamp >= 5000L && account.MyFlag.ReadSkillDBCount < 2)
                        {
                          for (int index11 = 0; index11 < account.MySkills.SkillDelays.Count; ++index11)
                          {
                            var tempSkill = frmLogin.GAuto.SkillBookDB.First(s => account.MySkills.SkillDelays[index11].SkillBook == s.SkillBook
                                && account.MySkills.SkillDelays[index11].BookSlot == s.BookSlot
                                && (account.Myself.Menpai == s.RealMenpai || s.RealMenpai == AllEnums.Menpais.ALLPHAI));
                            if (tempSkill != null)
                            {
                              account.MySkills.SkillDelays[index11].SkillID = tempSkill.SkillID;
                              account.MySkills.SkillDelays[index11].RageRequired = tempSkill.RageRequired;
                              account.MySkills.SkillDelays[index11].IsAttackPhat = tempSkill.IsAttackPhat;
                              account.MySkills.SkillDelays[index11].IsBuffPhat = tempSkill.IsBuffPhat;
                              account.MySkills.SkillDelays[index11].PKSlot = tempSkill.PKSlot;
                              account.MySkills.SkillDelays[index11].TrainSlot = tempSkill.TrainSlot;
                              account.MySkills.SkillDelays[index11].Special = tempSkill.Special;
                              account.MySkills.SkillDelays[index11].BuffPeriod = tempSkill.BuffPeriod;
                              account.MySkills.SkillDelays[index11].FoundInList = true;
                            }
                          }
                          if (account.Myself.Menpai != AllEnums.Menpais.THIEULAM)
                          {
                            account.MySkills.LoadSkills = true;
                            account.MyFlag.ReadSkillDBCount = 5;
                          }
                          else
                          {
                            ++account.MyFlag.ReadSkillDBCount;
                            if (account.MyFlag.ReadSkillDBStamp == 0L)
                              account.MyFlag.ReadSkillDBStamp = account.nowStamp();
                            if (account.MyFlag.ReadSkillDBCount >= 2)
                              account.MySkills.LoadSkills = true;
                          }
                        }
                        if (account.MySkills.IDChangeList.Count > 0)
                        {
                          if (account.MySkills.LoadSkills)
                          {
                            try
                            {
                              for (int index13 = 0; index13 < account.MySkills.IDChangeList.Count; ++index13)
                              {
                                for (int index14 = 0; index14 < account.MySkills.SkillDelays.Count; ++index14)
                                {
                                  if (account.MySkills.SkillDelays[index14].SkillID == account.MySkills.AllSkills[account.MySkills.IDChangeList[index13]].ID)
                                  {
                                    account.MySkills.AllSkills[account.MySkills.IDChangeList[index13]].SkillBook = account.MySkills.SkillDelays[index14].SkillBook;
                                    account.MySkills.AllSkills[account.MySkills.IDChangeList[index13]].BookSlot = account.MySkills.SkillDelays[index14].BookSlot;
                                    account.MySkills.AllSkills[account.MySkills.IDChangeList[index13]].DelayIndex = index14;
                                    account.MySkills.AllSkills[account.MySkills.IDChangeList[index13]].RageRequired = account.MySkills.SkillDelays[index14].RageRequired;
                                    account.MySkills.AllSkills[account.MySkills.IDChangeList[index13]].IsAttackPhat = account.MySkills.SkillDelays[index14].IsAttackPhat;
                                    account.MySkills.AllSkills[account.MySkills.IDChangeList[index13]].IsBuffPhat = account.MySkills.SkillDelays[index14].IsBuffPhat;
                                    account.MySkills.AllSkills[account.MySkills.IDChangeList[index13]].PKSlot = account.MySkills.SkillDelays[index14].PKSlot;
                                    account.MySkills.AllSkills[account.MySkills.IDChangeList[index13]].TrainSlot = account.MySkills.SkillDelays[index14].TrainSlot;
                                    account.MySkills.AllSkills[account.MySkills.IDChangeList[index13]].Special = account.MySkills.SkillDelays[index14].Special;
                                    account.MySkills.AllSkills[account.MySkills.IDChangeList[index13]].BuffPeriod = account.MySkills.SkillDelays[index14].BuffPeriod;
                                    account.MySkills.AllSkills[account.MySkills.IDChangeList[index13]].FoundInList = account.MySkills.SkillDelays[index14].FoundInList;
                                    break;
                                  }
                                }
                                account.MySkills.AllSkills[account.MySkills.IDChangeList[index13]].Searched = true;
                                account.MySkills.AllSkills[account.MySkills.IDChangeList[index13]].Name = account.Myself.Menpai == AllEnums.Menpais.QUYCOC ? GA.GetValidSkillName(GA.GetSkillName(account.MySkills.AllSkills[account.MySkills.IDChangeList[index13]].ID)) : GA.GetSkillName(account.MySkills.AllSkills[account.MySkills.IDChangeList[index13]].ID);
                                
                                //TODO: lỗi
                                account.MySkills.AllSkills[account.MySkills.IDChangeList[index13]].KeyDesc = GA.GetSkillButton(account.MySkills.AllSkills[account.MySkills.IDChangeList[index13]].ID, account);
                                SmartClass.AdjustSkillButton(account, index13);
                              }
                            }
                            catch (Exception ex)
                            {
                              if (!account.Target.SkillError)
                              {
                                account.Target.SkillError = true;
                                GA.WriteUserLog(frmMain.langErrorReadingSkill2, account);
                              }
                            }
                            finally
                            {
                              account.MySkills.IDChangeList.Clear();
                            }
                          }
                        }
                        if (account.Myself != null)
                        {
                          int mybase29 = tempIntValue + 1204;
                          myref4 = 0;
                          SmartClass.ReadMyValueInt(account, ref myref4, mybase29);
                          account.Myself.QLKF1 = myref4;
                          int mybase30 = tempIntValue + 1228;
                          myref4 = 0;
                          SmartClass.ReadMyValueInt(account, ref myref4, mybase30);
                          account.Myself.QLKF2 = myref4;
                          int mybase31 = tempIntValue + 1252;
                          myref4 = 0;
                          SmartClass.ReadMyValueInt(account, ref myref4, mybase31);
                          account.Myself.QLKF3 = myref4;
                          int mybase32 = tempIntValue + 1276;
                          myref4 = 0;
                          SmartClass.ReadMyValueInt(account, ref myref4, mybase32);
                          account.Myself.QLKF4 = myref4;
                          continue;
                        }
                        continue;
                      }
                      continue;
                    case "rm31":
                      if (account.MyPet != null)
                      {
                        if (account.MyFlag.PetXuatChienIndex > 0)
                          SmartClass.ReadPetSkillDelayByIndex(account, account.MyFlag.PetXuatChienIndex, tempIntValue);
                        if (account.MyFlag.PetCongSinhIndex > 0)
                          SmartClass.ReadPetSkillDelayByIndex(account, account.MyFlag.PetCongSinhIndex, tempIntValue);
                        if (account.MyFlag.PetHuyetTeIndex > 0)
                          SmartClass.ReadPetSkillDelayByIndex(account, account.MyFlag.PetHuyetTeIndex, tempIntValue);
                        if (account.CustomSleep(10, 60000))
                        {
                          num1 = 0;
                          account.MyFlag.PetXuatChienIndex = -1;
                          account.MyFlag.PetCongSinhIndex = -1;
                          account.MyFlag.PetHuyetTeIndex = -1;
                          for (int index15 = 0; index15 < 10; ++index15)
                          {
                            SmartClass.ReadPetSkillDelayByIndex(account, index15, tempIntValue);
                            if (account.MyPet.AllPets[index15].PetName == account.MyPet.AlwaysActivePetName)
                              account.MyFlag.PetXuatChienIndex = index15;
                            if (account.MyPet.AllPets[index15].PetName == account.MyPet.CongSinhPetName)
                              account.MyFlag.PetCongSinhIndex = index15;
                            if (account.MyPet.AllPets[index15].PetName == account.MyPet.HuyetTePetName)
                              account.MyFlag.PetHuyetTeIndex = index15;
                          }
                          continue;
                        }
                        continue;
                      }
                      continue;
                    case "rm24":
                      if (account.MyParty != null && tempIntValue > 0)
                      {
                        num1 = 0;
                        myref1 = 0;
                        myref4 = 0;
                        int num9 = tempIntValue;
                        bool flag5 = false;
                        int num10 = 240 /*0xF0*/;
                        for (int index16 = 0; index16 < 5; ++index16)
                        {
                          int mybase33 = num9 + index16 * 4;
                          myref1 = 0;
                          SmartClass.ReadMyValueInt(account, ref myref1, mybase33);
                          int mybase34 = myref1 + 4;
                          myref1 = 0;
                          SmartClass.ReadMyValueInt(account, ref myref1, mybase34);
                          int num11 = myref1;
                          for (int index17 = 0; index17 < 6; ++index17)
                          {
                            int mybase35 = num11 + index17 * 4;
                            myref1 = 0;
                            SmartClass.ReadMyValueInt(account, ref myref1, mybase35);
                            SmartClass.ReadMyValueInt(account, ref myref1, mybase35);
                            bool flag6 = true;
                            int mybase36 = myref1 + 4;
                            myref4 = 0;
                            SmartClass.ReadMyValueInt(account, ref myref4, mybase36);
                            int index18 = index16 * 6 + index17;
                            if (myref4 < 10000)
                            {
                              if (account.MyArmy.AllMembers[index18].DatabaseID > 0)
                              {
                                account.MyArmy.AllMembers[index18].DatabaseID = 0;
                                account.MyArmy.AllMembers[index18].ID = 0;
                                account.MyArmy.AllMembers[index18].Name = "";
                                account.MyArmy.AllMembers[index18].MapID = 0;
                                account.MyArmy.AllMembers[index18].HP = 0;
                              }
                            }
                            else
                            {
                              flag5 = true;
                              if (account.MyArmy.AllMembers[index18].DatabaseID != myref4)
                              {
                                account.MyArmy.AllMembers[index18].DatabaseID = myref4;
                                flag6 = false;
                              }
                              if (flag6)
                              {
                                int mybase37 = myref1;
                                myref4 = 0;
                                SmartClass.ReadMyValueInt(account, ref myref4, mybase37);
                                account.MyArmy.AllMembers[index18].DatabaseIDLow = myref4;
                              }
                              int num12 = 0;
                              if (versionNum == 7 || versionNum == 8 || versionNum == 1 || versionNum == 2)
                                num12 = 4;
                              if (account.MyFlag.Slow3000Read)
                              {
                                int mybase38 = myref1 + 4 + num12;
                                myref4 = 0;
                                SmartClass.ReadMyValueInt(account, ref myref4, mybase38);
                                account.MyArmy.AllMembers[index18].ID = myref4;
                                int mybase39 = myref1 + 8 + num12;
                                myref4 = 0;
                                SmartClass.ReadMyValueInt16(account, ref myref4, mybase39);
                                account.MyArmy.AllMembers[index18].MapID = myref4;
                              }
                              if (!flag6)
                              {
                                int mybase40 = myref1 + 16 /*0x10*/ + num12;
                                if (account.Myself != null && account.Myself.MapID >= 0)
                                {
                                  SmartClass.ReadMyValueString(account, ref myref2, mybase40);
                                  account.MyArmy.AllMembers[index18].Name = myref2;
                                }
                                int mybase41 = myref1 + 48 /*0x30*/ + num12;
                                myref4 = 0;
                                SmartClass.ReadMyValueInt16(account, ref myref4, mybase41);
                                account.MyArmy.AllMembers[index18].Menpai = myref4;
                                int mybase42 = myref1 + 56 + num12;
                                myref4 = 0;
                                SmartClass.ReadMyValueInt(account, ref myref4, mybase42);
                                account.MyArmy.AllMembers[index18].Level = myref4;
                                int mybase43 = myref1 + 76 + num12;
                                myref4 = 0;
                                SmartClass.ReadMyValueInt(account, ref myref4, mybase43);
                                account.MyArmy.AllMembers[index18].MaxHP = myref4;
                              }
                              int mybase44 = myref1 + 64 /*0x40*/ + num12;
                              SmartClass.ReadMyValueFloat(account, ref myref3, mybase44);
                              account.MyArmy.AllMembers[index18].PosX = myref3;
                              int mybase45 = myref1 + 68 + num12;
                              myref3 = 0.0f;
                              SmartClass.ReadMyValueFloat(account, ref myref3, mybase45);
                              account.MyArmy.AllMembers[index18].PosY = myref3;
                              int mybase46 = myref1 + 72 + num12;
                              myref4 = 0;
                              SmartClass.ReadMyValueInt(account, ref myref4, mybase46);
                              account.MyArmy.AllMembers[index18].HP = myref4;
                              num10 += 4;
                            }
                          }
                          num10 += 24;
                        }
                        if (flag5)
                        {
                          account.MyFlag.ReadQuanDoanStamp = SmartClass.nowStamp() + 20000L;
                          continue;
                        }
                        continue;
                      }
                      continue;
                    default:
                      if (identifier == "rm16" && (account.Settings.AIMode == AllEnums.AIModes.NHIEMVU || account.MyFlag.Slow1000Read))
                      {
                        if (account.MyInventory != null && tempIntValue > 0)
                        {
                          num1 = 0;
                          myref4 = 0;
                          for (int index19 = 0; index19 < 90; ++index19)
                          {
                            int myref16 = tempIntValue + index19 * 4;
                            SmartClass.ReadMyValueInt(account, ref myref4, myref16);
                            myref4 += 20;
                            SmartClass.ReadMyValueInt(account, ref myref16, myref4);
                            myref1 = myref16;
                            int mybase47 = myref1;
                            int itemGuiD1 = account.MyInventory.AllItems[index19].ItemGUID1;
                            SmartClass.ReadMyValueInt(account, ref myref4, mybase47);
                            if (versionNum == 7 || versionNum == 8 || versionNum == 1 || versionNum == 2)
                              account.MyInventory.AllItems[index19].ItemGUID2 = myref4;
                            else
                              account.MyInventory.AllItems[index19].ItemGUID1 = myref4;
                            int mybase48 = myref1 + 4;
                            int itemGuiD2 = account.MyInventory.AllItems[index19].ItemGUID2;
                            SmartClass.ReadMyValueInt(account, ref myref4, mybase48);
                            if (versionNum == 7 || versionNum == 8 || versionNum == 1 || versionNum == 2)
                              account.MyInventory.AllItems[index19].ItemGUID1 = myref4;
                            else
                              account.MyInventory.AllItems[index19].ItemGUID2 = myref4;
                            int mybase49 = myref1 + 8;
                            int itemId = account.MyInventory.AllItems[index19].ItemID;
                            myref4 = -1;
                            SmartClass.ReadMyValueInt(account, ref myref4, mybase49);
                            account.MyInventory.AllItems[index19].ItemID = myref4;
                            if (account.MyInventory.AllItems[index19].ItemID != itemId && account.MyInventory.AllItems[index19].ItemID >= 0 && (account.MyInventory.AllItems[index19].ItemGUID2 != itemGuiD2 || account.MyInventory.AllItems[index19].ItemGUID1 != itemGuiD1))
                            {
                              account.MyInventory.tempName = "";
                              account.MyInventory.tempType = "";
                              GA.GetItemNameTypeFromID(account.MyInventory.AllItems[index19].ItemID, out account.MyInventory.tempName, out account.MyInventory.tempType);
                              account.MyInventory.AllItems[index19].ItemName = account.MyInventory.tempName;
                              account.MyInventory.AllItems[index19].ItemType = account.MyInventory.tempType;
                              account.MyInventory.AllItems[index19].ItemStars = (byte) 0;
                              account.MyInventory.AllItems[index19].ItemSource = AllEnums.ItemSources.Chưa_biết;
                              account.MyInventory.AllItems[index19].Lines = (byte) 0;
                              account.MyInventory.AllItems[index19].SavedCode = 0;
                              account.MyInventory.AllItems[index19].LineValueArray.Clear();
                              account.MyInventory.AllItems[index19].LastTimeSeen = account.nowStamp();
                            }
                            int num13 = 0;
                            if (versionNum == 7 || versionNum == 8 || versionNum == 1 || versionNum == 2)
                              num13 = 4;
                            int mybase50 = versionNum != 3 ? myref1 + 60 + num13 : myref1 + 88;
                            SmartClass.ReadMyValueByte(account, ref myref4, mybase50);
                            account.MyInventory.AllItems[index19].ItemCount = (byte) myref4;
                            int mybase51 = versionNum != 3 ? myref1 + 48 /*0x30*/ + num13 : myref1 + 76;
                            SmartClass.ReadMyValueInt(account, ref myref4, mybase51);
                            account.MyInventory.AllItems[index19].BuyingPrice = myref4;
                            int mybase52;
                            switch (versionNum)
                            {
                              case 3:
                                mybase52 = myref1 + 80 /*0x50*/;
                                break;
                              case 4:
                                mybase52 = myref1 + 52;
                                break;
                              default:
                                mybase52 = myref1 + 52 + num13;
                                break;
                            }
                            SmartClass.ReadMyValueInt(account, ref myref4, mybase52);
                            account.MyInventory.AllItems[index19].SellingPrice = myref4;
                            SmartClass.ReadMyValueInt16(account, ref myref4, mybase52);
                            int itemMapId = account.MyInventory.AllItems[index19].ItemMapID;
                            account.MyInventory.AllItems[index19].ItemMapID = myref4;
                            int mybase53 = myref1 + 49 + num13;
                            SmartClass.ReadMyValueInt16(account, ref myref4, mybase53);
                            account.MyInventory.AllItems[index19].BTDMapID = myref4;
                            int mybase54;
                            switch (versionNum)
                            {
                              case 3:
                                mybase54 = myref1 + 79;
                                break;
                              case 4:
                                mybase54 = myref1 + 51;
                                break;
                              default:
                                mybase54 = myref1 + 51 + num13;
                                break;
                            }
                            int dinhViPhuTime = (int) account.MyInventory.AllItems[index19].DinhViPhuTime;
                            SmartClass.ReadMyValueByte(account, ref myref4, mybase54);
                            account.MyInventory.AllItems[index19].DinhViPhuTime = (byte) myref4;
                            if (dinhViPhuTime != (int) account.MyInventory.AllItems[index19].DinhViPhuTime)
                              GA.isVipMember();
                            SmartClass.ReadMyValueInt16(account, ref myref4, mybase54);
                            account.MyInventory.AllItems[index19].BTDposX = myref4;
                            int mybase55 = myref1 + 53 + num13;
                            SmartClass.ReadMyValueInt16(account, ref myref4, mybase55);
                            account.MyInventory.AllItems[index19].BTDposY = myref4;
                          }
                          continue;
                        }
                        continue;
                      }
                      switch (identifier)
                      {
                        case "rm22":
                          if (account.Myself != null)
                          {
                            if ((byte) tempIntValue != (byte) 0 && (byte) tempIntValue != (byte) 1 && (byte) tempIntValue != byte.MaxValue)
                            {
                              if (account.MyFlag.IsInGame && account.Myself.isSceneTrans == 0 && account.Myself.ID > 0 && frmLogin.GAuto.Settings.TipHuongDan && (account.MyFlag.WriteUserLogStamp == 0L || account.nowStamp() - account.MyFlag.WriteUserLogStamp > 1800000L))
                              {
                                GA.WriteUserLog($"{frmMain.langLoiDuLieuAuto} - code PartyFollowed {(object) (byte) tempIntValue}", account);
                                account.MyFlag.WriteUserLogStamp = account.nowStamp();
                                continue;
                              }
                              continue;
                            }
                            account.Myself.IsPartyFollowed = (byte) tempIntValue;
                            if (account.Myself.IsPartyFollowed == (byte) 1)
                            {
                              account.Myself.FlagPartyFollowRequest = (byte) 0;
                              continue;
                            }
                            continue;
                          }
                          continue;
                        case "rm30":
                          if (account.MySkills != null)
                          {
                            num1 = 0;
                            myref4 = 0;
                            if (account.Myself.Menpai == AllEnums.Menpais.NGAMI)
                            {
                              int mybase56 = tempIntValue + 696;
                              SmartClass.ReadMyValueInt(account, ref myref4, mybase56);
                              account.MySkills.XungHuDelay = myref4;
                              int mybase57 = tempIntValue + 876;
                              SmartClass.ReadMyValueInt(account, ref myref4, mybase57);
                              account.MySkills.ThanhTamDelay = myref4;
                              int mybase58 = tempIntValue + 708;
                              SmartClass.ReadMyValueInt(account, ref myref4, mybase58);
                              account.MySkills.HoiSinhDelay = myref4;
                            }
                            int mybase59 = tempIntValue + 660;
                            SmartClass.ReadMyValueInt(account, ref myref4, mybase59);
                            account.MySkills.ChayNhanhDelay1 = myref4;
                            int mybase60 = tempIntValue + 720;
                            SmartClass.ReadMyValueInt(account, ref myref4, mybase60);
                            account.MySkills.ChayNhanhDelay2 = myref4;
                            int mybase61 = tempIntValue + 756;
                            SmartClass.ReadMyValueInt(account, ref myref4, mybase61);
                            account.MySkills.ChayNhanhDelay3 = myref4;
                            if (account.MyFlag.Slow3000Read)
                            {
                              int mybase62 = tempIntValue + 612;
                              SmartClass.ReadMyValueInt(account, ref myref4, mybase62);
                              account.MySkills.PhuDaiLyDelay = myref4;
                            }
                            myref4 = -2;
                            int mybase63 = tempIntValue + 636;
                            SmartClass.ReadMyValueInt(account, ref myref4, mybase63);
                            account.MySkills.SkillDelays[0].SkillDelay = myref4;
                            int mybase64 = tempIntValue + 852;
                            SmartClass.ReadMyValueInt(account, ref myref4, mybase64);
                            account.MySkills.SkillDelays[1].SkillDelay = myref4;
                            int mybase65 = tempIntValue + 648;
                            SmartClass.ReadMyValueInt(account, ref myref4, mybase65);
                            account.MySkills.SkillDelays[2].SkillDelay = myref4;
                            int mybase66 = tempIntValue + 660;
                            SmartClass.ReadMyValueInt(account, ref myref4, mybase66);
                            account.MySkills.SkillDelays[3].SkillDelay = myref4;
                            int mybase67 = tempIntValue + 672;
                            SmartClass.ReadMyValueInt(account, ref myref4, mybase67);
                            account.MySkills.SkillDelays[4].SkillDelay = myref4;
                            int mybase68 = tempIntValue + 684;
                            SmartClass.ReadMyValueInt(account, ref myref4, mybase68);
                            account.MySkills.SkillDelays[5].SkillDelay = myref4;
                            int mybase69 = tempIntValue + 696;
                            SmartClass.ReadMyValueInt(account, ref myref4, mybase69);
                            account.MySkills.SkillDelays[6].SkillDelay = myref4;
                            int mybase70 = tempIntValue + 708;
                            SmartClass.ReadMyValueInt(account, ref myref4, mybase70);
                            account.MySkills.SkillDelays[7].SkillDelay = myref4;
                            int mybase71 = tempIntValue + 720;
                            SmartClass.ReadMyValueInt(account, ref myref4, mybase71);
                            account.MySkills.SkillDelays[8].SkillDelay = myref4;
                            int mybase72 = tempIntValue + 732;
                            SmartClass.ReadMyValueInt(account, ref myref4, mybase72);
                            account.MySkills.SkillDelays[9].SkillDelay = myref4;
                            int mybase73 = tempIntValue + 744;
                            SmartClass.ReadMyValueInt(account, ref myref4, mybase73);
                            account.MySkills.SkillDelays[10].SkillDelay = myref4;
                            int mybase74 = tempIntValue + 756;
                            SmartClass.ReadMyValueInt(account, ref myref4, mybase74);
                            account.MySkills.SkillDelays[11].SkillDelay = myref4;
                            int mybase75 = tempIntValue + 768 /*0x0300*/;
                            SmartClass.ReadMyValueInt(account, ref myref4, mybase75);
                            account.MySkills.SkillDelays[12].SkillDelay = myref4;
                            int mybase76 = tempIntValue + 744;
                            SmartClass.ReadMyValueInt(account, ref myref4, mybase76);
                            account.MySkills.SkillDelays[13].SkillDelay = myref4;
                            int mybase77 = tempIntValue + 792;
                            SmartClass.ReadMyValueInt(account, ref myref4, mybase77);
                            account.MySkills.SkillDelays[14].SkillDelay = myref4;
                            int mybase78 = tempIntValue + 804;
                            SmartClass.ReadMyValueInt(account, ref myref4, mybase78);
                            account.MySkills.SkillDelays[15].SkillDelay = myref4;
                            int mybase79 = tempIntValue + 816;
                            SmartClass.ReadMyValueInt(account, ref myref4, mybase79);
                            account.MySkills.SkillDelays[16 /*0x10*/].SkillDelay = myref4;
                            int mybase80 = tempIntValue + 828;
                            SmartClass.ReadMyValueInt(account, ref myref4, mybase80);
                            account.MySkills.SkillDelays[17].SkillDelay = myref4;
                            int mybase81 = tempIntValue + 840;
                            SmartClass.ReadMyValueInt(account, ref myref4, mybase81);
                            account.MySkills.SkillDelays[18].SkillDelay = myref4;
                            int mybase82 = account.Myself.Menpai != AllEnums.Menpais.NGAMI ? tempIntValue + 864 : tempIntValue + 876;
                            SmartClass.ReadMyValueInt(account, ref myref4, mybase82);
                            account.MySkills.SkillDelays[19].SkillDelay = myref4;
                            int mybase83 = account.Myself.Menpai != AllEnums.Menpais.NGAMI ? tempIntValue + 876 : tempIntValue + 1416;
                            SmartClass.ReadMyValueInt(account, ref myref4, mybase83);
                            account.MySkills.SkillDelays[20].SkillDelay = myref4;
                            int mybase84 = tempIntValue + 1596;
                            SmartClass.ReadMyValueInt(account, ref myref4, mybase84);
                            account.MySkills.SkillDelays[21].SkillDelay = myref4;
                            int mybase85 = tempIntValue + 1560;
                            SmartClass.ReadMyValueInt(account, ref myref4, mybase85);
                            account.MySkills.SkillDelays[22].SkillDelay = myref4;
                            int mybase86 = tempIntValue + 1392;
                            SmartClass.ReadMyValueInt(account, ref myref4, mybase86);
                            account.MySkills.SkillDelays[23].SkillDelay = myref4;
                            int mybase87 = tempIntValue + 1284;
                            SmartClass.ReadMyValueInt(account, ref myref4, mybase87);
                            account.MySkills.SkillDelays[24].SkillDelay = myref4;
                            int mybase88 = tempIntValue + 1380;
                            SmartClass.ReadMyValueInt(account, ref myref4, mybase88);
                            account.MySkills.SkillDelays[25].SkillDelay = myref4;
                            int mybase89 = tempIntValue + 1236;
                            SmartClass.ReadMyValueInt(account, ref myref4, mybase89);
                            account.MySkills.SkillDelays[26].SkillDelay = myref4;
                            continue;
                          }
                          continue;
                        case "rm25":
                          if (account.Myself != null)
                          {
                            if (tempIntValue != 0 && tempIntValue != 1)
                            {
                              if (account.MyFlag.IsInGame && account.Myself.isSceneTrans == 0 && account.Myself.ID > 0 && frmLogin.GAuto.Settings.TipHuongDan && (account.MyFlag.WriteUserLogStamp == 0L || account.nowStamp() - account.MyFlag.WriteUserLogStamp > 1800000L))
                              {
                                GA.WriteUserLog($"{frmMain.langLoiDuLieuAuto} - code AcceptBox {(object) tempIntValue}", account);
                                account.MyFlag.WriteUserLogStamp = account.nowStamp();
                                continue;
                              }
                              continue;
                            }
                            account.Myself.isAcceptBox = tempIntValue;
                            continue;
                          }
                          continue;
                        case "rm26":
                          if (account.Myself != null)
                          {
                            if (tempIntValue != 0 && tempIntValue != 1)
                            {
                              if (account.MyFlag.IsInGame && account.Myself.isSceneTrans == 0 && account.Myself.ID > 0 && frmLogin.GAuto.Settings.TipHuongDan && (account.MyFlag.WriteUserLogStamp == 0L || account.nowStamp() - account.MyFlag.WriteUserLogStamp > 1800000L))
                              {
                                GA.WriteUserLog($"{frmMain.langLoiDuLieuAuto} - code MessageBox_Self {(object) tempIntValue}", account);
                                account.MyFlag.WriteUserLogStamp = account.nowStamp();
                                continue;
                              }
                              continue;
                            }
                            account.Myself.isMessageBox_Self = tempIntValue;
                            continue;
                          }
                          continue;
                        case "rm28":
                          if (account.Myself != null)
                          {
                            if (num3 != (byte) 0 && num3 != (byte) 1)
                            {
                              if (account.MyFlag.IsInGame && account.Myself.isSceneTrans == 0 && account.Myself.ID > 0 && frmLogin.GAuto.Settings.TipHuongDan && (account.MyFlag.WriteUserLogStamp == 0L || account.nowStamp() - account.MyFlag.WriteUserLogStamp > 300000L))
                              {
                                GA.WriteUserLog($"{frmMain.langLoiDuLieuAuto} - code AttackStatus {(object) num3}", account);
                                account.MyFlag.WriteUserLogStamp = account.nowStamp();
                                continue;
                              }
                              continue;
                            }
                            account.Myself.AttackStatus = num3;
                            continue;
                          }
                          continue;
                        default:
                          if (identifier == "rm29" && account.Settings.cboxPassCap2 && account.MyFlag.Slow1000Read)
                          {
                            if (account.Myself != null)
                            {
                              if (tempIntValue != 0 && tempIntValue != 1)
                              {
                                if (account.MyFlag.IsInGame && account.Myself.isSceneTrans == 0 && account.Myself.ID > 0 && frmLogin.GAuto.Settings.TipHuongDan && (account.MyFlag.WriteUserLogStamp == 0L || account.nowStamp() - account.MyFlag.WriteUserLogStamp > 300000L))
                                {
                                  GA.WriteUserLog($"{frmMain.langLoiDuLieuAuto} - code Pass2box {(object) tempIntValue}", account);
                                  account.MyFlag.WriteUserLogStamp = account.nowStamp();
                                  continue;
                                }
                                continue;
                              }
                              account.Myself.Pass2BoxShow = tempIntValue;
                              continue;
                            }
                            continue;
                          }
                          switch (identifier)
                          {
                            case "rm33":
                              if (account.Myself != null)
                              {
                                if (tempIntValue != 0 && tempIntValue != 1)
                                {
                                  if (account.MyFlag.IsInGame && account.Myself.isSceneTrans == 0 && account.Myself.ID > 0 && frmLogin.GAuto.Settings.TipHuongDan && (account.MyFlag.WriteUserLogStamp == 0L || account.nowStamp() - account.MyFlag.WriteUserLogStamp > 300000L))
                                  {
                                    GA.WriteUserLog($"{frmMain.langLoiDuLieuAuto} - code QuestFrame {(object) tempIntValue}", account);
                                    account.MyFlag.WriteUserLogStamp = account.nowStamp();
                                    continue;
                                  }
                                  continue;
                                }
                                account.Myself.isQuestFrameShow = tempIntValue;
                                continue;
                              }
                              continue;
                            case "rm34":
                              if (account.Myself != null)
                              {
                                account.Myself.BocShowID = tempIntValue;
                                continue;
                              }
                              continue;
                            case "rm5":
                              if (account.Myself != null)
                              {
                                if (tempIntValue != 0 && tempIntValue != 1 && tempIntValue != -1)
                                {
                                  if (account.MyFlag.IsInGame && account.Myself.isSceneTrans == 0 && account.Myself.ID > 0 && frmLogin.GAuto.Settings.TipHuongDan && (account.MyFlag.WriteUserLogStamp == 0L || account.nowStamp() - account.MyFlag.WriteUserLogStamp > 300000L))
                                  {
                                    GA.WriteUserLog($"{frmMain.langLoiDuLieuAuto} - code hasTarget {(object) tempIntValue}", account);
                                    account.MyFlag.WriteUserLogStamp = account.nowStamp();
                                    continue;
                                  }
                                  continue;
                                }
                                if (tempIntValue == 0)
                                {
                                  if (account.Myself.HasTarget)
                                    account.Myself.HasTargetStamp = account.nowStamp();
                                  account.Myself.HasTarget = false;
                                  continue;
                                }
                                account.Myself.HasTarget = true;
                                continue;
                              }
                              continue;
                            default:
                              if (identifier == "rm40" && frmLogin.GAuto.Settings.TuKetNoiLai)
                              {
                                if (tempIntValue == 1)
                                {
                                  if (account.MyFlag.isDisconnectBoxShowStamp == 0L)
                                  {
                                    account.MyFlag.isDisconnectBoxShowStamp = account.nowStamp();
                                    continue;
                                  }
                                  if (account.nowStamp() - account.MyFlag.isDisconnectBoxShowStamp > 5000L)
                                  {
                                    account.CallStringWithEnv(30);
                                    account.MyFlag.isDisconnectBoxShowStamp = 0L;
                                    continue;
                                  }
                                  continue;
                                }
                                account.MyFlag.isDisconnectBoxShowStamp = 0L;
                                continue;
                              }
                              continue;
                          }
                      }
                  }
              }
            }
          }
        }
      }
    }
  }

  private static void AdjustSkillButton(AutoAccount account, int i)
  {
    // TODO: lỗi
    if (account.Settings.SkillPlayList.Count > 0 && account.MySkills.AllSkills[account.MySkills.IDChangeList[i]].IsAttackPhat == 1)
    {
      for (int index = account.Settings.SkillPlayList.Count - 1; index >= 0; --index)
      {
        bool flag = false;
        if (account.Settings.SkillPlayList[index].SkillItem.Name == account.MySkills.AllSkills[account.MySkills.IDChangeList[i]].Name)
          flag = true;
        if (!flag && account.Myself.Menpai == AllEnums.Menpais.QUYCOC && GA.GetValidSkillName(account.Settings.SkillPlayList[index].SkillItem.Name) == account.MySkills.AllSkills[account.MySkills.IDChangeList[i]].Name)
          flag = true;
        if (flag)
        {
          try
          {
            account.Settings.SkillPlayList[index].SkillItem.KeyDesc = account.MySkills.AllSkills[account.MySkills.IDChangeList[i]].KeyDesc;
            break;
          }
          catch (Exception ex)
          {
            break;
          }
        }
      }
    }
    if (account.Settings.SkillPKList.Count > 0 && account.MySkills.AllSkills[account.MySkills.IDChangeList[i]].IsAttackPhat == 1)
    {
      for (int index = account.Settings.SkillPKList.Count - 1; index >= 0; --index)
      {
        bool flag = false;
        if (account.Settings.SkillPKList[index].SkillItem.Name == account.MySkills.AllSkills[account.MySkills.IDChangeList[i]].Name)
          flag = true;
        if (!flag && account.Myself.Menpai == AllEnums.Menpais.QUYCOC && GA.GetValidSkillName(account.Settings.SkillPKList[index].SkillItem.Name) == account.MySkills.AllSkills[account.MySkills.IDChangeList[i]].Name)
          flag = true;
        if (flag)
        {
          try
          {
            account.Settings.SkillPKList[index].SkillItem.KeyDesc = account.MySkills.AllSkills[account.MySkills.IDChangeList[i]].KeyDesc;
            break;
          }
          catch (Exception ex)
          {
            break;
          }
        }
      }
    }
    if (account.Settings.SkillBuffList.Count <= 0 || account.MySkills.AllSkills[account.MySkills.IDChangeList[i]].IsBuffPhat != 1)
      return;
    for (int index = account.Settings.SkillBuffList.Count - 1; index >= 0; --index)
    {
      bool flag = false;
      if (account.Settings.SkillBuffList[index].SkillItem.Name == account.MySkills.AllSkills[account.MySkills.IDChangeList[i]].Name)
        flag = true;
      if (!flag && account.Myself.Menpai == AllEnums.Menpais.QUYCOC && GA.GetValidSkillName(account.Settings.SkillBuffList[index].SkillItem.Name) == account.MySkills.AllSkills[account.MySkills.IDChangeList[i]].Name)
        flag = true;
      if (flag)
      {
        try
        {
          account.Settings.SkillBuffList[index].SkillItem.KeyDesc = account.MySkills.AllSkills[account.MySkills.IDChangeList[i]].KeyDesc;
          break;
        }
        catch (Exception ex)
        {
          break;
        }
      }
    }
  }

  public static void ReadMyValueInt(AutoAccount account, ref int myref, int mybase)
  {
    int lpNumberOfBytesRead = 0;
    account.Target.tempBuffer[0] = (byte) 0;
    account.Target.tempBuffer[1] = (byte) 0;
    account.Target.tempBuffer[2] = (byte) 0;
    account.Target.tempBuffer[3] = (byte) 0;
    MyDLL.ReadProcessMemory((int) account.Target.ProcessHandle, (IntPtr) mybase, account.Target.tempBuffer, 4U, ref lpNumberOfBytesRead);
    myref = (int) account.Target.tempBuffer[0] | (int) account.Target.tempBuffer[1] << 8 | (int) account.Target.tempBuffer[2] << 16 /*0x10*/ | (int) account.Target.tempBuffer[3] << 24;
  }

  public static void ReadMyValueIntPrivate(
    AutoAccount account,
    byte[] buffer,
    ref int myref,
    int mybase)
  {
    int lpNumberOfBytesRead = 0;
    buffer[0] = (byte) 0;
    buffer[1] = (byte) 0;
    buffer[2] = (byte) 0;
    buffer[3] = (byte) 0;
    MyDLL.ReadProcessMemory((int) account.Target.ProcessHandle, (IntPtr) mybase, buffer, 4U, ref lpNumberOfBytesRead);
    myref = (int) buffer[0] | (int) buffer[1] << 8 | (int) buffer[2] << 16 /*0x10*/ | (int) buffer[3] << 24;
  }

  public static void ReadMyValueUInt(AutoAccount account, ref uint myref, int mybase)
  {
    int lpNumberOfBytesRead = 0;
    account.Target.tempBuffer[0] = (byte) 0;
    account.Target.tempBuffer[1] = (byte) 0;
    account.Target.tempBuffer[2] = (byte) 0;
    account.Target.tempBuffer[3] = (byte) 0;
    MyDLL.ReadProcessMemory((int) account.Target.ProcessHandle, (IntPtr) mybase, account.Target.tempBuffer, 4U, ref lpNumberOfBytesRead);
    myref = BitConverter.ToUInt32(account.Target.tempBuffer, 0);
  }

  public static void ReadMyValueInt16(AutoAccount account, ref int myref, int mybase)
  {
    int lpNumberOfBytesRead = 0;
    account.Target.tempBuffer[0] = (byte) 0;
    account.Target.tempBuffer[1] = (byte) 0;
    MyDLL.ReadProcessMemory((int) account.Target.ProcessHandle, (IntPtr) mybase, account.Target.tempBuffer, 2U, ref lpNumberOfBytesRead);
    myref = (int) BitConverter.ToInt16(account.Target.tempBuffer, 0);
  }

  public static void ReadMyValueString(AutoAccount account, ref string myref, int mybase)
  {
    int lpNumberOfBytesRead = 0;
    SmartClass.Reset30(account);
    MyDLL.ReadProcessMemory((int) account.Target.ProcessHandle, (IntPtr) mybase, account.Target.tempBuffer, 30U, ref lpNumberOfBytesRead);
    bool flag = false;
    int index = 0;
    while (!flag)
    {
      if (account.Target.tempBuffer[index] == (byte) 0 || index >= 29)
        flag = true;
      ++index;
    }
    Encoding.UTF7.GetString(account.Target.tempBuffer, 0, index - 1);
    if (account.Target.VersionNum == 7 || account.Target.VersionNum == 8 || account.Target.VersionNum == 5 || account.Target.VersionNum == 6)
    {
      string str = Encoding.GetEncoding("gb2312").GetString(account.Target.tempBuffer, 0, index - 1);
      myref = str;
    }
    else
      myref = GA.ConvertToUnicode(account.Target.tempBuffer, 0, index - 1);
  }

  public static void ReadMyValueStringPrivate(
    AutoAccount account,
    byte[] buffer,
    ref string myref,
    int mybase)
  {
    int lpNumberOfBytesRead = 0;
    SmartClass.Reset30(buffer);
    MyDLL.ReadProcessMemory((int) account.Target.ProcessHandle, (IntPtr) mybase, buffer, 30U, ref lpNumberOfBytesRead);
    bool flag = false;
    int index = 0;
    while (!flag)
    {
      if (buffer[index] == (byte) 0 || index >= 29)
        flag = true;
      ++index;
    }
    Encoding.UTF7.GetString(buffer, 0, index - 1);
    if (account.Target.VersionNum == 7 || account.Target.VersionNum == 8 || account.Target.VersionNum == 5 || account.Target.VersionNum == 6)
    {
      string str = Encoding.GetEncoding("gb2312").GetString(buffer, 0, index - 1);
      myref = str;
    }
    else
      myref = GA.ConvertToUnicode(buffer, 0, index - 1);
  }

  public static void ReadMyValueByte(AutoAccount account, ref int myref, int mybase)
  {
    int lpNumberOfBytesRead = 0;
    account.Target.tempBuffer[0] = (byte) 0;
    MyDLL.ReadProcessMemory((int) account.Target.ProcessHandle, (IntPtr) mybase, account.Target.tempBuffer, 1U, ref lpNumberOfBytesRead);
    myref = (int) account.Target.tempBuffer[0];
  }

  public static void ReadMyValueFloat(AutoAccount account, ref float myref, int mybase)
  {
    int lpNumberOfBytesRead = 0;
    account.Target.tempBuffer[0] = (byte) 0;
    account.Target.tempBuffer[1] = (byte) 0;
    account.Target.tempBuffer[2] = (byte) 0;
    account.Target.tempBuffer[3] = (byte) 0;
    MyDLL.ReadProcessMemory((int) account.Target.ProcessHandle, (IntPtr) mybase, account.Target.tempBuffer, 4U, ref lpNumberOfBytesRead);
    myref = BitConverter.ToSingle(account.Target.tempBuffer, 0);
  }

  public static void CallClearNhiemVuData(AutoAccount account, MessageFunc messageFunc)
  {
    SmartClass.ResetNhiemVu(account);
  }

  public static void CallSetUpNhiemVuDataRing(AutoAccount account, MessageFunc messageFunc)
  {
    if (account.Myself == null)
      return;
    if (messageFunc.int1 != -1)
      account.Myself.NhiemVuPosX = messageFunc.int1;
    if (messageFunc.int2 != -1)
      account.Myself.NhiemVuPosY = messageFunc.int2;
    if (messageFunc.int3 != -1)
      account.Myself.NhiemVuMapID = messageFunc.int3;
    if (messageFunc.int4 == -1)
      return;
    account.Myself.NhiemVuType = messageFunc.int4;
  }

  public static void ResetQuestString(AutoAccount account)
  {
    if (account.Myself == null)
      return;
    account.Myself.QuestInfo = "";
    account.Myself.flagXayDungFinished = false;
  }

  public static void ResetNhiemVu(AutoAccount account)
  {
    if (account.Myself == null)
      return;
    account.Myself.NhiemVuMapID = -1;
    account.Myself.NhiemVuPosX = 0;
    account.Myself.NhiemVuPosY = 0;
    account.Myself.NhiemVuType = 0;
    account.Myself.NhiemVuItemIndex = -1;
    account.Myself.QuestInfo = "";
  }

  public static void CallClearPartyAsk(AutoAccount account, MessageFunc messageFunc)
  {
    if (account.MyParty == null)
      return;
    int ptAskSequence = account.MyParty.PTAskSequence;
    account.MyParty.PTAskDBAsked = 0;
    account.MyParty.PTAskDBAsker = 0;
    account.MyParty.PTAskSequence = 0;
    account.MyParty.PTAskName = "";
    account.MyParty.PTAskLevel = 0;
  }

  public static void ErasePartyInvite(AutoAccount account, MessageFunc messageFunc)
  {
    if (account.MyParty == null)
      return;
    account.MyParty.InviterDB = 0;
    account.MyParty.LastTimeSeenInvite = 0L;
    account.MyParty.Name = "";
  }

  public static void ResetInformation(AutoAccount account, bool resetBoc)
  {
    if (account.MyQuai != null)
    {
      account.MyQuai.AllQuai.Clear();
      SmartClass.ResetTarget(account);
    }
    if (!resetBoc || account.MyBoc == null)
      return;
    account.MyBoc.ActiveBocID = 0;
    account.MyBoc.PosX = 0.0f;
    account.MyBoc.PosY = 0.0f;
    account.MyBoc.LastTimeSeen = 0L;
    account.MyBoc.AllBocs.Clear();
  }

  public static void ResetPartyFollow(AutoAccount account, MessageFunc messageFunc)
  {
    if (account.Myself == null)
      return;
    account.Myself.FlagPartyFollowRequest = (byte) 0;
  }

  public static void CallClearBocDLL(AutoAccount account, int bocID)
  {
    if (account.MyBoc == null || account.MyBoc.AllBocs.Count <= 0)
      return;
    if (bocID == account.MyBoc.ActiveBocID)
    {
      account.MyBoc.ActiveBocID = 0;
      account.MyBoc.PosX = 0.0f;
      account.MyBoc.PosY = 0.0f;
    }
    for (int index = account.MyBoc.AllBocs.Count - 1; index >= 0; --index)
    {
      if (account.MyBoc.AllBocs[index].BocID == bocID)
      {
        account.MyBoc.AllBocs.RemoveAt(index);
        break;
      }
    }
  }

  public static void UpdateBoc(AutoAccount account, MessageFunc tempmsg)
  {
    if (account.MyBoc == null)
      return;
    bool flag = false;
    if (account.MyBoc.AllBocs.Count > 0)
    {
      for (int index = account.MyBoc.AllBocs.Count - 1; index >= 0; --index)
      {
        NewBoc allBoc = account.MyBoc.AllBocs[index];
        if (account.nowStamp() - allBoc.LastTimeSeen >= 59000L && allBoc.BocType == 5000)
        {
          SmartClass.ResetBocIndividual(account, index);
        }
        else
        {
          if (allBoc.BocID == tempmsg.int1)
          {
            allBoc.BocType = tempmsg.int2 == -1 || tempmsg.int4 != -1 && tempmsg.int4 != 153 ? tempmsg.int4 : 5000;
            if ((double) allBoc.PosX == (double) tempmsg.float1 && (double) allBoc.PosY == (double) tempmsg.float2)
            {
              flag = true;
              break;
            }
            if (!SmartClass.CheckRemovedBoc(account, allBoc))
              allBoc.LastTimeSeen = account.nowStamp();
            allBoc.PosX = tempmsg.float1;
            allBoc.PosY = tempmsg.float2;
            allBoc.OwnerDatabaseID = tempmsg.int2;
            allBoc.OwnerDatabaseIDLow = tempmsg.int3;
            flag = false;
            break;
          }
          flag = false;
        }
      }
    }
    if (flag)
      return;
    NewBoc boc = new NewBoc();
    boc.BocID = tempmsg.int1;
    boc.PosX = tempmsg.float1;
    boc.PosY = tempmsg.float2;
    boc.OwnerDatabaseID = tempmsg.int2;
    boc.OwnerDatabaseIDLow = tempmsg.int3;
    boc.BocType = tempmsg.int2 == -1 || tempmsg.int4 != -1 && tempmsg.int4 != 153 ? tempmsg.int4 : 5000;
    if (!SmartClass.CheckRemovedBoc(account, boc))
      boc.LastTimeSeen = account.nowStamp();
    account.MyBoc.AllBocs.Add(boc);
    if (!account.Myself.isNhatTuyet || boc.BocType != 809 || account.Myself.ActionStatus == (byte) 8)
      return;
    double distance = GA.CalculateDistance((double) account.Myself.PosX, (double) account.Myself.PosY, (double) boc.PosX, (double) boc.PosY);
    int num = 5;
    if (account.Settings.cboxNhatTuyetDungIm)
      num = 3;
    if (distance > (double) num)
      return;
    account.CallThocBocFunc(boc.BocID);
  }

  private static bool CheckRemovedBoc(AutoAccount account, NewBoc boc)
  {
    bool flag = false;
    if (account.MyBoc.RemovedBocList.Count > 0)
    {
      for (int index = account.MyBoc.RemovedBocList.Count - 1; index >= 0; --index)
      {
        if (account.MyBoc.RemovedBocList[index].BocID == boc.BocID && (double) account.MyBoc.RemovedBocList[index].PosX == (double) boc.PosX && (double) account.MyBoc.RemovedBocList[index].PosY == (double) boc.PosY)
        {
          boc.LastTimeSeen = account.MyBoc.RemovedBocList[index].LastTimeSeen;
          flag = true;
          break;
        }
        if (account.MyBoc.RemovedBocList[index].BocID == boc.BocID && ((double) account.MyBoc.RemovedBocList[index].PosX != (double) boc.PosX || (double) account.MyBoc.RemovedBocList[index].PosY != (double) boc.PosY))
          account.MyBoc.RemovedBocList.RemoveAt(index);
      }
    }
    return flag;
  }

  public static void UpdateTarget(AutoAccount account, MessageFunc tempmsg)
  {
    if (account.MyQuai == null || account.Myself == null)
      return;
    account.Myself.TargetLagStamp = account.nowStamp();
    account.MyQuai.CanAttackInt = tempmsg.int1;
    account.MyQuai.TargetHPPercent = tempmsg.float1 * 100f;
    int int2 = tempmsg.int2;
    if (account.MyQuai.AllQuai.Count <= 0 || account.MyQuai.TargetID == account.Myself.ID)
      return;
    for (int index1 = account.MyQuai.AllQuai.Count - 1; index1 >= 0; --index1)
    {
      QuaiIndividual quaiIndividual = account.MyQuai.AllQuai[index1];
      if (quaiIndividual.ID == account.MyQuai.TargetID && account.MyQuai.TargetID != -1)
      {
        account.MyQuai.SavedTargetStamp = account.nowStamp();
        quaiIndividual.NPCVal1 = tempmsg.int5;
        quaiIndividual.NPCVal2 = tempmsg.int6;
        quaiIndividual.NPCVal3 = tempmsg.int7;
        quaiIndividual.Level = (int) (byte) tempmsg.int4;
        quaiIndividual.MPPercent = (float) tempmsg.int3;
        if (int2 == -1)
        {
          quaiIndividual.KSMode = (byte) 0;
          break;
        }
        if (account.Myself == null || account.MyParty == null)
          break;
        if (account.Myself.DatabaseID == int2)
        {
          quaiIndividual.KSMode = (byte) 1;
          break;
        }
        bool flag = false;
        if (account.MyParty.AllMembers.Count > 0)
        {
          for (int index2 = 0; index2 < account.MyParty.AllMembers.Count; ++index2)
          {
            if (account.MyParty.AllMembers[index2].DatabaseID == int2)
            {
              flag = true;
              quaiIndividual.KSMode = (byte) 1;
              break;
            }
          }
        }
        if (flag)
          break;
        quaiIndividual.KSMode = byte.MaxValue;
        break;
      }
    }
  }

  public static void UpdateTargetID(AutoAccount account, MessageFunc tempmsg)
  {
    if (account.MyQuai == null)
      return;
    account.MyQuai.SavedTargetID = account.MyQuai.TargetID;
    account.MyQuai.TargetID = tempmsg.int1;
    account.MyQuai.TargetIDforPK = tempmsg.int1;
    account.MyQuai.SavedTargetStamp = account.nowStamp();
    if (account.MyQuai.TargetID != -1)
      return;
    account.MyQuai.TargetHPPercent = 0.0f;
    account.MyQuai.CanAttackInt = 0;
  }

  public static void UpdateCaptchaAddress(AutoAccount account, MessageFunc tempmsg)
  {
    if (account.Myself == null)
      return;
    account.Myself.CaptchaAddress = tempmsg.int1;
  }

  public static void UpdatePlayerData(AutoAccount account, MessageFunc tempmsg)
  {
    if (account.MyPlayers == null || tempmsg.int6 < 100 || tempmsg.int1 <= 0)
      return;
    bool flag = false;
    float int4 = (float) tempmsg.int4;
    float myref1 = 0.0f;
    SmartClass.ReadMyValueFloat(account, ref myref1, tempmsg.int4);
    float num = myref1 * 100f;
    if (account.MyPlayers.AllPlayers.Count > 0)
    {
      for (int index = account.MyPlayers.AllPlayers.Count - 1; index >= 0; --index)
      {
        if (account.MyPlayers.AllPlayers[index].DatabaseID > 0 && account.MyPlayers.AllPlayers[index].DatabaseID == tempmsg.int6)
        {
          if ((double) num >= 0.0)
          {
            account.MyPlayers.AllPlayers[index].PosX = tempmsg.float1;
            account.MyPlayers.AllPlayers[index].PosY = tempmsg.float2;
            account.MyPlayers.AllPlayers[index].MapID = account.Myself.MapID;
            account.MyPlayers.AllPlayers[index].LastTimeSeen = account.nowStamp();
            account.MyPlayers.AllPlayers[index].HPPercent = num;
            account.MyPlayers.AllPlayers[index].BangID = tempmsg.int2;
            account.MyPlayers.AllPlayers[index].ID = tempmsg.int1;
          }
          flag = true;
          break;
        }
      }
    }
    if (!flag)
    {
      if (tempmsg.byte1 == (byte) 0)
        return;
      string myref2 = "";
      int int8 = tempmsg.int8;
      if (account.Target.VersionNum == 3 || account.Target.VersionNum == 4)
        int8 -= 4;
      int myref3 = 0;
      SmartClass.ReadMyValueInt(account, ref myref3, int8 + 20);
      if (myref3 == 31 /*0x1F*/)
        SmartClass.ReadMyValueInt(account, ref int8, int8);
      SmartClass.ReadMyValueString(account, ref myref2, int8);
      if (myref2 == "")
        return;
      PlayerIndividual playerIndividual = new PlayerIndividual();
      playerIndividual.DatabaseID = tempmsg.int6;
      if (playerIndividual.DatabaseID > 100)
      {
        playerIndividual.DatabaseIDLow = tempmsg.int9;
        playerIndividual.ID = tempmsg.int1;
        playerIndividual.PosX = tempmsg.float1;
        playerIndividual.PosY = tempmsg.float2;
        playerIndividual.MapID = account.Myself.MapID;
        playerIndividual.LastTimeSeen = account.nowStamp();
        playerIndividual.HPPercent = num;
        playerIndividual.Menpai = tempmsg.int3;
        playerIndividual.BangID = tempmsg.int2;
        playerIndividual.Level = (int) tempmsg.byte1;
        playerIndividual.Name = myref2;
        account.MyPlayers.AllPlayers.Add(playerIndividual);
        flag = true;
      }
    }
    if (!flag)
      return;
    if (tempmsg.int1 == account.MyQuai.TargetID)
      account.MyQuai.SavedTargetStamp = account.nowStamp();
    if (account.MyParty != null && 0 < account.MyParty.PartyNumbers && account.MyParty.PartyNumbers < 6)
    {
      for (int index = 0; index <= account.MyParty.PartyNumbers; ++index)
      {
        PartyMember allMember = account.MyParty.AllMembers[index];
        if (allMember.DatabaseID == tempmsg.int6)
        {
          allMember.PosX = tempmsg.float1;
          allMember.PosY = tempmsg.float2;
          if (allMember.MaxHP > 0)
          {
            allMember.HP = (int) ((double) num / 100.0 * (double) allMember.MaxHP);
            break;
          }
          break;
        }
      }
    }
    if (account.MyFlag.ReadQuanDoanStamp <= SmartClass.nowStamp() || account.MyArmy == null || account.Target.VersionNum == 3 || account.Target.VersionNum == 4)
      return;
    for (int index = 0; index < 30; ++index)
    {
      PartyMember allMember = account.MyArmy.AllMembers[index];
      if (allMember.DatabaseID == tempmsg.int6)
      {
        allMember.PosX = tempmsg.float1;
        allMember.PosY = tempmsg.float2;
        if (allMember.MaxHP > 0)
          allMember.HP = (int) ((double) num / 100.0 * (double) allMember.MaxHP);
      }
    }
  }

  public static void UpdateQuaiData(AutoAccount account, MessageFunc tempmsg)
  {
    if (account.MyQuai == null)
      return;
    bool flag = false;
    float num = tempmsg.float3 * 100f;
    int int3 = tempmsg.int3;
    if (account.MyQuai.AllQuai.Count > 0)
    {
      for (int index = account.MyQuai.AllQuai.Count - 1; index >= 0; --index)
      {
        if (account.MyQuai.AllQuai[index].ID != -1 && account.MyQuai.AllQuai[index].ID == tempmsg.int7)
        {
          if ((double) num > 0.0)
          {
            account.MyQuai.AllQuai[index].PosX = tempmsg.float1;
            account.MyQuai.AllQuai[index].PosY = tempmsg.float2;
            account.MyQuai.AllQuai[index].HPPercent = num;
            account.MyQuai.AllQuai[index].LastTimeSeen = account.nowStamp();
          }
          else if ((double) num <= 0.0)
            SmartClass.ResetQuaiByIndex(account, index);
          flag = true;
          break;
        }
      }
    }
    if (!flag && (double) num > 0.0)
    {
      if (tempmsg.byte1 <= (byte) 0)
        return;
      string myref1 = "";
      int int8 = tempmsg.int8;
      int myref2 = 0;
      SmartClass.ReadMyValueInt(account, ref myref2, int8 + 20);
      if (myref2 == 31 /*0x1F*/)
        SmartClass.ReadMyValueInt(account, ref int8, int8);
      SmartClass.ReadMyValueString(account, ref myref1, int8);
      string myref3 = "";
      int int10 = tempmsg.int10;
      int myref4 = 0;
      SmartClass.ReadMyValueInt(account, ref myref4, int10 + 20);
      if (myref4 == 31 /*0x1F*/)
        SmartClass.ReadMyValueInt(account, ref int10, int10);
      SmartClass.ReadMyValueString(account, ref myref3, int10);
      if (myref3.Contains("#"))
        myref3 = myref3.Split('#')[0];
      account.MyQuai.AllQuai.Add(new QuaiIndividual()
      {
        ID = tempmsg.int7,
        PosX = tempmsg.float1,
        PosY = tempmsg.float2,
        MapID = account.Myself.MapID,
        LastTimeSeen = account.nowStamp(),
        HPPointer = int3,
        Level = (int)tempmsg.byte1,
        QuaiType = (byte) 1,
        CanAttack = (byte) tempmsg.int5,
        IsBossValue = tempmsg.int6,
        Name = myref1,
        DanhHieu = myref3,
        HPPercent = num
      });
    }
    if ((double) num <= 0.0 || tempmsg.int7 != account.MyQuai.TargetID)
      return;
    account.MyQuai.SavedTargetStamp = account.nowStamp();
  }

  public static void ResetQuaiByIndex(AutoAccount account, int i)
  {
    if (account.MyQuai == null || account.MyQuai.AllQuai.Count <= 0 || i >= account.MyQuai.AllQuai.Count)
      return;
    if (account.MyQuai.AllQuai[i].ID == account.MyQuai.TargetID && account.MyQuai.TargetID != -1)
    {
      account.MyQuai.TargetID = -1;
      account.MyQuai.TargetHPPercent = 0.0f;
      account.MyQuai.SavedTargetID = -1;
    }
    if (account.Myself.AttackedID == account.MyQuai.AllQuai[i].ID)
      account.Myself.AttackedID = -1;
    account.MyQuai.AllQuai.RemoveAt(i);
  }

  private static void IsBufferEmpty(AutoAccount account)
  {
    account.Target.bufferEmpty = false;
    if (account.Myself.PacketReadIndex >= account.Myself.PacketWriteIndex && account.Myself.PacketReadIndex == 0L)
      account.Target.bufferEmpty = true;
    else
      account.Target.bufferEmpty = false;
  }

  public static long nowStamp() => frmLogin.GlobalTimer.ElapsedMilliseconds;

  public static void ReadPetSkillDelayByIndex(AutoAccount account, int index, int tempIntValue)
  {
    if (index >= account.MyPet.AllPets.Count)
      return;
    int num1 = index * (int) byte.MaxValue + 9;
    int mybase1 = tempIntValue + (num1 * 2 + num1) * 4;
    int myref1 = 9999;
    SmartClass.ReadMyValueInt(account, ref myref1, mybase1);
    account.MyPet.AllPets[index].KhaiDuongDelay = myref1;
    int num2 = index * (int) byte.MaxValue + 1;
    int mybase2 = tempIntValue + (num2 * 2 + num2) * 4;
    int myref2 = 9999;
    SmartClass.ReadMyValueInt(account, ref myref2, mybase2);
    account.MyPet.AllPets[index].PhaQuanDelay = myref2;
  }

  public AutoAccount CurrentAuto { get; set; }

  public SmartClass()
  {
    this.ReadInfoThread = new Thread(new ThreadStart(this.ReadAllMemory));
    this.ReadInfoThread.IsBackground = true;
    this.ReadInfoThread.Start();
  }

  public void ReadAllMemory()
  {
    while (true)
    {
      while (!this.UIAvailable)
        Thread.Sleep(300);
      try
      {
        if (frmLogin.GlobalTimer.ElapsedMilliseconds - frmLogin.GCStamp >= 600000L)
        {
          frmLogin.GCStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
          GC.Collect();
        }
        if (frmLogin.GlobalTimer.ElapsedMilliseconds - frmLogin.BackgroundCheckTimestamp >= 5000L)
        {
          frmLogin.BackgroundCheckTimestamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
          if (frmLogin.debugApps.isDangerous && !frmLogin.submittedInfo && frmLogin.GAuto.AllAutoAccounts.Count > 0)
          {
            frmLogin.submittedInfo = true;
            new Thread((ThreadStart) (() => SecurityHelper.submit_my_info())).Start();
          }
          if (frmLogin.GAuto.Settings.TipHuongDan && (frmLogin.NotificationStamp == 0L || frmLogin.NotificationStamp > 0L && frmLogin.GlobalTimer.ElapsedMilliseconds - frmLogin.NotificationStamp >= frmLogin.NotificationDelay) && frmLogin.NotificationList.Count > 0 && frmLogin.NotificationDelay > 0L && frmLogin.GAuto.AllAutoAccounts.Count > 0)
          {
            frmLogin.NotificationStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
            try
            {
              if (frmLogin.GAuto.AllAutoAccounts[0].Target.VersionNum == 3 && frmLogin.GAuto.AllAutoAccounts[0].Target.SubVersion != 6 && frmLogin.NotificationTK.Count > 0)
              {
                int index = GA.random.Next(0, frmLogin.NotificationTK.Count);
                GA.WriteUserLog(frmLogin.NotificationTK[index]);
              }
              else if (frmLogin.GAuto.AllAutoAccounts[0].Target.VersionNum < 3 && frmLogin.NotificationVNG.Count > 0)
              {
                int index = GA.random.Next(0, frmLogin.NotificationVNG.Count);
                GA.WriteUserLog(frmLogin.NotificationVNG[index]);
              }
              else if (frmLogin.GAuto.AllAutoAccounts[0].Target.VersionNum == 3 && frmLogin.GAuto.AllAutoAccounts[0].Target.SubVersion == 6 && frmLogin.Notification69.Count > 0)
              {
                int index = GA.random.Next(0, frmLogin.Notification69.Count);
                GA.WriteUserLog(frmLogin.Notification69[index]);
              }
              else if (frmLogin.GAuto.AllAutoAccounts[0].Target.VersionNum == 4)
              {
                if (frmLogin.NotificationDO2.Count > 0)
                {
                  int index = GA.random.Next(0, frmLogin.NotificationDO2.Count);
                  GA.WriteUserLog(frmLogin.NotificationDO2[index]);
                }
              }
            }
            catch (Exception ex)
            {
              GA.WriteUserLog("Please notify GAuto. Error code 12587");
            }
          }
          long num1 = frmLogin.GlobalTimer.ElapsedMilliseconds - frmLogin.GAuto.Settings.Account.LastValidTimeStampQ12;
          int num2 = (frmLogin.GAuto.Settings.Q12TCDuration ^ 1786) / 849;
          if ((long) (num2 * 1000) > num1)
          {
            int num3 = (num2 * 1000 - (int) num1) / 1000;
            try
            {
              frmLogin.GAuto.Settings.Q12TCDuration = num3 * 849 ^ 1786;
            }
            catch (Exception ex)
            {
            }
          }
          else
          {
            try
            {
              int num4 = 0;
              try
              {
                for (int index = frmLogin.GAuto.AllAutoAccounts.Count - 1; index >= 0; --index)
                {
                  if (frmLogin.GAuto.AllAutoAccounts[index].Myself.IsQ1 || frmLogin.GAuto.AllAutoAccounts[index].Myself.IsQ2)
                  {
                    ++num4;
                    break;
                  }
                }
              }
              catch (Exception ex)
              {
              }
              frmLogin.GAuto.Settings.Q12TCDuration = frmLogin.GAuto.Settings.Account.EmptySecondQ123Hits != 0 || !frmLogin.GAuto.Settings.HadQ123Pro || num4 <= 0 || !frmLogin.GAuto.Settings.cboxQ12AutoExtend ? 1786 : 1019210;
              ++frmLogin.GAuto.Settings.Account.EmptySecondQ123Hits;
            }
            catch (Exception ex)
            {
            }
          }
          frmLogin.GAuto.Settings.Account.LastValidTimeStampQ12 = frmLogin.GlobalTimer.ElapsedMilliseconds;
          long num5 = frmLogin.GlobalTimer.ElapsedMilliseconds - frmLogin.GAuto.Settings.Account.LastValidTimeStampYTO;
          int num6 = (frmLogin.GAuto.Settings.YTODuration ^ 2716) / 147;
          if ((long) (num6 * 1000) > num5)
          {
            int num7 = (num6 * 1000 - (int) num5) / 1000;
            try
            {
              frmLogin.GAuto.Settings.YTODuration = num7 * 147 ^ 2716;
            }
            catch (Exception ex)
            {
            }
          }
          else
          {
            try
            {
              int num8 = 0;
              try
              {
                for (int index = frmLogin.GAuto.AllAutoAccounts.Count - 1; index >= 0; --index)
                {
                  if (frmLogin.GAuto.AllAutoAccounts[index].Myself.isYTO)
                  {
                    ++num8;
                    break;
                  }
                }
              }
              catch (Exception ex)
              {
              }
              frmLogin.GAuto.Settings.YTODuration = frmLogin.GAuto.Settings.Account.EmptySecondYTOHits != 0 || !frmLogin.GAuto.Settings.HadYTOPro || num8 <= 0 || !frmLogin.GAuto.Settings.cboxYTOGiaHan ? 2716 : 179084;
              ++frmLogin.GAuto.Settings.Account.EmptySecondYTOHits;
            }
            catch (Exception ex)
            {
            }
          }
          frmLogin.GAuto.Settings.Account.LastValidTimeStampYTO = frmLogin.GlobalTimer.ElapsedMilliseconds;
          frmLogin.GAuto.Settings.Account.MyLicense.UpdateLicense();
          if (!frmLogin.CheckVersion)
          {
            bool flag1 = false;
            bool flag2 = false;
            if (frmLogin.BlockFromVer != 0)
            {
              string s = GA.GetMyVersion().Replace(".", "");
              int result = 0;
              int.TryParse(s, out result);
              if (frmLogin.BlockFromVer >= result)
                flag1 = true;
            }
            if (frmLogin.BlockTheseVersions.Count > 0 && frmLogin.BlockTheseVersions.Contains(GA.GetMyVersion().Replace(".", "")))
              flag2 = true;
            if ((flag1 || flag2) && frmLogin.BlockedStamp == 0L)
            {
              frmLogin.BlockedStamp = frmLogin.GlobalTimer.ElapsedMilliseconds + 120000L;
              GA.WriteUserLog($"Bạn đang xài phiên bản ({GA.GetMyVersion()}) cũ không phù hợp. Auto sẽ tự thoát sau 2 phút nữa");
              GA.ShowMessage($"Bạn đang xài phiên bản ({GA.GetMyVersion()}) cũ không phù hợp. Auto sẽ tự thoát sau 2 phút nữa. Vui lòng chạy file update.exe để cập nhật phiên bản mới nhất", "Phiên bản cũ", 120000);
            }
            frmLogin.CheckVersion = true;
          }
          if (frmLogin.BlockedStamp != 0L && frmLogin.GlobalTimer.ElapsedMilliseconds >= frmLogin.BlockedStamp)
          {
            string _content = "Auto tự thoát. Bạn cần cập nhật phiên bản mới hơn";
            frmThongBao_FW.ExitAuto = 1;
            GA.ShowMessage(_content, "Phiên bản quá cũ", 60000);
            frmLogin.BlockedStamp = 0L;
          }
          if (frmLogin.CompilingLanguage == "VN")
          {
            long num9 = frmLogin.GlobalTimer.ElapsedMilliseconds - frmLogin.GAuto.Settings.Account.LastValidTimeStampCheDo;
            int num10 = (frmLogin.GAuto.Settings.CheDoDuration ^ 2013) / 152;
            if ((long) (num10 * 1000) > num9)
            {
              int num11 = (num10 * 1000 - (int) num9) / 1000;
              try
              {
                frmLogin.GAuto.Settings.CheDoDuration = num11 * 152 ^ 2013;
              }
              catch (Exception ex)
              {
              }
            }
            else
            {
              try
              {
                int num12 = 0;
                try
                {
                  for (int index = frmLogin.GAuto.AllAutoAccounts.Count - 1; index >= 0; --index)
                  {
                    if (frmLogin.GAuto.AllAutoAccounts[index].Myself.IsCheDo)
                      ++num12;
                  }
                }
                catch (Exception ex)
                {
                }
                if (frmLogin.GAuto.Settings.Account.EmptySecondCDHits == 0 && frmLogin.GAuto.Settings.HadCDPro && num12 > 0)
                {
                  frmLogin.GAuto.Settings.CheDoDuration = 184157;
                }
                else
                {
                  frmLogin.GAuto.Settings.CheDoDuration = 2013;
                  frmLogin.GAuto.Settings.CheDoCounts = 2013;
                }
                ++frmLogin.GAuto.Settings.Account.EmptySecondCDHits;
              }
              catch (Exception ex)
              {
              }
            }
            frmLogin.GAuto.Settings.Account.LastValidTimeStampCheDo = frmLogin.GlobalTimer.ElapsedMilliseconds;
          }
          try
          {
            if (frmLogin.GAuto.AllCyberAccounts.Count > 0)
            {
              for (int index = frmLogin.GAuto.AllCyberAccounts.Count - 1; index >= 0; --index)
              {
                if (frmLogin.GAuto.AllCyberAccounts[index].Target.CyberPseudoSent < 10)
                {
                  if (!frmLogin.GAuto.AllCyberAccounts[index].Target.IsCyberRestored)
                  {
                    MyDLL.PostMessage(frmLogin.GAuto.AllCyberAccounts[index].Target.MainWindowHandle, frmLogin.GAuto.Settings.WM_PSEUDOCODE, (IntPtr) 0, (IntPtr) 0);
                    frmLogin.GAuto.AllCyberAccounts[index].Target.IsCyberRestored = true;
                  }
                  AutoAccount.CreatePseudo(frmLogin.GAuto.AllCyberAccounts[index]);
                }
              }
            }
          }
          catch (Exception ex)
          {
          }
        }
        if (frmLogin.GlobalTimer.ElapsedMilliseconds - frmLogin.CheckSeconds >= 5000L)
        {
          frmLogin.CheckSeconds = frmLogin.GlobalTimer.ElapsedMilliseconds;
          long num = frmLogin.GlobalTimer.ElapsedMilliseconds - frmLogin.GAuto.Settings.Account.LastValidTimeStamp;
          if (frmLogin.GAuto.Settings.Account.RemainMSeconds > (double) num)
          {
            try
            {
              frmLogin.GAuto.Settings.Account.RemainMSeconds -= (double) num;
            }
            catch (Exception ex)
            {
            }
          }
          else
          {
            try
            {
              frmLogin.GAuto.Settings.Account.RemainMSeconds = frmLogin.GAuto.Settings.Account.EmptySecondHits != 0 || !frmLogin.GAuto.Settings.WasPro ? 0.0 : 600000.0;
            }
            catch (Exception ex)
            {
            }
            ++frmLogin.GAuto.Settings.Account.EmptySecondHits;
          }
          frmLogin.GAuto.Settings.Account.LastValidTimeStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
        }
        this.SmartKeepAlive();
        if (frmLogin.GlobalTimer.ElapsedMilliseconds - frmLogin.frmMainShownStamp >= 60000L && frmLogin.frmMainShownStamp != 0L)
        {
          frmLogin.frmMainShownStamp = 0L;
          this.Settings.EnumProcessDelay = 3000;
        }
        if (frmLogin.GlobalTimer.ElapsedMilliseconds - this.Settings.EnumProcessTimeStamp >= (long) this.Settings.EnumProcessDelay || frmLogin.EnumProcessStamp > 0L && frmLogin.GlobalTimer.ElapsedMilliseconds - frmLogin.EnumProcessStamp <= 120000L)
        {
          this.Settings.EnumProcessTimeStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
          if (this.AllAutoAccounts.Count > 0)
          {
            for (int index = this.AllAutoAccounts.Count - 1; index >= 0; --index)
            {
              if (this.AllAutoAccounts[index] != null && !this.AllAutoAccounts[index].IsLicensed)
                this.AllAutoAccounts[index].IsLicensed = true;
            }
          }
          if (frmLogin.GAuto.Settings.SavedAIStatus.Count > 0)
          {
            for (int index1 = frmLogin.GAuto.Settings.SavedAIStatus.Count - 1; index1 >= 0; --index1)
            {
              SavedAI savedAiStatu = frmLogin.GAuto.Settings.SavedAIStatus[index1];
              try
              {
                for (int index2 = 0; index2 < frmLogin.GAuto.AllAutoAccounts.Count; ++index2)
                {
                  AutoAccount allAutoAccount = frmLogin.GAuto.AllAutoAccounts[index2];
                  if (allAutoAccount.Myself != null && savedAiStatu.PlayerDBID == allAutoAccount.Myself.DatabaseID)
                  {
                    allAutoAccount.IsAIEnabled = savedAiStatu.SavedAIStatus;
                    frmLogin.GAuto.Settings.SavedAIStatus.RemoveAt(index1);
                    break;
                  }
                }
              }
              catch (Exception ex)
              {
              }
            }
          }
          if (!SmartClass.Exiting)
          {
            Process[] processes = Process.GetProcessesByName("Game");
            bool flag3 = false;
            if (processes != null)
            {
              if (true)
              {
                foreach (Process process in processes)
                {
                  Process proc = process;
                  if (proc.ProcessName.ToLower() == this.TargetProcessName)
                  {
                    bool flag4 = false;
                    try
                    {
                      for (int index = frmLogin.GAuto.AllAutoAccounts.Count - 1; index >= 0; --index)
                      {
                        if (frmLogin.GAuto.AllAutoAccounts[index].Target.ProcessID == proc.Id)
                        {
                          flag4 = true;
                          break;
                        }
                      }
                    }
                    catch (Exception ex)
                    {
                    }
                    bool flag5 = false;
                    int titleCheck = 0;
                    if (!flag4)
                    {
                      if (frmLogin.GAuto.Settings.ProcessList.Contains(proc.Id))
                        flag4 = true;
                      if (frmMain.InMyIgnoredList(proc.Id))
                      {
                        flag4 = true;
                        if (flag5)
                        {
                          titleCheck = 99;
                          flag4 = false;
                          if (frmLogin.GAuto.AllCyberAccounts.Count > 0)
                          {
                            try
                            {
                              for (int index = frmLogin.GAuto.AllCyberAccounts.Count - 1; index >= 0; --index)
                              {
                                if (frmLogin.GAuto.AllCyberAccounts[index].Target.ProcessID == proc.Id)
                                {
                                  flag4 = true;
                                  break;
                                }
                              }
                            }
                            catch (Exception ex)
                            {
                            }
                          }
                        }
                      }
                      else
                      {
                        if (frmLogin.GAuto.BlockedAutoAccounts.Count > 0)
                        {
                          for (int index = frmLogin.GAuto.BlockedAutoAccounts.Count - 1; index >= 0; --index)
                          {
                            if (frmLogin.GAuto.BlockedAutoAccounts[index].Target.ProcessID == proc.Id)
                            {
                              AutoAccount blockedAutoAccount = frmLogin.GAuto.BlockedAutoAccounts[index];
                              frmLogin.GAuto.AllAutoAccounts.Add(blockedAutoAccount);
                              blockedAutoAccount.Target.TempRemoved = false;
                              frmLogin.GAuto.BlockedAutoAccounts.RemoveAt(index);
                              flag4 = true;
                              break;
                            }
                          }
                        }
                        if (!flag4 && !flag5 && !frmLogin.GAuto.Settings.optAcceptNewGame)
                          flag4 = true;
                      }
                    }
                    if (!flag4)
                    {
                      try
                      {
                        AutoAccount newAccount = new AutoAccount();
                        int tempProc_ID = proc.Id;
                        uint lpdwProcessId = 0;
                        IntPtr tempWindowHandle = proc.MainWindowHandle;
                        uint tempMainThreadID = MyDLL.GetWindowThreadProcessId(tempWindowHandle, out lpdwProcessId);
                        string lpClassName = "1123456789012345678911234567891123456789";
                        MyDLL.GetClassName(tempWindowHandle, lpClassName, lpClassName.Length);
                        IntPtr hProc = MyDLL.OpenProcess(33554432U /*0x02000000*/, 1, (uint) tempProc_ID);
                        if (hProc != IntPtr.Zero)
                        {
                          StringBuilder tempProcessPath = new StringBuilder((int) byte.MaxValue);
                          int moduleFileNameEx = (int) MyDLL.GetModuleFileNameEx(hProc, IntPtr.Zero, tempProcessPath, (int) byte.MaxValue);
                          string lower = tempProcessPath.ToString().ToLower();
                          if (newAccount != null && newAccount.Target != null)
                            newAccount.Target.ProcessExePath = lower;
                          if (lower != "")
                          {
                            string tempFileName = Path.GetFileName(lower);
                            if (SmartClass.allHash.Count > 0)
                            {
                              for (int index = SmartClass.allHash.Count - 1; index >= 0; --index)
                              {
                                if (SmartClass.allHash[index].GamePath == lower)
                                {
                                  newAccount.Target.TargetHash = SmartClass.allHash[index].RealHash;
                                  break;
                                }
                              }
                            }
                            if (newAccount.Target.TargetHash == "" && File.Exists(lower))
                            {
                              using (MD5 md5 = MD5.Create())
                              {
                                using (FileStream inputStream = File.OpenRead(lower))
                                {
                                  newAccount.Target.TargetHash = BitConverter.ToString(md5.ComputeHash((Stream) inputStream)).Replace("-", "").ToUpper();
                                  SmartClass.allHash.Add(new GameHash()
                                  {
                                    GamePath = lower,
                                    RealHash = newAccount.Target.TargetHash
                                  });
                                }
                              }
                            }
                            bool flag6 = false;
                            if (proc.MainWindowTitle == newAccount.Target.TemporaryClassName || proc.MainWindowTitle == "Thien Long Bat Bo" || proc.MainWindowTitle == "Dragon Oath" || proc.MainWindowTitle == "《新天龙八部》永恒经典版" || proc.MainWindowTitle == "《新天龙八部》唯美3D版")
                              flag6 = true;
                            bool flag7 = false;
                            if (lpClassName.Contains(newAccount.Target.MainWindowClassName) || lpClassName.Contains("32770") || lpClassName.Contains("123456789"))
                              flag7 = true;
                            if (proc.MainWindowTitle.Contains("www.bossgame.net"))
                              flag7 = false;
                            if (tempMainThreadID != 0U && !flag6 && (flag7 || lpClassName.Contains("TeamViewer_TitleBarButtonClass")))
                            {
                              newAccount.Target.ProcessHandle = hProc;
                              newAccount.Target.ProcessID = tempProc_ID;
                              HashAddressPatch myBase = SmartClass.GetBasicBases(newAccount);
                              if (myBase == null || newAccount.Target.ClientPattern == null && frmLogin.CompilingLanguage == "CN" || GA.isVipMember())
                              {
                                this.GetMyBases_ReadPattern(newAccount);
                                myBase = SmartClass.GetBasicBases(newAccount);
                              }
                              if (myBase != null)
                              {
                                int tempLevel = 0;
                                int tempMaxHP = 0;
                                int tempMenpai = -1;
                                int tempRage = -1;
                                if (frmLogin.GAuto.Settings.AllowReadMem)
                                {
                                  SmartClass.ReadBriefInfo(hProc, myBase, ref tempLevel, ref tempMaxHP, ref tempMenpai, ref tempRage, newAccount);
                                  newAccount.Target.MyBase = myBase;
                                }
                                if (true)
                                {
                                  frmLogin.GAuto.Settings.ProcessList.Add(tempProc_ID);
                                  new Thread((ThreadStart) (() => this.AddAccount(proc, newAccount, tempProc_ID, tempWindowHandle, tempMainThreadID, hProc, tempProcessPath, tempFileName, myBase.VersionNum, titleCheck))).Start();
                                }
                                else
                                  MyDLL.CloseHandle(hProc);
                              }
                              else if (myBase == null)
                              {
                                bool flag8 = false;
                                if (newAccount.Target.TargetHash != "" && frmLogin.BlackListHash.Contains(newAccount.Target.TargetHash))
                                  flag8 = true;
                                bool flag9 = false;
                                if (frmLogin.MyHashList.Contains(newAccount.Target.TargetHash))
                                  flag9 = true;
                                if (frmLogin.MyBases.Count > 0)
                                {
                                  if (!flag9)
                                  {
                                    if (!flag8)
                                    {
                                      int num = (int) new frmHashPick()
                                      {
                                        ProcessID = tempProc_ID,
                                        TempHash = newAccount.Target.TargetHash
                                      }.ShowDialog();
                                    }
                                  }
                                }
                              }
                            }
                            else if (flag6)
                            {
                              bool flag10 = frmLogin.GAuto.Settings.AppMode != AllEnums.AutoModes.Lite;
                              newAccount.Target.ProcessHandle = hProc;
                              newAccount.Target.ProcessID = tempProc_ID;
                              if (true)
                              {
                                HashAddressPatch myPatch = SmartClass.GetMyPatch(newAccount);
                                if (myPatch == null || newAccount.Target.ClientPattern == null && frmLogin.CompilingLanguage == "CN")
                                {
                                  this.GetMyBases_ReadPattern(newAccount);
                                  myPatch = SmartClass.GetMyPatch(newAccount);
                                }
                                if (myPatch != null)
                                {
                                  int address = myPatch.Address;
                                  if (address != 0)
                                  {
                                    IntPtr windowEx = MyDLL.FindWindowEx(proc.MainWindowHandle, IntPtr.Zero, "Button", "OK");
                                    TimeSpan timeSpan = DateTime.Now - proc.StartTime;
                                    if (windowEx != IntPtr.Zero && timeSpan.TotalSeconds >= 3.0)
                                    {
                                      byte[] buffer1 = new byte[15]
                                      {
                                        (byte) 131,
                                        (byte) 196,
                                        (byte) 16 /*0x10*/,
                                        (byte) 139,
                                        (byte) 124,
                                        (byte) 228,
                                        (byte) 8,
                                        (byte) 137,
                                        (byte) 60,
                                        (byte) 228,
                                        (byte) 233,
                                        (byte) 62,
                                        byte.MaxValue,
                                        byte.MaxValue,
                                        byte.MaxValue
                                      };
                                      int size = 15;
                                      if (myPatch.VersionNum == 3)
                                      {
                                        buffer1 = new byte[14]
                                        {
                                          (byte) 131,
                                          (byte) 196,
                                          (byte) 16 /*0x10*/,
                                          (byte) 139,
                                          (byte) 60,
                                          (byte) 36,
                                          (byte) 137,
                                          (byte) 60,
                                          (byte) 36,
                                          (byte) 233,
                                          (byte) 99,
                                          byte.MaxValue,
                                          byte.MaxValue,
                                          byte.MaxValue
                                        };
                                        size = 14;
                                      }
                                      else if (myPatch.VersionNum == 4)
                                      {
                                        buffer1 = new byte[11]
                                        {
                                          (byte) 131,
                                          (byte) 196,
                                          (byte) 16 /*0x10*/,
                                          (byte) 95,
                                          (byte) 95,
                                          (byte) 87,
                                          (byte) 233,
                                          (byte) 102,
                                          byte.MaxValue,
                                          byte.MaxValue,
                                          byte.MaxValue
                                        };
                                        size = 11;
                                      }
                                      else if (myPatch.VersionNum == 5 || myPatch.VersionNum == 6)
                                        buffer1 = new byte[14]
                                        {
                                          (byte) 131,
                                          (byte) 196,
                                          (byte) 16 /*0x10*/,
                                          (byte) 139,
                                          (byte) 60,
                                          (byte) 228,
                                          (byte) 137,
                                          (byte) 60,
                                          (byte) 228,
                                          (byte) 233,
                                          (byte) 99,
                                          byte.MaxValue,
                                          byte.MaxValue,
                                          byte.MaxValue
                                        };
                                      if (myPatch.VersionNum == 3 || myPatch.VersionNum == 4)
                                        address += 4198400 /*0x401000*/;
                                      MyDLL.WriteProcessMemory(hProc, (IntPtr) address, buffer1, (uint) size, 0);
                                      int lpBaseAddress1 = address - 50;
                                      if (myPatch.VersionNum < 3)
                                        lpBaseAddress1 -= 56;
                                      byte[] buffer2 = new byte[1]
                                      {
                                        (byte) 80 /*0x50*/
                                      };
                                      MyDLL.WriteProcessMemory(hProc, (IntPtr) lpBaseAddress1, buffer2, 1U, 0);
                                      byte[] numArray = new byte[1]
                                      {
                                        (byte) 12
                                      };
                                      int num13 = 0;
                                      double num14 = GA.DayBalance();
                                      int num15 = 12;
                                      int num16 = 50;
                                      for (int index = 6; index <= 90 && num14 >= (double) num16; index += 6)
                                      {
                                        num15 = 12 + index;
                                        num16 += 50;
                                      }
                                      double totalBalance = frmLogin.GAuto.Settings.Account.TotalBalance;
                                      int num17 = 12;
                                      int num18 = 80 /*0x50*/;
                                      for (int index = 6; index <= 90 && totalBalance >= (double) num17; index += 6)
                                      {
                                        num17 = 12 + index;
                                        num18 += 80 /*0x50*/;
                                      }
                                      if (num17 > num15)
                                        num15 = num17;
                                      if (frmLogin.GAuto.AllAutoAccounts.Count > 0)
                                      {
                                        for (int index = frmLogin.GAuto.AllAutoAccounts.Count - 1; index >= 0; --index)
                                        {
                                          if (frmLogin.GAuto.AllAutoAccounts[index].Target.VersionNum == 1 || frmLogin.GAuto.AllAutoAccounts[index].Target.VersionNum == 2)
                                          {
                                            ++num13;
                                            if (num13 >= num15)
                                              GA.ShowBalloon(frmMain.langLimitAccVNG, frmMain.langWarning, (AutoAccount) null, 5000, (object) num15.ToString(), (object) num16.ToString(), (object) num18.ToString());
                                          }
                                        }
                                      }
                                      if (num15 > 12)
                                        numArray = new byte[1]
                                        {
                                          Convert.ToByte(num15)
                                        };
                                      byte[] buffer3 = numArray;
                                      if (myPatch.VersionNum < 3)
                                      {
                                        int lpBaseAddress2 = myPatch.Address - 338;
                                        MyDLL.WriteProcessMemory(hProc, (IntPtr) lpBaseAddress2, buffer3, 1U, 0);
                                      }
                                      if (myPatch.VersionNum < 3)
                                      {
                                        int lpBaseAddress3 = myPatch.Address - 84;
                                        byte[] buffer4 = new byte[1]
                                        {
                                          (byte) 235
                                        };
                                        MyDLL.WriteProcessMemory(hProc, (IntPtr) lpBaseAddress3, buffer4, 1U, 0);
                                      }
                                      MyDLL.SendMessage((int) proc.MainWindowHandle, 16 /*0x10*/, 0, 0);
                                    }
                                    else
                                      MyDLL.CloseHandle(hProc);
                                  }
                                }
                              }
                            }
                          }
                        }
                      }
                      catch (Exception ex)
                      {
                        if (GA.isVipMember())
                          GA.WriteUserLog($"{ex.Message}. Stack: {ex.StackTrace.ToString()}");
                      }
                    }
                  }
                }
              }
              if (frmLogin.GlobalTimer.ElapsedMilliseconds - frmLogin.GAuto.checkRemoveAccount >= 1500L)
              {
                frmLogin.GAuto.checkRemoveAccount = frmLogin.GlobalTimer.ElapsedMilliseconds;
                try
                {
                  for (int index = this.AllAutoAccounts.Count - 1; index >= 0; --index)
                  {
                    AutoAccount allAutoAccount = this.AllAutoAccounts[index];
                    bool flag11 = false;
                    if (processes.Length > 0)
                    {
                      if (allAutoAccount != null)
                      {
                        foreach (Process process in processes)
                        {
                          if (process.Id == allAutoAccount.Target.ProcessID)
                          {
                            flag11 = true;
                            break;
                          }
                        }
                      }
                    }
                    else
                      flag11 = true;
                    if (!flag11)
                    {
                      allAutoAccount.Target.NeedToAbort3 = true;
                      try
                      {
                        F.UnhookProcess(allAutoAccount, true);
                        if (allAutoAccount.AIThreadTimer != null)
                        {
                          allAutoAccount.AIThreadTimer.Stop();
                        }
                        
                        if (allAutoAccount.AutoProfile != null)
                        {
                          allAutoAccount.AutoProfile.IsHandled = false;
                          allAutoAccount.AutoProfile.IsAssigned = false;
                          allAutoAccount.AutoProfile.NeedHandle = false;
                          allAutoAccount.AutoProfile.GameStarted = false;
                          allAutoAccount.AutoProfile.InvalidPassword = false;
                          allAutoAccount.AutoProfile.RefAutoAccount = (AutoAccount) null;
                        }
                        this.AllAutoAccounts.Remove(allAutoAccount);
                        frmLogin.GAuto.Settings.ProcessList.Remove(allAutoAccount.Target.ProcessID);
                      }
                      catch (Exception ex)
                      {
                        GA.WriteUserLog(frmMain.langReportBGT2 + ex.Message, allAutoAccount);
                      }
                    }
                  }
                }
                catch (Exception ex)
                {
                }
              }
            }
            frmLogin.GAuto.Settings.Account.CyberDate = !flag3 ? "0" : DateTime.Now.ToString();
          }
        }
        if (frmLogin.GlobalTimer.ElapsedMilliseconds - frmLogin.SavePatternStamp >= 10000L)
        {
          frmLogin.SavePatternStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
          try
          {
            if (frmLogin.SavedPatterns.Count > 0)
            {
              for (int index = frmLogin.SavedPatterns.Count - 1; index >= 0; --index)
              {
                if (frmLogin.SavedPatterns[index].FirstSeen != 0L && frmLogin.GlobalTimer.ElapsedMilliseconds - frmLogin.SavedPatterns[index].FirstSeen >= 40000L)
                  frmLogin.SavedPatterns.RemoveAt(index);
              }
            }
          }
          catch (Exception ex)
          {
          }
        }
        if (this.AllAutoAccounts.Count > 0)
        {
          try
          {
            for (int index3 = frmLogin.GAuto.AllAutoAccounts.Count - 1; index3 >= 0; --index3)
            {
              AutoAccount allAutoAccount = frmLogin.GAuto.AllAutoAccounts[index3];
              if (allAutoAccount.Myself != null)
              {
                try
                {
                  if (allAutoAccount.Myself.DatabaseID > 0)
                  {
                    if (allAutoAccount.Settings.CharDBID != allAutoAccount.Myself.DatabaseID)
                      allAutoAccount.Settings.CharDBID = allAutoAccount.Myself.DatabaseID;
                    if (allAutoAccount.MyPet.CharDBID != allAutoAccount.Myself.DatabaseID)
                      allAutoAccount.MyPet.CharDBID = allAutoAccount.Myself.DatabaseID;
                    if (!allAutoAccount.Settings.AllInformationLoaded && allAutoAccount.Settings.PartySavedPosX != 0 && allAutoAccount.Settings.PartySavedPosY != 0 && allAutoAccount.Settings.PartySavedMapID != -1)
                    {
                      allAutoAccount.Settings.CenterX = (double) allAutoAccount.Settings.PartySavedPosX;
                      allAutoAccount.Settings.CenterY = (double) allAutoAccount.Settings.PartySavedPosY;
                      allAutoAccount.Settings.MapID = allAutoAccount.Settings.PartySavedMapID;
                    }
                    if (frmLogin.GlobalTimer.ElapsedMilliseconds - frmLogin.StampChecker1 < 10000L)
                    {
                      if (frmLogin.StampChecker1 != 0L)
                        continue;
                    }
                    frmLogin.StampChecker1 = frmLogin.GlobalTimer.ElapsedMilliseconds;
                    int lpBaseAddress = 5718988;
                    int lpNumberOfBytesRead = 0;
                    byte[] lpBuffer = new byte[1];
                    MyDLL.ReadProcessMemory((int) allAutoAccount.Target.ProcessHandle, (IntPtr) lpBaseAddress, lpBuffer, 1U, ref lpNumberOfBytesRead);
                    if (lpBuffer[0] != (byte) 86)
                    {
                      if (allAutoAccount.Target.VersionNum == 3)
                      {
                        if (lpBuffer[0] != (byte) 0)
                        {
                          if (!frmMain.InMyIgnoredList(allAutoAccount.Target.ProcessID))
                            frmLogin.GAuto.Settings.ProcessListIgnored.Add(new IgnoredProcess()
                            {
                              processID = allAutoAccount.Target.ProcessID,
                              VersionNum = allAutoAccount.Target.VersionNum
                            });
                          F.UnhookProcess(allAutoAccount, true);
                          try
                          {
                            for (int index4 = frmLogin.GAuto.AllAutoAccounts.Count - 1; index4 >= 0; --index4)
                            {
                              if (frmMain.InMyIgnoredList(frmLogin.GAuto.AllAutoAccounts[index4].Target.ProcessID))
                                frmLogin.GAuto.AllAutoAccounts.RemoveAt(index4);
                            }
                          }
                          catch (Exception ex)
                          {
                          }
                        }
                      }
                    }
                    try
                    {
                      string mainWindowTitle = Process.GetProcessById(allAutoAccount.Target.ProcessID).MainWindowTitle;
                      if (allAutoAccount.Target.CyberStamp == 0L)
                      {
                        switch (GA.Check3rdPartyApp(mainWindowTitle))
                        {
                          case 1:
                          case 99:
                            MyDLL.PostMessage(allAutoAccount.Target.MainWindowHandle, frmLogin.GAuto.Settings.WM_TITLECHANGE, (IntPtr) 0, (IntPtr) 0);
                            allAutoAccount.Target.CyberStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
                            continue;
                          default:
                            continue;
                        }
                      }
                    }
                    catch (Exception ex)
                    {
                    }
                  }
                }
                catch (Exception ex)
                {
                  int num = (int) MessageBox.Show($"{frmMain.langErrorStartup}{ex.Message} Stack: {ex.StackTrace.ToString()}", frmMain.langMinorError, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
              }
            }
          }
          catch (Exception ex)
          {
          }
        }
        if (this.AllAutoAccounts.Count <= 0 && frmLogin.GAuto.BlockedAutoAccounts.Count <= 0)
        {
          if (frmLogin.GAuto.Settings.ProcessListIgnored.Count <= 0)
            goto label_330;
        }
        if (frmLogin.checkLimitStamp < SmartClass.nowStamp())
        {
          frmLogin.checkLimitStamp = SmartClass.nowStamp() + 30000L;
          try
          {
            List<int> toKillProc = new List<int>();
            int num19 = 0;
            double num20 = GA.DayBalance();
            int num21 = 12;
            int num22 = 50;
            for (int index = 6; index <= 90 && num20 >= (double) num22; index += 6)
            {
              num21 = 12 + index;
              num22 += 50;
            }
            double totalBalance = frmLogin.GAuto.Settings.Account.TotalBalance;
            int num23 = 12;
            int num24 = 80 /*0x50*/;
            for (int index = 6; index <= 90 && totalBalance >= (double) num23; index += 6)
            {
              num23 = 12 + index;
              num24 += 80 /*0x50*/;
            }
            if (num23 > num21)
              num21 = num23;
            if (frmLogin.GAuto.AllAutoAccounts.Count > 0)
            {
              for (int index = frmLogin.GAuto.AllAutoAccounts.Count - 1; index >= 0; --index)
              {
                if (frmLogin.GAuto.AllAutoAccounts[index].Target.VersionNum == 1 || frmLogin.GAuto.AllAutoAccounts[index].Target.VersionNum == 2)
                {
                  ++num19;
                  if (num19 > num21)
                  {
                    toKillProc.Add(frmLogin.GAuto.AllAutoAccounts[index].Target.ProcessID);
                    GA.ShowBalloon(frmMain.langLimitAccVNG, frmMain.langWarning, (AutoAccount) null, 5000, (object) num21.ToString(), (object) num22.ToString());
                  }
                }
              }
            }
            if (frmLogin.GAuto.BlockedAutoAccounts.Count > 0)
            {
              for (int index = frmLogin.GAuto.BlockedAutoAccounts.Count - 1; index >= 0; --index)
              {
                if (frmLogin.GAuto.BlockedAutoAccounts[index].Target.VersionNum == 1 || frmLogin.GAuto.BlockedAutoAccounts[index].Target.VersionNum == 2)
                {
                  ++num19;
                  if (num19 > num21)
                  {
                    toKillProc.Add(frmLogin.GAuto.BlockedAutoAccounts[index].Target.ProcessID);
                    GA.ShowBalloon(frmMain.langLimitAccVNG, frmMain.langWarning, (AutoAccount) null, 5000, (object) num21.ToString(), (object) num22.ToString());
                  }
                }
              }
            }
            if (frmLogin.GAuto.Settings.ProcessListIgnored.Count > 0)
            {
              for (int index = frmLogin.GAuto.Settings.ProcessListIgnored.Count - 1; index >= 0; --index)
              {
                if (frmLogin.GAuto.Settings.ProcessListIgnored[index].VersionNum == 1 || frmLogin.GAuto.Settings.ProcessListIgnored[index].VersionNum == 2)
                {
                  ++num19;
                  if (num19 > num21)
                  {
                    toKillProc.Add(frmLogin.GAuto.Settings.ProcessListIgnored[index].processID);
                    frmLogin.GAuto.Settings.ProcessListIgnored.RemoveAt(index);
                    GA.ShowBalloon(frmMain.langLimitAccVNG, frmMain.langWarning, (AutoAccount) null, 5000, (object) num21.ToString(), (object) num22.ToString());
                  }
                }
              }
            }
            if (toKillProc.Count > 0)
              new Thread((ThreadStart) (() =>
              {
                foreach (int processId in toKillProc)
                {
                  try
                  {
                    Process.GetProcessById(processId)?.Kill();
                  }
                  catch (Exception ex)
                  {
                  }
                }
              })).Start();
          }
          catch (Exception ex)
          {
          }
        }
      }
      catch (Exception ex)
      {
        GA.WriteUserLog($"{frmMain.langErrorBGT3}{ex.Message}\n{ex.StackTrace}");
      }
label_330:
      Thread.Sleep(300);
    }
  }

  private void SmartKeepAlive()
  {
    if (frmLogin.GlobalTimer.ElapsedMilliseconds - frmLogin.KeepAliveStamp < GA.checkTimeout)
      return;
    try
    {
      frmLogin.KeepAliveStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
    }
    catch (Exception ex)
    {
    }
    switch (GA.SecureLoginPHPv2(new LoginParams()
    {
      Username = frmLogin.GAuto.Settings.Account.Username,
      Password = frmLogin.GAuto.Settings.Account.Password,
      ShowForm = false
    }).LoginCode)
    {
      case 0:
        ++frmLogin.GAuto.Settings.AliveFailedCounts;
        if (frmLogin.CompilingLanguage == "VN")
        {
          if (GA.blogfun != null)
          {
            if (GA.blogfun.k2 >= 3)
              this.kfail = GA.blogfun.k2;
            if (GA.blogfun.k1 >= 3)
              this.maxFailed = GA.blogfun.k1;
          }
          else
          {
            this.kfail = frmLogin.defaultfun.k2;
            this.maxFailed = frmLogin.defaultfun.k1;
          }
        }
        if (frmLogin.GAuto.Settings.AliveFailedCounts >= this.maxFailed)
        {
          if (frmLogin.AllGAutoServers.Count > 0)
          {
            frmLogin.MainGAutoServer = GA.PickGAutoServer();
            bool flag = false;
            int num = frmLogin.MainGAutoServer.LastOption ? 1 : 0;
            if (!frmLogin.MainGAutoServer.LastOption)
            {
              flag = true;
              frmLogin.UsedAlternativeServer = true;
            }
            if (flag)
            {
              frmLogin.GAuto.Settings.AliveFailedCounts = 0;
            }
            else
            {
              this.keepaliveFailed = true;
              if (this.useBlogSpot)
                this.needCheckBlogSpot = true;
            }
          }
          else
          {
            this.keepaliveFailed = true;
            if (this.useBlogSpot)
              this.needCheckBlogSpot = true;
          }
          if (this.keepaliveFailed)
          {
            if (this.needCheckBlogSpot)
            {
              if (GA.blogfun != null)
              {
                if (GA.blogfun.c1 == "DNF")
                {
                  frmLogin.GAuto.Settings.AliveFailedCounts = 0;
                  SmartClass.servermode = 2;
                  SmartClass.servercase = 3;
                }
                if (GA.blogfun.c1 == "SKO")
                {
                  int num = (int) MessageBox.Show(frmMain.langDisconnectAuto, frmMain.langStopAuto, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                  SmartClass.ForceExitAuto();
                }
              }
            }
            else
            {
              int num = (int) MessageBox.Show(frmMain.langDisconnectAuto, frmMain.langStopAuto, MessageBoxButtons.OK, MessageBoxIcon.Hand);
              SmartClass.ForceExitAuto();
            }
          }
        }
        if (frmLogin.GAuto.Settings.AliveFailedCounts < this.kfail || frmLogin.GAuto.Settings.AliveFailedCounts % this.kfail != 0 || GA.blogfun == null || !(GA.blogfun.c1 != "DNF"))
          break;
        GA.WriteUserLog("Server auto đang khổng ổn định, vui lòng báo cho Admin để kịp thời khắc phục sự cố");
        break;
      case 1:
        frmLogin.GAuto.Settings.AliveFailedCounts = 0;
        break;
      case 400:
        GA.WriteUserLog("Tài khoản này buộc phải thoát auto vì đăng nhập ở một máy khác");
        frmLogin.flagIsKicked = true;
        SmartClass.ForceExitAuto();
        break;
      case 401:
        frmThongBao_FW.ExitAuto = 1;
        GA.ShowMessage(frmMain.langLockedAccount, frmMain.langLockedAccountTitle, 60000);
        SmartClass.ForceExitAuto();
        break;
    }
  }

  public static void ReadBriefInfo(
    IntPtr hProc,
    HashAddressPatch myBase,
    ref int tempLevel,
    ref int tempMaxHP,
    ref int tempMenpai,
    ref int tempRage,
    AutoAccount newAccount)
  {
    if (newAccount != null && myBase != null)
      newAccount.Target.VersionNum = myBase.VersionNum;
    List<int> addresses = new List<int>()
    {
      myBase.Address,
      12,
      492,
      4,
      10204
    };
    if (GA.CheckGameVersion(myBase.VersionNum) == 301)
    {
      addresses[2] = 340;
      addresses[4] = 1856;
    }
    else if (GA.CheckGameVersion(myBase.VersionNum) == 201)
    {
      addresses[2] = 436;
      addresses[4] = 2584;
    }
    else if (GA.CheckGameVersion(myBase.VersionNum) == 350)
    {
      addresses[2] = 480;
      addresses[4] = 9432;
    }
    else if (myBase.VersionNum == 7 || myBase.VersionNum == 8)
    {
      addresses[2] = 492;
      addresses[4] = 10200;
    }
    else if (GA.CheckGameVersion(myBase.VersionNum) == 356)
    {
      addresses[2] = 492;
      addresses[4] = 10204;
    }
    tempMaxHP = SmartClass.MyReadProcessMemory(hProc, addresses, newAccount);
    addresses[4] = 108;
    if (GA.CheckGameVersion(myBase.VersionNum) == 301)
    {
      addresses[2] = 340;
      addresses[4] = 92;
    }
    else if (GA.CheckGameVersion(myBase.VersionNum) == 201)
    {
      addresses[2] = 436;
      addresses[4] = 96 /*0x60*/;
    }
    else if (myBase.VersionNum == 7 || myBase.VersionNum == 8)
    {
      addresses[2] = 492;
      addresses[4] = 108;
    }
    else if (GA.CheckGameVersion(myBase.VersionNum) == 356)
    {
      addresses[2] = 492;
      addresses[4] = 108;
    }
    tempLevel = SmartClass.MyReadProcessMemory(hProc, addresses, newAccount);
    addresses[4] = 244;
    if (GA.CheckGameVersion(myBase.VersionNum) == 301)
    {
      addresses[2] = 340;
      addresses[4] = 168;
    }
    else if (GA.CheckGameVersion(myBase.VersionNum) == 201)
    {
      addresses[2] = 436;
      addresses[4] = 172;
    }
    else if (myBase.VersionNum == 7 || myBase.VersionNum == 8)
    {
      addresses[2] = 492;
      addresses[4] = 244;
    }
    else if (GA.CheckGameVersion(myBase.VersionNum) == 356)
    {
      addresses[2] = 492;
      addresses[4] = 244;
    }
    tempMenpai = SmartClass.MyReadProcessMemory(hProc, addresses, newAccount);
    addresses[4] = 112 /*0x70*/;
    if (GA.CheckGameVersion(myBase.VersionNum) == 301)
    {
      addresses[2] = 340;
      addresses[4] = 96 /*0x60*/;
    }
    else if (GA.CheckGameVersion(myBase.VersionNum) == 201)
    {
      addresses[2] = 436;
      addresses[4] = 100;
    }
    else if (myBase.VersionNum == 7 || myBase.VersionNum == 8)
    {
      addresses[2] = 492;
      addresses[4] = 112 /*0x70*/;
    }
    else if (GA.CheckGameVersion(myBase.VersionNum) == 356)
    {
      addresses[2] = 492;
      addresses[4] = 112 /*0x70*/;
    }
    tempRage = SmartClass.MyReadProcessMemory(hProc, addresses, newAccount);
  }

  public static void RemoveAutoAccount(int i, bool unhook = false, bool isToReset = false)
  {
    try
    {
      frmLogin.GAuto.AllAutoAccounts[i].Target.IsReset = isToReset;
      if (unhook)
      {
        frmLogin.GAuto.AllAutoAccounts[i].IsLicensed = false;
        if (!frmLogin.GAuto.AllAutoAccounts[i].Myself.cboxAnHienGame || !frmLogin.GAuto.AllAutoAccounts[i].Myself.cboxAnHienGame2)
          frmLogin.GAuto.AllAutoAccounts[i].CallBringWindowUp(frmLogin.GAuto.AllAutoAccounts[i].Target.MainWindowHandle);
      }
      frmLogin.GAuto.AllAutoAccounts[i].IsAIEnabled = false;
      if (frmLogin.GAuto.AllAutoAccounts[i].AutoProfile != null)
      {
        frmLogin.GAuto.AllAutoAccounts[i].AutoProfile.IsHandled = false;
        frmLogin.GAuto.AllAutoAccounts[i].AutoProfile.IsAssigned = false;
        frmLogin.GAuto.AllAutoAccounts[i].AutoProfile.NeedHandle = false;
        frmLogin.GAuto.AllAutoAccounts[i].AutoProfile.GameStarted = false;
        frmLogin.GAuto.AllAutoAccounts[i].AutoProfile.InvalidPassword = false;
        frmLogin.GAuto.AllAutoAccounts[i].AutoProfile.RefAutoAccount = (AutoAccount) null;
      }
      if (unhook && frmLogin.GAuto.AllAutoAccounts[i].BGThreadTimer != null && unhook)
        frmLogin.GAuto.AllAutoAccounts[i].BGThreadTimer.Stop();

      frmLogin.GAuto.AllAutoAccounts[i].Target.AICreated = false;
      if (!unhook)
      {
        frmLogin.GAuto.AllAutoAccounts[i].MyInventory = new InventoryClass();
        frmLogin.GAuto.AllAutoAccounts[i].Myself = new MainPlayerClass();
        frmLogin.GAuto.AllAutoAccounts[i].MyPet = new PetClass();
        frmLogin.GAuto.AllAutoAccounts[i].MyParty = new PartyClass();
        frmLogin.GAuto.AllAutoAccounts[i].MyQuai = new QuaiClass();
        frmLogin.GAuto.AllAutoAccounts[i].MySkills = new SkillsClass();
        frmLogin.GAuto.AllAutoAccounts[i].MyPlayers = new PlayerInfo();
        frmLogin.GAuto.AllAutoAccounts[i].MyFlag = new MyFlagClass(frmLogin.GAuto.AllAutoAccounts[i]);
        frmLogin.GAuto.AllAutoAccounts[i].MyArmy = new ArmyClass();
        frmLogin.GAuto.AllAutoAccounts[i].MyBoc = new BocClass();
        frmLogin.GAuto.AllAutoAccounts[i].Settings = new AutoSettings();
        frmLogin.GAuto.AllAutoAccounts[i].Target.NeedToAbort4 = 0;
      }
      F.UnhookProcess(frmLogin.GAuto.AllAutoAccounts[i], unhook, isToReset);
      if (!unhook)
        return;
      if (frmLogin.GAuto.AllAutoAccounts[i].AIThreadTimer != null)
      {
        Debug.WriteLine("Stop  AIThreadTimer ---- from SmartClass line 7348");
        frmLogin.GAuto.AllAutoAccounts[i].AIThreadTimer.Stop();

      }
      frmLogin.GAuto.AllAutoAccounts[i].Target.NeedToAbort2 = true;
      if (unhook)
        frmLogin.GAuto.Settings.ProcessList.Remove(frmLogin.GAuto.AllAutoAccounts[i].Target.ProcessID);
      if (!unhook)
        return;
      frmLogin.GAuto.AllAutoAccounts.RemoveAt(i);
    }
    catch (Exception ex)
    {
    }
  }

  public void KeepAliveFunction()
  {
    while (true)
    {
      if (this.UIAvailable && frmLogin.GlobalTimer.ElapsedMilliseconds - frmLogin.KeepAliveFuncStamp > 2000L)
      {
        frmLogin.KeepAliveFuncStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
        if (frmLogin.GAuto.AllAutoAccounts.Count > 0)
        {
          try
          {
            for (int index = frmLogin.GAuto.AllAutoAccounts.Count - 1; index >= 0; --index)
            {
              AutoAccount allAutoAccount = frmLogin.GAuto.AllAutoAccounts[index];
              if (allAutoAccount != null && !allAutoAccount.Target.ThreadDied)
                allAutoAccount.Target.SelfAutoRef = 1;
            }
          }
          catch (Exception ex)
          {
          }
        }
      }
      Thread.Sleep(1000);
    }
  }

  public static void ForceExitAuto()
  {
    try
    {
      for (int index = frmLogin.GAuto.AllAutoAccounts.Count - 1; index >= 0; --index)
      {
        AutoAccount allAutoAccount = frmLogin.GAuto.AllAutoAccounts[index];
        allAutoAccount.IsAIEnabled = false;
        allAutoAccount.Settings.AIWhileLoop = false;
      }
    }
    catch (Exception ex)
    {
    }
    finally
    {
      frmLogin.ForcefullyExit = true;
    }
  }

  private void AddAccount(
    Process proc,
    AutoAccount newAccount,
    int tempProc_ID,
    IntPtr tempWindowHandle,
    uint tempMainThreadID,
    IntPtr hProc,
    StringBuilder tempProcessPath,
    string tempFileName,
    int VersionNum,
    int titleCheck)
  {
    newAccount.Target.ProcessID = tempProc_ID;
    newAccount.Target.MainWindowHandle = tempWindowHandle;
    newAccount.Target.MainThreadID = tempMainThreadID;
    newAccount.Target.ProcessStartTime = proc.StartTime;
    newAccount.Target.ProcessExePath = tempProcessPath.ToString().ToLower();
    newAccount.Target.ProcessFileName = tempFileName;
    newAccount.Target.ProcessHandle = hProc;
    newAccount.Target.VersionNum = VersionNum;
    newAccount.Target.GLoginAIReady = false;
    newAccount.Target.FirstSeenStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
    newAccount.Target.Status = AllEnums.InjectionStatus.FoundProcess;
    if (!frmLogin.GAuto.Settings.optAcceptNewGame && titleCheck == 1)
      titleCheck = 99;
    if (titleCheck == 99)
    {
      newAccount.Target.CyberBlacklisted = true;
      MyDLL.PostMessage(newAccount.Target.MainWindowHandle, frmLogin.GAuto.Settings.WM_TITLECHANGE, (IntPtr) 0, (IntPtr) 0);
      this.AllCyberAccounts.Add(newAccount);
    }
    else
      this.AllAutoAccounts.Add(newAccount);
    if (titleCheck == 1 || titleCheck == 99)
      newAccount.Target.CyberStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
    newAccount.BGThreadTimer = new System.Timers.Timer(300);
    newAccount.BGThreadTimer.Elapsed += newAccount.OnBGThreadTimerElapsed;
    newAccount.BGThreadTimer.AutoReset = true;
    newAccount.BGThreadTimer.Start();
  }

  private static HashAddressPatch GetMyPatch(AutoAccount newAccount)
  {
    HashAddressPatch myPatch = (HashAddressPatch) null;
    foreach (HashAddressPatch multiAccPatch in frmLogin.GAuto.Settings.MultiAccPatches)
    {
      if (multiAccPatch.Hash == newAccount.Target.TargetHash && multiAccPatch.Address != 0)
      {
        myPatch = multiAccPatch;
        break;
      }
    }
    return myPatch;
  }

  private static HashAddressPatch GetBasicBases(AutoAccount newAccount)
  {
    HashAddressPatch basicBases = (HashAddressPatch) null;
    foreach (HashAddressPatch charInfoBriefBase in frmLogin.GAuto.Settings.CharInfoBriefBases)
    {
      string str = "";
      if (frmLogin.HashDB.Count > 0)
      {
        foreach (HashDBElement hashDbElement in frmLogin.HashDB)
        {
          if (hashDbElement.NewHash == newAccount.Target.TargetHash)
            str = hashDbElement.MatchingHash;
        }
      }
      bool flag = false;
      if (charInfoBriefBase.Hash == newAccount.Target.TargetHash || charInfoBriefBase.Hash == str && str != "")
        flag = true;
      if (flag && charInfoBriefBase.Address != 0)
      {
        basicBases = charInfoBriefBase;
        break;
      }
    }
    return basicBases;
  }

  private void GetMyBases_ReadPattern(AutoAccount newAccount)
  {
    if (newAccount == null)
      return;
    string str1 = "";
    string versionCode1 = SmartClass.GetVersionCode(newAccount);
    bool flag1 = false;
    if (versionCode1 == "47062" || versionCode1 == "88187")
      flag1 = true;
    if ((frmLogin.CompilingLanguage != "CN" || frmLogin.ReadOldStyle) && !flag1)
    {
      if (frmLogin.HashDB.Count > 0)
      {
        foreach (HashDBElement hashDbElement in frmLogin.HashDB)
        {
          if (hashDbElement.NewHash == newAccount.Target.TargetHash)
            str1 = hashDbElement.MatchingHash;
        }
      }
      foreach (BaseInfo baseInfo in frmLogin.MyBases)
      {
        bool flag2 = false;
        if (baseInfo.myHash == newAccount.Target.TargetHash || baseInfo.myHash == str1 && str1 != "")
          flag2 = true;
        if (flag2)
        {
          string[] strArray = GA.XOREncrypt(baseInfo.myInfo, "TDTthangancap").Split('|');
          if (strArray.Length < 3)
            break;
          string str2 = strArray[2];
          int num1 = 1;
          string s = GA.GetMidString(str2, "bs13,0x", ",");
          if (string.IsNullOrEmpty(s))
            s = "1";
          int num2 = int.Parse(s, NumberStyles.HexNumber);
          SmartClass.GetBSSettings(str2, "bs40,0x", ref frmLogin.GAuto.Settings.EnableAT);
          SmartClass.GetBSSettings(str2, "bs41,0x", ref frmLogin.GAuto.Settings.EnableAB);
          SmartClass.GetBSSettings(str2, "bs42,0x", ref frmLogin.GAuto.Settings.EnableQ12);
          SmartClass.GetBSSettings(str2, "bs43,0x", ref frmLogin.GAuto.Settings.EnableYTO);
          SmartClass.GetBSSettings(str2, "bs45,0x", ref frmLogin.GAuto.Settings.EnableKyCuoc);
          if (num2 != 0)
          {
            HashAddressPatch hashAddressPatch = new HashAddressPatch();
            hashAddressPatch.Hash = newAccount.Target.TargetHash;
            hashAddressPatch.AltHash = str1;
            hashAddressPatch.Address = num2;
            num1 = int.Parse(GA.GetMidString(str2, "bs32,", ","), NumberStyles.HexNumber);
            hashAddressPatch.VersionNum = num1;
            bool flag3 = true;
            foreach (HashAddressPatch multiAccPatch in frmLogin.GAuto.Settings.MultiAccPatches)
            {
              if (multiAccPatch.Hash == hashAddressPatch.Hash)
              {
                flag3 = false;
                break;
              }
            }
            if (flag3)
              frmLogin.GAuto.Settings.MultiAccPatches.Add(hashAddressPatch);
          }
          int num3 = int.Parse(GA.GetMidString(strArray[0], ",rm1,int,4,0x", ","), NumberStyles.HexNumber);
          if (num3 != 0)
          {
            HashAddressPatch hashAddressPatch = new HashAddressPatch();
            hashAddressPatch.Hash = newAccount.Target.TargetHash;
            hashAddressPatch.Address = num3;
            hashAddressPatch.VersionNum = num1;
            bool flag4 = true;
            foreach (HashAddressPatch charInfoBriefBase in frmLogin.GAuto.Settings.CharInfoBriefBases)
            {
              if (charInfoBriefBase.Hash == hashAddressPatch.Hash)
              {
                flag4 = false;
                break;
              }
            }
            if (flag4)
              frmLogin.GAuto.Settings.CharInfoBriefBases.Add(hashAddressPatch);
          }
          break;
        }
      }
    }
    else
    {
      bool flag5 = false;
      if (frmLogin.SavedPatterns.Count > 0)
      {
        foreach (GGameMemory savedPattern in frmLogin.SavedPatterns)
        {
          if (savedPattern.ProcessID == newAccount.Target.ProcessID && savedPattern.GameHash == newAccount.Target.TargetHash)
          {
            savedPattern.FirstSeen = frmLogin.GlobalTimer.ElapsedMilliseconds;
            string str3 = JsonConvert.SerializeObject((object) savedPattern);
            newAccount.Target.ClientPattern = JsonConvert.DeserializeObject<GGameMemory>(str3);
            newAccount.Target.ClientPatternKey = savedPattern.GameKey;
            flag5 = true;
            break;
          }
        }
      }
      if (frmLogin.GamePatterns.Count > 0 && newAccount.Target.ClientPatternKey == string.Empty)
      {
        foreach (GGameMemory gamePattern in frmLogin.GamePatterns)
        {
          if (gamePattern.GameHash != "" && gamePattern.GameHash == newAccount.Target.TargetHash)
          {
            newAccount.Target.ClientPatternKey = gamePattern.GameKey;
            break;
          }
        }
      }
      if (newAccount.Target.ClientPatternKey == string.Empty && !flag5)
      {
        string versionCode2 = SmartClass.GetVersionCode(newAccount);
        if (versionCode2 != "")
        {
          int result1 = 0;
          int num4 = 999999;
          int.TryParse(versionCode2, out result1);
          if (frmLogin.GamePatterns.Count > 0)
          {
            bool flag6 = false;
            foreach (GGameMemory gamePattern in frmLogin.GamePatterns)
            {
              int result2 = 0;
              if (gamePattern.GameVersionCode.Count > 0)
              {
                foreach (string s in gamePattern.GameVersionCode)
                {
                  int.TryParse(s, out result2);
                  int num5 = Math.Abs(result2 - result1);
                  if (num5 <= num4)
                  {
                    newAccount.Target.ClientPatternKey = gamePattern.GameKey;
                    num4 = num5;
                    if (num4 == 0)
                    {
                      flag6 = true;
                      break;
                    }
                  }
                }
              }
              if (flag6)
                break;
            }
          }
        }
      }
      bool flag7 = true;
      if (frmLogin.GamePatterns.Count > 0 && newAccount.Target.ClientPatternKey != "" && !flag5)
      {
        GGameMemory ggameMemory = (GGameMemory) null;
        foreach (GGameMemory gamePattern in frmLogin.GamePatterns)
        {
          if (string.Compare(gamePattern.GameHash, newAccount.Target.TargetHash, true) == 0)
          {
            ggameMemory = gamePattern;
            break;
          }
          if (newAccount.Target.ClientPatternKey == gamePattern.GameKey)
          {
            ggameMemory = gamePattern;
            break;
          }
        }
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        if (ggameMemory != null)
        {
          string str4 = JsonConvert.SerializeObject((object) ggameMemory);
          newAccount.Target.ClientPattern = JsonConvert.DeserializeObject<GGameMemory>(str4);
          newAccount.Target.ClientPattern.GameHash = newAccount.Target.TargetHash;
          if (newAccount.Target.ClientPattern.Membases.Count > 0)
          {
            int num6 = 0;
            int num7 = 0;
            int num8 = 0;
            foreach (GMemBase membase in newAccount.Target.ClientPattern.Membases)
            {
              if (membase.Name != "")
              {
                if (membase.Name == "bs_multiacc" && membase.Pattern != null && !membase.IsRead)
                {
                  num6 = TargetProcess.AobScan(newAccount, membase.Pattern.Pattern, membase.Index, membase.ReadMem, membase.Offset, membase.AddSub);
                  if (num6 != 0)
                  {
                    membase.Value = num6;
                    membase.IsRead = true;
                  }
                }
                if (membase.Name == "bs_versionnum")
                  num7 = membase.Value;
                if (membase.Name == "bs_enableAT")
                  frmLogin.GAuto.Settings.EnableAT = membase.Value;
                if (membase.Name == "bs_enableAB")
                  frmLogin.GAuto.Settings.EnableAB = membase.Value;
                if (membase.Name == "bs_enableQ12")
                  frmLogin.GAuto.Settings.EnableQ12 = membase.Value;
                if (membase.Name == "bs_enableYTO")
                  frmLogin.GAuto.Settings.EnableYTO = membase.Value;
                if (membase.Name == "bs_enableCheDo")
                  frmLogin.GAuto.Settings.EnableCheDo = membase.Value;
                if (membase.Name == "bs_enableKyCuoc")
                  frmLogin.GAuto.Settings.EnableKyCuoc = membase.Value;
                if (membase.Name == "bs_charinfo" && membase.Pattern != null && !membase.IsRead)
                {
                  num8 = TargetProcess.AobScan(newAccount, membase.Pattern.Pattern, membase.Index, membase.ReadMem, membase.Offset, membase.AddSub);
                  if (num8 == 0)
                  {
                    try
                    {
                      ++membase.Errors;
                      if (membase.Errors >= frmLogin.GAuto.Settings.MaxBaseError)
                      {
                        membase.Errors = 0;
                        string str5 = "none";
                        if (membase.Pattern != null)
                          str5 = GA.ByteArrayToString(membase.Pattern.Pattern);
                        GA.WriteUserLog("Error reading memory #1. Log: " + str5);
                      }
                    }
                    catch (Exception ex)
                    {
                    }
                  }
                  else
                  {
                    membase.Value = num8;
                    membase.IsRead = true;
                  }
                }
                if (!membase.IsRead || frmLogin.PointerBasesNames.Contains(membase.Name))
                {
                  int num9 = TargetProcess.AobScan(newAccount, membase.Pattern.Pattern, membase.Index, membase.ReadMem, membase.Offset, membase.AddSub);
                  if (membase.Name == "bs28" && num9 == 0)
                    flag7 = false;
                  if (num9 == 0)
                  {
                    ++membase.Errors;
                  }
                  else
                  {
                    membase.Errors = 0;
                    membase.Value = num9;
                    membase.IsRead = true;
                  }
                }
              }
            }
            if (num6 > 0)
            {
              HashAddressPatch hashAddressPatch = new HashAddressPatch();
              hashAddressPatch.Hash = newAccount.Target.TargetHash;
              hashAddressPatch.Address = num6;
              hashAddressPatch.VersionNum = num7;
              bool flag8 = true;
              foreach (HashAddressPatch multiAccPatch in frmLogin.GAuto.Settings.MultiAccPatches)
              {
                if (multiAccPatch.Hash == hashAddressPatch.Hash)
                {
                  flag8 = false;
                  multiAccPatch.Address = hashAddressPatch.Address;
                  break;
                }
              }
              if (flag8)
                frmLogin.GAuto.Settings.MultiAccPatches.Add(hashAddressPatch);
            }
            if (num8 > 0)
            {
              HashAddressPatch hashAddressPatch = new HashAddressPatch();
              hashAddressPatch.Hash = newAccount.Target.TargetHash;
              hashAddressPatch.Address = num8;
              hashAddressPatch.VersionNum = num7;
              bool flag9 = true;
              foreach (HashAddressPatch charInfoBriefBase in frmLogin.GAuto.Settings.CharInfoBriefBases)
              {
                if (charInfoBriefBase.Hash == hashAddressPatch.Hash)
                {
                  flag9 = false;
                  break;
                }
              }
              if (flag9)
                frmLogin.GAuto.Settings.CharInfoBriefBases.Add(hashAddressPatch);
            }
          }
        }
        stopwatch.Stop();
      }
      if (!flag5 && flag7)
      {
        bool flag10 = false;
        if (frmLogin.SavedPatterns.Count > 0)
        {
          foreach (GGameMemory savedPattern in frmLogin.SavedPatterns)
          {
            if (savedPattern.ProcessID == newAccount.Target.ProcessID && savedPattern.GameHash == newAccount.Target.TargetHash)
            {
              flag10 = true;
              break;
            }
          }
        }
        if (!flag10 && newAccount.Target.ClientPattern != null)
        {
          GGameMemory ggameMemory = JsonConvert.DeserializeObject<GGameMemory>(JsonConvert.SerializeObject((object) newAccount.Target.ClientPattern));
          ggameMemory.GameHash = newAccount.Target.TargetHash;
          ggameMemory.ProcessID = newAccount.Target.ProcessID;
          ggameMemory.FirstSeen = frmLogin.GlobalTimer.ElapsedMilliseconds;
          frmLogin.SavedPatterns.Add(ggameMemory);
        }
        if (newAccount.Target.ClientPattern == null && !frmLogin.IncompatibleProcessID.Contains(newAccount.Target.ProcessID))
        {
          GA.WriteUserLog("Incompatible game version. Please contact the auto team. Version code = " + newAccount.Target.FileVersion);
          frmLogin.IncompatibleProcessID.Add(newAccount.Target.ProcessID);
        }
      }
      if (newAccount.Target.MemReg == null)
        return;
      newAccount.Target.MemReg.Clear();
      GC.Collect();
    }
  }

  private static string GetVersionCode(AutoAccount newAccount)
  {
    string versionCode = "";
    GameHash gameHash = (GameHash) null;
    if (SmartClass.allHash.Count > 0)
    {
      for (int index = SmartClass.allHash.Count - 1; index >= 0; --index)
      {
        if (SmartClass.allHash[index].GamePath == newAccount.Target.ProcessExePath)
        {
          if (SmartClass.allHash[index].GameVer != "")
            return SmartClass.allHash[index].GameVer;
          gameHash = SmartClass.allHash[index];
          break;
        }
      }
    }
    string path = Path.GetDirectoryName(newAccount.Target.ProcessExePath).Replace("bin", "");
    if (Directory.Exists(path) && File.Exists(path + "(version)"))
    {
      StreamReader streamReader = new StreamReader(path + "(version)");
      if (streamReader != null)
      {
        try
        {
          string str1 = streamReader.ReadLine();
          if (str1 != "")
          {
            if (str1.Contains("|"))
            {
              string[] strArray = str1.Split('|');
              if (strArray.Length >= 2)
              {
                versionCode = strArray[1];
                newAccount.Target.FileVersion = versionCode;
                if (strArray.Length >= 3)
                {
                  string str2 = strArray[2];
                }
              }
            }
          }
        }
        catch (Exception ex)
        {
        }
        finally
        {
          streamReader.Close();
        }
      }
    }
    if (gameHash != null)
      gameHash.GameVer = versionCode;
    return versionCode;
  }

  public static void GetBSSettings(string masterString, string keyword, ref int myInt)
  {
    string s = GA.GetMidString(masterString, keyword, ",");
    if (string.IsNullOrEmpty(s))
      s = "1";
    int.TryParse(s, out myInt);
  }

  private static int MyReadProcessMemory(IntPtr hProc, List<int> addresses, AutoAccount newAccount = null)
  {
    int num = 0;
    bool flag = false;
    if (newAccount != null && newAccount.Target.VersionNum <= 4)
      flag = true;
    for (int index = 0; index < addresses.Count; ++index)
    {
      int lpBaseAddress = addresses[index];
      if (index == 0)
      {
        if (!(newAccount.Target.ClientPatternKey != "") && (frmLogin.CompilingLanguage != "CN" || flag))
          lpBaseAddress += 4194304 /*0x400000*/;
      }
      else
        lpBaseAddress = num + addresses[index];
      byte[] lpBuffer = new byte[4];
      int lpNumberOfBytesRead = 0;
      MyDLL.ReadProcessMemory((int) hProc, (IntPtr) lpBaseAddress, lpBuffer, (uint) lpBuffer.Length, ref lpNumberOfBytesRead);
      num = BitConverter.ToInt32(lpBuffer, 0);
    }
    return num;
  }

  private static void GetLoadLibraryHandle()
  {
    if (!(frmLogin.LoadLibraryAddr == IntPtr.Zero))
      return;
    using (Process process = Process.Start(new ProcessStartInfo()
    {
      FileName = ".\\ghandle.exe",
      RedirectStandardOutput = true,
      WindowStyle = ProcessWindowStyle.Hidden,
      CreateNoWindow = true,
      UseShellExecute = false
    }))
    {
      using (StreamReader standardOutput = process.StandardOutput)
      {
        string end = standardOutput.ReadToEnd();
        int num = 0;
        try
        {
          num = int.Parse(end, NumberStyles.HexNumber);
        }
        catch (Exception ex)
        {
        }
        frmLogin.LoadLibraryAddr = (IntPtr) num;
      }
    }
  }

  public static void InjectDll(AutoAccount newAccount, bool GLoginHook = false)
  {
    lock (frmLogin.dllinjectlock)
    {
      SmartClass.KickMyAss(newAccount);
      if (File.Exists(frmLogin.GAuto.Settings.BaseDllName))
      {
        string sourceFileName = frmLogin.GAuto.Settings.BaseDllName;
        if (SmartClass.allHash.Count > 0 && frmLogin.GAuto.Settings.DLLHash == string.Empty)
        {
          for (int index = SmartClass.allHash.Count - 1; index >= 0; --index)
          {
            if (SmartClass.allHash[index].GamePath == sourceFileName)
            {
              frmLogin.GAuto.Settings.DLLHash = SmartClass.allHash[index].RealHash;
              break;
            }
          }
        }
        if (frmLogin.GAuto.Settings.DLLHash == string.Empty)
        {
          using (MD5 md5 = MD5.Create())
          {
            using (FileStream inputStream = File.OpenRead(sourceFileName.ToLower()))
            {
              try
              {
                frmLogin.GAuto.Settings.DLLHash = BitConverter.ToString(md5.ComputeHash((Stream) inputStream)).Replace("-", "").ToUpper();
                SmartClass.allHash.Add(new GameHash()
                {
                  GamePath = sourceFileName,
                  RealHash = frmLogin.GAuto.Settings.DLLHash
                });
              }
              catch (Exception ex)
              {
              }
            }
          }
        }
        string str1 = "wshtcpip.tmp";
        if (GLoginHook)
        {
          str1 = "wshtcpips.tmp";
          sourceFileName = "glogin.dll";
        }
        string tempPath = Path.GetTempPath();
        if (frmLogin.DllHandle == IntPtr.Zero)
        {
          try
          {
            string str2 = "";
            if (File.Exists(tempPath + str1))
            {
              using (MD5 md5 = MD5.Create())
              {
                using (FileStream inputStream = File.OpenRead((tempPath + str1).ToLower()))
                  str2 = BitConverter.ToString(md5.ComputeHash((Stream) inputStream)).Replace("-", "").ToUpper();
              }
            }
            if (str2 != frmLogin.GAuto.Settings.DLLHash)
            {
              File.Delete(tempPath + str1);
              File.Copy(sourceFileName, tempPath + str1);
            }
          }
          catch (Exception ex)
          {
          }
          try
          {
            frmLogin.DllHandle = MyDLL.LoadLibrary(Path.GetTempPath() + str1);
          }
          catch (Exception ex)
          {
          }
        }
        IntPtr zero = IntPtr.Zero;
        IntPtr dllHandle = frmLogin.DllHandle;
        IntPtr procAddress = MyDLL.GetProcAddress(dllHandle, "GetMsgProc");
        if (!GLoginHook)
          newAccount.Target.hHook = (HookProc) Marshal.GetDelegateForFunctionPointer(procAddress, typeof (HookProc));
        else if (GLoginHook)
          newAccount.Target.hHookGLogin = (HookProc) Marshal.GetDelegateForFunctionPointer(procAddress, typeof (HookProc));
        try
        {
          if (procAddress != IntPtr.Zero)
          {
            if (!GLoginHook)
              newAccount.Target.HookResult = MyDLL.SetWindowsHookEx(MyDLL.HookType.WH_GETMESSAGE, newAccount.Target.hHook, dllHandle, newAccount.Target.MainThreadID);
            else if (GLoginHook)
              newAccount.Target.HookGLoginResult = MyDLL.SetWindowsHookEx(MyDLL.HookType.WH_GETMESSAGE, newAccount.Target.hHookGLogin, dllHandle, newAccount.Target.MainThreadID);
            if (newAccount.Target.HookResult == IntPtr.Zero && !GLoginHook)
              GA.WriteUserLog(frmMain.langHookError + MyDLL.GetLastError().ToString());
          }
          else if (GA.isVipMember() && frmLogin.LoadLibraryAddr == IntPtr.Zero)
          {
            int num = (int) MessageBox.Show("Could not find my hook proc function", "Failed");
          }
          newAccount.Target.IsHooked = true;
          newAccount.Target.IsInjected = true;
        }
        catch (Exception ex)
        {
        }
      }
      else
      {
        if (!GA.isVipMember() || !(frmLogin.LoadLibraryAddr == IntPtr.Zero))
          return;
        int num = (int) MessageBox.Show("Could not find my lovely DLL", "Failed");
      }
    }
  }

  public static unsafe string KickMyAss(AutoAccount newAccount, int delay = 1000)
  {
    lock (frmLogin.dllinjectlock)
    {
      string str1 = "";
      if (File.Exists("gpilot.dll"))
      {
        string str2 = "gpilot.dll";
        str1 = Path.GetTempPath() + str2;
        try
        {
          File.Delete(str1);
          File.Copy("gpilot.dll", str1);
        }
        catch (Exception ex)
        {
        }
        IntPtr zero = IntPtr.Zero;
        SmartClass.GetLoadLibraryHandle();
        IntPtr loadLibraryAddr = frmLogin.LoadLibraryAddr;
        if (loadLibraryAddr != IntPtr.Zero)
        {
          IntPtr num = MyDLL.VirtualAllocEx(newAccount.Target.ProcessHandle, IntPtr.Zero, (IntPtr) str1.Length, 12288U /*0x3000*/, 64U /*0x40*/);
          byte[] bytes = Encoding.UTF8.GetBytes(str1);
          if (frmLogin.CompilingLanguage == "CN")
            bytes = Encoding.GetEncoding("gb2312").GetBytes(str1);
          MyDLL.WriteProcessMemory(newAccount.Target.ProcessHandle, num, bytes, (uint) str1.Length, 0);
          MyDLL.CreateRemoteThread(newAccount.Target.ProcessHandle, (IntPtr) (void*) null, (IntPtr) 0, loadLibraryAddr, num, 0U, (IntPtr) 0);
        }
        else if (GA.isVipMember() && frmLogin.LoadLibraryAddr == IntPtr.Zero)
        {
          int num1 = (int) MessageBox.Show("Could not find API handle", "Failed");
        }
      }
      int num2 = 0;
      long elapsedMilliseconds = frmLogin.GlobalTimer.ElapsedMilliseconds;
      for (; num2 <= 5; ++num2)
      {
        Thread.Sleep(200);
        try
        {
          File.Delete(str1);
          break;
        }
        catch (Exception ex)
        {
        }
      }
      return str1;
    }
  }

  public static int SearchAutoAccount(int processID)
  {
    if (frmLogin.GAuto.AllAutoAccounts.Count <= 0)
      return -1;
    try
    {
      for (int index = frmLogin.GAuto.AllAutoAccounts.Count - 1; index >= 0; --index)
      {
        if (frmLogin.GAuto.AllAutoAccounts[index].Target.ProcessID == processID)
          return index;
      }
    }
    catch (Exception ex)
    {
    }
    return -1;
  }

  public bool DownloadBaseAddress(string targetVersion)
  {
    int num = (int) MessageBox.Show("Download base addrseses từ server dựa trên version của target hiện tại");
    return true;
  }
}
