using SmartBot;
using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Forms;

namespace OathAuto.Services
{
  /// <summary>
  /// Service for sending mouse input to TLBB game.
  /// IMPORTANT: Standard Windows mouse messages (WM_LBUTTONDOWN/UP) don't work with this game.
  /// The game uses custom registered messages via injected DLLs (tinydll.dll, glogin.dll, gpilot.dll).
  ///
  /// For UI button clicks, use the game's custom WM_CLOSECONFIRMBOX message.
  /// For arbitrary position clicks, try SendClickWithChildWindow or SendClickHybrid methods.
  /// </summary>
  public static class MouseInputService
  {
    [DllImport("user32.dll")]
    private static extern int SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

    [DllImport("user32.dll")]
    private static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

    [DllImport("user32.dll")]
    private static extern IntPtr WindowFromPoint(POINT Point);

    [DllImport("user32.dll")]
    private static extern bool ClientToScreen(IntPtr hWnd, ref POINT lpPoint);

    [DllImport("user32.dll")]
    private static extern IntPtr ChildWindowFromPoint(IntPtr hWnd, POINT Point);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern uint RegisterWindowMessage(string lpString);

    [StructLayout(LayoutKind.Sequential)]
    private struct POINT
    {
      public int X;
      public int Y;
    }

    /// <summary>
    /// Gets the child window at the specified client coordinates.
    /// </summary>
    public static IntPtr GetChildWindowAtPoint(IntPtr parentWindow, int x, int y)
    {
      POINT pt = new POINT { X = x, Y = y };
      return ChildWindowFromPoint(parentWindow, pt);
    }

    /// <summary>
    /// Clicks using game's custom message protocol combined with position data.
    /// This sends WM_DOSOMETHING to prepare, then attempts click with custom message.
    /// </summary>
    /// <param name="windowHandle">Game window handle</param>
    /// <param name="x">X coordinate relative to window client area</param>
    /// <param name="y">Y coordinate relative to window client area</param>
    /// <param name="clickType">Type of click action (default = 0)</param>
    /// <returns>True if messages were sent</returns>
    public static bool SendClickWithCustomProtocol(IntPtr windowHandle, int x, int y, int clickType = 0)
    {
      if (windowHandle == IntPtr.Zero)
        return false;

      // Get custom messages from game settings
      uint WM_DOSOMETHING = frmLogin.GAuto.Settings.WM_DOSOMETHING;
      uint WM_CLOSECONFIRMBOX = frmLogin.GAuto.Settings.WM_CLOSECONFIRMBOX;

      // Create lParam with position
      int lParam = MyDLL.MakeLParam(x, y);

      // Step 1: Prepare the game state
      MyDLL.PostMessage(windowHandle, WM_DOSOMETHING, (IntPtr)5, IntPtr.Zero);
      System.Threading.Thread.Sleep(50);

      // Step 2: Send mouse move to establish position
      const uint WM_MOUSEMOVE = 512;
      SendMessage(windowHandle, WM_MOUSEMOVE, IntPtr.Zero, (IntPtr)lParam);
      System.Threading.Thread.Sleep(20);

      // Step 3: Send the custom click command
      MyDLL.PostMessage(windowHandle, WM_CLOSECONFIRMBOX, (IntPtr)clickType, (IntPtr)lParam);

      return true;
    }

    /// <summary>
    /// Attempts to click by finding and targeting the child window at the position.
    /// Some games render in child windows that handle mouse messages separately.
    /// </summary>
    public static bool SendClickWithChildWindow(IntPtr windowHandle, int x, int y, int delayBetweenDownUp = 50)
    {
      if (windowHandle == IntPtr.Zero)
        return false;

      // Find child window at this position
      IntPtr childWindow = GetChildWindowAtPoint(windowHandle, x, y);
      if (childWindow == IntPtr.Zero || childWindow == windowHandle)
        childWindow = windowHandle; // No child, use parent

      int lParam = MyDLL.MakeLParam(x, y);

      // Try with SendMessage (synchronous) on the child window
      const uint WM_MOUSEMOVE = 512;
      SendMessage(childWindow, WM_MOUSEMOVE, IntPtr.Zero, (IntPtr)lParam);
      System.Threading.Thread.Sleep(10);

      SendMessage(childWindow, MyDLL.WM_LBUTTONDOWN, (IntPtr)MyDLL.MK_LBUTTON, (IntPtr)lParam);

      if (delayBetweenDownUp > 0)
        System.Threading.Thread.Sleep(delayBetweenDownUp);

      SendMessage(childWindow, MyDLL.WM_LBUTTONUP, IntPtr.Zero, (IntPtr)lParam);

      return true;
    }

    /// <summary>
    /// Hybrid approach: Try both custom protocol and standard messages.
    /// </summary>
    public static bool SendClickHybrid(IntPtr windowHandle, int x, int y, int delayBetweenDownUp = 50)
    {
      if (windowHandle == IntPtr.Zero)
        return false;

      // Attempt 1: Custom protocol
      SendClickWithCustomProtocol(windowHandle, x, y, 0);
      System.Threading.Thread.Sleep(delayBetweenDownUp);

      // Attempt 2: Standard messages to child window as backup
      SendClickWithChildWindow(windowHandle, x, y, delayBetweenDownUp);

      return true;
    }

    /// <summary>
    /// Original SendClick method - uses standard Windows messages.
    /// WARNING: This doesn't work with TLBB game. Use SendClickWithCustomProtocol instead.
    /// </summary>
    public static bool SendClick(IntPtr windowHandle, int x, int y, int delayBetweenDownUp = 50)
    {
      if (windowHandle == IntPtr.Zero)
        return false;

      int lParam = MyDLL.MakeLParam(x, y);
      const uint WM_MOUSEMOVE = 512;

      SendMessage(windowHandle, WM_MOUSEMOVE, IntPtr.Zero, (IntPtr)lParam);
      System.Threading.Thread.Sleep(10);

      SendMessage(windowHandle, MyDLL.WM_LBUTTONDOWN, (IntPtr)MyDLL.MK_LBUTTON, (IntPtr)lParam);

      if (delayBetweenDownUp > 0)
        System.Threading.Thread.Sleep(delayBetweenDownUp);

      SendMessage(windowHandle, MyDLL.WM_LBUTTONUP, IntPtr.Zero, (IntPtr)lParam);

      return true;
    }

    /// <summary>
    /// Clicks a specific game UI button using the custom message protocol.
    /// This is how CoreLibrary clicks buttons.
    /// </summary>
    /// <param name="windowHandle">Game window handle</param>
    /// <param name="buttonId">Button identifier:
    /// 0 = Accept/Yes, 1 = Accept box, 6 = Buy KNB, 7 = Mode button,
    /// 8 = Inventory item, 9 = Storage chest, 10 = Inventory tab,
    /// 11 = Skill menu, 12 = Open inventory</param>
    /// <param name="buttonParam">Additional parameter (e.g., chest index, tab index)</param>
    public static bool ClickGameButton(IntPtr windowHandle, int buttonId, int buttonParam = 0)
    {
      if (windowHandle == IntPtr.Zero)
        return false;

      uint WM_DOSOMETHING = frmLogin.GAuto.Settings.WM_DOSOMETHING;
      uint WM_CLOSECONFIRMBOX = frmLogin.GAuto.Settings.WM_CLOSECONFIRMBOX;

      // Prepare game state
      MyDLL.PostMessage(windowHandle, WM_DOSOMETHING, (IntPtr)5, IntPtr.Zero);
      System.Threading.Thread.Sleep(50);

      // Send click command
      MyDLL.PostMessage(windowHandle, WM_CLOSECONFIRMBOX, (IntPtr)buttonId, (IntPtr)buttonParam);

      return true;
    }

    /// <summary>
    /// Sends a double-click using the custom protocol.
    /// </summary>
    public static bool SendDoubleClick(IntPtr windowHandle, int x, int y, int delayBetweenClicks = 100)
    {
      bool firstClick = SendClickWithCustomProtocol(windowHandle, x, y);

      if (!firstClick)
        return false;

      if (delayBetweenClicks > 0)
        System.Threading.Thread.Sleep(delayBetweenClicks);

      return SendClickWithCustomProtocol(windowHandle, x, y);
    }

    /// <summary>
    /// Sends a right mouse button click.
    /// WARNING: May not work with TLBB game's custom protocol.
    /// </summary>
    public static bool SendRightClick(IntPtr windowHandle, int x, int y, int delayBetweenDownUp = 50)
    {
      const uint WM_RBUTTONDOWN = 516;
      const uint WM_RBUTTONUP = 517;
      const uint MK_RBUTTON = 2;

      if (windowHandle == IntPtr.Zero)
        return false;

      int lParam = MyDLL.MakeLParam(x, y);

      SendMessage(windowHandle, WM_RBUTTONDOWN, (IntPtr)MK_RBUTTON, (IntPtr)lParam);

      if (delayBetweenDownUp > 0)
        System.Threading.Thread.Sleep(delayBetweenDownUp);

      SendMessage(windowHandle, WM_RBUTTONUP, IntPtr.Zero, (IntPtr)lParam);

      return true;
    }

    /// <summary>
    /// Sends a mouse move event to the specified window.
    /// </summary>
    public static bool SendMouseMove(IntPtr windowHandle, int x, int y)
    {
      const uint WM_MOUSEMOVE = 512;

      if (windowHandle == IntPtr.Zero)
        return false;

      int lParam = MyDLL.MakeLParam(x, y);

      return MyDLL.PostMessage(windowHandle, WM_MOUSEMOVE, IntPtr.Zero, (IntPtr)lParam);
    }

    public enum EMouseKey
    {
      LEFT,
      RIGHT,
      DOUBLE_LEFT,
      DOUBLE_RIGHT
    }

    [DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
    public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, UIntPtr dwExtraInfo);

    public static void Click(EMouseKey mouseKey = EMouseKey.LEFT)
    {
      switch (mouseKey)
      {
        case EMouseKey.LEFT:
          mouse_event(32774u, 0u, 0u, 0u, UIntPtr.Zero);
          break;
        case EMouseKey.RIGHT:
          mouse_event(32792u, 0u, 0u, 0u, UIntPtr.Zero);
          break;
        case EMouseKey.DOUBLE_LEFT:
          mouse_event(32774u, 0u, 0u, 0u, UIntPtr.Zero);
          mouse_event(32774u, 0u, 0u, 0u, UIntPtr.Zero);
          break;
        case EMouseKey.DOUBLE_RIGHT:
          mouse_event(32792u, 0u, 0u, 0u, UIntPtr.Zero);
          mouse_event(32792u, 0u, 0u, 0u, UIntPtr.Zero);
          break;
      }
    }

    //public static void MouseClick(int x, int y, EMouseKey mouseKey = EMouseKey.LEFT)
    //{
    //  Cursor.Position = new Point(x, y);
    //  Click(mouseKey);
    //}

    //public static async Task MouseClick(Point point, EMouseKey mouseKey = EMouseKey.LEFT)
    //{
    //  Cursor.Position = point;
    //  await Task.Delay(200);
    //  Click(mouseKey);
    //}
  }
}
