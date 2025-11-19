// Decompiled with JetBrains decompiler
// Type: SmartBot.LicenseManager
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;

#nullable disable
namespace SmartBot;

public class LicenseManager : INotifyPropertyChanged
{
  public List<TinhNang> ListTinhNang = new List<TinhNang>();
  private long LastLicenseStamp;

  public event PropertyChangedEventHandler PropertyChanged;

  private void NotifyPropertyChanged(string info)
  {
    if (this.PropertyChanged == null)
      return;
    try
    {
      if (frmMain.frmMainInstance.tabDieuKhien.InvokeRequired)
        frmMain.frmMainInstance.tabDieuKhien.Invoke((Delegate) (() => this.PropertyChanged((object) this, new PropertyChangedEventArgs(info))));
      else
        this.PropertyChanged((object) this, new PropertyChangedEventArgs(info));
    }
    catch (Exception ex)
    {
    }
  }

  public int CountSlots(string tnkey)
  {
    int num = 0;
    if (this.ListTinhNang.Count > 0)
    {
      for (int index = this.ListTinhNang.Count - 1; index >= 0; --index)
      {
        if (this.ListTinhNang[index].TNKey == tnkey && this.ListTinhNang[index].RemainMS > 0L)
          ++num;
      }
    }
    return num;
  }

  public int CountUnit(string tnkey)
  {
    int num = 0;
    if (this.ListTinhNang.Count > 0)
    {
      for (int index = this.ListTinhNang.Count - 1; index >= 0; --index)
      {
        if (this.ListTinhNang[index].TNKey == tnkey && this.ListTinhNang[index].RemainMS > 0L)
          num += this.ListTinhNang[index].SlotCount;
      }
    }
    return num;
  }

  public void GetLicenseCount(string tnkey, ref int tnslots, ref string remainHour)
  {
    try
    {
      if (frmLogin.GAuto.Settings.Account.MyLicense.ListTinhNang.Count <= 0)
        return;
      for (int index = 0; index < frmLogin.GAuto.Settings.Account.MyLicense.ListTinhNang.Count; ++index)
      {
        if (frmLogin.GAuto.Settings.Account.MyLicense.ListTinhNang[index].TNKey == tnkey)
        {
          TimeSpan timeSpan = TimeSpan.FromSeconds((double) frmLogin.GAuto.Settings.Account.MyLicense.ListTinhNang[index].RemainMS);
          remainHour = timeSpan.Days <= 0 ? $"{timeSpan.Hours.ToString("00")}:{timeSpan.Minutes.ToString("00")}" : $"{timeSpan.Days.ToString()}d {timeSpan.Hours.ToString("00")}:{timeSpan.Minutes.ToString("00")}";
          ++tnslots;
        }
      }
    }
    catch (Exception ex)
    {
    }
  }

  public bool IsLicensePro() => frmLogin.GAuto.Settings.Account.RemainMSeconds > 0.0;

  public void UpdateLicense()
  {
    long num = frmLogin.GlobalTimer.ElapsedMilliseconds - this.LastLicenseStamp;
    if (this.ListTinhNang.Count > 0)
    {
      if (Monitor.TryEnter(frmLogin.licenseLock, 5000))
      {
        try
        {
          for (int index = this.ListTinhNang.Count - 1; index >= 0; --index)
          {
            if (this.ListTinhNang[index].RemainMS * 1000L > num)
            {
              this.ListTinhNang[index].RemainMS = (this.ListTinhNang[index].RemainMS * 1000L - num) / 1000L;
              if (this.ListTinhNang[index].stampExpired > 0L)
                this.ListTinhNang[index].stampExpired = 0L;
            }
            else
            {
              if (this.ListTinhNang[index].RemainMS > 0L)
                this.ListTinhNang[index].RemainMS = 0L;
              if (this.ListTinhNang[index].stampExpired == 0L)
                this.ListTinhNang[index].stampExpired = frmLogin.GlobalTimer.ElapsedMilliseconds + 10000L;
              else if (frmLogin.GlobalTimer.ElapsedMilliseconds >= this.ListTinhNang[index].stampExpired)
                this.ListTinhNang.RemoveAt(index);
            }
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
    }
    this.LastLicenseStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
  }

  internal void CheckLicense()
  {
    while (true)
    {
      while (frmLogin.GAuto.UIAvailable && frmLogin.GlobalTimer.ElapsedMilliseconds >= frmLogin.licenseStamp)
      {
        frmLogin.licenseStamp = frmLogin.GlobalTimer.ElapsedMilliseconds + 45000L;
        int curCount1 = 0;
        int curCount2 = 0;
        int curCount3 = 0;
        int curCount4 = 0;
        try
        {
          for (int index = frmLogin.GAuto.AllAutoAccounts.Count - 1; index >= 0; --index)
          {
            if (frmLogin.GAuto.AllAutoAccounts[index].Myself.IsCheDo)
              ++curCount1;
            if (frmLogin.GAuto.AllAutoAccounts[index].Myself.IsQ1 || frmLogin.GAuto.AllAutoAccounts[index].Myself.IsQ2)
              ++curCount2;
            if (frmLogin.GAuto.AllAutoAccounts[index].Myself.isYTO)
              ++curCount3;
            if (frmLogin.GAuto.AllAutoAccounts[index].Settings.AIMode == AllEnums.AIModes.THUONGNHAN)
              ++curCount4;
          }
        }
        catch (Exception ex)
        {
        }
        bool log = false;
        string tnkey = "tnyto";
        bool boughtTime = false;
        if (curCount3 > 0)
        {
          this.ProcessLicExp(tnkey, curCount3, ref log, ref boughtTime);
          if (log)
            GA.WriteUserLog(frmMain.langYTOTimeout);
          if (boughtTime)
            continue;
        }
        if (curCount2 > 0)
        {
          this.ProcessLicExp("tnq12", curCount2, ref log, ref boughtTime);
          if (log)
            GA.WriteUserLog(frmMain.langTimeoutQ12);
          if (boughtTime)
            continue;
        }
        if (curCount1 > 0)
        {
          this.ProcessLicExp("tnchedo", curCount1, ref log, ref boughtTime);
          if (boughtTime)
            continue;
        }
        if (curCount4 > 0)
        {
          this.ProcessLicExp("tntrader", curCount4, ref log, ref boughtTime);
          if (boughtTime)
            continue;
        }
        if (frmLogin.GAuto.Settings.WasPro && frmLogin.GAuto.Settings.Account.RemainMSeconds <= 300000.0 && frmLogin.GAuto.Settings.Account.EmptySecondHits == 0)
        {
          List<PriceItem> _priceList = new List<PriceItem>();
          _priceList.Add(new PriceItem());
          if (frmLiteBuy.CalcBuyPrice(_priceList) <= frmLogin.GAuto.Settings.Account.TotalBalance)
          {
            frmLogin.frmBuyLicense.BuyTinhNang("time", _priceList[0], useForm: false);
            if (frmLogin.GAuto.Settings.Account.RemainMSeconds > 300000.0)
            {
              ++frmLogin.GAuto.Settings.Account.EmptySecondHits;
              GA.WriteUserLog("Tự gia hạn thêm 24 giờ chơi để tránh bị gián đoạn auto.");
              break;
            }
            break;
          }
          break;
        }
        break;
      }
      Thread.Sleep(30000);
    }
  }

  private void ProcessLicExp(string tnkey, int curCount, ref bool log, ref bool boughtTime)
  {
    int num1 = this.CountUnit(tnkey);
    if (tnkey == "tntrader" && num1 == 0)
      num1 = frmLogin.GAuto.Settings.TNFreeAcc;
    int tempDiff = curCount - num1;
    int tempOff = 0;
    bool flag1 = false;
    PriceItem price = (PriceItem) null;
    log = false;
    bool flag2 = false;
    if (tnkey == "tnyto" && frmLogin.GAuto.Settings.cboxYTOGiaHan)
      flag2 = true;
    else if (tnkey == "tnq12" && frmLogin.GAuto.Settings.cboxQ12AutoExtend)
    {
      flag2 = true;
    }
    else
    {
      switch (tnkey)
      {
        case "tnchedo":
          flag2 = true;
          flag1 = true;
          break;
        case "tntrader":
          flag2 = false;
          break;
      }
    }
    bool flag3 = false;
    if (frmLogin.GAuto.Settings.WasPro && frmLogin.GAuto.Settings.Account.EmptySecondHits == 0)
      flag3 = true;
    if (!flag3 && flag1)
      flag3 = true;
    if (num1 == 0 && flag2 && flag3)
    {
      if (tnkey == "tnchedo")
      {
        if (frmLogin.GAuto.Settings.cboxCDExtend && frmLogin.GAuto.Settings.cboCDExtend != "")
          price = LicenseManager.GetPriceByShortName(tnkey, frmLogin.GAuto.Settings.cboCDExtend);
      }
      else
        price = LicenseManager.GetLastPrice(tnkey);
      if (price != null && price.Price <= frmLogin.GAuto.Settings.Account.TotalBalance)
      {
        frmLogin.frmBuyLicense.BuyTinhNang(tnkey, price, useForm: false);
        int num2 = this.CountUnit(tnkey);
        tempDiff = curCount - num2;
        boughtTime = true;
      }
    }
    if (frmLogin.GAuto.Settings.AppMode == AllEnums.AutoModes.Lite && !flag1)
      tempDiff = 999;
    LicenseManager.TurnOffTN(tnkey, tempDiff, ref tempOff, ref log);
  }

  public static PriceItem GetPriceByShortName(string tnkey, string shortname)
  {
    if (frmLogin.GAuto.Settings.Account.BangGia.Count > 0)
    {
      for (int index = 0; index < frmLogin.GAuto.Settings.Account.BangGia.Count; ++index)
      {
        if (frmLogin.GAuto.Settings.Account.BangGia[index].Key == tnkey && frmLogin.GAuto.Settings.Account.BangGia[index].ShortDisplay == shortname)
          return frmLogin.GAuto.Settings.Account.BangGia[index];
      }
    }
    return (PriceItem) null;
  }

  public static PriceItem GetLastPrice(string tnkey)
  {
    PriceItem lastPrice = (PriceItem) null;
    if (frmLogin.frmBuyLicense.lastPrices.Count > 0)
    {
      try
      {
        for (int index = 0; index < frmLogin.frmBuyLicense.lastPrices.Count; ++index)
        {
          if (frmLogin.frmBuyLicense.lastPrices[index].Key == tnkey)
          {
            lastPrice = frmLogin.frmBuyLicense.lastPrices[index];
            break;
          }
        }
      }
      catch (Exception ex)
      {
      }
    }
    if (lastPrice == null && frmLogin.GAuto.Settings.Account.BangGia.Count > 0)
    {
      double num = 9999.0;
      for (int index = 0; index < frmLogin.GAuto.Settings.Account.BangGia.Count; ++index)
      {
        if (frmLogin.GAuto.Settings.Account.BangGia[index].Key == tnkey && frmLogin.GAuto.Settings.Account.BangGia[index].Price < num)
        {
          lastPrice = frmLogin.GAuto.Settings.Account.BangGia[index];
          num = frmLogin.GAuto.Settings.Account.BangGia[index].Price;
        }
      }
    }
    return lastPrice;
  }

  private static void TurnOffTN(string tnkey, int tempDiff, ref int tempOff, ref bool log)
  {
    try
    {
      if (tempDiff <= 0)
        return;
      for (int index = frmLogin.GAuto.AllAutoAccounts.Count - 1; index >= 0; --index)
      {
        bool flag = false;
        if (tnkey == "tnyto" && frmLogin.GAuto.AllAutoAccounts[index].Myself.isYTO)
          flag = true;
        else if (tnkey == "tnq12" && (frmLogin.GAuto.AllAutoAccounts[index].Myself.IsQ1 || frmLogin.GAuto.AllAutoAccounts[index].Myself.IsQ2))
          flag = true;
        else if (tnkey == "tntrader" && frmLogin.GAuto.AllAutoAccounts[index].Settings.AIMode == AllEnums.AIModes.THUONGNHAN)
          flag = true;
        else if (tnkey == "tnchedo" && frmLogin.GAuto.AllAutoAccounts[index].Myself.IsCheDo)
          flag = true;
        if (flag)
        {
          switch (tnkey)
          {
            case "tnyto":
              frmLogin.GAuto.AllAutoAccounts[index].Myself.isYTO = false;
              break;
            case "tnq12":
              frmLogin.GAuto.AllAutoAccounts[index].Myself.IsQ1 = false;
              frmLogin.GAuto.AllAutoAccounts[index].Myself.IsQ2 = false;
              break;
            case "tnchedo":
              frmLogin.GAuto.AllAutoAccounts[index].Myself.IsCheDo = false;
              break;
            case "tntrader":
              frmLogin.GAuto.AllAutoAccounts[index].Settings.AIMode = AllEnums.AIModes.DANHQUANHDIEM;
              break;
          }
          if (!frmLogin.GAuto.AllAutoAccounts[index].MyFlag.waitMsgBox)
            log = true;
          ++tempOff;
          if (tempOff >= tempDiff)
            break;
        }
      }
    }
    catch (Exception ex)
    {
    }
  }
}
