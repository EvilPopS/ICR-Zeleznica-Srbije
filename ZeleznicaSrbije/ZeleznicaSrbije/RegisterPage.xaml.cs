using System;
using System.Windows;
using ZeleznicaSrbije.API.Services;

namespace ZeleznicaSrbije {
    public partial class RegisterPage : ContentPage {
        public RegisterPage() {
            InitializeComponent();
        }

        private void RegisterBtn_Click(object sender, RoutedEventArgs e) {
            string name = nameInpField.Text;
            string surname = surnameInpField.Text;
            string email = emailInpField.Text;
            string password = passwordInpField.Password.ToString();

            if (name == "" || surname == "" || email == "" || password == "")
                ShowErrorPopUp("Sva polja forme za registraciju moraju da budu popunjena.");

            if (new LoginRegisterService().RegisterNewUser(name, surname, email, password))
                Console.WriteLine("Prebaci se na login page");
            else
                ShowErrorPopUp("Email je već zauzet.\nPokušajte nešto drugo.");
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
