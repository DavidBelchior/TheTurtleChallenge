using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTurtleChallenge
{
    /// <summary>
    /// Represents the settings for a game of Turtle Challenge.
    /// </summary>
    public class GameSettings
    {
        public GameBoard Board { get; }
        public Turtle Turtle { get; }

        [JsonConstructor]
        public GameSettings(GameBoard board, Turtle turtle)
        {
            this.Board = board;
            this.Turtle = turtle;
        }

        /// <summary>
        /// Loads game settings from a JSON file.
        /// </summary>
        /// <param name="filePath"> path to the file containing the settings </param>
        /// <returns> returns game settings </returns>
        public static GameSettings LoadFromFile(string filePath)
        {
            return JsonConvert.DeserializeObject<GameSettings>(File.ReadAllText(filePath));
        }
    }
}
