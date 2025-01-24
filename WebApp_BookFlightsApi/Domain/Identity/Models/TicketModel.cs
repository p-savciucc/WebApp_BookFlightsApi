using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_BookFlightsApi.Domain.Identity.Models
{
    public class TicketModel
    {
        public long? Id { get; set; }
        public long? IdUser { get; set; }
        public long? IdTripDeparture { get; set; }
        public long? IdTripReturn { get; set; }
        public double TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; }

        public TicketModel()
        {

        }

        public TicketModel(long Id, long IdUser, long IdTripDeparture, long IdTripReturn, double TotalPrice, DateTime CreatedAt)
        {
            this.Id = Id;
            this.IdUser = IdUser;
            this.IdTripDeparture = IdTripDeparture;
            this.IdTripReturn = IdTripReturn;
            this.TotalPrice = TotalPrice;
            this.CreatedAt = CreatedAt;
        }
    }
}
