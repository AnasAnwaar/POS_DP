using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication14
{
    public class productdata
    {
        public string getprodata()
        {
            string data = "";
            quantity qu = new quantity();
            data += qu.getquantity();
            data += "            ";

            unit un = new unit();
            data += un.countunit();
            data += "               ";

            amount am = new amount();
            data += am.getammount();

            return data;
        }
    }
}
