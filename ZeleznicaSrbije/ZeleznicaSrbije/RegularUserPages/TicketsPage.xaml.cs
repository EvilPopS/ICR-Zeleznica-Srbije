using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using ZeleznicaSrbije.API.DTOs;
using ZeleznicaSrbije.API.Services;

namespace ZeleznicaSrbije.RegularUserPages {
    public partial class TicketsPage : Page {
        private readonly TicketsService _ticketsService;
        ObservableCollection<ShowTicketDTO> TicketDTOsList{ get; set; }
        private List<ShowTicketDTO> _boughtTickets;
        private List<ShowTicketDTO> _reservedTickets;


        public TicketsPage(int userId) {
            _boughtTickets = new List<ShowTicketDTO>();
            _reservedTickets = new List<ShowTicketDTO>();

            InitializeComponent();
            _ticketsService = new TicketsService();

            SetDisplayList(userId);
        }

        private void BoughtTickets_Checked(object sender, System.Windows.RoutedEventArgs e) {
            if (TicketDTOsList != null)
                SwitchDisplayList(true, _boughtTickets);
        }

        private void ReservedTickets_Checked(object sender, System.Windows.RoutedEventArgs e) {
            SwitchDisplayList(false, _reservedTickets);
        }

        private void SwitchDisplayList(bool isBoughtTicksList, List<ShowTicketDTO> toIterate) {
            TicketDTOsList.Clear();

            foreach (ShowTicketDTO dto in toIterate)
                TicketDTOsList.Add(dto);
        }

        private void SetDisplayList(int userId) {
            foreach (ShowTicketDTO tckDTO in _ticketsService.GetTicketsDTOByUserId(userId))
                if (tckDTO.IsBought)
                    _boughtTickets.Add(tckDTO);
                else
                    _reservedTickets.Add(tckDTO);

            TicketDTOsList = new ObservableCollection<ShowTicketDTO>(_boughtTickets);
            TicketsList.ItemsSource = TicketDTOsList;
        }
    }
}
