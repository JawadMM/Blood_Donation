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
    public partial class frmConfirmPayment : Form
    {
        string con = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public frmConfirmPayment()
        {
            InitializeComponent();
        }

        public void loadDataGrid()
        {
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();

                string query = "   select UnitID,case when IsPaid='1' then 'Payment Confirmed' else 'Payment Pending' end as payment,DonationDate,ExpirationDate,do.Name,re.Name,bl.BloodGroup,bd.Location from BloodUnit bu inner join Donor do on bu.DonorID = do.DonorID inner join Recipient re on bu.RecipientID = re.RecipientID inner join BloodType bl on bu.BloodTypeID = bl.BloodTypeID inner join BloodDonationDrive bd on bu.DonationDriveID= bd.DriveID  ";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    grdUserDetails.DataSource = dataTable;
                }
                connection.Close();
            }
        }

        private void frmConfirmPayment_Load(object sender, EventArgs e)
        {
            try
            {
                loadDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                string id = txtID.Text.Trim();

                using (SqlConnection connection = new SqlConnection(con))
                {
                    connection.Open();

                    string query = " update BloodUnit set IsPaid ='1' where UnitID = '" + id + "' ";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data Payment Confirm successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to Payment Confirm  data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    txtID.Text = "";
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
