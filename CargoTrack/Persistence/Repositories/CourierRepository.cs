using Microsoft.EntityFrameworkCore;
using server.CargoTrack.App.Domain.Repository;
using server.CargoTrack.Domain.Models;
using Shared.Persistence.Contexts;
using Shared.Persistence.Repositories;

namespace WebApplication1.App.Persistence.Repositories;
public class CourierRepository:BaseRepository,ICourierRepository
{
    public CourierRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Courier>> ListAsync()
    {
        return await _context.Couriers.ToListAsync();
    }

    public async Task AddAsync(Courier courier)
    {
       await _context.Couriers.AddAsync(courier);
    }

    public async Task<Courier> FindByIdAsync(int id)
    {
        return await _context.Couriers.FindAsync(id);
    }

    public void Update(Courier courier)
    {
        _context.Couriers.Update(courier);
    }

    public void Remove(Courier courier)
    {
        _context.Couriers.Remove(courier);
    }
}