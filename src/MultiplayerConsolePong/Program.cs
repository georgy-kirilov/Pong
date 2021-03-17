namespace MultiplayerConsolePong
{
    using System;

    public class Program
    {
        public static void Main()
        {
            ConsoleManager
                .Configure(optionsBuilder =>
                    {
                        optionsBuilder.AllowMinimizing = false;
                        optionsBuilder.AllowMaximizing = false;
                        optionsBuilder.AllowResizing = false;
                        optionsBuilder.AllowScrollbars = false;
                        optionsBuilder.IsCursorVisible = false;
                        optionsBuilder.Width = GlobalConstants.GridWidth;
                        optionsBuilder.Height = GlobalConstants.GridHeight;
                    })
                .Build();

            var leftPaddle = new Paddle(GlobalConstants.LeftPaddleX);
            var rightPaddle = new Paddle(GlobalConstants.RightPaddleX);
            var ball = new Ball();
            
            var pongGame = new PongGame(ball, leftPaddle, rightPaddle);
            pongGame.Start();
        }
    }
}
