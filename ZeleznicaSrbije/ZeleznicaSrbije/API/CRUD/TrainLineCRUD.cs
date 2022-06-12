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
        private readonly Repository<TrainLine> _trainLines;

        public TrainLineCRUD() {
            _trainLines = FileReaderWriter.ReadFile<TrainLine>(FILE_PATH);
        }

        public List<TrainLine> GetTrainLines()
        {
            return _trainLines.Entities;
        }

        internal TrainLine getTrainLineById(int id)
        {
            foreach (var line in GetTrainLines())
            {
                if (line.Id == id)
                {
                    return line;
                }
            }
            return null;
        }
    }
}
