using System.Windows;
using System.Windows.Controls;
using ZeleznicaSrbije.API.Models;

namespace ZeleznicaSrbije.RegularUserPages {
    public partial class UserProfilePage : Page {
        private readonly RegularUser _userData;
        private readonly RegularUserWindow _parentWin;

        public UserProfilePage(RegularUser userData, RegularUserWindow parentWin) {
            _userData = userData;
            _parentWin = parentWin;

            InitializeComponent();
            SetUpProfilePageData();
        }

        private void SetUpProfilePageData() {
            NameInpField.Text = _userData.Name;
            SurnameInpField.Text = _userData.Surname;
            EmailInpField.Text = _userData.Email;
        }

        private void LogoutBtn_Click(object sender, RoutedEventArgs e) {
            MainWindow mainWin = new MainWindow();
            mainWin.Show();
            _parentWin.Close();
        }
    }
}
