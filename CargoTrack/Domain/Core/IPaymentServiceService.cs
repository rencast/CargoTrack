using server.CargoTrack.Domain.Core.Communication;
using server.CargoTrack.Domain.Models;

namespace server.CargoTrack.Domain.Core;


public interface IPaymentServiceService
{
    Task<IEnumerable<PaymentService>> ListAsync();
    Task<PaymentServiceResponse> SaveAsync(PaymentService paymentService);
    Task<PaymentServiceResponse> UpdateAsync(int id, PaymentService paymentService);
    Task<PaymentServiceResponse> DeleteAsync(int id);
}