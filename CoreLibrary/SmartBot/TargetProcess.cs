// Decompiled with JetBrains decompiler
// Type: SmartBot.TargetProcess
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

#nullable disable
namespace SmartBot;

public class TargetProcess : AllEnums
{
  public AutoAccount RefBot;
  public int ThreadDelay = 300;
  public HookProc hHook;
  public HookProc hHookGLogin;
  public bool BlockChatListSent;
  public string ClientPatternKey = "";
  public GGameMemory ClientPattern;
  public List<ReadMemEntry> ReadmemContainer = new List<ReadMemEntry>();
  public int ProcessID;
  public int VersionNum = 1;
  public List<MEMORY_BASIC_INFORMATION> MemReg = new List<MEMORY_BASIC_INFORMATION>();
  public DateTime ProcessStartTime = DateTime.MaxValue;
  public string UniqueDllName = "";
  public IntPtr SetHookAddr = IntPtr.Zero;
  public IntPtr UniqueDllHandle = IntPtr.Zero;
  public IntPtr RemoveHookAddr = IntPtr.Zero;
  public IntPtr ProcessHandle;
  public byte[] tempBuffer = new byte[30];
  public int ExeBase = 4194304 /*0x400000*/;
  public IntPtr MessageSignalAlloc = IntPtr.Zero;
  public IntPtr ControlSignalAlloc = IntPtr.Zero;
  public IntPtr InvitePartyAlloc = IntPtr.Zero;
  public IntPtr ChatAlloc = IntPtr.Zero;
  public IntPtr BlockChatAlloc = IntPtr.Zero;
  public IntPtr TinhKiemAlloc = IntPtr.Zero;
  public IntPtr MainWindowHandle = IntPtr.Zero;
  public int MainWindowTimeStamp;
  public string MainWindowClassName = "TianLongBaBu WndClass";
  public string TemporaryClassName = "TTL";
  public uint MainThreadID;
  public bool IsHooked;
  public bool IsInjected;
  public string ProcessFileName = "";
  public string ProcessExePath = "";
  public string TargetHash = "";
  public IntPtr controllerMutex = IntPtr.Zero;
  public string VersionOfTarget = "";
  public bool IsReady;
  public string PipeName = "";
  public UIntPtr PipeSize = (UIntPtr) 2048U /*0x0800*/;
  public IntPtr pView = IntPtr.Zero;
  public IntPtr hMapFile = IntPtr.Zero;
  public string TempPipeName = "tinydllname";
  public IntPtr TemphMapFile = IntPtr.Zero;
  public IntPtr TemppView = IntPtr.Zero;
  public UIntPtr TempPipeSize = (UIntPtr) 512U /*0x0200*/;
  public string PlayerPipeName = "";
  public IntPtr PlayerpView = IntPtr.Zero;
  public IntPtr PlayerhMapFile = IntPtr.Zero;
  public UIntPtr PlayerPipeSize = (UIntPtr) 2048U /*0x0800*/;
  public string MiscPipeName = "";
  public IntPtr MiscpView = IntPtr.Zero;
  public IntPtr MischMapFile = IntPtr.Zero;
  public UIntPtr MiscPipeSize = (UIntPtr) 2048U /*0x0800*/;
  public UIntPtr NPCPipeSize = (UIntPtr) 50000U;
  public string NPCPipeName = "";
  public IntPtr NPCpView = IntPtr.Zero;
  public IntPtr NPChMapFile = IntPtr.Zero;
  public UIntPtr BocPipeSize = (UIntPtr) 5048U;
  public string BocPipeName = "";
  public IntPtr BocpView = IntPtr.Zero;
  public IntPtr BochMapFile = IntPtr.Zero;
  public UIntPtr InventoryPipeSize = (UIntPtr) 4096U /*0x1000*/;
  public string InventoryPipeName = "";
  public IntPtr InventorypView = IntPtr.Zero;
  public IntPtr InventoryhMapFile = IntPtr.Zero;
  public UIntPtr PartyPipeSize = (UIntPtr) 4096U /*0x1000*/;
  public string PartyPipeName = "";
  public IntPtr PartypView = IntPtr.Zero;
  public IntPtr PartyhMapFile = IntPtr.Zero;
  public UIntPtr SkillsPipeSize = (UIntPtr) 1024U /*0x0400*/;
  public string SkillsPipeName = "";
  public IntPtr SkillspView = IntPtr.Zero;
  public IntPtr SkillshMapFile = IntPtr.Zero;
  public string RingPacketName = "";
  public UIntPtr RingPacketSize = (UIntPtr) 500000U;
  public IntPtr RingPacketpView = IntPtr.Zero;
  public IntPtr RingPackethMapFile = IntPtr.Zero;
  public string RingQuaiPipeName = "";
  public UIntPtr RingQuaiPipeSize = (UIntPtr) 1024000U /*0x0FA000*/;
  public IntPtr RingQuaipView = IntPtr.Zero;
  public IntPtr RingQuaihMapFile = IntPtr.Zero;
  public string RingNguoiPipeName = "";
  public UIntPtr RingNguoiPipeSize = (UIntPtr) 1024000U /*0x0FA000*/;
  public IntPtr RingNguoipView = IntPtr.Zero;
  public IntPtr RingNguoihMapFile = IntPtr.Zero;
  public string RingBocPipeName = "";
  public UIntPtr RingBocPipeSize = (UIntPtr) 64000U;
  public IntPtr RingBocpView = IntPtr.Zero;
  public IntPtr RingBochMapFile = IntPtr.Zero;
  public string RingMsgPipeName = "";
  public UIntPtr RingMsgPipeSize = (UIntPtr) 64000U;
  public IntPtr RingMsgpView = IntPtr.Zero;
  public IntPtr RingMsghMapFile = IntPtr.Zero;
  public string RingHKPipeName = "";
  public UIntPtr RingHKPipeSize = (UIntPtr) 32000U;
  public IntPtr RingHKpView = IntPtr.Zero;
  public IntPtr RingHKhMapFile = IntPtr.Zero;
  public unsafe byte* _InventoryRef;
  public unsafe byte* _MiscRef;
  public unsafe byte* _PlayerRef;
  public unsafe byte* _NPCRef;
  public unsafe byte* _BocRef;
  public unsafe byte* _ControllerRef;
  public unsafe byte* _PartyRef;
  public unsafe byte* _SkillsRef;
  public unsafe byte* _RingRef;
  public unsafe byte* _RingQuaiRef;
  public unsafe byte* _RingNguoiRef;
  public unsafe byte* _RingBocRef;
  public unsafe byte* _RingMsgRef;
  public unsafe byte* _RingHKRef;
  public byte[] tempNewPacket = new byte[4000];
  public char[] menuUniqueID = new char[90];
  public AllEnums.InjectionStatus Status;
  public MyDLL.SetHookFunc SetHookFunction;
  public MyDLL.RemoveHookFunc RemoveHookFunction;
  public bool TempUnHooked;
  public bool AllowReadMem;
  public int FullInfoStamp;
  public bool bufferEmpty;
  public int funcBufferLength = 30;
  public long funcWriteIndex;
  public long funcReadIndex;
  public MessageFunc[] Ring3 = new MessageFunc[30];
  public MessageFunc[] RingHK = new MessageFunc[20];
  public byte[] bocTempItemData = new byte[800];
  public int DLLChecking;
  public bool DLLRead;
  public uint DLLPatchedValue;
  public bool DLLExit;
  public bool HasException;
  public int MySeq;
  public long BGThreadStamp;
  public long BGRandom;
  public long sequenceStamp;
  public bool ThreadDied;
  public long ThreadDiedStamp;
  public long SavedBGRandomStamp;
  public long SavedBGRandom;
  public bool BGThreadDied;
  private byte[] AutoRefArray = new byte[4];
  public int _SelfAutoRef;
  public bool SkillError;
  public int SubVersion;
  public bool NeedToAbort;
  public bool NeedToAbort2;
  public bool NeedToAbort3;
  public int NeedToAbort4;
  public IntPtr HookResult = IntPtr.Zero;
  public IntPtr HookGLoginResult = IntPtr.Zero;
  public bool BGRunner = true;
  public long FirstSeenStamp;
  private bool CreatedPipes;
  public bool AICreated;
  public HashAddressPatch MyBase;
  public long PacketStamp;
  public long DLLCounter;
  public long CyberStamp;
  public bool CyberBlacklisted;
  public bool IsCyberRestored;
  public long CyberPseudoStamp;
  public long CyberRandom;
  public int CyberPseudoSent;
  public bool TempRemoved;
  public bool IsReset;
  public int ServerIndex = -1;
  public bool GLoginAIReady;
  public bool HasActiveProfile;
  public string FileVersion = "";
  public bool GLoginAttached;
  public byte GLoginHideGame;

  public TargetProcess(AutoAccount _refBot) => this.RefBot = _refBot;

  public unsafe int SelfAutoRef
  {
    get => this._SelfAutoRef;
    set
    {
      this._SelfAutoRef = value;
      GA.random.NextBytes(this.AutoRefArray);
      this._PlayerRef[931] = this.AutoRefArray[0];
      this._PlayerRef[932] = this.AutoRefArray[1];
      this._PlayerRef[933] = this.AutoRefArray[2];
      this._PlayerRef[934] = this.AutoRefArray[3];
    }
  }

  public void MemInfo(IntPtr pHandle)
  {
    IntPtr lpAddress = new IntPtr();
    int num = 0;
    bool flag = false;
    do
    {
      MyDLL.MEMORY_BASIC_INFORMATION lpBuffer = new MyDLL.MEMORY_BASIC_INFORMATION();
      if (MyDLL.VirtualQueryEx(pHandle, lpAddress, out lpBuffer, Marshal.SizeOf((object) lpBuffer)) == 0)
        break;
      if (((int) lpBuffer.State & 4096 /*0x1000*/) != 0 && ((int) lpBuffer.Protect & 256 /*0x0100*/) == 0)
        this.MemReg.Add(new MEMORY_BASIC_INFORMATION()
        {
          AllocationBase = lpBuffer.AllocationBase,
          AllocationProtect = lpBuffer.AllocationProtect,
          BaseAddress = lpBuffer.BaseAddress,
          Protect = lpBuffer.Protect,
          RegionSize = lpBuffer.RegionSize,
          State = lpBuffer.State,
          Type = lpBuffer.Type
        });
      ++num;
      try
      {
        lpAddress = new IntPtr((long) lpBuffer.BaseAddress.ToInt32() + (long) lpBuffer.RegionSize);
      }
      catch (Exception ex)
      {
        flag = true;
      }
    }
    while ((int) lpAddress < 2147418112 && !flag);
  }

  public static IntPtr _Scan(byte[] memRegion, byte[] pattern, int index = 1)
  {
    try
    {
      int[] numArray = new int[256 /*0x0100*/];
      int num1 = 0;
      int num2 = pattern.Length - 1;
      for (int index1 = 0; index1 < 256 /*0x0100*/; ++index1)
        numArray[index1] = pattern.Length;
      for (int index2 = 0; index2 < num2; ++index2)
        numArray[(int) pattern[index2]] = num2 - index2;
      int num3 = 0;
      for (; num1 <= memRegion.Length - pattern.Length; num1 += numArray[(int) memRegion[num1 + num2]])
      {
        for (int index3 = num2; (int) memRegion[num1 + index3] == (int) pattern[index3]; --index3)
        {
          if (index3 == 0)
          {
            ++num3;
            if (num3 == index)
              return new IntPtr(num1);
            break;
          }
        }
      }
    }
    catch (Exception ex)
    {
    }
    return IntPtr.Zero;
  }

  public static int AobScan(
    AutoAccount account,
    byte[] Pattern,
    int index = 1,
    bool readmem = false,
    int offset = 0,
    int addsub = 0)
  {
    if (account.Target.ProcessHandle == IntPtr.Zero)
      return 0;
    if (account.Target.MemReg.Count == 0)
      account.Target.MemInfo(account.Target.ProcessHandle);
    int lpNumberOfBytesRead = 0;
    IntPtr zero = IntPtr.Zero;
    for (int index1 = 0; index1 < account.Target.MemReg.Count; ++index1)
    {
      try
      {
        byte[] numArray = new byte[account.Target.MemReg[index1].RegionSize];
        MyDLL.ReadProcessMemory((int) account.Target.ProcessHandle, account.Target.MemReg[index1].BaseAddress, numArray, account.Target.MemReg[index1].RegionSize, ref lpNumberOfBytesRead);
        IntPtr num1 = TargetProcess._Scan(numArray, Pattern, index);
        if (num1 != IntPtr.Zero)
        {
          int num2 = account.Target.MemReg[index1].BaseAddress.ToInt32() + num1.ToInt32();
          int num3 = num2;
          if (readmem)
          {
            int lpBaseAddress = num2 + offset;
            byte[] lpBuffer = new byte[4];
            MyDLL.ReadProcessMemory((int) account.Target.ProcessHandle, (IntPtr) lpBaseAddress, lpBuffer, 4U, ref lpNumberOfBytesRead);
            num3 = BitConverter.ToInt32(lpBuffer, 0);
          }
          if (num3 != 0)
            num3 += addsub;
          return num3;
        }
      }
      catch (Exception ex)
      {
      }
    }
    return 0;
  }

  public static string ReadNamePipe(
    string szName,
    ref IntPtr pView,
    ref IntPtr hMapFile,
    UIntPtr size)
  {
    hMapFile = MyDLL.OpenFileMapping(983071U, false, szName);
    uint lastError = MyDLL.GetLastError();
    switch (lastError)
    {
      case 0:
        if (hMapFile == MyDLL.INTPTR_ZERO)
        {
          GA.Message("Cannot read the mapped object - null returned");
          return "";
        }
        pView = MyDLL.MapViewOfFile(hMapFile, 983071U, 0U, 0U, size);
        if (pView == IntPtr.Zero)
        {
          GA.Message("Cannot create the file view");
          return "";
        }
        return pView != IntPtr.Zero ? Marshal.PtrToStringAuto(pView) : "";
      case 2:
        throw new FileNotFoundException(szName);
      default:
        GA.LogToFile("Unprocessed error ID: ", (object) lastError.ToString());
        goto case 0;
    }
  }

  public bool InitiateCommunicationChannel()
  {
    if (!this.CreatedPipes)
    {
      this.PlayerPipeName = GA.GenerateRandomName();
      GA.CreateNewFileMapping(ref this.PlayerhMapFile, ref this.PlayerpView, this.PlayerPipeName, this.PlayerPipeSize);
      this.RingPacketName = GA.GenerateRandomName();
      GA.CreateNewFileMapping(ref this.RingPackethMapFile, ref this.RingPacketpView, this.RingPacketName, this.RingPacketSize);
      this.RingQuaiPipeName = GA.GenerateRandomName();
      GA.CreateNewFileMapping(ref this.RingQuaihMapFile, ref this.RingQuaipView, this.RingQuaiPipeName, this.RingQuaiPipeSize);
      this.RingNguoiPipeName = GA.GenerateRandomName();
      GA.CreateNewFileMapping(ref this.RingNguoihMapFile, ref this.RingNguoipView, this.RingNguoiPipeName, this.RingNguoiPipeSize);
      this.RingBocPipeName = GA.GenerateRandomName();
      GA.CreateNewFileMapping(ref this.RingBochMapFile, ref this.RingBocpView, this.RingBocPipeName, this.RingBocPipeSize);
      this.RingMsgPipeName = GA.GenerateRandomName();
      GA.CreateNewFileMapping(ref this.RingMsghMapFile, ref this.RingMsgpView, this.RingMsgPipeName, this.RingMsgPipeSize);
      this.RingHKPipeName = GA.GenerateRandomName();
      GA.CreateNewFileMapping(ref this.RingHKhMapFile, ref this.RingHKpView, this.RingHKPipeName, this.RingHKPipeSize);
      this.CreatedPipes = true;
    }
    return true;
  }

  public void SendControlMessage(
    uint msg,
    MyControlClass msgParams,
    ref IntPtr myAlloc,
    int wparam = 0,
    bool newAlloc = true)
  {
    if (msg <= 0U || !(this.MainWindowHandle != IntPtr.Zero))
      return;
    int length = 10000;
    if (newAlloc || myAlloc == IntPtr.Zero)
      myAlloc = MyDLL.VirtualAllocEx(this.ProcessHandle, IntPtr.Zero, (IntPtr) length, 12288U /*0x3000*/, 4U);
    if (!(myAlloc != IntPtr.Zero))
      return;
    byte[] numArray = new byte[length];
    if (msgParams.string1 != "" || msgParams.string2 != "" || msgParams.string3 != "" || msgParams.string4 != "")
    {
      Array.Clear((Array) numArray, 0, length);
      if (msgParams.string1 != "" && msgParams.string1.Length < 5000)
      {
        byte[] sourceArray = GA.CheckVISCII(msgParams.string1, this.VersionNum);
        Array.Copy((Array) sourceArray, 0, (Array) numArray, 0, sourceArray.Length);
      }
      if (msgParams.string2 != "" && msgParams.string2.Length < 1000)
      {
        byte[] sourceArray = GA.CheckVISCII(msgParams.string2, this.VersionNum);
        Array.Copy((Array) sourceArray, 0, (Array) numArray, 5000, sourceArray.Length);
      }
      if (msgParams.string3 != "" && msgParams.string3.Length < 1000)
      {
        byte[] sourceArray = GA.CheckVISCII(msgParams.string3, this.VersionNum);
        Array.Copy((Array) sourceArray, 0, (Array) numArray, 6000, sourceArray.Length);
      }
      if (msgParams.string4 != "" && msgParams.string4.Length < 1000)
      {
        byte[] sourceArray = GA.CheckVISCII(msgParams.string4, this.VersionNum);
        Array.Copy((Array) sourceArray, 0, (Array) numArray, 7000, sourceArray.Length);
      }
    }
    int lpNumberOfBytesWritten = 0;
    MyDLL.WriteProcessMemory(this.ProcessHandle, myAlloc, numArray, (uint) length, lpNumberOfBytesWritten);
    MyDLL.PostMessage(this.MainWindowHandle, msg, (IntPtr) wparam, myAlloc);
  }

  public void SendMessageCommand(uint msg, MyParamsClass msgParams)
  {
    if (msg <= 0U || !(this.MainWindowHandle != IntPtr.Zero))
      return;
    int length = 1042;
    IntPtr num1 = MyDLL.VirtualAllocEx(this.ProcessHandle, IntPtr.Zero, (IntPtr) length, 12288U /*0x3000*/, 4U);
    if (!(num1 != IntPtr.Zero))
      return;
    byte[] numArray = new byte[length];
    IntPtr num2 = Marshal.AllocHGlobal(length);
    Marshal.StructureToPtr((object) msgParams, num2, false);
    Marshal.Copy(num2, numArray, 0, length);
    if (msgParams.string1 != "" || msgParams.string2 != "")
    {
      Array.Clear((Array) numArray, 42, 1000);
      if (msgParams.string1 != "")
      {
        byte[] bytes = Encoding.ASCII.GetBytes(msgParams.string1);
        Array.Copy((Array) bytes, 0, (Array) numArray, 42, bytes.Length);
      }
      if (msgParams.string2 != "")
      {
        byte[] bytes = Encoding.ASCII.GetBytes(msgParams.string2);
        Array.Copy((Array) bytes, 0, (Array) numArray, 542, bytes.Length);
      }
    }
    Marshal.FreeHGlobal(num2);
    int lpNumberOfBytesWritten = 0;
    MyDLL.WriteProcessMemory(this.ProcessHandle, num1, numArray, (uint) length, lpNumberOfBytesWritten);
    MyDLL.PostMessage(this.MainWindowHandle, msg, (IntPtr) 0, num1);
  }

  public unsafe void SendPipeCommand(string command)
  {
    bool flag = false;
    string str = "";
    if (MyDLL.WaitForSingleObject(this.controllerMutex, 5U) != 0U)
      return;
    try
    {
      TargetProcess.WriteNamePipe(ref this._ControllerRef, this.PipeName, command);
    }
    finally
    {
      MyDLL.ReleaseMutex(this.controllerMutex);
    }
    while (!flag)
    {
      if ((IntPtr) (void*) this._ControllerRef != IntPtr.Zero)
      {
        for (int index = 0; index < 5; ++index)
          str = GABitConverter.ToString(this._ControllerRef);
      }
      str = str.Replace("\0", "");
      if (str == "Ready")
        flag = true;
      else
        Thread.Sleep(50);
    }
  }

  public static bool WriteNamePipe(ref IntPtr memRef, string fileName, string content)
  {
    if (!(memRef != IntPtr.Zero))
      return false;
    if (!content.EndsWith(";"))
      content += ";";
    try
    {
      if (content.Length <= 2048 /*0x0800*/)
      {
        IntPtr hglobalAuto = Marshal.StringToHGlobalAuto(content);
        MyDLL.CopyMemory(memRef, hglobalAuto, (uint) (content.Length * 2));
      }
      return true;
    }
    catch (Exception ex)
    {
      return false;
    }
  }

  public static unsafe bool WriteNamePipe(ref byte* memRef, string fileName, string content)
  {
    if (!((IntPtr) (void*) memRef != IntPtr.Zero))
      return false;
    if (!content.EndsWith(";"))
      content += ";";
    try
    {
      if (content.Length <= 2048 /*0x0800*/)
      {
        MyDLL.MemSet((IntPtr) (void*) memRef, 0, 2048 /*0x0800*/);
        char[] charArray = content.ToCharArray();
        for (int index = 0; index < content.Length; ++index)
          memRef[index] = (byte) charArray[index];
      }
      return true;
    }
    catch (Exception ex)
    {
      return false;
    }
  }
}
