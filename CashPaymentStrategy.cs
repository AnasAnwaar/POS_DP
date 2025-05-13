using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication14
{
    public class CashPaymentStrategy : IPaymentStrategy
    {
        public string Pay(double amount)
        {
            return "Customer pays " + amount + " By Cash";
        }
    }
}
