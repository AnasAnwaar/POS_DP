using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication14
{
    public abstract class Abstractcontrol
    {
        protected reciptgateway reciptgateway;
        protected Abstractcontrol(reciptgateway reciptgateway)
        {
            this.reciptgateway = reciptgateway;
        }
        public abstract string SwitchOn();
        public abstract string SwitchOff();
        public abstract string settransactionid(string tarid);
    }
}
