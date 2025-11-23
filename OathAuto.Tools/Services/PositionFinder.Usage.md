# Position Finder Tool - Usage Guide

## Overview
The Position Finder is a transparent overlay tool that helps you identify exact coordinates in the game window. It's integrated into OathAuto and works seamlessly with the MouseInputService.

## How to Launch

### From the UI:
1. Run OathAuto application
2. Click **Tools** menu → **Position Finder...**
3. The overlay window appears

### From Code:
```csharp
using OathAuto.Services;

// Show the Position Finder
PositionFinderService.Show();

// Toggle (show/hide)
PositionFinderService.Toggle();

// Close
PositionFinderService.Close();
```

## How to Use

### Step 1: Set Target Window
1. Click **"Set Target Window"** button
2. Click on your game window
3. The tool will display the window title

### Step 2: Find Coordinates
- Move your mouse over the game window
- Watch the **Window Position** (gold numbers) update in real-time
- These are the coordinates relative to the game window (what you need for code)

### Step 3: Capture Positions
- Press **F9** while hovering over the desired location
- Or click the **"Capture (F9)"** button
- The position is added to the captured list

### Step 4: Export Code
1. Click **"Copy Code"** button
2. Paste into your automation code
3. Ready-to-use MouseInputService code is generated!

## Display Information

### Screen Position (White)
- Absolute screen coordinates
- X, Y from top-left corner of screen

### Window Position (Gold) ⭐ **USE THIS IN CODE**
- Coordinates relative to the game window
- X, Y from top-left corner of the window's client area
- These are the values you pass to `MouseInputService.SendClick()`

## Features

### Hotkeys
- **F9**: Capture current mouse position

### Buttons
- **Set Target Window**: Choose which window to track
- **Capture (F9)**: Manually capture position
- **Clear List**: Remove all captured positions
- **Copy Code**: Generate code for all captures

### Window Features
- **Draggable**: Click and drag the title bar
- **Always on Top**: Stays above other windows
- **Resizable**: Drag from bottom-right corner
- **Semi-Transparent**: See through the overlay

## Example Workflow

1. Launch Position Finder from Tools menu
2. Click "Set Target Window" and click on game
3. Hover mouse over "Attack" button in game
4. Press F9 to capture
5. Hover over "Skills" menu
6. Press F9 to capture
7. Click "Copy Code"
8. Paste into your automation script:

```csharp
// Captured positions for MouseInputService
IntPtr gameHandle = smartClass.Target.MainWindowHandle;

// Position 1
MouseInputService.SendClick(gameHandle, x: 450, y: 320);
// Position 2
MouseInputService.SendClick(gameHandle, x: 380, y: 250);
```

## Tips

✅ **DO:**
- Use Window Position (gold) values in your code
- Set target window before capturing
- Keep overlay open while testing clicks
- Press F9 quickly to capture exact positions

❌ **DON'T:**
- Don't use Screen Position values (those are absolute)
- Don't forget to set target window first
- Don't close the overlay if you need to capture more positions

## Troubleshooting

**Q: F9 doesn't work**
- Another app might be using F9 hotkey
- Try clicking "Capture (F9)" button instead

**Q: Window Position shows "No target"**
- Click "Set Target Window" first
- Then click on your game window

**Q: Coordinates seem wrong**
- Make sure you selected the correct window
- Use Window Position (gold), not Screen Position
- Verify game window is not scrolled or zoomed

**Q: Copy Code button does nothing**
- Capture at least one position first
- Check if clipboard access is blocked
