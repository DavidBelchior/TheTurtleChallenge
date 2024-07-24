using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTurtleChallenge
{
    /// <summary>
    /// Represents a sequence of moves.
    /// </summary>
    public class MoveSequence
    {
        private static readonly HashSet<char> ValidMoves = new HashSet<char> { 'm', 'r' };
        
        public List<char> Moves { get; }

        public MoveSequence(List<char> moves) 
        {
            Moves = moves ?? throw new ArgumentNullException(nameof(moves));
            ValidateMoves();
        }

        /// <summary>
        /// Loads a move sequence from a JSON file.
        /// </summary>
        /// <param name="filePath"> the path of the file that contains the movement sequences </param>
        /// <returns> the sequence of movements </returns>
        public static List<MoveSequence> LoadFromFile(string filePath)
        {
            ValidateFilePath(filePath);
            string fileContent = ReadFileContent(filePath);
            var sequences = DeserializeSequences(fileContent);
            sequences.ForEach(sequence => sequence.ValidateMoves());
            return sequences;
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
                throw new ArgumentException("File path cannot be null or empty", nameof(filePath));

            if (!File.Exists(filePath))
                throw new FileNotFoundException("The specified file was not found", filePath);
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
                throw new InvalidOperationException("The file content is empty.");
            return content;
        }

        /// <summary>
        /// Deserializes the content of a file into a list of move sequences.
        /// </summary>
        /// <param name="fileContent"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        private static List<MoveSequence> DeserializeSequences(string fileContent)
        {
            try
            {
                var sequences = JsonConvert.DeserializeObject<List<MoveSequence>>(fileContent);
                if (sequences == null)
                    throw new InvalidOperationException("The file content could not be deserialized into a list of MoveSequence.");
                return sequences;
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException("The file content is not a valid JSON.", ex);
            }
        }

        /// <summary>
        /// Validates the moves in the sequence.
        /// </summary>
        private void ValidateMoves()
        {
            if (Moves == null || Moves.Count == 0)
                throw new InvalidOperationException("Move sequence cannot be null or empty.");

            if (Moves.Any(move => !ValidMoves.Contains(move)))
                throw new InvalidOperationException($"Invalid moves detected in the sequence. Allowed moves are 'm' and 'r'.");
        }
    }
}
