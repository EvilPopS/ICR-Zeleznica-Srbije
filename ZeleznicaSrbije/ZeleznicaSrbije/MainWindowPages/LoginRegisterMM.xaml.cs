using System;
using System.Windows;
using System.Windows.Controls;

namespace ZeleznicaSrbije {

    public partial class LoginRegisterMM : Page {
        public event Action<string> NavBarClicked;

        public LoginRegisterMM() {
            InitializeComponent();
        }

        private void LoginRB_Checked(object sender, RoutedEventArgs e) {
            NavBarClicked?.Invoke("LOGIN");
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e) {
            NavBarClicked?.Invoke("REGISTER");
        }
    }
}
