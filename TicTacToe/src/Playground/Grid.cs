namespace TicTacToe;

public sealed class Grid
{
    private string GridTable { set; get; } = $"{string.Concat(Enumerable.Repeat(new String(StepType.TYPE_BACKGROUND.GetName(), 3) + '\n', 3))}";
    public Int16 RowAmount { get; private set; }
    public Int16 ColumnAmount  { get; private set; }

    private void InitializeGrid(string pattern)
    {
        GridTable = (pattern[^1] == '\n') ? pattern.Remove(pattern.Length - 1) : pattern;
        RowAmount = (Int16)(GridTable.Split().Length);
        ColumnAmount = (Int16)(GridTable.Split()[0].Length);
    }
    
    private string GetGridHeader()
    {
        string output = "  ";
        for (Int16 i = 0; i < RowAmount; i++)
            output += i;
        return output;
    }

    private Int32 CalcLinearIndex(Int16 i, Int16 j)
        => i * (RowAmount + 1) + j;

    public Grid()
    {
        InitializeGrid(GridTable);
    }
    
    public Grid(string pattern)
    {
        InitializeGrid(pattern);
    }
    
    public Grid(Playground playground)
    {
        GridTable = playground.ToString();
    }
    
    public bool IsCellOccupied(Int16 i, Int16 j)
        => this[i, j] != StepType.TYPE_BACKGROUND.GetName();

    public char this[Int16 i, Int16 j]
    {
        get
        {
            if (i >= 0 && j >= 0 && i < RowAmount && j < ColumnAmount)
            {
                char getCell = GridTable.ToCharArray()[CalcLinearIndex(i, j)];
                GridTable = new string(GridTable);
                return getCell;
            }
            else
            {
                throw new Exception($"[!] The coordinate is out of playground ({i} [Max: {RowAmount - 1} | Min: 0], {j} [Max: {ColumnAmount - 1} | Min: 0]).\n[?] Enter another coordinate.");
            }
        }
        
        set
        {
            if (!IsCellOccupied(i, j))
            {
                char[] gridChar = GridTable.ToCharArray();
                gridChar[CalcLinearIndex(i, j)] = value;
                GridTable = new string(gridChar);
            }
            else
            {
                throw new Exception("[!] This coordinate is occupied by other player.\n[?] Enter another coordinate.");
            }
        }
    }

    public string PrintPlayground()
    {
        string output = GetGridHeader();
        string[] temp = GridTable.Split('\n');
        for (Int16 i = 0; i < temp.Length; i++)
            output += $"\n{i} {temp[i]}";
        return output;
    }

    public override string ToString()
        => GridTable;
}