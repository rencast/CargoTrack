using server.CargoTrack.Domain.Core.Communication;
using server.CargoTrack.Domain.Models;

namespace server.CargoTrack.Domain.Core;

public interface IBrandVehicleService
{
    Task<IEnumerable<BrandVehicle>> ListAsync();
    Task<BrandVehicleResponse> SaveAsync(BrandVehicle brandVehicle);
    Task<BrandVehicleResponse> UpdateAsync(int id, BrandVehicle brandVehicle);
    Task<BrandVehicleResponse> DeleteAsync(int id);
}