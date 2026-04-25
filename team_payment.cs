using MySql.Data.MySqlClient;
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
    public partial class team_payment: Form
    {   
        private int event_id;
        private int team_id;
        public team_payment(string event_name, int team_id)
        {
            InitializeComponent();
            this.payment_submit_button.Click += new EventHandler(payment_submit_button_Click);
            this.event_id = GetEventIdFromName(event_name);
            this.team_id = team_id;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void team_payment_Load(object sender, EventArgs e)
        {

        }

        private int GetEventIdFromName(string eventName)
        {
            int eventId = 0;

            DatabaseConnection db = new DatabaseConnection();
            MySqlConnection conn = db.GetConnection();
            conn.Open();

            using (conn)
            {
                string query = "SELECT event_id FROM events WHERE name = @eventName";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@eventName", eventName);

                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    eventId = Convert.ToInt32(result);
                }
            }
            db.Close();
            return eventId;
        }


        private void payment_submit_button_Click(object sender, EventArgs e)
        {
            string payerId = textBox1.Text;
            string amount = textBox2.Text;
            string paymentMethod = "";

            if (radioDirect.Checked)
                paymentMethod = "Cash";
            else if (radioOnline.Checked)
                paymentMethod = "Credit Card";

            DatabaseConnection db = new DatabaseConnection();
            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    // inserting into the payment_detail table
                    string paymentQuery = "INSERT INTO payment_detail (payer_id, amount_payed, payment_method, payment_status) " +
                      "VALUES (@payer_id, @amount, @method, 'unpaid');" ;

                    MySqlCommand paymentCmd = new MySqlCommand(paymentQuery, conn);
                    paymentCmd.Parameters.AddWithValue("@payer_id", payerId);
                    paymentCmd.Parameters.AddWithValue("@amount", amount);
                    paymentCmd.Parameters.AddWithValue("@method", paymentMethod);

                    paymentCmd.ExecuteNonQuery();

                    // Getting the last newly inserted payment_detail_id
                    // using long because mysql by default stores auto-incremented values as 64 bit int
                    long paymentDetailId = paymentCmd.LastInsertedId; 

                    // Now, insert into event_team table with the new payment_detail_id
                    string eventQuery = "INSERT INTO event_team (team_id, event_id, payment_detail_id) " +
                                        "VALUES (@team_id, @event_id, @payment_detail_id);";

                    MySqlCommand eventCmd = new MySqlCommand(eventQuery, conn);
                    eventCmd.Parameters.AddWithValue("@team_id", team_id);
                    eventCmd.Parameters.AddWithValue("@event_id", event_id);
                    eventCmd.Parameters.AddWithValue("@payment_detail_id", paymentDetailId);

                    eventCmd.ExecuteNonQuery();

                    // printing the messege:

                    // checking the payment status
                    string statusQuery = "SELECT payment_status FROM payment_detail pd JOIN event_team et ON " +
                        "pd.detail_id = et.payment_detail_id WHERE et.event_id = @event_id AND et.team_id = @team_id;";
                    MySqlCommand statusCmd = new MySqlCommand(statusQuery, conn);
                    statusCmd.Parameters.AddWithValue("@team_id", team_id);
                    statusCmd.Parameters.AddWithValue("@event_id", event_id);

                    object result = statusCmd.ExecuteScalar();

                    if (result != null && result.ToString() == "paid")
                    {
                        MessageBox.Show("Payment successful!");
                    }
                    else
                    {
                        MessageBox.Show("Payment added, but not enough. Remaining amount is needed.");
                    }
                }
                catch //(MySqlException ex)
                {
                        //MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

    }
}
