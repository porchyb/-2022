using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattle.Lib
{
    public interface IMoveStartable
    {
        public IMovable target { get; set; }
        public Vector velocity { get; set; }
        public Queue<ICommand> queue {get; set;}
    }
}
