namespace server.CargoTrack.Domain.Models;
public class Person
{
    public int Id { get; set; }
    public string Phone{ get; set; }
    public User User { get; set; }
    public Courier Courier { get; set; }
}