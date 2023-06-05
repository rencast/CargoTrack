using Microsoft.EntityFrameworkCore;
using server.CargoTrack.App.Domain.Repository;
using server.CargoTrack.Domain.Models;
using Shared.Persistence.Contexts;
using Shared.Persistence.Repositories;

namespace WebApplication1.App.Persistence.Repositories;

public class UserRequestRepository : BaseRepository,IUserRequestRepository
{
    public UserRequestRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<UserRequest>> ListAsync()
    {
        return await _context.UserRequests.ToListAsync();
    }

    public async Task AddAsync(UserRequest userRequest)
    {
        await _context.UserRequests.AddAsync(userRequest);
    }

    public async Task<UserRequest> FindByIdAsync(int id)
    {
        return await _context.UserRequests.FindAsync(id);
    }

    public void Update(UserRequest userRequest)
    {
        _context.UserRequests.Update(userRequest);
    }

    public void Remove(UserRequest userRequest)
    {
        _context.UserRequests.Remove(userRequest);
    }
}