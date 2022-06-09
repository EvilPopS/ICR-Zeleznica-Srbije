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
using ZeleznicaSrbije.API.CRUD;

namespace ZeleznicaSrbije {

    public partial class MainWindow : Window {
        private LoginRegisterMM loginRegisterMM;


        public MainWindow() {
            InitializeComponent();
            loginRegisterMM = new LoginRegisterMM();
            loginRegisterMM.NavBarClicked += LoadNewContentPage;
            NavBar.Content = loginRegisterMM;
            LoadNewContentPage("LOGIN");
        }


        public void LoadNewContentPage(string obj) {
            switch(obj) {
                case "LOGIN":
                    WinContent.Content = new LoginPage();
                    break;
                case "REGISTER":
                    WinContent.Content = new RegisterPage();
                    break;
            }
        }
    }
}
