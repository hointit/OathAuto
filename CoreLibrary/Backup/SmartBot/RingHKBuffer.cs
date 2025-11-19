// Decompiled with JetBrains decompiler
// Type: SmartBot.RingHKBuffer
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System;

#nullable disable
namespace SmartBot;

public class RingHKBuffer
{
  private int ClassSize = 1138;
  private TargetProcess localTarget;

  public RingHKBuffer(TargetProcess _tempTarget) => this.localTarget = _tempTarget;

  private unsafe bool EverythingOK() => (IntPtr) (void*) this.localTarget._RingHKRef != IntPtr.Zero;

  public unsafe MessageFunc this[int index]
  {
    get
    {
      MessageFunc messageFunc = new MessageFunc();
      if (this.EverythingOK() && index < frmLogin.GAuto.Settings.RingHKSize)
      {
        int index1 = this.ClassSize * index;
        messageFunc.Message = GABitConverter.ToInt32(this.localTarget._RingHKRef, index1);
        messageFunc.float1 = GABitConverter.ToFloat(this.localTarget._RingHKRef, index1 + 4);
        messageFunc.float2 = GABitConverter.ToFloat(this.localTarget._RingHKRef, index1 + 8);
        messageFunc.float3 = GABitConverter.ToFloat(this.localTarget._RingHKRef, index1 + 12);
        messageFunc.float4 = GABitConverter.ToFloat(this.localTarget._RingHKRef, index1 + 16 /*0x10*/);
        messageFunc.int1 = GABitConverter.ToInt32(this.localTarget._RingHKRef, index1 + 20);
        messageFunc.int2 = GABitConverter.ToInt32(this.localTarget._RingHKRef, index1 + 24);
        messageFunc.int3 = GABitConverter.ToInt32(this.localTarget._RingHKRef, index1 + 28);
        messageFunc.int4 = GABitConverter.ToInt32(this.localTarget._RingHKRef, index1 + 32 /*0x20*/);
        messageFunc.int5 = GABitConverter.ToInt32(this.localTarget._RingHKRef, index1 + 36);
        messageFunc.int6 = GABitConverter.ToInt32(this.localTarget._RingHKRef, index1 + 40);
        messageFunc.int7 = GABitConverter.ToInt32(this.localTarget._RingHKRef, index1 + 44);
        messageFunc.int8 = GABitConverter.ToInt32(this.localTarget._RingHKRef, index1 + 48 /*0x30*/);
        messageFunc.int9 = GABitConverter.ToInt32(this.localTarget._RingHKRef, index1 + 52);
        messageFunc.int10 = GABitConverter.ToInt32(this.localTarget._RingHKRef, index1 + 56);
        messageFunc.double1 = GABitConverter.ToDouble(this.localTarget._RingHKRef, index1 + 60);
        messageFunc.double2 = GABitConverter.ToDouble(this.localTarget._RingHKRef, index1 + 68);
        messageFunc.double3 = GABitConverter.ToDouble(this.localTarget._RingHKRef, index1 + 76);
        messageFunc.double4 = GABitConverter.ToDouble(this.localTarget._RingHKRef, index1 + 84);
        messageFunc.bool1 = this.localTarget._RingHKRef[index1 + 92] == (byte) 1;
        messageFunc.bool2 = this.localTarget._RingHKRef[index1 + 93] == (byte) 1;
        messageFunc.byte1 = this.localTarget._RingHKRef[index1 + 94];
        messageFunc.byte2 = this.localTarget._RingHKRef[index1 + 95];
        messageFunc.byte3 = this.localTarget._RingHKRef[index1 + 96 /*0x60*/];
        messageFunc.byte4 = this.localTarget._RingHKRef[index1 + 97];
        messageFunc.int64_1 = GABitConverter.ToInt64(this.localTarget._RingHKRef, index1 + 1122);
        messageFunc.timestamp = GABitConverter.ToInt64(this.localTarget._RingHKRef, index1 + 1130);
      }
      return messageFunc;
    }
  }
}
