using GscareApiAspNetCore.Domain.Entities;
using GscareApiAspNetCore.Domain.Enums;
using GscareApiAspNetCore.Domain.Repositories;
using GscareApiAspNetCore.Domain.Repositories.WarningRepositories;
using GscareApiAspNetCore.Domain.Services.LoggedUser;
using GscareApiAspNetCore.Exception;
using GscareApiAspNetCore.Exception.ExceptionBase;
using System.Threading.Tasks;

namespace GscareApiAspNetCore.Application.UseCases.WarningUseCases
{
    public class DeleteWarningUseCase : IDeleteWarningUseCase
    {
        private readonly IWarningReadOnlyRepository _repositoryRead;
        private readonly IWarningWriteOnlyRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggedUser _loggedUser;

        public DeleteWarningUseCase(IWarningWriteOnlyRepository repository, IUnitOfWork unitOfWork, ILoggedUser loggedUser, IWarningReadOnlyRepository repositoryRead)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _loggedUser = loggedUser;
            _repositoryRead = repositoryRead;
        }

        public async Task Execute(long id)
        {
            var loggedInUser = await _loggedUser.User();
            if (loggedInUser.UserType != RolesUserType.Company)
            {
                throw new UnauthorizedAccessException("Apenas empresas podem fazer essa operação");
            }

            var resultRead = await _repositoryRead.GetById(id);

            if (resultRead is null)
            {
                throw new NotFoundException("Warning não encontrada");
            }

            if (loggedInUser.CompanyId != resultRead.CompanyId)
            {
                throw new UnauthorizedAccessException("Você só pode operar avisos feitos pela sua empresa");
            }

            var result = await _repository.Delete(id);

            if (!result)
            {
                throw new NotFoundException(ResourceErrorMessages.EMPLOYEE_NOT_FOUND);
            }

            await _unitOfWork.Commit();
        }
    }
}
