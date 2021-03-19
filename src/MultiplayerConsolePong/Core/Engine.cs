namespace MultiplayerConsolePong.Core
{
    using System;
    using MultiplayerConsolePong.Enums;
    using MultiplayerConsolePong.Games;
    using MultiplayerConsolePong.Models;

    public static class Engine
    {
        private static readonly string[] MainMenuOptions = new string[]
        {
            "New 2 Player Game", "New Game Against Bot", "New Online Game", "EXIT"
        };

        private static readonly string[] RobotDifficultyOptions = new string[]
        {
            "Beginner", "Intermediate", "Expert"
        };

        private static readonly string[] PaddleSideOptions = new string[]
        {
            "LEFT", "RIGHT"
        };

        public static void Run()
        {
            while (true)
            {
                MainMenuOption menuItem = MainMenu();

                if (menuItem == MainMenuOption.TwoPlayerGame)
                {
                    var game = new TwoPlayerPongGame(NewLeftPaddle(), NewRightPaddle(), new Ball());
                    game.Start();
                }
                else if (menuItem == MainMenuOption.AgainstBot)
                {
                    RobotDifficulty difficulty = BotDifficultyMenu();
                    bool isBotWithLeftPaddle = PaddleSideMenu() != PaddleSide.Left;
                    var game = new RobotPongGame(NewLeftPaddle(), NewRightPaddle(), new Ball(), difficulty, isBotWithLeftPaddle);
                    game.Start();
                }
                else if (menuItem == MainMenuOption.Exit)
                {
                    Environment.Exit(0);
                }
            }
        }

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

        private static RobotDifficulty BotDifficultyMenu()
        {
            int selectedOptionIndex = 0;

            while (true)
            {
                PrintMenu("CHOOSE DIFFICULTY", RobotDifficultyOptions, selectedOptionIndex);
                bool indexSelected = SelectOptionIndex(RobotDifficultyOptions.Length, ref selectedOptionIndex);

                if (indexSelected)
                {
                    return (RobotDifficulty)selectedOptionIndex;
                }
            }
        }

        private static PaddleSide PaddleSideMenu()
        {
            int selectedOptionIndex = 0;

            while (true)
            {
                PrintMenu("CHOOSE YOUR SIDE", PaddleSideOptions, selectedOptionIndex);
                bool indexSelected = SelectOptionIndex(PaddleSideOptions.Length, ref selectedOptionIndex);

                if (indexSelected)
                {
                    return (PaddleSide)selectedOptionIndex;
                }
            }
        }

        private static void PrintMenu(string menuTitle, string[] menuOptions, int selectedOptionIndex = 0)
        {
            int y = GlobalConstants.Grid.Height / 3 - MainMenuOptions.Length / 4;
            int x = GlobalConstants.Grid.Width / 2;
            int index = 0;

            ConsoleManager.ClearConsole();
            menuTitle = $" {menuTitle} ";

            ConsoleManager.WriteAt(GlobalConstants.Grid.Width / 2 - menuTitle.Length / 2,
                GlobalConstants.Grid.Height / 6, menuTitle, ConsoleColor.Yellow, Console.BackgroundColor);

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

        private static Paddle NewLeftPaddle()
        {
            return new Paddle(GlobalConstants.Paddles.LeftX, GlobalConstants.Paddles.LeftMoveUpKey, GlobalConstants.Paddles.LeftMoveDownKey);
        }

        private static Paddle NewRightPaddle()
        {
            return new Paddle(GlobalConstants.Paddles.RightX, GlobalConstants.Paddles.RightMoveUpKey, GlobalConstants.Paddles.RightMoveDownKey);
        }
    }
}
