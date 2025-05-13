using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication14
{
    public class productFactory : saleitemtypeFactory
    {
        string code = "";
        public productFactory(string b)
        {
            code = b;
        }
        protected override saleitemtype MakeProduct()
        {
            saleitemtype product = new product(code);
            return product;
        }
    }
}
