using server.CargoTrack.Domain.Core.Communication;
using server.CargoTrack.Domain.Models;

namespace server.CargoTrack.Domain.Core;


public interface ICourierService
{
    Task<IEnumerable<Courier>> ListAsync();
    Task<CourierResponse> SaveAsync(Courier courier);
    Task<CourierResponse> UpdateAsync(int id, Courier courier);
    Task<CourierResponse> DeleteAsync(int id);
}