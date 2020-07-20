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
    public partial class Orders : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\database\inventory.mdf;Integrated Security=True;Connect Timeout=30");
        public Orders()
        {
            InitializeComponent();
        }

        private void Orders_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            fill_Product();
            fill_Customer();
            fill_Quantity();

            string qty2 = "select * from Productorder";
            SqlDataAdapter ada = new SqlDataAdapter(qty2, con);
            DataSet da = new DataSet();
            ada.Fill(da, "Productorder");
            dataGridView1.DataSource = da.Tables["Productorder"];

        }
        public  void fill_Product()
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Product";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["Productname"].ToString());
            }

        }
        public void fill_Quantity()
        {
           
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Product";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                txtquantity.Text=dr["Quantity"].ToString();
            }

        }

        public  void fill_Customer()
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Customer";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox3.Items.Add(dr["Customername"].ToString());
            }

        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            txttotal.Text = (int.Parse(txtprice.Text) * int.Parse(txtquantity.Text)).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int qty, price, total, profit;
            string name, pudate, cname, expiredate, putype;
            try
            {
                if (comboBox1.Text == "" || txtquantity.Text == "" || txtprice.Text == "" || txttotal.Text == "" || comboBox2.Text == "" || comboBox3.Text == "" || textBox4.Text == "")

                {
                    MessageBox.Show("Please enter values");
                }
                else
                {
                    name = comboBox1.Text;
                    qty = int.Parse(txtquantity.Text);
                    price = int.Parse(txtprice.Text);
                    total = int.Parse(txttotal.Text);
                    pudate = dateTimePicker1.Value.ToString("dd-MM-yyyy");
                    putype = comboBox2.Text;
                    cname = comboBox3.Text;
                    expiredate = dateTimePicker2.Value.ToString("dd-MM-yyyy");
                    profit = int.Parse(textBox4.Text);

                    SqlCommand cmd1 = con.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = " insert into Productorder values('" + name + "', '" + qty + "', '" + price + "', '" + total + "', '" + pudate + "', '" + putype + "', '" + cname + "', '" + expiredate + "', '" + profit + "')";
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("Record inserted successfully");
                }

            }
            catch (Exception we)
            {
                Console.WriteLine(we);
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

            string qty2 = "select * from Productorder";
            SqlDataAdapter ada = new SqlDataAdapter(qty2, con);
            DataSet da = new DataSet();
            ada.Fill(da, "Productorder");
            dataGridView1.DataSource = da.Tables["Productorder"];

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int no;
            try
            {
                no = int.Parse(txtoid.Text);
                SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\database\inventory.mdf;Integrated Security=True;Connect Timeout=30");
                string qrys = "select * from Productorder where Id='" + no + "'";
                SqlCommand cmd2 = new SqlCommand(qrys, con1);
                try
                {
                    con1.Open();
                    SqlDataReader drt = cmd2.ExecuteReader();
                    if (drt.Read())
                    {
                        no = int.Parse(txtoid.Text);
                        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\database\inventory.mdf;Integrated Security=True;Connect Timeout=30");
                        string qry2 = "delete from Productorder where Id='" + no + "'";
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

        private void button4_Click(object sender, EventArgs e)
        {
            int no;
            try
            {
                no = int.Parse(txtoid.Text);
                string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\database\inventory.mdf;Integrated Security=True;Connect Timeout=30";
                string qry = "select * from Productorder where Id='" + no + "'";
                SqlDataAdapter ada = new SqlDataAdapter(qry, con);
                DataSet dts = new DataSet();
                ada.Fill(dts, " Productorder");
                dataGridView1.DataSource = dts.Tables[" Productorder"];
            }
            catch (Exception we)
            {
                Console.WriteLine(we);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int no2, price, total, profit,qty;
            string name, pudate, cname, expiredate, putype;
            try
            {

                if (comboBox1.Text == "" || txtquantity.Text == "" || txtprice.Text == "" || txttotal.Text == "" || comboBox2.Text == "" || comboBox3.Text == "" || textBox4.Text=="")

                {
                    MessageBox.Show("Please enter values");
                }
                else
                {
                    no2 = int.Parse(txtoid.Text);

                    name = comboBox1.Text;
                    qty = int.Parse(txtquantity.Text);
                    price = int.Parse(txtprice.Text);
                    total = int.Parse(txttotal.Text);
                    pudate = dateTimePicker1.Value.ToString("dd-MM-yyyy");
                    putype = comboBox2.Text;
                    cname = comboBox3.Text;
                    expiredate = dateTimePicker2.Value.ToString("dd-MM-yyyy");
                    profit = int.Parse(textBox4.Text);

                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\database\inventory.mdf;Integrated Security=True;Connect Timeout=30");
                    string qry = "update Productorder set pname='" + name + "',pqty='" + qty + "',pprice='" + price + "', ptotal='" + total + "',purchasedate='"+pudate+ "',purchasetype='"+putype+ "',customername='"+cname+ "',expiredate='"+expiredate+ "',profit='"+profit+"' where Id='" + no2 + "' ";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Updated successfully!");
                    }
                    catch (SqlException rt)
                    {
                        Console.WriteLine(rt);
                    }
                }
            }
            catch (Exception er)
            {
                Console.WriteLine("" + er);
            }
        }
    }
}
