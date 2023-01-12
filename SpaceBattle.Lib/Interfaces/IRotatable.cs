using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattle.Lib
{
    public interface IRotatable: IObject
    {        
        public degree angle{get;}
        public degree direction{get;set;}       
    }
}
