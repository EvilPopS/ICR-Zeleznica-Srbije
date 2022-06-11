using System.Windows;
using ZeleznicaSrbije.API.Services;
using ZeleznicaSrbije.ManagerPages;

namespace ZeleznicaSrbije {
    public partial class ManagerWindow : Window {
        private readonly ManagerMM _managerMM;
        private readonly ManagerService _managerService;
        private readonly TrainsService _trainService;

        public ManagerWindow() {
            _managerService = new ManagerService();
            _trainService = new TrainsService(); 
            InitializeComponent();

            _managerMM = new ManagerMM();
            _managerMM.NavBarClicked += LoadNewContentPage;
            NavBar.Content = _managerMM;
            LoadNewContentPage("MANAGER_PROFILE_PAGE");
        }

        public void LoadNewContentPage(string obj) {
            switch (obj) {
                case "PROFILE_PAGE":
                    WinContent.Content = new ManagerProfilePage(_managerService);
                    break;
                case "TRAINS_PAGE":
                    WinContent.Content = new TrainsPage(_trainService);
                    break;
            }
        }
    }
}
