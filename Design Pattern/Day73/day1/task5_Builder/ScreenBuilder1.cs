using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5_Builder
{
    internal class ScreenBuilder1:Builder
    {
        private Product _product = new Product();

        public override void Sky()
        {
            _product.Add("Blue Sky");
        }

        public override void Grass()
        {
            _product.Add("Green Grass");
        }

        public override void Fans()
        {
            _product.Add("500 Fans");
        }

        public override Product GetResult()
        {
            return _product;
        }
    }
}
