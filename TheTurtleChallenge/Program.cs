using TheTurtleChallenge;

class Program
{
    /// <summary>
    /// The main entry point of the application.
    /// </summary>
    static void Main()
    {
        string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

        string gameSettingsPath = Path.Combine(projectDirectory, "game-settings.json");
        string movesPath = Path.Combine(projectDirectory, "moves.json");

        var settings = GameSettings.LoadFromFile(gameSettingsPath);
        var sequences = MoveSequence.LoadFromFile(movesPath);
        var logger = new ConsoleLogger();
        var game = new Game(settings, logger);

        game.Play(sequences);
    }
}