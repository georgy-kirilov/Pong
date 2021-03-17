namespace MultiplayerConsolePong.IO
{
    using System;

    public static class IOProvider
    {
        private const string LogoMessage = " WELCOME TO PONG 2021 ";

        private static readonly string[] MainMenuItems = new string[]
        {
            "New 2 Player Game",
            "New Game Against Bot",
            "New Online Game",
        };

        public static void PrintMainMenu(int selectedMenuItemIndex = 0)
        {
            int y = GlobalConstants.GridHeight / 3 - MainMenuItems.Length / 4;
            int x = GlobalConstants.GridWidth / 2;
            int index = 0;

            foreach (string mainMenuItem in MainMenuItems)
            {
                var color = ConsoleColor.DarkYellow;

                if (index == selectedMenuItemIndex)
                {
                    color = ConsoleColor.Green;
                }

                ConsoleManager.WriteAt(x - mainMenuItem.Length / 2, y, mainMenuItem, null, color);
                y += 2;

                index++;
            }
        }

        public static void PrintLogo()
        {
            ConsoleManager.WriteAt(GlobalConstants.GridWidth / 2 - LogoMessage.Length / 2, GlobalConstants.GridHeight / 6, LogoMessage, ConsoleColor.Yellow, Console.BackgroundColor);
        }

        public static GameOption InputMainMenu()
        {
            int selectedMenuItemIndex = 0;

            while (true)
            {
                ConsoleManager.ClearConsole();
                PrintLogo();
                PrintMainMenu(selectedMenuItemIndex);

                ConsoleKey key = Console.ReadKey().Key;

                if (key == ConsoleKey.UpArrow || key == ConsoleKey.W)
                {
                    selectedMenuItemIndex--;
                }

                if (key == ConsoleKey.DownArrow || key == ConsoleKey.S)
                {
                    selectedMenuItemIndex++;
                }

                if (key == ConsoleKey.Enter)
                {
                    return (GameOption)(selectedMenuItemIndex + 1);
                }

                if (selectedMenuItemIndex < 0 || selectedMenuItemIndex >= MainMenuItems.Length)
                {
                    selectedMenuItemIndex = 0;
                }
            }
        }

        public static void Run()
        {
            while (true)
            {
                GameOption gameOption = InputMainMenu();

                if (gameOption == GameOption.TwoPlayerGame)
                {
                    var leftPaddle = new Paddle(GlobalConstants.LeftPaddleX);
                    var rightPaddle = new Paddle(GlobalConstants.RightPaddleX);
                    var ball = new Ball();

                    var pongGame = new PongGame(ball, leftPaddle, rightPaddle);
                    pongGame.Start();
                }
            }
        }
    }
}
