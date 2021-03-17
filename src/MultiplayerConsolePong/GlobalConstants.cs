namespace MultiplayerConsolePong
{
    using System;

    public static class GlobalConstants
    {
        // Grid
        public const int GridHeight = 26;
        public const int GridWidth = 100;
        public const int GridScoreY = 1;
        public const char GridMarkingSymbol = ' ';
        public const ConsoleColor GridMarkingColor = ConsoleColor.White;
        public const int PauseBetweenRoundsMilliseconds = 500;

        // Ball
        public const char BallSymbol = '@';
        public const int BallX = GridWidth / 2;
        public const int BallY = GridHeight / 2;
        public const int BallDefaultHorizontalSpeed = 2;
        public const int BallDefaultVerticalSpeed = 1;

        // Paddles
        public const int PaddleHeight = 4;
        public const char PaddleSymbol = ' ';
        public const ConsoleColor PaddleColor = ConsoleColor.DarkYellow;
        public const int PaddleY = GridHeight / 2 - PaddleHeight / 2;
        public const int LeftPaddleX = 1;
        public const int RightPaddleX = GridWidth - 1;

        // Pong game
        public const int RoundsToWinCount = 5;
        public const int FramesPerSecond = 30;
    }
}
