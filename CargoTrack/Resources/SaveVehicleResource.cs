namespace server.CargoTrack.Resources;
public class SaveVehicleResource
{
    public string Plate { get; set; }
    public string Photo { get; set; }
    public string CirculationCard { get; set; }
    public int BrandVehicleId { get; set; }
    public int Courier_PersonId { get; set; }  
}