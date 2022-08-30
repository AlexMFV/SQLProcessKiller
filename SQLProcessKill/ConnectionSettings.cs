using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLProcessKill
{
    public class ConnectionSettings
    {
        static string path = Path.Combine(Environment.CurrentDirectory);
        public string connectionString = "Server=@Instance;Database=@Database;User Id=@User;Password=@Password;";
        public bool hasSettings = false;
        public string instance = null;
        public string database = null;
        public string user = null;
        public string pwd = null;

        public ConnectionSettings()
        {
            ReadSettings();
        }

        public void ReadSettings()
        {
            string fullPath = Path.Combine(path, "settings.txt");
            if (File.Exists(fullPath))
            {
                using (StreamReader reader = new StreamReader(fullPath))
                {
                    string line = "";

                    while (line != null)
                    {
                        line = reader.ReadLine();
                        if (line == null)
                            break;

                        if (line.StartsWith("Instance:"))
                            instance = line.Replace("Instance:", "");

                        if (line.StartsWith("Database:"))
                            database = line.Replace("Database:", "");

                        if (line.StartsWith("User:"))
                            user = line.Replace("User:", "");

                        if (line.StartsWith("Password:"))
                            pwd = line.Replace("Password:", "");
                    }
                }

                connectionString = connectionString.Replace("@Instance", instance).Replace("@Database", database)
                    .Replace("@User", user).Replace("@Password", pwd);

                hasSettings = true;
            }
        }

        public void SaveSettings(string instance, string database, string user, string pwd)
        {
            string fullPath = Path.Combine(path, "settings.txt");
            string text =
                $"Instance:{instance}\n" +
                $"Database:{database}\n" +
                $"User:{user}\n" +
                $"Password:{pwd}\n";

            File.WriteAllText(fullPath, text);
        }
    }
}
