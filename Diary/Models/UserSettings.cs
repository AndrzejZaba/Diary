using ControlzEx.Standard;
using Diary.Commands;
using Diary.Models;
using Diary.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;

namespace Diary.Models
{
    public class UserSettings : IDataErrorInfo
    {
        private bool _isServerAddressValid;
        private bool _isServerNameValid;
        private bool _isDataBaseValid;
        private bool _isUsernameValid;
        private bool _isPasswordValid;
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


        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(ServerAddress):
                        if (string.IsNullOrWhiteSpace(ServerAddress))
                        {
                            Error = "Pole Adres serwera jest wymagane.";
                            _isServerAddressValid = false;
                        }
                        else
                        {
                            Error = string.Empty;
                            _isServerAddressValid = true;
                        }
                        break;
                    case nameof(ServerName):
                        if (string.IsNullOrWhiteSpace(ServerName))
                        {
                            Error = "Pole Nazwa serwera jest wymagane.";
                            _isServerNameValid = false;
                        }
                        else
                        {
                            Error = string.Empty;
                            _isServerNameValid = true;
                        }
                        break;
                    case nameof(DataBase):
                        if (string.IsNullOrWhiteSpace(DataBase))
                        {
                            Error = "Pole Nazwa bazy danych jest wymagane.";
                            _isDataBaseValid = false;
                        }
                        else
                        {
                            Error = string.Empty;
                            _isDataBaseValid = true;
                        }
                        break;
                    case nameof(Username):
                        if (string.IsNullOrWhiteSpace(Username))
                        {
                            Error = "Pole Login użytkownika jest wymagane.";
                            _isUsernameValid = false;
                        }
                        else
                        {
                            Error = string.Empty;
                            _isUsernameValid = true;
                        }
                        break;
                    case nameof(Password):
                        if (string.IsNullOrWhiteSpace(Password))
                        {
                            Error = "Pole Hasło użytkownika jest wymagane.";
                            _isPasswordValid = false;
                        }
                        else
                        {
                            Error = string.Empty;
                            _isPasswordValid = true;
                        }
                        break;
                }
                return Error;
            }
        }
        public string Error { get; set; }
        public bool IsValid
        {
            get
            {
                return _isServerAddressValid &&
                    _isServerNameValid &&
                    _isDataBaseValid &&
                _isUsernameValid &&
                    _isPasswordValid;
            }
        }
        public void Save()
        {
            Settings.Default.Save();
        }
    }
}
