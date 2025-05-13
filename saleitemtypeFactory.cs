using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication14
{
    public abstract class saleitemtypeFactory
    {
        protected abstract saleitemtype MakeProduct();
        public saleitemtype CreateProduct()
        {
            return this.MakeProduct();
        }
    }
}
