
using server.CargoTrack.Domain.Models;
using Shared.Domain.Core.Comunication;

namespace server.CargoTrack.Domain.Core.Communication;

public class LicenseResponse:BaseResponse<License>
{
    public LicenseResponse(License resource) : base(resource)
    {
    }

    public LicenseResponse(string message) : base(message)
    {
    }
}