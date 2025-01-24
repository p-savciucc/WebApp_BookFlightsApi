using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebApp_BookFlightsApi.Domain.Identity.Interfaces;
using WebApp_BookFlightsApi.Domain.Identity.Models;

namespace WebApp_BookFlightsApi.Controllers
{
    [ApiController]
    [Route("trips")]
    public class TripController : ControllerBase
    {
        private readonly ITripService _tripService;

        public TripController(ITripService tripService)
        {
            _tripService = tripService;
        }

        [HttpPost("addTrip")]
        public async Task<IActionResult> AddTrip(AddTripModel request)
        {
            var result = await _tripService.AddTrip(request);

            return Ok(result);
        }

        [HttpPost("modify")]
        public IActionResult ModifyTrip([FromForm] TripModel request)
        {
            var result = _tripService.ModifyTrip(request);

            return Ok(result);
        }

        [HttpGet("searchByDepartureDate")]
        public IActionResult SearchByDepartureDate()
        {
            var result = _tripService.SortByFrom();

            return Ok(result);
        }

        [HttpGet("getTrips")]
        public IActionResult GetTrips()
        {
            var result = _tripService.GetTrips();
            
            return Ok(result);
        }
        [HttpGet("searchTrips")]
        public IActionResult searchTrips(string From, string To, DateTime DateDeparture, DateTime DateArrival, string tripSortBy)
        {
            var result = _tripService.SearchTrips(From, To, DateDeparture, DateArrival, tripSortBy);


            return Ok(result);
        }
    }
}
