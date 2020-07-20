using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventoryms
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

     

        

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Product fm1 = new Product();
            fm1.Show();
            this.Hide();
        }

        private void emailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Email em1 = new Email();
            em1.Show();
            this.Hide();
        }

        private void showDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please go to the Adimin view");
        }

       

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really want to Log out?", "Exit", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                this.Close();
                Login lg = new Login();
                lg.Show();
            }
            else if (dialog == DialogResult.No)
            {

            }
            
        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really want to exit?", "Exit", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (dialog == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {

            AdminLogin adm = new AdminLogin();
            adm.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            Customer cus = new Customer();
            cus.Show();
            this.Hide();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            Orders ord = new Orders();
            ord.Show();
            this.Hide();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            Reports ret = new Reports();
            ret.Show();
            this.Hide();
            
        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Payments py = new Payments();
            py.Show();
            this.Hide();
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Suppliers sp = new Suppliers();
            sp.Show();
            this.Hide();
        }

       
    }
}
