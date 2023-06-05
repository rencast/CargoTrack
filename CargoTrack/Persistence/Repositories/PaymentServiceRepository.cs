using Microsoft.EntityFrameworkCore;
using server.CargoTrack.App.Domain.Repository;
using server.CargoTrack.Domain.Models;
using Shared.Persistence.Contexts;
using Shared.Persistence.Repositories;

namespace WebApplication1.App.Persistence.Repositories;

public class PaymentServiceRepository:BaseRepository,IPaymentServiceRepository
{
    public PaymentServiceRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<PaymentService>> ListAsync()
    {
        return await _context.PaymentServices.ToListAsync();
    }

    public async Task AddAsync(PaymentService paymentService)
    {
        await _context.PaymentServices.AddAsync(paymentService);
    }

    public async Task<PaymentService> FindByIdAsync(int id)
    {
        return await _context.PaymentServices.FindAsync(id);
    }

    public void Update(PaymentService paymentService)
    {
        _context.PaymentServices.Update(paymentService);
    }

    public void Remove(PaymentService paymentService)
    {
        _context.PaymentServices.Remove(paymentService);
    }
}