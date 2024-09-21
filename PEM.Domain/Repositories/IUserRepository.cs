using PEM.Domain.Entities;

namespace PEM.Domain.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User> GetByIdAsync(Guid userId);
        Task<User> GetByEmailAsync(string email);
    }
}
