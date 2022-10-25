namespace TicTacToe;

public class Player
{
    protected Int16 WinsAmount { get; set; } = 0;
    public StepType TypeOfStep;

    public Player(StepType typeOfStep)
    {
        TypeOfStep = typeOfStep;
    }

    public void IncrementWinsAmount()
    {
        WinsAmount++;
    }

    public void Reset()
    {
        WinsAmount = 0;
    }

    public override string ToString()
        => $"Player [{TypeOfStep.GetName()}] | Score: {WinsAmount}";
}