

using server.CargoTrack.Domain.Models;

namespace server.CargoTrack.App.Domain.Repository;

public interface IServiceRepository
{
    Task<IEnumerable<Service>> ListAsync();
    Task AddAsync(Service service);
    Task<Service> FindByIdAsync(int id);
    void Update(Service service);
    void Remove(Service service);
}