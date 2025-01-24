using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_BookFlightsApi.DataAccess.Entities
{
    public class TicketEntity
    {
        public long? Id { get; set; }
        public long? IdUser { get; set; }
        public UserEntity user { get; set; }
        public long? IdTrip { get; set; }
        public TripEntity trip { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
