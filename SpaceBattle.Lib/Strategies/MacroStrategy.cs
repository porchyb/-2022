namespace SpaceBattle.Lib;

public class MacroStrategy: IStrategy{
    public object UseStrategy(params object[] args){
        List<string> dependencies = IoC.Resolve<List<string>>("Game.Operation" + (string)args[0]);
        object obj = args[1];
        List<ICommand> commands = new List<ICommand>();
        foreach(var dependency in dependencies){
            commands.Add(IoC.Resolve<ICommand>(dependency));
        }
        return new MacroCommand(commands, obj);
    }
}
