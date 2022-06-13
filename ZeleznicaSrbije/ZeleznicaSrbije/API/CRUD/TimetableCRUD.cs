using System.Collections.Generic;
using ZeleznicaSrbije.API.Models;
using ZeleznicaSrbije.Database;
using ZeleznicaSrbije.Database.Repositories;

namespace ZeleznicaSrbije.API.CRUD {
    public class TimetableCRUD {
        private readonly string FILE_PATH = AppSettings.databasePath + "timetables.json";
        private readonly Repository<Timetable> _timetables;

        public TimetableCRUD() {
            _timetables = FileReaderWriter.ReadFile<Timetable>(FILE_PATH);
        }

        public List<Timetable> GetTimetable() {
            return _timetables.Entities;        
        }


        public void addNewRide(Timetable newRide)
        {
            _timetables.Entities.Add(newRide);
            FileReaderWriter.UpdateFile(FILE_PATH, _timetables);

        }
    }
}
