using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceBattle.Lib
{
    public class StartMoveCommand: ICommand
    {
        public IMoveStartable obj { get; set; }
        public Vector velocity { get; set; }
        public Queue<ICommand> queue {get; set;}

        public StartMoveCommand(IMoveStartable _obj, Vector _velocity)
        {
            this.obj = _obj;
            this.velocity = _velocity;
            queue = IoC.Resolve<Queue<ICommand>>("Game.Queue");
        }
        public void Execute()
        {
            ICommand changeVelocityCommand = new ChangeVelocityCommand(obj.target, velocity);
            queue.Enqueue(changeVelocityCommand);

            ICommand moveCommand = new MoveCommand(obj.target);
            queue.Enqueue(moveCommand);
        }
    }
}
