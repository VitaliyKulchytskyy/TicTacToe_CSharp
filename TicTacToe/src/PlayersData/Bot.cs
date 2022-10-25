namespace TicTacToe;

public enum BotHardLevel
{
    HLVL_EASY = 0,
    HLVL_MID = 1,
    LAST
}

public sealed class Bot : Player
{
    public BotHardLevel HardLevel;

    public Bot(StepType typeOfStep, BotHardLevel hardLvl)
        : base(typeOfStep)
    {
        HardLevel = hardLvl;
    }
    
    public override string ToString()
        => $"Bot    [{TypeOfStep.GetName()}] | Score: {WinsAmount}";
}

public static class PlayerArrayExtension
{
    public static void SetOppositeType(this Player[] players)
    {
        foreach (Player player in players)
            player.TypeOfStep = player.TypeOfStep.GetOppositeType();
    }

    public static void Reset(this Player[] players)
    {
        foreach (Player player in players)
            player.Reset();
    }
}