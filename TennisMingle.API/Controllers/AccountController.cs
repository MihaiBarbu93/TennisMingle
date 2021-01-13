using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TennisMingle.API.Data;
using TennisMingle.API.DTOs;
using TennisMingle.API.Entities;
using TennisMingle.API.Interfaces;

namespace TennisMingle.API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly AppDbContext _context;
        private readonly ITokenService _tokenService;
        private readonly ICityRepository _cityRepository;

        /* public ITokenService _tokenService { get; set; }*/
        public AccountController(AppDbContext context, ITokenService tokenService, ICityRepository cityRepository)
        {
            _tokenService = tokenService;
            _context = context;
            _cityRepository = cityRepository; 
        }
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDTO)
        {
            if (await UserExists(registerDTO.UserName)) return BadRequest("Username is taken");


            var person = new AppUser
            {
                UserName = registerDTO.UserName.ToLower(),
                
                CityId = registerDTO.City.Id,
                DateOfBirth = registerDTO.DateOfBirth,
                UserType = registerDTO.UserType
            };

            _context.Users.Add(person);
            await _context.SaveChangesAsync();
            return new UserDto
            {
                UserName = person.UserName,
                Token = _tokenService.CreateToken(person)
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _context.Users
                .Include(p=>p.Photo)
                .SingleOrDefaultAsync(x => x.UserName == loginDto.Username);

            if (user == null) return Unauthorized("Invalid username");

            return new UserDto
            {
                UserName = user.UserName,
                Token = _tokenService.CreateToken(user)
            };
        }

        private async Task<bool> UserExists(string username)
        {
            return await _context.Users.AnyAsync(x => x.UserName == username.ToLower());
        }
    }
}