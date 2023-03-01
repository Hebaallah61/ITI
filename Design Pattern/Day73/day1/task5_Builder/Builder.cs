using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5_Builder
{
    abstract class Builder
    {
        public abstract void Sky();
        public abstract void Grass();
        public abstract void Fans();
        public abstract Product GetResult();

    }
}
