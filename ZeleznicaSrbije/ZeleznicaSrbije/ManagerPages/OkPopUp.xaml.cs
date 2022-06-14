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
using System.Windows.Shapes;

namespace ZeleznicaSrbije.ManagerPages
{
    /// <summary>
    /// Interaction logic for OkPopUp.xaml
    /// </summary>
    public partial class OkPopUp : Window
    {
        

        public OkPopUp(string infoMessage)
        {
            InitializeComponent();
            informativeMessage.Text = infoMessage;
        }

        private void Ok_Clicked(object sender, RoutedEventArgs e)
        {
            
            this.Close();
        }
    }
}
