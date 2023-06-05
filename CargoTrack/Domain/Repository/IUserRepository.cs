
using server.CargoTrack.Domain.Models;

namespace server.CargoTrack.App.Domain.Repository;

public interface IUserRepository
{
    Task<IEnumerable<User>> ListAsync();
    Task AddAsync(User userService);
    Task<User> FindByIdAsync(int id);
    void Remove(User userService);
}