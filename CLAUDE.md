# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

OathAuto is a game automation application targeting the TLBB (Thiên Long Bát Bộ) MMORPG. The project consists of:
- **OathAuto**: WPF-based Windows application (.NET Framework 3.5) - the main UI layer
- **CoreLibrary**: Core automation engine with decompiled game interaction logic

## 💡 AI Code Assistant Guidelines (Claude Code)

Please adhere strictly to the following constraints and project structure rules when analyzing or generating code.

---

### 💻 Technology and Platform Constraints (Non-Negotiable)

1.  **Target Framework:** The entire solution runs on **.NET Framework 3.5**.
2.  **Package Restriction:** **DO NOT** suggest, use, or implement any features, packages, NuGet references, or APIs specific to **.NET Core**, **.NET 5+**, or any newer framework version beyond .NET Framework 3.5.

---

### 📁 Project Modification Policy

The solution has two distinct projects with separate modification rules:

#### 1. CoreLibrary (Read-Only / Stable Zone)

* **Policy:** Changes in `CoreLibrary` files are **strictly forbidden** unless explicitly requested and the file path is provided in the prompt (e.g., "Change `CoreLibrary\File.cs`").
* **Role:** Your primary role regarding `CoreLibrary` is for **context and dependency analysis only**.

#### 2. OathAuto (Primary Development Zone)

* **Policy:** This is the project where new features, bug fixes, and development work are primarily conducted. **You are encouraged to suggest and implement changes** in files belonging to the `OathAuto` project to fulfill feature requests.
* **Recommendation:** Prioritize all code modifications and additions within this project.

---

### ✔ Summary of Expectations

* **Always** verify compatibility with **.NET Framework 3.5**.
* **Prefer** code changes in `OathAuto`.
* **Avoid** code changes in `CoreLibrary` unless specifically instructed.
* **Never** introduce .NET Core dependencies.

---

## Build Commands

### Building the solution
```bash
# Build entire solution (both projects)
msbuild OathAuto.slnx /p:Configuration=Debug /p:Platform=x86

# Build for release
msbuild OathAuto.slnx /p:Configuration=Release /p:Platform=x86
```

### Building individual projects
```bash
# Build OathAuto only
msbuild OathAuto/OathAuto.csproj /p:Configuration=Debug /p:Platform=x86

# Build CoreLibrary only
msbuild CoreLibrary/CoreLibrary.csproj /p:Configuration=Debug /p:Platform=x86
```

**Note**: This project targets x86 architecture specifically (not AnyCPU) as indicated in the solution configuration.

## Architecture Overview

### Layer Structure

```
OathAuto (WPF UI)
    ├── MainWindow.xaml.cs - Entry point, initializes SmartClassService
    ├── Services/
    │   ├── SmartClassService.cs - Manages SmartClass lifecycle from CoreLibrary
    │   └── CommonService.cs - Utility functions (XOR encryption, version checking, VISCII encoding)
    └── AppState/
        ├── BaseHashState.cs - Contains JSON with game memory addresses/hashes
        └── StringConverterState.cs - VISCII character encoding mappings

CoreLibrary (Game Automation Engine)
    ├── SmartBot/SmartClass.cs - Central automation controller
    ├── SmartBot/*.cs - 200+ classes for game interaction
    ├── CS2PHPCryptography/ - Encrypted communication with PHP backend
    ├── EXControls/ - Custom UI controls
    └── NotEncrypted/ - BlogSpot integration for updates/licensing
```

### Key Architectural Patterns

**1. Memory-based Game Interaction**
- CoreLibrary reads game process memory using DLL injection (`tinydll.dll`, `glogin.dll`, `gpilot.dll`, `ghandle.exe`)
- Base addresses are stored in `BaseHashState.StringHash` as JSON, XOR-encrypted with key `"TDTthangancap"`
- Supports multiple game versions (3.00, 3.01, 3.60, 3.73, 3.75) and providers (2d, 3d, tk)

**2. Initialization Sequence** (see `SmartClassService.cs:25-48`)
```
1. Start frmLogin.GlobalTimer
2. Initialize GAuto.Settings with AllowReadMem = true
3. Decrypt and load MyBases from BaseHashState
4. Set UIAvailable = true to enable background threads
```

**3. Threading Model**
- `ReadInfoThread`: Continuous game state monitoring
- `CheckLicThread`: License validation
- `KeepAliveThread`: Connection maintenance
- All threads controlled via `UIAvailable` flag

**4. External Dependencies**
- Native DLLs copied to output (ghandle.exe, glogin.dll, gpilot.dll, tinydll.dll)
- SQLite.Interop.dll (x86) for database operations
- ObjectListView.dll for advanced list controls
- Newtonsoft.Json 13.0.4 for JSON serialization

## Critical Implementation Details

### Game Process Targeting
- Default target process name: `"game"` (configurable via `SmartClass.TargetProcessName`)
- Uses DLL injection for memory reading (`SmartClass.DllPath`)

### Memory Address Resolution
The `BaseHashState.StringHash` contains memory offset chains like:
```
rm1,int,4,0x00245800,0xC,0x154,0x4  // Chain of offsets to find data
```
These are decrypted via `CommonService.XOREncrypt()` and parsed into `BaseInfo` objects.

### Multi-version Support
`CommonService.CheckGameVersion()` maps version numbers to game client codes:
- Version 1,2,5,6,7,8 → 356
- Version 3 → 301
- Version 4 → 201

### Text Encoding
`CommonService.CheckVISCII()` converts strings to VISCII encoding (Vietnamese legacy charset) for in-game messaging.

## Configuration Files

- `LOGIN.json` - Login credentials (copied to output directory)
- `MyBase.json` - Base configuration (copied to output directory)
- `packages.config` - NuGet dependencies

## Important Notes

- **Unsafe Code**: CoreLibrary uses `AllowUnsafeBlocks=true` for direct memory manipulation
- **Legacy Framework**: Targets .NET Framework 3.5 (released 2007) - do not use modern C# features beyond C# 7.3
- **Decompiled Origin**: CoreLibrary header indicates it was decompiled from `GAuto_Auto_None.exe` using JetBrains decompiler
- **Native Interop**: Heavy use of P/Invoke for Windows API calls and game process manipulation
