using AutoMapper;
using GscareApiAspNetCore.Communication.Responses.UserResponses;
using GscareApiAspNetCore.Domain.Entities;
using GscareApiAspNetCore.Domain.Enums;
using GscareApiAspNetCore.Domain.Repositories.UserRepositories;
using GscareApiAspNetCore.Domain.Services.LoggedUser;
using GscareApiAspNetCore.Exception.ExceptionBase;

namespace GscareApiAspNetCore.Application.UseCases.UserUseCases;
internal class GetUserProfileUseCase : IGetUserProfileUseCase
{
    private readonly IUserReadOnlyRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILoggedUser _loggedUser;

    public GetUserProfileUseCase(IUserReadOnlyRepository repository, IMapper mapper, ILoggedUser loggedUser)
    {
        _loggedUser = loggedUser;
        _repository = repository;
        _mapper = mapper;
    }

    async public Task<ResponseUserProfileJson> Execute()
    {
        var loggedInUser = await _loggedUser.User();
        var user = await _repository.GetByIdWithRelations(loggedInUser.Id);

        if (user == null)
        {
            throw new NotFoundException("User not found");
        }

        var response = _mapper.Map<ResponseUserProfileJson>(user);

        return response;
    }

    // No serviço ou controlador adequado que lida com a lógica de autenticação e autorização
    public async Task<Company?> GetCompanyAssociatedWithLoggedInUser(long userId)
    {
        var user = await _repository.GetByIdWithRelations(userId);
        if (user == null)
        {
            throw new ArgumentException("User not found", nameof(userId));
        }

        switch (user.UserType)
        {
            case RolesUserType.Employee:
                return user.Employee?.CurrentCompany;
            case RolesUserType.Patient:
                return user.Patient?.CurrentCompany;
            default:
                throw new InvalidOperationException("User is not an Employee or Patient.");
        }
    }

}
