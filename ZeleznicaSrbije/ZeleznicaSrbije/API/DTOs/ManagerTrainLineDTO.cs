using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeleznicaSrbije.API.DTOs
{
    public class ManagerTrainLineDTO
    {
        private string placeStart;
        private string placeEnd;
        private string middleStations;
        private int trainLineId;
        private List<int> allPlacesIds;
        private List<string> placeNames;

        public List<string> PlaceNames { get { return placeNames; } set { placeNames = value; } }

        public List<int> AllPlacesIds { get { return allPlacesIds; } set { allPlacesIds = value; } }
        public int TrainLineId { get { return trainLineId; } set { trainLineId = value; } }
        public string PlaceStart { get { return placeStart; } set { placeStart = value; } } 
        public string PlaceEnd { get { return placeEnd; } set { placeEnd = value; } } 
        
        public string MiddleStations { get { return middleStations; } set { middleStations = value; } }
    }
}
