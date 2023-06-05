namespace server.CargoTrack.Domain.Models; 
public class UserRequest
{
    public int Id { get; set; }
    //Attributes
    public string AddressStart { get; set; }
    public string AddressEnd { get; set; }
    public string ReferenceAddress { get; set; }
    public string Photo { get; set; }
    public string Description { get; set; }
    public string Date { get; set; }
    public string Hour { get; set; }
    //RelationShip
    public User User { get; set; }
    public int User_PersonId { get; set; }
    public List<Service> Services { get; set; } = new List<Service>();
    
}