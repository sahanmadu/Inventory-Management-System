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
    public partial class Product : Form
    {
        public Product()
        {
            InitializeComponent();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            Addproduct apr = new Addproduct();
            apr.Show();
            this.Hide();
        }

        private void Product_Load(object sender, EventArgs e)
        {
            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\database\inventory.mdf;Integrated Security=True;Connect Timeout=30";
            string qry = "select * from Product";
            SqlDataAdapter ada = new SqlDataAdapter(qry, con);
            DataSet dts = new DataSet();
            ada.Fill(dts, "Product");
            dataGridView1.DataSource = dts.Tables["Product"];
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            int no;
            try
            {
                no = int.Parse(txtid.Text);
                string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\database\inventory.mdf;Integrated Security=True;Connect Timeout=30";
                string qry = "select * from Product where ProductID='" + no + "'";
                SqlDataAdapter ada = new SqlDataAdapter(qry, con);
                DataSet dts = new DataSet();
                ada.Fill(dts, "Product");
                dataGridView1.DataSource = dts.Tables["Product"];
            }
            catch (Exception we)
            {
                Console.WriteLine(we);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\database\inventory.mdf;Integrated Security=True;Connect Timeout=30";
            string qry = "select * from Product";
            SqlDataAdapter ada = new SqlDataAdapter(qry, con);
            DataSet dts = new DataSet();
            ada.Fill(dts, "Product");
            dataGridView1.DataSource = dts.Tables["Product"];
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            Updateproduct up = new Updateproduct();
            up.Show();
            this.Hide();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            int no;
            try
            {
                no = int.Parse(txtid.Text);
                SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\database\inventory.mdf;Integrated Security=True;Connect Timeout=30");
                string qrys = "select * from Product where ProductID='" + no + "'";
                SqlCommand cmd1 = new SqlCommand(qrys, con1);
                try
                {
                    con1.Open();
                    SqlDataReader drt = cmd1.ExecuteReader();
                    if (drt.Read())
                    {
                        no = int.Parse(txtid.Text);
                        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\database\inventory.mdf;Integrated Security=True;Connect Timeout=30");
                        string qry2 = "delete from Product where ProductID='" + no + "'";
                        SqlCommand cmd = new SqlCommand(qry2, con);
                        try
                        {
                            con.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Record deleted successfully");
                        }
                        catch (SqlException qw)
                        {
                            Console.WriteLine(qw);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalaid Number!!");
                    }




                }
                catch (SqlException we)
                {
                    Console.WriteLine(we);
                }
            }
            catch (Exception rt)
            {
                Console.WriteLine(rt);
            }
            
            }
    
        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Home hm = new Home();
            hm.Show();
            this.Hide();
        }
    }
}
