namespace MultiplayerConsolePong
{
    using System;
    using System.Threading;

    public class PongGame
    {
        private readonly Ball ball;
        private readonly Paddle leftPaddle;
        private readonly Paddle rightPaddle;
        private readonly int sleepTimeMiliseconds;

        private readonly Random random;

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
            this.random = new Random();
        }
        public int RoundsToWinCount { get; }

        public void Start()
        {
            string winner = null;

            while (this.leftPaddle.Score < this.RoundsToWinCount && this.rightPaddle.Score < this.RoundsToWinCount)
            {
                this.NewRound();

                if (this.leftPaddle.Score >= this.RoundsToWinCount)
                {
                    winner = "LEFT";
                    break;
                }

                if (this.rightPaddle.Score >= this.RoundsToWinCount)
                {
                    winner = "RIGHT";
                    break;
                }
            }

            string message = $"{winner} PLAYER WINS!";
            ConsoleManager.WriteAt(GlobalConstants.GridWidth / 2 - message.Length / 2, GlobalConstants.GridHeight / 2, message, null, ConsoleColor.DarkYellow);
            Console.ReadKey();
        }

        private void NewRound()
        {
            bool roundOver = false;

            ConsoleManager.ClearConsole();

            this.leftPaddle.Print();
            this.rightPaddle.Print();

            while (!roundOver)
            {
                this.ManageUserInput();
                this.ball.Move();

                roundOver |= this.HasLeftPaddleConceded();
                roundOver |= this.HasRightPaddleConceded();

                this.ball.Print();
                this.PrintScore();
                this.PrintGridMarking();

                Thread.Sleep(this.sleepTimeMiliseconds);
                this.ball.Clear();
            }

            // Update ball properties
            this.ball.X = GlobalConstants.BallX;
            this.ball.Y = this.NewRandomBallY();
            this.ball.SpeedX = GlobalConstants.BallDefaultHorizontalSpeed;
            this.ball.IsMovingLeft = this.NewRandomBool();
            this.ball.IsMovingUp = this.NewRandomBool();

            // Reset paddles positions
            this.leftPaddle.TopY = GlobalConstants.PaddleY;
            this.rightPaddle.TopY = GlobalConstants.PaddleY;

            Thread.Sleep(GlobalConstants.PauseBetweenRoundsMilliseconds);
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
            ConsoleManager.WriteAt(scoreX, GlobalConstants.GridScoreY, scoreAsText, null, ConsoleColor.Green);
        }

        private bool HasBallHitPaddle(Paddle paddle)
        {
            return this.ball.Y >= paddle.TopY - 1 && this.ball.Y <= paddle.BottomY + 1;
        }

        private bool HasLeftPaddleConceded()
        {
            if (this.ball.IsMovingLeft && this.ball.X == this.ball.LeftMostX)
            {
                if (this.HasBallHitPaddle(this.leftPaddle))
                {
                    this.ball.IsMovingLeft = false;
                    this.ball.ChangeHorizontalSpeed();
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
                    this.ball.ChangeHorizontalSpeed();
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
                ConsoleManager.ClearAtCursorPosition(left: -1);

                if (key == ConsoleKey.UpArrow || key == ConsoleKey.DownArrow)
                {
                    paddleToMove = this.rightPaddle;
                }
                else if (key == ConsoleKey.W || key == ConsoleKey.S)
                {
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

        private bool NewRandomBool()
        {
            return this.random.Next(0, 2) == 0;
        }

        private int NewRandomBallY()
        {
            return this.random.Next(GlobalConstants.GridHeight / 4, GlobalConstants.GridHeight / 4 * 3);
        }
    }
}
