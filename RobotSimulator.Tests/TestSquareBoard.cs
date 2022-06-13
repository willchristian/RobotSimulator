using Xunit;
using RobotSimulator.Board;
using RobotSimulator.Toy;

namespace RobotSimulator.Tests
{
    public class TestSquareBoard
    {
        [Fact]
        public void TestCreateWithCorrectRowsAndColumns()
        {
            //arrange
            SquareBoard squareBoard = new SquareBoard(5);
            //act
            int expectedRows = 5;
            int expectedColumns = 5;
            //assert
            Assert.Equal(expectedRows, squareBoard.Rows);
            Assert.Equal(expectedColumns, squareBoard.Columns);
        }

        [Theory]
        [InlineData(-1, false)]
        [InlineData(1, true)]
        [InlineData(5, false)]
        [InlineData(0, true)]
        [InlineData(4, true)]
        public void TestXBounds(int xPosition, bool expected)
        {
            //arrange
            SquareBoard squareBoard = new SquareBoard(5);
            Coordinate testCoordinate = new Coordinate(xPosition, 0);
            //act
            bool actual = squareBoard.IsValidBoardPosition(testCoordinate);
            //assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(-1, false)]
        [InlineData(1, true)]
        [InlineData(5, false)]
        [InlineData(0, true)]
        [InlineData(4, true)]
        public void TestYBounces(int yPosition, bool expected)
        {
            //arrange
            SquareBoard squareBoard = new SquareBoard(5);
            Coordinate testCoordinate = new Coordinate(0, yPosition);
            //act
            bool actual = squareBoard.IsValidBoardPosition(testCoordinate);
            //assert
            Assert.Equal(expected, actual);
        }
    }
}
