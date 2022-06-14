using System.Windows;
using System.Windows.Input;
using ZeleznicaSrbije.API.Models;
using ZeleznicaSrbije.API.Services;
using ZeleznicaSrbije.Help;
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
                case "TRAIN_SCHEDULE_PAGE":
                    WinContent.Content = new TimetablePage();
                    break;
                case "TRAIN_LINES_PAGE":
                    WinContent.Content = new TrainLinesPage();
                    break;
            }
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e) {
            IInputElement focusedControl = FocusManager.GetFocusedElement(Application.Current.Windows[0]);
            if (focusedControl is DependencyObject) {
                string str = HelpProvider.GetHelpKey((DependencyObject)focusedControl);
                HelpProvider.ShowHelp("ManagerHelp", this);
            }
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = true;
        }
    }
}
