using System;
using System.Data.SQLite;

namespace WILDLINK_CLIENTS
{
    public static class DatabaseHelper
    {
        private static readonly string connectionString = "Data Source=ChatApp.db;Version=3;";

        public static void InitializeDatabase()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string createTableQuery = @"
                CREATE TABLE IF NOT EXISTS Users (
                    SchoolID TEXT PRIMARY KEY,
                    CollegeEmail TEXT UNIQUE,
                    Password TEXT
                )";
                using (var command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public static bool RegisterUser(string schoolID, string collegeEmail, string password)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string insertQuery = "INSERT INTO Users (SchoolID, CollegeEmail, Password) VALUES (@SchoolID, @CollegeEmail, @Password)";
                    using (var command = new SQLiteCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@SchoolID", schoolID);
                        command.Parameters.AddWithValue("@CollegeEmail", collegeEmail);
                        command.Parameters.AddWithValue("@Password", password);
                        command.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (SQLiteException ex)
            {
                // Handle unique constraint violation (email or school ID already exists)
                if (ex.ResultCode == SQLiteErrorCode.Constraint)
                {
                    return false;
                }
                throw;
            }
        }

        public static bool LoginUser(string schoolID, string password)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Users WHERE SchoolID = @SchoolID AND Password = @Password";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SchoolID", schoolID);
                    command.Parameters.AddWithValue("@Password", password);
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        public static bool EmailExists(string collegeEmail)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Users WHERE CollegeEmail = @CollegeEmail";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CollegeEmail", collegeEmail);
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        public static bool SchoolIDExists(string schoolID)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Users WHERE SchoolID = @SchoolID";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SchoolID", schoolID);
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
        }
    }
}
