using AutoMapper;
using GscareApiAspNetCore.Communication.Responses.WarningResponses;
using GscareApiAspNetCore.Domain.Enums;
using GscareApiAspNetCore.Domain.Repositories.WarningRepositories;
using GscareApiAspNetCore.Domain.Services.LoggedUser;
using GscareApiAspNetCore.Exception;
using GscareApiAspNetCore.Exception.ExceptionBase;
using System.Threading.Tasks;

namespace GscareApiAspNetCore.Application.UseCases.WarningUseCases
{
    public class GetWarningByIdUseCase : IGetWarningByIdUseCase
    {
        private readonly IWarningReadOnlyRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILoggedUser _loggedUser;

        public GetWarningByIdUseCase(IWarningReadOnlyRepository repository, IMapper mapper, ILoggedUser loggedUser)
        {
            _repository = repository;
            _mapper = mapper;
            _loggedUser = loggedUser;
        }

        public async Task<ResponseWarningJson> Execute(long id)
        {
            var loggedInUser = await _loggedUser.User();
            if (loggedInUser.UserType != RolesUserType.Company)
            {
                throw new UnauthorizedAccessException("Apenas empresas podem fazer essa operação");
            }

            var result = await _repository.GetById(id);

            if (result is null)
            {
                throw new NotFoundException("Warning não encontrada");
            }

            if (loggedInUser.CompanyId != result.CompanyId)
            {
                throw new UnauthorizedAccessException("Você só pode operar avisos feitos pela sua empresa");
            }

            return _mapper.Map<ResponseWarningJson>(result);
        }
    }
}
