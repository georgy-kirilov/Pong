namespace MultiplayerConsolePong
{
    using System;

    public static class Engine
    {
        private static readonly string[] MainMenuOptions = new string[]
        {
            "New 2 Player Game",
            "New Game Against Bot",
            "New Online Game",
            "EXIT",
        };

        private static readonly string[] BotDifficultyOptions = new string[]
        {
            "Beginner",
            "Intermediate",
            "Expert",
        };

        private static MainMenuOption MainMenu()
        {
            int selectedOptionIndex = 0;

            while (true)
            {
                PrintMenu("WELCOME TO PONG 2021", MainMenuOptions, selectedOptionIndex);
                bool indexSelected = SelectOptionIndex(MainMenuOptions.Length, ref selectedOptionIndex);
                
                if (indexSelected)
                {
                    return (MainMenuOption)selectedOptionIndex;
                }
            }
        }

        private static BotDifficulty BotDifficultyMenu()
        {
            int selectedOptionIndex = 0;

            while (true)
            {
                PrintMenu("CHOOSE DIFFICULTY", BotDifficultyOptions, selectedOptionIndex);
                bool indexSelected = SelectOptionIndex(BotDifficultyOptions.Length, ref selectedOptionIndex);

                if (indexSelected)
                {
                    return (BotDifficulty)selectedOptionIndex;
                }
            }
        }

        private static void PrintMenu(string menuTitle, string[] menuOptions, int selectedOptionIndex = 0)
        {
            int y = GlobalConstants.GridHeight / 3 - MainMenuOptions.Length / 4;
            int x = GlobalConstants.GridWidth / 2;
            int index = 0;

            ConsoleManager.ClearConsole();
            menuTitle = $" {menuTitle} ";

            ConsoleManager.WriteAt(GlobalConstants.GridWidth / 2 - menuTitle.Length / 2,
                GlobalConstants.GridHeight / 6, menuTitle, ConsoleColor.Yellow, Console.BackgroundColor);

            foreach (string option in menuOptions)
            {
                var color = index == selectedOptionIndex ? ConsoleColor.Green : ConsoleColor.DarkYellow;
                ConsoleManager.WriteAt(x - option.Length / 2, y, option, null, color);
                y += 2;
                index++;
            }
        }

        private static bool SelectOptionIndex(int menuOptionsCount, ref int currentSelectedOptionIndex)
        {
            ConsoleKey key = Console.ReadKey().Key;

            if (key == ConsoleKey.Enter)
            {
                return true;
            }
            else if (key == ConsoleKey.UpArrow || key == ConsoleKey.W)
            {
                currentSelectedOptionIndex--;
            }
            else if (key == ConsoleKey.DownArrow || key == ConsoleKey.S)
            {
                currentSelectedOptionIndex++;
            }

            if (currentSelectedOptionIndex < 0)
            {
                currentSelectedOptionIndex = menuOptionsCount - 1;
            }
            else if (currentSelectedOptionIndex >= menuOptionsCount)
            {
                currentSelectedOptionIndex = 0;
            }

            return false;
        }

        public static void Run()
        {
            while (true)
            {
                MainMenuOption menuItem = MainMenu();

                if (menuItem == MainMenuOption.TwoPlayerGame)
                {
                    new TwoPlayerPongGame(
                        new Paddle(GlobalConstants.LeftPaddleX),
                        new Paddle(GlobalConstants.RightPaddleX),
                        new Ball())
                    .Start();
                }
                else if (menuItem == MainMenuOption.AgainstBot)
                {
                    BotDifficulty difficulty = BotDifficultyMenu();

                    new BotPongGame(
                        new Paddle(GlobalConstants.LeftPaddleX),
                        new Paddle(GlobalConstants.RightPaddleX),
                        new Ball(), 
                        difficulty)
                    .Start();
                }
                else if (menuItem == MainMenuOption.Exit)
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}
