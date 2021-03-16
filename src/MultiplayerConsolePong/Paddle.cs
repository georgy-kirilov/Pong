namespace MultiplayerConsolePong
{
    public class Paddle
    {
        public Paddle(int x, int y, int height)
        {
            this.Height = height;
            this.X = x;
            this.Y = y;
        }

        public int Height { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public void MoveUp()
        {
            
        }
    }
}
