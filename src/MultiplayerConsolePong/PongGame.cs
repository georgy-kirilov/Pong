namespace MultiplayerConsolePong
{
    using System;
    using System.Threading;

    public abstract class PongGame : IPongGame
    {
        public PongGame(Paddle leftPaddle, Paddle rightPaddle, Ball ball,
                        int roundsToWinCount = GlobalConstants.RoundsToWinCount,
                        int framesPerSecond = GlobalConstants.FramesPerSecond)
        {
            this.LeftPaddle = leftPaddle;
            this.RightPaddle = rightPaddle;
            this.Ball = ball;
            this.RoundsToWinCount = roundsToWinCount;
            this.SleepTimeMilliseconds = 1000 / framesPerSecond;
        }

        public Paddle LeftPaddle { get; }

        public Paddle RightPaddle { get; }

        public Ball Ball { get; }

        public int RoundsToWinCount { get; }

        public int SleepTimeMilliseconds { get; }

        public void Start()
        {
            string winner = string.Empty;

            while (true)
            {
                this.NewRound();

                if (this.LeftPaddle.Score >= this.RoundsToWinCount)
                {
                    winner = "LEFT";
                    break;
                }

                if (this.RightPaddle.Score >= this.RoundsToWinCount)
                {
                    winner = "RIGHT";
                    break;
                }
            }

            string message = $"{winner} PLAYER WINS!";

            ConsoleManager.WriteAt(
                GlobalConstants.GridWidth / 2 - message.Length / 2, 
                GlobalConstants.GridHeight / 2, message, null, ConsoleColor.DarkYellow);

            Console.ReadKey();
        }

        private void NewRound()
        {
            bool roundOver = false;
            ConsoleManager.ClearConsole();

            this.LeftPaddle.Print();
            this.RightPaddle.Print();

            while (!roundOver)
            {
                this.UpdatePaddles();
                this.Ball.Move();

                roundOver |= this.HasLeftPaddleConceded();
                roundOver |= this.HasRightPaddleConceded();

                this.Ball.Print();
                this.PrintScore();
                this.PrintGridMarking();

                Thread.Sleep(this.SleepTimeMilliseconds);
                this.Ball.Clear();
            }

            this.Ball.UpdateProperties();

            this.LeftPaddle.ResetVerticalPosition();
            this.RightPaddle.ResetVerticalPosition();

            Thread.Sleep(GlobalConstants.PauseBetweenRoundsMilliseconds);
        }

        protected virtual void UpdatePaddles()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey().Key;
                ConsoleManager.ClearAtCursorPosition(left: -1);
                this.MovePaddlesByKey(key);
            }
        }

        protected virtual void MovePaddlesByKey(ConsoleKey key)
        {
            this.ManagePaddleInput(this.LeftPaddle, key);
            this.ManagePaddleInput(this.RightPaddle, key);
        }

        protected void ManagePaddleInput(Paddle paddle, ConsoleKey key)
        {
            paddle.Clear();

            if (key == paddle.MoveUpKey)
            {
                paddle.MoveUp();
            }
            else if (key == paddle.MoveDownKey)
            {
                paddle.MoveDown();
            }

            paddle.Print();
        }


        private bool HasLeftPaddleConceded()
        {
            if (this.Ball.IsMovingLeft && this.Ball.X == this.Ball.LeftMostX)
            {
                if (this.LeftPaddle.HasHitBall(this.Ball))
                {
                    this.Ball.IsMovingLeft = false;
                    this.Ball.ChangeSpeedX();
                    this.Ball.ChangeSpeedY();
                }
                else
                {
                    this.RightPaddle.Score++;
                    return true;
                }
            }

            return false;
        }

        private bool HasRightPaddleConceded()
        {
            if (!this.Ball.IsMovingLeft && this.Ball.X == this.Ball.RightMostX)
            {
                if (this.RightPaddle.HasHitBall(this.Ball))
                {
                    this.Ball.IsMovingLeft = true;
                    this.Ball.ChangeSpeedX();
                    this.Ball.ChangeSpeedY();
                }
                else
                {
                    this.LeftPaddle.Score++;
                    return true;
                }
            }

            return false;
        }

        private void PrintGridMarking()
        {
            int column = GlobalConstants.GridWidth / 2;

            for (int row = 3; row < GlobalConstants.GridHeight; row += 3)
            {
                ConsoleManager.WriteAt(column, row, GlobalConstants.GridMarkingSymbol, GlobalConstants.GridMarkingColor);
            }
        }

        private void PrintScore()
        {
            string scoreAsText = $"{this.LeftPaddle.Score} : {this.RightPaddle.Score}";
            int scoreX = GlobalConstants.GridWidth / 2 - scoreAsText.Length / 2;
            ConsoleManager.WriteAt(scoreX, GlobalConstants.GridScoreY, scoreAsText, null, GlobalConstants.ScoreColor);
        }
    }
}
