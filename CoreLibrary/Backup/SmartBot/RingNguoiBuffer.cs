// Decompiled with JetBrains decompiler
// Type: SmartBot.RingNguoiBuffer
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System;

#nullable disable
namespace SmartBot;

public class RingNguoiBuffer
{
  private int ClassSize = 1138;
  private TargetProcess localTarget;

  public RingNguoiBuffer(TargetProcess _tempTarget) => this.localTarget = _tempTarget;

  private bool EverythingOK() => true;

  public unsafe MessageFunc this[int index]
  {
    get
    {
      MessageFunc messageFunc = new MessageFunc();
      bool flag = true;
      if ((IntPtr) (void*) this.localTarget._RingNguoiRef != IntPtr.Zero && index < frmLogin.GAuto.Settings.RingNguoiSize)
      {
        int index1 = this.ClassSize * index;
        messageFunc.Message = GABitConverter.ToInt32(this.localTarget._RingNguoiRef, index1);
        messageFunc.int6 = GABitConverter.ToInt32(this.localTarget._RingNguoiRef, index1 + 40);
        if (this.localTarget.RefBot != null && this.localTarget.RefBot.MyPlayers.AllPlayers.Count > 0)
        {
          for (int index2 = this.localTarget.RefBot.MyPlayers.AllPlayers.Count - 1; index2 >= 0; --index2)
          {
            PlayerIndividual allPlayer = this.localTarget.RefBot.MyPlayers.AllPlayers[index2];
            if (allPlayer.DatabaseID == messageFunc.int6 && allPlayer.DatabaseID > 0)
            {
              if (allPlayer.Level > 0 && allPlayer.Menpai >= 0 && allPlayer.Name != "")
              {
                flag = false;
                break;
              }
              break;
            }
          }
        }
        messageFunc.float1 = GABitConverter.ToFloat(this.localTarget._RingNguoiRef, index1 + 4);
        messageFunc.float2 = GABitConverter.ToFloat(this.localTarget._RingNguoiRef, index1 + 8);
        messageFunc.int4 = GABitConverter.ToInt32(this.localTarget._RingNguoiRef, index1 + 32 /*0x20*/);
        messageFunc.int1 = GABitConverter.ToInt32(this.localTarget._RingNguoiRef, index1 + 20);
        messageFunc.int2 = GABitConverter.ToInt32(this.localTarget._RingNguoiRef, index1 + 24);
        if (flag)
        {
          messageFunc.int3 = GABitConverter.ToInt32(this.localTarget._RingNguoiRef, index1 + 28);
          messageFunc.int8 = GABitConverter.ToInt32(this.localTarget._RingNguoiRef, index1 + 48 /*0x30*/);
          messageFunc.int9 = GABitConverter.ToInt32(this.localTarget._RingNguoiRef, index1 + 52);
          messageFunc.byte1 = this.localTarget._RingNguoiRef[index1 + 94];
        }
      }
      return messageFunc;
    }
  }
}
