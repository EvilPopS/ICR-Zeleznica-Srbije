using System;

namespace ZeleznicaSrbije.API.Models {
    public class Timetable {
        private int id;
        private int trainServiceId;
        private int trainId;
        private TimeSpan start;
        private TimeSpan end;
        private bool isDeleted;

        public Timetable() { }
        public int Id { get => id; set => id = value; }
        public int TrainServiceId { get => trainServiceId; set => trainServiceId = value; }
        public int TrainId { get => trainId; set => trainId = value; }
        public TimeSpan Start { get => start; set => start = value; }
        public TimeSpan End { get => end; set => end = value; }
        public bool IsDeleted { get => isDeleted; set => isDeleted = value; }
    }
}
