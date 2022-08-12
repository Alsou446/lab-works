using System.Data.SQLite;
using System.Globalization;

namespace Server
{
    public class SQLiteWorker
    {
        public readonly string DatetimeFormat = "dd.MM.yyyy_hh:mm:ss";
        private readonly string DbConnStr = "Data Source=C:\\Users\\gothi\\source\\repos\\C#_M_lab\\ChatDatabase.db;mode=Exclusive";
        public SQLiteWorker()
        {
            
        }

        public bool UserExist(string user)
        {
            bool exist = false;

            using (SQLiteConnection Connection = new SQLiteConnection(DbConnStr))
            {
                string commandText = "SELECT COUNT(User.id) as count FROM User WHERE User.username = @username";

                using (SQLiteCommand Command = new SQLiteCommand(commandText, Connection))
                {                    
                    Command.Parameters.AddWithValue("@username", user);
                    Connection.Open();

                    using (SQLiteDataReader sqlReader = Command.ExecuteReader())
                    {                        
                        sqlReader.Read();
                        if (sqlReader["count"].ToString() != "0")
                        {
                            exist = true;
                        }
                        Connection.Close();
                    }
                }
            }

            return exist;
        }

        public void AddUser(string user, string passMd5)
        {
            using (SQLiteConnection Connect = new SQLiteConnection(DbConnStr))
            {
                string commandText = "INSERT INTO User (username, password, timemark) VALUES(@username, @password, @timemark)";
                using (SQLiteCommand Command = new SQLiteCommand(commandText, Connect))
                {
                    Command.Parameters.AddWithValue("@username", user);
                    Command.Parameters.AddWithValue("@password", passMd5);
                    Command.Parameters.AddWithValue("@timemark", System.DateTime.Now.AddHours(1).ToString(DatetimeFormat));

                    Connect.Open();
                    Command.ExecuteNonQuery();
                    Connect.Close();
                }
            }            
        }

        public System.DateTime GetTimemark(string user)
        {
            System.DateTime timemark;
            using (SQLiteConnection Connect = new SQLiteConnection(DbConnStr))
            {
                string commandText = "SELECT timemark FROM User WHERE User.username = @username";
                using (SQLiteCommand Command = new SQLiteCommand(commandText, Connect))
                {
                    Command.Parameters.AddWithValue("@username", user);
                    Connect.Open();
                    using (SQLiteDataReader sqlReader = Command.ExecuteReader())
                    {
                        sqlReader.Read();
                        timemark = System.DateTime.ParseExact(sqlReader["timemark"].ToString(), DatetimeFormat, CultureInfo.InvariantCulture);
                        Connect.Close();
                    }
                }
            }
            return timemark;
        }

        public string GetPassword(string user)
        {
            string password;
            using (SQLiteConnection Connect = new SQLiteConnection(DbConnStr))
            {
                string commandText = "SELECT password FROM User WHERE User.username = @username";
                using (SQLiteCommand Command = new SQLiteCommand(commandText, Connect))
                {
                    Command.Parameters.AddWithValue("@username", user);
                    Connect.Open();
                    using (SQLiteDataReader sqlReader = Command.ExecuteReader())
                    {
                        sqlReader.Read();
                        password = sqlReader["password"].ToString();
                        Connect.Close();
                    }
                }
            }
            return password;
        }

        public void UpdateTimemark(string user)
        {
            using (SQLiteConnection Connect = new SQLiteConnection(DbConnStr))
            {
                string commandText = "UPDATE User SET timemark = @timemark WHERE User.username = @username";
                using (SQLiteCommand Command = new SQLiteCommand(commandText, Connect))
                {
                    Command.Parameters.AddWithValue("@username", user);
                    Command.Parameters.AddWithValue("@timemark", System.DateTime.Now.AddHours(1).ToString(DatetimeFormat));

                    Connect.Open();
                    Command.ExecuteNonQuery();
                    Connect.Close();
                }
            }
        }        
    }
}