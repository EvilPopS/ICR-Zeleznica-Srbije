using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeleznicaSrbije.API.DTOs
{
    public class RelationDTO
    {
        private string relation;
        private int trainLineId;


        public string Relation { get { return relation; } set { relation = value; } }

        public int TrainLineId { get { return trainLineId; } set { trainLineId = value; } }

       
    }
}
