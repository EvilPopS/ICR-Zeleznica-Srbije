using System.Windows.Controls;
using ZeleznicaSrbije.API.Services;

namespace ZeleznicaSrbije.RegularUserPages {
    public partial class UserProfilePage : Page {
        private readonly RegularUserService _userService;

        public UserProfilePage(RegularUserService userService) {
            InitializeComponent();
            _userService = userService;
        }
    }
}
