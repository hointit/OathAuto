using System;
using System.Runtime.InteropServices;
using SmartBot;

namespace OathAuto.Tools.Services
{
    /// <summary>
    /// Service for sending mouse input to a window without blocking the real mouse.
    /// Uses PostMessage to send mouse events directly to the target window.
    /// </summary>
    public static class MouseInputService
    {
        /// <summary>
        /// Sends a left mouse button click to the specified window at the given position.
        /// Position is relative to the window's client area.
        /// </summary>
        /// <param name="windowHandle">Handle to the target window</param>
        /// <param name="x">X coordinate relative to window client area</param>
        /// <param name="y">Y coordinate relative to window client area</param>
        /// <param name="delayBetweenDownUp">Delay in milliseconds between mouse down and up (default: 50ms)</param>
        /// <returns>True if messages were sent successfully</returns>
        public static bool SendClick(IntPtr windowHandle, int x, int y, int delayBetweenDownUp = 50)
        {
            if (windowHandle == IntPtr.Zero)
                return false;

            // Create lParam with position (x in low word, y in high word)
            int lParam = MyDLL.MakeLParam(x, y);

            // Send mouse down
            bool downSent = MyDLL.PostMessage(windowHandle, MyDLL.WM_LBUTTONDOWN, (IntPtr)MyDLL.MK_LBUTTON, (IntPtr)lParam);

            if (!downSent)
                return false;

            // Small delay between down and up to simulate realistic click
            if (delayBetweenDownUp > 0)
                System.Threading.Thread.Sleep(delayBetweenDownUp);

            // Send mouse up
            bool upSent = MyDLL.PostMessage(windowHandle, MyDLL.WM_LBUTTONUP, IntPtr.Zero, (IntPtr)lParam);

            return upSent;
        }

        /// <summary>
        /// Sends a left mouse button double-click to the specified window at the given position.
        /// Position is relative to the window's client area.
        /// </summary>
        /// <param name="windowHandle">Handle to the target window</param>
        /// <param name="x">X coordinate relative to window client area</param>
        /// <param name="y">Y coordinate relative to window client area</param>
        /// <param name="delayBetweenClicks">Delay in milliseconds between clicks (default: 100ms)</param>
        /// <returns>True if messages were sent successfully</returns>
        public static bool SendDoubleClick(IntPtr windowHandle, int x, int y, int delayBetweenClicks = 100)
        {
            bool firstClick = SendClick(windowHandle, x, y);

            if (!firstClick)
                return false;

            if (delayBetweenClicks > 0)
                System.Threading.Thread.Sleep(delayBetweenClicks);

            return SendClick(windowHandle, x, y);
        }

        /// <summary>
        /// Sends a right mouse button click to the specified window at the given position.
        /// Position is relative to the window's client area.
        /// </summary>
        /// <param name="windowHandle">Handle to the target window</param>
        /// <param name="x">X coordinate relative to window client area</param>
        /// <param name="y">Y coordinate relative to window client area</param>
        /// <param name="delayBetweenDownUp">Delay in milliseconds between mouse down and up (default: 50ms)</param>
        /// <returns>True if messages were sent successfully</returns>
        public static bool SendRightClick(IntPtr windowHandle, int x, int y, int delayBetweenDownUp = 50)
        {
            const uint WM_RBUTTONDOWN = 516;
            const uint WM_RBUTTONUP = 517;
            const uint MK_RBUTTON = 2;

            if (windowHandle == IntPtr.Zero)
                return false;

            int lParam = MyDLL.MakeLParam(x, y);

            bool downSent = MyDLL.PostMessage(windowHandle, WM_RBUTTONDOWN, (IntPtr)MK_RBUTTON, (IntPtr)lParam);

            if (!downSent)
                return false;

            if (delayBetweenDownUp > 0)
                System.Threading.Thread.Sleep(delayBetweenDownUp);

            bool upSent = MyDLL.PostMessage(windowHandle, WM_RBUTTONUP, IntPtr.Zero, (IntPtr)lParam);

            return upSent;
        }

        /// <summary>
        /// Sends a mouse move event to the specified window.
        /// Position is relative to the window's client area.
        /// </summary>
        /// <param name="windowHandle">Handle to the target window</param>
        /// <param name="x">X coordinate relative to window client area</param>
        /// <param name="y">Y coordinate relative to window client area</param>
        /// <returns>True if message was sent successfully</returns>
        public static bool SendMouseMove(IntPtr windowHandle, int x, int y)
        {
            const uint WM_MOUSEMOVE = 512;

            if (windowHandle == IntPtr.Zero)
                return false;

            int lParam = MyDLL.MakeLParam(x, y);

            return MyDLL.PostMessage(windowHandle, WM_MOUSEMOVE, IntPtr.Zero, (IntPtr)lParam);
        }
    }
}
