using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Create the login form instance
            Login loginForm = new Login();

            //            Create instances of all the forms
            EventForm_Organizer organizerForm = new EventForm_Organizer();
          //  EventDetail eventDetailsForm = new EventDetail();
            Participant_Accommodation accommodationForm = new Participant_Accommodation();
            EventForm_Participant participantForm = new EventForm_Participant();
            Report_page report_Page = new Report_page();
            string event_name = "Gaming Tournament";
            registeration_page reg_page = new registeration_page(event_name);
            judge_dashboard JP = new judge_dashboard(1);

            //  Show all the forms
            //  JP.Show();
            //report_Page.Show();
            //reg_page.Show();
            //eventDetailsForm.Show();
            // accommodationForm.Show();
            // organizerForm.Show();
            loginForm.Show();
            //SponsorshipForm sp = new SponsorshipForm();
            //PaymentForm Py = new PaymentForm(sp);

            // Run the application starting with the Login form
            Application.Run(loginForm);
            //Application.Run(sp);
        }
    }
}
