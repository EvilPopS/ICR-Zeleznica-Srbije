using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeleznicaSrbije.API.Models;

namespace ZeleznicaSrbije.API.DTOs
{
    internal class ManagerTimetableDTO
    {
        private string from;
        private string to;
        private string trainNumber;
        private string startTime;
        private string endTime;


        

        public string From { get { return from; } set { from = value; } }

        public string To { get { return to; } set { to = value; } }

        public string TrainNumber { get { return trainNumber; } set { trainNumber = value; } }

        public string StartTime { get { return startTime; } set { startTime = value; } }

        public string EndTime { get { return endTime; } set { endTime = value; } }  
        

    }
}
