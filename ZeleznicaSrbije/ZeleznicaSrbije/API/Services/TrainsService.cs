using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeleznicaSrbije.API.CRUD;
using ZeleznicaSrbije.API.Models;

namespace ZeleznicaSrbije.API.Services
{
    internal class TrainsService
    {

        TrainCRUD trainCRUD;

        public TrainsService()
        {
            trainCRUD = new TrainCRUD();
        }

        public ObservableCollection<Train> getAllTrains()
        {
            return trainCRUD.getAllTrains();
        }

        public bool deleteTrain(string trainNumber)
        {
            return trainCRUD.deleteTrain(trainNumber); 
        }
    }
}
