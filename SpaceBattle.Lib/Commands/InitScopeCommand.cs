using System.Collections.Generic;


namespace SpaceBattle.Lib;

public class InitScopeCommand: ICommand{
    public void Execute(){
        Dictionary<string, IStrategy> scope = new(){
            {"Game.CreateAndStartThread", new CreateAndStartThreadStrategy()},
            {"Game.SendCommand", new SendStrategy()},
            {"Game.HardStopThread", new HardStopStrategy()},
            {"Game.SoftStopThread", new SoftStopStrategy()}
        };
    }
}
