using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApplication14
{
    public class instantReport : ReportBuilder
    {
        public instantReport()
        {
            connect = connection_string.Instance;
        }
        private connection_string connect;
        public override void SetReportContent()
        {
            string datahold = "";
            string holddate = "" + DateTime.Now.ToString("dd/MM/yyyy");

            //SqlConnection con = new SqlConnection(connection_string.conn);

            //con.Open();
            SqlConnection connection = connect.GetConnection();
            connect.OpenConnection();
            string query1 = "select COUNT(id) from tbl_tr where date='"+holddate+"'";
            SqlCommand cmd1 = new SqlCommand(query1, connection);
            SqlDataReader reader = cmd1.ExecuteReader();
            if (reader.Read())
            {
                datahold +="\n\nTransactions: "+reader[0].ToString();
            }
            //con.Close();
            connect.CloseConnection();

            //con.Open();
            connect.OpenConnection();
            string query2 = "select SUM(amount) from tbl_tr where date='"+holddate+"'";
            SqlCommand cmd2 = new SqlCommand(query2, connection);
            SqlDataReader reader1 = cmd2.ExecuteReader();
            if (reader1.Read())
            {
                datahold += "\n\nAmount: " + reader1[0].ToString();
            }
            //con.Close();
            connect.CloseConnection();

            //con.Open();
            connect.OpenConnection();
            string query3 = "select sum(units) from tbl_tr where date='"+holddate+"'";
            SqlCommand cmd3 = new SqlCommand(query3, connection);
            SqlDataReader reader2= cmd3.ExecuteReader();
            if (reader2.Read())
            {
                datahold += "\n\nQuantity: " + reader2[0].ToString();
            }
            //con.Close();
            connect.CloseConnection();



            reportObject.ReportContent = datahold;
        }
        public override void SetReportFooter()
        {
            reportObject.ReportFooter = "\n\n\ncopyright 2023-2024 STORE POS";
        }
        public override void SetReportHeader()
        {
            reportObject.ReportHeader = "Daily sales report: "+DateTime.Now.ToString("dd/MM/yyyy");
        }
        public override void SetReportType()
        {
            reportObject.ReportType = "Instant Report\n\n\n";
        }
    }
}
