namespace SpaceBattle.Lib
{
    public interface IReceiver{
        public ICommand Receive();
        public void Put(ICommand _command);
        public bool IsEmpty();
    }
}
