using Microsoft.EntityFrameworkCore;
using server.CargoTrack.App.Domain.Repository;
using server.CargoTrack.Domain.Models;
using Shared.Persistence.Contexts;
using Shared.Persistence.Repositories;

namespace WebApplication1.App.Persistence.Repositories;

public class PersonRepository:BaseRepository,IPersonRepository
{
    public PersonRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Person>> ListAsync()
    {
        return await _context.Persons.ToListAsync();
    }

    public async Task AddAsync(Person person)
    {
        await _context.Persons.AddAsync(person);
    }

    public async Task<Person> FindByIdAsync(int id)
    {
        return await _context.Persons.FindAsync(id);
    }

    public void Update(Person person)
    {
        _context.Persons.Update(person);
    }

    public void Remove(Person person)
    {
        _context.Persons.Remove(person);
    }
}