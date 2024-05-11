using GscareApiAspNetCore.Communication.Enums;
using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Communication.Responses;
using GscareApiAspNetCore.Exception.ExceptionBase;

namespace GscareApiAspNetCore.Application.UseCases;
public class RegisterEmployeeUseCase
{
    public ResponseRegisteredEmployeeJson Execute(RequestRegisterEmployeeJson request)
    {
        Validate(request);

        return new ResponseRegisteredEmployeeJson();
    }

    private void Validate(RequestRegisterEmployeeJson request)
    {
        var validator = new RegisterEmployeeValidator();

        var result = validator.Validate(request);

        if (result.IsValid == false )
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
