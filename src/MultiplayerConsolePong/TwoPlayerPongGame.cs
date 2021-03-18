namespace MultiplayerConsolePong
{
    public class TwoPlayerPongGame : PongGame
    {
        public TwoPlayerPongGame(Paddle leftPaddle, Paddle rightPaddle, Ball ball, 
            int roundsToWinCount = GlobalConstants.RoundsToWinCount, 
            int framesPerSecond = GlobalConstants.FramesPerSecond) 
            : base(leftPaddle, rightPaddle, ball, roundsToWinCount, framesPerSecond)
        {
        }
    }
}
