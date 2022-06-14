using System.Windows;
using System.Windows.Input;
using ZeleznicaSrbije.API.Models;
using ZeleznicaSrbije.API.Services;
using ZeleznicaSrbije.Help;
using ZeleznicaSrbije.RegularUserPages;

namespace ZeleznicaSrbije {
    public partial class RegularUserWindow : Window {
        private readonly RegularUserMM _userMM;
        private readonly RegularUser _userData; 

        public RegularUserWindow(string userEmail) {
            _userData = new RegularUserService().GetUserByEmail(userEmail);
            InitializeComponent();

            _userMM = new RegularUserMM();
            _userMM.NavBarClicked += LoadNewContentPage;

            NavBar.Content = _userMM;
            LoadNewContentPage("PROFILE");
        }
        
        public void LoadNewContentPage(string pageName) {
            
            switch (pageName) {
                case "PROFILE":
                    WinContent.Content = new UserProfilePage(_userData, this);
                    break;
                case "TICKETS":
                    WinContent.Content = new TicketsPage(_userData.Id);
                    break;
                case "TRAIN_SCHEDULE":
                    WinContent.Content = new TimetablePage(_userData);
                    break;
            }
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e) {
            IInputElement focusedControl = FocusManager.GetFocusedElement(Application.Current.Windows[0]);
            if (focusedControl is DependencyObject) {
                string str = HelpProvider.GetHelpKey((DependencyObject)focusedControl);
                HelpProvider.ShowHelp("UserHelp", this);
            }
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = true;
        }
    }
}
