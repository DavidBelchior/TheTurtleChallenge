using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTurtleChallenge
{
    /// <summary>
    /// Represents a point in a grid.
    /// </summary>
    public class Point
    {
        public int X { get; set; } // The x-coordinate of the point.
        public int Y { get; set; } // The y-coordinate of the point.

        public Point() { }

        [JsonConstructor]
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Checks if the point is equal to another point.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns> true if the points are equal otherwise false </returns>
        public override bool Equals(object obj)
        {
            if (obj is Point other)
            {
                return X == other.X && Y == other.Y;
            }
            return false;
        }

        /// <summary>
        /// Gets the hash code of the point.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
    }
}

