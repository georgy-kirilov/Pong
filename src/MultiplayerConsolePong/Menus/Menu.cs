namespace MultiplayerConsolePong.Menus
{
    using System;

    public abstract class Menu<T> : IMenu<T> where T : struct, IConvertible
    {
        private int selectedOptionIndex;

        protected Menu(string title, string[] options = null)
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }

            this.Title = this.FormatTitle(title);
            this.Options = options;
            this.selectedOptionIndex = 0;
        }

        public string Title { get; }

        public string[] Options { get; protected set; }

        public void Print()
        {
            ConsoleManager.ClearConsole();
            this.PrintTitle();
            this.PrintOptions();
        }

        public abstract T Display();

        protected int ParseInputOptionIndex()
        {
            this.selectedOptionIndex = 0;

            while (true)
            {
                this.Print();
                bool indexSelected = this.IsOptionIndexSelected();

                if (indexSelected)
                {
                    return this.selectedOptionIndex;
                }
            }
        }

        private void PrintTitle()
        {
            int x = GlobalConstants.Grid.Width / 2 - this.Title.Length / 2;
            int y = GlobalConstants.Grid.Height / 6;

            ConsoleManager.WriteAt(x, y, this.Title, ConsoleColor.Yellow, Console.BackgroundColor);
        }

        private void PrintOptions()
        {
            int y = GlobalConstants.Grid.Height / 3 - this.Options.Length / 4;
            int x = GlobalConstants.Grid.Width / 2;
            int index = 0;

            foreach (string option in this.Options)
            {
                var color = index == this.selectedOptionIndex ? ConsoleColor.Green : ConsoleColor.DarkYellow;
                ConsoleManager.WriteAt(x - option.Length / 2, y, option, null, color);
                y += 2;
                index++;
            }
        }

        private bool IsOptionIndexSelected()
        {
            ConsoleKey key = Console.ReadKey().Key;

            if (key == ConsoleKey.Enter)
            {
                return true;
            }
            else if (key == ConsoleKey.UpArrow || key == ConsoleKey.W)
            {
                this.selectedOptionIndex--;
            }
            else if (key == ConsoleKey.DownArrow || key == ConsoleKey.S)
            {
                this.selectedOptionIndex++;
            }

            if (this.selectedOptionIndex < 0)
            {
                this.selectedOptionIndex = this.Options.Length - 1;
            }
            else if (this.selectedOptionIndex >= this.Options.Length)
            {
                this.selectedOptionIndex = 0;
            }

            return false;
        }

        private string FormatTitle(string rawTitle)
        {
            return $" {rawTitle.ToUpper()} ";
        }
    }
}
