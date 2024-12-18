using Api_TikTok.Model;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Api_TikTok.Dto;

namespace Api_TikTok.Repository
{
    public interface UserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<User?> GetByEmailAsync(string email);
        Task<bool> CreateAsync(User user);
        Task<bool> UpdateAsync(User user);

    }
}
