using Diary.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.Models
{
    public class UserSettings
    {
        public string ServerAddress 
        { 
            get
            {
                return Settings.Default.ServerAddress;
            }
            set
            {
                Settings.Default.ServerAddress = value;
            }
        }
        public string ServerName
        {
            get
            {
                return Settings.Default.ServerName;
            }
            set
            {
                Settings.Default.ServerName = value;
            }
        }
        public string DataBase
        {
            get
            {
                return Settings.Default.Database;
            }
            set
            {
                Settings.Default.Database = value;
            }
        }
        public string Username
        {
            get
            {
                return Settings.Default.User;
            }
            set
            {
                Settings.Default.User = value;
            }
        }
        public string Password
        {
            get
            {
                return Settings.Default.Password;
            }
            set
            {
                Settings.Default.Password = value;
            }
        }
    }
}
