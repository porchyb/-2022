using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceBattle.Lib
{
    public class MoveCommand: ICommand
    {
        public IMovable movObj;

        public MoveCommand(IMovable obj)
        {
            movObj = obj;
        }
        public void Execute()
        {
            if (movObj.position is null) throw new ArgumentException();
            movObj.position = movObj.position + movObj.velocity;
        }
    }
}
