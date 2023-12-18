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
    public partial class frmBloodUnit : Form
    {
        string con = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public frmBloodUnit()
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

        public void loadType()
        {
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();

                string query = "select BloodTypeID,BloodGroup from BloodType";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    cmpType.DataSource = dataTable;
                    cmpType.DisplayMember = "BloodGroup";
                    cmpType.ValueMember = "BloodTypeID";
                }
                connection.Close();
            }
        }

        public void loadDrive()
        {
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();

                string query = "select DriveID,Location from BloodDonationDrive";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    cmpDrive.DataSource = dataTable;
                    cmpDrive.DisplayMember = "Location";
                    cmpDrive.ValueMember = "DriveID";
                }
                connection.Close();
            }
        }

        private void frmBloodUnit_Load(object sender, EventArgs e)
        {
            try
            {
                loadDonors();
                loadRecipiant();
                loadType();
                loadDrive();
                loadDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void clear()
        {
            cmpDrive.ResetText();
            cmbDonor.ResetText();
            cmpRecepiant.ResetText();
            cmpType.ResetText();
            dtpExpireDate.Text = "";
            dtpDonatedate.ResetText();
        }

        public void loadDataGrid()
        {
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();

                string query = "   select DonationDate,ExpirationDate,do.Name,re.Name,bl.BloodGroup,bd.Location from BloodUnit bu inner join Donor do on bu.DonorID = do.DonorID inner join Recipient re on bu.RecipientID = re.RecipientID inner join BloodType bl on bu.BloodTypeID = bl.BloodTypeID inner join BloodDonationDrive bd on bu.DonationDriveID= bd.DriveID  ";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    grdUserDetails.DataSource = dataTable;
                }
                connection.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime donateDate = Convert.ToDateTime(dtpDonatedate.Text.Trim());
                DateTime expireDate = Convert.ToDateTime(dtpExpireDate.Text.Trim());
                int reciptID = Convert.ToInt32(cmpRecepiant.SelectedValue);
                int donorId = Convert.ToInt32(cmbDonor.SelectedValue);
                int typeId = Convert.ToInt32(cmpType.SelectedValue);
                int driveId = Convert.ToInt32(cmpDrive.SelectedValue);

                using (SqlConnection connection = new SqlConnection(con))
                    {
                        connection.Open();

                        string query = "INSERT INTO BloodUnit (DonationDate, ExpirationDate,DonorID,RecipientID,BloodTypeID,DonationDriveID) VALUES (@Param1, @Param2, @Param3,@Param4, @Param5, @Param6)";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Param1", donateDate);
                            command.Parameters.AddWithValue("@Param2", expireDate);
                            command.Parameters.AddWithValue("@Param3", reciptID);
                            command.Parameters.AddWithValue("@Param4", donorId);
                            command.Parameters.AddWithValue("@Param5", typeId);
                            command.Parameters.AddWithValue("@Param6", driveId);

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
    }
}
