using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication14
{
    public class CreditCardPaymentStrategy : IPaymentStrategy
    {
        public string Pay(double amount)
        {
            return "Customer pays " + amount + " using Credit/ Pay later";
        }
    }
}
