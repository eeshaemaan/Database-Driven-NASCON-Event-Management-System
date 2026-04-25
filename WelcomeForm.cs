using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using WinFormsApp2;

namespace WindowsFormsApp1
{
    public partial class WelcomeForm : Form
    {
        private string usernameOrEmail;
        private string role;
        

        public WelcomeForm(string usernameOrEmail, string role)
        {
            MessageBox.Show($"Constructor reached with role: {role}"); 
            InitializeComponent();
            this.usernameOrEmail = usernameOrEmail;
            this.role = role;
        }


        private void WelcomeForm_Load(object sender, EventArgs e)
        {
            DatabaseConnection db = new DatabaseConnection();
            role = GetRoleFromDatabase(usernameOrEmail);
            int userId = -1;

            MessageBox.Show($"Role fetched: {role}"); 

            label2.Text = $"Welcome {role}!";

           
            if (role == "Event Organizer")
            {
                AddButton("Create Event");
                AddButton("Reports");
                userId = db.GetEventOrganizerIdByUserId();
            }
            else if (role == "Participant")
            {
                AddButton("Participate in Event");    //EventForm_Participant
                AddButton("View My Registrations");  // Register.cs
                AddButton("View Accommodation Details");  // Open Participant_Accomodation.cs
                //AddButton("Payment");      // Open team_payment.cs
                userId = db.GetParticipantIdByUserId();
            }
            else if (role == "Sponsor")
            {
                AddButton("View Reports");        // Open DynamicReportPage.cs
                AddButton("Sign Sponsorship Contract");        //Open EventForm_Sponsorship.cs
                //AddButton("Generate Total Funds Report");
                //AddButton("Track Branding");
                userId = db.GetSponsorIdByUserId();
            }
            //else if (role == "Judge")
            //{
            //    userId = db.GetJudgeIdByUserId();
            //    // AddButton("View Assigned Events");         
            //    // AddButton("Enter Scores");
            //    // AddButton("View Event Leaderboards");
            //}

            if (userId != -1)
{
    id_label.Text = $"ID: {userId}";
}
else
{
    id_label.Text = "ID not found.";
}
        }

        private void AddButton(string text)
        {
            Button btn = new Button();
            btn.Text = text;
            btn.Width = 200;
            btn.Height = 40;
            btn.Margin = new Padding(10);
            btn.Click += Button_Click; 
            flowLayoutPanel1.Controls.Add(btn);
            btn.BackColor = Color.Black;      
            btn.ForeColor = Color.White;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton != null)
            {
                string buttonText = clickedButton.Text;

                switch (buttonText)
                {
                    case "View Reports":
                        DynamicReportPage reportPage = new DynamicReportPage();
                        reportPage.LoadReport("sponsorship_details");
                        reportPage.Show();
                        break;

                    case "Sign Sponsorship Contract":
                        EventForm_Sponsor sponsorForm = new EventForm_Sponsor();
                        sponsorForm.Show();
                        break;

                    //case "Generate Total Funds Report":
                    //  //  TotalFundsReportForm totalFundsForm = new TotalFundsReportForm(); // Make sure this form exists
                    //  //  totalFundsForm.Show();
                    //  //  break;

                    //case "Track Branding":
                    //  //  BrandingTrackingForm brandingForm = new BrandingTrackingForm(); // Make sure this form exists
                    //  //  brandingForm.Show();
                    //  //  break;

                    case "Create Event":
                        EventForm_Organizer organizerForm = new EventForm_Organizer();
                        organizerForm.Show();
                        break;

                    case "Reports":
                        Report_page report = new Report_page();
                        report.Show();
                        break;

                    case "Participate in Event":
                        EventForm_Participant participateForm = new EventForm_Participant();
                        participateForm.Show();
                        break;

                    case "View My Registrations":
                        try
                        {
                            Participant_Registration registrationsForm = new Participant_Registration();
                            registrationsForm.Show();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error opening registration page: " + ex.Message);
                        }
                        break;

                    case "View Accommodation Details":
                        try
                        {
                            Registered_Accommodation accommodationForm = new Registered_Accommodation();
                            accommodationForm.Show();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error opening accommodation page: " + ex.Message);
                        }
                        break;

                    //case "Payment":
                    //  //  team_payment paymentForm = new team_payment();
                    //  //  paymentForm.Show();
                    //  //  break;

                    default:
                        MessageBox.Show($"Button '{buttonText}' clicked.");
                        break;
                }
            }
        }


        private string GetRoleFromDatabase(string usernameOrEmail)
        {
            try
            {
                string roleFromDb = "";

                DatabaseConnection db = new DatabaseConnection();
                db.Connect(); // Always connect first

                // Now call a method inside DatabaseConnection class
                roleFromDb = db.GetUserRoleByUsernameOrEmail(usernameOrEmail);

                return roleFromDb;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching role: " + ex.Message);
                return "";
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void id_label_Click(object sender, EventArgs e)
        {

        }
    }
}
