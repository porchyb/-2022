using System.Collections.Concurrent;
namespace SpaceBattle.Lib;

public class RecieverAdapter: IReceiver{
    BlockingCollection<ICommand> queue;
    public RecieverAdapter(BlockingCollection<ICommand> _queue) => this.queue=_queue;
    public ICommand Receive(){
        return queue.Take();
    }
    public void Put(ICommand _command){
        queue.Add(_command);
    }
    public bool IsEmpty(){
        return queue.Count == 0;
    }
}
