using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blood_Donation
{
    public partial class frmHomePage : Form
    {
        string user = "";
        public frmHomePage(string userRole)
        {
            InitializeComponent();
            disableMenu();
            enbleMenu(userRole);
        }

        private void disableMenu()
        {
            approvalsToolStripMenuItem.Enabled = false;
            donorToolStripMenuItem.Enabled = false;
            recipientToolStripMenuItem.Enabled = false;
            bloodDriveToolStripMenuItem.Enabled = false;
            bloodUnitToolStripMenuItem.Enabled = false;
            userToolStripMenuItem.Enabled = false;
            notificationToolStripMenuItem.Enabled = false;
        }

        private void enbleMenu(string userRole)
        {
            if(userRole =="1")
            {
                approvalsToolStripMenuItem.Enabled = true;
                donorToolStripMenuItem.Enabled = true;
                recipientToolStripMenuItem.Enabled = true;
                bloodDriveToolStripMenuItem.Enabled = true;
                bloodUnitToolStripMenuItem.Enabled = true;
                userToolStripMenuItem.Enabled = true;
                notificationToolStripMenuItem.Enabled = true;
            }
            else if (userRole == "2")
            {
                approvalsToolStripMenuItem.Enabled = false;
                donorToolStripMenuItem.Enabled = true;
                recipientToolStripMenuItem.Enabled = true;
                bloodDriveToolStripMenuItem.Enabled = true;
                bloodUnitToolStripMenuItem.Enabled = true;
                userToolStripMenuItem.Enabled = true;
                notificationToolStripMenuItem.Enabled = true;
            }
            else if (userRole == "3")
            {
                approvalsToolStripMenuItem.Enabled = true;
                donorToolStripMenuItem.Enabled = false;
                recipientToolStripMenuItem.Enabled = false;
                bloodDriveToolStripMenuItem.Enabled = false;
                bloodUnitToolStripMenuItem.Enabled = false;
                userToolStripMenuItem.Enabled = false;
                notificationToolStripMenuItem.Enabled = false;
            }
            else if (userRole == "4")
            {
                approvalsToolStripMenuItem.Enabled = true;
                donorToolStripMenuItem.Enabled = false;
                recipientToolStripMenuItem.Enabled = false;
                bloodDriveToolStripMenuItem.Enabled = false;
                bloodUnitToolStripMenuItem.Enabled = false;
                userToolStripMenuItem.Enabled = false;
                notificationToolStripMenuItem.Enabled = false;
            }
            else
            {
                approvalsToolStripMenuItem.Enabled = false;
                donorToolStripMenuItem.Enabled = false;
                recipientToolStripMenuItem.Enabled = false;
                bloodDriveToolStripMenuItem.Enabled = false;
                bloodUnitToolStripMenuItem.Enabled = false;
                userToolStripMenuItem.Enabled = false;
                notificationToolStripMenuItem.Enabled = false;
            }
        }

        private void donorManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDonorManagement donor = new frmDonorManagement();
            donor.Show();
        }

        private void recipientManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRecipientManagement frmRecipientManagement = new frmRecipientManagement();
            frmRecipientManagement.Show();
        }

        private void bloodDriveManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBloodDonationDrive frmBloodDonationDrive = new frmBloodDonationDrive();
            frmBloodDonationDrive.Show();
        }

        private void bloodUnitManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBloodUnit frmBloodUnit = new frmBloodUnit();
            frmBloodUnit.Show();
        }

        private void userManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserManagement frmUserManagement = new frmUserManagement();
            frmUserManagement.Show();
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSendEmail frmSendEmail = new frmSendEmail();
            frmSendEmail.Show();
        }

        private void logOutToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            // Create a list to store forms to close
            List<Form> formsToClose = new List<Form>();

            // Identify forms to close and add them to the list
            foreach (Form form in Application.OpenForms)
            {
                // Exclude the login form from the list of forms to close
                if (form != this )
                {
                    formsToClose.Add(form);
                }
            }

            this.Close();


            // Open the login form
            frmLogin loginForm = new frmLogin();
            loginForm.Show();
        }

        private void bloodDonationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBloodDonation frmBloodDonation = new frmBloodDonation();
            frmBloodDonation.Show();
        }

        private void bloodTypeDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBloodTypeWIseCount frmBloodTypeWIseCount = new frmBloodTypeWIseCount();
            frmBloodTypeWIseCount.Show();
        }

        private void bloodDriveDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBloodDriveDetails frmBloodDriveDetails = new frmBloodDriveDetails();
            frmBloodDriveDetails.Show();
        }

        private void bloodDonationReceivingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAprroveDOnationOrReceiving frmAprroveDOnationOrReceiving = new frmAprroveDOnationOrReceiving();
            frmAprroveDOnationOrReceiving.Show();
        }

        private void donorUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApproveDonorRecipUpdate ApproveDonorRecipUpdate = new ApproveDonorRecipUpdate();
            ApproveDonorRecipUpdate.Show();
        }

        private void recipientUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmApproveResUpdate frmApproveResUpdate = new frmApproveResUpdate();
            frmApproveResUpdate.Show();
        }

        private void confirmPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void confirmPaymentToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmConfirmPayment frmConfirmPayment = new frmConfirmPayment();
            frmConfirmPayment.Show();
        }

        private void paymentDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPaymentSummery frmPaymentSummery = new frmPaymentSummery();
            frmPaymentSummery.Show();
        }
    }
}
