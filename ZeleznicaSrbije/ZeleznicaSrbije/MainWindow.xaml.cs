using System.Windows;
using System.Windows.Input;
using ZeleznicaSrbije.API.Services;
using ZeleznicaSrbije.Help;
using ZeleznicaSrbije.MainWindowPages;

namespace ZeleznicaSrbije {

    public partial class MainWindow : Window {
        private readonly LoginRegisterMM _loginRegisterMM;
        private readonly LoginRegisterService _loginRegisterService;

        
        public MainWindow() {
            _loginRegisterService = new LoginRegisterService();
            InitializeComponent();
            
            _loginRegisterMM = new LoginRegisterMM();
            _loginRegisterMM.NavBarClicked += LoadNewContentPage;
            NavBar.Content = _loginRegisterMM;
            LoadNewContentPage("LOGIN");
        }


        public void LoadNewContentPage(string pageName) {
            switch(pageName) {
                case "LOGIN":
                    WinContent.Content = new LoginPage(this, _loginRegisterService);
                    break;
                case "REGISTER":
                    WinContent.Content = new RegisterPage(_loginRegisterService);
                    break;
            }
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e) {
            IInputElement focusedControl = FocusManager.GetFocusedElement(Application.Current.Windows[0]);
            if (focusedControl is DependencyObject) {
                string str = HelpProvider.GetHelpKey((DependencyObject)focusedControl);
                HelpProvider.ShowHelp("LoginRegisterHelp", this);
            }
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = true;
        }
    }
}
