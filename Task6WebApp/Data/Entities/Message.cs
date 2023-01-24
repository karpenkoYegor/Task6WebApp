namespace Task6WebApp.Data.Entities;

public class Message
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public string FromUser { get; set; }
    public int ToUser { get; set; }
    public User User { get; set; }
}