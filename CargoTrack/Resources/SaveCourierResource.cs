namespace server.CargoTrack.Resources;
public class SaveCourierResource
{
    public int PersonId { get; set; }
    public int DNI { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string BirthDay { get; set; }
    public string Email { get; set; }
    public string LicenseNumber { get; set; }
}