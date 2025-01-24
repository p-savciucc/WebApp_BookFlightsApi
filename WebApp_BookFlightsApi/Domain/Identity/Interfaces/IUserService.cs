using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_BookFlightsApi.Domain.Identity.Models;

namespace WebApp_BookFlightsApi.Domain.Identity.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> Register(RegistrationDto request);
        Task<UserDto> Login(LoginDto request);
        UserDto GetUserById(long? userId);
        UserDto GetUserByEmail(string email);
    }
}
