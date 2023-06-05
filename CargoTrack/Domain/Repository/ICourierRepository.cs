using server.CargoTrack.Domain.Models;

namespace server.CargoTrack.App.Domain.Repository;

public interface ICourierRepository
{
    Task<IEnumerable<Courier>> ListAsync();
    Task AddAsync(Courier courier);
    Task<Courier> FindByIdAsync(int id);
    void Update(Courier courier);
    void Remove(Courier courier);
}