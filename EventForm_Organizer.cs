using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using MySql.Data.MySqlClient;
using WinFormsApp2;

namespace WindowsFormsApp1
{
    public partial class EventForm_Organizer : Form
    {
        public EventForm_Organizer()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void EventForm_Organizer_Load(object sender, EventArgs e)
        {
            DatabaseConnection db = new DatabaseConnection();
            db.Connect();

            //Fills the event org details on the form
            int organizerId = db.GetEventOrganizerIdByUserId();
            label_EventOrg_ID.Text = organizerId.ToString();
           

            //Loading venue names into the venue combo box
            try
            {
                MySqlConnection conn = db.GetConnection();
              
                string query = "SELECT name FROM venues";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    comboBox1.Items.Clear();
                    while (reader.Read())
                    {
                        comboBox1.Items.Add(reader["name"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading venues: " + ex.Message);
            }
            finally
            {
                db.Close();
            }
        }




        private void payment_submit_button_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtEventName.Text) ||
                    comboBoxCategory.SelectedItem == null ||
                    string.IsNullOrWhiteSpace(txtDescription.Text) ||
                    string.IsNullOrWhiteSpace(txtMaxParticipants.Text) ||
                    string.IsNullOrWhiteSpace(txtRegistrationFees.Text) ||
                    string.IsNullOrWhiteSpace(txtWinnerPrize.Text) ||
                    string.IsNullOrWhiteSpace(txtRunnerUpPrize.Text) ||
                    string.IsNullOrWhiteSpace(textBox_Rules.Text) ||
                    string.IsNullOrWhiteSpace(textBox_Date.Text) ||
                    string.IsNullOrWhiteSpace(textBox_Start_time.Text) ||
                    string.IsNullOrWhiteSpace(textBox_End_Time.Text) ||
                    comboBox1.SelectedItem == null)
                {
                    MessageBox.Show("Please fill in all required fields before submitting.");
                    return;
                }

                string name = txtEventName.Text;
                string category = comboBoxCategory.SelectedItem?.ToString() ?? "";
                string description = txtDescription.Text;
                int maxParticipants = Convert.ToInt32(txtMaxParticipants.Text);
                decimal registrationFees = Convert.ToDecimal(txtRegistrationFees.Text);
                decimal winnerPrize = Convert.ToDecimal(txtWinnerPrize.Text);
                decimal runnerUpPrize = Convert.ToDecimal(txtRunnerUpPrize.Text);
                string rules = textBox_Rules.Text;
                DateTime eventDate = Convert.ToDateTime(textBox_Date.Text);
                TimeSpan startTime = Convert.ToDateTime(textBox_Start_time.Text).TimeOfDay;
                TimeSpan endTime = Convert.ToDateTime(textBox_End_Time.Text).TimeOfDay;
                string venue = comboBox1.SelectedItem?.ToString() ?? "";


                DatabaseConnection db = new DatabaseConnection();
                db.Connect();

                int organizerId = db.GetOrganizerId();


                //Getting venue id from the venues table using th selected venue name
                int venueId = -1; 

                try
                {
                    string venueQuery = "SELECT venue_id FROM venues WHERE name = @VenueName";

                    using (MySqlCommand cmd = new MySqlCommand(venueQuery, db.GetConnection()))
                    {
                        cmd.Parameters.AddWithValue("@VenueName", venue);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            venueId = Convert.ToInt32(result);
                        }
                        else
                        {
                            MessageBox.Show("Selected venue not found.");
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching venue ID: " + ex.Message);
                    return;
                }


                db.InsertEvent(name, category, description, maxParticipants, registrationFees,
                winnerPrize, runnerUpPrize, organizerId, rules, eventDate, startTime, endTime, venueId);




                db.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error submitting event: " + ex.Message);
            }
        }

        private void txtEventName_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label_EventOrg_name_Click(object sender, EventArgs e)
        {

        }

        private void textBox_Rules_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Date_Time_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Venue_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Venue_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox_End_Time_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
