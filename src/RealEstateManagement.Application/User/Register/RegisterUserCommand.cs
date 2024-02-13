using MediatR;
using RealEstateManagement.Application.Common.Models;

namespace RealEstateManagement.Application.Authentication.Register;

public class RegisterUserCommand(string username, string email, string password) : IRequest<Result>
{
    public string Username { get; } = username;
    public string Email { get; } = email;
    public string Password { get; } = password;
}
