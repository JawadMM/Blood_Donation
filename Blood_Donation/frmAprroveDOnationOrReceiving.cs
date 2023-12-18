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
    public partial class frmAprroveDOnationOrReceiving : Form
    {
        string con = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public frmAprroveDOnationOrReceiving()
        {
            InitializeComponent();
        }

        public void loadDataGrid()
        {
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();

                string query = "   select UnitID,case when bu.Status=1 then 'Approval Pending' when bu.Status=2 then 'Approved' else 'Rejected'  end as status ,DonationDate,ExpirationDate,do.Name,re.Name,bl.BloodGroup,bd.Location from BloodUnit bu inner join Donor do on bu.DonorID = do.DonorID inner join Recipient re on bu.RecipientID = re.RecipientID inner join BloodType bl on bu.BloodTypeID = bl.BloodTypeID inner join BloodDonationDrive bd on bu.DonationDriveID= bd.DriveID  ";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    grdUserDetails.DataSource = dataTable;
                }
                connection.Close();
            }
        }

        private void frmAprroveDOnationOrReceiving_Load(object sender, EventArgs e)
        {
            loadDataGrid();
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {

            try
            {
                string id = txtID.Text.Trim();

                using (SqlConnection connection = new SqlConnection(con))
                {
                    connection.Open();

                    string query = " update BloodUnit set Status='2' where UnitID = '"+id+"' ";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data Approved successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to Approved data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    connection.Close();
                    loadDataGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            try
            {
                string id = txtID.Text.Trim();

                using (SqlConnection connection = new SqlConnection(con))
                {
                    connection.Open();

                    string query = " update BloodUnit set Status='3' where UnitID = '" + id + "' ";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data Rejected successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to Rejected data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    connection.Close();
                    loadDataGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
