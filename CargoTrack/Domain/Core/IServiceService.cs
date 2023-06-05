using server.CargoTrack.Domain.Core.Communication;
using server.CargoTrack.Domain.Models;

namespace server.CargoTrack.Domain.Core;

public interface IServiceService
{
    Task<IEnumerable<Service>> ListAsync();
    Task<ServiceResponse> SaveAsync(Service service);
    Task<ServiceResponse> UpdateAsync(int id, Service service);
    Task<ServiceResponse> DeleteAsync(int id);
}