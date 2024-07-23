using TheTurtleChallenge;

class Program
{
    /// <summary>
    /// The main entry point of the application.
    /// </summary>
    static void Main()
    {
        string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName; // The directory of the project.

        string gameSettingsPath = Path.Combine(projectDirectory, "game-settings.json"); // The path to the game settings file.
        string movesPath = Path.Combine(projectDirectory, "moves.json"); // The path to the moves file.

        var settings = GameSettings.LoadFromFile(gameSettingsPath); // Load the game settings.
        var sequences = MoveSequence.LoadFromFile(movesPath); // Load the move sequences.
        var logger = new ConsoleLogger(); // Create a logger.
        var game = new Game(settings, logger); // Create a game.

        game.Play(sequences); // Play the game.
    }
}