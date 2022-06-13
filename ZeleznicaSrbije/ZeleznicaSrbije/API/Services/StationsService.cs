using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeleznicaSrbije.API.Models;


namespace ZeleznicaSrbije.API.Services
{
    public class StationsService
    {
        private static string FILE_PATH = AppSettings.databasePath + "stations.json";
        List<Station> _stations;
        public StationsService()
        {
            _stations = JsonConvert.DeserializeObject<List<Station>>(File.ReadAllText(FILE_PATH));

        }

        public int getTravelTimeByPlaceOneAndTwo(string placeOne, string placeTwo)
        {
            foreach(Station station in _stations)
            {
                if ((station.PlaceOne.Equals(placeOne) && station.PlaceTwo.Equals(placeTwo)) || (station.PlaceOne.Equals(placeTwo) && station.PlaceTwo.Equals(placeOne)))
                {
                    return station.TravelTime;
                }
            }

            return 0;
        }

        public TimeSpan calculateEndTime(TimeSpan startTime, List<string> midleStations, string startPoint, string endPoint)
        {
            List<string> completePath = new List<string>();
            completePath.Add(startPoint);
            if (!midleStations[0].Equals("Bez medjustanica"))
            {
                foreach (string ms in midleStations) { completePath.Add(ms); };
            }
            
            completePath.Add(endPoint);
            
            int minutes = 0;
            int j = 1;
            for (int i = 0; i < completePath.Count - 1; i++)
            {
                minutes += getTravelTimeByPlaceOneAndTwo(completePath[i], completePath[j]);
                j++;
            }
            startTime += TimeSpan.FromMinutes(minutes);
            return startTime;
        }
    }
}
