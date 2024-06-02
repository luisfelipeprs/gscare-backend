using GscareApiAspNetCore.Domain.Repositories;
using GscareApiAspNetCore.Domain.Repositories.ServiceRepositories;
using GscareApiAspNetCore.Exception;
using GscareApiAspNetCore.Exception.ExceptionBase;

namespace GscareApiAspNetCore.Application.UseCases.ServiceUseCases;
public class DeleteServiceUseCase : IDeleteServiceUseCase
{
    private readonly IServiceWriteOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteServiceUseCase(IServiceWriteOnlyRepository repository, IUnitOfWork unitOfWork)
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
