using System.Collections.Generic;
using ZeleznicaSrbije.API.CRUD;
using ZeleznicaSrbije.API.DTOs;
using ZeleznicaSrbije.API.Models;

namespace ZeleznicaSrbije.API.Services {
    public class TicketsService {
        private readonly TicketCRUD _ticketsCRUD;

        public TicketsService() {
            _ticketsCRUD = new TicketCRUD();
        }

        public List<ShowTicketDTO> GetTicketsDTOByUserId(int userId) {
            TimetableService timetableService = new TimetableService();
            TrainsService trainService = new TrainsService();

            List<ShowTicketDTO> ticketDTOs = new List<ShowTicketDTO>();
            foreach (Ticket tick in _ticketsCRUD.GetTicketsByUserId(userId)) {
                Timetable timetable = timetableService.GetTimetableById(tick.TimetableId);
                Train train = trainService.GetByTrainId(timetable.TrainId);
                
                ticketDTOs.Add(
                    new ShowTicketDTO(
                        tick,
                        timetable,
                        train
                    )
                );
            }
            return ticketDTOs;
        }
    }
}
