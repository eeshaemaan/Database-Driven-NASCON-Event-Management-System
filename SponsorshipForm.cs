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

namespace WindowsFormsApp1
{
    public partial class SponsorshipForm : Form
    {
        public SponsorshipForm()
        {
            InitializeComponent();

            // Auto-fill user ID from session
            textBox_UserId.Text = Session.LoggedInUserID.ToString();
            textBox_UserId.ReadOnly = true;

            // Make Event ID and Organizer ID read-only
            textBox_EventId.ReadOnly = true;
            textBox_EventOrgId.ReadOnly = true;

            // Default unpaid status
            statusTextBox.Text = "Unpaid";

            // Populate sponsorship categories
            comboBox_Category.Items.Add("Title Sponsor");
            comboBox_Category.Items.Add("Gold Sponsor");
            comboBox_Category.Items.Add("Silver Sponsor");
            comboBox_Category.Items.Add("Media Partner");

            // Hook category change to auto-fill amount
            comboBox_Category.SelectedIndexChanged += comboBox_Category_SelectedIndexChanged;
        }
        public void SetEventAndOrganizer(int eventId, int organizerId)
        {
            textBox_EventId.Text = eventId.ToString();
            textBox_EventOrgId.Text = organizerId.ToString();
        }

        public void SetStatusPaid()
        {
            statusTextBox.Text = "Paid";
        }

        private void button_MakePayment_Click(object sender, EventArgs e)
        {
            PaymentForm pf = new PaymentForm(this); // Pass reference of SponsorshipForm
            pf.Show();
        }

        private void button_Submit_Click(object sender, EventArgs e)
        {
            string companyName = textBox_CompanyName.Text.Trim();
            string category = comboBox_Category.SelectedItem?.ToString();
            string userIdText = textBox_UserId.Text.Trim();
            string eventIdText = textBox_EventId.Text.Trim();
            string eventOrgIdText = textBox_EventOrgId.Text.Trim();
            string amountText = textBox_Amount.Text.Trim();
            string status = statusTextBox.Text.Trim();

            if (string.IsNullOrEmpty(companyName) || string.IsNullOrEmpty(category) ||
                string.IsNullOrEmpty(userIdText) || string.IsNullOrEmpty(eventIdText) ||
                string.IsNullOrEmpty(eventOrgIdText) || string.IsNullOrEmpty(amountText))
            {
                MessageBox.Show("Please fill all required fields.");
                return;
            }

            if (status != "Paid")
            {
                MessageBox.Show("Please complete the payment before submitting.");
                return;
            }

            int userId = Convert.ToInt32(userIdText);
            int eventId = Convert.ToInt32(eventIdText);
            int eventOrgId = Convert.ToInt32(eventOrgIdText);
            decimal amount = Convert.ToDecimal(amountText);

            DatabaseConnection db = new DatabaseConnection();
            db.Connect();

            int sponsorId = db.InsertSponsor(companyName, userId, category);

            if (sponsorId > 0)
            {
                bool success = db.InsertSponsorship(sponsorId, eventId, eventOrgId, amount);

                if (success)
                {
                    MessageBox.Show("Sponsorship submitted successfully!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to insert into sponsorship table.");
                }
            }
            else
            {
                MessageBox.Show("Failed to insert into sponsor table.");
            }

            db.Close();
        }

        private void comboBox_Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox_Category.SelectedItem.ToString())
            {
                case "Title Sponsor":
                    textBox_Amount.Text = "50000";
                    break;
                case "Gold Sponsor":
                    textBox_Amount.Text = "30000";
                    break;
                case "Silver Sponsor":
                    textBox_Amount.Text = "15000";
                    break;
                case "Media Partner":
                    textBox_Amount.Text = "10000";
                    break;
            }
        }

    }
}
