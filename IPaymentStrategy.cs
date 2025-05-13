using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication14
{
    public interface IPaymentStrategy
    {
        string Pay(double amount);
    }
}
