using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeleznicaSrbije.API.Models {
    internal class TrainService {
        private int id;
        private string placeStart;
        private string placeEnd;
        private List<int> timetableInds;
        private bool isDeleted;


        public int Id { get => id; set => id = value; }
        public string PlaceStart { get => placeStart; set => placeStart = value; }
        public string PlaceEnd { get => placeEnd; set => placeEnd = value; }
        public List<int> TimetableInds { get => timetableInds; set => timetableInds = value; }
        public bool IsDeleted { get => isDeleted; set => isDeleted = value; }
    }
}
