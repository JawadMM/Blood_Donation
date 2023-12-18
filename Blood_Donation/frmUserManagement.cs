using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace Blood_Donation
{
    public partial class frmUserManagement : Form
    {
        string con = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public frmUserManagement()
        {
            InitializeComponent();
        }

        public void loadUserRoles()
        {
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();

                string query = "SELECT RoleId,RoleName FROM UserRoles";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    cmbUserRole.DataSource = dataTable;
                    cmbUserRole.DisplayMember = "RoleName";
                    cmbUserRole.ValueMember = "RoleId";
                }
                connection.Close();
            }          
        }

        public void clear()
        {
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtReEnter.Text = "";
            cmbUserRole.ResetText();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string userName = txtUserName.Text.Trim();
                string password = txtPassword.Text.Trim();
                string rePassword = txtReEnter.Text.Trim();
                int roleId = Convert.ToInt32(cmbUserRole.SelectedValue);
                if(password == rePassword)
                {
                    using (SqlConnection connection = new SqlConnection(con))
                    {
                        connection.Open();

                        string query = "INSERT INTO UserLogin (UserName, Password,UserRole) VALUES (@Param1, @Param2, @Param3)";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Param1", userName);
                            command.Parameters.AddWithValue("@Param2", password);
                            command.Parameters.AddWithValue("@Param3", roleId);

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
                else
                {
                    MessageBox.Show("Password Missmatched", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(),"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void frmUserManagement_Load(object sender, EventArgs e)
        {
            try
            {
                loadUserRoles();
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

                string query = " select UserId,UserName,Password,RoleName from UserLogin UL inner join UserRoles UR on ul.UserRole = ur.RoleId ";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    grdUserDetails.DataSource = dataTable;
                }
                connection.Close();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(con))
                {
                    connection.Open();

                    string query = "select UserId,UserName,Password,RoleName from UserLogin UL inner join UserRoles UR on ul.UserRole = ur.RoleId where UserName ='"+txtUserName.Text.Trim()+"' ";
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(con))
                {
                    connection.Open();

                    string query = "delete from UserLogin where UserName = '"+txtUserName.Text.Trim()+"' ";
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string userName = txtUserName.Text.Trim();
                string password = txtPassword.Text.Trim();
                string rePassword = txtReEnter.Text.Trim();
                int roleId = Convert.ToInt32(cmbUserRole.SelectedValue);
                if (password == rePassword)
                {
                    using (SqlConnection connection = new SqlConnection(con))
                    {
                        connection.Open();

                        string query = "update UserLogin set Password = '"+ password + "',UserRole='"+ roleId + "' where UserName = '" + userName + "' ";
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
                else
                {
                    MessageBox.Show("Password Missmatched", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
