using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_BookFlightsApi.DataAccess;
using WebApp_BookFlightsApi.DataAccess.Entities;
using WebApp_BookFlightsApi.Domain.Identity.Interfaces;
using WebApp_BookFlightsApi.Domain.Identity.Models;

namespace WebApp_BookFlightsApi.Domain.Identity.Services
{
    public class TicketService : ITicketService
    {
        private readonly ApiDbContext _context;

        public TicketService(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<long?> AddTicket(TicketModel request)
        {
            TicketEntity ticketModel = new TicketEntity
            {
                Id = request.Id,
                IdTripDeparture = request.IdTripDeparture,
                IdTripReturn = request.IdTripReturn,
                IdUser = request.IdUser,
                TotalPrice = request.TotalPrice,
                CreatedAt = DateTime.Now
            };

            var resultEntityId = await _context.Tickets.AddAsync(ticketModel);
            await _context.SaveChangesAsync();

            return resultEntityId.Entity.Id;
        }

        public TripPair GetTicketById(long ticketId)
        {
            var ticket = _context.Tickets.Where(x => x.Id == ticketId).First();

            var tripDeparture = _context.Trips.Where(x => x.Id == ticket.IdTripDeparture).First();
            var tripReturn = _context.Trips.Where(x => x.Id == ticket.IdTripReturn).First();

            return new TripPair(tripDeparture, tripReturn);
        }

        public List<TripPair> GetTickets()
        {
            var tickets = _context.Tickets.ToList();
            var returnList = new List<TripPair>();

            foreach (TicketEntity item in tickets)            
                returnList.Add(GetTicketById((long)item.Id));
            

            return returnList;
        }
    }
}
