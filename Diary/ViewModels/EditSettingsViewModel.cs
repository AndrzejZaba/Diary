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

namespace Diary.ViewModels
{
    public class EditSettingsViewModel : ViewModelBase
    {
        public UserSettings SavedUserSettings { get; set; }
        public EditSettingsViewModel()
        {
            CloseCommand = new RelayCommand(Close);
            ConfirmCommand = new RelayCommand(Confirm);

            
        }

        public ICommand CloseCommand { get; set; }
        public ICommand ConfirmCommand { get; set; }

        private void Confirm(object obj)
        {
            throw new NotImplementedException();
        }

        private void Close(object obj)
        {
            throw new NotImplementedException();
        }

        
    }
}
