using System;
using System.Collections.Generic;
using System.Text;
using RobotSimulator.Command;
using Xunit;

namespace RobotSimulator.Tests
{
    public class TestCommandFactory
    {
        private CommandFactory commandFactory { get; set; }
        public TestCommandFactory()
        {
            commandFactory = new CommandFactory();
        }

        [Fact]
        public void TestGetPlaceCommand()
        {
            //arrange
            ICommand expected = new PlaceCommand();
            string optionalParameters = "1,2,WEST";
            //act
            ICommand actual = commandFactory.Create(CommandNames.Place, optionalParameters);
            //assert
            Assert.Equal(expected.GetType(), actual.GetType());
        }

        [Fact]
        public void TestGetLeftCommand()
        {
            //arrange
            ICommand expected = new LeftCommand();
            //act
            ICommand actual = commandFactory.Create(CommandNames.Left);
            //assert
            Assert.Equal(expected.GetType(), actual.GetType());
        }

        [Fact]
        public void TestGetRightCommand()
        {
            //arrange
            ICommand expected = new RightCommand();
            //act
            ICommand actual = commandFactory.Create(CommandNames.Right);
            //assert
            Assert.Equal(expected.GetType(), actual.GetType());
        }

        [Fact]
        public void TestGetMoveCommand()
        {
            //arrange
            ICommand expected = new MoveCommand();
            //act
            ICommand actual = commandFactory.Create(CommandNames.Move);
            //assert
            Assert.Equal(expected.GetType(), actual.GetType());
        }

        [Fact]
        public void TestGetReportCommand()
        {
            //arrange
            ICommand expected = new ReportCommand();
            //act
            ICommand actual = commandFactory.Create(CommandNames.Report);
            //assert
            Assert.Equal(expected.GetType(), actual.GetType());
        }

        [Fact]
        public void TestThrowsCommandIfNotFound()
        {
            //arrange
            //act
            //assert
            Assert.Throws<Exception>(() => commandFactory.Create((CommandNames)100));
        }
    }
}
