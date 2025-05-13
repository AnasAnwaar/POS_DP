using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication14
{
    public class trackcontrol : Abstractcontrol
    {
        public trackcontrol(reciptgateway reciptgateway)
            : base(reciptgateway)
        {
        }
        public override string SwitchOn()
        {
            return "" + reciptgateway.SwitchOn();
        }
        public override string SwitchOff()
        {
            return "" + reciptgateway.SwitchOff();
        }
        public override string settransactionid(string tarid)
        {
            return "" + reciptgateway.settransactionid(tarid);
        }
    }
}
