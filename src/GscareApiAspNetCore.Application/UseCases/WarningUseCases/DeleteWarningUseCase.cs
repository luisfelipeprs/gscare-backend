using GscareApiAspNetCore.Domain.Repositories;
using GscareApiAspNetCore.Domain.Repositories.WarningRepositories;
using GscareApiAspNetCore.Exception;
using GscareApiAspNetCore.Exception.ExceptionBase;

namespace GscareApiAspNetCore.Application.UseCases.WarningUseCases;
public class DeleteWarningUseCase : IDeleteWarningUseCase
{
    private readonly IWarningWriteOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteWarningUseCase(IWarningWriteOnlyRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(long id)
    {
        var result = await _repository.Delete(id);

        if (result == false)
        {
            throw new NotFoundException(ResourceErrorMessages.EMPLOYEE_NOT_FOUND);
        }

        await _unitOfWork.Commit();
    }
}
