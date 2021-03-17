namespace MultiplayerConsolePong
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

        public static void ClearAtCursorPosition(int left = 0, int right = 0)
        {
            ClearAt(Console.CursorLeft + left, Console.CursorTop + right);
        }

        public static void WriteAt(int x, int y, string text)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(text);
        }

        public static void ClearAt(int x, int y)
        {
            WriteAt(x, y, " ");
        }
    }
}
