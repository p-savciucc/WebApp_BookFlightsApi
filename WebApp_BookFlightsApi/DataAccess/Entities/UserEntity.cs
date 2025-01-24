using System;
using Microsoft.AspNetCore.Identity;

namespace WebApp_BookFlightsApi.DataAccess.Entities
{
    public class UserEntity : IdentityUser<long>
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Birth { get; set; }
        public string CurrentLocation { get; set; }
        public DateTime? CreatedAt { get; set; }

        public UserEntity()
        {

        }
        public UserEntity(long Id)
        {
            this.Id = Id;
        }
    }
}
