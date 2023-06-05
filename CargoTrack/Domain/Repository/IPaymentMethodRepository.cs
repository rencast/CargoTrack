using server.CargoTrack.Domain.Models;

namespace server.CargoTrack.App.Domain.Repository;

public interface IPaymentMethodRepository
{
    Task<IEnumerable<PaymentMethod>> ListAsync();
    Task AddAsync(PaymentMethod paymentMethod);
    Task<PaymentMethod> FindByIdAsync(int id);
    void Update(PaymentMethod paymentMethod);
    void Remove(PaymentMethod paymentMethod);
}