using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using ZeleznicaSrbije.API.DTOs;
using ZeleznicaSrbije.API.Models;
using ZeleznicaSrbije.API.Services;
using ZeleznicaSrbije.MainWindowPages;

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

            InformPopUp popUp = null;
            if (_selectedStartPlace == "Nije izabrano" || _selectedEndPlace == "Nije izabrano")
                popUp = new InformPopUp("Molimo vas izaberite i početnu i krajnju destinaciju putovanja.", true);
            else if (_selectedStartPlace == _selectedEndPlace)
                popUp = new InformPopUp("Izabrane destinacije moraju biti različite.", true);

            popUp?.ShowDialog();

            DTOsList = new ObservableCollection<UserTimeTableShowDTO>(
                _trainLineService.GetTrainLinesDTOs(_selectedStartPlace, _selectedEndPlace)
            );
            TimeTablesList.ItemsSource = DTOsList;
        }

        private void Buy_Click(object sender, RoutedEventArgs e) {
            UserTimeTableShowDTO selectedRow = ((UserTimeTableShowDTO)TimeTablesList.SelectedItem);
            if (!CheckIfBuyReserveClickable(selectedRow))
                return;

            BuyReserveTicketWindow popUpWind = new BuyReserveTicketWindow(_userData, selectedRow, true, _selectedStartPlace, _selectedEndPlace);
            popUpWind.ShowDialog();
        }

        private void Reserve_Click(object sender, RoutedEventArgs e) {
            UserTimeTableShowDTO selectedRow = ((UserTimeTableShowDTO)TimeTablesList.SelectedItem);
            if (!CheckIfBuyReserveClickable(selectedRow))
                return;

            BuyReserveTicketWindow popUpWind = new BuyReserveTicketWindow(_userData, selectedRow, false, _selectedStartPlace, _selectedEndPlace);
            popUpWind.ShowDialog();
        }

        private bool CheckIfBuyReserveClickable(UserTimeTableShowDTO selectedRow) {
            InformPopUp popUp = null;
            if (selectedRow == null)
                popUp = new InformPopUp("Izaberite jednu voznju iz prikaza pa onda pritisnite dugme za kupovinu/rezervaciju karte za tu voznju.", true);
            popUp?.ShowDialog();
            return popUp == null;
        }

    }
}
