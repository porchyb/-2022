using Hwdtech;
namespace SpaceBattle
{
    public class QueueReceiverAdapter : IReceiver
    {
        Queue<Hwdtech.ICommand> queue;
        public QueueReceiverAdapter(Queue<Hwdtech.ICommand> queue)
        {
            this.queue = queue;
        }
        public Hwdtech.ICommand Receive()
        {
            return queue.Dequeue();
        }
        public bool isEmpty()
        {
            return queue.Count == 0;
        }
    }
}
