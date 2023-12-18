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
    public partial class frmBloodDonationDrive : Form
    {
        string con = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public frmBloodDonationDrive()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime date = Convert.ToDateTime(dtpDate.Text.Trim());
                string location = txtLocation.Text.Trim();
                string organizer = txtOrganizer.Text.Trim();
                int donrCount = Convert.ToInt32(txtDonorCount.Text.Trim());

                using (SqlConnection connection = new SqlConnection(con))
                {
                    connection.Open();

                    string query = "INSERT INTO BloodDonationDrive (Date, Location,Organizer,DonorCount) VALUES (@Param1, @Param2, @Param3, @Param4)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Param1", date);
                        command.Parameters.AddWithValue("@Param2", location);
                        command.Parameters.AddWithValue("@Param3", organizer);
                        command.Parameters.AddWithValue("@Param4", donrCount);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data saved successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to save data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    connection.Close();
                    clear();
                    loadDataGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void clear()
        {
            txtDonorCount.Text = "";
            txtLocation.Text = "";
            txtOrganizer.Text = "";
            dtpDate.Text = "";
        }

        public void loadDataGrid()
        {
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();

                string query = " select Date,Location,Organizer,DonorCount from BloodDonationDrive ";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    grdUserDetails.DataSource = dataTable;
                }
                connection.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void grdUserDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
