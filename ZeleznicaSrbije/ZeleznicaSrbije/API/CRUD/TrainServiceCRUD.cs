using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeleznicaSrbije.API.Models;
using ZeleznicaSrbije.Database;
using ZeleznicaSrbije.Database.Repositories;

namespace ZeleznicaSrbije.API.CRUD {
    public class TrainServiceCRUD {
        private readonly string FILE_PATH = AppSettings.databasePath + "train_services.json";
        private readonly Repository<TrainService> _trainServices;

        public TrainServiceCRUD() {
            _trainServices = FileReaderWriter.ReadFile<TrainService>(FILE_PATH);
        }
    }
}
