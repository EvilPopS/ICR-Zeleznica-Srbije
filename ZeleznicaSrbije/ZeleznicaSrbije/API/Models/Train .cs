using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeleznicaSrbije.API.Models {
    internal class Train {
        private int id;
        private string trainNumber;
        private int capacity;
        private bool isDeleted;

        public int Id { get => id; set => id = value; }
        public string TrainNumber { get => trainNumber; set => trainNumber = value; }
        public int Capacity { get => capacity; set => capacity = value; }
        public bool IsDeleted { get => isDeleted; set => isDeleted = value; }
    }
}
