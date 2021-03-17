namespace MultiplayerConsolePong
{
    using MultiplayerConsolePong.IO;
    using System;

    public class Program
    {
        public static void Main()
        {
            ConsoleManager
                .Configure(optionsBuilder =>
                    {
                        optionsBuilder.AllowMinimizing = false;
                        optionsBuilder.AllowMaximizing = false;
                        optionsBuilder.AllowResizing = false;
                        optionsBuilder.AllowScrollbars = false;
                        optionsBuilder.IsCursorVisible = false;
                        optionsBuilder.Width = GlobalConstants.GridWidth;
                        optionsBuilder.Height = GlobalConstants.GridHeight;
                    })
                .Build();

            IOProvider.Run();
        }
    }
}
