namespace MultiplayerConsolePong
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

        public ConsoleOptionsBuilder OptionsBuilder { get; private set; }

        public ConsoleBuilder()
        {
            this.OptionsBuilder = new ConsoleOptionsBuilder();
        }

        public void Build()
        {
            IntPtr handle = GetConsoleWindow();
            IntPtr sysMenu = GetSystemMenu(handle, false);

            Console.SetWindowSize(this.OptionsBuilder.Width, this.OptionsBuilder.Height);
            Console.CursorVisible = this.OptionsBuilder.IsCursorVisible;

            if (handle != IntPtr.Zero)
            {
                if (!this.OptionsBuilder.AllowMinimizing)
                {
                    DeleteMenu(sysMenu, SC_MINIMIZE, MF_BYCOMMAND);
                }

                if (!this.OptionsBuilder.AllowMaximizing)
                {
                    DeleteMenu(sysMenu, SC_MAXIMIZE, MF_BYCOMMAND);
                }

                if (!this.OptionsBuilder.AllowResizing)
                {
                    DeleteMenu(sysMenu, SC_SIZE, MF_BYCOMMAND);
                }

                if (!this.OptionsBuilder.AllowClosing)
                {
                    DeleteMenu(sysMenu, SC_CLOSE, MF_BYCOMMAND);
                }

                if (!this.OptionsBuilder.AllowScrollbars)
                {
                    Console.SetBufferSize(this.OptionsBuilder.Width, this.OptionsBuilder.Height);
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
