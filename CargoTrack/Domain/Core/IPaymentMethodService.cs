using server.CargoTrack.Domain.Core.Communication;
using server.CargoTrack.Domain.Models;

namespace server.CargoTrack.Domain.Core;

public interface IPaymentMethodService
{
    Task<IEnumerable<PaymentMethod>> ListAsync();
    Task<PaymentMethodResponse> SaveAsync(PaymentMethod paymentMethod);
    Task<PaymentMethodResponse> UpdateAsync(int id, PaymentMethod paymentMethod);
    Task<PaymentMethodResponse> DeleteAsync(int id);
}