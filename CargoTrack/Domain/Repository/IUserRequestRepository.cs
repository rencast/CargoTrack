

using server.CargoTrack.Domain.Models;

namespace server.CargoTrack.App.Domain.Repository;

public interface IUserRequestRepository
{
    Task<IEnumerable<UserRequest>> ListAsync();
    Task AddAsync(UserRequest userRequest);
    Task<UserRequest> FindByIdAsync(int id);
    void Update(UserRequest userRequest);
    void Remove(UserRequest userRequest);
}