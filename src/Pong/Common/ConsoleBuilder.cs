namespace Pong.Common
{
    using System;
    using System.Runtime.InteropServices;

    public class ConsoleBuilder
    {
        private const int MF_BYCOMMAND = 0x00000000;
        private const int SC_CLOSE = 0xF060;
        private const int SC_MINIMIZE = 0xF020;
        private const int SC_MAXIMIZE = 0xF030;
        private const int SC_SIZE = 0xF000;

        public ConsoleOptions Options { get; private set; }

        public ConsoleBuilder()
        {
            this.Options = new ConsoleOptions();
        }

        public void Build()
        {
            IntPtr handle = GetConsoleWindow();
            IntPtr sysMenu = GetSystemMenu(handle, false);

            Console.SetWindowSize(this.Options.Width, this.Options.Height);
            Console.CursorVisible = this.Options.IsCursorVisible;

            if (handle != IntPtr.Zero)
            {
                if (!this.Options.AllowMinimizing)
                {
                    DeleteMenu(sysMenu, SC_MINIMIZE, MF_BYCOMMAND);
                }

                if (!this.Options.AllowMaximizing)
                {
                    DeleteMenu(sysMenu, SC_MAXIMIZE, MF_BYCOMMAND);
                }

                if (!this.Options.AllowResizing)
                {
                    DeleteMenu(sysMenu, SC_SIZE, MF_BYCOMMAND);
                }

                if (!this.Options.AllowClosing)
                {
                    DeleteMenu(sysMenu, SC_CLOSE, MF_BYCOMMAND);
                }

                if (!this.Options.AllowScrollbars)
                {
                    Console.SetBufferSize(this.Options.Width, this.Options.Height);
                }
            }
        }

        [DllImport("user32.dll")]
        private static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
    }
}
