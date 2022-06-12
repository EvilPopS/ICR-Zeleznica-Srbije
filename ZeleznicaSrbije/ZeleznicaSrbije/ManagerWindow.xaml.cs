using System.Windows;
using ZeleznicaSrbije.API.Models;
using ZeleznicaSrbije.API.Services;
using ZeleznicaSrbije.ManagerPages;

namespace ZeleznicaSrbije {
    public partial class ManagerWindow : Window {
        private readonly ManagerMM _managerMM;
        private readonly ManagerService _managerService;
        private readonly TrainsService _trainService;
        private readonly Manager _manager;

        public ManagerWindow(string email) {
            _managerService = new ManagerService();
            _trainService = new TrainsService();
            _manager = _managerService.getManager(email);
            
            InitializeComponent();

            _managerMM = new ManagerMM();
            _managerMM.NavBarClicked += LoadNewContentPage;
            NavBar.Content = _managerMM;
            LoadNewContentPage("PROFILE_PAGE");
        }

        public void LoadNewContentPage(string obj) {
            switch (obj) {
                case "PROFILE_PAGE":
                    WinContent.Content = new ManagerProfilePage(_manager, this);
                    break;
                case "TRAINS_PAGE":
                    WinContent.Content = new TrainsPage(_trainService);
                    break;
            }
        }
    }
}
