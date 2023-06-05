using server.CargoTrack.Domain.Models;
using Shared.Domain.Core.Comunication;

namespace server.CargoTrack.Domain.Core.Communication;

public class UserResponse:BaseResponse<User>
{
    public UserResponse(User resource) : base(resource)
    {
    }

    public UserResponse(string message) : base(message)
    {
    }
}