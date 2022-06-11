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
            Train newTrain = new Train{ TrainNumber = newTrainNumber.Text, Capacity = Int32.Parse(newTrainNoCols.Text) * Int32.Parse(newTrainNoRows.Text), IsDeleted = false };
            addTrainClicked?.Invoke(newTrain);
            this.Close();
        }
    }
}
