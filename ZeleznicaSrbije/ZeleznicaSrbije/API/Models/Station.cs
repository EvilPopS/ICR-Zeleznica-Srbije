using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeleznicaSrbije.API.Models
{
    public class Station
    {
        private string placeOne;
        private string placeTwo;
        private int travelTime;

        public string PlaceOne { get { return placeOne; } set { placeOne = value; } }
        public string PlaceTwo { get { return placeTwo; } set { placeTwo = value; } }
        public int TravelTime { get { return travelTime; } set { travelTime = value; } } 

    }
}
