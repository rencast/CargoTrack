using server.CargoTrack.Domain.Core.Communication;
using server.CargoTrack.Domain.Models;

namespace server.CargoTrack.Domain.Core;
public interface IUserService
{
    Task<IEnumerable<User>> ListAsync();
    Task<UserResponse> SaveAsync(User user);
    Task<UserResponse> DeleteAsync(int id);
}