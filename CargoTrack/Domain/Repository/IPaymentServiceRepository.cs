


using server.CargoTrack.Domain.Models;

namespace server.CargoTrack.App.Domain.Repository;

public interface IPaymentServiceRepository
{
    Task<IEnumerable<PaymentService>> ListAsync();
    Task AddAsync(PaymentService paymentService);
    Task<PaymentService> FindByIdAsync(int id);
    void Update(PaymentService paymentService);
    void Remove(PaymentService paymentService);
}