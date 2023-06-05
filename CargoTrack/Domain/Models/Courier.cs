namespace server.CargoTrack.Domain.Models;
public class Courier
{
    public Person Person { get; set; }
    public int PersonId { get; set; }
    public int DNI { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string BirthDay { get; set; }
    public string Email { get; set; }
    public string LicenseNumber { get; set; }
    //RelationsShip one many
    public List<Vehicle> Vehicles  { get; set; } = new List<Vehicle>(); 
    public List<License> Licenses { get; set; } = new List<License>();
    public List<Service> Services { get; set; } = new List<Service>();
}