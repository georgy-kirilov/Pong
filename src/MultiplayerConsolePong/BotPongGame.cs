namespace MultiplayerConsolePong
{
    using System;

    public class BotPongGame : PongGame
    {
        private readonly Random random = new Random();

        public BotPongGame(Paddle leftPaddle, Paddle rightPaddle, Ball ball, 
            BotDifficulty difficulty = BotDifficulty.Intermediate,
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
        }

        public double NumericDifficulty { get; }

        protected override void ManageUserInput()
        {
            if (this.Ball.IsMovingLeft && this.Ball.X < GlobalConstants.GridWidth / 2 && this.random.NextDouble() <= this.NumericDifficulty)
            {
                int paddleHeightThird = this.LeftPaddle.Height / 3;
                this.LeftPaddle.Clear();

                if (this.LeftPaddle.TopY + paddleHeightThird > this.Ball.Y)
                {
                    this.LeftPaddle.MoveUp();
                }
                else if (this.LeftPaddle.BottomY - paddleHeightThird < this.Ball.Y)
                {
                    this.LeftPaddle.MoveDown();
                }

                this.LeftPaddle.Print();
            }

            if (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey().Key;
                Paddle paddleToMove = null;
                ConsoleManager.ClearAtCursorPosition(left: -1);

                if (key == ConsoleKey.UpArrow || key == ConsoleKey.DownArrow)
                {
                    paddleToMove = this.RightPaddle;
                }

                bool moveUp = key == ConsoleKey.UpArrow;

                if (paddleToMove != null)
                {
                    paddleToMove.Clear();

                    if (moveUp)
                    {
                        paddleToMove.MoveUp();
                    }
                    else
                    {
                        paddleToMove.MoveDown();
                    }

                    paddleToMove.Print();
                }
            }
        }
    }
}
