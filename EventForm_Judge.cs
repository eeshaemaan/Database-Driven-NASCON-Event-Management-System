using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp2;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System.Management.Instrumentation;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class EventForm_Judge : Form
    {
        private Panel panel1;
        private Label label5;
        private Label label1;
        private Button Submit;
        private Label label2;
        private ComboBox comboBox1;
        private PictureBox pictureBox2;
        private int ID;
        private string event_name;
        public EventForm_Judge(string event_name, int judge_ID)
        {
            ID = judge_ID;
            this.event_name = event_name;
            InitializeComponent();
            this.comboBox1.DropDown += new System.EventHandler(this.comboBox1_DropDown);
        }

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Submit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Honeydew;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(674, 71);
            this.panel1.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(81, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 37);
            this.label5.TabIndex = 1;
            this.label5.Text = "Nascon";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::WindowsFormsApp1.Properties.Resources.logo;
            this.pictureBox2.Location = new System.Drawing.Point(3, 0);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(71, 68);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(201, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 49);
            this.label1.TabIndex = 2;
            this.label1.Text = "Application Form";
            // 
            // Submit
            // 
            this.Submit.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Submit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Submit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Submit.Location = new System.Drawing.Point(211, 562);
            this.Submit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(238, 40);
            this.Submit.TabIndex = 23;
            this.Submit.Text = "Submit";
            this.Submit.UseVisualStyleBackColor = false;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(193, 348);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(353, 28);
            this.label2.TabIndex = 24;
            this.label2.Text = "Event Round You Wish to Apply in:  ";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(229, 413);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(208, 24);
            this.comboBox1.TabIndex = 25;
            // 
            // EventForm_Judge
            // 
            this.BackColor = System.Drawing.Color.MistyRose;
            this.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.Backgrounf_Img;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(674, 641);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Submit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "EventForm_Judge";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            DatabaseConnection db = new DatabaseConnection();

            try
            {
                MySqlConnection conn = db.GetConnection();
                conn.Open();

                string query = "select r.name from rounds r;";
                MySqlCommand evalCmd = new MySqlCommand(query, conn);

                using (MySqlDataReader reader = evalCmd.ExecuteReader())
                {
                    // Clear ComboBox before adding new items
                    comboBox1.Items.Clear();

                    // Read each row from the result set and add it to the ComboBox
                    while (reader.Read())
                    {
                        comboBox1.Items.Add(reader["name"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, for example, connection errors
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Ensure the connection is closed if it was opened
                db.Close();
            }
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            DatabaseConnection db = new DatabaseConnection();

            try
            {
                MySqlConnection conn = db.GetConnection();
                conn.Open();

                string selected = comboBox1.SelectedItem?.ToString() ?? "";
                // MessageBox.Show($"Event: {event_name}, Round: {selected}");

                string query = @"insert into event_judges(eve_s_id, judge_id) 
                values (
                    (select es.eve_s_id 
                     from event_schedules es 
                     join events e on es.event_id = e.event_id
                     join rounds r on es.round_id = r.round_id 
                     where e.name = @event_name and r.name = @selected), 
                    @judge_id
                );";

                MySqlCommand evalCmd = new MySqlCommand(query, conn);

                // Parameters
                evalCmd.Parameters.AddWithValue("@event_name", event_name);
                evalCmd.Parameters.AddWithValue("@selected", selected);
                evalCmd.Parameters.AddWithValue("@judge_id", ID);

                evalCmd.ExecuteNonQuery();

                MessageBox.Show("Application Submitted Successfully!");
            }
            catch (MySqlException ex)
            {
                // Check for duplicate entry error
                if (ex.Number == 1062)
                {
                    MessageBox.Show("You've already applied to this event and round.", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            finally
            {
                db.Close();
            }
        }

    }
}
