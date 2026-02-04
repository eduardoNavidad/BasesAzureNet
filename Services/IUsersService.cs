using ApiSqlAzure.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiSqlAzure.Services
{
    public interface IUsersService
    {
        Task<IEnumerable<Users>> GetAllAsync();
        Task<Users?> GetByIdAsync(string id);
        Task<Users> CreateAsync(Users users);

        Task<Users> UpdateAsync(Users users);

        Task<IEnumerable<Users>> DeleteAsync(string id);

    }
}