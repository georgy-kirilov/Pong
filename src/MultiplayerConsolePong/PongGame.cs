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
        public int RoundsToWinCount { get; }

        public PongGame(Ball ball, Paddle leftPaddle, Paddle rightPaddle, int roundsToWinCount = 5, int framesPerSecond = 30)
        {
            this.ball = ball;
            this.leftPaddle = leftPaddle;
            this.rightPaddle = rightPaddle;
            this.sleepTimeMiliseconds = 1000 / framesPerSecond;
            this.RoundsToWinCount = roundsToWinCount;
        }

        public void NewRound()
        {
            bool gameOver = false;

            this.ball = new Ball(x: GlobalConstants.GridWidth / 2,
                                y: GlobalConstants.GridHeight / 2,
                                speedX: 2,
                                speedY: 1,
                                isMovingLeft: true,
                                isMovingUp: false);

            this.leftPaddle = new Paddle(x: 1,
                                        y: GlobalConstants.InitialPaddleY,
                                        height: GlobalConstants.PaddleHeight);

            this.rightPaddle = new Paddle(x: GlobalConstants.GridWidth - 1,
                                         y: GlobalConstants.InitialPaddleY,
                                         height: GlobalConstants.PaddleHeight);

            while (!gameOver)
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
                        ConsoleManager.ClearAtCursorPosition(-1);
                        this.leftPaddle.Clear();
                        this.leftPaddle.MoveUp();
                        this.leftPaddle.Print();

                    }
                    else if (key == ConsoleKey.S)
                    {
                        ConsoleManager.ClearAtCursorPosition(-1);
                        this.leftPaddle.Clear();
                        this.leftPaddle.MoveDown();
                        this.leftPaddle.Print();
                    }
                }

                this.ball.Move();

                if (this.ball.IsMovingLeft && this.ball.X == this.leftPaddle.X + 1)
                {
                    if (this.ball.Y >= this.leftPaddle.Y && this.ball.Y <= this.leftPaddle.Y + this.leftPaddle.Height)
                    {
                        this.ball.IsMovingLeft = false;
                    }
                    else
                    {
                        this.rightPaddle.Score++;
                        gameOver = true;
                    }
                }

                if (!this.ball.IsMovingLeft && this.ball.X == this.rightPaddle.X - 1)
                {
                    if (this.ball.Y >= this.rightPaddle.Y && this.ball.Y <= this.rightPaddle.Y + this.rightPaddle.Height)
                    {
                        this.ball.IsMovingLeft = true;
                    }
                    else
                    {
                        this.leftPaddle.Score++;
                        gameOver = true;
                    }
                }

                this.ball.Draw();
                string scoreAsText = $"{this.leftPaddle.Score} : {this.rightPaddle.Score}";
                ConsoleManager.WriteAt(GlobalConstants.GridWidth / 2 - scoreAsText.Length / 2, 1, scoreAsText);
                this.DrawGridMarking();
                Thread.Sleep(30);
                this.ball.Clear();
            }

            Console.Clear();
        }

        public void Start()
        {
            while (this.leftPaddle.Score < this.RoundsToWinCount && this.rightPaddle.Score < this.RoundsToWinCount)
            {
                this.NewRound();
            }
        }

        private void DrawGridMarking()
        {
            int column = GlobalConstants.GridWidth / 2;
            for (int row = 3; row < GlobalConstants.GridHeight; row += 3)
            {
                Console.BackgroundColor = ConsoleColor.White;
                ConsoleManager.WriteAt(column, row, " ");
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }
    }
}
