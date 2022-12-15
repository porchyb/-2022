using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattle.Lib
{
    public interface IMovable
    {
        public Vector velocity { get; set; }
        public Vector position { get; set; }
    }
}
