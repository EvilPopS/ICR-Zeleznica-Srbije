namespace ZeleznicaSrbije.API.Models {
    public class Seat
    {
        private int seatNumber;
        private bool available;
        private int userId;

        public int SeatNumber { get => seatNumber; set => seatNumber = value; }
        public bool IsAvailable { get => available; set => available = value; }

        public int UserId { get => userId; set => userId = value; }
    }
}
