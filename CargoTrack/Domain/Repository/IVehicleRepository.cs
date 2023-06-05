

using server.CargoTrack.Domain.Models;

namespace server.CargoTrack.App.Domain.Repository;

public interface IVehicleRepository
{
    Task<IEnumerable<Vehicle>> ListAsync();
    Task AddAsync(Vehicle vehicle);
    Task<Vehicle> FindByIdAsync(int id);
    void Update(Vehicle vehicle);
    void Remove(Vehicle vehicle);
}