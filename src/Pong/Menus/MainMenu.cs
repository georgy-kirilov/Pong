namespace Pong.Menus
{
    using Pong.Common;
    using Pong.Enums;

    public class MainMenu : Menu<MainMenuOption>
    {
        public static MainMenuOption New()
        {
            return new MainMenu().Display();
        }

        private const string MainMenuTitle = "WELCOME TO " + GlobalConstants.Gameplay.GameTitle;

        private static readonly string[] MainMenuOptions = new string[]
        {
            "New 2 Player Game",
            "New Game Against Bot",
            "New Online Game",
            "EXIT",
        };

        public MainMenu() : base(MainMenuTitle)
        {
            this.Options = MainMenuOptions;
        }

        public override MainMenuOption Display()
        {
            return (MainMenuOption)this.ParseInputOptionIndex();
        }
    }
}
