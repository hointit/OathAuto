using OathAuto.AppState;
using OathAuto.Models;
using SmartBot;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Timers;
using Timer = System.Timers.Timer;

namespace OathAuto.ViewModels
{
  public partial class PlayerViewModel
  {
    public IntPtr MainWindowHandle = IntPtr.Zero;
    private Queue<int> queueSkill = new Queue<int>();
    private Timer _autoFarmTimer = new(500);

    private void OnAutoFarmTimerElapsed(object sender, ElapsedEventArgs e)
    {
      AutoFarm();
    }

    private void AutoFarm()
    {
      if (_player.MapID == Constant.DaiLyMapId) return;
      if (this.Player.Monsters != null && this.Player.Monsters.Count > 0)
      {
        try
        {
          var monster = this.Player.Monsters.OrderBy(m => m.Distance).FirstOrDefault();
          var index = this.Player.Monsters.IndexOf(monster);
          var skill = this.Player.Skills[0];
          TargetMonster(monster.ID);
          Thread.Sleep(10);

          var listCheckedSkill = this.Player.Skills.Skip(1).Where(s => s.IsSelected).Select(s => s.Id);
          var skillId = this.Player.AutoAccount.MySkills.SkillDelays
            .Where(sd => listCheckedSkill.Contains(sd.SkillID) && sd.SkillDelay == 0).Select(sd => sd.SkillID).FirstOrDefault();
          if (skillId != 0)
          {
            CallAttackTargetFast(monster.ID, skillId, (int)monster.PosX, (int)monster.PosY);
          }
          else
          {
            CallAttackTargetFast(monster.ID, this.Player.Skills[0].Id, (int)monster.PosX, (int)monster.PosY);
          }
          this.Player.Monsters.RemoveAt(index);
        }
        catch (Exception ex)
        {
          Debug.WriteLine($"List monster has been updated  -- {ex.Message}");
        }
      }
    }

    public void TargetMonster(int targetID)
    {
      MyDLL.PostMessage(this.Player.AutoAccount.Target.MainWindowHandle, frmLogin.GAuto.Settings.WM_SELECTTARGET, (IntPtr)0, (IntPtr)targetID);
    }

    public void CallAttackTargetFast(int targetID, int skillID, int posX, int posY)
    {
      MyDLL.PostMessage(this.Player.AutoAccount.Target.MainWindowHandle, frmLogin.GAuto.Settings.WM_ATTACKTARGET_1, (IntPtr)targetID, (IntPtr)skillID);
      MyDLL.PostMessage(this.Player.AutoAccount.Target.MainWindowHandle, frmLogin.GAuto.Settings.WM_ATTACKTARGET_2, (IntPtr)posX, (IntPtr)posY);
    }
    
    public void MoveToPosition(Position position)
    {
      MyDLL.PostMessage(this.Player.AutoAccount.Target.MainWindowHandle, frmLogin.GAuto.Settings.WM_CALLMOVETO, (IntPtr)position.X, (IntPtr)position.Y);
    }


    public void FeedActivePet(int index)
    {
      MyDLL.PostMessage(this.Player.AutoAccount.Target.MainWindowHandle, frmLogin.GAuto.Settings.WM_PETCARE, (IntPtr)index, (IntPtr)0);
    }

    private int GetBasicSkillId()
    {
      switch (_player.Menpai)
      {
        case AllEnums.Menpais.CAIBANG:
          return 341;
        case AllEnums.Menpais.DUONGMON:
          return 2900;
        case AllEnums.Menpais.THIEULAM:
          return 281;
        case AllEnums.Menpais.MINHGIAO:
          return 311;
        case AllEnums.Menpais.VODANG:
          return 371;
        case AllEnums.Menpais.NGAMI:
          return 401;
        case AllEnums.Menpais.TINHTUC:
          return 431;
        case AllEnums.Menpais.THIENLONG:
          return 461;
        case AllEnums.Menpais.THIENSON:
          return 491;
        case AllEnums.Menpais.TIEUDAO:
          return 521;
        case AllEnums.Menpais.MODUNG:
          return 760;
        case AllEnums.Menpais.QUYCOC:
          return 1850;
        default: return 0;
      }
    }
  }
}