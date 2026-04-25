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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WindowsFormsApp1
{
    public enum UserRole
    {
        Admin,
        Judge,
        Participant,
        EventOrganizer,
        Sponsor
    }
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            // Populate ComboBox with UserRole enum values
            foreach (UserRole role in Enum.GetValues(typeof(UserRole)))
            {
                comboBox_Role.Items.Add(role.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox_Name.Text.Trim();
            string phoneNumber = textBox_Phone.Text.Trim();
            string email = textBox_Email.Text.Trim();
            string password = textBox_Password.Text;
            string confirmPassword = textBox_Confirm_Pass.Text;

            if (comboBox_Role.SelectedItem == null)
            {
                MessageBox.Show("Please select a role.");
                return;
            }
            string role = comboBox_Role.SelectedItem.ToString();

            // If text box is empty, change its color to red and display message
            bool hasEmpty = false;

            if (string.IsNullOrWhiteSpace(name))
            {
                textBox_Name.BackColor = Color.MistyRose;
                hasEmpty = true;
            }
            if (string.IsNullOrWhiteSpace(email))
            {
                textBox_Email.BackColor = Color.MistyRose;
                hasEmpty = true;
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                textBox_Password.BackColor = Color.MistyRose;
                hasEmpty = true;
            }
            if (string.IsNullOrWhiteSpace(confirmPassword))
            {
                textBox_Confirm_Pass.BackColor = Color.MistyRose;
                hasEmpty = true;
            }

            if (hasEmpty)
            {
                MessageBox.Show("All fields are required.");
                return;
            }

            // Username syntax validation
            if (name.Length < 6)
            {
                MessageBox.Show("Name must be at least 6 characters long.");
                return;
            }

            // Email validation
            if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Please enter a valid email address.");
                return;
            }

            // Password checks
            if (password.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters long.");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            // Database connection
            DatabaseConnection db = new DatabaseConnection();
            db.Connect();

            // Check if email already exists
            if (db.CheckIfEmailExists(email))
            {
                MessageBox.Show("Email already exists.");
            }
            else
            {
                bool success = db.RegisterUser(name, phoneNumber, email, password, role);

                if (success)
                {
                    MessageBox.Show("Registration successful!");
                    this.Hide();
                    WelcomeForm welcomeForm = new WelcomeForm(name, role);
                    welcomeForm.Show();
                }
                else
                {
                    MessageBox.Show("Registration failed. Please try again.");
                }
            }

            db.Close();
        }

    }
 }
