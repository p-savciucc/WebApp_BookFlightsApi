using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_BookFlightsApi.DataAccess.Entities;

namespace WebApp_BookFlightsApi.Domain.Identity.Interfaces
{
    public interface IJwtGenerator
    {
        string CreateToken(UserEntity user);
    }
}
