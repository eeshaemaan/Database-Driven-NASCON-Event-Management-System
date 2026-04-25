using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp2;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class registeration_page:Form
    {
        private Panel panel1;
        private Label label5;
        private Panel back_panel;
        private Button button1;
        private Button add_participant_btn;
        private TextBox textBox1;
        private Label label2;
        private Panel panel2;
        private Label label1;
        private Label label4;
        private PictureBox pictureBox2;
        private string eventName;
        private Label label_EventOrg_ID;
        private int team_id_for_payment;
        public registeration_page(string eventName)
        {
            InitializeComponent();
            this.eventName = eventName;
            this.label4.Text = "Registration for " + (string.IsNullOrEmpty(eventName) ? " " : eventName);
            this.label4.BackColor = Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Black;
            add_participant_btn.Enabled = false;

            DatabaseConnection dbConnection = new DatabaseConnection();
            int participantId = dbConnection.GetParticipantIdByUserId();
            label_EventOrg_ID.Text = "Your ID: " + participantId.ToString();

            // the add participant button is only enabled if the user has 
            // entered the team name
            textBox1.TextChanged += (s, e) =>
            {
                add_participant_btn.Enabled = !string.IsNullOrWhiteSpace(textBox1.Text);
            };

            this.add_participant_btn.Click += (s, e) => AddMoreParticipants();
            this.add_participant_btn.ForeColor = System.Drawing.Color.White;
        }

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.back_panel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.add_participant_btn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_EventOrg_ID = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.back_panel.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(812, 71);
            this.panel1.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
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
            // back_panel
            // 
            this.back_panel.AutoScroll = true;
            this.back_panel.BackColor = System.Drawing.Color.MistyRose;
            this.back_panel.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.Backgrounf_Img;
            this.back_panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.back_panel.Controls.Add(this.label_EventOrg_ID);
            this.back_panel.Controls.Add(this.button1);
            this.back_panel.Controls.Add(this.add_participant_btn);
            this.back_panel.Controls.Add(this.textBox1);
            this.back_panel.Controls.Add(this.label2);
            this.back_panel.Controls.Add(this.panel2);
            this.back_panel.Controls.Add(this.label1);
            this.back_panel.Controls.Add(this.label4);
            this.back_panel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.back_panel.Location = new System.Drawing.Point(3, 78);
            this.back_panel.Name = "back_panel";
            this.back_panel.Size = new System.Drawing.Size(805, 496);
            this.back_panel.TabIndex = 12;
            this.back_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.back_panel_Paint);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(286, 443);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(238, 40);
            this.button1.TabIndex = 18;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.reg_submit_button_Click);
            // 
            // add_participant_btn
            // 
            this.add_participant_btn.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.add_participant_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add_participant_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.add_participant_btn.Location = new System.Drawing.Point(513, 100);
            this.add_participant_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.add_participant_btn.Name = "add_participant_btn";
            this.add_participant_btn.Size = new System.Drawing.Size(238, 40);
            this.add_participant_btn.TabIndex = 17;
            this.add_participant_btn.Text = "Add Participant";
            this.add_participant_btn.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(173, 109);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(321, 22);
            this.textBox1.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(25, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 28);
            this.label2.TabIndex = 22;
            this.label2.Text = "Team Name: ";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.panel2.Location = new System.Drawing.Point(10, 161);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(754, 260);
            this.panel2.TabIndex = 21;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(25, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(377, 28);
            this.label1.TabIndex = 20;
            this.label1.Text = "Lead Participant will register the team";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(25, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 31);
            this.label4.TabIndex = 19;
            // 
            // label_EventOrg_ID
            // 
            this.label_EventOrg_ID.AutoSize = true;
            this.label_EventOrg_ID.BackColor = System.Drawing.Color.Transparent;
            this.label_EventOrg_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label_EventOrg_ID.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label_EventOrg_ID.Location = new System.Drawing.Point(641, 13);
            this.label_EventOrg_ID.Name = "label_EventOrg_ID";
            this.label_EventOrg_ID.Size = new System.Drawing.Size(44, 25);
            this.label_EventOrg_ID.TabIndex = 28;
            this.label_EventOrg_ID.Text = "----";
            // 
            // registeration_page
            // 
            this.BackColor = System.Drawing.Color.MistyRose;
            this.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.Backgrounf_Img;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(812, 582);
            this.Controls.Add(this.back_panel);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Name = "registeration_page";
            this.Load += new System.EventHandler(this.registeration_page_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.back_panel.ResumeLayout(false);
            this.back_panel.PerformLayout();
            this.ResumeLayout(false);

        }

       


    // dynamic add more participants to a team code
    int participantCount = 0;
        private void AddMoreParticipants()
        {
            int yOffset = participantCount * 100;

            // Label - Participant ID
            Label idLabel = new Label();
            idLabel.Text = "Participant ID:";
            idLabel.Location = new Point(0, yOffset + 5);
            idLabel.Width = 100;
            idLabel.ForeColor = Color.White;

            // TextBox - Participant ID
            TextBox idBox = new TextBox();
            idBox.Name = "idBox_" + participantCount;
            idBox.Location = new Point(110, yOffset);
            idBox.Width = 150;

            //Accommodation
            Label accLabel = new Label();
            accLabel.Text = "Accommodation?";
            accLabel.Location = new Point(280, yOffset + 5);
            accLabel.Width = 110;
            accLabel.ForeColor = Color.White;

            Button accButton = new Button();
            accButton.Name = "accButton_" + participantCount;
            accButton.Text = "Request";
            accButton.Location = new Point(400, yOffset);
            accButton.Width = 120;
            accButton.ForeColor = Color.Black;
            accButton.BackColor = Color.LightGray;

            accButton.Click += (s, e) =>
            {
                Participant_Accommodation accForm = new Participant_Accommodation();
                accForm.ShowDialog(); 
            };



            // Add to panel
            panel2.Controls.Add(idLabel);
            panel2.Controls.Add(idBox);
            panel2.Controls.Add(accLabel);
            panel2.Controls.Add(accButton);


            participantCount++;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void registeration_page_Load(object sender, EventArgs e)
        {

        }

        private void reg_submit_button_Click(object sender, EventArgs e)
        {
            string team_name = textBox1.Text;
            int team_id = 0;

            DatabaseConnection db = new DatabaseConnection();
            MySqlConnection conn = db.GetConnection();
            conn.Open();
            MySqlTransaction transaction = conn.BeginTransaction();

            try
            {
                // Insert team
                string insertTeamQuery = "INSERT INTO teams (name) VALUES (@team_name);";
                MySqlCommand insertTeamCmd = new MySqlCommand(insertTeamQuery, conn, transaction);
                insertTeamCmd.Parameters.AddWithValue("@team_name", team_name);
                insertTeamCmd.ExecuteNonQuery();

                // Get inserted team ID
                string getTeamIdQuery = "SELECT team_id FROM teams WHERE name = @team_name;";
                MySqlCommand getTeamIdcmd = new MySqlCommand(getTeamIdQuery, conn, transaction);
                getTeamIdcmd.Parameters.AddWithValue("@team_name", team_name);
                object result = getTeamIdcmd.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    team_id = Convert.ToInt32(result);
                    team_id_for_payment = team_id;
                }

                // Get event_org_id
                string getEventOrgIdQuery = "SELECT event_org_id FROM events WHERE name = @event_name";
                MySqlCommand eventCmd = new MySqlCommand(getEventOrgIdQuery, conn, transaction);
                eventCmd.Parameters.AddWithValue("@event_name", eventName);
                result = eventCmd.ExecuteScalar();
                if (result == DBNull.Value)
                {
                    throw new Exception("Event not found!");
                }
                int event_org_id = Convert.ToInt32(result);
                

                // Check participants
                for (int i = 0; i < participantCount; i++)
                {
                    var idBox = panel2.Controls.Find("idBox_" + i, false).FirstOrDefault() as TextBox;
                    if (idBox == null || string.IsNullOrWhiteSpace(idBox.Text))
                    {
                        throw new Exception("You cannot leave empty participant slots.");
                    }

                    string participantId = idBox.Text;
                    string checkQuery = "SELECT COUNT(*) FROM participant WHERE part_id = @id";
                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn, transaction);
                    checkCmd.Parameters.AddWithValue("@id", participantId);
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count == 0)
                    {
                        throw new Exception("Participant with ID " + participantId + " doesn't exist.");
                    }
                }

                // Insert team-participants and accommodations
                for (int i = 0; i < participantCount; i++)
                {
                    var idBox = panel2.Controls.Find("idBox_" + i, false).FirstOrDefault() as TextBox;
                    var accDropdown = panel2.Controls.Find("accDropdown_" + i, false).FirstOrDefault() as ComboBox;

                    if (idBox != null && accDropdown != null)
                    {
                        string participantId = idBox.Text;
                        string accommodation = accDropdown.SelectedItem?.ToString() ?? "None";

                        // Insert into team_participants
                        string query1 = "INSERT INTO team_participants (team_id, part_id) VALUES (@team_id, @part_id)";
                        MySqlCommand cmd1 = new MySqlCommand(query1, conn, transaction);
                        cmd1.Parameters.AddWithValue("@team_id", team_id);
                        cmd1.Parameters.AddWithValue("@part_id", participantId);
                        cmd1.ExecuteNonQuery();

                        // Handle accommodation if requested
                        if (accommodation != "None")
                        {
                            string checkQuery = "SELECT COUNT(*) FROM accommodations WHERE event_org_id = @event_org_id AND part_id = @part_id";
                            MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn, transaction);
                            checkCmd.Parameters.AddWithValue("@event_org_id", event_org_id);
                            checkCmd.Parameters.AddWithValue("@part_id", participantId);

                            int exists = Convert.ToInt32(checkCmd.ExecuteScalar());

                            if (exists == 0)
                            {
                                string query2 = "INSERT INTO accommodations (event_org_id, part_id, budget, status) " +
                                                "VALUES (@event_org_id, @part_id, @budget, 'pending')";
                                MySqlCommand cmd2 = new MySqlCommand(query2, conn, transaction);
                                cmd2.Parameters.AddWithValue("@event_org_id", event_org_id);
                                cmd2.Parameters.AddWithValue("@part_id", participantId);
                                cmd2.Parameters.AddWithValue("@budget", accommodation);
                                cmd2.ExecuteNonQuery();
                            }
                            else
                            {
                                MessageBox.Show("Participant " + participantId + " already requested accommodation.");
                            }
                        }
                    }
                }

                transaction.Commit();
                MessageBox.Show("All participants saved!");

                // opening the payment page
                team_payment teamPaymentForm = new team_payment(eventName, team_id_for_payment);
                teamPaymentForm.Show();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show("Error: " + ex.Message);

                // Reload form
                this.Hide();
                var newForm = new registeration_page(eventName);
                newForm.Show();
                this.Close();
            }
            db.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void back_panel_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}

