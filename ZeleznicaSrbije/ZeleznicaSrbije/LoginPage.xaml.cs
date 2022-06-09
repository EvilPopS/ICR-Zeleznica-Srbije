using System;
using System.Windows;
using System.Windows.Controls;
using ZeleznicaSrbije.API.Services;

namespace ZeleznicaSrbije {
    public partial class LoginPage : Page {
        public LoginPage() {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e) {
            string email = emailInpField.Text;
            string password = passwordInpField.Password.ToString();

            if (email == "" || password == "")
                ShowErrorPopUp("Oba polja moraju biti popunjena!");

            LoginRegisterService loginService = new LoginRegisterService();
            if (loginService.TryLoginAsManager(email, password)) {
                Console.WriteLine("Ulogovan kao menadzer");
            }
            else if (loginService.TryLoginAsRegularUser(email, password)) {
                Console.WriteLine("Ulogovan kao korisnik");
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
