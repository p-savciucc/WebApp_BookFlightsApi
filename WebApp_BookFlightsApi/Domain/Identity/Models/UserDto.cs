using System;
using System.Collections.Generic;

namespace WebApp_BookFlightsApi.Domain.Identity.Models
{
    public class UserDto
    {
        public long? IdUser { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime Birth { get; set; }
        public string CurrentLocation { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string Token { get; set; }
        public string Message { get; set; }
        public IList<string> Roles { get; set; }


        public UserDto()
        {

        }
        public UserDto(string Message)
        {
            this.Message = Message;
        }
        public UserDto(long? IdUser, string Firstname, string Lastname, string UserName, string Email, DateTime Birth, string CurrentLocation)
        {
            this.IdUser = IdUser;
            this.Firstname = Firstname;
            this.Lastname = Lastname;
            this.UserName = UserName;
            this.Email = Email;
            this.Birth = Birth;
            this.CurrentLocation = CurrentLocation;
        }
        public UserDto(long? IdUser, string Firstname, string Lastname, string UserName, string Email, DateTime Birth, string CurrentLocation, IList<string> Roles)
        {
            this.IdUser = IdUser;
            this.Firstname = Firstname;
            this.Lastname = Lastname;
            this.UserName = UserName;
            this.Email = Email;
            this.Birth = Birth;
            this.CurrentLocation = CurrentLocation;
            this.Roles = Roles;
        }
    }
}
