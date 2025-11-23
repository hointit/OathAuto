using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using OathAuto.Tools.ViewModels;

namespace OathAuto.Tools.Views
{
    /// <summary>
    /// Position Finder overlay window for identifying coordinates in game windows.
    /// </summary>
    public partial class PositionFinderWindow : Window
    {
        private PositionFinderViewModel _viewModel;
        private HwndSource _source;
        private const int WM_HOTKEY = 0x0312;
        private const int HOTKEY_ID = 9000;

        public PositionFinderWindow()
        {
            InitializeComponent();
            _viewModel = new PositionFinderViewModel();
            DataContext = _viewModel;

            Loaded += PositionFinderWindow_Loaded;
            Closed += PositionFinderWindow_Closed;
        }

        private void PositionFinderWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Register F9 hotkey
            RegisterHotKey();
        }

        private void PositionFinderWindow_Closed(object sender, EventArgs e)
        {
            // Unregister hotkey and cleanup
            UnregisterHotKey();
            _viewModel.Cleanup();
        }

        private void RegisterHotKey()
        {
            var helper = new WindowInteropHelper(this);
            _source = HwndSource.FromHwnd(helper.Handle);
            _source.AddHook(HwndHook);

            // Register F9 (0x78)
            if (!SmartBot.MyDLL.RegisterHotKey(helper.Handle, HOTKEY_ID, 0, 0x78))
            {
                MessageBox.Show("Could not register F9 hotkey. It may be in use by another application.",
                    "Hotkey Registration Failed", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void UnregisterHotKey()
        {
            var helper = new WindowInteropHelper(this);
            SmartBot.MyDLL.UnregisterHotKey(helper.Handle, HOTKEY_ID);

            if (_source != null)
            {
                _source.RemoveHook(HwndHook);
                _source = null;
            }
        }

        private IntPtr HwndHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == WM_HOTKEY)
            {
                if (wParam.ToInt32() == HOTKEY_ID)
                {
                    // F9 pressed - capture position
                    _viewModel.CaptureCommand.Execute(null);
                    handled = true;
                }
            }
            return IntPtr.Zero;
        }

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SetTargetButton_Click(object sender, RoutedEventArgs e)
        {
            // Hide window temporarily
            this.Hide();

            MessageBox.Show("Click on the game window to select it as target.\n\n" +
                          "This window will reappear after you click.",
                          "Select Target Window", MessageBoxButton.OK, MessageBoxImage.Information);

            // Wait for user to click
            System.Threading.Thread.Sleep(500);

            // Get window under cursor
            POINT cursorPos;
            if (GetCursorPos(out cursorPos))
            {
                IntPtr windowHandle = WindowFromPoint(cursorPos);
                if (windowHandle != IntPtr.Zero)
                {
                    // Get the top-level window
                    IntPtr rootWindow = GetAncestor(windowHandle, 2); // GA_ROOT = 2
                    if (rootWindow != IntPtr.Zero)
                        windowHandle = rootWindow;

                    _viewModel.TargetWindowHandle = windowHandle;

                    MessageBox.Show("Target window set successfully!\n\n" +
                                  "Window Handle: 0x" + windowHandle.ToString("X") + "\n" +
                                  "Title: " + _viewModel.TargetWindowTitle,
                                  "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Could not find window under cursor.",
                        "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            // Show window again
            this.Show();
        }

        private void CopyCodeButton_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.CapturedPositions.Count == 0)
            {
                MessageBox.Show("No positions captured yet!", "Nothing to Copy",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            StringBuilder code = new StringBuilder();
            code.AppendLine("// Captured positions for MouseInputService");
            code.AppendLine("using OathAuto.Tools.Services;");
            code.AppendLine();
            code.AppendLine("IntPtr gameHandle = smartClass.Target.MainWindowHandle;");
            code.AppendLine();

            foreach (var pos in _viewModel.CapturedPositions)
            {
                code.AppendLine(string.Format("// {0}", pos.Description));
                code.AppendLine(string.Format("MouseInputService.SendClick(gameHandle, x: {0}, y: {1});",
                    pos.WindowX, pos.WindowY));
            }

            try
            {
                Clipboard.SetText(code.ToString());
                MessageBox.Show("Code copied to clipboard!\n\nPaste it into your automation code.",
                    "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to copy to clipboard: " + ex.Message,
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // P/Invoke declarations
        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(out POINT lpPoint);

        [DllImport("user32.dll")]
        private static extern IntPtr WindowFromPoint(POINT Point);

        [DllImport("user32.dll")]
        private static extern IntPtr GetAncestor(IntPtr hwnd, uint gaFlags);

        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            public int X;
            public int Y;
        }
    }
}
