using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace IDreplacement
{
    public partial class Form1 : Form
    {
        string connectionString = "Server=YABU;Database=ID_Replacement;" +
                                    "Trusted_Connection=True; TrustServerCertificate=True;";
        Form2 studentView;
        Form3 adminView;
        public Form1()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        public class TransparentPanel : Panel
        {
            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);

                // Create a semi-transparent brush
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(128,
                          Color.Tan)))
                {
                    e.Graphics.FillRectangle(brush, this.ClientRectangle);
                }
            }
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {     
            // log in

            Form1 form = new Form1();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    SqlCommand command = new SqlCommand("usp_ConnectLogin_info ", connection);

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@username", textBox1.Text);
                    command.Parameters.AddWithValue("@password", textBox2.Text);
                    SqlParameter outputParam = new SqlParameter("@returnValue", SqlDbType.VarChar, 15)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(outputParam);

                    connection.Open();
                    command.ExecuteNonQuery();
                    string role = outputParam.Value?.ToString();
                    if (role != null)
                    {
                        this.Hide();
                        if (role == "Student") {
                            studentView = new Form2();
                            studentView.Show();
                        } else if (role == "Admin"){
                            adminView = new Form3();
                            adminView.Show();
                        }else{
                            MessageBox.Show("Invalid login credentials!", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            form.Show();
                        }
                    }
                }

            }
            catch (SqlException sq)
            {
                MessageBox.Show($"Connection failed: {sq.Message}", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        
    }
}

        
    

