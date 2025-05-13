using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication14
{
    public class trackreciptgateway : reciptgateway
    {
        private connection_string connect;
        public string SwitchOn()
        {
            return "1";
        }
        public string SwitchOff()
        {
            return "0";
        }
        public string settransactionid(string tarid)
        {
            //SqlConnection con = new SqlConnection(connection_string.conn);
            //con.Open();
            SqlConnection connection = connect.GetConnection();
            connect.OpenConnection();
            string query2 = "update tbl_credit set name='done' where id="+tarid+"";
            SqlCommand cmd2 = new SqlCommand(query2, connection);
            cmd2.ExecuteNonQuery();

            //con.Close();
            connect.CloseConnection();
                return "Sucess";
            
        }
    }
}
