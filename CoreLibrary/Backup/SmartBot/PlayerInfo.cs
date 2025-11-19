// Decompiled with JetBrains decompiler
// Type: SmartBot.PlayerInfo
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System;
using System.Collections.Generic;

#nullable disable
namespace SmartBot;

public class PlayerInfo
{
  private int ClassSize = 82;
  private TargetProcess localTarget;
  public List<PlayerIndividual> AllPlayers = new List<PlayerIndividual>();

  public void Initialize(TargetProcess _tempTarget) => this.localTarget = _tempTarget;

  private bool EverythingOK() => true;

  internal QuaiIndividual GetPlayerByIDAsQuai(int id, bool checkHP = false)
  {
    if (this.AllPlayers.Count > 0)
    {
      try
      {
        for (int index = this.AllPlayers.Count - 1; index >= 0; --index)
        {
          PlayerIndividual allPlayer = this.AllPlayers[index];
          if (allPlayer.ID == id)
            return checkHP && (double) allPlayer.HPPercent <= 0.0 ? (QuaiIndividual) null : new QuaiIndividual()
            {
              ID = allPlayer.ID,
              HPPercent = allPlayer.HPPercent,
              PosX = allPlayer.PosX,
              PosY = allPlayer.PosY,
              MapID = allPlayer.MapID
            };
        }
      }
      catch (Exception ex)
      {
      }
    }
    return (QuaiIndividual) null;
  }
}
