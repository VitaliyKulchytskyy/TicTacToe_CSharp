namespace TicTacToe;

public sealed partial class GameHandler
{
    /*
     * _players[0] - a real player;
     * _players[1] - a real player too or bot.
     */
    private static readonly Player[] _players = new Player[2];
    private static readonly Playground _playground = new (_players[0], _players[1]);
    private bool _isFirstGame = true;

    private enum MainMenu
    {
        NewGame = 0,
        NewMatch = 1,
        CheckScore = 2,
        Exit = 3,
        ChooseStatement = 4,
    }
    
    private void GameMenu()
    {
        Menu mainMenu = _isFirstGame ? 
            new Menu("[Main Menu]", new[]
            {
                "start new game",
                "exit"
            }) 
            : new Menu("[Main Menu]", new[]
            {
                "start new game",
                "start new match",
                "check players score",
                "exit",
            });
        mainMenu.Run();
        MainMenu command = _isFirstGame ? 
            (mainMenu.Result == 0 ? MainMenu.NewGame : MainMenu.Exit) 
            : (MainMenu)mainMenu.Result!;
        _isFirstGame = false;
        
        switch (command)
        {
            case MainMenu.NewMatch:
                ChangePlayerType();
                StartMatch();
                goto case MainMenu.ChooseStatement;
            case MainMenu.NewGame:
                PrepareToGame();
                StartMatch();
                goto case MainMenu.ChooseStatement;
            case MainMenu.CheckScore:
                PrintPlayersScore();
                goto case MainMenu.ChooseStatement;
            case MainMenu.ChooseStatement:
                GameMenu();
                break;
            case MainMenu.Exit:
                return;
        }
    }

    public GameHandler()
    {
        Console.WriteLine("..:::[TIC-TAC TOE]:::..");
        GameMenu();
    }
}