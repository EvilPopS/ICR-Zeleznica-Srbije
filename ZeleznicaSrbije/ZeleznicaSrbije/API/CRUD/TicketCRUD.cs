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
            tickets = FileReaderWriter.ReadFile<Ticket>(FILE_PATH);
        }
    }
}
