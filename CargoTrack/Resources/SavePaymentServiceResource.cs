namespace server.CargoTrack.Resources;
public class SavePaymentServiceResource
{
    public string CardUser { get; set; }
    public string CardCourier { get; set; }
    public int PaymentMethodId { get; set; }
}