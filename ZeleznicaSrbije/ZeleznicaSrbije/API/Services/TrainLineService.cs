using System;
using System.Collections.Generic;
using ZeleznicaSrbije.API.CRUD;
using ZeleznicaSrbije.API.DTOs;
using ZeleznicaSrbije.API.Models;

namespace ZeleznicaSrbije.API.Services {
    internal class TrainLineService
    {
        private readonly TrainLineCRUD trainLineCRUD;

        public TrainLineService()
        {
            trainLineCRUD = new TrainLineCRUD();    
        }

        public List<TrainLine> getTrainLines()
        {
            return trainLineCRUD.GetTrainLines();
        }

        public TrainLine getTrainLineById(int id)
        {
            return trainLineCRUD.getTrainLineById(id);
        }

        public TrainLine getTrainLineByMidleStations(List<string> midleStations)
        {
            return trainLineCRUD.getTrainLineByMidleStations(midleStations);
        }

        public bool DeleteTrainLine(int id)
        {
            return trainLineCRUD.DeleteTrainLine(id);
        }
      
        public List<UserTimeTableShowDTO> GetTrainLinesDTOs(string startPlace, string endPlace) {
            TrainsService trainService = new TrainsService();
            TimetableService timetableService = new TimetableService();
            
            List<UserTimeTableShowDTO> DTOs = new List<UserTimeTableShowDTO>();
            foreach (TrainLine tl in trainLineCRUD.GetTrainLines()) {
                List<string> places = new List<string>(tl.MiddlePlaces);
                places.Insert(0, tl.PlaceStart);

                bool isStartFound = false;
                bool isEndFound = false;
                int foundStartPlace = -1;
                int foundEndPlace = -1;

                for (int ind = 0; ind < places.Count; ind++)
                    if (!isStartFound) {
                        if (places[ind] == startPlace) {
                            foundStartPlace = ind;
                            isStartFound = true;
                        }
                    }
                    else {
                        if (places[ind] == endPlace) {
                            foundEndPlace = ind;
                            isEndFound = true;
                        }
                    }

                if (isStartFound) {
                    if (!isEndFound && tl.PlaceEnd == endPlace) {
                        foundEndPlace = places.Count;
                        isEndFound = true;
                    }

                    if (isEndFound) {
                        TimeSpan startTime = timetableService.GetTimetableById(tl.TimetableIds[foundStartPlace]).Start; ;
                        TimeSpan endTime = timetableService.GetTimetableById(tl.TimetableIds[foundEndPlace - 1]).End;

                        DTOs.Add(
                            new UserTimeTableShowDTO(
                                trainService.getTrainById(tl.TrainId),
                                startTime,
                                endTime,
                                endTime.Subtract(startTime)
                            )
                        );
                    }
                }
            }

            return DTOs;
        }

    }
}
