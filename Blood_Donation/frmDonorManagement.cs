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
    public partial class frmDonorManagement : Form
    {
        string con = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public frmDonorManagement()
        {
            InitializeComponent();
        }

        private void frmDonorManagement_Load(object sender, EventArgs e)
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

        public void loadDataGrid()
        {
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();

                string query = "  select DonorID,Name,Address,ContactNumber,Email,Age,Weight,HealthStatus from Donor";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    grdUserDetails.DataSource = dataTable;
                }
                connection.Close();
            }
        }

        public void clear()
        {
            txtName.Text = "";
            txtAddress.Text = "";
            txtContact.Text = "";
            txtEmail.Text = "";
            txtAge.Text = "";
            txtWeight.Text = "";
            txtHealth.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text.Trim();
                string address = txtAddress.Text.Trim();
                string contact = txtContact.Text.Trim();
                string email = txtEmail.Text.Trim();
                string age = txtAge.Text.Trim();
                string weight = txtWeight.Text.Trim();
                string health = txtHealth.Text.Trim();

                using (SqlConnection connection = new SqlConnection(con))
                    {
                        connection.Open();

                        string query = "INSERT INTO Donor (Name, Address,ContactNumber,Email,Age,Weight,HealthStatus) VALUES (@Param1, @Param2, @Param3, @Param4, @Param5, @Param6, @Param7)";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Param1", name);
                            command.Parameters.AddWithValue("@Param2", address);
                            command.Parameters.AddWithValue("@Param3", contact);
                            command.Parameters.AddWithValue("@Param4", email);
                            command.Parameters.AddWithValue("@Param5", age);
                            command.Parameters.AddWithValue("@Param6", weight);
                            command.Parameters.AddWithValue("@Param7", health);

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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(con))
                {
                    connection.Open();

                    string query = "delete from Donor where Name = '" + txtName.Text.Trim() + "' ";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data Delete successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to Delete data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(con))
                {
                    connection.Open();

                    string query = "select DonorID,Name,Address,ContactNumber,Email,Age,Weight,HealthStatus from Donor where Name='"+txtName.Text.Trim()+"'  ";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        grdUserDetails.DataSource = dataTable;
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text.Trim();
                string address = txtAddress.Text.Trim();
                string contact = txtContact.Text.Trim();
                string email = txtEmail.Text.Trim();
                string age = txtAge.Text.Trim();
                string weight = txtWeight.Text.Trim();
                string health = txtHealth.Text.Trim();

                using (SqlConnection connection = new SqlConnection(con))
                    {
                        connection.Open();

                        string query = "update Donor set Status='2',Address='" + address + "',ContactNumber='"+ contact + "',Email='"+ email + "',Age='"+ age + "',Weight='"+ weight + "',HealthStatus='"+health+"' where Name='"+name+"' ";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Data Updated successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Failed to Updated data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
