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
            ValidateFilePath(filePath);
            string jsonContent = ReadFileContent(filePath);
            return DeserializeSettings(jsonContent);
        }

        /// <summary>
        /// Validates the file path.
        /// </summary>
        /// <param name="filePath"></param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="FileNotFoundException"></exception>
        private static void ValidateFilePath(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentException("File path cannot be null or empty.", nameof(filePath));

            if (!File.Exists(filePath))
                throw new FileNotFoundException("The settings file was not found.", filePath);
        }

        /// <summary>
        /// Reads the content of a file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        private static string ReadFileContent(string filePath)
        {
            string content = File.ReadAllText(filePath);
            if (string.IsNullOrEmpty(content))
                throw new InvalidOperationException("The settings file is empty.");

            return content;
        }

        /// <summary>
        /// Deserializes game settings from a JSON string.
        /// </summary>
        /// <param name="jsonContent"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        private static GameSettings DeserializeSettings(string jsonContent)
        {
            try
            {
                var settings = JsonConvert.DeserializeObject<GameSettings>(jsonContent);
                if (settings?.Board == null || settings?.Turtle == null)
                    throw new InvalidOperationException("Deserialized board or turtle cannot be null.");

                return settings;
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException("Failed to deserialize the settings file.", ex);
            }
        }
    }
}
