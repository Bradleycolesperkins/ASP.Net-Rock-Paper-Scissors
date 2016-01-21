using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Coursework1
{
    // Create a global class of the user so all classes can access it
    public static class userDetails
    {
        public static String userName;
        public static String DOB;
        public static int wins;
        public static int draws;
        public static int losses;
        public static Boolean continuePlay;
        public static Boolean loggedIn;
    } 

    public partial class _Default : Page
    {
        // Set the selected strings available to the pageload and generate classes
        private string userSelected;
        private string cpuSelected;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            // Set the labels to the userDetails variables
            Username.Text = userDetails.userName;
            Wins.Text = userDetails.wins.ToString();
            Ties.Text = userDetails.draws.ToString();
            Losses.Text = userDetails.losses.ToString();

            // Get the current day in the 2 digit form
            String currentDay = DateTime.Now.ToString("dd");
            // Get the current month in the 2 digit form
            String currentMonth = DateTime.Now.ToString("MM");
            // Combine the two strings with a "/" in between
            String currentDate = currentMonth.ToString() + "/" + currentDay.ToString();
            
            // Method to display the game data and titles
            // If the user has not logged in:
            if (userDetails.userName == null)
            {
                title.Text = "Please Register or Login to continue";
                // Display the logged out screen
                LoggedOutScreen();
            } 
            // If the user has logged in:
            else 
            {
                // If the user has logged in and the first 5 characters of the 
                // date of birth match todays date string
                if (currentDate.Equals(userDetails.DOB.Substring(0, 5)))
                {
                    // Print happy birthday
                    title.Text = "HAPPY BIRTHDAY!!! Select a button to start the game";
                    // hide the register and log in buttons
                    ContinueToPlay.Visible = false;
                    Logout.Visible = false;
                }
                else 
                {
                    // Print normal title
                    title.Text = "Select a button to start the game";
                    // hide the register and log in buttons
                    ContinueToPlay.Visible = false;
                    Logout.Visible = false;
                }
            }
        }
        
        // Method for when the user has clicked the rock button
        protected void RockButton_Click(object sender, EventArgs e)
        {
            // Change the user button label to "Rock"
            ButtonSelected.Text = "Rock";
            // Set the userSelected string to "Rock"
            userSelected = "Rock";
            // Generate a CPU answer
            GenerateCPUAnswer();
            // Display both results
            DisplayResult();
            // Update the stats otherwise the stats labels update the next time a button is clicked
            RefreshUserStats();
            // Make the continue promt buttons appear
            userDetails.continuePlay = false;
            // call the stopplay method which hides the rock,paper,scissors.... buttons so the user cant play again
            StopPlay();
            // Update the database with the result of the game 
            updateStats();
            
        }

        // Method for when the user has clicked the rock button
        protected void PaperButton_Click(object sender, EventArgs e)
        {
            // Change the user button label to "Paper"
            ButtonSelected.Text = "Paper";
            // Set the userSelected string to "Paper"
            userSelected = "Paper";
            // Generate a CPU answer
            GenerateCPUAnswer();
            // Display both results
            DisplayResult();
            // Update the stats otherwise the stats labels update the next time a button is clicked
            RefreshUserStats();
            // Make the continue promt buttons appear
            userDetails.continuePlay = false;
            // call the stopplay method which hides the rock,paper,scissors.... buttons so the user cant play again
            StopPlay();
            // Update the database with the result of the game 
            updateStats();
        }

        // Method for when the user has clicked the rock button
        protected void ScissorsButton_Click(object sender, EventArgs e)
        {
            // Change the user button label to "Scissors"
            ButtonSelected.Text = "Scissors";
            // Set the userSelected string to "Scissors"
            userSelected = "Scissors";
            // Generate a CPU answer
            GenerateCPUAnswer();
            // Display both results
            DisplayResult();
            // Update the stats otherwise the stats labels update the next time a button is clicked
            RefreshUserStats();
            // Make the continue promt buttons appear
            userDetails.continuePlay = false;
            // call the stopplay method which hides the rock,paper,scissors.... buttons so the user cant play again
            StopPlay();
            // Update the database with the result of the game 
            updateStats();
        }

        // Method for when the user has clicked the rock button
        protected void LizardButton_Click(object sender, EventArgs e)
        {
            // Change the user button label to "Lizard"
            ButtonSelected.Text = "Lizard";
            // Set the userSelected string to "Lizard"
            userSelected = "Liazrd";
            // Generate a CPU answer
            GenerateCPUAnswer();
            // Display both results
            DisplayResult();
            // Update the stats otherwise the stats labels update the next time a button is clicked
            RefreshUserStats();
            // Make the continue promt buttons appear
            userDetails.continuePlay = false;
            // call the stopplay method which hides the rock,paper,scissors.... buttons so the user cant play again
            StopPlay();
            // Update the database with the result of the game 
            updateStats();
        }

        // Method for when the user has clicked the rock button
        protected void SpockButton_Click(object sender, EventArgs e)
        {
            // Change the user button label to "Spock"
            ButtonSelected.Text = "Spock";
            // Set the userSelected string to "Spock"
            userSelected = "Spock";
            // Generate a CPU answer
            GenerateCPUAnswer();
            // Display both results
            DisplayResult();
            // Update the stats otherwise the stats labels update the next time a button is clicked
            RefreshUserStats();
            // Make the continue promt buttons appear
            userDetails.continuePlay = false;
            // call the stopplay method which hides the rock,paper,scissors.... buttons so the user cant play again
            StopPlay();
            // Update the database with the result of the game 
            updateStats();
        }

        // Method to generate a computer answer
        public void GenerateCPUAnswer()
        {
            // Create a random generator
            var random = new Random();
            // Set the random generator to creat numbers from 1-6
            int randomNum = random.Next(1, 6);
            // Using the integers from 1-5:
            switch (randomNum)
            {
                // If the randomNum is 1:
                case 1:
                    // Change the computer label and the local variable to Rock
                    ComputerSelected.Text = "Rock";
                    cpuSelected = "Rock";
                    break;
                // If the randomNum is 2:
                case 2:
                    // Change the computer label and the local variable to Rock
                    ComputerSelected.Text = "Paper";
                    cpuSelected = "Paper";
                    break;
                // If the randomNum is 3:
                case 3:
                    // Change the computer label and the local variable to Rock
                    ComputerSelected.Text = "Scissors";
                    cpuSelected = "Scissors";
                    break;
                // If the randomNum is 4:
                case 4:
                    // Change the computer label and the local variable to Rock
                    ComputerSelected.Text = "Lizard";
                    cpuSelected = "Lizard";
                    break;
                // If the randomNum is 5:
                case 5:
                    // Change the computer label and the local variable to Rock
                    ComputerSelected.Text = "Spock";
                    cpuSelected = "Spock";
                    break;
                default:
                    break;
            }
        }

        // Method to display the result title
        public void DisplayResult()
        {
            // Cases for each of the possibilities of selections
            // Inside statement updates the result of the user
            // Then outputs the result to the result label
            if ((userSelected.Equals("Scissors")) && (cpuSelected.Equals("Paper")))
            {
                userDetails.wins = userDetails.wins + 1;
                Result.Text = "Result: You Win!";
            }
            else if ((cpuSelected.Equals("Scissors")) && (userSelected.Equals("Paper")))
            {
                userDetails.losses = userDetails.losses + 1;
                Result.Text = "Result: You Lose!";
            }
            else if ((userSelected.Equals("Paper")) && (cpuSelected.Equals("Rock")))
            {
                userDetails.wins = userDetails.wins + 1;
                Result.Text = "Result: You Win!";
            }
            else if ((cpuSelected.Equals("Paper")) && (userSelected.Equals("Rock")))
            {
                userDetails.losses = userDetails.losses + 1;
                Result.Text = "Result: You Lose!";
            }
            else if ((userSelected.Equals("Rock")) && (cpuSelected.Equals("Lizard")))
            {
                userDetails.wins = userDetails.wins + 1;
                Result.Text = "Result: You Win!";
            }
            else if ((cpuSelected.Equals("Rock")) && (userSelected.Equals("Lizard")))
            {
                userDetails.losses = userDetails.losses + 1;
                Result.Text = "Result: You Lose!";
            }
            else if ((userSelected.Equals("Lizard")) && (cpuSelected.Equals("Spock")))
            {
                userDetails.wins = userDetails.wins + 1;
                Result.Text = "Result: You Win!";
            }
            else if ((cpuSelected.Equals("Lizard")) && (userSelected.Equals("Spock")))
            {
                userDetails.losses = userDetails.losses + 1;
                Result.Text = "Result: You Lose!";
            }
            else if ((userSelected.Equals("Spock")) && (cpuSelected.Equals("Scissors")))
            {
                userDetails.wins = userDetails.wins + 1;
                Result.Text = "Result: You Win!";
            }
            else if ((cpuSelected.Equals("Spock")) && (userSelected.Equals("Scissors")))
            {
                userDetails.losses = userDetails.losses + 1;
                Result.Text = "Result: You Lose!";
            }
            else if ((userSelected.Equals("Lizard")) && (cpuSelected.Equals("Paper")))
            {
                userDetails.wins = userDetails.wins + 1;
                Result.Text = "Result: You Win!";
            }
            else if ((cpuSelected.Equals("Lizard")) && (userSelected.Equals("Paper")))
            {
                userDetails.losses = userDetails.losses + 1;
                Result.Text = "Result: You Lose!";
            }
            else if ((userSelected.Equals("Paper")) && (cpuSelected.Equals("Spock")))
            {
                userDetails.wins = userDetails.wins + 1;
                Result.Text = "Result: You Win!";
            }
            else if ((cpuSelected.Equals("Paper")) && (userSelected.Equals("Spock")))
            {
                userDetails.losses = userDetails.losses + 1;
                Result.Text = "Result: You Lose!";
            }
            else if ((userSelected.Equals("Spock")) && (cpuSelected.Equals("Rock")))
            {
                userDetails.wins = userDetails.wins + 1;
                Result.Text = "Result: You Win!";
            }
            else if ((cpuSelected.Equals("Spock")) && (userSelected.Equals("Rock")))
            {
                userDetails.losses = userDetails.losses + 1;
                Result.Text = "Result: You Lose!";
            }
            else if ((userSelected.Equals("Rock")) && (cpuSelected.Equals("Scissors")))
            {
                userDetails.wins = userDetails.wins + 1;
                Result.Text = "Result: You Win!";
            }
            else if ((cpuSelected.Equals("Rock")) && (userSelected.Equals("Scissors")))
            {
                userDetails.losses = userDetails.losses + 1;
                Result.Text = "Result: You Lose!";
            }
            else if ((userSelected.Equals("Scissors")) && (cpuSelected.Equals("Lizard")))
            {
                userDetails.wins = userDetails.wins + 1;
                Result.Text = "Result: You Win!";
            }
            else if ((cpuSelected.Equals("Scissors")) && (userSelected.Equals("Lizard")))
            {
                userDetails.losses = userDetails.losses + 1;
                Result.Text = "Result: You Lose!";
            }
           else
            {
                userDetails.draws = userDetails.draws + 1;
                Result.Text = "Result: Its A Tie";
            }
        }

        // Method when called refreshes the user stats
        protected void RefreshUserStats()
        {
            // Gets the win, loss and tie label and updates the userDetails
            Wins.Text = userDetails.wins.ToString();
            Ties.Text = userDetails.draws.ToString();
            Losses.Text = userDetails.losses.ToString();
            int totalNum = userDetails.wins + userDetails.draws + userDetails.losses;
            total.Text = totalNum.ToString();
        }

        // Method when called turns the 
        protected void StopPlay()
        {
            // Sets the visibility of the game buttons to off
            // Sets the register and login button to visible
            Stats.Visible = true;
            RockButton.Visible = false;
            PaperButton.Visible = false;
            ScissorsButton.Visible = false;
            LizardButton.Visible = false;
            SpockButton.Visible = false;
            ContinueToPlay.Visible = true;
            Logout.Visible = true;
            userDetails.loggedIn = false;
        }

        protected void ContinuePlay()
        {
            // Sets the visibility of the game buttons to on
            // Sets the register and login button to not visible
            RockButton.Visible = true;
            PaperButton.Visible = true;
            ScissorsButton.Visible = true;
            LizardButton.Visible = true;
            SpockButton.Visible = true;
            ContinueToPlay.Visible = false;
            Logout.Visible = false;

            userDetails.loggedIn = true;
        }

        protected void LoggedOutScreen()
        {
            // Set all the buttons and stats to not visible
            // Sets the register and login button to visible
            Selections.Visible = false;
            Stats.Visible = false; 
            Logout.Visible = true;
            userDetails.loggedIn = false;
        }

        // When the continueToPlay button is clicked:
        protected void ContinueToPlay_Click(object sender, EventArgs e)
        {
            // Change the userdetails booleans to ture to display the correct buttons
            userDetails.continuePlay = true;
            userDetails.loggedIn = true;
            // Call the continuePlay method
            ContinuePlay();
        }


        // When the logout button is clicked:
        protected void Logout_Click(object sender, EventArgs e)
        {
            // Call the logout Screen method
            LoggedOutScreen();
            userDetails.loggedIn = false;
            // Change the title text
            title.Text = "Please Register or Login to continue";
        }
        
        // Update stats method
        protected void updateStats()
        {
            try
            {
                // Initialize connection string of database
                String connectionString = @"Data Source=WIN-6CJBE273T5C\SQLEXPRESS;Initial Catalog=RPSLS;Integrated Security=True";
                // Initialize the sql query command 
                String commandString = "UPDATE LogInEntry SET Wins = @Wins, Losses = @Losses, Ties = @Ties WHERE Username = @User";

                // Create the method to open an SqlConnection using the connection string
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Create the Sqlcommand method using the query string and the database connection
                    SqlCommand command = new SqlCommand(commandString, conn);

                    // add the parameters of the query with the username and DOB, then update the wins, losses and ties
                    command.Parameters.AddWithValue("@User", userDetails.userName);
                    command.Parameters.AddWithValue("@DOB", userDetails.DOB);
                    command.Parameters.AddWithValue("@Wins", userDetails.wins);
                    command.Parameters.AddWithValue("@Losses", userDetails.losses);
                    command.Parameters.AddWithValue("@Ties", userDetails.draws);

                    // Open the SqlConnection
                    conn.Open();
                    // Execute the query
                    command.ExecuteNonQuery();
                    // Close the SqlConnection
                    conn.Close();
                }
            }
            // catch SqlException
            catch (SqlException ex)
            {
                // Output the exception to the error label
                Result.Text = ex.ToString();
            }
            // catch any other exception
            catch (Exception ex)
            {
                // Output the exception to the error label
                Result.Text = ex.ToString();
            }
        }
    }
}
