using System;
using SmartBot;

namespace OathAuto.Tools.Services
{
    /// <summary>
    /// Example usage of MouseInputService.
    /// This file demonstrates how to send mouse clicks to the game window without blocking your real mouse.
    /// </summary>
    public static class MouseInputServiceExample
    {
        /// <summary>
        /// Example: Send a click to the game window.
        /// This will not block your real mouse - you can continue using your PC normally.
        /// </summary>
        public static void ExampleSendClick()
        {
            // Get the game window handle
            // You can get this from SmartClass.Target.MainWindowHandle or by finding the window
            IntPtr gameWindowHandle = IntPtr.Zero; // Replace with actual game window handle

            // Example 1: Send a single click at position (100, 200) relative to the window
            bool success = MouseInputService.SendClick(gameWindowHandle, x: 100, y: 200);

            if (success)
            {
                Console.WriteLine("Click sent successfully!");
            }

            // Example 2: Send a double-click
            MouseInputService.SendDoubleClick(gameWindowHandle, x: 150, y: 250);

            // Example 3: Send a right-click
            MouseInputService.SendRightClick(gameWindowHandle, x: 200, y: 300);

            // Example 4: Send mouse move (hover)
            MouseInputService.SendMouseMove(gameWindowHandle, x: 300, y: 400);

            // Example 5: Custom delay between mouse down and up
            MouseInputService.SendClick(gameWindowHandle, x: 100, y: 200, delayBetweenDownUp: 100);
        }

        /// <summary>
        /// Example: Integration with SmartClass
        /// Shows how to use MouseInputService with the existing SmartClass infrastructure
        /// </summary>
        public static void ExampleWithSmartClass(SmartClass smartClass)
        {
            if (smartClass?.Target?.MainWindowHandle != null)
            {
                IntPtr gameHandle = smartClass.Target.MainWindowHandle;

                // Click at the center of a typical game button
                MouseInputService.SendClick(gameHandle, x: 400, y: 300);

                // Wait a bit
                System.Threading.Thread.Sleep(500);

                // Click another position
                MouseInputService.SendClick(gameHandle, x: 500, y: 350);
            }
        }

        /// <summary>
        /// Example: Automated clicking sequence
        /// Demonstrates sending multiple clicks without blocking your mouse
        /// </summary>
        public static void ExampleClickSequence(IntPtr gameWindowHandle)
        {
            // Click at position 1
            MouseInputService.SendClick(gameWindowHandle, 100, 100);
            System.Threading.Thread.Sleep(200);

            // Click at position 2
            MouseInputService.SendClick(gameWindowHandle, 200, 150);
            System.Threading.Thread.Sleep(200);

            // Click at position 3
            MouseInputService.SendClick(gameWindowHandle, 300, 200);

            // Your real mouse remains free during all of this!
        }
    }
}
