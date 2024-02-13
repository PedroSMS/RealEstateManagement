using System.Collections.Generic;

namespace RealEstateManagement.Application.Common.Models;

public class Result
{
    public static Result Success() => new(true, []);
    public static Result Failure(IEnumerable<string> errors) => new(false, errors);

    private Result(bool isSuccess, IEnumerable<string> errors) 
    {
        IsSuccess = isSuccess;
        Errors = errors;
    }

    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public IEnumerable<string> Errors { get; }
}
