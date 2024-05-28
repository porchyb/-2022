using Hwdtech;
namespace SpaceBattle.Lib
{
    public class CreateNewGameStrategy : IStrategy
    {
        public object UseStrategy(params object[] args)
        {
            string gameId = (string)args[0];

            new Hwdtech.Ioc.InitScopeBasedIoCImplementationCommand().Execute();
            var scope = Hwdtech.IoC.Resolve<object>("Scopes.New", Hwdtech.IoC.Resolve<object>("Scopes.Root"));

            Queue<Hwdtech.ICommand> commandQueue = new Queue<Hwdtech.ICommand>();
            IReceiver receiver = new QueueReceiverAdapter(commandQueue);

            Dictionary<string, Queue<Hwdtech.ICommand>> gamesDictionary = Hwdtech.IoC.Resolve<Dictionary<string, Queue<Hwdtech.ICommand>>>("Game.Get.GamesDictioanary");
            gamesDictionary.Add(gameId, commandQueue);

            return new GameComand(scope, receiver);
        }
    }
}
