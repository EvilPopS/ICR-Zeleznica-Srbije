using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using ZeleznicaSrbije.API.Services;

namespace ZeleznicaSrbije.MainWindowPages {
    public partial class RegisterPage : Page {
        private readonly LoginRegisterService _registerService;

        public RegisterPage(LoginRegisterService registerService) {
            InitializeComponent();
            _registerService = registerService;
        }

        private void RegisterBtn_Click(object sender, RoutedEventArgs e) {
            string name = nameInpField.Text;
            string surname = surnameInpField.Text;
            string email = emailInpField.Text;
            string password = passwordInpField.Password.ToString();

            InformPopUp popUp;
            if (name == "" || surname == "" || email == "" || password == "") {
                popUp = new InformPopUp("Sva polja forme za registraciju moraju da budu popunjena.", true);
            }
            else if (_registerService.RegisterNewUser(name, surname, email, password)) {
                nameInpField.Text = "";
                surnameInpField.Text = "";
                emailInpField.Text = "";
                passwordInpField.Password = "";
                popUp = new InformPopUp("Registracija je bila uspešna!\nSada možete da pređete na prozor za prijavu na sistem.", false);
            }
            else {
                popUp = new InformPopUp("Email je već zauzet.\nPokušajte nešto drugo.", true);
            }
            popUp?.ShowDialog();
        }


    }
}
