using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealEstateManagement.Application.Authentication.Register;

namespace RealEstateManagement.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpPost("register")]
    public async Task<IResult> Register([FromServices]IMediator mediator, [FromBody]RegisterUserRequest request)
    {
        var result = await mediator.Send(request.ToCommand());

        return result.IsSuccess
            ? Results.NoContent() : Results.BadRequest(result.Errors);
    }
}
