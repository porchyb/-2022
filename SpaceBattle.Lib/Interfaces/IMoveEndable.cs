namespace SpaceBattle.Lib
{


    public interface IMoveEndable
    {
        public MoveCommand? MCommand {get;} // set?      
        //BridgeCommand EndCommand {get; set;}
        public IMovable? target {get; set;}
        public Queue<ICommand>? queue {get; set;}
    }
}
