using server.CargoTrack.Domain.Core.Communication;
using server.CargoTrack.Domain.Models;

namespace server.CargoTrack.Domain.Core;

public interface IVehicleService
{
    Task<IEnumerable<Vehicle>> ListAsync();
    Task<VehicleResponse> SaveAsync(Vehicle vehicle);
    Task<VehicleResponse> UpdateAsync(int id, Vehicle vehicle);
    Task<VehicleResponse> DeleteAsync(int id);
}