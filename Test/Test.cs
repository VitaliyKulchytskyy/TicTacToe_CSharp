using System.Diagnostics;

namespace Test;
using TicTacToe;

public class WinChecker
{
    public class HorizontalLine
    {
        [Test]
        public void CheckWinInHorizontalLine_TypeX_0()
        {
            Grid testGrid = new Grid("XXX\nOXO\nO-O");
            bool isWin = WinTemplate.CheckPattern(testGrid, StepType.TYPE_X);
            Assert.True(isWin);
        }

        [Test]
        public void CheckWinInHorizontalLine_TypeO_1()
        {
            Grid testGrid = new Grid("OXO\nOOO\nX-X");
            bool isWin = WinTemplate.CheckPattern(testGrid, StepType.TYPE_O);
            Assert.True(isWin);
        }

        [Test]
        public void CheckWinInHorizontalLine_TypeX_2()
        {
            Grid testGrid = new Grid("OXO\nO-O\nXXX");
            bool isWin = WinTemplate.CheckPattern(testGrid, StepType.TYPE_X);
            Assert.True(isWin);
        }
    }
    
    public class VerticalLine
    {
        [Test]
        public void CheckWinInVerticalLine_TypeX_0()
        {
            Grid testGrid = new Grid("X--\nXXO\nXOO");
            bool isWin = WinTemplate.CheckPattern(testGrid, StepType.TYPE_X);
            Assert.True(isWin);
        }

        [Test]
        public void CheckWinInVerticalLine_TypeO_1()
        {
            Grid testGrid = new Grid("-OX\nXOO\nXO-");
            bool isWin = WinTemplate.CheckPattern(testGrid, StepType.TYPE_O);
            Assert.True(isWin);
        }

        [Test]
        public void CheckWinInVerticalLine_TypeX_2()
        {
            Grid testGrid = new Grid("-OX\n-OX\nO-X");
            bool isWin = WinTemplate.CheckPattern(testGrid, StepType.TYPE_X);
            Assert.True(isWin);
        }
    }
    
    public class MainDiagonal
    {
        [Test]
        public void CheckWinInVerticalLine_TypeX_0()
        {
            Grid testGrid = new Grid("X--\nXXO\n-OX");
            bool isWin = WinTemplate.CheckPattern(testGrid, StepType.TYPE_X);
            Assert.True(isWin);
        }

        [Test]
        public void CheckWinInVerticalLine_TypeO_1()
        {
            Grid testGrid = new Grid("-OO\nXOO\nOX-");
            bool isWin = WinTemplate.CheckPattern(testGrid, StepType.TYPE_O);
            Assert.True(isWin);
        }
    }
}

public class NextWinPosition
{
    public class FindExistsWinPosition
    {
        [Test]
        public void FindNextWinPosition_HorizontalLine_TypeX()
        {
            Grid testGrid = new Grid("-XX\nXOO\nOX-");
            var winPosition = WinTemplate.GetNextWinCell(testGrid, StepType.TYPE_X);
            Debug.Assert(winPosition != null, nameof(winPosition) + " != null");
            Assert.That((0, 0), Is.EqualTo(winPosition));
        }
        
        [Test]
        public void FindNextWinPosition_VerticalLine_TypeO()
        {
            Grid testGrid = new Grid("-XO\nOXO\n-X-");
            var winPosition = WinTemplate.GetNextWinCell(testGrid, StepType.TYPE_O);
            Debug.Assert(winPosition != null, nameof(winPosition) + " != null");
            Assert.That((2, 2), Is.EqualTo(winPosition));
        }
        
        [Test]
        public void FindNextWinPosition_MainDiagonal_TypeX()
        {
            Grid testGrid = new Grid("-OX\n--O\nX-O");
            var winPosition = WinTemplate.GetNextWinCell(testGrid, StepType.TYPE_X);
            Debug.Assert(winPosition != null, nameof(winPosition) + " != null");
            Assert.That((1, 1), Is.EqualTo(winPosition));
        }
    }
    
    public class FindNonExistentWinPosition
    {
        [Test]
        public void FindNextWinPosition_HorizontalLine_TypeX()
        {
            Grid testGrid = new Grid("OXX\nXOO\nOX-");
            var winPosition = WinTemplate.GetNextWinCell(testGrid, StepType.TYPE_X);
            Assert.IsNull(winPosition);
        }
        
        [Test]
        public void FindNextWinPosition_VerticalLine_TypeO()
        {
            Grid testGrid = new Grid("-O-\n-X-\n-O-");
            var winPosition = WinTemplate.GetNextWinCell(testGrid, StepType.TYPE_O);
            Assert.IsNull(winPosition);
        }
        
        [Test]
        public void FindNextWinPosition_MainDiagonal_TypeX()
        {
            Grid testGrid = new Grid("-OX\n-OO\nX-O");
            var winPosition = WinTemplate.GetNextWinCell(testGrid, StepType.TYPE_X);
            Assert.IsNull(winPosition);
        }
    }
}