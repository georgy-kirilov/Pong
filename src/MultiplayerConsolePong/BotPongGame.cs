namespace MultiplayerConsolePong
{
    using System;

    public class BotPongGame : PongGame
    {
        private readonly Random random = new Random();

        public BotPongGame(
            Paddle leftPaddle, Paddle rightPaddle, Ball ball, 
            BotDifficulty difficulty = BotDifficulty.Intermediate,
            bool isBotWithLeftPaddle = true,
            int roundsToWinCount = GlobalConstants.RoundsToWinCount,
            int framesPerSecond = GlobalConstants.FramesPerSecond) : base(leftPaddle, rightPaddle, ball, roundsToWinCount, framesPerSecond)
        {
            switch (difficulty)
            {
                case BotDifficulty.Beginner:
                    this.NumericDifficulty = 0.5;
                    break;

                case BotDifficulty.Intermediate:
                    this.NumericDifficulty = 0.75;
                    break;

                case BotDifficulty.Expert:
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
            bool validBallDirection = this.IsBotPaddleLeft && this.Ball.IsMovingLeft || !this.IsBotPaddleLeft && !this.Ball.IsMovingLeft;
            bool successfulPaddleMovement = this.random.NextDouble() <= this.NumericDifficulty;
            bool ballInsidePaddleHalf = this.IsBotPaddleLeft && this.Ball.X < GlobalConstants.GridWidth / 2 || !this.IsBotPaddleLeft && this.Ball.X > GlobalConstants.GridWidth / 2;

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
