using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication14
{
    public class Datastoring
    {
        private connection_string connect;
        public void Processsavedata(List<customer> listcu)
        {
            foreach (customer cu in listcu)
            {
               
                SqlConnection connection = connect.GetConnection();
                connect.OpenConnection();

                SqlCommand cmd = new SqlCommand("insert into tbl_emails(name,email) values ('" + cu.name + "', '" + cu.email + "')", connection);
                cmd.ExecuteNonQuery();

                connect.CloseConnection();
            }
        }
    }
}
