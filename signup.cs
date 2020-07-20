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
    public partial class signup : Form
    {
        public signup()
        {
            InitializeComponent();
        }

       

        private void txtuid_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtuid.Text))
            {
                e.Cancel = true;
                txtuid.Focus();
                errorProvider1.SetError(txtuid, "User id required");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtuid, "");
            }
        }

        private void txtFirstname_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFirstname.Text))
            {
                e.Cancel = true;
                txtFirstname.Focus();
                errorProvider1.SetError(txtFirstname, "First name required");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtFirstname, "");
            }
        }

        private void txtLastname_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtLastname.Text))
            {
                e.Cancel = true;
                txtLastname.Focus();
                errorProvider1.SetError(txtLastname, "Last name required");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtLastname, "");
            }
        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                e.Cancel = true;
                txtUsername.Focus();
                errorProvider1.SetError(txtUsername, "Username required");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtUsername, "");
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                e.Cancel = true;
                txtPassword.Focus();
                errorProvider1.SetError(txtPassword, "Password required");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPassword, "");
            }
        }

        private void txtCpassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCpassword.Text))
            {
                e.Cancel = true;
                txtCpassword.Focus();
                errorProvider1.SetError(txtCpassword, "Confirm password required");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtCpassword, "");
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                e.Cancel = true;
                txtEmail.Focus();
                errorProvider1.SetError(txtEmail, "Email required");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtEmail, "");
            }
        }

        private void txtContactno_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtContactno.Text))
            {
                e.Cancel = true;
                txtContactno.Focus();
                errorProvider1.SetError(txtContactno, "Contact no required");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtContactno, "");
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            int uid, cno1;
            string fname, lname, uname, password1, cpassword1, email1;
            try
            {
                if (ValidateChildren(ValidationConstraints.Enabled))
                {
                    if (txtPassword.Text != txtCpassword.Text)
                    {
                        MessageBox.Show("Password and confirm password does not match, try again!");
                    }
                    else
                    {

                        uid = int.Parse(txtuid.Text);
                        fname = txtFirstname.Text;
                        lname = txtLastname.Text;
                        uname = txtUsername.Text;
                        password1 = txtPassword.Text;
                        cpassword1 = txtCpassword.Text;
                        email1 = txtEmail.Text;
                        cno1 = int.Parse(txtContactno.Text);
                        SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\database\inventory.mdf;Integrated Security=True;Connect Timeout=30");
                        string qry1 = "insert into Userdetails values('" + uid + "','" + fname + "','" + lname + "','" + uname + "','" + password1 + "','" + cpassword1 + "','" + email1 + "','" + cno1 + "')";
                        SqlCommand cmd1 = new SqlCommand(qry1, con1);
                        try
                        {
                            con1.Open();
                            cmd1.ExecuteNonQuery();
                            MessageBox.Show("Data inserted successfully");
                        }
                        catch (SqlException sq)
                        {
                            Console.WriteLine(sq);
                        }

                    }
                }
            }
            catch (Exception erp)
            {
                Console.WriteLine(erp);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login lg = new Login();
            lg.Show();
           
        }
    }
}
