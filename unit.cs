using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication14
{
    public class unit
    {
        private connection_string connect;
        public unit()
        {
            connect = connection_string.Instance;
        }
        public string countunit()
        {
            //SqlConnection con = new SqlConnection(connection_string.conn);
            //con.Open();
            
            SqlConnection connection = connect.GetConnection();
            connection.Close();
            connection.Open();
            string query1 = "select count(units) from tbl_pos";
            SqlCommand cmd1 = new SqlCommand(query1, connection);
            SqlDataReader reader1 = cmd1.ExecuteReader();
            if (reader1.Read())
            {
                

                return ""+reader1[0].ToString();
            }
            else
            {
                

                return "";
            }
            //con.Close();
            connection.Close();
        }
    }
}
