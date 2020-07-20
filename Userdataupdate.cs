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
    public partial class Userdataupdate : Form
    {
        public Userdataupdate()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id,contactno;
            string fname, uname, lname, password, cpassword, email;
           
            try
            {
                if (txt1.Text=="" || txt2.Text=="" || txt3.Text=="" || txt4.Text=="" || txt5.Text=="" || txt6.Text=="" || txt7.Text=="" || txt8.Text=="")
                {
                    MessageBox.Show("Enter values!!");
                }
                else if (txt5.Text!=txt6.Text)
                {
                    MessageBox.Show("Password and confirm password are does not match!!");
                }
                else {
                    id = int.Parse(txt1.Text);
                    fname = txt2.Text;
                    lname = txt3.Text;
                    uname = txt4.Text;
                    password = txt5.Text;
                    cpassword = txt6.Text;
                    email = txt7.Text;
                    contactno = int.Parse(txt8.Text);

                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\database\inventory.mdf;Integrated Security=True;Connect Timeout=30");
                    string query = "update Userdetails set userid='" + id + "' , firstname='" + fname + "' , lastname='" + lname + "' , username='" + uname + "' , password='" + password + "' , cpassword='" + cpassword + "' , email='" + email + "' , contactno='" + contactno + "' where userid='" + id + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Updated successfully");
                    }
                    catch (SqlException we)

                    {
                        Console.WriteLine(we);
                    }
                    txt1.Text = "";
                    txt2.Text = "";
                    txt3.Text = "";
                    txt4.Text = "";
                    txt5.Text = "";
                    txt6.Text = "";
                    txt7.Text = "";
                    txt8.Text = "";
                }
            }
            catch(Exception er)
            {
                Console.WriteLine(er);
               
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Userdata ud = new Userdata();
            ud.Show();
            this.Hide();
        }
    }
}
