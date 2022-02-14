using System;
using System.Collections.Generic;
using System.Text;

namespace ToySimulation
{
    /// <summary>
    /// static class to store the constants.
    /// </summary>
    public static class Constants
    {
        public const int ParameterCount = 3;
        public const string OUT_OF_BOUNDS = "Command discarded, robot is outside of table surface.";
        public const string PLACE_FIRST = "PLACE command must be the first command.Please use PLACE X, Y, DIRECTION.";
        public const string INVALID_COMMAND = "Invalid command.";
        public const string VALID_COMMAND = "\nCommands of the following forms are all valid: \nPLACE X, Y, F \nMOVE \nLEFT \nRIGHT \nREPORT";
        
    }
}
