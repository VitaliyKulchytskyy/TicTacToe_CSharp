namespace TicTacToe;

public static partial class WinTemplate
{
    private static (Int16 Row, Int16 Column) GetMissCell(List<(Int16 Row, Int16 Column)> coordinates)
    {
        Int16 dRow = (Int16)Math.Abs(coordinates[0].Row - coordinates[1].Row);
        Int16 dColumn = (Int16)Math.Abs(coordinates[0].Column - coordinates[1].Column);
        if (dRow == 0)
            return (coordinates[0].Row, (Int16)(3 - (coordinates[0].Column + coordinates[1].Column)));
        if(dColumn == 0)
            return ((Int16)(3 - (coordinates[0].Row + coordinates[1].Row)), coordinates[0].Column );
        return ((Int16)(3 - (coordinates[0].Row + coordinates[1].Row)),
                (Int16)(3 - (coordinates[0].Column + coordinates[1].Column)));
    }
    
    private static bool CheckSamples(Grid playground, Grid pattern)
    {
        for (Int16 i = 0; i < 3; i++)
            for (Int16 j = 0; j < 3; j++)
                if (pattern[i, j] != StepType.TYPE_BACKGROUND.GetName() && 
                    pattern[i, j] != playground[i, j]) 
                    return false;
        return true;
    }
    
    public static (Int16 Row, Int16 Column)? GetNextWinCell(Grid playground, StepType stepType)
    {
        string replaced = playground.ToString()
            .Replace(stepType.GetName(), StepType.TYPE_PATTERN.GetName())
            .Replace(stepType.GetOppositeType().GetName(), StepType.TYPE_OCCUPIED.GetName());
        Grid temp = new Grid(replaced);

        foreach (Grid pattern in _patterns)
        {
            List<(Int16 Row, Int16 Column)> coordinates = new List<(Int16 Row, Int16 Column)>();
            for (Int16 i = 0; i < 3; i++)
            {
                for (Int16 j = 0; j < 3; j++)
                {
                    if(temp[i, j] == StepType.TYPE_BACKGROUND.GetName())
                        continue;
                    
                    if (pattern[i, j] == temp[i, j])
                        coordinates.Add((i, j));
                }
            }

            if (coordinates.Count == 2)
            {
                var coordinate = GetMissCell(coordinates);
                if(temp[coordinate.Row, coordinate.Column] != StepType.TYPE_OCCUPIED.GetName())
                    return coordinate;
            }
        }
        
        return null;
    }

    /* [Input] => [Make mask by X] => [Searching an appropriate pattern] => true (or false if either from patterns doesn't match)
     *   XXO      ##-                     ##-     #--
     *   OX-   => -#- => (searching..) => -#- (&) -#- => matches! (true)
     *   -OX      --#                     --#     --#
     */
    public static bool CheckPattern(Grid playground, StepType stepType)
    {
        string replaced = playground.ToString()
            .Replace(stepType.GetName(), StepType.TYPE_PATTERN.GetName())
            .Replace(stepType.GetOppositeType().GetName(), StepType.TYPE_BACKGROUND.GetName());
        foreach (Grid pattern in _patterns)
            if (CheckSamples(new Grid(replaced), pattern))
                return true;
        return false;
    }
}