using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Membership.OpenAuth;

namespace Coursework1.Account
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        /// <summary>
        /// Register button method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Register_Click(object sender, EventArgs e)
        {

            try
            {
                // Initialize connection string of database
                String connectionString = @"Data Source=WIN-6CJBE273T5C\SQLEXPRESS;Initial Catalog=RPSLS;Integrated Security=True";
                // Initialize the sql query command 
                String commandString = "INSERT into LogInEntry (Username, DOB, Wins, Losses, Ties) VALUES (@User, @DOB, @Wins, @Losses, @Ties)";

                // Create the method to open an SqlConnection using the connection string
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Create the Sqlcommand method using the query string and the database connection
                    SqlCommand command = new SqlCommand(commandString, conn);

                    // add the parameters of the query with the textfields and initialize the wins, losses and draws as 0
                    command.Parameters.AddWithValue("@User", Username.Text);
                    command.Parameters.AddWithValue("@DOB", DOB.Text);
                    command.Parameters.AddWithValue("@Wins", 0);
                    command.Parameters.AddWithValue("@Losses", 0);
                    command.Parameters.AddWithValue("@Ties", 0);
                    
                    // Open the SqlConnection
                    conn.Open();
                    // Execute the query
                    command.ExecuteNonQuery();
                    // Close the SqlConnection
                    conn.Close();
                    // Send the user to the login page once they've logged in            
                    Response.Redirect("Login.aspx");
                }
            }
            // catch SqlException
            catch (SqlException ex)
            {
                // Output the SqlException to the error label
                errorLabel.Text = "Sorry Username already taken";
            }
            // catch any other exception
            catch (Exception ex)
            {
                // Output the exception to the error label
                errorLabel.Text = ex.ToString();          
            }
        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

    }
}