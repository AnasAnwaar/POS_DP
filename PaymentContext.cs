using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication14
{
    public class PaymentContext
    {
        private IPaymentStrategy PaymentStrategy;
        public void SetPaymentStrategy(IPaymentStrategy strategy)
        {
            this.PaymentStrategy = strategy;
        }
        public string Pay(double amount)
        {
            return "" + PaymentStrategy.Pay(amount);
        }
    }
}
