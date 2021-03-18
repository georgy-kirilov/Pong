namespace MultiplayerConsolePong
{
    public class Paddle
    {
        private const int DefaultVerticalSpeed = 2;

        public Paddle(int x, int y = GlobalConstants.PaddleY, int height = GlobalConstants.PaddleHeight)
        {
            this.X = x;
            this.TopY = y;
            this.Height = height;
            this.Score = 0;
            this.VerticalSpeed = DefaultVerticalSpeed;
        }

        public int Height { get; set; }

        public int X { get; set; }

        public int TopY { get; set; }

        public int BottomY => this.TopY + this.Height;

        public int Score { get; set; }

        public int VerticalSpeed { get; set; }

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

            if (this.BottomY >= GlobalConstants.GridHeight)
            {
                this.TopY = GlobalConstants.GridHeight - this.Height - 1;
            }
        }

        public void ResetVerticalPosition()
        {
            this.TopY = GlobalConstants.PaddleY;
        }

        public bool HasHitBall(Ball ball)
        {
            return ball.Y >= this.TopY - 1 && ball.Y <= this.BottomY + 1;
        }

        public void Print()
        {
            for (int row = this.TopY; row <= this.BottomY; row++)
            {
                ConsoleManager.WriteAt(this.X, row, GlobalConstants.PaddleSymbol, GlobalConstants.PaddleColor);
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
