using System.ComponentModel.DataAnnotations;

namespace RealEstateManagement.Application.Authentication.Register;

public class RegisterUserRequest
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Email { get; set; }
    public string Password { get; set; }

    public RegisterUserCommand ToCommand() => new(Username, Email, Password);
}
