namespace server.CargoTrack.Domain.Models;
public class Service
{
    public int Id { get; set; }
    public bool IsFinalized { get; set; }
    public PaymentService PaymentService { get; set; }
    public int PaymentServiceId { get; set; }
    public UserRequest UserRequest { get; set; }
    public int UserRequestId { get; set; }
    public Courier Courier { get; set; }
    public int Courier_PersonId { get; set; }
}