using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using ZeleznicaSrbije.API.DTOs;
using ZeleznicaSrbije.API.Services;

namespace ZeleznicaSrbije.RegularUserPages {
    public partial class TimetablePage : Page {
        private readonly TrainLineService _trainLineService;

        ObservableCollection<UserTimeTableShowDTO> DTOsList { get; set; }

        public TimetablePage() {
            InitializeComponent();
            _trainLineService = new TrainLineService();
        }

        private void Search_Click(object sender, RoutedEventArgs e) {
            string startPlaceVal = ((ComboBoxItem)StartPlaceBox.SelectedItem).Content.ToString();
            string endPlaceVal = ((ComboBoxItem)EndPlaceBox.SelectedItem).Content.ToString();

            if (startPlaceVal == "" || endPlaceVal == "" || startPlaceVal == endPlaceVal) { 
            }

            DTOsList = new ObservableCollection<UserTimeTableShowDTO>(
                _trainLineService.GetTrainLinesDTOs(startPlaceVal, endPlaceVal)
            );
            TimeTablesList.ItemsSource = DTOsList;


        }
    }
}
