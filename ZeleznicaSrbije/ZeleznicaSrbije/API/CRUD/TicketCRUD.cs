using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeleznicaSrbije.API.Models;
using ZeleznicaSrbije.Database;
using ZeleznicaSrbije.Database.Repositories;

namespace ZeleznicaSrbije.API.CRUD {
    internal class TicketCRUD {
        private readonly string FILE_PATH = AppSettings.databasePath + "tickets.json";
        private Repository<Ticket> tickets;

        public TicketCRUD() {
            tickets = new Repository<Ticket>();
            tickets.AddEntity(new Ticket() { Id = 0, UserId=0, TimetableId=0, ValidityDate=DateTime.Now.Date, Price=300, IsReserved=false, IsActive=true, IsBought=true });
            FileReaderWriter.UpdateFile(FILE_PATH, tickets);
/*            tickets = FileReaderWriter.ReadFile<Ticket>(FILE_PATH);
*/
        }
    }
}
