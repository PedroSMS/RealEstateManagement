using Microsoft.AspNetCore.Identity;
using RealEstateManagement.Application.Authentication.Register;
using RealEstateManagement.Application.Common.Interfaces;
using RealEstateManagement.Application.Common.Models;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateManagement.Infrastructure.Service;

public class UserService(UserManager<IdentityUser> userManager) : IUserService
{
    private readonly UserManager<IdentityUser> _userManager = userManager;

    public async Task<Result> RegisterUserAsync(RegisterUserCommand command)
    {
        var result = await _userManager.CreateAsync(new()
        {
            Email = command.Email,
        }, command.Password);

        return result.Succeeded
            ? Result.Success()
            : Result.Failure(result.Errors.Select(e => e.Description));
    }
}
