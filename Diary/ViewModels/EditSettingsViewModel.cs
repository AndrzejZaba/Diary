using Diary.Commands;
using Diary.Models;
using Diary.Models.Domains;
using Diary.Models.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Data.Entity.Infrastructure.Design.Executor;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows;
using System.Diagnostics;

namespace Diary.ViewModels
{
    public class EditSettingsViewModel : ViewModelBase
    {
        private UserSettings _userSettings;
        public UserSettings UserSettings
        {
            get
            {
                return _userSettings;
            }
            set
            {
                _userSettings = value;
                OnPropertyChanged();
            }
        }
        public EditSettingsViewModel()
        {
            CloseCommand = new RelayCommand(Close);
            ConfirmCommand = new RelayCommand(Confirm);
            _userSettings = new UserSettings();


        }

        public ICommand CloseCommand { get; set; }
        public ICommand ConfirmCommand { get; set; }

        private void Confirm(object obj)
        {
            if (!UserSettings.IsValid)
                return;

            UserSettings.Save();
            RestartApplication();
        }

        private void RestartApplication()
        {
            Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }

        private void Close(object obj)
        {
            CloseWindow(obj as Window);
        }

        private void CloseWindow(Window window)
        {
            window.Close();
        }
    }
}
