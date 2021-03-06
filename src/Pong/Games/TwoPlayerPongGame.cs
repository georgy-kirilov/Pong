namespace Pong.Games
{
    using Pong.Common;
    using Pong.Models;

    public class TwoPlayerPongGame : PongGame
    {
        public TwoPlayerPongGame(
                Paddle leftPaddle,
                Paddle rightPaddle,
                Ball ball, 
                int roundsToWinCount = GlobalConstants.Gameplay.RoundsToWinCount, 
                int framesPerSecond = GlobalConstants.Gameplay.FramesPerSecond) 
            : base(leftPaddle, rightPaddle, ball, roundsToWinCount, framesPerSecond)
        {
        }
    }
}
