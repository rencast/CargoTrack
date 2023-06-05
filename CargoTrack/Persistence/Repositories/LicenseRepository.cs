
using Microsoft.EntityFrameworkCore;
using server.CargoTrack.App.Domain.Repository;
using server.CargoTrack.Domain.Models;
using Shared.Persistence.Contexts;
using Shared.Persistence.Repositories;

namespace WebApplication1.App.Persistence.Repositories;

public class LicenseRepository:BaseRepository, ILicenseRepository
{
    public LicenseRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<License>> ListAsync()
    {
        return await _context.Licenses.ToListAsync();
    }

    public async Task AddAsync(License license)
    {
        await _context.Licenses.AddAsync(license);
    }

    public async Task<License> FindByIdAsync(int id)
    {
        return await _context.Licenses.FindAsync(id);
    }

    public void Update(License license)
    {
        _context.Licenses.Update(license);
    }

    public void Remove(License license)
    {
        _context.Licenses.Remove(license);
    }
}