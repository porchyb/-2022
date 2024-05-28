using Hwdtech;


namespace SpaceBattle.Lib
{
    public class GameQueuePopStrategy : IStrategy
    {
        public object UseStrategy(params object[] param)
        {
            Queue<Hwdtech.ICommand> commandQueue = (Queue<Hwdtech.ICommand>)param[0];
            return (Hwdtech.ICommand)commandQueue.Dequeue();
        }
    }
}
