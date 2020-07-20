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
    public partial class Updateproduct : Form
    {
        public Updateproduct()
        {
            InitializeComponent();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Home hm = new Home();
            hm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int productid, price, quantity;
            string pname, category, description;
            try
            {

                if (txt1.Text == "" || txt2.Text == "" || txt3.Text == "" || txt4.Text == "" || txt5.Text == "" || txt6.Text == "")
                {
                    MessageBox.Show("Please enter values");
                }
                else
                {
                    productid = int.Parse(txt1.Text);
                    pname = txt2.Text;
                    price = int.Parse(txt3.Text);
                    quantity = int.Parse(txt4.Text);
                    category = txt5.Text;
                    description = txt6.Text;
                    SqlConnection con3 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\database\inventory.mdf;Integrated Security=True;Connect Timeout=30");
                    string qry = "update Product set Productname='" + pname + "',Price='" + price + "',Quantity='" + quantity + "',Catagery='" + category + "',Description='" + description + "' where ProductID='" + productid + "' ";
                    
                    SqlCommand cmd = new SqlCommand(qry, con3);
                    try
                    {
                        con3.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Updated successfully");
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
            else if(dialog==DialogResult.No)
            {
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txt1.Text = null;
            txt2.Text = null;
            txt3.Text = null;
            txt4.Text = null;
            txt5.Text = null;
            txt6.Text = null;
        }
    }
}
