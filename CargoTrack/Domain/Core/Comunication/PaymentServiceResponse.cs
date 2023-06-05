using server.CargoTrack.Domain.Models;
using Shared.Domain.Core.Comunication;

namespace server.CargoTrack.Domain.Core.Communication;

public class PaymentServiceResponse : BaseResponse<PaymentService>
{
    public PaymentServiceResponse(PaymentService resource) : base(resource)
    {
    }

    public PaymentServiceResponse(string message) : base(message)
    {
    }
}