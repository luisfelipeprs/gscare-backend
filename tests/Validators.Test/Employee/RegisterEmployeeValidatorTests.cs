using CommonTestUtils.Requests;
using FluentAssertions;
using GscareApiAspNetCore.Application.UseCases;
using GscareApiAspNetCore.Application.UseCases.EmployeeUseCases;
using GscareApiAspNetCore.Communication.Enums;
using GscareApiAspNetCore.Exception;

namespace Validators.Test.Employee;
public class RegisterEmployeeValidatorTests
{
    [Fact]
    public void Success()
    {
        //Arrange
        var validator = new EmployeeValidator();
        var request = RequestRegisterEmployeeJsonBuilder.Build();

        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.Should().BeTrue();
    }

    [Theory]
    [InlineData("    ")]
    [InlineData("")]
    [InlineData(null)]
    public void Error_NomeCompleto_Empty(string fullName)
    {
        //Arrange
        var validator = new EmployeeValidator();
        var request = RequestRegisterEmployeeJsonBuilder.Build();
        request.NomeCompleto = fullName;

        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.FULL_NAME_IS_REQUIRED));
    }

    [Fact]
    public void Error_DisponibilidadeDeHorario_Invalid()
    {
        //Arrange
        var validator = new EmployeeValidator();
        var request = RequestRegisterEmployeeJsonBuilder.Build();
        request.DisponibilidadeDeHorario = (DisponibilidadeDeHorarioType)800;

        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.TIME_AVAILABILITY_TYPE_IS_NOT_VALID_));
    }
}
