namespace MultiplayerConsolePong
{
    using System;

    public class Ball
    {
        private readonly Random random = new Random();

        public Ball(int x = GlobalConstants.BallX,
                    int y = GlobalConstants.BallY,
                    int speedX = GlobalConstants.BallMinSpeedX,
                    int speedY = GlobalConstants.BallMinSpeedY,
                    int leftMostX = GlobalConstants.Paddles.LeftX + 1,
                    int rightMostX = GlobalConstants.Paddles.RightX - 1,
                    bool isMovingLeft = true,
                    bool isMovingUp = true)
        {
            this.X = x;
            this.Y = y;
            this.SpeedX = speedX;
            this.SpeedY = speedY;
            this.LeftMostX = leftMostX;
            this.RightMostX = rightMostX;
            this.IsMovingLeft = isMovingLeft;
            this.IsMovingUp = isMovingUp;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public int SpeedX { get; set; }

        public int SpeedY { get; set; }

        public int LeftMostX { get; }

        public int RightMostX { get; }

        public bool IsMovingLeft { get; set; }

        public bool IsMovingUp { get; set; }

        public void ChangeSpeedX()
        {
            this.SpeedX = this.random.Next(GlobalConstants.BallMinSpeedX, GlobalConstants.BallMaxSpeedX + 1);
        }

        public void ChangeSpeedY()
        {
            this.SpeedY = this.random.Next(GlobalConstants.BallMinSpeedY, GlobalConstants.BallMaxSpeedY + 1);
        }

        public void UpdateProperties()
        {
            this.X = GlobalConstants.BallX;

            int topY = (int)(GlobalConstants.GridHeight * 0.2);
            int bottomY = (int)(GlobalConstants.GridHeight * 0.8);
            this.Y = this.random.Next(topY, bottomY);

            this.SpeedX = GlobalConstants.BallMinSpeedX;
            this.SpeedY = GlobalConstants.BallMinSpeedY;

            this.IsMovingLeft = this.random.NextDouble() >= 0.5;
            this.IsMovingUp = this.random.NextDouble() >= 0.5;
        }

        public void Move()
        {
            // Horizontally

            this.X += this.IsMovingLeft ? -this.SpeedX : this.SpeedX;

            if (this.X <= this.LeftMostX)
            {
                this.X = this.LeftMostX;
            }

            if (this.X >= this.RightMostX)
            {
                this.X = this.RightMostX;
            }

            // Vertically

            this.Y += this.IsMovingUp ? -this.SpeedY : this.SpeedY;

            if (this.Y <= 0)
            {
                this.Y = 0;
                this.IsMovingUp = false;
            }

            if (this.Y >= GlobalConstants.GridHeight - 1)
            {
                this.Y = GlobalConstants.GridHeight - 1;
                this.IsMovingUp = true;
            }
        }

        public void Print()
        {
            ConsoleManager.WriteAt(this.X, this.Y, GlobalConstants.BallSymbol);
        }

        public void Clear()
        {
            ConsoleManager.ClearAt(this.X, this.Y);
        }
    }
}
