namespace Pong.Common
{
    using System;

    public class ConsoleOptions
    {
        public bool AllowMaximizing { get; set; } = true;

        public bool AllowMinimizing { get; set; } = true;

        public bool AllowClosing { get; set; } = true;

        public bool AllowResizing { get; set; } = true;

        public bool AllowScrollbars { get; set; } = true;

        public bool IsCursorVisible { get; set; } = true;

        public int Height { get; set; } = Console.WindowHeight;

        public int Width { get; set; } = Console.WindowWidth;
    }
}
