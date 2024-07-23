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
        public List<char> Moves { get; } // The moves in the sequence.

        public MoveSequence(List<char> moves) 
        {
            Moves = moves;
        }

        /// <summary>
        /// Loads a move sequence from a JSON file.
        /// </summary>
        /// <param name="filePath"> the path of the file that contains the movement sequences </param>
        /// <returns> the sequence of movements </returns>
        public static List<MoveSequence> LoadFromFile(string filePath)
        {
            return JsonConvert.DeserializeObject<List<MoveSequence>>(File.ReadAllText(filePath));
        }
    }
}
