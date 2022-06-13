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
    }
}
