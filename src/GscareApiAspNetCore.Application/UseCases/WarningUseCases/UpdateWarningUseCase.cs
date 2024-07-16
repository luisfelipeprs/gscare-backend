using AutoMapper;
using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Domain.Repositories;
using GscareApiAspNetCore.Exception.ExceptionBase;
using GscareApiAspNetCore.Exception;
using GscareApiAspNetCore.Domain.Repositories.WarningRepositories;
using GscareApiAspNetCore.Domain.Services.LoggedUser;
using GscareApiAspNetCore.Domain.Enums;
using System.Linq;
using System.Threading.Tasks;

namespace GscareApiAspNetCore.Application.UseCases.WarningUseCases
{
    public class UpdateWarningUseCase : IUpdateWarningUseCase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWarningUpdateOnlyRepository _repository;
        private readonly ILoggedUser _loggedUser;

        public UpdateWarningUseCase(IMapper mapper, IUnitOfWork unitOfWork, IWarningUpdateOnlyRepository repository, ILoggedUser loggedUser)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _repository = repository;
            _loggedUser = loggedUser;
        }

        public async Task Execute(long Id, RequestWarningJson request)
        {
            var loggedInUser = await _loggedUser.User();

            if (loggedInUser.UserType != RolesUserType.Company)
            {
                throw new UnauthorizedAccessException("Apenas empresas podem fazer essa operação");
            }

            Validate(request);

            var warning = await _repository.GetById(Id);

            if (warning is null)
            {
                throw new NotFoundException(ResourceErrorMessages.EMPLOYEE_NOT_FOUND);
            }

            if (loggedInUser.CompanyId != warning.CompanyId)
            {
                throw new UnauthorizedAccessException("Você só pode operar avisos feitos pela sua empresa");
            }

            _mapper.Map(request, warning);

            _repository.Update(warning);

            await _unitOfWork.Commit();
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
