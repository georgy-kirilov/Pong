namespace MultiplayerConsolePong
{
    using System;

    public class Ball : IPrintable
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

        public int X { get; private set; }

        public int Y { get; private set; }

        public int SpeedX { get; private set; }

        public int SpeedY { get; private set; }

        public bool IsMovingLeft { get; set; }

        public bool IsMovingUp { get; set; }

        public void Move()
        {
            if (this.IsMovingLeft)
            {
                if (this.X - this.SpeedX < 1)
                {
                    this.X -= this.X - 1;
                    this.IsMovingLeft = false;
                }
                else
                {
                    this.X -= this.SpeedX;
                }
            }
            else
            {
                if (this.X + this.SpeedX >= GlobalConstants.GridWidth - 1)
                {
                    this.X += GlobalConstants.GridWidth - this.X - 2;
                    this.IsMovingLeft = true;
                }
                else
                {
                    this.X += this.SpeedX;
                }
            }

            if (this.IsMovingUp)
            {
                this.Y -= this.SpeedY;
            }
            else
            {
                this.Y += this.SpeedY;
            }
        }

        public void Print()
        {
            Console.SetCursorPosition(this.X, this.Y);
            Console.Write("@");
        }

        public void Clear()
        {
            Console.SetCursorPosition(this.X, this.Y);
            Console.Write(" ");
        }
    }
}
