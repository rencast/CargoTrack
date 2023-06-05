namespace server.CargoTrack.Resources;
public class ServiceResource
{
    public int Id { get; set; }
    public bool IsFinalized { get; set; }
    public int PaymentServiceId { get; set; }
    public int UserRequestId { get; set; }
    public int Courier_PersonId { get; set; }
}