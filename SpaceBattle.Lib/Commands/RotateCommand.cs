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
            try{
                rotObj.direction.deg = rotObj.direction.deg + rotObj.angle;
            }
            catch{
                throw new ArgumentException();  
            }
        }
    }
}