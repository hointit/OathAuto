// Decompiled with JetBrains decompiler
// Type: SmartBot.F
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

#nullable disable
namespace SmartBot;

public class F
{
  public static void MoiDoiCaNhom(AutoAccount account)
  {
    new Thread((ThreadStart) (() => F.InviteParty(account)))
    {
      IsBackground = true
    }.Start();
  }

  public static int PlayerComparison(PlayerListItem a, PlayerListItem b)
  {
    if (a.Name == b.Name)
      return 0;
    List<string> stringList = new List<string>();
    stringList.Add(a.Name);
    stringList.Add(b.Name);
    stringList.Sort();
    return stringList[0] == a.Name ? -1 : 1;
  }

  public static void HienGame(List<AutoAccount> accounts)
  {
    if (accounts == null || accounts.Count <= 0)
      return;
    foreach (AutoAccount account in accounts)
    {
      if (account != null)
        F.HienGameSingle(account);
    }
  }

  public static void HienGameSingle(AutoAccount account, bool special = false)
  {
    if (account == null)
      return;
    if (!special)
    {
      if (!account.Myself.cboxAnHienGame && account.Myself.cboxAnHienGame2 || account.Myself.cboxAnHienGame && account.Myself.cboxAnHienGame2)
      {
        account.CallBringWindowUp(account.Target.MainWindowHandle);
        account.Myself.cboxAnHienGame = true;
        return;
      }
      if (!account.Myself.cboxAnHienGame2 && account.Myself.cboxAnHienGame)
      {
        account.CallBringWindowUp(account.Target.MainWindowHandle, 1);
        account.Myself.cboxAnHienGame2 = true;
        return;
      }
      if (!account.Myself.cboxAnHienGame && !account.Myself.cboxAnHienGame2)
      {
        account.CallBringWindowUp(account.Target.MainWindowHandle, 2);
        account.Myself.cboxAnHienGame = true;
        account.Myself.cboxAnHienGame2 = true;
      }
    }
    if (!special)
      return;
    account.CallBringWindowUp(account.Target.MainWindowHandle, 3);
  }

  public static void ShowHideToTaskBar(List<AutoAccount> accounts)
  {
    if (accounts == null || accounts.Count <= 0)
      return;
    foreach (AutoAccount account in accounts)
    {
      if (account != null)
      {
        F.HienGameSingle(account);
        account.CallHideWindow(account.Target.MainWindowHandle, 21);
      }
    }
  }

  public static void HideMyWindow(List<AutoAccount> accounts, int myType = 0)
  {
    if (accounts == null || accounts.Count <= 0)
      return;
    foreach (AutoAccount account in accounts)
    {
      if (account != null)
        F.HideMyWindowSingle(account, myType);
    }
  }

  public static void ThoatGameNhanh(List<AutoAccount> accounts)
  {
    if (accounts == null || accounts.Count <= 0)
      return;
    foreach (AutoAccount account in accounts)
    {
      if (account != null)
      {
        account.CallOutGame();
        F.UnhookProcess(account, true);
      }
    }
  }

  public static bool InMyIgnoredList(int procID)
  {
    bool flag = false;
    if (frmLogin.GAuto.Settings.ProcessListIgnored.Count > 0)
    {
      try
      {
        for (int index = frmLogin.GAuto.Settings.ProcessListIgnored.Count - 1; index >= 0; --index)
        {
          if (frmLogin.GAuto.Settings.ProcessListIgnored[index].processID == procID)
          {
            flag = true;
            break;
          }
        }
      }
      catch (Exception ex)
      {
      }
    }
    return flag;
  }

  public static void UnhookProcess(AutoAccount account, bool unhook = false, bool isToReset = false)
  {
    account.Target.IsReset = isToReset;
    if (!unhook)
    {
      if (account == null)
        return;
      frmLogin.GAuto.BlockedAutoAccounts.Add(account);
      frmLogin.GAuto.AllAutoAccounts.Remove(account);
      account.Target.TempRemoved = true;
      account.IsAIEnabled = false;
      Debug.WriteLine("AICreated UnhookProcess");
      account.Target.AICreated = false;
      MyDLL.PostMessage(account.Target.MainWindowHandle, frmLogin.GAuto.Settings.WM_PSEUDOCODE, (IntPtr) 0, (IntPtr) 0);
    }
    else
    {
      account.Target.DLLExit = true;
      if (account.Target.Status == AllEnums.InjectionStatus.FoundProcess && !unhook)
        return;
      if (unhook)
        account.Target.Status = AllEnums.InjectionStatus.FoundProcess;
      F.UnloadAIThread(account);
      if (unhook)
      {
        F.UnloadMainDLL(account);
        F.UnloadBGThread(account);
      }
      account.Target.NeedToAbort = true;
      if (account.Myself != null)
        account.Myself.Initialized = false;
      if (!unhook)
        return;
      account.Target.IsHooked = false;
    }
  }

  private static void UnloadBGThread(AutoAccount account)
  {
    try
    {
      long elapsedMilliseconds = frmLogin.GlobalTimer.ElapsedMilliseconds;
      
      account.BGThreadTimer.Stop();
      account.BGThreadTimer = null;
    }
    catch (Exception ex)
    {
      GA.WriteUserLog(frmMain.langCannotOffBGT + ex.Message, account);
    }
  }

  private static void UnloadMainDLL(AutoAccount account)
  {
    if (account.Target.HookResult != IntPtr.Zero || account.Target.HookGLoginResult != IntPtr.Zero)
    {
      long elapsedMilliseconds = frmLogin.GlobalTimer.ElapsedMilliseconds;
      int num = 0;
      while (account.Target.IsHooked)
      {
        account.PleaseUnhook();
        ++num;
        Thread.Sleep(10);
        if (frmLogin.GlobalTimer.ElapsedMilliseconds - elapsedMilliseconds >= 500L || num >= 5)
          break;
      }
    }
    SmartClass.KickMyAss(account);
  }

  private static void UnloadAIThread(AutoAccount account)
  {
    try
    {
      account.AIThreadTimer.Stop();
      account.AIThreadTimer = null;
    }
    catch (Exception ex)
    {
      GA.WriteUserLog(frmMain.langCannotOffAI + ex.Message, account);
    }
  }

  public static void KickAccAuto(List<AutoAccount> accounts)
  {
    if (accounts == null || accounts.Count <= 0)
      return;
    foreach (AutoAccount account in accounts)
    {
      if (account != null)
      {
        if (!F.InMyIgnoredList(account.Target.ProcessID))
          frmLogin.GAuto.Settings.ProcessListIgnored.Add(new IgnoredProcess()
          {
            processID = account.Target.ProcessID,
            VersionNum = account.Target.VersionNum
          });
        F.UnhookProcess(account, isToReset: true);
      }
    }
    try
    {
      for (int index = frmLogin.GAuto.AllAutoAccounts.Count - 1; index >= 0; --index)
      {
        if (F.InMyIgnoredList(frmLogin.GAuto.AllAutoAccounts[index].Target.ProcessID))
        {
          frmLogin.GAuto.Settings.ProcessList.Remove(frmLogin.GAuto.AllAutoAccounts[index].Target.ProcessID);
          frmLogin.GAuto.AllAutoAccounts.RemoveAt(index);
        }
      }
    }
    catch (Exception ex)
    {
    }
  }

  public static void HienGameBiMat(List<AutoAccount> accounts)
  {
    if (accounts == null || accounts.Count <= 0)
      return;
    foreach (AutoAccount account in accounts)
    {
      if (account != null)
      {
        account.CallBringWindowUp(account.Target.MainWindowHandle, 98);
        account.Myself.cboxAnHienGame = true;
        account.Myself.cboxAnHienGame2 = true;
      }
    }
  }

  public static void HideMyWindowSingle(AutoAccount account, int myType = 0)
  {
    if (account == null)
      return;
    switch (myType)
    {
      case 0:
      case 10:
        if (!account.Myself.cboxAnHienGame)
          break;
        if (myType == 0)
          account.CallHideWindow(account.Target.MainWindowHandle, 0);
        else
          account.CallHideWindow(account.Target.MainWindowHandle, 10);
        account.Myself.cboxAnHienGame = false;
        break;
      case 1:
      case 20:
        if (account.Myself.cboxAnHienGame2)
        {
          account.Myself.AnGame2Stamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
          if (myType == 1)
            account.CallHideWindow(account.Target.MainWindowHandle, 1);
          else
            account.CallHideWindow(account.Target.MainWindowHandle, 20);
          account.Myself.cboxAnHienGame2 = false;
          account.Myself.AnGame1Stamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
          account.Myself.AnGameFlip = false;
          break;
        }
        if (myType != 20)
          break;
        account.CallHideWindow(account.Target.MainWindowHandle, 20);
        account.Myself.cboxAnHienGame2 = false;
        account.Myself.AnGame1Stamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
        account.Myself.AnGameFlip = false;
        break;
    }
  }

  public static void SetNhomID(List<AutoAccount> accounts)
  {
    if (accounts == null || accounts.Count <= 0)
      return;
    string s = Interaction.InputBox($"Nhập số nhóm ID ({frmMain.frmMainInstance.numGroupID.Minimum.ToString("0")} đến {frmMain.frmMainInstance.numGroupID.Maximum.ToString("0")})", "Set nhóm ID", "1");
    int result = 1;
    int.TryParse(s, out result);
    if ((Decimal) result < frmMain.frmMainInstance.numGroupID.Minimum)
      result = (int) frmMain.frmMainInstance.numGroupID.Minimum;
    try
    {
      foreach (AutoAccount account in accounts)
        account.Settings.numGroupID = result;
    }
    catch (Exception ex)
    {
    }
  }

  public static void TrieuTapCaNhom(AutoAccount account)
  {
    frmMain.frmMainInstance.NVTrieuTapNhomID(account);
  }

  public static void InviteParty(AutoAccount mainAccount)
  {
    if (frmLogin.GAuto.AllAutoAccounts.Count <= 1)
      return;
    int millisecondsTimeout = 4500;
    if (mainAccount.Target.VersionNum != 3)
    {
      if (mainAccount.Target.VersionNum != 4)
        goto label_4;
    }
    millisecondsTimeout = 300;
label_4:
    try
    {
      for (int index = frmLogin.GAuto.AllAutoAccounts.Count - 1; index >= 0; --index)
      {
        AutoAccount allAutoAccount = frmLogin.GAuto.AllAutoAccounts[index];
        if (allAutoAccount.Myself.Name != mainAccount.Myself.Name && allAutoAccount.Settings.numGroupID == mainAccount.Settings.numGroupID && allAutoAccount.MyParty.PartyNumbers <= 0)
        {
          mainAccount.CallInviteParty(allAutoAccount.Myself.Name);
          Thread.Sleep(millisecondsTimeout);
        }
      }
    }
    catch (Exception ex)
    {
    }
  }

  public static void UncheckAI(AutoAccount account)
  {
    if (!account.IsAIEnabled)
      return;
    account.IsAIEnabled = false;
    account.Myself.Status = AllEnums.CharStatuses.IDLE;
    account.Myself.UseAutoMove = false;
    account.Myself.MoveAcrossMap = false;
    account.Myself.MoveLongTrigger = false;
    account.Myself.IsLongMove = false;
    if (account.Settings.AIMode != AllEnums.AIModes.THUONGNHAN)
      return;
    account.Settings.AIMode = AllEnums.AIModes.DANHTUDO;
  }

  public static void CheckAI(AutoAccount account)
  {
    if (account.IsAIEnabled)
      return;
    account.IsAIEnabled = true;
    account.Myself.Status = AllEnums.CharStatuses.IDLE;
    account.Myself.SavedStatus = AllEnums.CharStatuses.IDLE;
    account.Myself.IsTrader = false;
    account.Settings.TraderMode = AllEnums.TraderModes.IDLE;
    account.Settings.TraderStatus = AllEnums.CharStatuses.IDLE;
    account.Myself.MinorStatus = AllEnums.CharStatuses.IDLE;
    account.Myself.MinorStatus2 = AllEnums.CharStatuses.IDLE;
    account.Myself.MoveFlashPos = false;
    account.Myself.UseAutoMove = false;
    account.Myself.MoveAcrossMap = false;
    account.Myself.MoveLongTrigger = false;
    account.Myself.IsLongMove = false;
    account.Myself.PossiblePaths = new List<AdvancedPath>();
    account.ScriptEngine.Script = (GScript) null;
    account.ScriptEngine.RunTimes = 0;
    account.ScriptEngine.IsOn = false;
    account.ScriptEngine.Index = 0;
    account.Myself.IsHaiDua = false;
    if (account.Settings.AIMode == AllEnums.AIModes.DANHQUANHDIEM || account.Settings.AIMode == AllEnums.AIModes.DANHTUDO)
    {
      account.Myself.trainExpSource = account.Myself.CurentExp;
      account.Myself.trainExpStamp = DateTime.Now;
    }
    account.Myself.veThanhFlagTimeStamp.Reset();
    account.Myself.veThanhFlagTimeStamp.Start();
    account.Myself.IsHaiDuaCarrying = false;
    account.Myself.thocbocCounter = 0;
    account.Myself.nhatbocCounter = 0;
    account.Myself.TargetX = 0.0f;
    account.Myself.TargetY = 0.0f;
    account.Myself.TargetMapID = -1;
    account.Myself.Status = AllEnums.CharStatuses.IDLE;
    account.Myself.IsPK = false;
    if (account.Myself.Level <= 20)
    {
      account.Settings.cboxTuNhatVatPham = false;
      account.Settings.cboxTuUpLevel = true;
      frmLogin.GAuto.Settings.cboxNoKS = true;
      account.Settings.cboxChoHoiSinh = true;
      account.Settings.numChoHoiSinh = 5;
    }
    if (account.Myself.Level <= 14)
      account.Settings.cboxNMBuff = false;
    if (account.Myself.Level > 30 || account.Target.VersionNum != 2)
      return;
    account.Settings.cboxCaptchaReset = false;
    account.Settings.cboxTNAlert = false;
    frmLogin.GAuto.Settings.cboxNoKS = true;
  }

  public static void SetLoginAction(List<AutoAccount> accounts, int mode)
  {
    if (accounts == null || accounts.Count <= 0)
      return;
    foreach (AutoAccount account in accounts)
    {
      if (account != null)
        account.MyFlag.LoginAction = mode;
    }
  }
}
