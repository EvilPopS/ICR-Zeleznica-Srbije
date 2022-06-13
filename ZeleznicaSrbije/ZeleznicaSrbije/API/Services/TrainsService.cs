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

        public void AddTrain(Train train)
        {
            _trainCRUD.addNewTrain(train);
        }

        public Train updateTrain(Train train)
        {
            return _trainCRUD.updateTrain(train);
        }

        public Train getTrainById(int id)
        {
            return _trainCRUD.getTrainById(id);
        }


    }
}
