using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTurtleChallenge
{
    /// <summary>
    /// Represents a turtle that can move around a board.
    /// </summary>
    public class Turtle
    {
        public Point Position { get; set; }
        public Direction Direction { get; set; }

        [JsonConstructor]
        public Turtle(Point position, Direction startDirection)
        {
            Position = position;
            Direction = startDirection;
        }

        /// <summary>
        /// Moves the turtle in the direction it is facing.
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public void Move()
        {
            Position = Direction switch
            {
                Direction.North => new Point(Position.X, Position.Y - 1),
                Direction.East => new Point(Position.X + 1, Position.Y),
                Direction.South => new Point(Position.X, Position.Y + 1),
                Direction.West => new Point(Position.X - 1, Position.Y),
                _ => throw new InvalidOperationException("Invalid direction")
            };
        }

        /// <summary>
        /// Moves the turtle 90 degrees to the right.
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public void Rotate()
        {
            Direction = Direction switch
            {
                Direction.North => Direction.East,
                Direction.East => Direction.South,
                Direction.South => Direction.West,
                Direction.West => Direction.North,
                _ => throw new InvalidOperationException("Invalid direction")
            };
      
        }
    }
}
