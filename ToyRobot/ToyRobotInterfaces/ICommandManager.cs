namespace ToySimulation
{
    interface ICommandManager
    {
        /// <summary>
        /// This method places the robot onto the board.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        string Place(int x, int y, Direction direction);

        /// <summary>
        /// This method moves the robot one unit forward in the direction that they are facing.
        /// </summary>
        /// <returns></returns>
        string Move();

        /// <summary>
        /// This method turns the robot to the left.
        /// </summary>
        void Left();

        /// <summary>
        /// This method turns the robot to the right.
        /// </summary>
        void Right();

        /// <summary>
        /// This method prints out the current position of the robot within the grid.
        /// </summary>
        /// <returns></returns>
        string Report();

        /// <summary>
        /// This method takes in the users input for processing.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        string UserCommand(string input);
    }
}
