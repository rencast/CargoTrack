namespace server.CargoTrack.Domain.Models;
public class PaymentMethod
{
    public int Id { get; set; }
    public string Type { get; set; }
    public List<PaymentService> PaymentServices { get; set; } = new List<PaymentService>();
}