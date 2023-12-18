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
    public partial class frmLogin : Form
    {
        string con = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmHomePage frmHomePage = new frmHomePage("10");
            frmHomePage.Show();

            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string roleId = "1";
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();

                string query = "select * from UserLogin where UserName = '"+txtUserName.Text.Trim()+"' and Password='"+txtPassword.Text.Trim()+"' ";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    connection.Close();

                    
                    if (dataTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in dataTable.Rows)
                        {
                            // Access values in each column
                            roleId = row["UserRole"].ToString();                         
                        }
                        this.Hide();
                        frmHomePage frmHomePage = new frmHomePage(roleId);
                        frmHomePage.Show();

                    }
                    else
                    {
                        MessageBox.Show("Invalid User Name or Password","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    }

                }
                
            }
        }
    }
}
