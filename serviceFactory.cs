using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication14
{
    public class serviceFactory : saleitemtypeFactory
    {
        string code = "";
        public serviceFactory(string b)
        {
            code = b;
        }
        protected override saleitemtype MakeProduct()
        {
            saleitemtype service = new service(code);
            return service;
        }
    }
}
