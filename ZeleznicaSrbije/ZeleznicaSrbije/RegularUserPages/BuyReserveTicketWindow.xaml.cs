using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ZeleznicaSrbije.API.DTOs;
using ZeleznicaSrbije.API.Models;
using ZeleznicaSrbije.API.Services;
using ZeleznicaSrbije.MainWindowPages;

namespace ZeleznicaSrbije.RegularUserPages {
    public partial class BuyReserveTicketWindow : Window {
        private const string BUY_CAP = "Izaberite datum važenja karte za sledeću vožnju i potvrdite kupovinu.";
        private const string RESERVE_CAP = "Izaberite datum važenja karte za sledeću vožnju i potvrdite rezervaciju.";
        private const string BUY_BTN_TXT = "POTVRDITE KUPOVINU";
        private const string RESERVE_BTN_TXT = "POTVRDITE REZERVACIJU";
        private readonly UserTimeTableShowDTO _dto;
        private readonly bool _isBuying;
        private readonly string _startPlace;
        private readonly string _endPlace;
        private readonly RegularUser _userData;


        public BuyReserveTicketWindow(RegularUser userData, UserTimeTableShowDTO dto, bool isBuying, string startPlace, string endPlace) {
            InitializeComponent();
            _dto = dto;
            _isBuying = isBuying;
            _startPlace = startPlace;
            _endPlace = endPlace;
            _userData = userData;
            SetComponents(isBuying);
            startPlaceInp.Text = startPlace;
            endPlaceInp.Text = endPlace;
            startTimeInp.Text = dto.StartTime.ToString();
            endTimeInp.Text = dto.StartTime.ToString();
        }


        public void SetComponents(bool isBuying) {
            if (isBuying) {
                caption.Content = BUY_CAP;
                SubmitButton.Content = BUY_BTN_TXT;
                SubmitButton.Background = (Brush)new BrushConverter().ConvertFrom("#A91BD8");
            }
            else {
                caption.Content = RESERVE_CAP;
                SubmitButton.Content = RESERVE_BTN_TXT;
                SubmitButton.Background = (Brush)new BrushConverter().ConvertFrom("#059C71");
            }

        }

        public void Submit_Click(object sender, EventArgs e) {
            DateTime valDate = DateTime.ParseExact(validityDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            if (!ValidateDate(valDate))
                return;

            TicketsService ticketsService = new TicketsService();
            ticketsService.MakeNewTicket(_userData.Id, _startPlace, _endPlace, _dto, valDate, _isBuying);
            InformPopUp popUp = new InformPopUp(
                (_isBuying ? "Kupovina" : "Rezervacija") + "je uspešno izvršena! Kartu možete da nađete na stranici za pregled kupljenih i rezervisanih karata.",
                false
            );
            Close();
            popUp.ShowDialog();
        }

        private bool ValidateDate(DateTime valDate) {
            InformPopUp popUp = null;
            if (valDate < DateTime.Now.Date)
                popUp = new InformPopUp("Izaberite datum koji nije iz prošlosti.", true);
            popUp?.ShowDialog();
            return popUp == null;
        }   

    }
}
