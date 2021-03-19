namespace MultiplayerConsolePong.Models
{
    using System;

    public class Paddle
    {
        public Paddle(int x, ConsoleKey moveUpKey, ConsoleKey moveDownKey) 
            : this(x, GlobalConstants.Paddles.InitialY, GlobalConstants.Paddles.Height, moveUpKey, moveDownKey)
        {
        }

        public Paddle(int x, int y, int height, ConsoleKey moveUpKey, ConsoleKey moveDownKey)
        {
            this.X = x;
            this.TopY = y;
            this.Height = height;
            this.Score = 0;
            this.VerticalSpeed = GlobalConstants.Paddles.SpeedY;
            this.MoveUpKey = moveUpKey;
            this.MoveDownKey = moveDownKey;
        }

        public int Height { get; set; }

        public int X { get; set; }

        public int TopY { get; set; }

        public int BottomY => this.TopY + this.Height;

        public int Score { get; set; }

        public int VerticalSpeed { get; set; }

        public ConsoleKey MoveUpKey { get; }

        public ConsoleKey MoveDownKey { get; }

        public void MoveUp()
        {
            this.TopY -= this.VerticalSpeed;

            if (this.TopY < 0)
            {
                this.TopY = 0;
            }
        }

        public void MoveDown()
        {
            this.TopY += this.VerticalSpeed;

            if (this.BottomY >= GlobalConstants.Grid.Height)
            {
                this.TopY = GlobalConstants.Grid.Height - this.Height - 1;
            }
        }

        public void ResetVerticalPosition()
        {
            this.TopY = GlobalConstants.Paddles.InitialY;
        }

        public bool HasHitBall(Ball ball)
        {
            return ball.Y >= this.TopY - 1 && ball.Y <= this.BottomY + 1;
        }

        public void Print()
        {
            for (int row = this.TopY; row <= this.BottomY; row++)
            {
                ConsoleManager.WriteAt(this.X, row, GlobalConstants.Paddles.Symbol, GlobalConstants.Paddles.BackgroundColor);
            }
        }

        public void Clear()
        {
            for (int row = this.TopY; row <= this.BottomY; row++)
            {
                ConsoleManager.ClearAt(this.X, row);
            }
        }
    }
}
