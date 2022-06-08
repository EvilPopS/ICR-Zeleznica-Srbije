using System;
using System.Collections.Generic;
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
    }
}
