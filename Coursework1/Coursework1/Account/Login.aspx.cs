using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Coursework1.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Set the register hyperlink to the register page if they havent registered
            RegisterHyperLink.NavigateUrl = "Register.aspx";

            // method if the request page string is not empty, then return the previous url
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        // Login button method
        protected void LogIn_Click(object sender, EventArgs e)
        {

            try {
                // Initialize connection string of database
                String connectionString = @"Data Source=WIN-6CJBE273T5C\SQLEXPRESS;Initial Catalog=RPSLS;Integrated Security=True";
                // Initialize the sql query command 
                String commandString = "SELECT * FROM [LogInEntry] WHERE (([Username] = @Username) AND ([DOB] = @DOB))";


                // Create the method to open an SqlConnection using the connection string
                using (SqlConnection conn = new SqlConnection(connectionString)) 
                {
                    // Create the Sqlcommand method using the query string and the database connection
                    SqlCommand command = new SqlCommand(commandString, conn);

                    // add the parameters of the username and DOB textfields to use in the query
                    command.Parameters.AddWithValue("@Username", Username.Text);
                    command.Parameters.AddWithValue("@DOB", DOB.Text);

                    // Open the SqlConnection
                    conn.Open();
                    // Execute the query
                    command.ExecuteNonQuery();


                    // Create a SqlDataReader method to read the data in the SqlCommand query
                    SqlDataReader reader = command.ExecuteReader();
                    
                    // For each data cell in the query row, assign the the data to the public UserDetails
                    // method in the Default class
                    if(reader.Read()){
	                    userDetails.userName = reader["Username"].ToString();
                        userDetails.DOB = reader["DOB"].ToString();
                        userDetails.wins = (int)reader["Wins"];
                        userDetails.draws = (int)reader["Ties"];
                        userDetails.losses = (int)reader["Losses"];
                        userDetails.continuePlay = true;    
                        Response.Redirect("~/");  
                    }
                    // Close the SqlConnection
                    conn.Close();
                }
            }
            // catch SqlException
            catch (SqlException ex)
            {
                // Output the SqlException to the error label
                errorLabel.Text = ex.ToString();
            }
            // catch any other exception
            catch (Exception ex)
            {
                // Output the exception to the error label
                errorLabel.Text = ex.ToString();
            }
            // Set the username and date of birth of the user 
         //   userDetails.userName = Username.Text.ToString();
          //  userDetails.DOB = DOB.Text.ToString();
           // userDetails.loggedIn = true;

            // Once the login info has been sent to userdetails with no errors send the user to the main screen
            
        }
    }
}