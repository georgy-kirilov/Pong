namespace MultiplayerConsolePong
{
    using System;

    public static class GlobalConstants
    {
        public static class Gameplay
        {
            public const int RoundsToWinCount = 5;
            public const int FramesPerSecond = 30;
            public const int PauseBetweenRoundsMilliseconds = 500;
        }

        public static class Grid
        {
            public const int Height = 26;
            public const int Width = 100;
            public const int ScoreViewY = 1;
            public const char MarkingSymbol = ' ';
            public const ConsoleColor ScoreViewColor = ConsoleColor.Green;
            public const ConsoleColor MarkingColor = ConsoleColor.White;
        }

        public static class Paddles
        {
            public const int Height = 4;

            public const int SpeedY = 2;

            public const int LeftX = 1;
            public const int RightX = Grid.Width - 1;

            public const int InitialY = Grid.Height / 2 - Height / 2;
            public const char Symbol = ' ';

            public const ConsoleColor BackgroundColor = ConsoleColor.DarkYellow;

            public const ConsoleKey LeftMoveUpKey = ConsoleKey.W;
            public const ConsoleKey LeftMoveDownKey = ConsoleKey.S;

            public const ConsoleKey RightMoveUpKey = ConsoleKey.UpArrow;
            public const ConsoleKey RightMoveDownKey = ConsoleKey.DownArrow;
        }

        public static class Ball
        {
            public const char Symbol = '@';

            public const int InitialX = Grid.Width / 2;
            public const int InitialY = Grid.Height / 2;

            public const int MinSpeedX = 2;
            public const int MinSpeedY = 1;
            public const int MaxSpeedX = 3;
            public const int MaxSpeedY = 1;
        }
    }
}
