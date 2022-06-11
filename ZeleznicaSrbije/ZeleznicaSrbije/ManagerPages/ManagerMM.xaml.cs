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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ZeleznicaSrbije.ManagerPages
{
    public partial class ManagerMM : Page
    {
        public event Action<string> NavBarClicked;


        public ManagerMM()
        {
            InitializeComponent();
        }

        private void Profile_Checked(object sender, RoutedEventArgs e)
        {
            NavBarClicked?.Invoke("PROFILE_PAGE");
        }

        private void TrainSchedule_Checked(object sender, RoutedEventArgs e)
        {
            NavBarClicked?.Invoke("TRAIN_SCHEDULE_PAGE");
        }

        private void Trains_Checked(object sender, RoutedEventArgs e)
        {
            NavBarClicked?.Invoke("TRAINS_PAGE");
        }

        private void TrainLines_Checked(object sender, RoutedEventArgs e)
        {
            NavBarClicked?.Invoke("TRAIN_LINES_PAGE");
        }

        private void Reports_Checked(object sender, RoutedEventArgs e)
        {
            NavBarClicked?.Invoke("REPORTS_PAGE");
        }
    }
}
