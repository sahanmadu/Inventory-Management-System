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

namespace Inventoryms
{
    public partial class Addproduct : Form
    {
        public Addproduct()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int productid, price, quantity;
            string pname, category, description;
            try
            {
              
                if (txtpid.Text=="" || txtpname.Text=="" || txtp.Text=="" || txtq.Text=="" || txtcato.Text=="" || txtdes.Text=="" )
                {
                    MessageBox.Show("Please enter values");
                }
                else {
                    productid = int.Parse(txtpid.Text);
                    pname = txtpname.Text;
                    price = int.Parse(txtp.Text);
                    quantity = int.Parse(txtq.Text);
                    category = txtcato.Text;
                    description = txtdes.Text;
                    SqlConnection con3 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\database\inventory.mdf;Integrated Security=True;Connect Timeout=30");
                    string qry = "insert into Product values('" + productid + "','" + pname + "','" + price + "','" + quantity + "','" + category + "','" + description + "')";
                    SqlCommand cmd = new SqlCommand(qry, con3);
                    try
                    {
                        con3.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Product added");
                    }
                    catch (SqlException we)
                    {
                        Console.WriteLine(we);
                    }
                   
                }
                

            }
           
            catch (Exception er)
            {
                Console.WriteLine(er);
            }
           
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Home hm = new Home();
            hm.Show();
            this.Hide();
        }


        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Product pr = new Product();
            pr.Show();
            this.Hide();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really want to exit?", "Exit", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (dialog == DialogResult.No)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtpid.Text = null;
            txtpname.Text = null;
            txtp.Text = null;
            txtq.Text = null;
            txtcato.Text = null;
            txtdes.Text = null;
        }
    }
}
