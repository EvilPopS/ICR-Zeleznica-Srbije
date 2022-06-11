using System.Windows.Controls;
using ZeleznicaSrbije.API.Models;
using ZeleznicaSrbije.API.Services;

namespace ZeleznicaSrbije.ManagerPages {
    public partial class ManagerProfilePage : Page
    {
        ManagerService _managerService;
        
        public ManagerProfilePage(ManagerService managerService)
        {
            _managerService = managerService;
            InitializeComponent();
 
            Manager manager = _managerService.getManager("abc@gmail.com");
            Name.Content = manager.Name + " " + manager.Surname;
            Email.Content = manager.Email;
            Password.Content = manager.Password;
        }
    }
}
