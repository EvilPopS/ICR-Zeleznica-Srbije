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
            emailInpField.Text = "abc@gmail.com";
            passwordInpField.Password = "sifra123";
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e) {
            string email = emailInpField.Text;
            string password = passwordInpField.Password.ToString();

            if (email == "" || password == "")
                ShowErrorPopUp("Oba polja moraju biti popunjena!");

            if (_loginService.TryLoginAsManager(email, password)) {
                new ManagerWindow().Show();
                _wind.Close();
            }
            else if (_loginService.TryLoginAsRegularUser(email, password)) {
                new RegularUserWindow().Show();
                _wind.Close();
            }
            else
                ShowErrorPopUp("Uneti podaci nisu tačni. \n Pokušajte ponovo.");
        }
        
        private void ShowErrorPopUp(string message) {
            errorPopUpText.Text = message;
            errorPopUp.IsOpen = true;
        }

        private void CloseErrorPopUp(object sender, RoutedEventArgs e) {
            errorPopUpText.Text = "";
            errorPopUp.IsOpen = false;
        }
    }
}
