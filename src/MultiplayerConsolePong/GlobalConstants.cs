﻿namespace MultiplayerConsolePong
{
    using System;

    public static class GlobalConstants
    {
        // Grid
        public const int GridHeight = 28;
        public const int GridWidth = 100;
        public const int GridScoreY = 1;
        public const char GridMarkingSymbol = ' ';
        public const ConsoleColor GridMarkingColor = ConsoleColor.White;

        // Ball
        public const char BallSymbol = '@';
        public const int BallX = GridWidth / 2;
        public const int BallY = GridHeight / 2;

        // Paddles
        public const int PaddleHeight = 6;
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
