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
