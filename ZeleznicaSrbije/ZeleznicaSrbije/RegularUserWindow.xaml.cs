using System.Windows;
using ZeleznicaSrbije.API.Services;
using ZeleznicaSrbije.RegularUserPages;

namespace ZeleznicaSrbije {
    public partial class RegularUserWindow : Window {
        private readonly RegularUserMM _userMM;
        private readonly RegularUserService _userService;

        public RegularUserWindow() {
            _userService = new RegularUserService();
            InitializeComponent();

            _userMM = new RegularUserMM();
            NavBar.Content = _userMM;

        }
        
        public void LoadNewContentPage(string pageName) {
            switch (pageName) {
                case "PROFILE":
                    WinContent.Content = new UserProfilePage(_userService);
                    break;
            }
        }
    }
}
