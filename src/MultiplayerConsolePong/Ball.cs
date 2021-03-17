namespace MultiplayerConsolePong
{
    using System;

    public class Ball
    {
        public Ball(int x, int y, int speedX, int speedY, bool isMovingLeft = true, bool isMovingUp = true)
        {
            this.X = x;
            this.Y = y;
            this.SpeedX = speedX;
            this.SpeedY = speedY;
            this.IsMovingLeft = isMovingLeft;
            this.IsMovingUp = isMovingUp;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public int SpeedX { get; private set; }

        public int SpeedY { get; private set; }

        public bool IsMovingLeft { get; set; }

        public bool IsMovingUp { get; set; }

        public void Move()
        {
            this.X += this.IsMovingLeft ? -this.SpeedX : this.SpeedX;

            if (this.X <= 1)
            {
                this.X = 1;
            }
            if (this.X >= GlobalConstants.GridWidth - 2)
            {
                this.X = GlobalConstants.GridWidth - 2;
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

        public void Draw()
        {
            ConsoleManager.WriteAt(this.X, this.Y, "@");
        }

        public void Clear()
        {
            ConsoleManager.ClearAt(this.X, this.Y);
        }
    }
}
