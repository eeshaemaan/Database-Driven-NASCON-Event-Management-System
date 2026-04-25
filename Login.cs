using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp2;
using MySql.Data.MySqlClient;


namespace WindowsFormsApp1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string usernameOrEmail = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            DatabaseConnection db = new DatabaseConnection();
            db.Connect(); // Always connect first

            if (db.CheckIfUsernameOrEmailExists(usernameOrEmail))
            {
                // User exists, check password
                if (db.CheckIfPasswordMatches(usernameOrEmail, password))
                {
                    // Everything correct, fetch user details
                    int userId = db.GetUserIDByUsernameOrEmail(usernameOrEmail);
                    string role = db.GetUserRoleByUsernameOrEmail(usernameOrEmail);
                    string username = db.GetUsernameByUsernameOrEmail(usernameOrEmail);

                    // Store in Session
                    Session.LoggedInUserID = userId;
                    Session.Username = username;
                    Session.Role = role;

                    // Open Welcome Form
                    MessageBox.Show($"Opening WelcomeForm with username: {username}, role: {role}");

                    if (role == "Judge")
                    {
                        int judge_id = 0;

                        try
                        {
                            MySqlConnection conn = db.GetConnection();

                            string query = "select judge_id from judge where user_id = @userId";
                            MySqlCommand command = new MySqlCommand(query, conn);
                            command.Parameters.AddWithValue("@userId", userId);

                            using (MySqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    judge_id = reader.GetInt32("judge_id");
                                }
                            }

                            judge_dashboard welcome_judge = new judge_dashboard(judge_id);
                            welcome_judge.Show();
                        }
                        catch (Exception ex)
                        {
                            // Handle exceptions, for example, connection errors
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }
                    else { 
                        WelcomeForm welcomeForm = new WelcomeForm(username, role);
                        welcomeForm.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect password. Please try again.");
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("User not found. Do you want to register?", "New User", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    Register regForm = new Register(); // if event name needed
                    regForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Please try again or contact support.");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Register form = new Register();
            form.Show();
        }
    }
}
