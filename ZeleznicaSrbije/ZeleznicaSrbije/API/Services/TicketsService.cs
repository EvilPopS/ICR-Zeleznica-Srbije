using System;
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
            TrainsService trainService = new TrainsService();

            List<ShowTicketDTO> ticketDTOs = new List<ShowTicketDTO>();
            foreach (Ticket tick in _ticketsCRUD.GetTicketsByUserId(userId)) {
                ticketDTOs.Add(
                    new ShowTicketDTO(
                        tick
                    )
                );
            }
            return ticketDTOs;
        }

        public void MakeNewTicket(int userId, string startPlace, string endPlace, UserTimeTableShowDTO dto, DateTime validityDate, bool isBought) {
            int curSeat = 0;
            foreach (Ticket tic in _ticketsCRUD.GetTicketsByDate(validityDate))
                if (tic.StartPlace == startPlace && tic.StartTime == dto.StartTime && curSeat < int.Parse(tic.SeatNumber))
                    curSeat = int.Parse(tic.SeatNumber);

            Ticket ticket = new Ticket() {
                UserId = userId,
                TrainNum = dto.TrainNumber,
                StartPlace = startPlace,
                EndPlace = endPlace,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                ValidityDate = validityDate,
                IsActive = true,
                IsBought = isBought,
                IsReserved = !isBought,
                Price = 100,
                SeatNumber = (curSeat+1).ToString()
            };

            _ticketsCRUD.AddTicket(ticket);
        
        }
    }
}
