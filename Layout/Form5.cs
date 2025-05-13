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



    public partial class Form5 : Form
    {
        private connection_string connect;
        public Form5()
        {
            InitializeComponent();
            connect = connection_string.Instance;
        }

        public void dataviewload()
        {
            //SqlConnection con = new SqlConnection(connection_string.conn);
            //con.Open();
            SqlConnection connection = connect.GetConnection();
            connect.OpenConnection();
            SqlDataAdapter adp = new SqlDataAdapter("select m_id,name,email from tbl_emails", connection);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            //con.Close();
            connect.CloseConnection();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            dataviewload();

            label4.Visible = false;
            label5.Visible = false;

            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;

            radioButton1.Checked = true;
        }


        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Hide();
            emailsend obj = new emailsend();
            obj.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if(radioButton1.Checked==true)
            {
                if (textBox1.Text != "" && textBox2.Text != "")
                {
                    if (radioButton1.Checked == true)
                    {
                        //SqlConnection con = new SqlConnection(connection_string.conn);
                        //con.Open();
                        SqlConnection connection = connect.GetConnection();
                        connect.OpenConnection();

                        SqlCommand cmd = new SqlCommand("insert into tbl_emails(name,email) values ('" + textBox1.Text + "', '" + textBox2.Text + "')", connection);
                        cmd.ExecuteNonQuery();

                        //con.Close();
                        connect.CloseConnection();
                        dataviewload();
                    }
                }
                else
                {
                    MessageBox.Show("Please enter name and email");
                }
            }
            else if(radioButton2.Checked==true)
            {
                string[,] cuArray = new string[3, 2] 
                 {
                {textBox1.Text,textBox2.Text},
                {textBox3.Text,textBox4.Text},
                {textBox5.Text,textBox6.Text}
                };

                ITarget target = new CuAdapter();

                target.Processcudata(cuArray);
                dataviewload();
                
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label4.Visible = true;
            label5.Visible = true;

            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label4.Visible = false;
            label5.Visible = false;

            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
        }
    }
}
