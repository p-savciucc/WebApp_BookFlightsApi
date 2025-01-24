using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_BookFlightsApi.Domain.Identity.Models
{
    public class AddTripModel
    {
        public long? Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime Duration { get; set; }
        public double Price { get; set; }
        public string WhereItPasses { get; set; }
        public DateTime DateDeparture { get; set; }
        public DateTime DateArrival { get; set; }
        public string Type { get; set; }
        public int NumerOfPassengers { get; set; }
        public string Company { get; set; }
        public string RegistrationId { get; set; }
        public DateTime? CreatedAt { get; set; }

        public AddTripModel()
        {

        }

        public AddTripModel(string From, string To, DateTime Duration, double Price, string WhereItPasses, DateTime DateDeparture, DateTime DateArrival, string Type, int NumerOfPassengers, string Company, string RegistrationId, DateTime CreatedAt)
        {
            this.From = From;
            this.To = To;
            this.Duration = Duration;
            this.WhereItPasses = WhereItPasses;
            this.DateDeparture = DateDeparture;
            this.DateArrival = DateArrival;
            this.Type = Type;
            this.NumerOfPassengers = NumerOfPassengers;
            this.Company = Company;
            this.RegistrationId = RegistrationId;
            this.CreatedAt = CreatedAt;
        }
    }
}
