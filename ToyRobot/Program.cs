using System;
namespace ToySimulation
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Robot robot = new Robot(6, 6);
                string userInput = string.Empty;
                Simulation.Start();
                do
                {
                    userInput = Console.ReadLine();
                    Console.WriteLine(robot.UserCommand(userInput));
                } while (true);
            }
            catch(Exception ex)
            {
                Console.WriteLine("An exception has occurred " + ex.Message);
            }
            
        }

    }
  
}
