﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeleznicaSrbije.API.Models {
    public class TrainLine {
        private int id;
        private string placeStart;
        private string placeEnd;
        private List<int> timetableIds;
        private List<string> middlePlaces;
        private bool isDeleted;


        public int Id { get => id; set => id = value; }
        public string PlaceStart { get => placeStart; set => placeStart = value; }
        public string PlaceEnd { get => placeEnd; set => placeEnd = value; }
        public List<int> TimetableIds { get => timetableIds; set => timetableIds = value; }

        public List<string> MiddlePlaces { get => middlePlaces; set => middlePlaces = value; }
        public bool IsDeleted { get => isDeleted; set => isDeleted = value; }
    }
}
