using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeleznicaSrbije.API.Models {
    internal class Train : INotifyPropertyChanged{
        private int id;
        private string trainNumber;
        private int capacity;
        private bool isDeleted;
        private List<Seat> seats;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public int Id { 
            get { return id; }  
            set { 
                if (value != id) 
                {
                    id = value;
                    OnPropertyChanged("Id");
                } 
            }
        }
        public string TrainNumber {
            get { return trainNumber; }
            set
            {
                if (value != trainNumber)
                {
                    trainNumber = value;
                    OnPropertyChanged("TrainNumber");
                }
            }
        }
        public int Capacity {
            get { return capacity; }
            set
            {
                if (value != capacity)
                {
                    capacity = value;
                    OnPropertyChanged("Capacity");
                }
            }
        }
        public bool IsDeleted {
            get { return isDeleted; }
            set
            {
                if (value != isDeleted)
                {
                    isDeleted = value;
                    OnPropertyChanged("IsDeleted");
                }
            }

        }

        public List<Seat> Seats {
            get { return seats; }
            set
            {
                if (value != seats)
                {
                    seats = value;
                    OnPropertyChanged("Seats");
                }
            }
        }

        public Train()
        {
            Seats = new List<Seat>();
            
        }
    }
}
