using System.Collections.Generic;
using ZeleznicaSrbije.API.CRUD;
using ZeleznicaSrbije.API.Models;

namespace ZeleznicaSrbije.API.Services {
    public class TrainsService
    {
        private readonly TrainCRUD _trainCRUD;

        public TrainsService()
        {
            _trainCRUD = new TrainCRUD();
        }

        public List<Train> GetAllTrains()
        {
            return _trainCRUD.GetAllTrains();
        }

        public bool DeleteTrain(string trainNumber)
        {
            return _trainCRUD.DeleteTrain(trainNumber); 
        }
    }
}
