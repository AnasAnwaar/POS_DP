using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication14
{
    public partial class Form6 : Form
    {
        private connection_string connect;
        public Form6()
        {
            InitializeComponent();
            connect = connection_string.Instance;
        }

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }
        List<string> mails = new List<string>();
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(connection_string.conn);
            //con.Open();
            SqlConnection connection = connect.GetConnection();
            connect.OpenConnection();
            SqlDataAdapter adp = new SqlDataAdapter("select email from tbl_emails", connection);
            DataTable dt = new DataTable();
            adp.Fill(dt);


            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    mails.Add(dt.Rows[i]["email"].ToString());
                }
            }
            else
            {
                MessageBox.Show("Invalid pin ");
            }

            //for (int i = 0; i < mails.Count; i++)
            //{
            //    MessageBox.Show(""+mails[i]+"");
            //}
            // ======================================================================================

            try
            {
                if (richTextBox1.Text != "")
                {
                    if (textBox1.Text != "" && textBox2.Text != "")
                    {
                        if (textBox3.Text != "" && textBox4.Text != "")
                        {
                            if (textBox5.Text != "")
                            {
                                int val_from = 0;
                                int val_to = 0;

                                try
                                {
                                    val_from = Convert.ToInt32(textBox3.Text);
                                    val_from--;
                                    val_to = Convert.ToInt32(textBox4.Text);
                                }
                                catch
                                {
                                    MessageBox.Show("Enter numeric value");
                                }

                                for (int i = val_from; i < val_to; i++)
                                {
                                    string check = mails[i];
                                    bool flag = false;

                                    for (int j = 0; j < check.Length; j++)
                                    {
                                        if (check[j] == '@')
                                        {
                                            flag = true;
                                            break;
                                        }
                                        else
                                        {
                                            continue;
                                        }
                                    }

                                    if (flag == true)
                                    {

                                        label4.Text = mails[i];


                                        MailMessage mail = new MailMessage();
                                        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                                        mail.From = new MailAddress("" + textBox1.Text + "");
                                        mail.To.Add("" + mails[i] + "");
                                        mail.Subject = "" + textBox5.Text + "";
                                        mail.Body = "" + richTextBox1.Text + "";


                                        SmtpServer.Port = 587;
                                        SmtpServer.Credentials = new System.Net.NetworkCredential("" + textBox1.Text + "", "" + textBox2.Text + "");
                                        SmtpServer.EnableSsl = true;

                                        SmtpServer.Send(mail);


                                        MessageBox.Show("Sucess");

                                        label4.Text = "";
                                    }
                                    else
                                    {
                                        MessageBox.Show("Email is not correct");
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Email subject is missing");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please enter range");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter email and passoword");
                    }
                }
                else
                {
                    MessageBox.Show("Enter email body");
                }
            }
            catch
            {
                MessageBox.Show("Please try again");
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Hide();
            emailsend obj = new emailsend();
            obj.Show();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
