using ApiSqlAzure.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace  ApiSqlAzure.Services
{
    public class UsersService : IUsersService
    {
        public readonly UsersContext _context;

        public UsersService(UsersContext context) => _context = context;
        
        public async Task<Users> CreateAsync(Users users)
        {
            _context.Add(users);
            await _context.SaveChangesAsync();
            return users;
        }

        public async Task<IEnumerable<Users>> GetAllAsync()=> await _context.Users.AsNoTracking().ToListAsync();
        
        public async Task<Users?> GetByIdAsync(string id) => await _context.Users.FirstOrDefaultAsync(u => u.id == id );

        public async Task<Users> UpdateAsync(Users users)
        {
            _context.Update(users);
            await _context.SaveChangesAsync();
            return users;
        }

        public async Task<IEnumerable<Users>> DeleteAsync(string id)
        {
            var userToDelete = new Users {id = id };
            _context.Entry(userToDelete).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return await _context.Users.ToListAsync();
        }

    }
}