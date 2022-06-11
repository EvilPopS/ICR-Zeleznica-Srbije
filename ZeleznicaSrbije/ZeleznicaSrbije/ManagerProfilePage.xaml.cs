using System;
using System.Collections.Generic;
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
using ZeleznicaSrbije.API.Models;
using ZeleznicaSrbije.API.Services;

namespace ZeleznicaSrbije
{
    /// <summary>
    /// Interaction logic for ManagerProfilePage.xaml
    /// </summary>
    public partial class ManagerProfilePage : Page
    {
        ManagerService managerService;
        
        public ManagerProfilePage()
        {

            managerService = new ManagerService();
            InitializeComponent();
            Manager manager = managerService.getManager("abc@gmail.com");
            Name.Content = manager.Name + " " + manager.Surname;
            Email.Content = manager.Email;
            Password.Content = manager.Password;
        }
    }
}
