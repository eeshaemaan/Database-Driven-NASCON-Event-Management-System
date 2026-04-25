using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp2;

namespace WindowsFormsApp1
{
    public partial class Registered_Accommodation : Form
    {

        public Registered_Accommodation()
        {
            InitializeComponent(); 
        }

        private void Registered_Accommodation_Load(object sender, EventArgs e)
        {
            DatabaseConnection db = new DatabaseConnection();
            int participantId = db.GetParticipantIdByUserId();
            DataTable accomDetails = db.GetAccommodationDetails(participantId);

            label_EventOrg_ID.Text = "Your ID: " + participantId.ToString();




            if (accomDetails.Rows.Count > 0)
            {
                DataRow row = accomDetails.Rows[0];
                check_in_date.Text = Convert.ToDateTime(row["check_in_date"]).ToShortDateString();
                check_out_date.Text = Convert.ToDateTime(row["check_out_date"]).ToShortDateString();
                room_name_label.Text = row["room_name"].ToString();
                room_type_label.Text = row["room_type"].ToString();
                Total_Cost_Label.Text = "Total Cost: " + row["total_cost"].ToString();


            }
            else
            {
                MessageBox.Show("No accommodation record found.");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void Part_id_Click(object sender, EventArgs e)
        {

        }

        private void Part_Name_Click(object sender, EventArgs e)
        {

        }

        private void check_in_date_Click(object sender, EventArgs e)
        {

        }

        private void check_out_date_Click(object sender, EventArgs e)
        {

        }

        private void room_name_label_Click(object sender, EventArgs e)
        {

        }

        private void room_type_label_Click(object sender, EventArgs e)
        {

        }

        private void Total_Cost_Label_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label_EventOrg_ID_Click(object sender, EventArgs e)
        {

        }
    }
}
