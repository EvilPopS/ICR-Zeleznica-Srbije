using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeleznicaSrbije.API.Models;
using ZeleznicaSrbije.Database;
using ZeleznicaSrbije.Database.Repositories;

namespace ZeleznicaSrbije.API.CRUD {
    internal class TimetableCRUD {
        private readonly string FILE_PATH = AppSettings.databasePath + "timetables.json";
        private Repository<Timetable> timetables;

        public TimetableCRUD() {
            timetables = FileReaderWriter.ReadFile<Timetable>(FILE_PATH);
        }
    }
}
