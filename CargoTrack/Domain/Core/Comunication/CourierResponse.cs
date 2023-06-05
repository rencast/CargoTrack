using server.CargoTrack.Domain.Models;
using Shared.Domain.Core.Comunication;

namespace server.CargoTrack.Domain.Core.Communication;

public class CourierResponse: BaseResponse<Courier>
{
    public CourierResponse(Courier resource) : base(resource)
    {
    }

    public CourierResponse(string message) : base(message)
    {
    }
}