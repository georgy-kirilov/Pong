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
        public const int BallMinSpeedX = 2;
        public const int BallMinSpeedY = 1;
        public const int BallMaxSpeedX = 3;
        public const int BallMaxSpeedY = 1;

        // Pong game
        public const int RoundsToWinCount = 5;
        public const int FramesPerSecond = 30;
        public const ConsoleColor ScoreColor = ConsoleColor.Green;

        public static class Paddles
        {
            public const int Height = 4;

            public const int SpeedY = 2;

            public const int LeftX = 1;
            public const int RightX = GridWidth - 1;

            public const int InitialY = GridHeight / 2 - Height / 2;
            public const char Symbol = ' ';

            public const ConsoleColor BackgroundColor = ConsoleColor.DarkYellow;

            public const ConsoleKey LeftMoveUpKey = ConsoleKey.W;
            public const ConsoleKey LeftMoveDownKey = ConsoleKey.S;

            public const ConsoleKey RightMoveUpKey = ConsoleKey.UpArrow;
            public const ConsoleKey RightMoveDownKey = ConsoleKey.DownArrow;
        }
    }
}
