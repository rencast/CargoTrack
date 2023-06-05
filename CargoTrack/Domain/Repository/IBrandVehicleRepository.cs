


using server.CargoTrack.Domain.Models;

namespace server.CargoTrack.App.Domain.Repository;

public interface IBrandVehicleRepository
{
    Task<IEnumerable<BrandVehicle>> ListAsync();
    Task AddAsync(BrandVehicle brandVehicle);
    Task<BrandVehicle> FindByIdAsync(int id);
    void Update(BrandVehicle brandVehicle);
    void Remove(BrandVehicle brandVehicle);
}