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
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ITokenService _tokenService;

        /* public ITokenService _tokenService { get; set; }*/
        public AccountController(AppDbContext context, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _context = context;
        }
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDTO)
        {
            if (await UserExists(registerDTO.UserName)) return BadRequest("Username is taken");

            using var hmac = new HMACSHA512();

            var person = new AppUser
            {
                UserName = registerDTO.UserName.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDTO.Password)),
                PasswordSalt = hmac.Key
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
            var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == loginDto.Username);

            if (user == null) return Unauthorized("Invalid username");

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password");
            }

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