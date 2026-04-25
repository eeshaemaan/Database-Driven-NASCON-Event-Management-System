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
    public partial class PaymentForm : Form
    {
        private SponsorshipForm sponsorForm;
        public PaymentForm(SponsorshipForm form)
        {
            InitializeComponent();
            sponsorForm = form;
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            int userId = Session.LoggedInUserID;

            if (userId != -1)
            {
                DatabaseConnection db = new DatabaseConnection();
                var (username, email, phone) = db.GetUserDetails(userId);

                if (username != null && email != null && phone != null)
                {
                    textBoxName.Text = username;
                    textBoxEmail.Text = email;
                    textBoxPhone.Text = phone;
                }
                else
                {
                    MessageBox.Show("User details could not be loaded.");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text.Trim();
            string email = textBoxEmail.Text.Trim();
            string phone = textBoxPhone.Text.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Please fill all fields correctly.");
                return;
            }

            // Update the SponsorshipForm status to Paid
            sponsorForm.SetStatusPaid();

            MessageBox.Show("Payment done successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close(); // Optional: Close payment form after success
        }
    }
}
