using server.CargoTrack.Domain.Models;
using Shared.Domain.Core.Comunication;

namespace server.CargoTrack.Domain.Core.Communication;

public class UserRequestResponse : BaseResponse<UserRequest>
{
    public UserRequestResponse(UserRequest resource) : base(resource)
    {
    }

    public UserRequestResponse(string message) : base(message)
    {
    }
}