namespace server.CargoTrack.Domain.Models; 
public class User
{
    public Person Person{ get; set; }
    public int PersonId{ get; set; }
    public List<UserRequest> UserRequests { get; set; } = new List<UserRequest>();
}