namespace Pong.Core
{
    using System;
    using Pong.Enums;
    using Pong.Games;
    using Pong.Models;
    using Pong.Menus;
    using Pong.Common;

    public static class Engine
    {
        public static void Run()
        {
            while (true)
            {
                MainMenuOption mainMenuOption = MainMenu.New();

                if (mainMenuOption == MainMenuOption.TwoPlayerGame)
                {
                    var game = new TwoPlayerPongGame(NewLeftPaddle(), NewRightPaddle(), new Ball());
                    game.Start();
                }
                else if (mainMenuOption == MainMenuOption.AgainstBot)
                {
                    RobotDifficultyOption difficulty = RobotDifficultyMenu.New();
                    bool isBotWithLeftPaddle = PlayerPaddleSideMenu.New() != PaddleSideOption.Left;
                    var game = new RobotPongGame(NewLeftPaddle(), NewRightPaddle(), new Ball(), difficulty, isBotWithLeftPaddle);
                    game.Start();
                }
                else if (mainMenuOption == MainMenuOption.Exit)
                {
                    Environment.Exit(0);
                }
            }
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
