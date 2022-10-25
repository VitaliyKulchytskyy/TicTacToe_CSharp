namespace TicTacToe;

public sealed partial class GameHandler
{
    private Player GetFirstPlayerData()
    {
        Menu chooseSide = new Menu("Choose your side:", 
            new []
            {
                $"playing for {StepType.TYPE_X.GetName()} (play first)",
                $"playing for {StepType.TYPE_O.GetName()}"
            });
        chooseSide.Run();
        return new Player((StepType)chooseSide.Result!);
    } 
    
    private Player GetOpponentPlayerData()
    {
        Menu chooseOpponent = new Menu("Choose your opponent:",
            new []
            {
                "play against to another human",
                "play against to the bot"
            });
        chooseOpponent.Run();
        return (chooseOpponent.Result == 0) ? 
            new Player(_players[0].TypeOfStep.GetOppositeType()) : 
            GetBotData();
    }

    private Bot GetBotData()
    {
        Menu chooseHardLevel = new Menu("Choose level of difficult for the bot:",
            new []
            {
                "easy level",
                "middle level"
            });
        chooseHardLevel.Run();
        return new Bot(_players[0].TypeOfStep.GetOppositeType(), (BotHardLevel)chooseHardLevel.Result!);
    }

    private void ChangePlayerType()
    {
        Menu chooseChangeStepType = new Menu("Do you wanna change anything?",
            new []
            {
                "swap players",
                "don't change anything and play"
            });
        chooseChangeStepType.Run();
        
        if(chooseChangeStepType.Result == 0)
            _players.SetOppositeType();
    }
}