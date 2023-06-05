namespace server.CargoTrack.Domain.Models;
public class License
{
    public int Id { get; set; }
    public string Class { get; set; }
    public string Category { get; set; }
    public Courier Courier { get; set; }
    public int Courier_PersonId { get; set; }
}