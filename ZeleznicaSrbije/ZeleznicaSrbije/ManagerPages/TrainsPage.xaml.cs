using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using ZeleznicaSrbije.API.Models;
using ZeleznicaSrbije.API.Services;
using ZeleznicaSrbije.MainWindowPages;

namespace ZeleznicaSrbije.ManagerPages {
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

            InformPopUp popUp = new InformPopUp("Uspešno ste dodali novi voz u sistem!", false);
            popUp.ShowDialog();
        }

        private void TrainsData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TrainsData.ItemsSource = TrainsCollection;
        }

        public void EditTrainButton_Click(object sender, RoutedEventArgs e)
        {
            Train selTrain = ((Train)TrainsData.SelectedItem);
            EditTrainWindow editTrainWindow = new EditTrainWindow(selTrain);
            editTrainWindow.saveButtonClicked += editTrain;
            editTrainWindow.ShowDialog();
        }

        private void updateTrainsCollection(Train succEditedTrain)
        {
            for (int i = 0; i < TrainsCollection.Count; i++)
            {
                if(succEditedTrain.Id == TrainsCollection[i].Id) {
                    TrainsCollection[i] = succEditedTrain;
                    break;
                }
            }   
        }

        public void editTrain(Train editedTrain)
        {
            Train successfullyEditedtrain = _trainsService.updateTrain(editedTrain);
            updateTrainsCollection(successfullyEditedtrain);
            
            OkPopUp okPopUp = new OkPopUp("Uspešno ste imzenili voz.");
            okPopUp.ShowDialog();

        }
    }
}
