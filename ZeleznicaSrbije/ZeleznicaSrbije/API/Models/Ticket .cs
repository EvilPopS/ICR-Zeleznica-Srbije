using System;

namespace ZeleznicaSrbije.API.Models {
    public class Ticket {
		private int id;
		private int userId;
        private string trainNum;
        private DateTime validityDate;
        private string startPlace;
        private string endPlace;
        private TimeSpan startTime;
        private TimeSpan endTime;
        private double price;
		private bool isReserved;
		private bool isBought;
		private bool isActive;
        private string seatNumber;


        public int Id { get => id; set => id = value; }
        public int UserId { get => userId; set => userId = value; }
        public DateTime ValidityDate { get => validityDate; set => validityDate = value; }
        public double Price { get => price; set => price = value; }
        public bool IsReserved { get => isReserved; set => isReserved = value; }
        public bool IsBought { get => isBought; set => isBought = value; }
        public bool IsActive { get => isActive; set => isActive = value; }
        public string SeatNumber { get => seatNumber; set => seatNumber = value; }
        public string StartPlace { get => startPlace; set => startPlace = value; }
        public string EndPlace { get => endPlace; set => endPlace = value; }
        public TimeSpan StartTime { get => startTime; set => startTime = value; }
        public TimeSpan EndTime { get => endTime; set => endTime = value; }
        public string TrainNum { get => trainNum; set => trainNum = value; }
    }
}
