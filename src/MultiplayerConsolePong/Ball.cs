using System;

namespace MultiplayerConsolePong
{
    public class Ball
    {
        private readonly Random random = new Random();

        public Ball(int x = GlobalConstants.BallX,
                    int y = GlobalConstants.BallY,
                    int speedX = GlobalConstants.BallDefaultHorizontalSpeed,
                    int speedY = GlobalConstants.BallDefaultVerticalSpeed,
                    int leftMostX = GlobalConstants.LeftPaddleX + 1,
                    int rightMostX = GlobalConstants.RightPaddleX - 1,
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

        public void ChangeHorizontalSpeed()
        {
            this.SpeedX = this.random.Next(GlobalConstants.BallDefaultHorizontalSpeed, 4);
        }

        public void Move()
        {
            this.X += this.IsMovingLeft ? -this.SpeedX : this.SpeedX;

            if (this.X <= this.LeftMostX)
            {
                this.X = this.LeftMostX;
            }

            if (this.X >= this.RightMostX)
            {
                this.X = this.RightMostX;
            }

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
