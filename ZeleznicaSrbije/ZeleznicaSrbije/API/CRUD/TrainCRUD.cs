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
    internal class TrainCRUD {
        private readonly string FILE_PATH = AppSettings.databasePath + "trains.json";
        private Repository<Train> trains;

        public TrainCRUD() {
            trains = FileReaderWriter.ReadFile<Train>(FILE_PATH);
        }

        public List<Train> getAllTrains() {
            List<Train> retVal = new List<Train>(); 
            foreach (var train in trains.Entities)
            {
                Console.WriteLine(train.TrainNumber);
                retVal.Add(train);
                
            }    
            return retVal;
        }

        public bool deleteTrain(string trainNumber) {
            foreach(var train in trains.Entities)
            {
                if(train.TrainNumber == trainNumber)
                {
                    trains.Entities.Remove(train);
                    FileReaderWriter.UpdateFile(FILE_PATH, trains);
                    return true;//aj dace bog
                }
            } 
            return false;
        }
    }
}
