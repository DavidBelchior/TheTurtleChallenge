using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTurtleChallenge
{
    /// <summary>
    /// Represents the game board.
    /// </summary>
    public class GameBoard
    {
        public int Width { get; set; }
        public int Height { get; set; }

        [JsonProperty("ExitPoint")]
        public Point ExitPoint { get; set; }

        [JsonProperty("Mines")]
        public HashSet<Point> Mines { get; }

        [JsonConstructor]
        public GameBoard(int width, int height, Point exitPoint, HashSet<Point> mines)
        {
            Width = width;
            Height = height;
            ExitPoint = exitPoint;
            Mines = mines;
        }

        /// <summary>
        /// Checks if the position have a mine.
        /// </summary>
        /// <param name="position"></param>
        /// <returns> true if the position matches that of the mine, otherwise false </returns>
        public bool IsMine(Point position)
        {
            return Mines.Contains(position);
        }

        /// <summary>
        /// Checks if the position is the exit.
        /// </summary>
        /// <param name="position"></param>
        /// <returns> true if the position matches that of the exit, otherwise false </returns>
        public bool IsExit(Point position)
        {
            return ExitPoint.Equals(position);
        }

        /// <summary>
        /// Checks if the position is out of the board.
        /// </summary>
        /// <param name="position"></param>
        /// <returns> true if the position is outside the board otherwise false </returns>
        public bool IsOutOfBounds(Point position)
        {
            return position.X < 0 || position.X >= Width || position.Y < 0 || position.Y >= Height;
        }

    }
}
