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
    public partial class Payments : Form
    {
        public Payments()
        {
            InitializeComponent();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            Home hm = new Home();
            hm.Show();
            this.Hide();
        }

        private void bunifuCheckbox1_OnChange(object sender, EventArgs e)
        {
            bunifuCheckbox1.Checked = bunifuCheckbox2.Checked = bunifuCheckbox3.Checked = false;
            ((Bunifu.Framework.UI.BunifuCheckbox)sender).Checked = true;
        }

        private void bunifuCheckbox2_OnChange(object sender, EventArgs e)
        {
            bunifuCheckbox1.Checked = bunifuCheckbox2.Checked = bunifuCheckbox3.Checked = false;
            ((Bunifu.Framework.UI.BunifuCheckbox)sender).Checked = true;
        }

        private void bunifuCheckbox3_OnChange(object sender, EventArgs e)
        {
            bunifuCheckbox1.Checked = bunifuCheckbox2.Checked = bunifuCheckbox3.Checked = false;
            ((Bunifu.Framework.UI.BunifuCheckbox)sender).Checked = true;
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            int cno,pno;
            string chname;
            try
            {
                chname = textBox1.Text;
                cno = int.Parse(textBox2.Text);
                pno = int.Parse(textBox3.Text);
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\database\inventory.mdf;Integrated Security=True;Connect Timeout=30");
                string qry = "insert into Payments values('" + chname + "','" + cno + "','" + pno + "')";
                SqlCommand cmd = new SqlCommand(qry, con);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully");
                }
                catch(SqlException er)
                {
                    Console.WriteLine("" + er);
                }
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
            catch (Exception we)
            {
                Console.WriteLine(we);
            }
        }
    }
}
