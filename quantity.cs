using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication14
{
    public class quantity
    {
        private connection_string connect;
        public string getquantity()
        {
            connect = connection_string.Instance;
            //SqlConnection con = new SqlConnection(connection_string.conn);
            //con.Open();
            SqlConnection connection = connect.GetConnection();
            connection.Open();
            string query = "select SUM(units) from tbl_pos";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {

                return ""+reader[0].ToString();
                
            }
            else
            {

                return "";
            }
            connection.Close();
            //con.Close();

        }
        
    }
}
