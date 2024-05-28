using System.Diagnostics;
using Hwdtech;
namespace SpaceBattle.Lib
{
    public class GameComand : Hwdtech.ICommand
    {
        private IReceiver receiver;
        private object scope;
        private Stopwatch time;

        public GameComand(object scope, IReceiver receiver)
        {
            this.scope = scope;
            this.receiver = receiver;
            time = new Stopwatch();
        }
        public void Execute()
        {
            Hwdtech.IoC.Resolve<Hwdtech.ICommand>("Scopes.Current.Set", scope).Execute();
            var gameTick = Hwdtech.IoC.Resolve<int>("Game.GetTick");
            time.Start();
            while (time.ElapsedMilliseconds <= gameTick)
            {
                if (!receiver.isEmpty())
                {
                    var cmd = this.receiver.Receive();
                    try
                    {
                        cmd.Execute();
                    }
                    catch (Exception err)
                    {
                        var exceptinHandlerStrategy = Hwdtech.IoC.Resolve<IStrategy>("Exception.FindHandlerStrategy", cmd, err);
                        exceptinHandlerStrategy.UseStrategy();
                    }
                }
                else break;
            }
            time.Reset();
        }
    }
}
