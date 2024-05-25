using FluentValidation;
using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Exception;

namespace GscareApiAspNetCore.Application.UseCases;
internal class UserValidator : AbstractValidator<RequestUserJson>
{
    public UserValidator()
    {
        RuleFor(user => user.Name).NotEmpty().WithMessage(ResourceErrorMessages.FULL_NAME_IS_REQUIRED);
        RuleFor(user => user.UserType).IsInEnum().WithMessage(ResourceErrorMessages.TIME_AVAILABILITY_TYPE_IS_NOT_VALID_);
    }
}
