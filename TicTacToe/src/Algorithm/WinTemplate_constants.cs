namespace TicTacToe;

public static partial class WinTemplate
{
    private static readonly string[] PATTERN_COLUMN = new[]
    {
        $"{StepType.TYPE_PATTERN.GetName()}{StepType.TYPE_BACKGROUND.GetName()}{StepType.TYPE_BACKGROUND.GetName()}\n",
        $"{StepType.TYPE_BACKGROUND.GetName()}{StepType.TYPE_PATTERN.GetName()}{StepType.TYPE_BACKGROUND.GetName()}\n",
        $"{StepType.TYPE_BACKGROUND.GetName()}{StepType.TYPE_BACKGROUND.GetName()}{StepType.TYPE_PATTERN.GetName()}\n"
    };
    private static readonly string PATTERN_ROW = new String(StepType.TYPE_PATTERN.GetName(), 3) + '\n';
    private static readonly string BACKGROUND_ROW = new String(StepType.TYPE_BACKGROUND.GetName(), 3) + '\n';
    
    private static readonly Grid[] _patterns =
    {
        // Horizontal columns
        new ($"{PATTERN_ROW}{BACKGROUND_ROW}{BACKGROUND_ROW}"),
        new ($"{BACKGROUND_ROW}{PATTERN_ROW}{BACKGROUND_ROW}"),
        new ($"{BACKGROUND_ROW}{BACKGROUND_ROW}{PATTERN_ROW}"),
        
        // Vertical columns
        new (string.Concat(Enumerable.Repeat(PATTERN_COLUMN[0], 3))), 
        new (string.Concat(Enumerable.Repeat(PATTERN_COLUMN[1], 3))),
        new (string.Concat(Enumerable.Repeat(PATTERN_COLUMN[2], 3))),
        
        // Main diagonals 
        new ($"{PATTERN_COLUMN[0]}{PATTERN_COLUMN[1]}{PATTERN_COLUMN[2]}"),
        new ($"{PATTERN_COLUMN[2]}{PATTERN_COLUMN[1]}{PATTERN_COLUMN[0]}")
    };
}