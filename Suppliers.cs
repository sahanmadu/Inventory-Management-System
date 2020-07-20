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
    public partial class Suppliers : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\database\inventory.mdf;Integrated Security=True;Connect Timeout=30");
        public Suppliers()
        {
            InitializeComponent();
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            int sid, quty;
            string sname, pname, sudate;
            try
            {
                if (textBox1.Text==""|| textBox2.Text=="" || textBox3.Text=="" || textBox4.Text=="")
                {
                    MessageBox.Show("Please enter values!!");
                }
                else {
                    sid = int.Parse(textBox1.Text);
                    sname = textBox2.Text;
                    pname = textBox3.Text;
                    quty = int.Parse(textBox4.Text);
                    sudate = dateTimePicker1.Value.ToString("dd-MM-yyyy");

                    SqlCommand cmd1 = con.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = " insert into Suppliers values('" + sid + "','" + sname + "','" + pname + "','" + quty + "','" + sudate + "')";
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("Record inserted successfully");
                }
               
            }
            catch(Exception er)
            {
                Console.WriteLine(""+er);
            }
        }

        private void Suppliers_Load(object sender, EventArgs e)
        {

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            string qty2 = "select * from Suppliers";
            SqlDataAdapter ada = new SqlDataAdapter(qty2, con);
            DataSet da = new DataSet();
            ada.Fill(da, "Suppliers");
            dataGridView1.DataSource = da.Tables["Suppliers"];
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            int no;
            try
            {
                no = int.Parse(txtid.Text);
                string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\database\inventory.mdf;Integrated Security=True;Connect Timeout=30";
                string qry = "select * from Suppliers where SupID='" + no + "'";
                SqlDataAdapter ada = new SqlDataAdapter(qry, con);
                DataSet dts = new DataSet();
                ada.Fill(dts, " Suppliers");
                dataGridView1.DataSource = dts.Tables[" Suppliers"];
            }
            catch (Exception we)
            {
                Console.WriteLine(we);
            }
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            int no;
            try
            {
                no = int.Parse(txtid.Text);
                SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\database\inventory.mdf;Integrated Security=True;Connect Timeout=30");
                string qrys = "select * from Suppliers where SupID='" + no + "'";
                SqlCommand cmd2 = new SqlCommand(qrys, con1);
                try
                {
                    con1.Open();
                    SqlDataReader drt = cmd2.ExecuteReader();
                    if (drt.Read())
                    {
                        no = int.Parse(txtid.Text);
                        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\database\inventory.mdf;Integrated Security=True;Connect Timeout=30");
                        string qry2 = "delete from Suppliers where SupID='" + no + "'";
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

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            int  quty,no1;
            string supName, pname, supDate;
            try
            {

                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
                {
                    MessageBox.Show("Please enter values");
                }
                else
                {
                    no1 = int.Parse(txtid.Text);

                    supName = textBox2.Text;
                    pname = textBox3.Text;
                    quty = int.Parse(textBox4.Text);
                    supDate = dateTimePicker1.Value.ToString("dd-MM-yyyy");

                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\database\inventory.mdf;Integrated Security=True;Connect Timeout=30");
                    string qry = "update Suppliers set SupName='" + supName + "',Pname='" + pname + "',quantity='" + quty + "', SupDate='" + supDate + "' where SupID='" + no1 + "' ";
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

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Home hm = new Home();
            hm.Show();
            this.Hide();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            string qty2 = "select * from Suppliers";
            SqlDataAdapter ada = new SqlDataAdapter(qty2, con);
            DataSet da = new DataSet();
            ada.Fill(da, "Suppliers");
            dataGridView1.DataSource = da.Tables["Suppliers"];
        }
    }
}
