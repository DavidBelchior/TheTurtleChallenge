using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTurtleChallenge
{
    /// <summary>
    /// Represents the game action
    /// </summary>
    public class Game
    {
        private readonly GameSettings _settings;
        private readonly ILogger _logger;

        public Game(GameSettings settings, ILogger logger)
        {
            _settings = settings;
            _logger = logger;
        }

        /// <summary>
        ///  Execute or play a sequence 
        /// </summary>
        /// <param name="sequence"> sequence to be played </param>
        /// <returns> returns the result of the sequence </returns>
        public MoveResult PlaySequence(MoveSequence sequence)
        {
            var turtle = new Turtle(_settings.Turtle.Position, _settings.Turtle.Direction);

            foreach (var move in sequence.Moves)
            {
                ExecuteMove(turtle, move);
                var result = GetMoveResultFromPosition(turtle.Position);

                if (result != MoveResult.StillInDanger)
                {
                    return result;
                }
            }
            return MoveResult.StillInDanger;
        }

        /// <summary>
        /// Executes a move for the turtle.
        /// </summary>
        /// <param name="turtle"></param>
        /// <param name="move"></param>
        /// <exception cref="InvalidOperationException"></exception>
        private void ExecuteMove(Turtle turtle, char move)
        {
            switch (move)
            {
                case 'm':
                    turtle.Move();
                    break;
                case 'r':
                    turtle.Rotate();
                    break;
                default:
                    throw new InvalidOperationException($"Invalid move '{move}'");
            }
        }

        /// <summary>
        ///  Determines the result of the turtle's current position on the board.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        private MoveResult GetMoveResultFromPosition(Point position)
        {
            if (_settings.Board.IsOutOfBounds(position))
            {
                return MoveResult.OutOfBounds;
            }

            if (_settings.Board.IsMine(position))
            {
                return MoveResult.MineHit;
            }

            if (_settings.Board.IsExit(position))
            {
                return MoveResult.Success;
            }

            return MoveResult.StillInDanger;
        }

        /// <summary>
        /// Allows you to play different sequences
        /// </summary>
        /// <param name="sequences"> list of sequences to be played </param>
        public void Play(List<MoveSequence> sequences)
        {
            foreach (var sequence in sequences)
            {
                var result = PlaySequence(sequence);
                _logger.Log(result.ToString());
            }
        }
    }
}
