using MahApps.Metro.Controls;
using Diary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Diary.Models;

namespace Diary.Views
{
    /// <summary>
    /// Interaction logic for EditSettingsView.xaml
    /// </summary>
    public partial class EditSettingsView : MetroWindow
    {
        public EditSettingsView(bool canCloseWindow)
        {
            InitializeComponent();
            DataContext = new EditSettingsViewModel(canCloseWindow);
        }
    }
}
