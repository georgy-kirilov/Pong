using System;

namespace MultiplayerConsolePong
{
    public class Paddle : IPrintable
    {
        public Paddle(int x, int y, int height)
        {
            this.Height = height;
            this.Score = 0;
            this.X = x;
            this.Y = y;
            this.Offset = 2;
        }

        public int Height { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public void Print()
        {
            for (int row = this.Y; row <= this.Y + this.Height; row++)
            {
                Console.SetCursorPosition(this.X, row);
                Console.Write("H");
            }
        }

        public void Clear()
        {
            for (int row = this.Y; row <= this.Y + this.Height; row++)
            {
                Console.SetCursorPosition(this.X, row);
                Console.Write(" ");
            }
        }

        public int Score { get; set; }

        public int Offset { get; set; }

        public void MoveUp()
        {
            int offset = this.Y - this.Offset < 0 ? this.Y : this.Offset;
            this.Y -= offset;
        }

        public void MoveDown()
        {
            int offset = this.Y + this.Height + this.Offset >= GlobalConstants.GridHeight ? GlobalConstants.GridHeight - (this.Y + this.Height) - 1 : this.Offset;
            this.Y += offset;
        }
    }
}
