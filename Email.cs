using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

namespace Inventoryms
{
    public partial class Email : Form
    {
        public Email()
        {
            InitializeComponent();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                MailMessage message = new MailMessage();
                message.From = new MailAddress(txtemailid.Text);
                message.To.Add(txtto.Text);
                message.Body = txtbody.Text;
                message.Subject = txtsubject.Text;
                client.UseDefaultCredentials = false;
                client.EnableSsl = true;
                if (txtattachment.Text != "")
                {
                    message.Attachments.Add(new Attachment(txtattachment.Text));
                }
                client.Credentials = new System.Net.NetworkCredential(txtemailid.Text, txtpassword.Text);
                client.Send(message);
                message = null;
                MessageBox.Show("Message sent");
            }
            catch (Exception em)
            {
                Console.WriteLine(em);
            }
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            txtto.Text = null;
            txtsubject.Text = null;
            txtbody.Text = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtattachment.Text = openFileDialog1.FileName.ToString();
            }
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Home hm1 = new Home();
            hm1.Show();
            this.Hide();
        }
    }
}
