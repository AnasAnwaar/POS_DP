using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication14
{
    public class amount
    {
        public amount()
        {
            connect = connection_string.Instance;
        }
        private connection_string connect;
        public string getammount()
        {
            //SqlConnection con = new SqlConnection(connection_string.conn);
            //con.Open();
            SqlConnection connection = connect.GetConnection();
            connection.Close();
            connection.Open();
            string query2 = "select SUM(price) from tbl_pos";
            SqlCommand cmd2 = new SqlCommand(query2, connection);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            if (reader2.Read())
            {
                
                return ""+reader2[0].ToString();

            }
            else
            {
                
                return "";
            }
            //con.Close();
            connect.CloseConnection();
        }
    }
}
