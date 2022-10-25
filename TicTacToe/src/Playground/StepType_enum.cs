namespace TicTacToe;

public enum StepType
{
    TYPE_X = 0,
    TYPE_O = 1,
    TYPE_BACKGROUND = 2,
    TYPE_PATTERN = 3,
    TYPE_UNION = 4,
    TYPE_OCCUPIED = 5
};

public static class StepTypeExtension
{
    public static char GetName(this StepType stepType)
        => "XO-#@?".ToCharArray()[(Int16)stepType];

    public static StepType GetOppositeType(this StepType stepType)
    {
        switch (stepType)
        {
            case StepType.TYPE_O:
                return StepType.TYPE_X;
            case StepType.TYPE_X:
                return StepType.TYPE_O;
            default:
                throw new Exception("[!] There is no way to get an opposite symbol for the technical symbols.");
        }
    }
}