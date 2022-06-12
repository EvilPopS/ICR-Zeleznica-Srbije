using System.Windows;
using ZeleznicaSrbije.API.Models;
using ZeleznicaSrbije.API.Services;
using ZeleznicaSrbije.RegularUserPages;

namespace ZeleznicaSrbije {
    public partial class RegularUserWindow : Window {
        private readonly RegularUserMM _userMM;
        private readonly RegularUserService _userService;
        private readonly RegularUser _userData; 

        public RegularUserWindow(string userEmail) {
            _userService = new RegularUserService();
            _userData = _userService.GetUserByEmail(userEmail);
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
            }
        }
    }
}
