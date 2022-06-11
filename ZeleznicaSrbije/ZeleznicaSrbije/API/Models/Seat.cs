using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeleznicaSrbije.API.Models
{
    internal class Seat
    {
        private int seatNumber;
        private bool available;
        private int userId;

        public int SeatNumber { get => seatNumber; set => seatNumber = value; }
        public bool IsAvailable { get => available; set => available = value; }

        public int UserId { get => userId; set => userId = value; }
    }
}
