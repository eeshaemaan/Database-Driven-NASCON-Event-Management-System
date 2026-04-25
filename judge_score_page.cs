using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp2;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections;

namespace WindowsFormsApp1
{
    public partial class judge_score_page : Form
    {
        private Panel panel1;
        private Label label5;
        private Label label1;
        private Panel panel2;
        private DataGridView dataGridView1;
        private PictureBox pictureBox2;
        private int ID;
        private string event_name;
        private Button ApplyForEvent;
        private string round_name;

        public judge_score_page(string event_name, int ID, string round_name)
        {
            this.ID = ID;
            this.event_name = event_name;
            this.round_name = round_name;
            InitializeComponent();
            LoadEvaluations();
        }

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ApplyForEvent = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Honeydew;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(775, 71);
            this.panel1.TabIndex = 23;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
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
            this.label1.Location = new System.Drawing.Point(40, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(366, 49);
            this.label1.TabIndex = 24;
            this.label1.Text = "Score Evaluation Page";
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.Backgrounf_Img;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Location = new System.Drawing.Point(3, 184);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(772, 451);
            this.panel2.TabIndex = 26;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Honeydew;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridView1.Location = new System.Drawing.Point(3, -6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(766, 454);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // ApplyForEvent
            // 
            this.ApplyForEvent.BackColor = System.Drawing.Color.Black;
            this.ApplyForEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApplyForEvent.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ApplyForEvent.Location = new System.Drawing.Point(515, 117);
            this.ApplyForEvent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ApplyForEvent.Name = "ApplyForEvent";
            this.ApplyForEvent.Size = new System.Drawing.Size(238, 40);
            this.ApplyForEvent.TabIndex = 27;
            this.ApplyForEvent.Text = "Submit Evaluations";
            this.ApplyForEvent.UseVisualStyleBackColor = false;
            this.ApplyForEvent.Click += new System.EventHandler(this.submitEvaluation);
            // 
            // judge_score_page
            // 
            this.BackColor = System.Drawing.Color.MistyRose;
            this.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.Backgrounf_Img;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(775, 636);
            this.Controls.Add(this.ApplyForEvent);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "judge_score_page";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void LoadEvaluations()
        {
            DatabaseConnection db = new DatabaseConnection();
            try
            {
                MySqlConnection conn = db.GetConnection();
                conn.Open();
                string query = " ";

                if (round_name.ToLower() == "prelim")
                {
                    query = @"SELECT t.name AS team_name, ev.score
                      FROM evaluations ev
                      JOIN teams t ON ev.team_id = t.team_id
                      JOIN event_schedules es ON es.eve_s_id = ev.eve_s_id
                      JOIN events e ON es.event_id = e.event_id
                      JOIN rounds r ON r.round_id = es.round_id
                      WHERE r.name = 'prelim' AND e.name = @event_name";
                }
                else if (round_name.ToLower() == "semi-final")
                {
                    // getting only those teams who qualified round 1
                    query = @"SELECT t.name AS team_name, ev.score
                    FROM evaluations ev
                    JOIN teams t ON ev.team_id = t.team_id
                    JOIN event_schedules es ON ev.eve_s_id = es.eve_s_id
                    JOIN rounds r ON es.round_id = r.round_id
                    JOIN events e ON es.event_id = e.event_id
                    WHERE r.name = 'Semi-Final'
                      AND e.name = @event_name
                      AND ev.team_id IN (
                          SELECT tr.team_id
                          FROM team_round_tracking tr
                          JOIN event_schedules es2 ON tr.eve_s_id = es2.eve_s_id
                          JOIN rounds r2 ON es2.round_id = r2.round_id
                          JOIN events e2 ON es2.event_id = e2.event_id
                          WHERE tr.status = 'qualified'
                            AND r2.name = 'Prelim'
                            AND e2.name = @event_name
                      );";
                }
                else if (round_name.ToLower() == "final")
                {
                    // getting only those teams who qualified round 2
                    query = @"SELECT t.name AS team_name, ev.score
                      FROM evaluations ev
                      JOIN teams t ON ev.team_id = t.team_id
                      JOIN event_schedules es ON ev.eve_s_id = es.eve_s_id
                      JOIN rounds r ON es.round_id = r.round_id
                      JOIN events e ON es.event_id = e.event_id
                      WHERE r.name = 'Final'
                        AND e.name = @event_name
                        AND ev.team_id IN (
                            SELECT tr.team_id
                            FROM team_round_tracking tr
                            JOIN event_schedules es2 ON tr.eve_s_id = es2.eve_s_id
                            JOIN rounds r2 ON es2.round_id = r2.round_id
                            JOIN events e2 ON es2.event_id = e2.event_id
                            WHERE tr.status = 'qualified'
                              AND r2.name = 'Semi-Final'
                              AND e2.name = @event_name
                        );";

                }
                else
                {
                    MessageBox.Show("Unknown round name: " + round_name);
                    return; // stop the function
                }


                //string query = @"SELECT t.name AS team_name, ev.score
                //FROM evaluations ev 
                //JOIN teams t ON ev.team_id = t.team_id
                //JOIN event_schedules es ON es.eve_s_id = ev.eve_s_id
                //JOIN events e ON es.event_id = e.event_id
                //JOIN rounds r ON r.round_id = es.round_id
                //WHERE r.name = @round_name AND e.name = @event_name";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@round_name", round_name);
                cmd.Parameters.AddWithValue("@event_name", event_name);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView1.DataSource = dt;

                // Make only Score editable
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    if (column.Name == "score")
                        column.ReadOnly = false;
                    else
                        column.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                db.Close();
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string teamName = dataGridView1.Rows[e.RowIndex].Cells["team_name"].Value.ToString();
            string scoreStr = dataGridView1.Rows[e.RowIndex].Cells["score"].Value.ToString();

            // convert the scoreStr (text from the grid)
            // into a decimal number. If it works, store it in newScore
            if (decimal.TryParse(scoreStr, out decimal newScore))
            {
                UpdateScoreInDatabase(teamName, newScore);
            }
            else
            {
                MessageBox.Show("Invalid score input.");
            }
        }

        private void UpdateScoreInDatabase(string teamName, decimal newScore)
        {
            DatabaseConnection db = new DatabaseConnection();
            MySqlConnection conn = db.GetConnection();
            conn.Open();

            // getting team_id
            int team_id = 0;
            string get_team_id = "select team_id from teams where name = @team_name";
            MySqlCommand get_team_id_cmd = new MySqlCommand(get_team_id, conn);
            get_team_id_cmd.Parameters.AddWithValue("@team_name", teamName);

            object result = get_team_id_cmd.ExecuteScalar();
            if (result != null)
            {
                team_id = Convert.ToInt32(result);
            }
            else
            {
                MessageBox.Show("Team not found.");
            }

            // getting the event_schedule_id
            int eve_s_id = 0;
            string eve_s_id_query = "select es.eve_s_id from event_schedules es " +
                "join events e on e.event_id = es.event_id " +
                "join rounds r on r.round_id = es.round_id " +
                "where r.name = @round_name and e.name = @event_name";
            MySqlCommand eve_s_id_cmd = new MySqlCommand(eve_s_id_query, conn);
            eve_s_id_cmd.Parameters.AddWithValue("@event_name", event_name);
            eve_s_id_cmd.Parameters.AddWithValue("@round_name", round_name);

            object result2 = eve_s_id_cmd.ExecuteScalar();
            if (result2 != null)
            {
                eve_s_id = Convert.ToInt32(result2);
            }
            else
            {
                MessageBox.Show("eve_s_id not found.");
            }

            try
            {
                string query = @"UPDATE evaluations ev set ev.score = @score 
                where eve_s_id = @eve_s_id and team_id = @team_id;";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@score", newScore);
                cmd.Parameters.AddWithValue("@eve_s_id", eve_s_id);
                cmd.Parameters.AddWithValue("@team_id", team_id);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Saved");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating score: " + ex.Message);
            }
            finally
            {
                db.Close();
            }
        }

        private void submitEvaluation(object sender, EventArgs e)
        {
            try
            {
                int currentRound = GetRoundIdByName(round_name); // Convert "Prelim", "Round 2" etc. to round ID
                int nextRound = currentRound + 1;

                List<int> qualifiedTeams = GetQualifiedTeamsForRound(currentRound);

                foreach (int teamId in qualifiedTeams)
                {
                    InsertEvaluationForNextRound(teamId, nextRound);
                }

                MessageBox.Show("Evaluations for the next round have been updated successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private int GetRoundIdByName(string roundName)
        {
            if (roundName.ToLower() == "prelim") return 1;
            if (roundName.ToLower() == "semi-final") return 2;
            if (roundName.ToLower() == "final") return 3;
            return 0;
        }

        private List<int> GetQualifiedTeamsForRound(int roundId)
        {
            DatabaseConnection db = new DatabaseConnection();
            MySqlConnection conn = db.GetConnection();
            conn.Open();
            List<int> qualifiedTeams = new List<int>();

            // getting the event_schedule_id
            int eve_s_id = 0;
            string eve_s_id_query = "select es.eve_s_id from event_schedules es " +
                "join events e on e.event_id = es.event_id " +
                "join rounds r on r.round_id = es.round_id " +
                "where r.name = @round_name and e.name = @event_name";
            MySqlCommand eve_s_id_cmd = new MySqlCommand(eve_s_id_query, conn);
            eve_s_id_cmd.Parameters.AddWithValue("@event_name", event_name);
            eve_s_id_cmd.Parameters.AddWithValue("@round_name", round_name);

            object result2 = eve_s_id_cmd.ExecuteScalar();
            if (result2 != null)
            {
                eve_s_id = Convert.ToInt32(result2);
            }
            else
            {
                MessageBox.Show("eve_s_id not found.");
            }

            string query = @"SELECT team_id
                     FROM team_round_tracking tr
                     WHERE tr.eve_s_id = @eve_s_id AND status = 'qualified'";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@eve_s_id", eve_s_id);

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    qualifiedTeams.Add(reader.GetInt32("team_id"));
                }
            }
            conn.Close();

            return qualifiedTeams;
        }

        private void InsertEvaluationForNextRound(int teamId, int roundId)
        {
            DatabaseConnection db = new DatabaseConnection();
            MySqlConnection conn = db.GetConnection();
            conn.Open();

            // getting the event_schedule_id
            int eve_s_id = 0;
            string eve_s_id_query = "select es.eve_s_id from event_schedules es " +
                "join events e on e.event_id = es.event_id " +
                "join rounds r on es.round_id = r.round_id " +
                "where r.round_id = @next_round_id and e.name = @event_name";
            MySqlCommand eve_s_id_cmd = new MySqlCommand(eve_s_id_query, conn);
            eve_s_id_cmd.Parameters.AddWithValue("@event_name", event_name);
            eve_s_id_cmd.Parameters.AddWithValue("@next_round_id", roundId);

            object result2 = eve_s_id_cmd.ExecuteScalar();
            if (result2 != null)
            {
                eve_s_id = Convert.ToInt32(result2);
            }
            else
            {
                MessageBox.Show("eve_s_id not found.");
            }

            string query = @"INSERT INTO evaluations (team_id, eve_s_id, score)
                       VALUES (@teamId, @eve_s_id, NULL)";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@teamId", teamId);
            cmd.Parameters.AddWithValue("@eve_s_id", eve_s_id);


            cmd.ExecuteNonQuery();
            db.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
