using Microsoft.EntityFrameworkCore;
using server.CargoTrack.App.Domain.Repository;
using server.CargoTrack.Domain.Models;
using Shared.Persistence.Contexts;
using Shared.Persistence.Repositories;

namespace serer.CargoTrack.Persistence.Repositories;
public class BrandVehicleRepository: BaseRepository,IBrandVehicleRepository
{
    public BrandVehicleRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<BrandVehicle>> ListAsync()
    {
        return await _context.BrandVehicles.ToListAsync();
    }

    public async Task AddAsync(BrandVehicle brandVehicle)
    {
        await _context.BrandVehicles.AddAsync(brandVehicle);
    }

    public async Task<BrandVehicle> FindByIdAsync(int id)
    {
        return await _context.BrandVehicles.FindAsync(id);
    }

    public void Update(BrandVehicle brandVehicle)
    {
        _context.BrandVehicles.Update(brandVehicle);
    }

    public void Remove(BrandVehicle brandVehicle)
    {
        _context.BrandVehicles.Remove(brandVehicle);
    }
}
