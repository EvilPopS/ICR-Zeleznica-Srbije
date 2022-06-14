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
    public class PlaceService
    {


        private static string FILE_PATH = AppSettings.databasePath + "places.json";
        List<Place> _places;
        public PlaceService()
        {
            _places = JsonConvert.DeserializeObject<List<Place>>(File.ReadAllText(FILE_PATH));

        }

        public List<Place> getAllPlaces()
        {
            return _places;
        }

        public Place getPlaceById(int Id)
        {
            foreach(Place place in _places)
            {
                if(place.Id == Id)
                {
                    return place;
                }
            }

            return null;
        }

        public Place getPlaceByName(string placeName)
        {
            foreach(Place place in _places)
            {
                if(place.PlaceName.Equals(placeName))
                {
                    return place;
                }
            }
            return null;
        }

        public List<Place> getNoNamePlaces()
        {
            List<Place> noNamePlaces = new List<Place>(); 
            foreach(Place nnplace in _places)
            {
                if (nnplace.PlaceName.Equals("noname"))
                {
                    noNamePlaces.Add(nnplace);
                }
            }
            return noNamePlaces;
        }

        public List<int> getAllIds()
        {
            List<int> allIds = new List<int>();
            foreach (Place place in _places)
            {
                allIds.Add(place.Id);
            }
            return allIds;

        }
    }
}
