using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication14
{
    public class CuAdapter : ITarget
    {
        Datastoring datastor = new Datastoring();

        public void Processcudata(string[,] cuArray)
        {
            string name = null;
            string email = null;

            List<customer> listcu = new List<customer>();

            for (int i = 0; i < cuArray.GetLength(0); i++)
            {
                for (int j = 0; j < cuArray.GetLength(1); j++)
                {
                    if (j == 0)
                    {
                        name = cuArray[i, j];
                    }
                    else if (j == 1)
                    {
                        email = cuArray[i, j];
                    }
                }
                listcu.Add(new customer(name, email));
            }
           
            datastor.Processsavedata(listcu);
        }
    }
}
