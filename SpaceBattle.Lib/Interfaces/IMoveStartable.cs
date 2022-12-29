namespace SpaceBattle.Lib
{
    public interface IMoveStartable
    {
        public IMovable target { get; set; }
        public Vector velocity { get; set; }
        public Queue<ICommand> queue {get; set;}
    }
}
