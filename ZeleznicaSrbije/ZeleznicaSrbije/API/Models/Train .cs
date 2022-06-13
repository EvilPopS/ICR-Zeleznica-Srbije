using System.Collections.Generic;

namespace ZeleznicaSrbije.API.Models {
    public class Train {
        private int id;
        private string trainNumber;
        private int capacity;
        private int noCols;
        private int noRows;
        private bool isDeleted;
        private List<Seat> seats;


        public Train() {
            Seats = new List<Seat>();
        }

        public int Id { get => id; set => id = value; }
        public string TrainNumber { get => trainNumber; set => trainNumber = value; }
        public int Capacity { get => capacity; set => capacity = value; }
        public int NoCols { get => noCols; set => noCols = value; }
        public int NoRows { get => noRows; set => noRows = value; }
        public bool IsDeleted { get => isDeleted; set => isDeleted = value; }
        public List<Seat> Seats { get => seats; set => seats = value; }
    }
}
