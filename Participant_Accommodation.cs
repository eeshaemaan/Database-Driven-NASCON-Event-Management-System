using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp2;

namespace WindowsFormsApp1
{
    public partial class Participant_Accommodation : Form
    {
        public Participant_Accommodation()
        {
            InitializeComponent();
            button_adjust.Visible = false;
            DatabaseConnection dbConnection = new DatabaseConnection();
            int participantId = dbConnection.GetParticipantIdByUserId();
            label_EventOrg_ID.Text = "Your ID: " + participantId.ToString();
        }


        private void Accomodation_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

     

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void label6_Click(object sender, EventArgs e)
        {

        }


        private void submit_button_Click_1(object sender, EventArgs e)
        {

              //re setting the color back to white
            comboBox_check_in.BackColor = Color.White;
            comboBox_check_out.BackColor = Color.White;
            comboBox_room.BackColor = Color.White;
            textBox_budget.BackColor = Color.White;

            //checking if ay field is empty
            if (comboBox_check_in.SelectedItem == null || comboBox_check_out.SelectedItem == null)
            {
                comboBox_check_in.BackColor = Color.MistyRose;
                comboBox_check_out.BackColor = Color.MistyRose;
                MessageBox.Show("Please select both check-in and check-out dates.");
                return;
            }

            if (comboBox_room.SelectedItem == null)
            {
                comboBox_room.BackColor = Color.MistyRose;
                MessageBox.Show("Please select a room preference.");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox_budget.Text))
            {
                textBox_budget.BackColor = Color.MistyRose;
                MessageBox.Show("Please enter your budget.");
                return;
            }

            DateTime checkInDate = DateTime.Parse(comboBox_check_in.SelectedItem.ToString());
            DateTime checkOutDate = DateTime.Parse(comboBox_check_out.SelectedItem.ToString());
            int stay_duration = (checkOutDate - checkInDate).Days;

            if (checkInDate >= checkOutDate)
            {
                MessageBox.Show("Check-in date must be earlier than check-out date.");
                return;
            }

            int room_cost = 0;
            int total_cost = 0;

            //setting the room cost per night as per user's preference

            if (comboBox_room.SelectedItem.ToString() == "Shared Room - 1000 per night")
                room_cost = 1000;
            else if (comboBox_room.SelectedItem.ToString() == "Double Room - 2000 per night")
                room_cost = 2000;
            else if (comboBox_room.SelectedItem.ToString() == "Single Room - 3000 per night")
                room_cost = 3000;

            //Total cost for the whole stay
            total_cost = room_cost * stay_duration;

            //Budget must be a positive numeric value check 
            int userBudget;

            if (!int.TryParse(textBox_budget.Text, out userBudget) || userBudget <= 0)
            {
                MessageBox.Show("Please enter a valid positive numeric budget.");
                return;
            }


            if (int.TryParse(textBox_budget.Text, out userBudget))
            {
                //Budget is sufficient
                if (userBudget >= total_cost)
                {

                    MessageBox.Show($"Your total stay cost is {total_cost}. Your budget is sufficient.");

                    int partId = 1;
                    string roomType = comboBox_room.SelectedItem.ToString().Split('-')[0].Trim().Split(' ')[0]; // Extracting room type 
                    string status = "pending";
                    DatabaseConnection dbConnection = new DatabaseConnection();
                    dbConnection.InsertAccommodationRequest(partId, roomType, checkInDate, checkOutDate, status, total_cost);

                }
                //Budget is insufficient
                else
                {
                    bool room_available = false; //var to keep track if any room matches user's budget
                    MessageBox.Show($"Your budget is insufficient for the selected room.\nTotal cost for your stay would be: {total_cost}.\nWe suggest alternative rooms within your budget.");
                    comboBox_room.Items.Clear();
                    comboBox_room.Text = "Choose an alternative room";

                    if (userBudget >= 1000 * stay_duration)
                    {
                        comboBox_room.Items.Add("Shared Room - 1000 per night");
                        room_available = true;
                    }

                    if (userBudget >= 2000 * stay_duration)
                    {
                        comboBox_room.Items.Add("Double Room - 2000 per night");
                        room_available = true;
                    }

                    if (userBudget >= 3000 * stay_duration)
                    {
                        comboBox_room.Items.Add("Single Room - 3000 per night");
                        room_available = true;
                    }
                    if (room_available == false) // no room available
                    {
                        MessageBox.Show("Unfortunately, no room is available within your budget.");
                        submit_button.Enabled = false;
                        button_adjust.Visible = true;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid budget.");
            }


        }


        private void button_adjust_Click(object sender, EventArgs e)
        {
            comboBox_room.Items.Clear();
            comboBox_room.Text = "Choose a preference";
            comboBox_room.Items.Add("Shared Room - 1000 per night");
            comboBox_room.Items.Add("Double Room - 2000 per night");
            comboBox_room.Items.Add("Single Room - 3000 per night");
            submit_button.Enabled = true;
            button_adjust.Visible = false;
        }

        private void label_EventOrg_ID_Click(object sender, EventArgs e)
        {

        }
    }
}
