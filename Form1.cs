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
using System.Threading;

namespace Inventoryms
{
    public partial class Login : Form
    {
        public Login()
        {
            Thread t = new Thread(new ThreadStart(StartForm));
            t.Start();
            Thread.Sleep(5000);

            InitializeComponent();
            t.Abort();
        }

        public void StartForm()
        {
            Application.Run(new LoadFrm());
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.MinimumSize = this.MaximumSize = this.Size;
        }

       

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            string uname, password;
            uname = textBox1.Text;
            password = textBox2.Text;
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\database\inventory.mdf;Integrated Security=True;Connect Timeout=30");
            string qry = "select * from Userdetails where username='" + uname + "' and password='" + password + "'";
            SqlDataAdapter ada = new SqlDataAdapter(qry, con);
            DataTable dbt1 = new DataTable();
            ada.Fill(dbt1);
            if(dbt1.Rows.Count==1)
            {
                Home hm1 = new Home();
                hm1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Your username and password incorrect, try again and signup");
            }
        }

      

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {

            signup openForm1 = new signup();
            openForm1.Show();
            this.Hide();
        }
    }
}
