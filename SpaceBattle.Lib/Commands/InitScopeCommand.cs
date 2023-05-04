using System.Collections.Generic;


namespace SpaceBattle.Lib;

public class InitScopeCommand: ICommand{
    public void Execute(){
        Dictionary<string, IStrategy> scope = new(){
            {"Game.CreateAndStartThreadCommand", new CreateAndStartThreadStrategy()},
            {"Game.SendCommand", new SendStrategy()},
            {"Game.HardStopThreadCommand", new HardStopStrategy()},
            {"Game.SoftStopThreadCommand", new SoftStopStrategy()},
            {"Game.ThreadDictionary", new threadDictStrategy()},
        };
        new IoCSetScopeCommand(scope).Execute();
    }
}
