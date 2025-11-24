using OathAuto.Models;
using OathAuto.Properties;
using SmartBot;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Security.Principal;
using System.Threading;

namespace OathAuto.Services
{
  public class SmartClassService
  {
    private SmartClass _smartClassInstance;
    private bool _isInitialized = false;

    public SmartClassService()
    {
      InitStateForCoreLibrary();
      Thread.Sleep(50);
      _smartClassInstance = frmLogin.GAuto;
      Thread.Sleep(50);
      _smartClassInstance.UIAvailable = true;
      _isInitialized = true;
      Thread.Sleep(50);
    }

    private void InitStateForCoreLibrary()
    {
      if (frmLogin.GlobalTimer != null)
      {
        if (!frmLogin.GlobalTimer.IsRunning)
        {
          frmLogin.GlobalTimer.Start();
        }
      }
      frmLogin.GCStamp = 0;
      frmLogin.BackgroundCheckTimestamp = 0;
      frmLogin.GAuto.Settings.AllowReadMem = true;
      frmLogin.GAuto.Settings.CharInfoBriefBases = new List<HashAddressPatch>();
      frmLogin.AutoInfoOK = true;

      // Importance: Must set MyBases after GAuto.Settings is initialized base address to read memory
      frmLogin.MyBases = CommonService.GetListBaseInfo();
      _smartClassInstance = frmLogin.GAuto;

      // Importance Enable UI interactions to start BGThread
      _smartClassInstance.UIAvailable = true;
      new Thread((ThreadStart)(() => frmMain.ReadDBInformation())).Start();
      _isInitialized = true;
    }

    

    public List<Player> GetAllAccountsData()
    {
      var result = new List<Player>();
      var accounts = GetAllAccounts();
      for (int i = 0; i < accounts.Count; i++)
      {
        var data = GetAccountData(i);
        if (data != null)
          result.Add(data);
      }
      return result;
    }


    public List<AutoAccount> GetAllAccounts()
    {
      if (!_isInitialized || _smartClassInstance == null)
        return new List<AutoAccount>();

      return _smartClassInstance.AllAutoAccounts;
    }
    public Player GetAccountData(int index)
    {
      var accounts = GetAllAccounts();
      if (index < 0 || index >= accounts.Count)
        return null;

      var account = accounts[index];
      if (account == null)
        return null;

      if (account.Myself.ID == 0)
      {
        return null;
      }

      try
      {
        var newPlayer = new Player
        {
          Id = account.Myself.ID,
          UserName = account.Myself?.Username ?? "Unknown",
          Name = account.Myself?.Name ?? "Unknown",
          Level = account.Myself?.Level ?? 0,
          HP = account.Myself?.HP ?? 0,
          MaxHP = account.Myself?.MaxHP ?? 0,
          HPPercent = account.Myself?.HPPercent ?? 0,
          MP = account.Myself?.MP ?? 0,
          MaxMP = account.Myself?.MaxMP ?? 0,
          MPPercent = account.Myself?.MPPercent ?? 0,
          Rage = account.Myself?.Rage ?? 0,
          MaxRage = account.Myself?.MaxRage ?? 0,
          MapName = account.Myself?.MapName ?? "Unknown",
          MapID = account.Myself?.MapID ?? 0,
          PosX = account.Myself?.PosX ?? 0,
          PosY = account.Myself?.PosY ?? 0,
          InCombat = account.Myself?.IsPK ?? false,
          ProcessID = account.Target?.ProcessID ?? 0,
          isTraining = account.Myself != null && !account.Myself.StopTrain,
          Monsters = account.MyQuai?.AllQuai,
          Menpai = (AllEnums.Menpais)(account.Myself?.Menpai),
          ExpPercent = account.Myself?.ExpPercent ?? 0,
          DatabaseId = account.Myself.DatabaseID,
          AutoAccount = account
        };

        account.Settings.cboxTuNhatVatPham = false;
        return newPlayer;
      }
      catch (Exception ex)
      {
        Debug.WriteLine($"Error getting account data at index {index}: {ex.Message}");
        return null;
      }
    }

    public void Shutdown()
    {
      try
      {
        if (_smartClassInstance != null)
        {
          if (_smartClassInstance.ReadInfoThread != null && _smartClassInstance.ReadInfoThread.IsAlive)
          {
            _smartClassInstance.UIAvailable = false;
          }
          _smartClassInstance = null;
        }
        _isInitialized = false;
      }
      catch (Exception ex)
      {
        Debug.WriteLine($"Error during shutdown: {ex.Message}");
      }
    }
  }
}
