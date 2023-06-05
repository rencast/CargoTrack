using server.CargoTrack.Domain.Models;
using Shared.Domain.Core.Comunication;

namespace server.CargoTrack.Domain.Core.Communication;

public class PersonResponse:BaseResponse<Person>
{
    public PersonResponse(Person resource) : base(resource)
    {
    }

    public PersonResponse(string message) : base(message)
    {
    }
}