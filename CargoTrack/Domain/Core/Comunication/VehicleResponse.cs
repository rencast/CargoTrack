using server.CargoTrack.Domain.Models;
using Shared.Domain.Core.Comunication;

namespace server.CargoTrack.Domain.Core.Communication;

public class VehicleResponse : BaseResponse<Vehicle>
{
    public VehicleResponse(Vehicle resource) : base(resource)
    {
    }

    public VehicleResponse(string message) : base(message)
    {
    }
}