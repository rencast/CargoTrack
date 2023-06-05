using server.CargoTrack.Domain.Models;
using Shared.Domain.Core.Comunication;

namespace server.CargoTrack.Domain.Core.Communication;

public class ServiceResponse : BaseResponse<Service>
{
    public ServiceResponse(Service resource) : base(resource)
    {
    }

    public ServiceResponse(string message) : base(message)
    {
    }
}