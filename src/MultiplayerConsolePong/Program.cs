namespace MultiplayerConsolePong
{
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

            var ball = new Ball(x: GlobalConstants.GridWidth / 2,
                                y: GlobalConstants.GridHeight / 2,
                                speedX: 2,
                                speedY: 1,
                                isMovingLeft: true,
                                isMovingUp: false);

            var leftPaddle = new Paddle(x: 0,
                                        y: GlobalConstants.InitialPaddleY,
                                        height: GlobalConstants.PaddleHeight);

            var rightPaddle = new Paddle(x: GlobalConstants.GridWidth - 1,
                                         y: GlobalConstants.InitialPaddleY, 
                                         height: GlobalConstants.PaddleHeight);

            var pongGame = new PongGame(ball, leftPaddle, rightPaddle);
            pongGame.Start();
        }
    }
}
