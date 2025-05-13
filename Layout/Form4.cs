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
    public partial class Form4 : Form
    {
        private connection_string connect;
        public Form4()
        {
            InitializeComponent();
            connect = connection_string.Instance;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            textBox3.Visible = false;
            textBox2.Visible = false;

            button3.Visible = false;
            button4.Visible = false;

            label11.Visible = false;

            //SqlConnection con = new SqlConnection(connection_string.conn);
            //con.Open();
            SqlConnection connection = connect.GetConnection();
            connect.OpenConnection();
            string query = "select * from tbl_tr";
            SqlDataAdapter cmd = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            dataGridView1.DataSource = dt;
            connect.CloseConnection();


            connect.OpenConnection();
            string query1 = "select count(code) from tbl_pos";
            SqlCommand cmd1 = new SqlCommand(query1, connection);
            SqlDataReader reader = cmd1.ExecuteReader();
            if (reader.Read())
            {
                label6.Text = reader[0].ToString();
            }
            connect.CloseConnection();

            //con.Open();
            connect.OpenConnection();
            string query2 = "select sum(units) from tbl_tr";
            SqlCommand cmd2 = new SqlCommand(query2, connection);
            SqlDataReader reader1 = cmd2.ExecuteReader();
            if (reader1.Read())
            {
                label7.Text = reader1[0].ToString();
            }
            //con.Close();
            connect.CloseConnection();

            // con.Open();
            connect.OpenConnection();
            string query3 = "select sum(amount) from tbl_tr";
            SqlCommand cmd3 = new SqlCommand(query3, connection);
            SqlDataReader reader3 = cmd3.ExecuteReader();
            if (reader3.Read())
            {
                label8.Text = reader3[0].ToString();
            }
            // con.Close();
            connect.CloseConnection();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(connection_string.conn);
            //con.Open();
            SqlConnection connection = connect.GetConnection();
            connect.OpenConnection();

            string query = "select * from tbl_tr where id='"+textBox1.Text+"'";
            SqlDataAdapter cmd = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            dataGridView1.DataSource = dt;
            //con.Close();
            connect.CloseConnection();
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 obj = new Form2();
            obj.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(connection_string.conn);
            //con.Open();
            SqlConnection connection = connect.GetConnection();
            connect.OpenConnection();

            string query = "select * from tbl_tr";
            SqlDataAdapter cmd = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            dataGridView1.DataSource = dt;

            //conn.Close();
            connect.CloseConnection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Report report;
            ReportDirector reportDirector = new ReportDirector();
            instantReport instantReport = new instantReport();

            report = reportDirector.MakeReport(instantReport);
            string get = report.DisplayReport();

            MessageBox.Show(get);
        }
        trackcontrol trackcontrol = new trackcontrol(new trackreciptgateway());
        int holdcont = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            if (holdcont == 1)
            {
                MessageBox.Show(trackcontrol.settransactionid("'" + textBox2.Text + "'"));
            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Visible = true;
           
            button4.Visible = true;



        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Visible = false;
            textBox2.Visible = false;

            button3.Visible = false;
            button4.Visible = false;

            label11.Visible = false;
            holdcont = int.Parse(trackcontrol.SwitchOff());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked==true)
            {
                if(textBox3.Text=="1122")
                {
                    holdcont = 1;
                    textBox2.Visible = true;
                    button3.Visible = true;
                    label11.Visible = true;
                    MessageBox.Show("sucess");

                }
                else
                {
                    label11.Visible = false;
                    textBox2.Visible = false;
                    button3.Visible = false;
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
