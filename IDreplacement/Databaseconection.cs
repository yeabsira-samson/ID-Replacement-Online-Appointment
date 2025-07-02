using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sql;
using System.Data;


namespace IDreplacement
{
    internal class DatabaseConnection
    {
   
        static string connectionString = "Server=YABU;Database=Sarah_short_cake;" +
                                      "Trusted_Connection=True; TrustServerCertificate=True;";

        public static void TestConnection()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    
                    SqlCommand command = new SqlCommand();
                    MessageBox.Show("Connection Successful!", "Information", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                }
            }
            catch (SqlException e)
            {
                MessageBox.Show($"Connection failed: {e.Message}", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

    }
}