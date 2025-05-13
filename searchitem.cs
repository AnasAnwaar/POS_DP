using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication14
{
    public partial class searchitem : Form
    {
        public searchitem()
        {
            InitializeComponent();
        }

        private void searchitem_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saleitemtype saleitemtype;

            if (radioButton1.Checked == true)
            {

                saleitemtype = new productFactory(textBox1.Text).CreateProduct();
                if (saleitemtype != null)
                {
                    label1.Text = "Type : Product";
                    label3.Text = "Name : " + saleitemtype.Getname();
                    label4.Text = "Ammount : " + saleitemtype.Getammount();
                    label5.Text = "Quantity : " + saleitemtype.Getquantity();
                }
                else
                {
                    MessageBox.Show("Invalid");
                }
            }

            else if (radioButton2.Checked == true)
            {
                saleitemtype = new serviceFactory(textBox1.Text).CreateProduct();
                if (saleitemtype != null)
                {
                    label1.Text = "Type : Service";
                    label3.Text = "Name : " + saleitemtype.Getname();
                    label4.Text = "Ammount : " + saleitemtype.Getammount();
                    label5.Text = "Quantity : " + saleitemtype.Getquantity();
                }
                else
                {
                    MessageBox.Show("Invalid");
                }
            }
        }

        private void searchitem_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form3 obj = new Form3();
            obj.Show();
            this.Hide();

        }
    }
}
