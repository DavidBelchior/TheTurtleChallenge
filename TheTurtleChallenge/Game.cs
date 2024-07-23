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
        private readonly GameSettings _settings; // The settings for the game.
        private readonly ILogger _logger; // The logger for the game.

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
                if (move == 'm') 
                {
                    turtle.Move();
                }
                else if (move == 'r')
                {
                    turtle.Rotate();
                }

                if (_settings.Board.IsOutOfBounds(turtle.Position))
                {
                    return MoveResult.OutOfBounds;
                }

                if (_settings.Board.IsMine(turtle.Position))
                {
                    
                    return MoveResult.MineHit;
                    
                }

                if (_settings.Board.IsExit(turtle.Position))
                {
                    
                    return MoveResult.Success;
                    
                }
            }
            return MoveResult.StillInDanger;
        }


        /// <summary>
        /// Allows you to play different sequences
        /// </summary>
        /// <param name="sequences"> list of sequences to be played </param>
        public void Play(List<MoveSequence> sequences)
        {
            foreach(var sequence in sequences)
            {
                var result = PlaySequence(sequence);
                _logger.Log(result.ToString());
            }
        }
    }
}
