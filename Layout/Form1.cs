using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO.Ports;
using System.Threading;

namespace WindowsFormsApplication14
{
    public partial class Form1 : Form
    {
        private connection_string connect;
        public string payhold = "";
        public Form1()
        {
            InitializeComponent();
            connect = connection_string.Instance;
        }
        int varsave_rep_number = 0;
        private void CreateReceipt_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();

            PrintDocument printDocument = new PrintDocument();

            printDialog.Document = printDocument; //add the document to the dialog box...        

            printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(CreateReceipt); //add an event handler that will do the printing

            //on a till you will not want to ask the user where to print but this is fine for the test envoironment.

            DialogResult result = printDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                printDocument.Print();

            } 
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            
                float test1 = float.Parse(txtPrice.Text);

                if (txtName.Text != "")
                {
                    listBox1.Items.Add(txtName.Text.PadRight(30) + txtPrice.Text);


                    varsaveunits += 1;
                    varsavetotal += float.Parse(txtPrice.Text);

                    label12.Text = null;
                    amountcount += float.Parse(txtPrice.Text);
                    label12.Text = Convert.ToString(amountcount);

                    
                    txtName.Text = "";
                    txtPrice.Text = "";
                    textBox1.Text = "";
                }
                else
                {
                    MessageBox.Show("Please enter the ");
                }
            
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            
        }

        public void CreateReceipt(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            float cash = float.Parse(txtCash.Text);
            float change = 0.00f;

            //this prints the reciept

            Graphics graphic = e.Graphics;

            Font font = new Font("Courier New",6); //must use a mono spaced font as the spaces need to line up

            float fontHeight = font.GetHeight();

            int startX = 15;
            int startY =8;
            int offset = 40;

            

            startX = 0;
            startY = 50;
            graphic.DrawString("      Point Of sale", new Font("Courier New", 8), new SolidBrush(Color.Black), startX, startY);

            startX = 0;
            startY = 90;
            graphic.DrawString(" Date: " + DateTime.Now.ToString("dd/MM/yyyy") + " ", new Font("Courier New",6), new SolidBrush(Color.Black), startX, startY);
            startX = 0;
            startY = 110;
            graphic.DrawString(" Time: " + DateTime.Now.ToString("hh:mm tt") + " ", new Font("Courier New",6), new SolidBrush(Color.Black), startX, startY);

            string top = "Item Name".PadRight(30) + "Price";
            graphic.DrawString(top, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight; //make the spacing consistent
            graphic.DrawString("----------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight + 5; //make the spacing consistent

            float totalprice = 0.00f;

            foreach (string item in listBox1.Items)
            {
                //create the string to print on the reciept
                string productDescription = item;
                string productTotal = item.Substring(item.Length - 6, 6);
                float productPrice = float.Parse(item.Substring(item.Length - 5, 5));

                //MessageBox.Show(item.Substring(item.Length - 5, 5) + "PROD TOTAL: " + productTotal);


                totalprice += productPrice;

                if (productDescription.Contains("  -"))
                {
                    string productLine = productDescription.Substring(0, 24);

                    graphic.DrawString(productLine, new Font("Courier New",6, FontStyle.Italic), new SolidBrush(Color.Red), startX, startY + offset);

                    offset = offset + (int)fontHeight + 5; //make the spacing consistent
                }
                else
                {
                    string productLine = productDescription;

                    graphic.DrawString(productLine, font, new SolidBrush(Color.Black), startX, startY + offset);

                    offset = offset + (int)fontHeight + 5; //make the spacing consistent
                }

            }

            change = (cash - totalprice);

            //when we have drawn all of the items add the total

            offset = offset + 20; //make some room so that the total stands out.

            graphic.DrawString("Total to pay ".PadRight(23) + String.Format("PKR {0}", totalprice), new Font("Courier New",6, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);


            offset = offset + 30; //make some room so that the total stands out.

            if (payhold == "cash")
            {
                graphic.DrawString("CASH ".PadRight(23) + String.Format("PKR {0}", cash), font, new SolidBrush(Color.Black), startX, startY + offset);


                offset = offset + 15;
                graphic.DrawString("CHANGE ".PadRight(23) + String.Format("PKR {0}", change), font, new SolidBrush(Color.Black), startX, startY + offset);
            }
            else if (payhold == "credit")
            {
                graphic.DrawString("Credit/ To Pay ".PadRight(23) + String.Format("PKR {0}", cash), font, new SolidBrush(Color.Black), startX, startY + offset);
            }


            offset = offset + 30; //make some room so that the total stands out.

            Random r = new Random();
            varsave_rep_number = r.Next(9999, 999999);

            graphic.DrawString("       Order No: '"+varsave_rep_number+"'", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 15;
            graphic.DrawString("     Thank-you for your custom,", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 15;
            graphic.DrawString("       please come back soon!", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 15;
            graphic.DrawString("        Powered by SPJ-CODER'S ", font, new SolidBrush(Color.Black), startX, startY + offset);


            using (SerialPort serialPort = new SerialPort("portname"))
            {
                try
                {
                    if (!serialPort.IsOpen)
                    {
                        SerialPort sp = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);
                        sp.Open();


                        sp.Write(new byte[] { 0x0C }, 0, 1);
                        sp.Write("   Total = "+Convert.ToString(cash-change));

                        sp.Write(new byte[] { 0x0A, 0x0D }, 0, 2);
                        sp.Write("Balance = "+Convert.ToString(change));
                        sp.Close();

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }  



        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label7.Text = "Date: "+DateTime.Now.ToString("dd/MM/yyyy");
            label8.Text= "Time: "+DateTime.Now.ToString("hh:mm tt");
            this.ActiveControl = textBox1;
            radioButton1.Checked = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string PaymentType="";
            double Amount = 0;
            if (radioButton1.Checked == true)
            {
                PaymentType = "cash";
                payhold = "cash";
                Amount = Convert.ToDouble(txtCash.Text);

                try
                {
                    float test2 = float.Parse(txtCash.Text);

                    PrintDialog printDialog = new PrintDialog();


                    PrintDocument printDocument = new PrintDocument();

                    printDialog.Document = printDocument; //add the document to the dialog box...        

                    printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(CreateReceipt); //add an event handler that will do the printing

                    //on a till you will not want to ask the user where to print but this is fine for the test envoironment.

                    DialogResult result = printDialog.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        printDocument.Print();
                    }

                    listBox1.Items.Clear();
                    txtName.Text = "";
                    txtCash.Text = "";
                    txtPrice.Text = "";

                    //SqlConnection con = new SqlConnection(connection_string.conn);
                    //con.Open();
                    SqlConnection connection = connect.GetConnection();
                    connect.OpenConnection();
                    string holddate = "" + DateTime.Now.ToString("dd/MM/yyyy");
                    string holdtime = "" + DateTime.Now.ToString("hh:mm tt");

                    string query = "insert into tbl_tr (id,date,time,amount,units) values ('" + varsave_rep_number + "','" + holddate + "','" + holdtime + "'," + varsavetotal + "," + varsaveunits + ")";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    connect.CloseConnection();



                }
                catch
                {
                    MessageBox.Show("Please enter numeric value \n\n    ");
                }

            }

            else if(radioButton2.Checked==true)
            {
                PaymentType = "creditcard";
                Amount = Convert.ToDouble(txtCash.Text);
                payhold = "credit";

                try
                {
                    float test2 = float.Parse(txtCash.Text);

                    PrintDialog printDialog = new PrintDialog();


                    PrintDocument printDocument = new PrintDocument();

                    printDialog.Document = printDocument; //add the document to the dialog box...        

                    printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(CreateReceipt); //add an event handler that will do the printing

                    //on a till you will not want to ask the user where to print but this is fine for the test envoironment.

                    DialogResult result = printDialog.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        printDocument.Print();
                    }

                    listBox1.Items.Clear();
                    txtName.Text = "";
                    txtCash.Text = "";
                    txtPrice.Text = "";

                    //SqlConnection con = new SqlConnection(connection_string.conn);
                    //con.Open();
                    SqlConnection connection = connect.GetConnection();
                    connect.OpenConnection();

                    string holddate = "" + DateTime.Now.ToString("dd/MM/yyyy");
                    string holdtime = "" + DateTime.Now.ToString("hh:mm tt");

                    string query = "insert into tbl_tr (id,date,time,amount,units) values ('" + varsave_rep_number + "','" + holddate + "','" + holdtime + "'," + varsavetotal + "," + varsaveunits + ")";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    //con.Close();


                    SqlConnection connection1 = connect.GetConnection();
                    connect.OpenConnection();

                    string query1 = "insert into tbl_credit (id,name,contact) values ('" + varsave_rep_number + "','" + textBox2.Text + "','" + textBox3.Text + "')";

                    SqlCommand cmd1 = new SqlCommand(query1, connection1);
                    cmd1.ExecuteNonQuery();
                    connect.CloseConnection();
                }
                catch
                {
                    MessageBox.Show("Please enter numeric value");
                }
            }
            ///apply strategy pattern 
            PaymentContext context = new PaymentContext();

            if ("CreditCard".Equals(PaymentType, StringComparison.InvariantCultureIgnoreCase))
            {
                context.SetPaymentStrategy(new CreditCardPaymentStrategy());
            }
            else if ("Cash".Equals(PaymentType, StringComparison.InvariantCultureIgnoreCase))
            {
                context.SetPaymentStrategy(new CashPaymentStrategy());
            }

            MessageBox.Show(context.Pay(Amount));

            
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        float amountcount = 0;
        float varsavetotal = 0;
        float varsaveunits = 0;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            float getquantity = 0;
            bool checkingdata = false;

            label7.Text = null;
            label8.Text = null;
            label7.Text = "Date: " + DateTime.Now.ToString("dd/MM/yyyy");
            label8.Text = "Time: " + DateTime.Now.ToString("hh:mm tt");

            //SqlConnection con = new SqlConnection(connection_string.conn);
            //con.Open();
            SqlConnection connection = connect.GetConnection();
            connection.Open();

            float hold=0;
            string query = "select * from tbl_pos where code = '" + textBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txtName.Text = reader[2].ToString();
                 hold= float.Parse(reader[3].ToString());
                 getquantity = float.Parse(reader[4].ToString());
            }

            label12.Text = null;
            txtPrice.Text = Convert.ToString(hold);
            amountcount += hold;
            label12.Text = Convert.ToString(amountcount);
            if(hold!=0)
            {
                varsaveunits += 1;
                varsavetotal += hold;
                checkingdata = true;
                getquantity -= 1;
            }
            connection.Close();

            if (checkingdata==true)
            {
                connection.Open();
                SqlCommand upd = new SqlCommand("update tbl_pos set units='" + getquantity + "' where code='" + textBox1.Text + "' ", connection);
                upd.ExecuteNonQuery();
                connection.Close();
            }


            try
                 {
                     float test1 = float.Parse(txtPrice.Text);

                     if (txtName.Text != "")
                     {
                         listBox1.Items.Add(txtName.Text.PadRight(30) + txtPrice.Text);
                         txtName.Text = "";
                         txtPrice.Text = "";
                         textBox1.Text = "";
                     }
                 }
                 catch
                 {
                     MessageBox.Show("Please enter numeric value ");
                 }


            
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form2 obj = new Form2();
            obj.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Visible = false;
            textBox3.Visible = false;

            label4.Visible = false;
            label5.Visible = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Visible = true;
            textBox3.Visible = true;

            label4.Visible = true;
            label5.Visible = true;

            txtCash.Text = label12.Text;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
