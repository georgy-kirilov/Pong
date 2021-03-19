namespace MultiplayerConsolePong.Common
{
    using System;

    public static class ConsoleManager
    {
        public static ConsoleBuilder Configure(Action<ConsoleOptionsBuilder> optionsBuilder)
        {
            var consoleBuilder = new ConsoleBuilder();
            optionsBuilder(consoleBuilder.OptionsBuilder);
            return consoleBuilder;
        }

        public static void ClearAtCursorPosition(int left = 0, int top = 0)
        {
            ClearAt(Console.CursorLeft + left, Console.CursorTop + top);
        }

        public static void WriteAt(int x, int y, object value, ConsoleColor? background = null, ConsoleColor? foreground = null)
        {
            var oldBackground = Console.BackgroundColor;
            var oldForeground = Console.ForegroundColor; 
            Console.BackgroundColor = background ?? oldBackground;
            Console.ForegroundColor = foreground ?? oldForeground;
            Console.SetCursorPosition(x, y);
            Console.Write(value);
            Console.BackgroundColor = oldBackground;
            Console.ForegroundColor = oldForeground;
        }

        public static void ClearAt(int x, int y)
        {
            WriteAt(x, y, ' ');
        }

        public static void ClearConsole()
        {
            Console.Clear();
        }
    }
}
