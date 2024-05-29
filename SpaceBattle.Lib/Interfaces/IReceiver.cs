namespace SpaceBattle
{
    public interface IReceiver
    {
        Hwdtech.ICommand Receive();

        bool isEmpty();
    }
}
