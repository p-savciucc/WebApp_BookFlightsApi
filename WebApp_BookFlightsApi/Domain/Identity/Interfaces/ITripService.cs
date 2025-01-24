using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp_BookFlightsApi.DataAccess.Entities;
using WebApp_BookFlightsApi.Domain.Identity.Models;

namespace WebApp_BookFlightsApi.Domain.Identity.Interfaces
{
    public interface ITripService
    {
        Task<long?> AddTrip(AddTripModel request);
        string ModifyTrip(TripModel request);
        List<TripEntity> SortByFrom();
        List<TripEntity> GetTrips();
        List<TripPair> SearchTrips(string From, string To, DateTime DateDeparture, DateTime DateArrival, string tripSortBy);
    }
}
