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
using ZeleznicaSrbije.MainWindowPages;

namespace ZeleznicaSrbije.ManagerPages
{
    /// <summary>
    /// Interaction logic for AddTrainWindow.xaml
    /// </summary>
    public partial class AddTrainWindow : Window
    {

        public Action<Train> addTrainClicked;
        public AddTrainWindow()
        {
            InitializeComponent();
        }

        private void addNewTrain_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckForm())
                return;

            Train newTrain = new Train { TrainNumber = newTrainNumber.Text,
                Capacity = Int32.Parse(newTrainNoCols.Text) * Int32.Parse(newTrainNoRows.Text),
                IsDeleted = false,
                NoCols = Int32.Parse(newTrainNoCols.Text),
                NoRows = Int32.Parse(newTrainNoRows.Text),
            };
            addTrainClicked?.Invoke(newTrain);
            this.Close();
        }

        private bool CheckForm() {
            InformPopUp popUp = null;
            if (newTrainNoCols.Text == "" || newTrainNoRows.Text == "" || newTrainNumber.Text == "")
                popUp = new InformPopUp("", true);
            popUp?.ShowDialog();
            return popUp != null;
        }
    }
}
