using server.CargoTrack.Domain.Models;
using Shared.Domain.Core.Comunication;

namespace server.CargoTrack.Domain.Core.Communication;

public class BrandVehicleResponse:BaseResponse<BrandVehicle>
{
    public BrandVehicleResponse(BrandVehicle resource) : base(resource)
    {
    }

    public BrandVehicleResponse(string message) : base(message)
    {
    }
}