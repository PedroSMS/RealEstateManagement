using RealEstateManagement.Application.Authentication.Register;
using RealEstateManagement.Application.Common.Models;
using System.Threading.Tasks;

namespace RealEstateManagement.Application.Common.Interfaces;

public interface IUserService
{
    Task<Result> RegisterUserAsync(RegisterUserCommand command);
}
