using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeleznicaSrbije.API.Models;
using ZeleznicaSrbije.Database;
using ZeleznicaSrbije.Database.Repositories;

namespace ZeleznicaSrbije.API.CRUD {
    internal class TrainServiceCRUD {
        private readonly string FILE_PATH = AppSettings.databasePath + "train_services.json";
        private Repository<TrainService> trainServices;

        public TrainServiceCRUD() {
            trainServices = FileReaderWriter.ReadFile<TrainService>(FILE_PATH);
        }
    }
}
