// Decompiled with JetBrains decompiler
// Type: SmartBot.MyDLL
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

#nullable disable
namespace SmartBot;

public class MyDLL
{
  public const uint STANDARD_RIGHTS_REQUIRED = 983040 /*0x0F0000*/;
  public const uint SECTION_QUERY = 1;
  public const uint SECTION_MAP_WRITE = 2;
  public const uint SECTION_MAP_READ = 4;
  public const uint SECTION_MAP_EXECUTE = 8;
  public const uint SECTION_EXTEND_SIZE = 16 /*0x10*/;
  public const uint SECTION_ALL_ACCESS = 983071;
  public const uint FILE_MAP_ALL_ACCESS = 983071;
  public static readonly IntPtr INTPTR_ZERO = (IntPtr) 0;
  public static uint WM_KEYDOWN = 256 /*0x0100*/;
  public static uint WM_KEYUP = 257;
  public static uint WM_CHAR = 258;
  public static uint MK_LBUTTON = 1;
  public static uint WM_LBUTTONUP = 514;
  public static uint WM_LBUTTONDOWN = 513;
  public static List<MyDLL.MEMORY_BASIC_INFORMATION_USAGE> MemReg = new List<MyDLL.MEMORY_BASIC_INFORMATION_USAGE>();

  [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
  public static extern IntPtr CreateFileMapping(
    IntPtr hFile,
    IntPtr lpFileMappingAttributes,
    MyDLL.FileMapProtection flProtect,
    uint dwMaximumSizeHigh,
    uint dwMaximumSizeLow,
    string lpName);

  [DllImport("kernel32.dll", SetLastError = true)]
  public static extern bool UnmapViewOfFile(IntPtr lpBaseAddress);

  [DllImport("Kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
  [return: MarshalAs(UnmanagedType.Bool)]
  public static extern bool GetVolumeInformation(
    string rootPathName,
    StringBuilder volumeNameBuffer,
    int volumeNameSize,
    out uint volumeSerialNumber,
    out uint maximumComponentLength,
    out MyDLL.FileSystemFeature fileSystemFlags,
    StringBuilder fileSystemNameBuffer,
    int nFileSystemNameSize);

  [DllImport("psapi")]
  public static extern bool EnumProcesses(
    [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U4), In, Out] int[] processIds,
    int arraySizeBytes,
    [MarshalAs(UnmanagedType.U4)] out int bytesCopied);

  [DllImport("kernel32.dll")]
  public static extern int VirtualQueryEx(
    IntPtr hProcess,
    IntPtr lpAddress,
    out MyDLL.MEMORY_BASIC_INFORMATION lpBuffer,
    int dwLength);

  [DllImport("kernel32.dll")]
  public static extern int VirtualQueryEx(
    IntPtr hProcess,
    IntPtr lpAddress,
    out MyDLL.MEMORY_BASIC_INFORMATION_UINT lpBuffer,
    int dwLength);

  [DllImport("user32.dll")]
  public static extern short VkKeyScan(char ch);

  [DllImport("user32.dll")]
  public static extern IntPtr SetCapture(IntPtr hWnd);

  [DllImport("user32.dll")]
  public static extern bool ReleaseCapture();

  [DllImport("user32.dll")]
  public static extern uint MapVirtualKey(uint uCode, uint uMapType);

  [DllImport("kernel32.dll", SetLastError = true)]
  [return: MarshalAs(UnmanagedType.Bool)]
  public static extern bool FreeLibrary(IntPtr hModule);

  [DllImport("user32.dll")]
  public static extern int ShowWindow(IntPtr hWnd, uint Msg);

  [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
  public static extern IntPtr LoadLibrary(string lpFileName);

  [DllImport("user32.dll", SetLastError = true)]
  public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

  [DllImport("user32.dll", SetLastError = true)]
  public static extern IntPtr FindWindowEx(
    IntPtr parentHandle,
    IntPtr childAfter,
    string className,
    string windowTitle);

  [DllImport("user32.dll", SetLastError = true)]
  public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

  [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
  public static extern int GetClassName(IntPtr hWnd, string lpClassName, int nMaxCount);

  [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
  public static extern uint RegisterWindowMessage(string lpString);

  [DllImport("psapi.dll")]
  public static extern uint GetModuleFileNameEx(
    IntPtr hProcess,
    IntPtr hModule,
    StringBuilder lpBaseName,
    [MarshalAs(UnmanagedType.U4), In] int nSize);

  [DllImport("psapi.dll")]
  public static extern uint GetModuleBaseName(
    IntPtr hProcess,
    IntPtr hModule,
    StringBuilder lpBaseName,
    uint nSize);

  [DllImport("user32.dll")]
  public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

  [DllImport("user32.dll")]
  public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

  [DllImport("user32.dll")]
  public static extern bool ClientToScreen(IntPtr hWnd, ref Point lpPoint);

  [DllImport("user32.dll")]
  public static extern uint SendInput(uint nInputs, [MarshalAs(UnmanagedType.LPArray), In] INPUT[] pInputs, int cbSize);

  [DllImport("user32.dll", SetLastError = true)]
  [return: MarshalAs(UnmanagedType.Bool)]
  public static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

  [DllImport("User32.dll")]
  public static extern int SendMessage(int hWnd, int Msg, int wParam, int lParam);

  [DllImport("user32.dll")]
  public static extern bool SetForegroundWindow(IntPtr hWnd);

  [DllImport("msvcrt.dll", EntryPoint = "memset", CallingConvention = CallingConvention.Cdecl)]
  public static extern IntPtr MemSet(IntPtr dest, int c, int count);

  [DllImport("kernel32.dll", SetLastError = true)]
  public static extern uint WaitForSingleObject(IntPtr hHandle, uint dwMilliseconds);

  [DllImport("kernel32.dll")]
  public static extern bool ReleaseMutex(IntPtr hMutex);

  [DllImport("user32.dll")]
  public static extern bool EnumWindowStations(
    MyDLL.EnumWindowStationsDelegate lpEnumFunc,
    IntPtr lParam);

  [DllImport("kernel32.dll")]
  public static extern IntPtr CreateMutex(
    IntPtr lpMutexAttributes,
    bool bInitialOwner,
    string lpName);

  [DllImport("kernel32.dll", SetLastError = true)]
  public static extern IntPtr OpenProcess(
    uint dwDesiredAccess,
    int bInheritHandle,
    uint dwProcessId);

  [DllImport("kernel32.dll", SetLastError = true)]
  [return: MarshalAs(UnmanagedType.Bool)]
  public static extern bool IsWow64Process([In] IntPtr processHandle, [MarshalAs(UnmanagedType.Bool)] out bool wow64Process);

  [DllImport("kernel32.dll", SetLastError = true)]
  public static extern int CloseHandle(IntPtr hObject);

  [DllImport("kernel32.dll", SetLastError = true)]
  public static extern uint GetLastError();

  [DllImport("kernel32.dll", SetLastError = true)]
  public static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

  [DllImport("user32.dll", SetLastError = true)]
  public static extern IntPtr SetWindowsHookEx(
    MyDLL.HookType hookType,
    HookProc lpfn,
    IntPtr hMod,
    uint dwThreadId);

  [DllImport("user32.dll", SetLastError = true)]
  [return: MarshalAs(UnmanagedType.Bool)]
  public static extern bool UnhookWindowsHookEx(IntPtr hhk);

  [DllImport("kernel32.dll", SetLastError = true)]
  public static extern IntPtr GetModuleHandle(string lpModuleName);

  [DllImport("kernel32.dll", SetLastError = true)]
  public static extern IntPtr VirtualAllocEx(
    IntPtr hProcess,
    IntPtr lpAddress,
    IntPtr dwSize,
    uint flAllocationType,
    uint flProtect);

  [DllImport("kernel32.dll", SetLastError = true)]
  public static extern int WriteProcessMemory(
    IntPtr hProcess,
    IntPtr lpBaseAddress,
    byte[] buffer,
    uint size,
    int lpNumberOfBytesWritten);

  [DllImport("kernel32.dll", SetLastError = true)]
  public static extern bool VirtualProtect(
    IntPtr lpAddress,
    uint dwSize,
    uint flNewProtect,
    out uint lpflOldProtect);

  [DllImport("kernel32.dll")]
  public static extern bool ReadProcessMemory(
    int hProcess,
    IntPtr lpBaseAddress,
    byte[] lpBuffer,
    uint dwSize,
    ref int lpNumberOfBytesRead);

  [DllImport("kernel32.dll")]
  public static extern bool ReadProcessMemory(
    int hProcess,
    uint lpBaseAddress,
    byte[] lpBuffer,
    uint dwSize,
    ref int lpNumberOfBytesRead);

  [DllImport("kernel32.dll", SetLastError = true)]
  public static extern IntPtr CreateRemoteThread(
    IntPtr hProcess,
    IntPtr lpThreadAttribute,
    IntPtr dwStackSize,
    IntPtr lpStartAddress,
    IntPtr lpParameter,
    uint dwCreationFlags,
    IntPtr lpThreadId);

  [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
  public static extern IntPtr OpenFileMapping(
    uint dwDesiredAccess,
    bool bInheritHandle,
    string lpName);

  [DllImport("msvcrt.dll", EntryPoint = "memcpy", CallingConvention = CallingConvention.Cdecl)]
  public static extern IntPtr MemCopy(IntPtr dest, IntPtr src, uint count);

  [DllImport("kernel32.dll")]
  public static extern void CopyMemory(IntPtr dest, IntPtr src, uint count);

  [DllImport("kernel32.dll", SetLastError = true)]
  public static extern IntPtr MapViewOfFile(
    IntPtr hFileMappingObject,
    uint dwDesiredAccess,
    uint dwFileOffsetHigh,
    uint dwFileOffsetLow,
    UIntPtr dwNumberOfBytesToMap);

  public static int MakeLParam(int LoWord, int HiWord)
  {
    return HiWord << 16 /*0x10*/ | LoWord & (int) ushort.MaxValue;
  }

  public bool IsRemoteProcess64Bit(Process myProcess) => false;

  public bool IsMyself64Bit() => false;

  [DllImport("kernel32.dll", SetLastError = true)]
  public static extern void SetLastError(uint dwErrorCode);

  public static void ReadMemInfo(IntPtr pHandle)
  {
    IntPtr lpAddress = new IntPtr();
    int num = 0;
    bool flag = false;
    do
    {
      MyDLL.MEMORY_BASIC_INFORMATION_UINT lpBuffer = new MyDLL.MEMORY_BASIC_INFORMATION_UINT();
      int lastError1 = (int) MyDLL.GetLastError();
      MyDLL.SetLastError(0U);
      MyDLL.VirtualQueryEx(pHandle, lpAddress, out lpBuffer, Marshal.SizeOf((object) lpBuffer));
      int lastError2 = (int) MyDLL.GetLastError();
      if (((int) lpBuffer.State & 4096 /*0x1000*/) != 0 && ((int) lpBuffer.Protect & 256 /*0x0100*/) == 0)
        MyDLL.MemReg.Add(new MyDLL.MEMORY_BASIC_INFORMATION_USAGE()
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
        lpAddress = new IntPtr((long) (lpBuffer.BaseAddress + lpBuffer.RegionSize));
      }
      catch (Exception ex)
      {
        flag = true;
      }
    }
    while ((int) lpAddress < 2147418112 && !flag);
  }

  public static int ScanMemoryRegion(byte[] memRegion, byte[] pattern)
  {
    try
    {
      int[] numArray = new int[256 /*0x0100*/];
      int num1 = 0;
      int num2 = pattern.Length - 1;
      for (int index = 0; index < 256 /*0x0100*/; ++index)
        numArray[index] = pattern.Length;
      for (int index = 0; index < num2; ++index)
        numArray[(int) pattern[index]] = num2 - index;
      int num3 = 0;
      for (; num1 <= memRegion.Length - pattern.Length; num1 += numArray[(int) memRegion[num1 + num2]])
      {
        for (int index = num2; (int) memRegion[num1 + index] == (int) pattern[index]; --index)
        {
          if (index == 0)
          {
            int num4 = num3 + 1;
            return num1;
          }
        }
      }
    }
    catch (Exception ex)
    {
    }
    return -1;
  }

  public static int SearchBytesPattern(
    IntPtr processHandle,
    byte[] Pattern,
    int index = 0,
    bool readmem = false,
    int offset = 0,
    int addsub = 0)
  {
    if (processHandle == IntPtr.Zero)
      return 0;
    if (MyDLL.MemReg.Count == 0)
      MyDLL.ReadMemInfo(processHandle);
    int lpNumberOfBytesRead = 0;
    int num1 = -1;
    for (int index1 = 0; index1 < MyDLL.MemReg.Count; ++index1)
    {
      try
      {
        byte[] numArray = new byte[MyDLL.MemReg[index1].RegionSize];
        MyDLL.ReadProcessMemory((int) processHandle, (IntPtr) (long) MyDLL.MemReg[index1].BaseAddress, numArray, MyDLL.MemReg[index1].RegionSize, ref lpNumberOfBytesRead);
        int num2 = MyDLL.ScanMemoryRegion(numArray, Pattern);
        if (num2 >= 0)
        {
          uint num3 = MyDLL.MemReg[index1].BaseAddress + (uint) num2;
          uint num4 = num3;
          if (readmem)
          {
            uint lpBaseAddress = num3 + (uint) offset;
            byte[] lpBuffer = new byte[4];
            MyDLL.ReadProcessMemory((int) processHandle, lpBaseAddress, lpBuffer, 4U, ref lpNumberOfBytesRead);
            num4 = BitConverter.ToUInt32(lpBuffer, 0);
          }
          if (num4 != 0U)
            num4 += (uint) addsub;
          if (num4 > 0U)
          {
            ++num1;
            if (num1 >= index)
              return (int) num4;
          }
        }
      }
      catch (Exception ex)
      {
      }
    }
    return 0;
  }

  public unsafe MyDLL.DLLInjectResults ExecuteDLLInjection(
    IntPtr processHandle,
    string dllPath,
    bool use64Bit)
  {
    if (use64Bit && !this.IsMyself64Bit())
      return MyDLL.DLLInjectResults.VersionMismatch;
    if (processHandle == MyDLL.INTPTR_ZERO)
      return MyDLL.DLLInjectResults.ProcessNotFound;
    IntPtr procAddress = MyDLL.GetProcAddress(MyDLL.GetModuleHandle("kernel32.dll"), "LoadLibraryA");
    if (procAddress == MyDLL.INTPTR_ZERO)
      return MyDLL.DLLInjectResults.NoLoadLibraryA;
    IntPtr num = MyDLL.VirtualAllocEx(processHandle, (IntPtr) (void*) null, (IntPtr) dllPath.Length, 12288U /*0x3000*/, 64U /*0x40*/);
    if (num == MyDLL.INTPTR_ZERO)
      return MyDLL.DLLInjectResults.CannotAllocateMemory;
    byte[] bytes = Encoding.UTF8.GetBytes(dllPath);
    if (MyDLL.WriteProcessMemory(processHandle, num, bytes, (uint) bytes.Length, 0) == 0)
      return MyDLL.DLLInjectResults.CannotWriteDLLToMemory;
    if (MyDLL.CreateRemoteThread(processHandle, (IntPtr) (void*) null, MyDLL.INTPTR_ZERO, procAddress, num, 0U, (IntPtr) (void*) null) == MyDLL.INTPTR_ZERO)
    {
      int nativeErrorCode = new Win32Exception(Marshal.GetLastWin32Error()).NativeErrorCode;
      string message = new Win32Exception(Marshal.GetLastWin32Error()).Message;
      if (nativeErrorCode == 5)
        return MyDLL.DLLInjectResults.AccessIsDenied;
    }
    MyDLL.CloseHandle(processHandle);
    int nativeErrorCode1 = new Win32Exception(Marshal.GetLastWin32Error()).NativeErrorCode;
    string message1 = new Win32Exception(Marshal.GetLastWin32Error()).Message;
    if (nativeErrorCode1 <= 0 || nativeErrorCode1 == 183)
      return MyDLL.DLLInjectResults.Success;
    GA.Message("Error while injecting {0}", (object) message1);
    GA.LogToFile("Error injecting DLL, message {0}", (object) message1);
    return MyDLL.DLLInjectResults.Failed;
  }

  public enum DLLInjectResults
  {
    DllNotFound,
    ProcessNotFound,
    Failed,
    Success,
    AccessIsDenied,
    NoLoadLibraryA,
    CannotAllocateMemory,
    CannotWriteDLLToMemory,
    VersionMismatch,
    Others,
  }

  public enum HookType
  {
    WH_JOURNALRECORD,
    WH_JOURNALPLAYBACK,
    WH_KEYBOARD,
    WH_GETMESSAGE,
    WH_CALLWNDPROC,
    WH_CBT,
    WH_SYSMSGFILTER,
    WH_MOUSE,
    WH_HARDWARE,
    WH_DEBUG,
    WH_SHELL,
    WH_FOREGROUNDIDLE,
    WH_CALLWNDPROCRET,
    WH_KEYBOARD_LL,
    WH_MOUSE_LL,
  }

  public delegate bool SetHookFunc(uint wHandle);

  public delegate bool RemoveHookFunc();

  [Flags]
  public enum FileMapProtection : uint
  {
    PageReadonly = 2,
    PageReadWrite = 4,
    PageWriteCopy = 8,
    PageExecuteRead = 32, // 0x00000020
    PageExecuteReadWrite = 64, // 0x00000040
    SectionCommit = 134217728, // 0x08000000
    SectionImage = 16777216, // 0x01000000
    SectionNoCache = 268435456, // 0x10000000
    SectionReserve = 67108864, // 0x04000000
  }

  public struct MEMORY_BASIC_INFORMATION_UINT
  {
    public uint BaseAddress;
    public uint AllocationBase;
    public uint AllocationProtect;
    public uint RegionSize;
    public uint State;
    public uint Protect;
    public uint Type;
  }

  public struct MEMORY_BASIC_INFORMATION
  {
    public IntPtr BaseAddress;
    public IntPtr AllocationBase;
    public uint AllocationProtect;
    public uint RegionSize;
    public uint State;
    public uint Protect;
    public uint Type;
  }

  public enum Protection
  {
    PAGE_NOACCESS = 1,
    PAGE_READONLY = 2,
    PAGE_READWRITE = 4,
    PAGE_WRITECOPY = 8,
    PAGE_EXECUTE = 16, // 0x00000010
    PAGE_EXECUTE_READ = 32, // 0x00000020
    PAGE_EXECUTE_READWRITE = 64, // 0x00000040
    PAGE_EXECUTE_WRITECOPY = 128, // 0x00000080
    PAGE_GUARD = 256, // 0x00000100
    PAGE_NOCACHE = 512, // 0x00000200
    PAGE_WRITECOMBINE = 1024, // 0x00000400
  }

  [Flags]
  public enum FileSystemFeature : uint
  {
    CasePreservedNames = 2,
    CaseSensitiveSearch = 1,
    DaxVolume = 536870912, // 0x20000000
    FileCompression = 16, // 0x00000010
    NamedStreams = 262144, // 0x00040000
    PersistentACLS = 8,
    ReadOnlyVolume = 524288, // 0x00080000
    SequentialWriteOnce = 1048576, // 0x00100000
    SupportsEncryption = 131072, // 0x00020000
    SupportsExtendedAttributes = 8388608, // 0x00800000
    SupportsHardLinks = 4194304, // 0x00400000
    SupportsObjectIDs = 65536, // 0x00010000
    SupportsOpenByFileId = 16777216, // 0x01000000
    SupportsReparsePoints = 128, // 0x00000080
    SupportsSparseFiles = 64, // 0x00000040
    SupportsTransactions = 2097152, // 0x00200000
    SupportsUsnJournal = 33554432, // 0x02000000
    UnicodeOnDisk = 4,
    VolumeIsCompressed = 32768, // 0x00008000
    VolumeQuotas = 32, // 0x00000020
  }

  public delegate bool EnumWindowStationsDelegate(string windowsStation, IntPtr lParam);

  public class MEMORY_BASIC_INFORMATION_USAGE
  {
    public uint BaseAddress;
    public uint AllocationBase;
    public uint AllocationProtect;
    public uint RegionSize;
    public uint State;
    public uint Protect;
    public uint Type;
    public byte[] ByteContent;
  }
}
