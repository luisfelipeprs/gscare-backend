using AutoMapper;
using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Communication.Responses.WarningResponses;
using GscareApiAspNetCore.Domain.Entities;
using GscareApiAspNetCore.Domain.Enums;
using GscareApiAspNetCore.Domain.Repositories;
using GscareApiAspNetCore.Domain.Repositories.WarningRepositories;
using GscareApiAspNetCore.Domain.Services.LoggedUser;
using GscareApiAspNetCore.Exception.ExceptionBase;
using System.Threading.Tasks;

namespace GscareApiAspNetCore.Application.UseCases.WarningUseCases
{
    public class RegisterWarningUseCase : IRegisterWarningUseCase
    {
        private readonly IWarningWriteOnlyRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILoggedUser _loggedUser;

        public RegisterWarningUseCase(IWarningWriteOnlyRepository repository, IUnitOfWork unitOfWork, IMapper mapper, ILoggedUser loggedUser)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _loggedUser = loggedUser;
        }

        public async Task<ResponseRegisteredWarningJson> Execute(RequestWarningJson request)
        {
            var loggedInUser = await _loggedUser.User();

            if (loggedInUser.UserType != RolesUserType.Company)
            {
                throw new UnauthorizedAccessException("Apenas empresas podem fazer essa operação");
            }

            Validate(request);

            var entity = _mapper.Map<Warning>(request);

            entity.CompanyId = loggedInUser.CompanyId.GetValueOrDefault();

            await _repository.Add(entity);

            await _unitOfWork.Commit();

            return _mapper.Map<ResponseRegisteredWarningJson>(entity);
        }

        private void Validate(RequestWarningJson request)
        {
            var validator = new WarningValidator();

            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
