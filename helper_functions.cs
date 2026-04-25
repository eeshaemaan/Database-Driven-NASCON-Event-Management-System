using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp2;

namespace WindowsFormsApp1
{
    static class helper_functions
    {
        // for report generation
        static public DataTable GetViewData(string viewName, MySqlConnection connection)
        {
            string query = $"SELECT * FROM {viewName}";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public static void LoadViewIntoPanel(Panel panel, string report_name)
        {
            DataGridView grid = new DataGridView();
            grid.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grid.Dock = DockStyle.None;
            grid.Location = new Point(0, 0);
            grid.Size = panel.Size;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.ReadOnly = true;
            grid.DefaultCellStyle.ForeColor = Color.Black;

            DatabaseConnection db = new DatabaseConnection();
            db.Connect();
            MySqlConnection conn = db.GetConnection();

            DataTable dt = GetViewData(report_name, conn);
            grid.DataSource = dt;
            db.Close();

            panel.Controls.Clear();
            panel.Controls.Add(grid);
            grid.BringToFront();
        }

        public static void participant_details_per_event_procedureCall(Panel panel, string eventName)
        {
            DatabaseConnection db = new DatabaseConnection();
            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand("get_participant_demographics", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@event_name", eventName);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    DataGridView grid = new DataGridView();
                    grid.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                    grid.Dock = DockStyle.None;
                    grid.Location = new Point(0, 0);
                    grid.Size = panel.Size;
                    grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    grid.ReadOnly = true;
                    grid.DefaultCellStyle.ForeColor = Color.Black;

                    grid.DataSource = dt;
                    db.Close();

                    panel.Controls.Clear();
                    panel.Controls.Add(grid);
                    grid.BringToFront();
                }
            }
        }
    }
}
