

using server.CargoTrack.Domain.Models;

namespace server.CargoTrack.App.Domain.Repository;

public interface ILicenseRepository
{
    Task<IEnumerable<License>> ListAsync();
    Task AddAsync(License license);
    Task<License> FindByIdAsync(int id);
    void Update(License license);
    void Remove(License license);
}