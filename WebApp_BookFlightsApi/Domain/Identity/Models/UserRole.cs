using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApp_BookFlightsApi.Domain.Identity.Models
{

    public enum UserRole
    {
        [Display(Name = "Administrator")]
        Administrator,
        [Display(Name = "Moderator")]
        Moderator,
        [Display(Name = "Buyer")]
        Buyer,
        [Display(Name = "Administrator,Moderator,Buyer")]
        All
}
}
