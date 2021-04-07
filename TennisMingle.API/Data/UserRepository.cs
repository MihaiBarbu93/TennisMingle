
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisMingle.API.Data;
using TennisMingle.API.DTOs;
using TennisMingle.API.Entities;
using TennisMingle.API.Extensions;
using TennisMingle.API.Interfaces;

namespace TennisMingle.API.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public UserRepository(AppDbContext context, IMapper mapper, UserManager<AppUser> userManager)
        {
            _mapper = mapper;
            _context = context;
            _userManager = userManager;
        }

        public async Task<MemberDto> GetMemberAsync(string username)
        {
            return await _context.Users
                .Where(x => x.UserName == username)
                .Include(x=> x.Bookings).ThenInclude(b=>b.TennisCourt).ThenInclude(tc=>tc.TennisClub)
                .Include(r => r.UserRoles)
                .ThenInclude(r => r.Role)
                .Select(u => new MemberDto
                {
                    Id = u.Id,
                    Username = u.UserName,
                    Age = u.DateOfBirth.CalculateAge(),
                    City = u.City,
                    PhotoUrl = u.Photo.Url,
                    Roles = u.UserRoles.Select(r => r.Role.Name).ToList(),
                    Bookings = u.Bookings
                })
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<MemberDto>> GetMembersAsync()
        {
            return await _context.Users
                .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<AppUser> GetUserByUsernameAsync(string username)
        {
            return await _context.Users
                .Include(p => p.Photo)
                .SingleOrDefaultAsync(x => x.UserName == username);
        }

        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {
            return await _context.Users
                .Include(p => p.Photo)
                .ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(AppUser person)
        {
            _context.Entry(person).State = EntityState.Modified;
        }
    }
}

