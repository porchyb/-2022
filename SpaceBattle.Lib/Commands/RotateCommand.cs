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
            if (rotObj.angle == 0){
                throw new ArgumentException();
            }
            try{                
                rotObj.direction.deg = rotObj.direction.deg + rotObj.angle;                
            }
            catch{
                throw new ArgumentException();  
            }
        }
    }
}