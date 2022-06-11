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

namespace ZeleznicaSrbije.RegularUserPages {
    public partial class RegularUserMM : Page {
        public event Action<string> NavBarClicked;
        
        public RegularUserMM() {
            InitializeComponent();
        }

        private void Profile_Checked(object sender, RoutedEventArgs e) {
            InvokeCheckedEvent("PROFILE");
        }

        private void TrainSchedule_Checked(object sender, RoutedEventArgs e) {
            InvokeCheckedEvent("TRAIN_SCHEDULE");
        }

        private void TrainLines_Checked(object sender, RoutedEventArgs e) {
            InvokeCheckedEvent("TRAIN_LINES");
        }

        private void Tickets_Checked(object sender, RoutedEventArgs e) {
            InvokeCheckedEvent("TICKETS");
        }

        private void InvokeCheckedEvent(string pageName) {
            NavBarClicked?.Invoke(pageName);
        }
    }
}
