using MediatR;
using RealEstateManagement.Application.Common.Interfaces;
using RealEstateManagement.Application.Common.Models;
using System.Threading;
using System.Threading.Tasks;

namespace RealEstateManagement.Application.Authentication.Register;

public class RegisterUSerCommandHandler(IUserService userService) : IRequestHandler<RegisterUserCommand, Result>
{
    private readonly IUserService _userService = userService;

    public async Task<Result> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var result = await _userService.RegisterUserAsync(request);
        return result;
    }
}
