namespace server.CargoTrack.Domain.Models;
public class BrandVehicle
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public Vehicle Vehicle { get; set; }
}