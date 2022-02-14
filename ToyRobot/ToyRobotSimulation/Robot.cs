using System;
namespace ToySimulation
{
    public class Robot : ICommandManager
    {
       
        private Board board { get; set; }
        private bool robotPlaced = false;
        private Direction facing { get; set; }
        public int x { get; private set; }
        public int y { get; private set; }

        /// <summary>
        /// Parameterised constructor to set the size of the board.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Robot(int x, int y)
        {
            board = new Board(x, y);
        }

        /// <summary>
        /// This method places the robot onto the board.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string Place(int x, int y, Direction direction)
        {
            string result = string.Empty;

            if (!board.ValidatePosition(this))
            {
                result = Constants.OUT_OF_BOUNDS;
            }
            else
            {
                robotPlaced = true;
            }

            return result;
        }

        /// <summary>
        /// This method moves the robot one unit forward in the direction that they are facing.
        /// </summary>
        /// <returns></returns>
        public string Move()
        {
            string result = string.Empty;

           
            var xOriginal = x;
            var yOriginal = y;

            
            switch (facing)
            {
                case Direction.NORTH:
                    y++;
                    break;

                case Direction.EAST:
                    x++;
                    break;

                case Direction.WEST:
                    x--;
                    break;

                case Direction.SOUTH:
                    y--;
                    break;
            }

           
            if (!board.ValidatePosition(this))
            {
               
                x = xOriginal;
                y = yOriginal;
                result = Constants.OUT_OF_BOUNDS;
            }

            return result;
        }

        /// <summary>
        /// This method accepts user input for processing.
        /// Either places, moves or reports the robot if the commands are valid.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>string</returns>
        public string UserCommand(string input)
        {
            string output = string.Empty;
            string command = input.ToUpper();
            Direction direction;
                if (command.Contains(((Enum)Command.PLACE).ToString()))
                {
                    string[] inputs = input.Split(new[] { ',', ' ' },
                                StringSplitOptions.RemoveEmptyEntries);
                    x = Int32.Parse(inputs[1]);
                    y = Int32.Parse(inputs[2]);
                    if(inputs.Length > Constants.ParameterCount && Enum.TryParse(inputs[3].ToString(), true, out direction))
                    {
                        facing = direction;
                        output = Place(x, y, direction);
                    }
                    
                }
                else if (!robotPlaced)
                {
                output = Constants.PLACE_FIRST;
                }
                else if (command.Contains(((Enum)Command.MOVE).ToString()))
                {
                output = Move();
                }
                else if (command.Contains(((Enum)Command.LEFT).ToString()))
                {
                    Left();
                }
                else if (command.Contains(((Enum)Command.RIGHT).ToString()))
                {
                    Right();
                }
                else if (command.Contains(((Enum)Command.REPORT).ToString()))
                {
                output = Report();
                }
                else
                {
                    output = Constants.INVALID_COMMAND + Constants.VALID_COMMAND; 
                }

            return output;
        }

        /// <summary>
        /// This method turns the robot to the left.
        /// </summary>
        public void Left()
        {
            switch (facing)
            {
                case Direction.NORTH:
                    facing = Direction.WEST;
                    break;

                case Direction.EAST:
                    facing = Direction.NORTH;
                    break;

                case Direction.SOUTH:
                    facing = Direction.EAST;
                    break;

                case Direction.WEST:
                    facing = Direction.SOUTH;
                    break;
            }
        }

        /// <summary>
        /// This method turns the robot to the right.
        /// </summary>
        public void Right()
        {
            switch (facing)
            {
                case Direction.NORTH:
                    facing = Direction.EAST;
                    break;

                case Direction.EAST:
                    facing = Direction.SOUTH;
                    break;

                case Direction.SOUTH:
                    facing = Direction.WEST;
                    break;

                case Direction.WEST:
                    facing = Direction.NORTH;
                    break;
            }
        }

        /// <summary>
        /// This method announces the orientation of the robot.
        /// </summary>
        /// <returns>string</returns>
        public string Report()
        {
            return "Output: " + x + "," + y + "," + facing;
        }
    }
}
