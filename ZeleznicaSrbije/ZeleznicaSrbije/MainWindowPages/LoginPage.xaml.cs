using System;
using System.Windows;
using System.Windows.Controls;
using ZeleznicaSrbije.API.Services;

namespace ZeleznicaSrbije.MainWindowPages {
    public partial class LoginPage : Page {

        private readonly MainWindow _wind;
        private readonly LoginRegisterService _loginService;

        public LoginPage(MainWindow wind, LoginRegisterService loginService) {
            InitializeComponent();
            _wind = wind;
            _loginService = loginService;
            emailInpField.Text = "user1@gmail.com";
            passwordInpField.Password = "sifra123";
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e) {
            string email = emailInpField.Text;
            string password = passwordInpField.Password.ToString();

            InformPopUp popUp = null;
            if (email == "" || password == "")
                popUp = new InformPopUp("Oba polja moraju biti popunjena!", true);
            else if (_loginService.TryLoginAsManager(email, password)) {
                new ManagerWindow(email).Show();
                _wind.Close();
            }
            else if (_loginService.TryLoginAsRegularUser(email, password)) {
                new RegularUserWindow(email).Show();
                _wind.Close();
            }
            else
                popUp = new InformPopUp("Uneti podaci nisu tačni. \n Pokušajte ponovo.", true);
            popUp?.ShowDialog();
        }
    }
}
