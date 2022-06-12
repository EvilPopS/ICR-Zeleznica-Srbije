using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeleznicaSrbije.API.Models;
using ZeleznicaSrbije.Database;
using ZeleznicaSrbije.Database.Repositories;

namespace ZeleznicaSrbije.API.CRUD {
    public class TrainLineCRUD {
        private readonly string FILE_PATH = AppSettings.databasePath + "train_lines.json";
        private readonly Repository<TrainLine> trainLines;

        public TrainLineCRUD() {
            trainLines = FileReaderWriter.ReadFile<TrainLine>(FILE_PATH);
        }
    }
}
