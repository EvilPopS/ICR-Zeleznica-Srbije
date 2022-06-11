using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace ZeleznicaSrbije.ManagerPages
{
    public partial class TrainsPage : Page
    {
        TrainsService _trainsService;

        ObservableCollection<Train> TrainsCollection { get; set; }

        public TrainsPage(TrainsService trainsService) {
            _trainsService = trainsService;
            InitializeComponent();

            TrainsCollection = new ObservableCollection<Train>(_trainsService.GetAllTrains());
            TrainsData.ItemsSource = TrainsCollection;
        }


        public void DeleteTrainBtn_Click(object sender, RoutedEventArgs e)
        {
            ConfirmTrainDeletePopUp deletePopUp = new ConfirmTrainDeletePopUp("Da li sigurno da želite da obrišete voz " + ((Train)TrainsData.SelectedItem).TrainNumber + "?");
            deletePopUp.YesClicked += PopUpClicked;
            deletePopUp.ShowDialog();
        }

        public void PopUpClicked(bool yes)
        {
            if (yes)
            {
                Train selTrain = ((Train)TrainsData.SelectedItem);
                _trainsService.DeleteTrain(selTrain.TrainNumber);
                TrainsCollection.Remove(selTrain);

                // sad ok pop up
                OkPopUp okPopUp = new OkPopUp("Uspešno ste obrisali voz " +
                    selTrain.TrainNumber + ".");
                okPopUp.ShowDialog();

            }
        }

        private void addNewtrainButton_Click(object sender, RoutedEventArgs e)
        {
            AddTrainWindow addTrainWindow = new AddTrainWindow();
            addTrainWindow.addTrainClicked += addNewTrain;
            addTrainWindow.ShowDialog();
        }

        public void addNewTrain(Train newTrain)
        {
            _trainsService.AddTrain(newTrain);
            TrainsCollection.Add(newTrain);

            OkPopUp okPopUp = new OkPopUp("Uspešno ste dodali novi voz.");
            okPopUp.ShowDialog();





        }

        private void TrainsData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine("sadsada");
        }
    }
}
