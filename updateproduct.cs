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
    public partial class updateproduct : Form
    {
        private connection_string connect;
        public updateproduct()
        {
            InitializeComponent();
            connect = connection_string.Instance;

        }

        private void updateproduct_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form3 obj = new Form3();
            obj.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                button1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;

                //SqlConnection con = new SqlConnection(connection_string.conn);
                //con.Open();
                SqlConnection connection = connect.GetConnection();
                connect.OpenConnection();
                string query = "select * from tbl_pos where code = '" + textBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    textBox2.Text = reader[2].ToString();
                    textBox3.Text = reader[3].ToString();
                    textBox4.Text = reader[4].ToString();
                }
                else
                {
                    MessageBox.Show("Not found");
                }
                //con.Close();
                connect.CloseConnection();
            }
            else
            {
                MessageBox.Show("Please enter barcode ");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                float test1 = float.Parse(textBox3.Text);
                //SqlConnection con = new SqlConnection(connection_string.conn);
                //con.Open();
                SqlConnection connection = connect.GetConnection();
                connect.OpenConnection();
                SqlCommand cnd = new SqlCommand("UPDATE tbl_pos SET name='" + textBox2.Text + "',price='" + textBox3.Text + "', units='"+textBox4.Text+"' where code='" + textBox1.Text + "'", connection);
                cnd.ExecuteNonQuery();
                //con.Close();
                connect.CloseConnection();
                MessageBox.Show("Success ");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            }
            catch
            {
                MessageBox.Show("Please enter numeric value");
            }
        }

        private void updateproduct_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox1.Focus();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
