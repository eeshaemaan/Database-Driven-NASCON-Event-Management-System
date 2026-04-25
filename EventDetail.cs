using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class EventDetail : Form
    {
        public EventDetail(string eventName, string category, string description, string rules, int maxParticipants,
                   decimal regFee, decimal winnerPrize, decimal runnerUpPrize,
                   string venue, DateTime eventDate, TimeSpan startTime, TimeSpan endTime, bool showRegisterButton = true)
        {
            InitializeComponent();

            label_Event_Name.Text = eventName;
            label_Category.Text = category;
            label_description.Text = description;
            label_rules.Text = rules;
            label_number_of_Participants.Text = maxParticipants.ToString();
            label_Reg_Fees.Text = regFee.ToString("C");
            label_Winner_prize.Text = winnerPrize.ToString("C");
            label_Runner_up_prize.Text = runnerUpPrize.ToString("C");
            label_venue.Text = venue;
            label_date.Text = eventDate.ToShortDateString();
            label_start_time.Text = startTime.ToString(@"hh\:mm");
            label_end_time.Text = endTime.ToString(@"hh\:mm");

            label_description.MaximumSize = new Size(210, 0); 
            label_rules.MaximumSize = new Size(300, 0);
            register_button.Visible = showRegisterButton;
        }

        private void EventDetail_Load(object sender, EventArgs e)
        {

        }

        private void label_Event_Name_Click(object sender, EventArgs e)
        {

        }

        private void label_Category_Click(object sender, EventArgs e)
        {

        }

        private void label_Reg_Fees_Click(object sender, EventArgs e)
        {

        }

        private void label_number_of_Participants_Click(object sender, EventArgs e)
        {

        }

        private void label_Winner_prize_Click(object sender, EventArgs e)
        {

        }

        private void label_Runner_up_prize_Click(object sender, EventArgs e)
        {

        }

        private void label_start_time_Click(object sender, EventArgs e)
        {

        }

        private void label_end_time_Click(object sender, EventArgs e)
        {

        }

        private void label_description_Click(object sender, EventArgs e)
        {

        }

        private void label_rules_Click(object sender, EventArgs e)
        {

        }

        private void payment_submit_button_Click(object sender, EventArgs e)
        {

            registeration_page regForm = new registeration_page(label_Event_Name.Text);
            regForm.ShowDialog();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label_venue_Click(object sender, EventArgs e)
        {

        }
    }
}
