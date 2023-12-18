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
    public partial class frmBloodDriveDetails : Form
    {
        string con = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public frmBloodDriveDetails()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
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


                string query = "  select Location,count(DonorCount) AS count   from BloodDonationDrive   group by Location ";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    grdReport.DataSource = dataTable;
                    ExportToExcel();
                }
                connection.Close();
            }
        }

        private void ExportToExcel()
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook workbook = excelApp.Workbooks.Add();
                Microsoft.Office.Interop.Excel.Worksheet worksheet = workbook.Sheets[1] as Microsoft.Office.Interop.Excel.Worksheet;

                // Export headers
                for (int i = 1; i <= grdReport.Columns.Count; i++)
                {
                    worksheet.Cells[1, i] = grdReport.Columns[i - 1].HeaderText;
                }

                // Export data
                for (int i = 0; i < grdReport.Rows.Count; i++)
                {
                    for (int j = 0; j < grdReport.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = grdReport.Rows[i].Cells[j].Value;
                    }
                }

                // Save the Excel file
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel Files|*.xlsx|All Files|*.*",
                    Title = "Save Excel File",
                    FileName = "BloodDriveDetails.xlsx"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(saveFileDialog.FileName);
                    workbook.Close();
                    excelApp.Quit();

                    MessageBox.Show("Data exported to Excel successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting to Excel: " + ex.Message);
            }
        }
    }
}
