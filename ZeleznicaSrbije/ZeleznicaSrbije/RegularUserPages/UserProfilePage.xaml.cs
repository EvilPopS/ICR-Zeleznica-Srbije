using System.Windows.Controls;
using ZeleznicaSrbije.API.Models;

namespace ZeleznicaSrbije.RegularUserPages {
    public partial class UserProfilePage : Page {
        private readonly RegularUser _userData;
        private readonly RegularUserWindow _parenWin;

        public UserProfilePage(RegularUser userData, RegularUserWindow parenWin) {
            _userData = userData;
            _parenWin = parenWin;

            InitializeComponent();
            SetUpProfilePageData();
        }

        private void SetUpProfilePageData() {
            NameInpField.Text = _userData.Name;
            SurnameInpField.Text = _userData.Surname;
            EmailInpField.Text = _userData.Email;
        }

        private void LogoutBtn_Click(object sender, System.Windows.RoutedEventArgs e) {
            MainWindow mainWin = new MainWindow();
            mainWin.Show();
            _parenWin.Close();

        }
    }
}
