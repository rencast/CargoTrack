namespace server.CargoTrack.Domain.Models;
public class PaymentService
{
    public int Id { get; set; }
    public string CardUser { get; set; }
    public string CardCourier { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public int PaymentMethodId { get; set; }
    public Service Service { get; set; }
}