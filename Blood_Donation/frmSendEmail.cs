using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blood_Donation
{
    public partial class frmSendEmail : Form
    {
        public frmSendEmail()
        {
            InitializeComponent();
        }

        private void btnSendMail_Click(object sender, EventArgs e)
        {
            try
            {
                // Set your Gmail credentials
                string senderEmail = txtSenderEmail.Text.Trim();
                string senderPassword = txtPassword.Text.Trim();

                // Set the recipient email address
                string recipientEmail = txtRecipientEmail.Text.Trim();

                // Set the email subject and body
                string subject = txtSubject.Text.Trim();
                string body = txtBody.Text.Trim();

                // Create and configure the SMTP client
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);

                // Create the email message
                MailMessage mailMessage = new MailMessage(senderEmail, recipientEmail, subject, body);

                // Send the email
                smtpClient.Send(mailMessage);

                MessageBox.Show("Email sent successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
