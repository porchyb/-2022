using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceBattle.Lib
{
    public class MoveCommand: ICommand
    {
        public IMovable movObj;
        private IMoveEndable? obj;

        public MoveCommand(IMovable obj)
        {
            movObj = obj;
        }

        public MoveCommand(IMoveEndable? obj)
        {
            this.obj = obj;
        }

        public void Execute()
        {
            movObj.position += movObj.velocity;
        }
    }
}
