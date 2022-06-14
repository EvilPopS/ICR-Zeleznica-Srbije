using System;
using System.Windows;
using System.Windows.Controls;

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
