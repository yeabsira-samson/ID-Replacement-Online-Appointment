using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
namespace IDreplacement
{
    public partial class Form2 : Form
    {
        string connectionString = "Server=YABU;Database=ID_Replacement;" +
                                    "Trusted_Connection=True; TrustServerCertificate=True;";
        // to tell the process progress
        private ProgressBar progressBar;
        
        private void InitializeProgressBar()
        {
            progressBar = new ProgressBar
            {
                Name = "progressBar",
                Minimum = 0,
                Maximum = 100,
                Value = 0, 
                Size = new Size(112, 34), 
                Location = new Point(342, 176), 
                Visible = false 
            };


            this.Controls.Add(progressBar);
        }
         
        public Form2()
        {
            
            InitializeComponent();
            InitializeProgressBar();

            // creating the initial size and location (x,y,width,hight) 
            panel3.SetBounds(220, 140, 0, 215);
            panel4.SetBounds(220, 140, 0, 215);
            panel5.SetBounds(220, 140, 0, 215);
            panel2.SetBounds(220, 140, 592, 215);

            DatabaseConnection.TestConnection();

            /* the first name text box in student 
             * that make them not insert number and other special character 
            */
            textBox1.KeyPress += (sender, arg) => {
                if (!char.IsLetter(arg.KeyChar) && !char.IsControl(arg.KeyChar))
                {
                    // the event is handled and the key press is ignored.
                    arg.Handled = true;
                }
            };
            /* the last name text box in student
             * that make them not insert number and other special character 
             */
            textBox2.KeyPress += (sender, arg) =>
            {
                if (!char.IsLetter(arg.KeyChar) && !char.IsControl(arg.KeyChar))
                {
                    // the event is handled and the key press is ignored.
                    arg.Handled = true;
                }
            };


        }
        private void btncancel_Click(object sender, EventArgs e)
        {
            // Cancel

            string studentId = Microsoft.VisualBasic.Interaction.InputBox(
                "Enter the Student ID to cancel the appointment:",
                "Cancel Appointment",
                "");
            string type= Microsoft.VisualBasic.Interaction.InputBox(
               "Enter the type of request to cancel the appointment(Deactivate,Replacement): ",
               "Cancel Appointment",
               "");
            

            if (!string.IsNullOrEmpty(studentId) && !string.IsNullOrEmpty(type))
            {
                try
                {
                    var result = MessageBox.Show(
                        $"Are you sure you want to cancel the appointment for Student ID: {studentId}?",
                        "Confirmation",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.OK)
                    {
                        using (SqlConnection con = new SqlConnection(connectionString))
                        {
                            con.Open();
                            using (SqlCommand cmd = new SqlCommand("usp_Delete_from_Appointment", con))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;

                                cmd.Parameters.AddWithValue("@id", studentId);
                                cmd.Parameters.AddWithValue ("@type", type);

                                 int row = cmd.ExecuteNonQuery();

                                if (row > 0)
                                {
                                    MessageBox.Show("The appointment has been cancelled successfully.",
                                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("Id is not found.",
                                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                }

                                
                            }
                        }
                    }
                }
                catch (SqlException p)
                {
                    MessageBox.Show($"A database error occurred: {p.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Operation cancelled. No Student ID provided.",
                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //panel2
        private void btnbook_Click(object sender, EventArgs e)
        {
            //next on book
            //change the panel size and position in the form to make it visible 
            panel3.SetBounds(0, 0, 592, 215);

            // forces the panel to redraw itself
            panel3.Invalidate();
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            //logout

            DialogResult result = MessageBox.Show("Are you sure you want to log out?",
                 "Log Out Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Dispose();   
                Form1 loginForm = new Form1();
                loginForm.Show(); 
                
            }
            else
            {
                MessageBox.Show("Log out cancelled.","Information");
            }

        }
        //panel3
        private void btnback4_Click(object sender, EventArgs e)
        {
            //Back
            // change the size and position of the panal so that to hide visible
            panel3.SetBounds(0, 0, 0, 215);

            //forcing the panal to redraw itself
            panel3.Invalidate();
        }

        private void btnnext5_Click(object sender, EventArgs e)
        {
            //next
            //change the panel size and position in the form to make it visible 
            panel4.SetBounds(0, 0, 592, 215);

            //forcing the panal to redraw itself
            panel4.Invalidate();

        }
        //panel4
        private void btnback6_Click(object sender, EventArgs e)
        {
            //back

            //change the size and position of the panal so that to hide visible
            panel4.SetBounds(0, 0, 0, 215);

            //forcing the panal to redraw itself
            panel4.Invalidate();
        }

        private void btnnext7_Click(object sender, EventArgs e)
        {
            //next
            //change the panel size and position in the form to make it visible 
            panel5.SetBounds(0, 0, 592, 215);

            //forcing the panal to redraw itself
            panel5.Invalidate();

        }
        //panel5
        private void btnback8_Click(object sender, EventArgs e)
        {
            //back
            //change the size and position of the panal so that to hide visible
            panel5.SetBounds(0, 0, 0, 215);

            //forcing the panal to redraw itself
            panel5.Invalidate();
        }

        // purpose of async is to make it usable after the btn is clicked 
        private async void btnsubmit_Click(object sender, EventArgs e)
        {
            //submit
           
            if (string.IsNullOrEmpty(textBox1.Text) ||
                string.IsNullOrEmpty(textBox2.Text) ||
                string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Fill the form properly.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            string selectedValue = string.Empty;

            if (radioButton1.Checked)
            {
                selectedValue = radioButton1.Text;
            }
            else if (radioButton2.Checked)
            {
                selectedValue = radioButton2.Text;
            }

            if (string.IsNullOrEmpty(selectedValue))
            {
                MessageBox.Show("Please select a valid request type.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime date;

            if (!DateTime.TryParse(dateTimePicker1.Text, out date) || date < DateTime.Today)
            {
                MessageBox.Show("Invalid date. Please select a valid future date.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {

                btnsubmit.Text = "Processing...";
                btnsubmit.Enabled = false;
                progressBar.Visible = true;

                await Task.Run(() => SimulateProcessing());


                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("usp_Insert_to_Appointment", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlParameter outputParam = new SqlParameter("@out_Value", SqlDbType.VarChar, 15)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(outputParam);
                    command.Parameters.AddWithValue("@id", textBox3.Text);
                    command.Parameters.AddWithValue("@Appoint_date", date);
                    command.Parameters.AddWithValue("@Request", selectedValue);

                    connection.Open();
                    command.ExecuteNonQuery();
                    string msg = outputParam.Value?.ToString();
                    if (msg != null)
                    {
                        if (msg == "Complete")
                        {
                            MessageBox.Show("Processing Complete!", "Success", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                          
                        } 
                        else if (msg == "Denied")
                        {
                            MessageBox.Show("Appointment alredy exists", "Information", MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Invalid Student id ", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);  
                        }
                    }                    
                }
            }
            catch (SqlException q)
            {
                MessageBox.Show($"Database connection failed: {q.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exs)
            {
                MessageBox.Show($"An error occurred: {exs.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

                btnsubmit.Text = "Submit";
                btnsubmit.Enabled = true;
                progressBar.Visible = false;
            }
        }

        private void SimulateProcessing()
        {
            System.Threading.Thread.Sleep(3000);
        }



        private void btnnotify_Click(object sender, EventArgs e)
        {
            // notification

            string studentId =
                Microsoft.VisualBasic.Interaction.InputBox(
               "Enter the Student ID to see the notification:",
               "Check Notification",
               "");
          

            if (!string.IsNullOrEmpty(studentId))
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        
                        con.Open();
                       
                        using (SqlCommand cmd = new SqlCommand("usp_Recive_Message",con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Student_Id", studentId);
                            

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    // Build a string to show all messages
                                    string messages = "Notifications:\n";

                                    while (reader.Read())
                                    {
                                        messages += $"- {reader["Message_Student"]}\n";
                                    }

                                    // Display the notifications in a MessageBox
                                    MessageBox.Show(messages, "Notifications",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("No notifications found for this Student ID.",
                                        "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                }
                catch (SqlException s)
                {
                    MessageBox.Show($"A database error occurred: {s.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Operation cancelled. No Student ID provided.",
                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}