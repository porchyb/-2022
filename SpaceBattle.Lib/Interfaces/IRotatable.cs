using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattle.Lib
{
    public interface IRotatable: IObject
    {        
        public float angle{get; set;}
        public degree direction{get;set;}
    }
}