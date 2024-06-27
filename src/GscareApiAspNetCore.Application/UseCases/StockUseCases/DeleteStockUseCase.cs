using GscareApiAspNetCore.Domain.Repositories;
using GscareApiAspNetCore.Domain.Repositories.StockRepositories;
using GscareApiAspNetCore.Exception.ExceptionBase;

namespace GscareApiAspNetCore.Application.UseCases.StockUseCases;
public class DeleteStockUseCase : IDeleteStockUseCase
{
    private readonly IStockWriteOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteStockUseCase(IStockWriteOnlyRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(long id)
    {
        var result = await _repository.Delete(id);

        if (result == false)
        {
            throw new NotFoundException("STOCK_NOT_FOUND");
        }

        await _unitOfWork.Commit();
    }
}
