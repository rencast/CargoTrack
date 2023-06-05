namespace server.CargoTrack.Resources;
public class SaveServiceResource
{
    public bool IsFinalized { get; set; }
    public int PaymentServiceId { get; set; }
    public int UserRequestId { get; set; }
    public int Courier_PersonId { get; set; }
}