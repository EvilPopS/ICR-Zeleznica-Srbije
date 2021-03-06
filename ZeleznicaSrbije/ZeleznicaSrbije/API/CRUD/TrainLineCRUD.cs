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

        public TrainLine getTrainLineById(int id)
        {
            foreach (var line in _trainLines.Entities)
            {
                if (line.Id == id)
                {
                    return line;
                }
            }
            return null;
        }

        public bool DeleteTrainLine(int id)
        {
            foreach(var line in _trainLines.Entities)
            {
                if(line.Id == id)
                {
                    _trainLines.Entities.Remove(line);
                    FileReaderWriter.UpdateFile(FILE_PATH, _trainLines);
                    return true;
                }
            }
            return false;
        }

        public TrainLine getTrainLineByMidleStations(List<string> midleStations)
        {
            foreach(var line in _trainLines.Entities)
            {
                if (line.MiddlePlaces.All(midleStations.Contains))
                {
                    return line;
                }
            }

            return null;
        }
    }
}
