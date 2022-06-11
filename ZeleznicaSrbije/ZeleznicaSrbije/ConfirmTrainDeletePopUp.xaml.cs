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
using ZeleznicaSrbije.API.Models;
using ZeleznicaSrbije.API.Services;

namespace ZeleznicaSrbije
{
    /// <summary>
    /// Interaction logic for ConfirmTrainDeletePopUp.xaml
    /// </summary>
    public partial class ConfirmTrainDeletePopUp : Window
    {
        public event Action<bool> yesClicked;

        public ConfirmTrainDeletePopUp(string popUpMessage)
        {
            InitializeComponent();
            trainDeleteTextBlock.Text = popUpMessage;
        }

        private void Yes_Clicked(object sender, RoutedEventArgs e)
        {
            yesClicked?.Invoke(true);
            this.Close();
        }

        private void No_Clicked(object sender, RoutedEventArgs e)
        {

            this.Close();
        }




    }
}
