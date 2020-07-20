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
    public partial class Userdata : Form
    {
        public Userdata()
        {
            InitializeComponent();
        }

        private void bunifuThinButtonu_Click(object sender, EventArgs e)
        {
            Userdataupdate usd = new Userdataupdate();
            usd.Show();
            this.Hide();
        }

        private void bunifuThinButtond_Click(object sender, EventArgs e)
        {
            UserdataDelete usd = new UserdataDelete();
            usd.Show();
            this.Hide();
        }

        private void bunifuThinButtons_Click(object sender, EventArgs e)
        {
            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\database\inventory.mdf;Integrated Security=True;Connect Timeout=30";
            string qry = "select * from Userdetails";
            SqlDataAdapter ada = new SqlDataAdapter(qry, con);
            DataSet dts = new DataSet();
            ada.Fill(dts, "Userdetails");
            dataGridView1.DataSource = dts.Tables["Userdetails"];
        }

        private void Userdata_Load(object sender, EventArgs e)
        {
            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\database\inventory.mdf;Integrated Security=True;Connect Timeout=30";
            string qry = "select * from Userdetails";
            SqlDataAdapter ada = new SqlDataAdapter(qry, con);
            DataSet dts = new DataSet();
            ada.Fill(dts, "Userdetails");
            dataGridView1.DataSource = dts.Tables["Userdetails"];
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Home hm = new Home();
            hm.Show();
            this.Hide();
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Adminpanel adp = new Adminpanel();
            adp.Show();
            this.Hide();
        }
    }
}
