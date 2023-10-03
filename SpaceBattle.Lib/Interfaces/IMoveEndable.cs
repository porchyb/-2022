namespace SpaceBattle.Lib
{
    public interface IMoveEndable
    {        
        public IMovable target {get; set;}
        public Queue<ICommand>? queue {get; set;}
        
    }
}
