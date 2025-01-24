using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApp_BookFlightsApi.Domain.Identity.Interfaces;
using WebApp_BookFlightsApi.Domain.Identity.Models;

namespace WebApp_BookFlightsApi.Controllers
{
    [ApiController]
    [Route("tickets")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpPost("addTicket")]
        public async Task<IActionResult> AddTicket(TicketModel request)
        {
            var result = await _ticketService.AddTicket(request);

            return Ok(result);
        }

        [HttpGet("getTickets")]
        public IActionResult GetTickets()
        {
            var result = _ticketService.GetTickets();

            return Ok(result);
        }

        [HttpGet("getTicketById")]
        public IActionResult GetTicketById(long ticketId)
        {
            var result = _ticketService.GetTicketById(ticketId);

            return Ok(result);
        }
    }
}
