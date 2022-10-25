namespace TicTacToe;

public sealed class Playground
{
    private Grid GameGrid = new Grid();
    private readonly Int32 _maxSteps;
    private Player[] _players;
    public Int16 DoneSteps = 0;

    public Playground(Player player1, Player player2)
    {
        _players = new[] { player1, player2 };
        _maxSteps = GameGrid.RowAmount * GameGrid.ColumnAmount;
    }

    public void DoStep(Int16 i, Int16 j, Player player)
    {
        GameGrid[i, j] = player.TypeOfStep.GetName();
        DoneSteps++;
    }

    public void ResetPlayground()
    {
        DoneSteps = 0;
        GameGrid = new Grid(); 
    }

    public bool IsCellOccupied(Int16 i, Int16 j)
        => GameGrid.IsCellOccupied(i, j);
    
    public bool IsGameEnd()
        => DoneSteps >= _maxSteps;

    public string PrintPlayground()
        => GameGrid.PrintPlayground();

    public override string ToString()
        => GameGrid.ToString();
}