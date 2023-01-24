using System.ComponentModel.DataAnnotations;

namespace Task6WebApp.Models;

public class LoginViewModel
{
    [Required]
    public string Login { get; set; }
}