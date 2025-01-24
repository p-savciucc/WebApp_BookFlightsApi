using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_BookFlightsApi.DataAccess.Entities;
using WebApp_BookFlightsApi.Domain.Identity.Models;

namespace WebApp_BookFlightsApi.Domain.Identity.Interfaces
{
    public interface ITicketService
    {
        Task<long?> AddTicket(TicketModel request);
        List<TripPair> GetTickets();
        TripPair GetTicketById(long ticketId);

    }
}
