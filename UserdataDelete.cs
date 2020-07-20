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
    public partial class UserdataDelete : Form
    {
        public UserdataDelete()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int userid;
                userid = int.Parse(txtuserid.Text);
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\database\inventory.mdf;Integrated Security=True;Connect Timeout=30");
                string qryd = "delete from Userdetails where userid='" + userid + "'";
                SqlCommand cmd = new SqlCommand(qryd, con);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("DEleted successfully");

                }
                catch(SqlException ty)
                {
                    Console.WriteLine(ty);
                }
                txtuserid.Text = "";
            }
            catch(Exception er1)
            {
                Console.WriteLine(er1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Userdata udt1 = new Userdata();
            udt1.Show();
            this.Hide();
        }
    }
}
