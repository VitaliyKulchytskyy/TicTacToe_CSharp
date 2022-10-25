namespace TicTacToe;

public sealed partial class GameHandler
{
    private Int16 _matchCount;
    
    private void PrepareToGame()
    {
        _players[0] = GetFirstPlayerData();
        _players[1] = GetOpponentPlayerData();
        _matchCount = 0;
    }

    private void PrintPlayersScore()
    {
        Console.WriteLine('\n' + new String('=', 40));
        Console.WriteLine($"{_players[0]}\n{_players[1]}\n{new string('-', 40)}\nMatches played: {_matchCount}");
        Console.WriteLine(new String('=', 40));
    }
    
    private void DoSafeStep(Player movingPlayer)
    {
        while (true)
        {
            try
            {
                Console.Write("Enter the coordinate of next step: ");
                Int16[] data = Console.ReadLine().Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(n => Int16.Parse(n)).ToArray();
                _playground.DoStep(data[0], data[1], movingPlayer);
                return;
            }
            catch (Exception ex)
            {
                string message = ex switch
                {
                    FormatException or IndexOutOfRangeException => "[!] Inputting error.",
                    _ => ex.Message
                };
                Console.WriteLine($"{message}\n[?] Example: 0 0");
            }
        }
    }
    
    private void DoStepHandler(Player movingPlayer)
    {
        if (movingPlayer is Bot)
        {
            var nextMove = GetNextMove();
            Console.Write($"Enter the coordinate of next step: {nextMove.Row} {nextMove.Column}\n");
            _playground.DoStep(nextMove.Row, nextMove.Column, movingPlayer);
        }
        else
        {
            DoSafeStep(movingPlayer);
        }
    }
    
    private void StartMatch()
    {
        if(_players[1] is Bot)
            PatternFirstStepsInitialize();
        Console.WriteLine($"\n===[Match: {++_matchCount}]===");
        
        (Player firstPlayer, Player secondPlayer) = (_players[0].TypeOfStep == StepType.TYPE_X) 
            ? (_players[0], _players[1]) : (_players[1], _players[0]);
        Player thisPlayerMove = firstPlayer;
        Console.WriteLine();
        
        while (!_playground.IsGameEnd())
        {
            Console.WriteLine($"{_playground.PrintPlayground()}\n\nNext move for {thisPlayerMove.TypeOfStep.GetName()}-player:");
            DoStepHandler(thisPlayerMove);
            
            if (_playground.DoneSteps > 3 &&
                WinTemplate.CheckPattern(new Grid(_playground), thisPlayerMove.TypeOfStep))
            {
                thisPlayerMove.IncrementWinsAmount();
                EndMatch(thisPlayerMove);
                return;
            }
            Console.WriteLine();
            
            thisPlayerMove = (thisPlayerMove == firstPlayer) ? secondPlayer : firstPlayer;
        }
        
        EndMatch(null, isTie: true); // tie
    }

    private void EndMatch(Player? winner, bool isTie = false)
    {
        Console.WriteLine($"\n{_playground.PrintPlayground()}\n");
        Console.WriteLine(isTie ? "There is no winner in this match." : $"Congratulations! The winner is {winner!.TypeOfStep.GetName()}-player!");
        PrintPlayersScore();

        _playground.ResetPlayground();
    }
}