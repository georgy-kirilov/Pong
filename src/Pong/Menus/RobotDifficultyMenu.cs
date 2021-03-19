namespace Pong.Menus
{
    using Pong.Enums;

    public class RobotDifficultyMenu : Menu<RobotDifficultyOption>
    {
        public static RobotDifficultyOption New()
        {
            return new RobotDifficultyMenu().Display();
        }

        private const string RobotDifficultyMenuTitle = "CHOOSE BOT DIFFICULTY";

        private static readonly string[] RobotDifficultyOptions = new string[]
        {
            "Beginner",
            "Intermediate",
            "Expert"
        };

        public RobotDifficultyMenu() : base(RobotDifficultyMenuTitle)
        {
            this.Options = RobotDifficultyOptions;
        }

        public override RobotDifficultyOption Display()
        {
            return (RobotDifficultyOption)this.ParseInputOptionIndex();
        }
    }
}
