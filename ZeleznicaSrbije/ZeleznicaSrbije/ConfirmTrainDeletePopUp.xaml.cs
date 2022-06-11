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
        TrainsService trainsService;
        Train trainToBeDeleted;
        string activePage;
        public ConfirmTrainDeletePopUp()
        {
            trainsService = new TrainsService();
            InitializeComponent();
        }

        public ConfirmTrainDeletePopUp(object selectedItem, string page)
        {



            trainsService = new TrainsService();
            InitializeComponent();
            activePage = page;

            switch (activePage)
            {
                case "train":
                    trainToBeDeleted = (Train)selectedItem;
                    trainDeleteTextBlock.Text = "Da li ste sigurni da zelite da obrisete voz " + trainToBeDeleted.TrainNumber + " ?";
                    break;

            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            switch (activePage)
            {
                case "train":
                    if (trainsService.deleteTrain(trainToBeDeleted.TrainNumber))
                    {
                        // ide pop up successfull
                        this.Hide();
                    }
                    else
                    {
                        // neki error popup
                    }
                    break;

            }



        }
    }
}
