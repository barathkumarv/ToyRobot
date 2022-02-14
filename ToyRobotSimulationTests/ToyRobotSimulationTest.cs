using NUnit.Framework;
using ToySimulation;
using System;

namespace ToyRobotSimulationTests
{
    public class ToyRobotTests
    {
        [Test]
        public void Robot_Place_Success()
        {
            //ARRANGE
            Robot robot = new Robot(6, 6);

            //ACT
            robot.UserCommand("PLACE 0,0,NORTH");
            var result = robot.UserCommand("REPORT");

            //ASSERT
            Assert.AreEqual("Output: 0,0,NORTH", result);
        }

        [Test]
        public void Robot_Left_Success()
        {
            //ARRANGE
            Robot robot = new Robot(6, 6);

            //ACT
            robot.UserCommand("PLACE 0,0,NORTH");
            robot.Left();
            var result = robot.UserCommand("REPORT");

            //ASSERT
            Assert.AreEqual("Output: 0,0,WEST", result);
        }

        [Test]
        public void Robot_Right_Success()
        {
            //ARRANGE
            Robot robot = new Robot(6, 6);

            //ACT
            robot.UserCommand("PLACE 0,0,NORTH");
            robot.Right();
            var result = robot.UserCommand("REPORT");

            //ASSERT
            Assert.AreEqual("Output: 0,0,EAST", result);
        }

        [Test]
        public void Robot_Move_Success()
        {
            //ARRANGE
            Robot robot = new Robot(6, 6);

            //ACT
            robot.UserCommand("PLACE 0,0,NORTH");
            robot.UserCommand("MOVE");
            string result = robot.UserCommand("REPORT");

            //ASSERT
            Assert.AreEqual("Output: 0,1,NORTH", result);
        }

        [Test]
        public void Robot_Behaviour_Turn_Left_Success()
        {
            //ARRANGE
            Robot robot = new Robot(6, 6);

            //ACT
            robot.UserCommand("PLACE 0,0,NORTH");
            robot.UserCommand("LEFT");
            string result = robot.UserCommand("REPORT");

            //ASSERT
            Assert.AreEqual("Output: 0,0,WEST", result);
        }

        [Test]
        public void Robot_Behaviour_Turn_Right_Success()
        {
            //ARRANGE
            Robot robot = new Robot(6, 6);

            //ACT
            robot.UserCommand("PLACE 1,2,EAST");
            robot.UserCommand("RIGHT");
            string result = robot.UserCommand("REPORT");

            //ASSERT
            Assert.AreEqual("Output: 1,2,SOUTH", result);
        }

        [Test]
        public void Robot_Sequential_Commands_Success()
        {
            //ARRANGE
            Robot robot = new Robot(6, 6);

            //ACT
            robot.UserCommand("PLACE 1,2,EAST");
            robot.UserCommand("MOVE");
            robot.UserCommand("MOVE");
            robot.UserCommand("LEFT");
            robot.UserCommand("MOVE");
            string result = robot.UserCommand("REPORT");

            //ASSERT
            Assert.AreEqual("Output: 3,3,NORTH", result);
        }

        [Test]
        public void Robot_Sequential_Commands_Without_Direction_Success()
        {
            //ARRANGE
            Robot robot = new Robot(6, 6);

            //ACT
            robot.UserCommand("PLACE 1,2,EAST");
            robot.UserCommand("MOVE");
            robot.UserCommand("LEFT");
            robot.UserCommand("MOVE");
            robot.UserCommand("PLACE 3,1");
            robot.UserCommand("MOVE");
            string result = robot.UserCommand("REPORT");

            //ASSERT
            Assert.AreEqual("Output: 3,2,NORTH", result);
        }

        [Test]
        public void Robot_Move_Out_Of_Grid_Failure()
        {
            //ARRANGE
            Robot robot = new Robot(6, 6);

            //ACT
            robot.UserCommand("PLACE 5,5,NORTH");
            var result = robot.UserCommand("MOVE");

            //ASSERT
            Assert.AreEqual(Constants.OUT_OF_BOUNDS, result);
        }

        [Test]
        public void Robot_Place_Out_Of_Grid_Failure()
        {
            //ARRANGE
            Robot robot = new Robot(6, 6);

            //ACT
            string result = robot.UserCommand("PLACE 12,13,WEST");

            //ASSERT
            Assert.AreEqual(Constants.OUT_OF_BOUNDS, result);
        }

        [Test]
        public void Robot_Invalid_First_Command()
        {
            //ARRANGE
            Robot robot = new Robot(6, 6);

            //ACT
            string result = robot.UserCommand("MOVE 12,13,WEST");

            //ASSERT
            Assert.AreEqual(Constants.PLACE_FIRST, result);
        }

        [Test]
        public void Robot_Invalid_Command()
        {
            //ARRANGE
            Robot robot = new Robot(6, 6);

            //ACT
            robot.UserCommand("PLACE 1,1,WEST");
            var result = robot.UserCommand("MOVE 1,1,WEST");

            //ASSERT
            Assert.AreEqual(string.Empty, result);
        }
    }
}