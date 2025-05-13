using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApplication14
{
    public class service : saleitemtype
    {
        private connection_string connect;
        string[] data = new string[4];
        public service(string b)
        {
            connect = connection_string.Instance;
            //SqlConnection con = new SqlConnection(connection_string.conn);
            //con.Open();
            SqlConnection connection = connect.GetConnection();
            connect.OpenConnection();
            string query = "select * from tbl_pos where ty='ser' and code='"+b+"' ";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                data[0] = reader[2].ToString();
                data[1] = reader[3].ToString();
                data[2] = reader[4].ToString();
                data[3] = reader[5].ToString();
            }
            //con.Close();
            connect.CloseConnection();
        }

        public string Getname()
        {
            return "" + data[0];
        }

        public string Getammount()
        {
            return "" + data[1];
        }
        public string Getquantity()
        {
            return "" + data[2];
        }
        public string Getitemtype()
        {
            return "" + data[3];
        }
    }
}
