using server.CargoTrack.Domain.Models;

namespace server.CargoTrack.App.Domain.Repository;

public interface IPersonRepository
{
    Task<IEnumerable<Person>> ListAsync();
    Task AddAsync(Person person);
    Task<Person> FindByIdAsync(int id);
    void Update(Person Person);
    void Remove(Person Person);
}