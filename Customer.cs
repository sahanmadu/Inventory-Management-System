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
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int pno;
            string cname,caddress1,caddress2,email;
            try
            {

                if ( txt2.Text == "" || txt3.Text == "" || txt4.Text == "" || txt5.Text == "" || txt6.Text == "")
                {
                    MessageBox.Show("Please enter values");
                }
                else
                {
                    cname = txt2.Text;
                    caddress1 = txt3.Text;
                    caddress2 = txt4.Text;
                    email = txt5.Text;
                    pno = int.Parse(txt6.Text);
                   
                    SqlConnection con3 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\database\inventory.mdf;Integrated Security=True;Connect Timeout=30");
                    string qry = "insert into Customer values('" + cname + "','" + caddress1+ "','" + caddress2 + "','" + email + "','" + pno + "')";
                    SqlCommand cmd = new SqlCommand(qry, con3);
                    try
                    {
                        con3.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("New Customer added");
                    }
                    catch (SqlException we)
                    {
                        Console.WriteLine(we);
                    }

                }
                txt2.Text = null;
                txt3.Text = null;
                txt4.Text = null;
                txt5.Text = null;
                txt6.Text = null;
               

            }
            catch (Exception er)
            {
                Console.WriteLine(er);
            }
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\database\inventory.mdf;Integrated Security=True;Connect Timeout=30";
            string qry = "select * from Customer";
            SqlDataAdapter ada = new SqlDataAdapter(qry, con);
            DataSet dts = new DataSet();
            ada.Fill(dts, "Customer");
            dataGridView1.DataSource = dts.Tables["Customer"];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int userid;

            try
            {
                userid = int.Parse(txtid.Text);
                SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\database\inventory.mdf;Integrated Security=True;Connect Timeout=30");
                string qrys = "select * from Customer where CustomerID='" + userid + "'";
                SqlCommand cmd1 = new SqlCommand(qrys, con1);
                try
                {
                    con1.Open();
                    SqlDataReader drt = cmd1.ExecuteReader();
                    if (drt.Read())
                    {
                        userid = int.Parse(txtid.Text);
                        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\database\inventory.mdf;Integrated Security=True;Connect Timeout=30");
                        string qryd = "delete from Customer where CustomerID='" + userid + "'";
                        SqlCommand cmd = new SqlCommand(qryd, con);
                        try
                        {
                            con.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Deleted successfully");

                        }
                        catch (SqlException ty)
                        {
                            Console.WriteLine(ty);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalaid ID!!");
                    }
                }
                catch(SqlException et)
                {
                    Console.WriteLine(et);
                }
                
               
                txtid.Text = "";
            }
            catch (Exception er1)
            {
                Console.WriteLine(er1);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int no;
            try
            {
                no = int.Parse(txtid.Text);
                string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\database\inventory.mdf;Integrated Security=True;Connect Timeout=30";
                string qry = "select * from Customer where CustomerID='" + no + "'";
                SqlDataAdapter ada = new SqlDataAdapter(qry, con);
                DataSet dts = new DataSet();
                ada.Fill(dts, "Customer");
                dataGridView1.DataSource = dts.Tables["Customer"];
            }
            catch (Exception we)
            {
                Console.WriteLine(we);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            int pno,uid;
            string cnmae1,cadd1,cadd2,email1;
            try
            {

                if (txt2.Text == "" || txt3.Text == "" || txt4.Text == "" || txt5.Text == "" || txt6.Text == "")
                {
                    MessageBox.Show("Please enter values");
                }
                else
                {
                   
                    cnmae1 = txt2.Text;
                    cadd1 = txt3.Text;
                    cadd2 = txt4.Text;
                    email1 = txt5.Text;
                    pno = int.Parse(txt6.Text);
                    uid = int.Parse(txtid.Text);
                    SqlConnection con3 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\database\inventory.mdf;Integrated Security=True;Connect Timeout=30");
                    string qry = "update Customer set Customername='" + cnmae1 + "',Address1='" + cadd1 + "',Address2='" + cadd2 + "',Email='" + email1 + "',Phonenumber='" + pno + "' where CustomerID='" + uid + "' ";

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
               
                txt2.Text = null;
                txt3.Text = null;
                txt4.Text = null;
                txt5.Text = null;
                txt6.Text = null;


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
            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\database\inventory.mdf;Integrated Security=True;Connect Timeout=30";
            string qry = "select * from Customer";
            SqlDataAdapter ada = new SqlDataAdapter(qry, con);
            DataSet dts = new DataSet();
            ada.Fill(dts, "Customer");
            dataGridView1.DataSource = dts.Tables["Customer"];
        }
    }
}
