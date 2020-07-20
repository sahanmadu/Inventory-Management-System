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
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            string uname, password;
            uname = textBox1.Text;
            password = textBox2.Text;
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\database\inventory.mdf;Integrated Security=True;Connect Timeout=30");
            string qry = "select * from Admindata where username='" + uname + "' and password='" + password + "'";
            SqlCommand cmd = new SqlCommand(qry, con);
            try
            {
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if(rd.Read())
                {
                    Adminpanel ad = new Adminpanel();
                    ad.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Login failed!!!");
                }

            }
            catch(SqlException we)
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
    }
}
