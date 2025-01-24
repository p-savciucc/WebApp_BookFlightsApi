using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_BookFlightsApi.DataAccess.Entities;

namespace WebApp_BookFlightsApi.Domain.Identity.Models
{
    public class TripPair
    {
        public TripEntity TripDeparture { get; set; } 
        public TripEntity TripReturn { get; set; }

        public TripPair(TripEntity TripDeparture, TripEntity TripReturn)
        {
            this.TripDeparture = TripDeparture;
            this.TripReturn = TripReturn;
        }
    }
}
