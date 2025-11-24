using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OathAuto.Tools.Services
{
  /// <summary>
  /// Service to inspect window hierarchy and properties.
  /// Helps debug why mouse clicks aren't working by showing window structure.
  /// </summary>
  public static class WindowInspectorService
  {
    [DllImport("user32.dll")]
    private static extern bool EnumChildWindows(IntPtr hWndParent, EnumWindowsProc lpEnumFunc, IntPtr lParam);

    [DllImport("user32.dll")]
    private static extern IntPtr GetWindow(IntPtr hWnd, uint uCmd);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

    [DllImport("user32.dll")]
    private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

    [DllImport("user32.dll")]
    private static extern bool GetClientRect(IntPtr hWnd, out RECT lpRect);

    [DllImport("user32.dll")]
    private static extern bool IsWindowVisible(IntPtr hWnd);

    [DllImport("user32.dll")]
    private static extern IntPtr WindowFromPoint(POINT Point);

    [DllImport("user32.dll")]
    private static extern IntPtr RealChildWindowFromPoint(IntPtr hwndParent, POINT ptParentClientCoords);

    private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
      public int Left;
      public int Top;
      public int Right;
      public int Bottom;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
      public int X;
      public int Y;
    }

    public class WindowInfo
    {
      public IntPtr Handle { get; set; }
      public string ClassName { get; set; }
      public string Title { get; set; }
      public RECT WindowRect { get; set; }
      public RECT ClientRect { get; set; }
      public bool IsVisible { get; set; }
      public int Level { get; set; }
      public List<WindowInfo> Children { get; set; }

      public WindowInfo()
      {
        Children = new List<WindowInfo>();
      }

      public override string ToString()
      {
        string indent = new string(' ', Level * 2);
        string size = string.Format("[{0}x{1}]", ClientRect.Right - ClientRect.Left, ClientRect.Bottom - ClientRect.Top);
        string visibility = IsVisible ? "Visible" : "Hidden";
        string title = string.IsNullOrEmpty(Title) ? "(no title)" : string.Format("\"{0}\"", Title);

        return string.Format("{0}├─ {1} {2} ({3})\n{0}   Handle: 0x{4:X8}, Class: {5}",
            indent, title, size, visibility, Handle.ToInt32(), ClassName);
      }
    }

    /// <summary>
    /// Gets complete window hierarchy starting from the specified window.
    /// </summary>
    public static WindowInfo GetWindowHierarchy(IntPtr windowHandle)
    {
      return GetWindowInfoRecursive(windowHandle, 0);
    }

    private static WindowInfo GetWindowInfoRecursive(IntPtr hWnd, int level)
    {
      WindowInfo info = new WindowInfo
      {
        Handle = hWnd,
        ClassName = GetWindowClassName(hWnd),
        Title = GetWindowTitle(hWnd),
        IsVisible = IsWindowVisible(hWnd),
        Level = level
      };

      RECT w = new RECT();
      RECT c = new RECT();

      GetWindowRect(hWnd, out w);
      GetClientRect(hWnd, out c);
      info.WindowRect = w;
      info.ClientRect = c;
      // Enumerate child windows
      List<IntPtr> children = new List<IntPtr>();
      EnumChildWindows(hWnd, (childHwnd, lParam) =>
      {
        children.Add(childHwnd);
        return true;
      }, IntPtr.Zero);

      // Get info for each child
      foreach (IntPtr child in children)
      {
        info.Children.Add(GetWindowInfoRecursive(child, level + 1));
      }

      return info;
    }

    /// <summary>
    /// Gets the window at a specific point (screen coordinates).
    /// </summary>
    public static IntPtr GetWindowAtScreenPoint(int x, int y)
    {
      POINT pt = new POINT { X = x, Y = y };
      return WindowFromPoint(pt);
    }

    /// <summary>
    /// Gets the real child window at a specific point (client coordinates).
    /// </summary>
    public static IntPtr GetRealChildWindowAtPoint(IntPtr parentWindow, int x, int y)
    {
      POINT pt = new POINT { X = x, Y = y };
      return RealChildWindowFromPoint(parentWindow, pt);
    }

    /// <summary>
    /// Formats the window hierarchy as a readable string.
    /// </summary>
    public static string FormatWindowHierarchy(WindowInfo windowInfo)
    {
      StringBuilder sb = new StringBuilder();
      FormatWindowHierarchyRecursive(windowInfo, sb);
      return sb.ToString();
    }

    private static void FormatWindowHierarchyRecursive(WindowInfo info, StringBuilder sb)
    {
      sb.AppendLine(info.ToString());

      foreach (var child in info.Children)
      {
        FormatWindowHierarchyRecursive(child, sb);
      }
    }

    /// <summary>
    /// Finds all windows with a specific class name in the hierarchy.
    /// </summary>
    public static List<WindowInfo> FindWindowsByClassName(WindowInfo root, string className)
    {
      List<WindowInfo> results = new List<WindowInfo>();
      FindWindowsByClassNameRecursive(root, className, results);
      return results;
    }

    private static void FindWindowsByClassNameRecursive(WindowInfo info, string className, List<WindowInfo> results)
    {
      if (info.ClassName.Equals(className, StringComparison.OrdinalIgnoreCase))
      {
        results.Add(info);
      }

      foreach (var child in info.Children)
      {
        FindWindowsByClassNameRecursive(child, className, results);
      }
    }

    /// <summary>
    /// Gets detailed information about a specific window at coordinates.
    /// </summary>
    public static string GetWindowInfoAtPosition(IntPtr parentWindow, int x, int y)
    {
      IntPtr window = GetRealChildWindowAtPoint(parentWindow, x, y);

      if (window == IntPtr.Zero)
        return "No window found at this position";

      WindowInfo info = GetWindowInfoRecursive(window, 0);
      StringBuilder sb = new StringBuilder();

      sb.AppendLine(string.Format("Window at position ({0}, {1}):", x, y));
      sb.AppendLine(string.Format("  Handle: 0x{0:X8}", info.Handle.ToInt32()));
      sb.AppendLine(string.Format("  Class: {0}", info.ClassName));
      sb.AppendLine(string.Format("  Title: {0}", string.IsNullOrEmpty(info.Title) ? "(none)" : info.Title));
      sb.AppendLine(string.Format("  Size: {0}x{1}", info.ClientRect.Right - info.ClientRect.Left, info.ClientRect.Bottom - info.ClientRect.Top));
      sb.AppendLine(string.Format("  Visible: {0}", info.IsVisible));
      sb.AppendLine(string.Format("  Child Count: {0}", info.Children.Count));

      return sb.ToString();
    }

    private static string GetWindowClassName(IntPtr hWnd)
    {
      StringBuilder sb = new StringBuilder(256);
      GetClassName(hWnd, sb, sb.Capacity);
      return sb.ToString();
    }

    private static string GetWindowTitle(IntPtr hWnd)
    {
      StringBuilder sb = new StringBuilder(256);
      GetWindowText(hWnd, sb, sb.Capacity);
      return sb.ToString();
    }
  }
}
