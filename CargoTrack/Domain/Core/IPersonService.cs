using server.CargoTrack.Domain.Core.Communication;
using server.CargoTrack.Domain.Models;

namespace server.CargoTrack.Domain.Core;

public interface IPersonService
{
    Task<IEnumerable<Person>> ListAsync();
    Task<PersonResponse> SaveAsync(Person person);
    Task<PersonResponse> UpdateAsync(int id, Person person);
    Task<PersonResponse> DeleteAsync(int id);
}