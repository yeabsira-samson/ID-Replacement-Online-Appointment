using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.Sql;
using Microsoft.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using OfficeOpenXml;
namespace IDreplacement
{
    
    public partial class Form3 : Form
    {
        string connectionString = "Server=YABU;Database=ID_Replacement;" +
                                     "Trusted_Connection=True; TrustServerCertificate=True;";
        public void hider()
        {
            panel2.Visible = false; // view btn 
            panel3.Visible = false; // msg btn
        }
        public Form3()
        {
            InitializeComponent();
            hider();
            DatabaseConnection.TestConnection();
        }

        private void btnview_Click(object sender, EventArgs e)
        {
            //viewall
            hider();
            panel2.Visible = true;
            gridView1();


        }
        // appointment table 
        public void gridView1()
        {
           
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    //fetch data from the database
                    using (SqlDataAdapter adapter = new SqlDataAdapter("usp_Select_Appointment", connection)){ 

                        adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                        
                        DataTable dataTable = new DataTable();
                        //fills the retrieved data into dataTable
                        adapter.Fill(dataTable);

                        // Bind the DataTable to the DataGridView
                        dataGridView1.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }


        private void btnreport_Click(object sender, EventArgs e)
        {
            //report
            
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string filePath = $@"C:\Users\25192\OneDrive\Desktop\Appointment report_{timestamp}.xlsx";

            try
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("usp_Select_Appointment", connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            // license setting to work
                            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                            // represents an Excel file
                            using (var package = new ExcelPackage())
                            {
                                // adding worksheet called appointment
                                var worksheet = package.Workbook.Worksheets.Add("Appointment");


                                for (int col = 0; col < reader.FieldCount; col++)
                                {
                                    //writes the column names in the first row of the Excel sheet
                                    worksheet.Cells[1, col + 1].Value = reader.GetName(col);
                                }

                                // row 2 b/c row 1 is the header
                                int row = 2;
                                while (reader.Read())
                                {
                                    for (int col = 0; col < reader.FieldCount; col++)
                                    {
                                        //writes the database values into the corresponding Excel cell
                                        worksheet.Cells[row, col + 1].Value = reader.GetValue(col);


                                        if (col == 2)
                                        {
                                            worksheet.Cells[row, col + 1].Style.Numberformat.Format
                                                = "yyyy-MM-dd";
                                        }
                                    }
                                    row++; //moves to the next row in the excel sheet
                                }


                                worksheet.Cells.AutoFitColumns();

                                /*converts the Excel file into a byte array and  writes 
                                 * the byte array to disk, saving the Excel file0
                                 */
                                File.WriteAllBytes(filePath, package.GetAsByteArray());

                                MessageBox.Show($"Excel file created successfully at {filePath}.",
                                        "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while retrieving the notifications:\n" + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            //logout
            DialogResult result = MessageBox.Show(
                "Are you sure you want to log out?",
                     "Log Out Confirmation",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question
    );

            if (result == DialogResult.Yes)
            {
                this.Dispose();     
                Form1 loginForm = new Form1(); 
                loginForm.Show(); 
                
            }
            else
            {
                MessageBox.Show("Log out cancelled.");
            }

        }

        private void btnmessage_Click(object sender, EventArgs e)
        {
            //msg
            hider();
            panel3.Visible = true;
            gridView2();


        }
        //notification table 
        public void gridView2()
        {
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    //fetch data from the database
                    using (SqlDataAdapter adapter = new SqlDataAdapter("usp_Select_Notification", connection))
                    { 
                      
                        adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                 
                        DataTable dataTable = new DataTable();
                        //fills the retrieved data
                        adapter.Fill(dataTable);

                        // Bind the DataTable to the DataGridView
                        dataGridView2.DataSource = dataTable;



                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }


        }

        private void update_Click(object sender, EventArgs e)
        {
            //update in view
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string student_id = Convert.ToString(selectedRow.Cells["Student_Id"].Value);
                string newStatus = statusbox.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(newStatus))
                {
                    try
                    {
                        using (SqlConnection con = new SqlConnection(connectionString))
                        {
                            con.Open();
                            SqlCommand cmd = new SqlCommand("usp_Update_and_Insert", con);
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@Student_Id", student_id);
                            cmd.Parameters.AddWithValue("@Appointment_Status", newStatus);


                            cmd.ExecuteNonQuery();
                            selectedRow.Cells["Status"].Value = newStatus;

                            MessageBox.Show("Status updated successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);


                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("An error occurred while updating the status:\n" + ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a valid status from the dropdown.", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please select a row to update.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }


        private void Search_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();

            string studentId = txtStudentid.Text;

            if (!string.IsNullOrEmpty(studentId))
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();

                        SqlCommand cmd = new SqlCommand("usp_Select_Specific_Studentid", con);
                        cmd.Parameters.AddWithValue("@Student_Id", studentId);

                        //fetch data from the database
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                            dataTable.Clear();
                            //fills the retrieved data
                            adapter.Fill(dataTable);
                        }

                        
                        if (dataTable.Rows.Count > 0)
                        {
                            // Bind the DataTable to the DataGridView
                            dataGridView2.DataSource = dataTable;
                        }
                        else
                        {
                            MessageBox.Show("No notifications found for this Student ID.", "No Data",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while retrieving the notifications:\n" + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid Student ID.", "Input Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }





        private void send_Click(object sender, EventArgs e)
        {
            
            if (dataGridView2.SelectedRows.Count > 0)
            {
                try
                {
                    
                    string studentId = dataGridView2.SelectedRows[0].Cells["Student_Id"].Value?.ToString();

                    if (!string.IsNullOrEmpty(studentId))
                    {
                        using (SqlConnection con = new SqlConnection(connectionString))
                        {
                            con.Open();
                            SqlCommand cmd = new SqlCommand("usp_Send_Message", con);
                            cmd.CommandType = CommandType.StoredProcedure;

                            
                            cmd.Parameters.AddWithValue("@student_id", studentId);

                            int rowsAffected = cmd.ExecuteNonQuery();
                           
                            if (rowsAffected > 0)
                            {
                                dataGridView2.SelectedRows[0].Cells["Status"].Value = "Sent";

                                MessageBox.Show("The notifications have been sent and status updated.",
                                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("No notifications were found for the given Student ID.",
                                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select a valid row with a valid Student ID.",
                            "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("An error occurred while updating the status:\n" + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while updating the status:\n" + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a row in the DataGridView to proceed.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}