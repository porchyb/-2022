namespace SpaceBattle.Lib;

public class InitScope: ICommand{
    public void Execute(){
        IoC.Resolve<ICommand>("IoC.Add", "CreateAndStartThread", mockQueueStrategy.Object).Execute();
    }
}
