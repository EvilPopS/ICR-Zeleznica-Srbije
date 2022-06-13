using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeleznicaSrbije.API.CRUD;
using ZeleznicaSrbije.API.Models;

namespace ZeleznicaSrbije.API.Services
{
    internal class TrainLineService
    {
        private readonly TrainLineCRUD trainLineCRUD;

        public TrainLineService()
        {
            trainLineCRUD = new TrainLineCRUD();    
        }

        public List<TrainLine> getTrainLines()
        {
            return trainLineCRUD.GetTrainLines();
        }

        public TrainLine getTrainLineById(int id)
        {
            return trainLineCRUD.getTrainLineById(id);
        }

        public TrainLine getTrainLineByMidleStations(List<string> midleStations)
        {
            return trainLineCRUD.getTrainLineByMidleStations(midleStations);
        }

        public bool DeleteTrainLine(int id)
        {
            return trainLineCRUD.DeleteTrainLine(id);
        }
    }
}
