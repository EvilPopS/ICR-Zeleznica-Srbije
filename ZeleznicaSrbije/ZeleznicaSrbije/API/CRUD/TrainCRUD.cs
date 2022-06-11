using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeleznicaSrbije.API.Models;
using ZeleznicaSrbije.Database;
using ZeleznicaSrbije.Database.Repositories;

namespace ZeleznicaSrbije.API.CRUD {
    public class TrainCRUD {
        private readonly string FILE_PATH = AppSettings.databasePath + "trains.json";
        private readonly Repository<Train> _trains;

        public TrainCRUD() {
            _trains = FileReaderWriter.ReadFile<Train>(FILE_PATH);
        }

        public List<Train> GetAllTrains() {
            return _trains.Entities;
        }

        public bool DeleteTrain(string trainNumber) {
            foreach(var train in _trains.Entities)
            {
                if(train.TrainNumber == trainNumber)
                {
                    _trains.Entities.Remove(train);
                    FileReaderWriter.UpdateFile(FILE_PATH, _trains);
                    return true;
                }
            } 
            return false;
        }
    }
}
