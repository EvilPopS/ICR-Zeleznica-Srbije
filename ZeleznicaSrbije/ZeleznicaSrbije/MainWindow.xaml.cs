using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using ZeleznicaSrbije.API.Models;

namespace ZeleznicaSrbije {

    public partial class MainWindow : Window {
        private LoginRegisterMM loginRegisterMM;
        private ManagerMM managerMM;
        private TrainCRUD trainCRUD;
        ObservableCollection<Train> trainList = new ObservableCollection<Train>();


        public MainWindow() {
            InitializeComponent();
            //loginRegisterMM = new LoginRegisterMM();
            //loginRegisterMM.NavBarClicked += LoadNewContentPage;
            //NavBar.Content = loginRegisterMM;
            //LoadNewContentPage("LOGIN");
            trainCRUD = new TrainCRUD();
            trainList = trainCRUD.getAllTrains();
            managerMM = new ManagerMM();
            managerMM.NavBarClicked += LoadNewContentPage;
            NavBar.Content = managerMM;
            LoadNewContentPage("MANAGER_PROFILE_PAGE");
            
        }


        public void LoadNewContentPage(string obj) {
            switch(obj) {
                case "LOGIN":
                    WinContent.Content = new LoginPage();
                    break;
                case "REGISTER":
                    WinContent.Content = new RegisterPage();
                    break;
                case "MANAGER_PROFILE_PAGE":
                    WinContent.Content = new ManagerProfilePage();
                    break;
                case "TRAINS_PAGE":
                    WinContent.Content = new TrainsPage();
                    break;


            }
        }
    }
}
