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

            if (name == "" || surname == "" || email == "" || password == "")
                ShowPopUp("Sva polja forme za registraciju moraju da budu popunjena.", true);
            else if (_registerService.RegisterNewUser(name, surname, email, password)) {
                nameInpField.Text = "";
                surnameInpField.Text = "";
                emailInpField.Text = "";
                passwordInpField.Password = "";
                ShowPopUp("Registracija je bila uspešna!\nSada možete da pređete na prozor za prijavu na sistem.", false);
            }
            else
                ShowPopUp("Email je već zauzet.\nPokušajte nešto drugo.", true);
        }

        private void ShowPopUp(string message, bool isError) {
            SetPopUpIcon(isError);
            PopUpText.Text = message;
            PopUp.IsOpen = true;
        }

        private void SetPopUpIcon(bool isError) {
            if (isError) 
                PopUpIcon.Source = new BitmapImage(new Uri(@"..\Assets\Images\warning-sign-icon.png", UriKind.Relative));
            else
                PopUpIcon.Source = new BitmapImage(new Uri(@"..\Assets\Images\task-success-icon.png", UriKind.Relative));
        }

        private void ClosePopUp(object sender, RoutedEventArgs e) {
            PopUpText.Text = "";
            PopUp.IsOpen = false;
        }
    }
}
