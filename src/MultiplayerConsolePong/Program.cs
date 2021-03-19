namespace MultiplayerConsolePong
{
    public class Program
    {
        public static void Main()
        {
            ConfigureConsole();
            Engine.Run();
        }

        public static void ConfigureConsole()
        {
            ConsoleManager
                .Configure(optionsBuilder =>
                {
                    optionsBuilder.AllowMinimizing = false;
                    optionsBuilder.AllowMaximizing = false;
                    optionsBuilder.AllowResizing = false;
                    optionsBuilder.AllowScrollbars = false;
                    optionsBuilder.IsCursorVisible = false;
                    optionsBuilder.Width = GlobalConstants.Grid.Width;
                    optionsBuilder.Height = GlobalConstants.Grid.Height;
                })
                .Build();
        }
    }
}
