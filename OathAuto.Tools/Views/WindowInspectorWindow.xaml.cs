using OathAuto.Tools.Services;
using SmartBot;
using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;

namespace OathAuto.Tools.Views
{
    public partial class WindowInspectorWindow : Window
    {
        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(out POINT lpPoint);

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;
        }

        public WindowInspectorWindow()
        {
            InitializeComponent();
        }

        private void BtnInspect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IntPtr windowHandle = ParseWindowHandle(txtWindowHandle.Text);

                if (windowHandle == IntPtr.Zero)
                {
                    txtStatus.Text = "Invalid window handle!";
                    return;
                }

                txtStatus.Text = "Inspecting window hierarchy...";
                txtResults.Text = "Loading...";

                // Run in background to avoid UI freeze (.NET 3.5 compatible)
                Thread bgThread = new Thread(() =>
                {
                    try
                    {
                        var hierarchy = WindowInspectorService.GetWindowHierarchy(windowHandle);
                        string result = WindowInspectorService.FormatWindowHierarchy(hierarchy);
                        int windowCount = CountWindows(hierarchy);

                        Dispatcher.BeginInvoke(new Action(() =>
                        {
                            txtResults.Text = result;
                            txtStatus.Text = string.Format("Hierarchy loaded. Found {0} windows.", windowCount);
                        }));
                    }
                    catch (Exception ex)
                    {
                        Dispatcher.BeginInvoke(new Action(() =>
                        {
                            txtResults.Text = string.Format("Error: {0}\n{1}", ex.Message, ex.StackTrace);
                            txtStatus.Text = "Error during inspection!";
                        }));
                    }
                });
                bgThread.IsBackground = true;
                bgThread.Start();
            }
            catch (Exception ex)
            {
                txtResults.Text = string.Format("Error: {0}", ex.Message);
                txtStatus.Text = "Failed to inspect window!";
            }
        }

        private void BtnGetFromProcess_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Try to get game window from SmartClass
                if (frmLogin.GAuto != null && frmLogin.GAuto.AllAutoAccounts != null && frmLogin.GAuto.AllAutoAccounts.Count > 0)
                {
                    var firstAccount = frmLogin.GAuto.AllAutoAccounts.FirstOrDefault();
                    if (firstAccount != null && firstAccount.Target != null && firstAccount.Target.MainWindowHandle != IntPtr.Zero)
                    {
                        IntPtr handle = firstAccount.Target.MainWindowHandle;
                        txtWindowHandle.Text = string.Format("0x{0:X8}", handle.ToInt32());
                        txtStatus.Text = string.Format("Got window handle from game process: {0}", handle);
                        return;
                    }
                }

                // Fallback: Find game.exe process
                var processes = Process.GetProcessesByName("game");
                if (processes.Length > 0)
                {
                    IntPtr handle = processes[0].MainWindowHandle;
                    txtWindowHandle.Text = string.Format("0x{0:X8}", handle.ToInt32());
                    txtStatus.Text = string.Format("Found game.exe process with handle: {0}", handle);
                }
                else
                {
                    txtStatus.Text = "No game process found! Is the game running?";
                }
            }
            catch (Exception ex)
            {
                txtStatus.Text = string.Format("Error: {0}", ex.Message);
            }
        }

        private void BtnInspectPosition_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IntPtr windowHandle = ParseWindowHandle(txtWindowHandle.Text);
                int x = int.Parse(txtX.Text);
                int y = int.Parse(txtY.Text);

                if (windowHandle == IntPtr.Zero)
                {
                    txtStatus.Text = "Invalid window handle!";
                    return;
                }

                string info = WindowInspectorService.GetWindowInfoAtPosition(windowHandle, x, y);
                IntPtr childWindow = WindowInspectorService.GetRealChildWindowAtPoint(windowHandle, x, y);

                txtResults.Text = info;

                if (childWindow != IntPtr.Zero)
                {
                    txtResults.Text += "\n\n=== TESTING CLICK AT THIS POSITION ===\n";
                    txtResults.Text += "You can use this child window handle for SendMessage/PostMessage:\n";
                    txtResults.Text += string.Format("  IntPtr targetWindow = (IntPtr)0x{0:X8};\n", childWindow.ToInt32());
                    txtResults.Text += string.Format("  MouseInputService.SendClick(targetWindow, {0}, {1});\n", x, y);
                }

                txtStatus.Text = string.Format("Inspected position ({0}, {1})", x, y);
            }
            catch (Exception ex)
            {
                txtResults.Text = string.Format("Error: {0}", ex.Message);
                txtStatus.Text = "Failed to inspect position!";
            }
        }

        private void BtnCaptureMousePos_Click(object sender, RoutedEventArgs e)
        {
            txtStatus.Text = "Move mouse to target position... Capturing in 3 seconds...";

            // Use Thread instead of async/await for .NET 3.5
            Thread delayThread = new Thread(() =>
            {
                Thread.Sleep(3000);

                Dispatcher.BeginInvoke(new Action(() =>
                {
                    POINT cursorPos;
                    if (GetCursorPos(out cursorPos))
                    {
                        // Try to get game window to convert to client coordinates
                        IntPtr windowHandle = ParseWindowHandle(txtWindowHandle.Text);

                        if (windowHandle != IntPtr.Zero)
                        {
                            // Get window info
                            IntPtr windowAtPos = WindowInspectorService.GetWindowAtScreenPoint(cursorPos.X, cursorPos.Y);

                            txtResults.Text = "=== MOUSE POSITION CAPTURED ===\n";
                            txtResults.Text += string.Format("Screen Coordinates: ({0}, {1})\n", cursorPos.X, cursorPos.Y);
                            txtResults.Text += string.Format("Window at Position: 0x{0:X8}\n\n", windowAtPos.ToInt32());

                            if (windowAtPos == windowHandle || IsChildWindow(windowHandle, windowAtPos))
                            {
                                txtResults.Text += "This position is inside the game window!\n";
                                txtResults.Text += "TODO: Convert to client coordinates for clicking.\n";
                            }
                            else
                            {
                                txtResults.Text += "WARNING: This position is NOT inside the game window!\n";
                            }

                            txtX.Text = cursorPos.X.ToString();
                            txtY.Text = cursorPos.Y.ToString();
                        }
                        else
                        {
                            txtResults.Text = string.Format("Mouse Position: ({0}, {1})\n", cursorPos.X, cursorPos.Y);
                            txtResults.Text += "Set window handle first to get more details.";
                        }

                        txtStatus.Text = string.Format("Captured position: ({0}, {1})", cursorPos.X, cursorPos.Y);
                    }
                    else
                    {
                        txtStatus.Text = "Failed to capture mouse position!";
                    }
                }));
            });
            delayThread.IsBackground = true;
            delayThread.Start();
        }

        private IntPtr ParseWindowHandle(string text)
        {
            try
            {
                text = text.Trim();
                if (text.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
                {
                    return new IntPtr(Convert.ToInt32(text, 16));
                }
                return new IntPtr(int.Parse(text));
            }
            catch
            {
                return IntPtr.Zero;
            }
        }

        private int CountWindows(WindowInspectorService.WindowInfo info)
        {
            int count = 1;
            foreach (var child in info.Children)
            {
                count += CountWindows(child);
            }
            return count;
        }

        [DllImport("user32.dll")]
        private static extern IntPtr GetParent(IntPtr hWnd);

        private bool IsChildWindow(IntPtr parent, IntPtr potentialChild)
        {
            IntPtr current = potentialChild;
            while (current != IntPtr.Zero)
            {
                if (current == parent)
                    return true;
                current = GetParent(current);
            }
            return false;
        }
    }
}
