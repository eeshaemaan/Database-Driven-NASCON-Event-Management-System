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
    public partial class EventForm_Sponsor : Form
    {
        public EventForm_Sponsor()
        {
            InitializeComponent();
            BackColor = ColorTranslator.FromHtml("#FFFFFF");
        }

        private void EventForm_Sponsor_Load(object sender, EventArgs e)
        {
           // MessageBox.Show("Load event triggered!"); // ✅ Check if this shows

            DatabaseConnection dbConnection = new DatabaseConnection();
            DataTable events = dbConnection.GetAllEvents();

           // MessageBox.Show("Events found: " + events.Rows.Count); // ✅ Check if this is > 0



            foreach (DataRow row in events.Rows)
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

                Label eventName = new Label
                {
                    Text = row["name"].ToString(),
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    Dock = DockStyle.Top
                };

                Label categoryLabel = new Label
                {
                    Text = "Category: " + row["category"].ToString(),
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    Dock = DockStyle.Top
                };

                //Label organizerLabel = new Label
                //{
                //    Text = "Organizer ID: " + row["organizer_id"].ToString(),
                //    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                //    Dock = DockStyle.Top
                //};

                Button sponsorButton = new Button
                {
                    Text = "Sponsor This Event",
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    Dock = DockStyle.Bottom,
                    ForeColor = Color.White,
                    Height = 30,
                    BackColor = Color.Black
                   
                };

                sponsorButton.Click += (s, evt) =>
                {
                    SponsorshipForm sponsorshipForm = new SponsorshipForm();

                    // Set EventID and OrganizerID in the form directly
                    sponsorshipForm.SetEventAndOrganizer(
                        Convert.ToInt32(row["event_id"]),
                        Convert.ToInt32(row["event_org_id"])
                    );

                    sponsorshipForm.ShowDialog();
                };

                eventCard.Controls.Add(sponsorButton);
              //  eventCard.Controls.Add(organizerLabel);
                eventCard.Controls.Add(categoryLabel);
                eventCard.Controls.Add(eventName);

                flowLayoutPanel1.Controls.Add(eventCard);
                flowLayoutPanel1.Padding = new Padding(10);
                Console.WriteLine("Added card for: " + row["name"]);  // ✅ OR use MessageBox
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
