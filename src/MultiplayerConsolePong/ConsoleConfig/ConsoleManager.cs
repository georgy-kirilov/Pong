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
    }
}
