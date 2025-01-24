using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp_BookFlightsApi.DataAccess.Entities;

namespace WebApp_BookFlightsApi.DataAccess
{
    public class ApiDbContext : IdentityDbContext<UserEntity, IdentityRole<long>, long>
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        public DbSet<TicketEntity> Tickets { get; set; }
        public DbSet<TripEntity> Trips { get; set; }
    }
}
