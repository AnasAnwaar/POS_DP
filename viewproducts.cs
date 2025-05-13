using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication14
{
    public partial class viewproducts : Form
    {
        private connection_string connect;
        public viewproducts()
        {
            InitializeComponent();
            connect = connection_string.Instance;
        }

        private void viewproducts_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void viewproducts_Load(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(connection_string.conn);
            //con.Open();
            SqlConnection connection = connect.GetConnection();
            connection.Open();
            SqlDataAdapter adp = new SqlDataAdapter("select * from tbl_pos", connection);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            //con.Close();
            connection.Close();


            productdata obj = new productdata();
            label2.Text = obj.getprodata();

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form3 obj = new Form3();
            obj.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(connection_string.conn);
            //con.Open();
            SqlConnection connection = connect.GetConnection();
            connection.Close();
            connection.Open();
            SqlDataAdapter adp = new SqlDataAdapter("select * from tbl_pos where ty='pro'", connection);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            //con.Close();
            connect.CloseConnection();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(connection_string.conn);
            //con.Open();
            SqlConnection connection = connect.GetConnection();
            connect.OpenConnection();
            SqlDataAdapter adp = new SqlDataAdapter("select * from tbl_pos where ty='ser'", connection);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            connect.CloseConnection();
            //con.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
