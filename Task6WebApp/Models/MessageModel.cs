using Task6WebApp.Data.Entities;

namespace Task6WebApp.Models;

public class MessageModel
{
    public Message Message { get; set; }
    public User FromUser { get; set; }
}