using AutoMapper;
using GscareApiAspNetCore.Communication.Responses.WarningResponses;
using GscareApiAspNetCore.Domain.Enums;
using GscareApiAspNetCore.Domain.Repositories.WarningRepositories;
using GscareApiAspNetCore.Domain.Services.LoggedUser;
using GscareApiAspNetCore.Exception.ExceptionBase;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GscareApiAspNetCore.Application.UseCases.WarningUseCases
{
    public class GetAllWarningsUseCase : IGetAllWarningsUseCase
    {
        private readonly IWarningReadOnlyRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILoggedUser _loggedUser;

        public GetAllWarningsUseCase(IWarningReadOnlyRepository repository, IMapper mapper, ILoggedUser loggedUser)
        {
            _repository = repository;
            _mapper = mapper;
            _loggedUser = loggedUser;
        }

        public async Task<ResponseWarningsJson> Execute()
        {
            var loggedInUser = await _loggedUser.User();
            if (loggedInUser.UserType != RolesUserType.Company)
            {
                throw new UnauthorizedAccessException("Apenas empresas podem fazer essa operação");
            }

            var companyId = loggedInUser.CompanyId.GetValueOrDefault();

            var result = await _repository.GetAll(companyId);

            return new ResponseWarningsJson
            {
                Warning = _mapper.Map<List<ResponseShortWarningJson>>(result)
            };
        }
    }
}
