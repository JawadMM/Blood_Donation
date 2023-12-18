using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blood_Donation
{
    public partial class frmHistory : Form
    {
        string con = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public frmHistory()
        {
            InitializeComponent();
        }

        public void loadDonors()
        {
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();

                string query = "select DonorID,Name from Donor";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    cmbDonor.DataSource = dataTable;
                    cmbDonor.DisplayMember = "Name";
                    cmbDonor.ValueMember = "DonorID";
                }
                connection.Close();
            }
        }

        public void loadRecipiant()
        {
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();

                string query = "select RecipientID,Name from Recipient";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    cmpRecepiant.DataSource = dataTable;
                    cmpRecepiant.DisplayMember = "Name";
                    cmpRecepiant.ValueMember = "RecipientID";
                }
                connection.Close();
            }
        }

        public void loadDataGridforDonor(int donorID)
        {
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();

                string query = "   select DonationDate,ExpirationDate,do.Name,re.Name,bl.BloodGroup,bd.Location from BloodUnit bu inner join Donor do on bu.DonorID = do.DonorID inner join Recipient re on bu.RecipientID = re.RecipientID inner join BloodType bl on bu.BloodTypeID = bl.BloodTypeID inner join BloodDonationDrive bd on bu.DonationDriveID= bd.DriveID where do.DonorID ='"+donorID+"' ";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    grdUserDetails.DataSource = dataTable;
                }
                connection.Close();
            }
        }

        public void loadDataGridforRecipiant(int resId)
        {
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();

                string query = "   select DonationDate,ExpirationDate,do.Name,re.Name,bl.BloodGroup,bd.Location from BloodUnit bu inner join Donor do on bu.DonorID = do.DonorID inner join Recipient re on bu.RecipientID = re.RecipientID inner join BloodType bl on bu.BloodTypeID = bl.BloodTypeID inner join BloodDonationDrive bd on bu.DonationDriveID= bd.DriveID  where re.RecipientID ='"+resId+"' ";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    grdUserDetails.DataSource = dataTable;
                }
                connection.Close();
            }
        }

        private void frmHistory_Load(object sender, EventArgs e)
        {
            try
            {
                loadDonors();
                loadRecipiant();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbDonor_SelectedIndexChanged(object sender, EventArgs e)
        {
  
        }

        private void cmpRecepiant_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmpRecepiant_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                loadDataGridforRecipiant(Convert.ToInt32(cmpRecepiant.SelectedValue));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbDonor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                loadDataGridforDonor(Convert.ToInt32(cmbDonor.SelectedValue));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
