namespace server.CargoTrack.Resources;
public class PaymentServiceResource
{
    public int Id { get; set; }
    public string CardUser { get; set; }
    public string CardCourier { get; set; }
    public int PaymentMethodId { get; set; }
}