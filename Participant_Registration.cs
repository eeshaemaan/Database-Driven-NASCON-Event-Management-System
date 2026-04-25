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
    public partial class Participant_Registration : Form
    {
        public Participant_Registration()
        {
            InitializeComponent();
        }

        private void Participant_Registration_Load(object sender, EventArgs e)
        {
        
            DatabaseConnection dbConnection = new DatabaseConnection();
            int participantId = dbConnection.GetParticipantIdByUserId();
            label_EventOrg_ID.Text = "Your ID: " + participantId.ToString();


            DataTable participantEvents = dbConnection.GetEventsByParticipant(dbConnection.GetParticipantIdByUserId());
           if (participantEvents.Rows.Count == 0)
            {
                MessageBox.Show($"No events found for the participant.ID: {dbConnection.GetParticipantIdByUserId()}");
            }
            foreach (DataRow row in participantEvents.Rows)
            {
                Panel eventCard = new Panel
                {
                    Width = 200,
                    Height = 180,
                    BorderStyle = BorderStyle.Fixed3D,
                    Margin = new Padding(15),
                    BackColor = Color.Black,
                    ForeColor = Color.White
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
                    BackColor = Color.Black
                };

                moreInfoButton.Click += (s, evt) =>
                {
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
                        TimeSpan.Parse(row["end_time"].ToString()),
                        showRegisterButton: false
                    );

                    detailForm.ShowDialog();
                };

                eventCard.Controls.Add(moreInfoButton);
                eventCard.Controls.Add(Rprize_label);
                eventCard.Controls.Add(Wprize_label);
                eventCard.Controls.Add(regFees_label);
                eventCard.Controls.Add(participants_label);
                eventCard.Controls.Add(category_label);
                eventCard.Controls.Add(event_name);

                // Add the event card to the flowLayoutPanel
                flowLayoutPanel1.Controls.Add(eventCard);
                flowLayoutPanel1.Padding = new Padding(10);
            }
        }

        

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label_EventOrg_ID_Click(object sender, EventArgs e)
        {

        }
    }
}
