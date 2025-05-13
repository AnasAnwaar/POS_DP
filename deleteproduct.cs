using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication14
{
    public partial class deleteproduct : Form
    {
        private connection_string connect;
        public deleteproduct()
        {
            InitializeComponent();
            connect = connection_string.Instance;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(connection_string.);
            SqlConnection connection = connect.GetConnection();
            connect.OpenConnection();
            SqlCommand cmd = new SqlCommand("delete from tbl_pos where code='" + textBox1.Text + "'", connection);
            cmd.ExecuteNonQuery();
            connect.CloseConnection();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form3 obj = new Form3();
            obj.Show();
            this.Hide();
        }

        private void deleteproduct_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                SqlConnection connection = connect.GetConnection();
                connect.OpenConnection();
                SqlCommand cmd = new SqlCommand("delete from tbl_pos where code='" + textBox1.Text + "'", connection);
                cmd.ExecuteNonQuery();
                connect.CloseConnection();
                MessageBox.Show("Success ");
                textBox1.Text = "";
            }
            else
            {
                MessageBox.Show("Please enter barcode");
            }
        }
    }
}
