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
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cname;
            cname = textBox1.Text;
            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\database\inventory.mdf;Integrated Security=True;Connect Timeout=30";
            string qry = "select * from Productorder where customername='" + cname + "'";
            SqlDataAdapter ada = new SqlDataAdapter(qry, con);
            DataSet da = new DataSet();
            ada.Fill(da, "Productorder");
            dataGridView1.DataSource = da.Tables["Productorder"];



        }

        private void button3_Click(object sender, EventArgs e)
        {
            string cname;
            cname = textBox1.Text;
            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\database\inventory.mdf;Integrated Security=True;Connect Timeout=30";
            string qry = "select customername,pqty,ptotal,expiredate,profit from Productorder where customername='" + cname + "'";
            SqlDataAdapter ada = new SqlDataAdapter(qry, con);
            DataSet da = new DataSet();
            ada.Fill(da, "Productorder");
            dataGridView1.DataSource = da.Tables["Productorder"];
        }


        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap obj = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            dataGridView1.DrawToBitmap(obj, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));
            e.Graphics.DrawImage(obj, 30,20);

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        

        private void homeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Home hm = new Home();
            hm.Show();
            this.Hide();
        }
    }
}
