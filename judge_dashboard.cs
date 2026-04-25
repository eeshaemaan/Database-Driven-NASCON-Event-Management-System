using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp2;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Management.Instrumentation;
using System.Xml.Linq;

namespace WindowsFormsApp1 
{
    public partial class judge_dashboard : Form
    {
        private int ID;
        public judge_dashboard(int ID = 0)
        {
            InitializeComponent();
            this.ID = ID;
            this.comboBox1.DropDown += new System.EventHandler(this.comboBox1_DropDown);
            this.comboBox2.DropDown += new System.EventHandler(this.comboBox2_DropDown);
            this.comboBox3.DropDown += new System.EventHandler(this.comboBox3_DropDown);
            this.label3.Text = "Your Judge ID: " + ID.ToString();
        }


        private Button ApplyForEvent;
        private Panel panel1;
        private Label label5;
        private PictureBox pictureBox2;
        private Panel panel2;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox comboBox1;
        private Label label4;
        private Label label6;
        private ComboBox comboBox2;
        private ComboBox comboBox3;
        private Label label7;
        private Button Evaluations;

        private void InitializeComponent()
        {
            this.ApplyForEvent = new System.Windows.Forms.Button();
            this.Evaluations = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ApplyForEvent
            // 
            this.ApplyForEvent.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ApplyForEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApplyForEvent.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ApplyForEvent.Location = new System.Drawing.Point(455, 383);
            this.ApplyForEvent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ApplyForEvent.Name = "ApplyForEvent";
            this.ApplyForEvent.Size = new System.Drawing.Size(238, 40);
            this.ApplyForEvent.TabIndex = 19;
            this.ApplyForEvent.Text = "Apply for Event";
            this.ApplyForEvent.UseVisualStyleBackColor = false;
            this.ApplyForEvent.Click += new System.EventHandler(this.button1_Click);
            // 
            // Evaluations
            // 
            this.Evaluations.BackColor = System.Drawing.SystemColors.ControlText;
            this.Evaluations.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Evaluations.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Evaluations.Location = new System.Drawing.Point(455, 515);
            this.Evaluations.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Evaluations.Name = "Evaluations";
            this.Evaluations.Size = new System.Drawing.Size(238, 40);
            this.Evaluations.TabIndex = 20;
            this.Evaluations.Text = "Go to my Evaluations";
            this.Evaluations.UseVisualStyleBackColor = false;
            this.Evaluations.Click += new System.EventHandler(this.button2_Click);
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
            this.panel1.Size = new System.Drawing.Size(753, 71);
            this.panel1.TabIndex = 21;
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
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(25, 116);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(705, 238);
            this.panel2.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(58, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 25);
            this.label3.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(59, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Your User ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(94, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(456, 49);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome To your Dashboard";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(58, 395);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(377, 24);
            this.comboBox1.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(53, 357);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(313, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Select an event from the dropdown: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(53, 450);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(313, 20);
            this.label6.TabIndex = 24;
            this.label6.Text = "Select an event from the dropdown: ";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(58, 487);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(377, 24);
            this.comboBox2.TabIndex = 25;
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(58, 567);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(377, 24);
            this.comboBox3.TabIndex = 26;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(53, 530);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(305, 20);
            this.label7.TabIndex = 27;
            this.label7.Text = "Select a round from the dropdown: ";
            // 
            // judge_dashboard
            // 
            this.BackColor = System.Drawing.Color.MistyRose;
            this.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.Backgrounf_Img;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(753, 641);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Evaluations);
            this.Controls.Add(this.ApplyForEvent);
            this.Name = "judge_dashboard";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string event_name = comboBox1.SelectedItem?.ToString() ?? "";
            EventForm_Judge EJ = new EventForm_Judge(event_name, ID);
            EJ.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string event_name = comboBox2.SelectedItem?.ToString() ?? "";
            string round_name = comboBox3.SelectedItem?.ToString() ?? "";
            judge_score_page JS = new judge_score_page(event_name, ID, round_name);
            JS.Show();
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            DatabaseConnection db = new DatabaseConnection();

            try
            {
                MySqlConnection conn = db.GetConnection();
                conn.Open();

                string query = "SELECT name FROM events";
                MySqlCommand command = new MySqlCommand(query, conn);


                using (MySqlDataReader reader = command.ExecuteReader())
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

        private void comboBox2_DropDown(object sender, EventArgs e)
        {
            DatabaseConnection db = new DatabaseConnection();

            try
            {
                MySqlConnection conn = db.GetConnection();
                conn.Open();

                string query = "SELECT distinct(e.name) FROM events e join event_schedules es " +
                    "on es.event_id = e.event_id " +
                    "join event_judges ej on es.eve_s_id = ej.eve_s_id where judge_id = @ID";
                MySqlCommand evalCmd = new MySqlCommand(query, conn);
                evalCmd.Parameters.AddWithValue("@ID", ID);

                using (MySqlDataReader reader = evalCmd.ExecuteReader())
                {
                    // Clear ComboBox before adding new items
                    comboBox2.Items.Clear();

                    // Read each row from the result set and add it to the ComboBox
                    while (reader.Read())
                    {
                        comboBox2.Items.Add(reader["name"].ToString());
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

        private void comboBox3_DropDown(object sender, EventArgs e)
        {
            DatabaseConnection db = new DatabaseConnection();
            string event_name = comboBox2.SelectedItem?.ToString() ?? ""; ;
            try
            {
                MySqlConnection conn = db.GetConnection();
                conn.Open();

                string query = @"SELECT r.name
                FROM event_schedules es
                JOIN events e ON e.event_id = es.event_id
                JOIN rounds r ON r.round_id = es.round_id
                JOIN event_judges ej ON ej.eve_s_id = es.eve_s_id
                WHERE ej.judge_id = @ID AND e.name = @event_name";

                MySqlCommand evalCmd = new MySqlCommand(query, conn);
                evalCmd.Parameters.AddWithValue("@ID", ID);
                evalCmd.Parameters.AddWithValue("@event_name", event_name);

                using (MySqlDataReader reader = evalCmd.ExecuteReader())
                {
                    // Clear ComboBox before adding new items
                    comboBox3.Items.Clear();

                    // Read each row from the result set and add it to the ComboBox
                    while (reader.Read())
                    {
                        comboBox3.Items.Add(reader["name"].ToString());
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

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
