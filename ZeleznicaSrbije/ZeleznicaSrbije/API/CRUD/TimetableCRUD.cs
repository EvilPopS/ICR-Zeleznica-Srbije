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

        public Timetable GetById(int timetableId) {
            foreach (Timetable tt in _timetables.Entities)
                if (tt.Id == timetableId)
                    return tt;
            return null;
          }

        public List<Timetable> GetTimetable() {
            return _timetables.Entities;        
        }

        public void addNewRide(Timetable newRide)
        {
            _timetables.Entities.Add(newRide);
            FileReaderWriter.UpdateFile(FILE_PATH, _timetables);
        }

        public Timetable updateRide(Timetable editedTimetable)
        {
            foreach(var tt in _timetables.Entities)
            {
                if (tt.Id == editedTimetable.Id)
                {
                    tt.Id = editedTimetable.Id;
                    tt.TrainServiceId = editedTimetable.TrainServiceId;
                    tt.TrainId = editedTimetable.TrainId;
                    tt.Start = editedTimetable.Start;
                    tt.End = editedTimetable.End;
                    tt.IsDeleted = editedTimetable.IsDeleted;
                    FileReaderWriter.UpdateFile(FILE_PATH, _timetables);
                    return tt;
                }
            }
            return null;
        }

        public bool DeleteRide(int Id)
        {
            foreach(var ride in _timetables.Entities)
            {
                if(ride.Id == Id)
                {
                    _timetables.Entities.Remove(ride);
                    FileReaderWriter.UpdateFile(FILE_PATH, _timetables);
                    return true;
                }
            }

            return false;
        }

    }
}
