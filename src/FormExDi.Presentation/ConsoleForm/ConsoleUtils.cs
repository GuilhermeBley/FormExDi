using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FormExDi.Presentation.ConsoleForm
{
    internal static class ConsoleUtils
    {
        private const int ATTACH_PARENT_PROCESS = -1;
        private static IntPtr? _handleConsole { get; set; } = null;

        private const UInt32 StdOutputHandle = 0xFFFFFFF5;

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetStdHandle(UInt32 nStdHandle);

        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);

        [DllImport("kernel32.dll")]
        private static extern void SetStdHandle(UInt32 nStdHandle, IntPtr handle);

        [DllImport("kernel32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool AllocConsole();

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool FreeConsole();

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private const int SW_HIDE = 0;
        private const int SW_SHOW = 5;
        private static readonly object _lock = new object();

        public static void CreateConsole()
        {
            lock (_lock)
            {
                if (_handleConsole is not null)
                    return;

                var tryGetHandle = GetConsoleWindow();
                if (tryGetHandle != IntPtr.Zero)
                {
                    _handleConsole = tryGetHandle;
                    return;
                }

                AllocConsole();

                Console.Title = string.Empty;

                _handleConsole = GetConsoleWindow();
            }
        }

        public static void Hide(bool hide = true)
        {
            if (_handleConsole is null)
                return;

            if (hide)
                ShowWindow(_handleConsole.Value, SW_HIDE);
            else
                ShowWindow(_handleConsole.Value, SW_SHOW);
        }

        public static void DisposeCurrentConsole()
        {
            lock (_lock)
            {
                FreeConsole();
                _handleConsole = null;
            }
        }
    }
}
