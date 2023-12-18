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
    public partial class ApproveDonorRecipUpdate : Form
    {
        string con = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public ApproveDonorRecipUpdate()
        {
            InitializeComponent();
        }

        public void loadDataGrid()
        {
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();

                string query = "   select DonorID,case when Status=1 then 'Approved' when Status=2 then 'Approval Pending' else 'Rejected'  end as status,Name,Address,ContactNumber,Email,Age,Weight,HealthStatus from Donor where Status ='2' ";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    grdUserDetails.DataSource = dataTable;
                }
                connection.Close();
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

                    string query = " update Donor set Status='1' where DonorID = '" + id + "' ";
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

        private void btnReject_Click(object sender, EventArgs e)
        {
            try
            {
                string id = txtID.Text.Trim();

                using (SqlConnection connection = new SqlConnection(con))
                {
                    connection.Open();

                    string query = " update Donor set Status='3' where DonorID = '" + id + "'  ";
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

        private void ApproveDonorRecipUpdate_Load(object sender, EventArgs e)
        {
            loadDataGrid();
        }
    }
}
