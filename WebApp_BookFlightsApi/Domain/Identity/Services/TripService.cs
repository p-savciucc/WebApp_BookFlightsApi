using Microsoft.Extensions.Configuration;
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
    public class TripService : ITripService
    {
        private readonly ApiDbContext _context;
        private readonly IConfiguration _configuration;

        public TripService(ApiDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<long?> AddTrip(AddTripModel request)
        {

            var whereItPasses = request.WhereItPasses.Split(',').ToList();

            TripEntity tripEntity = new TripEntity
            {
                From = request.From,
                To = request.To,
                Price = request.Price,
                Duration = request.Duration,
                DateDeparture = request.DateDeparture,
                DateArrival = request.DateArrival,
                WhereItPasses = whereItPasses,
                Type = request.Type,
                NumerOfPassengers = request.NumerOfPassengers,
                Company = request.Company,
                RegistrationId = request.RegistrationId,
                CreatedAt = DateTime.Now,
            };

           
            var resultEntityId = await _context.Trips.AddAsync(tripEntity);
            await _context.SaveChangesAsync();

            return resultEntityId.Entity.Id;
        }

        public List<TripEntity> GetTrips()
        {
            return _context.Trips.ToList();
        }

        public string ModifyTrip(TripModel request)
        {
            var entity = _context.Trips.First(x => x.Id == request.Id);


            entity.From = request.From;
            entity.To = request.To;
            entity.Duration = request.Duration;
            entity.DateDeparture = request.DateDeparture;
            entity.DateArrival = request.DateArrival;
            entity.Type = request.Type;
            entity.NumerOfPassengers = request.NumerOfPassengers;
            entity.Company = request.Company;
            entity.RegistrationId = request.RegistrationId;
            entity.CreatedAt = request.CreatedAt;

            try
            {
               _context.Trips.Update(entity);
                return "Update is successful!";
            }
            catch (Exception)
            {
                return "An error occurred!";
            }
        }

        public List<TripPair> SearchTrips(string From, string To, DateTime DateDeparture, DateTime DateReturn, string tripSortBy)
        {
            var pairsTrip = new List<TripPair>();
            var tripsDeparture = _context.Trips.Where(trip => trip.From == From && trip.To == To && trip.DateDeparture.Date == DateDeparture.Date).ToList();
            var tripsReturn = _context.Trips.Where(trip => trip.From == To && trip.To == From && trip.DateDeparture.Date == DateReturn.Date).ToList();

            if (tripsDeparture.Count > tripsReturn.Count)            
                for (int i = 0; i < tripsDeparture.Count; i++)
                    pairsTrip.Add(new TripPair(tripsDeparture[i], tripsReturn[i]));
            
            else
                for (int i = 0; i < tripsReturn.Count; i++)
                    pairsTrip.Add(new TripPair(tripsDeparture[i], tripsReturn[i]));

            switch(tripSortBy)
            {
                case TripSortBy.Best:
                    pairsTrip.Sort(new BestComparer());
                    break;
                case TripSortBy.Cheapest:
                    pairsTrip.Sort(new CheapestComparer());
                    break;
                case TripSortBy.MostExpensive:
                    pairsTrip.Sort(new MostExpensiveComparer());
                    break;
            }

            return pairsTrip;
        }

        public List<TripEntity> SortByFrom()
        {
            List<TripEntity> tmpList = new List<TripEntity>();
            List<TripEntity> listComponents = new List<TripEntity>();
            List<char> alphabetList = Enumerable.Range('a', 26).Select(i => (char)i).ToList();
            List<Alphabet> listAlphabetLength = new List<Alphabet>();


            tmpList =  _context.Trips.ToList();
            

            foreach (char alphabetItem in alphabetList)
            {
                int length = 0;
                foreach (TripEntity item in tmpList)
                {
                    if (char.ToUpper(item.From[0]) == char.ToUpper(alphabetItem))
                    {
                        listComponents.Add(item);
                        length += 1;
                    }
                }
                if (length != 0)
                    listAlphabetLength.Add(new Alphabet(alphabetItem, length));
            }

            string[][] jaggedArray = new string[listAlphabetLength.Count][];

            int iListComponents = 0;
            for (int i = 0; i < listAlphabetLength.Count; i++)
            {
                jaggedArray[i] = new string[listAlphabetLength[i].length];

                for (int j = 0; j < listAlphabetLength[i].length; j++)
                {
                    jaggedArray[i][j] = listComponents[iListComponents].From; 
                    iListComponents += 1;
                }

            }

            var tmp = jaggedArray;

            return listComponents;
        }

        class Alphabet
        {
            public char caracter { get; set; }
            public int length { get; set; }

            public Alphabet(char caracter, int length)
            {
                this.caracter = caracter;
                this.length = length;
            }
        }

        public class BestComparer : IComparer<TripPair>
        {
            public int Compare(TripPair x, TripPair y)
            {
                if (x == null || y == null)
                    throw new ArgumentException("Parameters can't be null");

                return (x.TripDeparture.Price + x.TripReturn.Price).CompareTo(y.TripDeparture.Price + y.TripReturn.Price);
            }
        }

        public class CheapestComparer : IComparer<TripPair>
        {
            public int Compare(TripPair x, TripPair y)
            {
                if (x == null || y == null)
                    throw new ArgumentException("Parameters can't be null");

                return (x.TripDeparture.Price + x.TripReturn.Price).CompareTo(y.TripDeparture.Price + y.TripReturn.Price);
            }
        }

        public class MostExpensiveComparer : IComparer<TripPair>
        {
            public int Compare(TripPair x, TripPair y)
            {
                if (x == null || y == null)
                    throw new ArgumentException("Parameters can't be null");

                return (y.TripDeparture.Price + y.TripReturn.Price).CompareTo(x.TripDeparture.Price + x.TripReturn.Price);
            }
        }
    }
}
