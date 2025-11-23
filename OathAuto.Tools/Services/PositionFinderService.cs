using System.Windows;
using OathAuto.Tools.Views;

namespace OathAuto.Tools.Services
{
    /// <summary>
    /// Service for launching the Position Finder overlay tool.
    /// </summary>
    public static class PositionFinderService
    {
        private static PositionFinderWindow _currentWindow;

        /// <summary>
        /// Shows the Position Finder overlay window.
        /// If already open, brings it to front.
        /// </summary>
        public static void Show()
        {
            if (_currentWindow != null)
            {
                // Window already exists, bring to front
                _currentWindow.Activate();
                _currentWindow.Topmost = true;
                return;
            }

            // Create new window
            _currentWindow = new PositionFinderWindow();
            _currentWindow.Closed += (sender, e) => _currentWindow = null;
            _currentWindow.Show();
        }

        /// <summary>
        /// Closes the Position Finder window if open.
        /// </summary>
        public static void Close()
        {
            if (_currentWindow != null)
            {
                _currentWindow.Close();
                _currentWindow = null;
            }
        }

        /// <summary>
        /// Checks if the Position Finder window is currently open.
        /// </summary>
        public static bool IsOpen
        {
            get { return _currentWindow != null; }
        }

        /// <summary>
        /// Shows or hides the Position Finder window (toggle).
        /// </summary>
        public static void Toggle()
        {
            if (IsOpen)
                Close();
            else
                Show();
        }
    }
}
