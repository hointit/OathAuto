// Decompiled with JetBrains decompiler
// Type: SmartBot.BocClass
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System.Collections.Generic;
using System.Diagnostics;

#nullable disable
namespace SmartBot;

public class BocClass
{
  private int ClassSize = 28;
  private TargetProcess localTarget;
  public List<NewBoc> PickedBocList = new List<NewBoc>();
  public List<NewBoc> RemovedBocList = new List<NewBoc>();
  public int CurrentPickedIndex;
  public List<int> PickedBocID = new List<int>()
  {
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0
  };
  public int TotalItems;
  public long LastTimeSeen;
  public bool AlreadyPicked_a;
  public Stopwatch nhatBocTimeStamp = new Stopwatch();
  public long LastActiveBocStamp;
  public List<ItemTrongBoc> AllItems = new List<ItemTrongBoc>();
  public int ActiveBocID;
  public float PosX;
  public float PosY;
  public List<NewBoc> AllBocs;

  public void Initialize(TargetProcess _tempTarget) => this.localTarget = _tempTarget;

  public BocClass()
  {
    this.AllBocs = new List<NewBoc>();
    for (int index = 0; index < 50; ++index)
      this.PickedBocList.Add(new NewBoc());
    this.nhatBocTimeStamp.Start();
  }

  private bool EverythingOK() => true;
}
