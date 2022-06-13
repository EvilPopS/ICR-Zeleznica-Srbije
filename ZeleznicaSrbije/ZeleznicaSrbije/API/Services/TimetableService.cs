using ZeleznicaSrbije.API.CRUD;
using ZeleznicaSrbije.API.Models;

namespace ZeleznicaSrbije.API.Services {
    public class TimetableService {
        private readonly TimetableCRUD _timetableCRUD;

        public TimetableService() {
            _timetableCRUD = new TimetableCRUD();
        }

        public Timetable GetTimetableById(int timetableId) {
            return _timetableCRUD.GetById(timetableId);
        }
    }
}
