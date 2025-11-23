# OathAuto.Tools

A separate WPF library project containing automation tools and utilities for OathAuto.

## Overview

This project contains reusable tools that help with game automation development. By separating tools into their own project, we maintain better organization and allow for easier reuse across different applications.

## Components

### Position Finder Tool
A transparent overlay window for identifying coordinates in game windows.

**Features:**
- Real-time mouse position tracking (screen and window-relative)
- F9 hotkey to capture positions
- Code generation for MouseInputService
- Dark theme overlay UI

**Usage:**
```csharp
using OathAuto.Tools.Services;

// Show the Position Finder
PositionFinderService.Show();
```

### Mouse Input Service
Service for sending mouse clicks to windows without blocking the real mouse.

**Features:**
- SendClick - Left mouse click
- SendDoubleClick - Double-click
- SendRightClick - Right mouse click
- SendMouseMove - Mouse hover

**Usage:**
```csharp
using OathAuto.Tools.Services;

IntPtr gameHandle = smartClass.Target.MainWindowHandle;
MouseInputService.SendClick(gameHandle, x: 400, y: 300);
```

## Project Structure

```
OathAuto.Tools/
├── Services/
│   ├── MouseInputService.cs           # Mouse input automation
│   ├── PositionFinderService.cs       # Position Finder launcher
│   ├── MouseInputService.Example.cs   # Usage examples
│   └── PositionFinder.Usage.md        # Detailed documentation
├── ViewModels/
│   ├── PositionFinderViewModel.cs     # Position Finder logic
│   └── RelayCommand.cs                # MVVM command helper
├── Views/
│   ├── PositionFinderWindow.xaml      # Position Finder UI
│   └── PositionFinderWindow.xaml.cs   # Position Finder code-behind
└── Properties/
    └── AssemblyInfo.cs
```

## Dependencies

- **.NET Framework 3.5** - Target framework
- **CoreLibrary** - For SmartBot.MyDLL P/Invoke declarations
- **WindowsBase, PresentationCore, PresentationFramework** - WPF support

## Integration with OathAuto

The main OathAuto application references this project and integrates the Position Finder tool via the Tools menu:

```xml
<!-- MainWindow.xaml -->
<Menu Grid.Row="0">
  <MenuItem Header="Tools">
    <MenuItem Header="Position Finder..." Click="PositionFinder_Click"/>
  </MenuItem>
</Menu>
```

```csharp
// MainWindow.xaml.cs
using OathAuto.Tools.Services;

private void PositionFinder_Click(object sender, RoutedEventArgs e)
{
    PositionFinderService.Show();
}
```

## Build Configuration

The project targets x86 architecture to match the main application:

- **Debug|x86** - Development build with debug symbols
- **Release|x86** - Optimized production build

## Future Tools

This project can be extended with additional automation tools:
- Skill rotation designer
- NPC path recorder
- Script macro recorder
- Performance profiler
- Log analyzer

## License

Same license as the main OathAuto project.
