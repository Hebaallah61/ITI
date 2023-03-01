using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5_Builder
{
    internal class ScreenBuilder2:Builder
    {
        private Product _product = new Product();

        public override void Sky()
        {
            _product.Add("Black Sky");
        }

        public override void Grass()
        {
            _product.Add("Yellow Grass");
        }

        public override void Fans()
        {
            
        }

        public override Product GetResult()
        {
            return _product;
        }

        
    }
}
