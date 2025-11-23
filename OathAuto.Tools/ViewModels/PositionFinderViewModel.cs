using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace OathAuto.Tools.ViewModels
{
    /// <summary>
    /// ViewModel for the Position Finder overlay tool.
    /// Tracks mouse position and captures coordinates for game automation.
    /// </summary>
    public class PositionFinderViewModel : INotifyPropertyChanged
    {
        private string _mouseScreenX;
        private string _mouseScreenY;
        private string _mouseWindowX;
        private string _mouseWindowY;
        private string _targetWindowTitle;
        private IntPtr _targetWindowHandle;
        private DispatcherTimer _updateTimer;

        public PositionFinderViewModel()
        {
            CapturedPositions = new ObservableCollection<CapturedPosition>();
            CaptureCommand = new RelayCommand(CaptureCurrentPosition);
            ClearCommand = new RelayCommand(ClearCapturedPositions);

            // Update mouse position every 50ms
            _updateTimer = new DispatcherTimer();
            _updateTimer.Interval = TimeSpan.FromMilliseconds(50);
            _updateTimer.Tick += UpdateMousePosition;
            _updateTimer.Start();
        }

        public ObservableCollection<CapturedPosition> CapturedPositions { get; set; }
        public ICommand CaptureCommand { get; set; }
        public ICommand ClearCommand { get; set; }

        public string MouseScreenX
        {
            get { return _mouseScreenX; }
            set { _mouseScreenX = value; OnPropertyChanged("MouseScreenX"); }
        }

        public string MouseScreenY
        {
            get { return _mouseScreenY; }
            set { _mouseScreenY = value; OnPropertyChanged("MouseScreenY"); }
        }

        public string MouseWindowX
        {
            get { return _mouseWindowX; }
            set { _mouseWindowX = value; OnPropertyChanged("MouseWindowX"); }
        }

        public string MouseWindowY
        {
            get { return _mouseWindowY; }
            set { _mouseWindowY = value; OnPropertyChanged("MouseWindowY"); }
        }

        public string TargetWindowTitle
        {
            get { return _targetWindowTitle; }
            set { _targetWindowTitle = value; OnPropertyChanged("TargetWindowTitle"); }
        }

        public IntPtr TargetWindowHandle
        {
            get { return _targetWindowHandle; }
            set
            {
                _targetWindowHandle = value;
                UpdateTargetWindowTitle();
            }
        }

        private void UpdateMousePosition(object sender, EventArgs e)
        {
            POINT cursorPos;
            if (GetCursorPos(out cursorPos))
            {
                MouseScreenX = cursorPos.X.ToString();
                MouseScreenY = cursorPos.Y.ToString();

                // Calculate window-relative position if we have a target window
                if (TargetWindowHandle != IntPtr.Zero)
                {
                    POINT windowPos = cursorPos;
                    if (ScreenToClient(TargetWindowHandle, ref windowPos))
                    {
                        MouseWindowX = windowPos.X.ToString();
                        MouseWindowY = windowPos.Y.ToString();
                    }
                }
                else
                {
                    MouseWindowX = "No target";
                    MouseWindowY = "No target";
                }
            }
        }

        private void UpdateTargetWindowTitle()
        {
            if (TargetWindowHandle != IntPtr.Zero)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder(256);
                GetWindowText(TargetWindowHandle, sb, sb.Capacity);
                TargetWindowTitle = sb.ToString();
                if (string.IsNullOrEmpty(TargetWindowTitle))
                {
                    TargetWindowTitle = "Handle: 0x" + TargetWindowHandle.ToString("X");
                }
            }
            else
            {
                TargetWindowTitle = "No target window selected";
            }
        }

        private void CaptureCurrentPosition()
        {
            if (TargetWindowHandle == IntPtr.Zero)
            {
                MessageBox.Show("Please set a target window first!", "No Target", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            int windowX = 0;
            int windowY = 0;
            int.TryParse(MouseWindowX, out windowX);
            int.TryParse(MouseWindowY, out windowY);

            CapturedPositions.Add(new CapturedPosition
            {
                Index = CapturedPositions.Count + 1,
                WindowX = windowX,
                WindowY = windowY,
                Description = "Position " + (CapturedPositions.Count + 1)
            });
        }

        private void ClearCapturedPositions()
        {
            CapturedPositions.Clear();
        }

        public void Cleanup()
        {
            if (_updateTimer != null)
            {
                _updateTimer.Stop();
                _updateTimer = null;
            }
        }

        // P/Invoke declarations
        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(out POINT lpPoint);

        [DllImport("user32.dll")]
        private static extern bool ScreenToClient(IntPtr hWnd, ref POINT lpPoint);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int GetWindowText(IntPtr hWnd, System.Text.StringBuilder lpString, int nMaxCount);

        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            public int X;
            public int Y;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    /// <summary>
    /// Represents a captured position coordinate.
    /// </summary>
    public class CapturedPosition
    {
        public int Index { get; set; }
        public int WindowX { get; set; }
        public int WindowY { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return string.Format("#{0}: ({1}, {2}) - {3}", Index, WindowX, WindowY, Description);
        }
    }
}
