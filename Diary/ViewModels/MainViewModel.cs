using Diary.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Diary.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            RefreshStudentCommand = new RelayCommand(RefreshStudents, CanRefreshStudents);
        }

        public ICommand RefreshStudentCommand { get; set; }

        private void RefreshStudents(object obj)
        {
            MessageBox.Show("RefreshStudent");
        }

        private bool CanRefreshStudents(object obj)
        {
            return true;
        }

        

        
    }
}
