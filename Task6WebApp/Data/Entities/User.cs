using Microsoft.AspNetCore.Identity;

namespace Task6WebApp.Data.Entities;

public class User : IdentityUser
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Message> Messages { get; set; }
}