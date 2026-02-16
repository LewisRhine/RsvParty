using System.ComponentModel.DataAnnotations;

namespace RsvParty.Models;

public class RegisterModel
{
    [Required] public string Email { get; set; }
    [Required] public string Password { get; set; }
}

public class LoginModel
{
    [Required] public string Email { get; set; }
    [Required] public string Password { get; set; }
}
