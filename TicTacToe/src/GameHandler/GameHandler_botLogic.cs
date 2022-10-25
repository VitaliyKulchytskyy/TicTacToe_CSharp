using System.Diagnostics.CodeAnalysis;

namespace TicTacToe;

public sealed partial class GameHandler
{
    private Stack<(Int16 Row, Int16 Column)> _patternFirstSteps;

    private void PatternFirstStepsInitialize()
    {
        _patternFirstSteps = new Stack<(Int16 Row, Int16 Column)>();
        _patternFirstSteps.Push((2, 2));
        _patternFirstSteps.Push((0, 0));
        _patternFirstSteps.Push((0, 2));
        _patternFirstSteps.Push((2, 0));
    }
    
    private (Int16, Int16) GetRandomCell()
    {
        (Int16 Row, Int16 Column) output;

        do
            output = ((Int16)(new Random().Next(0, 3)), (Int16)(new Random().Next(0, 3)));
        while (_playground.IsCellOccupied(output.Row, output.Column));

        return output;
    }

    private (Int16, Int16)? CalcNextWinMove(Player player)
    {
        var outputNull = WinTemplate.GetNextWinCell(new Grid(_playground), player.TypeOfStep);
        return outputNull ?? null;
    }
    
    private (Int16, Int16) CalcComplexStep()
    {
        (Int16, Int16) output = GetRandomCell();
        if (_playground.DoneSteps >= 3)
        {
            var preventPlayerWin = CalcNextWinMove(_players[0]);
            if (preventPlayerWin != null)
                return ((Int16, Int16))preventPlayerWin;
            
            var botWinMove = CalcNextWinMove(_players[1]);
            if (botWinMove != null)
                return ((Int16, Int16))botWinMove;
        }

        while (_patternFirstSteps.Count > 0)
        {
            if (!_playground.IsCellOccupied(_patternFirstSteps.Peek().Row, _patternFirstSteps.Peek().Column))
            {
                output = _patternFirstSteps.Pop();
                break;
            }
            _patternFirstSteps.Pop();
        }

        return output;
    }

    private (Int16 Row, Int16 Column) GetNextMove()
    {
        switch ((_players[1] as Bot)!.HardLevel)
        {
            case BotHardLevel.HLVL_EASY:
                return GetRandomCell();
            case BotHardLevel.HLVL_MID:
                return CalcComplexStep();
        }
        
        return (0, 0);
    }

}