using System;
using System.Collections.Generic;
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

        public List<Ticket> GetTicketsByUserId(int userId) {
            List<Ticket> tickets = new List<Ticket>();

            foreach(Ticket tick in _tickets.Entities) 
                if (tick.UserId == userId && tick.IsActive)
                    tickets.Add(tick);

            return tickets;
        }

        public List<Ticket> GetTicketsByDate(DateTime validityDate) {
            List<Ticket> ticks = new List<Ticket>();
            foreach(Ticket t in _tickets.Entities) {
                if (t.ValidityDate == validityDate)
                    ticks.Add(t);
            }

            return ticks;
        }

        public void AddTicket(Ticket ticket) {
            ticket.Id = _tickets.NextInd;
            _tickets.AddEntity(ticket);
            FileReaderWriter.UpdateFile(FILE_PATH, _tickets);
        }
    }
}
