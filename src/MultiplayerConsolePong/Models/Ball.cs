namespace MultiplayerConsolePong.Models
{
    using System;

    public class Ball
    {
        private readonly Random random = new Random();

        public Ball(int x = GlobalConstants.Ball.InitialX,
                    int y = GlobalConstants.Ball.InitialY,
                    int speedX = GlobalConstants.Ball.MinSpeedX,
                    int speedY = GlobalConstants.Ball.MinSpeedY,
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
            this.SpeedX = this.random.Next(GlobalConstants.Ball.MinSpeedX, GlobalConstants.Ball.MaxSpeedX + 1);
        }

        public void ChangeSpeedY()
        {
            this.SpeedY = this.random.Next(GlobalConstants.Ball.MinSpeedY, GlobalConstants.Ball.MaxSpeedY + 1);
        }

        public void UpdateProperties()
        {
            this.X = GlobalConstants.Ball.InitialX;

            int topY = (int)(GlobalConstants.Grid.Height * 0.2);
            int bottomY = (int)(GlobalConstants.Grid.Height * 0.8);
            this.Y = this.random.Next(topY, bottomY);

            this.SpeedX = GlobalConstants.Ball.MinSpeedX;
            this.SpeedY = GlobalConstants.Ball.MinSpeedY;

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

            if (this.Y >= GlobalConstants.Grid.Height - 1)
            {
                this.Y = GlobalConstants.Grid.Height - 1;
                this.IsMovingUp = true;
            }
        }

        public void Print()
        {
            ConsoleManager.WriteAt(this.X, this.Y, GlobalConstants.Ball.Symbol);
        }

        public void Clear()
        {
            ConsoleManager.ClearAt(this.X, this.Y);
        }
    }
}
