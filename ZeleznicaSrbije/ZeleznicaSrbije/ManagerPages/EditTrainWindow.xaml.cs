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
    /// Interaction logic for EditTrainWindow.xaml
    /// </summary>
    public partial class EditTrainWindow : Window
    {

        public event Action<Train> saveButtonClicked;
        Train selTrain;
        public EditTrainWindow(Train selectedTrain)
        {

            InitializeComponent();
            editTrainTitle.Text = "Izmena voza " + selectedTrain.TrainNumber;
            this.DataContext = selectedTrain;
            selTrain = selectedTrain;
        }

        private void saveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            Train editedTrain = new Train{
                Id = this.selTrain.Id,
                TrainNumber = editedTrainNumber.Text,
                NoRows = Int32.Parse(editedTrainNoRows.Text),
                NoCols = Int32.Parse(editedTrainNoCols.Text),
                Capacity = Int32.Parse(editedTrainNoRows.Text) * Int32.Parse(editedTrainNoCols.Text),
                IsDeleted = false
            };
            saveButtonClicked?.Invoke(editedTrain);
            this.Close();
        }
    }
}
