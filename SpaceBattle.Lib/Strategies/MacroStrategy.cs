namespace SpaceBattle.Lib;

public class MacroStrategy: IStrategy{
    public object UseStrategy(params object[] args){
        List<string> dependencies = IoC.Resolve<List<string>>((string)args[0]);
        object obj = args[1];
        List<ICommand> commands = new List<ICommand>();
        foreach(var dependency in dependencies){
            commands.Add(IoC.Resolve<ICommand>(dependency, obj));
        }
        return new MacroCommand(commands);
    }
}
