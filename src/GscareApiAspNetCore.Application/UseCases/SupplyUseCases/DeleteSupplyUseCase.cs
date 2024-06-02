using GscareApiAspNetCore.Domain.Repositories;
using GscareApiAspNetCore.Exception.ExceptionBase;
using GscareApiAspNetCore.Exception;
using GscareApiAspNetCore.Domain.Repositories.SupplyRepositories;

namespace GscareApiAspNetCore.Application.UseCases.SupplyUseCases;
public class DeleteSupplyUseCase : IDeleteSupplyUseCase
{
    private readonly ISupplyWriteOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSupplyUseCase(ISupplyWriteOnlyRepository repository, IUnitOfWork unitOfWork)
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
