namespace MultiplayerConsolePong
{
    using System;
    using System.Threading;

    public class PongGame
    {
        private Ball ball;
        private Paddle leftPaddle;
        private Paddle rightPaddle;
        private readonly int sleepTimeMiliseconds;

        public PongGame(Ball ball, 
                        Paddle leftPaddle, 
                        Paddle rightPaddle, 
                        int roundsToWinCount = GlobalConstants.RoundsToWinCount, 
                        int framesPerSecond = GlobalConstants.FramesPerSecond)
        {
            this.ball = ball;
            this.leftPaddle = leftPaddle;
            this.rightPaddle = rightPaddle;
            this.sleepTimeMiliseconds = 1000 / framesPerSecond;
            this.RoundsToWinCount = roundsToWinCount;
        }
        public int RoundsToWinCount { get; }

        public void Start()
        {
            while (this.leftPaddle.Score < this.RoundsToWinCount && this.rightPaddle.Score < this.RoundsToWinCount)
            {
                this.NewRound();
            }
        }

        private void NewRound()
        {
            bool roundOver = false;

            this.leftPaddle.Print();
            this.rightPaddle.Print();

            while (!roundOver)
            {
                this.ManageUserInput();
                this.ball.Move();

                roundOver |= this.HasLeftPaddleConceded();
                roundOver |= this.HasRightPaddleConceded();

                this.ball.Draw();
                this.PrintScore();
                this.PrintGridMarking();

                Thread.Sleep(this.sleepTimeMiliseconds);
                this.ball.Clear();
            }

            this.ball.X = GlobalConstants.BallX;
            this.ball.Y = GlobalConstants.BallY;

            this.leftPaddle.TopY = GlobalConstants.PaddleY;
            this.rightPaddle.TopY = GlobalConstants.PaddleY;

            ConsoleManager.ClearConsole();
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
            string scoreAsText = $"{this.leftPaddle.Score} : {this.rightPaddle.Score}";
            int scoreX = GlobalConstants.GridWidth / 2 - scoreAsText.Length / 2;
            ConsoleManager.WriteAt(scoreX, GlobalConstants.GridScoreY, scoreAsText);
        }

        private bool HasBallHitPaddle(Paddle paddle)
        {
            return this.ball.Y >= paddle.TopY && this.ball.Y <= paddle.BottomY;
        }

        private bool HasLeftPaddleConceded()
        {
            if (this.ball.IsMovingLeft && this.ball.X == this.ball.LeftMostX)
            {
                if (this.HasBallHitPaddle(this.leftPaddle))
                {
                    this.ball.IsMovingLeft = false;
                }
                else
                {
                    this.rightPaddle.Score++;
                    return true;
                }
            }

            return false;
        }

        private bool HasRightPaddleConceded()
        {
            if (!this.ball.IsMovingLeft && this.ball.X == this.ball.RightMostX)
            {
                if (this.HasBallHitPaddle(this.rightPaddle))
                {
                    this.ball.IsMovingLeft = true;
                }
                else
                {
                    this.leftPaddle.Score++;
                    return true;
                }
            }

            return false;
        }

        private void ManageUserInput()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey().Key;
                Paddle paddleToMove = null;

                if (key == ConsoleKey.UpArrow || key == ConsoleKey.DownArrow)
                {
                    paddleToMove = this.rightPaddle;
                }
                else if (key == ConsoleKey.W || key == ConsoleKey.S)
                {
                    ConsoleManager.ClearAtCursorPosition(left: -1);
                    paddleToMove = this.leftPaddle;
                }

                bool moveUp = key == ConsoleKey.UpArrow || key == ConsoleKey.W;

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
