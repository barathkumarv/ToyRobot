using System;
namespace ToySimulation
{
    static class Simulation
    {
    
        const string description = @"   Places the toy robot on a 6x6 square tabletop using following commands -
   PLACE  -  PLACE X,Y,F (Where X and Y are integers and F must be either NORTH, SOUTH, EAST or WEST)
   LEFT   – turns the toy 90 degrees to the left.
   RIGHT  – turns the toy 90 degrees to the right.
   MOVE   – Moves the toy 1 unit in the facing direction.
   REPORT – Shows the current position and direction of the robot.";
       

        /// <summary>
        /// Starts the simulation and outputs the rules to the console.
        /// </summary>
        public static void Start()
        {
            Console.WriteLine("------------Welcome----------------------------------------------------------------------------------\n");
            Console.WriteLine("Commands: ");
            Console.WriteLine(description);
            Console.WriteLine("------------------------------------------------------------------------------------------------------\n");
        }
    }
}
