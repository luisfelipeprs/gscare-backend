using GscareApiAspNetCore.Domain.Repositories;
using GscareApiAspNetCore.Exception;
using GscareApiAspNetCore.Exception.ExceptionBase;

namespace GscareApiAspNetCore.Application.UseCases;
public class DeleteCompanyUseCase : IDeleteCompanyUseCase
{
    private readonly ICompanyWriteOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCompanyUseCase(ICompanyWriteOnlyRepository repository, IUnitOfWork unitOfWork)
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
