using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Management.Instrumentation;
using System.Windows.Forms;
using System.Xml.Linq;
using WindowsFormsApp1;

namespace WinFormsApp2
{
    class DatabaseConnection
    {
        private static readonly string connectionString =
            "server=db-project-db-project-sem04.l.aivencloud.com;port=17110;database=defaultdb;user=avnadmin;password=AVNS_6PxmumYFS_hBk6Ek4az;";
        private MySqlConnection connection;

        // Constructor initializes connection
        public DatabaseConnection()
        {
            connection = new MySqlConnection(connectionString);
        }

        // Open connection
        public void Connect()
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                    System.Diagnostics.Debug.WriteLine("Connected to MySQL database!");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Connection failed: " + ex.ToString());
            }
        }

        // Close connection
        public void Close()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
                System.Diagnostics.Debug.WriteLine("Connection closed.");
            }
        }

        // Get connection object for queries
        public MySqlConnection GetConnection()
        {
            return connection;
        }


        //Function ro return the id of the currnt event organizer
        public int GetOrganizerId()
        {
            return 3; // Replace with the actual ID of the organizer using the form
        }


        // Function to insert data in the event table
        public void InsertEvent(string name, string category, string description, int maxParticipants,
                        decimal registrationFees, decimal winnerPrize, decimal runnerUpPrize, int organizerId,
                        string rules, DateTime eventDate, TimeSpan startTime, TimeSpan endTime, int venue)
        {
            string query = @"INSERT INTO events (name, category, description, max_participants, registration_fee,
                           winner_prize, runnerUp_prize, event_org_id, rules, event_date, start_time, end_time, venue_id) 
                           VALUES (@Name, @Category, @Description, @MaxParticipants, @RegistrationFees, @WinnerPrize,
                           @RunnerUpPrize, @OrganizerId, @Rules, @EventDate, @StartTime, @EndTime, @Venue)";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Category", category);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@MaxParticipants", maxParticipants);
                    cmd.Parameters.AddWithValue("@RegistrationFees", registrationFees);
                    cmd.Parameters.AddWithValue("@WinnerPrize", winnerPrize);
                    cmd.Parameters.AddWithValue("@RunnerUpPrize", runnerUpPrize);
                    cmd.Parameters.AddWithValue("@OrganizerId", organizerId);
                    cmd.Parameters.AddWithValue("@Rules", rules);
                    cmd.Parameters.AddWithValue("@EventDate", eventDate);
                    cmd.Parameters.AddWithValue("@StartTime", startTime);
                    cmd.Parameters.AddWithValue("@EndTime", endTime);
                    cmd.Parameters.AddWithValue("@Venue", venue);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Event added successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting event: " + ex.Message);
            }
        }

        //Gets the name of the organizer from the uer table using join
        public string GetOrganizerNameByOrganizerId(int organizerId)
        {
            string query = @"
            SELECT u.name
            FROM event_organizer eo
            JOIN user u ON eo.user_id = u.user_id
            WHERE eo.event_org_id = @OrganizerId";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@OrganizerId", organizerId);
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                        return result.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching organizer name: " + ex.Message);
            }

            return "Unknown";
        }

        // Returns all events from the event table
        public DataTable GetAllEvents()
        {

            // using join to get venue names using venue id
            string query = @"
                                SELECT e.event_id, e.event_org_id, e.name, e.category, e.description, e.rules, e.max_participants, 
                                e.registration_fee, e.winner_prize, e.runnerUp_prize, e.event_date, 
                                v.name AS venue_name, e.start_time, e.end_time
                                FROM events e
                                JOIN venues v ON e.venue_id = v.venue_id";


            DataTable dt = new DataTable();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching events: " + ex.ToString());
            }

            return dt;
        }


        public void AssignAccommodation(int accomId, string roomType, DateTime checkInDate, DateTime checkOutDate)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    Connect();
                }

                //checking available rooms according to user's req
                string availabilityCheckQuery = @"
                    SELECT room_id 
                    FROM rooms 
                    WHERE room_type = @RoomType -- matches user's type
                    AND NOT EXISTS (
                        SELECT 1    -- one row where this room is already booked within the reuested duration
                        FROM accommodation_assignment 
                        WHERE room_id = rooms.room_id
                        AND (
                            (check_in_date BETWEEN @CheckInDate AND @CheckOutDate) OR
                            (check_out_date BETWEEN @CheckInDate AND @CheckOutDate) OR
                            (@CheckInDate BETWEEN check_in_date AND check_out_date)
                        )
                    )
                    LIMIT 1"; // gets the first available room

                using (MySqlCommand availabilityCmd = new MySqlCommand(availabilityCheckQuery, connection))
                {
                    availabilityCmd.Parameters.AddWithValue("@RoomType", roomType);
                    availabilityCmd.Parameters.AddWithValue("@CheckInDate", checkInDate);
                    availabilityCmd.Parameters.AddWithValue("@CheckOutDate", checkOutDate);

                    object result = availabilityCmd.ExecuteScalar();

                    if (result == null)
                    {
                        MessageBox.Show("No available rooms for the requested dates. Please try again later.");
                        return;
                    }

                    int roomId = Convert.ToInt32(result);

                    string assignmentQuery = @"
                                        INSERT INTO accommodation_assignment (accom_id, room_id, check_in_date, check_out_date, status) 
                                        VALUES (@AccomId, @RoomId, @CheckInDate, @CheckOutDate, 'assigned')";

                    using (MySqlCommand assignCmd = new MySqlCommand(assignmentQuery, connection))
                    {
                        assignCmd.Parameters.AddWithValue("@AccomId", accomId);
                        assignCmd.Parameters.AddWithValue("@RoomId", roomId);
                        assignCmd.Parameters.AddWithValue("@CheckInDate", checkInDate);
                        assignCmd.Parameters.AddWithValue("@CheckOutDate", checkOutDate);

                        assignCmd.ExecuteNonQuery();
                        MessageBox.Show("Room assigned successfully!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error assigning room to accommodation: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }


        public void InsertAccommodationRequest(int partId, string roomType, DateTime checkInDate, DateTime checkOutDate, string status, decimal totalCost)
        {
            string query = @"INSERT INTO accommodation_request (part_id, room_type, check_in_date, check_out_date, status, total_cost) 
                           VALUES (@PartId, @RoomType, @CheckInDate, @CheckOutDate, @Status, @TotalCost)";
            try
            {

                if (connection.State == ConnectionState.Closed)
                {
                    Connect();
                }

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@PartId", partId);
                    cmd.Parameters.AddWithValue("@RoomType", roomType);
                    cmd.Parameters.AddWithValue("@CheckInDate", checkInDate);
                    cmd.Parameters.AddWithValue("@CheckOutDate", checkOutDate);
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@TotalCost", totalCost);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Accommodation request submitted successfully!");
                    int accomId = Convert.ToInt32(cmd.LastInsertedId);
                    AssignAccommodation(accomId, roomType, checkInDate, checkOutDate);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting accommodation request: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    Close();
                }
            }
        }

        // Function to authenticate user and get role
        public string Login(string usernameOrEmail, string password)
        {
            string role = null;

            string query = "SELECT role FROM user WHERE (name = @input OR email = @input) AND password = @password";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@input", usernameOrEmail);
                    cmd.Parameters.AddWithValue("@password", password);

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        role = result.ToString();
                    }
                }
            }
            return role;
        }

        public bool RegisterUser(string name, string phone, string email, string password, string role)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    Connect();
                }

                string query = "INSERT INTO user (name, phone_no, email, password, role) VALUES (@name, @phone, @email, @password, @role)";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password); // **you forgot password here originally**
                cmd.Parameters.AddWithValue("@role", role);

                int rowsAffected = cmd.ExecuteNonQuery();

                // Now insert into role-specific table
                if (rowsAffected > 0)
                {
                    int userId = (int)cmd.LastInsertedId;

                    switch (role)
                    {
                        case "Judge":
                            string judgeQuery = "INSERT INTO judge (user_id) VALUES (@userId)";
                            using (MySqlCommand judgeCmd = new MySqlCommand(judgeQuery, connection))
                            {
                                judgeCmd.Parameters.AddWithValue("@userId", userId);
                                judgeCmd.ExecuteNonQuery();
                            }
                            break;

                        case "Participant":
                            string participantQuery = "INSERT INTO participant (user_id) VALUES (@userId)";
                            using (MySqlCommand participantCmd = new MySqlCommand(participantQuery, connection))
                            {
                                participantCmd.Parameters.AddWithValue("@userId", userId);
                                participantCmd.ExecuteNonQuery();
                            }
                            break;

                        case "Event Organizer":
                            string eventOrgQuery = "INSERT INTO event_organizer (user_id) VALUES (@userId)";
                            using (MySqlCommand eventOrgCmd = new MySqlCommand(eventOrgQuery, connection))
                            {
                                eventOrgCmd.Parameters.AddWithValue("@userId", userId);
                                eventOrgCmd.ExecuteNonQuery();
                            }
                            break;
                    }

                    MessageBox.Show("User registered successfully!");
                    return true;
                }
                else
                {
                    MessageBox.Show("User registration failed.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during registration: " + ex.Message);
                return false;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    Close();
                }
            }
        }




        public bool CheckIfEmailExists(string email)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM user WHERE email = @email";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@email", email);
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                return count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }

        public bool CheckIfUsernameOrEmailExists(string usernameOrEmail)
        {
            string query = "SELECT COUNT(*) FROM user WHERE name = @input OR email = @input";
            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@input", usernameOrEmail);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        public bool CheckIfPasswordMatches(string usernameOrEmail, string password)
        {
            string query = "SELECT password FROM user WHERE name = @input OR email = @input";
            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@input", usernameOrEmail);
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    string storedPassword = result.ToString();
                    return storedPassword == password; // Replace with hash comparison if using hashed passwords
                }
                return false;
            }
        }

        public int GetUserIDByUsernameOrEmail(string usernameOrEmail)
        {
            string query = "SELECT user_id FROM user WHERE name = @input OR email = @input";
            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@input", usernameOrEmail);
                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : -1;
            }
        }

        public string GetUserRoleByUsernameOrEmail(string usernameOrEmail)
        {
            string query = "SELECT role FROM user WHERE name = @input OR email = @input";
            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@input", usernameOrEmail);
                object result = cmd.ExecuteScalar();
                return result?.ToString();
            }
        }

        public string GetUsernameByUsernameOrEmail(string usernameOrEmail)
        {
            string query = "SELECT name FROM user WHERE name = @input OR email = @input";
            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@input", usernameOrEmail);
                object result = cmd.ExecuteScalar();
                return result?.ToString();
            }
        }

        public (string username, string email, string phone) GetUserDetails(int userId)
        {
            string query = "SELECT username, email, phone FROM users WHERE id = @id";

            try
            {
                if (connection.State == ConnectionState.Closed)
                    Connect();

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", userId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string username = reader.GetString("username");
                            string email = reader.GetString("email");
                            string phone = reader.GetString("phone");
                            return (username, email, phone);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving user details: " + ex.Message);
            }

            return (null, null, null);
        }

        public int InsertSponsor(string companyName, int userId, string category)
        {
            int sponsorId = -1;
            string query = "INSERT INTO sponsor (company_name, user_id, category) VALUES (@name, @userId, @category)";
            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            { 

                cmd.Parameters.AddWithValue("@name", companyName);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@category", category);
                cmd.ExecuteNonQuery();

                sponsorId = (int)cmd.LastInsertedId;
            }

            return sponsorId;
        }

        public bool InsertSponsorship(int sponsorId, int eventId, int orgId, decimal amount)
        {
            string query = @"INSERT INTO sponsorship (sponsor_id, event_id, event_org_id, amount_paid) 
                     VALUES (@sponsorId, @eventId, @orgId, @amount)";
            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@sponsorId", sponsorId);
                cmd.Parameters.AddWithValue("@eventId", eventId);
                cmd.Parameters.AddWithValue("@orgId", orgId);
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.ExecuteNonQuery();
                return true;
            }
        }

        public DataTable GetEventsByParticipant(int participantId)
        {
            string query = @"
                    SELECT e.name, e.category, e.description, e.rules, e.max_participants, 
                           e.registration_fee, e.winner_prize, e.runnerUp_prize, e.event_date, 
                           v.name AS venue_name, e.start_time, e.end_time
                    FROM events e
                    JOIN venues v ON e.venue_id = v.venue_id
                    JOIN event_team et ON e.event_id = et.event_id
                    JOIN team_participants tp ON et.team_id = tp.team_id
                    WHERE tp.part_id = @participantId";  

            DataTable dt = new DataTable();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Add parameter to query to avoid SQL injection
                        cmd.Parameters.AddWithValue("@participantId", participantId);

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching participant's events: " + ex.ToString());
            }

            return dt;
        }

        public int GetParticipantIdByUserId()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();
                string query = @"SELECT part_id FROM participant WHERE user_id = @userId";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", Session.LoggedInUserID);

                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToInt32(result);
                }
                else
                {
                    return -1; // Not found
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return -1; 
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Dispose();
            }
        }

        public DataTable GetAccommodationDetails(int participantId)
        {
            
            MySqlConnection conn = new MySqlConnection(connectionString);
            DataTable dt = new DataTable();

            try
            {
                conn.Open();  
                string query = @"SELECT ar.check_in_date, ar.check_out_date, r.room_name, r.room_type, ar.status, ar.total_cost
                         FROM accommodation_request ar
                         JOIN rooms r ON ar.room_type = r.room_type
                         WHERE ar.part_id = @partId";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@partId", participantId);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);  

                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return null;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();  
                }
                conn.Dispose();  
            }
        }

        public int GetJudgeIdByUserId()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();
                string query = @"SELECT judge_id FROM judge WHERE user_id = @userId";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", Session.LoggedInUserID);

                object result = cmd.ExecuteScalar();
                return (result != null && result != DBNull.Value) ? Convert.ToInt32(result) : -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return -1;
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Dispose();
            }
        }

        public int GetSponsorIdByUserId()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();
                string query = @"SELECT sponsor_id FROM sponsor WHERE user_id = @userId";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", Session.LoggedInUserID);

                object result = cmd.ExecuteScalar();
                return (result != null && result != DBNull.Value) ? Convert.ToInt32(result) : -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return -1;
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Dispose();
            }
        }

        public int GetEventOrganizerIdByUserId()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();
                string query = @"SELECT event_org_id FROM event_organizer WHERE user_id = @userId";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", Session.LoggedInUserID);

                object result = cmd.ExecuteScalar();
                return (result != null && result != DBNull.Value) ? Convert.ToInt32(result) : -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return -1;
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Dispose();
            }
        }



    }


}