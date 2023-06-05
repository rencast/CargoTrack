namespace server.CargoTrack.Resources;
public class SaveUserRequestResource
{
    public string AddressStart { get; set; }
    public string AddressEnd { get; set; }
    public string ReferenceAddress { get; set; }
    public string Photo { get; set; }
    public string Description { get; set; }
    public string Date { get; set; }
    public string Hour { get; set; }
    public int User_PersonId { get; set; }
}