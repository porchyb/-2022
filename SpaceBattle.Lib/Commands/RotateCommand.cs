using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceBattle.Lib
{
    public class RotateCommand : ICommand
    {
        public IRotatable rotObj;
        
        public RotateCommand(IRotatable obj)
        {
            rotObj = obj;
        }

        public void Execute()
        {
            rotObj.direction += rotObj.angle;
        }
    }
}
