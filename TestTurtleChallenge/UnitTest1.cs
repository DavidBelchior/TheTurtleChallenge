using Newtonsoft.Json;
using TheTurtleChallenge;

namespace TestTurtleChallenge
{
    public class UnitTest1
    {
        [Fact]
        public void Turtle_Inicializes_Correctly()
        {

            // Arrange
            var position = new Point(0, 0);
            var turtle = new Turtle(position, Direction.North);

            // Act
            var actualPosition = turtle.Position;
            var actualDirection = turtle.Direction;

            //Assert
            Assert.Equal(position, actualPosition);
            Assert.Equal(Direction.North, actualDirection);
        }

        [Fact]
        public void GameBoard_Initializes_Correctly()
        {
            // Arrange
            var width = 5;
            var height = 4;
            var exitPoint = new Point(4, 2);
            var mines = new HashSet<Point> { new Point(1, 1), new Point(3, 1), new Point(3, 3) };
            var board = new GameBoard(width, height, exitPoint, mines);

            // Act
            var actualWidth = board.Width;
            var actualHeight = board.Height;
            var actualExitPoint = board.ExitPoint;
            var actualMines = board.Mines;

            // Assert
            Assert.Equal(width, actualWidth);
            Assert.Equal(height, actualHeight);
            Assert.Equal(exitPoint, actualExitPoint);
            Assert.Equal(mines, actualMines);
        }

        [Fact]
        public void Turtle_Moves_Forward()
        {
            // Arrange
            var turtle = new Turtle(new Point(0, 0), Direction.North);

            // Act
            turtle.Move();
            var actualPositionNorth = turtle.Position;

            turtle = new Turtle(new Point(0, 0), Direction.East);
            turtle.Move();
            var actualPositionEast = turtle.Position;

            // Assert
            Assert.Equal(new Point(0, -1), actualPositionNorth);
            Assert.Equal(new Point(1, 0), actualPositionEast);
        }

        [Fact]
        public void Turtle_Rotates_Right()
        {
            // Arrange
            var turtle = new Turtle(new Point(0, 0), Direction.North);

            // Act
            turtle.Rotate();
            var actualDirectionEast = turtle.Direction;

            turtle.Rotate();
            var actualDirectionSouth = turtle.Direction;

            // Assert
            Assert.Equal(Direction.East, actualDirectionEast);
            Assert.Equal(Direction.South, actualDirectionSouth);
        }

        [Fact]
        public void Game_Board_Checks_Position()
        {
            // Arrange
            var exitPoint = new Point(4, 2);
            var mines = new HashSet<Point> { new Point(1, 1), new Point(3, 1), new Point(3, 3) };
            var board = new GameBoard(5, 4, exitPoint, mines);

            // Act & Assert
            Assert.True(board.IsMine(new Point(1, 1)));
            Assert.False(board.IsMine(new Point(0, 0)));

            Assert.True(board.IsExit(new Point(4, 2)));
            Assert.False(board.IsExit(new Point(0, 0)));

            Assert.True(board.IsOutOfBounds(new Point(-1, 0)));
            Assert.False(board.IsOutOfBounds(new Point(2, 2)));
        }
        
        [Fact]
        public void Turtle_Processes_Move_Sequence_Out_Of_Bounds()
        {
            // Arrange
            var board = new GameBoard(5, 4, new Point(4, 2), new HashSet<Point> { new Point(1, 1), new Point(3, 1), new Point(3, 3) });
            var turtle = new Turtle(new Point(0, 0), Direction.North);
            var sequence = new MoveSequence(new List<char> { 'm', 'm', 'm', 'm'});

            // Act
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

                if (board.IsOutOfBounds(turtle.Position))
                {
                    // Assert
                    Assert.True(true);
                    return;
                }
            }
        }

        [Fact]
        public void Turtle_Processes_MoveSequence_Success()
        {
            // Arrange
            var board = new GameBoard(5, 4, new Point(4, 2), new HashSet<Point> { new Point(1, 1), new Point(3, 1), new Point(3, 3) });
            var turtle = new Turtle(new Point(0, 1), Direction.North);
            var sequence = new MoveSequence(new List<char> { 'r', 'r', 'm', 'r', 'r', 'r', 'm', 'm', 'm', 'm' });

            // Act
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

                if (board.IsOutOfBounds(turtle.Position))
                {
                    // Assert
                    Assert.True(false, "Expected to succeed but went out of bounds.");
                    return;
                }

                if (board.IsMine(turtle.Position))
                {
                    // Assert
                    Assert.True(false, "Expected to succeed but hit a mine.");
                    return;
                }

                if (board.IsExit(turtle.Position))
                {
                    // Assert
                    Assert.True(true);
                    return;
                }
            }

            // Assert
            Assert.True(false, "Expected to reach the exit but did not.");
        }

        [Fact]
        public void Turtle_Processes_MoveSequence_HitMine()
        {
            // Arrange
            var board = new GameBoard(5, 4, new Point(4, 2), new HashSet<Point> { new Point(1, 1), new Point(3, 1), new Point(3, 3) });
            var turtle = new Turtle(new Point(0, 1), Direction.North);
            var sequence = new MoveSequence(new List<char> { 'r', 'm', 'm'});

            // Act
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

                if (board.IsOutOfBounds(turtle.Position))
                {
                    // Assert
                    Assert.True(false, "Expected to hit a mine but went out of bounds.");
                    return;
                }

                if (board.IsMine(turtle.Position))
                {
                    // Assert
                    Assert.True(true);
                    return;
                }
            }

            // Assert
            Assert.True(false, "Expected to hit a mine but did not.");
        }


        [Fact]
        public void Turtle_Processes_MoveSequence_StillInDanger()
        {
            // Arrange
            var board = new GameBoard(5, 4, new Point(4, 2), new HashSet<Point> { new Point(1, 1), new Point(3, 1), new Point(3, 3) });
            var turtle = new Turtle(new Point(0, 1), Direction.North);
            var sequence = new MoveSequence(new List<char> { 'r', 'r', 'm' });

            // Act
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

                if (board.IsOutOfBounds(turtle.Position))
                {
                    // Assert
                    Assert.True(false, "Expected to be still in danger but went out of bounds.");
                    return;
                }

                if (board.IsMine(turtle.Position))
                {
                    // Assert
                    Assert.True(false, "Expected to be still in danger but hit a mine.");
                    return;
                }

                if (board.IsExit(turtle.Position))
                {
                    // Assert
                    Assert.True(false, "Expected to be still in danger but reached the exit.");
                    return;
                }
            }

            // Assert
            Assert.True(true);
        }

        [Fact]
        public void MoveSequence_Deserializes_Correctly()
        {
            // Arrange
            string json = @"[
              { ""Moves"": [ ""m"", ""m"", ""m"", ""m"" ] }, // Out of bounds
              { ""Moves"": [ ""r"", ""r"", ""m"", ""r"", ""r"", ""r"", ""m"", ""m"", ""m"", ""m""] }, // Success
              { ""Moves"": [ ""r"", ""m"", ""m"" ] }, // Hit a mine
              { ""Moves"": [ ""r"", ""r"",""m""] } // Still in danger
            ]";

            // Act
            var sequences = JsonConvert.DeserializeObject<List<MoveSequence>>(json);

            // Assert
            Assert.Equal(4, sequences.Count);
            Assert.Equal(4, sequences[0].Moves.Count);
            Assert.Equal('m', sequences[0].Moves[0]);
            Assert.Equal('r', sequences[1].Moves[0]);
        }


    }
}