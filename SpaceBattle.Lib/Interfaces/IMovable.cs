using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattle.Lib
{
    public interface IMovable: IObject
    {
        public Vector velocity { get; set; }
        public void Move();
    }
}
