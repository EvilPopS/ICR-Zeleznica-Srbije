using System.Windows;
using System.Windows.Controls;
using ZeleznicaSrbije.API.Models;

namespace ZeleznicaSrbije.ManagerPages {
    public partial class ManagerProfilePage : Page {
        private readonly Manager _managerData;
        private readonly ManagerWindow _parentWin;

        public ManagerProfilePage(Manager managerData, ManagerWindow parentWin) {
            _managerData = managerData;
            _parentWin = parentWin;

            InitializeComponent();
            SetUpProfilePageData();
        }

        private void SetUpProfilePageData() {
            NameInpField.Text = _managerData.Name;
            SurnameInpField.Text = _managerData.Surname;
            EmailInpField.Text = _managerData.Email;
        }

        private void LogoutBtn_Click(object sender, RoutedEventArgs e) {
            MainWindow mainWin = new MainWindow();
            mainWin.Show();
            _parentWin.Close();

        }
    }
}
