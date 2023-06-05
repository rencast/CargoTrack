using server.CargoTrack.Domain.Core.Communication;
using server.CargoTrack.Domain.Models;

namespace server.CargoTrack.Domain.Core;

public interface IUserRequestService
{
    Task<IEnumerable<UserRequest>> ListAsync();
    Task<UserRequestResponse> SaveAsync(UserRequest userRequest);
    Task<UserRequestResponse> UpdateAsync(int id, UserRequest userRequest);
    Task<UserRequestResponse> DeleteAsync(int id);
}