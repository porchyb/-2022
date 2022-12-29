namespace SpaceBattle.Lib;

public class ChangeVelocityCommand: ICommand{
    private IMovable obj;
    private Vector newVelocity;
    public ChangeVelocityCommand(IMovable _obj, Vector _newVelocity){
        this.obj = _obj;
        newVelocity = _newVelocity;
    }
    public void Execute(){
        obj.velocity = newVelocity;
    }
}
