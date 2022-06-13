using System;
using ZeleznicaSrbije.API.Models;

namespace ZeleznicaSrbije.API.DTOs {
    public class ShowTicketDTO {
        public string SeatNumber { get; set; }
        public string ValidityDate { get; set; }
        public string TrainNumber { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string StartPlace { get; set; }
        public string EndPlace { get; set; }
        public bool IsBought { get; set; }


        public ShowTicketDTO(Ticket ticket, Timetable timetable, Train train) {
            SeatNumber = ticket.SeatNumber;
            ValidityDate = ticket.ValidityDate.Date.ToString().Split(' ')[0];
            TrainNumber = train.TrainNumber;
            StartTime = timetable.Start;
            EndTime = timetable.End;
            StartPlace = "Novi Sad";
            EndPlace = "Beograd";
            IsBought = ticket.IsBought;
        }
    }
}
