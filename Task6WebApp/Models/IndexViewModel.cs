using System.ComponentModel.DataAnnotations;
using Task6WebApp.Data.Entities;

namespace Task6WebApp.Models;

public class IndexViewModel
{
    
    public List<User> Users { get; set; }
    public string MessageToUser { get; set; }
    public string MessageTitle { get; set; }
    public string Message { get; set; }
    public List<Message> MessageForUser { get; set; }
    
}