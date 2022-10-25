namespace TicTacToe;

public sealed class Menu
{
    private readonly string _header;
    private readonly string[] _questions;
    private readonly string _diapason;
    public Int16? Result = null;

    private Int16 GetAnswer()
    {
        Int16 convertAnswer = Int16.Parse(Console.ReadLine());
        if (convertAnswer >= 0 && convertAnswer < _questions.Length)
            return convertAnswer;
        throw new Exception($"[!] Enter value from the diapason {_diapason}.");
    }
    
    private Int16 MakeDecision()
    {
        do {
            try
            {
                Console.Write($" - Enter the answer {_diapason}: ");
                return GetAnswer();
            }
            catch (System.FormatException)
            {
                Console.WriteLine("[!] Inputting error.");
            }
            catch(Exception questionException)
            {
                Console.WriteLine(questionException.Message);
            }
        } while (true);
    }
    
    private void PrintMenu()
    {
        Console.WriteLine();
        string output = _header;
        for (Int16 i = 0; i < _questions.Length; i++)
            output += $"\n[{i}] - {_questions[i]}{(i == _questions.Length - 1 ? "." : ";")}";
        Console.WriteLine(output);
    }
    
    public Menu(string header, string[] questions)
    {
        _header = header;
        _questions = questions;
        _diapason = (_questions.Length > 1) ? $"[0..{_questions.Length - 1}]" : $"[0]";
    }

    public void Run()
    {
        PrintMenu();
        Result = MakeDecision();
    }
}