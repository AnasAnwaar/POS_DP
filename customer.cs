using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication14
{
    public class customer
    {
        public string name { get; set; }
        public string email { get; set; }
        public customer(string n, string em)
        {
            name = n;
            email = em;
        }
    }
}
