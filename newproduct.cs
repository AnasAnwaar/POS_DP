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
    public partial class newproduct : Form
    {
        private connection_string connect;
        public newproduct()
        {
            InitializeComponent();
            connect = connection_string.Instance;
        }

        private void newproduct_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void newproduct_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            button1.Enabled = false;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
                {
                    try
                    {
                        float test1 = float.Parse(textBox3.Text);

                        //SqlConnection con = new SqlConnection(connection_string.conn);
                        //con.Open();
                        SqlConnection connection = connect.GetConnection();
                        connect.OpenConnection();
                        SqlCommand cmd = new SqlCommand("insert into tbl_pos(code,name,price,units,ty)values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','pro')", connection);
                        cmd.ExecuteNonQuery();
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
                        MessageBox.Show("Please enter numeric value \n الرجاء إدخال قيمة رقمية");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter all values \n الرجاء إدخال جميع القيم");
                }
            }
            else if (radioButton2.Checked == true)
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
                {
                    try
                    {
                        float test1 = float.Parse(textBox3.Text);

                        //SqlConnection con = new SqlConnection(connection_string.conn);
                        //con.Open();
                        SqlConnection connection = connect.GetConnection();
                        connect.OpenConnection();
                        SqlCommand cmd = new SqlCommand("insert into tbl_pos(code,name,price,units,ty)values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','ser')", connection);
                        cmd.ExecuteNonQuery();
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
                        MessageBox.Show("Please enter numeric value \n الرجاء إدخال قيمة رقمية");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter all values \n الرجاء إدخال جميع القيم");
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form3 obj = new Form3();
            obj.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            button1.Enabled = true;
        }
    }
}
