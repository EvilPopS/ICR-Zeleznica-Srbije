using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeleznicaSrbije.API.CRUD;
using ZeleznicaSrbije.API.Models;

namespace ZeleznicaSrbije.API.Services
{
    internal class TimetableService
    {
        private readonly TimetableCRUD timetableCRUD;

        public TimetableService()
        {
            timetableCRUD = new TimetableCRUD();
        }

        public List<Timetable> getTimetable()
        {
            return timetableCRUD.GetTimetable();
        }
    }
}
