using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using ZeleznicaSrbije.API.DTOs;
using ZeleznicaSrbije.API.Models;
using ZeleznicaSrbije.API.Services;

namespace ZeleznicaSrbije.RegularUserPages {
    public partial class TimetablePage : Page {
        private readonly TrainLineService _trainLineService;
        private string _selectedStartPlace;
        private string _selectedEndPlace;
        private RegularUser _userData;

        ObservableCollection<UserTimeTableShowDTO> DTOsList { get; set; }

        public TimetablePage(RegularUser userData) {
            _userData = userData;
            InitializeComponent();
            _trainLineService = new TrainLineService();
        }

        private void Search_Click(object sender, RoutedEventArgs e) {
            _selectedStartPlace = ((ComboBoxItem)StartPlaceBox.SelectedItem).Content.ToString();
            _selectedEndPlace = ((ComboBoxItem)EndPlaceBox.SelectedItem).Content.ToString();

            if (_selectedStartPlace == "" || _selectedEndPlace == "" || _selectedStartPlace == _selectedEndPlace) { 
            }

            DTOsList = new ObservableCollection<UserTimeTableShowDTO>(
                _trainLineService.GetTrainLinesDTOs(_selectedStartPlace, _selectedEndPlace)
            );
            TimeTablesList.ItemsSource = DTOsList;
        }

        private void Buy_Click(object sender, RoutedEventArgs e) {
            UserTimeTableShowDTO selectedRow = ((UserTimeTableShowDTO)TimeTablesList.SelectedItem);
            if (selectedRow == null)
                return;

            BuyReserveTicketWindow popUpWind = new BuyReserveTicketWindow(_userData, selectedRow, true, _selectedStartPlace, _selectedEndPlace);
            popUpWind.ShowDialog();
        }

        private void Reserve_Click(object sender, RoutedEventArgs e) {
            UserTimeTableShowDTO selectedRow = ((UserTimeTableShowDTO)TimeTablesList.SelectedItem);
            if (selectedRow == null)
                return;

            BuyReserveTicketWindow popUpWind = new BuyReserveTicketWindow(_userData, selectedRow, false, _selectedStartPlace, _selectedEndPlace);
            popUpWind.ShowDialog();
        }
    }
}
