
using server.CargoTrack.Domain.Core.Communication;
using server.CargoTrack.Domain.Models;

namespace server.CargoTrack.Domain.Core;

public interface ILicenseService
{
    Task<IEnumerable<License>> ListAsync();
    Task<LicenseResponse> SaveAsync(License license);
    Task<LicenseResponse> UpdateAsync(int id, License license);
    Task<LicenseResponse> DeleteAsync(int id);
}