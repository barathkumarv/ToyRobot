using ToyRobot.ToySimulation;
namespace ToySimulation
{
    class Board : IValidator
    {
       
        public int rows = 0;
        public int columns = 0;
       

        /// <summary>
        /// Constructor which takes in the width and height of the board.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Board(int x, int y)
        {
            rows = x;
            columns = y;
        }

        /// <summary>
        /// This method checks if the robot is within the boundaries of the boards width and height. 
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public bool ValidatePosition(Robot position)
        {
            return position.x < rows && position.x >= 0 &&
                 position.y < columns && position.y >= 0;
        }
    }
}
