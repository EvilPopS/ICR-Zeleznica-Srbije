using ZeleznicaSrbije.API.Models;
using ZeleznicaSrbije.Database;
using ZeleznicaSrbije.Database.Repositories;

namespace ZeleznicaSrbije.API.CRUD {
    internal class TicketCRUD {
        private readonly string FILE_PATH = AppSettings.databasePath + "tickets.json";
        private readonly Repository<Ticket> _tickets;

        public TicketCRUD() {
            _tickets = FileReaderWriter.ReadFile<Ticket>(FILE_PATH);
        }
    }
}
