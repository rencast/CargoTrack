using server.CargoTrack.Domain.Models;
using Shared.Domain.Core.Comunication;

namespace server.CargoTrack.Domain.Core.Communication;

public class PaymentMethodResponse:BaseResponse<PaymentMethod>
{
    public PaymentMethodResponse(PaymentMethod resource) : base(resource)
    {
    }

    public PaymentMethodResponse(string message) : base(message)
    {
    }
}