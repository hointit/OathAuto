// Decompiled with JetBrains decompiler
// Type: SmartBot.RingQuaiBuffer
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System;

#nullable disable
namespace SmartBot;

public class RingQuaiBuffer
{
  private int ClassSize = 1138;
  private TargetProcess localTarget;

  public RingQuaiBuffer(TargetProcess _tempTarget) => this.localTarget = _tempTarget;

  private bool EverythingOK() => true;

  public unsafe MessageFunc this[int index]
  {
    get
    {
      MessageFunc messageFunc = new MessageFunc();
      bool flag = true;
      if ((IntPtr) (void*) this.localTarget._RingQuaiRef != IntPtr.Zero && index < frmLogin.GAuto.Settings.RingQuaiSize)
      {
        int index1 = this.ClassSize * index;
        messageFunc.Message = GABitConverter.ToInt32(this.localTarget._RingQuaiRef, index1);
        messageFunc.int7 = GABitConverter.ToInt32(this.localTarget._RingQuaiRef, index1 + 44);
        if (this.localTarget.RefBot != null && this.localTarget.RefBot.MyQuai.AllQuai.Count > 0)
        {
          for (int index2 = this.localTarget.RefBot.MyQuai.AllQuai.Count - 1; index2 >= 0; --index2)
          {
            QuaiIndividual quaiIndividual = this.localTarget.RefBot.MyQuai.AllQuai[index2];
            if (quaiIndividual.ID == messageFunc.int7 && quaiIndividual.ID != -1 && quaiIndividual.Level > 0)
            {
              flag = false;
              break;
            }
          }
        }
        messageFunc.float1 = GABitConverter.ToFloat(this.localTarget._RingQuaiRef, index1 + 4);
        messageFunc.float2 = GABitConverter.ToFloat(this.localTarget._RingQuaiRef, index1 + 8);
        messageFunc.float3 = GABitConverter.ToFloat(this.localTarget._RingQuaiRef, index1 + 12);
        messageFunc.int3 = GABitConverter.ToInt32(this.localTarget._RingQuaiRef, index1 + 28);
        if (flag)
        {
          messageFunc.int5 = GABitConverter.ToInt32(this.localTarget._RingQuaiRef, index1 + 36);
          messageFunc.int6 = GABitConverter.ToInt32(this.localTarget._RingQuaiRef, index1 + 40);
          messageFunc.int8 = GABitConverter.ToInt32(this.localTarget._RingQuaiRef, index1 + 48 /*0x30*/);
          messageFunc.int10 = GABitConverter.ToInt32(this.localTarget._RingQuaiRef, index1 + 56);
          messageFunc.byte1 = this.localTarget._RingQuaiRef[index1 + 94];
        }
      }
      return messageFunc;
    }
  }
}
