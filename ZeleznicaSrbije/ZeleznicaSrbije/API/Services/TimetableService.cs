using System;
using ZeleznicaSrbije.API.CRUD;
using ZeleznicaSrbije.API.Models;

namespace ZeleznicaSrbije.API.Services
{
    internal class TimetableService
    {
        private readonly TimetableCRUD _timetableCRUD;

        public TimetableService()
        {
            _timetableCRUD = new TimetableCRUD();
        }

        public List<Timetable> getTimetable()
        {
            return _timetableCRUD.GetTimetable();
        }

        public Timetable GetTimetableById(int timetableId) {
            return _timetableCRUD.GetById(timetableId);
        }

        public void addNewRideToTimetable(Timetable newRide)
        {
            _timetableCRUD.addNewRide(newRide);
        }
    }
}
