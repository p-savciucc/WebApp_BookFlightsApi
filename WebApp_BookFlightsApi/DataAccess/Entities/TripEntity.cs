using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_BookFlightsApi.DataAccess.Entities
{
    public class TripEntity
    {
        public long? Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public TimeSpan Duration { get; set; }
        public double Price { get; set; }
        public List<string> WhereItPasses { get; set; }
        public DateTime DateDeparture { get; set; }
        public DateTime DateArrival { get; set; }
        public string Type { get; set; }
        public int NumerOfPassengers { get; set; }
    }
}
