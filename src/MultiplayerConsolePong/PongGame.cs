namespace MultiplayerConsolePong
{
    using System;
    using System.Threading;

    public class PongGame
    {
        private Ball ball;
        private Paddle leftPaddle;
        private Paddle rightPaddle;
        private int sleepTimeMiliseconds;

        public PongGame(Ball ball, Paddle leftPaddle, Paddle rightPaddle, int framesPerSecond = 30)
        {
            this.ball = ball;
            this.leftPaddle = leftPaddle;
            this.rightPaddle = rightPaddle;
            this.sleepTimeMiliseconds = 1000 / framesPerSecond;
        }

        public void NewRound()
        {
            
        }

        public void Start()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKey key = Console.ReadKey().Key;

                    if (key == ConsoleKey.UpArrow)
                    {
                        this.rightPaddle.Clear();
                        this.rightPaddle.MoveUp();
                        rightPaddle.Print();
                    }
                    else if (key == ConsoleKey.DownArrow)
                    {
                        this.rightPaddle.Clear();
                        this.rightPaddle.MoveDown();
                        this.rightPaddle.Print();
                    }
                    else if (key == ConsoleKey.W)
                    {
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        Console.Write(" ");
                        this.leftPaddle.Clear();
                        this.leftPaddle.MoveUp();
                        this.leftPaddle.Print();

                    }
                    else if (key == ConsoleKey.S)
                    {
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        Console.Write(" ");
                        this.leftPaddle.Clear();
                        this.leftPaddle.MoveDown();
                        this.leftPaddle.Print();
                    }
                }

                this.ball.Move();

                if (this.HasBallGoneOufOfGrid(GridSide.Top) || this.HasBallGoneOufOfGrid(GridSide.Bottom))
                {
                    this.ball.IsMovingUp = !this.ball.IsMovingUp;
                }

                this.ManageBallCollisions();

                this.ball.Print();
                Thread.Sleep(this.sleepTimeMiliseconds);
                ball.Clear();
            }
        }

        private void ManageBallCollisions()
        {
            bool hasBallHitRightPaddle = this.ball.Y >= this.rightPaddle.Y && this.ball.Y <= this.rightPaddle.Y + this.rightPaddle.Height;

            if (this.ball.X == this.rightPaddle.X - 1)
            {
                if (hasBallHitRightPaddle)
                {
                    this.ball.IsMovingLeft = true;
                }
                else
                {
                    this.leftPaddle.Score++;
                }
            }

            bool hasBallHitLeftPaddle = this.ball.Y >= this.leftPaddle.Y && this.ball.Y <= this.leftPaddle.Y + this.leftPaddle.Height;

            if (this.ball.X == this.leftPaddle.X + 1)
            {
                if (hasBallHitLeftPaddle)
                {
                    this.ball.IsMovingLeft = false;
                }
                else
                {
                    this.rightPaddle.Score++;
                }
            }
        }

        private bool HasBallGoneOufOfGrid(GridSide gridSide)
        {
            switch (gridSide)
            {
                case GridSide.Top:
                    return this.ball.Y <= 0;

                case GridSide.Right:
                    return this.ball.X >= GlobalConstants.GridWidth - 2;

                case GridSide.Bottom:
                    return this.ball.Y >= GlobalConstants.GridHeight - 1;

                case GridSide.Left:
                    return this.ball.X < 1;

                default:
                    throw new NotSupportedException("Unsupported grid side");
            }
        }
    }
}
