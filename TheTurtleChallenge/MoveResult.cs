using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTurtleChallenge
{
    /// <summary>
    /// Represents the result of a move.
    /// </summary>
    public enum MoveResult
    {
        Success,
        MineHit,
        StillInDanger,
        OutOfBounds,
    }
}
