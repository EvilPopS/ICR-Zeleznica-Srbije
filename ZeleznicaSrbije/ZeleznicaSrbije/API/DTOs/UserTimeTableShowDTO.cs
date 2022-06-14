using System;
using ZeleznicaSrbije.API.Models;

namespace ZeleznicaSrbije.API.DTOs {
    public class UserTimeTableShowDTO {
        public string TrainNumber { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public TimeSpan TravelTime { get; set; }

        public UserTimeTableShowDTO(Train train, TimeSpan startTime, TimeSpan endTime, TimeSpan travelTime) {
            TrainNumber = train.TrainNumber;
            StartTime = startTime;
            EndTime = endTime;
            TravelTime = travelTime;
        }
    }
}
