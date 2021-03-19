namespace MultiplayerConsolePong.Games
{
    using System;
    using MultiplayerConsolePong.Enums;
    using MultiplayerConsolePong.Models;

    public class RobotPongGame : PongGame
    {
        private readonly Random random = new Random();

        public RobotPongGame(
                Paddle leftPaddle, 
                Paddle rightPaddle, 
                Ball ball, 
                RobotDifficulty difficulty = RobotDifficulty.Intermediate,
                bool isBotWithLeftPaddle = true,
                int roundsToWinCount = GlobalConstants.Gameplay.RoundsToWinCount,
                int framesPerSecond = GlobalConstants.Gameplay.FramesPerSecond)

            : base(leftPaddle, rightPaddle, ball, roundsToWinCount, framesPerSecond)
        {
            switch (difficulty)
            {
                case RobotDifficulty.Beginner:
                    this.NumericDifficulty = 0.5;
                    break;

                case RobotDifficulty.Intermediate:
                    this.NumericDifficulty = 0.70;
                    break;

                case RobotDifficulty.Expert:
                    this.NumericDifficulty = 0.85;
                    break;

                default:
                    throw new NotSupportedException("Unsupported Bot Difficulty");
            }

            this.BotPaddle = isBotWithLeftPaddle ? this.LeftPaddle : this.RightPaddle;
            this.PlayerPaddle = isBotWithLeftPaddle ? this.RightPaddle : this.LeftPaddle;
            this.IsBotPaddleLeft = isBotWithLeftPaddle;
        }

        public double NumericDifficulty { get; }

        public Paddle BotPaddle { get; }

        public Paddle PlayerPaddle { get; }

        public bool IsBotPaddleLeft { get; }

        protected override void UpdatePaddles()
        {
            this.UpdateBotPaddle();
            base.UpdatePaddles();
        }

        protected override void MovePaddlesByKey(ConsoleKey key)
        {
            this.ManagePaddleInput(this.PlayerPaddle, key);
        }

        private void UpdateBotPaddle()
        {
            bool validBallDirection = this.IsBotPaddleLeft && this.Ball.IsMovingLeft || 
                !this.IsBotPaddleLeft && !this.Ball.IsMovingLeft;

            bool successfulPaddleMovement = this.random.NextDouble() <= this.NumericDifficulty;

            bool ballInsidePaddleHalf = this.IsBotPaddleLeft && this.Ball.X < GlobalConstants.Grid.Width / 2 || 
                !this.IsBotPaddleLeft && this.Ball.X > GlobalConstants.Grid.Width / 2;

            if (validBallDirection && successfulPaddleMovement && ballInsidePaddleHalf)
            {
                int paddleHeightThird = this.BotPaddle.Height / 3;
                this.BotPaddle.Clear();

                if (this.BotPaddle.TopY + paddleHeightThird > this.Ball.Y)
                {
                    this.BotPaddle.MoveUp();
                }
                else if (this.BotPaddle.BottomY - paddleHeightThird < this.Ball.Y)
                {
                    this.BotPaddle.MoveDown();
                }

                this.BotPaddle.Print();
            }
        }
    }
}
