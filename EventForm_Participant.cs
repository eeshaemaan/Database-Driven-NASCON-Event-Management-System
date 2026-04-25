using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp2;

namespace WindowsFormsApp1
{
    public partial class EventForm_Participant : Form
    {
        public EventForm_Participant()
        {
            InitializeComponent();
        
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void EventForm_Participant_Load(object sender, EventArgs e)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            DataTable events = dbConnection.GetAllEvents();

            // Loop through the rows and create cards for each event
            foreach (DataRow row in events.Rows)
            {
                //For each event creat a sepaarte panel
                Panel eventCard = new Panel
                {
                    Width = 200,
                    Height = 180,
                    BorderStyle = BorderStyle.Fixed3D,
                    Margin = new Padding(15),
                    BackColor = Color.Black,
                    ForeColor = Color.Honeydew


                };

                Label event_name = new Label
                {
                    Text = row["name"].ToString(),
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    Dock = DockStyle.Top
                };


                Label category_label = new Label
                {
                    Text = "Category: " + row["category"].ToString(),
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    Dock = DockStyle.Top
                };


                Label participants_label = new Label
                {
                    Text = "Max Participants: " + row["max_participants"].ToString(),
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    Dock = DockStyle.Top
                };


                Label regFees_label = new Label
                {
                    Text = "Registration Fee: " + row["registration_fee"].ToString(),
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    Dock = DockStyle.Top
                };


                Label Wprize_label = new Label
                {
                    Text = "Winner Prize: " + row["winner_prize"].ToString(),
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    Dock = DockStyle.Top
                };

                Label Rprize_label = new Label
                {
                    Text = "Runner-Up Prize: " + row["runnerUp_prize"].ToString(),
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    Dock = DockStyle.Top
                };

                Button moreInfoButton = new Button
                {
                    Text = "Get More Info",
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    Dock = DockStyle.Bottom,
                    ForeColor = Color.White,
                    Height = 30,
                    BackColor = Color.Black,
                };

                moreInfoButton.Click += (s, evt) =>
                {
                    // Open the EventDetail form and pass data from the current row
                    EventDetail detailForm = new EventDetail(
                        row["name"].ToString(),
                        row["category"].ToString(),
                        row["description"] == DBNull.Value ? "No description available" : row["description"].ToString(),
                        row["rules"] == DBNull.Value ? "No rules available" : row["rules"].ToString(),
                        Convert.ToInt32(row["max_participants"]),
                        Convert.ToDecimal(row["registration_fee"]),
                        Convert.ToDecimal(row["winner_prize"]),
                        Convert.ToDecimal(row["runnerUp_prize"]),
                        row["venue_name"].ToString(),
                        Convert.ToDateTime(row["event_date"]),
                        TimeSpan.Parse(row["start_time"].ToString()),
                        TimeSpan.Parse(row["end_time"].ToString())
                    );

                    // Show the details form as a modal dialog
                    detailForm.ShowDialog();
                };


                eventCard.Controls.Add(moreInfoButton);
                eventCard.Controls.Add(Rprize_label);
                eventCard.Controls.Add(Wprize_label);
                eventCard.Controls.Add(regFees_label);
                eventCard.Controls.Add(participants_label);
                eventCard.Controls.Add(category_label);
                eventCard.Controls.Add(event_name);



                // Adding the event card to the flowLayoutPanel
                flowLayoutPanel1.Controls.Add(eventCard);
                flowLayoutPanel1.Padding = new Padding(10);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label_EventOrg_ID_Click(object sender, EventArgs e)
        {

        }
    }
}
