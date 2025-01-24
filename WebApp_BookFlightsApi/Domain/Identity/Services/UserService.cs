using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApp_BookFlightsApi.Domain.Identity.Interfaces;
using WebApp_BookFlightsApi.Domain.Identity.Models;
using WebApp_BookFlightsApi.DataAccess.Entities;
using WebApp_BookFlightsApi.DataAccess;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp_BookFlightsApi.Domain.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;
        private readonly IJwtGenerator _jwtGenerator;
        private readonly ApiDbContext _context;
        private readonly IConfiguration _configuration;

        public UserService(ApiDbContext context, IJwtGenerator jwtGenerator, SignInManager<UserEntity> signInManager, UserManager<UserEntity> userManager, IConfiguration configuration)
        {
            _context = context;
            _jwtGenerator = jwtGenerator;
            _signInManager = signInManager;
            _userManager = userManager;
            _configuration = configuration;
        }
        public async Task<UserDto> Login(LoginDto request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                return new UserDto("No such user found!");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (!result.Succeeded) return new UserDto("Invalid password!");

            var roles = await _userManager.GetRolesAsync(user);

            var userDto = new UserDto
            {
                IdUser = user.Id,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Message = "Login is successful!",
                Roles = roles.ToList(),
                Token = _jwtGenerator.CreateToken(user),
            };

            LoginDto.Id = user.Id;

            return userDto;
        }

        public async Task<UserDto> Register(RegistrationDto request)
        {
            if (await _context.Users.Where(x => x.Email == request.Email).AnyAsync())
            {
                return new UserDto("Such an email is obvious, please choose another one !");
            }

            var newUser = new UserEntity
            {
                Firstname = request.Firstname,
                Lastname = request.Lastname,
                Email = request.Email,
                UserName = request.UserName,
                Birth = request.Birth,
                CurrentLocation = request.CurrentLocation,
                CreatedAt = System.DateTime.Now
            };

            var result = await _userManager.CreateAsync(newUser, request.Password);

            if (result.Succeeded)
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == newUser.Email);
                await _userManager.AddToRoleAsync(user, GetDisplayName(UserRole.Buyer));
                var roles = await _userManager.GetRolesAsync(user);

                return new UserDto
                {
                    IdUser = request.IdUser,
                    Firstname = request.Firstname,
                    Lastname = request.Lastname,
                    Email = request.Email,
                    Birth = request.Birth,
                    CurrentLocation = request.CurrentLocation,
                    Message = "Registration successful!",
                    Token = _jwtGenerator.CreateToken(newUser),
                    UserName = newUser.UserName,
                    Roles = roles.ToList(),
                };
            }
            else
            {
                return new UserDto("The password is entered incorrectly!");
            }
        }
        public UserDto GetUserByEmail(string email)
        {
            var _user = _context.Users.Where(x => x.Email == email).First();

            return new UserDto
            {
                IdUser = _user.Id,
                Firstname = _user.Firstname,
                Lastname = _user.Lastname,
                UserName = _user.UserName,
                Email = _user.Email,
                CurrentLocation = _user.CurrentLocation,
                Birth = _user.Birth,
                CreatedAt = _user.CreatedAt
            };
        }

        public UserDto GetUserById(long? userId)
        {
            var _user = _context.Users.Where(x => x.Id == userId).First();

            return new UserDto
            {
                IdUser = _user.Id,
                Firstname = _user.Firstname,
                Lastname = _user.Lastname,
                UserName = _user.UserName,
                Email = _user.Email,
                CurrentLocation = _user.CurrentLocation,
                Birth = _user.Birth,
                CreatedAt = _user.CreatedAt
            };
        }

        public async Task<bool> UpdateUserById(UpdateUserDto userDto)
        {
            var result = from t in _context.Users
                         where t.Id == userDto.IdUser
                         select t;


            foreach (UserEntity item in result)
            {
                item.Firstname = userDto.Firstname;
                item.Lastname = userDto.Lastname;
                item.Birth = userDto.Birth;
            }

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        static string GetDisplayName(UserRole userRole)
        {
            var type = userRole.GetType();
            var field = type.GetField(userRole.ToString());
            var attribute = Attribute.GetCustomAttribute(field, typeof(DisplayAttribute)) as DisplayAttribute;
            return attribute?.Name ?? userRole.ToString();
        }
    }
}
