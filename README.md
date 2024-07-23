🐢 # TheTurtleChallenge


## Description
The Turtle Challenge is a simulation game where a turtle must navigate through a minefield. The program reads the initial game settings from one file and one or more sequences of moves from another file. For each move sequence, the program determines whether the turtle successfully reaches the exit point, steps on a mine, or neither.

## Features
- Reads game settings from a file.
- Reads multiple move sequences from a separate file.
- Determines the result of each move sequence:
  - Success (turtle reaches the exit point).
  -  Failure (turtle steps on a mine).
  -   Incomplete (turtle does not reach the exit point nor steps on a mine).

## Technologies Used
C#

## Example Files
- game-settings.json:
  - {
  "Board": {
    "Width": 5,
    "Height": 4,
    "ExitPoint": {
      "X": 4,
      "Y": 2
    },
    "Mines": [
      {
        "X": 1,
        "Y": 1
      },
      {
        "X": 3,
        "Y": 1
      },
      {
        "X": 3,
        "Y": 3
      }
    ]
  },
  "Turtle": {
    "Position": {
      "X": 0,
      "Y": 1
    },
    "Direction": "North"
  }
}

- moves.json:
  - [
  { "Moves": [ "m", "m", "m", "m" ] },
  { "Moves": [ "r", "r", "m", "r", "r", "r", "m", "m", "m", "m" ] },
  { "Moves": [ "r", "m", "m" ] },
  { "Moves": [ "r", "r", "m" ] }

]

### Example Output
- Sequence 1: Out of bounds
- Sequence 2: Success
- Sequence 3: Hit a mine
- Sequence 4: Still in danger


![image](https://github.com/user-attachments/assets/403a511c-a703-43a7-96b7-dc27419f516f)
  Hope that you liked! 
