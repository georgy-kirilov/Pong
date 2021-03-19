namespace Pong.Menus
{
    using Pong.Enums;

    public class PlayerPaddleSideMenu : Menu<PaddleSideOption>
    {
        public static PaddleSideOption New()
        {
            return new PlayerPaddleSideMenu().Display();
        }

        private const string MenuTitle = "CHOOSE YOUR SIDE";

        private static readonly string[] MenuOptions = new string[]
        {
            "LEFT",
            "RIGHT",
        };

        public PlayerPaddleSideMenu() : base(MenuTitle)
        {
            this.Options = MenuOptions;
        }

        public override PaddleSideOption Display()
        {
            return (PaddleSideOption)this.ParseInputOptionIndex();
        }
    }
}
