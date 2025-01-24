using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_BookFlightsApi.Domain.Identity.Models
{
    public class RegistrationDto
    {
        public long IdUser { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime Birth { get; set; }
        public string CurrentLocation { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
